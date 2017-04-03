/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
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
    @SerializedName("share_this_app")
    @Expose
    private String shareThisApp;
    @SerializedName("history_message_limit")
    @Expose
    private String historyMessageLimit;
    @SerializedName("rtt_key")
    @Expose
    private String rttKey;

    @SerializedName("broadcastmessage_enabled")
    @Expose
    private String broadcastMessageEnabled;
    @SerializedName("avbroadcast_enabled")
    @Expose
    private String avBroadcastEnabled;
    @SerializedName("avconference_enabled")
    @Expose
    private String avConferenceEnabled;
    @SerializedName("stickers_enabled")
    @Expose
    private String stickersEnabled;
    @SerializedName("cravbroadcast_enabled")
    @Expose
    private String cravbroadcastEnabled;
    @SerializedName("last_seen_enabled")
    @Expose
    private String lastseenEnabled;
    @SerializedName("typing_enabled")
    @Expose
    private String typingEnabled;
    @SerializedName("receipts_enabled")
    @Expose
    private String receiptsEnabled;
    @SerializedName("whiteboard_enabled")
    @Expose
    private String whiteboardEnabled;
    @SerializedName("whiteboard_url")
    @Expose
    private String whiteboardUrl;

    @SerializedName("crwhiteboard_enabled")
    @Expose
    private String crwhiteboardEnabled;

    @SerializedName("single_games_enabled")
    @Expose
    private String singleGamesEnabled;

    @SerializedName("crhideusercount")
    @Expose
    private String crHideUserCount;

    @SerializedName("writeboard_enabled")
    @Expose
    private String writeboardEnabled;

    @SerializedName("crwriteboard_enabled")
    @Expose
    private String crWriteboardEnabled;

    @SerializedName("handwrite_enabled")
    @Expose
    private String handwriteEnabled;



    @SerializedName("crhandwrite_enabled")
    @Expose
    private String crhandwriteEnabled;


    @SerializedName("crpersonal_chat")
    @Expose
    private String crpersonalchatEnabled;

    @SerializedName("crstyles")
    @Expose
    private Crstyles crstyles;


    @SerializedName("bots_enabled")
    @Expose
    private int botsEnabled;

    public int getBotsEnabled(){
        return botsEnabled;
    }

    public Crstyles getCrstyles() {
        return crstyles;
    }

    /**
     * @return The fullName
     */
    public String getFullName() {
        return fullName;
    }


    /**
     * @return The messageBeep
     */
    public String getMessageBeep() {
        return messageBeep;
    }


    /**
     * @return The beepOnAllMessages
     */
    public String getBeepOnAllMessages() {
        return beepOnAllMessages;
    }

    /**
     * @return The idleTimeout
     */
    public String getIdleTimeout() {
        return idleTimeout;
    }

    public String getCrhandwriteEnabled() {
        return crhandwriteEnabled;
    }


    /**
     * @return The armyTime
     */
    public String getArmyTime() {
        return armyTime;
    }

    public String getHandwriteUrl() {
        return handwriteEnabled;
    }


    /**
     * @return The DISPLAYALLUSERS
     */
    public String getDISPLAYALLUSERS() {
        return DISPLAYALLUSERS;
    }


    /**
     * @return The REFRESHBUDDYLIST
     */
    public String getREFRESHBUDDYLIST() {
        return REFRESHBUDDYLIST;
    }


    /**
     * @return The USECOMET
     */
    public String getUSECOMET() {
        return USECOMET;
    }


    /**
     * @return The minHeartbeat
     */
    public String getMinHeartbeat() {
        return minHeartbeat;
    }

    /**
     * @return The maxHeartbeat
     */
    public String getMaxHeartbeat() {
        return maxHeartbeat;
    }


    /**
     * @return The KEYA
     */
    public String getKEYA() {
        return KEYA;
    }


    /**
     * @return The KEYB
     */
    public String getKEYB() {
        return KEYB;
    }


    /**
     * @return The KEYC
     */
    public String getKEYC() {
        return KEYC;
    }


    /**
     * @return The TRANSPORT
     */
    public String getTRANSPORT() {
        return TRANSPORT;
    }


    /**
     * @return The COMETCHATROOMS
     */
    public String getCOMETCHATROOMS() {
        return COMETCHATROOMS;
    }


    /**
     * @return The homepageURL
     */
    public String getHomepageURL() {
        return homepageURL;
    }


    /**
     * @return The oneononeEnabled
     */
    public String getOneononeEnabled() {
        return oneononeEnabled;
    }


    /**
     * @return The announcementEnabled
     */
    public String getAnnouncementEnabled() {
        return announcementEnabled;
    }


    /**
     * @return The inviteViaSms
     */
    public String getInviteViaSms() {
        return inviteViaSms;
    }


    /**
     * @return The historyMessageLimit
     */
    public String getHistoryMessageLimit() {
        return historyMessageLimit;
    }


    /**
     * @return The rttKey
     */
    public String getRttKey() {
        return rttKey;
    }

    public String getShareThisApp() {
        return shareThisApp;
    }

    public String getBroadcastMessageEnabled() {
        return broadcastMessageEnabled;
    }

    public String getStickersEnabled() {
        return stickersEnabled;
    }

    public String getAvConferenceEnabled() {
        return avConferenceEnabled;
    }

    public String getAvBroadcastEnabled() {
        return avBroadcastEnabled;
    }


    public String getCravbroadcastEnabled() {
        return cravbroadcastEnabled;
    }

    public String getlastseenEnabled() {
        return lastseenEnabled;
    }


    public String gettypingEnabled() {
        return typingEnabled;
    }

    public String getreceiptsEnabled() {
        return receiptsEnabled;
    }


    public String getWhiteboardEnabled() {
        return whiteboardEnabled;
    }

    public String getCrWhiteboardEnabled() {
        return crwhiteboardEnabled;
    }

    public String getWhiteboardUrl() {
        return whiteboardUrl;
    }


    public String getSingleGamesEnabled() {
        return singleGamesEnabled;
    }

    public String getCrHideUserCount() {
        return crHideUserCount;
    }


    public String getWriteboardEnabled() {
        return writeboardEnabled;
    }

    public String getCrWriteboardEnabled() {
        return crWriteboardEnabled;
    }

    public String getCrpersonalchatEnabled() {

        return crpersonalchatEnabled;
    }

}