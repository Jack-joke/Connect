package com.inscripts.plugins;

import java.lang.reflect.Field;

import org.json.JSONObject;

import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ImageSpan;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;

public class Stickers {

	public static boolean isEnabled() {
		return null != JsonPhp.getInstance().getConfig().getStickersEnabled()
				&& JsonPhp.getInstance().getConfig().getStickersEnabled().equals("1");
	}

	public static SpannableString showSticker(String message, Field field) {
		SpannableString textSpannable = new SpannableString("");
		try {
			Resources res = PreferenceHelper.getContext().getResources();
			int id = field.getInt(null);
			Drawable drawable = res.getDrawable(id);
			drawable.setBounds(0, 0, 250, 250);
			textSpannable = new SpannableString(message);
			textSpannable.setSpan(new ImageSpan(drawable), 0, message.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
			return textSpannable;

			/*  
			  
			  String data[] = message.split("_\\{");
			  JSONObject json = new JSONObject("{" + data[1]);
			  JSONObject params = json.getJSONObject("params");
			  String sticker = params.getString("key");
			  Field field = R.drawable.class.getField(sticker);
			  Resources res = PreferenceHelper.getContext().getResources();
			  int id = field.getInt(null);
			  Drawable drawable = res.getDrawable(id);
			  drawable.setBounds(0, 0, 250, 250);
			  textSpannable = new SpannableString(message);
			  textSpannable.setSpan(new ImageSpan(drawable), 0, message.length(),
			          Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
			  return textSpannable;
			  
			*/
		} catch (Exception e) {
			e.printStackTrace();
		}
		return textSpannable;
	}

	public static String getSticker(String message) {
		try {
			String data[] = message.split("_\\{");
			JSONObject json = new JSONObject("{" + data[1]);
			JSONObject params = json.getJSONObject("params");
			return params.getString("key");
		} catch (Exception e) {
			return "";
		}
	}

	public static boolean isSticker(String message) {
		return message.contains("\"method\":\"sendSticker\"");
	}

	public static String getCategory(String sticker) {
		if (sticker.startsWith("bear")) {
			return "bear";
		} else if (sticker.startsWith("gery")) {
			return "gery";
		} else if (sticker.startsWith("geek")) {
			return "geek";
		} else if (sticker.startsWith("happ")) {
			return "happyghost";
		} else if (sticker.startsWith("litt")) {
			return "littledyno";
		} else if (sticker.startsWith("momo")) {
			return "momon";
		} else if (sticker.startsWith("mons")) {
			return "monster";
		} else if (sticker.startsWith("peng")) {
			return "penguin";
		} else if (sticker.startsWith("pira")) {
			return "pirate";
		} else if (sticker.startsWith("skat")) {
			return "skaterboy";
		} else if (sticker.startsWith("vamp")) {
			return "vampire";
		} else {
			return "bear";
		}
	}

}
