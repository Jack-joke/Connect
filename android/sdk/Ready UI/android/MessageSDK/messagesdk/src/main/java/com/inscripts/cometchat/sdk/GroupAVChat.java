/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/

package com.inscripts.cometchat.sdk;

import android.content.Context;
import android.media.AudioManager;
import android.text.TextUtils;
import android.view.ViewGroup.LayoutParams;
import android.widget.RelativeLayout;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.ErrorKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.VideoChat;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import fm.SingleAction;
import fm.android.conference.webrtc.App;
import fm.icelink.webrtc.DefaultProviders;

public class GroupAVChat {
	private Context context;
	private static GroupAVChat groupChat;
	private String roomName;
	private App app;
	private String webasyncURL = "https://r.chatforyoursite.com:8443/websync.ashx",
			iceLinkServerAddress = "r.chatforyoursite.com";
	private static RelativeLayout relativeLayoutForRotationHandling;
	private static AudioManager audioManager;

	public static GroupAVChat getGroupChatInstance(Context context) {
		if (null == groupChat) {
			groupChat = new GroupAVChat(context);
		}
		return groupChat;
	}

	private GroupAVChat(Context context) {
		this.context = context;
	}

	public void joinConference(final Callbacks callbacks) {
		if (VideoChat.isDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED));
			return;
		}
		if (android.os.Build.VERSION.SDK_INT < 16) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_SUPPORTED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_NOT_SUPPORTED));
			return;
		}

		if (CometChat.isLoggedIn()) {
			String chatroomid = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
			if (!TextUtils.isEmpty(chatroomid)) {
				VolleyHelper vhelper = new VolleyHelper(context, URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {

					@Override
					public void successCallback(String response) {
						try {
							JSONObject json = new JSONObject();
							json.put("status", "conference join success");
							callbacks.successCallback(json);
						} catch (Exception e) {
							e.printStackTrace();
						}

					}

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if(isNoInternet){
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

				vhelper.addNameValuePair(CometChatKeys.AVchatKeys.JOIN, "1");
				vhelper.addNameValuePair(CometChatKeys.AVchatKeys.TYPE, "0");
				vhelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, chatroomid);
				vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
				vhelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "call");
				vhelper.sendAjax();
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}

	}

	public void startConference(final RelativeLayout container, final Callbacks callbacks) {
		if (VideoChat.isDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED));
			return;
		}
		if (android.os.Build.VERSION.SDK_INT < 16) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_SUPPORTED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_NOT_SUPPORTED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			String chatroomid = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
			if (!TextUtils.isEmpty(chatroomid)) {
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
				if (TextUtils.isEmpty(roomName)) {
					if (!TextUtils.isEmpty(SessionData.getInstance().getAvChatRoomName())) {
						roomName = SessionData.getInstance().getAvChatRoomName();
					} else {
						roomName = chatroomid;
					}
				}
				String webrtc_channel = PreferenceHelper.get(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
				try {
					if (!TextUtils.isEmpty(webrtc_channel)) {
						roomName = EncryptionHelper.encodeIntoMD5(webrtc_channel + roomName);
					}
				} catch (Exception e1) {
					e1.printStackTrace();
				}

				if (!roomName.startsWith("/")) {
					roomName = "/" + roomName;
				}
				if (container == null) {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_AVCHAT_CONTAINER_EMPTY,
							CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_CONTAINER_EMPTY));
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
							}, webasyncURL, false, false);
							// Start the conference engine.
                            app.startConference(iceLinkServerAddress,roomName,false,relativeLayoutForRotationHandling,null,null,null,null,null,null,false,false,new SingleAction<Exception>(){
                                @Override
                                public void invoke(Exception ex) {
                                    if (ex != null) {
                                        Logger.error("Error at startconference " + ex.getLocalizedMessage());
                                    }
                                }
                            });
						} else {
							Logger.error("Error at startLocalMedia " + ex.getLocalizedMessage());
						}
					}
				}, true, true);

			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		} else {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
					CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
		}
	}

	public void sendConferenceRequest(final Callbacks callbacks) {
		if (VideoChat.isDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			String chatroomId = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
			if (!TextUtils.isEmpty(chatroomId)) {
				VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {

					@Override
					public void successCallback(String response) {
						// Logger.error("success response of cr avchat request "
						// + response);+

						try {
							if (!response.equals("1")) {
								String room = VideoChat.getAVRoomnameFromRequest(response, false);
								roomName = room;
								SessionData.getInstance().setAvChatRoomName(roomName);
							}
							JSONObject json = new JSONObject();
							json.put("status", "Conference request sent successfully");
							callbacks.successCallback(json);
						} catch (Exception e) {
							e.printStackTrace();
						}
					}

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if(isNoInternet){
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
				vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, chatroomId);
				// vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP,
				// chatroomId);
				vHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
				vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.REQUEST);
				vHelper.sendAjax();
			} else {
				// You have not joined any chatroom
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_CHATROOM_NOT_JOINED,
						CometChatKeys.ErrorKeys.MESSAGE_CHATROOM_NOT_JOINED));
			}
		}
	}

	public void endConference(final Callbacks callbacks) {
		if (VideoChat.isDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AVCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED));
			return;
		}
		if (CometChat.isLoggedIn()) {
			String chatroomId = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
			if (!TextUtils.isEmpty(chatroomId)) {
				VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {

					@Override
					public void successCallback(String response) {
						if (app != null) {
							SessionData.getInstance().setAvChatRoomName("");
							SessionData.getInstance().setActiveAVchatUserID("0");
							SessionData.getInstance().setAvchatCallRunning(false);
							try {
								JSONObject json = new JSONObject();
								json.put("status", "Conference ended successfully");
								callbacks.successCallback(json);
							} catch (Exception e) {
								e.printStackTrace();
							}
							app.endCall();
							app = null;
						}
					}

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if(isNoInternet){
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
				vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, chatroomId);
				vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, chatroomId);
				vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.ENDCALL_ACTION);
				vHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
				vHelper.sendAjax();
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

	public void toggleAudio(Boolean toggle) {
		if (VideoChat.isDisabled()) {
			return;
		}
		if (app != null) {
			app.muteAudio(toggle);
		}
	}

	public void toggleVideo(Boolean toggle) {
		if (VideoChat.isDisabled()) {
			return;
		}
		if (app != null) {
			app.publishLocalVideo(toggle);
		}
	}

	/**
	 * Allows you to switch between front and back cameras
	 */
	public void switchCamera() {
		try {
			if (VideoChat.isDisabled()) {
				return;
			}
			if (app != null && SessionData.getInstance().isAvchatCallRunning()) {
				app.switchCamera();
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	/**
	 * Allows you to switch between your main and ear/caller speaker
	 */
	public void switchSpeakers(Callbacks callbacks) {
		try {
			if (audioManager == null) {
				audioManager = (AudioManager) context.getSystemService(Context.AUDIO_SERVICE);
			}
			audioManager.setMode(AudioManager.MODE_IN_COMMUNICATION);
			if (audioManager.isSpeakerphoneOn()) {
				audioManager.setSpeakerphoneOn(false);
				callbacks.successCallback(new JSONObject().put("audio_route", "calle speaker"));
			} else {
				audioManager.setSpeakerphoneOn(true);
				callbacks.successCallback(new JSONObject().put("audio_route", "main speaker"));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
