/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class MobileTheme {

    @SerializedName("login_background")
    @Expose
    private String loginBackground;

    @SerializedName("login_foreground")
    @Expose
    private String loginForeground;

    @SerializedName("login_placeholder")
    @Expose
    private String loginPlaceholder;

    @SerializedName("login_button_pressed")
    @Expose
    private String loginButtonPressed;

    @SerializedName("login_foreground_text")
    @Expose
    private String loginForegroundText;

    @SerializedName("actionbar_color")
    @Expose
    private String actionbarColor;

    @SerializedName("actionbar_text_color")
    @Expose
    private String actionbarTextColor;

    @SerializedName("left_bubble_color")
    @Expose
    private String leftBubbleColor;

    @SerializedName("left_bubble_text_color")
    @Expose
    private String leftBubbleTextColor;

    @SerializedName("right_bubble_color")
    @Expose
    private String rightBubbleColor;

    @SerializedName("right_bubble_text_color")
    @Expose
    private String rightBubbleTextColor;

    @SerializedName("tab_highlight_color")
    @Expose
    private String tabHighlightColor;

    @SerializedName("login_button_text")
    @Expose
    private String loginButtonText;

    @SerializedName("login_button")
    @Expose
    private String loginButton;

    @SerializedName("login_text")
    @Expose
    private String loginText;

    @SerializedName("login_text_hint")
    @Expose
    private String loginTextHint;

    @SerializedName("left_bubble_timestamp_color")
    @Expose
    private String leftBubbleTimestampColor;

    @SerializedName("right_bubble_timestamp_color")
    @Expose
    private String RightBubbleTimestampColor;

    @SerializedName("primary_color")
    @Expose
    private String primaryColor;

    @SerializedName("secondary_color")
    @Expose
    private String primaryDarkColor;


    public String getLoginTextHint() {
        return loginTextHint;
    }

    public String getLoginText() {
        return loginText;
    }

    public String getLoginButton() {
        return loginButton;
    }


    /**
     * @return The loginBackground
     */
    public String getLoginBackground() {
        return loginBackground;
    }


    /**
     * @return The loginForeground
     */
    public String getLoginForeground() {
        return loginForeground;
    }


    /**
     * @return The loginPlaceholder
     */
    public String getLoginPlaceholder() {
        return loginPlaceholder;
    }


    /**
     * @return The loginButtonPressed
     */
    public String getLoginButtonPressed() {
        return loginButtonPressed;
    }


    /**
     * @return The loginForegroundText
     */
    public String getLoginForegroundText() {
        return loginForegroundText;
    }


    public String getActionbarColor() {
        return actionbarColor;
    }

    public String getActionbarTextColor() {
        return actionbarTextColor;
    }

    public String getLeftBubbleColor() {
        return leftBubbleColor;
    }

    public String getLeftBubbleTextColor() {
        return leftBubbleTextColor;
    }

    public String getRightBubbleColor() {
        return rightBubbleColor;
    }

    public String getRightBubbleTextColor() {
        return rightBubbleTextColor;
    }

    public String getTabHighlightColor() {
        return tabHighlightColor;
    }

    public String getLoginButtonText() {
        return loginButtonText;
    }

    public String getLeftBubbleTimestampColor() {
        return leftBubbleTimestampColor;
    }

    public void setLeftBubbleTimestampColor(String leftBubbleTimestampColor) {
        this.leftBubbleTimestampColor = leftBubbleTimestampColor;
    }

    public String getRightBubbleTimestampColor() {
        return RightBubbleTimestampColor;
    }

    public void setRightBubbleTimestampColor(String rightBubbleTimestampColor) {
        RightBubbleTimestampColor = rightBubbleTimestampColor;
    }

    public String getPrimaryColor() {
        return primaryColor;
    }

    public String getPrimarkDaryColor() {
        return primaryDarkColor;
    }


}