package com.inscripts.transports;

import org.json.JSONObject;

import android.text.TextUtils;

import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
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

public class CometserviceOneOnOne {

	private String myChannel;
	private Pubnub pubnub;
	private static CometserviceOneOnOne cometService = null;
	private SubscribeCallbacks cometChatCallbacks;

	public static CometserviceOneOnOne getInstance() {
		if (null == cometService) {
			cometService = new CometserviceOneOnOne();
		}
		return cometService;
	}

	private CometserviceOneOnOne() {
	}

	public void startCometService(String cometId, SubscribeCallbacks cometChatCallbacks) {
		myChannel = cometId;
		this.cometChatCallbacks = cometChatCallbacks;
		Config config = JsonPhp.getInstance().getConfig();
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
										} catch (Exception e) {
											e.printStackTrace();
										}
										MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage,
												cometChatCallbacks, true);
									}

									@Override
									public void noInternetCallback() {
										MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage,
												cometChatCallbacks, true);
									}

									@Override
									public void failCallback(String response) {
										MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage,
												cometChatCallbacks, true);
									}
								});

							} else {
								MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage, cometChatCallbacks,
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

	public static void sendMessage(String channel, String message) {
		try {
			Logger.error("message "+new JSONObject(message));
			CometserviceOneOnOne.getInstance().pubnub.publish(channel, new JSONObject(message), new Callback() {
			});
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
