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
     * @param loader The loader
     */
    public void setLoader(String loader) {
        this.loader = loader;
    }

    /**
     * @return The urlHint
     */
    public String getUrlHint() {
        return urlHint;
    }

    /**
     * @param urlHint The url_hint
     */
    public void setUrlHint(String urlHint) {
        this.urlHint = urlHint;
    }

    /**
     * @return The usernameHint
     */
    public String getUsernameHint() {
        return usernameHint;
    }

    /**
     * @param usernameHint The username_hint
     */
    public void setUsernameHint(String usernameHint) {
        this.usernameHint = usernameHint;
    }

    /**
     * @return The passwordHint
     */
    public String getPasswordHint() {
        return passwordHint;
    }

    /**
     * @param passwordHint The password_hint
     */
    public void setPasswordHint(String passwordHint) {
        this.passwordHint = passwordHint;
    }

    /**
     * @return The phoneHint
     */
    public String getPhoneHint() {
        return phoneHint;
    }

    /**
     * @param phoneHint The phone_hint
     */
    public void setPhoneHint(String phoneHint) {
        this.phoneHint = phoneHint;
    }

    /**
     * @return The countryCode
     */
    public String getCountryCode() {
        return countryCode;
    }

    /**
     * @param countryCode The country_code
     */
    public void setCountryCode(String countryCode) {
        this.countryCode = countryCode;
    }

    /**
     * @return The rememberMe
     */
    public String getRememberMe() {
        return rememberMe;
    }

    /**
     * @param rememberMe The remember_me
     */
    public void setRememberMe(String rememberMe) {
        this.rememberMe = rememberMe;
    }

    /**
     * @return The selectList
     */
    public String getSelectList() {
        return selectList;
    }

    /**
     * @param selectList The select_list
     */
    public void setSelectList(String selectList) {
        this.selectList = selectList;
    }

    /**
     * @return The loginButtonText
     */
    public String getLoginButtonText() {
        return loginButtonText;
    }

    /**
     * @param loginButtonText The login_button_text
     */
    public void setLoginButtonText(String loginButtonText) {
        this.loginButtonText = loginButtonText;
    }

    /**
     * @return The registerLinkText
     */
    public String getRegisterLinkText() {
        return registerLinkText;
    }

    /**
     * @param registerLinkText The register_link_text
     */
    public void setRegisterLinkText(String registerLinkText) {
        this.registerLinkText = registerLinkText;
    }

    /**
     * @return The registerNumberButtonText
     */
    public String getRegisterNumberButtonText() {
        return registerNumberButtonText;
    }

    /**
     * @param registerNumberButtonText The register_number_button_text
     */
    public void setRegisterNumberButtonText(String registerNumberButtonText) {
        this.registerNumberButtonText = registerNumberButtonText;
    }

    /**
     * @return The urlBlank
     */
    public String getUrlBlank() {
        return urlBlank;
    }

    /**
     * @param urlBlank The url_blank
     */
    public void setUrlBlank(String urlBlank) {
        this.urlBlank = urlBlank;
    }

    /**
     * @return The usernameBlank
     */
    public String getUsernameBlank() {
        return usernameBlank;
    }

    /**
     * @param usernameBlank The username_blank
     */
    public void setUsernameBlank(String usernameBlank) {
        this.usernameBlank = usernameBlank;
    }

    /**
     * @return The passwordBlank
     */
    public String getPasswordBlank() {
        return passwordBlank;
    }

    /**
     * @param passwordBlank The password_blank
     */
    public void setPasswordBlank(String passwordBlank) {
        this.passwordBlank = passwordBlank;
    }

    /**
     * @return The phoneBlank
     */
    public String getPhoneBlank() {
        return phoneBlank;
    }

    /**
     * @param phoneBlank The phone_blank
     */
    public void setPhoneBlank(String phoneBlank) {
        this.phoneBlank = phoneBlank;
    }

    /**
     * @return The invalidUrl
     */
    public String getInvalidUrl() {
        return invalidUrl;
    }

    /**
     * @param invalidUrl The invalid_url
     */
    public void setInvalidUrl(String invalidUrl) {
        this.invalidUrl = invalidUrl;
    }

    /**
     * @return The invalidUsername
     */
    public String getInvalidUsername() {
        return invalidUsername;
    }

    /**
     * @param invalidUsername The invalid_username
     */
    public void setInvalidUsername(String invalidUsername) {
        this.invalidUsername = invalidUsername;
    }

    /**
     * @return The invalidPassword
     */
    public String getInvalidPassword() {
        return invalidPassword;
    }

    /**
     * @param invalidPassword The invalid_password
     */
    public void setInvalidPassword(String invalidPassword) {
        this.invalidPassword = invalidPassword;
    }

    /**
     * @return The invalidPhone
     */
    public String getInvalidPhone() {
        return invalidPhone;
    }

    /**
     * @param invalidPhone The invalid_phone
     */
    public void setInvalidPhone(String invalidPhone) {
        this.invalidPhone = invalidPhone;
    }


    public String getLoginViaEmail() {
        return loginViaEmail;
    }

    public void setLoginViaEmail(String loginViaEmail) {
        this.loginViaEmail = loginViaEmail;
    }
}
