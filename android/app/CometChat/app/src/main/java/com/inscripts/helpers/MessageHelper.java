/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.text.TextUtils;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request.Method;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.Response.Listener;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.Audiochat;
import com.inscripts.jsonphp.Avchat;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.Conversation;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.AVBroadcast;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoChat;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.videochat.IncomingCallActivity;
import com.inscripts.videochat.OutgoingCallActivity;
import com.inscripts.videochat.VideoChatActivity;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.select.Elements;

import java.io.File;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;

public class MessageHelper {

    private static final String TAG = MessageHelper.class.getSimpleName();
    private static MessageHelper messagerHelper;
    private Context context = PreferenceHelper.getContext();
    private Avchat avchatJsonPhp = JsonPhp.getInstance().getLang().getAvchat();
    private Audiochat audiochat = JsonPhp.getInstance().getLang().getAudiochat();
    private String meText = null == JsonPhp.getInstance().getLang() ? StaticMembers.ME_TEXT : JsonPhp.getInstance().getLang().getMobile().get6();
    private long serverTime;
    private Mobile mobileLangs;

    public static MessageHelper getInstance() {
        if (messagerHelper == null) {
            messagerHelper = new MessageHelper();
        }
        return messagerHelper;
    }

    /**
     * @param message : Pass single received message JSONObject
     */
    @SuppressLint("DefaultLocale")
    public boolean handleOneOnOneMessage(Buddy buddy, JSONObject message) {
        Logger.error(TAG,"Helper message"+message);
        int messageProcessed = 1;
        try {
            SessionData session = SessionData.getInstance();
            Long buddyId = buddy.buddyId;
            String buddyName = buddy.name;

            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(CometChatKeys.AjaxKeys.SENT)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
            } else {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT));
            }
            String mess = message.getString(CometChatKeys.AjaxKeys.MESSAGE);
            message.put(CometChatKeys.AjaxKeys.SENT, serverTime);
            message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, "");
            message.put(DatabaseKeys.ColoumnKeys.MESSAGE_INSERTED_BY, 0);
            message.put(DatabaseKeys.ColoumnKeys.MESSAGE_TICK, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);

            if (mess.contains("jqcc.cc")) {
                if (VideoChat.isAVChatRequest(mess)) {
                    if (VideoChat.isDisabled()) {
                        return false;
                    }
                    if (android.os.Build.VERSION.SDK_INT < 16) {
                        Toast.makeText(PreferenceHelper.getContext(), avchatJsonPhp.get42(), Toast.LENGTH_LONG).show();
                        return false;
                    }

                    message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get29() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);


                    String servertime = SessionData.getInstance().getServerTime();
                    long diff = 0;
                    boolean callAcceptCondition = session.getUserInfoHeartBeatFlag().equals("0") && session.getAvchatStatus() == 0 && session.isCall();
                    if (!TextUtils.isEmpty(servertime)) {
                        servertime += "000";
                        diff = ((Long.parseLong(servertime) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE))) - message.getLong(AjaxKeys.SENT));
                        callAcceptCondition = callAcceptCondition && (diff != 0 && diff < 60000) && session.isCall();
                    }
                    OneOnOneMessage avmessage = OneOnOneMessage.findById(message.getLong("id"));
                    boolean avCallisProcessed = false;
                    if (avmessage != null) {
                        avCallisProcessed = true;
                        avmessage.message = avchatJsonPhp.get29() + " " + buddyName;
                        avmessage.save();
                    }
                    if (!avCallisProcessed) {
                        if (callAcceptCondition) {
                            Intent intent = new Intent(context, IncomingCallActivity.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, VideoChat.getAVRoomName(mess, false));
                            intent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID,
                                    message.getString(CometChatKeys.AjaxKeys.FROM));
                            context.startActivity(intent);
                        } else {
                            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                    URLFactory.getAVChatURL());
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, String.valueOf(buddyId));
                            // vHelper.sendCallBack(false);
                            vHelper.sendAjax();
                        }
                    }

                } else if (VideoChat.isAVChatAccepted(mess)) {
                    if (VideoChat.isDisabled()) {
                        return false;
                    }

                    message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);

                    Intent intent = new Intent(BroadcastReceiverKeys.AvchatKeys.EVENT_AVCHAT_ACCEPTED);
                    intent.putExtra(BroadcastReceiverKeys.AvchatKeys.AVCHAT_CALLER_ID,
                            message.getString(CometChatKeys.AjaxKeys.FROM));
                    intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, VideoChat.getAVRoomName(mess, false));
                    context.sendBroadcast(intent);

                } else if (VideoChat.isAVChatSentSuccessful(mess)) {
                    return false;
                } else if (VideoChat.isAudioChatRequest(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    if (android.os.Build.VERSION.SDK_INT < 16) {
                        Toast.makeText(PreferenceHelper.getContext(), avchatJsonPhp.get42(), Toast.LENGTH_LONG).show();
                        return false;
                    }
                    message.put(CometChatKeys.AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get29() : audiochat.get29() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    String servertime = SessionData.getInstance().getServerTime();
                    long diff = 0;
                    boolean callAcceptCondition = session.getUserInfoHeartBeatFlag().equals("0") && session.getAvchatStatus() == 0 && session.isCall();
                    if (!TextUtils.isEmpty(servertime)) {
                        servertime += "000";
                        diff = ((Long.parseLong(servertime) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE))) - message.getLong(AjaxKeys.SENT));
                        callAcceptCondition = callAcceptCondition && (diff != 0 && diff < 60000) && session.isCall();
                    }
                    OneOnOneMessage avmessage = OneOnOneMessage.findById(message.getLong("id"));
                    if (avmessage != null) {
                        avmessage.message = (audiochat == null) ? avchatJsonPhp.get29() : audiochat.get29() + " " + buddyName;
                        avmessage.save();
                    }
                    if (callAcceptCondition) {
                        Intent intent = new Intent(context, IncomingCallActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, VideoChat.getAVRoomName(mess, true));
                        intent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                        intent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID,
                                message.getString(CometChatKeys.AjaxKeys.FROM));
                        context.startActivity(intent);
                    } else {
                        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                URLFactory.getAudioChatURL());
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, String.valueOf(buddyId));
                        // vHelper.sendCallBack(false);
                        vHelper.sendAjax();
                    }

                } else if (VideoChat.isAudioChatAccepted(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }

                    message.put(CometChatKeys.AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get30() : audiochat.get30() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);

                    Intent intent = new Intent(BroadcastReceiverKeys.AvchatKeys.EVENT_AVCHAT_ACCEPTED);
                    intent.putExtra(BroadcastReceiverKeys.AvchatKeys.AVCHAT_CALLER_ID,
                            message.getString(CometChatKeys.AjaxKeys.FROM));
                    intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, VideoChat.getAVRoomName(mess, true));
                    intent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                    context.sendBroadcast(intent);

                } else if (VideoChat.isAudioChatSentSuccessful(mess)) {
                    return false;
                } else if (AVBroadcast.isAVBroadcast(mess)) {
                    String roomname = AVBroadcast.getGroupName(mess, false);

                    /*Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*/
                    mobileLangs = JsonPhp.getInstance().getLang().getMobile();
                    if (null != mobileLangs) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, JsonPhp.getInstance().getLang().getMobile().get160() + "##" + roomname);
                    } else {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    }
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVBROADCAST);

                } else if (OtherPlugins.isGameAccept(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isGameRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    String randomid = OtherPlugins.getRandomId(mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WRITEBOARD_REQUEST);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + randomid);

                } else if (OtherPlugins.isScreehShareRequest(mess)) {
                    Logger.error(mess);
                    Document doc = Jsoup.parseBodyFragment(mess);
                    Elements anchortag = doc.select(StaticMembers.ANCHOR_TAG);
                    String grp = anchortag.attr("grp");

                  /*  message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*/
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.SCREENSHARE_REQUEST);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + grp);

                    Logger.error("Screen share message = " + doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + grp);

                } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + OtherPlugins.getWhiteBoardRoomName(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST);
                } else {
                    //Logger.error("in else of jqcc , message is not processed");
                    messageProcessed = 2;
                }
            } else if (mess.contains("CC^CONTROL_")) {
                //Logger.error("Mess CC control " + message);

                if (OtherPlugins.isBotResponce(mess)) {
                    String trimedMess = mess.replace("CC^CONTROL_", "");
                    JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, jsonParams);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                } else if (VideoChat.isAVChatCallRejected(mess)) {
                    session.setAvchatStatus(0);
                    if (VideoChat.isDisabled()) {
                        return false;
                    }

                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " "
                                + avchatJsonPhp.get32());
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }
                } else if (VideoChat.isAVChatCallEnded(mess)) {
                    PreferenceHelper.removeKey(PreferenceKeys.DataKeys.ACTIVE_AVCHAT_BUDDY_ID);
                    if (VideoChat.isDisabled()) {
                        return false;
                    }
                    long startTime = session.getAVChatCallStartTime();
                    session.setAvchatStatus(0);
                    session.setAVChatCallStartTime(0);
                    if (startTime != 0) {
                        String callDuration = CommonUtils
                                .convertTimeStampToDurationTime((System.currentTimeMillis() - startTime));

                        message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get31() + " " + callDuration);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                        if ((message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("0"))) {
                            if (VideoChatActivity.videoChatActivity != null) {
                                VideoChatActivity.videoChatActivity.endcall();
                            }
                        }
                    } else {
                        return false;
                    }
                } else if (VideoChat.isAVChatCallNoAnswer(mess)) {
                    if (VideoChat.isDisabled()) {
                        return false;
                    }
                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get33() + " " + buddyName);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }
                } else if (VideoChat.isAVChatCancelCall(mess)) {
                    if (session.getAvchatStatus() == 3 && PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_AVCHAT_BUDDY_ID)
                            && !(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_AVCHAT_BUDDY_ID)).equals(String.valueOf(buddyId))) {
                        return false;
                    } else {
                        session.setAvchatStatus(0);
                        if (VideoChat.isDisabled()) {
                            return false;
                        }
                        if (IncomingCallActivity.incomingCallActivity != null) {
                            IncomingCallActivity.incomingCallActivity.finish();
                        }
                        if (VideoChatActivity.videoChatActivity != null) {
                            VideoChatActivity.videoChatActivity.finish();
                        }
                        if (message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("1")) {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " "
                                    + avchatJsonPhp.get34().toLowerCase());
                            message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                        } else {
                            return false;
                        }
                    }
                } else if (VideoChat.isAVChatBusyCall(mess)) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " busy");
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                    }
                } else if (VideoChat.isAudioChatCallRejected(mess)) {
                    session.setAvchatStatus(0);
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }

                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get30()
                                : audiochat.get30() + " " + buddyName + " " + avchatJsonPhp.get32());
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }

                } else if (VideoChat.isAudioChatCallEnded(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    long startTime = session.getAVChatCallStartTime();
                    session.setAvchatStatus(0);
                    session.setAVChatCallStartTime(0);
                    if (startTime != 0) {
                        String callDuration = CommonUtils
                                .convertTimeStampToDurationTime((System.currentTimeMillis() - startTime));

                        message.put(CometChatKeys.AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get31()
                                : audiochat.get31() + " " + callDuration);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                        if ((message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("0"))) {
                            if (VideoChatActivity.videoChatActivity != null) {
                                VideoChatActivity.videoChatActivity.endcall();
                            }
                        }
                    } else {
                        return false;
                    }

                } else if (VideoChat.isAudioChatCallNoAnswer(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get33()
                                : audiochat.get33() + " " + buddyName);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }

                } else if (VideoChat.isAudioChatCancelCall(mess)) {
                    session.setAvchatStatus(0);
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    if (IncomingCallActivity.incomingCallActivity != null) {
                        IncomingCallActivity.incomingCallActivity.finish();
                    }
                    if (VideoChatActivity.videoChatActivity != null) {
                        VideoChatActivity.videoChatActivity.finish();
                    }
                    if (message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("1")) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get30()
                                : audiochat.get30() + " " + buddyName + " " + avchatJsonPhp.get34().toLowerCase());
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    } else {
                        return false;
                    }

                } else if (VideoChat.isAudioChatBusyCall(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    message.put(CometChatKeys.AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get30() : audiochat.get30() + " " + buddyName + " busy");
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                    }

                } else if (AVBroadcast.isAVBroadcastEnd(mess)) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, null == JsonPhp.getInstance().getLang().getMobile().get166() ? "This broadcast has ended" : JsonPhp.getInstance().getLang().getMobile().get166());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                    if ((message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("0"))) {
                        if (VideoChatActivity.videoChatActivity != null) {
                            VideoChatActivity.videoChatActivity.endcall();
                        }
                    }
                } else if (OtherPlugins.isTypingStop(mess)) {
                    Intent intent = new Intent(
                            BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.TYPING_STOP);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddyId);
                    context.sendBroadcast(intent);

                    Intent intent1 = new Intent(
                            BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.TYPING_STOP);
                    intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddyId);
                    context.sendBroadcast(intent1);
                    return false;
                } else if (OtherPlugins.isTypingStart(mess)) {
                    Intent intent = new Intent(
                            BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.TYPING_START);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddyId);
                    context.sendBroadcast(intent);

                    Intent intent1 = new Intent(
                            BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.TYPING_START);
                    intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddyId);
                    context.sendBroadcast(intent1);
                    return false;
                } else if (OtherPlugins.isMessageDelivery(mess)) {
                    OneOnOneMessage msg = OneOnOneMessage.findById(OtherPlugins.getMessageID(mess));
                    if (msg != null && msg.self == 1) {
                        if (msg.messagetick != CometChatKeys.MessageTypeKeys.MESSAGE_READ) {
                            msg.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_DELIVERD;
                            msg.save();
                            Intent intent = new Intent(
                                    BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.MESSAGE_TICK, BroadcastReceiverKeys.IntentExtrasKeys.MESSAGE_DELIVERED);
                            context.sendBroadcast(intent);
                        }

                    }
                    return false;
                } else if (OtherPlugins.isMessageRead(mess) || OtherPlugins.isMessageReadDelivered(mess)) {
                    OneOnOneMessage msg = OneOnOneMessage.findById(OtherPlugins.getMessageID(mess));
                    if (msg != null && msg.self == 1) {
                        msg.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_READ;
                        msg.save();
                        Intent intent = new Intent(
                                BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.MESSAGE_TICK, BroadcastReceiverKeys.IntentExtrasKeys.MESSAGE_READ);
                        context.sendBroadcast(intent);
                    }
                    return false;

                } else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.STICKERS);
                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("plugins/filetransfer")) {
                if (ImageSharing.isIncomingImage(mess)) {
                    // Logger.error("chatrom message="+message);
                    /*
                     * Replace the message value by the image link and use it in
					 * the adapter
					 */
                    String url = ImageSharing.getImageURL(mess);
                    int startIndex = url.indexOf(StaticMembers.FILE_PREFIX) + StaticMembers.FILE_PREFIX.length();
                    String fileName;
                    try {
                        fileName = URLEncoder.encode((url.substring(startIndex, url.length())), StaticMembers.UTF_8);
                    } catch (UnsupportedEncodingException e1) {
                        fileName = url.substring(startIndex, url.length());
                        e1.printStackTrace();
                    }

                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, url);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.IMAGE_NEW);

                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage temp = OneOnOneMessage.findById(message.getLong(CometChatKeys.AjaxKeys.ID));
                        if (null != temp) {
                            temp.imageUrl = url;
                            temp.save();
                            return false;
                        }
                    }

                    File file = new File(LocalStorageFactory.getImageStoragePath() + fileName);
                    if (file.exists()) {
                        // Logger.error("file exisit in message helper");
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
                                CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED);
                    } else {
                        LocalStorageFactory.saveIncomingImage(fileName, url, null, false,
                                message.getString(CometChatKeys.AjaxKeys.ID), false);
                    }
                } else if (VideoSharing.isIncomingVideo(mess)) {
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.VIDEO_NEW);
                    String videoUrl = ImageSharing.getImageURL(mess);
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, videoUrl);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, videoUrl);

                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage pojo = OneOnOneMessage.findById(message.getLong(CometChatKeys.AjaxKeys.ID));
                        if (null != pojo) {
                            pojo.imageUrl = videoUrl;
                            pojo.save();
                            return false;
                        }
                    }
                } else if (AudioSharing.isIncomingAudio(mess)) {
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO_NEW);
                    String audioUrl = ImageSharing.getImageURL(mess);
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, audioUrl);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, audioUrl);
                    AudioSharing.downloadAndStoreAudio(message.getString(CometChatKeys.AjaxKeys.ID), audioUrl, false);
                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage pojo = OneOnOneMessage.findById(message.getLong(CometChatKeys.AjaxKeys.ID));
                        if (null != pojo) {
                            pojo.imageUrl = audioUrl;
                            pojo.save();
                            return false;
                        }
                    }
                } else if (ImageSharing.isFileTransfer(mess)) {
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, mess);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, ImageSharing.getImageURL(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.FILE_NEW);
                    //return false;
                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("jqcc.cometchat")) {
                if (ChatroomManager.isJoinChatroomMessage(mess)) {
                    String joinChatroomMessage = ChatroomManager.parseJoinRequest(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, joinChatroomMessage);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
                            CometChatKeys.MessageTypeKeys.JOIN_CHATROOM_MESSAGE);
                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("/plugins/handwrite/") || mess.contains("/writable/handwrite/")) {
                if (OtherPlugins.isHandWrite(mess)) {
                    String url = OtherPlugins.getHandwriteImageUrl(mess);
                    int startIndex = url.lastIndexOf("/") + 1;
                    String fileName;
                    try {
                        fileName = URLEncoder.encode((url.substring(startIndex, url.length())), StaticMembers.UTF_8);
                    } catch (UnsupportedEncodingException e1) {
                        fileName = url.substring(startIndex, url.length());
                        e1.printStackTrace();
                    }

                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, url);
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE,
                            doc.text().split("\\.")[0] + "|" + LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITE_NEW);
                    LocalStorageFactory.saveIncomingImage(fileName, url, null, false,
                            message.getString(CometChatKeys.AjaxKeys.ID), true);
                } else {
                    messageProcessed = 2;
                }
            } else {
                /* normal message */
                /*
                 * if (isNotComet) { if
				 * (message.getString(CometChatKeys.AjaxKeys .OLD).equals("1"))
				 * { return; } }
				 */
                if (AVBroadcast.isAVBroadcastInvite(mess)) {
                    String roomname = AVBroadcast.getInviteGroupName(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    //message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVBROADCAST);
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(CommonUtils.handleLink(mess));
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                }
            }
            if (messageProcessed == 2) {
                return false;
            } else {
                Config config = JsonPhp.getInstance().getConfig();

                if ((message.getString(DatabaseKeys.ColoumnKeys.SELF).equals("0"))) {
                    if (config.getUSECOMET() != null && config.getUSECOMET().equals("1")) {
                        String transport = config.getTRANSPORT();
                        if (transport.equals("cometservice")) {
                            CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getDeliveredTickMessage(message.getString(CometChatKeys.AjaxKeys.ID)));
                        } else if (transport.equals("cometservice-selfhosted")) {
                            WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getDeliveredTickMessage(message.getString(CometChatKeys.AjaxKeys.ID)));
                        }

                    }
                }
            }

            if (messageProcessed == 0) {
                mess = CommonUtils.handleSpecialHtmlCharacters(CommonUtils.handleLink(mess));
                message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
            }

            session.setOneToOneBroadCastMissed(true);
            session.setBuddyListBroadcastMissed(true);

            message.put(CometChatKeys.AjaxKeys.OLD, "1");
            message.put(CometChatKeys.AjaxKeys.TO, session.getId());
            message.put(CometChatKeys.AjaxKeys.SENT, serverTime);

            boolean isNew;
            OneOnOneMessage pojo = OneOnOneMessage.findById(message.getString(CometChatKeys.AjaxKeys.ID));
            if (null == pojo) {
                isNew = true;
                pojo = new OneOnOneMessage(message);
            } else {
                isNew = false;
            }
            pojo.save();


            buddy.lastUpdated = System.currentTimeMillis();
            buddy.lastseen = String.valueOf(serverTime);
            buddy.save();

            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID)) {
                long buddyWindowId = Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID));

                if ((buddyWindowId != buddyId || buddyWindowId == 0) && isNew && pojo.self == 0) {
                    if (buddy.unreadCount == 0) {
                        /*int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_CHAT_BADGE));
                        count++;
                        PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, count);*/
                        buddy.unreadCount = buddy.unreadCount + 1;
                        buddy.save();
                        SessionData.getInstance().setChatbadgeMissed(true);
                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        context.sendBroadcast(iintent);
                    } else {
                        buddy.unreadCount = buddy.unreadCount + 1;
                        buddy.save();
                    }

                    if (Conversation.isNewBuddyConversation(String.valueOf(buddyId))) {
                        Logger.error(TAG, "Is New Conversation");
                        Logger.error(TAG,"Message type = "+message.get(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                        Conversation conversation = new Conversation();
                        conversation.buddyID = buddyId;
                        conversation.unreadCount = conversation.unreadCount + 1;
                        conversation.timestamp = message.getLong("sent");
                        conversation.lstMessage =  processLastRecentMessage(message.getString("message"),message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                        conversation.name = buddy.name;
                        conversation.avtarUrl = buddy.avatarURL;
                        conversation.save();

                    } else {
                        Logger.error(TAG, "Is old Conversation");
                        Logger.error(TAG,"Message type = "+message.get(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                        Conversation conversation = Conversation.getConversationByBuddyID(String.valueOf(buddyId));
                        if (conversation != null) {
                            conversation.timestamp = message.getLong("sent");
                            conversation.lstMessage =  processLastRecentMessage(message.getString("message"),message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                            conversation.name = buddy.name;
                            conversation.avtarUrl = buddy.avatarURL;
                            conversation.unreadCount = conversation.unreadCount + 1;
                            conversation.save();
                        }
                    }

                    Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    iintent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_RECENT_FRAGMENT, 1);
                    PreferenceHelper.getContext().sendBroadcast(iintent);

                   /* Intent intent = new Intent(
                            BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                    context.sendBroadcast(intent);*/
                }
            }
            return isNew;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    /**
     * @param message : Pass single received message JSONObject
     */
    public boolean handleChatroomMessage(JSONObject message) {
        try {
            int messageProcessed = 1;
            SessionData session = SessionData.getInstance();
            String mess = message.getString(CometChatKeys.AjaxKeys.MESSAGE);
            message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, "");
            message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, StaticMembers.DEFAULT_TEXT_COLOR);
            message.put(DatabaseKeys.ColoumnKeys.MESSAGE_INSERTED_BY, 0);
            long chatroomid = 0;
            if (message.has(CometChatKeys.ChatroomKeys.CHATROOMID)) {
                message.put(CometChatKeys.ChatroomKeys.CHATROOMID, message.getString(CometChatKeys.ChatroomKeys.CHATROOMID));
                chatroomid = message.getLong(CometChatKeys.ChatroomKeys.CHATROOMID);
            } else if (message.has(CometChatKeys.ChatroomKeys.ROOMID)) {
                message.put(CometChatKeys.ChatroomKeys.CHATROOMID, message.getString(CometChatKeys.ChatroomKeys.ROOMID));
                chatroomid = message.getLong(CometChatKeys.ChatroomKeys.ROOMID);
            }
            Logger.error("chatroom message " + mess);

            if (chatroomid != 0) {
                JSONObject temp;
                if (PreferenceHelper.contains(CometChatKeys.ChatroomKeys.CHATROOM_JSON)) {
                    temp = new JSONObject(PreferenceHelper.get(CometChatKeys.ChatroomKeys.CHATROOM_JSON));
                } else {
                    temp = new JSONObject();
                }
                temp.put(String.valueOf(chatroomid), message.getString(AjaxKeys.ID));
                PreferenceHelper.save(CometChatKeys.ChatroomKeys.CHATROOM_JSON, temp.toString());
            }
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(CometChatKeys.AjaxKeys.SENT)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
            } else {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT));
            }

            if (mess.contains("jqcc.cc")) {
                if (VideoChat.isCrAvchatRequest(mess)) {
                    if (VideoChat.isConferenceDisabled()) {
                        return false;
                    }
                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1));
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    } else {
                        String roomname = VideoChat.getAVConferenceRoomName(mess);
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }

                } else if (VideoChat.isCrAudioCHatRequest(mess)) {
                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1));
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO_CONFERENCE);
                    } else {
                        String roomname = VideoChat.getAudioConferenceRoomName(mess);
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO_CONFERENCE);
                    }
                } else if (OtherPlugins.isScreehShareRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    Elements anchortag = doc.select(StaticMembers.ANCHOR_TAG);
                    String grp = anchortag.attr("grp");

                  /*  message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*/
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.SCREENSHARE_REQUEST);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + grp);

                } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                    /*Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*/


                    Document doc = Jsoup.parseBodyFragment(mess);
                    String randomid = OtherPlugins.getRandomId(mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WRITEBOARD_REQUEST);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + randomid);

                } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + OtherPlugins.getWhiteBoardRoomName(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST);
                } else if (AVBroadcast.isCrAVBroadcast(mess)) {
                    String roomname = AVBroadcast.getCRGroupName(mess, false);
                    mobileLangs = JsonPhp.getInstance().getLang().getMobile();
                    if (null != mobileLangs) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, JsonPhp.getInstance().getLang().getMobile().get160() + "##" + roomname);
                    } else {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    }
                    //message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVBROADCAST);

                    /*Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*/

                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("CC^CONTROL_")) {
                if (OtherPlugins.isBotResponce(mess)) {
                    String trimedMess = mess.replace("CC^CONTROL_", "");
                    JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, jsonParams);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                } else if (ChatroomManager.isDeleteChatroomMessage(mess)) {
                    String substring = mess.substring(Math.max(mess.length() - 2, 0));

                    Chatroom.deleteChatroom(Long.parseLong(substring));
                    Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                    intent.putExtra(
                            BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                    PreferenceHelper.getContext().sendBroadcast(intent);
                    SessionData.getInstance().setChatroomListBroadcastMissed(true);

                } else if (ChatroomManager.isKickedChatroomMessage(mess)) {
                    String[] kickSplitedMessage = mess.split("_");
                    String kicked = kickSplitedMessage[kickSplitedMessage.length - 1];
                    if (!kicked.equals(CometChatKeys.ChatroomKeys.KICKED)) {
                        if (Long.parseLong(kicked) == session.getId()) {
                            if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
                                ChatroomManager.kickUser(message.getString(CometChatKeys.AjaxKeys.SENT));
                            } else {
                                ChatroomManager.kickUser(message.getString(CometChatKeys.AjaxKeys.ID));
                            }
                            ChatroomManager.leaveChatroom(session.getCurrentChatroom(), "2");
                        }
                    }
                    return false;
                } else if (ChatroomManager.isBannedChatroomMessage(mess)) {

					/* Message is CC^CONTROL_banned_*userid value* */
                    String[] banSplitedMessage = mess.split("_");
                    String banned = banSplitedMessage[banSplitedMessage.length - 1];
                    if (!banned.equals(CometChatKeys.ChatroomKeys.BANNED)) {
                        if (Long.parseLong(banned) == session.getId()) {
                            if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
                                ChatroomManager.banUser(message.getString(CometChatKeys.AjaxKeys.SENT));
                            } else {
                                ChatroomManager.banUser(message.getString(CometChatKeys.AjaxKeys.ID));
                            }
                            ChatroomManager.leaveChatroom(session.getCurrentChatroom(), "1");
                        }
                    }
                    /*
                     * We don't need to insert this message in database so
					 * return from here
					 */
                    return false;
                } else if (ChatroomManager.isDeleteMessage(mess)) {
                    ChatroomMessage.deleteMessage(ChatroomManager.getMessageId(mess));
                    return true;
                } else if (AVBroadcast.isAVBroadcastEnd(mess)) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, null == JsonPhp.getInstance().getLang().getMobile().get166() ? "This broadcast has ended" : JsonPhp.getInstance().getLang().getMobile().get166());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                    if (!message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            && !message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        if (VideoChatActivity.videoChatActivity != null) {
                            VideoChatActivity.videoChatActivity.endcall();
                        }
                    }
                } else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.STICKERS);
                } else {
                    messageProcessed = 2;
                }

            } else if (mess.contains("plugins/filetransfer")) {
                if (ImageSharing.isIncomingChatroomImage(mess)) {
                    // Logger.error("chatrom message="+message);
                    /*
                     * Replace the message value by the image link and use it in
					 * the adapter
					 */
                    String url = ImageSharing.getImageURL(mess);
                    int startIndex = url.indexOf(StaticMembers.FILE_PREFIX) + StaticMembers.FILE_PREFIX.length();
                    String fileName;
                    try {
                        fileName = URLEncoder.encode((url.substring(startIndex, url.length())), StaticMembers.UTF_8);
                    } catch (UnsupportedEncodingException e1) {
                        fileName = url.substring(startIndex, url.length());
                        e1.printStackTrace();
                    }

                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, url);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, LocalStorageFactory.getImageStoragePath() + fileName);

                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {

						/* Image send by me, update url to database */
                        ChatroomMessage messagePojo = ChatroomMessage.findById(message
                                .getString(CometChatKeys.AjaxKeys.ID));
                        if (null != messagePojo) {
                            messagePojo.imageUrl = url;
                            messagePojo.save();
                        }
                    }

                    File file = new File(LocalStorageFactory.getImageStoragePath() + fileName);
                    if (file.exists()) {
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
                                CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED);
                    } else {
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.IMAGE_NEW);
                        LocalStorageFactory.saveIncomingImage(fileName, url, null, true,
                                message.getString(CometChatKeys.AjaxKeys.ID), false);
                    }
                } else if (VideoSharing.isIncomingChatroomVideo(mess)) {
                    String url = ImageSharing.getImageURL(mess);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, url);
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, url);

                    int startIndex = url.indexOf(StaticMembers.FILE_PREFIX) + StaticMembers.FILE_PREFIX.length();
                    String fileName;
                    try {
                        fileName = URLEncoder.encode((url.substring(startIndex, url.length())), StaticMembers.UTF_8);
                    } catch (UnsupportedEncodingException e1) {
                        fileName = url.substring(startIndex, url.length());
                        e1.printStackTrace();
                    }

                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        /* Image send by me, update url to database */
                        ChatroomMessage pojo = ChatroomMessage.findById(message.getLong(CometChatKeys.AjaxKeys.ID));
                        if (null != pojo) {
                            pojo.imageUrl = url;
                            pojo.save();
                            return false;
                        }
                    }

                    File file = new File(LocalStorageFactory.getVideoStoragePath() + fileName);
                    if (file.exists()) {
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
                                CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED);
                        message.put(DatabaseKeys.ColoumnKeys.MESSAGE, file.toString());
                    } else {
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.VIDEO_NEW);
                    }
                } else if (AudioSharing.isIncomingAudio(mess)) {
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO_NEW);
                    String audioUrl = ImageSharing.getImageURL(mess);
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, audioUrl);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, audioUrl);
                    AudioSharing.downloadAndStoreAudio(message.getString(CometChatKeys.AjaxKeys.ID), audioUrl, true);
                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        ChatroomMessage pojo = ChatroomMessage.findById(message.getLong(CometChatKeys.AjaxKeys.ID));
                        if (null != pojo) {
                            pojo.imageUrl = audioUrl;
                            pojo.save();
                            return false;
                        }
                    }
                } else if (ImageSharing.isFileTransfer(mess)) {
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, mess);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, ImageSharing.getImageURL(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.FILE_NEW);
                    //return false;
                } else {
                    messageProcessed = 2;
                }

            } else if (mess.contains("/plugins/handwrite/") || mess.contains("/writable/handwrite/")) {
                if (OtherPlugins.isHandWrite(mess)) {
                    Logger.error(TAG, "Handwrite message = " + mess);
                    String url = OtherPlugins.getHandwriteImageUrl(mess);
                    int startIndex = url.lastIndexOf("/") + 1;
                    String fileName;
                    try {
                        fileName = URLEncoder.encode((url.substring(startIndex, url.length())), StaticMembers.UTF_8);
                    } catch (UnsupportedEncodingException e1) {
                        fileName = url.substring(startIndex, url.length());
                        e1.printStackTrace();
                    }

                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, url);
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE,
                            doc.text().split("\\.")[0] + "|" + LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITE_NEW);

                    LocalStorageFactory.saveIncomingImage(fileName, url, null, true,
                            message.getString(CometChatKeys.AjaxKeys.ID), true);
                } else {
                    messageProcessed = 2;
                }
            } else {
                if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                        || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), true));
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), false));
                }
                message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, ChatroomManager.getTextColor());
                messageProcessed = 0;
            }
            if (messageProcessed == 2) {
                return false;
            }

            if (messageProcessed == 1) {
                mess = message.getString(CometChatKeys.AjaxKeys.MESSAGE);
                if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(meText)
                        || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), true));
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), false));
                }
                message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                //message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, ChatroomManager.getTextColor());
            }

            if (message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                message.put(CometChatKeys.AjaxKeys.FROM, meText);
            } else {
                message.put(CometChatKeys.AjaxKeys.FROM, message.getString(DatabaseKeys.ColoumnKeys.FROM));
            }
            message.put(CometChatKeys.AjaxKeys.SENT, serverTime);

            boolean isNew = true;

            if(message.getLong(DatabaseKeys.ColoumnKeys.FROMID) == session.getId()){
                Logger.error(TAG,"Is my message");
                String timestamp = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_LAST_UPDATED_TIMESTAMP);
                long lstUpdated = Long.parseLong(timestamp)+(30*1000);
                if(message.getLong("sent")<lstUpdated){
                    isNew = false;
                }
            }
            if(isNew){
                ChatroomMessage pojo = ChatroomMessage.findById(message.getString(CometChatKeys.AjaxKeys.ID));
                if (null == pojo) {
                    pojo = new ChatroomMessage(message);
                } else {
                    isNew = false;
                }
                pojo.save();
            }

            //session.setChatroomBroadcastMissed(true);
            session.setChatroomListBroadcastMissed(true);
            Chatroom chatroom;
            if (message.has(CometChatKeys.ChatroomKeys.CHATROOMID)) {
                chatroom = Chatroom.getChatroomDetails(message.getString(CometChatKeys.ChatroomKeys.CHATROOMID));
            } else if (message.has(CometChatKeys.ChatroomKeys.ROOMID)) {
                chatroom = Chatroom.getChatroomDetails(message.getString(CometChatKeys.ChatroomKeys.ROOMID));
            } else {
                chatroom = Chatroom.getChatroomDetails(session.getCurrentChatroom());
            }
            /* If message chatroom id is not equals current chatroom id then update unread count */

            if ((message.has(CometChatKeys.ChatroomKeys.CHATROOMID)
                    && !(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID)).equals(message.getString(CometChatKeys.ChatroomKeys.CHATROOMID)))
                    || ((message.has(CometChatKeys.ChatroomKeys.ROOMID))
                    && !(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID)).equals(message.getString(CometChatKeys.ChatroomKeys.ROOMID)))) {

                long chatroomWindowId = Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID));
                if ((chatroomWindowId != chatroom.chatroomId || chatroomWindowId == 0) && isNew && message.getLong(DatabaseKeys.ColoumnKeys.FROMID) != session.getId()) {

                    if (chatroom.unreadCount == 0) {
                        /*int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT));
                        count++;
                        PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT, 1);
                                SessionData.getInstance().setChatbadgeMissed(true);*/
                        chatroom.unreadCount = chatroom.unreadCount + 1;
                        chatroom.lastUpdated = System.currentTimeMillis();
                        chatroom.save();

                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_CHATROOM_MESSAGE, 1);
                        context.sendBroadcast(iintent);
                    } else {
                        chatroom.unreadCount = chatroom.unreadCount + 1;
                        chatroom.lastUpdated = System.currentTimeMillis();
                        chatroom.save();
                    }

                    if (Conversation.isNewChatroomConversation(String.valueOf(message.getLong("chatroomid")))) {
                        Logger.error(TAG, "Is New Chatroom Conversation");
                        Conversation conversation = new Conversation();
                        conversation.chatroomID = message.getLong("chatroomid");
                        conversation.timestamp = message.getLong("sent");
                        conversation.lstMessage = processLastRecentMessage(message.getString("message"),message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                        //conversation.lstMessage =  message.getString("message");
                        conversation.name = chatroom.name;
                        conversation.avtarUrl = "";
                        conversation.unreadCount = conversation.unreadCount + 1;
                        conversation.save();
                    } else {
                        Logger.error(TAG, "Is old chatroom Conversation");
                        Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(message.getLong("chatroomid")));
                        if (conversation != null) {
                            conversation.timestamp = message.getLong("sent");
                            conversation.lstMessage = processLastRecentMessage(message.getString("message"),message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE));
                            conversation.unreadCount = conversation.unreadCount + 1;
                            conversation.name = chatroom.name;
                            conversation.avtarUrl = "";
                            conversation.save();
                        }
                    }

                    Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    iintent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_RECENT_FRAGMENT, 1);
                    PreferenceHelper.getContext().sendBroadcast(iintent);
                }

                Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                context.sendBroadcast(intent);
            } else {
                if (null != chatroom) {
                    chatroom.lastUpdated = System.currentTimeMillis();
                    chatroom.save();
                }
            }
            return isNew;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }

    public void addNewBuddy(Long buddyId, final Context context, final CometchatCallbacks callbacks, final int showUser) {
        try {
            RequestQueue queue = Volley.newRequestQueue(context);
            final HashMap<String, String> nameValuePair = new HashMap<>();
            nameValuePair.put(AjaxKeys.BASE_DATA, SessionData.getInstance().getBaseData());
            nameValuePair.put(AjaxKeys.CALLBACK_FN, AjaxKeys.CALLBACK_FN_VALUE);
            // nameValuePair.put(AjaxKeys.VERSION, "1");
            nameValuePair.put(AjaxKeys.VERSION2, "1");
            nameValuePair.put(AjaxKeys.VERSION3, "1");
            nameValuePair.put(AjaxKeys.CALLBACK, "jqcc17108543446448165930_" + System.currentTimeMillis());
            nameValuePair.put(AjaxKeys.USERID, String.valueOf(buddyId));
            String url = URLFactory.getInfoFromId();
            if (url.startsWith("https")) {
                CommonUtils.allowHttpsConnection();
            }
            StringRequest request = new StringRequest(Method.POST, url, new Listener<String>() {

                @Override
                public void onResponse(String response) {
                    // Logger.error("success response  of add new buudy" +
                    // response);
                    nameValuePair.clear();
                    try {
                        JSONObject newBuddyJson = new JSONObject(response);

                        Buddy.insertNewBuddy(newBuddyJson, showUser);

                        Intent intent = new Intent(
                                BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                        intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                        context.sendBroadcast(intent);
                        SessionData.getInstance().setBuddyListBroadcastMissed(true);
                        callbacks.successCallback();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }

                }
            }, new Response.ErrorListener() {

                @Override
                public void onErrorResponse(VolleyError response) {
                    // Logger.error("fail response " + response);
                    nameValuePair.clear();
                    Logger.error("404 in sending ajax addnewbuddy");
                    callbacks.successCallback();

                }
            }) {
                @Override
                protected Map<String, String> getParams() throws AuthFailureError {
                    return nameValuePair;
                }
            };
            queue.add(request);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    public static String processLastRecentMessage(String message , String messageType){
        switch (messageType){

            case CometChatKeys.MessageTypeKeys.IMAGE_NEW :
            case CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED :
                return CometChatKeys.RecentMessageTypes.IMAGE;

            case CometChatKeys.MessageTypeKeys.AUDIO_IS_DOWNLOADING :
            case CometChatKeys.MessageTypeKeys.AUDIO_NEW :
            case CometChatKeys.MessageTypeKeys.AUDIO_UPLOAD :
            case CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED :

                return CometChatKeys.RecentMessageTypes.AUDIO;

            case CometChatKeys.MessageTypeKeys.STICKERS:

                return CometChatKeys.RecentMessageTypes.STICKER;

            case CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED:
            case CometChatKeys.MessageTypeKeys.VIDEO_NEW:
            case CometChatKeys.MessageTypeKeys.VIDEO_UPLOAD:
            case CometChatKeys.MessageTypeKeys.VIDEO_IS_DOWNLOADING:

                return CometChatKeys.RecentMessageTypes.VIDEO;

            case CometChatKeys.MessageTypeKeys.FILE_NEW:
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADING:
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADED:

                return CometChatKeys.RecentMessageTypes.FILE;

            case CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED:
            case CometChatKeys.MessageTypeKeys.HANDWRITE_NEW:

                return CometChatKeys.RecentMessageTypes.HANDWRITE;

            default:
                return message;
        }
    }
}