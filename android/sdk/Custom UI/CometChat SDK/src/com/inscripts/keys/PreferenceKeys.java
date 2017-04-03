package com.inscripts.keys;

public class PreferenceKeys {

	/**
	 * Keys used to set preferences of Login details
	 * */
	public static class LoginKeys {

		public static final String LOGIN_SITE_URL = "SDK_BASE_URL";
		public static final String LOGIN_NAME = "SDK_USERNAME";
		public static final String COMETCHAT_FOLDER = "SDK_COMETCHAT_FOLDER";
		public static final String LOGIN_PASSWORD = "SDK_PASSWORD";
		public static final String LOGGED_IN = "SDK_LOGGED_IN";
		public static final String OLD_LOGIN_URL = "SDK_OLD_LOGIN_URL";
		public static final String LOGGED_IN_AS_GUEST = "LOGGED_IN_AS_GUEST";
		public static final String LOGGED_IN_AS_COD = "LOGGED_IN_AS_COD";
	}

	/**
	 * Keys used to set preferences of data coming from initial Ajax call
	 * requests
	 * */
	public static class DataKeys {
		public static final String BASE_DATA = "SDK_BASE_DATA";
		public static final String JSON_PHP_DATA = "SDK_JSON_PHP_DATA";
		public static final String JSON_CHATROOM_MEMBERS = "SDK_CHATROOM_MEMBERS";

		/**
		 * Stores the current id to which you are chatting
		 */
		public static final String ACTIVE_BUDDY_ID = "SDK_ACTIVE_BUDDY_ID";
		public static final String ACTIVE_CHATROOM_ID = "SDK_ACTIVE_CHATROOM_ID";
		public static final String CURRENT_CHATROOM_ID = "SDK_CURRENT_CHATROOM_ID";
		public static final String CURRENT_CHATROOM_PASSWORD = "SDK_CURRENT_CHATROOM_PASSWORD";
		public static final String LAST_START_INDEX_PUBNUB = "SDK_LAST_START_INDEX_PUBNUB";
		public static final String DEVELOPMENT_MODE = "SDK_DEVELOPMENT_MODE";
		public static final String COD_ID = "SDK_COD_ID";
		public static final String API_KEY = "COD_API_KEY";
		public static final String SELECTED_LANGUAGE = "SELECTED_LANGUAGE";
	}

	/**
	 * Keys used to set preferences of Hashes
	 * */
	public static class HashKeys {
		public static final String CHATROOM_MEMBERS_HASH = "SDK_USER_LIST_HASH";
		public static final String CHATROOM_LIST_HASH = "SDK_CHATROOM_LIST_HASH";
		public static final String BUDDY_LIST_HASH = "SDK_BUDDY_LIST_HASH";
	}

	public static class UserKeys {
		public static final String USER_ID = "SDK_USERID";
		public static final String FIRST_NAME = "SDK_FIRST_NAME";
		public static final String LAST_NAME = "SDK_LAST_NAME";
		public static final String STATUS = "SDK_STATUS";
		public static final String WEBRTC_PREFIX = "SDK_WEBRTC_CHANNEL";
	}

}