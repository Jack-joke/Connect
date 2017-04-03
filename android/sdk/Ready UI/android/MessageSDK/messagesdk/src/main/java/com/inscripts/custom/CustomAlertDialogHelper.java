/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.custom;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

import com.inscripts.interfaces.OnAlertDialogButtonClickListener;

public class CustomAlertDialogHelper implements OnClickListener {
	private OnAlertDialogButtonClickListener onAlertDialogButtonClick;

	private View view;

	private AlertDialog alertDialogCreater;

	private int popupId;

	public CustomAlertDialogHelper(Context context, String title, View view, String positiveTitle, String neutralTitle,
			String negativeTitle, OnAlertDialogButtonClickListener onAlertDialogButton, int popUpId) {
		onAlertDialogButtonClick = onAlertDialogButton;
		// LayoutInflater inflater = (LayoutInflater)
		// context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		this.view = view;
		AlertDialog.Builder builder = new AlertDialog.Builder(context);

		builder.setView(view);

		if (!title.equals("")) {
			builder.setTitle(title);
		}

		if (!positiveTitle.equals("")) {
			builder.setPositiveButton(positiveTitle, null);
		}
		if (!negativeTitle.equals("")) {
			builder.setNegativeButton(negativeTitle, null);
		}
		if (!neutralTitle.equals("")) {
			builder.setNeutralButton(neutralTitle, null);
		}

		alertDialogCreater = builder.create();
		alertDialogCreater.show();

		this.popupId = popUpId;

		Button button = alertDialogCreater.getButton(DialogInterface.BUTTON_POSITIVE);
		button.setId(DialogInterface.BUTTON_POSITIVE);
		button.setOnClickListener(this);

		button = alertDialogCreater.getButton(DialogInterface.BUTTON_NEGATIVE);
		button.setId(DialogInterface.BUTTON_NEGATIVE);
		button.setOnClickListener(this);

		button = alertDialogCreater.getButton(DialogInterface.BUTTON_NEUTRAL);
		button.setId(DialogInterface.BUTTON_NEUTRAL);
		button.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		onAlertDialogButtonClick.onButtonClick(alertDialogCreater, view, v.getId(), popupId);
	}

}
