/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.os.ResultReceiver;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.text.TextUtils;
import android.widget.Toast;

import com.inscripts.activities.R;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.BitmapProcessingHelper;
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
import com.inscripts.services.FileUploadService;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.net.URI;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ImageSharing {

    private static final String TAG = ImageSharing.class.getSimpleName();
    private static String fileName;

    public static boolean isIncomingImage(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CSS_CLASS)
                && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.IMAGE_MESSAGE_CLASS);
    }

    public static boolean isIncomingChatroomImage(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CSS_CLASS)
                && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.IMAGE_MESSAGE_CLASS);
    }

    public static boolean isFileTransfer(String message) {
        return message.contains(StaticMembers.FILETRANSFER_KEY) && message.contains(").");
    }

    public static String getImageURL(String message) {
        /*
         * URL is received as //siteurl/cometchat/cometchat/plugins/filetransfer
		 * /download.php?file=Emoticon128.png
		 */
        Logger.error("Receiver origmai image messgae = "+message);
        Document doc = Jsoup.parseBodyFragment(message);
        Element link = doc.select(StaticMembers.ANCHOR_TAG).first();
        String relHref = link.attr(StaticMembers.HREF), websiteUrl = URLFactory.getWebsiteURL();

        if (!relHref.contains(URLFactory.PROTOCOL_PREFIX) && !relHref.contains(URLFactory.PROTOCOL_PREFIX_SECURE)) {
            if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX)) {
                relHref = URLFactory.PROTOCOL_PREFIX + relHref;
            } else if (websiteUrl.startsWith(URLFactory.PROTOCOL_PREFIX_SECURE)) {
                relHref = URLFactory.PROTOCOL_PREFIX_SECURE + relHref;
            } else {
                relHref = URLFactory.PROTOCOL_PREFIX + relHref;
            }
        } else if (!relHref.contains(websiteUrl)) {
            //relHref = websiteUrl + relHref;
        }

        if (relHref.contains("////")) {
            relHref = relHref.replace("////", "//");
        }
        return relHref;
    }

    public static boolean isDisabled() {
        return JsonPhp.getInstance().getFiletransferEnabled().equals("0");
    }

    public static boolean isCrDisabled() {
        return JsonPhp.getInstance().getCrfiletransferEnabled().equals("0");
    }

    /**
     * @param data    Data received from onActivityResult
     * @param buddyId Buddy id to whom image is to be send
     */
    public void sendImageOneOnOne(Context context, Intent data, Long buddyId) {
        sendImage(context, data, buddyId, false);
    }

    public void sendImageOneOnOne(Context context, Intent data, Long buddyId,  ResultReceiver resultReceiver) {
        Logger.error(TAG,"SendImageOneonOne with uploadCallback = "+resultReceiver);
        sendImage(context, data, buddyId, false,resultReceiver);
    }

    /**
     * @param data       Data received from onActivityResult
     * @param chatroomId Chatroom id to which image is to be send
     */
    public void sendImageChatroom(Context context,Intent data, long chatroomId) {
        sendImage(context, data, chatroomId, true);
    }


    /**
     * Used for sending image from api level 19
     *
     * @param fileUri    URI which is send as extra parameter with intent
     * @param chatroomId buddyid to whom chat is going on
     */
    public void sendImageChatroom(Context context, Uri fileUri, Long chatroomId) {
        sendImage(context, fileUri, chatroomId, true);
    }

    /**
     * Used for sending image from api level 19
     *
     * @param fileUri URI which is send as extra parameter with intent
     * @param buddyId buddyid to whom chatting is going on
     */
    public void sendImageOneOnOne(Context context, Uri fileUri, Long buddyId) {
        sendImage(context, fileUri, buddyId, false);
    }

    /**
     * Send picassa images from gallery
     *
     * @param filename      File name extracted from uri
     * @param picassaBitmap Bitmap of picassa image
     * @param buddyId
     */
    public void sendImageOneOnOne(Context context, String filename, Bitmap picassaBitmap, long buddyId) {
        sendPicassaImage(context, filename, picassaBitmap, buddyId, false);
    }

    /**
     * Send picassa images from gallery
     *
     * @param filename      File name extracted from uri
     * @param picassaBitmap Bitmap of picassa image
     * @param chatroomId
     */
    public void sendImageChatroom(Context context, String filename, Bitmap picassaBitmap, long chatroomId) {
        sendPicassaImage(context, filename, picassaBitmap, chatroomId, true);
    }

    /**
     * @param fileUri    URI which is send as extra parameter with intent
     * @param windowId   buddyid / chatroomid to which current chat is goining on
     * @param isChatroom if image is to be send in chatroom set it to true
     */
    private void sendImage(Context context, Uri fileUri, final Long windowId, final boolean isChatroom) {
        try {
            File newfile = new File(new URI(fileUri.toString()));
            String filePath = newfile.getAbsolutePath();
            fileName = newfile.getName();
            fileName = fileName.replaceAll("-", "").replaceAll(" ", "_").replaceAll("_", "");
            // Logger.error("fileName: " + fileName);
            Bitmap selectedImage = BitmapProcessingHelper.createBitmap(filePath, true);
            if (selectedImage != null) {
                sendImageAjax(context,selectedImage, windowId, isChatroom);
            } else {
                Toast.makeText(PreferenceHelper.getContext(), "Unable to send image", Toast.LENGTH_SHORT).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /* Used for image file sharing */
    @TargetApi(Build.VERSION_CODES.KITKAT)
    private void sendImage(Context context, Intent data, final Long windowId, final boolean isChatroom) {
        try {
            String filePath = null;
            if(CommonUtils.isSamsung()){
                filePath = LocalStorageFactory.getFilePathFromIntent(data);
                if (filePath == null && data.getData() !=null){
                    filePath = getPhotosAppFilePath(context,data.getData());
                }
            }else if(CommonUtils.isXiaomi()){
                try{
                    filePath = LocalStorageFactory.getPath(data.getData(),true);
                    if (filePath == null && data.getData() !=null){
                        filePath = getPhotosAppFilePath(context,data.getData());
                    }
                }catch (Exception e){
                    e.printStackTrace();
                    filePath = data.getData().getPath().toString().replace("file://", "");
                    if (filePath == null && data.getData() !=null){
                        filePath = getPhotosAppFilePath(context,data.getData());
                    }
                }

            } else if (Build.VERSION.SDK_INT > 19) {
                try{
                    filePath = LocalStorageFactory.getPath(data.getData(),true);
                }catch (Exception e){
                    Uri imagePhotos = data.getData();
                    InputStream is = null;
                    String myPath;
                    if (imagePhotos.getAuthority() != null) {
                        try {
                            is = context.getContentResolver().openInputStream(imagePhotos);
                            Bitmap bmp = BitmapFactory.decodeStream(is);
                            ByteArrayOutputStream bytes = new ByteArrayOutputStream();
                            bmp.compress(Bitmap.CompressFormat.JPEG, 100, bytes);
                            filePath = MediaStore.Images.Media.insertImage(context.getContentResolver(), bmp, "Title", null);
                            //String path = writeToTempImageAndGetPathUri(this, bmp).toString();
                            Uri pathUri = Uri.parse(filePath);
                            if (pathUri != null) {
                                String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                                Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                                        .query(pathUri, filePathColumn, null, null, null);
                                cursor.moveToFirst();
                                filePath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));

                                cursor.close();
                            } else {
                                myPath = null;
                            }
                        }catch (Exception e2 ){
                            e2.printStackTrace();
                        }
                    }
                }
            } else {
                Uri imageUri = data.getData();
                String wholeID = DocumentsContract.getDocumentId(imageUri);
                String id = wholeID.split(":")[1];
                String[] column = {MediaStore.Images.Media.DATA};
                String sel = MediaStore.Images.Media._ID + "=?";

                Cursor cursor = PreferenceHelper.getContext().getContentResolver().
                        query(MediaStore.Images.Media.EXTERNAL_CONTENT_URI,
                                column, sel, new String[]{id}, null);
                int columnIndex = cursor.getColumnIndex(column[0]);
                filePath = "";
                if (cursor.moveToFirst()) {
                    filePath = cursor.getString(columnIndex);
                }
                cursor.close();
            }
            if (filePath != null) {
                fileName = filePath.substring(filePath.lastIndexOf("/") + 1, filePath.length());
                fileName = fileName.replaceAll("-", "").replaceAll(" ", "_").replaceAll("_", "");

                Bitmap selectedImage = BitmapProcessingHelper.createBitmap(filePath, false);
                if (selectedImage != null) {
                    sendImageAjax(context,selectedImage, windowId, isChatroom);
                } else {
                    Logger.error("Image formation error at ImageSharing.java sendImage() ");
                }
            } else {
                Logger.error("File path is null");
            }
        } catch (Exception e) {
            Logger.error("Exception at ImageSharing.java sendImage() :" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }


    private void sendImage(Context context, Intent data, final Long windowId, final boolean isChatroom , ResultReceiver resultReceiver) {
        Logger.error(TAG,"sendImage with uploadCallback = "+resultReceiver);
        try {
            String filePath = null;
            if(CommonUtils.isSamsung()){
                filePath = LocalStorageFactory.getFilePathFromIntent(data);
                if (filePath == null && data.getData() !=null){
                    filePath = getPhotosAppFilePath(context,data.getData());
                }
            }else if(CommonUtils.isXiaomi()){
                try{
                    filePath = LocalStorageFactory.getPath(data.getData(),true);
                    if (filePath == null && data.getData() !=null){
                        filePath = getPhotosAppFilePath(context,data.getData());
                    }
                }catch (Exception e){
                    e.printStackTrace();
                    filePath = data.getData().getPath().toString().replace("file://", "");
                    if (filePath == null && data.getData() !=null){
                        filePath = getPhotosAppFilePath(context,data.getData());
                    }
                }

            } else if (Build.VERSION.SDK_INT > 19) {
                try{
                    filePath = LocalStorageFactory.getPath(data.getData(),true);
                }catch (Exception e){
                    Uri imagePhotos = data.getData();
                    InputStream is = null;
                    String myPath;
                    if (imagePhotos.getAuthority() != null) {
                        try {
                            is = context.getContentResolver().openInputStream(imagePhotos);
                            Bitmap bmp = BitmapFactory.decodeStream(is);
                            ByteArrayOutputStream bytes = new ByteArrayOutputStream();
                            bmp.compress(Bitmap.CompressFormat.JPEG, 100, bytes);
                            filePath = MediaStore.Images.Media.insertImage(context.getContentResolver(), bmp, "Title", null);
                            //String path = writeToTempImageAndGetPathUri(this, bmp).toString();
                            Uri pathUri = Uri.parse(filePath);
                            if (pathUri != null) {
                                String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                                Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                                        .query(pathUri, filePathColumn, null, null, null);
                                cursor.moveToFirst();
                                filePath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));

                                cursor.close();
                            } else {
                                myPath = null;
                            }
                        }catch (Exception e2 ){
                            e2.printStackTrace();
                        }
                    }
                }
            } else {
                Uri imageUri = data.getData();
                String wholeID = DocumentsContract.getDocumentId(imageUri);
                String id = wholeID.split(":")[1];
                String[] column = {MediaStore.Images.Media.DATA};
                String sel = MediaStore.Images.Media._ID + "=?";

                Cursor cursor = PreferenceHelper.getContext().getContentResolver().
                        query(MediaStore.Images.Media.EXTERNAL_CONTENT_URI,
                                column, sel, new String[]{id}, null);
                int columnIndex = cursor.getColumnIndex(column[0]);
                filePath = "";
                if (cursor.moveToFirst()) {
                    filePath = cursor.getString(columnIndex);
                }
                cursor.close();
            }
            if (filePath != null) {
                fileName = filePath.substring(filePath.lastIndexOf("/") + 1, filePath.length());
                fileName = fileName.replaceAll("-", "").replaceAll(" ", "_").replaceAll("_", "");

                Bitmap selectedImage = BitmapProcessingHelper.createBitmap(filePath, false);
                if (selectedImage != null) {
                    sendImageAjax(context,selectedImage, windowId, isChatroom ,resultReceiver);
                } else {
                    Logger.error("Image formation error at ImageSharing.java sendImage() ");
                }
            } else {
                Logger.error("File path is null");
            }
        } catch (Exception e) {
            Logger.error("Exception at ImageSharing.java sendImage() :" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    private void sendPicassaImage(Context context, String filename, Bitmap selectedImage, final long windowId, final boolean isChatroom) {
        try {
            fileName = filename + ".png";
            if (selectedImage != null) {
                sendImageAjax(context,selectedImage, windowId, isChatroom);
            } else {
                Logger.error("Image formation error at ImageSharing.java sendImage() ");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * @param selectedImage Processed image bitmap to be sent
     * @param windowId      To id / chatroom id
     * @param isChatroom    Boolean value to specify image to be sent in chatroom or not
     */
    @SuppressLint("HandlerLeak")
    private void sendImageAjax(Context context, Bitmap selectedImage, final long windowId, final boolean isChatroom) {
        try {
            if (selectedImage != null) {
                ByteArrayOutputStream outstr = new ByteArrayOutputStream();
                String fileExtension = fileName.substring(fileName.lastIndexOf(".") + 1);
                if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
                    selectedImage.compress(Bitmap.CompressFormat.JPEG, 80, outstr);
                } else {
                    selectedImage.compress(Bitmap.CompressFormat.PNG, 80, outstr);
                }
                byte[] outputData = outstr.toByteArray();
                File compressedImageFile = LocalStorageFactory.writeFile(LocalStorageFactory.getImageStoragePath(),
                        fileName, outputData);

                Handler handler = new Handler() {

                    @Override
                    public void handleMessage(Message msg) {
                        super.handleMessage(msg);
                        try {
                            String messageId = msg.obj.toString();
                            Logger.error(TAG,"image ajax=" + msg);
                            switch (msg.what) {
                                case 200:
                                    if (!TextUtils.isEmpty(messageId)) {
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
                                                addChatroomMessage(Long.valueOf(messageId), windowId);
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

                                                    Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                                                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                                    PreferenceHelper.getContext().sendBroadcast(intent);
                                                }
                                            }else{
                                                addOneOnOneMessage(messageId, windowId);
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    Logger.error("problem");
                                    break;
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                String callback = "";
                if(!isChatroom){
                    long msgid = addOneOnOneMessage(context,windowId);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgid;
                }else{
                    long msgid = addChatroomMessage(windowId);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgid;
                }
                Logger.error(TAG,"Callback value = "+callback);

                ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                        URLFactory.getFileUploadURL()+callback, handler);
                imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
                imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, String.valueOf(selectedImage.getHeight()));
                imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, String.valueOf(selectedImage.getWidth()));
                imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance().getName());
                imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, fileName);
                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, compressedImageFile);

                if (isChatroom) {
                    imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
                }
                imageSendHelper.sendCallBack(false);
                imageSendHelper.sendImageAjax();

                //addOneOnOneMessage(messageId, windowId);
            } else {
                Logger.error("Image formation error at ImageSharing.java sendImage() ");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }


    @SuppressLint("HandlerLeak")
    private void sendImageAjax(Context context, Bitmap selectedImage, final long windowId, final boolean isChatroom , ResultReceiver progressResultReceiver) {
       Logger.error(TAG,"SendImageAjax with upload callback = "+progressResultReceiver);
        try {
            if (selectedImage != null) {
                ByteArrayOutputStream outstr = new ByteArrayOutputStream();
                String fileExtension = fileName.substring(fileName.lastIndexOf(".") + 1);
                if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
                    selectedImage.compress(Bitmap.CompressFormat.JPEG, 80, outstr);
                } else {
                    selectedImage.compress(Bitmap.CompressFormat.PNG, 80, outstr);
                }
                byte[] outputData = outstr.toByteArray();
                File compressedImageFile = LocalStorageFactory.writeFile(LocalStorageFactory.getImageStoragePath(),
                        fileName, outputData);

                Handler handler = new Handler() {

                    @Override
                    public void handleMessage(Message msg) {
                        super.handleMessage(msg);
                        try {
                            String messageId = msg.obj.toString();
                            Logger.error("image ajax=" + msg);
                            switch (msg.what) {
                                case 200:
                                    if (!TextUtils.isEmpty(messageId)) {
                                        if (isChatroom) {
                                            addChatroomMessage(Long.valueOf(messageId), windowId);
                                        } else {
                                            //addOneOnOneMessage(messageId, windowId);
                                        }
                                    }
                                    break;
                                default:
                                    Logger.error("problem");
                                    break;
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                Logger.error(TAG,"Image uploading Service called");
                Logger.error(TAG,"callback value  = "+progressResultReceiver);
                //long msgid = addOneOnOneMessage(windowId);
                Logger.error(TAG,"Message if = "+-1);
                Intent imageSharingIntent = new Intent(context, FileUploadService.class);
                imageSharingIntent.putExtra(CometChatKeys.AjaxKeys.TO,String.valueOf(windowId));
                imageSharingIntent.putExtra(CometChatKeys.FileUploadKeys.FILEDATA,compressedImageFile.getAbsolutePath());
                imageSharingIntent.putExtra(CometChatKeys.FileUploadKeys.FILENAME,fileName);
                imageSharingIntent.putExtra(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT,String.valueOf(selectedImage.getHeight()));
                imageSharingIntent.putExtra(CometChatKeys.FileUploadKeys.IMAGE_WIDTH,String.valueOf(selectedImage.getWidth()));
                imageSharingIntent.putExtra("Result_receiver",progressResultReceiver);
                imageSharingIntent.putExtra("LocalMsgId",-1);
                context.startService(imageSharingIntent);
            } else {
                Logger.error("Image formation error at ImageSharing.java sendImage() ");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void addOneOnOneMessage(String messageId, long toId) {
        Logger.error(TAG,"Add OneOnOneMessage called");
        OneOnOneMessage message;
        if(!TextUtils.isEmpty(messageId))
            message = OneOnOneMessage.findById(messageId);
        else
            message = null;

        if (null == message) {
            message = new OneOnOneMessage();

            if(!TextUtils.isEmpty(messageId))
            message.remoteId = Long.parseLong(messageId);
            else
            message.remoteId = 0;

            message.fromId = SessionData.getInstance().getId();
            message.toId = toId;
            message.message = LocalStorageFactory.getImageStoragePath() + fileName;
            message.imageUrl = "";
            message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            message.insertedBy = 1;
            message.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_SENT;
            message.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        } else {
            message.fromId = SessionData.getInstance().getId();
            message.toId = toId;
            message.message = LocalStorageFactory.getImageStoragePath() + fileName;
            message.imageUrl = "";
            message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            message.insertedBy = 1;
            message.save();
        }
    }

    private long addOneOnOneMessage(final Context context, long toId){
        OneOnOneMessage message = new OneOnOneMessage();

        message.remoteId = 0;

        message.fromId = SessionData.getInstance().getId();
        message.toId = toId;
        message.message = LocalStorageFactory.getImageStoragePath() + fileName;
        message.imageUrl = "";
        message.sentTimestamp = System.currentTimeMillis();
        message.type = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
        message.read = 1;
        message.self = 1;
        message.insertedBy = 1;
        message.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_SENT;
        message.save();

        Logger.error(TAG,"Boradcast send");

        new Handler().post(new Runnable() {
            @Override
            public void run() {
                // Code here will run in UI thread
                Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                context.sendBroadcast(intent);
            }
        });

        if(Conversation.isNewBuddyConversation(String.valueOf(toId))){
            Logger.error(TAG,"Is New Conversation");
            Conversation conversation = new Conversation();
            conversation.buddyID = toId;
            conversation.timestamp = System.currentTimeMillis();
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.IMAGE;
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
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.IMAGE;
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

    private void addChatroomMessage(Long messageId, long chatroomId) {

        ChatroomMessage messagePojo = ChatroomMessage.findById(messageId);
        if (null == messagePojo) {
            messagePojo = new ChatroomMessage(messageId, SessionData.getInstance().getId(), chatroomId,
                    LocalStorageFactory.getImageStoragePath() + fileName, System.currentTimeMillis(),
                    StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED, "", "#000000", 1);
            messagePojo.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        } else {
            messagePojo.imageUrl = CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED;
            messagePojo.save();
        }
    }

    private long addChatroomMessage(long chatroomID){
        ChatroomMessage messagePojo = new ChatroomMessage(0L, SessionData.getInstance().getId(), chatroomID,
                LocalStorageFactory.getImageStoragePath() + fileName, System.currentTimeMillis(),
                StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED, "", "#000000", 1);
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
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.IMAGE;
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
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.IMAGE;
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

    /**
     * Create a file Uri for saving an image or video
     *
     * @param isChatroom
     */
    public static Uri getOutputMediaFileUri(int type, boolean isChatroom) {
        return Uri.fromFile(getOutputMediaFile(type, isChatroom));
    }

    @SuppressLint("SimpleDateFormat")
    private static File getOutputMediaFile(int type, boolean isChatroom) {
        File mediaStorageDir = new File(Environment.getExternalStorageDirectory(), PreferenceHelper.getContext()
                .getString(R.string.app_name));

        // Create the storage directory if it does not exist
        if (!mediaStorageDir.exists()) {
            if (!mediaStorageDir.mkdirs()) {
                return null;
            }
        }

        // Create a media file name
        String timeStamp = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date());
        File mediaFile;
        if (type == StaticMembers.MEDIA_TYPE_IMAGE) {
            String imageStoragePath = LocalStorageFactory.getImageStoragePath();
			/*
			 * if (isChatroom) { imageStoragePath =
			 * LocalStorageFactory.getImageStoragePath(); } else {
			 * imageStoragePath = LocalStorageFactory.getImageStoragePath(); }
			 */

            LocalStorageFactory.createDirectory(imageStoragePath);
            mediaFile = new File(imageStoragePath + "IMG" + timeStamp + ".jpg");
        } else if (type == StaticMembers.MEDIA_TYPE_VIDEO) {
            String videoStoragePath = LocalStorageFactory.getVideoStoragePath();
            LocalStorageFactory.createDirectory(videoStoragePath);
            mediaFile = new File(videoStoragePath + "VID" + timeStamp + ".mp4");
        } else {
            return null;
        }
        return mediaFile;
    }

    public static Bitmap getImageBitmap(Uri selectedImageUri, Activity activity){
        Bitmap bitmap = null;
        InputStream is = null;
        String myPath;
        if (selectedImageUri.getAuthority() != null) {
            try {
                is = activity.getContentResolver().openInputStream(selectedImageUri);
                Bitmap bmp = BitmapFactory.decodeStream(is);
                String path = writeToTempImageAndGetPathUri(activity, bmp).toString();
                Uri pathUri = Uri.parse(path);
                if (pathUri != null) {
                    String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                    Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                            .query(pathUri, filePathColumn, null, null, null);
                    cursor.moveToFirst();
                    myPath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));
                    File imgFile = new File(myPath);
                    if (imgFile.exists()) {
                        bitmap = BitmapFactory.decodeFile(imgFile.getAbsolutePath());
                    }
                    cursor.close();
                } else {
                    myPath = null;
                }
            } catch (FileNotFoundException e2) {
                Toast.makeText(activity, "Cant Send Empty File ", Toast.LENGTH_SHORT).show();
                e2.printStackTrace();
            } finally {
                try {
                    if (is != null)
                        is.close();
                } catch (IOException e3) {
                    e3.printStackTrace();
                }
            }
        }
        return bitmap;
    }

    public static Uri writeToTempImageAndGetPathUri(Context inContext, Bitmap inImage) {
        ByteArrayOutputStream bytes = new ByteArrayOutputStream();
        String path = MediaStore.Images.Media.insertImage(inContext.getContentResolver(), inImage, "Title", null);
        return Uri.parse(path);
    }
    public static String getPhotosAppFilePath(Context context, Uri uri) {
        Uri imagePhotos = uri;
        InputStream is = null;
        String filePath = null;
        if (imagePhotos.getAuthority() != null) {
            try {
                is = context.getContentResolver().openInputStream(imagePhotos);
                Bitmap bmp = BitmapFactory.decodeStream(is);
                ByteArrayOutputStream bytes = new ByteArrayOutputStream();
                bmp.compress(Bitmap.CompressFormat.JPEG, 100, bytes);
                filePath = MediaStore.Images.Media.insertImage(context.getContentResolver(), bmp, "Title", null);
                //String path = writeToTempImageAndGetPathUri(this, bmp).toString();
                Uri pathUri = Uri.parse(filePath);
                if (pathUri != null) {
                    String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                    Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                            .query(pathUri, filePathColumn, null, null, null);
                    cursor.moveToFirst();
                    filePath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));

                    cursor.close();
                } else {
                    filePath = null;
                }
            }catch (Exception e2 ){
                e2.printStackTrace();
            }
        }
        return filePath;
    }

}
