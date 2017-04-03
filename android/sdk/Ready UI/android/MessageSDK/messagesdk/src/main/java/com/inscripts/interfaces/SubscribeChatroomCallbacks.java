/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

import org.json.JSONObject;

public interface SubscribeChatroomCallbacks {

	/**
	 * Provides incoming json object string
	 * 
	 * @param receivedMessage
	 */
	public void onMessageReceived(JSONObject receivedMessage);

	/**
	 * Provides Error message
	 * 
	 * @param errorResponse
	 */
	public void onError(JSONObject errorResponse);

	/**
	 * Triggered when the currently logged in user leaves a chatroom.
	 */
	public void onLeaveChatroom(JSONObject leaveResponse);

	/**
	 * Triggered when we get the complete chatroom list from the server.
	 */
	public void gotChatroomList(JSONObject chatroomList);

	/**
	 * Triggered when the we get the members of the current chatroom.
	 */
	public void gotChatroomMembers(JSONObject chatroomMembers);

	/**
	 * Triggered when the we get AVChat messages
	 */
	public void onAVChatMessageReceived(JSONObject response);

	/**
	 * Triggered when actions like kick, ban, delete chatroom happens
	 * */
	public void onActionMessageReceived(JSONObject response);
}
