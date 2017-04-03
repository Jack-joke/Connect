/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.res.AssetFileDescriptor;
import android.media.MediaPlayer;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Build;
import android.os.Vibrator;
import android.text.Html;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.TextUtils;
import android.text.format.DateFormat;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.util.Base64;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.TextView;

import com.android.volley.Request.Method;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.Locale;
import java.util.regex.Pattern;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

public class CommonUtils {

    private static Vibrator vibrator;
    private static MediaPlayer player;
    private static ConnectivityManager cm;
    public static HashMap<String, String> usertoChannelMap = new HashMap<>();
    private HeartbeatOneOnOne heartbeatOneOnOne;
    public static boolean isConnected() {
        if (cm == null) {
            cm = (ConnectivityManager) PreferenceHelper.getContext().getSystemService(Context.CONNECTIVITY_SERVICE);
        }
        NetworkInfo info = cm.getActiveNetworkInfo();
        if (null != info) {
            if (info.isConnectedOrConnecting()) {
                return true;
            }
        }
        return false;
    }

    @SuppressLint("SimpleDateFormat")
    public static String convertTimestampToDate(long timestamp) {
        Timestamp tStamp = new Timestamp(timestamp);
        SimpleDateFormat simpleDateFormat;
        boolean isArmyTime = null != JsonPhp.getInstance().getConfig().getArmyTime()
                && JsonPhp.getInstance().getConfig().getArmyTime().equals("1");

        if (isArmyTime) {
            simpleDateFormat = new SimpleDateFormat("H:mm");
        } else {
            simpleDateFormat = new SimpleDateFormat("hh:mm a");
        }

        /*if (DateUtils.isToday(timestamp)) {
            if (isArmyTime) {
                simpleDateFormat = new SimpleDateFormat("H:mm");
            } else {
                simpleDateFormat = new SimpleDateFormat("hh:mm a");
            }
           *//* if (null != JsonPhp.getInstance().getLang().getMobile() && null != JsonPhp.getInstance().getLang().getMobile().get179()){
                //return JsonPhp.getInstance().getLang().getMobile().get179() + " " + simpleDateFormat.format(tStamp);
                return JsonPhp.getInstance().getLang().getMobile().get179() + " " + simpleDateFormat.format(tStamp);
            }else if (null != JsonPhp.getInstance().getLang().getMobile() && null != JsonPhp.getInstance().getLang().getMobile().get37()){
                return JsonPhp.getInstance().getLang().getMobile().get37() + " " + simpleDateFormat.format(tStamp);
            }else{
                return "today at "+ simpleDateFormat.format(tStamp);
            }*//*

            return simpleDateFormat.format(tStamp);

        } else {
            if (isArmyTime) {
                simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy H:mm");
            } else {
                simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy hh:mm a");
            }
            return simpleDateFormat.format(tStamp);
        }*/

        return simpleDateFormat.format(tStamp);
    }

    public static String getFormattedDate(long messageTimeInMilis) {
        Lang lang = JsonPhp.getInstance().getLang();;
        Calendar messageTimestamp = Calendar.getInstance();
        messageTimestamp.setTimeInMillis(messageTimeInMilis);
        Calendar now = Calendar.getInstance();
        if(now.get(Calendar.DATE) == messageTimestamp.get(Calendar.DATE) ){
            if (lang != null && null != lang.getCore() && null != lang.getCore().getLangToday()) {
                return lang.getCore().getLangToday();
            } else {
                return "Today";
            }
        }else if(now.get(Calendar.DATE) - messageTimestamp.get(Calendar.DATE) == 1 ){
            if (lang != null && null != lang.getCore() && null != lang.getCore().getLangYesterday()) {
                return lang.getCore().getLangYesterday();
            } else {
                return "Yesterday";
            }
        }else {
            return DateFormat.format("d MMMM yyyy", messageTimestamp).toString();
        }
    }

    public static String getDateId(long time) {
        Calendar cal = Calendar.getInstance(Locale.ENGLISH);
        cal.setTimeInMillis(time);
        String date = DateFormat.format("ddMMyyyy", cal).toString();
        return date;
    }

    /* Used to show time duration for avchat calls */
    public static String convertTimeStampToDurationTime(long timestamp) {
        long second = timestamp / 1000;
        long minute = (second / 60) % 60;
        long hour = ((second / 60) / 60) % 24;
        if (hour == 0) {
            return String.format(Locale.getDefault(), "%02d:%02d", minute, second % 60);
        } else {
            return String.format(Locale.getDefault(), "%02d:%02d:%02d", hour, minute, second % 60);
        }

    }

    public static String checkOnlineStatus(Long lastseen) {
        if (lastseen == 0) {
            return "";
        } else {
            Lang lang = JsonPhp.getInstance().getLang();
            Long ladiff = System.currentTimeMillis() - lastseen;
            if (ladiff < 60000) {
                if (lang != null && null != lang.getMobile() && null != lang.getMobile().get159()) {
                    return lang.getMobile().get158();
                } else {
                    return "Online";
                }
            } else {
                if (lang != null && null != lang.getMobile() && null != lang.getMobile().get159()) {
                    return lang.getMobile().get159() + " " + convertTimestampToDate(lastseen);
                } else {
                    return "Last seen " + convertTimestampToDate(lastseen);
                }
            }
        }
    }

    public static byte[] xorWithKey(byte[] a, byte[] key) {
        byte[] out = new byte[a.length];
        for (int i = 0; i < a.length; i++) {
            out[i] = (byte) (a[i] ^ key[i % key.length]);
        }
        return out;
    }

    public static byte[] encodeBase64(String value) {
        return CommonUtils.encodeBase64(value.getBytes());
    }

    public static byte[] encodeBase64(byte[] value) {
        return Base64.encode(value, 0);
    }

    public static byte[] decodeBase64(String value) {
        return Base64.decode(value, 0);
    }

    public static byte[] decodeBase64(byte[] value) {
        return Base64.decode(value, 0);
    }

    /**
     * If timestamp is less than 13 digit then convert it to 13 digit
     *
     * @param timestampInMessage
     * @return corrected timestamp
     */
    public static long correctIncomingTimestamp(long timestampInMessage) {
        long correctedTimestamp = timestampInMessage;

        if (String.valueOf(timestampInMessage).length() < 13) {
            int difference = 13 - String.valueOf(timestampInMessage).length(), i;
            String differenceValue = "1";
            for (i = 0; i < difference; i++) {
                differenceValue += "0";
            }
            correctedTimestamp = (timestampInMessage * Long.parseLong(differenceValue))
                    + (System.currentTimeMillis() % (Long.parseLong(differenceValue)));
        }
        return correctedTimestamp;
    }

    public static String encodeURIComponent(String s) {
        String result;
        try {
            result = URLEncoder.encode(s, "UTF-8").replaceAll("\\+", "%20").replaceAll("\\%21", "!")
                    .replaceAll("\\%27", "'").replaceAll("\\%28", "(").replaceAll("\\%29", ")")
                    .replaceAll("\\%7E", "~");
        } catch (UnsupportedEncodingException e) {
            result = s;
        }
        return result;
    }

    @SuppressLint("DefaultLocale")
    public static boolean isSamsungWithApi16() {
        return (android.os.Build.MANUFACTURER.toLowerCase().equals(StaticMembers.SAMSUNG) && android.os.Build.VERSION.SDK_INT == 16);
    }

    public static boolean isSamsung() {
        return (android.os.Build.MANUFACTURER.toLowerCase().equals(StaticMembers.SAMSUNG) || android.os.Build.MANUFACTURER.toUpperCase().equals(StaticMembers.SAMSUNG));
    }

    public static boolean isXiaomi() {
        return (android.os.Build.MANUFACTURER.toLowerCase().equals(StaticMembers.XIAOMI) || android.os.Build.MANUFACTURER.toUpperCase().equals(StaticMembers.XIAOMI));
    }

    public static Vibrator getVibratorInstance(Context c) {
        if (null == vibrator) {
            vibrator = (Vibrator) c.getSystemService(Context.VIBRATOR_SERVICE);
        }
        return vibrator;
    }

    public static MediaPlayer getPlayerInstance() {
        if (null == player) {
            player = new MediaPlayer();
        }
        return player;
    }

    public static void resetPlayerInstance() {
        player = null;
    }

    public static boolean isJSONValid(String test) {
        try {
            new JSONObject(test);
        } catch (Exception ex) {
            return false;
        }
        return true;
    }

    public static void playRingtone(Activity activity, String ringtone) {
        try {
            if (!SessionData.getInstance().isMediaPlayerOn()) {
                player = CommonUtils.getPlayerInstance();
                player.reset();
                AssetFileDescriptor assetFileDescriptor = activity.getAssets().openFd(ringtone);
                player.setDataSource(assetFileDescriptor.getFileDescriptor(), assetFileDescriptor.getStartOffset(),
                        assetFileDescriptor.getLength());
                player.prepare();
                player.setLooping(true);
                player.start();
                SessionData.getInstance().setMediaPlayerOn(true);
            }
        } catch (Exception e) {
            Logger.error("OutgoingCallActivity.java stratPlayer Exception =" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    public static void stopRingtone() {
        try {
            SessionData.getInstance().setMediaPlayerOn(false);
            if (player == null) {
                getPlayerInstance().stop();
            } else {
                player.stop();
            }
        } catch (Exception e) {
            Logger.error("OutgoingCallActivity.java stopPlayer Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    public static void stopVibrate(Context context) {
        SessionData.getInstance().setVibrateOn(false);
        if (null == vibrator) {
            getVibratorInstance(context).cancel();
        } else {
            vibrator.cancel();
        }
    }

    /**
     * Returns screen type of device required for initial json
     *
     * @param context
     * @return Screen type
     */
    public static String getScreenType(Context context) {
        String density = "";
        switch (context.getResources().getDisplayMetrics().densityDpi) {
            case DisplayMetrics.DENSITY_LOW:
                density = "ldpi";
                break;
            case DisplayMetrics.DENSITY_MEDIUM:
                density = "mdpi";
                break;
            case DisplayMetrics.DENSITY_HIGH:
                density = "hdpi";
                break;
            case DisplayMetrics.DENSITY_XHIGH:
                density = "xhdpi";
                break;
            case DisplayMetrics.DENSITY_XXHIGH:
                density = "xxhdpi";
                break;
            case DisplayMetrics.DENSITY_XXXHIGH:
                density = "xxxhdpi";
                break;
            default:
                break;
        }
        return density;
    }

    /**
     * Handles unwanted &lt;br&gt; &amplt; &ampgt; HTML characters
     *
     * @param message Incoming message
     * @return Sanitized message
     */
    public static String handleSpecialHtmlCharacters(String message) {
        return message.replaceAll("<br/>([^.]*?)", "\n").replaceAll("<br>([^.]*?)", "\n")
                .replaceAll("&lt;([^.]*?)", "<").replaceAll("&gt;([^.]*?)", ">").replaceAll("&amp;([^.]*?)", "&")
                .replace("&nbsp;([^.]*?)", " ");
    }

    @SuppressLint("DefaultLocale")
    public static String ucWords(String textString) {
        return String.valueOf(textString.charAt(0)).toUpperCase() + textString.substring(1);
    }

    public static String handleLink(String message) {
        Document doc = Jsoup.parseBodyFragment(message);
        Elements anchorTag = doc.select(StaticMembers.ANCHOR_TAG);
        for (Element link : anchorTag) {
            String temp = link.attr(StaticMembers.HREF);
            if (!TextUtils.isEmpty(temp)) {
                message = message.replace(link.toString(), temp);
            }
        }
        return message;
    }

    public static void translateMessage(String message, final VolleyAjaxCallbacks volleyAjaxCallbacks) {
        String goolgeTranslateURL;
        try {

            goolgeTranslateURL = URLFactory.getGoogleTranslateURL() + "?key="
                    + JsonPhp.getInstance().getConfig().getRttKey() + "&q=" + URLEncoder.encode(message, "utf-8")
                    + "&target=" + PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
        } catch (Exception e1) {
            e1.printStackTrace();
            goolgeTranslateURL = URLFactory.getGoogleTranslateURL() + "?key=AIzaSyCrgExNrv4-O6JKMwEFdBp5XrIoCyw3UJw&q="
                    + message + "&target=" + PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
        }

        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), goolgeTranslateURL,
                new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            // Logger.error("translate successCallback: " +
                            // response);
                            JSONObject translatedObject = new JSONObject(response);
                            String translatedText = translatedObject.getJSONObject("data").getJSONArray("translations")
                                    .getJSONObject(0).getString("translatedText");
                            volleyAjaxCallbacks.successCallback(translatedText);
                        } catch (Exception e) {
                            volleyAjaxCallbacks.failCallback(response, false);
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        volleyAjaxCallbacks.failCallback(response, isNoInternet);
                    }
                });
        vHelper.setRequestType(Method.GET);
        vHelper.sendAjax();
    }

    public static void allowHttpsConnection() {
        try {
            TrustManager[] trustAllCerts = new TrustManager[]{new X509TrustManager() {
                public X509Certificate[] getAcceptedIssuers() {
                    X509Certificate[] myTrustedAnchors = new X509Certificate[0];
                    return myTrustedAnchors;
                }

                @Override
                public void checkClientTrusted(X509Certificate[] certs, String authType) {
                }

                @Override
                public void checkServerTrusted(X509Certificate[] certs, String authType) {
                }
            }};

            SSLContext sc = SSLContext.getInstance("SSL");
            sc.init(null, trustAllCerts, new SecureRandom());
            HttpsURLConnection.setDefaultSSLSocketFactory(sc.getSocketFactory());
            HttpsURLConnection.setDefaultHostnameVerifier(new HostnameVerifier() {
                @Override
                public boolean verify(String arg0, SSLSession arg1) {
                    return true;
                }
            });
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String processAvatarUrl(String avatarUrl) {
        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
            if (avatarUrl.contains("graph.facebook.com")) {
                avatarUrl = URLFactory.PROTOCOL_PREFIX_SECURE + avatarUrl;
            } else if (avatarUrl.startsWith("//")) {
                avatarUrl = URLFactory.PROTOCOL_PREFIX + avatarUrl;
            }
        } else if (!avatarUrl.startsWith(URLFactory.PROTOCOL_PREFIX)
                && !avatarUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
            if (avatarUrl.contains("graph.facebook.com")) {
                avatarUrl = URLFactory.PROTOCOL_PREFIX_SECURE + avatarUrl;
            } else {
                if (avatarUrl.startsWith("//")) {
                    avatarUrl = URLFactory.PROTOCOL_PREFIX + avatarUrl;
                } else {
                    avatarUrl = URLFactory.getWebsiteURL() + avatarUrl;
                }
            }
        }

        if (avatarUrl.contains("////")) {
            avatarUrl = avatarUrl.replace("////", "//");
        }
        return avatarUrl;
    }

    public static String getTypingStartMessage() {
        Long time = System.currentTimeMillis();
        return "{\"from\":" + SessionData.getInstance().getId() + ",\"sent\":" + time + ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"typingTo\\\",\\\"params\\\":{\\\"fromid\\\":" + SessionData.getInstance().getId() + ",\\\"typingtime\\\":" + time + "}}\"}";
    }

    public static String getTypingStopMessage() {
        Long time = System.currentTimeMillis();
        return "{\"from\":" + SessionData.getInstance().getId() + ",\"sent\":" + time + ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"typingStop\\\",\\\"params\\\":{\\\"fromid\\\":" + SessionData.getInstance().getId() + ",\\\"typingtime\\\":" + time + "}}\"}";
    }

    public static String getDeliveredTickMessage(String messageID) {
        return "{\"from\":" + SessionData.getInstance().getId() + ",\"sent\":" + System.currentTimeMillis() + ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"deliveredMessageNotify\\\",\\\"params\\\":{\\\"fromid\\\":" + SessionData.getInstance().getId() + ",\\\"message\\\":" + messageID + "}}\"}";
    }

    public static String getReadTickMessage(String messageID) {
        return "{\"from\":" + SessionData.getInstance().getId() + ",\"sent\":" + System.currentTimeMillis() + ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"readMessageNotify\\\",\\\"params\\\":{\\\"fromid\\\":" + SessionData.getInstance().getId() + ",\\\"message\\\":" + messageID + "}}\"}";
    }

    public static int getVersionCode(String versionCode) {
        versionCode = versionCode.replace(".", "");
        return Integer.parseInt(versionCode);
    }

    public static Boolean checkImageType(String type) {
        Boolean bool = false;
        if (type.equals("image/*") || type.equals("image/jpeg") || type.equals("image/jpg") || type.equals("image/png")) {
            bool = true;
        }
        return bool;
    }

    public static Boolean checkVideoType(String type) {
        Boolean bool = false;
        if (type.equals("video/*") || type.equals("video/mpeg") || type.equals("video/flv") || type.equals("video/webm") || type.equals("video/wmv") || type.equals("video/3gp") || type.equals("video/3gpp") || type.equals("video/mp4")) {
            bool = true;
        }
        return bool;
    }

    public static Boolean checkAudioType(String type) {
        Boolean bool = false;
        if (type.equals("audio/*") || type.equals("audio/mp3") || type.equals("audio/ogg") || type.equals("audio/wma") || type.equals("audio/wav") || type.equals("audio/aac") || type.equals("audio/mpeg")) {
            bool = true;
        }
        return bool;
    }

    public static JSONObject createErrorJson(String errorCode, String description) {
        JSONObject json = new JSONObject();
        try {
            json.put("code", errorCode);
            json.put("message", description);
            return json;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return json;
    }

    public static void sendCallBackError(String errorCode, String description, SubscribeCallbacks callback) {
        JSONObject json = new JSONObject();
        try {
            json.put(errorCode, description);
        } catch (Exception e) {
            e.printStackTrace();
        }
        callback.onError(json);
    }

    public static void sendCallBackError(String status, String description, SubscribeChatroomCallbacks callback) {
        JSONObject json = new JSONObject();
        try {
            json.put(status, description);
        } catch (Exception e) {
            e.printStackTrace();
        }
        callback.onError(json);
    }

    public static void performChatlogin(final Context context, final String username, final String password, final Callbacks callback, final int attempt) {

        VolleyAjaxCallbacks callbacks = new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Logger.error("Login resp: " + response + "|");
                    JSONObject version = new JSONObject(response);
                    if (version.has("version")) {
                        String versionCode = version.getString("version");
                        PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, versionCode);
                    }
                    Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                    if (htmlPattern.matcher(response).matches()) {
                        failCallback(response, false);
                    } else if (CommonUtils.isJSONValid(response)) {

                        try {
                            String baseData = version.getString(CometChatKeys.AjaxKeys.BASE_DATA);

                            if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                                SessionData.getInstance().setBaseData(baseData);
                                if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL)
                                        && !PreferenceHelper.get(PreferenceKeys.LoginKeys.OLD_LOGIN_URL).equalsIgnoreCase(
                                        URLFactory.getLoginURL())) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
                                }

                                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                                callback.successCallback(new JSONObject().put("success","login successful"));
                            } else {
                                JSONObject abc = new JSONObject();
                                abc.put(CometChatKeys.ErrorKeys.CODE_INVALID_URL, CometChatKeys.ErrorKeys.MESSAGE_INVALID_URL);
                                callback.failCallback(abc);
                            }
                        } catch (Exception e1) {
                            e1.printStackTrace();
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                try {
                    if (isNoInternet) {
                        JSONObject abc = new JSONObject();
                        abc.put(CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION, CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION);
                        callback.failCallback(abc);
                    } else {
                        if (attempt == 1) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);

                            performChatlogin(context, username, password, callback, 2);
                        } else if (attempt == 2) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);

                            performChatlogin(context, username, password, callback, 3);
                        } else if (attempt == 3) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);

                            performChatlogin(context, username, password, callback, 4);
                        } else if (attempt == 4) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_5);

                            performChatlogin(context, username, password, callback, 5);
                        } else {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };

        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL))

        {
            PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
        }


        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getLoginURL(), callbacks);
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, username);
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, password);
        vHelper.sendAjax();
    }


    public static void performChatlogin(final Context context, final String username, final String password, final LoginCallbacks callback, final int attempt) {

        VolleyAjaxCallbacks callbacks = new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Logger.error("Login resp: " + response + "|");
                    JSONObject version = new JSONObject(response);
                    if (version.has("version")) {
                        String versionCode = version.getString("version");
                        PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, versionCode);
                    }
                    Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                    if (htmlPattern.matcher(response).matches()) {
                        failCallback(response, false);
                    } else if (CommonUtils.isJSONValid(response)) {

                        try {
                            String baseData = version.getString(CometChatKeys.AjaxKeys.BASE_DATA);

                            if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                                SessionData.getInstance().setBaseData(baseData);
                                if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL)
                                        && !PreferenceHelper.get(PreferenceKeys.LoginKeys.OLD_LOGIN_URL).equalsIgnoreCase(
                                        URLFactory.getLoginURL())) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
                                }

                                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                                callback.successCallback(new JSONObject().put("success","login successful"));
                                HeartbeatOneOnOne heartbeatOneOnOne = HeartbeatOneOnOne.getInstance(callback);
                                HeartbeatChatroom heartbeatChatroom = HeartbeatChatroom.getInstance(callback);

                            } else {
                                JSONObject abc = new JSONObject();
                                abc.put(CometChatKeys.ErrorKeys.CODE_INVALID_URL, CometChatKeys.ErrorKeys.MESSAGE_INVALID_URL);
                                callback.failCallback(abc);
                            }
                        } catch (Exception e1) {
                            e1.printStackTrace();
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                try {
                    if (isNoInternet) {
                        JSONObject abc = new JSONObject();
                        abc.put(CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION, CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION);
                        callback.failCallback(abc);
                    } else {
                        if (attempt == 1) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);

                            performChatlogin(context, username, password, callback, 2);
                        } else if (attempt == 2) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);

                            performChatlogin(context, username, password, callback, 3);
                        } else if (attempt == 3) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);

                            performChatlogin(context, username, password, callback, 4);
                        } else if (attempt == 4) {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_5);

                            performChatlogin(context, username, password, callback, 5);
                        } else {
                            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                    StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };

        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL))

        {
            PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
        }


        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getLoginURL(), callbacks);
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, username);
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, password);
        vHelper.sendAjax();
    }


    public static void renderHtmlInATextView(final Context context , TextView textView , String message) {
        textView.setLinksClickable(true);
        textView.setMovementMethod(LinkMovementMethod.getInstance());

        Document doc = Jsoup.parseBodyFragment(message);
        Elements anchorTag = doc.select(StaticMembers.ANCHOR_TAG);
        final HashMap<String,String> linkmap = new HashMap<String,String>();
        for (Element link : anchorTag) {
            String temp = link.attr(StaticMembers.HREF).replace("\\","").replaceAll("\"","");
            linkmap.put(link.text().trim(),temp.replace("\\","").replaceAll("\"","").trim());
        }

        //replaces all the < and > signs in the html
        String replaceHtml = message
                .replaceAll("&lt;", "<")
                .replaceAll("&gt;", ">");

        Spanned span = Html.fromHtml(replaceHtml);
        final Spannable spannable = new SpannableString(span);

        textView.setText(spannable, TextView.BufferType.SPANNABLE);

        final ClickableSpan[] clickSpans = spannable.getSpans(0, span.length(), ClickableSpan.class);

        if (clickSpans != null) {
            for (int i = 0; i < clickSpans.length; i++) {
                ClickableSpan thisClickSpan = clickSpans[i];

                int start = spannable.getSpanStart(thisClickSpan);
                int end = spannable.getSpanEnd(thisClickSpan);
                int flags = spannable.getSpanFlags(thisClickSpan);

                final CharSequence clickText = textView.getText().subSequence(start, end);

                spannable.setSpan(new ClickableSpan() {
                    @Override
                    public void onClick(View view) {
                        Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(linkmap.get(clickText.toString().trim())));
                        context.startActivity(browserIntent);
                    }
                }, start, end, flags);
                spannable.removeSpan(clickSpans[i]);
            }
        }

        textView.setText(spannable, TextView.BufferType.SPANNABLE);
    }

    public static boolean isGreaterThanKitKat() {
        return Build.VERSION.SDK_INT > Build.VERSION_CODES.KITKAT_WATCH;
    }
}
