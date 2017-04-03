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

package com.inscripts.heartbeats;

import java.util.Timer;
import java.util.TimerTask;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import android.annotation.SuppressLint;
import android.content.Context;

import com.inscripts.callbacks.SubscribeChatroomCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.cometchat.sdk.CometChatroom;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.ChatroomActionMessageTypeKeys;
import com.inscripts.keys.CometChatKeys.ChatroomKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

@SuppressLint("HandlerLeak")
public class HeartbeatChatroom {

	private Timer timer;
	private TimerTask timerTask;
	private static HeartbeatChatroom heartbeatChatroom;
	private boolean useComet, translateOn = false;
	private String cookiePrefix = "cc_";
	private static SubscribeChatroomCallbacks callbacklistener;

	public static HeartbeatChatroom getInstance(SubscribeChatroomCallbacks callback) {
		if (null == heartbeatChatroom) {
			heartbeatChatroom = new HeartbeatChatroom();
		}
		if (null != callback) {
			callbacklistener = callback;
		}
		return heartbeatChatroom;
	}

	public void startHeartbeat(final Context context) {
		final SessionData session = SessionData.getInstance();
		final Config config = JsonPhp.getInstance().getConfig();
		final long maxHeartbeat = Long.parseLong(config.getMaxHeartbeat()), minHeartbeat = Long.parseLong(config
				.getMinHeartbeat());
		useComet = config.getUSECOMET().equals("1");
		translateOn = JsonPhp.getInstance().getRealtimeTranslation() != null
				&& JsonPhp.getInstance().getRealtimeTranslation().equals("1");
		if (JsonPhp.getInstance().getCookieprefix() != null) {
			cookiePrefix = JsonPhp.getInstance().getCookieprefix();
		}
		timer = new Timer();

		final VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomHeartbeatUrl(), new VolleyAjaxCallbacks() {

			@Override
			public void successCallback(String response) {
				response = response.trim();
				//Logger.error("chatroom heartbeat = " + response);
				if (response.equals("[]")) {
					// Logger.info("No data returned from server for chatroom.php polling");
					if (!useComet) {
						session.setChatroomHeartbeatIdealCount(session.getChatroomHeartbeatIdealCount() + 1);
						if (session.getChatroomHeartbeatIdealCount() > 4) {
							session.setChatroomHeartbeatIdealCount(1);
							long newInterval = session.getChatroomHeartbeatInterval() * 2;
							if (newInterval > maxHeartbeat) {
								newInterval = maxHeartbeat;
							}
							if (newInterval != session.getChatroomHeartbeatInterval()) {
								session.setChatroomHeartbeatInterval(newInterval);
								changeChatroomHeartbeatInverval();
							}
						}
					}
				} else {
					try {
						JSONObject resultObject = new JSONObject(response);

						if (resultObject.has(CometChatKeys.ChatroomKeys.CHATROOM_LIST_HASH)
								&& resultObject.has(CometChatKeys.AjaxKeys.CHATROOM_LIST)) {

							if ("[]".equals(resultObject.get(AjaxKeys.CHATROOM_LIST).toString())
									|| "{}".equals(resultObject.get(AjaxKeys.CHATROOM_LIST).toString())) {
								callbacklistener.gotChatroomList(new JSONObject());
							} else {
								JSONObject chatroomList = resultObject.getJSONObject(AjaxKeys.CHATROOM_LIST);
								PreferenceHelper.save(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH,
										resultObject.getString(ChatroomKeys.CHATROOM_LIST_HASH));
								callbacklistener.gotChatroomList(chatroomList);
							}
							session.setChatroomListHash(resultObject.getString(ChatroomKeys.CHATROOM_LIST_HASH));
						}

						if (resultObject.has(AjaxKeys.MESSAGES)) {
							JSONArray messages = resultObject.getJSONArray(AjaxKeys.MESSAGES);
							if (messages.length() > 0) {
								int lastMessageId = (messages.getJSONObject(messages.length() - 1))
										.getInt(CometChatKeys.AjaxKeys.ID);
								session.setChatroomHeartBeatTimestamp(String.valueOf(lastMessageId));
								int length = messages.length(), i;
								for (i = 0; i < length; i++) {
									MessageHelper.getInstance().handleChatroomMessage(messages.getJSONObject(i),
											callbacklistener, true);
								}
							}
						}

						if (resultObject.has(CometChatKeys.ChatroomKeys.CHATROOM_MEMBERS_HASH)
								&& resultObject.has(CometChatKeys.ChatroomKeys.MEMBERS)) {

							String heartbeatUserListHash = resultObject
									.getString(CometChatKeys.ChatroomKeys.CHATROOM_MEMBERS_HASH);
							session.setChatroomMemberListHash(heartbeatUserListHash);
							PreferenceHelper.save(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH, heartbeatUserListHash);

							String chatromMembers = resultObject.getString(CometChatKeys.ChatroomKeys.MEMBERS);
							Object json = new JSONTokener(chatromMembers).nextValue();
							/*
							 * If members list is empty then it returns [] which
							 * is json array
							 */
							if (json instanceof JSONObject) {
								callbacklistener.gotChatroomMembers(new JSONObject(chatromMembers));
							}
						}

						if (resultObject.has(ChatroomKeys.ERROR)) {
							String errorValue = resultObject.getString(ChatroomKeys.ERROR);

							if (errorValue.equals(ChatroomKeys.ROOM_DOES_NOT_EXISTS)) {
								// Currently joined chatroom is deleted , leave it
								JSONObject json = new JSONObject();
								json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_DELETED);
								json.put("chatroom_id",
										PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));
								CometChatroom.getInstance(context).leaveChatroom(null);
								callbacklistener.onActionMessageReceived(json);
							}
						}

						if (!useComet) {
							session.setChatroomHeartbeatIdealCount(1);
							if (session.getChatroomHeartbeatInterval() > minHeartbeat) {
								session.setChatroomHeartbeatInterval(minHeartbeat);
								changeChatroomHeartbeatInverval();
							}
						}
					} catch (Exception e) {
						Logger.error("HeartbeatChatroom.java: Error at parsing json for " + e.getLocalizedMessage());
						e.printStackTrace();
					}
				}
			}

			@Override
			public void noInternetCallback() {
				if (!useComet) {
					session.setChatroomHeartbeatIdealCount(session.getChatroomHeartbeatIdealCount() + 1);
					if (session.getChatroomHeartbeatIdealCount() > 4) {
						session.setChatroomHeartbeatIdealCount(1);
						long newInterval = session.getChatroomHeartbeatInterval() * 2;
						if (newInterval > maxHeartbeat) {
							newInterval = maxHeartbeat;
						}
						if (newInterval != session.getChatroomHeartbeatInterval()) {
							session.setChatroomHeartbeatInterval(newInterval);
							changeChatroomHeartbeatInverval();
						}
					}
				}
			}

			@Override
			public void failCallback(String response) {
				Logger.error("HeartbeatChatroom.java: 404 of polling chatroom.php  ");
			}
		});

		timerTask = new TimerTask() {

			@Override
			public void run() {
				//vHelper.addNameValuePair(OneOnOneKeys.TYPING_TO, "0");
				//vHelper.addNameValuePair(ChatroomKeys.POPOUT, "0");
				vHelper.addNameValuePair(ChatroomKeys.CHATROOM_LIST_HASH,
						PreferenceHelper.get(PreferenceKeys.HashKeys.CHATROOM_LIST_HASH));
				vHelper.addNameValuePair(ChatroomKeys.CHATROOM_MEMBERS_HASH,
						PreferenceHelper.get(PreferenceKeys.HashKeys.CHATROOM_MEMBERS_HASH));
				vHelper.addNameValuePair(ChatroomKeys.CURRENT_P,
						PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD));
				vHelper.addNameValuePair(ChatroomKeys.CURRENT_ROOM,
						PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));
				vHelper.addNameValuePair(AjaxKeys.TIMESTAMP, session.getChatroomHeartBeatTimestamp());
				if (translateOn) {
					vHelper.addNameValuePair(cookiePrefix + "lang",
							PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE));
				} else {
					vHelper.addNameValuePair(cookiePrefix + "lang", "");
				}
				vHelper.sendAjax();
			}

		};
		timer.scheduleAtFixedRate(timerTask, 0, session.getChatroomHeartbeatInterval());

	}

	public void stopHeartbeatChatroom() {
		if (null != timerTask) {
			timerTask.cancel();
		}
		if (null != timer) {
			timer.cancel();
			timer.purge();
		}
	}

	public void changeChatroomHeartbeatInverval() {
		stopHeartbeatChatroom();
		startHeartbeat(PreferenceHelper.getContext());
	}
}
