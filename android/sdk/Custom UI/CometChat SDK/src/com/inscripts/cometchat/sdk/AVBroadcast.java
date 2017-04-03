package com.inscripts.cometchat.sdk;

import org.json.JSONArray;
import org.json.JSONObject;

import android.content.Context;
import android.text.TextUtils;
import android.view.ViewGroup.LayoutParams;
import android.widget.RelativeLayout;

import com.inscripts.avchat.webrtc.App;
import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AVchatKeys;
import com.inscripts.keys.CometChatKeys.ChatroomKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.plugins.AVBroadcastplugin;

import fm.SingleAction;
import fm.icelink.webrtc.DefaultProviders;

public class AVBroadcast {

	private Context context;
	private static AVBroadcast avbroadcast;
	private String roomName;
	private App app;
	private String webasyncURL = "https://r.chatforyoursite.com:8443/websync.ashx",
			iceLinkServerAddress = "r.chatforyoursite.com";
	private static RelativeLayout relativeLayoutForRotationHandling;

	private AVBroadcast(Context context) {
		this.context = context;
	}

	public static AVBroadcast getAVBroadcastInstance(Context context) {
		if (avbroadcast == null) {
			avbroadcast = new AVBroadcast(context);
		}
		return avbroadcast;
	}

	public void sendAVBroadcastRequest(final String toId, final Callbacks callbacks) {
		if (AVBroadcastplugin.isEnabled()) {
			if (!TextUtils.isEmpty(toId)) {
				VolleyHelper vhelper = new VolleyHelper(context, URLFactory.getAVbroadcastUrl(),
						new VolleyAjaxCallbacks() {

							@Override
							public void successCallback(String response) {
								JSONObject json = new JSONObject();
								try {
									if (response.contains("jqcc") && response.contains("(")) {
										String data[] = response.split("\\(");
										String room = data[1].substring(0, data[1].length() - 1);
										json.put(CometChatKeys.AjaxKeys.CALLID, room);
										json.put("id", toId);
										callbacks.successCallback(json);
										SessionData.getInstance().setActiveAVchatUserID(toId);
										roomName = room;
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
								Logger.error("fail  " + response);
							}
						});

				vhelper.addNameValuePair(AjaxKeys.ACTION, "request");
				vhelper.addNameValuePair(AjaxKeys.TO, toId);
				vhelper.addNameValuePair(AjaxKeys.CHATROOM_TYPE, "1");
				vhelper.addNameValuePair(AjaxKeys.AVBROADCAST, "0");
				vhelper.sendAjax();
			} else {
				throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVBROADCAST_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED));
			return;
		}
	}

	public void startBroadcast(final boolean isInitiator, String callid, final RelativeLayout container,
			final Callbacks callbacks) {
		if (!AVBroadcastplugin.isEnabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVBROADCAST_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED));
			return;
		}
		if (android.os.Build.VERSION.SDK_INT < 16) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVBROADCAST_NOT_SUPPORTED,
					CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_NOT_SUPPORTED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			if (TextUtils.isEmpty(callid)) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND,
						CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND));
			} else {
				if (!SessionData.getInstance().isAvchatCallRunning()) {
					app = App.getInstance();
					String webRTCServerAddress = JsonPhp.getInstance().getWebRTCServer();
					if (null != webRTCServerAddress) {
						if (webRTCServerAddress.contains("r.chatforyoursite.com")) {
							webasyncURL = "https://" + webRTCServerAddress + ":8443/websync.ashx";
							iceLinkServerAddress = webRTCServerAddress;
						} else {
							webasyncURL = "http://" + webRTCServerAddress + ":8080/websync.ashx";
							iceLinkServerAddress = webRTCServerAddress;
						}
					}
					boolean video = true, audio = true;
					if (!isInitiator) {
						video = audio = false;
					}

					String webrtc_prefix = PreferenceHelper.get(PreferenceKeys.UserKeys.WEBRTC_PREFIX);
					try {
						if (!TextUtils.isEmpty(webrtc_prefix)) {
							roomName = EncryptionHelper.encodeIntoMD5(webrtc_prefix + callid);
						} else {
							roomName = callid;
						}
					} catch (Exception e1) {
						e1.printStackTrace();
					}

					if (!roomName.startsWith("/")) {
						roomName = "/" + roomName;
					}
					if (container == null) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AVBROADCAST_CONTAINER_EMPTY,
								CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_CONTAINER_EMPTY));
					}
					if (relativeLayoutForRotationHandling == null) {
						relativeLayoutForRotationHandling = new RelativeLayout(context);
						relativeLayoutForRotationHandling.setLayoutParams(new RelativeLayout.LayoutParams(
								LayoutParams.MATCH_PARENT, LayoutParams.MATCH_PARENT));
					}
					DefaultProviders.setAndroidContext(context);
					SessionData.getInstance().setAvchatCallRunning(true);
					app.startLocalMedia(new SingleAction<Exception>() {
						@Override
						public void invoke(Exception ex) {
							if (ex == null) {
								// Start the signalling engine.
								app.startSignalling(new SingleAction<String>() {
									@Override
									public void invoke(String ex) {
										if (ex != null) {
											Logger.error("Error at startSignalling " + ex);
										}
									}
								}, webasyncURL, String.valueOf(SessionData.getInstance().getId()), true, isInitiator);
								// Start the conference engine.
								app.startConference(iceLinkServerAddress, roomName, true,
										relativeLayoutForRotationHandling, new SingleAction<Exception>() {
											@Override
											public void invoke(Exception ex) {
												if (ex != null) {
													Logger.error("Error at startconference " + ex.getLocalizedMessage());
												}
											}
										}, true, isInitiator, callbacks);
							} else {
								Logger.error("Error at startLocalMedia " + ex.getLocalizedMessage());
							}
						}
					}, video, audio);
				}
			}
		}
	}

	public void endBroadcast(boolean isInitiator, final String userId, final String callid, final Callbacks callbacks) {
		if (!AVBroadcastplugin.isEnabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVBROADCAST_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			if (!TextUtils.isEmpty(userId)) {
				if (TextUtils.isEmpty(callid)) {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND,
							CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND));
				} else {
					VolleyHelper helper = new VolleyHelper(context, URLFactory.getAVbroadcastUrl(),
							new VolleyAjaxCallbacks() {

								@Override
								public void successCallback(String response) {
									SessionData.getInstance().setAvchatCallRunning(false);
								}

								@Override
								public void noInternetCallback() {

								}

								@Override
								public void failCallback(String response) {

								}
							});
					helper.addNameValuePair(AjaxKeys.ACTION, "endcall");
					helper.addNameValuePair(AVchatKeys.GRP, callid);
					if (isInitiator) {
						helper.addNameValuePair(AjaxKeys.TO, userId);
					} else {
						helper.addNameValuePair(AjaxKeys.TO, "");
					}
					helper.sendAjax();
				}
			} else {
				throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void inviteUsersInBroadcast(JSONArray users, String callid, Callbacks callbacks)
			throws IllegalArgumentException {
		if (!AVBroadcastplugin.isEnabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVBROADCAST_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			if (TextUtils.isEmpty(callid)) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND,
						CometChatKeys.ErrorKeys.MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND));
			} else {
				if (users == null || users.length() == 0) {
					throw new IllegalArgumentException("users list cannot be NULL. users list cannot have 0 length.");
				} else {
					try {
						int len = users.length(), i;
						for (i = 0; i < len; i++) {

							VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAVBroadcastInviteUrl(),
									new VolleyAjaxCallbacks() {

										@Override
										public void successCallback(String response) {

										}

										@Override
										public void noInternetCallback() {

										}

										@Override
										public void failCallback(String response) {

										}
									});
							vHelper.addNameValuePair(AVchatKeys.GRP, callid);
							vHelper.addNameValuePair(ChatroomKeys.INVITE, users.getString(i));
							vHelper.sendCallBack(false);
							vHelper.sendAjax();
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

	/**
	 * To handle the device rotation you need to call this method onPause()
	 * event of activity.<br>
	 * Pass the container which is provided to start the avchat
	 * 
	 */
	public void removeVideoOnRotation(RelativeLayout layout) {
		if (layout != null) {
			if (relativeLayoutForRotationHandling != null) {
				if (SessionData.getInstance().isAvchatCallRunning()) {
					layout.removeView(relativeLayoutForRotationHandling);
				} else {
					Logger.error("no avchat");
				}
			}
		} else {
			Logger.error("layout is null");
		}
	}

	/**
	 * To handle the device rotation you need to call this method onResume()
	 * event of activity.<br>
	 * Pass the container which is provided to start the avchat
	 * 
	 */
	public void addVideoOnRotation(RelativeLayout layout) {
		if (layout != null) {
			if (relativeLayoutForRotationHandling != null) {
				if (SessionData.getInstance().isAvchatCallRunning()) {
					layout.addView(relativeLayoutForRotationHandling);
				} else {
					Logger.error("no avchat");
				}
			}
		} else {
			Logger.error("layout is null");
		}
	}
}
