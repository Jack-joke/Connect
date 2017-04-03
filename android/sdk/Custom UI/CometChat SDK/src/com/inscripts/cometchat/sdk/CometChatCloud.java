/*

CometChat
Copyright (c) 2015 Inscripts

CometChat ('the Software') is a copyrighted work of authorship. Inscripts
retains ownership of the Software and any copies of it, regardless of the
form in which the copies may exist. This license is not a sale of the
original Software or any copies.

By installing and using CometChat on your server, you agree to the following
terms and conditions. Such agreement is either on your own behalf or on behalf
of any corporate entity which employs you or which you represent
('Corporate Licensee'). In this Agreement, 'you' includes both the reader
and any Corporate Licensee and 'Inscripts' means Inscripts (I) Private Limited:

CometChat license grants you the right to run one instance (a single installation)
of the Software on one web server and one web site for each license purchased.
Each license may power one instance of the Software on one domain. For each
installed instance of the Software, a separate license is required.
The Software is licensed only to you. You may not rent, lease, sublicense, sell,
assign, pledge, transfer or otherwise dispose of the Software in any form, on
a temporary or permanent basis, without the prior written consent of Inscripts.

The license is effective until terminated. You may terminate it
at any time by uninstalling the Software and destroying any copies in any form.

The Software source code may be altered (at your risk)

All Software copyright notices within the scripts must remain unchanged (and visible).

The Software may not be used for anything that would represent or is associated
with an Intellectual Property violation, including, but not limited to,
engaging in any activity that infringes or misappropriates the intellectual property
rights of others, including copyrights, trademarks, service marks, trade secrets,
software piracy, and patents held by individuals, corporations, or other entities.

If any of the terms of this Agreement are violated, Inscripts reserves the right
to revoke the Software license at any time.

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

 */

package com.inscripts.cometchat.sdk;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.content.Context;
import android.text.TextUtils;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.enums.StatusOption;
import com.inscripts.factories.URLFactory.CloudURLS;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.StatusKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;

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
					failCallback(response);
				} catch (Exception e) {
					callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
							CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
				}
			}

			@Override
			public void failCallback(String response) {
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

			@Override
			public void noInternetCallback() {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
						CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
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
									failCallback(response);
								} catch (Exception e) {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
											CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
								}
							}

							@Override
							public void failCallback(String response) {
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

							@Override
							public void noInternetCallback() {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
										CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
							}
						});

				vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, username);
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
						failCallback(response);
					} catch (Exception e) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
								CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
					}
				}

				@Override
				public void failCallback(String response) {
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

				@Override
				public void noInternetCallback() {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
							CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
				}
			});

			vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERID, id);
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
						failCallback(response);
					} catch (Exception e) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
								CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
					}
				}

				@Override
				public void failCallback(String response) {
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

				@Override
				public void noInternetCallback() {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
							CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
				}
			});

			vHelper.addNameValuePair(CometChatKeys.AjaxKeys.FRIENDS, users.toString());
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
								failCallback(response);
							} catch (Exception e) {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
										CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
							}
						}

						@Override
						public void failCallback(String response) {
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

						@Override
						public void noInternetCallback() {
							callbacks.failCallback(CommonUtils.createErrorJson(
									CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
									CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
						}
					});

			vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERID, SessionData.getInstance().getId());
			vHelper.addNameValuePair(CometChatKeys.AjaxKeys.FRIENDS, users.toString());
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
									failCallback(response);
								} catch (Exception e) {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
											CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
								}
							}

							@Override
							public void failCallback(String response) {
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

							@Override
							public void noInternetCallback() {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
										CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
							}
						});

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
