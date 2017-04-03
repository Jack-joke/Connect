/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.text.TextUtils;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.HeaderImage;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.util.Set;

public class PreferenceHelper {

    private static int attempt = 1;

    private static Context context = null;
    private static SharedPreferences preferences;
    private static SharedPreferences.Editor editor;

    public static Context getContext() {
        return context;
    }

    public static void initialize(Context con) {
        if (context == null) {
            context = con;
        }
        if (null == preferences) {
            preferences = PreferenceManager.getDefaultSharedPreferences(context);
        }
        if (null == editor) {
            editor = preferences.edit();
        }
    }

    public static void save(String key, String value) {
        editor.putString(key, value);
        editor.commit();
    }

    public static void save(String key, Integer value) {
        save(key, String.valueOf(value));
    }

    public static void save(String key, Set set) {
        editor.putStringSet(key, set);
        editor.commit();
    }
    public static Set getStringSet(String key) {
        return preferences.getStringSet(key, null);
    }

    public static void save(String key, Long value) {
        save(key, String.valueOf(value));
    }

    public static String get(String key) {
        return preferences.getString(key, null);
    }

/*    public static Set<String> getObjectSet(String key) {
        return preferences.getStringSet(key, null);
    }

    public static void setObjectSet(String key, Set<String> array) {
        editor.putStringSet(key, array);
        editor.commit();
    }*/

    public static Boolean contains(String key) {
        return preferences.contains(key);
    }

    public static void removeKey(String key) {
        editor.remove(key);
        editor.commit();
    }

    /**
     * Flush all user data from the preferences
     */
    public static void cleanUp() {
        if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
            /* Remove admin panel settings only if it's the stock app. */
            removeKey(PreferenceKeys.DataKeys.JSON_PHP_DATA);
            removeKey(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH);
        }

        removeKey(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS);

        removeKey(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH);
        removeKey(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH);
        removeKey(PreferenceKeys.HashKeys.BUDDY_LIST_HASH);
        removeKey(PreferenceKeys.HashKeys.BOT_LIST_HASH);
        removeKey(PreferenceKeys.LoginKeys.LOGGED_IN);
        removeKey(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER);

        removeKey(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID);
        removeKey(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID);
        removeKey(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
        removeKey(PreferenceKeys.DataKeys.ANN_BADGE_COUNT);
        removeKey(PreferenceKeys.UserKeys.STATUS);
        removeKey(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS);
    }

    /**
     * Fetch the latest settings from the admin panel and save them locally. Also downloads the header image for white-labelled apps.
     */
    public static void searchJsonPhp(final CometchatCallbacks callbacks) {
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getJsonPhpURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                Logger.error("PreferenceHelper : searchJsonPhp() : JsonPhpUrl : " + URLFactory.getJsonPhpURL());
                Logger.error("PreferenceHelper : searchJsonPhp() : Response : " + response);
                if (response.length() > 0) {
                    try {
//                        try {
                            response = response.substring(response.indexOf("{")).trim();
                            new JSONObject(response);
                            if(response.equals("{\"no_change\":\"1\"}") && contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)){
                                if (contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                                    Gson gson = new Gson();
                                    JsonPhp.setInstance(gson.fromJson(get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
                                }
                            } else {
                                if (CommonUtils.isValidJson(response)) {
                                    save(PreferenceKeys.DataKeys.JSON_PHP_DATA, response);
                                    Gson gson = new Gson();
                                    JsonPhp.setInstance(gson.fromJson(response, JsonPhp.class));
                                    save(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH, JsonPhp.getInstance().getResponseHash());
                                } else {
                                    failCallback(response, false);
                                    return;
                                }
                            }
                            /*Gson gson = new Gson();
                            JsonPhp.setInstance(gson.fromJson(response, JsonPhp.class));*/
                            if (!TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
                                // Fetch header image for white labelled apps
                                HeaderImage headerImage = JsonPhp.getInstance().getHeaderImage();
                                if (null != headerImage) {
                                    LocalStorageFactory.saveAppLogo(new CometchatCallbacks() {

                                        @Override
                                        public void successCallback() {
                                            callbacks.successCallback();
                                            attempt = 1;
                                        }

                                        @Override
                                        public void failCallback() {
                                            callbacks.successCallback();
                                            attempt = 1;
                                        }
                                    });
                                } else {
                                    // Delete the image
                                    File f = new File(LocalStorageFactory.getAppLogoStoragePath() + StaticMembers.APP_ICON_NAME_FOR_WHITE_LABEL);
                                    if (f.exists()) {
                                        f.delete();
                                    }
                                    callbacks.successCallback();
                                    attempt = 1;
                                }
                            } else {
                                callbacks.successCallback();
                                attempt = 1;
                            }
//                        } catch (Exception e) {
//                            failCallback(response, false);
//                        }
                    // added catch to handle json exception and url attempting.
                    } catch (JsonSyntaxException | JSONException | IndexOutOfBoundsException ex) {
                        failCallback(response, false);
                    } catch (Exception e) {
                        Toast.makeText(context, "Error occured at initial settings", Toast.LENGTH_SHORT)
                                .show();

                        callbacks.failCallback();
                        attempt = 1;
                    }
                } else {
                    Toast.makeText(context, "Zero length of json.php", Toast.LENGTH_SHORT)
                            .show();
                    callbacks.failCallback();
                    attempt = 1;
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                // Attempt to find CometChat at different location
                boolean isDefaultCase = false;
                switch (attempt) {
                    case 1:
                        attempt = 2;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);
                        break;
                    case 2:
                        attempt = 3;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);
                        break;
                    case 3:
                        attempt = 4;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);
                        break;
                    case 4:
                        attempt = 5;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_4);
                        break;
                    case 5:
                        attempt = 6;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_5);
                        break;
                    case 6:
                        attempt = 7;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_6);
                        break;
                    case 7:
                        attempt = 8;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_7);
                        break;
                    case 8:
                        attempt = 9;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_8);
                        break;
                    default:
                        attempt = 1;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                        callbacks.failCallback();
                        isDefaultCase = true;
                        break;
                }
                if (!isDefaultCase) {
                    searchJsonPhp(callbacks);
                }

                // Fallback to previous json.php
                if (contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                    try {
                        Gson gson = new Gson();
                        JsonPhp.setInstance(gson.fromJson(get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
                    } catch (JsonSyntaxException ex) {
                        ex.printStackTrace();
                    }
                }
            }
        });
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.DEVICE_TYPE, CommonUtils.getScreenType(context));
        if (contains(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH)){
            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.JSON_RESPONSE_HASH,get(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH));
        }
        vHelper.sendAjax();
    }
}