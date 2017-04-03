/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
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

    @SerializedName("logout_enabled")
    @Expose
    private String logoutEnabled;

    public String getUsernamePasswordEnabled() {
        return usernamePasswordEnabled;
    }

    public String getPhoneNumberEnabled() {
        return phoneNumberEnabled;
    }

    public String getGuestEnabled() {
        return guestEnabled;
    }

    public String getFacebookEnabled() {
        return facebookEnabled;
    }

    public String getTwitterEnabled() {
        return twitterEnabled;
    }

    public String getGoogleEnabled() {
        return googleEnabled;
    }

    public String getSocialAuthEnabled() {
        return socialAuthEnabled;
    }

    public String getLogoutEnabled() {
        return logoutEnabled;
    }
}