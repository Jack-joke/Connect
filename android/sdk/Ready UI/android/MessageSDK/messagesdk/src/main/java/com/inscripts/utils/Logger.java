/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.util.Log;

public class Logger {

	public static void error(String message) {
		Log.e(StaticMembers.LOGGER_TAG, message);
	}

	public static void debug(String message) {
		Log.d(StaticMembers.LOGGER_TAG, message);
	}

	public static void info(String message) {
		Log.i(StaticMembers.LOGGER_TAG, message);
	}

}