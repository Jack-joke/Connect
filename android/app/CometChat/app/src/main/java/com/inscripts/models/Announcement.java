/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.models;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Set;

public class Announcement extends SugarRecord {

	private static final String TABLE_NAME = Announcement.class.getSimpleName().toLowerCase(Locale.US);
	private static final String COLUMN_ANNOUNCEMENT_ID = "announcement_id";
	private static final String COLUMN_SENT_TIMESTAMP = "sent_timestamp";

	@Column(name = COLUMN_ANNOUNCEMENT_ID, unique = true, notNull = true)
	public long announcementId;
	public String message;
	public long sentTimestamp, id;

	public static List<Announcement> getAllAnnouncements() {
		return findWithQuery(Announcement.class, "SELECT * FROM `" + TABLE_NAME + "` ORDER BY `"
				+ COLUMN_SENT_TIMESTAMP + "` DESC;", new String[0]);
	}

	public static void deleteAnnouncement(Long announcementId) {
		String whereClause = "`" + COLUMN_ANNOUNCEMENT_ID + "` = ?";
		String[] whereArgs = { String.valueOf(announcementId) };
		deleteAll(Announcement.class, whereClause, whereArgs);
	}

	public static Announcement findById(Long announcementId) {
		List<Announcement> list = find(Announcement.class, "`" + COLUMN_ANNOUNCEMENT_ID + "` = ?",
				String.valueOf(announcementId));
		if (null == list || list.size() == 0) {
			return null;
		} else {
			return list.get(0);
		}
	}

	public static void updateAnnouncements(JSONObject announcements, int announcementId) {
		try {
			Set<Long> ids = new HashSet<Long>();
			ArrayList<Announcement> announcementList = new ArrayList<Announcement>();
			if (announcements.length() > 0) {
				Iterator<String> iterator = announcements.keys();
				while (iterator.hasNext()) {
					JSONObject announcement = announcements.getJSONObject(iterator.next());

					if (announcement.getInt(AjaxKeys.ID) > announcementId) {
						announcementId = announcement.getInt(AjaxKeys.ID);
					}

					Announcement ann = Announcement.findById(announcement.getLong(AjaxKeys.ID));

					if (null == ann) {
						ann = new Announcement();
						PreferenceHelper.save(PreferenceKeys.DataKeys.ANN_BADGE_COUNT,
								Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.ANN_BADGE_COUNT)) + 1);
					}
					ann.announcementId = announcement.getInt(AjaxKeys.ID);
					ann.message = announcement.getString(JsonParsingKeys.STATUS_MESSAGE);
					ann.sentTimestamp = CommonUtils.correctIncomingTimestamp(Long.parseLong(announcement
							.getString(JsonParsingKeys.ANNOUNCEMENT_TIME)));

					announcementList.add(ann);
					ids.add(ann.announcementId);
				}
				String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
				String whereClause = "`" + COLUMN_ANNOUNCEMENT_ID + "` NOT IN (" + csvWithQuote + ")";
				deleteAll(Announcement.class, whereClause, new String[0]);
				saveInTx(announcementList);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
