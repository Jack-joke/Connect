package com.inscripts.activities;

import android.content.BroadcastReceiver;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.adapters.BotListAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Core;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Bot;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.List;

public class BotsActivity extends SuperActivity {
    private Core core;
    private BroadcastReceiver customReceiver;
    private RelativeLayout emptyView;
    private ListView lstViewBot;
    private List<Bot> botList;
    private BotListAdapter botListAdapter;
    private TextView tvNoBots;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bots);
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        Logger.error("Bot list hash "+PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH));
        if(PreferenceHelper.contains(PreferenceKeys.HashKeys.BOT_LIST_HASH) && PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH).isEmpty()){
            fetchBotList();
        }

        core = JsonPhp.getInstance().getLang().getCore();

        if(core.getBots() != null && !core.getBots().isEmpty()){
            getSupportActionBar().setTitle(core.getBots());
        }else {
            getSupportActionBar().setTitle("Bots");
        }
        setupfields();
        if(PreferenceHelper.contains(PreferenceKeys.HashKeys.BOT_LIST_HASH) && PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH) != null && !PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH).isEmpty()){
            updateBotList();
        }


        lstViewBot.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Bot bot = botList.get(i);
                Intent intent = new Intent(getApplicationContext(), BotDetailActivity.class);
                intent.putExtra("BOT_ID",bot.botId+"");
                startActivity(intent);
            }
        });
    }

    private void fetchBotList(){
        VolleyHelper volley = new VolleyHelper(BotsActivity.this, URLFactory.getBotsUrl(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                try{
                    JSONObject resultObject = new JSONObject(response);
                    if(resultObject.has(CometChatKeys.AjaxKeys.BOT_LIST)){

                        //PreferenceHelper.save(PreferenceKeys.HashKeys.BOT_LIST_HASH, resultObject.getString(CometChatKeys.AjaxKeys.BOT_LIST_HAST));

                        if(resultObject.get(CometChatKeys.AjaxKeys.BOT_LIST) instanceof JSONObject){
                            Logger.error("fetBot Got Bot list " + resultObject.getJSONObject(CometChatKeys.AjaxKeys.BOT_LIST));
                            Bot.updateAllBots(resultObject.getJSONObject(CometChatKeys.AjaxKeys.BOT_LIST));

                        }else {
                            Bot.deleteAll(Bot.class);
                        }
                        updateBotList();

                    }

                }catch (JSONException je){
                    Logger.error("Bots exception");
                }


            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });
        volley.sendAjax();
    }

    private void setupfields() {
        lstViewBot = (ListView) findViewById(R.id.list_of_bots);
        emptyView = (RelativeLayout) findViewById(R.id.relativeLayoutbotsMessage);
        lstViewBot.setEmptyView(emptyView);
        tvNoBots = (TextView) findViewById(R.id.textViewNoBotMessage);
        if(JsonPhp.getInstance().getLang().getCore().getNoBots() != null){
            tvNoBots.setText(JsonPhp.getInstance().getLang().getCore().getNoBots());
        }
    }

    private void updateBotList() {
        botList = Bot.getAllbots();
        Logger.error("Bot list size "+botList.size());
            botListAdapter = new BotListAdapter(getApplicationContext(),botList);
            lstViewBot.setAdapter(botListAdapter);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.bots_activity_menu,menu);

        menu.findItem(R.id.custom_refresh_bot_menu).setVisible(false);

        return super.onCreateOptionsMenu(menu);

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.custom_refresh_bot_menu:
                if(PreferenceHelper.contains(PreferenceKeys.HashKeys.BOT_LIST_HASH) && PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH) != null && !PreferenceHelper.get(PreferenceKeys.HashKeys.BOT_LIST_HASH).isEmpty()){
                    Logger.error("Hybrid bots refresh");
                    SessionData.getInstance().setInitialHeartbeat(true);
                    updateBotList();
                }else {
                    Logger.error("Index bots refresh");
                    fetchBotList();
                }

                break;
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }
}
