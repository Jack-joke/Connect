/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.utils.StaticMembers;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class AVBroadcastplugin {

    public static boolean isEnabled() {
        return null != JsonPhp.getInstance().getConfig().getAvBroadcastEnabled() && JsonPhp.getInstance().getConfig().getAvBroadcastEnabled().equals("1");
    }

    public static boolean isCrEnabled(){
        return null != JsonPhp.getInstance().getConfig().getCravbroadcastEnabled() && JsonPhp.getInstance().getConfig().getCravbroadcastEnabled().equals("1");
    }

    public static boolean isAVBroadcast(String message) {
        return message.contains(CometChatKeys.AVBroadcastKeys.BROADCAST_REQUEST_KEY);
    }

    public static boolean isAVBroadcastEnd(String message) {
        return message.contains(CometChatKeys.AVBroadcastKeys.BROADCAST_END_KEY);
    }

    public static boolean isCrAVBroadcast(String message) {
        return message.contains(CometChatKeys.AVBroadcastKeys.CRBROADCAST_REQUEST_KEY);
    }

    public static boolean isAVBroadcastInvite(String message) {
        try {
            return message.contains("class=\"broadcastInvite\"");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public static String getInviteGroupName(String message) {
        try {
            Document doc = Jsoup.parseBodyFragment(message);
            Elements elements = doc.select(StaticMembers.ANCHOR_TAG);
            for (Element element : elements) {
                if (element.attr("class").equals("broadcastInvite")) {
                    return element.attr("grp");
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static String getGroupName(String message, boolean isAudioOnly) {
        int initialIndex = 0;
        /*if (isAudioOnly) {
            if(message.contains(CometChatKeys.AudiochatKeys.HAS_ACCEPTED_REQUEST)){
                initialIndex = message.indexOf(CometChatKeys.AudiochatKeys.HAS_ACCEPTED_REQUEST);
            } else {
                initialIndex = message.indexOf(CometChatKeys.AudiochatKeys.REQUEST_KEY);
            }
        } else {*/
        if (message.contains(CometChatKeys.AVBroadcastKeys.BROADCAST_REQUEST_KEY)) {
            initialIndex = message.indexOf(CometChatKeys.AVBroadcastKeys.BROADCAST_REQUEST_KEY);
        }
            /*} else {
                initialIndex = message.indexOf(CometChatKeys.AVchatKeys.REQUEST_KEY);
            }*/
        //}
        message = message.substring(initialIndex, message.length());
        String parts[] = message.split(",");
        return parts[1].substring(1, parts[1].indexOf("\');"));
    }

    public static String getCRGroupName(String message, boolean isAudioOnly) {
        int initialIndex = 0;
        try {
            if (message.contains(CometChatKeys.AVBroadcastKeys.CRBROADCAST_REQUEST_KEY)) {
                initialIndex = message.indexOf(CometChatKeys.AVBroadcastKeys.CRBROADCAST_REQUEST_KEY);
            }
            message = message.substring(initialIndex, message.length());
            initialIndex = message.indexOf("(\'") + 2;
            return message.substring(initialIndex, message.indexOf("\');"));
        } catch (Exception e) {
            e.printStackTrace();
            return "";
        }
    }

}
