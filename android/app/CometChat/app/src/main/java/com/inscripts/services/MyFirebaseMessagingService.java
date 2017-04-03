package com.inscripts.services;

import android.annotation.SuppressLint;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.support.v4.app.NotificationCompat;
import android.text.TextUtils;

import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;
import com.google.gson.Gson;
import com.inscripts.activities.CometChatActivity;
import com.inscripts.activities.R;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.utils.SessionData;
import com.inscripts.videochat.IncomingCallActivity;

import org.json.JSONObject;

import java.util.Map;

public class MyFirebaseMessagingService extends FirebaseMessagingService {

    private static final String TAG = "MyFirebaseMsgService";
    private static SessionData session = SessionData.getInstance();
    private static final String DELIMITER = "#:::#";

    public MyFirebaseMessagingService() {
        super();

    }

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        PreferenceHelper.initialize(this);
        //Logger.error(" on message receive "+remoteMessage);


        JsonPhp jp = JsonPhp.getInstance();
        if (null == jp) {
            Gson gson = new Gson();
            JsonPhp.setInstance(gson.fromJson(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
        }
        try {
            Intent intent = new Intent(this, CometChatActivity.class);
            Map<String, String> titleText = remoteMessage.getData();
            //Log.d(TAG, "Notification data " + remoteMessage.getData().toString());
            JSONObject jsonData = new JSONObject();

            if (titleText.containsKey("action")) {
                jsonData.put("action",titleText.get("action"));
            }
            if (titleText.containsKey("t")) {
                jsonData.put("t", titleText.get("t"));
            }
            if (titleText.containsKey("alert")) {
                jsonData.put("alert", titleText.get("alert"));
            }
            if (titleText.containsKey("badge")) {
                jsonData.put("badge", titleText.get("badge"));
            }
            if (titleText.containsKey("sound")) {
                jsonData.put("sound", titleText.get("sound"));
            }
            if (titleText.containsKey("title")) {
                jsonData.put("title", titleText.get("title"));
            }
            if (titleText.containsKey("isCR")) {
                jsonData.put("isCR", titleText.get("isCR"));
            }
            if (titleText.containsKey("isANN")) {
                jsonData.put("isANN", titleText.get("isANN"));
            }


            //Calling method to generate notification

            if (titleText.containsKey("m")) {
                jsonData.put("m",titleText.get("m").toString());
                JSONObject messageJson = new JSONObject(titleText.get("m"));
                String type = titleText.get(PushNotificationKeys.TYPE);
                String alert = titleText.get(PushNotificationKeys.ALERT);
                String title = this.getString(this.getApplicationInfo().labelRes);

                /*if (titleText.containsKey("isCR")
                        && titleText.get("isCR") == "1") {*/
                    if (type.equals("C") ){

                    if (!"0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))
                            && null != PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
                        // You're a part of a chatroom
                        if (!PreferenceHelper.get(PreferenceKeys.UserKeys.USER_ID).equals(messageJson.getString(PushNotificationKeys.FROM_ID))
                                && ("0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))
                                || !(messageJson.getString("cid").equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))))) {
                            intent.putExtra(PushNotificationsManager.PushNotificationKeys.DATA,jsonData.toString());
                            showNotification(this, alert, title, intent);
                        }
                    }
                } else if (titleText.containsKey("isANN")) {
                    if (jp != null && null != jp.getLang()) {
                        intent.putExtra(PushNotificationsManager.PushNotificationKeys.DATA,jsonData.toString());
                        showNotification(this, alert, jp.getLang().getAnnouncements().get100(), intent);
                    } else {
                        intent.putExtra(PushNotificationsManager.PushNotificationKeys.DATA,jsonData.toString());
                        showNotification(this, alert, "Announcements", intent);
                    }
                } else {

                    Long buddyId = messageJson.getLong(PushNotificationKeys.FROM_ID);
                    if (PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID)) {
                        // if we are chatting with someone
                        if (messageJson.has("m")) {

                            long buddyWindowId = Long.parseLong(PreferenceHelper
                                    .get(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID));
                            if (type.contains("O_A")) {
                                Intent i = new Intent(this, IncomingCallActivity.class);
                                if (type.equals("O_AVC")) {
                                    i.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, false);
                                } else if (type.equals("O_AC")) {
                                    i.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                                }
                                if (titleText.containsKey("grp")) {
                                    i.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, titleText.get("grp"));
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
                                                            CometChatKeys.MessageTypeKeys.AVCHAT, "", 1, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);
                                                    mess.save();

                                                    i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    i.addFlags(Intent.FLAG_ACTIVITY_EXCLUDE_FROM_RECENTS);
                                                    i.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, String.valueOf(buddyId));
                                                    i.putExtra(CometChatKeys.AVchatKeys.CALLER_NAME, messageJson.getString("name"));
                                                    this.startActivity(i);
                                                }
                                            } catch (Exception e) {
                                                e.printStackTrace();
                                            }
                                        }
                                    } else {
                                        //Logger.error("Notification is arrived late ");
                                    }
                                }
                            } else {
                                if (buddyWindowId != buddyId || buddyWindowId == 0) {
                                    intent.putExtra(PushNotificationsManager.PushNotificationKeys.DATA,jsonData.toString());
                                    showNotification(this, alert, title, intent);
                                }
                            }
                        }
                    }else{
                        intent.putExtra(PushNotificationsManager.PushNotificationKeys.DATA, jsonData.toString());
                        showNotification(this, alert, title, intent);
                    }

                }
            }

        }catch (Exception e){
            //Logger.error("In firebase exception");
            e.printStackTrace();

        }


        //showNotification(this, remoteMessage.getNotification().getBody(), remoteMessage.getData(),intent);
       // sendNotification(remoteMessage.getNotification().getBody());
    }

    //This method is only generating push notification
    //It is same as we did in earlier posts
  /*  private void sendNotification(String messageBody) {

        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, intent,
                PendingIntent.FLAG_ONE_SHOT);


       *//* Uri defaultSoundUri= RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
                .setSmallIcon(R.mipmap.ic_launcher)
                .setContentTitle("Firebase Push Notification")
                .setContentText(messageBody)
                .setAutoCancel(true)
                .setSound(defaultSoundUri)
                .setContentIntent(pendingIntent);

        NotificationManager notificationManager =(NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);

        notificationManager.notify(0, notificationBuilder.build());*//*
    }*/
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


    @SuppressLint("NewApi")
    public static void showNotification(Context context, String notificationText, String titleText, Intent resultIntent) {
        try {
            boolean showNotification = PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_ON).equals("1");
            if (showNotification && session.getAvchatStatus() == 0) {
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
                        /*Code for custom notification sound too be uncomented in future realease*/
                        // CommonUtils.playSound(context, "notification_sound.wav");
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

}