/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

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
import android.widget.Toast;

import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.FileDownloadHelper;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.Conversation;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import java.io.File;
import java.io.FileDescriptor;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;

public class VideoSharing {

    private static final String TAG = VideoSharing.class.getSimpleName();
    private static String fileName;

    public static boolean isIncomingVideo(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CLASS) && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.VIDEO_MESSAGE_CSS_CLASS);
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
                        Logger.error(TAG,"Video ajax=" + msg);
                        try {
                            String messageId = msg.obj.toString();
                            if (isChatroom) {
                                if(messageId.contains("jqcc")){
                                    JSONObject imageJson = new JSONObject(messageId);
                                    String jqcc = imageJson.getString("callback");
                                    jqcc = jqcc.replace("jqcc","");
                                    String[] strings = jqcc.split("_");
                                    long localId = Long.parseLong(strings[2]);
                                    long imei = Long.parseLong(strings[0]);
                                    Logger.error(TAG,"local id = "+localId);
                                    Logger.error(TAG,"imei = "+imei);
                                    if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                        ChatroomMessage mess = ChatroomMessage.findByLocalId(String.valueOf(localId));
                                        if(mess != null){
                                            mess.remoteId = imageJson.getLong("id");
                                            mess.save();

                                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                            PreferenceHelper.getContext().sendBroadcast(intent);
                                        }

                                    }
                                }else{
                                    addChatroomMessage(Long.valueOf(messageId), windowId, fileName, storagePath);
                                }
                            } else {
                                if(messageId.contains("jqcc")){
                                    JSONObject imageJson = new JSONObject(messageId);
                                    String jqcc = imageJson.getString("callback");
                                    jqcc = jqcc.replace("jqcc","");
                                    String[] strings = jqcc.split("_");
                                    long localId = Long.parseLong(strings[2]);
                                    long imei = Long.parseLong(strings[0]);
                                    if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                        OneOnOneMessage mess = OneOnOneMessage.findByLocalId(localId);
                                        if(mess != null){
                                            mess.remoteId = imageJson.getLong("id");
                                            mess.save();
                                        }

                                        Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                        PreferenceHelper.getContext().sendBroadcast(intent);
                                    }
                                }else{
                                    addOneOnOneMessage(messageId, windowId, fileName, storagePath);
                                }
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                //FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
                String callback ="";
                if(!isChatroom){
                    long msgId = addOneOnOneMessage(windowId, fileName, storagePath);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgId;
                }else {
                    long msgid = addChatroomMessage(windowId);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgid;
                }

                Logger.error(TAG,"Video Callback value = "+callback);
                ImageUploadHelper videoSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                        URLFactory.getFileUploadURL()+callback, handler);
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

            message.message = storagePath + fileName;
            message.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            message.save();
        }
    }

    private static long addOneOnOneMessage(long toId, String fileName, String storagePath){
        OneOnOneMessage message = new OneOnOneMessage();
        message.remoteId = 0L;
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

        Logger.error(TAG,"OneOnOneMessage send Audio Message send");
        if(Conversation.isNewBuddyConversation(String.valueOf(toId))){
            Logger.error(TAG,"Is New Conversation");
            Conversation conversation = new Conversation();
            conversation.buddyID = toId;
            conversation.timestamp = System.currentTimeMillis();
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.VIDEO;
            Buddy buddy = Buddy.getBuddyDetails(toId);
            if(buddy != null){
                conversation.name =buddy.name;
                conversation.avtarUrl =buddy.avatarURL;
            }
            conversation.save();
        }else{
            Logger.error(TAG,"Is old Conversation");
            Conversation conversation = Conversation.getConversationByBuddyID(String.valueOf(toId));
            if(conversation != null){
                conversation.timestamp = System.currentTimeMillis();
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.VIDEO;
                Buddy buddy = Buddy.getBuddyDetails(toId);
                if(buddy != null){
                    conversation.name =buddy.name;
                    conversation.avtarUrl =buddy.avatarURL;
                }
                conversation.save();
            }
        }
        return message.getId();
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

    private static long addChatroomMessage(long chatroomID){
        ChatroomMessage messagePojo = new ChatroomMessage(0L, SessionData.getInstance().getId(), chatroomID,
                LocalStorageFactory.getVideoStoragePath() + fileName, System.currentTimeMillis(),
                StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED, "", "#000000", 1);
        messagePojo.save();
        new Handler().post(new Runnable() {
            @Override
            public void run() {
                // Code here will run in UI thread
                Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                PreferenceHelper.getContext().sendBroadcast(intent);
            }
        });

        if(Conversation.isNewChatroomConversation(String.valueOf(chatroomID))){
            Logger.error(TAG,"Is New Chatroom Conversation");
            Conversation conversation = new Conversation();
            conversation.chatroomID = chatroomID;
            conversation.timestamp = System.currentTimeMillis() ;
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.VIDEO;
            Chatroom chatroom = Chatroom.getChatroomDetails(chatroomID);
            if(chatroom != null)
                conversation.name = chatroom.name;
            else
                conversation.name = "Chatroom";

            conversation.avtarUrl = "";
            conversation.save();
        }else{
            Logger.error(TAG,"Is old chatroom Conversation");
            Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(chatroomID));
            if(conversation != null){
                conversation.timestamp = System.currentTimeMillis() ;
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.VIDEO;
                Chatroom chatroom = Chatroom.getChatroomDetails(chatroomID);
                if(chatroom != null)
                    conversation.name = chatroom.name;
                else
                    conversation.name = "Chatroom";

                conversation.avtarUrl = "";
                conversation.save();
            }
        }

        return messagePojo.getId();
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
