/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Announcements {

    @SerializedName("100")
    @Expose
    private String _100;
    @SerializedName("0")
    @Expose
    private String _0;
    @Expose
    private String hash;

    /**
     * @return The _100
     */
    public String get100() {
        return _100;
    }

    /**
     * @return The _0
     */
    public String get0() {
        return _0;
    }

    /**
     * @return The hash
     */
    public String getHash() {
        return hash;
    }

}