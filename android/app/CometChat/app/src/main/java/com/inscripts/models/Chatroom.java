/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.models;

import com.inscripts.keys.JsonParsingKeys;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Set;

public class Chatroom extends SugarRecord {

    private static final String TABLE_NAME = Chatroom.class.getSimpleName().toLowerCase(Locale.US);
    private static final String COLUMN_CHATROOM_ID = "chatroom_id";
    private static final String COLUMN_LAST_UPDATED = "last_updated";
    private static final String COLUMN_UNREAD_COUNT = "unread_count";
    private static final String COLUMN_NAME = "name";
    private static final String COLUMN_STATUS = "status";

    /**
     * Chatroom id
     */
    @Column(name = COLUMN_CHATROOM_ID, unique = true, notNull = true)
    public long chatroomId;


    @Column(name = COLUMN_STATUS)
    public int status;

    /**
     * The parameter 's' which contain one of the 3 values, namely: 0 (another
     * user), 1 (created by self), 2 (created by moderator)
     */
    public int createdBy;
    public long lastUpdated, id;

    /**
     * The parameter 'type' which may contain one of the 3 values, namely: 0
     * (public), 1 (password protected), 2 (invite only)
     */
    public int type;
    public int unreadCount, memberCount, onlineCount;
    public String name, password;

    public static void updateAllChatrooms(JSONObject chatroomList) {
        try {
            if (chatroomList.length() > 0) {
                ArrayList<Chatroom> chatrooms = new ArrayList<Chatroom>();
                Iterator<String> keys = chatroomList.keys();
                Set<Long> ids = new HashSet<Long>();

                while (keys.hasNext()) {
                    try {
                        JSONObject chatroomJson = chatroomList.getJSONObject(keys.next());
                        Chatroom chatroom = getChatroomDetails(chatroomJson.getLong(JsonParsingKeys.ID));
                        if (null == chatroom) {
                            chatroom = new Chatroom();
                            chatroom.chatroomId = chatroomJson.getLong(JsonParsingKeys.ID);
                            chatroom.lastUpdated = System.currentTimeMillis();
                        }
                        chatroom.chatroomId = chatroomJson.getLong(JsonParsingKeys.ID);
                        chatroom.name = chatroomJson.getString(JsonParsingKeys.CHATROOM_NAME);
                        chatroom.onlineCount = chatroomJson.getInt(JsonParsingKeys.ONLINE);
                        chatroom.type = chatroomJson.getInt(JsonParsingKeys.TYPE);
                        chatroom.password = chatroomJson.getString(JsonParsingKeys.CHATROOM_PASSWORD);
                        chatroom.createdBy = chatroomJson.getInt(JsonParsingKeys.CREATED_BY);

                        if(chatroomJson.has(JsonParsingKeys.CHATROOM_STATUS)){
                            chatroom.status = chatroomJson.getInt(JsonParsingKeys.CHATROOM_STATUS);
                        }else{
                            chatroom.status = 0;
                        }


                        chatrooms.add(chatroom);
                        ids.add(chatroom.chatroomId);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
                String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
                String whereClause = "`" + COLUMN_CHATROOM_ID + "` NOT IN (" + csvWithQuote + ")";
                // String whereArgs = csvWithQuote;
                deleteAll(Chatroom.class, whereClause, new String[0]);
                /* Bulk insert. */
                saveInTx(chatrooms);
            } else {
                deleteAll(Chatroom.class);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static Chatroom getChatroomDetails(String chatroomId) {
        List<Chatroom> list = find(Chatroom.class, "`" + COLUMN_CHATROOM_ID + "` = ?", chatroomId);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }

    public static Chatroom getChatroomDetails(Integer chatroomId) {
        return getChatroomDetails(String.valueOf(chatroomId));
    }

    public static Chatroom getChatroomDetails(Long chatroomId) {
        return getChatroomDetails(String.valueOf(chatroomId));
    }

    public static List<Chatroom> getAllChatrooms() {
        return findWithQuery(Chatroom.class, "SELECT * FROM `" + TABLE_NAME + "` ORDER BY `" + COLUMN_STATUS +
                /*+ "` , `"+ COLUMN_STATUS+*/"` DESC;", new String[0]);
    }

    @Override
    public long save() {
        // Thread.dumpStack();
        return super.save();
    }

    public static List<Chatroom> searchChatrooms(String searchText) {
        String rawQuery = "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_NAME + "` LIKE '%" + searchText
                + "%' ORDER BY `" + COLUMN_LAST_UPDATED + "` DESC";
        return findWithQuery(Chatroom.class, rawQuery, new String[0]);
    }

    public static void deleteChatroom(Long chatroomid) {
        deleteAll(Chatroom.class, "`" + COLUMN_CHATROOM_ID + "` = " + chatroomid, new String[0]);
    }

    public static int getUnreadChatroomCount() {
        List<Chatroom> chatrooms = findWithQuery(Chatroom.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_UNREAD_COUNT + "` >" + 0);
        if (chatrooms == null || chatrooms.size() == 0) {
            return 0;
        } else {
            return chatrooms.size();
        }
    }
}