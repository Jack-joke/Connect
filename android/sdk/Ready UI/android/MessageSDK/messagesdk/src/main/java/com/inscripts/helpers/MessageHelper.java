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
import com.google.gson.Gson;
import com.inscripts.cometchat.sdk.AVBroadcast;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.cometchat.sdk.CometChatroom;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.jsonphp.Audiochat;
import com.inscripts.jsonphp.Avchat;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.AvchatMessageTypeKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.AVBroadcastplugin;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.Smilies;
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
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.File;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;

public class MessageHelper {

    private static MessageHelper messagerHelper;
    private SubscribeChatroomCallbacks chatroomCallback;
    private Context context = PreferenceHelper.getContext();
    private static Avchat avchatJsonPhp;
    private static Audiochat audiochat;
    private static String meText;
    private long serverTime;
    private Mobile mobileLangs;
    private static String textColor;
    private static Config config;

    public static MessageHelper getInstance() {

        if (messagerHelper == null) {
            messagerHelper = new MessageHelper();
        }
        if (null == JsonPhp.getInstance().getConfig()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                Gson gson = new Gson();
                JsonPhp.setInstance(gson.fromJson(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
            }
        }

        config = JsonPhp.getInstance().getConfig();
        avchatJsonPhp = JsonPhp.getInstance().getLang().getAvchat();
        audiochat = JsonPhp.getInstance().getLang().getAudiochat();
        meText = null == JsonPhp.getInstance().getLang() ? StaticMembers.ME_TEXT : JsonPhp.getInstance().getLang().getMobile().get6();
        return messagerHelper;
    }


    /**
     * @param message : Pass single received message JSONObject
     */
    @SuppressLint("DefaultLocale")
    public boolean handleOneOnOneMessage(Buddy buddy, JSONObject message) {
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

                    Logger.error("Screen share message = "+doc.text().split("\\.")[0] + ".\n"
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

                if(OtherPlugins.isBotResponce(mess)){
                    String trimedMess = mess.replace("CC^CONTROL_","");
                    JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, jsonParams);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                }else if (VideoChat.isAVChatCallRejected(mess)) {
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
                    Intent intent = new Intent(
                            BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                    context.sendBroadcast(intent);
                }
            }
            return isNew;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
/*

    */
/**
     * @param message : Pass single received message JSONObject
     *//*

    @SuppressLint("DefaultLocale")
    public boolean handleOneOnOneMessage(Buddy buddy, JSONObject message) {
        int messageProcessed = 1;
        try {

            SessionData session = SessionData.getInstance();
            Long buddyId = buddy.buddyId;
            String buddyName = buddy.name;

            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
            } else {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT));
            }
            String mess = message.getString(AjaxKeys.MESSAGE);
            message.put(AjaxKeys.SENT, serverTime);
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

                    message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get29() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);


                    String servertime = SessionData.getInstance().getServerTime();
                    long diff = 0;
                    boolean callAcceptCondition = session.getUserInfoHeartBeatFlag().equals("0") && session.getAvchatStatus() == 0;
                    if (!TextUtils.isEmpty(servertime)) {
                        servertime += "000";
                        diff = ((Long.parseLong(servertime) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE))) - message.getLong(AjaxKeys.SENT));
                        callAcceptCondition = callAcceptCondition && (diff != 0 && diff < 60000);
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
                                    message.getString(AjaxKeys.FROM));
                            context.startActivity(intent);
                        } else {
                            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                    URLFactory.getAVChatURL());
                            vHelper.addNameValuePair(AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                            vHelper.addNameValuePair(AjaxKeys.TO, String.valueOf(buddyId));
                            // vHelper.sendCallBack(false);
                            vHelper.sendAjax();
                        }
                    }

                } else if (VideoChat.isAVChatAccepted(mess)) {
                    if (VideoChat.isDisabled()) {
                        return false;
                    }

                    message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);

                    Intent intent = new Intent(BroadcastReceiverKeys.AvchatKeys.EVENT_AVCHAT_ACCEPTED);
                    intent.putExtra(BroadcastReceiverKeys.AvchatKeys.AVCHAT_CALLER_ID,
                            message.getString(AjaxKeys.FROM));
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
                    message.put(AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get29() : audiochat.get29() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    String servertime = SessionData.getInstance().getServerTime();
                    long diff = 0;
                    boolean callAcceptCondition = session.getUserInfoHeartBeatFlag().equals("0") && session.getAvchatStatus() == 0;
                    if (!TextUtils.isEmpty(servertime)) {
                        servertime += "000";
                        diff = ((Long.parseLong(servertime) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE))) - message.getLong(AjaxKeys.SENT));
                        callAcceptCondition = callAcceptCondition && (diff != 0 && diff < 60000);
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
                                message.getString(AjaxKeys.FROM));
                        context.startActivity(intent);
                    } else {
                        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                URLFactory.getAudioChatURL());
                        vHelper.addNameValuePair(AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                        vHelper.addNameValuePair(AjaxKeys.TO, String.valueOf(buddyId));
                        // vHelper.sendCallBack(false);
                        vHelper.sendAjax();
                    }

                } else if (VideoChat.isAudioChatAccepted(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }

                    message.put(AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get30() : audiochat.get30() + " " + buddyName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);

                    Intent intent = new Intent(BroadcastReceiverKeys.AvchatKeys.EVENT_AVCHAT_ACCEPTED);
                    intent.putExtra(BroadcastReceiverKeys.AvchatKeys.AVCHAT_CALLER_ID,
                            message.getString(AjaxKeys.FROM));
                    intent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, VideoChat.getAVRoomName(mess, true));
                    intent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                    context.sendBroadcast(intent);

                } else if (VideoChat.isAudioChatSentSuccessful(mess)) {
                    return false;
                } else if (AVBroadcastplugin.isAVBroadcast(mess)) {
                    String roomname = AVBroadcastplugin.getGroupName(mess, false);

                    */
/*Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);*//*

                    mobileLangs = JsonPhp.getInstance().getLang().getMobile();
                    if (null != mobileLangs) {
                        message.put(AjaxKeys.MESSAGE, JsonPhp.getInstance().getLang().getMobile().get160() + "##" + roomname);
                    } else {
                        message.put(AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    }
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVBROADCAST);

                } else if (OtherPlugins.isGameAccept(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isGameRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isScreehShareRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    Elements anchortag = doc.select(StaticMembers.ANCHOR_TAG);
                    String grp = anchortag.attr("grp");
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.SCREENSHARE_REQUEST);
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + grp);

                    Logger.error("Screen share message = "+doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + grp);

                } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + OtherPlugins.getWhiteBoardRoomName(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST);
                } else {
                    //Logger.error("in else of jqcc , message is not processed");
                    messageProcessed = 2;
                }
            } else if (mess.contains("CC^CONTROL_")) {
                Logger.error("Mess CC control = " + mess + "IS BOT mess "+OtherPlugins.isBotResponce(mess));
                if(OtherPlugins.isBotResponce(mess)){
                    String trimedMess = mess.replace("CC^CONTROL_","");
                    JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, jsonParams);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                }
                if (VideoChat.isAVChatCallRejected(mess)) {
                    session.setAvchatStatus(0);
                    if (VideoChat.isDisabled()) {
                        return false;
                    }

                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                        message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " "
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

                        message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get31() + " " + callDuration);
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
                        message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get33() + " " + buddyName);
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
                            message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " "
                                    + avchatJsonPhp.get34().toLowerCase());
                            message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                        } else {
                            return false;
                        }
                    }
                } else if (VideoChat.isAVChatBusyCall(mess)) {
                    message.put(AjaxKeys.MESSAGE, avchatJsonPhp.get30() + " " + buddyName + " busy");
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
                        message.put(AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get30()
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

                        message.put(AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get31()
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
                        message.put(AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get33()
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
                        message.put(AjaxKeys.MESSAGE, (audiochat == null) ? avchatJsonPhp.get30()
                                : audiochat.get30() + " " + buddyName + " " + avchatJsonPhp.get34().toLowerCase());
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    } else {
                        return false;
                    }

                } else if (VideoChat.isAudioChatBusyCall(mess)) {
                    if (VideoChat.isAudioChatDisabled()) {
                        return false;
                    }
                    message.put(AjaxKeys.MESSAGE,
                            (audiochat == null) ? avchatJsonPhp.get30() : audiochat.get30() + " " + buddyName + " busy");
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    if (OutgoingCallActivity.outgoingCallActivity != null) {
                        OutgoingCallActivity.outgoingCallActivity.finish();
                    }

                } else if (AVBroadcastplugin.isAVBroadcastEnd(mess)) {
                    message.put(AjaxKeys.MESSAGE, null == JsonPhp.getInstance().getLang().getMobile().get166() ? "This broadcast has ended" : JsonPhp.getInstance().getLang().getMobile().get166());
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
                    message.put(AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.STICKERS);
                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("plugins/filetransfer")) {
                if (ImageSharing.isIncomingImage(mess)) {
                    // Logger.error("chatrom message="+message);
                    */
/*
                     * Replace the message value by the image link and use it in
					 * the adapter
					 *//*

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
                    message.put(AjaxKeys.MESSAGE, LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.IMAGE_NEW);

                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage temp = OneOnOneMessage.findById(message.getLong(AjaxKeys.ID));
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
                                message.getString(AjaxKeys.ID), false);
                    }
                } else if (VideoSharing.isIncomingVideo(mess)) {
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.VIDEO_NEW);
                    String videoUrl = ImageSharing.getImageURL(mess);
                    message.put(DatabaseKeys.ColoumnKeys.MESSAGE, videoUrl);
                    message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, videoUrl);

                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage pojo = OneOnOneMessage.findById(message.getLong(AjaxKeys.ID));
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
                    AudioSharing.downloadAndStoreAudio(message.getString(AjaxKeys.ID), audioUrl, false);
                    if (1 == message.getInt(DatabaseKeys.ColoumnKeys.SELF)) {
                        OneOnOneMessage pojo = OneOnOneMessage.findById(message.getLong(AjaxKeys.ID));
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
                    message.put(AjaxKeys.MESSAGE, joinChatroomMessage);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
                            CometChatKeys.MessageTypeKeys.JOIN_CHATROOM_MESSAGE);
                } else {
                    messageProcessed = 2;
                }
            } else if (mess.contains("/plugins/handwrite/")) {
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
                    message.put(AjaxKeys.MESSAGE,
                            doc.text().split("\\.")[0] + "|" + LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITE_NEW);
                    LocalStorageFactory.saveIncomingImage(fileName, url, null, false,
                            message.getString(AjaxKeys.ID), true);

                } else {
                    messageProcessed = 2;
                }
            } else {
                */
/* normal message *//*

                */
/*
                 * if (isNotComet) { if
				 * (message.getString(CometChatKeys.AjaxKeys .OLD).equals("1"))
				 * { return; } }
				 *//*

                if (AVBroadcastplugin.isAVBroadcastInvite(mess)) {
                    String roomname = AVBroadcastplugin.getInviteGroupName(mess);
                    message.put(AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                    //message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVBROADCAST);
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(CommonUtils.handleLink(mess));
                    message.put(AjaxKeys.MESSAGE, mess);
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
                            CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getDeliveredTickMessage(message.getString(AjaxKeys.ID)));
                        } else if (transport.equals("cometservice-selfhosted")) {
                           */
/* WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getDeliveredTickMessage(message.getString(AjaxKeys.ID)));*//*

                        }

                    }
                }
            }

            if (messageProcessed == 0) {
                mess = CommonUtils.handleSpecialHtmlCharacters(CommonUtils.handleLink(mess));
                message.put(AjaxKeys.MESSAGE, mess);
                message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
            }

            session.setOneToOneBroadCastMissed(true);
            session.setBuddyListBroadcastMissed(true);

            message.put(AjaxKeys.OLD, "1");
            message.put(AjaxKeys.TO, session.getId());
            message.put(AjaxKeys.SENT, serverTime);

            boolean isNew;
            OneOnOneMessage pojo = OneOnOneMessage.findById(message.getString(AjaxKeys.ID));
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
                        SessionData.getInstance().setChatbadgeMissed(true);
                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        context.sendBroadcast(iintent);
                    }
                    buddy.unreadCount = buddy.unreadCount + 1;
                    buddy.save();
                    Intent intent = new Intent(
                            BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                    intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                    context.sendBroadcast(intent);
                }
            }
            return isNew;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
    }
*/

    /**
     * @param message : Pass single received message JSONObject
     */
    public boolean handleChatroomMessage(JSONObject message) {
        Logger.error("chatrom handle messages =" + message);

        try {
            int messageProcessed = 1;
            long chatroomid = 0;
            SessionData session = SessionData.getInstance();
            String mess = message.getString(AjaxKeys.MESSAGE);
            message.put(DatabaseKeys.ColoumnKeys.IMAGE_URL, "");
            message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, StaticMembers.DEFAULT_TEXT_COLOR);
            message.put(DatabaseKeys.ColoumnKeys.MESSAGE_INSERTED_BY, 0);
            if (message.has("chatroomid")) {
                message.put("chatroomid", message.getString("chatroomid"));
                chatroomid = message.getLong("chatroomid");
            } else if (message.has("roomid")) {
                message.put("chatroomid", message.getString("roomid"));
                chatroomid = message.getLong("roomid");
            }
            if (chatroomid != 0) {
                JSONObject temp;
                if (PreferenceHelper.contains("ccjsonObject")) {
                    temp = new JSONObject(PreferenceHelper.get("ccjsonObject"));
                } else {
                    temp = new JSONObject();
                }
                temp.put(String.valueOf(chatroomid), message.getString(AjaxKeys.ID));
                PreferenceHelper.save("ccjsonObject", temp.toString());
            }
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
            } else {
                serverTime = CommonUtils.correctIncomingTimestamp(message.getLong(AjaxKeys.SENT));
            }
            //Logger.error("Time chatroom " + serverTime);

            if (mess.contains("jqcc.cc")) {
                if (VideoChat.isCrAvchatRequest(mess)) {
                    if (VideoChat.isConferenceDisabled()) {
                        return false;
                    }
                    if (message.getString(AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        message.put(AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1));
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    } else {
                        String roomname = VideoChat.getAVConferenceRoomName(mess);
                        message.put(AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
                        message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AVCHAT);
                    }

                } else if (OtherPlugins.isScreehShareRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getMobile().get60());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);

                } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                    Document doc = Jsoup.parseBodyFragment(mess);
                    message.put(AjaxKeys.MESSAGE, doc.text().split("\\.")[0] + ".\n"
                            + JsonPhp.getInstance().getLang().getCore().get47() + "|#|" + OtherPlugins.getWhiteBoardRoomName(mess));
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST);
                } else if (AVBroadcastplugin.isCrAVBroadcast(mess)) {
                    String roomname = AVBroadcastplugin.getCRGroupName(mess, false);
                    mobileLangs = JsonPhp.getInstance().getLang().getMobile();
                    if (null != mobileLangs) {
                        message.put(AjaxKeys.MESSAGE, JsonPhp.getInstance().getLang().getMobile().get160() + "##" + roomname);
                    } else {
                        message.put(AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1) + "##" + roomname);
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

                if(OtherPlugins.isBotResponce(mess)){
                    String trimedMess = mess.replace("CC^CONTROL_","");
                    JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, jsonParams);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                }else if (ChatroomManager.isKickedChatroomMessage(mess)) {

					/* Message is CC^CONTROL_kicked_*userid value* */
                    String[] kickSplitedMessage = mess.split("_");
                    String kicked = kickSplitedMessage[kickSplitedMessage.length - 1];
                    if (!kicked.equals(CometChatKeys.ChatroomKeys.KICKED)) {
                        if (Long.parseLong(kicked) == session.getId()) {
                            if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
                                ChatroomManager.kickUser(message.getString(AjaxKeys.SENT));
                            } else {
                                ChatroomManager.kickUser(message.getString(AjaxKeys.ID));
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
                                ChatroomManager.banUser(message.getString(AjaxKeys.SENT));
                            } else {
                                ChatroomManager.banUser(message.getString(AjaxKeys.ID));
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
                } else if (AVBroadcastplugin.isAVBroadcastEnd(mess)) {
                    message.put(AjaxKeys.MESSAGE, null == JsonPhp.getInstance().getLang().getMobile().get166() ? "This broadcast has ended" : JsonPhp.getInstance().getLang().getMobile().get166());
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                    if (!message.getString(AjaxKeys.FROM).equals(meText)
                            && !message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        if (VideoChatActivity.videoChatActivity != null) {
                            VideoChatActivity.videoChatActivity.endcall();
                        }
                    }
                } else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
                    message.put(AjaxKeys.MESSAGE, mess);
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
                    message.put(AjaxKeys.MESSAGE, LocalStorageFactory.getImageStoragePath() + fileName);

                    if (message.getString(AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {

						/* Image send by me, update url to database */
                        ChatroomMessage messagePojo = ChatroomMessage.findById(message
                                .getString(AjaxKeys.ID));
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
                                message.getString(AjaxKeys.ID), false);
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

                    if (message.getString(AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        /* Image send by me, update url to database */
                        ChatroomMessage pojo = ChatroomMessage.findById(message.getLong(AjaxKeys.ID));
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
                    AudioSharing.downloadAndStoreAudio(message.getString(AjaxKeys.ID), audioUrl, true);
                    if (message.getString(AjaxKeys.FROM).equals(meText)
                            || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        ChatroomMessage pojo = ChatroomMessage.findById(message.getLong(AjaxKeys.ID));
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

            } else if (mess.contains("/plugins/handwrite/")) {
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
                    message.put(AjaxKeys.MESSAGE,
                            doc.text().split("\\.")[0] + "|" + LocalStorageFactory.getImageStoragePath() + fileName);
                    message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITE_NEW);

                    LocalStorageFactory.saveIncomingImage(fileName, url, null, true,
                            message.getString(AjaxKeys.ID), true);
                } else {
                    messageProcessed = 2;
                }
            } else {
                if (message.getString(AjaxKeys.FROM).equals(meText)
                        || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), true));
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), false));
                }
                message.put(AjaxKeys.MESSAGE, mess);
                message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, ChatroomManager.getTextColor());
                messageProcessed = 0;
            }
            if (messageProcessed == 2) {
                return false;
            }

            if (messageProcessed == 1) {
                mess = message.getString(AjaxKeys.MESSAGE);
                if (message.getString(AjaxKeys.FROM).equals(meText)
                        || message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), true));
                } else {
                    mess = CommonUtils.handleSpecialHtmlCharacters(ChatroomManager.getColoredText(
                            CommonUtils.handleLink(mess), false));
                }
                message.put(AjaxKeys.MESSAGE, mess);
                //message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
                message.put(DatabaseKeys.ColoumnKeys.TEXT_COLOR, ChatroomManager.getTextColor());
            }

            if (message.getString(DatabaseKeys.ColoumnKeys.FROMID).equals(String.valueOf(session.getId()))) {
                message.put(AjaxKeys.FROM, meText);
            } else {
                message.put(AjaxKeys.FROM, message.getString(DatabaseKeys.ColoumnKeys.FROM));
            }
            message.put(AjaxKeys.SENT, serverTime);

            boolean isNew = true;
            ChatroomMessage pojo = ChatroomMessage.findById(message.getString(AjaxKeys.ID));
            if (null == pojo) {
                pojo = new ChatroomMessage(message);
            } else {
                isNew = false;
            }
            pojo.save();

            Logger.error("Chatroom MessageHandler message = "+message);
            LoginCallbacks loginCallbacks = HeartbeatChatroom.getInstance().getReadyUIListner();
            if(loginCallbacks!=null){
                JSONObject chatroomMess = new JSONObject();
                chatroomMess.put("message_id",message.get("id"));
                chatroomMess.put("chatroom_id",message.get("chatroomid"));
                chatroomMess.put("user_id",message.get("fromid"));

                loginCallbacks.onMessageReceive(chatroomMess);
            }

            //session.setChatroomBroadcastMissed(true);
            session.setChatroomListBroadcastMissed(true);
            Chatroom chatroom;
            if (chatroomid == 0) {
                chatroom = Chatroom.getChatroomDetails(session.getCurrentChatroom());
            } else {
                chatroom = Chatroom.getChatroomDetails(chatroomid);
            }

            /* If no current chatroom are open then update unread count */
            if ("0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))) {
                try {
                    if (null != chatroom && isNew && pojo.fromId != SessionData.getInstance().getId()) {
                        chatroom.unreadCount = chatroom.unreadCount + 1;
                        chatroom.lastUpdated = System.currentTimeMillis();
                        chatroom.save();
                    }
                    Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                    intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                    context.sendBroadcast(intent);
                } catch (Exception e) {
                    e.printStackTrace();
                }
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

    public void addNewBuddy(Long buddyId, final Context context, final CometchatCallbacks callbacks, final Callbacks responsecallback) {
        try {
            RequestQueue queue = Volley.newRequestQueue(context);
            final HashMap<String, String> nameValuePair = new HashMap<>();
            nameValuePair.put(AjaxKeys.BASE_DATA, SessionData.getInstance().getBaseData());
            nameValuePair.put(AjaxKeys.CALLBACK_FN, AjaxKeys.CALLBACK_FN_VALUE);
            // nameValuePair.put(AjaxKeys.VERSION, "1");
            // nameValuePair.put(AjaxKeys.VERSION2, "1");
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
                    nameValuePair.clear();
                    try {
                        JSONObject newBuddyJson = new JSONObject(response);

                        Buddy.insertNewBuddy(newBuddyJson, responsecallback);

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

    private static void sendKickUserConfirmation(String messageId) {
        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getKickUserURL());
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
                .getCurrentChatroom());

		/* On receiver side value of kickid = kicked */
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICKID, CometChatKeys.ChatroomKeys.KICKED);
        /* kick parameter holds timestamp */
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICK, messageId);
        vHelper.sendCallBack(false);
        vHelper.sendAjax();
    }

    private static void sendBanUserConfirmation(String messageId) {
        VolleyHelper vhelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getBanUserURL());
        vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
                .getCurrentChatroom());
        vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_ID, CometChatKeys.ChatroomKeys.BANNED);
        vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN, messageId);
        vhelper.sendCallBack(false);
        vhelper.sendAjax();
    }

    private static String getColoredText(String message, boolean isMyMessage) {
        try {
            if (isMyMessage) {
                textColor = StaticMembers.MY_DEFAULT_TEXT_COLOR;
            } else {
                textColor = StaticMembers.DEFAULT_TEXT_COLOR;
            }
            Document doc = Jsoup.parseBodyFragment(message);
            Elements spantags = doc.select(StaticMembers.SPAN_TAG);
            for (Element span : spantags) {
                String[] color = span.attr(StaticMembers.STYLE_ATTR).split(":");
                textColor = color[1];
                message = message.replace(span.outerHtml(), span.html().replace(" />", ""));
            }
            return message;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return message;
    }

    private static String handleLink(String message) {
        Document doc = Jsoup.parseBodyFragment(message);
        Elements anchorTag = doc.select(StaticMembers.ANCHOR_TAG);
        for (Element link : anchorTag) {
            String temp = anchorTag.attr(StaticMembers.HREF);
            if (!TextUtils.isEmpty(temp)) {
                message = message.replace(link.toString(), temp);
            }
        }
        return message;
    }

    /**
     * Handles unwanted &lt;br&gt; &amplt; &ampgt; HTML characters
     *
     * @param message Incoming message
     * @return Sanitized message
     */
    private static String handleSpecialHtmlCharacters(String message) {
        return message.replaceAll("<br/>([^.]*?)", "\n").replaceAll("<br>([^.]*?)", "\n")
                .replaceAll("&lt;([^.]*?)", "<").replaceAll("&gt;([^.]*?)", ">").replaceAll("&amp;([^.]*?)", "&")
                .replace("&nbsp;([^.]*?)", " ");
    }

    @SuppressLint("DefaultLocale")
    public JSONObject handleOneOnOneMessage(JSONObject message, SubscribeCallbacks callbacks, boolean fromHeartBeat) {
        Logger.error("HandleOneOnOneMessage json message = "+message);
        int messageProcessed = 1;
        try {
            SessionData session = SessionData.getInstance();
            if (message.has(AjaxKeys.MESSAGE)) {
                String mess = message.getString(AjaxKeys.MESSAGE);
                if (mess.contains("jqcc.cc")) {
                    if (VideoChat.isAVChatRequest(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVchatKeys.INCOMING_AVCALL_MESSAGE);
                            String roomName = VideoChat.getAVRoomName(mess, false);
                            if (session.isAvchatCallRunning()) {
                                message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                        CometChatKeys.AVchatKeys.INCOMING_AVCALL_WHILE_USER_BUSY_MESSAGE);
                                message.put(
                                        CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                        CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE);
                            } else {
                                session.setAvChatRoomName(roomName);
                                session.setActiveAVchatUserID(message.getString(CometChatKeys.AjaxKeys.FROM));
                            }
                            message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAVChatAccepted(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            if (session.isAvchatCallRunning()) {
                                VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                        URLFactory.getAVChatURL());
                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO,
                                        message.getString(CometChatKeys.AjaxKeys.FROM));
                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                                vHelper.sendAjax();
                                messageProcessed = 0;
                            } else {
                                String roomName = VideoChat.getAVRoomName(mess, false);
                                session.setAvChatRoomName(roomName);
                                message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                        CometChatKeys.AVchatKeys.AVCALL_ACCECPTED_MESSAGE);
                                message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                        CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED);
                                message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
                                message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                        CometChatKeys.SDKMessageTypeKeys.AVCALL);
                                messageProcessed = 2;
                            }
                        }
                        // } else if (VideoChat.isAVChatSentSuccessful(mess)) {
                        // messageProcessed = 0;
                        // } else if (VideoChat.isAudioChatSentSuccessful(mess))
                        // {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isGameAccept(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isGameRequest(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isScreehShareRequest(mess)) {
                        // messageProcessed = 0;
                    } else if (VideoChat.isAudioChatRequest(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVchatKeys.INCOMING_AUDIOCALL_MESSAGE);
                            String roomName = VideoChat.getAVRoomName(mess, true);
                            if (session.isAvchatCallRunning()) {
                                message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                        CometChatKeys.AVchatKeys.INCOMING_AUDIOCALL_WHILE_USER_BUSY_MESSAGE);
                                message.put(
                                        CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                        CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE);
                            } else {
                                session.setAvChatRoomName(roomName);
                                session.setActiveAVchatUserID(message.getString(CometChatKeys.AjaxKeys.FROM));
                            }
                            message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAudioChatAccepted(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {
                            if (session.isAvchatCallRunning()) {
                                VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                        URLFactory.getAudioChatURL());
                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO,
                                        message.getString(CometChatKeys.AjaxKeys.FROM));
                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
                                vHelper.sendAjax();
                                messageProcessed = 0;
                            } else {
                                String roomName = VideoChat.getAVRoomName(mess, true);
                                session.setAvChatRoomName(roomName);
                                message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                        CometChatKeys.AVchatKeys.AUDIOCALL_ACCECPTED_MESSAGE);
                                message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                        CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED);
                                message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
                                message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                        CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                                messageProcessed = 2;
                            }
                        }
                    } else if (AVBroadcastplugin.isAVBroadcast(mess)) {
                        if (AVBroadcastplugin.isEnabled()) {
                            message.put(CometChatKeys.AjaxKeys.CALLID, AVBroadcastplugin.getGroupName(mess, false));
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_INCOMING_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AVBROADCAST);
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVBroadcastKeys.INCOMING_AVBROADCAST_MESSAGE);
                            messageProcessed = 2;
                        } else {
                            messageProcessed = 0;
                        }
                    } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                        String url;
                        String room = OtherPlugins.getWhiteBoardRoomName(mess);
                        if (config != null && !TextUtils.isEmpty(config.getWhiteboardUrl())) {
                            url = config.getWhiteboardUrl();
                            if (!url.startsWith("http") || !url.startsWith("https")) {
                                url = "https://" + url;
                                url = url.replace("////", "//");
                            }
                            if (url.endsWith("/")) {
                                url += "d/draw-";
                            } else {
                                url += "/d/draw-";
                            }
                            url = url + room;
                        } else {
                            url = "https://b.chatforyoursite.com/d/draw-" + room;
                        }
                        message.put(AjaxKeys.MESSAGE, url);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.WHITEBOARD);
                    } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                        String url;
                        String room = OtherPlugins.getWriteBoardRoomName(mess);
                        if (config != null && !TextUtils.isEmpty(config.getWriteboardUrl())) {
                            url = config.getWriteboardUrl();
                            if (!url.startsWith("http") || !url.startsWith("https")) {
                                url = "https://" + url;
                                url = url.replace("////", "//");
                            }
                            if (url.endsWith("/")) {
                                url += "p/chat-";
                            } else {
                                url += "/p/chat-";
                            }
                        } else {
                            url = "https://w.chatforyoursite.com/p/chat-";
                        }
                        url = url + EncryptionHelper.encodeIntoMD5("writeboard" + room) + "?userName=sss";
                        message.put(AjaxKeys.MESSAGE, url);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.WRITEBOARD);
                    } else if (OtherPlugins.isScreehShareRequest(mess)) {
                        Document doc = Jsoup.parseBodyFragment(mess);
                        Elements anchortag = doc.select(StaticMembers.ANCHOR_TAG);
                        String grp = anchortag.attr("grp");
                        message.put(AjaxKeys.MESSAGE, grp);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.SCREENSHARE);
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("CC^CONTROL_")) {
                    if(OtherPlugins.isBotResponce(mess)){
                        String trimedMess = mess.replace("CC^CONTROL_","");

                        JSONObject jsonParams = new JSONObject(trimedMess).getJSONObject("params");
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,CometChatKeys.MessageTypeKeys.BOT_RESPONCE);
                        message.put(CometChatKeys.AjaxKeys.MESSAGE,jsonParams.getString("message"));
                        message.put(AjaxKeys.BOT_RESPONCE_TYPE,jsonParams.getString("messagetype"));
                        message.put(AjaxKeys.BOT_ID,jsonParams.getString("botid"));
                    }else if (VideoChat.isAVChatCallRejected(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.AVCALL_REJECTED_MESSAGE);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_REJECT_CALL);
                        message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                        messageProcessed = 2;
                    } else if (VideoChat.isAVChatCallEnded(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            if (session.isAvchatCallRunning()) {
                                SessionData.getInstance().setAvchatCallRunning(false);
                            }
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.END_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_END_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAVChatCallNoAnswer(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVchatKeys.NOANSWER_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_NO_ANSWER);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAVChatCancelCall(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.CANCEL_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CANCEL_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAVChatBusyCall(mess)) {
                        if (VideoChat.isDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.BUSY_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_BUSY_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AVCALL);
                            messageProcessed = 2;
                        }
                    } else if (AVBroadcastplugin.isAVBroadcastEnd(mess)) {
                        if (AVBroadcastplugin.isEnabled()) {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVBroadcastKeys.END_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_END_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AVBROADCAST);
                            messageProcessed = 2;
                        } else {
                            messageProcessed = 0;
                        }
                    } else if (VideoChat.isAudioChatCallRejected(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.AUDIOCALL_REJECTED_MESSAGE);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_REJECT_CALL);
                        message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE, CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                        messageProcessed = 2;
                    } else if (VideoChat.isAudioChatCallEnded(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {

                            if (session.isAvchatCallRunning()) {
                                SessionData.getInstance().setAvchatCallRunning(false);
                            }
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVBroadcastKeys.END_AVCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_END_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAudioChatCallNoAnswer(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVchatKeys.NOANSWER_AUDIOCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_NO_ANSWER);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAudioChatCancelCall(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                    CometChatKeys.AVchatKeys.CANCEL_AUDIOCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CANCEL_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                            messageProcessed = 2;
                        }
                    } else if (VideoChat.isAudioChatBusyCall(mess)) {
                        if (VideoChat.isAudioChatDisabled()) {
                            messageProcessed = 0;
                        } else {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.BUSY_AUDIOCALL_MESSAGE);
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_BUSY_CALL);
                            message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                    CometChatKeys.SDKMessageTypeKeys.AUDIO_CALL);
                            messageProcessed = 2;
                        }
                    } else if (OtherPlugins.isTypingStart(mess)) {
                        try {
                            JSONObject responsetobeSent = new JSONObject();
                            responsetobeSent.put("action", "typing_start");
                            responsetobeSent.put("from", message.getString("from"));
                            responsetobeSent.put("sent", message.getString("sent"));
                            callbacks.onActionMessageReceived(responsetobeSent);
                            messageProcessed = 0;
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                        messageProcessed = 0;
                    } else if (OtherPlugins.isTypingStop(mess)) {
                        JSONObject responsetobeSent = new JSONObject();
                        responsetobeSent.put("action", "typing_stop");
                        responsetobeSent.put("from", message.getString("from"));
                        responsetobeSent.put("sent", message.getString("sent"));
                        callbacks.onActionMessageReceived(responsetobeSent);
                        messageProcessed = 0;
                    } else if (OtherPlugins.isMessageDelivery(mess)) {
                        JSONObject responsetobeSent = new JSONObject();
                        String msgDetails[] = OtherPlugins.getTickMessageDetail(mess).split("#");
                        responsetobeSent.put("action", "message_deliverd");
                        responsetobeSent.put("message_id", msgDetails[0]);
                        responsetobeSent.put("from", msgDetails[1]);
                        callbacks.onActionMessageReceived(responsetobeSent);
                        messageProcessed = 0;
                    } else if (OtherPlugins.isMessageRead(mess) || OtherPlugins.isMessageReadDelivered(mess)) {
                        JSONObject responsetobeSent = new JSONObject();
                        String msgDetails[] = OtherPlugins.getTickMessageDetail(mess).split("#");
                        responsetobeSent.put("action", "message_read");
                        responsetobeSent.put("message_id", msgDetails[0]);
                        responsetobeSent.put("from", msgDetails[1]);
                        callbacks.onActionMessageReceived(responsetobeSent);
                        messageProcessed = 0;
                    } else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, Stickers.getSticker(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.STICKER);
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("plugins/filetransfer")) {
                    if (ImageSharing.isIncomingImage(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.IMAGE);
                    } else if (VideoSharing.isIncomingVideo(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, VideoSharing.getVideoURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.VIDEO);
                    } else if (AudioSharing.isIncomingAudio(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.AUDIO);
                    } else if (ImageSharing.isFileTransfer(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.FILE);
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("jqcc.cometchat")) {
                    if (ChatroomManager.isJoinChatroomMessage(mess)) {
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.JOIN_CHATROOM_MESSAGE);
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ChatroomManager.processJoinRequest(mess));
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("/plugins/handwrite/")) {
                    message.put(CometChatKeys.AjaxKeys.MESSAGE, OtherPlugins.getHandwriteImageUrl(mess));
                    message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.HANDWRITTEN_MESSAGE);
                } else {
                    if (AVBroadcastplugin.isAVBroadcastInvite(mess)) {
                        message.put(CometChatKeys.AjaxKeys.CALLID, AVBroadcastplugin.getInviteGroupName(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_INVITE);
                        message.put(CometChatKeys.SDKMessageTypeKeys.PLUGIN_TYPE,
                                CometChatKeys.SDKMessageTypeKeys.AVBROADCAST);
                        message.put(CometChatKeys.AjaxKeys.MESSAGE,
                                CometChatKeys.AVBroadcastKeys.AVBROADCAST_INVITE_MESSAGE);
                        messageProcessed = 2;
                    } else {

                        if (CometChat.useHTML) {
                            mess = Smilies.convertImageTagToEmoji(handleSpecialHtmlCharacters(handleLink(mess)));
                            if (TextUtils.isEmpty(mess)) {
                                messageProcessed = 0;
                            }
                        } else {
                            mess = handleSpecialHtmlCharacters(handleLink(mess));
                        }
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.NORMAL);
                    }
                }
            } else {
                messageProcessed = 0;
            }

			/*
             * Fix for the case where CometChat sends your own messages with
			 * interchanged from/to ids.
			 */
            if (1 == message.getInt(CometChatKeys.AjaxKeys.SELF)) {
                message.put(CometChatKeys.AjaxKeys.TO, message.getString(CometChatKeys.AjaxKeys.FROM));
                message.put(CometChatKeys.AjaxKeys.FROM, session.getId());
            }

            if (fromHeartBeat) {
                switch (messageProcessed) {
                    case 0:
                        break;
                    case 1:

                        /*long messageId =  message.getLong("id");
                        String messagePrefId = PreferenceHelper.get("One-One-Message-id");

                        if(messagePrefId != null && messageId == Long.parseLong(messagePrefId)){

                        }else{
                            PreferenceHelper.save("One-One-Message-id",messageId);
                            callbacks.onMessageReceived(message);
                        }*/
                        callbacks.onMessageReceived(message);

                        if ((message.getString(AjaxKeys.SELF).equals("0"))) {
                            if (config.getUSECOMET() != null && config.getUSECOMET().equals("1")) {
                                String transport = config.getTRANSPORT();
                                if (CommonUtils.usertoChannelMap != null) {
                                    String userid = message.getString(AjaxKeys.FROM);
                                    String channel = CommonUtils.usertoChannelMap.get(userid);
                                    if (!TextUtils.isEmpty(channel)) {
                                        if (transport.equals("cometservice")) {
                                            Logger.error("msg id " + message.getString(CometChatKeys.AjaxKeys.ID));
                                            CometserviceOneOnOne.sendMessage(channel, CommonUtils
                                                    .getDeliveredTickMessage(message.getString(CometChatKeys.AjaxKeys.ID)));
                                        } else if (transport.equals("cometservice-selfhosted")) {
                                            WebsyncOneOnOne.getInstance().publish(
                                                    channel,
                                                    CommonUtils.getDeliveredTickMessage(message
                                                            .getString(CometChatKeys.AjaxKeys.ID)));
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 2:
                        callbacks.onAVChatMessageReceived(message);
                        break;
                    default:
                        break;
                }
                return null;
            } else {
                if (messageProcessed != 0) {
                    return message;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

    /**
     * @param message : Pass single received message JSONObject
     */
    public JSONObject handleChatroomMessage(JSONObject message, SubscribeChatroomCallbacks callbacks, boolean fromHeartBeat) {
        try {
            int messageProcessed = 1;
            long chatroomid = 0;
            if (message.has(AjaxKeys.MESSAGE)) {
                SessionData session = SessionData.getInstance();
                String mess = message.getString(AjaxKeys.MESSAGE);
                if (message.has("chatroomid")) {
                    message.put("chatroomid", message.getString("chatroomid"));
                    chatroomid = message.getLong("chatroomid");
                } else if (message.has("roomid")) {
                    message.put("chatroomid", message.getString("roomid"));
                    chatroomid = message.getLong("roomid");
                }

                if (chatroomid != 0) {
                    JSONObject temp;
                    if (PreferenceHelper.contains("ccjsonObject")) {
                        temp = new JSONObject(PreferenceHelper.get("ccjsonObject"));
                    } else {
                        temp = new JSONObject();
                    }
                    temp.put(String.valueOf(chatroomid), message.getString(AjaxKeys.ID));
                    PreferenceHelper.save("ccjsonObject", temp.toString());
                }

                if (mess.contains("jqcc.cc")) {
                    if (VideoChat.isCrAvchatRequest(mess)) {
                        if (!String.valueOf(session.getId()).equals(message.getString("fromid"))) {
                            message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1));
                            message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE,
                                    CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
                            String roomName = VideoChat.getAVConferenceRoomName(mess);
                            session.setAvChatRoomName(roomName);
                            messageProcessed = 2;
                        } else {
                            messageProcessed = 0;
                        }
                        // } else if (OtherPlugins.isScreehShareRequest(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isWriteBoardRequest(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
                        // messageProcessed = 0;
                        // } else if (OtherPlugins.isCrAVBroadcast(mess)) {
                        // messageProcessed = 0;
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("CC^CONTROL_")) {
                    if (ChatroomManager.isKickedChatroomMessage(mess)) {
                        /* Message is CC^CONTROL_kicked_*userid value* */
                        String[] kickSplitedMessage = mess.split("_");
                        String kicked = kickSplitedMessage[kickSplitedMessage.length - 1];
                        if (!kicked.equals(CometChatKeys.ChatroomKeys.KICKED)) {
                            if (Integer.parseInt(kicked) == session.getId()) {
                                if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
                                    sendKickUserConfirmation(message.getString(CometChatKeys.AjaxKeys.SENT));
                                } else {
                                    sendKickUserConfirmation(message.getString(CometChatKeys.AjaxKeys.ID));
                                }
                                CometChatroom.leaveChatroom(String.valueOf(session.getCurrentChatroom()), "2", chatroomCallback);
                            }
                        }
                        messageProcessed = 0;
                    } else if (ChatroomManager.isBannedChatroomMessage(mess)) {
                        /* Message is CC^CONTROL_banned_*userid value* */
                        String[] banSplitedMessage = mess.split("_");
                        String banned = banSplitedMessage[banSplitedMessage.length - 1];
                        if (!banned.equals(CometChatKeys.ChatroomKeys.BANNED)) {
                            if (Integer.parseInt(banned) == session.getId()) {
                                if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
                                    sendBanUserConfirmation(message.getString(CometChatKeys.AjaxKeys.SENT));
                                } else {
                                    sendBanUserConfirmation(message.getString(CometChatKeys.AjaxKeys.ID));
                                }
                                CometChatroom.leaveChatroom(String.valueOf(session.getCurrentChatroom()), "1", chatroomCallback);
                            }
                        }
                        messageProcessed = 0;
                    } else if (ChatroomManager.isMessageDeletedFromChatroom(mess)) {
                        JSONObject json = new JSONObject();
                        json.put("action_type", CometChatKeys.ChatroomActionMessageTypeKeys.CHATROOM_MESSAGE_DELETED);
                        json.put("message_id", mess.split("_")[2]);
                        callbacks.onActionMessageReceived(json);
                        messageProcessed = 0;
                    } else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, Stickers.getSticker(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.STICKER);
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("plugins/filetransfer")) {
                    if (ImageSharing.isIncomingImage(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.IMAGE);
                    } else if (VideoSharing.isIncomingVideo(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, VideoSharing.getVideoURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.VIDEO);
                    } else if (AudioSharing.isIncomingAudio(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.AUDIO);
                    } else if (ImageSharing.isFileTransfer(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.FILE);
                    } else {
                        messageProcessed = 0;
                    }
                } else if (mess.contains("/plugins/handwrite/")) {
                    if (OtherPlugins.isHandWrite(mess)) {
                        message.put(CometChatKeys.AjaxKeys.MESSAGE, OtherPlugins.getHandwriteImageUrl(mess));
                        message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.HANDWRITTEN_MESSAGE);
                    } else {
                        messageProcessed = 0;
                    }
                } else {
                    // Normal Message
                    if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(StaticMembers.ME_TEXT)
                            || message.getString(CometChatKeys.ChatroomKeys.FROMID).equals(
                            String.valueOf(session.getId()))) {
                        mess = handleSpecialHtmlCharacters(getColoredText(handleLink(mess), true));
                    } else {
                        mess = handleSpecialHtmlCharacters(getColoredText(handleLink(mess), false));
                    }
                    if (CometChatroom.useHTML) {
                        mess = Smilies.convertImageTagToEmoji(handleLink(mess));
                    }

                    message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
                    message.put(CometChatKeys.SDKMessageTypeKeys.MESSAGE_TYPE, CometChatKeys.SDKMessageTypeKeys.NORMAL);
                    message.put(CometChatKeys.ChatroomKeys.TEXT_COLOR, textColor);
                    messageProcessed = 1;
                }
            } else {
                messageProcessed = 0;
            }
            if (fromHeartBeat) {
                switch (messageProcessed) {
                    case 0:
                        break;
                    case 1:
                        callbacks.onMessageReceived(message);
                        break;
                    case 2:
                        callbacks.onAVChatMessageReceived(message);
                        break;
                    default:
                        break;
                }
                return null;
            } else {
                if (0 != messageProcessed) {
                    return message;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }

}