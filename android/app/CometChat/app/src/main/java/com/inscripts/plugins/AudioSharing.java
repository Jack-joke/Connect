/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.provider.MediaStore;
import android.widget.Toast;

import com.inscripts.activities.R;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.FileDownloadHelper;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.Conversation;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class AudioSharing {
    public static final String TAG = AudioSharing.class.getSimpleName();
    private static String fileName;

    public static boolean isIncomingAudio(String message) {
        return message.contains(StaticMembers.IMAGE_MESSAGE_CLASS) && message.contains(StaticMembers.FILETRANSFER_KEY)
                && message.contains(StaticMembers.AUDIO_MESSAGE_CSS_CLASS);
    }

    @SuppressLint("SimpleDateFormat")
    public static String getOutputMediaFile() {
        File mediaStorageDir = new File(Environment.getExternalStorageDirectory(), PreferenceHelper.getContext()
                .getString(R.string.app_name));

        // Create the storage directory if it does not exist
        if (!mediaStorageDir.exists()) {
            if (!mediaStorageDir.mkdirs()) {
                return null;
            }
        }
        String audioStoragePath = LocalStorageFactory.getAudioStoragePath();
        LocalStorageFactory.createDirectory(audioStoragePath);

        return audioStoragePath + new SimpleDateFormat("yyyyMMddHHmmss").format(new Date()) + ".aac";
    }

    public static void downloadAndStoreAudio(String remoteId, String videoRemoteURL, boolean isChatroom) {
        try {
            if (isChatroom) {
                //Params are Remoteid, URL, is Chatroom, 0=>Audio to be downloaded
                new FileDownloadHelper().execute(remoteId, videoRemoteURL, "1", "0","0");
            } else {
                new FileDownloadHelper().execute(remoteId, videoRemoteURL, "0", "0","0");
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String getRealPathFromURI(Context context, Uri contentUri) {
        Cursor cursor = null;
        try {
            String[] proj = { MediaStore.Images.Media.DATA };
            cursor = context.getContentResolver().query(contentUri,  proj, null, null, null);
            int column_index = cursor.getColumnIndexOrThrow(MediaStore.Images.Media.DATA);
            cursor.moveToFirst();
            return cursor.getString(column_index);
        } finally {
            if (cursor != null) {
                cursor.close();
            }
        }
    }

    public static void sendAudio(Activity activity, final String filePath, final long windowId, final boolean isChatroom) {
        try {
            File sourceFile = new File(filePath);
            fileName = sourceFile.getName();

            if (sourceFile.length() <= LocalConfig.getFileUploadLimit()) {

                Handler handler = new Handler() {
                    @Override
                    public void handleMessage(Message msg) {
                        super.handleMessage(msg);
                        try {
                            String messageId = msg.obj.toString();
                            //Logger.error("send audio note messageid =" + messageId);
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
                                    addChatroomMessage(Long.valueOf(messageId), windowId, fileName, filePath);
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
                                    addOneOnOneMessage(messageId, windowId, fileName, filePath);
                                }
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                String callback ="";
                if(!isChatroom){
                    long msgId = addOneOnOneMessage(windowId, fileName, filePath);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgId;
                }else{
                    long msgid = addChatroomMessage(windowId, fileName, filePath);
                    callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgid;
                }

                //FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
                ImageUploadHelper audioSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                        URLFactory.getFileUploadURL()+callback, handler);
                audioSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, windowId);
                audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 30);
                audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 30);
                audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                        .getName());
                audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, fileName);
                audioSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, sourceFile);
                audioSendHelper.sendCallBack(false);

                if (isChatroom) {
                    audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                            CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
                }
                audioSendHelper.sendImageAjax();
            } else {
                Toast.makeText(activity, "File size limit exceeded. Cannot send this video.", Toast.LENGTH_LONG).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void sendAudio(Activity activity, Uri fileuri, final long windowId, final boolean isChatroom) {
        try {
            String filePath = null;
            File file = new File(fileuri.getPath());
            if(file.exists()){
                filePath = file.toString();
                sendAudio(activity, filePath, windowId, isChatroom);
            }else{
                Uri selectedImageURI = fileuri;
                try{
                    if (selectedImageURI != null) {
                        String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                        Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                                .query(selectedImageURI, filePathColumn, null, null, null);
                        cursor.moveToFirst();
                        filePath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));
                        sendAudio(activity, filePath, windowId, isChatroom);
                        cursor.close();
                    } else {
                        filePath = null;
                    }
                }catch(Exception e){
                    e.printStackTrace();
                    filePath = file.toString();
                    sendAudio(activity, filePath, windowId, isChatroom);
                }
            }


        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static void addOneOnOneMessage(String messageId, long toId, String fileName, String storagePath) {

        OneOnOneMessage message = OneOnOneMessage.findById(messageId);

        if (null == message) {

            message = new OneOnOneMessage();
            message.remoteId = Long.parseLong(messageId);
            message.fromId = SessionData.getInstance().getId();
            message.toId = toId;
            message.message = storagePath;
            message.imageUrl = "";
            message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
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
            message.message = storagePath;
            // message.imageUrl = "";
            // message.sentTimestamp = System.currentTimeMillis();
            message.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
            message.read = 1;
            message.self = 1;
            // message.insertedBy = StaticMembers.MSG_INSERTED_BY_RESPONSE;
            message.save();
        }


    }

    private static long addOneOnOneMessage(long toId, String fileName, String storagePath){
        OneOnOneMessage message =  new OneOnOneMessage();
        message.remoteId = 0L;
        message.fromId = SessionData.getInstance().getId();
        message.toId = toId;
        message.message = storagePath;
        message.imageUrl = "";
        message.sentTimestamp = System.currentTimeMillis();
        message.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
        message.read = 1;
        message.self = 1;
        message.insertedBy = 1;
        message.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_SENT;
        message.save();

        Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
        PreferenceHelper.getContext().sendBroadcast(intent);

        if(Conversation.isNewBuddyConversation(String.valueOf(toId))){
            Logger.error(TAG,"Is New Conversation");
            Conversation conversation = new Conversation();
            conversation.buddyID = toId;
            conversation.timestamp = System.currentTimeMillis();
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.AUDIO_NOTE;
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
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.AUDIO_NOTE;
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
                    storagePath, System.currentTimeMillis(),
                    StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED, "", "#000000", 1);
            messagePojo.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        } else {
            messagePojo.message = storagePath;
            messagePojo.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
            messagePojo.save();

            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(intent);
        }
    }

    private static long addChatroomMessage(long chatroomId, String fileName, String storagePath) {

        ChatroomMessage messagePojo = new ChatroomMessage(0L, SessionData.getInstance().getId(), chatroomId,
                    storagePath, System.currentTimeMillis(),
                    StaticMembers.ME_TEXT, CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED, "", "#000000", 1);
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

        if(Conversation.isNewChatroomConversation(String.valueOf(chatroomId))){
            Logger.error(TAG,"Is New Chatroom Conversation");
            Conversation conversation = new Conversation();
            conversation.chatroomID = chatroomId;
            conversation.timestamp = System.currentTimeMillis() ;
            conversation.lstMessage = CometChatKeys.RecentMessageTypes.AUDIO_NOTE;
            Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
            if(chatroom != null)
                conversation.name = chatroom.name;
            else
                conversation.name = "Chatroom";

            conversation.avtarUrl = "";
            conversation.save();
        }else{
            Logger.error(TAG,"Is old chatroom Conversation");
            Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(chatroomId));
            if(conversation != null){
                conversation.timestamp = System.currentTimeMillis() ;
                conversation.lstMessage = CometChatKeys.RecentMessageTypes.AUDIO_NOTE;
                Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
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
}
