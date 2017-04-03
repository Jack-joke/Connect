package com.inscripts.cometchat_sdkdemo;

import java.io.File;

import org.json.JSONObject;

import android.content.Intent;
import android.os.Bundle;
import android.os.Environment;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.inscripts.callbacks.Callbacks;
import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.cometchat_sdkdemo.R;
import com.inscripts.helper.Keys.SharedPreferenceKeys;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helper.SharedPreferenceHelper;
import com.inscripts.utils.Logger;

public class LoginTypeActivity extends ActionBarActivity {

	private Button usernameBtn;

	private Button useridBtn, guestBtn;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_login_type);

		useridBtn = (Button) findViewById(R.id.buttonLoginWithUserid);
		guestBtn = (Button) findViewById(R.id.buttonLoginWithGuest);

		usernameBtn = (Button) findViewById(R.id.buttonLoginWithUsername);
		usernameBtn.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				Intent intent = new Intent(LoginTypeActivity.this, LoginActivity.class);
				SharedPreferenceHelper.save(SharedPreferenceKeys.LOGIN_TYPE, "2");
				startActivity(intent);
			}
		});

		useridBtn.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View arg0) {
				Intent intent = new Intent(LoginTypeActivity.this, LoginActivity.class);
				SharedPreferenceHelper.save(SharedPreferenceKeys.LOGIN_TYPE, "1");
				startActivity(intent);
			}
		});

		guestBtn.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				Intent intent = new Intent(LoginTypeActivity.this, LoginActivity.class);
				SharedPreferenceHelper.save(SharedPreferenceKeys.LOGIN_TYPE, "3");
				startActivity(intent);
			}
		});

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.login_type, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int id = item.getItemId();
		switch (id) {
		case R.id.action_createUser:
			CometChat chat = CometChat.getInstance(getApplicationContext(),
					SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY));
			chat.setCometChatUrl("<your site url>");
			String path = Environment.getExternalStorageDirectory() + File.separator + "wallpaper.png";
			try {
				File imagefile = new File(path);
				chat.createUser("User hoi", "123", "myCoolName", "", imagefile, new Callbacks() {

					@Override
					public void successCallback(JSONObject response) {
						Logger.debug("create user success " + response);
					}

					@Override
					public void failCallback(JSONObject response) {
						Logger.debug("create user fail  " + response);
					}
				});
			} catch (Exception e) {
				e.printStackTrace();
			}
			break;
		default:
			break;

		}
		return super.onOptionsItemSelected(item);
	}

}
