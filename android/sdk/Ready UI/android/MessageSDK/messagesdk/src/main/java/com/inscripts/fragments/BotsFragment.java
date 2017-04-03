package com.inscripts.fragments;


import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.RelativeLayout;

import com.inscripts.R;
import com.inscripts.activities.BotDetailActivity;
import com.inscripts.adapters.BotListAdapter;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.models.Bot;
import com.inscripts.utils.Logger;

import java.util.List;

public class BotsFragment extends Fragment {

    private BroadcastReceiver customReceiver;
    private RelativeLayout emptyView;
    private ListView lstViewBot;
    private List<Bot> botList;
    private BotListAdapter botListAdapter;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
        customReceiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
                Bundle extras = intent.getExtras();
                if(extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BOT_LIST_FRAGMENT)){
                    updateBotlist();
                }
            }
        };
    }

    public BotsFragment() {
        setRetainInstance(true);
    }


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_bot, container, false);

        lstViewBot = (ListView) view.findViewById(R.id.list_of_bots);
        emptyView = (RelativeLayout) view.findViewById(R.id.relativeLayoutbotsMessage);
        lstViewBot.setEmptyView(emptyView);
        updateBotlist();


        lstViewBot.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Bot bot = botList.get(i);
                Intent intent = new Intent(getContext(), BotDetailActivity.class);
                intent.putExtra("BOT_ID",bot.botId+"");
                startActivity(intent);
            }
        });

        return view;
    }


    private void updateBotlist(){
        botList = Bot.getAllbots();
        botListAdapter = new BotListAdapter(getContext(),botList);
        lstViewBot.setAdapter(botListAdapter);
    }


    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            getActivity().registerReceiver(customReceiver,
                    new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION));
        }
    }


    @Override
    public void onStop() {
        super.onStop();
        if (null != customReceiver) {
            getActivity().unregisterReceiver(customReceiver);
        }
    }


    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        try {

            menu.findItem(R.id.custom_action_search).setVisible(false);

           /* MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
            searchMenuItem.setVisible(false);
            menu.findItem(R.id.custom_action_create_chatroom).setVisible(false);
            menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
            menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
            menu.findItem(R.id.custom_notification).setVisible(true);
            menu.findItem(R.id.custom_action_search).setVisible(true);
            menu.findItem(R.id.custom_setting).setVisible(true);
            menu.findItem(R.id.add_group).setVisible(false);*/
        } catch (Exception e) {
            Logger.error("onCreateOptionsMenu in chatroom.java Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
        super.onCreateOptionsMenu(menu, inflater);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
      /*  switch (item.getItemId()) {
            case R.id.custom_notification:
                Intent AnnouncementIntent = new Intent(getActivity(), AnnouncementActivity.class);
                startActivity(AnnouncementIntent);
                break;

            case R.id.custom_setting:
                Intent settingIntent = new Intent(getActivity(), SettingActivity.class);
                startActivity(settingIntent);
                break;

            default:
                break;
        }*/
        return super.onOptionsItemSelected(item);
    }

}
