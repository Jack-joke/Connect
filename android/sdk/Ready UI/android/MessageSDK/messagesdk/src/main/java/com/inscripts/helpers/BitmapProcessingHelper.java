/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.graphics.Rect;
import android.graphics.RectF;
import android.media.ExifInterface;
import android.net.Uri;
import android.text.TextUtils;

import java.io.File;

/**
 * Custom implementation to rescale an image taken from the camera.
 */
public class BitmapProcessingHelper {

    public static Bitmap createBitmap(String path, boolean isCameraImage) {
        Bitmap image = null;
        try {
            if (isCameraImage) {
                BitmapFactory.Options options = new BitmapFactory.Options();
                options.inSampleSize = 2;
                image = BitmapFactory.decodeFile(path, options);
            } else {
                image = BitmapFactory.decodeFile(path);
            }
        } catch (OutOfMemoryError e) {
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.inSampleSize = 2;
            image = BitmapFactory.decodeFile(path, options);
            e.printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
        if (image != null) {
            image = scaleBitmap(image, image.getHeight(), image.getWidth(), path);
            if (image == null) {
                return null;
            }
            return image;
        } else {
            // int imageHeight = options.outHeight, imageWidth =
            // options.outWidth;
            // imageWidth+" path="+path);
            // Bitmap newImage = scaleBitmap(image, imageHeight, imageWidth,
            // path);
            // if (newImage == null) {
            // return null;
            // }
            return null;
        }
    }

    public static Bitmap scaleBitmap(Bitmap image, int imageHeight, int imageWidth, String filePath) {
        Bitmap bitmapnew;
        Bitmap rotatedBmp;
        BitmapFactory.Options options = new BitmapFactory.Options();
        double dwidth, dheight;
        options.inJustDecodeBounds = true;
        try {
            if ((imageHeight > imageWidth) && (imageHeight > 800)) {
                dwidth = ((double) imageWidth / (double) imageHeight) * 800;
                dheight = 800;
            } else if ((imageWidth > imageHeight) && (imageWidth > 800)) {
                dheight = ((double) imageHeight / (double) imageWidth) * 800;
                dwidth = 800;
            } else {
                dheight = imageHeight;
                dwidth = imageWidth;
                if ((imageHeight == imageWidth) && imageHeight > 800) {
                    dheight = dwidth = 800;
                }
            }

			/*
             * int scaleRatio = calculateInSampleSize(options, (int) dwidth,
			 * (int) dheight); options.inSampleSize = scaleRatio;
			 * options.inPurgeable = true; options.inInputShareable = true;
			 * options.inJustDecodeBounds = false; Bitmap newImage =
			 * BitmapFactory.decodeFile(filePath, options);
			 */
            bitmapnew = Bitmap.createScaledBitmap(image, (int) dwidth, (int) dheight, true);
            if (bitmapnew == null) {
                return null;
            }
            Matrix matrix = new Matrix();
            matrix.postRotate(getCameraPhotoOrientation(PreferenceHelper.getContext(), Uri.parse(filePath), filePath));
            try {
                rotatedBmp = Bitmap.createBitmap(bitmapnew, 0, 0, bitmapnew.getWidth(), bitmapnew.getHeight(), matrix,
                        true);
            } catch (OutOfMemoryError e) {
                rotatedBmp = Bitmap.createBitmap(bitmapnew, 0, 0, bitmapnew.getWidth() / 2, bitmapnew.getHeight() / 2,
                        matrix, true);
            }

            if (rotatedBmp == null) {
                return null;
            }
            return rotatedBmp;
        } catch (OutOfMemoryError e) {
            e.printStackTrace();
        }
        return null;
    }

    public static Bitmap getRoundedCroppedBitmap(Bitmap bitmap, int radius) {
        Bitmap finalBitmap;
        if (bitmap.getWidth() != radius || bitmap.getHeight() != radius)
            finalBitmap = Bitmap.createScaledBitmap(bitmap, bitmap.getWidth(), bitmap.getHeight(),
                    false);
        else
            finalBitmap = bitmap;
        Bitmap output = Bitmap.createBitmap(finalBitmap.getWidth(),
                finalBitmap.getHeight(), Bitmap.Config.ARGB_8888);
        Canvas canvas = new Canvas(output);

        final Paint paint = new Paint();
        final Rect rect = new Rect(0, 0, finalBitmap.getWidth(),
                finalBitmap.getHeight());

        final RectF rectf = new RectF(0, 0, finalBitmap.getWidth(),
                finalBitmap.getHeight());

        paint.setAntiAlias(true);
        paint.setFilterBitmap(true);
        paint.setDither(true);
        canvas.drawARGB(10,10,0,0);
        //Set Required Radius Here
        canvas.drawRoundRect(rectf, radius, radius, paint);
        paint.setXfermode(new PorterDuffXfermode(PorterDuff.Mode.SRC_IN));
        canvas.drawBitmap(finalBitmap, rect, rect, paint);

        return output;
    }

    public static Bitmap addBorderToRoundedBitmap(Bitmap srcBitmap, int cornerRadius, int borderWidth, int borderColor){
        // We will hide half border by bitmap
        borderWidth = borderWidth*2;

        // Initialize a new Bitmap to make it bordered rounded bitmap
        Bitmap dstBitmap = Bitmap.createBitmap(
                srcBitmap.getWidth() + borderWidth, // Width
                srcBitmap.getHeight() + borderWidth, // Height
                Bitmap.Config.ARGB_8888 // Config
        );

        // Initialize a new Canvas instance
        Canvas canvas = new Canvas(dstBitmap);

        // Initialize a new Paint instance to draw border
        Paint paint = new Paint();
        paint.setColor(borderColor);
        paint.setStyle(Paint.Style.STROKE);
        paint.setStrokeWidth(borderWidth);
        paint.setAntiAlias(true);

        // Initialize a new Rect instance
        Rect rect = new Rect(
                borderWidth/2,
                borderWidth/2,
                dstBitmap.getWidth() - borderWidth/2,
                dstBitmap.getHeight() - borderWidth/2
        );


        RectF rectF = new RectF(rect);


        canvas.drawRoundRect(rectF,cornerRadius,cornerRadius,paint);


        canvas.drawBitmap(srcBitmap, borderWidth / 2, borderWidth / 2, null);

        srcBitmap.recycle();


        return dstBitmap;
    }

	/*
     * private static int calculateInSampleSize(BitmapFactory.Options options,
	 * int reqWidth, int reqHeight) { // Raw height and width of image final int
	 * height = options.outHeight; final int width = options.outWidth; int
	 * inSampleSize = 1;
	 * 
	 * if (height > reqHeight || width > reqWidth) {
	 * 
	 * // Calculate ratios of height and width to requested height and // width
	 * 
	 * final int heightRatio = Math.round((float) height / (float) reqHeight);
	 * final int widthRatio = Math.round((float) width / (float) reqWidth);
	 * 
	 * // Choose the smallest ratio as inSampleSize value, this will guarantee
	 * // a final image with both dimensions larger than or equal to the //
	 * requested height and width. inSampleSize = heightRatio < widthRatio ?
	 * heightRatio : widthRatio;
	 * 
	 * final int halfHeight = height / 2; final int halfWidth = width / 2;
	 * 
	 * // Calculate the largest inSampleSize value that is a power of 2 and //
	 * keeps both // height and width larger than the requested height and
	 * width. while ((halfHeight / inSampleSize) > reqHeight && (halfWidth /
	 * inSampleSize) > reqWidth) { inSampleSize *= 2; } } return inSampleSize; }
	 */

    private static int getCameraPhotoOrientation(Context context, Uri imageUri, String imagePath) {
        int rotate = 0;
        try {
            if (imageUri != null && !TextUtils.isEmpty(imagePath)) {
                context.getContentResolver().notifyChange(imageUri, null);
                File imageFile = new File(imagePath);
                ExifInterface exif = new ExifInterface(imageFile.getAbsolutePath());
                int orientation = exif.getAttributeInt(ExifInterface.TAG_ORIENTATION, ExifInterface.ORIENTATION_NORMAL);

                switch (orientation) {
                    case ExifInterface.ORIENTATION_ROTATE_270:
                        rotate = 270;
                        break;
                    case ExifInterface.ORIENTATION_ROTATE_180:
                        rotate = 180;
                        break;
                    case ExifInterface.ORIENTATION_ROTATE_90:
                        rotate = 90;
                        break;
                }
            } else {
                rotate = 0;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } catch (OutOfMemoryError e) {
            e.printStackTrace();
        }

        return rotate;
    }
}
