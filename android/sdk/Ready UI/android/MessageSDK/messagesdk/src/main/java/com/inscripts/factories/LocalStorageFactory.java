/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.factories;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.media.MediaScannerConnection;
import android.net.Uri;
import android.os.Build;
import android.os.Handler;
import android.os.Looper;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.provider.MediaStore.MediaColumns;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ImageSpan;
import android.widget.ImageView;

import com.bumptech.glide.DrawableRequestBuilder;
import com.bumptech.glide.Glide;
import com.bumptech.glide.load.resource.bitmap.GlideBitmapDrawable;
import com.bumptech.glide.request.animation.GlideAnimation;
import com.bumptech.glide.request.target.SimpleTarget;
import com.inscripts.R;
import com.inscripts.helpers.BitmapProcessingHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.HeaderImage;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.squareup.picasso.Picasso;
import com.squareup.picasso.Target;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.concurrent.Executors;

public class LocalStorageFactory {

    private static Target target, targetSmiley;
    private static Picasso picasso;
    private static int downloadAttempt = 0;
    private static SimpleTarget simpleTarget,simpleTargetSmiley;

    public static Picasso getPicassoInstance() {
        if (picasso == null) {
            picasso = new Picasso.Builder(PreferenceHelper.getContext()).executor(Executors.newSingleThreadExecutor())
                    .build();
        }
        return picasso;
    }

    public static void LoadImageUsingURL(Context context, String Url, ImageView imgView , int placeHolder){
        Glide.with(context)
                .load(Url)
                .override(800,600)
                .fitCenter()
                .centerCrop()
                .dontAnimate()
                .placeholder(placeHolder)
                .into(imgView);
    }

    private static final String LOCAL_STORAGE_PATH = android.os.Environment.getExternalStorageDirectory() + "/"
            + PreferenceHelper.getContext().getResources().getString(R.string.app_name);

    public static String getImageStoragePath() {
        return LOCAL_STORAGE_PATH + " Images/";
    }

    public static String getWallpaperStoragePath() {
        return LOCAL_STORAGE_PATH + " Wallpaper/";
    }


    public static String getVideoStoragePath() {
        return LOCAL_STORAGE_PATH + " Videos/";
    }

    public static String getAudioStoragePath() {
        return LOCAL_STORAGE_PATH + " Audio/";
    }

    public static String getNormalStoragePath() {
        return LOCAL_STORAGE_PATH + " Files/";
    }

    /* Folder name is prefixed with "." to hide it from file manager and gallery */
    public static String getSmileyStoragePath() {
        return getImageStoragePath() + ".Smileys/";
    }

    public static String getAppLogoStoragePath() {
        return getImageStoragePath() + ".AppLogo/";
    }

    /**
     * <b>Write Image to local storage</b>
     *
     * @param filePath  Path of the file to be saved
     * @param fileName  Name of file
     * @param imageData Data of file to be written in byte[]
     * @return File instance which is written
     */

    public static File writeFile(String filePath, String fileName, byte[] imageData) {
        File file = null;
        FileOutputStream outputStream;
        createDirectory(filePath);
        try {
            file = new File(filePath, fileName);
            outputStream = new FileOutputStream(file);
            outputStream.write(imageData);
            outputStream.close();
            scanFileForGallery(filePath + fileName, false);
        } catch (Exception e) {
            Logger.error("LocalStorageFactory.java writeFile(): Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
        return file;
    }

    /**
     * @param source          Source path of original file
     * @param newFileName     New file name
     * @param destinationPath Destination for where new file to be stored
     */
    public static File copyFile(File source, String newFileName, String destinationPath) {
        try {
            if (source.getAbsolutePath().equals(destinationPath + newFileName)) {
                scanFileForGallery(destinationPath + newFileName, false);
                return source;
            } else {
                createDirectory(destinationPath);

                InputStream in = new FileInputStream(source);
                OutputStream out = new FileOutputStream(destinationPath + newFileName);

                byte[] buf = new byte[512];
                int len;
                while ((len = in.read(buf)) > 0) {
                    //Logger.error("WHILE" + len);
                    out.write(buf, 0, len);
                }

                in.close();
                out.close();
                Logger.error("After closing" + destinationPath + newFileName);
                scanFileForGallery(destinationPath + newFileName, false);
                return new File(destinationPath + newFileName);
            }
        } catch (Exception e) {
            Logger.error("LocalStorageFactory.java copyFile(): Exception = " + e.getMessage());
        }
        return null;
    }

    /**
     * Refresh the gallery content when file is added or deleted
     *
     * @param path     Complete path to the file with filname and extension
     * @param isDelete If file is deleted then set variable true , if new file is
     *                 created then set true
     */
    public static void scanFileForGallery(String path, final boolean isDelete) {
        try {
            // Logger.error("Scan for galery called for file = " + path);
            final Context c = PreferenceHelper.getContext();
            MediaScannerConnection.scanFile(c, new String[]{path}, null,
                    new MediaScannerConnection.OnScanCompletedListener() {
                        @Override
                        public void onScanCompleted(String path, Uri uri) {
                            if (isDelete) {
                                if (uri != null) {
                                    c.getContentResolver().delete(uri, null, null);
                                }
                            }
                        }
                    });
        } catch (Exception e) {
            Logger.error("exception at scanfile " + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    /**
     * @param data Intent data returned from onActivityResult on selecting image
     *             from gallery
     * @return Path of file selected from gallery
     */
    public static String getFilePathFromIntent(Intent data) {
        String filePath = null;
        try {
            Uri selectedImageURI = data.getData();
            if (selectedImageURI != null) {
                // Logger.error("selected image = " +
                // selectedImageURI.getPath());
                // Logger.error("getFilePathFromIntent if");
                String[] filePathColumn = {MediaColumns.DATA};
                Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                        .query(selectedImageURI, filePathColumn, null, null, null);
                cursor.moveToFirst();
                filePath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));
                // Logger.error("Filepath in getfilepathfrom intent = " +
                // filePath);
                cursor.close();
            } else {
                Logger.error("getFilePathFromIntent else " + data.getData());
                filePath = null;
            }
        } catch (Exception e) {
            Logger.error("Exception at get filepath from intent " + e.getLocalizedMessage());
            e.printStackTrace();
        }
        return filePath;
    }

    public static String getPath(Uri uri, boolean isImage) {
        if (uri == null) {
            return null;
        }
        String[] projection;
        String coloumnName, selection;
        if (isImage) {
            selection = MediaStore.Images.Media._ID + "=?";
            coloumnName = MediaStore.Images.Media.DATA;
        } else {
            selection = MediaStore.Video.Media._ID + "=?";
            coloumnName = MediaStore.Video.Media.DATA;
        }
        projection = new String[]{coloumnName};
        Cursor cursor;
        if (Build.VERSION.SDK_INT > 19) {
            // Will return "image:x*"
            String wholeID = DocumentsContract.getDocumentId(uri);
            // Split at colon, use second item in the array
            String id = wholeID.split(":")[1];
            // where id is equal to
            if (isImage) {
                cursor = PreferenceHelper.getContext().getContentResolver().query(MediaStore.Images.Media.EXTERNAL_CONTENT_URI,
                        projection, selection, new String[]{id}, null);
            } else {
                cursor = PreferenceHelper.getContext().getContentResolver().query(MediaStore.Video.Media.EXTERNAL_CONTENT_URI,
                        projection, selection, new String[]{id}, null);
            }
        } else {
            cursor = PreferenceHelper.getContext().getContentResolver().query(uri, projection, null, null, null);
        }
        String path = null;
        try {
            int column_index = cursor.getColumnIndex(coloumnName);
            cursor.moveToFirst();
            path = cursor.getString(column_index);
            cursor.close();
        } catch (Exception e) {
            e.printStackTrace();
            if (CommonUtils.isXiaomi()) {
                try {
                    path = uri.getPath().toString().replace("file://", "");
                } catch (Exception e1) {
                    e1.printStackTrace();
                }

            }
        }
        return path;
    }

    /**
     * @param filePath :Creates directory if not exists for a specified path
     */
    public static void createDirectory(String filePath) {
        if (!new File(filePath).exists()) {
            new File(filePath).mkdirs();
        }
    }

    /**
     * @param fileName  Name of image with extension
     * @param url       Message containing url of image
     * @param imageview Imageview on which image is going to be loaded
     */
    public static void saveIncomingImage(final String fileName, final String url, final ImageView imageview,
                                         final boolean isChatroom, final String messageId, final boolean isHandwrite) {
        try {
            downloadAttempt = 0;
            final String filePath = getImageStoragePath();


            if(!url.contains(".gif")){
                simpleTarget = new SimpleTarget<GlideBitmapDrawable>() {
                    @Override
                    public void onResourceReady(GlideBitmapDrawable bitmapDrawable, GlideAnimation glideAnimation) {
                        try {
                            createDirectory(filePath);

                            Bitmap bitmap = bitmapDrawable.getBitmap();
                            bitmap = BitmapProcessingHelper.scaleBitmap(bitmap, bitmap.getHeight(), bitmap.getWidth(),
                                    filePath);
                            if (null != bitmap) {
                                File file = new File(filePath + fileName);
                                FileOutputStream ostream = new FileOutputStream(file);
                                String fileExtension = fileName.substring(fileName.lastIndexOf(".") + 1);
                                if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
                                    bitmap.compress(Bitmap.CompressFormat.JPEG, 80, ostream);
                                } else {
                                    bitmap.compress(Bitmap.CompressFormat.PNG, 80, ostream);
                                }
                                ostream.close();
                                scanFileForGallery(filePath + fileName, false);
                            }

                            if (isChatroom) {
                                ChatroomMessage pojo = ChatroomMessage.findById(messageId);
                                if (isHandwrite) {
                                    pojo.type = CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED;
                                } else {
                                    pojo.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
                                }
                                pojo.save();

                                Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                PreferenceHelper.getContext().sendBroadcast(intent);
                            } else {
                                OneOnOneMessage temp = OneOnOneMessage.findById(messageId);
                                if (isHandwrite) {
                                    temp.type = CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED;
                                } else {
                                    temp.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
                                }
                                temp.save();

                                Intent intent = new Intent(
                                        BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                PreferenceHelper.getContext().sendBroadcast(intent);
                            }

                        } catch (IOException e) {
                            Logger.error("LocalStorageFactory.java saveIncomingImage()->onBitmapLoaded() : Exception = "
                                    + e.getLocalizedMessage());
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void onLoadFailed(Exception e, Drawable errorDrawable) {
                        super.onLoadFailed(e, errorDrawable);

                        if (downloadAttempt < 1) {

                            DrawableRequestBuilder<String> drawableRequest = Glide.with(PreferenceHelper.getContext())
                                    .load(url)
                                    .placeholder(R.drawable.cc_thumbnail_default)
                                    .override(800,600);

						/* Save image to local storage */
                            drawableRequest.into(simpleTarget);
                        /* Render image to imageview */
                            if (null != imageview) {
                                drawableRequest.into(imageview);
                            }
                            downloadAttempt = 1;
                            Logger.error("2nd attempt");
                        }
                    }

                };

                Handler uiHandler = new Handler(Looper.getMainLooper());
                uiHandler.post(new Runnable() {
                    @Override
                    public void run() {

                        DrawableRequestBuilder<String> drawableRequest = Glide.with(PreferenceHelper.getContext())
                                .load(url)
                                .placeholder(R.drawable.cc_thumbnail_default)
                                .override(800,600);

                        drawableRequest.into(simpleTarget);
                        if (null != imageview) {
                            drawableRequest.into(imageview);
                        }
                    }
                });
            }


/*
            target = new Target() {

                @Override
                public void onPrepareLoad(Drawable drawable) {
                }

                @Override
                public void onBitmapLoaded(Bitmap bitmap, LoadedFrom from) {
                    try {
                        createDirectory(filePath);
                        bitmap = BitmapProcessingHelper.scaleBitmap(bitmap, bitmap.getHeight(), bitmap.getWidth(),
                                filePath);
                        if (null != bitmap) {
                            File file = new File(filePath + fileName);
                            FileOutputStream ostream = new FileOutputStream(file);
                            String fileExtension = fileName.substring(fileName.lastIndexOf(".") + 1);
                            if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
                                bitmap.compress(Bitmap.CompressFormat.JPEG, 80, ostream);
                            } else {
                                bitmap.compress(Bitmap.CompressFormat.PNG, 80, ostream);
                            }
                            ostream.close();
                            scanFileForGallery(filePath + fileName, false);
                        }

                        if (isChatroom) {
                            ChatroomMessage pojo = ChatroomMessage.findById(messageId);
                            if (isHandwrite) {
                                pojo.type = CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED;
                            } else {
                                pojo.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
                            }
                            pojo.save();

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(intent);
                        } else {
                            OneOnOneMessage temp = OneOnOneMessage.findById(messageId);
                            if (isHandwrite) {
                                temp.type = CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED;
                            } else {
                                temp.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
                            }
                            temp.save();

                            Intent intent = new Intent(
                                    BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(intent);
                        }

                    } catch (IOException e) {
                        Logger.error("LocalStorageFactory.java saveIncomingImage()->onBitmapLoaded() : Exception = "
                                + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }

                @Override
                public void onBitmapFailed(Drawable arg0) {
                    if (downloadAttempt < 1) {
                        RequestCreator downloadedImage = getPicassoInstance().load(url)
                                .placeholder(R.drawable.thumbnail_default).resize(800, 600);

                        *//** Temporary code to be continued**//*
                        DrawableRequestBuilder<String> drawableRequest = Glide.with(PreferenceHelper.getContext())
                                                                        .load(url)
                                                                        .placeholder(R.drawable.thumbnail_default)
                                                                        .override(800,600);

						*//* Save image to local storage *//*
                        downloadedImage.into(target);
                        *//* Render image to imageview *//*
                        if (null != imageview) {
                            downloadedImage.into(imageview);
                        }
                        downloadAttempt = 1;
                        Logger.error("2nd attempt");
                    }
                    Logger.error("LocalStorageFactory.java  saveIncomingImage()->onBitmapFailed() ");
                }
            };*/

            // RequestCreator downloadedImage =
            // getPicassoInstance().load(url).placeholder(R.drawable.thumbnail_default);
            /* Save image to local storage */
            // downloadedImage.get();
            // downloadedImage.into(target);
            /* Render image to imageview */
            // downloadedImage.into(imageview);



        } catch (Exception e) {
            Logger.error("LocalStorageFactory.java saveIncomingImage() : Exception =" + e.getLocalizedMessage());
            e.printStackTrace();
        } catch (OutOfMemoryError e) {
            Logger.error("Save incoming image outof memory exception");
        }
    }

    /**
     * @param fileName            Name of smiley obtained from title with ".png" extension
     * @param url                 Url of smiley obtained from src tag of image
     * @param context             Context
     * @param textSpannableString Full received message as spannable string
     * @param startIndex          startIndex of image tag
     * @param endIndex            endIndex of image tag
     * @param emojiSize           Dimension for smiley
     */
    public static void getUnsupportedEmoji(final String fileName, String url, final Context context,
                                           final SpannableString textSpannableString, final int startIndex, final int endIndex, final int emojiSize,
                                           final boolean isChatroom) {


        try {


            simpleTargetSmiley = new SimpleTarget<Bitmap>() {
                @Override
                public void onResourceReady(Bitmap bitmap, GlideAnimation glideAnimation) {
                    try {
                        if (null != bitmap) {
                            Drawable d = new BitmapDrawable(context.getResources(), bitmap);
                            d.setBounds(0, 0, emojiSize, emojiSize);
                            textSpannableString.setSpan(new ImageSpan(d), startIndex, endIndex,
                                    Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                            createDirectory(getSmileyStoragePath());
                            File file = new File(getSmileyStoragePath() + fileName);
                            file.createNewFile();
                            if (null != bitmap) {
                                FileOutputStream ostream = new FileOutputStream(file);
                                bitmap.compress(CompressFormat.PNG, 100, ostream);
                                ostream.close();
                            }

                            if (isChatroom) {
                                Intent intent = new Intent(
                                        BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED, 1);
                                context.sendBroadcast(intent);
                            } else {
                                Intent intent = new Intent(
                                        BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED, 1);
                                context.sendBroadcast(intent);
                                // Logger.error("new smiley intent sent");
                            }
                        } else {
                            return;
                        }
                    } catch (Exception e) {
                        Logger.error("LocalStorageFactory.java getUnsupportedEmoji()->onBitmapLoaded() : Exception = "
                                + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }


                @Override
                public void onLoadFailed(Exception e, Drawable errorDrawable) {
                    Logger.error("Bitmap download failed-> getUnsupportedEmoji() ");
                }
            };

           /* targetSmiley = new Target() {

                @Override
                public void onPrepareLoad(Drawable drawable) {
                }

                @Override
                public void onBitmapLoaded(Bitmap bitmap, LoadedFrom from) {
                    try {
                        if (null != bitmap) {
                            Drawable d = new BitmapDrawable(context.getResources(), bitmap);
                            d.setBounds(0, 0, emojiSize, emojiSize);
                            textSpannableString.setSpan(new ImageSpan(d), startIndex, endIndex,
                                    Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

                            createDirectory(getSmileyStoragePath());
                            File file = new File(getSmileyStoragePath() + fileName);
                            file.createNewFile();
                            if (null != bitmap) {
                                FileOutputStream ostream = new FileOutputStream(file);
                                bitmap.compress(CompressFormat.PNG, 100, ostream);
                                ostream.close();
                            }

                            if (isChatroom) {
                                Intent intent = new Intent(
                                        BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED, 1);
                                context.sendBroadcast(intent);
                            } else {
                                Intent intent = new Intent(
                                        BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED, 1);
                                context.sendBroadcast(intent);
                                // Logger.error("new smiley intent sent");
                            }
                        } else {
                            return;
                        }
                    } catch (Exception e) {
                        Logger.error("LocalStorageFactory.java getUnsupportedEmoji()->onBitmapLoaded() : Exception = "
                                + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }

                @Override
                public void onBitmapFailed(Drawable arg0) {
                    Logger.error("Bitmap download failed-> getUnsupportedEmoji() ");
                }
            };
*/
            Glide.with(PreferenceHelper.getContext()).load(url).into(simpleTargetSmiley);
        } catch (Exception e) {
            Logger.error("LocalStorageFactory.java saveIncomingImage() : Exception =" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    public static void saveAppLogo(final CometchatCallbacks callbacks) {
        try {

            SimpleTarget simpleTargetAppLogo;

            simpleTargetAppLogo = new SimpleTarget<Bitmap>() {
                @Override
                public void onResourceReady(Bitmap bitmap, GlideAnimation<? super Bitmap> glideAnimation) {
                    try {
                        String filePath = getAppLogoStoragePath();
                        String fileName = "cc_logo.png";
                        LocalStorageFactory.createDirectory(filePath);
                        File file = new File(filePath + fileName);
                        file.createNewFile();
                        if (null != bitmap) {
                            FileOutputStream ostream = new FileOutputStream(file);
                            bitmap.compress(CompressFormat.PNG, 100, ostream);
                            ostream.close();
                        }
                        callbacks.successCallback();
                    } catch (Exception e) {
                        Logger.error("LocalStorageFactory.java saveAppLogo()->onBitmapLoaded() Exception="
                                + e.getLocalizedMessage());
                    }
                }

                @Override
                public void onLoadFailed(Exception e, Drawable errorDrawable) {
                    callbacks.successCallback();
                }
            };


          /*
            Target targetAppLogo = new Target() {

                @Override
                public void onPrepareLoad(Drawable arg0) {
                }

                @SuppressLint("NewApi")
                @Override
                public void onBitmapLoaded(Bitmap bitmap, LoadedFrom arg1) {
                    try {
                        String filePath = getAppLogoStoragePath();
                        String fileName = "cc_logo.png";
                        LocalStorageFactory.createDirectory(filePath);
                        File file = new File(filePath + fileName);
                        file.createNewFile();
                        if (null != bitmap) {
                            FileOutputStream ostream = new FileOutputStream(file);
                            bitmap.compress(CompressFormat.PNG, 100, ostream);
                            ostream.close();
                        }
                        callbacks.successCallback();
                    } catch (Exception e) {
                        Logger.error("LocalStorageFactory.java saveAppLogo()->onBitmapLoaded() Exception="
                                + e.getLocalizedMessage());
                    }
                }

                @Override
                public void onBitmapFailed(Drawable arg0) {
                    callbacks.successCallback();
                }
            };*/

            HeaderImage headerImage = JsonPhp.getInstance().getHeaderImage();
            if (null != headerImage) {
                if (!PreferenceHelper.contains(PreferenceKeys.HashKeys.APP_LOGO_TIMESTAMP)) {
                    PreferenceHelper.save(PreferenceKeys.HashKeys.APP_LOGO_TIMESTAMP, "");
                }

                if (!PreferenceHelper.get(PreferenceKeys.HashKeys.APP_LOGO_TIMESTAMP).equals(
                        headerImage.getImageModifiedTime().toString())) {
                    PreferenceHelper.save(PreferenceKeys.HashKeys.APP_LOGO_TIMESTAMP, headerImage.getImageModifiedTime().toString());
                    String url = headerImage.getImagePath() + "?t=" + System.currentTimeMillis();
                    String websiteUrl = URLFactory.getWebsiteURL();
                    if (!url.contains(websiteUrl)) {
                        url = websiteUrl + url;
                    }

                    if (url.contains("////")) {
                        url = url.replace("////", "//");
                    } else if (url.contains("///")) {
                        url = url.replace("///", "//");
                    }
                    Glide.with(PreferenceHelper.getContext()).load(url).into(simpleTargetAppLogo);
                } else {
                    Logger.error("Image timestamp is not changed, we have same image already");
                    callbacks.successCallback();
                }

            } else {
                Logger.error("header image is null");
                callbacks.successCallback();
            }
        } catch (Exception e) {
            Logger.error("LocalStorageFactory.java saveAppLogo() Exception=" + e.getLocalizedMessage());
            callbacks.successCallback();
        }
    }

}
