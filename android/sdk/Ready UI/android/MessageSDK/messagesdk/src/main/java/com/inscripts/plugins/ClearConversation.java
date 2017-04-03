/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import com.inscripts.jsonphp.JsonPhp;

public class ClearConversation {

	public static boolean isDisabled() {
		return JsonPhp.getInstance().getClearconversationEnabled().equals("0");
	}

	public static boolean isCrDisabled() {
		return JsonPhp.getInstance().getCrclearconversationEnabled().equals("0");
	}

}
