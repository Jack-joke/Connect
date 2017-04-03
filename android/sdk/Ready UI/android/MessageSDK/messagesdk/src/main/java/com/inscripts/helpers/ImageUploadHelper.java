/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.os.Handler;
import android.os.Message;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request.Method;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.Response.Listener;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.apache.http.entity.mime.MultipartEntity;
import org.apache.http.entity.mime.content.FileBody;
import org.apache.http.entity.mime.content.StringBody;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;

public class ImageUploadHelper {

	private String URL;
	private static RequestQueue queue;
	private Handler handler = null;
	private boolean callback = true;

	private MultipartEntity multipartEntity = new MultipartEntity();

	public ImageUploadHelper(Context c, String URL, Handler handler) {
		this.handler = handler;
		this.URL = URL;

		queue = VolleyHelper.getQueueInstance(c);
	}

	public void sendImageAjax() {
		if (CommonUtils.isConnected()) {
			try {
                if(URL.startsWith("https")){
                    CommonUtils.allowHttpsConnection();
                }
				multipartEntity.addPart(AjaxKeys.BASE_DATA, new StringBody(SessionData.getInstance().getBaseData()));
				multipartEntity.addPart(AjaxKeys.CALLBACK_FN, new StringBody(AjaxKeys.CALLBACK_FN_VALUE));
				// multipartEntity.addPart(AjaxKeys.VERSION, new
				// StringBody("1"));
				multipartEntity.addPart(AjaxKeys.VERSION2, new StringBody("1"));
				multipartEntity.addPart(AjaxKeys.VERSION3, new StringBody("1"));

				/*
				 * For some ajax calls Callback value is not required..
				 * duplicate error occurs at server side
				 */
				if (callback) {
					multipartEntity.addPart(AjaxKeys.CALLBACK,
							new StringBody("jqcc17108543446448165930_" + System.currentTimeMillis()));
				}

				StringRequest request = new StringRequest(Method.POST, URL, new Listener<String>() {

					@Override
					public void onResponse(String response) {
						if (handler != null) {
							Message message = handler.obtainMessage();
							message.obj = response;
							message.what = StaticMembers.AJAX_SUCCESS;
							handler.sendMessage(message);
						}

					}
				}, new Response.ErrorListener() {

					@Override
					public void onErrorResponse(VolleyError response) {
						if (handler != null) {
							Message message = handler.obtainMessage();
							message.obj = response;
							message.what = StaticMembers.AJAX_FAIL;
							handler.sendMessage(message);
						}
					}
				}) {
					@Override
					public byte[] getBody() {
						ByteArrayOutputStream bos = new ByteArrayOutputStream();
						try {
							multipartEntity.writeTo(bos);
						} catch (Exception e) {
							e.printStackTrace();
						}
						return bos.toByteArray();
					}

					@Override
					public String getBodyContentType() {
						return multipartEntity.getContentType().getValue();
					}
				};
				request.setRetryPolicy(new DefaultRetryPolicy(0, DefaultRetryPolicy.DEFAULT_MAX_RETRIES,
						DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
				queue.add(request);
			} catch (Exception e) {
				e.printStackTrace();
			}

		} else {
			if (handler != null) {
				Message message = handler.obtainMessage();
				message.obj = StaticMembers.PLEASE_CHECK_YOUR_INTERNET;
				message.what = -1;
				handler.sendMessage(message);
			}
		}
	}

	/**
	 * Add a new name value pair to the current request. The parameters are
	 * cleared after the request in completed.
	 **/
	public void addNameValuePair(String name, String value) {
		try {
			multipartEntity.addPart(name, new StringBody(value));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void addNameValuePair(String name, Integer value) {
		try {
			multipartEntity.addPart(name, new StringBody(String.valueOf(value)));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void addNameValuePair(String name, Long value) {
		try {
			multipartEntity.addPart(name, new StringBody(String.valueOf(value)));
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void addFile(String key, File newFile) throws FileNotFoundException {
		if (newFile.exists()) {
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
}
