/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Login {

    @Expose
    private String loader;
    @SerializedName("url_hint")
    @Expose
    private String urlHint;
    @SerializedName("username_hint")
    @Expose
    private String usernameHint;
    @SerializedName("password_hint")
    @Expose
    private String passwordHint;
    @SerializedName("phone_hint")
    @Expose
    private String phoneHint;
    @SerializedName("country_code")
    @Expose
    private String countryCode;
    @SerializedName("remember_me")
    @Expose
    private String rememberMe;
    @SerializedName("select_list")
    @Expose
    private String selectList;
    @SerializedName("login_button_text")
    @Expose
    private String loginButtonText;
    @SerializedName("register_link_text")
    @Expose
    private String registerLinkText;
    @SerializedName("register_number_button_text")
    @Expose
    private String registerNumberButtonText;
    @SerializedName("url_blank")
    @Expose
    private String urlBlank;
    @SerializedName("username_blank")
    @Expose
    private String usernameBlank;
    @SerializedName("password_blank")
    @Expose
    private String passwordBlank;
    @SerializedName("phone_blank")
    @Expose
    private String phoneBlank;
    @SerializedName("invalid_url")
    @Expose
    private String invalidUrl;
    @SerializedName("invalid_username")
    @Expose
    private String invalidUsername;
    @SerializedName("invalid_password")
    @Expose
    private String invalidPassword;
    @SerializedName("invalid_phone")
    @Expose
    private String invalidPhone;
    @SerializedName("login_via_email")
    @Expose
    private String loginViaEmail;

    /**
     * @return The loader
     */
    public String getLoader() {
        return loader;
    }

    /**
     * @return The urlHint
     */
    public String getUrlHint() {
        return urlHint;
    }

    /**
     * @return The usernameHint
     */
    public String getUsernameHint() {
        return usernameHint;
    }

    /**
     * @return The passwordHint
     */
    public String getPasswordHint() {
        return passwordHint;
    }

    /**
     * @return The phoneHint
     */
    public String getPhoneHint() {
        return phoneHint;
    }

    /**
     * @return The countryCode
     */
    public String getCountryCode() {
        return countryCode;
    }

    /**
     * @return The rememberMe
     */
    public String getRememberMe() {
        return rememberMe;
    }

    /**
     * @return The selectList
     */
    public String getSelectList() {
        return selectList;
    }

    /**
     * @return The loginButtonText
     */
    public String getLoginButtonText() {
        return loginButtonText;
    }

    /**
     * @return The registerLinkText
     */
    public String getRegisterLinkText() {
        return registerLinkText;
    }

    /**
     * @return The registerNumberButtonText
     */
    public String getRegisterNumberButtonText() {
        return registerNumberButtonText;
    }

    /**
     * @return The urlBlank
     */
    public String getUrlBlank() {
        return urlBlank;
    }

    /**
     * @return The usernameBlank
     */
    public String getUsernameBlank() {
        return usernameBlank;
    }

    /**
     * @return The passwordBlank
     */
    public String getPasswordBlank() {
        return passwordBlank;
    }

    /**
     * @return The phoneBlank
     */
    public String getPhoneBlank() {
        return phoneBlank;
    }

    /**
     * @return The invalidUrl
     */
    public String getInvalidUrl() {
        return invalidUrl;
    }

    /**
     * @return The invalidUsername
     */
    public String getInvalidUsername() {
        return invalidUsername;
    }

    /**
     * @return The invalidPassword
     */
    public String getInvalidPassword() {
        return invalidPassword;
    }

    /**
     * @return The invalidPhone
     */
    public String getInvalidPhone() {
        return invalidPhone;
    }


    public String getLoginViaEmail() {
        return loginViaEmail;
    }
}
