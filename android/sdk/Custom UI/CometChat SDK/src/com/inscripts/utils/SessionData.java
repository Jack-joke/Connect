package com.inscripts.utils;

import org.json.JSONObject;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.pojos.User;

public class SessionData extends User {

	private static SessionData sessionData = null;
	private String baseData, userInfoHeartBeatFlag, chatroomHeartBeatTimestamp, chatroomMemberListHash,
			chatroomListHash, currentChatroomPassword, cometID, currentChatroomName, currentChatroom = "0",
			avChatRoomName, activeAVchatUserID = "";

	private int oneOnOneHeartBeatIdealCount = 1, chatroomHeartbeatIdealCount = 1;
	private long oneOnOneHeartBeatTimestamp, oneOnOneHeartbeatInterval, chatroomHeartbeatInterval;
	private boolean initialHeartbeat, avchatCallRunning = false;

	/**
	 * @return Your Channel id which is used for subscribing channel in
	 *         cometservice
	 */
	public String getCometID() {
		return cometID;
	}

	/**
	 * @param Set
	 *            your channel id for cometservice used for subscribing
	 */
	public void setCometID(String cometID) {
		this.cometID = cometID;
	}

	public static SessionData getInstance() {
		if (null == sessionData) {
			sessionData = new SessionData();
		}
		return sessionData;
	}

	/**
	 * @return the baseData
	 */
	public String getBaseData() {
		return baseData;
	}

	/**
	 * @param baseData
	 *            the baseData to set
	 */
	public void setBaseData(String baseData) {
		this.baseData = baseData;
	}

	/**
	 * @return the userDataInitialize
	 */
	public String getUserInfoHeartBeatFlag() {
		return userInfoHeartBeatFlag;
	}

	/**
	 * @param userInfoHeartBeatFlag
	 *            the userDataInitialize to set
	 */
	public void setUserInfoHeartBeatFlag(String userInfoHeartBeatFlag) {
		this.userInfoHeartBeatFlag = userInfoHeartBeatFlag;
	}

	/**
	 * @return the initializeOneOnOne
	 */
	public Long getOneOnOneHeartBeatTimestamp() {
		return oneOnOneHeartBeatTimestamp;
	}

	/**
	 * @param oneOnOneHeartBeatTimestamp
	 *            the initializeOneOnOne to set
	 */
	public void setOneOnOneHeartBeatTimestamp(Long oneOnOneHeartBeatTimestamp) {
		this.oneOnOneHeartBeatTimestamp = oneOnOneHeartBeatTimestamp;
	}

	/**
	 * @return the initializeChatroom
	 */
	public String getChatroomHeartBeatTimestamp() {
		return chatroomHeartBeatTimestamp;
	}

	/**
	 * @param chatroomHeartBeatTimestamp
	 *            the initializeChatroom to set
	 */
	public void setChatroomHeartBeatTimestamp(String chatroomHeartBeatTimestamp) {
		this.chatroomHeartBeatTimestamp = chatroomHeartBeatTimestamp;
	}

	/**
	 * @return the buddyListHashChatroom
	 */
	public String getChatroomMemberListHash() {
		return chatroomMemberListHash;
	}

	/**
	 * @param chatroomMemberListHash
	 *            the buddyListHashChatroom to set
	 */
	public void setChatroomMemberListHash(String chatroomMemberListHash) {
		this.chatroomMemberListHash = chatroomMemberListHash;
	}

	/**
	 * @return the currentChatroomPassword
	 */
	public String getCurrentChatroomPassword() {
		return currentChatroomPassword;
	}

	/**
	 * @param currentChatroomPassword
	 *            the currentChatroomPassword to set
	 */
	public void setCurrentChatroomPassword(String currentChatroomPassword) {
		this.currentChatroomPassword = currentChatroomPassword;
	}

	public void update(JSONObject userDetails) {
		try {
			if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.USER_ID)) {
				PreferenceHelper.save(PreferenceKeys.UserKeys.USER_ID, userDetails.getInt("id"));
			}
			setId(Integer.parseInt(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_ID)));
			if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.FIRST_NAME)) {
				PreferenceHelper.save(PreferenceKeys.UserKeys.FIRST_NAME, userDetails.getString("n"));
			}
			setFirstName(PreferenceHelper.get(PreferenceKeys.UserKeys.FIRST_NAME));
			if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.LAST_NAME)) {
				PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_NAME, userDetails.getString("l"));
			}
			setLastName(PreferenceHelper.get(PreferenceKeys.UserKeys.LAST_NAME));
			setAvatarLink(userDetails.getString("a"));
			setStatus(userDetails.getString("s"));
			setStatusMessage(userDetails.getString("m"));
		} catch (Exception e) {
			Logger.error("Cannot update UserData: " + e.getMessage());
		}
	}

	public String getCurrentChatroomName() {
		return currentChatroomName;
	}

	public void setCurrentChatroomName(String currentChatroomName) {
		this.currentChatroomName = currentChatroomName;
	}

	public int getOneOnOneHeartBeatIdealCount() {
		return oneOnOneHeartBeatIdealCount;
	}

	public void setOneOnOneHeartBeatIdealCount(int oneOnOneHeartBeatIdealCount) {
		this.oneOnOneHeartBeatIdealCount = oneOnOneHeartBeatIdealCount;
	}

	public int getChatroomHeartbeatIdealCount() {
		return chatroomHeartbeatIdealCount;
	}

	public void setChatroomHeartbeatIdealCount(int chatroomHeartbeatIdealCount) {
		this.chatroomHeartbeatIdealCount = chatroomHeartbeatIdealCount;
	}

	public long getOneOnOneHeartbeatInterval() {
		return oneOnOneHeartbeatInterval;
	}

	public void setOneOnOneHeartbeatInterval(long oneOnOneHeartbeatInterval) {
		this.oneOnOneHeartbeatInterval = oneOnOneHeartbeatInterval;
	}

	public long getChatroomHeartbeatInterval() {
		return chatroomHeartbeatInterval;
	}

	public void setChatroomHeartbeatInterval(long chatroomHeartbeatInterval) {
		this.chatroomHeartbeatInterval = chatroomHeartbeatInterval;
	}

	public boolean isInitialHeartbeat() {
		return initialHeartbeat;
	}

	public void setInitialHeartbeat(boolean initialHeartbeat) {
		this.initialHeartbeat = initialHeartbeat;
	}

	public String getCurrentChatroom() {
		return currentChatroom;
	}

	public void setCurrentChatroom(String currentChatroom) {
		this.currentChatroom = currentChatroom;
	}

	public String getChatroomListHash() {
		return chatroomListHash;
	}

	public void setChatroomListHash(String chatroomListHash) {
		this.chatroomListHash = chatroomListHash;
	}

	public String getAvChatRoomName() {
		return avChatRoomName;
	}

	public void setAvChatRoomName(String avChatRoomName) {
		this.avChatRoomName = avChatRoomName;
	}

	public String getActiveAVchatUserID() {
		return activeAVchatUserID;
	}

	public void setActiveAVchatUserID(String activeAVchatUserID) {
		this.activeAVchatUserID = activeAVchatUserID;
	}

	public boolean isAvchatCallRunning() {
		return avchatCallRunning;
	}

	public void setAvchatCallRunning(boolean avchatCallRunning) {
		this.avchatCallRunning = avchatCallRunning;
	}
}
