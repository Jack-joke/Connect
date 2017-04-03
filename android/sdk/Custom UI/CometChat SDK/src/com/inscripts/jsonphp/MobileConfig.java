package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class MobileConfig {

    @SerializedName("phone_number_enabled")
    @Expose
    private String phoneNumberEnabled;
    @SerializedName("username_password_enabled")
    @Expose
    private String usernamePasswordEnabled;
    @SerializedName("social_auth_enabled")
    @Expose
    private String socialAuthEnabled;
    @SerializedName("f_enabled")
    @Expose
    private String facebookEnabled;
    @SerializedName("t_enabled")
    @Expose
    private String twitterEnabled;
    @SerializedName("g_enabled")
    @Expose
    private String googleEnabled;
    @SerializedName("guest_enabled")
    @Expose
    private String guestEnabled;

    public String getUsernamePasswordEnabled() {
        return usernamePasswordEnabled;
    }

    public void setUsernamePasswordEnabled(String usernamePasswordEnabled) {
        this.usernamePasswordEnabled = usernamePasswordEnabled;
    }

    public String getPhoneNumberEnabled() {
        return phoneNumberEnabled;
    }

    public void setPhoneNumberEnabled(String phoneNumberEnabled) {
        this.phoneNumberEnabled = phoneNumberEnabled;
    }

    public String getGuestEnabled() {
        return guestEnabled;
    }

    public void setGuestEnabled(String guestEnabled) {
        this.guestEnabled = guestEnabled;
    }

    public String getFacebookEnabled() {
        return facebookEnabled;
    }

    public void setFacebookEnabled(String facebookEnabled) {
        this.facebookEnabled = facebookEnabled;
    }

    public String getTwitterEnabled() {
        return twitterEnabled;
    }

    public void setTwitterEnabled(String twitterEnabled) {
        this.twitterEnabled = twitterEnabled;
    }

    public String getGoogleEnabled() {
        return googleEnabled;
    }

    public void setGoogleEnabled(String googleEnabled) {
        this.googleEnabled = googleEnabled;
    }

    public String getSocialAuthEnabled() {
        return socialAuthEnabled;
    }

    public void setSocialAuthEnabled(String socialAuthEnabled) {
        this.socialAuthEnabled = socialAuthEnabled;
    }
}
