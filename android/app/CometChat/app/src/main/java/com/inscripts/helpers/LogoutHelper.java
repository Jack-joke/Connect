/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Intent;

import com.google.firebase.messaging.FirebaseMessaging;
import com.inscripts.activities.UrlInitializerActivityNew;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.plugins.SocialAuth;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SessionData;

public class LogoutHelper {

    public static void chatLogout() {
        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getLogoutURL());
        vHelper.sendAjax();

		/* Stop both heartbeats */

        HeartbeatOneOnOne.getInstance().stopHeartbeatOneOnOne();
        HeartbeatChatroom.getInstance().stopHeartbeatChatroom();
        HybridHeartbeat.getInstance().stopHeartbeatHybrid();

		/* if cometservice is enabled unsubscribe from channel */
        if (null != JsonPhp.getInstance().getConfig() && JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
            String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
            if (transport.equals("cometservice")) {
                CometserviceChatroom.getInstance().unSubscribe();
            } else if (transport.equals("cometservice-selfhosted")) {
                WebsyncChatroom.getInstance().unsubscribe();
            }
        }
        //PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
        SocialAuth.logout();
        PushNotificationsManager.clearAllNotifications();
        PushNotificationsManager.unsubscribeAll();
        if(SessionData.getInstance().getParseChannel()!=null)
        FirebaseMessaging.getInstance().unsubscribeFromTopic(SessionData.getInstance().getParseChannel());
        PreferenceHelper.cleanUp();
        if (LocalConfig.isWhiteLabelled()) {
            LoginHelper.checkLoginTypeAndStart(PreferenceHelper.getContext());
        } else {
            Intent intent = new Intent(PreferenceHelper.getContext(), UrlInitializerActivityNew.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            PreferenceHelper.getContext().startActivity(intent);
        }
    }


}