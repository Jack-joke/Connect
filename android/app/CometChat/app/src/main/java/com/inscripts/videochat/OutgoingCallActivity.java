/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.videochat;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageButton;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
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

public class OutgoingCallActivity extends Activity implements OnClickListener {

	private ImageButton cancelCallButton,volumeControlButton;
	private TextView callerNameTextView, callingTextview;
	private BroadcastReceiver receiver;
	private ProfileRoundedImageView buddyProfileImageView;
	private String roomName, buddyId;
	public static OutgoingCallActivity outgoingCallActivity;
	private SessionData session;
	private boolean isAudioCall;
    private boolean isRinging = true;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		outgoingCallActivity = this;
		setContentView(R.layout.activity_outgoing_call);

		Intent intent = getIntent();
		buddyId = intent.getStringExtra(CometChatKeys.AVchatKeys.CALLER_ID);
		isAudioCall = intent.getBooleanExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, false);

		cancelCallButton = (ImageButton) findViewById(R.id.buttonCancelCall);
        volumeControlButton = (ImageButton) findViewById(R.id.buttonSpeaker);
		callerNameTextView = (TextView) findViewById(R.id.textViewOutgoingCallerName);
		buddyProfileImageView = (ProfileRoundedImageView) findViewById(R.id.imageViewOutgoingProfilePicture);
		callingTextview = (TextView) findViewById(R.id.textViewCallingText);

		if (null != JsonPhp.getInstance().getLang()) {
			callingTextview.setText(JsonPhp.getInstance().getLang().getMobile().get43());
		}


        cancelCallButton.getBackground().setColorFilter(Color.parseColor("#eb5160"), PorterDuff.Mode.SRC_ATOP);
        volumeControlButton.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        volumeControlButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                if(isRinging) {
                    CommonUtils.stopRingtone();
                    volumeControlButton.setImageResource(R.drawable.ic_mutespeaker);
                    isRinging = false;
                }else{
                    CommonUtils.playRingtone(OutgoingCallActivity.this, "outgoing_call_sound.wav");
                    volumeControlButton.setImageResource(R.drawable.ic_volume_control);
                    isRinging = true;
                }
            }
        });


		cancelCallButton.setOnClickListener(this);

		Buddy buddy = Buddy.getBuddyDetails(Long.parseLong(buddyId));
		if (null != buddy) {
			callerNameTextView.setText(buddy.name);
			Picasso.with(getApplicationContext()).load(buddy.avatarURL).placeholder(R.drawable.default_avatar)
					.into(buddyProfileImageView);
		}

		session = SessionData.getInstance();

		receiver = new BroadcastReceiver() {
			@Override
			public void onReceive(android.content.Context context, Intent intent) {
				String caller = intent.getStringExtra(BroadcastReceiverKeys.AvchatKeys.AVCHAT_CALLER_ID);
				if (caller.equalsIgnoreCase(buddyId)) {
                    roomName = intent.getStringExtra(CometChatKeys.AVchatKeys.ROOM_NAME);
					if (isAudioCall) {
						VideoChat.startVideoCall(roomName, true, false, OutgoingCallActivity.this,
								VideoChatActivity.class, buddyId);
					} else {
						VideoChat.startVideoCall(roomName, true, true, OutgoingCallActivity.this,
								VideoChatActivity.class, buddyId);
					}
					finish();
				}
			}
		};

		CommonUtils.playRingtone(this, "outgoing_call_sound.wav");
		session.setAvchatStatus(2);

		Handler handler = new Handler();
		handler.postDelayed(new Runnable() {

			@Override
			public void run() {
				session.setAvchatStatus(0);
				CommonUtils.stopRingtone();
				finish();
			}
		}, LocalConfig.OUTGOING_CALL_TIMEOUT);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.buttonCancelCall:
			Logger.error("Call cancelled");
			cancelOutgoingCall();
			session.setAvchatStatus(0);
			CommonUtils.stopRingtone();
			finish();
			break;
		default:
			break;
		}
	}

	private void cancelOutgoingCall() {
		VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioCall ? URLFactory.getAudioChatURL()
				: URLFactory.getAVChatURL());
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, buddyId);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.CANCEL_OUTGOING_CALL_ACTION);
		vHelper.sendAjax();

	}

	@Override
	protected void onStart() {
		super.onStart();
		if (receiver != null) {
			registerReceiver(receiver, new IntentFilter(BroadcastReceiverKeys.AvchatKeys.EVENT_AVCHAT_ACCEPTED));
		}
	}

	@Override
	public void finish() {
		super.finish();
		CommonUtils.stopRingtone();
	}

	@Override
	public void onStop() {
		super.onStop();
		if (receiver != null) {
			unregisterReceiver(receiver);
		}
	}

	@Override
	public void onBackPressed() {

	}
}
