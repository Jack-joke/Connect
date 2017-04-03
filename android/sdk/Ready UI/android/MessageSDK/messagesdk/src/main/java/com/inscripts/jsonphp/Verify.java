/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Verify {

    @Expose
    private String actionbar;
    @Expose
    private String loader;
    @SerializedName("field_hint")
    @Expose
    private String fieldHint;
    @SerializedName("verify_button")
    @Expose
    private String verifyButton;
    @SerializedName("resend_button")
    @Expose
    private String resendButton;
    @SerializedName("wrong_code")
    @Expose
    private String wrongCode;
    @SerializedName("change_email")
    @Expose
    private String changeEmail;

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
     * @return The fieldHint
     */
    public String getFieldHint() {
        return fieldHint;
    }


    /**
     * @return The verifyButton
     */
    public String getVerifyButton() {
        return verifyButton;
    }


    /**
     * @return The resendButton
     */
    public String getResendButton() {
        return resendButton;
    }


    /**
     * @return The wrongCode
     */
    public String getWrongCode() {
        return wrongCode;
    }


    /**
     * @return The changeEmail
     */
    public String getChangeEmail() {
        return changeEmail;
    }

}