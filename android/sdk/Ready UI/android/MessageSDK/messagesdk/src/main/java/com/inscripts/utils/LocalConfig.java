/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.content.Context;
import android.text.TextUtils;

import java.io.InputStream;
import java.util.Properties;

public class LocalConfig {

    /* Base URL for white labeling. Keep empty for default app. */
    public static final String DEMO_SITE_URL = "https://chat.phpchatsoftware.com";

    /*
     * Set 1 for username/password login, 2 for phone number login, 3 for phone
     * number with email login, 4 for having create cc_profile on register button
     */
    @Deprecated
    public static final int LOGIN_TYPE = 1;

    /* Values in milliseconds */
    public static final int SPLASH_TIMEOUT = 2000;
    public static final long INCOMING_CALL_TIMEOUT = 50000;
    public static final long OUTGOING_CALL_TIMEOUT = 55000;
    public static final long SCROLL_BUTTON_TIMEOUT = 3000;

    private LocalConfig() {
    }

    private static Properties properties;

    public static void initialize(Context context) {
        try {
            InputStream inputStream = context.getAssets().open("config.properties");
            properties = new Properties();
            properties.load(inputStream);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String getString(String key) {
        try {
            return properties.getProperty(key, null);
        } catch (Exception e) {
            return null;
        }
    }

    public static boolean isWhiteLabelled() {
        return !TextUtils.isEmpty(getSiteUrl());
    }

    public static String getSplashBackgroundColor() {
        return getString("SPLASH_BG");
    }

    public static String getSiteUrl() {
        return getString("SITE_URL");
    }

    public static String getUserRegistrationLink() {
        return getString("USER_REGISTRATION_LINK");
    }

    public static String getFacebookAppId() {
        return getString("FACEBOOK_APP_ID");
    }

    public static String getTwitterKey() {
        return getString("TWITTER_KEY");
    }

    public static String getTwitterSecret() {
        return getString("TWITTER_SECRET");
    }

    public static String getParseAppId() {
        return getString("PARSE_APP_ID");
    }

    public static String getParseClientKey() {
        return getString("PARSE_CLIENT_KEY");
    }

    public static String getIsCOD() {
        return getString("IS_COD");
    }

    public static long getFileUploadLimit() {
        return Long.parseLong(getString("FILE_UPLOAD_LIMIT"));
    }

    public static String getMessageLimit() {
        return getString("MESSAGE_LIMIT");
    }

    public static String getDefaultInviteMessage() {
        return getString("DEFAULT_INVITE_MESSAGE");
    }
}