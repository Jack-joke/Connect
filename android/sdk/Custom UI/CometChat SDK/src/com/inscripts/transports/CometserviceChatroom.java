package com.inscripts.transports;

import org.json.JSONObject;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.text.TextUtils;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.SubscribeChatroomCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.pubnub.api.Callback;
import com.pubnub.api.Pubnub;
import com.pubnub.api.PubnubError;

public class CometserviceChatroom extends Service {

	private static CometserviceChatroom cometService = null;
	private String myChannel;
	private Pubnub pubnub;
	private SubscribeChatroomCallbacks callbacklistener;

	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}

	public static CometserviceChatroom getInstance() {
		if (null == cometService) {
			cometService = new CometserviceChatroom();
		}
		return cometService;
	}

	private CometserviceChatroom() {
	}

	public void startChatroomCometService(String chatroomId, SubscribeChatroomCallbacks callback, Callbacks callbacks) {
		Config config = JsonPhp.getInstance().getConfig();
		callbacklistener = callback;
		try {
			myChannel = EncryptionHelper.encodeIntoMD5("chatroom_" + chatroomId + config.getKEYA() + config.getKEYB()
					+ config.getKEYC());
		} catch (Exception e) {
			Logger.error("error at md5 generation startcometservice");
			e.printStackTrace();
		}
		pubnub = new Pubnub(config.getKEYA(), config.getKEYB(), config.getKEYC(), false);
		subscribe();
	}

	private void subscribe() {
		try {
			pubnub.subscribe(myChannel, new Callback() {
				@Override
				public void connectCallback(String channel, Object message) {
					Logger.error("SUBSCRIBE : CONNECT on channel:" + message.toString());
				}

				@Override
				public void disconnectCallback(String channel, Object message) {
					Logger.error("SUBSCRIBE : DISCONNECT on channel:" + message.toString());
				}

				@Override
				public void reconnectCallback(String channel, Object message) {
					Logger.error("SUBSCRIBE : RECONNECT on channel:" + message.toString());
				}

				@Override
				public void successCallback(String channel, Object message) {
					try {
						boolean isLanguageSelected = false;
						if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SELECTED_LANGUAGE)) {
							isLanguageSelected = PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE)
									.length() != 0;
						}
						final JSONObject receivedMessage = new JSONObject(message.toString());
						if (null != receivedMessage) {
							final String messageReceived = receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE);
							if (!TextUtils.isEmpty(JsonPhp.getInstance().getRealtimeTranslation())
									&& JsonPhp.getInstance().getRealtimeTranslation().equals("1")
									&& !TextUtils.isEmpty(JsonPhp.getInstance().getConfig().getRttKey())
									&& isLanguageSelected && !messageReceived.contains("CC^CONTROL_")) {

								CommonUtils.translateMessage(messageReceived, new VolleyAjaxCallbacks() {

									@Override
									public void successCallback(String translatedMessage) {
										try {
											/*
											 * format according to CometChat
											 * convention
											 */
											receivedMessage.put(AjaxKeys.MESSAGE, translatedMessage + " ("
													+ messageReceived + ")");
											Logger.error("receibed message =" + receivedMessage);
										} catch (Exception e) {
											e.printStackTrace();
										}
										MessageHelper.getInstance().handleChatroomMessage(receivedMessage,
												callbacklistener, true);
									}

									@Override
									public void noInternetCallback() {
										MessageHelper.getInstance().handleChatroomMessage(receivedMessage,
												callbacklistener, true);
									}

									@Override
									public void failCallback(String response) {
										MessageHelper.getInstance().handleChatroomMessage(receivedMessage,
												callbacklistener, true);
									}
								});

							} else {
								MessageHelper.getInstance().handleChatroomMessage(receivedMessage, callbacklistener,
										true);
							}
						}
					} catch (Exception e) {
						e.printStackTrace();
					}
				}

				@Override
				public void errorCallback(String channel, PubnubError error) {
					Logger.error("SUBSCRIBE : ERROR on channel " + channel + " : " + error.toString());
				}
			});
		} catch (Exception e) {

		}
	}

	public void unSubscribe() {
		if (pubnub != null && null != myChannel) {
			pubnub.unsubscribe(myChannel);
		}
	}
}
