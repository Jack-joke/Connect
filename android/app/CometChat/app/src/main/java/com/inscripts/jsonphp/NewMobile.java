/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class NewMobile {

    @Expose
    private Common common;
    @Expose
    private Settings settings;
    @Expose
    private Ann ann;
    @Expose
    private Home home;
    @Expose
    private Login login;
    @Expose
    private Verify verify;
    @SerializedName("create_profile")
    @Expose
    private CreateProfile createProfile;
    @SerializedName("invite_sms")
    @Expose
    private InviteSms inviteSms;

    /**
     * @return The common
     */
    public Common getCommon() {
        return common;
    }


    /**
     * @return The settings
     */
    public Settings getSettings() {
        return settings;
    }


    /**
     * @return The ann
     */
    public Ann getAnn() {
        return ann;
    }


    /**
     * @return The home
     */
    public Home getHome() {
        return home;
    }


    /**
     * @return The login
     */
    public Login getLogin() {
        return login;
    }


    /**
     * @return The verify
     */
    public Verify getVerify() {
        return verify;
    }


    /**
     * @return The createProfile
     */
    public CreateProfile getCreateProfile() {
        return createProfile;
    }


    /**
     * @return The inviteSms
     */
    public InviteSms getInviteSms() {
        return inviteSms;
    }

}