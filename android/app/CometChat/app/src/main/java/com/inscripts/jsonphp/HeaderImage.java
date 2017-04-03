/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class HeaderImage {

    @SerializedName("image_path")
    @Expose
    private String imagePath;
    @SerializedName("image_width")
    @Expose
    private Integer imageWidth;
    @SerializedName("image_height")
    @Expose
    private Integer imageHeight;
    @SerializedName("image_modified_time")
    @Expose
    private Integer imageModifiedTime;

    /**
     * @return The imagePath
     */
    public String getImagePath() {
        return imagePath;
    }

    /**
     * @return The imageWidth
     */
    public Integer getImageWidth() {
        return imageWidth;
    }

    /**
     * @return The imageHeight
     */
    public Integer getImageHeight() {
        return imageHeight;
    }

    /**
     * @return The imageModifiedTime
     */
    public Integer getImageModifiedTime() {
        return imageModifiedTime;
    }

}