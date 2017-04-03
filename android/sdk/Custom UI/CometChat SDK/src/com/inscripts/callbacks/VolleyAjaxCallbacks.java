package com.inscripts.callbacks;

public interface VolleyAjaxCallbacks {

	public void successCallback(String response);

	public void failCallback(String response);

	public void noInternetCallback();
}
