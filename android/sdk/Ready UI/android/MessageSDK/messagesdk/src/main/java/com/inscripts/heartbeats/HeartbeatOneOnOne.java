/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.heartbeats;

import android.content.Context;
import android.content.Intent;
import android.text.TextUtils;
import android.widget.Toast;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.LogoutHelper;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Announcement;
import com.inscripts.models.Bot;
import com.inscripts.models.Buddy;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

public class HeartbeatOneOnOne {

    private static HeartbeatOneOnOne heartbeatOneOnOne;
    private boolean useComet, translateOn = true, isNewMessage, oldMessageIsNew;
    private int announcementId = 0, messageProcessedCount = 0;
    private String cookiePrefix = "cc_";
    private static Timer timer;
    boolean firstheartbeatResponse;
    private long serverTime;
    private static SubscribeCallbacks callbacklistener;
    private static LoginCallbacks readyUIListener;

    public static HeartbeatOneOnOne getInstance() {
        if (null == heartbeatOneOnOne) {
            heartbeatOneOnOne = new HeartbeatOneOnOne();
        }
        return heartbeatOneOnOne;
    }

    public static HeartbeatOneOnOne getInstance(SubscribeCallbacks listener) {
        if (null == heartbeatOneOnOne) {
            heartbeatOneOnOne = new HeartbeatOneOnOne();
        }
        if (null != listener) {
            callbacklistener = listener;
        }
        return heartbeatOneOnOne;
    }

    public static HeartbeatOneOnOne getInstance(LoginCallbacks listener) {
        if (null == heartbeatOneOnOne) {
            heartbeatOneOnOne = new HeartbeatOneOnOne();
        }
        if (null != listener) {
            readyUIListener = listener;
        }
        return heartbeatOneOnOne;
    }


    public LoginCallbacks getReadyUIListener(){
        return readyUIListener;
    }

    public void startHeartbeat(final Context context) {
        final SessionData session = SessionData.getInstance();
        final Config config = JsonPhp.getInstance().getConfig();
        final long minHeartbeat = Long.parseLong(config.getMinHeartbeat()), maxHeartbeat = Long.parseLong(config
                .getMaxHeartbeat());

        Logger.error("Minhearbeat valu = "+minHeartbeat+"    maxHearbeat value = "+maxHeartbeat);
        useComet = config.getUSECOMET().equals("1");
        translateOn = JsonPhp.getInstance().getRealtimeTranslation() != null && JsonPhp.getInstance()
                .getRealtimeTranslation().equals("1");
        firstheartbeatResponse = false;

        if (session.isInitialHeartbeat()) {
            firstheartbeatResponse = true;
            //session.setInitialHeartbeat(false);
            session.setUserInfoHeartBeatFlag("1");
            session.setOneOnOneHeartBeatTimestamp(0L);
        }

        if (JsonPhp.getInstance().getCookieprefix() != null) {
            cookiePrefix = JsonPhp.getInstance().getCookieprefix();
        }
        timer = new Timer();

        final VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getRecieveURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                response = response.trim();
                if (response.equals("[]")) {
                    // Logger.info("No data returned from server for receive.php polling");

                    if (!useComet) {
                        session.setOneOnOneHeartBeatIdealCount(session.getOneOnOneHeartBeatIdealCount() + 1);
                        if (session.getOneOnOneHeartBeatIdealCount() > 4) {
                            session.setOneOnOneHeartBeatIdealCount(1);
                            long newInterval = session.getOneOnOneHeartbeatInterval() * 2;
                            if (newInterval > maxHeartbeat) {
                                newInterval = maxHeartbeat;
                            }
                            if (newInterval != session.getOneOnOneHeartbeatInterval()) {
                                session.setOneOnOneHeartbeatInterval(newInterval);
                                changeOneOnOneHeartbeatInverval();
                            }
                        }
                    }
                } else if (response.contains("{\"loggedout\":")) {
                    Logger.error("Loggedout 1 error:" + response);
                } else if (response.contains("logout_message") && response.contains("loggedout")) {
                    try {
                        JSONObject jsonObject = new JSONObject(response);
                        if (jsonObject.has("logout_message")) {
                            Toast.makeText(context, jsonObject.getString("logout_message"), Toast.LENGTH_SHORT).show();
                        } else {
                            Toast.makeText(context, jsonObject.getString("logout_message"), Toast.LENGTH_SHORT).show();
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                    LogoutHelper.chatLogout();
                } else {
                    Logger.error("Received message in one on one" + response);
                    try {
                        final JSONObject resultObject = new JSONObject(response);
                        if (resultObject.has("st")) {
                            SessionData.getInstance().setServerTime(resultObject.getString("st"));
                            serverTime = System.currentTimeMillis() - (CommonUtils.correctIncomingTimestamp(Long.parseLong(resultObject.getString("st"))));
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SERVER_DIFFERENCE, serverTime);
                        }

                        if (resultObject.has(AjaxKeys.BUDDY_LIST_HASH) && resultObject.has(AjaxKeys.BUDDY_LIST)) {
                            new Thread(new Runnable() {
                                @Override
                                public void run() {
                                    try {
                                        PreferenceHelper.save(PreferenceKeys.HashKeys.BUDDY_LIST_HASH,
                                                resultObject.getString(AjaxKeys.BUDDY_LIST_HASH));
                                        String buddyListTemp = resultObject.getString(AjaxKeys.BUDDY_LIST);
                                        Object json = new JSONTokener(buddyListTemp).nextValue();

                                        if (json instanceof JSONObject) {
                                            if (callbacklistener != null) {
                                                callbacklistener.gotOnlineList(resultObject.getJSONObject(AjaxKeys.BUDDY_LIST));
                                            }
                                            Buddy.updateAllBuddies(resultObject.getJSONObject(AjaxKeys.BUDDY_LIST));
                                            /* Intimate the fragment to reload data */
                                            Intent intent = new Intent(
                                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                                            context.sendBroadcast(intent);
                                            session.setBuddyListBroadcastMissed(true);

                                            Intent i = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                            i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.REFRESH_LASTSEEN);
                                            context.sendBroadcast(i);

                                        } else if (json instanceof JSONArray) {

                                            Buddy.updateAllBuddies(resultObject.getJSONArray(AjaxKeys.BUDDY_LIST));

								            /* Intimate the fragment to reload data */
                                            Intent intent = new Intent(
                                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                                            context.sendBroadcast(intent);
                                            session.setBuddyListBroadcastMissed(true);
                                        }
                                        firstheartbeatResponse = false;
                                        session.setUserInfoHeartBeatFlag("0");
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }

                                }
                            }).start();

                        } else {
                            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                            iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(iintent);
                            SessionData.getInstance().setChatbadgeMissed(true);
                        }


                        if(resultObject.has(AjaxKeys.BOT_LIST)){
                            Logger.error("Got Bot list " + resultObject.getJSONObject(AjaxKeys.BOT_LIST));
                            PreferenceHelper.save(PreferenceKeys.HashKeys.BOT_LIST_HASH, resultObject.getString(AjaxKeys.BOT_LIST_HAST));
                            if (callbacklistener != null) {
                                callbacklistener.gotBotList(resultObject.getJSONObject(AjaxKeys.BOT_LIST));
                            }
                            Bot.updateAllBots(resultObject.getJSONObject(AjaxKeys.BOT_LIST));
                        }

                        if (resultObject.has(AjaxKeys.COMETID)) {
                            JSONObject cometIdDetails = resultObject.getJSONObject(AjaxKeys.COMETID);
                            session.setCometID(cometIdDetails.getString(AjaxKeys.ID));
                            /* Subscribe to the channel which is our cometid */
                            String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                            if (transport.equals("cometservice")) {
                                CometserviceOneOnOne.getInstance().startCometService(session.getCometID());
                                if (callbacklistener != null) {
                                    CometserviceOneOnOne.getInstance().startCometService(session.getCometID(),
                                            callbacklistener);
                                }
                            } else if (transport.equals("cometservice-selfhosted")) {
                                WebsyncOneOnOne.getInstance().connect(JsonPhp.getInstance().getWebsyncServer(),
                                        session.getCometID());
                            }
                        }

                        if (resultObject.has(AjaxKeys.MESSAGES)) {
                            JSONObject messages = resultObject.getJSONObject(AjaxKeys.MESSAGES);
                            Logger.error("Message receiver in hearbeat = "+messages);
                            if (messages.length() > 0) {
                                /* New Messages have arrived */
                                Iterator<String> iterator = messages.keys();
                                List<String> sortedKeys = new ArrayList<>();
                                while (iterator.hasNext()) {
                                    sortedKeys.add(iterator.next());
                                }
                                Collections.sort(sortedKeys);
                                oldMessageIsNew = false;
                                messageProcessedCount = 0;
                                for (String messageId : sortedKeys) {
                                    final JSONObject message = messages.getJSONObject(messageId);

                                    if (message.has(AjaxKeys.MESSAGE)) {
                                        if (TextUtils.isEmpty(message.getString(AjaxKeys.MESSAGE))) {
                                            continue;
                                        }
                                    }
                                    if (callbacklistener != null) {
                                        MessageHelper.getInstance().handleOneOnOneMessage(message, callbacklistener, true);
                                    }

                                    Logger.error("Messahe json == "+message);
                                    if(readyUIListener != null){
                                        JSONObject messageJson = new JSONObject();
                                        messageJson.put("user_id",message.get("from"));
                                        messageJson.put("self",message.get("self"));
                                        messageJson.put("message_id",message.get("id"));
                                        readyUIListener.onMessageReceive(messageJson);
                                    }

                                    session.setOneOnOneHeartBeatTimestamp(message.getLong(AjaxKeys.ID));
                                    final long buddyId = message.getLong(AjaxKeys.FROM);
                                    Buddy buddy = Buddy.getBuddyDetails(buddyId);
                                    if (null == buddy) {
                                        MessageHelper.getInstance().addNewBuddy(buddyId, context,
                                                new CometchatCallbacks() {
                                                    @Override
                                                    public void successCallback() {
                                                        isNewMessage = MessageHelper.getInstance()
                                                                .handleOneOnOneMessage(Buddy.getBuddyDetails(buddyId),
                                                                        message);

                                                        messageProcessedCount++;
                                                    }

                                                    @Override
                                                    public void failCallback() {
                                                        isNewMessage = MessageHelper.getInstance()
                                                                .handleOneOnOneMessage(Buddy.getBuddyDetails(buddyId),
                                                                        message);
                                                        messageProcessedCount++;
                                                    }
                                                }, null);
                                    } else {
                                        isNewMessage = MessageHelper.getInstance().handleOneOnOneMessage(buddy,
                                                message);
                                        messageProcessedCount++;
                                    }
                                    if (isNewMessage) {
                                        oldMessageIsNew = true;
                                    }
                                }
                                if (firstheartbeatResponse && messageProcessedCount == sortedKeys.size()) {
                                    firstheartbeatResponse = false;
                                    session.setUserInfoHeartBeatFlag("0");
                                }
                                sortedKeys.clear();
                                if (oldMessageIsNew) {
                                    isNewMessage = true;
                                }
                                if (isNewMessage) {
                                    Intent intent = new Intent(
                                            BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                    context.sendBroadcast(intent);
                                }
                            }
                        }
                        session.setCall(true);

                        if (resultObject.has(AjaxKeys.INITIALIZE)) {
                            session.setOneOnOneHeartBeatTimestamp(resultObject.getLong(AjaxKeys.INITIALIZE));
                            // Add call to announcement index.php
                            if (null != config.getAnnouncementEnabled() && config.getAnnouncementEnabled().equals("1")) {

                                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAnnouncementUrl(),
                                        new VolleyAjaxCallbacks() {

                                            @Override
                                            public void successCallback(String response) {
                                                try {
                                                    if (!"[]".equals(response)) {
                                                        JSONObject annObject = new JSONObject(response);
                                                        Announcement.updateAnnouncements(annObject, announcementId);
                                                    }

                                                    Intent intent = new Intent(
                                                            BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_UPDATATION);
                                                    intent.putExtra(
                                                            BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_LIST,
                                                            1);
                                                    context.sendBroadcast(intent);
                                                    session.setAnnouncementListBroadcastMissed(true);
                                                    if (null != session.getTopFragment() && !session.getTopFragment().equals(
                                                            StaticMembers.TOP_FRAGMENT_ANNOUNCEMENT)) {
                                                        Intent iintent = new Intent(
                                                                BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                                                        iintent.putExtra(
                                                                BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_BADGE,
                                                                1);
                                                        context.sendBroadcast(iintent);

                                                    }
                                                } catch (Exception e) {
                                                    e.printStackTrace();
                                                }
                                            }

                                            @Override
                                            public void failCallback(String response, boolean isNoInternet) {

                                            }
                                        });
                                vHelper.sendAjax();
                            }
                        }

                        if (resultObject.has(AjaxKeys.USER_STATUS)) {
                            // Set to 0 once we get user data
                            if (!firstheartbeatResponse) {
                                session.setUserInfoHeartBeatFlag("0");
                            }
                            JSONObject userStatus = resultObject.getJSONObject(AjaxKeys.USER_STATUS);
                            PreferenceHelper.save(PreferenceKeys.DataKeys.USER_STATUS, userStatus.toString());
                            session.update(userStatus);

                            Intent statusintent = new Intent(
                                    BroadcastReceiverKeys.IntentExtrasKeys.USER_STATUS);
                            statusintent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_USER_STATUS, 1);
                            context.sendBroadcast(statusintent);

                            if (null != callbacklistener) {
                                callbacklistener.gotProfileInfo(userStatus);
                            }


                            if (userStatus.has("webrtc_channel")) {
                                PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_CHANNEL,
                                        userStatus.getString("webrtc_channel"));
                            } else if (userStatus.has("webrtc_prefix")) {
                                PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_CHANNEL,
                                        userStatus.getString("webrtc_prefix"));
                            } else {
                                if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.WEBRTC_CHANNEL)) {
                                    PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_CHANNEL, "");
                                }
                            }
                            //PushNotificationsManager.subscribe(false, session.getAnnParseChannel());



                            JSONObject pushinfo = new JSONObject();
                            pushinfo.put("push_channel",userStatus.get("push_channel"));
                            pushinfo.put("push_an_channel",userStatus.get("push_an_channel"));
                            if (null != readyUIListener) {
                                readyUIListener.userInfoCallback(pushinfo);
                            }
                        }


                        if (resultObject.has(AjaxKeys.ANNOUNCEMENT)) {
                            JSONObject announcementDetails = resultObject.getJSONObject(AjaxKeys.ANNOUNCEMENT);
                            if (announcementDetails.getInt(AjaxKeys.ID) > announcementId) {
                                announcementId = announcementDetails.getInt(AjaxKeys.ID);
                            }
                            if (null != callbacklistener) {
                                callbacklistener.gotAnnouncement(announcementDetails);
                            }

                            Announcement ann = Announcement.findById(announcementDetails.getLong(AjaxKeys.ID));

                            boolean isNew = false;
                            if (null == ann) {
                                ann = new Announcement();
                                isNew = true;
                            }

                            ann.announcementId = announcementId;
                            ann.message = announcementDetails.getString(JsonParsingKeys.STATUS_MESSAGE);
                            ann.sentTimestamp = CommonUtils.correctIncomingTimestamp(Long.parseLong(announcementDetails
                                    .getString(JsonParsingKeys.ANNOUNCEMENT_TIME)));
                            ann.save();

                            if (isNew) {
                                Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_UPDATATION);
                                intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_LIST, 1);
                                context.sendBroadcast(intent);
                                if (session.getTopFragment() != null && !session.getTopFragment().equals(StaticMembers.TOP_FRAGMENT_ANNOUNCEMENT)) {
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.ANN_BADGE_COUNT,
                                            Integer.parseInt(PreferenceHelper
                                                    .get(PreferenceKeys.DataKeys.ANN_BADGE_COUNT)) + 1);
                                    Intent iintent = new Intent(
                                            BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                                    iintent.putExtra(
                                            BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_BADGE, 1);
                                    context.sendBroadcast(iintent);

                                }
                            }
                            session.setAnnouncementListBroadcastMissed(true);
                        }

                        if (!useComet) {
                            session.setOneOnOneHeartBeatIdealCount(1);
                            if (session.getOneOnOneHeartbeatInterval() > minHeartbeat) {
                                session.setOneOnOneHeartbeatInterval(minHeartbeat);
                                changeOneOnOneHeartbeatInverval();
                            }
                        }
                    } catch (Exception e) {
                        Logger.error("HeartbeatOneOnOne.java: 200 Error at parsing json for " + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    if (!useComet) {
                        session.setOneOnOneHeartBeatIdealCount(session.getOneOnOneHeartBeatIdealCount() + 1);
                        if (session.getOneOnOneHeartBeatIdealCount() > 4) {
                            session.setOneOnOneHeartBeatIdealCount(1);
                            long newInterval = session.getOneOnOneHeartbeatInterval() * 2;
                            if (newInterval > maxHeartbeat) {
                                newInterval = maxHeartbeat;
                            }
                            if (newInterval != session.getOneOnOneHeartbeatInterval()) {
                                session.setOneOnOneHeartbeatInterval(newInterval);
                                changeOneOnOneHeartbeatInverval();
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
                //vHelper.addNameValuePair(StatusKeys.STATUS, PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS));
                vHelper.addNameValuePair(AjaxKeys.BUDDY_LIST, "1");
                //vHelper.addNameValuePair(OneOnOneKeys.CURRENT_TIME, "0");
                vHelper.addNameValuePair(AjaxKeys.BUDDY_LIST_HASH,
                        PreferenceHelper.get(PreferenceKeys.HashKeys.BUDDY_LIST_HASH));
                vHelper.addNameValuePair(AjaxKeys.BOT_LIST_HAST,PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH));
                if (session.isInitialHeartbeat()) {
                    vHelper.addNameValuePair(AjaxKeys.INITIALIZE, "1");
                    vHelper.addNameValuePair(CometChatKeys.StatusKeys.STATUS, "");
                    session.setInitialHeartbeat(false);
                    session.setCall(false);
                } else {
                    vHelper.addNameValuePair(AjaxKeys.INITIALIZE, "0");
                    vHelper.addNameValuePair(CometChatKeys.StatusKeys.STATUS, PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS));
                }

                if (PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID) != null) {
                    vHelper.addNameValuePair(AjaxKeys.ACTIVE_CHATWINDOW_ID, Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID)));
                }

                if (useComet) {
                    vHelper.addNameValuePair(AjaxKeys.TIMESTAMP, "0");
                } else {
                    vHelper.addNameValuePair(AjaxKeys.TIMESTAMP,
                            String.valueOf(session.getOneOnOneHeartBeatTimestamp()));
                }
                vHelper.addNameValuePair(cookiePrefix + AjaxKeys.ANNOUNCEMENT, String.valueOf(announcementId));
                if (translateOn) {
                    vHelper.addNameValuePair(cookiePrefix + "lang",
                            PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE));
                } else {
                    vHelper.addNameValuePair(cookiePrefix + "lang", "");
                }
                vHelper.sendAjax();
            }
        }, 0, session.getOneOnOneHeartbeatInterval());
    }

    public void stopHeartbeatOneOnOne() {
        if (timer != null) {
            timer.cancel();
            timer = null;
        }
    }

    public void changeOneOnOneHeartbeatInverval() {
        stopHeartbeatOneOnOne();
        startHeartbeat(PreferenceHelper.getContext());
    }

}
