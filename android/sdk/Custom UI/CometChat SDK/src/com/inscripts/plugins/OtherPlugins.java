package com.inscripts.plugins;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import com.inscripts.factories.URLFactory;
import com.inscripts.keys.CometChatKeys.OtherPluginKeys;
import com.inscripts.utils.StaticMembers;

public class OtherPlugins {

	public static boolean isAVBroadcast(String message) {
		return message.contains(OtherPluginKeys.BROADCAST_REQUEST_KEY);
	}

	public static boolean isAVBroadcastEnd(String message) {
		return message.contains(OtherPluginKeys.BROADCAST_END_KEY);
	}

	public static boolean isCrAVBroadcast(String message) {
		return message.contains(OtherPluginKeys.CRBROADCAST_REQUEST_KEY);
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

	public static String getHandwriteImageUrl(String message) {
		Document doc = Jsoup.parseBodyFragment(message);
		Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
		String relHref = URLFactory.getWebsiteURL() + link.attr(StaticMembers.HREF);
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

	public static boolean isMessageRead(String message) {
		return message.contains("\"method\":\"readMessageNotify\"");
	}

	public static boolean isMessageReadDelivered(String message) {
		return message.contains("\"method\":\"deliveredReadMessageNotify\"");
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
}
