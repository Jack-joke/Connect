/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

import android.webkit.JavascriptInterface;

public interface CustomJavaScriptInterface {

	@JavascriptInterface
	public void sendToMobile(String html);
}
