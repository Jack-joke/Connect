/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.keys;

public class CometChatKeys {

    /**
     * Used to set the keys used for sending Ajax calls
     */
    public static class AjaxKeys {
        public static final String CALLBACK_FN = "callbackfn";
        public static final String CALLBACK_FN_VALUE = "mobileapp";
        public static final String CALLBACK = "callback";
        public static final String INITIALIZE = "initialize";
        public static final String CHATROOM_INITIALIZE = "crinitialize";
        public static final String TIMESTAMP = "timestamp";
        public static final String CR_TIMESTAMP = "crtimestamp";
        public static final String BASE_DATA = "basedata";
        public static final String ACTION = "action";
        public static final String TO = "to";
        public static final String V = "v";
        public static final String LASTSEENSETTINGFLAG = "lastseenSettingsFlag";
        public static final String BUDDY_LIST_HASH = "blh";
        public static final String MESSAGE = "message";
        public static final String SENT = "sent";
        public static final String PLATFORM = "platform";
        public static final String ACTIVE_CHATWINDOW_ID = "activeChatboxIds";
        public static final String SENDERNAME = "sendername";
        public static final String CR_INITIALIZE = "crinitialize";
        public static final String GUEST_NAME = "guestname";
        public static final String LOCAL_ID = "localId";
        public static final String IMEI = "IMEI";


        /*
         * Used for comet-service as backward compatibility, to get the same
		 * reply as of without comet-service
		 */
        public static final String VERSION2 = "v2";
        public static final String VERSION3 = "v3";

        public static final String ID = "id";
        public static final String USERNAME = "username";
        public static final String PASSWORD = "password";
        public static final String MESSAGES = "messages";
        public static final String CHATROOM_MESSAGES = "crmessages";
        public static final String FROM = "from";
        public static final String USER_STATUS = "userstatus";
        public static final String COMETID = "cometid";
        public static final String OLD = "old";
        public static final String BUDDY_LIST = "buddylist";
        public static final String CHATROOM_LIST = "chatrooms";
        public static final String USERID = "userid";
        public static final String BOT_LIST = "botlist";
        public static final String BOT_LIST_HAST = "botlh";

        /* chatroomtype in create chatroom */
        public static final String CHATROOM_TYPE = "type";
        /* chatroom name in create chatroom */
        public static final String NAME = "name";
        public static final String DEVICE_TYPE = "device_type";
        public static final String ANNOUNCEMENT = "an";
        public static final String RESULT = "result";
        public static final String STATUS_MESSAGE = "statusmessage";
        public static final String FORCE = "force";
        public static final String PHONE_NUMBER = "phone";
        public static final String PHONE_NUMBER_HASH = "phone_hash";
        public static final String VERIFICATION_CODE = "veri_code";
        public static final String TEMP_ID = "temp_id";
        public static final String CONTACT_LIST = "contacts_list";
        public static final String AVATAR = "avatar";
        public static final String SAME_AVATAR = "same_avatar";
        public static final String COUNT = "count";
        public static final String EMAIL = "email";
        public static final String NEW_EMAIL = "new_email";
        public static final String GUEST_LOGIN = "guest_login";
        public static final String AVBROADCAST = "broadcast";
        public static final String KEY = "key";
        public static final String CATEGORY = "category";
        public static final String WHITEBOARD = "whiteboard";
        public static final String RANDOM = "random";
        public static final String ACTION_ACCEPT = "accept";
        public static final String SUBACTION = "subaction";
        public static final String WRITEBOARD_USERNAME = "?userName=";
        public static final String WRITEBOARD_TYPE_CHECK = "/writeboard";
        public static final String MODERATORIDS = "moderatorUserIDs";
        public static final String JSON_RESPONSE_HASH = "response_hash";
    }

    public static class SocialKeys {
        public static final String SOCIAL_DETAILS = "social_details";
        public static final String IDENTIFIER = "identifier";
        public static final String NETWORK_TYPE = "network_name";
        public static final String WEBSITE_URL = "webSiteURL";
        public static final String PROFILE_URL = "profileURL";
        public static final String PHOTO_URL = "photoURL";
        public static final String DISPLAY_NAME = "displayName";
        public static final String USER_NAME = "username";
        public static final String DESCRIPTION = "description";
        public static final String FIRST_NAME = "firstName";
        public static final String LAST_NAME = "lastName";
        public static final String GENDER = "gender";
        public static final String LANGUAGE = "language";
        public static final String AGE = "age";
        public static final String BIRTH_DAY = "birthDay";
        public static final String BIRTH_YEAR = "birthYear";
        public static final String BIRTH_MONTH = "birthMonth";
        public static final String EMAIL = "email";
        public static final String EMAIL_VERIFIED = "emailVerified";
        public static final String PHONE = "phone";
        public static final String ADDRESS = "address";
        public static final String COUNTRY = "country";
        public static final String REGION = "region";
        public static final String CITY = "city";
        public static final String ZIP = "zip";
    }

    /**
     * Used to set the keys releated to chatrooms
     */
    public static class ChatroomKeys {
        public static final String FLAG = "flag";
        public static final String CHATROOM_ID_FIELD = "id";
        public static final String NEW_CHATROOM_NAME = "cname";
        public static final String CHATROOM_LIST_HASH = "clh";
        public static final String CURRENT_P = "currentp";
        public static final String CURRENT_ROOM = "currentroom";
        public static final String CHATROOM_MEMBERS_HASH = "ulh";
        public static final String CHATROOM_ID = "currentroom";
        public static final String CHATROOM_NAME = "currentroomname";
        public static final String READ_MESSAGES = "crreadmessages";
        public static final String CHATROOM_JSON = "ccjsonObject";
        public static final String CHATROOM_LIST_JSON = "chatroomList";

        public static final String JOIN_KEY = "jqcc.cometchat.joinChatroom(";
        public static final String JOIN_REQUEST_MESSAGE = "Has invited you to join a chatroom.\nJoin";
        public static final String MEMBERS = "users";
        public static final String ROOMNAME = "roomname";
        public static final String INVITE = "invite[]";
        public static final String ROOMID = "roomid";
        public static final String INVITEDID = "inviteid";
        public static final String KICK_KEY = "CC^CONTROL_kicked";
        public static final String BAN_KEY = "CC^CONTROL_banned";
        public static final String KICKID = "kickid";
        public static final String KICK = "kick";
        public static final String KICKED = "kicked";
        public static final String BAN_ID = "banid";
        public static final String BANNED = "banned";
        public static final String BAN = "ban";
        public static final String UNBAN = "unban";
        public static final String UNBANUSER = "unbanusers";
        public static final String POPOUTMODE = "popoutmode";
        public static final String BAN_FLAG = "banflag";
        public static final String DELETE_MESSAGE_KEY = "CC^CONTROL_deletemessage";
        public static final String ERROR = "error";
        public static final String ROOM_DOES_NOT_EXISTS = "ROOM_DOES_NOT_EXISTS";
        public static final String CHATROOMID = "chatroomid";
        public static final String CID = "cid";
        public static final String INTENT_CHATROOM_ID = "chatroomid";
        public static final String DELETE_CHATROOM_MESSAGE = "CC^CONTROL_deletedchatroom";

        public static class TypeKeys {
            public static final int PASSWORD_PROTECTED = 1;
            public static final int PUBLIC = 0;
            public static final int INVITE_ONLY = 2;
        }
    }

    /**
     * Keys used for login functionalities
     */
    public static class LoginKeys {
        public static final String USER_LOGGED_IN = "1";
        public static final String USER_REMEMBER = "1";
        public static final String DONT_REMEMBER_USER = "0";
    }

    /**
     * Used to set the keys for Avchat
     */
    public static class AVchatKeys {
        public static final String REQUEST_KEY = "jqcc.ccavchat.accept(";
        public static final String JOIN_KEY = "jqcc.ccavchat.join(";
        public static final String ROOM_NAME = "ROOM_NAME";
        public static final String CALLER_ID = "CALLER_ID";
        public static final String HAS_SENT_REQUEST_SUCCESSFULLY = "jqcc.ccavchat.cancel_call(";
        public static final String HAS_ACCEPTED_REQUEST = "jqcc.ccavchat.accept_fid";
        public static final String GRP = "grp";
        public static final String ACCEPTED = "accept";
        public static final String VIDEO_CALL_REJECTED = "CC^CONTROL_PLUGIN_AVCHAT_REJECTCALL";
        public static final String VIDEO_CALL_ENDED = "CC^CONTROL_PLUGIN_AVCHAT_ENDCALL";
        public static final String VIDEO_NO_ANSWER = "CC^CONTROL_PLUGIN_AVCHAT_NOANSWER";
        public static final String VIDEO_CALL_CANCEL = "CC^CONTROL_PLUGIN_AVCHAT_CANCELCALL";
        public static final String VIDEO_BUSY_CALL = "CC^CONTROL_PLUGIN_AVCHAT_BUSYCALL";
        public static final String VIDEO_CrREQUEST_KEY = "jqcc.ccavchat.join(";
        public static final String CALLER_NAME = "name";
    }

    public static class AudiochatKeys {
        public static final String REQUEST_KEY = "jqcc.ccaudiochat.accept(";
        public static final String HAS_SENT_REQUEST_SUCCESSFULLY = "jqcc.ccaudiochat.cancel_call(";
        public static final String HAS_ACCEPTED_REQUEST = "jqcc.ccaudiochat.accept_fid";
        public static final String AUDIO_CALL_REJECTED = "CC^CONTROL_PLUGIN_AUDIOCHAT_REJECTCALL";
        public static final String AUDIO_CALL_ENDED = "CC^CONTROL_PLUGIN_AUDIOCHAT_ENDCALL";
        public static final String AUDIO_NO_ANSWER = "CC^CONTROL_PLUGIN_AUDIOCHAT_NOANSWER";
        public static final String AUDIO_CALL_CANCEL = "CC^CONTROL_PLUGIN_AUDIOCHAT_CANCELCALL";
        public static final String AUDIO_BUSY_CALL = "CC^CONTROL_PLUGIN_AUDIOCHAT_BUSYCALL";
        public static final String AUDIO_CrREQUEST_KEY = "jqcc.ccaudiochat.join(";
        public static final String AUDIO_ONLY_CALL = "AUDIO_ONLY_CALL";
    }

    public static class AVBroadcastKeys {
        public static final String BROADCAST_REQUEST_KEY = "jqcc.ccbroadcast.accept(";
        public static final String CRBROADCAST_REQUEST_KEY = "jqcc.ccbroadcast.join(";
        public static final CharSequence BROADCAST_END_KEY = "CC^CONTROL_PLUGIN_BROADCAST_ENDCALL";
    }

    public static class OtherPluginKeys {
        public static final String GAME_REQUEST_KEY = "jqcc.ccgames.accept(";
        public static final String GAME_ACCEPT_KEY = "jqcc.ccgames.accept_fid(";
        public static final String WRITEBOARD_REQUEST_KEY = "jqcc.ccwriteboard.accept(";
        public static final String HANDWRITE_KEY = "/plugins/handwrite/uploads/";
        public static final String HANDWRITE_NEW_KEY = "/writable/handwrite/uploads/";
        public static final String WHITEBOARD_REQUEST_KEY = "jqcc.ccwhiteboard.accept(";
        public static final String SCREENSHARE_REQUEST_KEY = "jqcc.ccscreenshare.accept(";

    }

    /**
     * Used to set the keys for User status
     */
    public static class StatusKeys {
        public static final String STATUS = "status";
        public static final String AVALIABLE = "available";
        public static final String BUSY = "busy";
        public static final String OFFLINE = "offline";
        public static final String INVISIBLE = "invisible";
        public static final String AWAY = "away";
    }

    /**
     * Used to set the keys for Report conversation
     */
    public static class ReportKeys {
        public static final String REPORT_ISSUE = "issue";
        public static final String RANDOM = "rand";
    }

    public static class MessageTypeKeys {
        public static final String MESSAGE_TYPE = "messageType";
        public static final String NORMAL = "0";
        public static final String AVCHAT = "1";
        public static final String JOIN_CHATROOM_MESSAGE = "2";
        public static final String IMAGE_NEW = "3";
        public static final String VIDEO_NEW = "4";
        public static final String VIDEO_DOWNLOADED = "5";
        public static final String VIDEO_UPLOAD = "6";
        public static final String HANDWRITE_NEW = "7";
        public static final String IMAGE_DOWNLOADED = "8";
        public static final String HANDWRITE_DOWNLOADED = "9";
        public static final String VIDEO_IS_DOWNLOADING = "10";
        public static final String AUDIO_IS_DOWNLOADING = "11";
        public static final String AUDIO_DOWNLOADED = "12";
        public static final String AUDIO_NEW = "13";
        public static final String AUDIO_UPLOAD = "14";
        public static final String AVBROADCAST = "15";
        public static final String STICKERS = "16";
        public static final String FILE_NEW = "17";
        public static final String FILE_DOWNLOADING = "18";
        public static final String FILE_DOWNLOADED = "19";
        public static final String WHITEBOARD_REQUEST = "20";
        public static final String WRITEBOARD_REQUEST = "21";
        public static final String SCREENSHARE_REQUEST = "22";
        public static final String AUDIO_CONFERENCE = "23";
        public static final String BOT_RESPONCE = "24";

        public static final int MESSAGE_SENT = 1;
        public static final int MESSAGE_DELIVERD = 2;
        public static final int MESSAGE_READ = 3;

    }

    public static class FileUploadKeys {
        public static final String FILEDATA = "Filedata";
        public static final String IMAGE_HEIGHT = "imageheight";
        public static final String IMAGE_WIDTH = "imagewidth";
        public static final String SENDERNAME = "sendername";

        /* File name with extension */
        public static final String FILENAME = "name";
        public static final String CHATROOMMODE = "chatroommode";
        public static final String CHATROOMMODE_VALUE = "1";
    }

    public static class RecentMessageTypes{
        public static final String IMAGE = "Image";
        public static final String AUDIO = "Audio";
        public static final String AUDIO_NOTE = "Audio Note";
        public static final String STICKER = "Sticker";
        public static final String VIDEO = "Video";
        public static final String FILE = "File";
        public static final String HANDWRITE = "Handwrite";
        public static final String WHITEBOARD = "Whiteboard";
        public static final String WRITEBOARD = "Writeboard";
        public static final String SCREEN_SHARE_REQUEST = "Screenshare";
    }
}
