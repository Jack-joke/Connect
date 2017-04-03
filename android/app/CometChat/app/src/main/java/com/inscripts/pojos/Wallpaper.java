/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.pojos;

/**
 * Created by GauravB on 8/18/2015.
 */
public class Wallpaper {

    private boolean showNotify;
    private String title;
    private int icon;

    public Wallpaper(String title, int icon) {

        this.title = title;
        this.icon = icon;
    }

    public int getImage() {
        return this.icon;
    }

    public void setImage(int icon) {
        this.icon = icon;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
}
