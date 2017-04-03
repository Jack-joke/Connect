package com.inscripts.cometchat_sdkdemo;

import org.json.JSONObject;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.cometchat_sdkdemo.R;
import com.inscripts.helper.Keys.SharedPreferenceKeys;
import com.inscripts.helper.SharedPreferenceHelper;

public class UrlScreenActivity extends ActionBarActivity {

	private Button nextBtn;
	private EditText urlField;
	// private EditText apikeyField;
	private ProgressBar loader;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_url_screen);
		nextBtn = (Button) findViewById(R.id.buttonNext);

		loader = (ProgressBar) findViewById(R.id.progressBarLoader);
		SharedPreferenceHelper.initialize(this);

		/*apikeyField = (EditText) findViewById(R.id.editTextUrlField);
		apikeyField.setHint("Enter API-key");
		apikeyField.setText("10108xbe8e430df890202085ea36a364745175");*/

		urlField = (EditText) findViewById(R.id.editTextUrlField);
		urlField.setText("http://blogish.pttestdrive.com/cometchat/");

		SharedPreferenceHelper.save(SharedPreferenceKeys.API_KEY, "7808ebda5f6c611695c58f0911e9ff6f");

		nextBtn.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {

				// Get API-key for COD

				/*String apikey = apikeyField.getText().toString().trim();
				if (TextUtils.isEmpty(apikey)) {
					apikeyField.setError("Please enter apikey");
				} else {
					Intent intent = new Intent(UrlScreenActivity.this, LoginTypeActivity.class);
					SharedPreferenceHelper.save(SharedPreferenceKeys.API_KEY, apikey);
					startActivity(intent);
				}*/

				// Get url for without COD

				String url = urlField.getText().toString().trim();
				if (TextUtils.isEmpty(url)) {
					urlField.setError("Please enter url");
				} else {
					Intent intent = new Intent(UrlScreenActivity.this, LoginTypeActivity.class);
					SharedPreferenceHelper.save(SharedPreferenceKeys.SITE_URL, url);
					startActivity(intent);
				}

			}
		});

		boolean isLoggedin = SharedPreferenceHelper.contains(SharedPreferenceKeys.IS_LOGGEDIN)
				&& SharedPreferenceHelper.get(SharedPreferenceKeys.IS_LOGGEDIN).equals("1");
		if (isLoggedin) {
			nextBtn.setVisibility(View.INVISIBLE);

			loader.setVisibility(View.VISIBLE);

			String logintype = SharedPreferenceHelper.get(SharedPreferenceKeys.LOGIN_TYPE);
			String userName = SharedPreferenceHelper.get(SharedPreferenceKeys.USER_NAME);

			/*apikeyField.setVisibility(View.INVISIBLE);
			String apikey = SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY);
			CometChat chat = CometChat.getInstance(getApplicationContext(),
					SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY));*/

			urlField.setVisibility(View.INVISIBLE);
			String siteurl = SharedPreferenceHelper.get(SharedPreferenceKeys.SITE_URL);
			CometChat chat = CometChat.getInstance(getApplicationContext(),
					SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY));

			if (logintype.equals("2")) {
				// Login with username and password
				String password = SharedPreferenceHelper.get(SharedPreferenceKeys.PASSWORD);

				/*chat.login(userName, password, new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						startCometChatActivity();
					}

					@Override
					public void failCallback(JSONObject response) {
						loader.setVisibility(View.INVISIBLE);
						nextBtn.setVisibility(View.VISIBLE);

						apikeyField.setVisibility(View.VISIBLE);

						Toast.makeText(getApplicationContext(), "Some error occured at login", Toast.LENGTH_SHORT)
								.show();
					}
				});*/

				chat.login(siteurl, userName, password, new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						startCometChatActivity();
					}

					@Override
					public void failCallback(JSONObject response) {
						loader.setVisibility(View.INVISIBLE);
						nextBtn.setVisibility(View.VISIBLE);

						urlField.setVisibility(View.VISIBLE);

						Toast.makeText(getApplicationContext(), "Some error occured at login", Toast.LENGTH_SHORT)
								.show();
					}
				});

			} else if (logintype.equals("1")) {
				/*chat.login(userName, new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						startCometChatActivity();

					}

					@Override
					public void failCallback(JSONObject response) {
						loader.setVisibility(View.INVISIBLE);
						nextBtn.setVisibility(View.VISIBLE);

						Toast.makeText(getApplicationContext(), "Some error occured at login", Toast.LENGTH_SHORT)
								.show();

					}
				});*/

				chat.login(siteurl, userName, new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						startCometChatActivity();

					}

					@Override
					public void failCallback(JSONObject response) {
						loader.setVisibility(View.INVISIBLE);
						nextBtn.setVisibility(View.VISIBLE);

						Toast.makeText(getApplicationContext(), "Some error occured at login", Toast.LENGTH_SHORT)
								.show();

					}
				});
			} /*else {
				/*Guest login
				
				You don't need to call login again if you have logged in as
				guest, because if you call login again with guest then you will
				be recognized as different user by CometChat

				startCometChatActivity();
				}*/

		}
	}

	public void startCometChatActivity() {
		loader.setVisibility(View.INVISIBLE);
		Intent intent = new Intent(this, CometChatActivity.class);
		intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		startActivity(intent);
		finish();
	}
}
