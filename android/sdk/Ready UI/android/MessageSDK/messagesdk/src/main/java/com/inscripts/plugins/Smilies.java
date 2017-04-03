/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.content.Context;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ImageSpan;

import com.inscripts.R;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.utils.StaticMembers;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.File;
import java.lang.reflect.Field;
import java.util.LinkedHashMap;
import java.util.Locale;

public class Smilies {

	private static String smileyPath = LocalStorageFactory.getSmileyStoragePath(), baseUrl = URLFactory.getBaseURL(),
			websiteUrl = URLFactory.getWebsiteURL(),smileyMessageResult = "";

	private static final int smileyCacheSize = 100;
	private static LinkedHashMap<String, SpannableString> messageToSmileyText = new LinkedHashMap<String, SpannableString>(
			smileyCacheSize, 0.75F, false) {

		private static final long serialVersionUID = 1L;

		@Override
		protected boolean removeEldestEntry(Entry<String, SpannableString> eldest) {
			return size() > smileyCacheSize;
		};
	};

	private static SpannableString textSpannable = new SpannableString("");

	/**
	 * @param message
	 *            Message to be displayed
	 * @param context
	 *            Context
	 * @param isChatroom
	 *            is message from chatroom or oneOnOne chat
	 * @return string containing image tags replaced by emojis
	 */
	public static SpannableString convertImageTagToEmoji(String message, Context context, boolean isChatroom,
			Class<?> resClass) {
		try {
			/*
			 * If message is already processed return its spannableString
			 */
			if (messageToSmileyText.containsKey(message)) {
				return messageToSmileyText.get(message);
			} else {
				/* Get image tags and title from message */
				textSpannable = new SpannableString(message);
				Document doc = Jsoup.parseBodyFragment(message);
				Elements imageTags = doc.select(StaticMembers.IMAGE_TAG);
				Resources res = context.getResources();
				int startIndex, endIndex, searchOffset = 0, id, emojiSize = Integer.parseInt(res
						.getString(R.string.emoji_size_actual)) + 7;
				Field field;
				for (Element image : imageTags) {
					/*
					 * String title =
					 * image.attr(StaticMembers.ATTRIBUTE_TITLE).replace(" ",
					 * "-") .toLowerCase(Locale.getDefault());
					 */
					String imageName = image.attr("src").substring(image.attr("src").lastIndexOf("/"));
					imageName = imageName.substring(1, imageName.lastIndexOf(".")).replace(" ", "-")
							.toLowerCase(Locale.getDefault());

					if (image.attr("class").equals("cometchat_smiley")) {
						/* Jsoup adds " />" to image tag if it is not there */
						String imageTag = image.toString().replace(" />", ">");
						switch (imageName) {
						case "e-mail":
							imageName = "e_mail";
							break;
						case "non-potable_water":
							imageName = "non_potable_water";
							break;
						case "new":
							imageName = "objects_new";
							break;
						case "100":
							imageName = "numbers_100";
							break;
						case "1234":
							imageName = "numbers_1234";
							break;
						case "8ball":
							imageName = "ball_8";
							break;
						default:
							break;
						}
						try {
							field = resClass.getField(imageName);
							id = field.getInt(null);
							Drawable drawable = res.getDrawable(id);
							drawable.setBounds(0, 0, emojiSize, emojiSize);
							startIndex = message.indexOf(imageTag, searchOffset);
							endIndex = startIndex + imageTag.length();
							textSpannable.setSpan(new ImageSpan(drawable), startIndex, endIndex,
									Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
							searchOffset = endIndex;
						} catch (Exception e) {
							/* If unsupported smiley is received */
							startIndex = message.indexOf(imageTag, searchOffset);
							endIndex = startIndex + imageTag.length();
							String fileName = imageName + ".png";
							File file = new File(smileyPath, fileName);
							if (file.exists()) {
								Drawable drawable = Drawable.createFromPath(smileyPath + fileName);
								drawable.setBounds(0, 0, emojiSize, emojiSize);
								textSpannable.setSpan(new ImageSpan(drawable), startIndex, endIndex,
										Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
							} else {
								String src = image.attr(StaticMembers.ATTRIBUTE_SRC), url;
								if (src.contains(websiteUrl)) {
									url = src;
								} else if (baseUrl.contains(src)
										|| src.contains(baseUrl.substring(websiteUrl.length()))) {
									url = websiteUrl + src;
								} else {
									url = baseUrl + src;
								}
								LocalStorageFactory.getUnsupportedEmoji(fileName, url, context, textSpannable,
										startIndex, endIndex, emojiSize, isChatroom);

								/*
								 * show dummy image till actual smiley get
								 * downloaded
								 */
								Drawable d = res.getDrawable(R.drawable.cc_broken_box);
								d.setBounds(0, 0, emojiSize, emojiSize);
								textSpannable.setSpan(new ImageSpan(d), startIndex, endIndex,
										Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
							}
							searchOffset = endIndex;
						}
					}
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		/*
		 * Store message and its spannableString in hashmap so it can be used
		 * next time
		 */
		messageToSmileyText.put(message, textSpannable);
		return textSpannable;
	}


    public static String convertImageTagToEmoji(String message) {
		/* Get image tags and title from message */
        smileyMessageResult = message;
        Document doc = Jsoup.parseBodyFragment(message);
        Elements imageTags = doc.select(StaticMembers.IMAGE_TAG);
        int startIndex = 0, endIndex = 0, searchOffset = 0;
        for (Element image : imageTags) {
            String title = image.attr(StaticMembers.ATTRIBUTE_TITLE).replace(" ", "-").toLowerCase(Locale.getDefault());
            if (image.attr(StaticMembers.ATTRIBUTE_SRC).contains(title)) {
				/* Jsoup adds " />" to image tag if it is not there */
                String imageTag = image.toString().replace(" />", ">");
                switch (title) {
                    case "e-mail":
                        title = "e_mail";
                        break;
                    case "non-potable_water":
                        title = "non_potable_water";
                        break;
                    case "new":
                        title = "objects_new";
                        break;
                    case "100":
                        title = "numbers_100";
                        break;
                    case "1234":
                        title = "numbers_1234";
                        break;
                    case "8ball":
                        title = "ball_8";
                        break;
                    default:
                        break;
                }

                try {
                    startIndex = message.indexOf(imageTag, searchOffset);
                    endIndex = startIndex + imageTag.length();
					/*if (emojiMapping.containsValue(title)) {
						smileyMessageResult = smileyMessageResult.replace(message.substring(startIndex, endIndex),
								emojiMapping.getKey(title));
					} else {
						 If unsupported smiley is received
						smileyMessageResult = smileyMessageResult.replace(message.substring(startIndex, endIndex), "");
					}*/
                    smileyMessageResult = smileyMessageResult.replace(message.substring(startIndex, endIndex), ":"
                            + title + ":");
                    searchOffset = endIndex;
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        }
        return smileyMessageResult;
    }

}
