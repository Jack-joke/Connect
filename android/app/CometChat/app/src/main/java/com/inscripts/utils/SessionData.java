/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.pojos.User;

import org.json.JSONObject;

public class SessionData extends User {

    private static SessionData sessionData = null;
    private String baseData = "", userInfoHeartBeatFlag, chatroomHeartBeatTimestamp, chatroomMemberListHash, currentChatroomPassword,
            topFragment, cometID, currentChatroomName, singleChatParseChannel, chatroomParseChannel, chatroomCometId,
            annParseChannel, serverTime = "", isModerator = "";
    private int oneOnOneHeartBeatIdealCount = 1, chatroomHeartbeatIdealCount = 1, avchatStatus = 0;
    private long AVChatCallStartTime, oneOnOneHeartBeatTimestamp, oneOnOneHeartbeatInterval, chatroomHeartbeatInterval,
            currentChatroom;
    private boolean vibrateOn, mediaPlayerOn, oneToOneBroadCastMissed, initialHeartbeat, chatroomBroadcastMissed,
            buddyListBroadcastMissed, chatroomListBroadcastMissed, announcementListBroadcastMissed, isCometOnDemand,chatbadgeMissed;



    private boolean isCall;

    public String getServerTime() {
        return serverTime;
    }

    public void setServerTime(String serverTime) {
        this.serverTime = serverTime;
    }


    public boolean isCometOnDemand() {
        return isCometOnDemand;
    }

    public void setIsCometOnDemand(boolean isCometOnDemand) {
        this.isCometOnDemand = isCometOnDemand;
    }

    /**
     * @return Your Channel id which is used for subscribing channel in
     * cometservice
     */
    public String getCometID() {
        return cometID;
    }

    /**
     * @param cometID your channel id for cometservice used for subscribing
     */
    public void setCometID(String cometID) {
        this.cometID = cometID;
    }

    /**
     * @return the topFragment
     */
    public String getTopFragment() {
        return topFragment;
    }

    /**
     * @param topFragment the topFragment to set
     */
    public void setTopFragment(String topFragment) {
        this.topFragment = topFragment;
    }

    public static SessionData getInstance() {
        if (null == sessionData) {
            sessionData = new SessionData();
        }
        return sessionData;
    }

    public static void setInstance(SessionData sessionData) {
        SessionData.sessionData = sessionData;
    }

    public boolean isCall() {
        return isCall;
    }

    public void setCall(boolean call) {
        isCall = call;
    }

    /**
     * @return the baseData
     */
    public String getBaseData() {
        return baseData;
    }

    /**
     * @param baseData the baseData to set
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
     * @param userInfoHeartBeatFlag the userDataInitialize to set
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
     * @param oneOnOneHeartBeatTimestamp the initializeOneOnOne to set
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
     * @param chatroomHeartBeatTimestamp the initializeChatroom to set
     */
    public void setChatroomHeartBeatTimestamp(String chatroomHeartBeatTimestamp) {
        this.chatroomHeartBeatTimestamp = chatroomHeartBeatTimestamp;
    }

    /**
     * @return the buddyListHashChatroom
     */
    /*public String getChatroomMemberListHash() {
        return chatroomMemberListHash;
    }*/

    /**
     * @param chatroomMemberListHash the buddyListHashChatroom to set
     */
    public void setChatroomMemberListHash(String chatroomMemberListHash) {
        this.chatroomMemberListHash = chatroomMemberListHash;
    }

    /**
     * @return the currentChatroom
     */
    public long getCurrentChatroom() {
        return currentChatroom;
    }

    /**
     * @param currentChatroom the currentChatroom to set
     */
    public void setCurrentChatroom(long currentChatroom) {
        this.currentChatroom = currentChatroom;
    }

    /**
     * @return the currentChatroomPassword
     */
    public String getCurrentChatroomPassword() {
        return currentChatroomPassword;
    }

    /**
     * @param currentChatroomPassword the currentChatroomPassword to set
     */
    public void setCurrentChatroomPassword(String currentChatroomPassword) {
        this.currentChatroomPassword = currentChatroomPassword;
    }

    public void update(JSONObject userDetails) {
        try {
            setId(userDetails.getLong("id"));
            setName(userDetails.getString("n"));
            setLink(userDetails.getString("l"));
            setAvatarLink(userDetails.getString("a"));
            setStatus(userDetails.getString("s"));
            setStatusMessage(userDetails.getString("m"));
            if(userDetails.has("push_channel")) {
                Logger.error("Push chanel value = "+ userDetails.getString("push_channel"));
                setParseChannel(userDetails.getString("push_channel"));
            }
            if (userDetails.has("push_an_channel")) {
                setAnnParseChannel(userDetails.getString("push_an_channel"));
            }
            PreferenceHelper.save(PreferenceKeys.UserKeys.USER_ID, getId());
            PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, getStatus());
        } catch (Exception e) {
            Logger.error("Cannot update UserData: " + e.getMessage());
        }
    }

    /**
     * @return Timestamp value when call started
     */
    public long getAVChatCallStartTime() {
        return AVChatCallStartTime;
    }

    /**
     * @param aVChatCallStartTime Set timestamp value when call started
     */
    public void setAVChatCallStartTime(long aVChatCallStartTime) {
        AVChatCallStartTime = aVChatCallStartTime;
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

    public boolean isVibrateOn() {
        return vibrateOn;
    }

    public void setVibrateOn(boolean vibrateStatus) {
        this.vibrateOn = vibrateStatus;
    }

    public boolean isMediaPlayerOn() {
        return mediaPlayerOn;
    }

    public void setMediaPlayerOn(boolean mediaPlayerStatus) {
        this.mediaPlayerOn = mediaPlayerStatus;
    }

    public boolean isOneToOneBroadCastMissed() {
        return oneToOneBroadCastMissed;
    }

    public void setOneToOneBroadCastMissed(boolean broadCastMissed) {
        this.oneToOneBroadCastMissed = broadCastMissed;
    }

    public boolean isInitialHeartbeat() {
        return initialHeartbeat;
    }

    public void setInitialHeartbeat(boolean initialHeartbeat) {
        Thread.dumpStack();
        this.initialHeartbeat = initialHeartbeat;
    }

    public int getAvchatStatus() {
        return avchatStatus;
    }

    /**
     * Set avchat status
     *
     * @param avchatStatus <br>
     *                     set 1 for "Incoming call" <br>
     *                     set 2 for "Outgoing call" <br>
     *                     set 3 for "Video chat" <br>
     *                     set 0 to reset the status
     */
    public void setAvchatStatus(int avchatStatus) {
        this.avchatStatus = avchatStatus;
    }

    public String getParseChannel() {
        return singleChatParseChannel;
    }

    public void setParseChannel(String parseChannel) {
        this.singleChatParseChannel = parseChannel;
    }

    public String getChatroomParseChannel() {
        return chatroomParseChannel;
    }

    public void setChatroomParseChannel(String chatroomParseChannel) {
        this.chatroomParseChannel = chatroomParseChannel;
    }

    public String getChatroomCometId() {
        return chatroomCometId;
    }

    public void setChatroomCometId(String chatroomCometId) {
        this.chatroomCometId = chatroomCometId;
    }

    public boolean isChatroomBroadcastMissed() {
        return chatroomBroadcastMissed;
    }

    public void setChatroomBroadcastMissed(boolean chatroomBroadcastMissed) {
        this.chatroomBroadcastMissed = chatroomBroadcastMissed;
    }

    public boolean isBuddyListBroadcastMissed() {
        return buddyListBroadcastMissed;
    }

    public void setBuddyListBroadcastMissed(boolean buddyListBroadcastMissed) {
        this.buddyListBroadcastMissed = buddyListBroadcastMissed;
    }

    public boolean isChatroomListBroadcastMissed() {
        return chatroomListBroadcastMissed;
    }

    public void setChatroomListBroadcastMissed(boolean chatroomListBroadcastMissed) {
        this.chatroomListBroadcastMissed = chatroomListBroadcastMissed;
    }

    public boolean isAnnouncementListBroadcastMissed() {
        return announcementListBroadcastMissed;
    }

    public void setAnnouncementListBroadcastMissed(boolean announcementListBroadcastMissed) {
        this.announcementListBroadcastMissed = announcementListBroadcastMissed;
    }

    public String getAnnParseChannel() {
        return annParseChannel;
    }

    public void setAnnParseChannel(String annParseChannel) {
        this.annParseChannel = annParseChannel;
    }

    public boolean isChatbadgeMissed() {
        return chatbadgeMissed;
    }

    public void setChatbadgeMissed(boolean chatbadgeMissed) {
        this.chatbadgeMissed = chatbadgeMissed;
    }

    public String getIsModerator() {
        return isModerator;
    }

    public void setIsModerator(String isModerator) {
        this.isModerator = isModerator;
    }
}
