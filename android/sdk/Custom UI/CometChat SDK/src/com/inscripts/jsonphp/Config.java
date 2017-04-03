package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Config {

	@Expose
	private String fullName;
	@Expose
	private String messageBeep;
	@Expose
	private String beepOnAllMessages;
	@Expose
	private String vibrate;
	@Expose
	private String idleTimeout;
	@Expose
	private String armyTime;
	@SerializedName("DISPLAY_ALL_USERS")
	@Expose
	private String DISPLAYALLUSERS;
	@SerializedName("REFRESH_BUDDYLIST")
	@Expose
	private String REFRESHBUDDYLIST;
	@SerializedName("USE_COMET")
	@Expose
	private String USECOMET;
	@Expose
	private String minHeartbeat;
	@Expose
	private String maxHeartbeat;
	@SerializedName("KEY_A")
	@Expose
	private String KEYA;
	@SerializedName("KEY_B")
	@Expose
	private String KEYB;
	@SerializedName("KEY_C")
	@Expose
	private String KEYC;
	@Expose
	private String TRANSPORT;
	@SerializedName("COMET_CHATROOMS")
	@Expose
	private String COMETCHATROOMS;
	@SerializedName("homepage_URL")
	@Expose
	private String homepageURL;
	@SerializedName("oneonone_enabled")
	@Expose
	private String oneononeEnabled;
	@SerializedName("announcement_enabled")
	@Expose
	private String announcementEnabled;
	@SerializedName("invite_via_sms")
	@Expose
	private String inviteViaSms;
	@SerializedName("history_message_limit")
	@Expose
	private String historyMessageLimit;
	@SerializedName("rtt_key")
	@Expose
	private String rttKey;
	@SerializedName("broadcastmessage_enabled")
	@Expose
	private String broadcastMessageEnabled;
	@SerializedName("stickers_enabled")
    @Expose
    private String stickersEnabled;
	@SerializedName("typing_enabled")
	@Expose
	private String typingEnabled;
	@SerializedName("avbroadcast_enabled")
	@Expose
	private String avBroadcastEnabled;
	@SerializedName("cravbroadcast_enabled")
	@Expose
	private String cravbroadcastEnabled;

	/**
	 * 
	 * @return The fullName
	 */
	public String getFullName() {
		return fullName;
	}

	/**
	 * 
	 * @param fullName
	 *            The fullName
	 */
	public void setFullName(String fullName) {
		this.fullName = fullName;
	}

	/**
	 * 
	 * @return The messageBeep
	 */
	public String getMessageBeep() {
		return messageBeep;
	}

	/**
	 * 
	 * @param messageBeep
	 *            The messageBeep
	 */
	public void setMessageBeep(String messageBeep) {
		this.messageBeep = messageBeep;
	}

	/**
	 * 
	 * @return The beepOnAllMessages
	 */
	public String getBeepOnAllMessages() {
		return beepOnAllMessages;
	}

	/**
	 * 
	 * @param beepOnAllMessages
	 *            The beepOnAllMessages
	 */
	public void setBeepOnAllMessages(String beepOnAllMessages) {
		this.beepOnAllMessages = beepOnAllMessages;
	}

	/**
	 * 
	 * @return The vibrate
	 */
	public String getVibrate() {
		return vibrate;
	}

	/**
	 * 
	 * @param vibrate
	 *            The vibrate
	 */
	public void setVibrate(String vibrate) {
		this.vibrate = vibrate;
	}

	/**
	 * 
	 * @return The idleTimeout
	 */
	public String getIdleTimeout() {
		return idleTimeout;
	}

	/**
	 * 
	 * @param idleTimeout
	 *            The idleTimeout
	 */
	public void setIdleTimeout(String idleTimeout) {
		this.idleTimeout = idleTimeout;
	}

	/**
	 * 
	 * @return The armyTime
	 */
	public String getArmyTime() {
		return armyTime;
	}

	/**
	 * 
	 * @param armyTime
	 *            The armyTime
	 */
	public void setArmyTime(String armyTime) {
		this.armyTime = armyTime;
	}

	/**
	 * 
	 * @return The DISPLAYALLUSERS
	 */
	public String getDISPLAYALLUSERS() {
		return DISPLAYALLUSERS;
	}

	/**
	 * 
	 * @param DISPLAYALLUSERS
	 *            The DISPLAY_ALL_USERS
	 */
	public void setDISPLAYALLUSERS(String DISPLAYALLUSERS) {
		this.DISPLAYALLUSERS = DISPLAYALLUSERS;
	}

	/**
	 * 
	 * @return The REFRESHBUDDYLIST
	 */
	public String getREFRESHBUDDYLIST() {
		return REFRESHBUDDYLIST;
	}

	/**
	 * 
	 * @param REFRESHBUDDYLIST
	 *            The REFRESH_BUDDYLIST
	 */
	public void setREFRESHBUDDYLIST(String REFRESHBUDDYLIST) {
		this.REFRESHBUDDYLIST = REFRESHBUDDYLIST;
	}

	/**
	 * 
	 * @return The USECOMET
	 */
	public String getUSECOMET() {
		return USECOMET;
	}

	/**
	 * 
	 * @param USECOMET
	 *            The USE_COMET
	 */
	public void setUSECOMET(String USECOMET) {
		this.USECOMET = USECOMET;
	}

	/**
	 * 
	 * @return The minHeartbeat
	 */
	public String getMinHeartbeat() {
		return minHeartbeat;
	}

	/**
	 * 
	 * @param minHeartbeat
	 *            The minHeartbeat
	 */
	public void setMinHeartbeat(String minHeartbeat) {
		this.minHeartbeat = minHeartbeat;
	}

	/**
	 * 
	 * @return The maxHeartbeat
	 */
	public String getMaxHeartbeat() {
		return maxHeartbeat;
	}

	/**
	 * 
	 * @param maxHeartbeat
	 *            The maxHeartbeat
	 */
	public void setMaxHeartbeat(String maxHeartbeat) {
		this.maxHeartbeat = maxHeartbeat;
	}

	/**
	 * 
	 * @return The KEYA
	 */
	public String getKEYA() {
		return KEYA;
	}

	/**
	 * 
	 * @param KEYA
	 *            The KEY_A
	 */
	public void setKEYA(String KEYA) {
		this.KEYA = KEYA;
	}

	/**
	 * 
	 * @return The KEYB
	 */
	public String getKEYB() {
		return KEYB;
	}

	/**
	 * 
	 * @param KEYB
	 *            The KEY_B
	 */
	public void setKEYB(String KEYB) {
		this.KEYB = KEYB;
	}

	/**
	 * 
	 * @return The KEYC
	 */
	public String getKEYC() {
		return KEYC;
	}

	/**
	 * 
	 * @param KEYC
	 *            The KEY_C
	 */
	public void setKEYC(String KEYC) {
		this.KEYC = KEYC;
	}

	/**
	 * 
	 * @return The TRANSPORT
	 */
	public String getTRANSPORT() {
		return TRANSPORT;
	}

	/**
	 * 
	 * @param TRANSPORT
	 *            The TRANSPORT
	 */
	public void setTRANSPORT(String TRANSPORT) {
		this.TRANSPORT = TRANSPORT;
	}

	/**
	 * 
	 * @return The COMETCHATROOMS
	 */
	public String getCOMETCHATROOMS() {
		return COMETCHATROOMS;
	}

	/**
	 * 
	 * @param COMETCHATROOMS
	 *            The COMET_CHATROOMS
	 */
	public void setCOMETCHATROOMS(String COMETCHATROOMS) {
		this.COMETCHATROOMS = COMETCHATROOMS;
	}

	/**
	 * 
	 * @return The homepageURL
	 */
	public String getHomepageURL() {
		return homepageURL;
	}

	/**
	 * 
	 * @param homepageURL
	 *            The homepage_URL
	 */
	public void setHomepageURL(String homepageURL) {
		this.homepageURL = homepageURL;
	}

	/**
	 * 
	 * @return The oneononeEnabled
	 */
	public String getOneononeEnabled() {
		return oneononeEnabled;
	}
	public String getStickersEnabled() {
        return stickersEnabled;
    }

	/**
	 * 
	 * @param oneononeEnabled
	 *            The oneonone_enabled
	 */
	public void setOneononeEnabled(String oneononeEnabled) {
		this.oneononeEnabled = oneononeEnabled;
	}

	/**
	 * 
	 * @return The announcementEnabled
	 */
	public String getAnnouncementEnabled() {
		return announcementEnabled;
	}

	/**
	 * 
	 * @param announcementEnabled
	 *            The announcement_enabled
	 */
	public void setAnnouncementEnabled(String announcementEnabled) {
		this.announcementEnabled = announcementEnabled;
	}

	/**
	 * 
	 * @return The inviteViaSms
	 */
	public String getInviteViaSms() {
		return inviteViaSms;
	}

	/**
	 * 
	 * @param inviteViaSms
	 *            The invite_via_sms
	 */
	public void setInviteViaSms(String inviteViaSms) {
		this.inviteViaSms = inviteViaSms;
	}

	/**
	 * 
	 * @return The historyMessageLimit
	 */
	public String getHistoryMessageLimit() {
		return historyMessageLimit;
	}

	/**
	 * 
	 * @param historyMessageLimit
	 *            The history_message_limit
	 */
	public void setHistoryMessageLimit(String historyMessageLimit) {
		this.historyMessageLimit = historyMessageLimit;
	}

	/**
	 * 
	 * @return The rttKey
	 */
	public String getRttKey() {
		return rttKey;
	}

	/**
	 * 
	 * @param rttKey
	 *            The rtt_key
	 */
	public void setRttKey(String rttKey) {
		this.rttKey = rttKey;
	}

	public String getBroadcastMessageEnabled() {
		return broadcastMessageEnabled;
	}

	public void setBroadcastMessageEnabled(String broadcastMessageEnabled) {
		this.broadcastMessageEnabled = broadcastMessageEnabled;
	}

	public String gettypingEnabled() {
		return typingEnabled;
	}

	public void settypingEnabled(String typingEnabled) {
		this.typingEnabled = typingEnabled;
	}

	public String getAvBroadcastEnabled() {
		return avBroadcastEnabled;
	}

	public void setAvBroadcastEnabled(String avBroadcastEnabled) {
		this.avBroadcastEnabled = avBroadcastEnabled;
	}

	public String getCravbroadcastEnabled() {
		return cravbroadcastEnabled;
	}

	public void setCravbroadcastEnabled(String cravbroadcastEnabled) {
		this.cravbroadcastEnabled = cravbroadcastEnabled;
	}

}