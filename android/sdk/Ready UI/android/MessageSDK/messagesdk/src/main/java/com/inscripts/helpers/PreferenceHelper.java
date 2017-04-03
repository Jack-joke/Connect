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
import com.inscripts.factories.URLFactory;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

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
        }

        removeKey(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS);

        removeKey(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH);
        removeKey(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH);
        removeKey(PreferenceKeys.HashKeys.BUDDY_LIST_HASH);

        removeKey(PreferenceKeys.LoginKeys.LOGGED_IN);
        removeKey(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER);

        removeKey(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID);
        removeKey(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID);
        removeKey(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
        removeKey(PreferenceKeys.DataKeys.ANN_BADGE_COUNT);
        removeKey(PreferenceKeys.UserKeys.STATUS);
        removeKey(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH);
    }

    /**
     * Fetch the latest settings from the admin panel and save them locally. Also downloads the header image for white-labelled apps.
     */
    public static void searchJsonPhp(final CometchatCallbacks callbacks) {
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getJsonPhpURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                if (response.length() > 0) {
                    try {
                        try {
                            response = response.substring(response.indexOf("{")).trim();
                            new JSONObject(response);
                            if(response.equals("{\"no_change\":\"1\"}")){
                                if (contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                                    Gson gson = new Gson();
                                    JsonPhp.setInstance(gson.fromJson(get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
                                }
                            } else {
                                save(PreferenceKeys.DataKeys.JSON_PHP_DATA, response);
                                Gson gson = new Gson();
                                JsonPhp.setInstance(gson.fromJson(response, JsonPhp.class));
                                save(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH, JsonPhp.getInstance().getResponseHash());
                            }
                            callbacks.successCallback();
                            attempt = 1;
                            return;
                        } catch (Exception e) {
                            e.printStackTrace();
                            failCallback(response, false);
                        }
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
                switch (attempt) {
                    case 1:
                        attempt = 2;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);
                        searchJsonPhp(callbacks);
                        break;
                    case 2:
                        attempt = 3;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);
                        searchJsonPhp(callbacks);
                        break;
                    case 3:
                        attempt = 4;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);
                        searchJsonPhp(callbacks);
                        break;
                    case 4:
                        attempt = 5;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_4);
                        searchJsonPhp(callbacks);
                        break;
                    case 5:
                        attempt = 6;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_5);
                        searchJsonPhp(callbacks);
                        break;
                    default:
                        attempt = 1;
                        save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                        callbacks.failCallback();
                        break;
                }

                // Fallback to previous json.php
                if (contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                    Gson gson = new Gson();
                    JsonPhp.setInstance(gson.fromJson(get(PreferenceKeys.DataKeys.JSON_PHP_DATA), JsonPhp.class));
                }
            }
        });
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.DEVICE_TYPE, CommonUtils.getScreenType(context));
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.JSON_RESPONSE_HASH,get(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH));
        assert PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE_DATA) != null;
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.LANG_COOKIE,PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE_DATA));
        vHelper.sendAjax();
    }
}