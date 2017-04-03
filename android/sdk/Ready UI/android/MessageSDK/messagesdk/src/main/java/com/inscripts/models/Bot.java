package com.inscripts.models;


import android.content.Intent;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.Logger;
import com.orm.SugarRecord;
import com.orm.dsl.Column;

import org.json.JSONObject;

import java.io.File;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Set;

public class Bot extends SugarRecord {

    private static final String TABLE_NAME = Bot.class.getSimpleName().toLowerCase(Locale.US);
    private static final String COLUMN_BOT_ID = "bot_id";
    private static final String COLUMN_BOT_NAME = "bot_name";
    private static final String COLUMN_BOT_DESCRIPTION = "bot_description";
    private static final String COLUMN_BOT_AVATAR = "bot_avatar";

    @Column(name = COLUMN_BOT_ID, unique = true, notNull = true)
    public long botId;

    @Column(name = COLUMN_BOT_NAME)
    public String botName;

    @Column(name = COLUMN_BOT_DESCRIPTION)
    public String botDescription;

    @Column(name = COLUMN_BOT_AVATAR)
    public String botAvatar;


    public static void updateAllBots(JSONObject botList) {
        try {
            if (botList.length() > 0) {
                ArrayList<Bot> bots = new ArrayList<>();
                Iterator<String> keys = botList.keys();
                Set<Long> ids = new HashSet<>();

                while (keys.hasNext()) {
                    try {
                        JSONObject bot = botList.getJSONObject(keys.next());
                        Bot botPojo = getBotDetails(bot.getString(JsonParsingKeys.BOT_ID));
                        if (null == botPojo) {
                            botPojo = new Bot();
                            botPojo.botId = bot.getLong(JsonParsingKeys.BOT_ID);
                        }
                        botPojo.botName = bot.getString(JsonParsingKeys.BOT_NAME);
                        botPojo.botDescription = bot.getString(JsonParsingKeys.BOT_DESCRIPTION);
                        botPojo.botAvatar = handelBotAvtarUrl(bot.getString(JsonParsingKeys.BOT_AVATAR));
                        bots.add(botPojo);
                        ids.add(botPojo.botId);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                iintent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BOT_LIST_FRAGMENT, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);


                String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");
                String whereClause = "`" + COLUMN_BOT_ID + "` NOT IN (" + csvWithQuote + ")";

                deleteAll(Bot.class, whereClause, new String[0]);

				/* Bulk insert. */
                saveInTx(bots);
            }  else {
                deleteAll(Bot.class);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }



    public static List<Bot> getAllbots() {
        return findWithQuery(Bot.class, "SELECT * FROM `" + TABLE_NAME + "` ORDER BY `" + COLUMN_BOT_NAME +
                /*+ "` , `"+ COLUMN_STATUS+*/"` DESC;", new String[0]);
    }


    public static Bot getBotDetails(String botId) {
        Set<Long> ids = new HashSet<>();
        ids.add(Long.parseLong(botId));
        String csvWithQuote = ids.toString().replace("[", "'").replace("]", "'").replace(", ", "','");

        List<Bot> list = findWithQuery(Bot.class, "SELECT * FROM `" + TABLE_NAME + "` WHERE `" + COLUMN_BOT_ID + "` IN ("
                + csvWithQuote + ");", new String[0]);
        if (null == list || list.size() == 0) {
            return null;
        } else {
            return list.get(0);
        }
    }



    private static String handelBotAvtarUrl(String url){
        //Logger.error("Bots avatar  before handle "+url);
        url = url.replaceAll("\\\\", File.separator);
        Logger.error("Bots avatar  before handle "+url);
        if(url.contains("https://") || url.contains("http://") ){
            return url;
        }else{
            String baseurl = PreferenceHelper.get(PreferenceKeys.LoginKeys.BASE_URL);
            String[] split = baseurl.split("/");
            return split[0]+"//"+split[2]+url;
        }

    }
}
