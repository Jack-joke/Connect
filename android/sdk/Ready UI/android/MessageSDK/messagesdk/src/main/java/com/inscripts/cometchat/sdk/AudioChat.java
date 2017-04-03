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

public class AudioChat {

	private static AudioChat audiochat;
	private Context context;
	private String webasyncURL = "https://r.chatforyoursite.com:8443/websync.ashx",
			iceLinkServerAddress = "r.chatforyoursite.com";
	private String roomName;
	private static RelativeLayout relativeLayoutForRotationHandling;
	private App app;
	private static AudioManager audioManager;

	private AudioChat(Context context) {
		this.context = context;
	}

	public static AudioChat getInstance(Context context) {
		if (audiochat == null) {
			audiochat = new AudioChat(context);
		}
		return audiochat;
	}

	public void acceptAudioChatRequest(final String userId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}

			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					if (userId.equals(SessionData.getInstance().getActiveAVchatUserID())) {
						String tempName = SessionData.getInstance().getAvChatRoomName();
						VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
								new VolleyAjaxCallbacks() {

									@Override
									public void successCallback(String response) {
										try {
											SessionData.getInstance().setActiveAVchatUserID(userId);
											JSONObject json = new JSONObject();
											json.put("id", userId);
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
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
						vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, tempName);
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "accept");
						vHelper.sendCallBack(false);
						vHelper.sendAjax();
					} else {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_INCORRECT_USER,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_INCORRECT_USER));
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}

			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}

	}

	public void rejectAudioChatRequest(final String userId, final String callId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					if (TextUtils.isEmpty(callId)) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND));
					} else {
						if (userId.equals(SessionData.getInstance().getActiveAVchatUserID())) {
							VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
									new VolleyAjaxCallbacks() {

										@Override
										public void successCallback(String response) {
											try {
												SessionData.getInstance().setAvChatRoomName("");
												SessionData.getInstance().setActiveAVchatUserID("0");
												JSONObject json = new JSONObject();
												json.put("id", userId);
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
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
							vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, callId);
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.REJECTCALL_ACTION);
							vHelper.sendAjax();
						} else {
							callbacks.failCallback(CommonUtils.createErrorJson(
									CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_INCORRECT_USER,
									CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_INCORRECT_USER));
						}
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void startAudioChatCall(String callid, final RelativeLayout container, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {

			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
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

					String webrtc_prefix = PreferenceHelper.get(PreferenceKeys.UserKeys.WEBRTC_CHANNEL);
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
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CONTAINER_EMPTY,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CONTAINER_EMPTY));
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
								}, webasyncURL,false,false);
								// Start the conference engine.
								// Logger.error("Final roomname: " + roomName);
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
					}, false, true);
				} else {
					callbacks.failCallback(CommonUtils.createErrorJson(
							CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_USER_BUSY,
							CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_USER_BUSY));
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}

	}

	public void endAudioChatCall(final String userId, final String callid, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {

			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					if (TextUtils.isEmpty(callid)) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND));
					} else {
						if (userId.equals(SessionData.getInstance().getActiveAVchatUserID())) {
							VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
									new VolleyAjaxCallbacks() {

										@Override
										public void successCallback(String response) {
											if (app != null) {
												SessionData.getInstance().setAvChatRoomName("");
												SessionData.getInstance().setActiveAVchatUserID("0");
												SessionData.getInstance().setAvchatCallRunning(false);
												try {
													JSONObject json = new JSONObject();
													json.put("id", userId);
													json.put(CometChatKeys.AjaxKeys.CALLID, callid);
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
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
							vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, callid);
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.ENDCALL_ACTION);
							vHelper.sendAjax();
						} else {
							callbacks.failCallback(CommonUtils.createErrorJson(
									CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_INCORRECT_USER,
									CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_INCORRECT_USER));
						}
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void sendAudioChatRequest(final String toId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {

			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(toId)) {
					try {
						/*String myId = EncryptionHelper.encodeIntoMD5(String.valueOf(SessionData.getInstance().getId()));
						String wId = EncryptionHelper.encodeIntoMD5(toId);
						SessionData.getInstance().setAvChatRoomName("");
						if (SessionData.getInstance().getId() < Integer.parseInt(toId)) {
							roomName = "/" + EncryptionHelper.encodeIntoMD5(URLFactory.getWebsiteHostURL() + myId + wId);
						} else {
							roomName = "/" + EncryptionHelper.encodeIntoMD5(URLFactory.getWebsiteHostURL() + wId + myId);
						}*/
						VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
								new VolleyAjaxCallbacks() {

									@Override
									public void successCallback(String response) {
										JSONObject json = new JSONObject();
										try {
											if (!response.equals("1")) {
												
												String room = VideoChat.getAVRoomnameFromRequest(response, false);
												if (!TextUtils.isEmpty(room)) {
													json.put(CometChatKeys.AjaxKeys.CALLID, room);
												}
												roomName = room;
												SessionData.getInstance().setAvChatRoomName(roomName);
											}
											SessionData.getInstance().setActiveAVchatUserID(toId);
											json.put("id", toId);
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
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, toId);
						// vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName.substring(1));
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.REQUEST);
						vHelper.sendAjax();

					} catch (Exception e) {
						e.printStackTrace();
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void sendBusyTone(final String userId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					String tempName = SessionData.getInstance().getAvChatRoomName();
					if (TextUtils.isEmpty(tempName)) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND));
					} else {
						VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
								new VolleyAjaxCallbacks() {

									@Override
									public void successCallback(String response) {
										try {
											JSONObject json = new JSONObject();
											json.put("id", userId);
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
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
						vHelper.sendCallBack(false);
						vHelper.sendAjax();
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void cancelAudioChatRequest(final String userId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					String tempName = SessionData.getInstance().getAvChatRoomName();
					if (TextUtils.isEmpty(tempName)) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND));
					} else {
						if (userId.equals(SessionData.getInstance().getActiveAVchatUserID())) {
							VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
									new VolleyAjaxCallbacks() {

										@Override
										public void successCallback(String response) {
											SessionData.getInstance().setAvChatRoomName("");
											SessionData.getInstance().setActiveAVchatUserID("0");
											try {
												JSONObject json = new JSONObject();
												json.put("id", userId);
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
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION,
									StaticMembers.CANCEL_OUTGOING_CALL_ACTION);
							vHelper.sendAjax();
						} else {
							callbacks.failCallback(CommonUtils.createErrorJson(
									CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_INCORRECT_USER,
									CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_INCORRECT_USER));
						}
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void sendNoAnswerCall(final String userId, final Callbacks callbacks) {
		if (VideoChat.isAudioChatDisabled()) {
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_ENABLED,
					CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED));
			return;
		} else {
			if (android.os.Build.VERSION.SDK_INT < 16) {
				callbacks.failCallback(CommonUtils.createErrorJson(
						CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_NOT_SUPPORTED,
						CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_NOT_SUPPORTED));
				return;
			}
			if (CometChat.isLoggedIn()) {
				if (!TextUtils.isEmpty(userId)) {
					String tempName = SessionData.getInstance().getAvChatRoomName();
					if (TextUtils.isEmpty(tempName)) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND,
								CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND));
					} else {
						if (userId.equals(SessionData.getInstance().getActiveAVchatUserID())) {
							VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getAudioChatURL(),
									new VolleyAjaxCallbacks() {

										@Override
										public void successCallback(String response) {
											SessionData.getInstance().setAvChatRoomName("");
											SessionData.getInstance().setActiveAVchatUserID("0");
											try {
												JSONObject json = new JSONObject();
												json.put("id", userId);
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
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
							vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, tempName);
							vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.NO_ANSWER_ACTION);
							vHelper.sendAjax();
						} else {
							callbacks.failCallback(CommonUtils.createErrorJson(
									CometChatKeys.ErrorKeys.CODE_AUDIOCHAT_INCORRECT_USER,
									CometChatKeys.ErrorKeys.MESSAGE_AUDIOCHAT_INCORRECT_USER));
						}
					}
				} else {
					throw new IllegalArgumentException("toId cannot be NULL. toId cannot have 0 length.");
				}
			} else {
				callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_USER_NOT_LOGGEDIN,
						CometChatKeys.ErrorKeys.MESSAGE_NOT_LOGGEDIN));
			}
		}
	}

	public void toggleAudio(Boolean toggle) {
		if (VideoChat.isAudioChatDisabled()) {
			return;
		}
		if (app != null) {
			app.muteAudio(toggle);
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
				callbacks.successCallback(new JSONObject().put("audio_route", "ear speaker"));
			} else {
				audioManager.setSpeakerphoneOn(true);
				callbacks.successCallback(new JSONObject().put("audio_route", "main speaker"));
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
