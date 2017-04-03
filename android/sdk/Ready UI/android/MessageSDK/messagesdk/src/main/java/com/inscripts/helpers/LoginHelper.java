/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.content.Intent;
import android.text.TextUtils;

import com.inscripts.activities.LoginActivity;
import com.inscripts.factories.URLFactory;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

public class LoginHelper {

    public static void checkLoginTypeAndStart(Context context) {
        MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
        Intent intent = null;

        intent = new Intent(context, LoginActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

        intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
        context.startActivity(intent);
    }

    /**
     * Checks if the domain belongs to CometOnDemand or not. successCallback will fire the final URL.
     *
     * @param context
     * @param url                 the initial url entered by the user
     * @param volleyAjaxCallbacks
     */
    public static void checkDomain(final Context context, final String url, final VolleyAjaxCallbacks volleyAjaxCallbacks) {

        // Check for CoD
        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCometOnDemandCheckerURL() + url, new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Logger.error(response);
                    if (!TextUtils.isEmpty(response)) {
                        JSONObject codRespone = new JSONObject(response);
                        if (codRespone.getInt("cod") == 0) {

                            // Try normal CC installation.
                            SessionData.getInstance().setIsCometOnDemand(false);
                            volleyAjaxCallbacks.successCallback(url);
                            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.COD_ID);
                        } else if (codRespone.getInt("cod") == -1) {

                            // CoD trial/subscription expired.
                            volleyAjaxCallbacks.failCallback(StaticMembers.DOMAIN_ERROR, false);
                            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.COD_ID);
                            SessionData.getInstance().setIsCometOnDemand(false);
                        } else {

                            // Valid CoD URL. Save the IDENTIFIER into preferences for later use.
                            SessionData.getInstance().setIsCometOnDemand(true);
                            PreferenceHelper.save(PreferenceKeys.DataKeys.COD_ID, codRespone.getString("cod"));
                            volleyAjaxCallbacks.successCallback("http://" + codRespone.getString("cod") + URLFactory.getCodUrl());
                        }
                    } else {

                        // API is not working. Try normal CC installation.
                        volleyAjaxCallbacks.successCallback(url);
                        SessionData.getInstance().setIsCometOnDemand(false);
                        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.COD_ID);
                    }
                } catch (Exception e) {
                    volleyAjaxCallbacks.failCallback(e.getLocalizedMessage(), false);
                    SessionData.getInstance().setIsCometOnDemand(false);
                    PreferenceHelper.removeKey(PreferenceKeys.DataKeys.COD_ID);
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                volleyAjaxCallbacks.failCallback(response, isNoInternet);
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.COD_ID);
            }
        });
        vHelper.sendAjax();
    }

}
