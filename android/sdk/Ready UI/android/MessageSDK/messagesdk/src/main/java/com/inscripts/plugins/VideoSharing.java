/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.media.ThumbnailUtils;
import android.net.Uri;
import android.os.Build;
import android.os.Handler;
import android.os.Message;
import android.os.ParcelFileDescriptor;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.text.TextUtils;
import android.widget.Toast;

import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.FileDownloadHelper;
import com.inscripts.helpers.FileUploadHelper;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.File;
import java.io.FileDescriptor;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;

public class VideoSharing {

    private static String fileName;

    public static boolean isIncomingVideo(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CLASS) && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.VIDEO_MESSAGE_CSS_CLASS);
    }

    public static String getVideoURL(String message) {

		/* * URL is received as //siteurl/cometchat/cometchat/plugins/filetransfer
		 * /download.php?file=Emoticon128.png*/

        Document doc = Jsoup.parseBodyFragment(message);
        Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
        String relHref = link.attr(StaticMembers.HREF), websiteUrl = URLFactory.getWebsiteURL();
        if (!relHref.contains(URLFactory.PROTOCOL_PREFIX)) {
            if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX)) {
                relHref = URLFactory.PROTOCOL_PREFIX + relHref;
            } else if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
                relHref = URLFactory.PROTOCOL_PREFIX_SECURE + relHref;
            } else {
                relHref = URLFactory.PROTOCOL_PREFIX + relHref;
            }
        } else if (!relHref.contains(websiteUrl)) {
            relHref = websiteUrl + relHref;
        }

        if (relHref.contains("////")) {
            relHref = relHref.replace("////", "//");
        }

        if(relHref.contains("///")){
            relHref = relHref.replace("///", "//");
        }
        return relHref;
    }

    public static boolean isIncomingChatroomVideo(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CLASS) && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.VIDEO_MESSAGE_CSS_CLASS);
    }

    public static boolean isDisabled() {
        return JsonPhp.getInstance().getFiletransferEnabled().equals("0");
    }

    public static boolean isCrDisabled() {
        return JsonPhp.getInstance().getCrfiletransferEnabled().equals("0");
    }

    public static void downloadAndStoreVideo(String remoteId, String videoRemoteURL, boolean isChatroom, boolean isNormalFile) {
        try {
            if (isNormalFile) {
                if (isChatroom) {
                    new FileDownloadHelper().execute(remoteId, videoRemoteURL, CHATROOM_VIDEO, "0", "1");
                } else {
                    new FileDownloadHelper().execute(remoteId, videoRemoteURL, ONE_ON_ONE_VIDEO, "0", "1");
                }

            } else {
                if (isChatroom) {
                    //Params are Remoteid, URL, is Chatroom, 1=>Video to be downloaded, 1=> Normal file to be downloaded
                    new FileDownloadHelper().execute(remoteId, videoRemoteURL, CHATROOM_VIDEO, "1", "0");
                } else {
                    new FileDownloadHelper().execute(remoteId, videoRemoteURL, ONE_ON_ONE_VIDEO, "1", "0");
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String CHATROOM_VIDEO = "1";
    public static String ONE_ON_ONE_VIDEO = "0";

    /**
     * @param data    Data received from gallery intent
     * @param buddyId id of user to whom video to be sent
     */
    public static void sendVideoOneOnOne(Activity activity, Intent data, long buddyId) {
        sendVideo(activity, data, buddyId, false);
    }

    public static void sendVideoOneOnOne(Activity activity, String filePath, long buddyId) {
        sendVideo(activity, filePath, buddyId, false);
    }

    /**
     * @param data       Data received from gallery intent
     * @param chatroomId Chatroom id in which video is sent
     */
    public static void sendVideoChatroom(Activity activity, Intent data, long chatroomId) {
        sendVideo(activity, data, chatroomId, true);
    }

    public static void sendVideoChatroom(Activity activity, String filePath, long chatroomId) {
        sendVideo(activity, filePath, chatroomId, true);
    }

    /**
     * @param videoFile
     *            Video file to be sent
     * @param windowId
     *            To id / Chatroom id
     * @param isChatroom
     *            Boolean value to specify video to be sent in chatroom or not
     */
    @SuppressLint("HandlerLeak")
    public void sendVideoAjax(final File videoFile, final String windowId, final boolean isChatroom,
                              final Callbacks callbacks) {
        try {
            Handler handler = new Handler() {

                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    try {
                        String messageId = msg.obj.toString();
                        if (!TextUtils.isEmpty(messageId)) {
                            JSONObject success = new JSONObject();
                            success.put(CometChatKeys.AjaxKeys.ID, messageId);
                            success.put(CometChatKeys.AjaxKeys.ORIGINAL_FILE, videoFile);
                            callbacks.successCallback(success);
                        } else {
                            JSONObject failed = new JSONObject();
                            callbacks.failCallback(failed);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                        callbacks.failCallback(CommonUtils.createErrorJson(
                                CometChatKeys.ErrorKeys.CODE_RANDOM_EXCEPTION,
                                CometChatKeys.ErrorKeys.MESSAGE_RANDOM_EXCEPTION));
                    }
                }
            };

            FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
            videoSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 512);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 512);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                    .getName());
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, videoFile.getName());
            videoSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, videoFile);
            videoSendHelper.sendCallBack(false);

            if (isChatroom) {
                videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                        CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
            }
            videoSendHelper.execute();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static void sendVideo(Activity activity, String filePath, final long windowId, final boolean isChatroom) {
        try {
            File sourceFile = new File(filePath);

            if (sourceFile.length() <= LocalConfig.getFileUploadLimit()) {
                fileName = filePath.substring(filePath.lastIndexOf("/") + 1, filePath.length());
                fileName = fileName.replaceAll("-", "").replaceAll(" ", "_")
                        .replaceAll(fileName.substring(0, fileName.indexOf("_") + 1), "");

                final String storagePath = LocalStorageFactory.getVideoStoragePath();
                File videoToSendFIle = LocalStorageFactory.copyFile(sourceFile, fileName, storagePath);

                Handler handler = new Handler() {

                    @Override
                    public void handleMessage(Message msg) {
                        super.handleMessage(msg);
                        try {
                            String messageId = msg.obj.toString();
                            if (isChatroom) {
                                addChatroomMessage(Long.valueOf(messageId), windowId, fileName, storagePath);
                            } else {
                                addOneOnOneMessage(messageId, windowId, fileName, storagePath);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                //FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
                ImageUploadHelper videoSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                        URLFactory.getFileUploadURL(), handler);
                videoSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
                videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 512);
                videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 512);
                videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                        .getName());
                videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, fileName);
                videoSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, videoToSendFIle);
                videoSendHelper.sendCallBack(false);

                if (isChatroom) {
                    videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                            CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
                }
                videoSendHelper.sendImageAjax();
            } else {
                Toast.makeText(activity, "File size limit exceeded. Cannot send this video.", Toast.LENGTH_LONG).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * @param data       Data received from Gallery intent or camera intent
     * @param windowId   user id or chatrom id to whom video is to be sent
     * @param isChatroom Set true if video is sent from chatroom , else false
     */
    @TargetApi(Build.VERSION_CODES.KITKAT)
    private static void sendVideo(Activity activity, Intent data, long windowId, boolean isChatroom) {
        String videoPath = LocalStorageFactory.getVideoStoragePath();
        if (CommonUtils.isSamsung()) {
            sendVideo(activity, LocalStorageFactory.getFilePathFromIntent(data), windowId, isChatroom);
        } else if (CommonUtils.isXiaomi()) {
            if (PreferenceHelper.contains(PreferenceKeys.UserKeys.VIDEO_FILE_NAME)) {
                File file = new File(videoPath + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4");
                if (file.exists()) {
                    sendVideo(activity, videoPath + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4", windowId, isChatroom);
                    PreferenceHelper.removeKey(PreferenceKeys.UserKeys.VIDEO_FILE_NAME);
                } else {
                    sendVideo(activity, LocalStorageFactory.getFilePathFromIntent(data), windowId, isChatroom);
                }
            } else {
                sendVideo(activity, LocalStorageFactory.getFilePathFromIntent(data), windowId, isChatroom);
            }
        } else if (Build.VERSION.SDK_INT > 19) {
            try {
                sendVideo(activity, LocalStorageFactory.getPath(data.getData(), false), windowId, isChatroom);
            } catch (Exception e1) {
                if (PreferenceHelper.contains(PreferenceKeys.UserKeys.VIDEO_FILE_NAME)) {
                    File file = new File(videoPath + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4");
                    if (file.exists()) {
                        sendVideo(activity, videoPath + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4", windowId, isChatroom);
                    }
                }
            }
        } else {
            Uri imageUri = data.getData();
            String wholeID = DocumentsContract.getDocumentId(imageUri);
            String id = wholeID.split(":")[1];

            String[] column = {MediaStore.Images.Media.DATA};
            String sel = MediaStore.Video.Media._ID + "=?";

            Cursor cursor = PreferenceHelper.getContext().getContentResolver().
                    query(MediaStore.Video.Media.EXTERNAL_CONTENT_URI,
                            column, sel, new String[]{id}, null);
            int columnIndex = cursor.getColumnIndex(column[0]);
            String filePath = "";
            if (cursor.moveToFirst()) {
                filePath = cursor.getString(columnIndex);
            }
            cursor.close();
            sendVideo(activity, filePath, windowId, isChatroom);
        }
    }

    private static void addOneOnOneMessage(String messageId, long toId, String fileName, String storagePath) {

        OneOnOneMessage message = OneOnOneMessage.findById(messageId);

        if (null == message) {

            message = new OneOnOneMessage();
            message.remoteId = Long.parseLong(messageId);
            message.fromId = SessionData.getInstance().getId();
            message.toId = toId;
            message.message = storagePath + fileName;
            message.imageUrl = "";
            message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            message.insertedBy = 1;
            message.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_SENT;
            message.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        } else {
            // message.fromId = SessionData.getInstance().getId();
            // message.toId = toId;
            message.message = storagePath + fileName;
            // message.imageUrl = "";
            // message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            // message.insertedBy = StaticMembers.MSG_INSERTED_BY_RESPONSE;
            message.save();
        }
    }

    private static void addChatroomMessage(Long messageId, long chatroomId, String fileName, String storagePath) {

        ChatroomMessage messagePojo = ChatroomMessage.findById(messageId);

        if (null == messagePojo) {
            messagePojo = new ChatroomMessage(messageId, SessionData.getInstance().getId(), chatroomId,
                    LocalStorageFactory.getVideoStoragePath() + fileName, System.currentTimeMillis(),
                    StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED, "", "#000000", 1);
            messagePojo.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        } else {
            messagePojo.message = storagePath + fileName;
            messagePojo.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
            messagePojo.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        }
    }

    public static Bitmap getVideoBitmap(Uri selectedImageUri, Activity activity) {
        Bitmap bitmap = null;
        String url = selectedImageUri.toString();
        try {
            ParcelFileDescriptor parcelFileDescriptor = activity.getContentResolver()
                    .openFileDescriptor(Uri.parse(url), "r");
            FileDescriptor fileDescriptor = parcelFileDescriptor.getFileDescriptor();
            InputStream inputStream = new FileInputStream(fileDescriptor);

            PreferenceHelper.save(PreferenceKeys.UserKeys.VIDEO_FILE_NAME, System.currentTimeMillis());
            FileOutputStream f = new FileOutputStream(new File(LocalStorageFactory.getVideoStoragePath()
                    + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4"));

            byte[] buffer = new byte[1024];
            int len1 = 0;
            while ((len1 = inputStream.read(buffer)) > 0) {
                f.write(buffer, 0, len1);
            }
            f.close();
            parcelFileDescriptor.close();

            inputStream.close();

            String filename = LocalStorageFactory.getVideoStoragePath() + PreferenceHelper.get(PreferenceKeys.UserKeys.VIDEO_FILE_NAME) + ".mp4";
            bitmap = ThumbnailUtils.createVideoThumbnail(filename, MediaStore.Video.Thumbnails.MICRO_KIND);
        } catch (Exception e1) {
            e1.printStackTrace();
        }
        return bitmap;
    }
}
