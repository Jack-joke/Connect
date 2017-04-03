/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.PackageManager;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AVchatKeys;
import com.inscripts.utils.StaticMembers;
import com.inscripts.videochat.VideoChatActivity;


public class VideoChat {

    public static boolean isDisabled() {
        return JsonPhp.getInstance().getAvchatEnabled().equals("0");
    }

    public static boolean isConferenceDisabled() {
        return null == JsonPhp.getInstance().getConfig().getAvConferenceEnabled() || JsonPhp.getInstance().getConfig().getAvConferenceEnabled().equals("0");
    }

    public static boolean isCrAudioCallDisabled() {
        return null == JsonPhp.getInstance().getCrAudioCallEnabled() || JsonPhp.getInstance().getCrAudioCallEnabled().equals("0");
    }

    public static boolean isAudioChatDisabled() {
        return JsonPhp.getInstance().getAudiochatEnabled() == null || JsonPhp.getInstance().getAudiochatEnabled()
                .equals("0");
    }

    public static boolean isAVChatRequest(String message) {
        return message.contains(AVchatKeys.REQUEST_KEY);
    }

    public static boolean isCrAvchatRequest(String message) {
        return message.contains(AVchatKeys.VIDEO_CrREQUEST_KEY);
    }

    public static boolean isAudioChatRequest(String message) {
        return message.contains(CometChatKeys.AudiochatKeys.REQUEST_KEY);
    }

    public static boolean isCrAudioCHatRequest(String message) {
        return message.contains(CometChatKeys.AudiochatKeys.AUDIO_CrREQUEST_KEY);
    }

    public static String getAVRoomName(String message, boolean isAudioOnly) {
        int initialIndex;
        if (isAudioOnly) {
            if (message.contains(CometChatKeys.AudiochatKeys.HAS_ACCEPTED_REQUEST)) {
                initialIndex = message.indexOf(CometChatKeys.AudiochatKeys.HAS_ACCEPTED_REQUEST);
            } else {
                initialIndex = message.indexOf(CometChatKeys.AudiochatKeys.REQUEST_KEY);
            }
        } else {
            if (message.contains(AVchatKeys.HAS_ACCEPTED_REQUEST)) {
                initialIndex = message.indexOf(AVchatKeys.HAS_ACCEPTED_REQUEST);
            } else {
                initialIndex = message.indexOf(AVchatKeys.REQUEST_KEY);
            }
        }

        message = message.substring(initialIndex, message.length());
        String parts[] = message.split(",");
        return parts[1].substring(1, parts[1].indexOf("\');"));
    }

    public static String getAVConferenceRoomName(String message) {
        int initialIndex;
        initialIndex = message.indexOf(AVchatKeys.JOIN_KEY);
        message = message.substring(initialIndex, message.length());
        String parts[] = message.split("\'");
        String roomname = parts[1];
        return roomname;
    }

    public static String setAVConferenceRoomName(String message) {
        if(message.equals("1")){
            return "";
        } else {
            String[] partf = message.split("\\(");
            String[] parts = partf[1].split("\\)");
            String grptext = parts[0].replaceAll("\"","");
            return grptext;
        }
    }

    public static void startVideoCall(String roomName, boolean audio, boolean video, Activity referingActivity,
                                      Class<?> destinationActivity, String windowId) {
        Intent intent = new Intent(referingActivity, destinationActivity);
        intent.putExtra(StaticMembers.INTENT_ROOM_NAME, roomName);
        PackageManager pm = PreferenceHelper.getContext().getPackageManager();
        if (video) {
            if (pm.hasSystemFeature(PackageManager.FEATURE_CAMERA) || pm.hasSystemFeature(PackageManager.FEATURE_CAMERA_ANY)) {
                intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, video);
            } else {
                intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, false);
            }
        } else {
            intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, false);
        }
        intent.putExtra(StaticMembers.INTENT_AUDIO_FLAG, audio);
        intent.putExtra(IntentExtrasKeys.BUDDY_ID, windowId);
        referingActivity.startActivity(intent);
    }

    public static void startConference(String roomName, Activity sourceActivity) {
        Intent intent = new Intent(sourceActivity, VideoChatActivity.class);
        intent.putExtra(StaticMembers.INTENT_ROOM_NAME, roomName);
        sourceActivity.startActivity(intent);

    }

    public static boolean isAVChatSentSuccessful(String mess) {
        return mess.contains(AVchatKeys.HAS_SENT_REQUEST_SUCCESSFULLY);
    }

    public static boolean isAVChatAccepted(String mess) {
        return mess.contains(AVchatKeys.HAS_ACCEPTED_REQUEST);
    }

    public static boolean isAVChatCallEnded(String mess) {
        return mess.contains(AVchatKeys.VIDEO_CALL_ENDED);
    }

    public static boolean isAVChatCallRejected(String mess) {
        return mess.contains(AVchatKeys.VIDEO_CALL_REJECTED);
    }

    public static boolean isAVChatCallNoAnswer(String mess) {
        return mess.contains(AVchatKeys.VIDEO_NO_ANSWER);
    }

    public static boolean isAVChatCancelCall(String mess) {
        return mess.contains(AVchatKeys.VIDEO_CALL_CANCEL);
    }

    public static boolean isAVChatBusyCall(String mess) {
        return mess.contains(AVchatKeys.VIDEO_BUSY_CALL);
    }

    public static boolean isAudioChatSentSuccessful(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.HAS_SENT_REQUEST_SUCCESSFULLY);
    }

    public static boolean isAudioChatAccepted(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.HAS_ACCEPTED_REQUEST);
    }

    public static boolean isAudioChatCallEnded(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.AUDIO_CALL_ENDED);
    }

    public static boolean isAudioChatCallRejected(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.AUDIO_CALL_REJECTED);
    }

    public static boolean isAudioChatCallNoAnswer(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.AUDIO_NO_ANSWER);
    }

    public static boolean isAudioChatCancelCall(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.AUDIO_CALL_CANCEL);
    }

    public static boolean isAudioChatBusyCall(String mess) {
        return mess.contains(CometChatKeys.AudiochatKeys.AUDIO_BUSY_CALL);
    }

    public static String getAVRoomnameFromRequest(String message, boolean isAudioOnly) {
        // Message is in format jqcc17108543446448165930_1446454068014(236b5c8facf0b7d5118e09a2f6420b5b)
        try {
            message = message.replaceAll("\"", "");
            return message.substring(message.indexOf("(") + 1, message.lastIndexOf(")"));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }
}
