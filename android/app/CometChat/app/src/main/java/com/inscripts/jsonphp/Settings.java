/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Settings {

    @SerializedName("change_profile_pic")
    @Expose
    private String changeProfilePic;
    @SerializedName("edit_status_message")
    @Expose
    private String editStatusMessage;
    @SerializedName("status_message_hint")
    @Expose
    private String statusMessageHint;
    @SerializedName("set_status_message")
    @Expose
    private String setStatusMessage;
    @SerializedName("invite_viasms")
    @Expose
    private String inviteViasms;
    @SerializedName("edit_username")
    @Expose
    private String editUsername;
    @SerializedName("set_user_name")
    @Expose
    private String setUserName;
    @SerializedName("username_hint")
    @Expose
    private String usernameHint;
    @SerializedName("set_status")
    @Expose
    private String setStatus;
    @SerializedName("set_language")
    @Expose
    private String setLanguage;

    /**
     * @return The changeProfilePic
     */
    public String getChangeProfilePic() {
        return changeProfilePic;
    }


    /**
     * @return The editStatusMessage
     */
    public String getEditStatusMessage() {
        return editStatusMessage;
    }

    /**
     * @param editStatusMessage The edit_status_message
     */
    public void setEditStatusMessage(String editStatusMessage) {
        this.editStatusMessage = editStatusMessage;
    }

    /**
     * @return The statusMessageHint
     */
    public String getStatusMessageHint() {
        return statusMessageHint;
    }


    /**
     * @return The setStatusMessage
     */
    public String getSetStatusMessage() {
        return setStatusMessage;
    }


    /**
     * @return The inviteViasms
     */
    public String getInviteViasms() {
        return inviteViasms;
    }


    /**
     * @return The editUsername
     */
    public String getEditUsername() {
        return editUsername;
    }

    /**
     * @param editUsername The edit_username
     */
    public void setEditUsername(String editUsername) {
        this.editUsername = editUsername;
    }

    /**
     * @return The setUserName
     */
    public String getSetUserName() {
        return setUserName;
    }


    /**
     * @return The usernameHint
     */
    public String getUsernameHint() {
        return usernameHint;
    }


    /**
     * @return The setStatus
     */
    public String getSetStatus() {
        return setStatus;
    }


    /**
     * @return The setLanguage
     */
    public String getSetLanguage() {
        return setLanguage;
    }
}