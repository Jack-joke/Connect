/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.videochat;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.os.Handler;
import android.os.Vibrator;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.VideoChat;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.squareup.picasso.Picasso;

public class IncomingCallActivity extends Activity implements OnClickListener {

	private ImageButton answerCallButton, rejectCallButton ,volumeControlButton;
	private TextView callerNameTextView, callPlaceHolder;
	private ProfileRoundedImageView buddyProfileImageView;
	private String roomName, buddyId;
	private Handler handler;
	private Runnable incomingTimeOutRunnable;
	public static IncomingCallActivity incomingCallActivity;
	private Vibrator vibrator;
	private SessionData session;
	private boolean isAudioOnlyCall;
	private Window wind;
    private boolean isRinging = true;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_incoming_call);
		incomingCallActivity = this;

		try {
			wind = this.getWindow();
			wind.addFlags(WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD);
			wind.addFlags(WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED);
			wind.addFlags(WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);
		}catch (Exception e){
			e.printStackTrace();
		}


		Intent intent = getIntent();
		roomName = intent.getStringExtra(CometChatKeys.AVchatKeys.ROOM_NAME);
		buddyId = intent.getStringExtra(CometChatKeys.AVchatKeys.CALLER_ID);
		isAudioOnlyCall = intent.getBooleanExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, false);
		answerCallButton = (ImageButton) findViewById(R.id.buttonAnswerCall);
		rejectCallButton = (ImageButton) findViewById(R.id.buttonRejectCall);
		callerNameTextView = (TextView) findViewById(R.id.textViewCallerName);
        volumeControlButton = (ImageButton) findViewById(R.id.buttonSpeaker);
        buddyProfileImageView = (ProfileRoundedImageView) findViewById(R.id.imageViewBuddyProfilePicture);

		callPlaceHolder = (TextView) findViewById(R.id.textViewCallPlaceholder);

		rejectCallButton.setOnClickListener(this);
		answerCallButton.setOnClickListener(this);

        rejectCallButton.getBackground().setColorFilter(Color.parseColor("#eb5160"), PorterDuff.Mode.SRC_ATOP);
        answerCallButton.getBackground().setColorFilter(Color.parseColor("#36b581"), PorterDuff.Mode.SRC_ATOP);
        volumeControlButton.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);


        volumeControlButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {

                if(isRinging) {
                    CommonUtils.stopVibrate(IncomingCallActivity.this);
                    CommonUtils.stopRingtone();
                    volumeControlButton.setImageResource(R.drawable.ic_mutespeaker);
                    isRinging = false;
                }else{
                    CommonUtils.playRingtone(IncomingCallActivity.this, "incoming_call_sound.wav");
                    if (!session.isVibrateOn()) {
                        long pattern[] = { 0, 800, 200, 500, 200, 500, 200 };
                        vibrator = CommonUtils.getVibratorInstance(IncomingCallActivity.this);
                        handler.postDelayed(incomingTimeOutRunnable, LocalConfig.INCOMING_CALL_TIMEOUT);
                        vibrator.vibrate(pattern, 1);
                        session.setVibrateOn(true);
                    }
                    volumeControlButton.setImageResource(R.drawable.ic_volume_control);
                    isRinging = true;
                }
            }

        });
		/* Reset call duration value */
		session = SessionData.getInstance();
		session.setAVChatCallStartTime(0);

        if(buddyId == null){
            buddyId = PreferenceHelper.get("FCMBuddyID");
        }
		Buddy buddy = Buddy.getBuddyDetails(Long.parseLong(buddyId));
		if (null != buddy) {
            if (buddy.name.isEmpty()){
                callerNameTextView.setText("");
            }else{
                callerNameTextView.setText(buddy.name);
            }
			Picasso.with(getApplicationContext()).load(buddy.avatarURL).placeholder(R.drawable.default_avatar)
					.into(buddyProfileImageView);
		}

        if(intent.hasExtra(CometChatKeys.AVchatKeys.CALLER_NAME)){
            callerNameTextView.setText(intent.getStringExtra(CometChatKeys.AVchatKeys.CALLER_NAME));
        }


		if (null != JsonPhp.getInstance().getLang()) {
			callPlaceHolder.setText(JsonPhp.getInstance().getLang().getMobile().get44());
		}

		handler = new Handler();
		incomingTimeOutRunnable = new Runnable() {

			@Override
			public void run() {
				session.setAvchatStatus(0);
				finish();
				sendNoAnswerAjax();
			}
		};

		if (!session.isVibrateOn()) {
			long pattern[] = { 0, 800, 200, 500, 200, 500, 200 };
			vibrator = CommonUtils.getVibratorInstance(this);
			handler.postDelayed(incomingTimeOutRunnable, LocalConfig.INCOMING_CALL_TIMEOUT);
			vibrator.vibrate(pattern, 1);
			session.setVibrateOn(true);
		}
		session.setAvchatStatus(1);
		CommonUtils.playRingtone(this, "incoming_call_sound.wav");
	}

	private void sendNoAnswerAjax() {
		VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioOnlyCall ? URLFactory.getAudioChatURL()
				: URLFactory.getAVChatURL());

		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, buddyId);
		vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.NO_ANSWER_ACTION);
		vHelper.sendAjax();

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.buttonAnswerCall:
			VideoChat.startVideoCall(roomName, true, !isAudioOnlyCall, this, VideoChatActivity.class,
					buddyId);
			CommonUtils.stopVibrate(this);
			CommonUtils.stopRingtone();
			sendAcceptedAjax();
			finish();
			break;
		case R.id.buttonRejectCall:
			rejectIncomingCall();
			CommonUtils.stopVibrate(this);
			CommonUtils.stopRingtone();
			session.setAvchatStatus(0);
			finish();
			break;
		default:
			break;
		}
	}

	private void rejectIncomingCall() {
		cancelIncomingCallTimer();
		VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioOnlyCall ? URLFactory.getAudioChatURL()
				: URLFactory.getAVChatURL());
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, buddyId);
		vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.REJECTCALL_ACTION);
		vHelper.sendAjax();

	}

	/**
	 * Send an accept acknowledgment to the server.
	 */
	private void sendAcceptedAjax() {
		VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioOnlyCall ? URLFactory.getAudioChatURL()
				: URLFactory.getAVChatURL());

		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, buddyId);
		vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, CometChatKeys.AVchatKeys.ACCEPTED);
		vHelper.sendCallBack(false);
		vHelper.sendAjax();

	}

	@Override
	public void finish() {
		super.finish();
		CommonUtils.stopRingtone();
		CommonUtils.stopVibrate(getApplicationContext());
		cancelIncomingCallTimer();
	}

	private void cancelIncomingCallTimer() {
		if (null != handler && null != incomingTimeOutRunnable) {
			handler.removeCallbacks(incomingTimeOutRunnable);
			handler.removeCallbacksAndMessages(null);
		} else {
			Logger.error("handler is null = " + (handler == null) + "runnable is null ="
					+ (incomingTimeOutRunnable == null));
		}
	}

	@Override
	public void onBackPressed() {
	}
}