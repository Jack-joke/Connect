/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Home {

    @SerializedName("tab_text")
    @Expose
    private String tabText;

    /**
     *
     * @return The tabText
     */
    public String getTabText() {
        return tabText;
    }

}
