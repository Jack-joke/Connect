/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import com.inscripts.jsonphp.JsonPhp;

public class BroadcastMessage {
    public static boolean isEnabled() {
        if (null != JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled()) {
            return JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled().equals("1");
        }
        return false;
    }
}
