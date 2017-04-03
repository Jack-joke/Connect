/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.heartbeats;

import android.content.Context;
import android.content.Intent;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.ChatroomKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.orm.SugarRecord;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.util.Iterator;
import java.util.Timer;
import java.util.TimerTask;

public class HeartbeatChatroom {

    private Timer timer;
    private static HeartbeatChatroom heartbeatChatroom;
    private boolean useComet, translateOn = true, isNewMessage, oldMessageIsNew, firstHeartbeat = true;
    private String cookiePrefix = "cc_";
    private JSONObject chatroomObject = new JSONObject();

    public static HeartbeatChatroom getInstance() {
        if (null == heartbeatChatroom) {
            heartbeatChatroom = new HeartbeatChatroom();
        }
        return heartbeatChatroom;
    }

    public void startHeartbeat(final Context context) {

        Logger.error("Chatroom Heartbeat started");
        final SessionData session = SessionData.getInstance();
        final Config config = JsonPhp.getInstance().getConfig();
        final long maxHeartbeat = Long.parseLong(config.getMaxHeartbeat()), minHeartbeat = Long.parseLong(config
                .getMinHeartbeat());
        useComet = config.getUSECOMET().equals("1");
        translateOn = JsonPhp.getInstance().getRealtimeTranslation() != null && JsonPhp.getInstance()
                .getRealtimeTranslation().equals("1");
        if (JsonPhp.getInstance().getCookieprefix() != null) {
            cookiePrefix = JsonPhp.getInstance().getCookieprefix();
        }
        timer = new Timer();

        final VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomUrl(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                response = response.trim();
                //Logger.error("chatroom heartbeat = " + response);
                if (response.equals("[]")) {
                    // Logger.info("No data returned from server for chatroom.php polling");
                    if (!useComet) {
                        session.setChatroomHeartbeatIdealCount(session.getChatroomHeartbeatIdealCount() + 1);
                        if (session.getChatroomHeartbeatIdealCount() > 4) {
                            session.setChatroomHeartbeatIdealCount(1);
                            long newInterval = session.getChatroomHeartbeatInterval() * 2;
                            if (newInterval > maxHeartbeat) {
                                newInterval = maxHeartbeat;
                            }
                            if (newInterval != session.getChatroomHeartbeatInterval()) {
                                session.setChatroomHeartbeatInterval(newInterval);
                                changeChatroomHeartbeatInverval();
                            }
                        }
                    }
                } else {
                    try {
                        JSONObject chatroomListObject = new JSONObject(response);
                        if (chatroomListObject.has(ChatroomKeys.CHATROOM_LIST_JSON)) {
                            JSONObject list = chatroomListObject.getJSONObject(ChatroomKeys.CHATROOM_LIST_JSON);
                            Iterator<String> keys = list.keys();
                            while (keys.hasNext()) {
                                String key = keys.next();
                                chatroomObject.put(key.replace("_", ""), list.get(key));
                            }
                            PreferenceHelper.save(ChatroomKeys.CHATROOM_JSON, chatroomObject.toString());
                        }

                        JSONObject resultObject = new JSONObject(response);

                        if (resultObject.has(AjaxKeys.MESSAGES)) {
                            JSONArray messages = resultObject.getJSONArray(AjaxKeys.MESSAGES);
                            Logger.error("heartbeart chatroom message "+ messages);
                            if (messages.length() > 0) {
                                int length = messages.length(), i;
                                int lastMessageId = (messages.getJSONObject(length - 1)).getInt(AjaxKeys.ID);
                                session.setChatroomHeartBeatTimestamp(String.valueOf(lastMessageId));

                                oldMessageIsNew = false;
                                for (i = 0; i < length; i++) {
                                    final JSONObject message = messages.getJSONObject(i);
                                    final long buddyId = message.getLong(DatabaseKeys.ColoumnKeys.FROMID);
                                    Buddy buddy = Buddy.getBuddyDetails(buddyId);
                                    if(null == buddy){
                                        MessageHelper.getInstance().addNewBuddy(buddyId, context,
                                                new CometchatCallbacks() {
                                                    @Override
                                                    public void successCallback() {
                                                        isNewMessage = MessageHelper.getInstance().handleChatroomMessage(
                                                                message);
                                                    }
                                                    @Override
                                                    public void failCallback() {
                                                        isNewMessage = MessageHelper.getInstance().handleChatroomMessage(
                                                                message);
                                                    }
                                                }, 0);
                                    } else {
                                        isNewMessage = MessageHelper.getInstance().handleChatroomMessage(message);
                                    }

                                    if (isNewMessage) {
                                        oldMessageIsNew = true;
                                    }
                                }

                                if (oldMessageIsNew) {
                                    isNewMessage = true;
                                }

                                if (isNewMessage) {
                                    session.setChatroomBroadcastMissed(true);
                                    Intent intent = new Intent(
                                            BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                    context.sendBroadcast(intent);
                                }
                            }
                        }

                        if (resultObject.has(AjaxKeys.MODERATORIDS)){
                            PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_MODERATORS_ID, resultObject.get(AjaxKeys.MODERATORIDS).toString());
                        }

                        if (resultObject.has(ChatroomKeys.CHATROOM_MEMBERS_HASH)
                                && resultObject.has(ChatroomKeys.MEMBERS)) {

                            String heartbeatUserListHash = resultObject.getString(ChatroomKeys.CHATROOM_MEMBERS_HASH);
                            session.setChatroomMemberListHash(heartbeatUserListHash);
                            PreferenceHelper.save(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH, heartbeatUserListHash);

                            String chatromMembers = resultObject.getString(ChatroomKeys.MEMBERS);
                            Object json = new JSONTokener(chatromMembers).nextValue();
                            /*
                             * If members list is empty then it returns [] which
							 * is json array
							 */
                            if (json instanceof JSONObject) {
                                PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS, chatromMembers);
                            }
                            Intent i = new Intent(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_CHATROOM_MEMBERS);
                            context.sendBroadcast(i);
                            session.setChatroomListBroadcastMissed(true);
                        }

                        if (resultObject.has(ChatroomKeys.CHATROOM_LIST_HASH)
                                && resultObject.has(AjaxKeys.CHATROOM_LIST)) {
                            Logger.error("data received for list = " +
                             resultObject.get(AjaxKeys.CHATROOM_LIST));

                            if ("[]".equals(resultObject.get(AjaxKeys.CHATROOM_LIST).toString())
                                    || "{}".equals(resultObject.get(AjaxKeys.CHATROOM_LIST).toString())) {
                                SugarRecord.deleteAll(Chatroom.class);
                            } else {
                                JSONObject chatroomList = resultObject.getJSONObject(AjaxKeys.CHATROOM_LIST);
                                PreferenceHelper.save(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH,
                                        resultObject.getString(ChatroomKeys.CHATROOM_LIST_HASH));

                                Chatroom.updateAllChatrooms(chatroomList);
                            }

							/* Intimate the fragment to reload data */
                            Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                            intent.putExtra(
                                    BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);
                            session.setChatroomListBroadcastMissed(true);

                        }
                        if (resultObject.has(ChatroomKeys.ERROR)) {
                            String errorValue = resultObject.getString(ChatroomKeys.ERROR);

                            if (errorValue.equals(ChatroomKeys.ROOM_DOES_NOT_EXISTS)) {
                                // Currently joined chatroom is deleted
                                if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)){
                                    ChatroomManager.leaveChatroom(Long.parseLong(PreferenceHelper
                                            .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)), "3");
                                }
                            }
                        }
                        if (!useComet) {
                            session.setChatroomHeartbeatIdealCount(1);
                            if (session.getChatroomHeartbeatInterval() > minHeartbeat) {
                                session.setChatroomHeartbeatInterval(minHeartbeat);
                                changeChatroomHeartbeatInverval();
                            }
                        }
                    } catch (Exception e) {
                        Logger.error("HeartbeatChatroom.java: Error at parsing json for " + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    if (!useComet) {
                        session.setChatroomHeartbeatIdealCount(session.getChatroomHeartbeatIdealCount() + 1);
                        if (session.getChatroomHeartbeatIdealCount() > 4) {
                            session.setChatroomHeartbeatIdealCount(1);
                            long newInterval = session.getChatroomHeartbeatInterval() * 2;
                            if (newInterval > maxHeartbeat) {
                                newInterval = maxHeartbeat;
                            }
                            if (newInterval != session.getChatroomHeartbeatInterval()) {
                                session.setChatroomHeartbeatInterval(newInterval);
                                changeChatroomHeartbeatInverval();
                            }
                        }
                    }
                }
            }
        });
        timer.scheduleAtFixedRate(new TimerTask() {

            @Override
            public void run() {
                //vHelper.addNameValuePair(OneOnOneKeys.TYPING_TO, "0");
                //vHelper.addNameValuePair(ChatroomKeys.POPOUT, "0");
                vHelper.addNameValuePair(ChatroomKeys.CHATROOM_LIST_HASH,
                        PreferenceHelper.get(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH));
                vHelper.addNameValuePair(ChatroomKeys.CHATROOM_MEMBERS_HASH,
                        PreferenceHelper.get(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH));
                vHelper.addNameValuePair(ChatroomKeys.CURRENT_P,
                        PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD));
                vHelper.addNameValuePair(ChatroomKeys.CURRENT_ROOM,
                        PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));
                vHelper.addNameValuePair(AjaxKeys.TIMESTAMP, session.getChatroomHeartBeatTimestamp());
                Logger.error("timestamp "+session.getChatroomHeartBeatTimestamp());
               // vHelper.addNameValuePair(AjaxKeys.V, "1");

                if (firstHeartbeat) {
                    vHelper.addNameValuePair(AjaxKeys.FORCE, "1");
                    vHelper.addNameValuePair(AjaxKeys.INITIALIZE, "1");
                    vHelper.addNameValuePair(ChatroomKeys.CURRENT_ROOM, "0");
                    firstHeartbeat = false;
                }else {
                    vHelper.addNameValuePair(AjaxKeys.INITIALIZE, "0");
                    try {
                        JSONObject temp;
                        boolean send = false;
                        if (PreferenceHelper.contains(CometChatKeys.ChatroomKeys.CHATROOM_JSON)) {
                            temp = new JSONObject(PreferenceHelper.get(CometChatKeys.ChatroomKeys.CHATROOM_JSON));
                            send = true;
                        } else {
                            temp = new JSONObject();
                        }

                        String chatroomid = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
                        if (temp.length() != 0) {
                            chatroomObject = temp;
                        } else {
                            if (null!=chatroomid &&!chatroomid.equals("0")) {
                                if (chatroomObject.has(chatroomid)) {
                                    if (Long.parseLong(session.getChatroomHeartBeatTimestamp()) > chatroomObject.getLong(chatroomid)) {
                                        chatroomObject.put(chatroomid, session.getChatroomHeartBeatTimestamp());
                                    }
                                }
                            }
                        }
                        if (send && chatroomObject.length() > 0) {
                            vHelper.addNameValuePair(ChatroomKeys.READ_MESSAGES, chatroomObject.toString());
                            PreferenceHelper.save(CometChatKeys.ChatroomKeys.CHATROOM_JSON, chatroomObject.toString());
                        }
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                if (translateOn) {
                    vHelper.addNameValuePair(cookiePrefix + "lang",
                            PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE));
                } else {
                    vHelper.addNameValuePair(cookiePrefix + "lang", "");
                }
                vHelper.sendAjax();
            }

        }, 0, session.getChatroomHeartbeatInterval());

    }

    public void setForceHeartbeat() {
        firstHeartbeat = true;
    }

    public void stopHeartbeatChatroom() {
        if (timer != null) {
            timer.cancel();
            timer = null;
        }
    }

    public void changeChatroomHeartbeatInverval() {
        stopHeartbeatChatroom();
        startHeartbeat(PreferenceHelper.getContext());
    }
}
