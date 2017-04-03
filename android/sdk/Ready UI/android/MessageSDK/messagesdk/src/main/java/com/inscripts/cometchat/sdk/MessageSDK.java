/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.cometchat.sdk;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.text.TextUtils;

import com.google.gson.Gson;
import com.inscripts.activities.BlankActivity;
import com.inscripts.activities.CometChatActivity;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

public class MessageSDK {

    private static Context appcontext;
    private static boolean useComet = false;

    public static void launchCometChat(final Activity context, Callbacks callbacks) {
        PreferenceHelper.initialize(context);
        final boolean isLoggedIn = PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                && CometChatKeys.LoginKeys.USER_LOGGED_IN.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN));
        if (isLoggedIn) {
            if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
            }

            if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH)) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH, "");
            }

            Intent intent = new Intent(context, BlankActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
            context.startActivity(intent);


            new Thread(new Runnable() {
                @Override
                public void run() {
                    PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {
                        @Override
                        public void successCallback() {
                            try {
                                Thread.sleep(100);
                                BlankActivity.stopWheel();
                                Intent intent = new Intent(context, CometChatActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                context.startActivity(intent);
                            } catch (Exception e) {

                            }
                        }

                        @Override
                        public void failCallback() {
                            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                                try {
                                    Thread.sleep(100);
                                    Gson gson = new Gson();
                                    JsonPhp.setInstance(gson.fromJson(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
                                    BlankActivity.stopWheel();
                                    Intent intent = new Intent(context, CometChatActivity.class);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                                    context.startActivity(intent);
                                } catch (Exception e) {

                                }
                            }
                        }
                    });
                }
            }).start();
        } else {
            try {
                BlankActivity.stopWheel();
                callbacks.failCallback(new JSONObject().put(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN, CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
            } catch (Exception e) {

            }
        }
    }

    public static void initializeCometChat(Context context) {
        if (null != context) {
            appcontext = context;
        }

        PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {
            @Override
            public void successCallback() {
                SessionData sessionData = SessionData.getInstance();
                Config config = JsonPhp.getInstance().getConfig();
                Logger.error("Search Json Responce ...");
                boolean useComet = config.getUSECOMET().equals("1");
                long minHeartbeat = Long.parseLong(config.getMinHeartbeat());
                Long interval = 0L;
                sessionData.setInitialHeartbeat(true);
                sessionData.setActiveAVchatUserID("0");
                sessionData.setAvchatCallRunning(false);
                sessionData.setAvChatRoomName("");

                if (useComet) {
                    interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                    sessionData.setOneOnOneHeartbeatInterval(interval);
                } else {
                    interval = Long.parseLong(config.getMinHeartbeat());
                    sessionData.setOneOnOneHeartbeatInterval(interval);
                }
                if(HeartbeatOneOnOne.getInstance()==null) {
                    HeartbeatOneOnOne.getInstance().startHeartbeat(appcontext);
                }
            }

            @Override
            public void failCallback() {

            }
        });
    }

    public static void login(Context context, String username, String password, LoginCallbacks callbacks) throws IllegalArgumentException {

        if (TextUtils.isEmpty(username)) {
            throw new IllegalArgumentException("Username can not be empty or null");
        } else {
            if (TextUtils.isEmpty(password)) {
                throw new IllegalArgumentException("Password can not be empty or null");
            } else {
                if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                    PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
                    SessionData.getInstance().setBaseData("");
                }
                CommonUtils.performChatlogin(context, username, password, callbacks, 1);
            }
        }


    }

    public static void login(Context context, String userid, LoginCallbacks callbacks) throws IllegalArgumentException {
        if (TextUtils.isEmpty(userid)) {
            throw new IllegalArgumentException("userid can not be empty or null");
        } else {
            if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
                SessionData.getInstance().setBaseData("");
            }
            CommonUtils.performChatlogin(context, userid, "cometchat", callbacks, 1);
        }
    }


    public static void launchChatWindow(final boolean withUserlist, final Activity context, final String userid, final Callbacks callbacks) {
        PreferenceHelper.initialize(context);
        final boolean isLoggedIn = PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                && CometChatKeys.LoginKeys.USER_LOGGED_IN.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN));
        if (isLoggedIn) {

            Intent intent1 = new Intent(context, BlankActivity.class);
            intent1.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            intent1.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
            context.startActivity(intent1);


            if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
            }

            if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH)) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH, "");
            }

            new Thread(new Runnable() {
                @Override
                public void run() {
                    try {
                        Thread.sleep(200);
                        MessageSDK.initializeCometChat(context);
                        Buddy buddy = Buddy.getBuddyDetails(userid);
                        final Intent intent = new Intent(context, CometChatActivity.class);
                        if (withUserlist) {
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT, "0");
                        } else {
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT, "1");
                        }
                        if (null == buddy) {

                            MessageHelper.getInstance().addNewBuddy(Long.parseLong(userid), context, new CometchatCallbacks() {
                                @Override
                                public void successCallback() {
                                    Buddy buddy = Buddy.getBuddyDetails(userid);
                                    if (null == buddy) {
                                        failCallback();
                                        BlankActivity.stopWheel();
                                    } else {
                                        BlankActivity.stopWheel();
                                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddy.buddyId);
                                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME, buddy.name);
                                        context.startActivity(intent);
                                        //context.overridePendingTransition(R.anim.slide_in_up, 0);
                                    }
                                }

                                @Override
                                public void failCallback() {
                                    BlankActivity.stopWheel();
                                    BlankActivity.blankActivity.finish();
                                }
                            }, callbacks);

                        } else {
                            BlankActivity.stopWheel();
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddy.buddyId);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME, buddy.name);
                            context.startActivity(intent);
                            //context.overridePendingTransition(R.anim.slide_in_up, 0);

                        }

                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }).start();


        } else {
            try {
                callbacks.failCallback(new JSONObject().put(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN, CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
            } catch (Exception e) {

            }
            BlankActivity.stopWheel();
        }
    }

    public static void setUrl(Context context, String siteurl, Callbacks callbacks) throws IllegalArgumentException {
        if (TextUtils.isEmpty(siteurl)) {
            throw new IllegalArgumentException("Site url can not be empty or null");
        } else {
            try {
                if (!siteurl.endsWith("/")) {
                    siteurl += "/";
                }

                // Check if url contains http:// or https://PreferenceHelper.initialize();
                if (!(siteurl.contains(URLFactory.PROTOCOL_PREFIX) || siteurl
                        .contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                    siteurl = URLFactory.PROTOCOL_PREFIX + siteurl;
                }
                PreferenceHelper.initialize(context);
                PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, siteurl);
                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);

                JSONObject obj = new JSONObject();
                obj.put("success", "Url set to " + siteurl);
                callbacks.successCallback(obj);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }


    public static void setLanguage(String lang){
        PreferenceHelper.save(PreferenceKeys.DataKeys.SELECTED_LANGUAGE_DATA,lang);
    }


    /**
     * Ends the current session and clears all the data.
     */
    public static void logout(Context context , final Callbacks callbacks) {
        if (isLoggedIn()) {

            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getLogoutURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    HeartbeatOneOnOne.getInstance((SubscribeCallbacks)null).stopHeartbeatOneOnOne();
                    HeartbeatChatroom.getInstance((SubscribeChatroomCallbacks) null).stopHeartbeatChatroom();

                    if (useComet) {
                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        CometserviceOneOnOne.getInstance().unSubscribe();
                        if (!TextUtils.isEmpty(transport)) {
                            if (transport.equals("cometservice")) {
                                CometserviceOneOnOne.getInstance().unSubscribe();
                            } else {
                                WebsyncOneOnOne.getInstance().unsubscribe();
                            }
                        }
                    }
                    PreferenceHelper.cleanUp();

                    try {
                        JSONObject json = new JSONObject();
                        json.put("message", "Logout successful");
                        callbacks.successCallback(json);
                    } catch (Exception e) {
                        e.printStackTrace();
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_RANDOM_EXCEPTION,
                                CometChatKeys.ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                    }
                }
            });
            vHelper.sendAjax();

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public static boolean isLoggedIn() {
        return (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN) && ("1".equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN))));
    }

   /* public static void setApiKey(Context context, String apikey)throws IllegalArgumentException {
        if (TextUtils.isEmpty(apikey)) {
            throw new IllegalArgumentException("api key can not be null or empty");
        } else {
            PreferenceHelper.initialize(context);
            PreferenceHelper.save(PreferenceKeys.DataKeys.API_KEY, apikey.trim());
            URLFactory.buildBaseCodUrl();
        }
    }*/
}
