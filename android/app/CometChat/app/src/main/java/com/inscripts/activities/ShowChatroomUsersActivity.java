/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import com.inscripts.adapters.ChatroomUsersListAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.pojos.ChatroomMembers;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;


public class ShowChatroomUsersActivity extends SuperActivity {

    private ListView listview;
    private ChatroomUsersListAdapter adapter;
    //private BroadcastReceiver receiver;
    private TextView tvnousers;
    private ArrayList<ChatroomMembers> members;
    private ProgressWheel wheel;
    private MobileTheme theme;
    private Css css;
    private long chatroomid = 0l;
    private long tempChatroomId = 0l;
    private long tempUserId = 0l;
    private int index;
    private int versionnumber;
    private static String kick;
    private static String ban;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_chatroom_users);
        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));

        versionnumber = CommonUtils.getVersionCode(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE));
        listview = (ListView) findViewById(R.id.listViewViewChatroomUsers);
        tvnousers = (TextView) findViewById(R.id.textViewNoUsersMessage);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        theme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();
        Intent intent = getIntent();
        chatroomid = intent.getLongExtra(CometChatKeys.ChatroomKeys.INTENT_CHATROOM_ID, 0);


        if (JsonPhp.getInstance().getLang() != null && JsonPhp.getInstance().getLang().getChatrooms().get40() != null){
            kick = JsonPhp.getInstance().getLang().getChatrooms().get40();
        }else{
            kick = "Kick";
        }
        if (JsonPhp.getInstance().getLang() != null && JsonPhp.getInstance().getLang().getChatrooms().get41() != null){
            ban = JsonPhp.getInstance().getLang().getChatrooms().get41();
        }else{
            ban = "Ban";
        }

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
/*
        receiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
                setupChatroomMembersList(PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS));
            }
        };*/

        fetchUserListFromServer();


        if (versionnumber >= 600){
            registerForContextMenu(listview);
        }
        listview.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if (null != members && members.size() > 0) {
                    startWheel();
                    ChatroomMembers member = members.get(position);
                    final Long userid = member.getId();
                    Logger.error("user id = "+userid);
                    if (userid == SessionData.getInstance().getId()) {
                        Intent intent = new Intent(getApplicationContext(), CometChatActivity.class);
                        //intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        //intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.OPEN_SETTINGS, "1");
                        startActivity(intent);
                        finish();
                    } else {
                        Buddy buddy = Buddy.getBuddyDetails(userid);
                        if(/*JsonPhp.getInstance().getConfig().getCrpersonalchatEnabled() != null && JsonPhp.getInstance().getConfig().getCrpersonalchatEnabled().equals("1") &&*/ buddy.showuser == 1){
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
                                }, 0);
                            } else {
                                Intent intent = new Intent(getApplicationContext(), SingleChatActivity.class);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, userid);
                                startActivity(intent);
                                stopWheel();
                            }

                        }else if (JsonPhp.getInstance().getConfig().getCrpersonalchatEnabled() != null && JsonPhp.getInstance().getConfig().getCrpersonalchatEnabled().equals("0")) {
                            //disable onclick
                            stopWheel();
                        }else{
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
                                }, 0);
                            } else {
                                Intent intent = new Intent(getApplicationContext(), SingleChatActivity.class);
                                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, userid);
                                startActivity(intent);
                                stopWheel();
                            }
                        }

                    }
                }
            }
        });
        if (null != theme && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            wheel.setBarColor(btnColor);
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            wheel.setBarColor(btnColor);
        }
    }


    void fetchUserListFromServer(){
        VolleyHelper volleyHelper = new VolleyHelper(ShowChatroomUsersActivity.this, URLFactory.getChatroomUserListUrl(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                Logger.error("Get UserList responce = "+response);
                try {
                    JSONObject jsonObject = new JSONObject(response);
                    Logger.error("User json object = "+jsonObject.getString("users"));
                    PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS,jsonObject.getString("users"));
                    setupChatroomMembersList(jsonObject.getString("users"));
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });

        volleyHelper.addNameValuePair("currentroom",chatroomid);
        volleyHelper.addNameValuePair("basedata",PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
        volleyHelper.sendAjax();
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;
        index = info.position;
        ChatroomMembers member = members.get(index);
        tempUserId = member.getId();
        tempChatroomId = SessionData.getInstance().getCurrentChatroom();
        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomid);
        if(tempUserId != SessionData.getInstance().getId() && chatroom.createdBy == 1){
            menu.add(0, v.getId(), 0, kick);
        }
        if(tempUserId != SessionData.getInstance().getId() && ((null != SessionData.getInstance().getIsModerator() && SessionData.getInstance().getIsModerator().equals("1")) || chatroom.createdBy == 1)){
            menu.add(0, v.getId(), 0, ban);
        }
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        String title = (String) item.getTitle();
        if (title.equals(kick)){
            ChatroomManager.kickUserChatroom(tempUserId, 1);
            members.remove(members.get(index));
            adapter.notifyDataSetChanged();
        }else if(title.equals(ban)){
            ChatroomManager.banUserChatroom(tempUserId,tempChatroomId,1);
            members.remove(members.get(index));
            adapter.notifyDataSetChanged();
        }
        return true;
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
    public void onStart() {
        super.onStart();
        /*if (null != receiver) {
            getApplicationContext().registerReceiver(receiver, new IntentFilter(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_CHATROOM_MEMBERS));
        }*/
    }

    @Override
    protected void onStop() {
        super.onStop();
       /* if (null != receiver) {
            getApplicationContext().unregisterReceiver(receiver);
        }*/
    }

    @Override
    public void finish() {
        super.finish();
        stopWheel();
    }

    private void startWheel() {
        wheel.spin();
        wheel.setVisibility(View.VISIBLE);
    }

    private void stopWheel() {
        wheel.stopSpinning();
        wheel.setProgress(0f);
        wheel.setVisibility(View.GONE);
    }

    /*@Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_show_chatroom_users, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        return super.onOptionsItemSelected(item);
    }*/
}
