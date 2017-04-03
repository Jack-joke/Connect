/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.transports;

import android.content.Intent;
import android.text.TextUtils;

import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.pubnub.api.Callback;
import com.pubnub.api.Pubnub;
import com.pubnub.api.PubnubError;

import org.json.JSONObject;

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

    public void startCometService(String cometId, SubscribeCallbacks cometChatCallbacks) {
        myChannel = cometId;
        this.cometChatCallbacks = cometChatCallbacks;
        Config config = JsonPhp.getInstance().getConfig();
        pubnub = new Pubnub(config.getKEYA(), config.getKEYB(), config.getKEYC(), false);
        subscribe();
    }

    public void startCometService(String cometId) {
        try {
            myChannel = cometId;
            Config config = JsonPhp.getInstance().getConfig();
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
                            if (receivedMessage.has(AjaxKeys.MESSAGE)) {
                                if (TextUtils.isEmpty(receivedMessage.getString(AjaxKeys.MESSAGE))) {
                                    return;
                                }
                            }
                            if (!receivedMessage.has(AjaxKeys.ID)) {
                                receivedMessage.put(AjaxKeys.ID,
                                        receivedMessage.getString(DatabaseKeys.ColoumnKeys.SENT));
                            }
                            final long buddyId = receivedMessage.getLong(AjaxKeys.FROM);
                            final Buddy buddy = Buddy.getBuddyDetails(buddyId);
                            final String messageReceived = receivedMessage.getString(AjaxKeys.MESSAGE);
                            final boolean isLanguageSelected = PreferenceHelper
                                    .get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE).length() != 0;
                            if (null == buddy) {
                                MessageHelper.getInstance().addNewBuddy(buddyId, PreferenceHelper.getContext(),
                                        new CometchatCallbacks() {
                                            @Override
                                            public void successCallback() {
                                                try {
                                                    if (!TextUtils.isEmpty(JsonPhp.getInstance()
                                                            .getRealtimeTranslation())
                                                            && JsonPhp.getInstance().getRealtimeTranslation()
                                                            .equals("1")
                                                            && !TextUtils.isEmpty(JsonPhp.getInstance().getConfig()
                                                            .getRttKey())
                                                            && isLanguageSelected
                                                            && !messageReceived.contains("CC^CONTROL_")) {
                                                        CommonUtils.translateMessage(messageReceived,
                                                                new VolleyAjaxCallbacks() {

                                                                    @Override
                                                                    public void successCallback(String translatedMessage) {
                                                                        try {
                                                                            /* format according to CometChat convention */
                                                                            receivedMessage.put(AjaxKeys.MESSAGE,
                                                                                    translatedMessage + " ("
                                                                                            + messageReceived + ")");
                                                                        } catch (Exception e) {
                                                                            e.printStackTrace();
                                                                        }
                                                                        handleMessage(buddyId, receivedMessage);
                                                                    }

                                                                    @Override
                                                                    public void failCallback(String response,
                                                                                             boolean isNoInternet) {
                                                                        handleMessage(buddyId, receivedMessage);
                                                                    }
                                                                });
                                                    } else {
                                                        handleMessage(buddyId, receivedMessage);
                                                    }
                                                } catch (Exception e) {
                                                    e.printStackTrace();
                                                    handleMessage(buddyId, receivedMessage);
                                                }
                                            }

                                            @Override
                                            public void failCallback() {
                                                handleMessage(buddyId, receivedMessage);
                                            }
                                        },null);
                            } else {
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
                                            handleMessage(buddyId, receivedMessage);
                                        }

                                        @Override
                                        public void failCallback(String response, boolean isNoInternet) {
                                            handleMessage(buddyId, receivedMessage);
                                        }
                                    });
                                } else {
                                    handleMessage(buddyId, receivedMessage);
                                }
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

    private void handleMessage(long buddyId, JSONObject receivedMessage) {
        try {
            if (cometChatCallbacks != null) {
                MessageHelper.getInstance().handleOneOnOneMessage(receivedMessage,
                        cometChatCallbacks, true);
            }

            MessageHelper.getInstance().handleOneOnOneMessage(Buddy.getBuddyDetails(buddyId),
                    receivedMessage);

            String mess = receivedMessage.getString(AjaxKeys.MESSAGE);
            if (mess.contains("CC^CONTROL_")) {
                if (OtherPlugins.isTypingStop(mess)) {
                    return;
                } else if (OtherPlugins.isTypingStart(mess)) {
                    return;
                } else if (OtherPlugins.isMessageRead(mess)) {
                    return;
                } else if (OtherPlugins.isMessageDelivery(mess)) {
                    return;
                }
            }
            Intent intent = new Intent(
                    BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);

            LoginCallbacks loginCallbacks = HeartbeatOneOnOne.getInstance().getReadyUIListener();

            if(loginCallbacks != null){
                JSONObject messageJson = new JSONObject();
                messageJson.put("user_id",buddyId);
                messageJson.put("self",receivedMessage.get("self"));
                messageJson.put("message_id",receivedMessage.getLong("id"));
                loginCallbacks.onMessageReceive(messageJson);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void sendMessage(String channel, String message) {
        try {
            CometserviceOneOnOne.getInstance().pubnub.publish(channel, new JSONObject(message), new Callback() {
            });
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void sendMessage(String channel, JSONObject message) {
        CometserviceOneOnOne.getInstance().pubnub.publish(channel, message, new Callback() {
        });

    }

    public void unSubscribe() {
        if (pubnub != null) {
            pubnub.unsubscribe(myChannel);
        }
    }
}
