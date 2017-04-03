/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Ann {

    @SerializedName("tab_text")
    @Expose
    private String tabText;
    @SerializedName("read_more")
    @Expose
    private String readMore;
    @SerializedName("read_less")
    @Expose
    private String readLess;

    /**
     *
     * @return The tabText
     */
    public String getTabText() {
        return tabText;
    }

    /**
     *
     * @return The readMore
     */
    public String getReadMore() {
        return readMore;
    }

    /**
     *
     * @return The readLess
     */
    public String getReadLess() {
        return readLess;
    }
}