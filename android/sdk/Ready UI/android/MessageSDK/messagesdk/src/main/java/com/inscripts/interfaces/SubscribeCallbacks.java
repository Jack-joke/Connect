/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/

package com.inscripts.interfaces;

import org.json.JSONObject;

public interface SubscribeCallbacks {

	public void gotOnlineList(JSONObject onlineUsers);

    public void gotBotList(JSONObject botList);

	public void onError(JSONObject errorResponse);

	/**
	 * Provides incoming json object string
	 * 
	 * @param receivedMessage
	 *            JSONObject containing message with the message type
	 * 
	 */
	public void onMessageReceived(JSONObject receivedMessage);

	/**
	 * Provides information of logged in user
	 * 
	 * @param profileInfo
	 */
	public void gotProfileInfo(JSONObject profileInfo);

	/**
	 * Triggered when we receive announcement send by admin
	 * */
	public void gotAnnouncement(JSONObject announcement);

	/**
	 * Triggered when avchat related messages are received
	 * */
	public void onAVChatMessageReceived(JSONObject response);

	/**
	 * Triggered when special messages are received like typing started/stopped
	 * */
	public void onActionMessageReceived(JSONObject response);

}