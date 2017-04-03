/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/package com.inscripts.plugins;

import android.annotation.SuppressLint;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.NotificationCompat;
import android.text.TextUtils;

import com.google.firebase.messaging.FirebaseMessaging;
import com.google.gson.Gson;
import com.inscripts.activities.CometChatActivity;
import com.inscripts.activities.R;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.videochat.IncomingCallActivity;
import com.parse.ParseException;
import com.parse.ParseInstallation;
import com.parse.ParsePush;
import com.parse.ParsePushBroadcastReceiver;
import com.parse.SaveCallback;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class PushNotificationsManager extends ParsePushBroadcastReceiver {

    private static final String DELIMITER = "#:::#";
    private static SessionData session = SessionData.getInstance();



    public static ArrayList<String> chatroomChannelList = new ArrayList<String>();

    // private static AtomicInteger notificationId = new AtomicInteger(0);
    private static String currentChannel = null;

    /**
     * Subscribes to a channel based on the parameter passed. Pass <b>true</b>
     * for chatrooms
     */
    public static void subscribe(boolean isChatroom, String announcementChannel) {
        try {
            if (isChatroom) {
                if(chatroomChannelList == null){
                    chatroomChannelList = new ArrayList<String>();
                }
                currentChannel = SessionData.getInstance().getChatroomParseChannel();
                if(!chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())  ){
                    if(!PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)){
                        chatroomChannelList.add(SessionData.getInstance().getChatroomParseChannel());
                    }else{
                        String channelListStr = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                        if (!TextUtils.isEmpty(channelListStr)) {
                            channelListStr = channelListStr.substring(1, channelListStr.length() - 1);
                            //Logger.error("channel List string :   " + channelListStr);
                        }
                        List<String> items = Arrays.asList(channelListStr.split("\\s*,\\s*"));
                        //Logger.error("list size channel " + items.size());

                        if (items.size() > 0) {
                            for (int i = 0; i < items.size(); i++) {
                                if (!chatroomChannelList.contains(items.get(i))){
                                    chatroomChannelList.add(items.get(i));
                                }

                            }
                        }
                        if (!chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())){
                            chatroomChannelList.add(SessionData.getInstance().getChatroomParseChannel());
                        }


                    }

                }

                PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST, chatroomChannelList.toString());
            } else {
                currentChannel = SessionData.getInstance().getParseChannel();
            }
            if (null != currentChannel){
                FirebaseMessaging.getInstance().subscribeToTopic(currentChannel);
                ParsePush.subscribeInBackground(currentChannel);
            }
            if (!TextUtils.isEmpty(announcementChannel)) {
                FirebaseMessaging.getInstance().subscribeToTopic(announcementChannel);
                ParsePush.subscribeInBackground(announcementChannel);
            }
            ParseInstallation.getCurrentInstallation().saveInBackground();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void setChatroomChannelList(ArrayList<String> chatroomChannelList) {
        PushNotificationsManager.chatroomChannelList = chatroomChannelList;
    }

    public static void unsubscribe(boolean isChatroom,boolean isclearAll) {
        try {
            if (isChatroom) {
                if(isclearAll){
                    if(PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)){
                        String channelListStr = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                        if (!TextUtils.isEmpty(channelListStr)) {
                            channelListStr = channelListStr.substring(1, channelListStr.length()-1);
                            //Logger.error("channel List string :   " + channelListStr);
                        }
                        List<String> items = Arrays.asList(channelListStr.split("\\s*,\\s*"));
                        //Logger.error("list size channel "+items.size());
                        if (items.size() > 0) {
                            for (int i = 0; i < items.size(); i++) {
                                //Logger.error("unsub channel list "+ items.get(i));
                                ParsePush.unsubscribeInBackground(items.get(i));
                                FirebaseMessaging.getInstance().unsubscribeFromTopic(items.get(i));
                            }
                        }
                    }
                }else {
                    currentChannel = SessionData.getInstance().getChatroomParseChannel();
                    if(chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())){
                        chatroomChannelList.remove(SessionData.getInstance().getChatroomParseChannel());
                    }else if(PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)){
                        String channelListStr = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                        if (!TextUtils.isEmpty(channelListStr)) {
                            channelListStr = channelListStr.substring(1, channelListStr.length() - 1);
                            //Logger.error("channel List string :   " + channelListStr);
                        }
                        List<String> items = Arrays.asList(channelListStr.split("\\s*,\\s*"));
                        if (items.size() > 0) {
                            for (int i = 0; i < items.size(); i++) {
                                if(!chatroomChannelList.contains(items.get(i))){
                                    chatroomChannelList.add(items.get(i));
                                }

                            }
                        }
                        if (chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())) {
                            chatroomChannelList.remove(SessionData.getInstance().getChatroomParseChannel());
                        }
                    }

                    PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST, chatroomChannelList.toString());

                }

            } else {
                currentChannel = SessionData.getInstance().getParseChannel();
                if (chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())) {
                    chatroomChannelList.remove(SessionData.getInstance().getChatroomParseChannel());
                } else if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)) {
                    String channelListStr = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                    if (!TextUtils.isEmpty(channelListStr)) {
                        channelListStr = channelListStr.substring(1, channelListStr.length() - 1);
                        //Logger.error("channel List string :   " + channelListStr);
                    }
                    List<String> items = Arrays.asList(channelListStr.split("\\s*,\\s*"));
                    // Logger.error("list size channel " + items.size());
                    if (items.size() > 0) {
                        for (int i = 0; i < items.size(); i++) {
                            if (!chatroomChannelList.contains(items.get(i))) {
                                chatroomChannelList.add(items.get(i));
                            }

                        }
                    }
                    if (chatroomChannelList.contains(SessionData.getInstance().getChatroomParseChannel())) {
                        chatroomChannelList.remove(SessionData.getInstance().getChatroomParseChannel());
                    }
                }

                PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST, chatroomChannelList.toString());


            }
            if (null != currentChannel) {
                ParsePush.unsubscribeInBackground(currentChannel);
                FirebaseMessaging.getInstance().unsubscribeFromTopic(currentChannel);
            }
            ParseInstallation.getCurrentInstallation().saveInBackground();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Unsubscribes from all the channels on the device.
     */
    public static void unsubscribeAll() {
        try {
            unsubscribe(true,true);

            unsubscribe(false,false);
            if (!TextUtils.isEmpty(SessionData.getInstance().getAnnParseChannel())) {
                ParsePush.unsubscribeInBackground(SessionData.getInstance().getAnnParseChannel());
                FirebaseMessaging.getInstance().unsubscribeFromTopic(SessionData.getInstance().getAnnParseChannel());
            }
            //Logger.error("YES-AN-unscribe is called " + currentChannel);
        } catch (Exception e) {
            e.printStackTrace();
        }

        ParseInstallation installation = ParseInstallation.getCurrentInstallation();
        installation.remove("channels");
        installation.saveEventually(new SaveCallback() {  // or saveInBackground
            @Override
            public void done(ParseException e) {
                // TODO: add code here
            }
        });
    }



    public static class PushNotificationKeys {
        public static final String MESSAGE = "m";
        public static final String DATA = "com.parse.Data";
        public static final String AV_CHAT = "avchat";
        public static final String FROM_ID = "fid";
        public static final String IS_CHATROOM = "isCR";
        public static final String ALERT = "alert";
        public static final String IS_ANNOUNCEMENT = "isANN";
        public static String TYPE = "t";
    }

    public static class FireBasePushNotificationKeys {
        public static final String  IS_FIREBASE_NOTIFICATION = "isFirebaseNotification";
        public static final String  MESSAGE_TYPE = "t";
        public static final String  IS_AUDIO_CALL = "O_AC";
        public static final String  IS_AV_CALL = "O_AVC";
        public static final String  ROOMNAME = "grp";

    }

    @SuppressLint("NewApi")
    public static void showNotification(Context context, String notificationText, String titleText, Intent resultIntent) {
        try {
            boolean showNotification = PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_ON).equals("1");
            if (showNotification &&  session.getAvchatStatus() == 0) {
                boolean isSoundActive = PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_SOUND).equals("1");
                boolean isVibrateActive = PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE).equals("1");

                boolean isUsingSystemSound = true;

                String storedNotificationStack = PreferenceHelper.get(PreferenceKeys.DataKeys.NOTIFICATION_STACK);
                if (TextUtils.isEmpty(storedNotificationStack)) {
                    storedNotificationStack = notificationText;
                } else {
                    storedNotificationStack = storedNotificationStack + DELIMITER + notificationText;
                }

                PreferenceHelper.save(PreferenceKeys.DataKeys.NOTIFICATION_STACK, storedNotificationStack);
                String[] allNotifications = storedNotificationStack.split(DELIMITER);

                String summaryText, contentText;
                if (allNotifications.length == 1) {
                    summaryText = allNotifications.length + " new message";
                    contentText = notificationText;
                } else {
                    contentText = summaryText = allNotifications.length + " new messages";
                }

                String appName = context.getString(context.getApplicationInfo().labelRes);

                NotificationCompat.InboxStyle style = new NotificationCompat.InboxStyle().setSummaryText(summaryText)
                        .setBigContentTitle(appName);

                boolean isSinglePerson = true;
                boolean gotFirstValue = false;
                String oldPart = "";

                for (int i = allNotifications.length - 1; i >= 0; i--) {

                    String notifi = allNotifications[i];
                    String latestPart = notifi.substring(0, notifi.indexOf(":"));

                    if (!gotFirstValue) {
                        oldPart = latestPart;
                        gotFirstValue = true;
                    }

                    if (!oldPart.equals(latestPart)) {
                        isSinglePerson = false;
                    }

                    oldPart = latestPart;

                    // Adding the line to the notification
                    style.addLine(notifi);
                }

                if (isSinglePerson == false) {
                    resultIntent = new Intent();
                    resultIntent.setClass(context, CometChatActivity.class);
                }

                // To ensure onNewIntent is fired
                resultIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                resultIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

                PendingIntent pIntent = PendingIntent.getActivity(context, 1, resultIntent,
                        PendingIntent.FLAG_UPDATE_CURRENT);
                NotificationCompat.Builder mBuilder = new NotificationCompat.Builder(context);

                Notification summaryNotification = mBuilder.setContentTitle(appName).setSmallIcon(R.drawable.ic_launcher_small)
                        .setLargeIcon(BitmapFactory.decodeResource(context.getResources(), R.drawable.ic_launcher))
                        .setContentText(contentText).setContentIntent(pIntent).setAutoCancel(true).setStyle(style).setColor(Color.parseColor("#002832")).build();

                if (isSoundActive) {
                    if (isUsingSystemSound) {
                        summaryNotification.defaults |= Notification.DEFAULT_SOUND;
                    } else {
                        try {
                        /* Play notification sound */
                            // notification.sound =
                            // Uri.parse("android.resource://"
                            // + context.getPackageName() + "/raw/beep");
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }

                if (isVibrateActive) {
                    summaryNotification.defaults |= Notification.DEFAULT_VIBRATE;
                }

                summaryNotification.flags |= Notification.FLAG_SHOW_LIGHTS;
                summaryNotification.ledARGB = 0xff00ff00;
                summaryNotification.ledOnMS = 300;
                summaryNotification.ledOffMS = 2000;

                if (android.os.Build.VERSION.SDK_INT >= 16) {
                    summaryNotification.priority = Notification.PRIORITY_MAX;
                }

                NotificationManager notificationManager = (NotificationManager) context
                        .getSystemService(Context.NOTIFICATION_SERVICE);
                notificationManager.notify(1, summaryNotification);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Create the text to be displayed in the notifications. Example -
     * "User1: Wassap nigga!?"
     */
    /*private static String prepareNotificationMessage(String rawTitle, String rawMessage, boolean isChatroom) {

        String processedMessage = null;
        Lang lang = JsonPhp.getInstance().getLang();

        if (rawMessage.contains(lang.getFiletransfer().get5())) {
            processedMessage = lang.getFiletransfer().get5();
        } else if (rawMessage.contains(lang.getFiletransfer().get7())) {
        } else if (rawMessage.contains("jqcc.ccavchat.accept(")) {
            processedMessage = lang.getAvchat().get2();
        } else if (rawMessage.contains(lang.getFiletransfer().get9())) {
            processedMessage = lang.getFiletransfer().get9();
        } else if (rawMessage.contains("jqcc.ccavchat.accept_fid")) {
            processedMessage = null;
        } else {
            processedMessage = rawMessage;
        }

        if (isChatroom) {
            processedMessage = rawTitle + "@" + SessionData.getInstance().getCurrentChatroomName() + ": "
                    + processedMessage;
        } else {
            processedMessage = rawTitle + ": " + processedMessage;
        }
        return processedMessage;
    }*/

    @Override
    public void onReceive(Context context, Intent intent) {
        try {
            intent.setClass(context, CometChatActivity.class);

            if (null == PreferenceHelper.getContext()) {
                PreferenceHelper.initialize(context);
            }

            JsonPhp jp = JsonPhp.getInstance();
            if (null == jp) {
                Gson gson = new Gson();
                JsonPhp.setInstance(gson.fromJson(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
            }

            Bundle bundle = intent.getExtras();

            if (null != bundle) {

                /*for (String key : bundle.keySet()) {
                    Object value = bundle.get(key);
                    Logger.debug(String.format("%s %s (%s)",
                            key, value.toString(), value.getClass().getName()));
                }*/

                JSONObject payload = new JSONObject(bundle.getString(PushNotificationKeys.DATA));
                JSONObject messageJson = payload.getJSONObject(PushNotificationKeys.MESSAGE);
                String alert = payload.getString(PushNotificationKeys.ALERT);
                String title = context.getString(context.getApplicationInfo().labelRes);
                String type = payload.getString(PushNotificationKeys.TYPE);

                if (payload.has(PushNotificationKeys.IS_CHATROOM)
                        && payload.getInt(PushNotificationKeys.IS_CHATROOM) == 1) {

                    if (!"0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) && null != PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                        // You're a part of a chatroom
                        if (!PreferenceHelper.get(PreferenceKeys.UserKeys.USER_ID).equals(messageJson.getString(PushNotificationKeys.FROM_ID))
                                && ("0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))
                                || !(messageJson.getString("cid").equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))))) {
                            showNotification(context, alert, title, intent);
                        }
                    }
                } else if (payload.has(PushNotificationKeys.IS_ANNOUNCEMENT)) {
                    if (jp != null && null != jp.getLang()) {
                        showNotification(context, jp.getLang().getMobile().get62() + ": " + alert, jp.getLang().getAnnouncements().get100(), intent);
                    } else {
                        showNotification(context, "Announcement: " + alert, "Announcements", intent);
                    }
                } else {
                    Long buddyId = messageJson.getLong(PushNotificationKeys.FROM_ID);
                    if (PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID)) {
                        // if we are chatting with someone
                        if (messageJson.has("m")) {

                            long buddyWindowId = Long.parseLong(PreferenceHelper
                                    .get(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID));
                            if (type.contains("O_A")) {
                                Intent i = new Intent(context, IncomingCallActivity.class);
                                if (type.equals("O_AVC")) {
                                    i.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, false);
                                } else if (type.equals("O_AC")) {
                                    i.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                                }
                                if (payload.has("grp")) {
                                    i.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, payload.getString("grp"));
                                }
                                if (messageJson.has("sent")) {
                                    Long time = messageJson.getLong("sent") * 1000;
                                    if ((System.currentTimeMillis() - time) < 60000) {
                                        if (buddyWindowId != buddyId || buddyWindowId == 0) {
                                            try {
                                                Long messageid = messageJson.getLong("id");
                                                OneOnOneMessage avmessage = OneOnOneMessage.findById(messageid);
                                                if (avmessage == null) {
                                                    final OneOnOneMessage mess = new OneOnOneMessage(messageid, buddyId,
                                                            Long.parseLong(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_ID)), messageJson.getString("m"), System.currentTimeMillis(), 1, 1,
                                                            CometChatKeys.MessageTypeKeys.AVCHAT, "", 1,CometChatKeys.MessageTypeKeys.MESSAGE_SENT);
                                                    mess.save();

                                                    i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    i.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                    i.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, String.valueOf(buddyId));
                                                    i.putExtra(CometChatKeys.AVchatKeys.CALLER_NAME, messageJson.getString("name"));
                                                    context.startActivity(i);
                                                }
                                            } catch (Exception e) {
                                                e.printStackTrace();
                                            }
                                        }
                                    } else {
                                        Logger.error("Notification is arrived late ");
                                    }
                                }
                            } else {
                                if (buddyWindowId != buddyId || buddyWindowId == 0) {
                                    showNotification(context, alert, title, intent);
                                }
                            }
                        }
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Clears all the notifications
     */
    public static void clearAllNotifications() {
        NotificationManager notificationManager = (NotificationManager) PreferenceHelper.getContext().getSystemService(
                Context.NOTIFICATION_SERVICE);
        notificationManager.cancelAll();
        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.NOTIFICATION_STACK);
    }
}