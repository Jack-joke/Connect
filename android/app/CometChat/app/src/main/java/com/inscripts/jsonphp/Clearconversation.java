/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Clearconversation {

    @SerializedName("0")
    @Expose
    private String _0;
    @Expose
    private String hash;

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