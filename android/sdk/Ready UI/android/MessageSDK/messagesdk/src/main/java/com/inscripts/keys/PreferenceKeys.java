/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.keys;

public class PreferenceKeys {

    /**
     * Keys used to set preferences of Login details
     */
    public static class LoginKeys {

        /* ONLY FOR LOGINSCREEN */
        public static final String BASE_URL = "BASE_URL";
        public static final String LOGIN_NAME = "USERNAME";
        public static final String COMETCHAT_FOLDER = "COMETCHAT_FOLDER";
        public static final String LOGIN_PASSWORD = "PASSWORD";
        public static final String LOGGED_IN = "LOGGED_IN";
        public static final String REMEMBER_ME = "REMEMBER_ME";
        public static final String OLD_LOGIN_URL = "OLD_LOGIN_URL";
        public static final String CURRENT_PHONE = "CURRENT_PHONE";
        public static final String LOGGED_IN_AS_GUEST = "LOGGED_IN_AS_GUEST";
        public static final String LOGGED_IN_AS_DEMO = "LOGGED_IN_AS_DEMO";
        public static final String LOGGED_IN_AS_COD = "LOGGED_IN_AS_COD";
        public static final String INITIAL_URL = "INITIAL_URL";
        public static final String VERSION_CODE = "VERSION_CODE";
        public static final String VERSION_CODE_VALUE = "VERSION_CODE_VALUE";
        public static final String LOGIN_SITE_URL = "SDK_BASE_URL";
    }

    /**
     * Keys used to set preferences of data coming from initial Ajax call
     * requests
     */
    public static class DataKeys {
        public static final String BASE_DATA = "BASE_DATA";
        public static final String JSON_PHP_DATA = "JSON_PHP_DATA";
        public static final String JSON_CHATROOM_MEMBERS = "CHATROOM_MEMBERS";
        public static final String WALLPAPER_FILENAME = "WALLPAPER_FILENAME";
        public static final String SERVER_DIFFERENCE = "SERVER_DIFFERENCE";
        public static final String SHARE_IMAGE_URL = "SHARE_IMAGE_URL";
        public static final String SHARE_VIDEO_URL = "SHARE_VIDEO_URL";
        public static final String SHARE_AUDIO_URL = "SHARE_AUDIO_URL";
        public static final String SHARE_FILE_URL = "SHARE_FILE_URL";
        public static final String SELECTED_LANGUAGE_FULL = "SELECTED_LANGUAGE";
        public static final String LOAD_EARLIER_COUNT = "LOAD_EARLIER_COUNT";
        public static final String DEVELOPMENT_MODE = "SDK_DEVELOPMENT_MODE";
        public static final String SELECTED_LANGUAGE_DATA = "SELECTED_LANGUAGE_DATA";



        /**
         * Stores the current id to which you are chatting
         */
        public static final String ACTIVE_BUDDY_ID = "ACTIVE_BUDDY_ID";
        public static final String ACTIVE_AVCHAT_BUDDY_ID = "ACTIVE_AVCHAT_BUDDY_ID";
        public static final String ACTIVE_CHATROOM_ID = "ACTIVE_CHATROOM_ID";
        public static final String IS_TAB_WINDOW_OPEN = "TABS_OPEN";
        public static final String CURRENT_CHATROOM_ID = "CURRENT_CHATROOM_ID";
        public static final String CURRENT_CHATROOM_PASSWORD = "CURRENT_CHATROOM_PASSWORD";
        public static final String ANN_BADGE_COUNT = "ANN_BADGE_COUNT";
        public static final String SELECTED_LANGUAGE = "SELECTED_LANGUAGE_ONO";
        public static final String REGISTRATION_STATUS = "REGISTRATION_STATUS";
        public static final String TEMP_ID = "TEMP_ID";
        public static final String MY_PHONE_NUMBER = "MY_PHONE_NUMBER";
        public static final String USER_STATUS = "USER_STATUS";
        public static final String NOTIFICATION_STACK = "NOTIFICATION_STACK";
        public static final String COD_ID = "COD_ID";
        public static final String SAVED_STATUS = "SAVED_STATUS";
        public static final String CHATROOM_COMET_ID ="CHATROOM_COMET_ID" ;
        public static final String JSON_RESPONSE_HASH = "JSON_RESPONSE_HASH";
        public static final String EMOJI_KEYBOARD_HEIGHT = "EMOJI_KBD_HEIGHT";

        public static final String API_KEY = "COD_API_KEY";
        public static final String APP_INFO = "APP_INFO";
    }

    /**
     * Keys used to set preferences of Hashes
     */
    public static class HashKeys {
        public static final String CHATROOM_MEMBERS_HASH = "USER_LIST_HASH";
        public static final String CHATROOM_LIST_HASH = "CHATROOM_LIST_HASH";
        public static final String BUDDY_LIST_HASH = "BUDDY_LIST_HASH";
        public static final String APP_LOGO_TIMESTAMP = "APP_LOGO_TIMESTAMP";
        public static final String BOT_LIST_HASH = "BOT_LIST_HAST";
    }

    public static class UserKeys {
        public static final String USER_ID = "USER_ID";
        public static final String USER_NAME = "USER_NAME";
        public static final String USER_LINK = "USER_LINK";
        public static final String STATUS = "STATUS";
        public static final String STATUS_MESSAGE = "STATUS_MESSAGE";
        //public static final String AVATAR_LINK = "AVATAR_LINK";
        public static final String USER_PREVIOUS_NAME = "USER_PREVIOUS_NAME";
        public static final String USER_PREVIOUS_AVATAR = "USER_PREVIOUS_AVATAR";
        public static final String USER_EMAIL = "USER_EMAIL";
        public static final String SECOND_VERI_CODE = "SECOND_VERI_CODE";
        public static final String CHANGE_EMAIL = "CHANGE_EMAIL";
        public static final String WEBRTC_CHANNEL = "WEBRTC_CHANNEL";
        public static final String NOTIFICATION_ON = "NOTIFICATION_ON";
        public static final String READ_TICK = "READ_TICK_ON";
        public static final String NOTIFICATION_SOUND = "NOTIFICATION_SOUND";
        public static final String NOTIFICATION_VIBRATE = "NOTIFICATION_VIBRATE";
        public static final String LAST_SEEN_SETTING = "LAST_SEEN_SETTING";
        public static final String TYPING_SETTING = "TYPING_SETTING";
        public static final String VIDEO_FILE_NAME = "VIDEO_FILE_NAME";
    }

    public static class Colors{
        public static final String COLOR_PRIMARY = "PRIMARY_COLOR";
        public static final String COLOR_PRIMARY_DARK = "PRIMARY_COLOR_DARK";
        public static final String COLOR_CHATROOM_CHAT = "COLOR_CHATROOM_CHAT";
    }
}
