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

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import org.json.JSONObject;
import org.json.JSONTokener;

import android.annotation.SuppressLint;
import android.content.Context;
import android.text.TextUtils;

import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.StatusKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;

@SuppressLint("HandlerLeak")
public class HeartbeatOneOnOne {

	private static HeartbeatOneOnOne heartbeatOneOnOne;
	private boolean useComet, translateOn = false;
	private int announcementId = 0;
	private String cookiePrefix = "cc_";
	private static Timer timer;
	private TimerTask timerTask;
	private static SubscribeCallbacks callbacklistener;

	public static HeartbeatOneOnOne getInstance(SubscribeCallbacks listener) {
		if (null == heartbeatOneOnOne) {
			heartbeatOneOnOne = new HeartbeatOneOnOne();
		}
		if (null != listener) {
			callbacklistener = listener;
		}
		return heartbeatOneOnOne;
	}

	public void startHeartbeat(final Context context) {
		final SessionData session = SessionData.getInstance();
		final Config config = JsonPhp.getInstance().getConfig();
		final long minHeartbeat = Long.parseLong(config.getMinHeartbeat()), maxHeartbeat = Long.parseLong(config
				.getMaxHeartbeat());
		useComet = config.getUSECOMET().equals("1");
		translateOn = JsonPhp.getInstance().getRealtimeTranslation() != null
				&& JsonPhp.getInstance().getRealtimeTranslation().equals("1");

		if (session.isInitialHeartbeat()) {
			session.setInitialHeartbeat(false);
			session.setUserInfoHeartBeatFlag("1");
			session.setOneOnOneHeartBeatTimestamp(0L);
		}

		if (JsonPhp.getInstance().getCookieprefix() != null) {
			cookiePrefix = JsonPhp.getInstance().getCookieprefix();
		}

		timer = new Timer();

		final VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getRecieveURL(), new VolleyAjaxCallbacks() {

			@Override
			public void successCallback(String response) {

				response = response.trim();
				if (response.equals("[]")) {
					// Logger.info("No data returned from server for receive.php polling");
					if (!useComet) {
						session.setOneOnOneHeartBeatIdealCount(session.getOneOnOneHeartBeatIdealCount() + 1);
						if (session.getOneOnOneHeartBeatIdealCount() > 4) {
							session.setOneOnOneHeartBeatIdealCount(1);
							long newInterval = session.getOneOnOneHeartbeatInterval() * 2;
							if (newInterval > maxHeartbeat) {
								newInterval = maxHeartbeat;
							}
							if (newInterval != session.getOneOnOneHeartbeatInterval()) {
								session.setOneOnOneHeartbeatInterval(newInterval);
								changeOneOnOneHeartbeatInverval();
							}
						}
					}
				} else if (response.contains("{\"loggedout\":")) {
					CommonUtils.sendCallBackError(CometChatKeys.ErrorKeys.CODE_LOGGEDOUT_HEARTBEAT,
							CometChatKeys.ErrorKeys.MESSAGE_LOGGEDOUT_HEARTBEAT, callbacklistener);
				} else {
					// Logger.error("Received message in one on one" +
					// response);
					try {
						JSONObject resultObject = new JSONObject(response);
						if (resultObject.has(CometChatKeys.AjaxKeys.COMETID)) {
							JSONObject cometIdDetails = resultObject.getJSONObject(CometChatKeys.AjaxKeys.COMETID);
							session.setCometID(cometIdDetails.getString(CometChatKeys.AjaxKeys.ID));
							/* Subscribe to the channel which is our cometid */
							String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
							if (!TextUtils.isEmpty(transport)) {
								if (transport.equals("cometservice")) {
									CometserviceOneOnOne.getInstance().startCometService(session.getCometID(),
											callbacklistener);
								} else if (transport.equals("cometservice-selfhosted")) {
									WebsyncOneOnOne.getInstance().connect(JsonPhp.getInstance().getWebsyncServer(),
											session.getCometID(), callbacklistener);
								}
							}
						}

						if (resultObject.has(CometChatKeys.AjaxKeys.BUDDY_LIST_HASH)
								&& resultObject.has(AjaxKeys.BUDDY_LIST)) {

							String buddyListTemp = resultObject.getString(AjaxKeys.BUDDY_LIST);
							Object json = new JSONTokener(buddyListTemp).nextValue();
							PreferenceHelper.save(PreferenceKeys.HashKeys.BUDDY_LIST_HASH,
									resultObject.getString(CometChatKeys.AjaxKeys.BUDDY_LIST_HASH));

							if (json instanceof JSONObject) {
								/* Send buddylist callback */
								callbacklistener.gotOnlineList(resultObject.getJSONObject(AjaxKeys.BUDDY_LIST));
								if (useComet) {
									JSONObject blist = new JSONObject(buddyListTemp);
									if (blist.length() > 0) {
										CommonUtils.usertoChannelMap.clear();
										Iterator<String> keys = blist.keys();
										while (keys.hasNext()) {
											JSONObject buddy = blist.getJSONObject(keys.next());
											if (buddy.has(JsonParsingKeys.CSCHANNEL)) {
												CommonUtils.usertoChannelMap.put(buddy.getString(JsonParsingKeys.ID),
														buddy.getString(JsonParsingKeys.CSCHANNEL));
											}
										}
									}
									blist = null;
								}
							}
						}

						if (resultObject.has(AjaxKeys.MESSAGES)) {
							JSONObject messages = resultObject.getJSONObject(AjaxKeys.MESSAGES);
							if (messages.length() > 0) {
								/* New Messages have arrived */

								Iterator<String> iterator = messages.keys();
								List<String> sortedKeys = new ArrayList<String>();
								while (iterator.hasNext()) {
									sortedKeys.add(iterator.next());
								}
								Collections.sort(sortedKeys);
								for (String messageId : sortedKeys) {
									JSONObject message = messages.getJSONObject(messageId);
									session.setOneOnOneHeartBeatTimestamp(message.getLong(CometChatKeys.AjaxKeys.ID));
									MessageHelper.getInstance().handleOneOnOneMessage(message, callbacklistener, true);
								}
								sortedKeys.clear();
							}
						}

						if (resultObject.has(CometChatKeys.AjaxKeys.INITIALIZE)) {
							session.setOneOnOneHeartBeatTimestamp(resultObject
									.getLong(CometChatKeys.AjaxKeys.INITIALIZE));
						}

						if (resultObject.has(CometChatKeys.AjaxKeys.USER_STATUS)) {
							session.setUserInfoHeartBeatFlag("0");
							JSONObject userStatus = resultObject.getJSONObject(CometChatKeys.AjaxKeys.USER_STATUS);

							if (userStatus.has("webrtc_prefix")) {
								PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_PREFIX,
										userStatus.getString("webrtc_prefix"));
							} else if (userStatus.has("webrtc_channel")) {
								PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_PREFIX,
										userStatus.getString("webrtc_channel"));
							} else {
								PreferenceHelper.save(PreferenceKeys.UserKeys.WEBRTC_PREFIX, "");
							}

							session.update(userStatus);
							userStatus.remove("ccmobileauth");
							userStatus.remove("webrtc_prefix");
							callbacklistener.gotProfileInfo(userStatus);
						}

						if (resultObject.has(CometChatKeys.AjaxKeys.ANNOUNCEMENT)) {
							JSONObject announcementDetails = resultObject.getJSONObject(AjaxKeys.ANNOUNCEMENT);
							announcementId = announcementDetails.getInt(AjaxKeys.ID);
							callbacklistener.gotAnnouncement(announcementDetails);
							announcementDetails = null;
						}
						if (!useComet) {
							session.setOneOnOneHeartBeatIdealCount(1);
							if (session.getOneOnOneHeartbeatInterval() > minHeartbeat) {
								session.setOneOnOneHeartbeatInterval(minHeartbeat);
								changeOneOnOneHeartbeatInverval();
							}
						}
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			}

			@Override
			public void noInternetCallback() {
				if (!useComet) {
					session.setOneOnOneHeartBeatIdealCount(session.getOneOnOneHeartBeatIdealCount() + 1);
					if (session.getOneOnOneHeartBeatIdealCount() > 4) {
						session.setOneOnOneHeartBeatIdealCount(1);
						long newInterval = session.getOneOnOneHeartbeatInterval() * 2;
						if (newInterval > maxHeartbeat) {
							newInterval = maxHeartbeat;
						}
						if (newInterval != session.getOneOnOneHeartbeatInterval()) {
							session.setOneOnOneHeartbeatInterval(newInterval);
							changeOneOnOneHeartbeatInverval();
						}
					}
				}
			}

			@Override
			public void failCallback(String response) {
			}
		});

		timerTask = new TimerTask() {

			@Override
			public void run() {
				// vHelper.addNameValuePair(OneOnOneKeys.TYPING_TO, "0");
				vHelper.addNameValuePair(StatusKeys.STATUS, PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS));
				vHelper.addNameValuePair(AjaxKeys.BUDDY_LIST, "1");
				// vHelper.addNameValuePair(OneOnOneKeys.CURRENT_TIME, "0");
				vHelper.addNameValuePair(AjaxKeys.BUDDY_LIST_HASH,
						PreferenceHelper.get(PreferenceKeys.HashKeys.BUDDY_LIST_HASH));
				vHelper.addNameValuePair(AjaxKeys.INITIALIZE, session.getUserInfoHeartBeatFlag());

				if (useComet) {
					vHelper.addNameValuePair(AjaxKeys.TIMESTAMP, "0");
				} else {
					vHelper.addNameValuePair(AjaxKeys.TIMESTAMP,
							String.valueOf(session.getOneOnOneHeartBeatTimestamp()));
				}
				vHelper.addNameValuePair(cookiePrefix + AjaxKeys.ANNOUNCEMENT, String.valueOf(announcementId));
				if (translateOn) {
					vHelper.addNameValuePair(cookiePrefix + "lang",
							PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE));
				} else {
					vHelper.addNameValuePair(cookiePrefix + "lang", "");
				}
				vHelper.sendAjax();
			}

		};

		timer.scheduleAtFixedRate(timerTask, 0, session.getOneOnOneHeartbeatInterval());
	}

	public void stopHeartbeatOneOnOne() {
		if (null != timerTask) {
			timerTask.cancel();
		}
		if (null != timer) {
			timer.cancel();
			timer.purge();
		}
	}

	public void changeOneOnOneHeartbeatInverval() {
		stopHeartbeatOneOnOne();
		startHeartbeat(PreferenceHelper.getContext());
	}
}