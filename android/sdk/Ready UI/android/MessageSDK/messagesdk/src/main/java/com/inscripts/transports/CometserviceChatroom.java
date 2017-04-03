/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.transports;

import android.content.Intent;
import android.text.TextUtils;

import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.pubnub.api.Callback;
import com.pubnub.api.Pubnub;
import com.pubnub.api.PubnubError;

import org.json.JSONObject;

public class CometserviceChatroom {

    private static CometserviceChatroom cometService = null;
    private String myChannel;
    private Pubnub pubnub;
    private SubscribeChatroomCallbacks callbacklistener;

    public static CometserviceChatroom getInstance() {
        if (null == cometService) {
            cometService = new CometserviceChatroom();
        }
        return cometService;
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

    public void startChatroomCometService(Long chatroomId) {
        try {
            Config config = JsonPhp.getInstance().getConfig();
            myChannel = SessionData.getInstance().getChatroomCometId();
            if (myChannel == null) {
                myChannel = EncryptionHelper.encodeIntoMD5("chatroom_" + chatroomId + config.getKEYA()
                        + config.getKEYB() + config.getKEYC());
            }
            pubnub = new Pubnub(config.getKEYA(), config.getKEYB(), config.getKEYC(), false);
            subscribe();
        } catch (Exception e) {
            e.printStackTrace();
        }
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
                        if (null != message) {
                            final JSONObject receivedMessage = new JSONObject(message.toString());
                            if (!receivedMessage.has(AjaxKeys.ID)) {
                                receivedMessage.put(AjaxKeys.ID,
                                        receivedMessage.getString(DatabaseKeys.ColoumnKeys.SENT));
                            }
                            if (receivedMessage.has(AjaxKeys.MESSAGE)) {
                                if (TextUtils.isEmpty(receivedMessage.getString(AjaxKeys.MESSAGE))) {
                                    return;
                                }
                            }
                            final String messageReceived = receivedMessage.getString(AjaxKeys.MESSAGE);
                            final boolean isLanguageSelected = PreferenceHelper
                                    .get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE).length() != 0;

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
                                        handleMessage(receivedMessage);
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        handleMessage(receivedMessage);
                                    }
                                });
                            } else {
                                handleMessage(receivedMessage);
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
            e.printStackTrace();
        }
    }

    private void handleMessage(JSONObject receivedMessage) {

        if (callbacklistener != null) {
            MessageHelper.getInstance().handleChatroomMessage(receivedMessage,
                    callbacklistener, true);
        }
        MessageHelper.getInstance().handleChatroomMessage(receivedMessage);
        SessionData.getInstance().setChatroomBroadcastMissed(true);
        Intent intent = new Intent(
                BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
        PreferenceHelper.getContext().sendBroadcast(intent);
    }

    public void unSubscribe() {
        if (pubnub != null) {
            pubnub.unsubscribe(myChannel);
        }
    }
}
