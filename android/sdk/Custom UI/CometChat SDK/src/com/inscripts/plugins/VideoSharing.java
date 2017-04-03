package com.inscripts.plugins;

import java.io.File;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import android.annotation.SuppressLint;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.FileUploadHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

public class VideoSharing {

	public static boolean isIncomingVideo(String message) {
		return message.contains(StaticMembers.IMAGE_MESSAGE_CLASS) && message.contains(StaticMembers.FILETRANSFER_KEY)
				&& message.contains(StaticMembers.VIDEO_MESSAGE_CSS_CLASS);
	}

	public static boolean isDisabled() {
		return JsonPhp.getInstance().getFiletransferEnabled().equals("0");
	}

	public static boolean isCrDisabled() {
		return JsonPhp.getInstance().getCrfiletransferEnabled().equals("0");
	}

	public static String getVideoURL(String message) {
		/*
		 * URL is received as //siteurl/cometchat/cometchat/plugins/filetransfer
		 * /download.php?file=Emoticon128.png
		 */
		Document doc = Jsoup.parseBodyFragment(message);
		Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
		String relHref = link.attr(StaticMembers.HREF), websiteUrl = URLFactory.getWebsiteURL();
		if (!relHref.contains(URLFactory.PROTOCOL_PREFIX)) {
			if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX)) {
				relHref = URLFactory.PROTOCOL_PREFIX + relHref;
			} else if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
				relHref = URLFactory.PROTOCOL_PREFIX_SECURE + relHref;
			} else {
				relHref = URLFactory.PROTOCOL_PREFIX + relHref;
			}
		} else if (!relHref.contains(websiteUrl)) {
			relHref = websiteUrl + relHref;
		}

		if (relHref.contains("////")) {
			relHref = relHref.replace("////", "//");
		}
		return relHref;
	}


	/**
	 * @param videoFile
	 *            Video file to be sent
	 * @param windowId
	 *            To id / Chatroom id
	 * @param isChatroom
	 *            Boolean value to specify video to be sent in chatroom or not
	 */
	@SuppressLint("HandlerLeak")
	public void sendVideoAjax(final File videoFile, final String windowId, final boolean isChatroom,
			final Callbacks callbacks) {
		try {
			Handler handler = new Handler() {

				@Override
				public void handleMessage(Message msg) {
					super.handleMessage(msg);
					try {
						String messageId = msg.obj.toString();
						if (!TextUtils.isEmpty(messageId)) {
							JSONObject success = new JSONObject();
							success.put(AjaxKeys.ID, messageId);
							success.put(AjaxKeys.ORIGINAL_FILE, videoFile);
							callbacks.successCallback(success);
						} else {
							JSONObject failed = new JSONObject();
							callbacks.failCallback(failed);
						}
					} catch (Exception e) {
						e.printStackTrace();
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_RANDOM_EXCEPTION,
								CometChatKeys.ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
					}
				}
			};

			FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
			videoSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
			videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 512);
			videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 512);
			videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
					.getFirstName());
			videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, videoFile.getName());
			videoSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, videoFile);
			videoSendHelper.sendCallBack(false);

			if (isChatroom) {
				videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
						CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
			}
			videoSendHelper.execute();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}