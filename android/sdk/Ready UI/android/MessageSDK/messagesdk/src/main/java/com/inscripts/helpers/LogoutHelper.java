/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import com.inscripts.factories.URLFactory;
import com.inscripts.utils.LocalConfig;

public class LogoutHelper {

    public static void chatLogout() {
        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getLogoutURL());
        vHelper.sendAjax();

		/* Stop both heartbeats */
      /*  HeartbeatOneOnOne.getInstance().stopHeartbeatOneOnOne();
        HeartbeatChatroom.getInstance().stopHeartbeatChatroom();*/

		/* if cometservice is enabled unsubscribe from channel */
       /* if (null != JsonPhp.getInstance().getConfig() && JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
            String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
            if (transport.equals("cometservice")) {
                CometserviceChatroom.getInstance().unSubscribe();
            } else if (transport.equals("cometservice-selfhosted")) {
                WebsyncChatroom.getInstance().unsubscribe();
            }
        }*/
        //PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
        /*PushNotificationsManager.clearAllNotifications();
        PushNotificationsManager.unsubscribeAll();*/
        PreferenceHelper.cleanUp();
        if (LocalConfig.isWhiteLabelled()) {
            LoginHelper.checkLoginTypeAndStart(PreferenceHelper.getContext());
        } else {
           // Intent intent = new Intent(PreferenceHelper.getContext(), UrlInitializerActivity.class);
            //intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            //intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
           // intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            //PreferenceHelper.getContext().startActivity(intent);
        }
    }


}