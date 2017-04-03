/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;

import com.inscripts.R;


public class CustomActivity extends SuperActivity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.cc_cometchat_activity_menu, menu);
		setActionBarImage();
		return true;
	}

}
