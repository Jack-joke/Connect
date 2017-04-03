/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageView;

import com.inscripts.R;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;

import uk.co.senab.photoview.PhotoViewAttacher;

public class ImagePreviewActivity extends Activity {

	private PhotoViewAttacher mAttacher;
	private ImageView previewImage;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.cc_custom_image_preview);
		Intent intent = getIntent();
		String msg = intent.getStringExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE);

		previewImage = (ImageView) findViewById(R.id.imageViewLargePreview);
		Bitmap image = BitmapFactory.decodeFile(msg);
		if (image != null) {
			previewImage.setImageBitmap(image);
		} else {
			Logger.error("Image is null onclick for preview ");
		}

		mAttacher = new PhotoViewAttacher(previewImage);

		ImageView closePreview = (ImageView) findViewById(R.id.imageViewClosePreviewPopup);

		closePreview.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View view) {
				finish();
			}
		});
	}
}
