/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;

public class ReportConversation {

    public static boolean isDisabled() {
        return JsonPhp.getInstance().getReportEnabled().equals("0");
    }

    public static void report(final Long windowId, final String reasonForReporting) {
        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getReportConversationURL(),
                new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                                URLFactory.getReportConversationURL());
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ID, windowId);
                        vHelper.addNameValuePair(CometChatKeys.ReportKeys.REPORT_ISSUE, reasonForReporting);
                        vHelper.addNameValuePair(CometChatKeys.ReportKeys.RANDOM, response);
                        vHelper.sendAjax();
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {

                    }
                });
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ID, windowId);
        vHelper.sendAjax();
    }
}
