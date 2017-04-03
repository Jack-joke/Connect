package com.inscripts.cometchat_sdkdemo;

import org.json.JSONObject;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.cometchat.sdk.AVChat;
import com.inscripts.cometchat.sdk.AudioChat;
import com.inscripts.cometchat_sdkdemo.R;
import com.inscripts.helper.Keys.SharedPreferenceKeys;
import com.inscripts.helper.SharedPreferenceHelper;
import com.inscripts.utils.Logger;

public class IncomingCallActivity extends ActionBarActivity {

	private Button accept, reject;
	private long friendId;
	public int pluginType = 1;
	public static IncomingCallActivity incomingCallActivity;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		incomingCallActivity = this;
		setContentView(R.layout.activity_incoming_call);
		accept = (Button) findViewById(R.id.buttonCallAccept);
		reject = (Button) findViewById(R.id.buttonCallReject);

		Intent intent = getIntent();
		friendId = intent.getLongExtra("user_id", 0);
		pluginType = intent.getIntExtra("pluginType", 1);

		final AVChat avchat = AVChat.getAVChatInstance(this);
		final AudioChat audioChat = AudioChat.getInstance(this);

		accept.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				if (pluginType == 0) {
					audioChat.acceptAudioChatRequest(String.valueOf(friendId), new Callbacks() {

						@Override
						public void successCallback(JSONObject response) {
							Logger.error("accpet sucess");

						}

						@Override
						public void failCallback(JSONObject response) {
							Logger.debug("call accept error");
						}
					});

				} else {
					avchat.acceptAVChatRequest(String.valueOf(friendId), new Callbacks() {

						@Override
						public void successCallback(JSONObject response) {
							Logger.error("accpet sucess");

						}

						@Override
						public void failCallback(JSONObject response) {
							Logger.debug("call accept error");
						}
					});
				}
				Intent i = new Intent(getApplicationContext(), AVChatActivity.class);
				i.putExtra("user_id", String.valueOf(friendId));
				i.putExtra("pluginType", pluginType);
				startActivity(i);
				finish();

			}
		});

		reject.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				if (SharedPreferenceHelper.contains(SharedPreferenceKeys.CALLID)) {
					if (pluginType == 0) {
						audioChat.rejectAudioChatRequest(String.valueOf(friendId),
								SharedPreferenceHelper.get(SharedPreferenceKeys.CALLID), new Callbacks() {

									@Override
									public void successCallback(JSONObject response) {

									}

									@Override
									public void failCallback(JSONObject response) {

									}
								});
						finish();
					} else {
						avchat.rejectAVChatRequest(String.valueOf(friendId),
								SharedPreferenceHelper.get(SharedPreferenceKeys.CALLID), new Callbacks() {

									@Override
									public void successCallback(JSONObject response) {

									}

									@Override
									public void failCallback(JSONObject response) {

									}
								});
						finish();
					}
				}
			}
		});
	}
}
