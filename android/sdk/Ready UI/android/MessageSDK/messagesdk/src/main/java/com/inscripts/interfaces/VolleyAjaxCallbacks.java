/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

public interface VolleyAjaxCallbacks {

	public void successCallback(String response);

	public void failCallback(String response, boolean isNoInternet);

}
