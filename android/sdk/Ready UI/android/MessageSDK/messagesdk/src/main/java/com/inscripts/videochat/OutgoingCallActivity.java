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
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.VideoChat;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.squareup.picasso.Picasso;

public class OutgoingCallActivity extends Activity implements OnClickListener {

    private Button cancelCallButton;
    private TextView callerNameTextView, callingTextview;
    private BroadcastReceiver receiver;
    private ProfileRoundedImageView buddyProfileImageView;
    private String roomName, buddyId;
    public static OutgoingCallActivity outgoingCallActivity;
    private SessionData session;
    private boolean isAudioCall;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        outgoingCallActivity = this;
        setContentView(R.layout.cc_activity_outgoing_call);

        Intent intent = getIntent();
        buddyId = intent.getStringExtra(CometChatKeys.AVchatKeys.CALLER_ID);
        isAudioCall = intent.getBooleanExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, false);

        cancelCallButton = (Button) findViewById(R.id.buttonCancelCall);
        callerNameTextView = (TextView) findViewById(R.id.textViewOutgoingCallerName);
        buddyProfileImageView = (ProfileRoundedImageView) findViewById(R.id.imageViewOutgoingProfilePicture);
        callingTextview = (TextView) findViewById(R.id.textViewCallingText);

        if (null != JsonPhp.getInstance().getLang()) {
            callingTextview.setText(JsonPhp.getInstance().getLang().getMobile().get43());
        }

        cancelCallButton.setOnClickListener(this);

        Buddy buddy = Buddy.getBuddyDetails(Long.parseLong(buddyId));
        if (null != buddy) {
            callerNameTextView.setText(buddy.name);
            Picasso.with(getApplicationContext()).load(buddy.avatarURL).placeholder(R.drawable.cc_default_avatar)
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

        CommonUtils.playRingtone(this, "outgoing_call_sound.mp3");
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
        if (v.getId() == R.id.buttonCancelCall) {
            cancelOutgoingCall();
            session.setAvchatStatus(0);
            CommonUtils.stopRingtone();
            finish();
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
