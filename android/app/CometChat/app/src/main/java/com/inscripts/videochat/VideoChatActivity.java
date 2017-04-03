/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.videochat;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.media.AudioManager;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.view.Window;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.RelativeLayout;
import android.widget.Toast;

import com.inscripts.activities.InviteAVBroadcastUsers;
import com.inscripts.activities.R;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.pnikosis.materialishprogress.ProgressWheel;
import com.squareup.picasso.Picasso;

import fm.SingleAction;
import fm.icelink.webrtc.DefaultProviders;
import fm.android.conference.webrtc.App;

public class VideoChatActivity extends Activity implements OnClickListener {
    private RelativeLayout layout;
    private GestureDetector gestureDetector;
    private static RelativeLayout container;

    private String webasyncURL = "https://r.chatforyoursite.com:8443/websync.ashx";
    private String iceLinkServerAddress = "r.chatforyoursite.com";
    private String roomName, windowId, originalRoomName = "";
    private ImageButton endCallButton, muteControlToggle, videoOnOffToggle, speakerToggle, inviteUser;
    private App app;
    private static boolean isAudioOn = true, isVideoOn = true, isSpeakerOn = true, video, audio, isBroadcast = false, iamBroadcaster = false, isChatroom = false, isInviteClicked = false,isscreenshare = false, isCrAudioConference = false ;
    public static VideoChatActivity videoChatActivity;
    private SessionData session;
    private ProfileRoundedImageView audioOnlyDefaultAvatar;
    private static AudioManager audioManager;
    private ProgressWheel wheel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        videoChatActivity = this;
        Intent intent = getIntent();
        roomName = intent.getStringExtra(StaticMembers.INTENT_ROOM_NAME);
        video = intent.getBooleanExtra(StaticMembers.INTENT_VIDEO_FLAG, true);
        audio = intent.getBooleanExtra(StaticMembers.INTENT_AUDIO_FLAG, true);
        isBroadcast = intent.getBooleanExtra(StaticMembers.INTENT_AVBROADCAST_FLAG, false);
        iamBroadcaster = intent.getBooleanExtra(StaticMembers.INTENT_IAMBROADCASTER_FLAG, false);
        windowId = intent.getStringExtra(IntentExtrasKeys.BUDDY_ID);
        isChatroom = intent.getBooleanExtra(StaticMembers.CHATROOMMODE, false);
        isscreenshare = intent.getBooleanExtra(StaticMembers.SCREENSHARE_MODE,false);
        isCrAudioConference = intent.getBooleanExtra(StaticMembers.INTENT_CR_AUDIO_CONFERENCE_FLAG, false);

        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_AVCHAT_BUDDY_ID, windowId);

        String webRTCServerAddress = JsonPhp.getInstance().getWebRTCServer();
        if (null != webRTCServerAddress) {
            webasyncURL = "https://" + webRTCServerAddress + ":8443/websync.ashx";
            iceLinkServerAddress = webRTCServerAddress;
        }

        String webrtc_channel = PreferenceHelper.get(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
        originalRoomName = roomName;
        try {
            if (!TextUtils.isEmpty(webrtc_channel)) {
                roomName = EncryptionHelper.encodeIntoMD5(webrtc_channel + roomName);
            }
        } catch (Exception e1) {
            e1.printStackTrace();
        }
        if (!roomName.startsWith("/")) {
            roomName = "/" + roomName;
        }
        //Logger.error("Final roomname =" + roomName + " ogroomname " + originalRoomName);

        session = SessionData.getInstance();
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
        getWindow().addFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN);

        setContentView(R.layout.activity_video_chat);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        audioOnlyDefaultAvatar = (ProfileRoundedImageView) findViewById(R.id.imageViewAudioOnlyDefaultAvatar);

        if (session.getAVChatCallStartTime() == 0) {
            session.setAVChatCallStartTime(System.currentTimeMillis());
        }
        session.setAvchatStatus(3);

        // Get the activity's layout and give it a black background.
        layout = (RelativeLayout) findViewById(R.id.relativeLayoutVideoChat);
        layout.getRootView().setBackgroundColor(getResources().getColor(android.R.color.white));

        endCallButton = (ImageButton) findViewById(R.id.buttonEndCall);
        muteControlToggle = (ImageButton) findViewById(R.id.buttonMuteSound);
        videoOnOffToggle = (ImageButton) findViewById(R.id.buttonVideoOnOff);
        speakerToggle = (ImageButton) findViewById(R.id.buttonSpeakerToggle);
        inviteUser = (ImageButton) findViewById(R.id.buttonInviteUser);

        // Create a static container that will be preserved across
        // activity destruction/recreation.
        if (container == null) {
            container = new RelativeLayout(getApplicationContext());
            container.setLayoutParams(new RelativeLayout.LayoutParams(LayoutParams.MATCH_PARENT,
                    LayoutParams.MATCH_PARENT));
        }


        if (isBroadcast) {
            if (iamBroadcaster) {
                videoOnOffToggle.setOnClickListener(this);
                gestureDetector = new GestureDetector(this, new GestureDetector.SimpleOnGestureListener() {
                    @Override
                    public boolean onDoubleTap(MotionEvent e) {
                        App.getInstance().switchCamera();
                        return true;
                    }
                });
                inviteUser.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        isInviteClicked = true;
                        Intent intent = new Intent(getApplicationContext(), InviteAVBroadcastUsers.class);
                        intent.putExtra(StaticMembers.INTENT_ROOM_NAME, originalRoomName);
                        videoChatActivity.startActivity(intent);
                    }
                });
            } else {
                if (isscreenshare) {
                    speakerToggle.setVisibility(View.GONE);
                } else {
                    speakerToggle.setAlpha(0.5F);
                }
                wheel.setVisibility(View.VISIBLE);
                wheel.spin();
                videoOnOffToggle.setVisibility(View.GONE);
                muteControlToggle.setVisibility(View.GONE);
                inviteUser.setVisibility(View.GONE);
            }
        }else if (isCrAudioConference){
            videoOnOffToggle.setVisibility(View.GONE);
            muteControlToggle.setAlpha(0.5F);
            speakerToggle.setAlpha(0.5F);
            audioOnlyDefaultAvatar.setVisibility(View.VISIBLE);
            inviteUser.setVisibility(View.GONE);
            wheel.setVisibility(View.GONE);
        }else {
            inviteUser.setVisibility(View.GONE);
            if (video) {
                videoOnOffToggle.setOnClickListener(this);
                muteControlToggle.setAlpha(0.5F);
                speakerToggle.setAlpha(0.5F);
                videoOnOffToggle.setAlpha(0.5F);
                gestureDetector = new GestureDetector(this, new GestureDetector.SimpleOnGestureListener() {
                    @Override
                    public boolean onDoubleTap(MotionEvent e) {
                        App.getInstance().switchCamera();
                        return true;
                    }
                });
                Toast.makeText(this, "Double-tap to switch camera.", Toast.LENGTH_SHORT).show();
            } else {
                wheel.setVisibility(View.VISIBLE);
                wheel.spin();

                videoOnOffToggle.setVisibility(View.GONE);
                muteControlToggle.setAlpha(0.5F);
                speakerToggle.setAlpha(0.5F);
                videoOnOffToggle.setAlpha(0.5F);
                if (!isCrAudioConference){
                    Buddy buddy = Buddy.getBuddyDetails(Long.parseLong(windowId));
                    if (null != buddy) {
                        Picasso.with(getApplicationContext()).load(buddy.avatarURL).placeholder(R.drawable.default_avatar)
                                .into(audioOnlyDefaultAvatar);
                    }
                }
                // audioOnlyDefaultAvatar.setVisibility(View.VISIBLE);
                if (audioManager == null) {
                    audioManager = (AudioManager) getSystemService(Context.AUDIO_SERVICE);
                }
                audioManager.setMode(AudioManager.MODE_IN_COMMUNICATION);
                audioManager.setSpeakerphoneOn(false);
                isSpeakerOn = false;
                speakerToggle.setBackgroundResource(R.drawable.custom_round_main_speaker_selector);
            }
        }

        // Android's video providers need a context
        // in order to create surface views for video
        // rendering, so we need to supply one before
        // we start up the local media.
        DefaultProviders.setAndroidContext(this);

        // Get our static App instance.
        app = App.getInstance();

        // Start the local media engine.
        app.startLocalMedia(new SingleAction<Exception>() {
            @Override
            public void invoke(Exception ex) {
                if (ex == null) {
                    // Start the signalling engine.
                    app.startSignalling(new SingleAction<String>() {
                        @Override
                        public void invoke(String ex) {
                            if (ex != null) {
                                // alert("Could not start signalling. %s",
                                // ex.getMessage());
                                alert("Some problem occured while establishing connection");
                                Logger.error("Error at startSignalling " + ex);
                            }
                        }
                    }, webasyncURL, isBroadcast, iamBroadcaster);
                    // Start the conference engine.
                    app.startConference(iceLinkServerAddress, roomName, video, container, wheel, audioOnlyDefaultAvatar,
                            muteControlToggle, videoOnOffToggle, speakerToggle, videoChatActivity, isBroadcast, iamBroadcaster,
                            new SingleAction<Exception>() {
                                @Override
                                public void invoke(Exception ex) {
                                    if (ex != null) {
                                        // alert("Could not start conference. %s",
                                        // ex.getMessage());
                                        alert("Some problem occured while initializing video call");
                                        Logger.error("Error at startconference " + ex.getLocalizedMessage());
                                    }
                                }
                            });
                } else {
                    // alert("Could not start local media. %s",
                    // ex.getMessage());
                    alert("Some problem occured while getting media devices");
                    Logger.error("Error at startLocalMedia " + ex.getLocalizedMessage());
                }
            }
        }, video, audio);

        endCallButton.setOnClickListener(this);
        muteControlToggle.setOnClickListener(this);
        speakerToggle.setOnClickListener(this);

    }

    @Override
    protected void onPause() {
        super.onPause();
        // Remove the static container from the current layout.
        layout.removeView(container);
    }

    @Override
    protected void onResume() {
        super.onResume();
        // Add the static container to the current layout.
        isInviteClicked = false;
        layout.addView(container);
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        // Handle the double-tap event.
        if (gestureDetector == null || !gestureDetector.onTouchEvent(event)) {
            return super.onTouchEvent(event);
        }
        return true;
    }

    private void alert(String format, Object... args) {
        final String text = String.format(format, args);
        final Activity self = this;
        self.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                AlertDialog.Builder alert = new AlertDialog.Builder(self);
                alert.setMessage(text);
                alert.setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                    }
                });
                alert.show();
            }
        });
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.buttonEndCall:
                if (isBroadcast) {
                    if(!isscreenshare) {
                        VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getAVBroadcastEndURL());
                        if (isChatroom) {
                            vHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, 1);
                        }
                        vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName.substring(1, roomName.length()));
                        if (iamBroadcaster) {
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
                        } else {
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, "");
                        }

                        vHelper.sendAjax();
                    }
                } else {
                    VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), video ? URLFactory.getAVChatURL()
                            : URLFactory.getAudioChatURL());
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
                    vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName);
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.ENDCALL_ACTION);
                    vHelper.sendAjax();
                }
                session.setAvchatStatus(0);
                endcall();
                break;
            case R.id.buttonMuteSound:
                app.muteAudio(isAudioOn);
                if (isAudioOn) {
                    isAudioOn = false;
                    v.setBackgroundResource(R.drawable.custom_round_audio_off_button);
                } else {
                    isAudioOn = true;
                    v.setBackgroundResource(R.drawable.custom_round_audio_on_button);
                }
                break;
            case R.id.buttonVideoOnOff:
                app.publishLocalVideo(!isVideoOn);
                if (isVideoOn) {
                    isVideoOn = false;
                    v.setBackgroundResource(R.drawable.custom_round_video_off_button);
                } else {
                    isVideoOn = true;
                    v.setBackgroundResource(R.drawable.custom_round_video_on_button);
                }
                break;
            case R.id.buttonSpeakerToggle:
                if (audioManager == null) {
                    audioManager = (AudioManager) getSystemService(Context.AUDIO_SERVICE);
                }

                if (isSpeakerOn) {
                    audioManager.setMode(AudioManager.MODE_IN_COMMUNICATION);
                    audioManager.setSpeakerphoneOn(false);
                    isSpeakerOn = false;
                    v.setBackgroundResource(R.drawable.custom_round_main_speaker_selector);
                } else {
                    audioManager.setMode(AudioManager.MODE_IN_COMMUNICATION);
                    audioManager.setSpeakerphoneOn(true);
                    isSpeakerOn = true;
                    v.setBackgroundResource(R.drawable.custom_round_call_speaker_selector);
                }

            default:
                break;
        }
    }

    public void endcall() {
        if (audioManager == null) {
            audioManager = (AudioManager) getSystemService(Context.AUDIO_SERVICE);
        }
        audioManager.setMode(AudioManager.MODE_NORMAL);
        audioManager.setSpeakerphoneOn(true);
        if (app != null) {
            app.endCall();
            audioManager = null;
        }
        finish();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.ACTIVE_AVCHAT_BUDDY_ID);
        session.setAvchatStatus(0);
        
    }

    @Override
    public void onBackPressed() {

    }
}
