package com.inscripts.helpers;

import java.util.HashMap;
import java.util.Map;

import org.json.JSONObject;
import org.json.JSONTokener;

import android.content.Context;
import android.text.TextUtils;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request.Method;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.Response.Listener;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.cometchat.sdk.CometChatroom;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;

public class VolleyHelper {

	private String URL;
	private int REQUEST_TYPE = Method.POST;
	private static RequestQueue queue;
	private boolean callback = true;
	private VolleyAjaxCallbacks volleyCallbacks;
	private HashMap<String, String> nameValuePair = new HashMap<>();
	private Map<String, String> headers = new HashMap<>();
	private Context c;

	/**
	 * Use this constructor when there is ?action= in url of request,.. mostly
	 * in chatroom related url
	 * 
	 * @param c
	 *            context
	 * @param URL
	 *            url
	 * @param callbacks
	 *            callback
	 */
	public VolleyHelper(Context c, String URL, VolleyAjaxCallbacks callbacks) {
		this.volleyCallbacks = callbacks;
		this.c = c;
		queue = getQueueInstance(c);
		this.URL = URL;
	}

	/**
	 * Use this constructor when there is ?action= in url of request,.. mostly
	 * in chatroom related url
	 * 
	 * @param c
	 *            context
	 * @param URL
	 *            url
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
				nameValuePair.put(AjaxKeys.PLATFORM, "a");
				nameValuePair.put(AjaxKeys.SDK_PARAM, "1");

				if (callback) {
					nameValuePair.put(AjaxKeys.CALLBACK, "jqcc17108543446448165930_" + System.currentTimeMillis());
				}

				final StringBuilder finalURL = new StringBuilder(URL);
				if (URL.contains("?")) {
					finalURL.append("&t=").append(System.currentTimeMillis());
				} else {
					finalURL.append("?t=").append(System.currentTimeMillis());
				}
				if (PreferenceHelper.contains(PreferenceKeys.DataKeys.API_KEY)) {
					headers.put(AjaxKeys.API_KEY, PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY));
				}

				StringRequest request = new StringRequest(REQUEST_TYPE, finalURL.toString(), new Listener<String>() {

					@Override
					public void onResponse(String response) {
						// Logger.debug("success response volley " + response);
						nameValuePair.clear();
						headers.clear();
						if (volleyCallbacks != null) {
							try {
								if (TextUtils.isEmpty(response)) {
									if (URL.contains("cometchat_logout.php")) {
										volleyCallbacks.successCallback(response);
									}
								} else {
									Object json = new JSONTokener(response).nextValue();
									if (json instanceof JSONObject) {
										JSONObject codResponse = new JSONObject(response);
										if ((codResponse.has("cod") || codResponse.has("failed"))
												&& PreferenceHelper.contains(PreferenceKeys.DataKeys.API_KEY)) {
											boolean domainError = false;
											int codErrorCode = 0;
											if (codResponse.has("failed")) {
												JSONObject failresponse = codResponse.getJSONObject("failed");
												if (failresponse.has("cod")) {
													codErrorCode = failresponse.getInt("cod");
													if (codErrorCode == -2) {
														domainError = true;
														volleyCallbacks.failCallback(failresponse.getString("message"));
													}
												} else {
													volleyCallbacks.failCallback(response);
												}
											} else {
												codErrorCode = codResponse.getInt("cod");
											}
											if (codErrorCode == -1) {
												domainError = true;
												volleyCallbacks.failCallback(StaticMembers.DOMAIN_ERROR);
											}

											/* FORCE LOGOUT */
											// CometChat.getInstance(c).logout(
											// CometChat.getInstance(c,
											// PreferenceHelper.get(PreferenceKeys.DataKeys.COD_API_KEY)).logout(*/
											if (domainError) {
												CometChat.getInstance(c,
														PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY)).logout(
														new Callbacks() {

															@Override
															public void successCallback(JSONObject response) {

															}

															@Override
															public void failCallback(JSONObject response) {
															}
														});
												CometChatroom.getInstance(c).unsubscribe();
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
							// volleyCallbacks.successCallback(response);
						}
						/* DEV_MODE */
						if (PreferenceHelper.contains(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)
								&& Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)) == 1) {
							Logger.debug("CC_SDK_LOG:URL: " + finalURL);
							Logger.debug("CC_SDK_LOG:RESPONSE: " + response);
						}
					}
				}, new Response.ErrorListener() {

					@Override
					public void onErrorResponse(VolleyError response) {
						// Logger.error("fail response " + response);
						nameValuePair.clear();
						headers.clear();
						if (volleyCallbacks != null) {
							volleyCallbacks.failCallback(response.toString());
						}

						/* DEV_MODE */
						if (PreferenceHelper.contains(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)
								&& Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)) == 1) {
							Logger.debug("CC_SDK_LOG:URL: " + finalURL);
							Logger.debug("CC_SDK_LOG:RESPONSE: " + response);
						}
					}
				}) {
					@Override
					protected Map<String, String> getParams() throws AuthFailureError {
						return nameValuePair;
					}

					@Override
					public Map<String, String> getHeaders() throws AuthFailureError {
						return headers;
					}
				};
				// Logger.error("URL =" + URL + " parms " + nameValuePair);
				request.setRetryPolicy(new DefaultRetryPolicy(0, 0, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
				queue.add(request);
			} else {
				nameValuePair.clear();
				if (volleyCallbacks != null) {
					volleyCallbacks.noInternetCallback();
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