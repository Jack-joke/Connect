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

import org.json.JSONObject;

import android.content.Context;
import android.media.AudioManager;
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
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.VideoChat;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import fm.SingleAction;
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
									public void noInternetCallback() {

									}

									@Override
									public void failCallback(String response) {
									}
								});
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userId);
						vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, tempName);
						vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.ACCEPTED);
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
										public void noInternetCallback() {

										}

										@Override
										public void failCallback(String response) {

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
								}, webasyncURL, String.valueOf(SessionData.getInstance().getId()),false,false);
								// Start the conference engine.
								// Logger.error("Final roomname: " + roomName);
								app.startConference(iceLinkServerAddress, roomName, false,
										relativeLayoutForRotationHandling, new SingleAction<Exception>() {
											@Override
											public void invoke(Exception ex) {
												if (ex != null) {
													Logger.error("Error at startconference " + ex.getLocalizedMessage());
												}
											}
										},false,false, callbacks);
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
										public void noInternetCallback() {

										}

										@Override
										public void failCallback(String response) {

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
									public void noInternetCallback() {

									}

									@Override
									public void failCallback(String response) {

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
									public void noInternetCallback() {

									}

									@Override
									public void failCallback(String response) {

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
										public void noInternetCallback() {

										}

										@Override
										public void failCallback(String response) {

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
										public void noInternetCallback() {

										}

										@Override
										public void failCallback(String response) {

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
