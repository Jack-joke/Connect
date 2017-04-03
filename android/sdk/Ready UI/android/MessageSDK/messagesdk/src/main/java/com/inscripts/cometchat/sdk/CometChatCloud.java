/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/

package com.inscripts.cometchat.sdk;

import android.content.Context;
import android.text.TextUtils;

import com.inscripts.enums.StatusOption;
import com.inscripts.factories.URLFactory.CloudURLS;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.StatusKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class CometChatCloud {

	private Context context;
	private static CometChatCloud cometchatCloud;

	/**
	 * Initialize and get the <b>CometChatCloud</b> module.
	 *
	 * @param context
	 *
	 */
	public static CometChatCloud getInstance(Context context) {
		if (null == cometchatCloud) {
			cometchatCloud = new CometChatCloud(context);
		}
		return cometchatCloud;
	}

	private CometChatCloud(Context context) {
		this.context = context;
		PreferenceHelper.initialize(this.context);
	}

	/**
	 * Adds a new user to your CometChat Cloud database.
	 * 
	 * @param UID
	 *            Pass UID if you are creating user from your CMS, else "" for custom coded integration
	 * @param username
	 * @param password
	 * @param displayName
	 * @param link
	 * @param avatarUrl
	 * @param callbacks
	 * 
	 */
	public void createUser(String UID, String username, String password, String displayName, String link,
			String avatarUrl, final Callbacks callbacks) {
		VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getCreateUserURL(), new VolleyAjaxCallbacks() {

			@Override
			public void successCallback(String response) {
				try {
					JSONObject json = new JSONObject(response);
					JSONObject jsonresponse = json.getJSONObject("success");
					callbacks.successCallback(jsonresponse);
				} catch (JSONException e) {
					failCallback(response,false);
				} catch (Exception e) {
					callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
							CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
				}
			}

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                if(isNoInternet){
                    callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                            CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
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
                                CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                    }
                }
            }
		});

		vHelper.addNameValuePair(AjaxKeys.USERNAME, username);
		vHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
		vHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
		vHelper.addNameValuePair(AjaxKeys.LINK, link);
		vHelper.addNameValuePair(AjaxKeys.AVATAR, avatarUrl);
		if (TextUtils.isEmpty(UID)) {
			UID = "";
		}
		vHelper.addNameValuePair(AjaxKeys.UID, UID);
		vHelper.sendAjax();

	}

	/**
	 * Removes the user from your CometChat Cloud database based on
	 * <i>username</i>
	 * 
	 * @param username
	 *            : Username of the user to be removed.
	 * @param callbacks
	 * 
	 */
	public void removeUser(String username, final Callbacks callbacks) throws IllegalArgumentException {
		if (CometChat.isLoggedIn()) {
			if (TextUtils.isEmpty(username)) {
				throw new IllegalArgumentException("Username cannot be NULL. Username cannot have 0 length.");
			} else {
				VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getRemoveUserURL(),
						new VolleyAjaxCallbacks() {

							@Override
							public void successCallback(String response) {
								try {
									JSONObject json = new JSONObject(response);
									JSONObject jsonresponse = json.getJSONObject("success");
									callbacks.successCallback(jsonresponse);
								} catch (JSONException e) {
									failCallback(response,false);
								} catch (Exception e) {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
											CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
								}
							}

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if(isNoInternet){
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
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
                                                CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }
                            }
						});

				vHelper.addNameValuePair(AjaxKeys.USERNAME, username);
				vHelper.sendAjax();
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Removes the user from your CometChat Cloud database based on <i>id</i>
	 * 
	 * @param id
	 *            : id of the user to be removed.
	 * @param callbacks
	 * 
	 */
	public void removeUser(Long id, final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getRemoveUserURL(), new VolleyAjaxCallbacks() {

				@Override
				public void successCallback(String response) {
					try {
						JSONObject json = new JSONObject(response);
						JSONObject jsonresponse = json.getJSONObject("success");
						callbacks.successCallback(jsonresponse);
					} catch (JSONException e) {
						failCallback(response,false);
					} catch (Exception e) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
								CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
					}
				}

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if(isNoInternet){
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
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
                                    CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                    CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                        }
                    }
                }

			});

			vHelper.addNameValuePair(AjaxKeys.USERID, id);
			vHelper.sendAjax();
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Removes the user from your CometChat Cloud database based on <i>id</i>
	 * 
	 * @param id
	 *            : id of the user to be removed.
	 * @param callbacks
	 * 
	 */
	public void addFriends(JSONArray users, final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getAddFriendsURL(), new VolleyAjaxCallbacks() {

				@Override
				public void successCallback(String response) {
					try {
						JSONObject json = new JSONObject(response);
						JSONObject jsonresponse = json.getJSONObject("success");
						callbacks.successCallback(jsonresponse);
					} catch (JSONException e) {
						failCallback(response,false);
					} catch (Exception e) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
								CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
					}
				}

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if(isNoInternet){
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                    } else{
                        try {
                            JSONObject json = new JSONObject(response);
                            JSONObject jsonresponse = json.getJSONObject("failed");
                            jsonresponse.put("code", jsonresponse.getString("status"));
                            jsonresponse.put("message", jsonresponse.getString("message"));
                            jsonresponse.remove("status");
                            callbacks.failCallback(jsonresponse);
                        } catch (Exception e) {
                            callbacks.failCallback(CommonUtils.createErrorJson(
                                    CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                    CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                        }
                    }
                }

			});

			vHelper.addNameValuePair(AjaxKeys.FRIENDS, users.toString());
			vHelper.sendAjax();
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Unfriends the users present in the <b>JSONArray</b>. The array can be of
	 * <i>ids</i> or <i>usernames</i>
	 * 
	 * @param users
	 * @param callbacks
	 */
	public void removeFriends(JSONArray users, final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getRemoveFriendsURL(),
					new VolleyAjaxCallbacks() {

						@Override
						public void successCallback(String response) {
							try {
								JSONObject json = new JSONObject(response);
								JSONObject jsonresponse = json.getJSONObject("success");
								callbacks.successCallback(jsonresponse);
							} catch (JSONException e) {
								failCallback(response,false);
							} catch (Exception e) {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
										CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
							}
						}

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if(isNoInternet){
                                callbacks.failCallback(CommonUtils.createErrorJson(
                                        CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                        CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
                            } else{
                                try {
                                    JSONObject json = new JSONObject(response);
                                    JSONObject jsonresponse = json.getJSONObject("failed");
                                    jsonresponse.put("code", jsonresponse.getString("status"));
                                    jsonresponse.put("message", jsonresponse.getString("message"));
                                    jsonresponse.remove("status");
                                    callbacks.failCallback(jsonresponse);
                                } catch (Exception e) {
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                            CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                }
                            }
                        }

					});

			vHelper.addNameValuePair(AjaxKeys.USERID, SessionData.getInstance().getId());
			vHelper.addNameValuePair(AjaxKeys.FRIENDS, users.toString());
			vHelper.sendAjax();
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * 
	 * @param password
	 * @param displayName
	 * @param link
	 * @param avatar
	 * @param newPassword
	 * @param status
	 * @param statusMessage
	 * @param setNull
	 *            If you pass 'true' and set <b>null</b> or <b>""</b> to any
	 *            value, then it that value will be set to ""<br>
	 *            If you pass 'false' and set <b>null</b> to any value, then
	 *            that value will not be updated
	 * @param callbacks
	 * @throws IllegalArgumentException
	 */
	public void updateUser(String password, String displayName, String link, String avatar, String newPassword,
			StatusOption status, String statusMessage, boolean setNull, final Callbacks callbacks)
			throws IllegalArgumentException {
		if (CometChat.isLoggedIn()) {
			if (TextUtils.isEmpty(password)) {
				throw new IllegalArgumentException("Password cannot be NULL. Password cannot have 0 length.");
			} else if (null == status) {
				throw new IllegalArgumentException("Status option can not be null");
			} else {

				VolleyHelper vHelper = new VolleyHelper(context, CloudURLS.getUpdateUserURL(),
						new VolleyAjaxCallbacks() {

							@Override
							public void successCallback(String response) {
								try {
									JSONObject json = new JSONObject(response);
									JSONObject jsonresponse = json.getJSONObject("success");
									callbacks.successCallback(jsonresponse);
								} catch (JSONException e) {
									failCallback(response,false);
								} catch (Exception e) {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
											CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
								}
							}

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                if(isNoInternet){
                                    callbacks.failCallback(CommonUtils.createErrorJson(
                                            CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
                                            CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
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
                                                CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
                                                CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
                                    }
                                }
                            }


						});

				String statusForAjax;
				switch (status) {
				case AVAILABLE:
					statusForAjax = StatusKeys.AVALIABLE;
					break;
				case OFFLINE:
					statusForAjax = StatusKeys.OFFLINE;
					break;
				case INVISIBLE:
					statusForAjax = StatusKeys.INVISIBLE;
					break;
				case BUSY:
					statusForAjax = StatusKeys.BUSY;
					break;
				default:
					statusForAjax = StatusKeys.AVALIABLE;
					break;
				}

				if (setNull) {
					if (null == displayName) {
						displayName = "";
					}
					if (null == link) {
						link = "";
					}
					if (null == avatar) {
						avatar = "";
					}
					if (null == statusMessage) {
						statusMessage = "";
					}
					vHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
					vHelper.addNameValuePair(AjaxKeys.LINK, link);
					vHelper.addNameValuePair(AjaxKeys.AVATAR, avatar);
					vHelper.addNameValuePair(AjaxKeys.MESSAGE, statusMessage);
				} else {
					if (null == displayName && null == link && null == avatar && null == statusMessage
							&& null == newPassword) {
						throw new IllegalArgumentException("All fields can not be null");
					}
					if (null != displayName) {
						vHelper.addNameValuePair(AjaxKeys.DISPLAY_NAME, displayName);
					}
					if (null != link) {
						vHelper.addNameValuePair(AjaxKeys.LINK, link);
					}
					if (null != avatar) {
						vHelper.addNameValuePair(AjaxKeys.AVATAR, avatar);
					}
					if (null != statusMessage) {
						vHelper.addNameValuePair(AjaxKeys.MESSAGE, statusMessage);
					}
				}

				vHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
				vHelper.addNameValuePair(StatusKeys.STATUS, statusForAjax);

				if (!TextUtils.isEmpty(newPassword)) {
					vHelper.addNameValuePair(AjaxKeys.NEW_PASSWORD, newPassword);
				}
				if (setNull) {
					vHelper.addNameValuePair(AjaxKeys.ACCEPT_NULL, 1);
				} else {
					vHelper.addNameValuePair(AjaxKeys.ACCEPT_NULL, 0);
				}

				vHelper.sendAjax();
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}
}