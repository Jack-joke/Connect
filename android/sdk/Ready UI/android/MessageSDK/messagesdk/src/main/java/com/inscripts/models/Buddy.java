/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.models;

import android.content.Intent;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Set;

public class Buddy extends SugarRecord {

    private static final String TABLE_NAME = Buddy.class.getSimpleName().toLowerCase(Locale.US);
    private static final String COLUMN_BUDDY_ID = "buddy_id";
    private static final String COLUMN_LAST_UPDATED = "last_updated";
    private static final String COLUMN_UNREAD_COUNT = "unread_count";
    private static final String COLUMN_NAME = "name";
    private static final String COLUMN_COMET_ID = "cometid";
    private static final String COLUMN_LASTSEEN = "lastseen";
    private static final String LSTN = "lstn";
    private static final String SHOW_USER = "showuser";

    @Column(name = COLUMN_BUDDY_ID, unique = true, notNull = true)
    public long buddyId;
    public long lastUpdated, id;
    public int unreadCount, lstn, showuser = 1;
    public String name, link, avatarURL, status, statusMessage, cometid = "", lastseen = "";

    public static void updateAllBuddies(JSONArray buddyList) {
        try {
            if (buddyList.length() > 0) {
                ArrayList<Buddy> buddies = new ArrayList<Buddy>();
                Set<Long> ids = new HashSet<>();
                int i, len = buddyList.length();
                for (i = 0; i < len; i++) {
                    JSONObject buddy = buddyList.getJSONObject(i);
                    Buddy buddyPojo = getBuddyDetails(buddy.getLong(JsonParsingKeys.ID));
                    if (null == buddyPojo) {
                        buddyPojo = new Buddy();
                        buddyPojo.buddyId = buddy.getLong(JsonParsingKeys.ID);
                        buddyPojo.lastUpdated = 0;
                    }
                    buddyPojo.showuser = 1;
                    buddyPojo.name = CommonUtils.ucWords(buddy.getString(JsonParsingKeys.NAME));
                    buddyPojo.link = buddy.getString(JsonParsingKeys.LINK);
                    buddyPojo.avatarURL = CommonUtils.processAvatarUrl(buddy.getString(JsonParsingKeys.AVATAR_LINK));
                    buddyPojo.status = buddy.getString(JsonParsingKeys.STATUS);
                    buddyPojo.statusMessage = buddy.getString(JsonParsingKeys.STATUS_MESSAGE);
                    if (buddy.has(JsonParsingKeys.LSTN)) {
                        String lstn = buddy.getString(JsonParsingKeys.LSTN);
                        if (lstn == null || lstn.isEmpty() || lstn.equals("") || lstn.equals("null")) {
                            buddyPojo.lstn = 1;
                        } else {
                            buddyPojo.lstn = Integer.parseInt(lstn);
                        }
                    }
                    if (buddy.has(JsonParsingKeys.LASTSEEN)) {
                        String lastseen = buddy.getString(JsonParsingKeys.LASTSEEN);

                        if (lastseen == null || lastseen.equals("0") || lastseen.equals("") || lastseen.equals("null")) {
                            buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(0L));
                        } else {
                            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                                Long n = CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
                                buddyPojo.lastseen = String.valueOf(n);
                            } else {
                                buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)));
                            }
                        }
                    }
                    if (buddy.has(JsonParsingKeys.CSCHANNEL)) {
                        buddyPojo.cometid = buddy.getString(JsonParsingKeys.CSCHANNEL);
                    }
                    buddies.add(buddyPojo);
                    ids.add(buddyPojo.buddyId);
                }

                String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");

                String whereClause = "`" + COLUMN_BUDDY_ID + "` NOT IN (" + csvWithQuote + ")";

                List<Buddy> removedbuddy = findWithQuery(Buddy.class, "SELECT  * FROM `" + TABLE_NAME + "` WHERE " + whereClause);
                for (Buddy buddy : removedbuddy) {
                   /* if (buddy.unreadCount > 0) {
                        int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_CHAT_BADGE));
                        count--;
                        if (count >= 0) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, count);
                        }
                    }*/
                    buddy.showuser = 0;
                }
                Buddy.saveInTx(removedbuddy);
                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);
                SessionData.getInstance().setChatbadgeMissed(true);
                //deleteAll(Buddy.class, whereClause, new String[0]);
                /* Bulk insert. */
                saveInTx(buddies);
            } else {
                //PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, 0);
                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);
                SessionData.getInstance().setChatbadgeMissed(true);
                //deleteAll(Buddy.class);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void updateAllBuddies(JSONObject buddyList) {
        try {
            if (buddyList.length() > 0) {
                ArrayList<Buddy> buddies = new ArrayList<>();
                Iterator<String> keys = buddyList.keys();
                Set<Long> ids = new HashSet<>();

                while (keys.hasNext()) {
                    try {
                        JSONObject buddy = buddyList.getJSONObject(keys.next());
                        Buddy buddyPojo = getBuddyDetails(buddy.getLong(JsonParsingKeys.ID));
                        if (null == buddyPojo) {
                            buddyPojo = new Buddy();
                            buddyPojo.buddyId = buddy.getLong(JsonParsingKeys.ID);
                            buddyPojo.lastUpdated = 0;
                        }
                        buddyPojo.showuser = 1;
                        buddyPojo.name = CommonUtils.ucWords(buddy.getString(JsonParsingKeys.NAME));
                        buddyPojo.link = buddy.getString(JsonParsingKeys.LINK);
                        buddyPojo.avatarURL = CommonUtils.processAvatarUrl(buddy.getString(JsonParsingKeys.AVATAR_LINK));
                        if (buddy.has(JsonParsingKeys.LSTN)) {
                            String lstn = buddy.getString(JsonParsingKeys.LSTN);
                            if (lstn == null || lstn.isEmpty() || lstn.equals("") || lstn.equals("null")) {
                                buddyPojo.lstn = 1;
                            } else {
                                buddyPojo.lstn = Integer.parseInt(lstn);
                            }
                        }
                        if (buddy.has(JsonParsingKeys.LASTSEEN)) {
                            String lastseen = buddy.getString(JsonParsingKeys.LASTSEEN);

                            if (lastseen == null || lastseen.equals("0") || lastseen.equals("") || lastseen.equals("null")) {
                                buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(0L));
                            } else {
                                if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                                    Long n = CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
                                    buddyPojo.lastseen = String.valueOf(n);
                                } else {
                                    buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)));
                                }
                            }
                        }

                        buddyPojo.status = buddy.getString(JsonParsingKeys.STATUS);
                        buddyPojo.statusMessage = buddy.getString(JsonParsingKeys.STATUS_MESSAGE);
                        if (buddy.has(JsonParsingKeys.CSCHANNEL)) {
                            buddyPojo.cometid = buddy.getString(JsonParsingKeys.CSCHANNEL);
                        }
                        buddies.add(buddyPojo);
                        ids.add(buddyPojo.buddyId);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

                String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
                String whereClause = "`" + COLUMN_BUDDY_ID + "` NOT IN (" + csvWithQuote + ")";

                List<Buddy> removedbuddy = findWithQuery(Buddy.class, "SELECT  * FROM `" + TABLE_NAME + "` WHERE " + whereClause);
                for (Buddy buddy : removedbuddy) {
                   /* if (buddy.unreadCount > 0) {
                        int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_CHAT_BADGE));
                        count--;
                        if (count >= 0) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, count);
                        }
                    }*/
                    buddy.showuser = 0;
                }
                Buddy.saveInTx(removedbuddy);

                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);
                SessionData.getInstance().setChatbadgeMissed(true);
                //deleteAll(Buddy.class, whereClause, new String[0]);

				/* Bulk insert. */
                saveInTx(buddies);
            } else {
                Logger.error("buddy length is 0 " + buddyList);
                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);
                SessionData.getInstance().setChatbadgeMissed(true);
                //deleteAll(Buddy.class);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void insertNewBuddy(JSONObject buddy, Callbacks callback) {
        try {
            Buddy buddyPojo = getBuddyDetails(buddy.getLong(JsonParsingKeys.ID));
            if (buddyPojo == null) {
                buddyPojo = new Buddy();
                buddyPojo.buddyId = buddy.getLong(JsonParsingKeys.ID);
                buddyPojo.name = CommonUtils.ucWords(buddy.getString(JsonParsingKeys.NAME));
                buddyPojo.link = buddy.getString(JsonParsingKeys.LINK);
                buddyPojo.avatarURL = CommonUtils.processAvatarUrl(buddy.getString(JsonParsingKeys.AVATAR_LINK));
                buddyPojo.status = buddy.getString(JsonParsingKeys.STATUS);
                buddyPojo.statusMessage = buddy.getString(JsonParsingKeys.STATUS_MESSAGE);
                buddyPojo.lastUpdated = System.currentTimeMillis();
                buddyPojo.showuser = 1;
                if (buddy.has(JsonParsingKeys.LSTN)) {
                    String lstn = buddy.getString(JsonParsingKeys.LSTN);
                    if (lstn == null || lstn.isEmpty() || lstn.equals("") || lstn.equals("null")) {
                        buddyPojo.lstn = 1;
                    } else {
                        buddyPojo.lstn = Integer.parseInt(lstn);
                    }
                }
                if (buddy.has(JsonParsingKeys.LASTSEEN)) {
                    String lastseen = buddy.getString(JsonParsingKeys.LASTSEEN);

                    if (lastseen == null || lastseen.equals("0") || lastseen.equals("") || lastseen.equals("null")) {
                        buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(0L));
                    } else {
                        if (PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE) != null) {
                            Long n = CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)) + Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.SERVER_DIFFERENCE));
                            buddyPojo.lastseen = String.valueOf(n);
                        } else {
                            buddyPojo.lastseen = String.valueOf(CommonUtils.correctIncomingTimestamp(Long.parseLong(lastseen)));
                        }
                    }
                }

                if (buddy.has(JsonParsingKeys.CSCHANNEL)) {
                    buddyPojo.cometid = buddy.getString(JsonParsingKeys.CSCHANNEL);
                }
                buddyPojo.save();
            }
        } catch (Exception e) {
            //e.printStackTrace();
            if (null != callback) {
                try {
                    callback.failCallback(new JSONObject().put(CometChatKeys.ErrorKeys.CODE_USER_NOT_FOUND, CometChatKeys.ErrorKeys.MESSAGE_USER_NOT_FOUND));
                } catch (Exception e1) {

                }
            }
            //return 0;
        }
    }

    public static Buddy getBuddyDetails(String buddyId) {
        Set<Long> ids = new HashSet<>();
        ids.add(Long.parseLong(buddyId));
        String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");

        List<Buddy> list = findWithQuery(Buddy.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_BUDDY_ID + "` IN ("
                + csvWithQuote + ");", new String[0]);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }

    public static Buddy getBuddyDetails(Integer buddyId) {
        return getBuddyDetails(String.valueOf(buddyId));
    }

    public static Buddy getBuddyDetails(Long buddyId) {
        return getBuddyDetails(String.valueOf(buddyId));
    }

    /*public static List<Buddy> getAllBuddies() {
        return findWithQuery(Buddy.class, "SELECT * FROM `" + TABLE_NAME + "` ORDER BY `" + COLUMN_LAST_UPDATED
                + "` DESC;", new String[0]);
    }*/

    public static List<Buddy> getAllVisibieBuddies() {
        return findWithQuery(Buddy.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + SHOW_USER + "` = 1 ORDER BY `" + COLUMN_LAST_UPDATED
                + "` DESC;", new String[0]);
    }

    /* Get all users who are not a part of the chatroom. */
    public static List<Buddy> getExternalBuddies(Set<String> ids) {
        String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
        return findWithQuery(Buddy.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_BUDDY_ID + "` NOT IN ("
                + csvWithQuote + ");", new String[0]);
    }

    public static List<Buddy> searchBuddies(String searchText) {
        String rawQuery = "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_NAME + "` LIKE '%" + searchText
                + "%' AND `" + SHOW_USER + "`=1 ORDER BY `" + COLUMN_LAST_UPDATED + "` DESC";
        return findWithQuery(Buddy.class, rawQuery, new String[0]);
    }

    public static Buddy searchBuddy(long searchText) {
        String rawQuery = "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_BUDDY_ID + "` ='" + searchText
                + "' AND `" + SHOW_USER + "`=1";
        List<Buddy> buddies = findWithQuery(Buddy.class, rawQuery, new String[0]);
        if (null == buddies) {
            return null;
        } else {
            return buddies.get(0);
        }
    }

    public static int getUnreadBuddyCount() {
        List<Buddy> buddies = findWithQuery(Buddy.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + SHOW_USER + "` = 1 AND `" + COLUMN_UNREAD_COUNT + "` >" + 0);
        if (buddies == null || buddies.size() == 0) {
            return 0;
        } else {
            return buddies.size();
        }
    }

/*    public static void deleteById(Long buddyId) {
        deleteAll(Buddy.class, "`" + COLUMN_BUDDY_ID + "` = " + buddyId, new String[0]);
    }*/
}
