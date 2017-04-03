/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.factories;

import android.text.TextUtils;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SessionData;

import java.net.MalformedURLException;
import java.net.URL;

public class URLFactory {

    public static final String PROTOCOL_PREFIX = "http://";
    public static final String PROTOCOL_PREFIX_SECURE = "https://";

    /* Relative URLS for all AJAX calls */
    private static final String LOGIN_URL = "extensions/mobileapp/login.php";
    private static final String JSON_PHP_URL = "extensions/mobileapp/json.php";
    private static final String ONE_ON_ONE_HEARTBEAT_URL = "cometchat_receive.php";
    private static final String SEND_ONE_TO_ONE_URL = "cometchat_send.php";
    private static final String LOGOUT_URL = "cometchat_logout.php";
    private static final String CHATROOM_HEARTBEAT_URL = "modules/chatrooms/chatrooms.php?action=heartbeat";
    private static final String CHATROOM_USERLIST_URL = "modules/chatrooms/chatrooms.php?action=getchatroomusers";
    private static final String CHATROOM_CHECK_PASSWORD = "modules/chatrooms/chatrooms.php?action=checkpassword";
    private static final String  CHATROOM_SEND_URL = "modules/chatrooms/chatrooms.php?action=sendmessage";
    private static final String AVCHAT_URL = "plugins/avchat/index.php";
    private static final String REPORT_CONVERSATION_URL = "plugins/report/index.php?action=report";
    private static final String CHATROOM_LEAVE_URL = "modules/chatrooms/chatrooms.php?action=leavechatroom";
    private static final String CHATROOM_INVITE_URL = "modules/chatrooms/chatrooms.php?action=inviteusers";
    private static final String FILE_UPLOAD_URL = "plugins/filetransfer/upload.php";
    private static final String KICK_USER_URL = "modules/chatrooms/chatrooms.php?action=kickUser";
    private static final String DELETE_CHATROOM_URL = "modules/chatrooms/chatrooms.php?action=deletechatroom";
    private static final String RENAME_CHATROOM_URL = "modules/chatrooms/chatrooms.php?action=renamechatroom";
    private static final String BAN_USER_URL = "modules/chatrooms/chatrooms.php?action=banUser";
    private static final String GET_ID = "cometchat_getid.php";
    private static final String CREATE_CHATROOM_URL = "modules/chatrooms/chatrooms.php?action=createchatroom";
    public  static  final String LEGACY_APP_LINK = "https://play.google.com/store/apps/details?id=com.inscripts.cometchat.legacy";
    private static final String ANNOUNCEMENT_URL = "modules/announcements/index.php?";
    private static final String BLOCKUSER_URL = "plugins/block/index.php?action=block";
    private static final String UNBLOCKUSER_URL = "plugins/block/index.php?action=unblock";
    private static final String GET_BLOCKED_USER_URL = "plugins/block/index.php";
    private static final String AUDIO_CHAT_URL = "plugins/audiochat/index.php";

    /* URLs for phone number registration system. */
    private static final String PHONE_REGISTER = "extensions/mobileapp/phone_register.php";
    private static final String PHONE_EMAIL_REGISTER = "extensions/mobileapp/phone_email_register.php";
    private static final String GOOGLE_TRANSLATE_URL = "https://www.googleapis.com/language/translate/v2";

    private static final String COD_URL = ".cometondemand.net";
    private static final String COD_LOGIN_URL = "/api/app_login";
    private static final String COD_CHECKER_URL = "http://my.cometchat.com/checkdomaincod.php?domain=";
    public static final String TWITTER_TOKEN_URL = "https://api.twitter.com/oauth2/token";
    public static final String TWITTER_STREAM_URL = "https://api.twitter.com/1.1/users/show.json?screen_name=";
    private static final String BROADCAST_MESSAGE_URL = "modules/broadcastmessage/index.php?action=sendbroadcast";

    private static final String AVBROADCAST_REQUEST_URL = "plugins/broadcast/index.php?action=request";
    private static final String AVBROADCAST_END_URL = "plugins/broadcast/index.php?action=endcall";
    private static final String CRAVBROADCAST_REQUST_URL = "plugins/broadcast/index.php?action=call";
    private static final String AVBROADCAST_INVITE_URL = "plugins/broadcast/invite.php?action=inviteusers";
    private static final String UNBAN_CHATROOM_USER = "modules/chatrooms/chatrooms.php?action=unban";
    private static final String UNBAN_CHATROOM_USER_LIST = "modules/chatrooms/chatrooms.php?action=unbanusers";
    private static final String SEND_STICKER_URL = "plugins/stickers/index.php?action=sendSticker";
    private static final String WHITEBOARD_URL = "plugins/whiteboard/index.php";
    private static final String WRITEBOARD_URL = "plugins/writeboard/index.php?action=request";
    private static final String CRWRITEBOARD_URL = "plugins/writeboard/index.php?action=writeboard";
    private static final String WRITEBOARD_CONNECT_URL = "https://w.chatforyoursite.com/p/chat-";
    private static final String SINGLE_PLAYER_URL = "modules/games/index.php?basedata=null&callbackfn=mobileapp";
    private static final String HANDWRITE_URL = "/plugins/handwrite/index.php?popoutmode=1&callbackfn=mobileapp";



    private static final String BOTS_URL = "extensions/bots/index.php?callbackfn=mobileapp";



    private static final String HANDWRITE_URL_CHATROOM = "/plugins/handwrite/index.php?chatroommode=1&callbackfn=mobileapp";

    /* Get base url based on preferences */
    public static String getBaseURL() {

        String cometChatURL = "";
        if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
            /* Default application */
            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.BASE_URL)) {
                cometChatURL = PreferenceHelper.get(PreferenceKeys.LoginKeys.BASE_URL);
                if (!(cometChatURL.contains(PROTOCOL_PREFIX) || cometChatURL.contains(PROTOCOL_PREFIX_SECURE))) {
                    cometChatURL = PROTOCOL_PREFIX + cometChatURL;
                }
            }
            return cometChatURL;
        } else {
            /* White labeling */
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.COD_ID)) {
                return PreferenceHelper.get(PreferenceKeys.LoginKeys.BASE_URL);
            } else if (!(LocalConfig.getSiteUrl().contains(PROTOCOL_PREFIX) || LocalConfig.getSiteUrl()
                    .contains(PROTOCOL_PREFIX_SECURE))) {
                return URLFactory.PROTOCOL_PREFIX + LocalConfig.getSiteUrl();
            }
            return LocalConfig.getSiteUrl();
        }
    }

    /* Returns the final foldername in which CometChat is installed */
    private static String getCometChatFolder() {
        return PreferenceHelper.get(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER);
    }

    public static String getWebsiteURL() {
        String host = "";
        try {
            URL url = new URL(getBaseURL());
            host = url.getProtocol() + "://" + url.getHost();
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }
        return host;
    }

    public static String getHandwriteURL() {
        return getCometChatURL() + HANDWRITE_URL;
    }

    public static String getBotsUrl() {
        return getCometChatURL() + BOTS_URL;
    }

    public static String getWebsiteHostURL() {
        String host = "";
        try {
            host = new URL(getBaseURL()).getHost();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return host;
    }

    public static String getCometChatURL() {
        String baseUrl = getBaseURL();
        if (TextUtils.isEmpty(getCometChatFolder())) {
            if (baseUrl.endsWith("/")) {
                return baseUrl;
            } else {
                return baseUrl + "/";
            }
        } else {
            if (baseUrl.endsWith("/")) {
                return baseUrl + getCometChatFolder();
            } else {
                return baseUrl + "/" + getCometChatFolder();
            }
        }
    }

    public static String getPhoneRegisterURL() {

        MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
        if (mobileConfig != null) {
            int phoneLoginType = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneLoginType == 1) {
                return getCometChatURL() + PHONE_REGISTER;
            } else {
                return getCometChatURL() + PHONE_EMAIL_REGISTER;
            }
        } else {
            if (LocalConfig.LOGIN_TYPE == 3 || LocalConfig.LOGIN_TYPE == 4) {
                return getCometChatURL() + PHONE_EMAIL_REGISTER;
            } else {
                return getCometChatURL() + PHONE_REGISTER;
            }
        }
    }

    public static String getHandwriteUrlChatroom() {
        return getCometChatURL() + HANDWRITE_URL_CHATROOM;
    }

    public static String getLogoutURL() {
        return getCometChatURL() + LOGOUT_URL;
    }

    public static String getSendOneToOneMessageURL() {
        return getCometChatURL() + SEND_ONE_TO_ONE_URL;
    }

    public static String getRecieveURL() {
        return getCometChatURL() + ONE_ON_ONE_HEARTBEAT_URL;
    }

    public static String getJsonPhpURL() {
        return getCometChatURL() + JSON_PHP_URL;
    }

    public static String getLoginURL() {
        return getCometChatURL() + LOGIN_URL;
    }

    public static String getChatroomUrl() {
        return getCometChatURL() + CHATROOM_HEARTBEAT_URL;
    }

    public static String getChatroomUserListUrl(){
        return getCometChatURL() + CHATROOM_USERLIST_URL;
    }

    public static String getChatroomPasswordUrl() {

        return getCometChatURL() + CHATROOM_CHECK_PASSWORD;
    }

    public static String getSendChatroomMessageURL() {
        return getCometChatURL() + CHATROOM_SEND_URL;
    }

    public static String getAVChatURL() {
        return getCometChatURL() + AVCHAT_URL;
    }

    public static String getReportConversationURL() {
        return getCometChatURL() + REPORT_CONVERSATION_URL;
    }

    public static String getChatroomLeaveURL() {
        return getCometChatURL() + CHATROOM_LEAVE_URL;
    }

    public static String getChatroomInviteURL() {
        return getCometChatURL() + CHATROOM_INVITE_URL;
    }

    public static String getFileUploadURL() {
        return getCometChatURL() + FILE_UPLOAD_URL;
    }

    public static String getKickUserURL() {
        return getCometChatURL() + KICK_USER_URL;
    }
    public static String getDeleteChatroomURL() {
        return getCometChatURL() + DELETE_CHATROOM_URL;
    }

    public static String getRenameChatroomURL() {
        return getCometChatURL() + RENAME_CHATROOM_URL;
    }

    public static String getBanUserURL() {
        return getCometChatURL() + BAN_USER_URL;
    }

    public static String getInfoFromId() {
        return getCometChatURL() + GET_ID;
    }

    public static String getCreateChatroomURL() {
        return getCometChatURL() + CREATE_CHATROOM_URL;
    }

    public static String getAnnouncementUrl() {
        return getCometChatURL() + ANNOUNCEMENT_URL;
    }

    public static String getAnnouncementTabUrl() {
        return getCometChatURL() + ANNOUNCEMENT_URL + CometChatKeys.AjaxKeys.BASE_DATA + "=" + SessionData.getInstance().getBaseData();
    }

    public static String getBlockUserURL() {
        return getCometChatURL() + BLOCKUSER_URL;
    }

    public static String getUnblockUserURL() {
        return getCometChatURL() + UNBLOCKUSER_URL;
    }

    public static String getBlockedUserURL() {
        return getCometChatURL() + GET_BLOCKED_USER_URL;
    }

    public static String getAudioChatURL() {
        return getCometChatURL() + AUDIO_CHAT_URL;
    }

    public static String getGoogleTranslateURL() {
        return GOOGLE_TRANSLATE_URL;
    }

    public static String getCometOnDemandCheckerURL() {
        return COD_CHECKER_URL;
    }

    public static String getCodLoginUrl() {
        return COD_URL + COD_LOGIN_URL;
    }

    public static String getCodUrl() {
        return COD_URL;
    }

    public static String getBroadCastMessageURL() {
        return getCometChatURL() + BROADCAST_MESSAGE_URL;
    }

    public static String getAVBroadcastRequestURL() {
        return getCometChatURL() + AVBROADCAST_REQUEST_URL;
    }

    public static String getLastSeenSettingRequestURL() {
        return getCometChatURL() + SEND_ONE_TO_ONE_URL;
    }

    public static String getCRAVBroadcastRequestURL() {
        return getCometChatURL() + CRAVBROADCAST_REQUST_URL;
    }

    public static String getAVBroadcastEndURL() {
        return getCometChatURL() + AVBROADCAST_END_URL;
    }

    public static String getAVBroadcastInviteURL(){
        return getCometChatURL() + AVBROADCAST_INVITE_URL;
    }

    public static String getSendStickerURL(){
        return getCometChatURL() + SEND_STICKER_URL;
    }

    public static String getWhiteBoardURL(){ return getCometChatURL() + WHITEBOARD_URL;}

    public static String getWriteBoardURL(){ return getCometChatURL() + WRITEBOARD_URL;}

    public static String getCrWriteBoardURL(){ return getCometChatURL() + CRWRITEBOARD_URL;}

    public static String getWriteBoardConnectURL(){ return WRITEBOARD_CONNECT_URL;}

    public static String getSinglePlayerGameURL(){
        return getCometChatURL() + SINGLE_PLAYER_URL;
    }

    public static String getUnbanChatroomUserURL(){
        return getCometChatURL() + UNBAN_CHATROOM_USER;
    }
    public static String getUnbanChatroomUserListURL(){
        return getCometChatURL() + UNBAN_CHATROOM_USER_LIST;
    }
}
