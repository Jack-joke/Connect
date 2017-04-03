/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.cometchat.sdk;

import android.content.Context;
import android.text.TextUtils;
import android.view.ViewGroup;
import android.widget.RelativeLayout;

import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

import fm.SingleAction;
import fm.android.conference.webrtc.App;
import fm.icelink.webrtc.DefaultProviders;

public class Screenshare {

    private Context context;
    private static Screenshare screenshare;
    private String roomName;
    private App app;
    private String webasyncURL = "https://r.chatforyoursite.com:8443/websync.ashx",
            iceLinkServerAddress = "r.chatforyoursite.com";
    private static RelativeLayout relativeLayoutForRotationHandling;

    public static Screenshare getScreenshareInstance(Context context) {
        if (null == screenshare) {
            screenshare = new Screenshare(context);
        }
        return screenshare;

    }

    private Screenshare(Context context) {
        this.context = context;
    }

    public void startScreenShare(String callid, final RelativeLayout container, Callbacks callbacks){
        if (android.os.Build.VERSION.SDK_INT < 16) {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_SUPPORTED,
                    CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_NOT_SUPPORTED));
            return;
        }

        if (CometChat.isLoggedIn()) {
            if (TextUtils.isEmpty(callid)) {
                // Logger.error("tempname =" + tempName);
                callbacks.failCallback(CommonUtils.createErrorJson(
                        CometChatKeys.ErrorKeys.CODE_AVCHAT_CALL_DETAILS_NOT_FOUND,
                        CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_CALL_DETAILS_NOT_FOUND));
            } else {
                if (!SessionData.getInstance().isAvchatCallRunning()) {
                    app = App.getInstance();
                    String webRTCServerAddress = JsonPhp.getInstance().getWebRTCServer();

                    if (null != webRTCServerAddress) {
                        if (webRTCServerAddress.contains("r.chatforyoursite.com")) {
                            webasyncURL = "https://" + webRTCServerAddress + ":8443/websync.ashx";
                            iceLinkServerAddress = webRTCServerAddress;
                        } else {
                            webasyncURL = "http://" + webRTCServerAddress + ":8080/websync.ashx";
                            iceLinkServerAddress = webRTCServerAddress;
                        }
                    }
                    // Logger.error("call id " + callid);
                    String webrtc_prefix = PreferenceHelper.get(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
                    try {
                        if (!TextUtils.isEmpty(webrtc_prefix)) {
                            roomName = EncryptionHelper.encodeIntoMD5(webrtc_prefix + callid);
                        } else {
                            roomName = callid;
                        }
                    } catch (Exception e1) {
                        e1.printStackTrace();
                    }

                    if (!roomName.startsWith("/")) {
                        roomName = "/" + roomName;
                    }
                    if (container == null) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_AVCHAT_CONTAINER_EMPTY,
                                CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_CONTAINER_EMPTY));
                    }
                    if (relativeLayoutForRotationHandling == null) {
                        relativeLayoutForRotationHandling = new RelativeLayout(context);
                        relativeLayoutForRotationHandling.setLayoutParams(new RelativeLayout.LayoutParams(
                                ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT));
                    }

                    DefaultProviders.setAndroidContext(context);
                    SessionData.getInstance().setAvchatCallRunning(true);
                    app.startLocalMedia(new SingleAction<Exception>() {
                        @Override
                        public void invoke(Exception ex) {
                            if (ex == null) {
                                // Start the signalling engine.
                                app.startSignalling(new SingleAction<String>() {
                                    @Override
                                    public void invoke(String ex) {
                                        if (ex != null) {
                                            Logger.error("Error at startSignalling " + ex);
                                        }
                                    }
                                }, webasyncURL, false, false);
                                // Start the conference engine.
                                // Logger.error("Final roomname: " + roomName);

                                app.startConference(iceLinkServerAddress,roomName,true,relativeLayoutForRotationHandling,null,null,null,null,null,null,true,false,new SingleAction<Exception>(){
                                    @Override
                                    public void invoke(Exception ex) {
                                        if (ex != null) {
                                            Logger.error("Error at startconference " + ex.getLocalizedMessage());
                                        }
                                    }
                                });

                            } else {
                                Logger.error("Error at startLocalMedia " + ex.getLocalizedMessage());
                            }
                        }
                    }, false, false);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_USER_BUSY,
                            CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_USER_BUSY));
                }
            }

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }

    }
}
