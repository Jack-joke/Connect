package com.inscripts.cometchat_sdkdemo;

import java.io.File;
import java.util.ArrayList;

import org.json.JSONException;
import org.json.JSONObject;

import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.provider.MediaStore.MediaColumns;
import android.support.v7.app.ActionBarActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.cometchat.sdk.AVChat;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.enums.Languages;
import com.inscripts.enums.StatusOption;
import com.inscripts.helper.DatabaseHandler;
import com.inscripts.helper.Keys;
import com.inscripts.helper.Keys.SharedPreferenceKeys;
import com.inscripts.helper.PushNotificationsManager;
import com.inscripts.helper.SharedPreferenceHelper;
import com.inscripts.helper.Utils;
import com.inscripts.pojo.SingleChatMessage;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

public class CometChatActivity extends ActionBarActivity {

	public static final ArrayList<String> logs = new ArrayList<String>();

	/* Modify the URL to point to the site you desire. */
	private static final String SITE_URL = "http://192.168.0.159/";

	/* Change this value to a valid user ID on the above site. */
	public static final String USER_ID = "6";

	private CometChat cometchat;
	public static String myId;
	private DatabaseHandler dbhelper;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_initial);

		/*
		 * Initializing the core CometChat instance. This is a singleton and
		 * hence can be called and used anywhere.
		 */
		cometchat = CometChat.getInstance(getApplicationContext(),
				SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY));

		DatabaseHandler handler = new DatabaseHandler(this);
		/*
		 * This function will set/reset the development mode so that you can
		 * view the logs for the request and response You will get
		 * 
		 * "CC_SDK_LOG:URL" logs which will specifiy the url for which a request
		 * is sent You wukk get
		 * 
		 * "CC_SDK_LOG:RESPONSE" logs which will specify the response of request
		 * sent
		 */
		CometChat.setDevelopmentMode(false);
		dbhelper = new DatabaseHandler(this);

		final SubscribeCallbacks subCallbacks = new SubscribeCallbacks() {

			@Override
			public void onMessageReceived(JSONObject receivedMessage) {
				LogsActivity.addToLog("One-On-One onMessageReceived");
				// Logger.error("msg " + receivedMessage);
				try {
					String messagetype = receivedMessage.getString("message_type");
					Intent intent = new Intent();
					intent.setAction("NEW_SINGLE_MESSAGE");
					boolean imageMessage = false, videomessage = false, ismyMessage = false;
					if (messagetype.equals("12")) {
						intent.putExtra("imageMessage", "1");
						imageMessage = true;
						if (receivedMessage.getString("self").equals("1")) {
							intent.putExtra("myphoto", "1");
							ismyMessage = true;
						}
					} else if (messagetype.equals("14")) {
						intent.putExtra("videoMessage", "1");
						videomessage = true;
						if (receivedMessage.getString("self").equals("1")) {
							intent.putExtra("myVideo", "1");
							ismyMessage = true;
						}
					}
					intent.putExtra("message_type", messagetype);
					intent.putExtra("user_id", receivedMessage.getInt("from"));
					intent.putExtra("message", receivedMessage.getString("message").trim());
					intent.putExtra("time", receivedMessage.getString("sent"));
					intent.putExtra("message_id", receivedMessage.getString("id"));
					intent.putExtra("from", receivedMessage.getString("from"));
					String to = null;
					if (receivedMessage.has("to")) {
						to = receivedMessage.getString("to");
					} else {
						to = SharedPreferenceHelper.get(SharedPreferenceKeys.myId);
					}
					intent.putExtra("to", to);
					String time = Utils.convertTimestampToDate(Utils.correctTimestamp(Long.parseLong(receivedMessage
							.getString("sent"))));
					SingleChatMessage newMessage = new SingleChatMessage(receivedMessage.getString("id"),
							receivedMessage.getString("message").trim(), time, ismyMessage,
							receivedMessage.getString("from"), to, messagetype, 0);
					dbhelper.insertOneOnOneMessage(newMessage);
					sendBroadcast(intent);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

			@Override
			public void onError(JSONObject errorResponse) {
				LogsActivity.addToLog("One-On-One onError");
				Logger.debug("Some error: " + errorResponse);
			}

			@Override
			public void gotProfileInfo(JSONObject profileInfo) {
				LogsActivity.addToLog("One-On-One gotProfileInfo");
				Logger.error("profile infor " + profileInfo);
				cometchat.getPluginInfo(new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						Log.d("abc", "PLugin infor =" + response);
					}

					@Override
					public void failCallback(JSONObject response) {

					}
				});
				JSONObject j = profileInfo;
				try {
					myId = j.getString("id");
					SharedPreferenceHelper.save(SharedPreferenceKeys.myId, myId);
					if (j.has("push_channel")) {
						PushNotificationsManager.subscribe(j.getString("push_channel"));
					}
				} catch (JSONException e) {
					e.printStackTrace();
				}

				/*
				 * cometchat.getOnlineUsers(new Callbacks() {
				 * 
				 * @Override public void successCallback(JSONObject response) {
				 * Logger.debug("online users =" + response.toString());
				 * 
				 * }
				 * 
				 * @Override public void failCallback(JSONObject response) {
				 * 
				 * } });
				 */
			}

			@Override
			public void gotOnlineList(JSONObject onlineUsers) {
				try {
					LogsActivity.addToLog("One-On-One gotOnlineList");
					/* Store the list for later use. */
					SharedPreferenceHelper.save(SharedPreferenceKeys.USERS_LIST, onlineUsers.toString());
					UsersListActivity.populateList();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}

			@Override
			public void onAVChatMessageReceived(JSONObject response) {
				try {
					int pluginType = response.getInt("pluginType");
					// Logger.error("onavchat message " + response);
					if (pluginType == 2) {
						switch (response.getInt("message_type")) {
						case 41:
							Intent intent = new Intent();
							intent.setAction("NEW_SINGLE_MESSAGE");
							intent.putExtra("user_id", response.getInt("from"));
							intent.putExtra("message",
									response.getString("message").trim() + "|#|" + response.getString("callid"));
							intent.putExtra("time", response.getString("sent"));
							intent.putExtra("message_id", response.getString("id"));
							intent.putExtra("message_type", response.getString("message_type"));
							sendBroadcast(intent);
							break;
						case 42:
							// AVbroadcast ended
							AVChatActivity.avChatActivity.endCall();
							break;
						case 43:
							Intent intent1 = new Intent();
							intent1.setAction("NEW_SINGLE_MESSAGE");
							intent1.putExtra("user_id", response.getInt("from"));
							intent1.putExtra("message", response.getString("message").trim());
							intent1.putExtra("time", response.getString("sent"));
							intent1.putExtra("message_id", response.getString("id"));
							intent1.putExtra("message_type", response.getString("message_type"));
							sendBroadcast(intent1);
							break;
						}

					} else {
						switch (response.getInt("message_type")) {
						case 31:
							try {
								Intent intent = new Intent(getApplicationContext(), AVChatActivity.class);
								intent.putExtra("user_id", response.getString("from"));
								if (response.has("callid")) {
									SharedPreferenceHelper.save(SharedPreferenceKeys.CALLID,
											response.getString("callid"));
								}
								intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
								intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
								intent.putExtra("pluginType", pluginType);
								startActivity(intent);
							} catch (Exception e) {
								e.printStackTrace();
							}
							break;
						case 32:
							try {
								Intent i = new Intent(getApplicationContext(), IncomingCallActivity.class);
								SharedPreferenceHelper.save(SharedPreferenceKeys.CALLID, response.getString("callid"));
								i.putExtra("user_id", response.getLong("from"));
								i.putExtra("pluginType", pluginType);
								startActivity(i);
							} catch (Exception e) {
								e.printStackTrace();
							}
							break;
						case 33:
							Logger.debug("response for case 3 " + response);
							try {
								Logger.debug("from = " + response.getString("from"));
								AVChat.getAVChatInstance(getApplicationContext()).sendBusyTone(
										response.getString("from"), new Callbacks() {

											@Override
											public void successCallback(JSONObject response) {
												Logger.debug("send busy tone success " + response);
											}

											@Override
											public void failCallback(JSONObject response) {
												Logger.debug("send busy tone fail " + response);
											}
										});
							} catch (Exception e) {
								e.printStackTrace();
							}
							break;
						case 34:
							Logger.debug("response for case 4 " + response);
							if (response.getLong("from") != SessionData.getInstance().getId()) {
								AVChatActivity.avChatActivity.endCall();
							}
							break;
						case 35:
							Logger.debug("response for case 5 " + response);
							AVChatActivity.avChatActivity.finish();
							break;
						case 36:
							Logger.debug("response for case 6 " + response);
							// OutgoiningCallActivity.outgoiningCallActivity.finish();
							IncomingCallActivity.incomingCallActivity.finish();
							break;
						case 37:
							Logger.debug("response for case 7 " + response);
							break;
						case 38:
							Logger.debug("response for case 8 " + response);
							break;
						default:
							break;
						}
					}
				} catch (JSONException e) {
					e.printStackTrace();
				}
			}

			@Override
			public void gotAnnouncement(JSONObject announcement) {

			}

			@Override
			public void onActionMessageReceived(JSONObject response) {
				try {
					String action = response.getString("action");
					Intent i = new Intent("NEW_SINGLE_MESSAGE");
					if (action.equals("typing_start")) {
						i.putExtra("action", "typing_start");
					} else if (action.equals("typing_stop")) {
						i.putExtra("action", "typing_stop");
					} else if (action.equals("message_read")) {
						i.putExtra("action", "message_read");
						i.putExtra("from", response.getString("from"));
						i.putExtra("message_id", response.getString("message_id"));
						Utils.msgtoTickList.put(response.getString("message_id"), Keys.MessageTicks.read);
					} else if (action.equals("message_deliverd")) {
						i.putExtra("action", "message_deliverd");
						i.putExtra("from", response.getString("from"));
						i.putExtra("message_id", response.getString("message_id"));
						Utils.msgtoTickList.put(response.getString("message_id"), Keys.MessageTicks.deliverd);
					}
					sendBroadcast(i);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		};

		/*cometchat.isCometChatInstalled(SITE_URL, new Callbacks() {

			@Override
			public void successCallback(JSONObject response) {
				try {
					Logger.debug("in success " + response.getString("cometchat_url"));
				} catch (Exception e) {
				}
			}

			@Override
			public void failCallback(JSONObject response) {
				Logger.debug("in fail " + response);
			}
		});*/

		if (CometChat.isLoggedIn()) {
			cometchat.subscribe(true, subCallbacks);
		}
	}

	public void buttonClick(View view) {
		switch (view.getId()) {
		case R.id.buttonOpenOneOnOne:
			startActivity(new Intent(this, UsersListActivity.class));
			break;
		case R.id.buttonOpenChatrooms:
			startActivity(new Intent(this, ChatroomListActivity.class));
			break;
		case R.id.buttonOpenLogs:
			startActivity(new Intent(this, LogsActivity.class));
			break;
		case R.id.buttonLogout:
			cometchat.logout(new Callbacks() {

				@Override
				public void successCallback(JSONObject response) {
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.IS_LOGGEDIN);
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.USER_NAME);
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.PASSWORD);
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.LOGIN_TYPE);
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.USERS_LIST);
					SharedPreferenceHelper.removeKey(SharedPreferenceKeys.CHATROOMS_LIST);
					// SharedPreferenceHelper.removeKey(SharedPreferenceKeys.API_KEY);
					startActivity(new Intent(CometChatActivity.this, UrlScreenActivity.class));
					finish();
				}

				@Override
				public void failCallback(JSONObject response) {
					Logger.debug("logout failed");
				}
			});

			break;
		default:
			break;
		}
	}

	private void sendRandomVideo() {
		try {
			String[] projection = new String[] { MediaColumns.DATA, };

			Uri videos = MediaStore.Video.Media.EXTERNAL_CONTENT_URI;
			Cursor cur = managedQuery(videos, projection, "", null, "");

			final ArrayList<String> imagesPath = new ArrayList<String>();
			if (cur.moveToFirst()) {
				int dataColumn = cur.getColumnIndex(MediaColumns.DATA);
				do {
					imagesPath.add(cur.getString(dataColumn));
				} while (cur.moveToNext());
			}

			cometchat.sendVideo(new File(imagesPath.get(2)), "110", new Callbacks() {

				@Override
				public void successCallback(JSONObject response) {
					Logger.debug("Success: " + response);
				}

				@Override
				public void failCallback(JSONObject response) {
					Logger.debug("Fail: " + response);
				}
			});
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.cometchat, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int id = item.getItemId();
		if (id == R.id.action_set_status) {
			cometchat.setStatus(StatusOption.BUSY, new Callbacks() {

				@Override
				public void successCallback(JSONObject response) {
					Log.e("abc", "Success set status=" + response);
				}

				@Override
				public void failCallback(JSONObject response) {
					Log.e("abc", "fail set status=" + response);
				}
			});

		} else if (id == R.id.action_set_status_message) {
			cometchat.setStatusMessage("Wonderful day!", new Callbacks() {

				@Override
				public void successCallback(JSONObject response) {
					Log.e("abc", "Success set status message=" + response);
				}

				@Override
				public void failCallback(JSONObject response) {
					Log.e("abc", "fail set status message=" + response);
				}
			});

		} else if (id == R.id.action_translate_messages) {
			cometchat.setTranslateLanguage(Languages.Spanish, new Callbacks() {

				@Override
				public void successCallback(JSONObject response) {
					Logger.debug("translate response success = " + response);
				}

				@Override
				public void failCallback(JSONObject response) {
					Logger.debug("translate response fail = " + response);
				}
			});
		}

		return super.onOptionsItemSelected(item);
	}
}
