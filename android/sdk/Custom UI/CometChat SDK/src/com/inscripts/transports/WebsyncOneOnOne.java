package com.inscripts.transports;

import org.json.JSONObject;

import android.text.TextUtils;

import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;

import fm.SingleAction;
import fm.websync.Client;
import fm.websync.ConnectArgs;
import fm.websync.ConnectFailureArgs;
import fm.websync.ConnectSuccessArgs;
import fm.websync.PublishArgs;
import fm.websync.SubscribeArgs;
import fm.websync.SubscribeFailureArgs;
import fm.websync.SubscribeReceiveArgs;
import fm.websync.SubscribeSuccessArgs;
import fm.websync.UnsubscribeArgs;

public class WebsyncOneOnOne {

	private static WebsyncOneOnOne websync;
	private Client client;
	private String cometId;
	private SubscribeCallbacks cometChatCallbacks;

	public static WebsyncOneOnOne getInstance() {
		if (null == websync) {
			websync = new WebsyncOneOnOne();
		}
		return websync;
	}

	public void connect(final String serveraddress, String cometid, SubscribeCallbacks cometChatCallbacks) {
		try {
			if (serveraddress.startsWith(URLFactory.PROTOCOL_PREFIX)
					|| serveraddress.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
				client = new Client(serveraddress + "/textchat.ashx");
			} else {
				client = new Client("http://" + serveraddress + "/textchat.ashx");
			}
			cometId = cometid;
			this.cometChatCallbacks = cometChatCallbacks;
			client.connect(new ConnectArgs() {
				{
					setOnSuccess(new SingleAction<ConnectSuccessArgs>() {

						public void invoke(ConnectSuccessArgs e) {
							Logger.error("Connection to server established");
							if (!cometId.startsWith("/")) {
								cometId = "/" + cometId;
							}
							subscribe(cometId);
						}
					});

					setOnFailure(new SingleAction<ConnectFailureArgs>() {
						@Override
						public void invoke(ConnectFailureArgs e) {
							Logger.error("Connection to server failed");
						}
					});
				}
			});
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private void subscribe(String channel) {
		if (client != null) {
			try {
				client.subscribe(new SubscribeArgs(channel) {
					{
						setOnSuccess(new SingleAction<SubscribeSuccessArgs>() {
							public void invoke(final SubscribeSuccessArgs e) {
								Logger.error("Subsribed to channel " + e.getChannel());
							}
						});
						setOnFailure(new SingleAction<SubscribeFailureArgs>() {
							public void invoke(SubscribeFailureArgs e) {
								Logger.error("Subscription to channel failed " + e.getChannel());
							}
						});
						setOnReceive(new SingleAction<SubscribeReceiveArgs>() {
							public void invoke(final SubscribeReceiveArgs e) {
								try {
									Object message = e.getDataJson();
									boolean isLanguageSelected = false;
									if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SELECTED_LANGUAGE)) {
										isLanguageSelected = PreferenceHelper.get(
												PreferenceKeys.DataKeys.SELECTED_LANGUAGE).length() != 0;
									}
									final JSONObject receivedMessage = new JSONObject(message.toString());
									Logger.error("msg ="+receivedMessage);
									if (null != receivedMessage) {

										final String messageReceived = receivedMessage
												.getString(CometChatKeys.AjaxKeys.MESSAGE);
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
											MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage,
													cometChatCallbacks, true);
										}

									}
								} catch (Exception ex) {
									ex.printStackTrace();
								}
							}
						});
					}
				});
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}

	public void publish(String channel, String message) {
		if (client != null) {
			try {
				if (!channel.startsWith("/")) {
                    channel = "/" + channel;
                }
				client.publish(new PublishArgs(channel, message));
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
	
	public void unsubscribe() {
        try {
            if (client != null) {
                client.unsubscribe(new UnsubscribeArgs(cometId));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
