/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.keys;

public class BroadcastReceiverKeys {

    /**
     * Keys to send broadcast when list contents are updated
     */
    public static class ListUpdatationKeys {
        public static final String REFRESH_FULL_CHATROOM_LIST_FRAGMENT = "REFRESH_FULL_CHATROOM_LIST_FRAGMENT";
        public static final String REFRESH_BUDDY_LIST_FRAGMENT = "REFRESH_FULL_BUDDY_LIST_FRAGMENT";
        public static final String REFRESH_ANNOUNCEMENT_LIST = "REFRESH_ANNOUNCEMENT_LIST";
        public static final String REFRESH_ANNOUNCEMENT_BADGE = "REFRESH_ANNOUNCEMENT_BADGE";
        public static final String REFRESH_CHATROOM_MEMBERS = "REFRESH_CHATROOM_MEMBERS";
        public static final String REFRESH_USER_STATUS = "REFRESH_USER_STATUS";
        public static final String REFRESH_BOT_LIST_FRAGMENT = "REFRESH_BOT_LIST_FRAGMENT";
        public static final String REFRESH_RECENT_FRAGMENT = "REFRESH_RECENT_FRAGMENT";
    }

    /**
     * Keys to send broadcast when messages are updated
     */
    public static class NewMessageKeys {
        public static final String EVENT_NEW_MESSAGE_ONE_ON_ONE = "EVENT_NEW_MESSAGE_ONE_ON_ONE";
        public static final String EVENT_NEW_MESSAGE_CHATROOM = "EVENT_NEW_MESSAGE_CHATROOM";
    }

    /**
     * Keys to send broadcast when releated to heartbeat updatation
     */
    public static class HeartbeatKeys {
        public static final String ONE_ON_ONE_HEARTBEAT_NOTIFICATION = "ONE_ON_ONE_HEARTBEAT_UPDATAION";
        public static final String CHATROOM_HEARTBEAT_UPDATAION = "CHATROOM_HEARTBEAT_UPDATAION";
        public static final String ANNOUNCEMENT_UPDATATION = "ANNOUNCEMENT_UPDATATION";
        public static final String ANNOUNCEMENT_BADGE_UPDATION = "ANNOUNCEMENT_BADGE_UPDATION";
    }

    /**
     * Keys to send broadcast releated to AVchat
     */
    public static class AvchatKeys {
        public static final String EVENT_AVCHAT_ACCEPTED = "CALL_ACCEPTED";
        public static final String AVCHAT_CALLER_ID = "CALLER_ID";
    }

    /**
     * Keys used to send extra parameters with intent to send broadcast
     */
    public static class IntentExtrasKeys {
        public static final String NEW_MESSAGE = "NEW_MESSAGE";
        public static final String NEW_MESSAGE_DATA = "NEW_MESSAGE_DATA";
        public static final String NEW_CHATROOM_MESSAGE = "NEW_CHATROOM_MESSAGE";
        public static final String IMAGE_SENDING = "IMAGE_SENDING";
        public static final String UNSUPPORTED_SMILEY_DOWNLOADED = "UNSUPPORTED_SMILEY_DOWNLOADED";
        public static final String VIDEO_SENDING = "VIDEO_SENDING";
        public static final String TEMP_ID = "TEMP_ID";
        public static final String SELECTED_COUNTRY_CODE = "SELECTED_COUNTRY_CODE";
        public static final String SELECTED_COUNTRY_NAME = "SELECTED_COUNTRY_NAME";
        public static final String BUDDY_ID = "BUDDY_ID";
        public static final String BUDDY_NAME = "BUDDY_NAME";
        public static final String BUDDY_AVATAR = "BUDDY_AVATAR";
        public static final String VERFICATION_STATUS_CASE_TWO = "VERFICATION_STATUS_CASE_TWO";
        //public static final String COD_URL = "COD_URL";
        public static final String COD_CODE = "COD_CODE";
        public static final String OPEN_SETTINGS = "OPEN_SETTINGS";
        public static final String SUBTITLE_CHANGE = "SUBTITLE_CHANGE";
        public static final String TYPING_START = "TYPING_START";
        public static final String TYPING_STOP = "TYPING_STOP";
        public static final String MESSAGE_READ = "MESSAGE_READ";
        public static final String MESSAGE_DELIVERED = "MESSAGE_DELIVERED";
        public static final String MESSAGE_TICK = "MESSAGE_TICK";
        public static final String REFRESH_LASTSEEN = "REFRESH_LASTSEEN";
        public static final String ROOM_NAME = "ROOM_NAME";
        public static final String USER_STATUS = "USER_STATUS";
        public static final String RANDOMID = "randomId";
        public static final String CHATROOM_ID = "CHATROOM_ID";
        public static final String REFRESH_UNSEND_MESSAGES = "REFRESH_UNSEND_MESSAGES";
    }
}
