/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.adapters.ChatroomUsersListAdapter;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.pojos.ChatroomMembers;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;


public class ShowChatroomUsersActivity extends SuperActivity {

    private ListView listview;
    private ChatroomUsersListAdapter adapter;
    private BroadcastReceiver receiver;
    private TextView tvnousers;
    private ArrayList<ChatroomMembers> members;
    private ProgressBar wheel;
    private MobileTheme theme;
    private Css css;
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_show_chatroom_users);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        listview = (ListView) findViewById(R.id.listViewViewChatroomUsers);
        tvnousers = (TextView) findViewById(R.id.textViewNoUsersMessage);
        wheel = (ProgressBar) findViewById(R.id.progressWheel);
        theme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get91()) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get91());
        } else {
            setActionBarTitle(this.getTitle());
        }

        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS)) {
            setupChatroomMembersList(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS));
            tvnousers.setVisibility(View.GONE);
        } else {
            tvnousers.setVisibility(View.VISIBLE);
            if (!TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get95())) {
                tvnousers.setText(JsonPhp.getInstance().getLang().getMobile().get95());
            }
        }

        receiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
                setupChatroomMembersList(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS));
            }
        };

        listview.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if (null != members && members.size() > 0) {
                    startWheel();
                    ChatroomMembers member = members.get(position);
                    final Long userid = member.getId();
                    if (userid == SessionData.getInstance().getId()) {
                        Intent intent = new Intent(getApplicationContext(), CometChatActivity.class);
                        //intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        //intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.OPEN_SETTINGS, "1");
                        startActivity(intent);
                        finish();
                    } else {
                        Buddy buddy = Buddy.getBuddyDetails(userid);
                        if (buddy == null) {
                            MessageHelper.getInstance().addNewBuddy(userid, getApplicationContext(), new CometchatCallbacks() {
                                @Override
                                public void successCallback() {
                                    Intent intent = new Intent(getApplicationContext(), SingleChatActivity.class);
                                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, userid);
                                    startActivity(intent);
                                    stopWheel();
                                }

                                @Override
                                public void failCallback() {
                                    stopWheel();
                                }
                            },null);
                        } else {
                            Intent intent = new Intent(getApplicationContext(), SingleChatActivity.class);
                            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, userid);
                            startActivity(intent);
                            stopWheel();
                        }
                    }
                }
            }
        });
        if (null != theme && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
        }
    }

    private void setupChatroomMembersList(String chatroomMembers) {
        try {
            startWheel();
            JSONObject chatroomMembersjson = new JSONObject(chatroomMembers);
            Iterator itr = chatroomMembersjson.keys();
            Long myid = SessionData.getInstance().getId();
            members = new ArrayList<>();
            while (itr.hasNext()) {
                ChatroomMembers member = new ChatroomMembers();
                JSONObject data = chatroomMembersjson.getJSONObject(itr.next().toString());
                member.setId(data.getLong("id"));
                member.setAvatarUrl(CommonUtils.processAvatarUrl(data.getString("a")));
                member.setBanned(data.getInt("b"));
                if (myid == member.getId()) {
                    if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get89()) {
                        member.setName(JsonPhp.getInstance().getLang().getMobile().get89());
                    } else {
                        member.setName("You");
                    }
                } else {
                    member.setName(data.getString("n"));
                }
                members.add(member);
            }
            if (adapter == null) {
                adapter = new ChatroomUsersListAdapter(getApplicationContext(), members);
                listview.setAdapter(adapter);
            } else {
                adapter.clear();
                adapter.addAll(members);
            }

            if (members.size() == 0) {
                tvnousers.setVisibility(View.VISIBLE);
                if (!TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get95())) {
                    tvnousers.setText(JsonPhp.getInstance().getLang().getMobile().get95());
                }
            } else {
                tvnousers.setVisibility(View.GONE);
            }
            stopWheel();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            finish();
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onStart() {
        super.onStart();
        if (null != receiver) {
            getApplicationContext().registerReceiver(receiver, new IntentFilter(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_CHATROOM_MEMBERS));
        }
    }

    @Override
    protected void onStop() {
        super.onStop();
        if (null != receiver) {
            getApplicationContext().unregisterReceiver(receiver);
        }
    }

    @Override
    public void finish() {
        super.finish();
        stopWheel();
        overridePendingTransition(0, 0);
    }

    private void startWheel() {
        wheel.setVisibility(View.VISIBLE);
    }

    private void stopWheel() {
        wheel.setVisibility(View.GONE);
    }

    /*@Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.cc_menu_show_chatroom_users, menu);
        return true;
    }

    */
}
