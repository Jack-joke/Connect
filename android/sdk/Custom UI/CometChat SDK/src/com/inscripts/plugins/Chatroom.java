package com.inscripts.plugins;

import org.json.JSONObject;

import android.text.TextUtils;

import com.inscripts.keys.CometChatKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.StaticMembers;

public class Chatroom {
	public static boolean isKickedChatroomMessage(String message) {
		return message.contains(CometChatKeys.ChatroomKeys.KICK_KEY);
	}

	public static boolean isBannedChatroomMessage(String message) {
		return message.contains(CometChatKeys.ChatroomKeys.BAN_KEY);
	}

	public static boolean isMessageDeletedFromChatroom(String message) {
		return message.contains(CometChatKeys.ChatroomKeys.DELETE_MESSAGE_KEY);
	}

	public static boolean isJoinChatroomMessage(String message) {
		return message.contains(CometChatKeys.ChatroomKeys.JOIN_KEY);
	}

	/**
	 * Process the chatroom invite request and provides chatroom details
	 * 
	 * @param message
	 *            Join chatroom request received message
	 * @return If chatroom request is processed successfully then returns comma
	 *         separated chatroom details as
	 *         "<i>Chatroomid,ChatroomName,Chatroompassword</i>" <br>
	 *         else returns null
	 */
	public static JSONObject processJoinRequest(String message) throws IllegalArgumentException {
		if (!TextUtils.isEmpty(message)) {
			try {
				int startIndex = message.indexOf(CometChatKeys.ChatroomKeys.JOIN_KEY);
				String submessage = message.substring(startIndex, message.length());
				String parts[] = submessage.split(",");

				String joinRoomPassword = parts[1].substring(1, parts[1].length() - 1);
				String joinRoomName = parts[2].substring(1, parts[2].indexOf("')"));
				joinRoomName = new String(CommonUtils.decodeBase64(joinRoomName), StaticMembers.UTF_8);
				String joinRoomId = parts[0].substring(CometChatKeys.ChatroomKeys.JOIN_KEY.length() + 1,
						parts[0].length() - 1);

				JSONObject json = new JSONObject();
				json.put("chatroom_id", joinRoomId);
				json.put("chatroom_name", joinRoomName);
				json.put("chatroom_password", joinRoomPassword);
				return json;
			} catch (Exception e) {
				e.printStackTrace();
			}
		} else {
			throw new IllegalArgumentException("Message can't be empty or null");
		}
		return null;
	}
}
