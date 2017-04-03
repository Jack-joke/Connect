/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class InviteSms {

    @Expose
    private String actionbar;
    @SerializedName("contacts_hint")
    @Expose
    private String contactsHint;
    @SerializedName("contacts_label")
    @Expose
    private String contactsLabel;
    @SerializedName("sms_hint")
    @Expose
    private String smsHint;
    @SerializedName("sms_android")
    @Expose
    private String smsAndroid;
    @SerializedName("sms_ios")
    @Expose
    private String smsIos;
    @SerializedName("cannot_send")
    @Expose
    private String cannotSend;

    /**
     * @return The actionbar
     */
    public String getActionbar() {
        return actionbar;
    }


    /**
     * @return The contactsHint
     */
    public String getContactsHint() {
        return contactsHint;
    }


    /**
     * @return The contactsLabel
     */
    public String getContactsLabel() {
        return contactsLabel;
    }


    /**
     * @return The smsHint
     */
    public String getSmsHint() {
        return smsHint;
    }


    /**
     * @return The smsAndroid
     */
    public String getSmsAndroid() {
        return smsAndroid;
    }


    /**
     * @return The smsIos
     */
    public String getSmsIos() {
        return smsIos;
    }


    /**
     * @return The cannotSend
     */
    public String getCannotSend() {
        return cannotSend;
    }
}