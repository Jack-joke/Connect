/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

import org.json.JSONObject;

public interface LoginCallbacks {

	public void successCallback(JSONObject response);

	public void failCallback(JSONObject response);

    public void userInfoCallback(JSONObject response);

    public void chatroomInfoCallback(JSONObject response);

    public void onMessageReceive(JSONObject response);

    public void chatWindowListner(JSONObject response);
}
