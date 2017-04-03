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
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.pubnub.api.Callback;
import com.pubnub.api.Pubnub;
import com.pubnub.api.PubnubError;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class CometserviceChatroom {

    private static CometserviceChatroom cometService = null;
    private String myChannel;
    private Config config = JsonPhp.getInstance().getConfig();
    private Pubnub pubnub = new Pubnub(config.getKEYA(), config.getKEYB(), config.getKEYC(), false);
    ArrayList<String> subscribedChannel;

    public static CometserviceChatroom getInstance() {
        if (null == cometService) {
            cometService = new CometserviceChatroom();
        }
        return cometService;
    }

    public void startChatroomCometService(Long chatroomId) {
        try {
            myChannel = EncryptionHelper.encodeIntoMD5("chatroom_" + chatroomId + config.getKEYA()
                    + config.getKEYB() + config.getKEYC());
            subscribe();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void startChatroomCometService(String cometid) {
        try {
            myChannel = cometid;
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
                    //Logger.error("SUBSCRIBE : CONNECT on channel:" + message.toString()+"; Channel"+channel);

                    if (subscribedChannel != null){
                        if (!subscribedChannel.contains(myChannel)){
                            subscribedChannel.add(myChannel);
                        }
                    }else{
                        subscribedChannel = new ArrayList<String>();
                        subscribedChannel.add(myChannel);
                    }
                    if (subscribedChannel != null){
                        Set<String> set = new HashSet<String>();
                        set.addAll(subscribedChannel);
                        PreferenceHelper.save(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS, set);
                    }
                }

                @Override
                public void disconnectCallback(String channel, Object message) {
                    //Logger.error("SUBSCRIBE : DISCONNECT on channel:" + message.toString());
                }

                @Override
                public void reconnectCallback(String channel, Object message) {
                    //Logger.error("SUBSCRIBE : RECONNECT on channel:" + message.toString());
                }

                @Override
                public void successCallback(String channel, Object message) {
                    if (subscribedChannel != null){
                        if (subscribedChannel.contains(myChannel)){
                            try {
                                if (null != message) {
                                    final JSONObject receivedMessage = new JSONObject(message.toString());
                                    if (!receivedMessage.has(CometChatKeys.AjaxKeys.ID)) {
                                        receivedMessage.put(CometChatKeys.AjaxKeys.ID,
                                                receivedMessage.getString(DatabaseKeys.ColoumnKeys.SENT));
                                    }
                                    if (receivedMessage.has(CometChatKeys.AjaxKeys.MESSAGE)) {
                                        if (TextUtils.isEmpty(receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE))) {
                                            return;
                                        }
                                    }
                                    final String messageReceived = receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE);
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
                                                    receivedMessage.put(CometChatKeys.AjaxKeys.MESSAGE, translatedMessage + " ("
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
                    }

                }

                @Override
                public void errorCallback(String channel, PubnubError error) {
                    //Logger.error("SUBSCRIBE : ERROR on channel " + channel + " : " + error.toString());
                }
            });

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void handleMessage(JSONObject receivedMessage){
        MessageHelper.getInstance().handleChatroomMessage(receivedMessage);
        SessionData.getInstance().setChatroomBroadcastMissed(true);
        Intent intent = new Intent(
                BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
        PreferenceHelper.getContext().sendBroadcast(intent);
    }

    public void unSubscribe() {
        if (subscribedChannel != null){
            if (subscribedChannel.contains(myChannel)){
                subscribedChannel.remove(myChannel);
            }
        }
        if (pubnub != null) {
            if(myChannel != null)
            pubnub.unsubscribe(myChannel);
        }
        if (subscribedChannel != null && PreferenceHelper.contains(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS)){
            Set<String> set = new HashSet<String>();
            set.removeAll(subscribedChannel);
            set.addAll(subscribedChannel);
            PreferenceHelper.save(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS, set);
        }
    }

}
