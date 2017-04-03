/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Common {

    @Expose
    private String set;
    @SerializedName("complete_action")
    @Expose
    private String completeAction;
    @SerializedName("inapp_notification_message")
    @Expose
    private String inappNotificationMessage;

    /**
     * @return The set
     */
    public String getSet() {
        return set;
    }

    /**
     * @return The completeAction
     */
    public String getCompleteAction() {
        return completeAction;
    }

    /**
     * @return The inappNotificationMessage
     */
    public String getInappNotificationMessage() {
        return inappNotificationMessage;
    }
}
