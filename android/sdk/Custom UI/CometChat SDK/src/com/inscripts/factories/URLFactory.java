package com.inscripts.factories;

import java.net.URL;

import android.text.TextUtils;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.StaticMembers;

public class URLFactory {

	/* Base URL for white labeling. Keep null for defaul app. */
	private static final String SITE_URL = "";

	public static final String PROTOCOL_PREFIX = "http://";
	public static final String PROTOCOL_PREFIX_SECURE = "https://";

	/* Relative URLS for all AJAX calls */
	private static final String LOGIN_URL = "extensions/mobileapp/login.php";
	private static final String JSON_PHP_URL = "extensions/mobileapp/json.php";
	private static final String ONE_ON_ONE_HEARTBEAT_URL = "cometchat_receive.php";
	private static final String SEND_ONE_TO_ONE_URL = "cometchat_send.php";
	private static final String LOGOUT_URL = "cometchat_logout.php";
	private static final String CHATROOM_HEARTBEAT_URL = "modules/chatrooms/chatrooms.php?action=heartbeat";
	private static final String CHATROOM_CHECK_PASSWORD = "modules/chatrooms/chatrooms.php?action=checkpassword";
	private static final String CHATROOM_SEND_URL = "modules/chatrooms/chatrooms.php?action=sendmessage";
	private static final String AVCHAT_URL = "plugins/avchat/index.php";
	private static final String CHATROOM_LEAVE_URL = "modules/chatrooms/chatrooms.php?action=leavechatroom";
	private static final String CHATROOM_INVITE_URL = "modules/chatrooms/chatrooms.php?action=inviteusers";
	private static final String FILE_UPLOAD_URL = "plugins/filetransfer/upload.php";
	private static final String KICK_USER_URL = "modules/chatrooms/chatrooms.php?action=kickUser";
	private static final String BAN_USER_URL = "modules/chatrooms/chatrooms.php?action=banUser";
	private static final String GET_ID = "cometchat_getid.php";
	private static final String CREATE_CHATROOM_URL = "modules/chatrooms/chatrooms.php?action=createchatroom";
	private static final String BLOCKUSER_URL = "plugins/block/index.php?action=block";
	private static final String UNBLOCKUSER_URL = "plugins/block/index.php?action=unblock";
	private static final String GET_BLOCKED_USER_URL = "plugins/block/index.php";
	private static final String DELETE_USER_HISTORY_URL = "cometchat_delete.php";
	private static final String ANNOUNCEMENT_URL = "modules/announcements/index.php";
	private static final String GOOGLE_TRANSLATE_URL = "https://www.googleapis.com/language/translate/v2";
	private static final String DELETE_CHATROOM_URL = "modules/chatrooms/chatrooms.php?action=deletechatroom";
	private static final String BROADCAST_MESSAGE_URL = "modules/broadcastmessage/index.php?action=sendbroadcast";
	private static final String AUDIO_CHAT_URL = "plugins/audiochat/index.php";
	private static final String AVBROADCAST_URL = "plugins/broadcast/index.php";
	private static final String AVBROADCAST_INVITE_URL = "plugins/broadcast/invite.php?action=inviteusers";
	private static final String SEND_STICKER_URL = "plugins/stickers/index.php?action=sendSticker";

	private static final String USERMANAGEMENT_URL = "api/index.php";

	public static class CloudURLS {

		public static final String COD_URL = ".cometondemand.net/";
		public static final String COD_LOGIN_URL = "api/app_login";
		public static final String CREATE_USER = "api/createuser";
		public static final String REMOVE_USER = "api/removeuser";
		public static final String UPDATE_USER = "api/updateuser";
		public static final String ADD_FRIENDS = "api/addfriend";
		public static final String REMOVE_FRIENDS = "api/removefriend";

		public static String getLoginURL() {
			return getBaseURL() + COD_LOGIN_URL;
		}

		public static String getCreateUserURL() {
			return getBaseURL() + CREATE_USER;
		}

		public static String getRemoveUserURL() {
			return getBaseURL() + REMOVE_USER;
		}

		public static String getUpdateUserURL() {
			return getBaseURL() + UPDATE_USER;
		}

		public static String getAddFriendsURL() {
			return getBaseURL() + ADD_FRIENDS;
		}

		public static String getRemoveFriendsURL() {
			return getBaseURL() + REMOVE_FRIENDS;
		}
	}

	/* Get base url based on preferences */
	public static String getBaseURL() {

		String cometChatURL = "";
		if (TextUtils.isEmpty(SITE_URL)) {
			/* Default application */
			if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGIN_SITE_URL)) {
				cometChatURL = PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGIN_SITE_URL);
				if (!(cometChatURL.contains(PROTOCOL_PREFIX) || cometChatURL.contains(PROTOCOL_PREFIX_SECURE))) {
					cometChatURL = PROTOCOL_PREFIX + cometChatURL;
				}
			}
			return cometChatURL;
		} else {
			/* White labeling */
			if (!(SITE_URL.contains(PROTOCOL_PREFIX) || SITE_URL.contains(PROTOCOL_PREFIX_SECURE))) {
				return URLFactory.PROTOCOL_PREFIX + SITE_URL;
			}
			return SITE_URL;
		}
	}

	/* Returns the final foldername in which CometChat is installed */
	private static String getCometChatFolder() {
		if (!PreferenceHelper.contains(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER)) {
			PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER, StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
		}
		return PreferenceHelper.get(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER);
	}

	public static String getWebsiteURL() {
		String host = "";
		try {
			URL url = new URL(getBaseURL());
			host = url.getProtocol() + "://" + url.getHost();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return host;
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
		if (!getBaseURL().endsWith("/")) {
			return getBaseURL() + "/" + getCometChatFolder();
		}
		return getBaseURL() + getCometChatFolder();

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

	public static String getChatroomHeartbeatUrl() {
		return getCometChatURL() + CHATROOM_HEARTBEAT_URL;
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

	public static String getBanUserURL() {
		return getCometChatURL() + BAN_USER_URL;
	}

	public static String getInfoFromId() {
		return getCometChatURL() + GET_ID;
	}

	public static String getCreateChatroomURL() {
		return getCometChatURL() + CREATE_CHATROOM_URL;
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

	public static String getDeleteUserHistoryURL() {
		return getCometChatURL() + DELETE_USER_HISTORY_URL;
	}

	public static String getAnnouncementUrl() {
		return getCometChatURL() + ANNOUNCEMENT_URL;
	}

	public static String getCodLoginUrl() {
		return CloudURLS.COD_URL + CloudURLS.COD_LOGIN_URL;
	}

	public static String getCodUrl() {
		return CloudURLS.COD_URL;
	}

	public static void buildBaseCodUrl() throws IllegalArgumentException {
		// 10108xbe8e430df890202085ea36a364745175
		if (PreferenceHelper.contains(PreferenceKeys.DataKeys.API_KEY)) {
			String apikey = PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY);
			if (apikey.contains("x")) {
				apikey = apikey.substring(0, apikey.indexOf("x"));
				if (TextUtils.isDigitsOnly(apikey) && apikey.length() > 2) {
					PreferenceHelper.save(PreferenceKeys.DataKeys.COD_ID, apikey);
					PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_SITE_URL,
							"http://" + apikey + URLFactory.getCodUrl());
				} else {
					throw new IllegalArgumentException("Invalid APIkey");
				}
			} else {
				throw new IllegalArgumentException("Invalid APIkey");
			}
		}
	}

	public static String getGoogleTranslateURL() {
		return GOOGLE_TRANSLATE_URL;
	}

	public static String deleteChatroomUrl() {
		return getCometChatURL() + DELETE_CHATROOM_URL;
	}

	public static String getBroadCastMessageURL() {
		return getCometChatURL() + BROADCAST_MESSAGE_URL;
	}

	public static String getAudioChatURL() {
		return getCometChatURL() + AUDIO_CHAT_URL;
	}

	public static String getCCUserManagementURL() {
		return getCometChatURL() + USERMANAGEMENT_URL;
	}

	public static String getAVbroadcastUrl() {
		return getCometChatURL() + AVBROADCAST_URL;
	}

	public static String getAVBroadcastInviteUrl() {
		return getCometChatURL() + AVBROADCAST_INVITE_URL;
	}

	public static String getSendStickerURL() {
		return getCometChatURL() + SEND_STICKER_URL;
	}
}
