/*
CometChat
Copyright (c) 2014 Inscripts
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

import java.io.File;

import org.json.JSONArray;
import org.json.JSONObject;

import android.annotation.SuppressLint;
import android.content.Context;
import android.graphics.Bitmap;
import android.text.TextUtils;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.SubscribeChatroomCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.enums.ChatroomType;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.ChatroomActionMessageTypeKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

@SuppressLint("HandlerLeak")
public class CometChatroom {

	private static boolean useComet = false;
	public static boolean useHTML = false;
	private static Context context;
	private static SubscribeChatroomCallbacks callbacklistener;
	private static SessionData sessionData;
	private long minHeartbeat;
	private boolean isSubscribed = false;
	private static CometChatroom cometChatroom;
	private int userInviteCount = 0;

	public static CometChatroom getInstance(Context context) {
		if (null == cometChatroom) {
			cometChatroom = new CometChatroom(context);
		}
		return cometChatroom;
	}

	/**
	 * Initialize the Chatrooms module.
	 * 
	 * @param context
	 * @param listener
	 */
	private CometChatroom(Context context) {
		CometChatroom.context = context;
		PreferenceHelper.initialize(CometChatroom.context);
		sessionData = SessionData.getInstance();
		if (null == sessionData.getChatroomHeartBeatTimestamp()) {
			sessionData.setChatroomHeartBeatTimestamp("0");
		}
		if (null == sessionData.getCurrentChatroomPassword()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD)) {
				sessionData.setCurrentChatroomPassword(PreferenceHelper
						.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD));
			} else {
				sessionData.setCurrentChatroomPassword("");
			}
		}
	}

	/**
	 * Start receiving chatroom messages, chatroom list and chatroom members.
	 * 
	 * @param htmlFlag
	 *            : If set then emojis will be represnted by their short forms <br>
	 *            If unset then emojis will be represented by HTML tags
	 */
	public void subscribe(final boolean htmlFlag, final SubscribeChatroomCallbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			callbacklistener = callbacks;
			if (CometChat.isSubscribedCalled) {
				useHTML = htmlFlag;
				/*if (useHTML) {
					Smilies.InitializeMapping();
				}*/
				// HeartbeatChatroom.getInstance(callbacklistener).stopHeartbeatChatroom();

				Long interval = 0L;
				Config config = JsonPhp.getInstance().getConfig();
				minHeartbeat = Long.parseLong(config.getMinHeartbeat());
				useComet = config.getUSECOMET().equals("1");
				HeartbeatChatroom heartbeatChatroom = HeartbeatChatroom.getInstance(callbacklistener);
				if (useComet) {
					interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
					sessionData.setChatroomHeartbeatInterval(interval);
				} else {
					interval = Long.parseLong(config.getMinHeartbeat());
					sessionData.setChatroomHeartbeatInterval(interval);
				}

				isSubscribed = true;
				heartbeatChatroom.startHeartbeat(context);
			} else {

				// CometChat.getInstance(context)
				// CometChat.getInstance(context)
				CometChat.getInstance(context, PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY))
						.initializeJsonPhp(new Callbacks() {

							@Override
							public void successCallback(JSONObject response) {
								useHTML = htmlFlag;
								CometChat.isSubscribedCalled = true;
								/*if (useHTML) {
									Smilies.InitializeMapping();
								}*/
								HeartbeatChatroom.getInstance(callbacklistener).stopHeartbeatChatroom();

								Long interval = 0L;
								Config config = JsonPhp.getInstance().getConfig();
								minHeartbeat = Long.parseLong(config.getMinHeartbeat());
								useComet = config.getUSECOMET().equals("1");
								HeartbeatChatroom heartbeatChatroom = HeartbeatChatroom.getInstance(callbacklistener);
								if (useComet) {
									interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
									sessionData.setChatroomHeartbeatInterval(interval);
								} else {
									interval = Long.parseLong(config.getMinHeartbeat());
									sessionData.setChatroomHeartbeatInterval(interval);
								}

								isSubscribed = true;
								heartbeatChatroom.startHeartbeat(context);
							}

							@Override
							public void failCallback(JSONObject response) {
								callbacks.onError(response);
							}
						});
			}

		} else {
			CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacklistener);
		}
	}

	/**
	 * Stop receiving chatroom messages, lists and members.
	 */
	public void unsubscribe() {
		try {
			if (CometChat.isLoggedIn() && isSubscribed) {
				HeartbeatChatroom.getInstance(null).stopHeartbeatChatroom();
				leaveChatroom(null);

				if (useComet) {

					String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
					if (!TextUtils.isEmpty(transport)) {
						if (transport.equals("cometservice")) {
							CometserviceChatroom.getInstance().unSubscribe();
						} else if (transport.equals("cometservice-selfhosted")) {
							WebsyncChatroom.getInstance().unsubscribe();
						}
					}
				}
			}
		} catch (Exception e) {
		}
	}

	/**
	 * Join a specific chatroom
	 * 
	 * @param chatroomId
	 *            Id of chatroom
	 * @param chatroomName
	 *            Chatroom name
	 * @param password
	 *            Password of chatroom. For "password protected chatrooms",
	 *            <b>password must be SHA-1 encoded </b>. For other type of
	 *            chatrooms SHA-1 encoding is not required.
	 */
	public void joinChatroom(final String chatroomId, final String chatroomName, final String password,
			final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (!TextUtils.isEmpty(chatroomName)) {
				if (TextUtils.isEmpty(sessionData.getCurrentChatroom()) || sessionData.getCurrentChatroom().equals("0")) {
					joinChatroomAjaxCall(chatroomId, chatroomName, password, callbacks);
				} else {
					leaveChatroom(new Callbacks() {

						@Override
						public void successCallback(JSONObject response) {
							joinChatroomAjaxCall(chatroomId, chatroomName, password, callbacks);
						}

						@Override
						public void failCallback(JSONObject response) {
							callbacks.failCallback(response);
						}
					});
				}
			} else {
				throw new IllegalArgumentException("Chatroom name can't be empty");
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	private void joinChatroomAjaxCall(final String chatroomId, final String chatroomName, final String password,
			final Callbacks callbacks) {
		sessionData.setCurrentChatroomPassword(password);
		VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomPasswordUrl(),
				new VolleyAjaxCallbacks() {

					@Override
					public void successCallback(String response) {
						try {
							JSONObject chatroomJson = new JSONObject(response);
							String joinResponse = chatroomJson.getString("s");

							if (joinResponse.equals("INVALID_PASSWORD")) {
								/*
								 * Wrong password value returned 0
								 */
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_JOIN_CHATROOM_WRONG_PWD,
										CometChatKeys.ErrorKeys.MESSAGE_JOIN_CHATROOM_WRONG_PWD));
							} else if (joinResponse.equals("BANNED")) {
								/*
								 * User is banned for this chatroom value
								 * returned 2
								 */
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_JOIN_CHATROOM_BANNED,
										CometChatKeys.ErrorKeys.MESSAGE_JOIN_CHATROOM_BANNED));
							} else if (joinResponse.equals("INVALID_CHATROOM")) {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_CHATROOM_DONT_EXIST,
										CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_DONT_EXIST));
							} else {
								/* User is valid */
								if (useComet) {
									String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
									if (!TextUtils.isEmpty(transport)) {
										if (transport.equals("cometservice")) {
											if (!isSubscribedToChatroom(chatroomId)) {
												CometserviceChatroom.getInstance().startChatroomCometService(
														chatroomId, callbacklistener, callbacks);
											}
										} else if (transport.equals("cometservice-selfhosted")) {
											if (chatroomJson.has("cometid")) {
												WebsyncChatroom.getInstance().connect(
														JsonPhp.getInstance().getWebsyncServer(), chatroomId,
														chatroomJson.getString("cometid"), callbacklistener);
											}
										}
									}
								}
								subscribe(useHTML, callbacklistener);
								PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID,
										String.valueOf(chatroomId));
								PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD, password);
								sessionData.setCurrentChatroomName(chatroomName);
								sessionData.setCurrentChatroom(chatroomId);
								JSONObject json = new JSONObject();
								json.put("chatroom_id", chatroomId);
								json.put("push_channel", chatroomJson.get("push_channel"));
								callbacks.successCallback(json);
							}
						} catch (Exception e) {
							e.printStackTrace();
						}
					}

					@Override
					public void noInternetCallback() {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
								CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
					}

					@Override
					public void failCallback(String response) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
								CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
					}
				});

		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, String.valueOf(chatroomId));
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, password);
		vHelper.sendAjax();
	}

	public static void leaveChatroom(String chatroomId, String flag, SubscribeChatroomCallbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (null == chatroomId) {
				throw new IllegalArgumentException("chatroomId cannot be NULL or empty.");
			} else {
				if (TextUtils.isEmpty(flag)) {
					throw new IllegalArgumentException("flag cannot be NULL or empty.");
				} else {
					if (CometChat.isLoggedIn() && !sessionData.getCurrentChatroom().equals("0")) {
						VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomLeaveURL());
						vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
						if (flag.equals("0") || flag.equals("2")) {
							vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");

							if (flag.equals("2")) {
								// You got kicked.
								try {
									JSONObject json = new JSONObject();
									json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_KICKED);
									json.put("chatroom_id", chatroomId);
									callbacks.onActionMessageReceived(json);
								} catch (Exception e) {
									e.printStackTrace();
								}
							}
						} else if (flag.equals("1")) {
							vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_FLAG, "1");
							// You got banned
							try {
								JSONObject json = new JSONObject();
								json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_KICKED);
								json.put("chatroom_id", chatroomId);
								callbacks.onActionMessageReceived(json);
							} catch (Exception e) {
								e.printStackTrace();
							}
						}

						vHelper.sendAjax();

						sessionData.setCurrentChatroom("0");
						sessionData.setCurrentChatroomPassword("");
						sessionData.setCurrentChatroomName("0");
						sessionData.setChatroomHeartBeatTimestamp("");
						if (useComet) {
							String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
							if (!TextUtils.isEmpty(transport)) {
								if (transport.equals("cometservice")) {
									CometserviceChatroom.getInstance().unSubscribe();
								} else if (transport.equals("cometservice-selfhosted")) {
									WebsyncChatroom.getInstance().unsubscribe();
								}
							}
						}
						PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
						PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
						PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD);

						try {
							callbacks.onLeaveChatroom(new JSONObject("{\"chatroom_id\":" + chatroomId + "}"));
						} catch (Exception e) {
							e.printStackTrace();
						}
					} else {
						CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
								CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacks);
					}
				}
			}
		} else {
			CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN, callbacks);
		}
	}

	/**
	 * @param chatroomId
	 *            : Current chatroom id
	 */
	public void leaveChatroom(Callbacks callbacks) {
		String chatroomId = sessionData.getCurrentChatroom();
		if (CometChat.isLoggedIn()) {
			if (null == chatroomId) {
				// throw new
				// IllegalArgumentException("ChatroomId cannot be NULL or empty.");
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			} else {
				if (!sessionData.getCurrentChatroom().equals("0")
						&& sessionData.getCurrentChatroom().equals(chatroomId)) {
					VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomLeaveURL());
					vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
					vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");
					vHelper.sendAjax();

					sessionData.setCurrentChatroom("0");
					sessionData.setCurrentChatroomPassword("");
					sessionData.setCurrentChatroomName("0");
					sessionData.setChatroomHeartBeatTimestamp("");
					if (useComet) {
						String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
						if (!TextUtils.isEmpty(transport)) {
							if (transport.equals("cometservice")) {
								CometserviceChatroom.getInstance().unSubscribe();
							} else if (transport.equals("cometservice-selfhosted")) {
								WebsyncChatroom.getInstance().unsubscribe();
							}
						}
					}
					PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
					PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
					PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD);
					try {
						if (null != callbacks) {
							callbacks.successCallback(new JSONObject("{\"chatroom_id\":" + chatroomId + "}"));
						}
					} catch (Exception e) {
						e.printStackTrace();
					}
				} else {
					if (null != callbacks) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_CHATROOMID_MISMATCH,
								CometChatKeys.ErrorKeys.MESSAGE_CHATROOMID_MISMATCH));
					}
				}
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void getAllChatrooms(final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomHeartbeatUrl(),
					new VolleyAjaxCallbacks() {

						@Override
						public void successCallback(String response) {
							try {
								if (response.equals("[]")) {
									callbacks.successCallback(new JSONObject("{\"chatrooms\": {} }"));
								} else {
									JSONObject json = new JSONObject(response);
									if (json.has(CometChatKeys.AjaxKeys.CHATROOM_LIST)) {
										callbacks.successCallback(json
												.getJSONObject(CometChatKeys.AjaxKeys.CHATROOM_LIST));
									} else {
										callbacks.successCallback(new JSONObject());
									}
								}
							} catch (Exception e) {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
										CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
							}
						}

						@Override
						public void noInternetCallback() {
						}

						@Override
						public void failCallback(String response) {
						}
					});
			vHelper.addNameValuePair(AjaxKeys.CHATROOM_LIST, "1");
			vHelper.addNameValuePair(AjaxKeys.FORCE, "1");
			vHelper.addNameValuePair(AjaxKeys.FORCE_LIST, "1");
			vHelper.sendAjax();

		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Fetches the details of each chatroom member. You have to be a part of the
	 * chatroom to make this request.
	 */
	/*
	 * public void getChatroomMembers(String chatroomId, final Callbacks
	 * callbacks) { if (CometChat.isLoggedIn()) { if
	 * (chatroomId.equals(sessionData.getCurrentChatroom())) { Handler handler =
	 * new Handler() {
	 *
	 * @Override public void handleMessage(Message msg) {
	 * super.handleMessage(msg); try { JSONObject json = new
	 * JSONObject(msg.obj.toString()); if
	 * (json.has(CometChatKeys.ChatroomKeys.MEMBERS)) {
	 * callbacks.successCallback(json.getJSONObject(ChatroomKeys.MEMBERS)); } }
	 * catch (Exception e) {
	 * callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys
	 * .ErrorKeys.CODE_JSON_PARSING_ERROR,
	 * CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR)); } } };
	 *
	 * AjaxHelper aHelper = new AjaxHelper(URLFactory.getChatroomHeartbeatUrl(),
	 * handler);
	 * aHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID,
	 * chatroomId); aHelper.addNameValuePair(AjaxKeys.CHATROOM_LIST, "0");
	 * aHelper.addNameValuePair(AjaxKeys.FORCE_LIST, "1"); aHelper.execute(); }
	 * else {
	 * callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys
	 * .CODE_CHATROOMID_MISMATCH,
	 * CometChatKeys.ErrorKeys.MESSAGE_CHATROOMID_MISMATCH)); } } else {
	 * callbacks
	 * .failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys
	 * .CODE_USER_NOT_LOGGEDIN, CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
	 * } }
	 */

	/**
	 * Send a message to the designated chatroom. You have the be the member of
	 * this chatroom to send a message.
	 */
	public void sendMessage(String message, final Callbacks callbacks) throws IllegalArgumentException {
		String chatroomId = sessionData.getCurrentChatroom();
		if (chatroomId.equals("0")) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
					CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
		} else {
			if (TextUtils.isEmpty(message)) {
				throw new IllegalArgumentException("message cannot be NULL or empty.");
			} else {
				if (CometChat.isLoggedIn()) {
					if (chatroomId.equals(sessionData.getCurrentChatroom())) {
						if (!useComet) {
							resetChatroomHeartbeatInterval();
						}

						VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getSendChatroomMessageURL(),
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
											callbacks.failCallback(CommonUtils.createErrorJson(
													CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
													CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
										}
									}

									@Override
									public void noInternetCallback() {
										callbacks.failCallback(CommonUtils.createErrorJson(
												CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
												CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
									}

									@Override
									public void failCallback(String response) {
										callbacks.failCallback(CommonUtils.createErrorJson(
												CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
												CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
									}
								});

						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.MESSAGE, message);
						vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);
						vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_NAME, SessionData.getInstance()
								.getCurrentChatroomName());
						vHelper.sendAjax();
					} else {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_CHATROOMID_MISMATCH,
								CometChatKeys.ErrorKeys.MESSAGE_CHATROOMID_MISMATCH));
					}
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
							CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
				}
			}
		}
	}

	public void sendImage(File imageFile, final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
				if (imageFile != null && imageFile.exists()) {
					ImageSharing imgSharing = new ImageSharing();
					imgSharing.sendImageAjax(imageFile,
							PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
							CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void sendImage(Bitmap bitmap, Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
				ImageSharing imgSharing = new ImageSharing();
				imgSharing.sendImageAjax(bitmap, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
						true, "IMG-" + System.currentTimeMillis() + ".png", callbacks);
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void sendAudioFile(File audioFile, Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (audioFile != null && audioFile.exists()) {
				ImageSharing imgSharing = new ImageSharing();
				imgSharing.sendImageAjax(audioFile, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
						true, callbacks);
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
						CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
			}

		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Invite a user to be a part of the current chatroom. You have to be a part
	 * of the chatroom to make this call. The other user will receive a chatroom
	 * invite message in his respective callback.
	 */
	public void inviteUser(final JSONArray users, final Callbacks callbacks) {
		userInviteCount = 1;
		if (CometChat.isLoggedIn()) {
			String chatroomId = sessionData.getCurrentChatroom();
			if (chatroomId.equals("0")) {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			} else {
				if (null == users && users.length() == 0) {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
							CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
				} else {
					try {
						String chatroomName = new String(CommonUtils.encodeBase64(SessionData.getInstance()
								.getCurrentChatroomName()), StaticMembers.UTF_8);

						String password = SessionData.getInstance().getCurrentChatroomPassword(), url = URLFactory
								.getChatroomInviteURL();
						int i;
						final int len = users.length();
						final JSONArray returnResponse = new JSONArray();
						for (i = 0; i < len; i++) {
							sendInviteuserAjax(chatroomId, chatroomName, password, url, users.getString(i),
									new Callbacks() {

										@Override
										public void successCallback(JSONObject response) {
											try {
												returnResponse.put(response.get("user"));
												if (userInviteCount == len) {
													JSONObject data = new JSONObject();
													data.put("users_invited", returnResponse);
													callbacks.successCallback(data);
												}
											} catch (Exception e) {
												e.printStackTrace();
											}
											userInviteCount++;
										}

										@Override
										public void failCallback(JSONObject response) {

										}
									});
						}
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			}

		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	private void sendInviteuserAjax(String chatroomId, String chatroomName, String password, String url,
			final String userId, final Callbacks callback) {
		VolleyHelper vHelper = new VolleyHelper(context, url, new VolleyAjaxCallbacks() {

			@Override
			public void successCallback(String response) {
				try {
					callback.successCallback(new JSONObject("{\"user\":\"" + userId + "\"}"));
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

			@Override
			public void noInternetCallback() {
				callback.failCallback(null);
			}

			@Override
			public void failCallback(String response) {
				callback.failCallback(null);
			}
		});
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, chatroomId);
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITEDID, password);
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMNAME, chatroomName);
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITE, userId);
		vHelper.sendCallBack(false);
		vHelper.sendAjax();
	}

	/**
	 * <p>
	 * Creates a new chatroom and will throw "onChatroomCreated" callback which returns id of created chatroom or throws
	 * error
	 * </p>
	 * 
	 * @param chatroomName
	 *            Name of chatroom
	 * @param chatroomPassword
	 *            Password for the chatroom
	 * @param chatroomType
	 *            Type of chatroom to be created<br>
	 *            You can select required type from the ChatroomType enum<br>
	 *            The types are PUBLIC_CHATROOM, PASSWORD_PROTECTED, INVITE_ONLY
	 */
	public void createChatroom(String chatroomName, String chatroomPassword, ChatroomType chatroomType,
			Callbacks callbacks) {

		if (CometChat.isLoggedIn()) {
			if (!TextUtils.isEmpty(chatroomName)) {
				switch (chatroomType) {
				case PUBLIC_CHATROOM:
					sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
					break;
				case PASSWORD_PROTECTED:
					if (!TextUtils.isEmpty(chatroomPassword)) {
						sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
					} else {
						throw new IllegalArgumentException(
								"Password can't be empty or null for Password protected room");
					}
					break;
				case INVITE_ONLY:
					sendCreateChatromAjax(chatroomName, chatroomPassword, chatroomType.ordinal(), callbacks);
					break;
				default:
					throw new IllegalArgumentException("Please check your chatroom type");
				}
			} else {
				throw new IllegalArgumentException("Chatroom name can't be empty or null");
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	private void sendCreateChatromAjax(final String chatroomName, final String chatroomPassword, int chatroomType,
			final Callbacks callbacks) {
		VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getCreateChatroomURL(), new VolleyAjaxCallbacks() {

			@Override
			public void successCallback(String response) {

				long chatroomId;
				try {
					JSONObject json = new JSONObject(response);
					chatroomId = json.getLong("id");
				} catch (Exception e) {
					chatroomId = Long.parseLong(response);
				}

				if (chatroomId == 0) {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_CHATROOM_CREATION_ERROR,
							CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_CREATION_ERROR));
				} else {
					joinChatroom(String.valueOf(chatroomId), chatroomName, chatroomPassword, callbacks);
					try {
						callbacks.successCallback(new JSONObject("{\"chatroom_id\":" + String.valueOf(chatroomId) + "}"));
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			}

			@Override
			public void noInternetCallback() {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
						CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));

			}

			@Override
			public void failCallback(String response) {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
						CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
			}
		});

		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CHATROOM_TYPE, chatroomType);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, chatroomPassword);
		vHelper.addNameValuePair(CometChatKeys.AjaxKeys.NAME, chatroomName);
		vHelper.sendAjax();
	}

	/**
	 * Resets the heartbeat timing to minimum <br>
	 * <p>
	 * Use this method only when cometservice is not in use to reset heartbeat interval after sending chat message.
	 * </p>
	 */
	private void resetChatroomHeartbeatInterval() {
		minHeartbeat = Long.parseLong(JsonPhp.getInstance().getConfig().getMinHeartbeat());
		sessionData.setChatroomHeartbeatIdealCount(1);
		if (useComet) {
			sessionData.setChatroomHeartbeatInterval(Long.parseLong(JsonPhp.getInstance().getConfig()
					.getREFRESHBUDDYLIST()) * 1000);
		} else {
			if (sessionData.getChatroomHeartbeatInterval() > minHeartbeat) {
				sessionData.setChatroomHeartbeatInterval(minHeartbeat);
				HeartbeatChatroom.getInstance(null).changeChatroomHeartbeatInverval();
			}
		}

	}

	/**
	 * Returns the subscription status to the current chatroom.
	 */
	public boolean isSubscribedToChatroom(String chatroomId) {
		return sessionData.getCurrentChatroom().equals(chatroomId);
	}

	public String getCurrentChatroom() {
		if (CometChat.isLoggedIn()) {
			return SessionData.getInstance().getCurrentChatroom();
		}
		return "0";
	}

	/**
	 * Sends a video file in chatroom which you have joined
	 * 
	 * @param videoFile
	 *            Video file to be sent
	 * @param callbacks
	 */
	public void sendVideo(File videoFile, Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
				if (videoFile != null && videoFile.exists()) {
					VideoSharing videoSharing = new VideoSharing();
					videoSharing.sendVideoAjax(videoFile,
							PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
							CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * Sends a video file in chatroom which you have joined
	 * 
	 * @param filePath
	 *            Path of video file to be sent
	 * @param callbacks
	 */
	public void sendVideo(String filePath, Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
				File videoFile = new File(filePath);
				if (videoFile != null && videoFile.exists()) {
					VideoSharing videoSharing = new VideoSharing();
					videoSharing.sendVideoAjax(videoFile,
							PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID), true, callbacks);
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
							CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void sendFile(File file, Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
				if (file != null && file.exists()) {
					ImageSharing imgSharing = new ImageSharing();
					imgSharing.sendImageAjax(file, PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID),
							true, callbacks);
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_FILE_DOES_NOT_EXIST,
							CometChatKeys.ErrorKeys.MESSAGE_FILE_DOES_NOT_EXIST));
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	/**
	 * <b>Delete a chatroom</b> <br>
	 * You can delete the chatroom which are created by you only
	 * 
	 * @param chatroomId
	 *            Pass the chatroom id
	 * @param callbacks
	 * @throws IllegalArgumentException
	 */
	public void deleteChatroom(final String chatroomId, final Callbacks callbacks) throws IllegalArgumentException {
		if (CometChat.isLoggedIn()) {
			if (TextUtils.isEmpty(chatroomId)) {
				throw new IllegalArgumentException("ChatroomId can't be empty or null");
			} else {
				VolleyHelper vHelper = new VolleyHelper(context, URLFactory.deleteChatroomUrl(),
						new VolleyAjaxCallbacks() {

							@Override
							public void successCallback(String response) {
								try {
									// Logger.error("chatroom delet respnse =" + response);
									if (response.equals("1")) {
										JSONObject json = new JSONObject();
										json.put("chatroom_id", chatroomId);
										callbacks.successCallback(json);
										if (chatroomId.equals(PreferenceHelper
												.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))) {
											leaveChatroom(null);
										}
									} else {
										JSONObject json = new JSONObject();
										json.put(CometChatKeys.ErrorKeys.CODE_CHATROOM_DELETION_ERROR,
												CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_DELETE_ERROR);
										callbacks.failCallback(json);
									}
								} catch (Exception e) {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
											CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
								}
							}

							@Override
							public void noInternetCallback() {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
										CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
							}

							@Override
							public void failCallback(String response) {
								callbacks.failCallback(CommonUtils.createErrorJson(
										CometChatKeys.ErrorKeys.CODE_CONNECTION_TO_HOST_404,
										CometChatKeys.ErrorKeys.MESSAGE_CONNECTION_REFUSED_404));
							}
						});

				vHelper.addNameValuePair(AjaxKeys.ID, chatroomId);
				vHelper.sendAjax();
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void sendSticker(final String message, final Callbacks callbacks) {
		if (CometChat.isLoggedIn()) {
			if (Stickers.isEnabled()) {
				String chatroomId = sessionData.getCurrentChatroom();
				if (chatroomId.equals("0")) {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
							CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
				} else {
					VolleyHelper helper = new VolleyHelper(context, URLFactory.getSendStickerURL(),
							new VolleyAjaxCallbacks() {

								@Override
								public void successCallback(String response) {
									try {
										JSONObject sendResponse = new JSONObject(response.substring(
												response.indexOf("{"), response.lastIndexOf("}") + 1));
										Long id = sendResponse.getLong(CometChatKeys.AjaxKeys.ID);
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
								public void noInternetCallback() {
									callbacks.failCallback(CommonUtils.createErrorJson(
											CometChatKeys.ErrorKeys.CODE_NO_INTERNET_CONNECTION,
											CometChatKeys.ErrorKeys.MESSAGE_PLEASE_CHECK_INTERNET));
								}

								@Override
								public void failCallback(String response) {

								}
							});
					helper.addNameValuePair(AjaxKeys.TO, chatroomId);
					helper.addNameValuePair(AjaxKeys.CATEGORY, Stickers.getCategory(message));
					helper.addNameValuePair(AjaxKeys.KEY, message);
					helper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
					helper.addNameValuePair("caller", "");
					helper.sendAjax();
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_TYPING_NOT_ENABLED,
						CometChatKeys.ErrorKeys.MESSAGE_TYPING_NOT_ENABLED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_STICKER_PLUGIN_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_SITCKER_PLUGIN_NOT_ENABLED));
		}
	}
}
