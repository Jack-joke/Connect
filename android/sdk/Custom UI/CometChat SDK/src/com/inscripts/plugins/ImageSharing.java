package com.inscripts.plugins;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.FileUploadHelper;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.FileUploadKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

public class ImageSharing {

	public static boolean isIncomingImage(String message) {

		return message.contains(StaticMembers.IMAGE_MESSAGE_CSS_CLASS)
				&& message.contains(StaticMembers.FILETRANSFER_KEY)
				&& message.contains(StaticMembers.IMAGE_MESSAGE_CLASS);
	}

	public static boolean isIncomingAudio(String message) {
		return message.contains(StaticMembers.AUDIO_MESSAGE_CSS_CLASS)
				&& message.contains(StaticMembers.FILETRANSFER_KEY)
				&& message.contains(StaticMembers.IMAGE_MESSAGE_CLASS);
	}

	public static boolean isFileTransfer(String message) {
		return message.contains(StaticMembers.FILETRANSFER_KEY) && message.contains(").");
	}

	/*
	 * Gets the image URL from an anchor tag
	 */
	/*public static String getImageURL(String message) {
		
		 * URL is received as //siteurl/cometchat/cometchat/plugins/filetransfer
		 * /download.php?file=Emoticon128.png
		 
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
	}*/

	public static String getImageURL(String message) {
		/*
		 * URL is received as //siteurl/cometchat/cometchat/plugins/filetransfer
		 * /download.php?file=Emoticon128.png
		 */
		Document doc = Jsoup.parseBodyFragment(message);
		Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
		String relHref = link.attr(StaticMembers.HREF), websiteUrl = URLFactory.getWebsiteURL();
		if (!relHref.contains(URLFactory.PROTOCOL_PREFIX) && !relHref.contains(URLFactory.PROTOCOL_PREFIX_SECURE)) {
			if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX)) {
				if (!relHref.contains(websiteUrl)) {
					relHref = websiteUrl + relHref;
				} else {
					relHref = URLFactory.PROTOCOL_PREFIX + relHref;	
				}
			} else if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
				if (!relHref.contains(websiteUrl)) {
					relHref = websiteUrl + relHref;
				} else {
					relHref = URLFactory.PROTOCOL_PREFIX_SECURE + relHref;	
				}
			} else {
				relHref = URLFactory.PROTOCOL_PREFIX + relHref;
			}
		} else if (!relHref.contains(websiteUrl)) {
			relHref = websiteUrl + relHref;
		}

		/*if (relHref.contains("////")) {
			relHref = relHref.replace("////", "//");
		}*/
		
		relHref = relHref.replace("////", "//");
		
		relHref = relHref.replace("///", "//");
		return relHref;
	}

	/**
	 * @param selectedImage
	 *            Processed image bitmap to be sent
	 * @param windowId
	 *            To id / chatroom id
	 * @param isChatroom
	 *            Boolean value to specify image to be sent in chatroom or not
	 * @param callbacks
	 */
	@SuppressLint("HandlerLeak")
	public void sendImageAjax(final File imageFile, final String windowId, final boolean isChatroom,
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
							success.put(AjaxKeys.ORIGINAL_FILE, imageFile);
							callbacks.successCallback(success);
						} else {
							JSONObject failed = new JSONObject();
							// add error code
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

			FileUploadHelper imageSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
			imageSendHelper.addNameValuePair(AjaxKeys.TO, windowId);
			imageSendHelper.addNameValuePair(FileUploadKeys.IMAGE_HEIGHT, String.valueOf(512));
			imageSendHelper.addNameValuePair(FileUploadKeys.IMAGE_WIDTH, String.valueOf(512));
			imageSendHelper.addNameValuePair(FileUploadKeys.SENDERNAME, SessionData.getInstance().getFirstName());
			imageSendHelper.addNameValuePair(FileUploadKeys.FILENAME, imageFile.getName());
			imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, imageFile);

			if (isChatroom) {
				imageSendHelper.addNameValuePair(FileUploadKeys.CHATROOMMODE, FileUploadKeys.CHATROOMMODE_VALUE);
			}

			imageSendHelper.sendCallBack(false);
			imageSendHelper.execute();
		} catch (Exception e) {
			e.printStackTrace();
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_RANDOM_EXCEPTION,
					CometChatKeys.ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
		}
	}

	/**
	 * @param selectedImage
	 *            Processed image bitmap to be sent
	 * @param windowId
	 *            To id / chatroom id
	 * @param isChatroom
	 *            Boolean value to specify image to be sent in chatroom or not
	 */
	@SuppressLint("HandlerLeak")
	public void sendImageAjax(final Bitmap selectedImage, String windowId, boolean isChatroom, String fileName,
			final Callbacks callbacks) {
		try {
			ByteArrayOutputStream outstr = new ByteArrayOutputStream();
			selectedImage.compress(Bitmap.CompressFormat.JPEG, 85, outstr);

			final File file = new File(Environment.getExternalStorageDirectory() + File.separator + fileName);
			file.createNewFile();

			FileOutputStream fo = new FileOutputStream(file);
			fo.write(outstr.toByteArray());
			fo.flush();
			fo.close();

			Handler handler = new Handler() {

				@Override
				public void handleMessage(Message msg) {
					super.handleMessage(msg);
					try {
						JSONObject json = new JSONObject();
						json.put(AjaxKeys.ID, msg.obj.toString());
						json.put(AjaxKeys.ORIGINAL_FILE, selectedImage);
						callbacks.successCallback(json);
					} catch (Exception e) {
						callbacks.failCallback(CommonUtils.createErrorJson(
								CometChatKeys.ErrorKeys.CODE_JSON_PARSING_ERROR,
								CometChatKeys.ErrorKeys.MESSAGE_JSON_PARSING_ERROR));
					} finally {
						file.delete();
					}
				}
			};

			FileUploadHelper imageSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
			imageSendHelper.addNameValuePair(AjaxKeys.TO, windowId);
			imageSendHelper.addNameValuePair(FileUploadKeys.IMAGE_HEIGHT, String.valueOf(512));
			imageSendHelper.addNameValuePair(FileUploadKeys.IMAGE_WIDTH, String.valueOf(512));
			imageSendHelper.addNameValuePair(FileUploadKeys.SENDERNAME, SessionData.getInstance().getFirstName());
			imageSendHelper.addNameValuePair(FileUploadKeys.FILENAME, fileName);
			imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, file);

			if (isChatroom) {
				imageSendHelper.addNameValuePair(FileUploadKeys.CHATROOMMODE, FileUploadKeys.CHATROOMMODE_VALUE);
			}

			imageSendHelper.sendCallBack(false);
			imageSendHelper.execute();
		} catch (Exception e) {
			e.printStackTrace();
			callbacks.failCallback(CommonUtils.createErrorJson(CometChatKeys.ErrorKeys.CODE_RANDOM_EXCEPTION,
					CometChatKeys.ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
		}
	}

	public static String getHandwriteImageUrl(String message) {
		Document doc = Jsoup.parseBodyFragment(message);
		Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
		String relHref = URLFactory.getWebsiteURL() + link.attr(StaticMembers.HREF);
		return relHref;
	}

}
