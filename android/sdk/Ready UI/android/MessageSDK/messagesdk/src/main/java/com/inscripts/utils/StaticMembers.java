/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

public class StaticMembers {

    /* Tag for loggers */
    static final String LOGGER_TAG = "CC^LOGS";

    /* Response codes for AJAX calls */
    public static final int AJAX_SUCCESS = 200;
    public static final int AJAX_FAIL = 404;

    /* Label for Profile page */
    public static final String TOP_FRAGMENT_ONE_ON_ONE = "1";

    public static final String TOP_FRAGMENT_CHATROOM = "2";

    public static final String TOP_FRAGMENT_ANNOUNCEMENT = "3";

    //public static final String TOP_FRAGMENT_ANNOUNCEMENT_RESET = "0";

    public static final String INTENT_ROOM_NAME = "ROOM_NAME";

    public static final String INTENT_VIDEO_FLAG = "VIDEO";

    public static final String INTENT_AUDIO_FLAG = "AUDIO";

    public static final String INTENT_AVBROADCAST_FLAG = "avbroadcast";

    public static final String INTENT_CR_AUDIO_CONFERENCE_FLAG = "CR_AUDIO";

    public static final String POSITIVE_TITLE = "Yes";

    public static final String NEGATIVE_TITLE = "No";
    public static final String ATTRIBUTE_TITLE = "title";

    public static final String ME_TEXT = "Me";

    public static final int CHOOSE_IMAGE_REQUEST_ONE_ON_ONE = 1;

    public static final int CHOOSE_IMAGE_REQUEST_CHATROOM = 2;

    public static final int CAPTURE_PHOTO_REQUEST_ONE_ON_ONE = 3;

    public static final int CAPTURE_PHOTO_REQUEST_CHATROOM = 4;

    public static final int CHOOSE_VIDEO_REQUEST_ONE_ON_ONE = 5;

    public static final int CAPTURE_VIDEO_REQUEST_ONE_ON_ONE = 1337;

    public static final int CHOOSE_VIDEO_REQUEST_CHATROOM = 7;

    public static final int CAPTURE_VIDEO_REQUEST_CHATROOM = 8;

    public static final String COMETCHAT_LOGINURL_SUFFIX_0 = "";

    public static final String COMETCHAT_LOGINURL_SUFFIX_1 = "cometchat/";

    public static final String COMETCHAT_LOGINURL_SUFFIX_2 = "chat/";

    public static final String COMETCHAT_LOGINURL_SUFFIX_3 = "plugins/cometchat/";

    public static final String COMETCHAT_LOGINURL_SUFFIX_4 = "plugins/chat/";

    public static final String COMETCHAT_LOGINURL_SUFFIX_5 = "apps/cometchat/cometchat/";

    public static final String IMAGE_MESSAGE_CSS_CLASS = "file_image";

    public static final String VIDEO_MESSAGE_CSS_CLASS = "file_video";

    public static final String AUDIO_MESSAGE_CSS_CLASS = "file_audio";

    public static final String PLEASE_CHECK_YOUR_INTERNET = "Please check your internet connection";

    public static final String UTF_8 = "UTF-8";

    public static final String PERMANENT_MENU_KEY = "sHasPermanentMenuKey";

    public static final String IMAGE_TYPE = "image/*";

    public static final String REQUEST = "request";

    public static final String ANCHOR_TAG = "a";

    public static final String HREF = "href";

    //public static final String NO_WALLPAPER_TEXT = "No Wallpaper";

    //public static final String DEFAULT_WALLPAPER_TEXT = "Document";

    //public static final String APP_WALLPAPER_TEXT = "Presets";

    public static final String FILE_PREFIX = "&unencryptedfilename=";

    public static final String ONE_ON_ONE_TAB_TEXT = "CONTACTS";

    public static final String CHATROOM_TAB_TEXT = "GROUPS";

    public static final String RECENTS_TAB_TEXT = "RECENTS";

    public static final String BOT_TAB_TEXT = "BOTS";

    public static final String INTENT_CHATROOM_ID = "INTENT_CHATROOM_ID";

    public static final String INTENT_IAMBROADCASTER_FLAG = "iam_broadcaster";

    public static final String CHATROOMMODE = "CHATROOMMODE";

    //public static final int INVITE_USERS = 1;

    //public static final int LOGOUT = 0;

    public static final String CALL_FROM = "Call from ";

    public static final String CALL_TO = "Call to ";

    public static final int MEDIA_TYPE_IMAGE = 1;

    public static final int MEDIA_TYPE_VIDEO = 2;

    public static final String REJECTCALL_ACTION = "rejectcall";

    public static final String ENDCALL_ACTION = "endcall";

    public static final String CALL_ENDED_MESSAGE = "Call ended, duration ";

    public static final String CALL_REJECTED_MESSAGE = " rejected";

    public static final String NO_ANSWER_ACTION = "noanswer";

    public static final String COMETCHAT_DARK_GREEN = "#002832";

    public static final String NO_CHATROOM_TEXT = "No chatrooms avaliable.";

    public static final String NO_BUDDY_TEXT = "No users online at the moment.";

    public static final String INTENT_IMAGE_PREVIEW_MESSAGE = "INTENT_IMAGE_MESSAGE";

    public static final String INTENT_CHATROOM_NAME = "INTENT_CHATROOM_NAME";

    public static final String IMAGE_TAG = "img";

    public static final String ATTRIBUTE_SRC = "src";

    //public static final String ATTRIBUTE_TITLE = "title";

    public static final String NO_ANSWER_MESSAGE = "No answer from ";

    public static final String VIDEO_TYPE = "video/*";

    public static final String SETTINGS = "Settings";

    public static final String SAMSUNG = "samsung";

    public static final String XIAOMI = "xiaomi";

    public static final String CANCEL_OUTGOING_CALL_ACTION = "canceloutgoingcall";

    public static final String CALL_CANCELLED_MESSAGE = " cancelled";

    public static final String BUSY_CALL_ACTION = "busycall";

    public static final String CALL_BUSY_MESSAGE = " busy";

    public static final String SPAN_TAG = "span";

    public static final String DEFAULT_TEXT_COLOR = "#000000";

    public static final String MY_DEFAULT_TEXT_COLOR = "#FFFFFF";

    public static final String STYLE_ATTR = "style";

    public static final String APP_ICON_NAME_FOR_WHITE_LABEL = "cc_logo.png";

    public static final String FILETRANSFER_KEY = "plugins/filetransfer";

    public static final String IMAGE_MESSAGE_CLASS = "imagemessage";

    public static final String HOME_TAB_TEXT = "Home";

    public static final String ANNOUNCEMENT_TAB_TEXT = "Announcement";

    public static final String NO_ANNOUNCEMENT_TEXT = "There are no announcements at the moment.";

    public static final String BLOCK_USER_WARNING_TEXT = "Are you sure you want to block this user?";

    public static final String ERROR_BLOCKING_USER = "Error while blocking error";
    public static final String RANDOM = "random";
    public static final String ERROR_UNBLOCKING_USER = "Error while unblocking error";
    public static final String TWITTER_LOGIN_ERROR = "Couldn't login to Twitter.";
    public static final String FACEBOOK_LOGIN_ERROR = "Couldn't login to Facebook.";
    public static final String GMAIL_LOGIN_ERROR = "Couldn't login to Gmail.";
    public static final String DOMAIN_ERROR = "Unable to connect to domain. Please contact us at support@cometchat.com for more information.";
    public static final String SCREENSHARE_MODE = "screenshare_mode";


    public static class JsonPhpLangs {
        public static final String EMPTY_PASSWORD_ERROR_MESSAGE = "Please enter a password";
        public static final String EMPTY_USERNAME_ERROR_MESSAGE = "Username cannot be blank";
        public static final String INVALID_URL_MESSAGE = "CometChat was not found on this website. Please check the URL.";
        public static final String WRONG_USERNAME_MESSAGE = "Check your username";
        public static final String WRONG_PASSWORD_MESSAGE = "Check your password";
        public static final String WRONG_URL = "Please check the URL";
        public static final String VERSION_UPGRADE_REQUIRED = "CometChat needs to be upgraded on the site to use this app. In the meanwhile, you can download our Legacy App which is compatible with the version on this site.";
    }

}
