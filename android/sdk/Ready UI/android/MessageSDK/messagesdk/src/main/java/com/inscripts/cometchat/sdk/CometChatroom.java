/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/

package com.inscripts.cometchat.sdk;

import android.annotation.SuppressLint;
import android.content.Context;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.text.TextUtils;

import com.inscripts.enums.ChatroomType;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.ChatroomActionMessageTypeKeys;
import com.inscripts.keys.CometChatKeys.ErrorKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

@SuppressLint("HandlerLeak")
public class CometChatroom {

    private static boolean useComet = false;
    public static boolean useHTML = false;
    private static Context context;
    private static SubscribeChatroomCallbacks callbacklistener;
    private static SessionData sessionData;
    private long minHeartbeat;
    private boolean isSubscribed = false;
    private static CometChatroom cometChatroom;
    private int userInviteCount = 0;

    public static CometChatroom getInstance(Context context) {
        if (null == cometChatroom) {
            cometChatroom = new CometChatroom(context);
        }
        return cometChatroom;
    }

    /**
     * Initialize the Chatrooms module.
     *
     * @param context
     */
    private CometChatroom(Context context) {
        CometChatroom.context = context;
        PreferenceHelper.initialize(CometChatroom.context);
        sessionData = SessionData.getInstance();
        if (null == sessionData.getChatroomHeartBeatTimestamp()) {
            sessionData.setChatroomHeartBeatTimestamp("0");
        }
        if (null == sessionData.getCurrentChatroomPassword()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD)) {
                sessionData.setCurrentChatroomPassword(PreferenceHelper
                        .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD));
            } else {
                sessionData.setCurrentChatroomPassword("");
            }
        }
    }

    /**
     * Start receiving chatroom messages, chatroom list and chatroom members.
     *
     * @param htmlFlag : If set then emojis will be represnted by their short forms <br>
     *                 If unset then emojis will be represented by HTML tags
     */
    public void subscribe(final boolean htmlFlag, final SubscribeChatroomCallbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            callbacklistener = callbacks;
            if (CometChat.isSubscribedCalled) {
                useHTML = htmlFlag;
                /*if (useHTML) {
                    Smilies.InitializeMapping();
				}*/
                // HeartbeatChatroom.getInstance(callbacklistener).stopHeartbeatChatroom();

                Long interval = 0L;
                Config config = JsonPhp.getInstance().getConfig();
                minHeartbeat = Long.parseLong(config.getMinHeartbeat());
                useComet = config.getUSECOMET().equals("1");
                //HeartbeatChatroom heartbeatChatroom = HeartbeatChatroom.getInstance(callbacklistener);
                if (useComet) {
                    interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                    sessionData.setChatroomHeartbeatInterval(interval);
                } else {
                    interval = Long.parseLong(config.getMinHeartbeat());
                    sessionData.setChatroomHeartbeatInterval(interval);
                }

                isSubscribed = true;

                Logger.error("Cometchatroom version no = "+CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion()));
                if(CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion())>= 630){
                    HybridHeartbeat.getInstance(callbacklistener).startHeartbeat(context);
                    HybridHeartbeat.getInstance(callbacklistener).setForceHeartbeat();
                }else{
                    HeartbeatChatroom.getInstance(callbacklistener).startHeartbeat(context);
                    HeartbeatChatroom.getInstance(callbacklistener).setForceHeartbeat();
                }

            } else {

                // CometChat.getInstance(context)
                // CometChat.getInstance(context)
                CometChat.getInstance(context, PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY))
                        .initializeJsonPhp(new Callbacks() {

                            @Override
                            public void successCallback(JSONObject response) {
                                useHTML = htmlFlag;
                                CometChat.isSubscribedCalled = true;
                                /*if (useHTML) {
                                    Smilies.InitializeMapping();
								}*/
                                HeartbeatChatroom.getInstance(callbacklistener).stopHeartbeatChatroom();

                                Long interval = 0L;
                                Config config = JsonPhp.getInstance().getConfig();
                                minHeartbeat = Long.parseLong(config.getMinHeartbeat());
                                useComet = config.getUSECOMET().equals("1");
                                HeartbeatChatroom heartbeatChatroom = HeartbeatChatroom.getInstance(callbacklistener);
                                if (useComet) {
                                    interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                                    sessionData.setChatroomHeartbeatInterval(interval);
                                } else {
                                    interval = Long.parseLong(config.getMinHeartbeat());
                                    sessionData.setChatroomHeartbeatInterval(interval);
                                }

                                isSubscribed = true;
                                if(CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion())>= 630){
                                    HybridHeartbeat.getInstance(callbacklistener).startHeartbeat(context);
                                    HybridHeartbeat.getInstance(callbacklistener).setForceHeartbeat();
                                }else{
                                    HeartbeatChatroom.getInstance(callbacklistener).startHeartbeat(context);
                                    HeartbeatChatroom.getInstance(callbacklistener).setForceHeartbeat();
                                }
                            }

                            @Override
                            public void failCallback(JSONObject response) {
                                callbacks.onError(response);
                            }
                        });
            }

        } else {
            CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacklistener);
        }
    }

    /**
     * Stop receiving chatroom messages, lists and members.
     */
    public void unsubscribe() {
        try {
            if (CometChat.isLoggedIn() && isSubscribed) {
                HeartbeatChatroom.getInstance((SubscribeChatroomCallbacks) null).stopHeartbeatChatroom();
                leaveChatroom(null);

                if (useComet) {

                    String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                    if (!TextUtils.isEmpty(transport)) {
                        if (transport.equals("cometservice")) {
                            CometserviceChatroom.getInstance().unSubscribe();
                        } else if (transport.equals("cometservice-selfhosted")) {
                            WebsyncChatroom.getInstance().unsubscribe();
                        }
                    }
                }
            }
        } catch (Exception e) {
        }
    }

    /**
     * Join a specific chatroom
     *
     * @param chatroomId   Id of chatroom
     * @param chatroomName Chatroom name
     * @param password     Password of chatroom. For "password protected chatrooms",
     *                     <b>password must be SHA-1 encoded </b>. For other type of
     *                     chatrooms SHA-1 encoding is not required.
     */
    public void joinChatroom(final String chatroomId, final String chatroomName, final String password,
                             final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (!TextUtils.isEmpty(chatroomName)) {
                String tempname = String.valueOf(sessionData.getCurrentChatroom());
                if (TextUtils.isEmpty(tempname) || tempname.equals("0")) {
                    joinChatroomAjaxCall(chatroomId, chatroomName, password, callbacks);
                } else {
                    leaveChatroom(new Callbacks() {

                        @Override
                        public void successCallback(JSONObject response) {
                            joinChatroomAjaxCall(chatroomId, chatroomName, password, callbacks);
                        }

                        @Override
                        public void failCallback(JSONObject response) {
                            callbacks.failCallback(response);
                        }
                    });
                }
            } else {
                throw new IllegalArgumentException("Chatroom name can't be empty");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    private void joinChatroomAjaxCall(final String chatroomId, final String chatroomName, final String password,
                                      final Callbacks callbacks) {
        sessionData.setCurrentChatroomPassword(password);
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomPasswordUrl(),
                new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            JSONObject chatroomJson = new JSONObject(response);
                            String joinResponse = chatroomJson.getString("s");

                            if (joinResponse.equals("INVALID_PASSWORD")) {
                                /*
                                 * Wrong password value returned 0
								 */
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        CometChatKeys.ErrorKeys.CODE_JOIN_CHATROOM_WRONG_PWD,
                                        CometChatKeys.ErrorKeys.MESSAGE_JOIN_CHATROOM_WRONG_PWD));
                            } else if (joinResponse.equals("BANNED")) {
								/*
								 * User is banned for this chatroom value
								 * returned 2
								 */
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        CometChatKeys.ErrorKeys.CODE_JOIN_CHATROOM_BANNED,
                                        CometChatKeys.ErrorKeys.MESSAGE_JOIN_CHATROOM_BANNED));
                            } else if (joinResponse.equals("INVALID_CHATROOM")) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        CometChatKeys.ErrorKeys.CODE_CHATROOM_DONT_EXIST,
                                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_DONT_EXIST));
                            } else {
								/* User is valid */
                                if (useComet) {
                                    String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                                    if (!TextUtils.isEmpty(transport)) {
                                        if (transport.equals("cometservice")) {
                                            if (!isSubscribedToChatroom(chatroomId)) {
                                                CometserviceChatroom.getInstance().startChatroomCometService(
                                                        chatroomId, callbacklistener, callbacks);
                                            }
                                        } else if (transport.equals("cometservice-selfhosted")) {
                                            if (chatroomJson.has("cometid")) {
                                                WebsyncChatroom.getInstance().connect(
                                                        JsonPhp.getInstance().getWebsyncServer(), chatroomId,
                                                        chatroomJson.getString("cometid"), callbacklistener);
                                            }
                                        }
                                    }
                                }
                                subscribe(useHTML, callbacklistener);
                                PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID,
                                        String.valueOf(chatroomId));
                                PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD, password);
                                sessionData.setCurrentChatroomName(chatroomName);
                                sessionData.setCurrentChatroom(Long.parseLong(chatroomId));
                                JSONObject json = new JSONObject();
                                json.put("chatroom_id", chatroomId);
                                json.put("push_channel", chatroomJson.get("push_channel"));
                                callbacks.successCallback(json);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }


                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                    ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                    ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                        }
                    }
                });

        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, String.valueOf(chatroomId));
        vHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
        vHelper.sendAjax();
    }

    public static void leaveChatroom(String chatroomId, String flag, SubscribeChatroomCallbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (null == chatroomId) {
                throw new IllegalArgumentException("chatroomId cannot be NULL or empty.");
            } else {
                if (TextUtils.isEmpty(flag)) {
                    throw new IllegalArgumentException("flag cannot be NULL or empty.");
                } else {
                    String tempname = String.valueOf(sessionData.getCurrentChatroom());
                    if (CometChat.isLoggedIn() && !tempname.equals("0")) {
                        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomLeaveURL());
                        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
                        if (flag.equals("0") || flag.equals("2")) {
                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");

                            if (flag.equals("2")) {
                                // You got kicked.
                                try {
                                    JSONObject json = new JSONObject();
                                    json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_KICKED);
                                    json.put("chatroom_id", chatroomId);
                                    callbacks.onActionMessageReceived(json);
                                } catch (Exception e) {
                                    e.printStackTrace();
                                }
                            }
                        } else if (flag.equals("1")) {
                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_FLAG, "1");
                            // You got banned
                            try {
                                JSONObject json = new JSONObject();
                                json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_KICKED);
                                json.put("chatroom_id", chatroomId);
                                callbacks.onActionMessageReceived(json);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        vHelper.sendAjax();

                        sessionData.setCurrentChatroom(0L);
                        sessionData.setCurrentChatroomPassword("");
                        sessionData.setCurrentChatroomName("0");
                        sessionData.setChatroomHeartBeatTimestamp("");
                        if (useComet) {
                            String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                            if (!TextUtils.isEmpty(transport)) {
                                if (transport.equals("cometservice")) {
                                    CometserviceChatroom.getInstance().unSubscribe();
                                } else if (transport.equals("cometservice-selfhosted")) {
                                    WebsyncChatroom.getInstance().unsubscribe();
                                }
                            }
                        }
                        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
                        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
                        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD);

                        try {
                            callbacks.onLeaveChatroom(new JSONObject("{\"chatroom_id\":" + chatroomId + "}"));
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } else {
                        CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                                CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacks);
                    }
                }
            }
        } else {
            CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacks);
        }
    }


    public void leaveChatroom(Callbacks callbacks) {
        String chatroomId = String.valueOf(sessionData.getCurrentChatroom());
        if (CometChat.isLoggedIn()) {
            if (null == chatroomId) {
                // throw new
                // IllegalArgumentException("ChatroomId cannot be NULL or empty.");
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            } else {
                if (!chatroomId.equals("0")) {
                    VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomLeaveURL());
                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");
                    vHelper.sendAjax();

                    sessionData.setCurrentChatroom(0L);
                    sessionData.setCurrentChatroomPassword("");
                    sessionData.setCurrentChatroomName("0");
                    sessionData.setChatroomHeartBeatTimestamp("");
                    if (useComet) {
                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        if (!TextUtils.isEmpty(transport)) {
                            if (transport.equals("cometservice")) {
                                CometserviceChatroom.getInstance().unSubscribe();
                            } else if (transport.equals("cometservice-selfhosted")) {
                                WebsyncChatroom.getInstance().unsubscribe();
                            }
                        }
                    }
                    PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
                    PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
                    PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD);
                    try {
                        if (null != callbacks) {
                            callbacks.successCallback(new JSONObject("{\"chatroom_id\":" + chatroomId + "}"));
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                } else {
                    if (null != callbacks) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_CHATROOMID_MISMATCH,
                                CometChatKeys.ErrorKeys.MESSAGE_CHATROOMID_MISMATCH));
                    }
                }
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void getAllChatrooms(final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomUrl(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                if (response.equals("[]")) {
                                    callbacks.successCallback(new JSONObject("{\"chatrooms\": {} }"));
                                } else {
                                    JSONObject json = new JSONObject(response);
                                    if (json.has(AjaxKeys.CHATROOM_LIST)) {
                                        callbacks.successCallback(json
                                                .getJSONObject(AjaxKeys.CHATROOM_LIST));
                                    } else {
                                        callbacks.successCallback(new JSONObject());
                                    }
                                }
                            } catch (Exception e) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
                                        CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                            }
                        }


                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                        ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                            }
                        }
                    });
            vHelper.addNameValuePair(AjaxKeys.CHATROOM_LIST, "1");
            vHelper.addNameValuePair(AjaxKeys.FORCE, "1");
            vHelper.addNameValuePair(AjaxKeys.FORCE_LIST, "1");
            vHelper.sendAjax();

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Fetches the details of each chatroom member. You have to be a part of the
     * chatroom to make this request.
     */
	/*
	 * public void getChatroomMembers(String chatroomId, final Callbacks
	 * callbacks) { if (CometChat.isLoggedIn()) { if
	 * (chatroomId.equals(sessionData.getCurrentChatroom())) { Handler handler =
	 * new Handler() {
	 *
	 * @Override public void handleMessage(Message msg) {
	 * super.handleMessage(msg); try { JSONObject json = new
	 * JSONObject(msg.obj.toString()); if
	 * (json.has(CometChatKeys.ChatroomKeys.MEMBERS)) {
	 * callbacks.successCallback(json.getJSONObject(ChatroomKeys.MEMBERS)); } }
	 * catch (Exception e) {
	 * callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys
	 * .ErrorKeys.CODE_JSON_PARSING_ERROR,
	 * CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR)); } } };
	 *
	 * AjaxHelper aHelper = new AjaxHelper(URLFactory.getChatroomHeartbeatUrl(),
	 * handler);
	 * aHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID,
	 * chatroomId); aHelper.addNameValuePair(AjaxKeys.CHATROOM_LIST, "0");
	 * aHelper.addNameValuePair(AjaxKeys.FORCE_LIST, "1"); aHelper.execute(); }
	 * else {
	 * callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys
	 * .CODE_CHATROOMID_MISMATCH,
	 * CometChatKeys.ErrorKeys.MESSAGE_CHATROOMID_MISMATCH)); } } else {
	 * callbacks
	 * .failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys
	 * .CODE_USER_NOT_LOGGEDIN, CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
	 * } }
	 */

    /**
     * Send a message to the designated chatroom. You have the be the member of
     * this chatroom to send a message.
     */
    public void sendMessage(String chatroomId, String message, final Callbacks callbacks) throws IllegalArgumentException {
        if (chatroomId.equals("0")) {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                    CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
        } else {
            if (TextUtils.isEmpty(message)) {
                throw new IllegalArgumentException("message cannot be NULL or empty.");
            } else {
                if (CometChat.isLoggedIn()) {
                    if (!useComet) {
                        resetChatroomHeartbeatInterval();
                    }

                    VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getSendChatroomMessageURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    try {
                                        if (useHTML) {
                                            JSONObject modifiedMessage = new JSONObject(response);
                                            modifiedMessage.put("m",
                                                    Smilies.convertImageTagToEmoji(modifiedMessage.getString("m")));
                                            callbacks.successCallback(modifiedMessage);
                                        } else {
                                            callbacks.successCallback(new JSONObject(response));
                                        }
                                    } catch (Exception e) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
                                                CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                                    }
                                }


                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (isNoInternet) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                    } else {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }
                            });

                    vHelper.addNameValuePair(AjaxKeys.MESSAGE, message);
                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_NAME, SessionData.getInstance()
                            .getCurrentChatroomName());
                    vHelper.sendAjax();

                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                            CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
                }
            }

        }
    }

    public void sendImage(File imageFile, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                if (imageFile != null && imageFile.exists()) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(imageFile,
                            PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendImage(Bitmap bitmap, Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                ImageSharing imgSharing = new ImageSharing();
                imgSharing.sendImageAjax(bitmap, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
                        true, "IMG-" + System.currentTimeMillis() + ".png", callbacks);
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendAudioFile(File audioFile, Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (audioFile != null && audioFile.exists()) {
                ImageSharing imgSharing = new ImageSharing();
                imgSharing.sendImageAjax(audioFile, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
                        true, callbacks);
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                        CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
            }

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Invite a user to be a part of the current chatroom. You have to be a part
     * of the chatroom to make this call. The other user will receive a chatroom
     * invite message in his respective callback.
     */
    public void inviteUser(final JSONArray users, final Callbacks callbacks) {
        userInviteCount = 1;
        if (CometChat.isLoggedIn()) {
            String chatroomId = String.valueOf(sessionData.getCurrentChatroom());
            if (chatroomId.equals("0")) {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            } else {
                if (null == users && users.length() == 0) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                            CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
                } else {
                    try {
                        String chatroomName = new String(CommonUtils.encodeBase64(SessionData.getInstance()
                                .getCurrentChatroomName()), StaticMembers.UTF_8);

                        String password = SessionData.getInstance().getCurrentChatroomPassword(), url = URLFactory
                                .getChatroomInviteURL();
                        int i;
                        final int len = users.length();
                        final JSONArray returnResponse = new JSONArray();
                        for (i = 0; i < len; i++) {
                            sendInviteuserAjax(chatroomId, chatroomName, password, url, users.getString(i),
                                    new Callbacks() {

                                        @Override
                                        public void successCallback(JSONObject response) {
                                            try {
                                                returnResponse.put(response.get("user"));
                                                if (userInviteCount == len) {
                                                    JSONObject data = new JSONObject();
                                                    data.put("users_invited", returnResponse);
                                                    callbacks.successCallback(data);
                                                }
                                            } catch (Exception e) {
                                                e.printStackTrace();
                                            }
                                            userInviteCount++;
                                        }

                                        @Override
                                        public void failCallback(JSONObject response) {

                                        }
                                    });
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    private void sendInviteuserAjax(String chatroomId, String chatroomName, String password, String url,
                                    final String userId, final Callbacks callbacks) {
        VolleyHelper vHelper = new VolleyHelper(context, url, new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    callbacks.successCallback(new JSONObject("{\"user\":\"" + userId + "\"}"));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }


            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                }
            }
        });
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, chatroomId);
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITEDID, password);
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMNAME, chatroomName);
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITE, userId);
        vHelper.sendCallBack(false);
        vHelper.sendAjax();
    }

    /**
     * <p>
     * Creates a new chatroom and will throw "onChatroomCreated" callback which returns id of created chatroom or throws
     * error
     * </p>
     *
     * @param chatroomName     Name of chatroom
     * @param chatroomPassword Password for the chatroom
     * @param chatroomType     Type of chatroom to be created<br>
     *                         You can select required type from the ChatroomType enum<br>
     *                         The types are PUBLIC_CHATROOM, PASSWORD_PROTECTED, INVITE_ONLY
     */
    public void createChatroom(String chatroomName, String chatroomPassword, ChatroomType chatroomType,
                               Callbacks callbacks) {

        if (CometChat.isLoggedIn()) {
            if (!TextUtils.isEmpty(chatroomName)) {
                switch (chatroomType) {
                    case PUBLIC_CHATROOM:
                        sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
                        break;
                    case PASSWORD_PROTECTED:
                        if (!TextUtils.isEmpty(chatroomPassword)) {
                            sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
                        } else {
                            throw new IllegalArgumentException(
                                    "Password can't be empty or null for Password protected room");
                        }
                        break;
                    case INVITE_ONLY:
                        sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
                        break;
                    default:
                        throw new IllegalArgumentException("Please check your chatroom type");
                }
            } else {
                throw new IllegalArgumentException("Chatroom name can't be empty or null");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    private void sendCreateChatromAjax(final String chatroomName, final String chatroomPassword, int chatroomType,
                                       final Callbacks callbacks) {
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCreateChatroomURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {

                long chatroomId;
                try {
                    JSONObject json = new JSONObject(response);
                    chatroomId = json.getLong("id");
                } catch (Exception e) {
                    chatroomId = Long.parseLong(response);
                }

                if (chatroomId == 0) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_CHATROOM_CREATION_ERROR,
                            CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_CREATION_ERROR));
                } else {
                    joinChatroom(String.valueOf(chatroomId), chatroomName, chatroomPassword, callbacks);
                    try {
                        callbacks.successCallback(new JSONObject("{\"chatroom_id\":" + String.valueOf(chatroomId) + "}"));
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }


            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                }
            }
        });

        vHelper.addNameValuePair(AjaxKeys.CHATROOM_TYPE, chatroomType);
        vHelper.addNameValuePair(AjaxKeys.PASSWORD, chatroomPassword);
        vHelper.addNameValuePair(AjaxKeys.NAME, chatroomName);
        vHelper.sendAjax();
    }

    /**
     * Resets the heartbeat timing to minimum <br>
     * <p>
     * Use this method only when cometservice is not in use to reset heartbeat interval after sending chat message.
     * </p>
     */
    private void resetChatroomHeartbeatInterval() {
        minHeartbeat = Long.parseLong(JsonPhp.getInstance().getConfig().getMinHeartbeat());
        sessionData.setChatroomHeartbeatIdealCount(1);
        if (useComet) {
            sessionData.setChatroomHeartbeatInterval(Long.parseLong(JsonPhp.getInstance().getConfig()
                    .getREFRESHBUDDYLIST()) * 1000);
        } else {
            if (sessionData.getChatroomHeartbeatInterval() > minHeartbeat) {
                sessionData.setChatroomHeartbeatInterval(minHeartbeat);
                HeartbeatChatroom.getInstance((SubscribeChatroomCallbacks) null).changeChatroomHeartbeatInverval();
            }
        }

    }

    /**
     * Returns the subscription status to the current chatroom.
     */
    public boolean isSubscribedToChatroom(String chatroomId) {
        return String.valueOf(sessionData.getCurrentChatroom()).equals(chatroomId);
    }

    public String getCurrentChatroom() {
        if (CometChat.isLoggedIn()) {
            return String.valueOf(SessionData.getInstance().getCurrentChatroom());
        }
        return "0";
    }

    /**
     * Sends a video file in chatroom which you have joined
     *
     * @param videoFile Video file to be sent
     * @param callbacks
     */
    public void sendVideo(File videoFile, Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                if (videoFile != null && videoFile.exists()) {
                    VideoSharing videoSharing = new VideoSharing();
                    videoSharing.sendVideoAjax(videoFile,
                            PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Sends a video file in chatroom which you have joined
     *
     * @param filePath  Path of video file to be sent
     * @param callbacks
     */
    public void sendVideo(String filePath, Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                File videoFile = new File(filePath);
                if (videoFile != null && videoFile.exists()) {
                    VideoSharing videoSharing = new VideoSharing();
                    videoSharing.sendVideoAjax(videoFile,
                            PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendFile(File file, Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                if (file != null && file.exists()) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(file, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
                            true, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                        CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * <b>Delete a chatroom</b> <br>
     * You can delete the chatroom which are created by you only
     *
     * @param chatroomId Pass the chatroom id
     * @param callbacks
     * @throws IllegalArgumentException
     */
    public void deleteChatroom(final String chatroomId, final Callbacks callbacks) throws IllegalArgumentException {
        if (CometChat.isLoggedIn()) {
            if (TextUtils.isEmpty(chatroomId)) {
                throw new IllegalArgumentException("ChatroomId can't be empty or null");
            } else {
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getDeleteChatroomURL(),
                        new VolleyAjaxCallbacks() {

                            @Override
                            public void successCallback(String response) {
                                try {
                                    // Logger.error("chatroom delet respnse =" + response);
                                    if (response.equals("1")) {
                                        JSONObject json = new JSONObject();
                                        json.put("chatroom_id", chatroomId);
                                        callbacks.successCallback(json);
                                        if (chatroomId.equals(PreferenceHelper
                                                .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))) {
                                            leaveChatroom(null);
                                        }
                                    } else {
                                        JSONObject json = new JSONObject();
                                        json.put(CometChatKeys.ErrorKeys.CODE_CHATROOM_DELETION_ERROR,
                                                CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_DELETE_ERROR);
                                        callbacks.failCallback(json);
                                    }
                                } catch (Exception e) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
                                            CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                                }
                            }


                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if (isNoInternet) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                } else {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                }
                            }
                        });

                vHelper.addNameValuePair(AjaxKeys.ID, chatroomId);
                vHelper.sendAjax();
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendSticker(final String message, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (Stickers.isEnabled()) {
                String chatroomId = String.valueOf(sessionData.getCurrentChatroom());
                if (chatroomId.equals("0")) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
                            CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
                } else {
                    VolleyHelper helper = new VolleyHelper(context, URLFactory.getSendStickerURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    try {
                                        JSONObject sendResponse = new JSONObject(response.substring(
                                                response.indexOf("{"), response.lastIndexOf("}") + 1));
                                        Long id = sendResponse.getLong(AjaxKeys.ID);
                                        if (id != -1) {
                                            JSONObject msg = new JSONObject();
                                            msg.put("id", id);
                                            msg.put("m", message);
                                            callbacks.successCallback(msg);
                                        }
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }


                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (isNoInternet) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                    } else {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }
                            });
                    helper.addNameValuePair(AjaxKeys.TO, chatroomId);
                    helper.addNameValuePair(AjaxKeys.CATEGORY, Stickers.getCategory(message));
                    helper.addNameValuePair(AjaxKeys.KEY, message);
                    helper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
                    helper.addNameValuePair("caller", "");
                    helper.sendAjax();
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_TYPING_NOT_ENABLED,
                        CometChatKeys.ErrorKeys.MESSAGE_TYPING_NOT_ENABLED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_STICKER_PLUGIN_NOT_ENABLED,
                    CometChatKeys.ErrorKeys.MESSAGE_SITCKER_PLUGIN_NOT_ENABLED));
        }
    }

    public void getChatroomChatHistory(Long chatroomid, Long messageId, final Callbacks callbacks) {
        VolleyHelper vhelper = new VolleyHelper(context, URLFactory.getChatroomUrl(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(final String response) {
                Logger.debug("response of chatrom hjistory " + response);
                new AsyncTask<Void, Void, Void>() {

                    @Override
                    protected Void doInBackground(Void... params) {
                        try {
                            JSONArray allMessages = new JSONArray();
                            JSONObject messages;

                            if (!"[]".equals(response)) {
                                /*messages = new JSONObject(response);
                                messages = messages.getJSONObject(AjaxKeys.MESSAGES);
                                if (messages.length() > 0) {*/

									/* New Messages have arrived */
                                messages = new JSONObject(response);
                                Iterator<String> iterator = messages.keys();
                                List<String> sortedKeys = new ArrayList<String>();
                                while (iterator.hasNext()) {
                                    sortedKeys.add(iterator.next());
                                }

                                Collections.sort(sortedKeys);
                                for (String messageId : sortedKeys) {
                                    JSONObject message = messages.getJSONObject(messageId);
                                    message = MessageHelper.getInstance().handleChatroomMessage(message, null,
                                            false);
                                    if (null != message) {
                                        // Populate messages for history
                                        allMessages.put(message);
                                    }
                                }
                                // }
                            }

                            messages = new JSONObject();
                            messages.put("history", allMessages);
                            callbacks.successCallback(messages);
                        } catch (Exception e) {
                            e.printStackTrace();
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_JSON_PARSING_ERROR,
                                    ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                        }
                        return null;
                    }
                }.execute();
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });

        vhelper.addNameValuePair(AjaxKeys.ACTION, "updateChatroomMessages");
        vhelper.addNameValuePair(AjaxKeys.CHATROOMID, chatroomid);
        vhelper.addNameValuePair(AjaxKeys.PREPEND, messageId);
        vhelper.sendAjax();
    }

    public void renameChatroom(String chatroomid, final String chatroomName, final Callbacks callbacks) throws IllegalArgumentException {
        if (TextUtils.isEmpty(chatroomid)) {
            throw new IllegalArgumentException("Chatroom id can't be empty or null");
        } else {
            if (TextUtils.isEmpty(chatroomName)) {
                throw new IllegalArgumentException("Chatroom name can't be empty or null");
            } else {
                VolleyHelper helper = new VolleyHelper(context, URLFactory.getRenameChatroomUrl(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        try {
                            if (!TextUtils.isEmpty(response) && response.equals("1")) {
                                SessionData.getInstance().setCurrentChatroomName(chatroomName);
                                JSONObject json = new JSONObject();
                                json.put("rename_success", chatroomName);
                                callbacks.successCallback(json);
                            } else {
                                failCallback(response, false);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (response.equals("2")) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_YOU_ARE_NOT_OWNER,
                                    ErrorKeys.MESSAGE_NOT_CHATROOM_OWNER));
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_ROOM_ALREADY_EXIST,
                                    ErrorKeys.MESSAGE_ROOM_ALREADY_EXIST));
                        }
                    }
                });
                helper.addNameValuePair(CometChatKeys.ChatroomKeys.CNAME, chatroomName.trim());
                helper.addNameValuePair(AjaxKeys.ID, chatroomid);
                helper.sendAjax();
            }
        }

    }
}
