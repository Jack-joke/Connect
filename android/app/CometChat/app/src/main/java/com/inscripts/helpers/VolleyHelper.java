/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.content.Intent;
import android.text.TextUtils;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request.Method;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.Response.Listener;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.inscripts.activities.CoDLoginActivity;
import com.inscripts.activities.CometChatActivity;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

import org.json.JSONObject;
import org.json.JSONTokener;

import java.util.HashMap;
import java.util.Map;

public class VolleyHelper {

    private String URL;
    private int REQUEST_TYPE = Method.POST;
    private static RequestQueue queue;
    private boolean callback = true;
    private VolleyAjaxCallbacks volleyCallbacks;
    private HashMap<String, String> nameValuePair = new HashMap<>();

    /**
     * Use this constructor when there is ?action= in url of request,.. mostly in chatroom related url
     *
     * @param c         context
     * @param URL       url
     * @param callbacks callback
     */
    public VolleyHelper(Context c, String URL, VolleyAjaxCallbacks callbacks) {
        this.volleyCallbacks = callbacks;
        queue = getQueueInstance(c);
        this.URL = URL;
    }

    /**
     * Use this constructor when there is ?action= in url of request,.. mostly in chatroom related url
     *
     * @param c   context
     * @param URL url
     */
    public VolleyHelper(Context c, String URL) {
        queue = getQueueInstance(c);
        this.URL = URL;
    }

    public static synchronized RequestQueue getQueueInstance(Context c) {
        if (null == queue) {
            queue = Volley.newRequestQueue(c);
        }
        return queue;
    }

    /**
     * Add a new name value pair to the current request. The paramters are
     * cleared after the request in completed.
     */
    public void addNameValuePair(String key, String value) {
        if (null == value) {
            nameValuePair.put(key, "");
        } else {
            nameValuePair.put(key, value);
        }
    }

    /**
     * Add a new name value pair to the current request. The paramters are
     * cleared after the request in completed.
     */
    public void addNameValuePair(String key, Integer value) {
        if (null == value) {
            nameValuePair.put(key, "");
        } else {
            nameValuePair.put(key, String.valueOf(value));
        }
    }

    /**
     * Add a new name value pair to the current request. The paramters are
     * cleared after the request in completed.
     */
    public void addNameValuePair(String key, Long value) {
        if (null == value) {
            nameValuePair.put(key, "");
        } else {
            nameValuePair.put(key, String.valueOf(value));
        }
    }

    /**
     * Perform the AJAX request.
     */
    public void sendAjax() {
        try {
            if (CommonUtils.isConnected()) {
                if (URL.startsWith("https")) {
                    CommonUtils.allowHttpsConnection();
                }
                nameValuePair.put(AjaxKeys.BASE_DATA, PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
                nameValuePair.put(AjaxKeys.CALLBACK_FN, AjaxKeys.CALLBACK_FN_VALUE);
                // nameValuePair.put(AjaxKeys.VERSION, "1");
                nameValuePair.put(AjaxKeys.VERSION2, "1");
                nameValuePair.put(AjaxKeys.VERSION3, "1");
                nameValuePair.put("appinfo",PreferenceHelper.get(PreferenceKeys.UserKeys.DEVICE_INFO));

                //Logger.error("Device info = "+PreferenceHelper.get(PreferenceKeys.UserKeys.DEVICE_INFO));
                if (callback) {
                    nameValuePair.put(AjaxKeys.CALLBACK, "jqcc17108543446448165930_" + System.currentTimeMillis());
                }

                final String finalURL;
                if (URL.contains("?")) {
                    finalURL = URL + "&t=" + System.currentTimeMillis();
                } else {
                    finalURL = URL + "?t=" + System.currentTimeMillis();
                }

                StringRequest request = new StringRequest(REQUEST_TYPE, finalURL, new Listener<String>() {

                    @Override
                    public void onResponse(String response) {
//                      Logger.error("success response " + response+"response.leng "+response.length());
                        nameValuePair.clear();
                        if (volleyCallbacks != null) {
                            try {
                                if (TextUtils.isEmpty(response)){
                                    if (finalURL.contains(CometChatKeys.AjaxKeys.WRITEBOARD_TYPE_CHECK)){
                                        volleyCallbacks.successCallback(response);
                                    }
                                } else {
                                    Object json = new JSONTokener(response).nextValue();
                                    if (json instanceof JSONObject) {
                                        JSONObject codResponse = new JSONObject(response);

                                        if (codResponse.has("cod") && codResponse.getInt("cod") == -1 && PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                                            Intent intent = new Intent(PreferenceHelper.getContext(), CoDLoginActivity.class);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);

                                            PreferenceHelper.getContext().startActivity(intent);
                                            LogoutHelper.chatLogout();

                                            PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD);
                                            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.BASE_DATA);
                                            Toast.makeText(PreferenceHelper.getContext(), codResponse.has("msg") ? codResponse.getString("msg") : "Please contact support@cometchat.com for more information.", Toast.LENGTH_LONG).show();
                                            SessionData.getInstance().setBaseData("");
                                            if (CometChatActivity.tabActivity != null) {
                                                CometChatActivity.tabActivity.finish();
                                            }
                                        } else {
                                            volleyCallbacks.successCallback(response);
                                        }
                                    } else {
                                        volleyCallbacks.successCallback(response);
                                    }
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                                volleyCallbacks.successCallback(response);
                            }
                        }
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError response) {
//                        Logger.error("fail response " + response);
                        nameValuePair.clear();
                        if (volleyCallbacks != null) {
                            volleyCallbacks.failCallback(response.toString(), false);
                        }
                    }
                }) {
                    @Override
                    protected Map<String, String> getParams() throws AuthFailureError {
                        return nameValuePair;
                    }
                };
//
               /*if(finalURL.contains(URLFactory.getRecieveURL()))
                Logger.error("URL= " + finalURL + " params =" + nameValuePair);*/
                request.setRetryPolicy(new DefaultRetryPolicy(0, 0, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
                queue.add(request);
            } else {
                nameValuePair.clear();
                if (volleyCallbacks != null) {
                    volleyCallbacks.failCallback("", true);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Pass true to set the "callback" parameter. Callback is sent by default.
     */
    public void sendCallBack(Boolean isRequired) {
        callback = isRequired;
    }

    public void setRequestType(int requestType) {
        this.REQUEST_TYPE = requestType;
    }

}
