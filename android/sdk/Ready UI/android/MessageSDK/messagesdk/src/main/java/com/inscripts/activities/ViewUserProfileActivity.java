/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.Html;
import android.text.TextUtils;
import android.view.View;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.custom.ConfirmationWindow;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.VideoChat;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.inscripts.videochat.OutgoingCallActivity;


public class ViewUserProfileActivity extends SuperActivity {

    private Long buddyId;
    protected TextView name, statusMessage,  tvVideoCall, tvAudioCall;
    private ProfileRoundedImageView buddyProfileImage;
    protected ImageView statusImage;
    protected RelativeLayout videoCallContainer, audioCallContainer;
    private Toolbar toolbar;

    private ImageView imageViewBuddyVideoCall,imageViewBuddyAudioCall;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_view_user_profile);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);

        Intent intent = getIntent();

        toolbar.setNavigationIcon(R.drawable.cc_ic_action_cancel);
        toolbar.setNavigationOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onBackPressed();
            }
        });

        buddyId = intent.getLongExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, 0);

        if (JsonPhp.getInstance().getLang() != null && JsonPhp.getInstance().getLang().getMobile().get92() != null) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get92());
        }

        name = (TextView) findViewById(R.id.textViewProfileBuddyName);
        statusMessage = (TextView) findViewById(R.id.textViewProfileBuddyStatusMessage);
        buddyProfileImage = (ProfileRoundedImageView) findViewById(R.id.imageViewProfileBuddyPic);
        statusImage = (ImageView) findViewById(R.id.imageViewProfileBuddyStatus);

        videoCallContainer = (RelativeLayout) findViewById(R.id.relativeLayoutBuddyVideoCall);
        audioCallContainer = (RelativeLayout) findViewById(R.id.relativeLayoutBuddyAudioCall);

        imageViewBuddyVideoCall = (ImageView) findViewById(R.id.imageViewBuddyVideoCall);
        imageViewBuddyAudioCall = (ImageView) findViewById(R.id.imageViewBuddyAudioCall);


        imageViewBuddyVideoCall.getDrawable().setColorFilter(Color.parseColor("#8e8e92"), PorterDuff.Mode.SRC_ATOP);
        imageViewBuddyAudioCall.getDrawable().setColorFilter(Color.parseColor("#8e8e92"), PorterDuff.Mode.SRC_ATOP);
        if (VideoChat.isDisabled()) {
            videoCallContainer.setVisibility(View.GONE);
        } else {
            tvVideoCall = (TextView) findViewById(R.id.textViewBuddyVideoCall);
            if (!TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get93())) {
                tvVideoCall.setText(JsonPhp.getInstance().getLang().getMobile().get93());
            }
        }

        if (VideoChat.isAudioChatDisabled()) {
            audioCallContainer.setVisibility(View.GONE);
        } else {
            tvAudioCall = (TextView) findViewById(R.id.textViewBuddyAudioCall);
            if (!TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get94())) {
                tvAudioCall.setText(JsonPhp.getInstance().getLang().getMobile().get94());
            }
        }

        videoCallContainer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showCallPopup(false);
            }
        });

        audioCallContainer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showCallPopup(true);
            }
        });

        Buddy buddy = Buddy.getBuddyDetails(buddyId);
        if (null != buddy) {
            name.setText(Html.fromHtml(buddy.name));
            statusMessage.setText(buddy.statusMessage);
            String profileUrl = buddy.avatarURL;
            if (null != profileUrl) {
                if (!profileUrl.contains(URLFactory.PROTOCOL_PREFIX) && !profileUrl.contains(URLFactory.PROTOCOL_PREFIX_SECURE)) {
                    profileUrl = URLFactory.getBaseURL() + profileUrl;
                }
                /*LocalStorageFactory.getPicassoInstance().load(profileUrl).placeholder(R.drawable.default_avatar)
                        .into(buddyProfileImage);*/
                LocalStorageFactory.LoadImageUsingURL(this,profileUrl,buddyProfileImage,R.drawable.cc_default_avatar);
            }
            String status = buddy.status;
            if (TextUtils.isEmpty(status)) {
                statusImage.setImageResource(R.drawable.cc_ic_user_available);
            } else {
                switch (status) {
                    case CometChatKeys.StatusKeys.AVALIABLE:
                        statusImage.setImageResource(R.drawable.cc_ic_user_available);
                        break;
                    case CometChatKeys.StatusKeys.AWAY:
                        statusImage.setImageResource(R.drawable.cc_ic_user_away);
                        break;
                    case CometChatKeys.StatusKeys.BUSY:
                        statusImage.setImageResource(R.drawable.cc_ic_user_busy);
                        break;
                    case CometChatKeys.StatusKeys.OFFLINE:
                        statusImage.setImageResource(R.drawable.cc_ic_user_offline);
                        break;
                    case CometChatKeys.StatusKeys.INVISIBLE:
                        statusImage.setImageResource(R.drawable.cc_ic_user_offline);
                        break;
                    default:
                        statusImage.setImageResource(R.drawable.cc_ic_user_available);
                        break;
                }
            }
        }
    }


    private void showCallPopup(final boolean isAudioOnlyCall) {
        try {
            SessionData sessionData = SessionData.getInstance();
            Lang lang = JsonPhp.getInstance().getLang();

            String myId = EncryptionHelper.encodeIntoMD5(String.valueOf(sessionData.getId()));
            String wId = EncryptionHelper.encodeIntoMD5(String.valueOf(buddyId));
            String roomName;
            if (sessionData.getId() < buddyId) {
                roomName = "/" + EncryptionHelper.encodeIntoMD5(URLFactory.getWebsiteHostURL() + myId + wId);
            } else {
                roomName = "/" + EncryptionHelper.encodeIntoMD5(URLFactory.getWebsiteHostURL() + wId + myId);
            }
            final String finalRoomName = roomName;
            String yes = StaticMembers.POSITIVE_TITLE, no = StaticMembers.NEGATIVE_TITLE;
            if (lang.getMobile().get33() != null) {
                yes = lang.getMobile().get33();
            }
            if (lang.getMobile().get34() != null) {
                no = lang.getMobile().get34();
            }

            ConfirmationWindow cWindow = new ConfirmationWindow(this, yes, no) {

                @Override
                protected void setNegativeResponse() {
                    super.setNegativeResponse();
                }

                @Override
                protected void setPositiveResponse() {
                    super.setPositiveResponse();
                    initiateCall(finalRoomName, isAudioOnlyCall);
                }
            };
            if (isAudioOnlyCall) {
                cWindow.setMessage((lang.getAudiochat() == null) ? "Call" : lang.getAudiochat().get28() + " "
                        + name.getText().toString() + "?");
            } else {
                cWindow.setMessage((lang.getAvchat() == null) ? "Call" : lang.getAvchat().get28() + " " + name.getText().toString()
                        + "?");
            }

            cWindow.show();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("HandlerLeak")
    private void initiateCall(final String roomName, final boolean isAudioOnlyCall) {
        VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioOnlyCall ? URLFactory.getAudioChatURL()
                : URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Intent intent = new Intent(ViewUserProfileActivity.this, OutgoingCallActivity.class);
                    intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, roomName.substring(1));
                    intent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, String.valueOf(buddyId));
                    intent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, isAudioOnlyCall);
                    startActivity(intent);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, buddyId);
        vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName.substring(1));
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.REQUEST);
        vHelper.sendAjax();
    }
}
