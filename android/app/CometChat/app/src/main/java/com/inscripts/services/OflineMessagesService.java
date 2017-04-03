package com.inscripts.services;


import android.app.IntentService;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.ResultReceiver;
import android.text.TextUtils;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Iterator;
import java.util.List;

public class OflineMessagesService extends IntentService {

    private static final String TAG = OflineMessagesService.class.getSimpleName();
    private List<OneOnOneMessage> unsendMessagelist;
    private List<ChatroomMessage> unsendChatroomMessageList;
    public OflineMessagesService() {
        super(TAG);
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        PreferenceHelper.initialize(this);
        unsendMessagelist = OneOnOneMessage.getAllUnsendMessages();
        Logger.error(TAG,"Offline message service started with size = "+unsendMessagelist.size());
        for(Iterator iterator = unsendMessagelist.iterator();iterator.hasNext();){
            final OneOnOneMessage oneOnOneMessage = (OneOnOneMessage) iterator.next();

            Logger.error(TAG,"Message Type = "+oneOnOneMessage.type);

                switch (oneOnOneMessage.type){

                    case CometChatKeys.MessageTypeKeys.NORMAL:
                        sendMessage(oneOnOneMessage);
                        break;

                    case CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED:
                        sendImageMessage(oneOnOneMessage);
                        break;
                    case CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED:
                        sendVideoMessage(oneOnOneMessage);
                        break;
                    case CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED:
                        sendAudioMessage(oneOnOneMessage);
                        break;
                }
        }

        unsendChatroomMessageList = ChatroomMessage.getAllUnsendMessages();
        Logger.error(TAG,"Offline chatroom message service started with size = "+unsendChatroomMessageList.size());
        for(Iterator iterator = unsendChatroomMessageList.iterator();iterator.hasNext();){
            final ChatroomMessage chatroomMessage = (ChatroomMessage) iterator.next();

            switch (chatroomMessage.type){
                case CometChatKeys.MessageTypeKeys.NORMAL:
                    sendMessage(chatroomMessage);
                    break;
                case CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED:
                    sendImageMessage(chatroomMessage);
                    break;
                case CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED:
                    sendVideoMessage(chatroomMessage);
                    break;
                case CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED:
                    Logger.error(TAG,"Audio Download");
                    sendAudioMessage(chatroomMessage);
                    break;
            }
        }
    }


    @Override
    public void onDestroy() {
        super.onDestroy();
    }


    private void sendMessage(final OneOnOneMessage oneOnOneMessage){
        String sendMessageUrl = URLFactory.getSendOneToOneMessageURL();
        String callback = "?callback=jqcc"+PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+oneOnOneMessage.getId();
        final VolleyHelper helper = new VolleyHelper(this, sendMessageUrl+callback, new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {

                    Logger.error(TAG,"Success responce = "+response);
                    long localId = -1,imei = -1;

                    if(response.contains("jqcc")){
                        String jqcc = response.substring(0,response.lastIndexOf("("));
                        response = response.replace(jqcc,"");
                        response = response.substring(1,response.length()-1);
                        jqcc = jqcc.replace("jqcc","");
                        String[] strings = jqcc.split("_");
                        localId = Long.parseLong(strings[2]);
                        imei = Long.parseLong(strings[0]);
                    }

                    JSONObject sendResponse = new JSONObject(response);
                    Long id = sendResponse.getLong(CometChatKeys.AjaxKeys.ID);
                    if (id == -1) {
                        //Logger.error("you are banned by other user");
                    } else {

                        if(localId != -1 && imei != -1){

                            if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                OneOnOneMessage mess = OneOnOneMessage.findByLocalId(localId);
                                Logger.error(TAG,"Fetchted Mess local id = "+mess.getId()+"   Remote ID = "+mess.remoteId);
                                if(mess != null && mess.remoteId == 0){
                                    mess.remoteId = id;
                                    mess.save();

                                    unsendMessagelist.remove(oneOnOneMessage);
                                    if(unsendMessagelist.size() == 0){
                                        Logger.error(TAG,"Send Broadcast");
                                        Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.REFRESH_UNSEND_MESSAGES, 1);
                                        sendBroadcast(intent);

                                    }else{
                                        Logger.error(TAG,"Restart service");
                                        //startService(new Intent(OflineMessagesService.this, OflineMessagesService.class));
                                    }
                                }
                            }

                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                Logger.error(TAG,"Error response = "+response);
            }
        });
        helper.addNameValuePair(CometChatKeys.AjaxKeys.MESSAGE, oneOnOneMessage.message);
        helper.addNameValuePair(CometChatKeys.AjaxKeys.TO, String.valueOf(oneOnOneMessage.toId));
        helper.sendAjax();
    }


    private void sendMessage(ChatroomMessage chatroomMessage){
        String sendMessageUrl = URLFactory.getSendChatroomMessageURL();
        String callback = "&callback=jqcc"+PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+chatroomMessage.getId();

        VolleyHelper volleyHelper = new VolleyHelper(this, sendMessageUrl+callback, new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {

                    Logger.error(TAG,"Send message success ressult =" + response);
                    long localId = -1,imei = -1;

                    if(response.contains("jqcc")){
                        String jqcc = response.substring(0,response.lastIndexOf("("));
                        response = response.replace(jqcc,"");
                        response = response.substring(1,response.length()-1);
                        jqcc = jqcc.replace("jqcc","");
                        String[] strings = jqcc.split("_");
                        localId = Long.parseLong(strings[2]);
                        imei = Long.parseLong(strings[0]);
                    }

                    JSONObject sendResponse = new JSONObject(response);


                    Long id = sendResponse.getLong(CometChatKeys.AjaxKeys.ID);
                    Logger.error(TAG,"Remote id = "+id);
                    if (id == -1) {
                        //Logger.error("you are banned by other user");
                    } else {
                        if(localId != -1 && imei != -1){

                            if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                ChatroomMessage mess = ChatroomMessage.findByLocalId(String.valueOf(localId));
                                Logger.error(TAG,"Fetchted Mess local id = "+mess.getId()+"   message ID = "+mess.message);
                                if(mess != null){
                                    mess.remoteId = id;
                                    mess.save();
                                }
                            }

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(intent);
                        }
                    }
                    //Logger.error("send message respose = " + response);

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                Logger.error(TAG,"Fail responce = "+response);
                       /* if (isNoInternet) {
                            Toast.makeText(getApplicationContext(), lang.getMobile().get24(), Toast.LENGTH_SHORT)
                                    .show();
                        }*/
            }
        });
        volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.MESSAGE, chatroomMessage.message);
        /*if(selectedColor != null){
            if(selectedColor == StaticMembers.MY_DEFAULT_TEXT_COLOR){
                volleyHelper.addNameValuePair("cookie_"+ JsonPhp.getInstance().getCookieprefix()+"chatroomcolor","000");
            }else{
                volleyHelper.addNameValuePair("cookie_"+JsonPhp.getInstance().getCookieprefix()+"chatroomcolor",selectedColor.replace("#",""));
            }
        }*/
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, String.valueOf(chatroomMessage.chatroomId));

        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomMessage.chatroomId);
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_NAME, chatroom.name);
        //volleyHelper.addNameValuePair("localmessageid",messagePojo.getId());
        volleyHelper.sendAjax();
    }


    private void sendImageMessage(final OneOnOneMessage oneOnOneMessage){
        String path = oneOnOneMessage.message;
        BitmapFactory.Options options = new BitmapFactory.Options();
        Logger.error(TAG,"Image Path = "+path);

        File file = new File(oneOnOneMessage.message);

        if(file.exists()){

            Bitmap image = BitmapFactory.decodeFile(oneOnOneMessage.message, options);
            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+oneOnOneMessage.getId();
            Logger.error(TAG,"Callback value = "+callback);

            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {
                                    /*if (isChatroom) {
                                        addChatroomMessage(Long.valueOf(messageId), windowId);
                                    } else {*/

                                if(messageId.contains("jqcc")){
                                    JSONObject imageJson = null;
                                    try {
                                        imageJson = new JSONObject(messageId);
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
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };
            ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getFileUploadURL()+callback, resultReceiver);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, oneOnOneMessage.toId);
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, String.valueOf(image.getHeight()));
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, String.valueOf(image.getWidth()));
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance().getName());
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, file.getName());
            try {
                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, file);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }

        /*if (isChatroom) {
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
        }
        */
            imageSendHelper.sendCallBack(false);
            imageSendHelper.sendImageAjax();
        }
    }

    private void sendImageMessage(final ChatroomMessage chatroomMessage){
        String path = chatroomMessage.message;
        BitmapFactory.Options options = new BitmapFactory.Options();

        File file = new File(chatroomMessage.message);
        Logger.error(TAG,"Chatroom File exist ? "+file.exists());

        if(file.exists()){

             String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+chatroomMessage.getId();
            Bitmap image = BitmapFactory.decodeFile(chatroomMessage.message, options);
            Logger.error(TAG,"Callback value = "+callback);

            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));

                    Logger.error(TAG,"Message id = "+messageId);
                    Logger.error(TAG,"what = "+what);
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {
                                if(messageId.contains("jqcc")){

                                    try {
                                        JSONObject imageJson = new JSONObject(messageId);
                                        String jqcc = null;
                                        jqcc = imageJson.getString("callback");
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
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };


            ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getFileUploadURL()+callback, resultReceiver);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, chatroomMessage.chatroomId);
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, String.valueOf(image.getHeight()));
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, String.valueOf(image.getWidth()));
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance().getName());
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, file.getName());
            try {
                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, file);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            imageSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
            imageSendHelper.sendCallBack(false);
            imageSendHelper.sendImageAjax();
        }

    }

    private void sendVideoMessage(final OneOnOneMessage oneOnOneMessage){

        File sourceFile = new File(oneOnOneMessage.message);
        Logger.error(TAG,"Video file exist ?"+sourceFile.exists());
        if(sourceFile.exists()){
            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {
                                    /*if (isChatroom) {
                                        addChatroomMessage(Long.valueOf(messageId), windowId);
                                    } else {*/

                                if(messageId.contains("jqcc")){
                                    JSONObject videoJson = null;
                                    try {
                                        videoJson = new JSONObject(messageId);
                                        String jqcc = videoJson.getString("callback");
                                        jqcc = jqcc.replace("jqcc","");
                                        String[] strings = jqcc.split("_");
                                        long localId = Long.parseLong(strings[2]);
                                        long imei = Long.parseLong(strings[0]);
                                        if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                            OneOnOneMessage mess = OneOnOneMessage.findByLocalId(localId);
                                            if(mess != null){
                                                mess.remoteId = videoJson.getLong("id");
                                                mess.save();
                                            }

                                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                            PreferenceHelper.getContext().sendBroadcast(intent);
                                        }
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };

            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+oneOnOneMessage.getId();
            Logger.error(TAG,"Video Callback value = "+callback);
            ImageUploadHelper videoSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getFileUploadURL()+callback, resultReceiver);
            videoSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, oneOnOneMessage.toId);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 512);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 512);
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                    .getName());
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, sourceFile.getName());
            try {
                videoSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, sourceFile);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            videoSendHelper.sendCallBack(false);

    /*    if (isChatroom) {
            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                    CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
        }*/
            videoSendHelper.sendImageAjax();
        }

    }


    private void sendVideoMessage(final ChatroomMessage chatroomMessage){
        File sourceFile = new File(chatroomMessage.message);
        Logger.error(TAG,"Video file exist ?"+sourceFile.exists());
        if(sourceFile.exists()){
            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+chatroomMessage.getId();

            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {

                                if(messageId.contains("jqcc")){
                                    try {
                                        JSONObject imageJson =imageJson = new JSONObject(messageId);
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
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }

                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };

        Logger.error(TAG,"Video Callback value = "+callback);
        ImageUploadHelper videoSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                URLFactory.getFileUploadURL()+callback, resultReceiver);
        videoSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, chatroomMessage.chatroomId);
        videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 512);
        videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 512);
        videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                .getName());
        videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, sourceFile.getName());
            try {
                videoSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, sourceFile);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            videoSendHelper.sendCallBack(false);

            videoSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                    CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);

        videoSendHelper.sendImageAjax();
        }
    }


    private void sendAudioMessage(final OneOnOneMessage oneOnOneMessage){

        File sourceFile = new File(oneOnOneMessage.message);
        Logger.error(TAG,"audio file exist ?"+sourceFile.exists());
        if(sourceFile.exists()){
            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {
                                    /*if (isChatroom) {
                                        addChatroomMessage(Long.valueOf(messageId), windowId);
                                    } else {*/

                                if(messageId.contains("jqcc")){
                                    JSONObject videoJson = null;
                                    try {
                                        videoJson = new JSONObject(messageId);
                                        String jqcc = videoJson.getString("callback");
                                        jqcc = jqcc.replace("jqcc","");
                                        String[] strings = jqcc.split("_");
                                        long localId = Long.parseLong(strings[2]);
                                        long imei = Long.parseLong(strings[0]);
                                        if(imei == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA))){
                                            OneOnOneMessage mess = OneOnOneMessage.findByLocalId(localId);
                                            if(mess != null){
                                                mess.remoteId = videoJson.getLong("id");
                                                mess.save();
                                            }

                                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                                            PreferenceHelper.getContext().sendBroadcast(intent);
                                        }
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }
                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };

            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+oneOnOneMessage.getId();

            //FileUploadHelper videoSendHelper = new FileUploadHelper(URLFactory.getFileUploadURL(), handler);
            ImageUploadHelper audioSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getFileUploadURL()+callback, resultReceiver);
            audioSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, oneOnOneMessage.toId);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 30);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 30);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                    .getName());
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, sourceFile.getName());
            try {
                audioSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, sourceFile);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            audioSendHelper.sendCallBack(false);

     /*   if (isChatroom) {
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE,
                    CometChatKeys.FileUploadKeys.CHATROOMMODE_VALUE);
        }*/
            audioSendHelper.sendImageAjax();
        }

    }

    private void sendAudioMessage(final ChatroomMessage chatroomMessage){
        File sourceFile = new File(chatroomMessage.message);
        Logger.error(TAG,"audio file exist ?"+sourceFile.exists());
        if(sourceFile.exists()){
            ResultReceiver resultReceiver = new ResultReceiver(null){
                @Override
                protected void onReceiveResult(int resultCode, Bundle resultData) {
                    String messageId = resultData.getString("obj");
                    int what = Integer.parseInt(resultData.getString("what"));

                    Logger.error(TAG,"Message ID = "+messageId);
                    Logger.error(TAG,"Wat = "+what);
                    switch (what) {
                        case 200:
                            if (!TextUtils.isEmpty(messageId)) {
                                if(messageId.contains("jqcc")){
                                    try {
                                        JSONObject imageJson  = new JSONObject(messageId);
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
                                    } catch (JSONException e) {
                                        e.printStackTrace();
                                    }

                                }
                            }
                            break;
                        default:
                            Logger.error("problem");
                            break;
                    }
                }
            };

            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+chatroomMessage.getId();

            ImageUploadHelper audioSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getFileUploadURL()+callback, resultReceiver);
            audioSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, chatroomMessage.chatroomId);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT, 30);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.IMAGE_WIDTH, 30);
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.SENDERNAME, SessionData.getInstance()
                    .getName());
            audioSendHelper.addNameValuePair(CometChatKeys.FileUploadKeys.FILENAME, sourceFile.getName());
            try {
                audioSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, sourceFile);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
            audioSendHelper.sendCallBack(false);
            audioSendHelper.sendImageAjax();
        }
    }
}
