/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.custom;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;

public class ConfirmationWindow {

	private AlertDialog.Builder builder;

	public ConfirmationWindow(Context context, String positiveTitle, String negativeTitle) {
		builder = new AlertDialog.Builder(context);
		if (!positiveTitle.equals("")) {
			builder.setPositiveButton(positiveTitle, new DialogInterface.OnClickListener() {

				@Override
				public void onClick(DialogInterface dialog, int which) {
					setPositiveResponse();

				}
			});
		}
		if (!negativeTitle.equals("")) {
			builder.setNegativeButton(negativeTitle, new DialogInterface.OnClickListener() {

				@Override
				public void onClick(DialogInterface dialog, int which) {
					setNegativeResponse();
				}
			});
		}

	}

	public AlertDialog.Builder setMessage(String message) {
		return builder.setMessage(message);
	}

	public void setCancelable(boolean flag) {
		if (builder != null) {
			builder.setCancelable(flag);
		}
	}

	public void show() {
		final AlertDialog alertDialogCreater =  builder.create();
		alertDialogCreater.setOnShowListener(new DialogInterface.OnShowListener() {
			@Override
			public void onShow(DialogInterface dialogInterface) {
				alertDialogCreater.getButton(android.support.v7.app.AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
				alertDialogCreater.getButton(android.support.v7.app.AlertDialog.BUTTON_POSITIVE).setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
			}
		});

		builder.show();
	}

	protected void setPositiveResponse() {
	}

	protected void setNegativeResponse() {
	}



}