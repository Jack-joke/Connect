package fireBaseServices;

import android.annotation.SuppressLint;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.support.v4.app.NotificationCompat;
import android.text.TextUtils;
import android.util.Log;

import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;

import org.json.JSONException;
import org.json.JSONObject;

import helper.Keys;
import helper.SharedPreferenceHelper;
import inscripts.com.librarytestapp.ChooserActivity;
import inscripts.com.librarytestapp.R;
import inscripts.com.librarytestapp.SampleCometChatActivity;

public class MyFirebaseMessagingService extends FirebaseMessagingService {

    private static final String TAG = "MyFirebaseMsgService";
    private static final String DELIMITER = "#:::#";

    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        //Displaying data in log
        //It is optional
        Log.d(TAG, "From: " + remoteMessage.getFrom());
        Log.e(TAG,"Notification data payload = "+remoteMessage.getData());
        //Log.d(TAG, "Notification Message Body: " + remoteMessage.getNotification().getBody());

        //Calling method to generate notification
        //sendNotification(remoteMessage.getNotification().getBody());
        Intent intent = new Intent(this, ChooserActivity.class);
        String datapayload = remoteMessage.getData().get("m");
        Log.e(TAG,"Message value = "+datapayload);
        try {
            JSONObject message = new JSONObject(datapayload);
            showNotification(this,message.getString("m"),"CometChat SDK",intent);
        } catch (JSONException e) {
            e.printStackTrace();
        }
    }



    @SuppressLint("NewApi")
    public static void showNotification(Context context, String notificationText, String titleText, Intent resultIntent) {
        try {

            String storedNotificationStack = SharedPreferenceHelper.get(Keys.SharedPreferenceKeys.NOTIFICATION_STACK);
            if (TextUtils.isEmpty(storedNotificationStack)) {
                storedNotificationStack = notificationText;
            } else {
                storedNotificationStack = storedNotificationStack + DELIMITER + notificationText;
            }

            SharedPreferenceHelper.save(Keys.SharedPreferenceKeys.NOTIFICATION_STACK, storedNotificationStack);
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
                resultIntent.setClass(context, SampleCometChatActivity.class);
            }

            // To ensure onNewIntent is fired
            resultIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
            resultIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            resultIntent.addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

            PendingIntent pIntent = PendingIntent.getActivity(context, 1, resultIntent,
                    PendingIntent.FLAG_UPDATE_CURRENT);
            NotificationCompat.Builder mBuilder = new NotificationCompat.Builder(context);

            Notification summaryNotification = mBuilder.setContentTitle(appName)
                    .setSmallIcon(R.drawable.ic_launcher_small)
                    .setLargeIcon(BitmapFactory.decodeResource(context.getResources(), R.drawable.ic_launcher))
                    .setContentText(contentText).setContentIntent(pIntent).setAutoCancel(true).setStyle(style).build();

            summaryNotification.defaults |= Notification.DEFAULT_SOUND;

            summaryNotification.defaults |= Notification.DEFAULT_VIBRATE;

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
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}