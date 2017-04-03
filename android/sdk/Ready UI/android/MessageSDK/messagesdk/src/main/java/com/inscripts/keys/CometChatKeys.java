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
        public static final String CHATROOM_TIMESTAMP = "crtimestamp";
        public static final String BASE_DATA = "basedata";
        public static final String ACTION = "action";
        public static final String TO = "to";
        public static final String LASTSEENSETTINGFLAG = "lastseenSettingsFlag";
        public static final String BUDDY_LIST_HASH = "blh";
        public static final String MESSAGE = "message";
        public static final String SENT = "sent";
        public static final String PLATFORM = "platform";
        public static final String ACTIVE_CHATWINDOW_ID = "activeChatboxIds";
        public static final String SDK_PARAM = "cc_sdk";
        public static final String API_KEY = "api-key";
        public static final String USERS = "users";
        public static final String DISPLAY_NAME = "displayname";
        public static final String LINK = "link";
        public static final String APP_INFO = "appinfo";
        public static final String BOT_LIST = "botlist";
        public static final String BOT_LIST_HAST = "botlh";
        public static final String ACCEPT_NULL = "accept_null";
        public static final String NEW_PASSWORD = "newpassword";
        public static final String FRIENDS = "friends";
        public static final String CALLID = "callid";
        public static final String UID = "uid";
        public static final String SELF = "self";
        public static final String ORIGINAL_FILE = "original_file";
        public static final String SENDERNAME = "sendername";
        public static final String BOT_RESPONCE_TYPE = "bot_responce_type";
        public static final String BOT_ID = "botid";
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
        public static final String JSON_RESPONSE_HASH = "response_hash";
        public static final String FORCE_LIST = "f";
        public static final String CHATBOX = "chatbox";
        public static final String PREPEND = "prepend";
        public static final String CHATROOMID = "chatroomid";
        public static final String WRITEBOARD_USERNAME = "?userName=";
        public static final String LANG_COOKIE = "cookie_cc_lang";
    }

    public static class SDKMessageTypeKeys {
        public static final String MESSAGE_TYPE = "message_type";
        public static final String PLUGIN_TYPE = "pluginType";

        /* Message types */
        public static final int NORMAL = 10;
        public static final int JOIN_CHATROOM_MESSAGE = 11;
        public static final int IMAGE = 12;
        public static final int HANDWRITTEN_MESSAGE = 13;
        public static final int VIDEO = 14;
        public static final int DELETED_MESSAGE = 15;
        public static final int AUDIO = 16;
        public static final int FILE = 17;
        public static final int STICKER = 18;
        public static final int WHITEBOARD = 19;
        public static final int WRITEBOARD = 20;
        public static final int SCREENSHARE = 21;

		/* Plugin types*/

        public static final int AUDIO_CALL = 0;
        public static final int AVCALL = 1;
        public static final int AVBROADCAST = 2;
    }

    /**
     * Used to set the keys releated to chatrooms
     */
    public static class ChatroomKeys {
        public static final String FLAG = "flag";
        public static final String CHATROOM_ID_FIELD = "id";
        public static final String CHATROOM_LIST_HASH = "clh";
        public static final String CURRENT_P = "currentp";
        public static final String CURRENT_ROOM = "currentroom";
        public static final String CHATROOM_MEMBERS_HASH = "ulh";
        public static final String CHATROOM_ID = "currentroom";
        public static final String CHATROOM_NAME = "currentroomname";
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
        public static final String BAN_FLAG = "banflag";
        public static final String DELETE_MESSAGE_KEY = "CC^CONTROL_deletemessage";
        public static final String ERROR = "error";
        public static final String ROOM_DOES_NOT_EXISTS = "ROOM_DOES_NOT_EXISTS";
        public static final String FROMID = "fromid";
        public static final String TEXT_COLOR = "text_color";
        public static final String CNAME = "cname";

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

        public static final String JOIN = "join";
        public static final String TYPE = "type";

        public static final String INCOMING_AVCALL_MESSAGE = "AVCHAT_INCOMING_CALL";
        public static final String END_AVCALL_MESSAGE = "AVCHAT_END_CALL";
        public static final String AVCALL_REJECTED_MESSAGE = "AVCHAT_REJECT_CALL";
        public static final String CANCEL_AVCALL_MESSAGE = "AVCHAT_CANCEL_CALL";
        public static final String BUSY_AVCALL_MESSAGE = "AVCHAT_BUSY_CALL";
        public static final String NOANSWER_AVCALL_MESSAGE = "AVCHAT_NO_ANSWER";
        public static final String AVCALL_ACCECPTED_MESSAGE = "AVCHAT_CALL_ACCEPTED";
        public static final String AVCALL_SENTSUCCESSFUL_MESSAGE = "AVCHAT_CALL_SENT_SUCCESS";
        public static final String INCOMING_AVCALL_WHILE_USER_BUSY_MESSAGE = "AVCHAT_INCOMING_CALL_USER_BUSY";

        public static final String INCOMING_AUDIOCALL_MESSAGE = "AUDIOCHAT_INCOMING_CALL";
        public static final String END_AUDIOCALL_MESSAGE = "AUDIOCHAT_END_CALL";
        public static final String AUDIOCALL_REJECTED_MESSAGE = "AUDIOCHAT_REJECT_CALL";
        public static final String CANCEL_AUDIOCALL_MESSAGE = "AUDIOCHAT_CANCEL_CALL";
        public static final String BUSY_AUDIOCALL_MESSAGE = "AUDIOCHAT_BUSY_CALL";
        public static final String NOANSWER_AUDIOCALL_MESSAGE = "AUDIOCHAT_NO_ANSWER";
        public static final String AUDIOCALL_ACCECPTED_MESSAGE = "AUDIOCHAT_CALL_ACCEPTED";
        public static final String AUDIOCALL_SENTSUCCESSFUL_MESSAGE = "AUDIOCHAT_CALL_SENT_SUCCESS";
        public static final String INCOMING_AUDIOCALL_WHILE_USER_BUSY_MESSAGE = "AUDIOCHAT_INCOMING_CALL_USER_BUSY";
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
        public static final String INCOMING_AVBROADCAST_MESSAGE = "INCOMING_AVBROADCAST_REQUEST";
        public static final String END_AVCALL_MESSAGE = "AVBROADCAST_END";
        public static final String AVBROADCAST_INVITE_MESSAGE = "AVBROADCAST_INVITE_MESSAGE";
    }

    public static class OtherPluginKeys {
        public static final String GAME_REQUEST_KEY = "jqcc.ccgames.accept(";
        public static final String GAME_ACCEPT_KEY = "jqcc.ccgames.accept_fid(";
        public static final String WRITEBOARD_REQUEST_KEY = "jqcc.ccwriteboard.accept(";
        public static final String HANDWRITE_KEY = "/plugins/handwrite/uploads/";
        public static final String WHITEBOARD_REQUEST_KEY = "jqcc.ccwhiteboard.accept(";
        public static final String SCREENSHARE_REQUEST_KEY = "jqcc.ccscreenshare.accept(";
    }

    public static class ChatroomActionMessageTypeKeys {
        public static final int CHATROOM_KICKED = 10;
        public static final int CHATROOM_BANNED = 11;
        public static final int CHATROOM_DELETED = 12;
        public static final int CHATROOM_MESSAGE_DELETED = 13;
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
        public static final String STATUS_MESSAGE = "statusmessage";
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

    public static class AvchatMessageTypeKeys {
        public static final int AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED = 31;
        public static final int AVCHAT_MESSAGE_TYPE_INCOMING_CALL = 32;
        public static final int AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE = 33;
        public static final int AVCHAT_MESSAGE_TYPE_END_CALL = 34;
        public static final int AVCHAT_MESSAGE_TYPE_REJECT_CALL = 35;
        public static final int AVCHAT_MESSAGE_TYPE_CANCEL_CALL = 36;
        public static final int AVCHAT_MESSAGE_TYPE_NO_ANSWER = 37;
        public static final int AVCHAT_MESSAGE_TYPE_BUSY_CALL = 38;

    }

    public static class AvBroadcastMessageTypeKeys {
        public static final int AVBROADCAST_MESSAGE_TYPE_INCOMING_CALL = 41;
        public static final int AVBROADCAST_MESSAGE_TYPE_END_CALL = 42;
        public static final int AVBROADCAST_MESSAGE_TYPE_INVITE = 43;
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

    public static class ErrorKeys {

        /* Common errors codes */
        public static final String CODE_NO_INTERNET_CONNECTION = "100";
        public static final String CODE_CONNECTION_TO_HOST_404 = "101";
        public static final String CODE_USER_NOT_LOGGEDIN = "102";
        public static final String CODE_JSON_PARSING_ERROR = "103";
        public static final String CODE_INITAL_SETTING_ERROR = "104";
        public static final String CODE_LOGGEDOUT_HEARTBEAT = "105";
        public static final String CODE_FILE_DOES_NOT_EXIST = "106";
        public static final String CODE_RANDOM_EXCEPTION = "107";
        public static final String CODE_COMETCHAT_NOT_FOUND = "108";
        public static final String CODE_CONFIGURE_TRANSLATE_PLUGIN = "109";
        public static final String CODE_PLUGIN_INFO_NOTFOUND = "110";
        public static final String CODE_STICKER_PLUGIN_NOT_ENABLED = "111";
        public static final String CODE_USER_NOT_FOUND = "112";
        public static final String CODE_GAMES_NOT_ENABLED ="113" ;

        /* Login errors codes */
        public static final String CODE_USERID_WRONG = "200";
        public static final String CODE_EMPTY_RESPONSE = "201";
        public static final String CODE_INVALID_URL = "202";
        public static final String CODE_VERSION_OLD = "203";
        public static final String CODE_USERNAME_PASSWORD_WRONG = "204";
        public static final String CODE_SUBSCRIPTION_EXPRIED = "205";
        public static final String CODE_PLAN_NOT_SUPPORTED = "206";

        /* One-on-one errors code */
        public static final String CODE_USER_NOT_BLOCKED = "300";
        public static final String CODE_USER_NOT_UNBLOCKED = "301";
        public static final String CODE_USER_NOT_DELETED = "302";
        public static final String CODE_BROADCAST_MESSAGE_DISABLED = "303";
        public static final String CODE_COMETSERVICE_NOT_ENABLED = "304";
        public static final String CODE_TYPING_NOT_ENABLED = "305";
        public static final String CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED = "306";
        public static final String CODE_WHITEBOARD_NOT_ENABLED = "307";
        public static final String CODE_WRITEBOARD_NOT_ENABLED ="308";
        public static final String CODE_REPORTCONVERSATION_NOT_ENABLED = "309";

        /* Chatroom errors codes */
        public static final String CODE_CHATROOM_NOT_JOINED = "400";
        public static final String CODE_CHATROOM_CREATION_ERROR = "401";
        public static final String CODE_JOIN_CHATROOM_WRONG_PWD = "402";
        public static final String CODE_JOIN_CHATROOM_BANNED = "403";
        public static final String CODE_CHATROOMID_MISMATCH = "404";
        public static final String CODE_CHATROOM_DONT_EXIST = "405";
        public static final String CODE_CHATROOM_DELETION_ERROR = "406";
        public static final String CODE_ROOM_ALREADY_EXIST = "407";
        public static final String CODE_YOU_ARE_NOT_OWNER = "408";

        /* AVchat error codes */
        public static final String CODE_AVCHAT_NOT_ENABLED = "500";
        public static final String CODE_AVCHAT_INCORRECT_USER = "501";
        public static final String CODE_AVCHAT_CALL_DETAILS_NOT_FOUND = "502";
        public static final String CODE_AVCHAT_CONTAINER_EMPTY = "503";
        public static final String CODE_AVCHAT_NOT_SUPPORTED = "504";
        public static final String CODE_AVCHAT_USER_BUSY = "505";

        /* Audio chat error codes */
        public static final String CODE_AUDIOCHAT_NOT_ENABLED = "600";
        public static final String CODE_AUDIOCHAT_INCORRECT_USER = "601";
        public static final String CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND = "602";
        public static final String CODE_AUDIOCHAT_CONTAINER_EMPTY = "603";
        public static final String CODE_AUDIOCHAT_NOT_SUPPORTED = "604";
        public static final String CODE_AUDIOCHAT_USER_BUSY = "605";

        /* AVBroadcast error codes */
        public static final String CODE_AVBROADCAST_NOT_ENABLED = "700";
        public static final String CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND = "702";
        public static final String CODE_AVBROADCAST_CONTAINER_EMPTY = "703";
        public static final String CODE_AVBROADCAST_NOT_SUPPORTED = "704";

        /* Common errors message */
        public static final String MESSAGE_PLEASE_CHECK_INTERNET = "Please check your internet connection";
        public static final String MESSAGE_CONNECTION_REFUSED_404 = "Error in connection";
        public static final String MESSAGE_NOT_LOGGEDIN = "You must be logged in";
        public static final String MESSAGE_JSON_PARSING_ERROR = "Error at parsing json";
        public static final String MESSAGE_JSONPHP_ERROR = "Error at initializing settings";
        public static final String MESSAGE_FILE_DOES_NOT_EXIST = "The file does not exist on the given path.";
        public static final String MESSAGE_LOGGEDOUT_HEARTBEAT = "Log in error in heartbeat";
        public static final String MESSAGE_RANDOM_EXCEPTION = "An exception has occured. Please check the stacktrace.";
        public static final String MESSAGE_COMETCHAT_NOT_FOUND = "CometChat is not installed at specified url";
        public static final String MESSAGE_CONFIGURE_TRANSLATE_PLUGIN = "Please configure Translate Conversation module on CometChat admin panel";
        public static final String MESSAGE_PLUGIN_INFO_NOTFOUND = "Plugin information not present, please subscribe to CometChat.";
        public static final String MESSAGE_SITCKER_PLUGIN_NOT_ENABLED = "Sticker plugin is not enabled on your CometChat";
        public static final String MESSAGE_USER_NOT_FOUND = "User not found";
        public static final String MESSAGE_GAME_PLUGIN_NOT_ENABLED = "Single player game is not enabled on your CometChat";

        /* Login errors messages */
        public static final String MESSAGE_WRONG_USERID = "Incorrect userId";
        public static final String MESSAGE_EMPTY_LOGIN_RESPONSE = "Invalid user details";
        public static final String MESSAGE_INVALID_URL = "Invalid url or response for login is incorrect";
        public static final String MESSAGE_PLEASE_UPGRADE_COMETCHAT = "Sorry, CometChat needs to be upgraded on the site to use this app.";
        public static final String MESSAGE_WRONG_USERNAME_PASSWORD = "Incorrect username or password";

		/* One-on-one error messages */

        public static final String MESSAGE_USER_NOT_BLOCKED = "An error occurred while blocking user";
        public static final String MESSAGE_USER_NOT_UNBLOCKED = "An error occurred while unblocking user";
        public static final String MESSAGE_USER_NOT_DELETED = "An error occurred while deleting history of user";
        public static final String MESSAGE_BROADCAST_MESSAGE_DISABLED = "Broadcast module is not enabled for SDK";
        public static final String MESSAGE_COMETSERVICE_NOT_ENABLED = "CometService is not enabled for your CometChat";
        public static final String MESSAGE_TYPING_NOT_ENABLED = "Typing is not enabled on for your CometChat";
        public static final String MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED = "CometService Selfhosted is not enabled for your CometChat";
        public static final String MESSAGE_WHITEBOARD_NOT_ENABLED = "Please enable whiteboard plugin from administration panel";
        public static final String MESSAGE_WRITEBOARD_NOT_ENABLED = "Please enable writeboard plugin from administration panel";
        public static final String MESSAGE_REPORTCONVERSATION_NOT_ENABLED = "Please enable reportconversation plugin from administration panel";

        /* Chatroom error messages */
        public static final String MESSAGE_CHATROOM_NOT_JOINED = "You have not joined any chatroom";
        public static final String MESSAGE_CHATROOM_CREATION_ERROR = "This chatroom can't be created, it may exists";
        public static final String MESSAGE_JOIN_CHATROOM_WRONG_PWD = "Please enter correct password for chatroom";
        public static final String MESSAGE_JOIN_CHATROOM_BANNED = "You are banned from this chatroom";
        public static final String MESSAGE_CHATROOMID_MISMATCH = "Please check your chatroomid";
        public static final String MESSAGE_CHATROOM_DONT_EXIST = "This chatroom does not exist";
        public static final String MESSAGE_CHATROOM_DELETE_ERROR = "You do not have the privileges(owner,moderator & admin) to delete this chatroom OR This chatroom doesn't exists";
        public static final String MESSAGE_ROOM_ALREADY_EXIST = "The chatroomname already exist";
        public static final String MESSAGE_NOT_CHATROOM_OWNER = "You are not owner or moderator of chatroom";

        /* AVchat error messages */
        public static final String MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED = "AVChat plugin not enabled";
        public static final String MESSAGE_AVCHAT_INCORRECT_USER = "User id provided for AVChat call is incorrect";
        public static final String MESSAGE_AVCHAT_CALL_DETAILS_NOT_FOUND = "No Call Details found";
        public static final String MESSAGE_AVCHAT_CONTAINER_EMPTY = "Container is empty";
        public static final String MESSAGE_AVCHAT_NOT_SUPPORTED = "Your device does not support this feature";
        public static final String MESSAGE_AVCHAT_USER_BUSY = "User is already busy in a call";

        /* Audiochat error messages */
        public static final String MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED = "AudioChat plugin not enabled";
        public static final String MESSAGE_AUDIOCHAT_INCORRECT_USER = "User id provided for AudioChat call is incorrect";
        public static final String MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND = "No Call Details found";
        public static final String MESSAGE_AUDIOCHAT_CONTAINER_EMPTY = "Container is empty";
        public static final String MESSAGE_AUDIOCHAT_NOT_SUPPORTED = "Your device does not support this feature";
        public static final String MESSAGE_AUDIOCHAT_USER_BUSY = "User is already busy in a call";

        /* AVbroadcast error messages */
        public static final String MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED = "AVBroadcast plugin not enabled";
        public static final String MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND = "No broadcast Details found";
        public static final String MESSAGE_AVBROADCAST_CONTAINER_EMPTY = "Container is empty";
        public static final String MESSAGE_AVBROADCAST_NOT_SUPPORTED = "Your device does not support this feature";



    }



}
