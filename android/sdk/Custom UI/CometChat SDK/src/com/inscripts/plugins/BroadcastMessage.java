package com.inscripts.plugins;

import com.inscripts.jsonphp.JsonPhp;

public class BroadcastMessage {
	public static boolean isEnabled() {
		if (null == JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled()) {
			return false;
		} else {
			return JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled().equals("1");
		}
	}
}
