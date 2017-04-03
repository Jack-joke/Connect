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
import com.inscripts.utils.SessionData;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONObject;

import java.util.List;

public class OneOnOneMessage extends SugarRecord {

    private static final String TABLE_NAME = "ONE_ON_ONE_MESSAGE";
    private static final String COLUMN_REMOTE_ID = "remote_id";
    private static final String COLUMN_FROM_ID = "from_id";
    private static final String COLUMN_TO_ID = "to_id";
    private static final String COLUMN_SENT_TIMESTAMP = "sent";
    public static final String COLUMN_ID = "id";
    public static final String COLUMN_FROM = "from";
    public static final String COLUMN_TO = "to";
    public static final String COLUMN_MESSAGE = "message";
    public static final String COLUMN_SELF = "self";
    public static final String COLUMN_IMAGE_URL = "image_url";
    public static final String COLUMN_MESSAGE_INSERTED_BY = "inserted_by";
    public static final String COLOUMN_MESSAGE_TICK = "messagetick";

    @Column(name = "remote_id", notNull = true)
    public long remoteId;
    public int read, self;
    public long sentTimestamp, id, toId, fromId;
    public String message, imageUrl, type;

    /**
     * 1 => Inserted by response. 0 => Inserted by receive.
     */
    public int insertedBy;
    /**
     * 1=> Single tick, 2=> Double tick (Deliverd), 3=> Read tick ( Blue tick)
     */
    public int messagetick = 1;



    public OneOnOneMessage(Long remoteId, long fromId, long toId, String message, long sentTimestamp, int read,
                           int self, String messageType, String imageUrl, Integer insertedBy, int messageTick) {
        this.remoteId = remoteId;
        this.fromId = fromId;
        this.message = message;
        this.toId = toId;
        this.sentTimestamp = sentTimestamp;
        this.read = read;
        this.self = self;
        this.type = messageType;
        this.imageUrl = imageUrl;
        this.insertedBy = insertedBy;
        this.messagetick = messageTick;
    }

    public OneOnOneMessage() {
    }

    public static OneOnOneMessage findById(String messageId) {
        List<OneOnOneMessage> list = find(OneOnOneMessage.class, "`" + COLUMN_REMOTE_ID + "`=?", messageId);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }

    public static OneOnOneMessage findByLocalId(long messageId) {
        List<OneOnOneMessage> list = find(OneOnOneMessage.class, "`" + COLUMN_ID + "`=?", String.valueOf(messageId));
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }


    public static OneOnOneMessage findById(long messageId) {
        return findById(String.valueOf(messageId));
    }

    public OneOnOneMessage(JSONObject message) {
        try {
            this.remoteId = message.getLong(COLUMN_ID);
            this.fromId = message.getLong(COLUMN_FROM);
            this.toId = message.getLong(COLUMN_TO);
            this.message = message.getString(COLUMN_MESSAGE);
            this.sentTimestamp = message.getLong(COLUMN_SENT_TIMESTAMP);
            this.read = message.getInt(CometChatKeys.AjaxKeys.OLD);
            this.self = message.getInt(COLUMN_SELF);
            this.type = message.getString(CometChatKeys.MessageTypeKeys.MESSAGE_TYPE);
            this.imageUrl = message.getString(COLUMN_IMAGE_URL);
            this.insertedBy = message.getInt(COLUMN_MESSAGE_INSERTED_BY);
            this.messagetick = message.getInt(COLOUMN_MESSAGE_TICK);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void clearConversation(String buddyId) {
        String yourId = String.valueOf(SessionData.getInstance().getId());
        String whereClause = "`" + COLUMN_FROM_ID + "` = ? AND `" + COLUMN_TO_ID + "` = ? OR `" + COLUMN_TO_ID
                + "` = ? AND `" + COLUMN_FROM_ID + "` = ?";
        String[] whereArgs = {yourId, buddyId, yourId, buddyId};
        deleteAll(OneOnOneMessage.class, whereClause, whereArgs);
    }

    public static List<OneOnOneMessage> getAllMessages(String fromId, String toId) {
        //String messageLimit = LocalConfig.getMessageLimit();
        /*START CUSTOM*/
        String messageLimit = PreferenceHelper.get(PreferenceKeys.DataKeys.LOAD_EARLIER_COUNT);
        //String messageLimit = LocalConfig.getMessageLimit();

        if (messageLimit.equals("")){
            messageLimit = LocalConfig.getMessageLimit();
        }
        /*END CUSTOM*/
        if (null != JsonPhp.getInstance().getConfig()
                && null != JsonPhp.getInstance().getConfig().getHistoryMessageLimit()) {
            messageLimit = JsonPhp.getInstance().getConfig().getHistoryMessageLimit();
        }
        return findWithQuery(OneOnOneMessage.class, "SELECT * " + COLUMN_FROM + " (SELECT * " + COLUMN_FROM + "`" + TABLE_NAME + "` WHERE `"
                + COLUMN_FROM_ID + "`= " + toId + " AND `" + COLUMN_TO_ID + "` = " + fromId + " OR `" + COLUMN_TO_ID
                + "`=" + toId + " AND `" + COLUMN_FROM_ID + "` = " + fromId + " ORDER BY `" + COLUMN_ID
                + "` DESC LIMIT " + messageLimit + ") ORDER BY `" + COLUMN_ID + "` ASC;", new String[0]);
    }


    public static List<OneOnOneMessage> getAllUnsendMessages(){

        String query = "SELECT * from `"+ TABLE_NAME + "` WHERE `" + COLUMN_REMOTE_ID + "`= " +"0 ORDER BY `" + COLUMN_ID + "` ASC;";

        return findWithQuery(OneOnOneMessage.class,query,new String[0]);
    }

    public static List<OneOnOneMessage> getAllMessages(long fromId, long toId) {
        return getAllMessages(String.valueOf(fromId), String.valueOf(toId));
    }

}
