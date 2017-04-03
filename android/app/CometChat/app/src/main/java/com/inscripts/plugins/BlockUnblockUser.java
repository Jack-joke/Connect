/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.content.Context;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys.AjaxKeys;

import org.json.JSONObject;

public class BlockUnblockUser {

    public static boolean isblockUnblockDisabled() {
        return JsonPhp.getInstance().getBlockUserEnabled() == null || JsonPhp.getInstance().getBlockUserEnabled()
                .equals("0");
    }

    public static void blockUser(long buddyId, Context context, final CometchatCallbacks callbacks) {
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getBlockUserURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    // Logger.error("block response "+msg.obj.toString());
                    JSONObject blockresponse = new JSONObject(response);
                    String result = blockresponse.getString("result");
                    if (result.equals("1")) {
                        callbacks.successCallback();
                    } else {
                        callbacks.failCallback();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                callbacks.failCallback();
            }
        });
        vHelper.addNameValuePair(AjaxKeys.TO, buddyId);
        vHelper.sendAjax();
    }
}
