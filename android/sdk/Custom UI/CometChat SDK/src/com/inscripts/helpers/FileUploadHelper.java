package com.inscripts.helpers;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.net.Socket;
import java.net.UnknownHostException;
import java.security.KeyManagementException;
import java.security.KeyStore;
import java.security.KeyStoreException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.UnrecoverableKeyException;
import java.security.cert.CertificateException;
import java.security.cert.X509Certificate;

import javax.net.ssl.SSLContext;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.ssl.SSLSocketFactory;
import org.apache.http.entity.mime.MultipartEntity;
import org.apache.http.entity.mime.content.FileBody;
import org.apache.http.entity.mime.content.StringBody;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

import android.annotation.SuppressLint;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Message;

import com.inscripts.factories.URLFactory;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

public class FileUploadHelper extends AsyncTask<Void, Void, Void> {

	// private MultipartEntityBuilder multipartEntity;
	private MultipartEntity multipartEntity;
	private String URL;
	private Handler handler = null;
	private boolean callback = true;

	/**
	 * The response will be fired back to the defined Handler as a callback.
	 */
	public FileUploadHelper(String URL, Handler handler) {
		// multipartEntity = MultipartEntityBuilder.create();
		multipartEntity = new MultipartEntity();
		this.handler = handler;
		this.URL = URL;
	}

	/**
	 * When the response need not be processed.
	 **/
	public FileUploadHelper(String URL) {
		// multipartEntity = MultipartEntityBuilder.create();
		multipartEntity = new MultipartEntity();
		this.URL = URL;
	}

	@SuppressLint("TrulyRandom")
	@Override
	protected Void doInBackground(Void... arg0) {
		try {
			if (CommonUtils.isConnected()) {
				if (URL.startsWith("https")) {
					CommonUtils.allowHttpsConnection();
				}
				// multipartEntity.addTextBody(AjaxKeys.BASE_DATA, SessionData.getInstance().getBaseData());
				/*multipartEntity.addTextBody(AjaxKeys.CALLBACK_FN, AjaxKeys.CALLBACK_FN_VALUE);
				multipartEntity.addTextBody(AjaxKeys.VERSION2, "1");
				multipartEntity.addTextBody(AjaxKeys.VERSION3, "1");
				multipartEntity.addTextBody(AjaxKeys.SDK_PARAM, "1");
				multipartEntity.addTextBody(AjaxKeys.PLATFORM, "a");*/

				multipartEntity.addPart(AjaxKeys.BASE_DATA, new StringBody(SessionData.getInstance().getBaseData()));
				multipartEntity.addPart(AjaxKeys.CALLBACK_FN, new StringBody(AjaxKeys.CALLBACK_FN_VALUE));
				multipartEntity.addPart(AjaxKeys.VERSION2, new StringBody("1"));
				multipartEntity.addPart(AjaxKeys.VERSION3, new StringBody("1"));
				multipartEntity.addPart(AjaxKeys.SDK_PARAM, new StringBody("1"));
				multipartEntity.addPart(AjaxKeys.PLATFORM, new StringBody("a"));

				/*
				 * For some ajax calls Callback value is not required..
				 * duplicate error occurs at server side
				 */
				if (callback) {
					/*multipartEntity.addTextBody(AjaxKeys.CALLBACK,
							"jqcc17108543446448165930_" + System.currentTimeMillis());*/
					multipartEntity.addPart(AjaxKeys.CALLBACK,
							new StringBody("jqcc17108543446448165930_" + System.currentTimeMillis()));
				}

				// multipartEntity.setMode(HttpMultipartMode.BROWSER_COMPATIBLE);

				HttpClient httpclient;
				if (URL.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
					SSLContext ctx = SSLContext.getInstance("TLS");
					ctx.init(null, new TrustManager[] { new CustomX509TrustManager() }, new SecureRandom());

					HttpClient httpclient1 = new DefaultHttpClient();
					SSLSocketFactory ssf = new CustomSSLSocketFactory(ctx);
					ssf.setHostnameVerifier(SSLSocketFactory.ALLOW_ALL_HOSTNAME_VERIFIER);
					ClientConnectionManager ccm = httpclient1.getConnectionManager();
					SchemeRegistry sr = ccm.getSchemeRegistry();
					sr.register(new Scheme("https", ssf, 443));
					httpclient = new DefaultHttpClient(ccm, httpclient1.getParams());
				} else {
					httpclient = new DefaultHttpClient();
				}

				httpclient.getConnectionManager().closeExpiredConnections();
				HttpPost httppost = new HttpPost(URL);
				// httppost.setEntity(multipartEntity.build());
				httppost.setEntity(multipartEntity);
				if (PreferenceHelper.contains(PreferenceKeys.DataKeys.API_KEY)) {
					httppost.addHeader("api-key", PreferenceHelper.get(PreferenceKeys.DataKeys.API_KEY));
				}
				HttpResponse response = httpclient.execute(httppost);
				int responseCode = response.getStatusLine().getStatusCode();

				httppost = null;
				httpclient = null;

				String serverResponse = EntityUtils.toString(response.getEntity());
				if (handler != null) {
					Message message = handler.obtainMessage();
					message.obj = serverResponse;
					if (responseCode == 200) {
						message.what = StaticMembers.AJAX_SUCCESS;
					} else if (responseCode == 404) {
						message.what = StaticMembers.AJAX_FAIL;
					}
					handler.sendMessage(message);
				}

				/* DEV_MODE */
				if (PreferenceHelper.contains(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)
						&& Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.DEVELOPMENT_MODE)) == 1) {
					Logger.debug("CC_SDK_LOG:URL: " + URL);
					Logger.debug("CC_SDK_LOG:RESPONSE: " + serverResponse);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * Add a new name value pair to the current request. The parameters are
	 * cleared after the request in completed.
	 **/
	public void addNameValuePair(String name, String value) {
		try {
			// multipartEntity.addTextBody(name, value);
			multipartEntity.addPart(name, new StringBody(value));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void addNameValuePair(String name, Integer value) {
		try {
			// multipartEntity.addTextBody(name, value.toString());
			multipartEntity.addPart(name, new StringBody(value.toString()));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void addFile(String key, File newFile) throws FileNotFoundException {
		if (newFile.exists()) {
			// multipartEntity.addBinaryBody(key, newFile);
			multipartEntity.addPart(key, new FileBody(newFile));
		} else {
			throw new FileNotFoundException("No file was found at the path " + newFile.getPath());
		}
	}

	/**
	 * Pass true to set the "callback" parameter. Callback is sent by default.
	 */
	public void sendCallBack(Boolean isRequired) {
		callback = isRequired;
	}

	private class CustomX509TrustManager implements X509TrustManager {

		@Override
		public void checkClientTrusted(X509Certificate[] chain, String authType) throws CertificateException {
		}

		@Override
		public void checkServerTrusted(java.security.cert.X509Certificate[] certs, String authType)
				throws CertificateException {
		}

		@Override
		public X509Certificate[] getAcceptedIssuers() {
			return null;
		}

	}

	private class CustomSSLSocketFactory extends SSLSocketFactory {
		SSLContext sslContext = SSLContext.getInstance("TLS");

		public CustomSSLSocketFactory(KeyStore truststore) throws NoSuchAlgorithmException, KeyManagementException,
				KeyStoreException, UnrecoverableKeyException {
			super(truststore);

			TrustManager tm = new CustomX509TrustManager();

			sslContext.init(null, new TrustManager[] { tm }, null);
		}

		private CustomSSLSocketFactory(SSLContext context) throws KeyManagementException, NoSuchAlgorithmException,
				KeyStoreException, UnrecoverableKeyException {
			super(null);
			sslContext = context;
		}

		@Override
		public Socket createSocket(Socket socket, String host, int port, boolean autoClose) throws IOException,
				UnknownHostException {
			return sslContext.getSocketFactory().createSocket(socket, host, port, autoClose);
		}

		@Override
		public Socket createSocket() throws IOException {
			return sslContext.getSocketFactory().createSocket();
		}
	}

}