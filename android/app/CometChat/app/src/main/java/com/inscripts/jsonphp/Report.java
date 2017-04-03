/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Report {

    @SerializedName("0")
    @Expose
    private String _0;
    @SerializedName("1")
    @Expose
    private String _1;
    @SerializedName("2")
    @Expose
    private String _2;
    @SerializedName("3")
    @Expose
    private String _3;
    @SerializedName("4")
    @Expose
    private String _4;
    @SerializedName("5")
    @Expose
    private String _5;
    @SerializedName("6")
    @Expose
    private String _6;
    @Expose
    private String hash;

    /**
     * @return The _0
     */
    public String get0() {
        return _0;
    }


    /**
     * @return The _1
     */
    public String get1() {
        return _1;
    }


    /**
     * @return The _2
     */
    public String get2() {
        return _2;
    }


    /**
     * @return The _3
     */
    public String get3() {
        return _3;
    }


    /**
     * @return The _4
     */
    public String get4() {
        return _4;
    }


    /**
     * @return The _5
     */
    public String get5() {
        return _5;
    }


    /**
     * @return The _6
     */
    public String get6() {
        return _6;
    }

    /**
     * @return The hash
     */
    public String getHash() {
        return hash;
    }


}