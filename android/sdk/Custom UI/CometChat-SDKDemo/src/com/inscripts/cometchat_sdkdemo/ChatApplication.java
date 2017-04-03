package com.inscripts.cometchat_sdkdemo;

import android.content.Context;
import android.support.multidex.MultiDex;
import android.support.multidex.MultiDexApplication;

import com.parse.Parse;

public class ChatApplication extends MultiDexApplication {

	@Override
	public void onCreate() {
		super.onCreate();
		try {
			Parse.initialize(this, "JTsXPoBuAIgZnxkIQVcfXIY6ntiCXzTIa44L1b9i",
					"HMJ8W3d3gn77j1W3XQlwyyjPqnIuqWQyKPVhXajk");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	@Override
	protected void attachBaseContext(Context base) {
		super.attachBaseContext(base);
		MultiDex.install(this);
	}

}
