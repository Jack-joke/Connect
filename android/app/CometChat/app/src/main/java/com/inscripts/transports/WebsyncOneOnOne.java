/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.transports;

import android.content.Intent;
import android.text.TextUtils;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.DatabaseKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;

import org.json.JSONObject;

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

    public static WebsyncOneOnOne getInstance() {
        if (null == websync) {
            websync = new WebsyncOneOnOne();
        }
        return websync;
    }

    public void connect(final String serveraddress, String cometid) {
        try {
            if (serveraddress.startsWith(URLFactory.PROTOCOL_PREFIX)
                    || serveraddress.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
                client = new Client(serveraddress + "/textchat.ashx");
            } else {
                client = new Client("http://" + serveraddress + "/textchat.ashx");
            }
            cometId = cometid;
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

    public void subscribe(String channel) {
        if (client != null) {
            try {
                client.subscribe(new SubscribeArgs(channel) {{
                    setOnSuccess(new SingleAction<SubscribeSuccessArgs>() {
                        public void invoke(final SubscribeSuccessArgs e) {
                            //Logger.error("Subsribed to channel " + e.getChannel());
                        }
                    });
                    setOnFailure(new SingleAction<SubscribeFailureArgs>() {
                        public void invoke(SubscribeFailureArgs e) {
                            //Logger.error("Subscription to channel failed " + e.getChannel());
                        }
                    });
                    setOnReceive(new SingleAction<SubscribeReceiveArgs>() {
                        public void invoke(final SubscribeReceiveArgs e) {
                            try {
                                Object message = e.getDataJson();
                                if (null != message) {
                                    //Logger.error(" Inside WebOneonene" + message.toString());
                                    final JSONObject receivedMessage = new JSONObject(message.toString());
                                    if (receivedMessage.has(CometChatKeys.AjaxKeys.MESSAGE)) {
                                        if (TextUtils.isEmpty(receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE))) {
                                            return;
                                        }
                                    }
                                    if (!receivedMessage.has(CometChatKeys.AjaxKeys.ID)) {
                                        receivedMessage.put(CometChatKeys.AjaxKeys.ID,
                                                receivedMessage.getString(DatabaseKeys.ColoumnKeys.SENT));
                                    }
                                    final long buddyId = receivedMessage.getLong(CometChatKeys.AjaxKeys.FROM);
                                    final Buddy buddy = Buddy.getBuddyDetails(buddyId);
                                    final String messageReceived = receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE);
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
                                                                                    receivedMessage.put(CometChatKeys.AjaxKeys.MESSAGE,
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
                                                }, 1);
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
                                                        receivedMessage.put(CometChatKeys.AjaxKeys.MESSAGE, translatedMessage + " ("
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
                            } catch (Exception ex) {
                                ex.printStackTrace();
                            }
                        }
                    });
                }});
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    private void handleMessage(long buddyId, JSONObject receivedMessage) {
        try {
            MessageHelper.getInstance().handleOneOnOneMessage(Buddy.getBuddyDetails(buddyId),
                    receivedMessage);

            String mess = receivedMessage.getString(CometChatKeys.AjaxKeys.MESSAGE);
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
        } catch (Exception e) {
            e.printStackTrace();
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
}
