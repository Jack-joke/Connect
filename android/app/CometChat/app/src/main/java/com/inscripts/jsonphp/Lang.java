/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;

public class Lang {

    @Expose
    private Clearconversation clearconversation;
    @Expose
    private Report report;
    @Expose
    private Avchat avchat;
    @Expose
    private Filetransfer filetransfer;
    @Expose
    private Block block;
    @Expose
    private String rtl;
    @Expose
    private Core core;
    @Expose
    private Chatrooms chatrooms;
    @Expose
    private Mobile mobile;
    @Expose
    private Announcements announcements;
    @Expose
    private Realtimetranslate realtimetranslate;
    @Expose
    private Audiochat audiochat;
    @Expose
    private Whiteboard whiteboard;
    @Expose
    private Writeboard writeboard;
    @Expose
    private Handwrite handwrite;

    @Expose
    private Style style;

    /**
     * @return The clearconversation
     */
    public Clearconversation getClearconversation() {
        return clearconversation;
    }

    /**
     * @param clearconversation The clearconversation
     */
    public void setClearconversation(Clearconversation clearconversation) {
        this.clearconversation = clearconversation;
    }

    /**
     * @return The report
     */
    public Report getReport() {
        return report;
    }

    /**
     * @param report The report
     */
    public void setReport(Report report) {
        this.report = report;
    }

    /**
     * @return The avchat
     */
    public Avchat getAvchat() {
        return avchat;
    }

    /**
     * @param avchat The avchat
     */
    public void setAvchat(Avchat avchat) {
        this.avchat = avchat;
    }

    /**
     * @return The filetransfer
     */
    public Filetransfer getFiletransfer() {
        return filetransfer;
    }

    /**
     * @param filetransfer The filetransfer
     */
    public void setFiletransfer(Filetransfer filetransfer) {
        this.filetransfer = filetransfer;
    }

    /**
     * @return The block
     */
    public Block getBlock() {
        return block;
    }

    /**
     * @param block The block
     */
    public void setBlock(Block block) {
        this.block = block;
    }

    /**
     * @return The rtl
     */
    public String getRtl() {
        return rtl;
    }

    /**
     * @param rtl The rtl
     */
    public void setRtl(String rtl) {
        this.rtl = rtl;
    }

    /**
     * @return The core
     */
    public Core getCore() {
        return core;
    }

    /**
     * @param core The core
     */
    public void setCore(Core core) {
        this.core = core;
    }

    /**
     * @return The chatrooms
     */
    public Chatrooms getChatrooms() {
        return chatrooms;
    }

    /**
     * @param chatrooms The chatrooms
     */
    public void setChatrooms(Chatrooms chatrooms) {
        this.chatrooms = chatrooms;
    }

    /**
     * @return The mobile
     */
    public Mobile getMobile() {
        return mobile;
    }

    /**
     * @param mobile The mobile
     */
    public void setMobile(Mobile mobile) {
        this.mobile = mobile;
    }

    /**
     * @return The announcements
     */
    public Announcements getAnnouncements() {
        return announcements;
    }

    /**
     * @param announcements The announcements
     */
    public void setAnnouncements(Announcements announcements) {
        this.announcements = announcements;
    }

    /**
     * @return The realtimetranslate
     */
    public Realtimetranslate getRealtimetranslate() {
        return realtimetranslate;
    }

    /**
     * @param realtimetranslate The realtimetranslate
     */
    public void setRealtimetranslate(Realtimetranslate realtimetranslate) {
        this.realtimetranslate = realtimetranslate;
    }

    /**
     * @return The audiochat
     */
    public Audiochat getAudiochat() {
        return audiochat;
    }

    /**
     * @param audiochat The audiochat
     */
    public void setAudiochat(Audiochat audiochat) {
        this.audiochat = audiochat;
    }

    public Whiteboard getWhiteboard() {
        return whiteboard;
    }

    public void setWhiteboard(Whiteboard whiteboard) {
        this.whiteboard = whiteboard;
    }

    public Writeboard getWriteboard() {
        return writeboard;
    }

    public void setWriteboard(Writeboard writeboard) {
        this.writeboard = writeboard;
    }

    public Handwrite getHandwrite() {
        return handwrite;
    }

    public Style getStyle() {
        return style;
    }
}
