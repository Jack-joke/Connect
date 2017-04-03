/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/

package com.inscripts.cometchat.sdk;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Message;
import android.telephony.TelephonyManager;
import android.text.TextUtils;

import com.google.gson.Gson;
import com.inscripts.enums.Languages;
import com.inscripts.enums.StatusOption;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.FileUploadHelper;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.SubscribeCallbacks;
import com.inscripts.interfaces.SubscribeChatroomCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.ErrorKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.keys.PreferenceKeys.DataKeys;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.ReportConversation;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.regex.Pattern;

@SuppressLint("HandlerLeak")
public class CometChat {

    private Context context;
    private int attempt = 0, isCCattempt = 1;
    private boolean useComet = false;
    private SessionData sessionData;
    private long minHeartbeat;
    public static boolean useHTML = false;
    private static CometChat cometchat;
    private String originalUrl;
    protected static boolean isSubscribedCalled = false;

	/*This is for COD */
    /**
     * Initialize the <b>CometChat</b> module.
     *
     * @param context
     * @param APIkey
     */

	/*public static CometChat getInstance(Context context, String apikey) throws IllegalArgumentException {
        if (null == cometchat) {
			cometchat = new CometChat(context);
		}
		PreferenceHelper.save(PreferenceKeys.DataKeys.API_KEY, apikey.trim());
		URLFactory.buildBaseCodUrl();
		return cometchat;
	}*/

	/*This is for normal CometChat*/

    /**
     * @param context
     * @param apikey  Pass apikey if you wish to use our Usermanagement functionality, else pass ""
     * @throws IllegalArgumentException
     */
    public static CometChat getInstance(Context context, String apikey) throws IllegalArgumentException {
        if (null == cometchat) {
            cometchat = new CometChat(context);
        }
        if (null == apikey) {
            apikey = "";
        }

        PreferenceHelper.save(DataKeys.API_KEY, apikey.trim());
/*        TelephonyManager telephonyManager = (TelephonyManager)context.getSystemService(Context.TELEPHONY_SERVICE);
        JSONObject deviceInfo = new JSONObject();

        try {
            PackageInfo packageinfo = context.getPackageManager().getPackageInfo(context.getPackageName(), 0);
            deviceInfo.put("d",android.os.Build.MODEL);
            deviceInfo.put("imei",telephonyManager.getDeviceId());
            JSONObject os = new JSONObject();
            os.put("n","a");
            os.put("v",android.os.Build.VERSION.SDK_INT);
            deviceInfo.put("os",os);
            deviceInfo.put("v",packageinfo.versionName.toString());

        } catch (JSONException e) {
            e.printStackTrace();
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }

        PreferenceHelper.save(DataKeys.APP_INFO,deviceInfo.toString());*/
        return cometchat;
    }

    private CometChat(Context context) {
        this.context = context;
        PreferenceHelper.initialize(this.context);
        sessionData = SessionData.getInstance();
        if (PreferenceHelper.contains(DataKeys.BASE_DATA)) {
            sessionData.setBaseData(PreferenceHelper.get(DataKeys.BASE_DATA));
        } else {
            sessionData.setBaseData("");
        }

    }

	/*COD login functions*/

    /**
     * Login to Cometchat, with your userName and password.<br>
     * <b>All local data related to the previous user will be cleared</b>.
     *
     * @param userName
     * @param password
     * @param callbacks
     * @throws IllegalArgumentException
     */

	/*public void login(final String userName, final String password, final Callbacks callbacks)
            throws IllegalArgumentException {

		attempt = 0;
		if (!TextUtils.isEmpty(userName)) {
			if (!TextUtils.isEmpty(password)) {
				// PreferenceHelper.cleanUp();
				chatLogin(URLFactory.getBaseURL(), userName, password, false, false, callbacks);

			} else {
				throw new IllegalArgumentException("Password cannot be NULL. password cannot have 0 length.");
			}
		} else {
			throw new IllegalArgumentException("Username cannot be NULL. Username cannot have 0 length.");
		}
	}*/

    /**
     * Login to CometChat with your userId. <b>All local data related to the
     * previous user will be cleared</b>.
     *
     * @param userId    userId
     * @param callbacks callbacks
     * @throws IllegalArgumentException
     */

	/*public void login(String userId, Callbacks callbacks) throws IllegalArgumentException {
        // Kept zero to disable retry attempts.
		attempt = 0;
		if (!TextUtils.isEmpty(userId)) {
			// PreferenceHelper.cleanUp();
			chatLogin(URLFactory.getBaseURL(), userId, "cometchat", true, false, callbacks);
		} else {
			throw new IllegalArgumentException("UserId cannot be NULL. userId cannot have 0 length.");
		}
	}*/

	/* COD login function ends */

	/* Normal login functions */
    public void login(String siteUrl, String userName, String password, Callbacks callbacks)
            throws IllegalArgumentException {

        attempt = 0;
        if (!TextUtils.isEmpty(siteUrl)) {
            if (!TextUtils.isEmpty(userName)) {
                if (!TextUtils.isEmpty(password)) {
                    PreferenceHelper.cleanUp();
                    // Check if url contains http:// // or https://
                    if (!(siteUrl.contains(URLFactory.PROTOCOL_PREFIX) || siteUrl
                            .contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                        siteUrl = URLFactory.PROTOCOL_PREFIX + siteUrl;
                    }

                    if (!siteUrl.endsWith("/")) {
                        siteUrl += "/";
                    }

                    PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, siteUrl);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                    chatLogin(URLFactory.getBaseURL(), userName, password, false, false, callbacks);
                } else {
                    throw new IllegalArgumentException("Password cannot be NULL. password cannot have 0 length.");
                }
            } else {
                throw new IllegalArgumentException("Username cannot be NULL. Username cannot have 0 length.");
            }
        } else {
            throw new IllegalArgumentException("SiteUrl cannot be NULL. siteUrl cannot have 0 length.");
        }
    }

    /**
     * Login to CometChat as guest user
     *
     * @param siteUrl   Url where your CometChat is hosted
     * @param guestName Name by which guest user is going to log-in
     * @param callbacks callbacks
     */

    public void guestLogin(String siteUrl, String guestName, Callbacks callbacks) throws IllegalArgumentException {
        attempt = 0;
        if (!TextUtils.isEmpty(siteUrl)) {
            if (!TextUtils.isEmpty(guestName)) {
                // Check if url contains http:// or https://
                if (!(siteUrl.contains(URLFactory.PROTOCOL_PREFIX) || siteUrl
                        .contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                    siteUrl = URLFactory.PROTOCOL_PREFIX + siteUrl;
                }
                if (!siteUrl.endsWith("/")) {
                    siteUrl += "/";
                }
                PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, siteUrl);
                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                chatLogin(URLFactory.getBaseURL(), guestName, "CC^CONTROL_GUEST", false, true, callbacks);
            } else {
                throw new IllegalArgumentException("GuestUserName cannot be NULL. GuestUserName cannot have 0 length.");
            }
        } else {
            throw new IllegalArgumentException("SiteUrl cannot be NULL. siteUrl cannot have 0 length.");
        }
    }

    public void login(String siteUrl, String userId, Callbacks callbacks) throws IllegalArgumentException {
        // Kept zero to disable retry attempts.
        attempt = 0;
        if (!TextUtils.isEmpty(siteUrl)) {
            if (!TextUtils.isEmpty(userId)) {
                PreferenceHelper.cleanUp();
                // Check ifurl contains http:// or https://
                if (!(siteUrl.contains(URLFactory.PROTOCOL_PREFIX) || siteUrl
                        .contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                    siteUrl = URLFactory.PROTOCOL_PREFIX + siteUrl;
                }
                if (!siteUrl.endsWith("/")) {
                    siteUrl += "/";
                }
                PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, siteUrl);
                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                chatLogin(URLFactory.getBaseURL(), userId, "cometchat", true, false, callbacks);
            } else {
                throw new IllegalArgumentException("UserId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            throw new IllegalArgumentException("SiteUrl cannot be NULL. siteUrl cannot have 0 length.");
        }
    }

	/* Normal login function ends */

    /**
     * Ends the current session and clears all the data.
     */
    public void logout(final Callbacks callbacks) {
        if (isLoggedIn()) {

            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getLogoutURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    HeartbeatOneOnOne.getInstance((SubscribeCallbacks)null).stopHeartbeatOneOnOne();
                    HeartbeatChatroom.getInstance((SubscribeChatroomCallbacks) null).stopHeartbeatChatroom();

                    if (useComet) {
                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        CometserviceOneOnOne.getInstance().unSubscribe();
                        if (!TextUtils.isEmpty(transport)) {
                            if (transport.equals("cometservice")) {
                                CometserviceOneOnOne.getInstance().unSubscribe();
                            } else {
                                WebsyncOneOnOne.getInstance().unsubscribe();
                            }
                        }
                    }
                    PreferenceHelper.cleanUp();

                    try {
                        JSONObject json = new JSONObject();
                        json.put("message", "Logout successful");
                        callbacks.successCallback(json);
                    } catch (Exception e) {
                        e.printStackTrace();
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_RANDOM_EXCEPTION,
                                ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                    }
                }
            });
            vHelper.sendAjax();

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Send a message to the userId specified. NULL or empty messages will not
     * be sent.
     */
    public void sendMessage(String toId, String message, final Callbacks callbacks) throws IllegalArgumentException {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(toId)) {
                if (!TextUtils.isEmpty(message)) {
                    if (!useComet) {
                        resetOneOnOneHeartbeatInterval();
                    }
                    VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getSendOneToOneMessageURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    try {
                                        if (useHTML) {
                                            JSONObject modifiedMessage = new JSONObject(response);
                                            modifiedMessage.put("m",
                                                    Smilies.convertImageTagToEmoji(modifiedMessage.getString("m")));
                                            callbacks.successCallback(modifiedMessage);
                                        } else {
                                            callbacks.successCallback(new JSONObject(response));
                                        }
                                    } catch (Exception e) {

                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (isNoInternet) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_JSON_PARSING_ERROR,
                                                ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                                    } else {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }

                            });

                    vHelper.addNameValuePair(AjaxKeys.MESSAGE, message);
                    vHelper.addNameValuePair(AjaxKeys.TO, toId);
                    vHelper.sendAjax();
                } else {
                    throw new IllegalArgumentException("message cannot be NULL. message cannot have 0 length.");
                }
            } else {
                throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void setStatus(StatusOption status, final Callbacks callbacks) {
        if (isLoggedIn()) {

            String statusForAjax;

            switch (status) {
                case AVAILABLE:
                    statusForAjax = CometChatKeys.StatusKeys.AVALIABLE;
                    break;
                case OFFLINE:
                    statusForAjax = CometChatKeys.StatusKeys.OFFLINE;
                    break;
                case INVISIBLE:
                    statusForAjax = CometChatKeys.StatusKeys.INVISIBLE;
                    break;
                case BUSY:
                    statusForAjax = CometChatKeys.StatusKeys.BUSY;
                    break;
                default:
                    statusForAjax = CometChatKeys.StatusKeys.AVALIABLE;
                    break;
            }
            PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, statusForAjax);

            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getSendOneToOneMessageURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                JSONObject json = new JSONObject();
                                json.put("message", "Status changed.");
                                callbacks.successCallback(json);
                                SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                        ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                            }
                        }
                    });
            vHelper.addNameValuePair(CometChatKeys.StatusKeys.STATUS, statusForAjax);
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void setStatusMessage(String statusMessage, final Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(statusMessage)) {
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getSendOneToOneMessageURL(),
                        new VolleyAjaxCallbacks() {

                            @Override
                            public void successCallback(String response) {
                                try {
                                    JSONObject json = new JSONObject();
                                    json.put("message", "Status message changed.");
                                    callbacks.successCallback(json);
                                    SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                } catch (JSONException e) {
                                    e.printStackTrace();
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if (isNoInternet) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                } else {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                }
                            }
                        });
                vHelper.addNameValuePair(CometChatKeys.StatusKeys.STATUS_MESSAGE, statusMessage);
                vHelper.sendAjax();
            } else {
                throw new IllegalArgumentException("statusMessage cannot be NULL. statusMessage cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendImage(File imageFile, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                if (imageFile != null && imageFile.exists()) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(imageFile, userId, false, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendImage(Bitmap bitmap, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (null == bitmap) {
                throw new IllegalArgumentException("bitmap cannot be null");
            } else {
                if (!TextUtils.isEmpty(userId)) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(bitmap, userId, false, "IMG" + System.currentTimeMillis() + ".jpg",
                            callbacks);
                } else {
                    throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
                }
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }


    /**
     * Get the user details corresponding to the <i>userId</i>.
     *
     * @param userId
     */
    public void getUserInfo(String userId, final Callbacks callbacks) throws IllegalArgumentException {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getInfoFromId(), new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            callbacks.successCallback(new JSONObject(response));
                        } catch (Exception e) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_JSON_PARSING_ERROR,
                                    ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                    ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                    ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                        }
                    }

                });
                vHelper.addNameValuePair(AjaxKeys.USERID, userId);
                vHelper.sendAjax();

            } else {
                throw new IllegalArgumentException("UserId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Returns the list of currently active users.
     */
    public void getOnlineUsers(final Callbacks callbacks) {
        if (isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getRecieveURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    try {
                        JSONObject list = new JSONObject(response);
                        callbacks.successCallback(list.getJSONObject(AjaxKeys.BUDDY_LIST));
                    } catch (Exception e) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_JSON_PARSING_ERROR,
                                ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                    }
                }

            });
            vHelper.addNameValuePair(AjaxKeys.INITIALIZE, "1");
            vHelper.addNameValuePair(AjaxKeys.BUDDY_LIST, "1");
            vHelper.addNameValuePair(AjaxKeys.FORCE_LIST, "1");
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    private void chatLogin(final String baseURL, final String userId, final String password,
                           final boolean isUserIdLogin, final boolean isGuestLogin, final Callbacks callbacks) {
        try {
            /* Validation */
            if (!PreferenceHelper.contains(DataKeys.BASE_DATA)) {
                PreferenceHelper.save(DataKeys.BASE_DATA, "");
            }
            VolleyAjaxCallbacks vCallbacks = new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    //Logger.error("success callback login " + response);
                    Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                    if (htmlPattern.matcher(response).matches()) {
                        failCallback(response, false);
                    }
                    try {
                        if (isJSONValid(response)) {
                            final String baseData = new JSONObject(response).getString(AjaxKeys.BASE_DATA);
                            if (!TextUtils.isEmpty(baseData) && !"0".equalsIgnoreCase(baseData)) {
                                /* Valid user */
                                SessionData.getInstance().setBaseData(baseData);
								/*if (PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
									if (!baseData.equalsIgnoreCase(PreferenceHelper
											.get(PreferenceKeys.DataKeys.BASE_DATA))) {
									}
								}*/
                                if (!PreferenceHelper.get(PreferenceKeys.LoginKeys.OLD_LOGIN_URL).equalsIgnoreCase(
                                        URLFactory.getLoginURL())) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL,
                                            URLFactory.getLoginURL());
                                }

                                PreferenceHelper.save(DataKeys.BASE_DATA, baseData);
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN,
                                        CometChatKeys.LoginKeys.USER_LOGGED_IN);

                                JSONObject json = new JSONObject();
                                json.put("message", "Login successful");
                                callbacks.successCallback(json);

                            } else if ("-1".equals(baseData)) {
                                JSONObject json = new JSONObject();
                                json.put("message", "Incorrect username");
                                callbacks.failCallback(json);
                            } else {
                                if (isUserIdLogin) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_USERID_WRONG,
                                            ErrorKeys.MESSAGE_WRONG_USERID));
                                } else {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_USERNAME_PASSWORD_WRONG,
                                            ErrorKeys.MESSAGE_WRONG_USERNAME_PASSWORD));
                                }
                            }
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_VERSION_OLD,
                                    ErrorKeys.MESSAGE_PLEASE_UPGRADE_COMETCHAT));
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_RANDOM_EXCEPTION,
                                ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        if (PreferenceHelper.contains(DataKeys.API_KEY)) {
                            if (response.equals(StaticMembers.DOMAIN_ERROR)) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_SUBSCRIPTION_EXPRIED, response));
                            } else {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_PLAN_NOT_SUPPORTED, response));
                            }
                        } else {
                            if (attempt == 1) {
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);
                                attempt = 2;
                                chatLogin(baseURL, userId, password, isUserIdLogin, isGuestLogin, callbacks);
                            } else if (attempt == 2) {
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);
                                attempt = 3;
                                chatLogin(baseURL, userId, password, isUserIdLogin, isGuestLogin, callbacks);
                            } else if (attempt == 3) {
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);
                                // attempt = 1;
                                chatLogin(baseURL, userId, password, isUserIdLogin, isGuestLogin, callbacks);
                            } else {
                                PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                        StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                                // attempt = 1;
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_INVALID_URL,
                                        ErrorKeys.MESSAGE_INVALID_URL));
                            }
                        }
                    }
                }
            };

			/* Send login AJAX request to the server */
            if (!PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL)) {
                PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
            }
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getLoginURL(), vCallbacks);
            vHelper.addNameValuePair(AjaxKeys.USERNAME, userId);
            vHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
            if (isGuestLogin) {
                vHelper.addNameValuePair(AjaxKeys.GUEST_LOGIN, "1");
            }
            vHelper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_RANDOM_EXCEPTION,
                    ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
        }
    }

    /**
     * Start receiving messages, user's list and your cc_profile data.
     *
     * @param htmlFlag : If set then emojis will be represnted by their short forms <br>
     *                 If unset then emojis will be represented by HTML tags
     */
    public void subscribe(final boolean htmlFlag, final SubscribeCallbacks callbacks) {

        if (isLoggedIn()) {
            if (isSubscribedCalled) {
                useHTML = htmlFlag;

                Long interval = 0L;
                Config config = JsonPhp.getInstance().getConfig();
                useComet = config.getUSECOMET().equals("1");
                minHeartbeat = Long.parseLong(config.getMinHeartbeat());
                sessionData.setInitialHeartbeat(true);
                sessionData.setActiveAVchatUserID("0");
                sessionData.setAvchatCallRunning(false);
                sessionData.setAvChatRoomName("");
                if (useComet) {
                    interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                    sessionData.setOneOnOneHeartbeatInterval(interval);
                } else {
                    interval = Long.parseLong(config.getMinHeartbeat());
                    sessionData.setOneOnOneHeartbeatInterval(interval);
                }

                if(CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion())>= 630){
                    HybridHeartbeat.getInstance(callbacks).startHeartbeat(context);
                }else{
                    HeartbeatOneOnOne.getInstance(callbacks).startHeartbeat(context);
                }

                if (!PreferenceHelper.contains(DataKeys.SELECTED_LANGUAGE)) {
                    PreferenceHelper.save(DataKeys.SELECTED_LANGUAGE, "");
                }
            } else {
                initializeJsonPhp(new Callbacks() {

                    @Override
                    public void successCallback(JSONObject response) {
                        isSubscribedCalled = true;
                        useHTML = htmlFlag;
						/*if (htmlFlag) {
							Smilies.InitializeMapping();
						}*/

                        Long interval = 0L;
                        HeartbeatOneOnOne heartbeatOneOnOne = HeartbeatOneOnOne.getInstance(callbacks);
                        Config config = JsonPhp.getInstance().getConfig();
                        useComet = config.getUSECOMET().equals("1");
                        minHeartbeat = Long.parseLong(config.getMinHeartbeat());
                        sessionData.setInitialHeartbeat(true);
                        sessionData.setActiveAVchatUserID("0");
                        sessionData.setAvchatCallRunning(false);
                        sessionData.setAvChatRoomName("");
                        if (useComet) {
                            interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                            sessionData.setOneOnOneHeartbeatInterval(interval);
                        } else {
                            interval = Long.parseLong(config.getMinHeartbeat());
                            sessionData.setOneOnOneHeartbeatInterval(interval);
                        }
                        if(CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion())>= 630){
                            HybridHeartbeat.getInstance(callbacks).startHeartbeat(context);
                        }else{
                            HeartbeatOneOnOne.getInstance(callbacks).startHeartbeat(context);
                        }
                    }

                    @Override
                    public void failCallback(JSONObject response) {
                        callbacks.onError(response);
                    }
                });

                if (!PreferenceHelper.contains(DataKeys.SELECTED_LANGUAGE)) {
                    PreferenceHelper.save(DataKeys.SELECTED_LANGUAGE, "");
                }
            }
        } else {
            CommonUtils.sendCallBackError(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacks);
        }
    }

    /**
     * Fetch the conversation between you and the userId passed
     *
     * @param userId    : ID of the user who's conversation you wish to fetch
     * @param messageId : The ID of the oldest message present in the application. The
     *                  server will return messages exchanged prior to this ID
     * @param callbacks : Callbacks for receiving the response
     */
    public void getChatHistory(Long userId, Long messageId, final Callbacks callbacks) {

        VolleyHelper volley = new VolleyHelper(context, URLFactory.getRecieveURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(final String response) {

                new AsyncTask<Void, Void, Void>() {

                    @Override
                    protected Void doInBackground(Void... params) {
                        try {
                            JSONArray allMessages = new JSONArray();
                            JSONObject messages;

                            if (!"[]".equals(response)) {
                                messages = new JSONObject(response);
                                messages = messages.getJSONObject(AjaxKeys.MESSAGES);
                                if (messages.length() > 0) {

									/* New Messages have arrived */
                                    Iterator<String> iterator = messages.keys();
                                    List<String> sortedKeys = new ArrayList<String>();
                                    while (iterator.hasNext()) {
                                        sortedKeys.add(iterator.next());
                                    }

                                    Collections.sort(sortedKeys);
                                    for (String messageId : sortedKeys) {
                                        JSONObject message = messages.getJSONObject(messageId);
                                        message = MessageHelper.getInstance().handleOneOnOneMessage(message, null,
                                                false);
                                        if (null != message) {
                                            // Populate messages for history
                                            allMessages.put(message);
                                        }
                                    }
                                }
                            }

                            messages = new JSONObject();
                            messages.put("history", allMessages);
                            callbacks.successCallback(messages);
                        } catch (Exception e) {
                            e.printStackTrace();
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_JSON_PARSING_ERROR,
                                    ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                        }
                        return null;
                    }
                }.execute();
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                }
            }


        });

        volley.addNameValuePair(AjaxKeys.CHATBOX, userId);
        volley.addNameValuePair(AjaxKeys.PREPEND, messageId);
        volley.sendAjax();
    }

    /**
     * Resets the heartbeat timing to minimum <br>
     * <p>
     * Use this method only when cometservice is not in use to reset heartbeat interval after sending chat message.
     * </p>
     */
    private void resetOneOnOneHeartbeatInterval() {
        sessionData.setOneOnOneHeartBeatIdealCount(1);
        if (useComet) {
            sessionData.setOneOnOneHeartbeatInterval(Long.parseLong(JsonPhp.getInstance().getConfig()
                    .getREFRESHBUDDYLIST()) * 1000);
        } else {
            if (sessionData.getOneOnOneHeartbeatInterval() > minHeartbeat) {
                sessionData.setOneOnOneHeartbeatInterval(minHeartbeat);
                HeartbeatOneOnOne.getInstance((SubscribeCallbacks)null).changeOneOnOneHeartbeatInverval();
            }
        }
    }

    /**
     * Checks the user's login status. Returns <i>true</i> if the user is logged
     * in, <i>false</i> otherwise.
     */
    public static boolean isLoggedIn() {
        return (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN) && ("1".equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN))));
    }

    /**
     * This function will unsubscribe your app from cometchat, hence no messages
     * will be received.<br>
     * <p>
     * <b>This function must be called in onDestroy of activity where Cometchat is initialized</b>
     * </p>
     */
    public void unsubscribe() {
        if (isLoggedIn()) {
            HeartbeatOneOnOne.getInstance((SubscribeCallbacks) null).stopHeartbeatOneOnOne();
            if (useComet) {
                String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                CometserviceOneOnOne.getInstance().unSubscribe();
                if (!TextUtils.isEmpty(transport)) {
                    if (transport.equals("cometservice")) {
                        CometserviceOneOnOne.getInstance().unSubscribe();
                    } else {
                        WebsyncOneOnOne.getInstance().unsubscribe();
                    }
                }
            }
        }
    }

    /**
     * Fetch the latest settings from the admin panel and set them into the
     * preferences
     */
    void initializeJsonPhp(final Callbacks callbacks) {
        try {
            VolleyHelper vhHelper = new VolleyHelper(context, URLFactory.getJsonPhpURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    if (response.length() > 0) {
                        try {
                            Gson gson = new Gson();
                            JsonPhp.setInstance(gson.fromJson(response, JsonPhp.class));
                            PreferenceHelper.save(DataKeys.JSON_PHP_DATA, response);
                            callbacks.successCallback(new JSONObject(response));
                        } catch (Exception e) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_INITAL_SETTING_ERROR,
                                    ErrorKeys.MESSAGE_JSONPHP_ERROR));
                            e.printStackTrace();
                        }
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_INITAL_SETTING_ERROR,
                                ErrorKeys.MESSAGE_JSONPHP_ERROR));
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                    }
                }


            });
            vhHelper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_RANDOM_EXCEPTION,
                    ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
        }
    }

    private boolean isJSONValid(String test) {
        try {
            new JSONObject(test);
        } catch (Exception ex) {
            return false;
        }
        return true;
    }

    public void blockUser(String toId, final Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(toId)) {
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getBlockUserURL(),
                        new VolleyAjaxCallbacks() {

                            @Override
                            public void successCallback(String response) {
                                try {
                                    JSONObject blockresponse = new JSONObject(response);
                                    String result = blockresponse.getString("result");
                                    if (result.equals("1")) {
                                        callbacks.successCallback(new JSONObject("{\"id\":\""
                                                + blockresponse.getString("id") + "\"}"));
                                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        resetOneOnOneHeartbeatInterval();
                                    } else {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_USER_NOT_BLOCKED,
                                                ErrorKeys.MESSAGE_USER_NOT_BLOCKED));
                                    }
                                } catch (Exception e) {
                                    e.printStackTrace();
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_RANDOM_EXCEPTION,
                                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if (isNoInternet) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                } else {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_RANDOM_EXCEPTION,
                                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                                }
                            }
                        });
                vHelper.addNameValuePair(AjaxKeys.TO, toId);
                vHelper.sendAjax();
            } else {
                throw new IllegalArgumentException("To id cannot be NULL. To id cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void unblockUser(String toId, final Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(toId)) {
                if (toId.equals(String.valueOf(sessionData.getId()))) {
                    throw new IllegalStateException("Logged in user can not be blocked");
                }
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getUnblockUserURL(),
                        new VolleyAjaxCallbacks() {

                            @Override
                            public void successCallback(String response) {
                                try {
                                    JSONObject blockresponse = new JSONObject(response);
                                    String result = blockresponse.getString("result");
                                    if (result.equals("1")) {
                                        JSONObject json = new JSONObject();
                                        json.put("id", blockresponse.getString("id"));
                                        callbacks.successCallback(json);
                                    } else {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_USER_NOT_UNBLOCKED,
                                                ErrorKeys.MESSAGE_USER_NOT_UNBLOCKED));
                                    }
                                } catch (Exception e) {
                                    e.printStackTrace();
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_RANDOM_EXCEPTION,
                                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if (isNoInternet) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                } else {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_RANDOM_EXCEPTION,
                                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                                }

                            }
                        });

                vHelper.addNameValuePair(AjaxKeys.TO, toId);
                vHelper.sendAjax();
            } else {
                throw new IllegalArgumentException("To id cannot be NULL. To id cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void getBlockedUserList(final Callbacks callbacks) {
        if (isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getBlockedUserURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    try {
                        callbacks.successCallback(new JSONObject(response));
                    } catch (Exception e) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_JSON_PARSING_ERROR,
                                ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                        e.printStackTrace();
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else {
                        callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_RANDOM_EXCEPTION,
                                ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                    }
                }

            });
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void getAllAnnouncements(final Callbacks callbacks) {
        if (isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAnnouncementUrl(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                callbacks.successCallback(new JSONObject(response));
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                        ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                            }
                        }

                    });
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Sends a video file to specified user
     *
     * @param videoFile Video file to be sent
     * @param userId    'To' id of desired user
     * @param callbacks
     */
    public void sendVideo(File videoFile, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                if (videoFile != null && videoFile.exists()) {
                    VideoSharing videoSharing = new VideoSharing();
                    videoSharing.sendVideoAjax(videoFile, userId, false, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                throw new IllegalArgumentException("UserId cannot be NULL. UserId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Sends a video file to specified user
     *
     * @param filePath  File path of video file to be sent
     * @param userId    'To' id of desired user
     * @param callbacks
     */
    public void sendVideo(String filePath, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                File file = new File(filePath);
                if (file != null && file.exists()) {
                    VideoSharing videoSharing = new VideoSharing();
                    videoSharing.sendVideoAjax(file, userId, false, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public static String getSDKVersion() {
        return "1.6";
    }

    /**
     * @param siteUrl   Siteurl to check CometChat is installed or not
     * @param callbacks
     * @throws IllegalArgumentException
     */
    public void isCometChatInstalled(String siteUrl, final Callbacks callbacks) throws IllegalArgumentException {
        if (TextUtils.isEmpty(siteUrl)) {
            throw new IllegalArgumentException("SiteUrl cannot be NULL. siteUrl cannot have 0 length.");
        } else {
            siteUrl = siteUrl.trim();
            if (!siteUrl.endsWith("/")) {
                siteUrl = siteUrl + "/";
            }

            if (isCCattempt == 1) {
                originalUrl = siteUrl;
            }
            searchCometChat(siteUrl, callbacks);
        }
    }

    private void searchCometChat(String siteUrl, final Callbacks callbacks) {

        final String cometchatUrl = siteUrl;
        siteUrl = siteUrl + "extensions/mobileapp/login.php";
        VolleyHelper vHelper = new VolleyHelper(context, siteUrl, new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                    if (htmlPattern.matcher(response).matches()) {
                        failCallback(response, false);
                    } else {
                        JSONObject json = new JSONObject();
                        json.put("cometchat_url", cometchatUrl);
                        isCCattempt = 1;
                        originalUrl = "";
                        callbacks.successCallback(json);
                    }
                } catch (Exception e) {
                    callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_RANDOM_EXCEPTION,
                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if (isNoInternet) {
                    callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                } else {
                    switch (isCCattempt) {
                        case 1:
                            isCCattempt = 2;
                            searchCometChat(originalUrl + StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1, callbacks);
                            break;
                        case 2:
                            isCCattempt = 3;
                            searchCometChat(originalUrl + StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2, callbacks);
                            break;
                        case 3:
                            isCCattempt = 4;
                            searchCometChat(originalUrl + StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3, callbacks);
                            break;
                        case 4:
                            isCCattempt = 5;
                            searchCometChat(originalUrl + StaticMembers.COMETCHAT_LOGINURL_SUFFIX_4, callbacks);
                            break;
                        default:
                            isCCattempt = 1;
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_COMETCHAT_NOT_FOUND,
                                    ErrorKeys.MESSAGE_COMETCHAT_NOT_FOUND));
                            break;
                    }
                }
            }

        });
        vHelper.sendAjax();

    }

    /**
     * @param activate : Pass <i>true</i> to activate development mode and
     *                 <i>false</i> to deactivate it.
     */
    public static void setDevelopmentMode(boolean activate) {
        if (activate) {
            PreferenceHelper.save(DataKeys.DEVELOPMENT_MODE, "1");
        } else {
            PreferenceHelper.save(DataKeys.DEVELOPMENT_MODE, "0");
        }
    }

    /**
     * The languages used for translating the message are as per the google
     * translator
     *
     * @param language  Select desired language from the enum
     * @param callbacks
     */
    public void setTranslateLanguage(Languages language, Callbacks callbacks) {
        try {
            if (isLoggedIn()) {
                if ((JsonPhp.getInstance().getRealtimeTranslation() != null && JsonPhp.getInstance()
                        .getRealtimeTranslation().equals("1"))
                        && (null != JsonPhp.getInstance().getConfig() && !TextUtils.isEmpty(JsonPhp.getInstance()
                        .getConfig().getRttKey()))) {
                    String langCodes[] = new String[]{"", "af", "sq", "ar", "be", "bg", "ca", "zh-CN", "zh-TW", "hr",
                            "cs", "da", "nl", "en", "et", "tl", "fi", "fr", "gl", "de", "el", "ht", "iw", "hi", "hu",
                            "is", "id", "ga", "it", "ja", "ko", "lv", "lt", "mk", "ms", "mt", "no", "fa", "pl", "pt",
                            "ro", "ru", "sr", "sk", "sl", "es", "sw", "sv", "th", "tr", "uk", "vi", "cy", "yi"};

                    PreferenceHelper.save(DataKeys.SELECTED_LANGUAGE, langCodes[language.ordinal()]);

                    JSONObject json = new JSONObject();
                    json.put("Selected language", language.name());
                    callbacks.successCallback(json);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_CONFIGURE_TRANSLATE_PLUGIN,
                            ErrorKeys.MESSAGE_CONFIGURE_TRANSLATE_PLUGIN));
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                        ErrorKeys.MESSAGE_NOT_LOGGEDIN));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void getPluginInfo(final Callbacks callbacks) {
        try {
            if (isLoggedIn()) {
                initializeJsonPhp(new Callbacks() {

                    @Override
                    public void successCallback(JSONObject response) {
                        try {
                            JSONObject jsonresponse = new JSONObject();
                            JsonPhp json = JsonPhp.getInstance();
                            jsonresponse.put("avchat_enabled", (null == json) ? "0" : json.getAvchatEnabled());
                            jsonresponse.put("audiochat_enabled", (null == json) ? "0" : json.getAudiochatEnabled());
                            jsonresponse.put("createchatroom_enabled",
                                    (null == json) ? "0" : json.getAllowusersCreatechatroom());
                            jsonresponse.put("blockuser_enabled", (null == json) ? "0" : json.getBlockUserEnabled());
                            jsonresponse.put("mediasharing_enabled",

                                    (null == json) ? "0" : json.getFiletransferEnabled());
                            jsonresponse.put("chatroom_mediasharing_enabled",
                                    (null == json) ? "0" : json.getCrfiletransferEnabled());
                            String realtimeCondition = (json.getRealtimeTranslation().equals("1") && !TextUtils
                                    .isEmpty(json.getConfig().getRttKey())) ? "1" : "0";
                            jsonresponse.put("realtime_translate_enabled", (null == json) ? "0" : realtimeCondition);
                            callbacks.successCallback(jsonresponse);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(JSONObject response) {
                        callbacks.failCallback(response);
                    }
                });

            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                        ErrorKeys.MESSAGE_NOT_LOGGEDIN));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void broadcastMessage(String message, JSONArray users, final Callbacks callbacks)
            throws IllegalArgumentException {
        if (CometChat.isLoggedIn()) {
            if (OtherPlugins.isBroadcastMessageEnabled()) {
                if (users.length() > 0) {
                    if (TextUtils.isEmpty(message)) {
                        throw new IllegalArgumentException("message cannot be NULL. message cannot have 0 length.");
                    } else {
                        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getBroadCastMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        try {
                                            JSONObject result = new JSONObject();
                                            JSONArray arr = new JSONArray(response);
                                            result.put("response", (Object) arr);
                                            callbacks.successCallback(result);
                                        } catch (Exception e) {
                                            e.printStackTrace();
                                        }
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            callbacks.failCallback(CommonUtils.createErrorJson(
                                                    ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                                    ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                        }
                                    }

                                });

                        String userIds = "";
                        userIds = users.toString();
                        userIds = userIds.substring(1, userIds.length() - 1);

                        vHelper.addNameValuePair(AjaxKeys.MESSAGE, message);
                        vHelper.addNameValuePair(AjaxKeys.TO, userIds);
                        vHelper.sendAjax();
                    }
                } else {
                    throw new IllegalArgumentException("UserId cannot be NULL. UserId cannot have 0 length.");
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(
                        ErrorKeys.CODE_BROADCAST_MESSAGE_DISABLED,
                        ErrorKeys.MESSAGE_BROADCAST_MESSAGE_DISABLED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendAudioFile(File audioFile, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                if (audioFile != null && audioFile.exists()) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(audioFile, userId, false, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void sendFile(File file, String userId, Callbacks callbacks) {
        if (isLoggedIn()) {
            if (!TextUtils.isEmpty(userId)) {
                if (file != null && file.exists()) {
                    ImageSharing imgSharing = new ImageSharing();
                    imgSharing.sendImageAjax(file, userId, false, callbacks);
                } else {
                    callbacks.failCallback(CommonUtils.createErrorJson(
                            ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
                            ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
                }
            } else {
                throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * Use this function to send the special message to other user regarding are you typing or not
     *
     * @param istyping set true if you are typing, set false when you done with typing
     * @param channel  get the channel from userlist "ch" parameter.<br>
     *                 Note the channel is only available from CometChat v5.7 onwards
     */
    public void isTyping(boolean istyping, String channel, Callbacks callbacks) {
        if (isLoggedIn()) {
            Config config = JsonPhp.getInstance().getConfig();
            if (config != null && config.getUSECOMET() != null && config.gettypingEnabled() != null
                    && config.getUSECOMET().equals("1") && config.gettypingEnabled().equals("1")) {

                if (TextUtils.isEmpty(channel)) {
                    throw new IllegalArgumentException("Channel can not be empty or null");
                } else {
                    String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                    if (!TextUtils.isEmpty(transport)) {
                        if (transport.equals("cometservice")) {
                            if (istyping) {
                                CometserviceOneOnOne.getInstance().sendMessage(channel,
                                        CommonUtils.getTypingStartMessage());
                            } else {
                                CometserviceOneOnOne.getInstance().sendMessage(channel,
                                        CommonUtils.getTypingStopMessage());
                            }
                        } else if (transport.equals("cometservice-selfhosted")) {
                            if (istyping) {
                                WebsyncOneOnOne.getInstance().publish(channel, CommonUtils.getTypingStartMessage());
                            } else {
                                WebsyncOneOnOne.getInstance().publish(channel, CommonUtils.getTypingStopMessage());
                            }
                        }
                    }
                }
            } else {
                if (config.getUSECOMET() == null || config.getUSECOMET().equals("0")) {
                    String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                    if (!TextUtils.isEmpty(transport)) {
                        if (transport.equals("cometservice")) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_COMETSERVICE_NOT_ENABLED,
                                    ErrorKeys.MESSAGE_COMETSERVICE_NOT_ENABLED));
                        } else if (transport.equals("cometservice-selfhosted")) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED,
                                    ErrorKeys.MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED));
                        }
                    }
                } else if (config.gettypingEnabled() == null || config.gettypingEnabled().equals("0")) {
                    callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_TYPING_NOT_ENABLED,
                            ErrorKeys.MESSAGE_TYPING_NOT_ENABLED));
                }
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    /**
     * @param siteUrl Set the url for SDK to use<br/>
     *                Please set the url till the directory where cometchat is installed on your server
     */
    public void setCometChatUrl(String siteUrl) {
        if (TextUtils.isEmpty(siteUrl)) {
            throw new IllegalArgumentException("site url can not be empty or null");
        } else {
            if (!(siteUrl.contains(URLFactory.PROTOCOL_PREFIX) || siteUrl.contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                siteUrl = URLFactory.PROTOCOL_PREFIX + siteUrl;
            }
            if (!siteUrl.endsWith("/")) {
                siteUrl += "/";
            }
            PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_SITE_URL, siteUrl);
            PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER, StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
        }
    }

    public void sendSticker(final String message, String userId, final Callbacks callbacks) {
        if (isLoggedIn()) {
            if (Stickers.isEnabled()) {
                if (!TextUtils.isEmpty(userId)) {
                    VolleyHelper helper = new VolleyHelper(context, URLFactory.getSendStickerURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    try {
                                        JSONObject sendResponse = new JSONObject(response.substring(
                                                response.indexOf("{"), response.lastIndexOf("}") + 1));
                                        Long id = sendResponse.getLong(AjaxKeys.ID);
                                        if (id != -1) {
                                            JSONObject msg = new JSONObject();
                                            msg.put("id", id);
                                            msg.put("m", message);
                                            callbacks.successCallback(msg);
                                        }
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (isNoInternet) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                                ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                    }
                                }
                            });
                    helper.addNameValuePair(AjaxKeys.TO, String.valueOf(userId));
                    helper.addNameValuePair(AjaxKeys.CATEGORY, Stickers.getCategory(message));
                    helper.addNameValuePair(AjaxKeys.KEY, message);
                    helper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "0");
                    helper.addNameValuePair("caller", "");
                    helper.sendAjax();
                } else {
                    throw new IllegalArgumentException("userId cannot be NULL. userId cannot have 0 length.");
                }
            } else {
                callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_TYPING_NOT_ENABLED,
                        ErrorKeys.MESSAGE_TYPING_NOT_ENABLED));
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_STICKER_PLUGIN_NOT_ENABLED,
                    ErrorKeys.MESSAGE_SITCKER_PLUGIN_NOT_ENABLED));
        }
    }

    /**
     * Send message delivered information to the sender of message to get double tick to the message
     *
     * @param messageid Pass the message id of message which is deliverd to you
     * @param channelId Pass the channelId of user from whom you get the message
     */
    public void sendDeliverdReceipt(String messageid, String channelId, Callbacks callbacks)
            throws IllegalArgumentException {
        if (TextUtils.isEmpty(messageid)) {
            throw new IllegalArgumentException("messageid cannot be NULL. messageid cannot have 0 length.");
        } else {
            if (TextUtils.isEmpty(channelId)) {
                throw new IllegalArgumentException("channelId cannot be NULL. channelId cannot have 0 length.");
            } else {
                Config config = JsonPhp.getInstance().getConfig();
                if (null != config && config.getUSECOMET() != null && config.getUSECOMET().equals("1")) {
                    String transport = config.getTRANSPORT();
                    if (transport.equals("cometservice")) {
                        CometserviceOneOnOne.sendMessage(channelId, CommonUtils.getDeliveredTickMessage(messageid));
                    } else if (transport.equals("cometservice-selfhosted")) {
                        WebsyncOneOnOne.getInstance()
                                .publish(channelId, CommonUtils.getDeliveredTickMessage(messageid));
                    }
                } else {
                    if (config.getUSECOMET() == null || config.getUSECOMET().equals("0")) {
                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        if (!TextUtils.isEmpty(transport)) {
                            if (transport.equals("cometservice")) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_COMETSERVICE_NOT_ENABLED,
                                        ErrorKeys.MESSAGE_COMETSERVICE_NOT_ENABLED));
                            } else if (transport.equals("cometservice-selfhosted")) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED,
                                        ErrorKeys.MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED));
                            }
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_COMETSERVICE_NOT_ENABLED,
                                    ErrorKeys.MESSAGE_COMETSERVICE_NOT_ENABLED));
                        }
                    }
                }
            }
        }

    }

    /**
     * Send message delivered information to the sender of message to get double tick to the message
     *
     * @param messageid Pass the message id of message which is deliverd to you
     * @param channelId Pass the channelId of user from whom you get the message
     */
    public void sendReadReceipt(String messageid, String channelId, Callbacks callbacks)
            throws IllegalArgumentException {
        if (TextUtils.isEmpty(messageid)) {
            throw new IllegalArgumentException("messageid cannot be NULL. messageid cannot have 0 length.");
        } else {
            if (TextUtils.isEmpty(channelId)) {
                throw new IllegalArgumentException("channelId cannot be NULL. channelId cannot have 0 length.");
            } else {
                Config config = JsonPhp.getInstance().getConfig();
                if (null != config && config.getUSECOMET() != null && config.getUSECOMET().equals("1")) {
                    String transport = config.getTRANSPORT();
                    if (transport.equals("cometservice")) {
                        CometserviceOneOnOne.sendMessage(channelId, CommonUtils.getReadTickMessage(messageid));
                    } else if (transport.equals("cometservice-selfhosted")) {
                        WebsyncOneOnOne.getInstance().publish(channelId, CommonUtils.getReadTickMessage(messageid));
                    }
                } else {
                    if (config.getUSECOMET() == null && config.getUSECOMET().equals("0")) {
                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        if (!TextUtils.isEmpty(transport)) {
                            if (transport.equals("cometservice")) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_COMETSERVICE_NOT_ENABLED,
                                        ErrorKeys.MESSAGE_COMETSERVICE_NOT_ENABLED));
                            } else if (transport.equals("cometservice-selfhosted")) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED,
                                        ErrorKeys.MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED));
                            }
                        } else {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    ErrorKeys.CODE_COMETSERVICE_NOT_ENABLED,
                                    ErrorKeys.MESSAGE_COMETSERVICE_NOT_ENABLED));
                        }
                    }
                }
            }
        }
    }


    public void sendWriteBoardRequest(String to, final Callbacks callback) throws IllegalArgumentException {
        if (OtherPlugins.isWriteBoarddisabled()) {
            callback.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_WRITEBOARD_NOT_ENABLED,
                    ErrorKeys.MESSAGE_WRITEBOARD_NOT_ENABLED));
        } else {
            if (TextUtils.isEmpty(to)) {
                throw new IllegalArgumentException("Userid can not be null or empty");
            } else {
                final String random = String.valueOf(System.currentTimeMillis());
                VolleyHelper vhelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getWriteboardRequestUrl(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        String url;
                        Config config = JsonPhp.getInstance().getConfig();
                        if (config != null && !TextUtils.isEmpty(config.getWriteboardUrl())) {
                            url = config.getWriteboardUrl();
                            if (!url.startsWith("http") || !url.startsWith("https")) {
                                url = "https://" + url;
                                url = url.replace("////", "//");
                            }
                            if (url.endsWith("/")) {
                                url += "p/chat-";
                            } else {
                                url += "/p/chat-";
                            }
                        } else {
                            url = "https://w.chatforyoursite.com/p/chat-";
                        }
                        try {
                            url = url + EncryptionHelper.encodeIntoMD5("writeboard" + random) + "?userName=" + SessionData.getInstance().getName();
                            callback.successCallback(new JSONObject().put("writeboard_url", url));
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        Logger.debug("fail response " + response);
                    }
                });
                vhelper.addNameValuePair(AjaxKeys.TO, to);
                vhelper.addNameValuePair(AjaxKeys.ID, random);
                vhelper.sendAjax();
            }
        }
    }

    public void sendWhiteBoardRequest(String to, final Callbacks callback) throws IllegalArgumentException {
        if (OtherPlugins.isWhiteBoarddisabled()) {
            callback.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_WHITEBOARD_NOT_ENABLED,
                    ErrorKeys.MESSAGE_WHITEBOARD_NOT_ENABLED));
        } else {
            if (TextUtils.isEmpty(to)) {
                throw new IllegalArgumentException("Userid can not be null or empty");
            } else {
                VolleyHelper vhelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getWhiteBoardURL(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        try {
                            JSONObject details = new JSONObject(response);
                            if (details.has("room")) {
                                String roomname = details.getString("room");
                                Config config = JsonPhp.getInstance().getConfig();
                                String url;
                                if (config != null && !TextUtils.isEmpty(config.getWhiteboardUrl())) {
                                    url = config.getWhiteboardUrl();
                                    if (!url.startsWith("http") || !url.startsWith("https")) {
                                        url = "https://" + url;
                                        url = url.replace("////", "//");
                                    }
                                    if (url.endsWith("/")) {
                                        url += "d/draw-";
                                    } else {
                                        url += "/d/draw-";
                                    }
                                    url = url + roomname;
                                } else {
                                    url = "https://b.chatforyoursite.com/d/draw-" + roomname;
                                }
                                callback.successCallback(new JSONObject().put("whiteboard_url", url));
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {

                    }
                });
                vhelper.addNameValuePair(AjaxKeys.ACTION, AjaxKeys.WHITEBOARD);
                vhelper.addNameValuePair(AjaxKeys.ID, to);
                vhelper.sendCallBack(false);
                vhelper.addNameValuePair(AjaxKeys.RANDOM, System.currentTimeMillis());
                vhelper.sendAjax();
            }
        }
    }

    public void reportConversation(String userid, String reason, Callbacks callbacks) throws IllegalArgumentException {
        if (ReportConversation.isDisabled()) {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_REPORTCONVERSATION_NOT_ENABLED,
                    ErrorKeys.MESSAGE_REPORTCONVERSATION_NOT_ENABLED));
            return;
        }
        if (TextUtils.isEmpty(userid)) {
            throw new IllegalArgumentException("Userid can not be null or empty");
        } else {
            if (TextUtils.isEmpty(reason)) {
                throw new IllegalArgumentException("Reason can not be null or empty");
            } else {
                ReportConversation.report(Long.parseLong(userid), reason);
            }
        }
    }


    public void getSinglePlayerGamesUrl(final Callbacks callbacks){
        if (CometChat.isLoggedIn()){
            if(OtherPlugins.isSinglePlayerGamesEnabled()){
                try {
                    callbacks.successCallback(new JSONObject().put("url",URLFactory.getSinglePlayerGameURL()));
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }else{
                try {
                    callbacks.successCallback(new JSONObject().put(ErrorKeys.CODE_GAMES_NOT_ENABLED, ErrorKeys.MESSAGE_GAME_PLUGIN_NOT_ENABLED));
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        }else{
            callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }



    /**
     * Adds a new user to your CometChat database.
     *
     * @param username
     * @param password
     * @param displayName
     * @param link
     * @param imageFile
     * @param callbacks
     */
    public void createUser(String username, String password, String displayName, String link, File imageFile,
                           final Callbacks callbacks) {
        try {
            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGIN_SITE_URL)) {
                if (!TextUtils.isEmpty(username)) {
                    if (!TextUtils.isEmpty(password)) {
                        Handler handler = new Handler() {

                            @Override
                            public void handleMessage(Message msg) {
                                super.handleMessage(msg);
                                try {
                                    String response = msg.obj.toString();
                                    JSONObject json = new JSONObject(response);
                                    if (json.has("success")) {
                                        JSONObject jsonresponse = json.getJSONObject("success");
                                        callbacks.successCallback(jsonresponse);
                                    } else if (json.has("failed")) {
                                        JSONObject jsonresponse = json.getJSONObject("failed");
                                        jsonresponse.put("code", jsonresponse.getString("status"));
                                        jsonresponse.put("message", jsonresponse.getString("message"));
                                        jsonresponse.remove("status");
                                        callbacks.failCallback(jsonresponse);
                                    }
                                } catch (Exception e) {
                                    e.printStackTrace();
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_RANDOM_EXCEPTION,
                                            ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                                }
                            }
                        };

                        FileUploadHelper imageSendHelper = new FileUploadHelper(URLFactory.getCCUserManagementURL(),
                                handler);
                        imageSendHelper.addNameValuePair(AjaxKeys.USERNAME, username);
                        imageSendHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
                        imageSendHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
                        imageSendHelper.addNameValuePair(AjaxKeys.LINK, link);
                        imageSendHelper.addNameValuePair(AjaxKeys.API_KEY, PreferenceHelper.get(DataKeys.API_KEY));
                        imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, imageFile);
                        imageSendHelper.addNameValuePair(AjaxKeys.ACTION, "createuser");
                        imageSendHelper.execute();
                    } else {
                        throw new IllegalArgumentException("Password cannot be NULL. Password cannot have 0 length.");
                    }

                } else {
                    throw new IllegalArgumentException("Username cannot be NULL. Username cannot have 0 length.");
                }
            } else {
                throw new IllegalArgumentException("Set the url by using setUrl()");
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void addFriends(JSONArray users, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCCUserManagementURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                JSONObject json = new JSONObject(response);
                                JSONObject jsonresponse = json.getJSONObject("success");
                                callbacks.successCallback(jsonresponse);
                            } catch (JSONException e) {
                                failCallback(response, false);
                            } catch (Exception e) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_JSON_PARSING_ERROR,
                                        ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else {
                                try {
                                    JSONObject json = new JSONObject(response);
                                    JSONObject jsonresponse = json.getJSONObject("failed");
                                    jsonresponse.put("code", jsonresponse.getString("status"));
                                    jsonresponse.put("message", jsonresponse.getString("message"));
                                    jsonresponse.remove("status");
                                    callbacks.failCallback(jsonresponse);
                                } catch (Exception e) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                }
                            }
                        }
                    });

            vHelper.addNameValuePair(AjaxKeys.FRIENDS, users.toString());
            vHelper.addNameValuePair(AjaxKeys.API_KEY, PreferenceHelper.get(DataKeys.API_KEY));
            vHelper.addNameValuePair(AjaxKeys.ACTION, "addfriend");
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void updateUser(String userID, String password, String displayName, String link, File imageFile,
                           String newPassword, boolean setNull, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (TextUtils.isEmpty(password)) {
                throw new IllegalArgumentException("Password cannot be NULL. Password cannot have 0 length.");
            } else {
                try {
                    Handler handler = new Handler() {

                        @Override
                        public void handleMessage(Message msg) {
                            super.handleMessage(msg);
                            try {
                                String response = msg.obj.toString();
                                JSONObject json = new JSONObject(response);
                                if (json.has("success")) {
                                    JSONObject jsonresponse = json.getJSONObject("success");
                                    callbacks.successCallback(jsonresponse);
                                } else if (json.has("failed")) {
                                    JSONObject jsonresponse = json.getJSONObject("failed");
                                    jsonresponse.put("code", jsonresponse.getString("status"));
                                    jsonresponse.put("message", jsonresponse.getString("message"));
                                    jsonresponse.remove("status");
                                    callbacks.failCallback(jsonresponse);
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_RANDOM_EXCEPTION,
                                        ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                            }
                        }
                    };

                    FileUploadHelper imageSendHelper = new FileUploadHelper(URLFactory.getCCUserManagementURL(),
                            handler);
                    imageSendHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
                    Logger.error("apikey updateuser " + PreferenceHelper.get(DataKeys.API_KEY));
                    imageSendHelper.addNameValuePair(AjaxKeys.API_KEY,
                            PreferenceHelper.get(DataKeys.API_KEY));

                    if (setNull) {
                        if (null == displayName) {
                            displayName = "";
                        }
                        if (null == link) {
                            link = "";
                        }
						/*if (null == imageFile) {
							imageFile = "";
						}*/
                        imageSendHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
                        imageSendHelper.addNameValuePair(AjaxKeys.LINK, link);
                        imageSendHelper.addNameValuePair(AjaxKeys.AVATAR, "");
                    } else {
                        if (null == displayName && null == link && null == imageFile && null == newPassword) {
                            throw new IllegalArgumentException("All fields can not be null");
                        }
                        if (null != displayName) {
                            imageSendHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
                        }
                        if (null != link) {
                            imageSendHelper.addNameValuePair(AjaxKeys.LINK, link);
                        }
                        if (null != imageFile) {
                            imageSendHelper.addFile(AjaxKeys.AVATAR, imageFile);
                        }
                    }

                    if (!TextUtils.isEmpty(newPassword)) {
                        imageSendHelper.addNameValuePair(AjaxKeys.NEW_PASSWORD, newPassword);
                    }
                    if (setNull) {
                        imageSendHelper.addNameValuePair(AjaxKeys.ACCEPT_NULL, 1);
                    } else {
                        imageSendHelper.addNameValuePair(AjaxKeys.ACCEPT_NULL, 0);
                    }

                    if (!TextUtils.isEmpty(userID)) {
                        imageSendHelper.addNameValuePair(AjaxKeys.USERID, userID);
                    }
                    imageSendHelper.addNameValuePair(AjaxKeys.ACTION, "updateuser");
                    imageSendHelper.execute();
                } catch (Exception e) {

                }
            }
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void removeFriends(JSONArray users, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCCUserManagementURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {

                                JSONObject json = new JSONObject(response);
                                JSONObject jsonresponse = json.getJSONObject("success");
                                callbacks.successCallback(jsonresponse);
                            } catch (JSONException e) {
                                failCallback(response, false);
                            } catch (Exception e) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_JSON_PARSING_ERROR,
                                        ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else {
                                try {
                                    JSONObject json = new JSONObject(response);
                                    JSONObject jsonresponse = json.getJSONObject("failed");
                                    jsonresponse.put("code", jsonresponse.getString("status"));
                                    jsonresponse.put("message", jsonresponse.getString("message"));
                                    jsonresponse.remove("status");
                                    callbacks.failCallback(jsonresponse);
                                } catch (Exception e) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                            ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                }
                            }
                        }

                    });

            // vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERID, SessionData.getInstance().getId());
            vHelper.addNameValuePair(AjaxKeys.FRIENDS, users.toString());
            vHelper.addNameValuePair(AjaxKeys.API_KEY, PreferenceHelper.get(DataKeys.API_KEY));
            vHelper.addNameValuePair(AjaxKeys.ACTION, "removefriend");
            vHelper.sendAjax();
        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }

    public void removeUser(String userID, final Callbacks callbacks) {
        if (CometChat.isLoggedIn()) {
            if (TextUtils.isEmpty(userID)) {
                throw new IllegalArgumentException("userID cannot be NULL. userID cannot have 0 length.");
            } else {
                VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCCUserManagementURL(),
                        new VolleyAjaxCallbacks() {

                            @Override
                            public void successCallback(String response) {
                                try {
                                    JSONObject json = new JSONObject(response);
                                    JSONObject jsonresponse = json.getJSONObject("success");
                                    callbacks.successCallback(jsonresponse);
                                } catch (JSONException e) {
                                    failCallback(response, false);
                                } catch (Exception e) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_JSON_PARSING_ERROR,
                                            ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if (isNoInternet) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                                } else {
                                    try {
                                        JSONObject json = new JSONObject(response);
                                        JSONObject jsonresponse = json.getJSONObject("failed");
                                        jsonresponse.put("code", jsonresponse.getString("status"));
                                        jsonresponse.put("message", jsonresponse.getString("message"));
                                        jsonresponse.remove("status");
                                        callbacks.failCallback(jsonresponse);
                                    } catch (Exception e) {
                                        callbacks.failCallback(CommonUtils.createErrorJson(
                                                ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }
                            }
                        });
                vHelper.addNameValuePair(AjaxKeys.ACTION, "removeuser");
                vHelper.addNameValuePair(AjaxKeys.API_KEY, PreferenceHelper.get(DataKeys.API_KEY));
                vHelper.addNameValuePair(AjaxKeys.USERID, userID);
                vHelper.sendAjax();
            }

        } else {
            callbacks.failCallback(CommonUtils.createErrorJson(ErrorKeys.CODE_USER_NOT_LOGGEDIN,
                    ErrorKeys.MESSAGE_NOT_LOGGEDIN));
        }
    }
}