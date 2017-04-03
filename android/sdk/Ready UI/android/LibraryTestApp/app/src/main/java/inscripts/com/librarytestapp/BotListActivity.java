package inscripts.com.librarytestapp;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.ListView;

import com.inscripts.keys.JsonParsingKeys;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

import adapter.BotListAdapter;
import helper.Keys;
import helper.SharedPreferenceHelper;
import pojo.Bot;

public class BotListActivity extends AppCompatActivity {

    private ListView botListView;
    private ArrayList<Bot> botList;
    private BotListAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_bot_list);
        botListView = (ListView) findViewById(R.id.botListView);
        populateBotList();
    }


    private void populateBotList(){

        String json = SharedPreferenceHelper.get(Keys.SharedPreferenceKeys.BOT_LIST);

        if(json != null && !json.isEmpty()){

            if(botList == null){
                botList = new ArrayList<>();
            }

            botList.clear();
            try {
                JSONObject botObject = new JSONObject(json);
                Iterator<String> keys = botObject.keys();
                Set<Long> ids = new HashSet<>();

                while (keys.hasNext()) {
                    try {
                        JSONObject bot = botObject.getJSONObject(keys.next());

                        Bot botPojo = new Bot();
                        botPojo.botName = bot.getString(JsonParsingKeys.BOT_NAME);
                        botPojo.botDescription = bot.getString(JsonParsingKeys.BOT_DESCRIPTION);
                        botPojo.botAvatar = handelBotAvtarUrl(bot.getString(JsonParsingKeys.BOT_AVATAR));
                        botList.add(botPojo);
                        ids.add(botPojo.botId);
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

            } catch (JSONException e) {
                e.printStackTrace();
            }



            if(botList != null){
                adapter = new BotListAdapter(this,botList);
                botListView.setAdapter(adapter);
            }
        }

    }


    private static String handelBotAvtarUrl(String url){
/*
        if(url.contains("https://") || url.contains("http://") ){
            return url;
        }else{
            String baseurl = PreferenceHelper.get(PreferenceKeys.LoginKeys.BASE_URL);
            String[] split = baseurl.split("/");
            return split[0]+"//"+split[2]+url;
        }*/
        return url;
    }

}
