package com.inscripts.utils;

import java.util.ResourceBundle;

public class Messages {
	private static final String BUNDLE_NAME = "com.inscripts.utils.messages"; //$NON-NLS-1$

	private static final ResourceBundle RESOURCE_BUNDLE = ResourceBundle.getBundle(BUNDLE_NAME);

	private Messages() {
	}

	public static String getString(String key) {
		try {
			return RESOURCE_BUNDLE.getString(key);
		} catch (Exception e) {
			return '!' + key + '!';
		}
	}
}
