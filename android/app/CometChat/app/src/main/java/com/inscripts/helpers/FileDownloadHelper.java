/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.helpers;

import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;

import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

import java.io.BufferedInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

public class FileDownloadHelper extends AsyncTask<String, Void, Void> {

    /**
     * Downloads the file and returns it's location on the sdcard with full path
     */
    private static String downloadFile(String remoteFileLocation, boolean isVideo, boolean isNormalFile) {
        int count;
        try {
            URL url = new URL(remoteFileLocation);
            URLConnection conection = url.openConnection();
            conection.connect();

            // for progress bar
            // int lenghtOfFile = conection.getContentLength();

            // download the file
            InputStream input = new BufferedInputStream(url.openStream(), 8192);
            String storagePath;
            if (isNormalFile) {
                storagePath = LocalStorageFactory.getNormalStoragePath();
            } else if (isVideo) {
                storagePath = LocalStorageFactory.getVideoStoragePath();
            } else {
                storagePath = LocalStorageFactory.getAudioStoragePath();
            }


            LocalStorageFactory.createDirectory(storagePath);
            String fileName = getFileName(remoteFileLocation);
            String finalPath = storagePath + fileName;

            // Output stream
            FileOutputStream output = new FileOutputStream(finalPath);

            byte data[] = new byte[1024];
            // long total = 0;

            while ((count = input.read(data)) != -1) {
                // total += count;
                // Logger.error("count: " + count);
                output.write(data, 0, count);
            }

            // flushing output
            output.flush();
            // closing streams
            output.close();
            input.close();
            LocalStorageFactory.scanFileForGallery(finalPath, false);
            return finalPath;
        } catch (Exception e) {
            Logger.error("Exception in downloading: " + e.getMessage());
            e.printStackTrace();
            return "";
        }
    }

    private static String getFileName(String remoteFileLocation) {
        return remoteFileLocation.substring(remoteFileLocation.lastIndexOf("=") + 1,
                remoteFileLocation.length());
    }

    @Override
    protected Void doInBackground(String... params) {
        try {
            Context context = PreferenceHelper.getContext();
            boolean isVideo = params[3].equals("1");
            boolean isNormalFile = params[4].equals("1");

            String videoLocalPath = downloadFile(params[1], isVideo, isNormalFile);

            if (isNormalFile) {
                if ("0".equals(params[2])) {
                    OneOnOneMessage message = OneOnOneMessage.findById(params[0]);
                    if (null != message) {
                        message.message = message.message + "#" + videoLocalPath;
                        message.type = CometChatKeys.MessageTypeKeys.FILE_DOWNLOADED;
                        message.save();

                        Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        context.sendBroadcast(intent);
                        SessionData.getInstance().setBuddyListBroadcastMissed(true);
                    }
                } else {
                    ChatroomMessage message = ChatroomMessage.findById(params[0]);
                    if (null != message) {
                        message.message = message.message + "#" + videoLocalPath;
                        message.type = CometChatKeys.MessageTypeKeys.FILE_DOWNLOADED;
                        message.save();

                        Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        context.sendBroadcast(intent);
                        SessionData.getInstance().setChatroomBroadcastMissed(true);
                    }
                }
            } else {
                if (isVideo) {
                    if ("0".equals(params[2])) {
                        OneOnOneMessage message = OneOnOneMessage.findById(params[0]);
                        if (null != message) {
                            message.message = videoLocalPath;
                            message.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
                            message.save();

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            context.sendBroadcast(intent);
                            SessionData.getInstance().setBuddyListBroadcastMissed(true);
                        }
                    } else {
                        ChatroomMessage message = ChatroomMessage.findById(params[0]);
                        if (null != message) {
                            message.message = videoLocalPath;
                            message.type = CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED;
                            message.save();

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            context.sendBroadcast(intent);
                            SessionData.getInstance().setChatroomBroadcastMissed(true);
                        }
                    }
                } else {
                    if ("0".equals(params[2])) {
                        OneOnOneMessage message = OneOnOneMessage.findById(params[0]);
                        if (null != message) {
                            message.message = videoLocalPath;
                            message.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
                            message.save();

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            context.sendBroadcast(intent);
                            SessionData.getInstance().setBuddyListBroadcastMissed(true);
                        }
                    } else {
                        ChatroomMessage message = ChatroomMessage.findById(params[0]);
                        if (null != message) {
                            message.message = videoLocalPath;
                            message.type = CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED;
                            message.save();

                            Intent intent = new Intent(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            context.sendBroadcast(intent);
                            SessionData.getInstance().setChatroomBroadcastMissed(true);
                        }
                    }
                }
            }


        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
}
