package com.inscripts.pojos;

public class ChatMenuItem {

    private int mDrawableRes;

    private String mTitle;

    public ChatMenuItem(int drawable, String title) {
        mDrawableRes = drawable;
        mTitle = title;
    }

    public int getDrawableResource() {
        return mDrawableRes;
    }

    public String getTitle() {
        return mTitle;
    }

}
