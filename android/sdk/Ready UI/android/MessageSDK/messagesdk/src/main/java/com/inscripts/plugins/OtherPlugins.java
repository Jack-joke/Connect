/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import com.inscripts.factories.URLFactory;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys.OtherPluginKeys;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class OtherPlugins {

    public static boolean isWhiteBoarddisabled() {
        return null == JsonPhp.getInstance().getConfig().getWhiteboardEnabled() || "0".equals(JsonPhp.getInstance().getConfig().getWhiteboardEnabled());
    }

    public static boolean isWriteBoarddisabled() {
        return null == JsonPhp.getInstance().getConfig().getWriteboardEnabled() || "0".equals(JsonPhp.getInstance().getConfig().getWriteboardEnabled());
    }

    public static boolean isSinglePlayerGamesEnabled() {
        return null != JsonPhp.getInstance().getConfig().getSingleGamesEnabled() && "1".equals(JsonPhp.getInstance().getConfig().getSingleGamesEnabled());
    }

    public static boolean isBroadcastMessageEnabled() {
        if (null != JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled()) {
            return JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled().equals("1");
        }
        return false;
    }

    public static boolean isHandwriteDisabled() {
        return null == JsonPhp.getInstance().getConfig().getHandwriteUrl() || "0".equals(JsonPhp.getInstance().getConfig().getHandwriteUrl());
    }

    public static boolean isCrWhiteBoarddisabled() {
        return null == JsonPhp.getInstance().getConfig().getCrWhiteboardEnabled() || "0".equals(JsonPhp.getInstance().getConfig().getCrWhiteboardEnabled());
    }

    public static boolean isCrWriteBoarddisabled() {
        return null == JsonPhp.getInstance().getConfig().getCrWriteboardEnabled() || "0".equals(JsonPhp.getInstance().getConfig().getCrWriteboardEnabled());
    }

    public static boolean iscrHandwriteDisabled() {
        return null == JsonPhp.getInstance().getConfig().getCrhandwriteEnabled() || "0".equals(JsonPhp.getInstance().getConfig().getHandwriteUrl());
    }

    public static boolean isGameRequest(String message) {
        return message.contains(OtherPluginKeys.GAME_REQUEST_KEY);
    }

    public static boolean isGameAccept(String message) {
        return message.contains(OtherPluginKeys.GAME_ACCEPT_KEY);
    }

    public static boolean isWriteBoardRequest(String message) {
        return message.contains(OtherPluginKeys.WRITEBOARD_REQUEST_KEY);
    }

    public static boolean isHandWrite(String message) {
        return message.contains(OtherPluginKeys.HANDWRITE_KEY);
    }

    public static boolean isScreehShareRequest(String message) {
        return message.contains(OtherPluginKeys.SCREENSHARE_REQUEST_KEY);
    }

    public static boolean isWhiteBoardRequest(String message) {
        return message.contains(OtherPluginKeys.WHITEBOARD_REQUEST_KEY);
    }

    public static boolean isBotResponce(String message){
        Logger.error("Is bot Responce message" + message);
        return (message.contains("\"name\":\"bots\",\"method\":\"botresponse\""));
    }

    public static String getHandwriteImageUrl(String message) {
        Document doc = Jsoup.parseBodyFragment(message);
        Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
        String href = link.attr(StaticMembers.HREF), relHref;
        if (href.contains(URLFactory.PROTOCOL_PREFIX) || href.contains(URLFactory.PROTOCOL_PREFIX_SECURE)) {
            relHref = href;
        } else {
            relHref = URLFactory.getWebsiteURL() + href;
        }
        return relHref;
    }

    public static boolean isTypingStart(String message) {
        return message.contains("\"method\":\"typingTo\"");
    }

    public static boolean isTypingStop(String message) {
        return message.contains("\"method\":\"typingStop\"");
    }

    public static boolean isMessageDelivery(String message) {
        return message.contains("\"method\":\"deliveredMessageNotify\"");
    }

    public static String getMessageID(String message) {
        try {
            String data[] = message.split("_\\{");
            JSONObject json = new JSONObject("{" + data[1]);
            JSONObject params = json.getJSONObject("params");
            return params.getString("message");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static boolean isMessageRead(String message) {
        return message.contains("\"method\":\"readMessageNotify\"");
    }

    public static boolean isMessageReadDelivered(String message) {
        return message.contains("\"method\":\"deliveredReadMessageNotify\"");
    }

    public static String getWhiteBoardRoomName(String message) {
        try {
            Document doc = Jsoup.parseBodyFragment(message);
            Elements element = doc.select(StaticMembers.ANCHOR_TAG);
            return element.attr("room");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static String getWriteBoardRoomName(String message) {
        try {
            Document doc = Jsoup.parseBodyFragment(message);
            Elements element = doc.select(StaticMembers.ANCHOR_TAG);
            return element.attr("random");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static String getTickMessageDetail(String message) {
        try {
            String data[] = message.split("_\\{");
            JSONObject json = new JSONObject("{" + data[1]);
            JSONObject params = json.getJSONObject("params");
            return params.getLong("message") + "#" + params.getString("fromid");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static String getRandomId(String message) {
        Document doc = Jsoup.parseBodyFragment(message);
        Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
        String relrandom = link.attr(StaticMembers.RANDOM);
        return relrandom;
    }
}
