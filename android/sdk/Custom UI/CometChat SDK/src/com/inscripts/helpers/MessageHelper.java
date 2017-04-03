package com.inscripts.helpers;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import android.annotation.SuppressLint;
import android.text.TextUtils;

import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.callbacks.SubscribeChatroomCallbacks;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.cometchat.sdk.CometChatroom;
import com.inscripts.factories.URLFactory;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.AvchatMessageTypeKeys;
import com.inscripts.keys.CometChatKeys.ChatroomActionMessageTypeKeys;
import com.inscripts.keys.CometChatKeys.MessageTypeKeys;
import com.inscripts.plugins.AVBroadcastplugin;
import com.inscripts.plugins.Chatroom;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoChat;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

public class MessageHelper {

	private static MessageHelper messagerHelper;
	private SubscribeChatroomCallbacks chatroomCallback;
	private static String textColor;
	private static Config config;

	public static MessageHelper getInstance() {
		config = JsonPhp.getInstance().getConfig();
		if (messagerHelper == null) {
			messagerHelper = new MessageHelper();
		}
		return messagerHelper;
	}

	private static void sendKickUserConfirmation(String messageId) {
		VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getKickUserURL());
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
				.getCurrentChatroom());

		/* On receiver side value of kickid = kicked */
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICKID, CometChatKeys.ChatroomKeys.KICKED);
		/* kick parameter holds timestamp */
		vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICK, messageId);
		vHelper.sendCallBack(false);
		vHelper.sendAjax();
	}

	private static void sendBanUserConfirmation(String messageId) {
		VolleyHelper vhelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getBanUserURL());
		vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
				.getCurrentChatroom());
		vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_ID, CometChatKeys.ChatroomKeys.BANNED);
		vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN, messageId);
		vhelper.sendCallBack(false);
		vhelper.sendAjax();
	}

	private static String getColoredText(String message, boolean isMyMessage) {
		try {
			if (isMyMessage) {
				textColor = StaticMembers.MY_DEFAULT_TEXT_COLOR;
			} else {
				textColor = StaticMembers.DEFAULT_TEXT_COLOR;
			}
			Document doc = Jsoup.parseBodyFragment(message);
			Elements spantags = doc.select(StaticMembers.SPAN_TAG);
			for (Element span : spantags) {
				String[] color = span.attr(StaticMembers.STYLE_ATTR).split(":");
				textColor = color[1];
				message = message.replace(span.outerHtml(), span.html().replace(" />", ""));
			}
			return message;
		} catch (Exception e) {
			e.printStackTrace();
		}
		return message;
	}

	private static String handleLink(String message) {
		Document doc = Jsoup.parseBodyFragment(message);
		Elements anchorTag = doc.select(StaticMembers.ANCHOR_TAG);
		for (Element link : anchorTag) {
			String temp = anchorTag.attr(StaticMembers.HREF);
			if (!TextUtils.isEmpty(temp)) {
				message = message.replace(link.toString(), temp);
			}
		}
		return message;
	}

	/**
	 * Handles unwanted &lt;br&gt; &amplt; &ampgt; HTML characters
	 * 
	 * @param message
	 *            Incoming message
	 * @return Sanitized message
	 */
	private static String handleSpecialHtmlCharacters(String message) {
		return message.replaceAll("<br/>([^.]*?)", "\n").replaceAll("<br>([^.]*?)", "\n")
				.replaceAll("&lt;([^.]*?)", "<").replaceAll("&gt;([^.]*?)", ">").replaceAll("&amp;([^.]*?)", "&")
				.replace("&nbsp;([^.]*?)", " ");
	}

	/**
	 * @param message
	 *            : Pass single received message JSONObject
	 * @param fromHeartBeat
	 *            : Pass <i>true</i> for messages to be processed normally. Pass
	 *            <i>false</i> for messages to be processed for history call.
	 */
	@SuppressLint("DefaultLocale")
	public JSONObject handleOneOnOneMessage(JSONObject message, SubscribeCallbacks callbacks, boolean fromHeartBeat) {
		int messageProcessed = 1;
		try {
			SessionData session = SessionData.getInstance();
			if (message.has(AjaxKeys.MESSAGE)) {
				String mess = message.getString(AjaxKeys.MESSAGE);
				if (mess.contains("jqcc.cc")) {
					if (VideoChat.isAVChatRequest(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVchatKeys.INCOMING_AVCALL_MESSAGE);
							String roomName = VideoChat.getAVRoomName(mess, false);
							if (session.isAvchatCallRunning()) {
								message.put(CometChatKeys.AjaxKeys.MESSAGE,
										CometChatKeys.AVchatKeys.INCOMING_AVCALL_WHILE_USER_BUSY_MESSAGE);
								message.put(
										CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
										CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE);
							} else {
								session.setAvChatRoomName(roomName);
								session.setActiveAVchatUserID(message.getString(CometChatKeys.AjaxKeys.FROM));
							}
							message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
							message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAVChatAccepted(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							if (session.isAvchatCallRunning()) {
								VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
										URLFactory.getAVChatURL());
								vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO,
										message.getString(CometChatKeys.AjaxKeys.FROM));
								vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
								vHelper.sendAjax();
								messageProcessed = 0;
							} else {
								String roomName = VideoChat.getAVRoomName(mess, false);
								session.setAvChatRoomName(roomName);
								message.put(CometChatKeys.AjaxKeys.MESSAGE,
										CometChatKeys.AVchatKeys.AVCALL_ACCECPTED_MESSAGE);
								message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
										CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED);
								message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
								message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
										CometChatKeys.MessageTypeKeys.AVCALL);
								messageProcessed = 2;
							}
						}
						// } else if (VideoChat.isAVChatSentSuccessful(mess)) {
						// messageProcessed = 0;
						// } else if (VideoChat.isAudioChatSentSuccessful(mess))
						// {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isGameAccept(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isGameRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isWriteBoardRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isScreehShareRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
						// messageProcessed = 0;
					} else if (VideoChat.isAudioChatRequest(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVchatKeys.INCOMING_AUDIOCALL_MESSAGE);
							String roomName = VideoChat.getAVRoomName(mess, true);
							if (session.isAvchatCallRunning()) {
								message.put(CometChatKeys.AjaxKeys.MESSAGE,
										CometChatKeys.AVchatKeys.INCOMING_AUDIOCALL_WHILE_USER_BUSY_MESSAGE);
								message.put(
										CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
										CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE);
							} else {
								session.setAvChatRoomName(roomName);
								session.setActiveAVchatUserID(message.getString(CometChatKeys.AjaxKeys.FROM));
							}
							message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
							message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AUDIO_CALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAudioChatAccepted(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {
							if (session.isAvchatCallRunning()) {
								VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
										URLFactory.getAudioChatURL());
								vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO,
										message.getString(CometChatKeys.AjaxKeys.FROM));
								vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, StaticMembers.BUSY_CALL_ACTION);
								vHelper.sendAjax();
								messageProcessed = 0;
							} else {
								String roomName = VideoChat.getAVRoomName(mess, true);
								session.setAvChatRoomName(roomName);
								message.put(CometChatKeys.AjaxKeys.MESSAGE,
										CometChatKeys.AVchatKeys.AUDIOCALL_ACCECPTED_MESSAGE);
								message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
										CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED);
								message.put(CometChatKeys.AjaxKeys.CALLID, roomName);
								message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
										CometChatKeys.MessageTypeKeys.AUDIO_CALL);
								messageProcessed = 2;
							}
						}
					} else if (AVBroadcastplugin.isAVBroadcast(mess)) {
						if (AVBroadcastplugin.isEnabled()) {
							message.put(CometChatKeys.AjaxKeys.CALLID, AVBroadcastplugin.getGroupName(mess, false));
							message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_INCOMING_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AVBROADCAST);
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVBroadcastKeys.INCOMING_AVBROADCAST_MESSAGE);
							messageProcessed = 2;
						} else {
							messageProcessed = 0;
						}
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("CC^CONTROL_")) {
					if (VideoChat.isAVChatCallRejected(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.AVCALL_REJECTED_MESSAGE);
						message.put(MessageTypeKeys.MESSAGE_TYPE, AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_REJECT_CALL);
						message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
						messageProcessed = 2;
					} else if (VideoChat.isAVChatCallEnded(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							if (session.isAvchatCallRunning()) {
								SessionData.getInstance().setAvchatCallRunning(false);
							}
							message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.END_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_END_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAVChatCallNoAnswer(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVchatKeys.NOANSWER_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_NO_ANSWER);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAVChatCancelCall(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.CANCEL_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CANCEL_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAVChatBusyCall(mess)) {
						if (VideoChat.isDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.BUSY_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_BUSY_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AVCALL);
							messageProcessed = 2;
						}
					} else if (OtherPlugins.isAVBroadcastEnd(mess)) {
						if (AVBroadcastplugin.isEnabled()) {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVBroadcastKeys.END_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_END_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AVBROADCAST);
							messageProcessed = 2;
						} else {
							messageProcessed = 0;
						}
					} else if (VideoChat.isAudioChatCallRejected(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.AUDIOCALL_REJECTED_MESSAGE);
						message.put(MessageTypeKeys.MESSAGE_TYPE, AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_REJECT_CALL);
						message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE, CometChatKeys.MessageTypeKeys.AUDIO_CALL);
						messageProcessed = 2;
					} else if (VideoChat.isAudioChatCallEnded(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {

							if (session.isAvchatCallRunning()) {
								SessionData.getInstance().setAvchatCallRunning(false);
							}
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVBroadcastKeys.END_AVCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_END_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AUDIO_CALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAudioChatCallNoAnswer(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVchatKeys.NOANSWER_AUDIOCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_NO_ANSWER);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AUDIO_CALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAudioChatCancelCall(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE,
									CometChatKeys.AVchatKeys.CANCEL_AUDIOCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_CANCEL_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AUDIO_CALL);
							messageProcessed = 2;
						}
					} else if (VideoChat.isAudioChatBusyCall(mess)) {
						if (VideoChat.isAudioChatDisabled()) {
							messageProcessed = 0;
						} else {
							message.put(CometChatKeys.AjaxKeys.MESSAGE, CometChatKeys.AVchatKeys.BUSY_AUDIOCALL_MESSAGE);
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_BUSY_CALL);
							message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
									CometChatKeys.MessageTypeKeys.AUDIO_CALL);
							messageProcessed = 2;
						}
					} else if (OtherPlugins.isTypingStart(mess)) {
						try {
							JSONObject responsetobeSent = new JSONObject();
							responsetobeSent.put("action", "typing_start");
							responsetobeSent.put("from", message.getString("from"));
							responsetobeSent.put("sent", message.getString("sent"));
							callbacks.onActionMessageReceived(responsetobeSent);
							messageProcessed = 0;
						} catch (Exception e) {
							e.printStackTrace();
						}

						messageProcessed = 0;
					} else if (OtherPlugins.isTypingStop(mess)) {
						JSONObject responsetobeSent = new JSONObject();
						responsetobeSent.put("action", "typing_stop");
						responsetobeSent.put("from", message.getString("from"));
						responsetobeSent.put("sent", message.getString("sent"));
						callbacks.onActionMessageReceived(responsetobeSent);
						messageProcessed = 0;
					} else if (OtherPlugins.isMessageDelivery(mess)) {
						JSONObject responsetobeSent = new JSONObject();
						String msgDetails[] = OtherPlugins.getTickMessageDetail(mess).split("#");
						responsetobeSent.put("action", "message_deliverd");
						responsetobeSent.put("message_id", msgDetails[0]);
						responsetobeSent.put("from", msgDetails[1]);
						callbacks.onActionMessageReceived(responsetobeSent);
						messageProcessed = 0;
					} else if (OtherPlugins.isMessageRead(mess) || OtherPlugins.isMessageReadDelivered(mess)) {
						JSONObject responsetobeSent = new JSONObject();
						String msgDetails[] = OtherPlugins.getTickMessageDetail(mess).split("#");
						responsetobeSent.put("action", "message_read");
						responsetobeSent.put("message_id", msgDetails[0]);
						responsetobeSent.put("from", msgDetails[1]);
						callbacks.onActionMessageReceived(responsetobeSent);
						messageProcessed = 0;
					} else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, Stickers.getSticker(mess));
						message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.STICKER);
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("plugins/filetransfer")) {
					if (ImageSharing.isIncomingImage(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.IMAGE);
					} else if (VideoSharing.isIncomingVideo(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, VideoSharing.getVideoURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.VIDEO);
					} else if (ImageSharing.isIncomingAudio(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO);
					} else if (ImageSharing.isFileTransfer(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.FILE);
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("jqcc.cometchat")) {
					if (Chatroom.isJoinChatroomMessage(mess)) {
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.JOIN_CHATROOM_MESSAGE);
						message.put(CometChatKeys.AjaxKeys.MESSAGE, Chatroom.processJoinRequest(mess));
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("/plugins/handwrite/")) {
					message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getHandwriteImageUrl(mess));
					message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITTEN_MESSAGE);
				} else {
					if (AVBroadcastplugin.isAVBroadcastInvite(mess)) {
						message.put(CometChatKeys.AjaxKeys.CALLID, AVBroadcastplugin.getInviteGroupName(mess));
						message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE,
								CometChatKeys.AvBroadcastMessageTypeKeys.AVBROADCAST_MESSAGE_TYPE_INVITE);
						message.put(CometChatKeys.MessageTypeKeys.PLUGIN_TYPE,
								CometChatKeys.MessageTypeKeys.AVBROADCAST);
						message.put(CometChatKeys.AjaxKeys.MESSAGE,
								CometChatKeys.AVBroadcastKeys.AVBROADCAST_INVITE_MESSAGE);
						messageProcessed = 2;
					} else {

						if (CometChat.useHTML) {
							mess = Smilies.convertImageTagToEmoji(handleSpecialHtmlCharacters(handleLink(mess)));
							if (TextUtils.isEmpty(mess)) {
								messageProcessed = 0;
							}
						} else {
							mess = handleSpecialHtmlCharacters(handleLink(mess));
						}
						message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
					}
				}
			} else {
				messageProcessed = 0;
			}

			/*
			 * Fix for the case where CometChat sends your own messages with
			 * interchanged from/to ids.
			 */
			if (1 == message.getInt(CometChatKeys.AjaxKeys.SELF)) {
				message.put(CometChatKeys.AjaxKeys.TO, message.getString(CometChatKeys.AjaxKeys.FROM));
				message.put(CometChatKeys.AjaxKeys.FROM, session.getId());
			}

			if (fromHeartBeat) {
				switch (messageProcessed) {
				case 0:
					break;
				case 1:
					callbacks.onMessageReceived(message);

					if ((message.getString(AjaxKeys.SELF).equals("0"))) {
						if (config.getUSECOMET() != null && config.getUSECOMET().equals("1")) {
							String transport = config.getTRANSPORT();
							if (CommonUtils.usertoChannelMap != null) {
								String userid = message.getString(AjaxKeys.FROM);
								String channel = CommonUtils.usertoChannelMap.get(userid);
								if (!TextUtils.isEmpty(channel)) {
									if (transport.equals("cometservice")) {
										Logger.error("msg id "+message.getString(CometChatKeys.AjaxKeys.ID));
										CometserviceOneOnOne.sendMessage(channel, CommonUtils
												.getDeliveredTickMessage(message.getString(CometChatKeys.AjaxKeys.ID)));
									} else if (transport.equals("cometservice-selfhosted")) {
										WebsyncOneOnOne.getInstance().publish(
												channel,
												CommonUtils.getDeliveredTickMessage(message
														.getString(CometChatKeys.AjaxKeys.ID)));
									}
								}
							}

						}
					}
					break;
				case 2:
					callbacks.onAVChatMessageReceived(message);
					break;
				default:
					break;
				}
				return null;
			} else {
				if (messageProcessed != 0) {
					return message;
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * @param message
	 *            : Pass single received message JSONObject
	 */
	public JSONObject handleChatroomMessage(JSONObject message, SubscribeChatroomCallbacks callbacks,
			boolean fromHeartBeat) {
		try {

			int messageProcessed = 1;
			if (message.has(AjaxKeys.MESSAGE)) {
				SessionData session = SessionData.getInstance();
				String mess = message.getString(AjaxKeys.MESSAGE);

				if (mess.contains("jqcc.cc")) {
					if (VideoChat.isCrAvchatRequest(mess)) {
						if (!String.valueOf(session.getId()).equals(message.getString("fromid"))) {
							message.put(CometChatKeys.AjaxKeys.MESSAGE, mess.substring(0, mess.indexOf(".") + 1));
							message.put(MessageTypeKeys.MESSAGE_TYPE,
									CometChatKeys.AvchatMessageTypeKeys.AVCHAT_MESSAGE_TYPE_INCOMING_CALL);
							String roomName = VideoChat.getAVConferenceRoomName(mess);
							session.setAvChatRoomName(roomName);
							messageProcessed = 2;
						} else {
							messageProcessed = 0;
						}
						// } else if (OtherPlugins.isScreehShareRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isWriteBoardRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isWhiteBoardRequest(mess)) {
						// messageProcessed = 0;
						// } else if (OtherPlugins.isCrAVBroadcast(mess)) {
						// messageProcessed = 0;
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("CC^CONTROL_")) {
					if (Chatroom.isKickedChatroomMessage(mess)) {
						/* Message is CC^CONTROL_kicked_*userid value* */
						String[] kickSplitedMessage = mess.split("_");
						String kicked = kickSplitedMessage[kickSplitedMessage.length - 1];
						if (!kicked.equals(CometChatKeys.ChatroomKeys.KICKED)) {
							if (Integer.parseInt(kicked) == session.getId()) {
								if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
									sendKickUserConfirmation(message.getString(CometChatKeys.AjaxKeys.SENT));
								} else {
									sendKickUserConfirmation(message.getString(CometChatKeys.AjaxKeys.ID));
								}
								CometChatroom.leaveChatroom(session.getCurrentChatroom(), "2", chatroomCallback);
							}
						}
						messageProcessed = 0;
					} else if (Chatroom.isBannedChatroomMessage(mess)) {
						/* Message is CC^CONTROL_banned_*userid value* */
						String[] banSplitedMessage = mess.split("_");
						String banned = banSplitedMessage[banSplitedMessage.length - 1];
						if (!banned.equals(CometChatKeys.ChatroomKeys.BANNED)) {
							if (Integer.parseInt(banned) == session.getId()) {
								if (JsonPhp.getInstance().getConfig().getUSECOMET().equals("1")) {
									sendBanUserConfirmation(message.getString(CometChatKeys.AjaxKeys.SENT));
								} else {
									sendBanUserConfirmation(message.getString(CometChatKeys.AjaxKeys.ID));
								}
								CometChatroom.leaveChatroom(session.getCurrentChatroom(), "1", chatroomCallback);
							}
						}
						messageProcessed = 0;
					} else if (Chatroom.isMessageDeletedFromChatroom(mess)) {
						JSONObject json = new JSONObject();
						json.put("action_type", ChatroomActionMessageTypeKeys.CHATROOM_MESSAGE_DELETED);
						json.put("message_id", mess.split("_")[2]);
						callbacks.onActionMessageReceived(json);
						messageProcessed = 0;
					} else if (Stickers.isEnabled() && Stickers.isSticker(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, Stickers.getSticker(mess));
						message.put(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.STICKER);
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("plugins/filetransfer")) {
					if (ImageSharing.isIncomingImage(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.IMAGE);
					} else if (VideoSharing.isIncomingVideo(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, VideoSharing.getVideoURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.VIDEO);
					} else if (ImageSharing.isIncomingAudio(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.AUDIO);
					} else if (ImageSharing.isFileTransfer(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getImageURL(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.FILE);
					} else {
						messageProcessed = 0;
					}
				} else if (mess.contains("/plugins/handwrite/")) {
					if (OtherPlugins.isHandWrite(mess)) {
						message.put(CometChatKeys.AjaxKeys.MESSAGE, ImageSharing.getHandwriteImageUrl(mess));
						message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.HANDWRITTEN_MESSAGE);
					} else {
						messageProcessed = 0;
					}
				} else {
					// Normal Message
					if (message.getString(CometChatKeys.AjaxKeys.FROM).equals(StaticMembers.ME_TEXT)
							|| message.getString(CometChatKeys.ChatroomKeys.FROMID).equals(
									String.valueOf(session.getId()))) {
						mess = handleSpecialHtmlCharacters(getColoredText(handleLink(mess), true));
					} else {
						mess = handleSpecialHtmlCharacters(getColoredText(handleLink(mess), false));
					}
					if (CometChatroom.useHTML) {
						mess = Smilies.convertImageTagToEmoji(handleLink(mess));
					}

					message.put(CometChatKeys.AjaxKeys.MESSAGE, mess);
					message.put(MessageTypeKeys.MESSAGE_TYPE, CometChatKeys.MessageTypeKeys.NORMAL);
					message.put(CometChatKeys.ChatroomKeys.TEXT_COLOR, textColor);
					messageProcessed = 1;
				}
			} else {
				messageProcessed = 0;
			}
			if (fromHeartBeat) {
				switch (messageProcessed) {
				case 0:
					break;
				case 1:
					callbacks.onMessageReceived(message);
					break;
				case 2:
					callbacks.onAVChatMessageReceived(message);
					break;
				default:
					break;
				}
				return null;
			} else {
				if (0 != messageProcessed) {
					return message;
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}
}