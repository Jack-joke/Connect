/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.models;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONObject;

import java.util.List;

public class ChatroomMessage extends SugarRecord {

    private static final String ID = "id";
    private static final String TABLE_NAME = "CHATROOM_MESSAGE";
    private static final String COLUMN_REMOTE_ID = "remote_id";
    private static final String COLUMN_CHATROOM_ID = "chatroom_id";
    private static final String COLUMN_SENT_TIMESTAMP = "sent_timestamp";
    private static final String COLUMN_FROM = "from";
    private static final String COLUMN_MESSAGE = "message";
    private static final String COLUMN_SENT = "sent";
    private static final String COLUMN_FROM_ID = "fromid";
    private static final String COLUMN_IMAGE_URL = "image_url";
    private static final String COLUMN_TEXT_COLOR = "text_color";
    private static final String COLUMN_MESSAGE_INSERTED_BY = "inserted_by";

    /**
     * Chatroom message id
     */
    @Column(name = COLUMN_REMOTE_ID, notNull = true)
    public long remoteId;
    public long id, sentTimestamp, fromId, chatroomId;
    public String message, imageUrl, senderName, textColor, type;

    /**
     * 1 => Inserted by response. 0 => Inserted by receive.
     */
    public int insertedBy;

    public ChatroomMessage() {
    }

    public ChatroomMessage(long remoteId, long userId, Long chatroomId, String message, long sentTimestamp,
                           String senderName, String type, String imageUrl, String textColor, int msgInsertedBy) {
        this.remoteId = remoteId;
        this.fromId = userId;
        this.chatroomId = chatroomId;
        this.message = message;
        this.sentTimestamp = sentTimestamp;
        this.senderName = senderName;
        this.type = type;
        this.imageUrl = imageUrl;
        this.textColor = textColor;
        this.insertedBy = msgInsertedBy;
    }

    public ChatroomMessage(JSONObject message) {
        try {
            this.remoteId = message.getLong(ID);
            this.fromId = message.getLong(COLUMN_FROM_ID);
            this.senderName = message.getString(COLUMN_FROM);
            if (message.has(CometChatKeys.ChatroomKeys.CHATROOMID)) {
                this.chatroomId = message.getLong(CometChatKeys.ChatroomKeys.CHATROOMID);
            } else if(message.has(CometChatKeys.ChatroomKeys.ROOMID)){
                this.chatroomId = message.getLong(CometChatKeys.ChatroomKeys.ROOMID);
            }else{
                this.chatroomId = SessionData.getInstance().getCurrentChatroom();
            }
            this.message = message.getString(COLUMN_MESSAGE);
            this.sentTimestamp = message.getLong(COLUMN_SENT);
            this.type = message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE);
            this.imageUrl = message.getString(COLUMN_IMAGE_URL);
            this.textColor = message.getString(COLUMN_TEXT_COLOR);
            this.insertedBy = message.getInt(COLUMN_MESSAGE_INSERTED_BY);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static List<ChatroomMessage> getAllMessages(Long chatroomId) {
        String messageLimit = PreferenceHelper.get(PreferenceKeys.DataKeys.LOAD_EARLIER_COUNT_CHAROOM);
        if (messageLimit.equals("")){
            messageLimit = LocalConfig.getMessageLimit();
        }
        if (null != JsonPhp.getInstance().getConfig()
                && null != JsonPhp.getInstance().getConfig().getHistoryMessageLimit()) {
            messageLimit = JsonPhp.getInstance().getConfig().getHistoryMessageLimit();
        }
        return findWithQuery(ChatroomMessage.class, "SELECT * " + COLUMN_FROM + " ( SELECT *" + COLUMN_FROM + " `" + TABLE_NAME + "` WHERE `"
                + COLUMN_CHATROOM_ID + "`=" + chatroomId + " ORDER BY `" + ID + "` DESC LIMIT "
                + messageLimit + ") ORDER BY `" + ID + "` ASC;", new String[0]);
    }

    public static ChatroomMessage findById(String messageId) {
        List<ChatroomMessage> list = find(ChatroomMessage.class, "`" + COLUMN_REMOTE_ID + "` = ?", messageId);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }

    public static ChatroomMessage findByLocalId(String messageId) {
        List<ChatroomMessage> list = find(ChatroomMessage.class, "`" + ID + "` = ?", messageId);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }

    public static ChatroomMessage findById(Long messageId) {
        return findById(String.valueOf(messageId));
    }

    public static void deleteMessage(String messageId) {
        String whereClause = "`" + COLUMN_REMOTE_ID + "` = ?";
        String[] whereArgs = {messageId};
        deleteAll(ChatroomMessage.class, whereClause, whereArgs);
    }

    public static void clearConversation(Long chatroomId) {
        String whereClause = "`" + COLUMN_CHATROOM_ID + "` = ?";
        String[] whereArgs = {String.valueOf(chatroomId)};
        deleteAll(ChatroomMessage.class, whereClause, whereArgs);
    }

    public static List<ChatroomMessage> getAllUnsendMessages(){
        String query = "SELECT * from `"+ TABLE_NAME + "` WHERE `" + COLUMN_REMOTE_ID + "`= " +"0;";
        Logger.error("Query = "+query);
        return findWithQuery(ChatroomMessage.class,query,new String[0]);
    }


}