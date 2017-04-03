package com.inscripts.helpers;

import android.content.Context;
import android.content.SharedPreferences;

public class PreferenceHelper {

	private static Context context = null;
	private static SharedPreferences preferences;
	private static SharedPreferences.Editor editor;

	public static Context getContext() {
		return context;
	}

	public static void initialize(Context con) {
		if (context == null) {
			context = con;
		}
		preferences = context.getSharedPreferences("cc_sdk", Context.MODE_PRIVATE);
		editor = preferences.edit();

	}

	public static void save(String key, String value) {
		editor.putString(key, value);
		editor.commit();
	}

	public static void save(String key, Integer value) {
		save(key, String.valueOf(value));
	}

	public static String get(String key) {
		return preferences.getString(key, null);
	}

	public static Boolean contains(String key) {
		return preferences.contains(key);
	}

	public static void removeKey(String key) {
		editor.remove(key);
		editor.commit();
	}

	/**
	 * Flush all user data from the preferences
	 **/
	public static void cleanUp() {
		editor.clear().commit();
	}
}