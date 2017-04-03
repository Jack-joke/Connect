/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class CreateProfile {

    @Expose
    private String actionbar;
    @Expose
    private String loader;
    @SerializedName("create_button")
    @Expose
    private String createButton;
    @SerializedName("field_hint")
    @Expose
    private String fieldHint;
    @SerializedName("err_username")
    @Expose
    private String errUsername;
    @SerializedName("photo_hint")
    @Expose
    private String photoHint;
    @SerializedName("password_mismatch")
    @Expose
    private String passwordMismatch;
    @SerializedName("confpwd_empty")
    @Expose
    private String confpwdEmpty;
    @SerializedName("incorrect_password")
    @Expose
    private String incorrectPassword;
    @SerializedName("email_empty")
    @Expose
    private String emailEmpty;

    /**
     * @return The actionbar
     */
    public String getActionbar() {
        return actionbar;
    }


    /**
     * @return The loader
     */
    public String getLoader() {
        return loader;
    }


    /**
     * @return The createButton
     */
    public String getCreateButton() {
        return createButton;
    }


    /**
     * @return The fieldHint
     */
    public String getFieldHint() {
        return fieldHint;
    }


    /**
     * @return The errUsername
     */
    public String getErrUsername() {
        return errUsername;
    }


    /**
     * @return The photoHint
     */
    public String getPhotoHint() {
        return photoHint;
    }


    /**
     * @return The passwordMismatch
     */
    public String getPasswordMismatch() {
        return passwordMismatch;
    }


    /**
     * @return The confpwdEmpty
     */
    public String getConfpwdEmpty() {
        return confpwdEmpty;
    }


    /**
     * @return The incorrectPassword
     */
    public String getIncorrectPassword() {
        return incorrectPassword;
    }


    /**
     * @return The emailEmpty
     */
    public String getEmailEmpty() {
        return emailEmpty;
    }


}