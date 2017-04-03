package com.inscripts.utils;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.security.SecureRandom;
import java.security.cert.X509Certificate;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.Locale;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

import org.json.JSONObject;

import android.annotation.SuppressLint;
import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.text.format.DateUtils;
import android.util.Base64;

import com.android.volley.Request.Method;
import com.inscripts.callbacks.SubscribeCallbacks;
import com.inscripts.callbacks.SubscribeChatroomCallbacks;
import com.inscripts.callbacks.VolleyAjaxCallbacks;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.PreferenceKeys;

public class CommonUtils {

	private static ConnectivityManager cm;
	public static HashMap<String, String> usertoChannelMap = new HashMap<>();

	public static boolean isConnected() {
		if (cm == null) {
			cm = (ConnectivityManager) PreferenceHelper.getContext().getSystemService(Context.CONNECTIVITY_SERVICE);
		}
		NetworkInfo info = cm.getActiveNetworkInfo();
		if (null != info) {
			if (info.isConnectedOrConnecting()) {
				return true;
			}
		}
		return false;
	}

	@SuppressLint("SimpleDateFormat")
	public static String convertTimestampToDate(long timestamp) {
		Timestamp tStamp = new Timestamp(timestamp);
		SimpleDateFormat simpleDateFormat;
		boolean isArmyTime = null != JsonPhp.getInstance().getConfig().getArmyTime()
				&& JsonPhp.getInstance().getConfig().getArmyTime().equals("1");
		if (DateUtils.isToday(timestamp)) {
			if (isArmyTime) {
				simpleDateFormat = new SimpleDateFormat("H:mm");
			} else {
				simpleDateFormat = new SimpleDateFormat("hh:mm a");
			}
			return JsonPhp.getInstance().getLang().getMobile().get37() + " " + simpleDateFormat.format(tStamp);
		} else {
			if (isArmyTime) {
				simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy H:mm");
			} else {
				simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy hh:mm a");
			}
			return simpleDateFormat.format(tStamp);
		}
	}

	/* Used to show time duration for avchat calls */
	public static String convertTimeStampToDurationTime(long timestamp) {
		long second = timestamp / 1000;
		long minute = (second / 60) % 60;
		long hour = ((second / 60) / 60) % 24;
		return String.format(Locale.getDefault(), "%02d:%02d:%02d", hour, minute, second % 60);
	}

	public static byte[] xorWithKey(byte[] a, byte[] key) {
		byte[] out = new byte[a.length];
		for (int i = 0; i < a.length; i++) {
			out[i] = (byte) (a[i] ^ key[i % key.length]);
		}
		return out;
	}

	public static byte[] encodeBase64(String value) {
		return CommonUtils.encodeBase64(value.getBytes());
	}

	public static byte[] encodeBase64(byte[] value) {
		return Base64.encode(value, 0);
	}

	public static byte[] decodeBase64(String value) {
		return Base64.decode(value, 0);
	}

	public static byte[] decodeBase64(byte[] value) {
		return Base64.decode(value, 0);
	}

	/**
	 * If timestamp is less than 13 digit then convert it to 13 digit
	 * 
	 * @param timestampInMessage
	 * @return corrected timestamp
	 */
	public static long correctIncomingTimestamp(long timestampInMessage) {
		long correctedTimestamp = timestampInMessage;

		if (String.valueOf(timestampInMessage).length() < 13) {
			int difference = 13 - String.valueOf(timestampInMessage).length(), i;
			String differenceValue = "1";
			for (i = 0; i < difference; i++) {
				differenceValue += "0";
			}
			correctedTimestamp = (timestampInMessage * Long.parseLong(differenceValue))
					+ (System.currentTimeMillis() % (Long.parseLong(differenceValue)));
		}
		return correctedTimestamp;
	}

	public static boolean isJSONValid(String test) {
		try {
			new JSONObject(test);
		} catch (Exception ex) {
			return false;
		}
		return true;
	}

	public static void allowHttpsConnection() {
		try {
			TrustManager[] trustAllCerts = new TrustManager[] { new X509TrustManager() {
				@Override
				public X509Certificate[] getAcceptedIssuers() {
					X509Certificate[] myTrustedAnchors = new X509Certificate[0];
					return myTrustedAnchors;
				}

				@Override
				public void checkClientTrusted(X509Certificate[] certs, String authType) {
				}

				@Override
				public void checkServerTrusted(X509Certificate[] certs, String authType) {
				}
			} };

			SSLContext sc = SSLContext.getInstance("SSL");
			sc.init(null, trustAllCerts, new SecureRandom());
			HttpsURLConnection.setDefaultSSLSocketFactory(sc.getSocketFactory());
			HttpsURLConnection.setDefaultHostnameVerifier(new HostnameVerifier() {
				@Override
				public boolean verify(String arg0, SSLSession arg1) {
					return true;
				}
			});
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public static String processAvatarUrl(String avatarUrl) {
		if (PreferenceHelper.contains(PreferenceKeys.DataKeys.API_KEY)) {
			if (avatarUrl.contains("graph.facebook.com")) {
				avatarUrl = URLFactory.PROTOCOL_PREFIX_SECURE + avatarUrl;
			} else if (avatarUrl.startsWith("//")) {
				avatarUrl = URLFactory.PROTOCOL_PREFIX + avatarUrl;
			}
		} else if (!avatarUrl.startsWith(URLFactory.PROTOCOL_PREFIX)
				&& !avatarUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
			if (avatarUrl.contains("graph.facebook.com")) {
				avatarUrl = URLFactory.PROTOCOL_PREFIX_SECURE + avatarUrl;
			} else {
				avatarUrl = URLFactory.getWebsiteURL() + avatarUrl;
			}
		}

		if (avatarUrl.contains("////")) {
			avatarUrl = avatarUrl.replace("////", "//");
		}
		return avatarUrl;
	}

	public static void translateMessage(String message, final VolleyAjaxCallbacks volleyAjaxCallbacks) {
		String goolgeTranslateURL;
		try {
			goolgeTranslateURL = URLFactory.getGoogleTranslateURL() + "?key="
					+ JsonPhp.getInstance().getConfig().getRttKey() + "&q=" + URLEncoder.encode(message, "utf-8")
					+ "&target=" + PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
		} catch (UnsupportedEncodingException e1) {
			e1.printStackTrace();
			goolgeTranslateURL = URLFactory.getGoogleTranslateURL() + "?key=AIzaSyCrgExNrv4-O6JKMwEFdBp5XrIoCyw3UJw&q="
					+ message + "&target=" + PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
		}

		VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), goolgeTranslateURL,
				new VolleyAjaxCallbacks() {

					@Override
					public void successCallback(String response) {
						try {
							JSONObject translatedObject = new JSONObject(response);
							String translatedText = translatedObject.getJSONObject("data").getJSONArray("translations")
									.getJSONObject(0).getString("translatedText");
							volleyAjaxCallbacks.successCallback(translatedText);
						} catch (Exception e) {
							volleyAjaxCallbacks.failCallback(response);
						}
					}

					@Override
					public void failCallback(String response) {
						volleyAjaxCallbacks.failCallback(response);
					}

					@Override
					public void noInternetCallback() {
						volleyAjaxCallbacks.noInternetCallback();
					}
				});
		vHelper.setRequestType(Method.GET);
		vHelper.sendAjax();
	}

	public static JSONObject createErrorJson(String errorCode, String description) {
		JSONObject json = new JSONObject();
		try {
			json.put("code", errorCode);
			json.put("message", description);
			return json;
		} catch (Exception e) {
			e.printStackTrace();
		}
		return json;
	}

	public static void sendCallBackError(String errorCode, String description, SubscribeCallbacks callback) {
		JSONObject json = new JSONObject();
		try {
			json.put(errorCode, description);
		} catch (Exception e) {
			e.printStackTrace();
		}
		callback.onError(json);
	}

	public static void sendCallBackError(String status, String description, SubscribeChatroomCallbacks callback) {
		JSONObject json = new JSONObject();
		try {
			json.put(status, description);
		} catch (Exception e) {
			e.printStackTrace();
		}
		callback.onError(json);
	}

	public static String getTypingStartMessage() {
		Long time = System.currentTimeMillis();
		return "{\"from\":"
				+ SessionData.getInstance().getId()
				+ ",\"sent\":"
				+ time
				+ ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"typingTo\\\",\\\"params\\\":{\\\"fromid\\\":"
				+ SessionData.getInstance().getId() + ",\\\"typingtime\\\":" + time + "}}\"}";
	}

	public static String getTypingStopMessage() {
		Long time = System.currentTimeMillis();
		return "{\"from\":"
				+ SessionData.getInstance().getId()
				+ ",\"sent\":"
				+ time
				+ ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"typingStop\\\",\\\"params\\\":{\\\"fromid\\\":"
				+ SessionData.getInstance().getId() + ",\\\"typingtime\\\":" + time + "}}\"}";
	}

	public static String getDeliveredTickMessage(String messageID) {
		return "{\"from\":"
				+ SessionData.getInstance().getId()
				+ ",\"sent\":"
				+ System.currentTimeMillis()
				+ ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"deliveredMessageNotify\\\",\\\"params\\\":{\\\"fromid\\\":"
				+ SessionData.getInstance().getId() + ",\\\"message\\\":" + messageID + "}}\"}";
	}

	public static String getReadTickMessage(String messageID) {
		return "{\"from\":"
				+ SessionData.getInstance().getId()
				+ ",\"sent\":"
				+ System.currentTimeMillis()
				+ ",\"message\":\"CC^CONTROL_{\\\"type\\\":\\\"core\\\",\\\"name\\\":\\\"textchat\\\",\\\"method\\\":\\\"readMessageNotify\\\",\\\"params\\\":{\\\"fromid\\\":"
				+ SessionData.getInstance().getId() + ",\\\"message\\\":" + messageID + "}}\"}";
	}
}