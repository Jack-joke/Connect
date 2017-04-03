package com.inscripts.plugins;

import java.util.Locale;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import com.inscripts.utils.StaticMembers;

public class Smilies {
	private static String smileyMessageResult = "";

	// private static BidiMap<String, String> emojiMapping;

	/**
	 * @param message
	 *            Message to be displayed
	 * @param context
	 *            Context
	 * @param isChatroom
	 *            is message from chatroom or oneOnOne chat
	 * @return string containing image tags replaced by emojis
	 */
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
