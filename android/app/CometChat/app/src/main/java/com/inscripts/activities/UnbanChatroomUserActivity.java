/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.inscripts.adapters.UnbanChatroomUserAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.pojos.UnbanUsers;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;


public class UnbanChatroomUserActivity extends SuperActivity{
    private UnbanChatroomUserAdapter adapter;
    private ListView listview;
    private ArrayList<UnbanUsers> unban;
    private TextView tv;
    private Button cancel, send;
    private LinearLayout buttonContainer;
    private String checkBoxKeyForBundle = "checkBoxKeyForBundle";
    private Boolean flag = false;
    private String TRUE = "true";
    private String FALSE = "false";
    ArrayList<String> positionChecked = new ArrayList<>();
    ArrayList<String> savedCheckbox = new ArrayList<>();
    Lang lang = JsonPhp.getInstance().getLang();
    private String title;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_unban_chatroom_user);
        Intent intent = getIntent();
        unban = new ArrayList<>();
        title = (null == lang.getChatrooms().get68()) ? title : lang.getChatrooms().get68();
        setActionBarTitle(title);
        final long id = intent.getLongExtra(BroadcastReceiverKeys.IntentExtrasKeys.CHATROOM_ID,0);
        cancel = (Button) findViewById(R.id.buttonCancel);
        send = (Button) findViewById(R.id.buttonUnbanUser);
        buttonContainer = (LinearLayout) findViewById(R.id.relativeLayoutInviteUserFooter);
        listview = (ListView) findViewById(R.id.listView);
        tv = (TextView) findViewById(R.id.noUser);

        if (null != lang && null != lang.getChatrooms() && null != lang.getChatrooms().get44()){
            tv.setText(lang.getChatrooms().get44());
        }

        cancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendUnbanUserList(id);
            }
        });

        if (savedInstanceState == null){
            final VolleyHelper vhelper = new VolleyHelper(this, URLFactory.getUnbanChatroomUserURL(), new VolleyAjaxCallbacks() {
                @Override
                public void successCallback(String response) {
                    PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_UNBAN_USERS, response);
                    setUpUnbanUsers();
                    setUpUnbanUsersList();
                }
                @Override
                public void failCallback(String response, boolean isNoInternet) {
                }
            });
            vhelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, CometChatKeys.ChatroomKeys.UNBAN);
            vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, id);
            vhelper.sendAjax();
        }else {
            if (null != savedInstanceState) {
                flag = true;
                savedCheckbox = savedInstanceState.getStringArrayList(checkBoxKeyForBundle);
                setUpUnbanUsersSaved();
                setUpUnbanUsersListFromSaved(savedCheckbox);
            }
        }

        listview.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                CheckBox cb = (CheckBox) view.findViewById(R.id.checkbox);
                if (cb.isChecked()){
                    cb.setChecked(!cb.isChecked());
                    positionChecked.set(position, FALSE);
                    adapter.toggleUnban(position,FALSE);
                }else{
                    cb.setChecked(!cb.isChecked());
                    positionChecked.set(position, TRUE);
                    adapter.toggleUnban(position, TRUE);
                }
                adapter.notifyDataSetChanged();
            }
        });
    }

    public void setUpUnbanUsers(){
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_UNBAN_USERS)){
            String response = PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_UNBAN_USERS);
            if (!PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_UNBAN_USERS).equals("{\"unban\":[]}")){
                unban = new ArrayList<>();
                try {
                    JSONObject jsonObject = new JSONObject(response);
                    JSONObject result = jsonObject.getJSONObject(CometChatKeys.ChatroomKeys.UNBAN);
                    Iterator<String> keys = result.keys();
                    while (keys.hasNext()) {
                        JSONObject unbanList = result.getJSONObject(keys.next());
                        UnbanUsers unbanUsers = new UnbanUsers();
                        unbanUsers.setId(Long.parseLong(unbanList.getString("id")));
                        unbanUsers.setName(unbanList.getString("n"));
                        unbanUsers.setAvatarUrl(unbanList.getString("a"));
                        unban.add(unbanUsers);
                    }
                    tv.setVisibility(View.GONE);
                    buttonContainer.setVisibility(View.VISIBLE);
                    for (int i = 0; i< unban.size();i++){
                        positionChecked.add(FALSE);
                    }
                }catch (Exception e){
                    e.printStackTrace();
                }
            }
        }
    }

    public void setUpUnbanUsersSaved(){
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_UNBAN_USERS)){
            String response = PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_UNBAN_USERS);
            if (!PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_UNBAN_USERS).equals("{\"unban\":[]}")){
                try {
                    JSONObject jsonObject = new JSONObject(response);
                    JSONObject result = jsonObject.getJSONObject(CometChatKeys.ChatroomKeys.UNBAN);
                    Iterator<String> keys = result.keys();
                    while (keys.hasNext()) {
                        JSONObject unbanList = result.getJSONObject(keys.next());
                        UnbanUsers unbanUsers = new UnbanUsers();
                        unbanUsers.setId(Long.parseLong(unbanList.getString("id")));
                        unbanUsers.setName(unbanList.getString("n"));
                        unbanUsers.setAvatarUrl(unbanList.getString("a"));
                        unban.add(unbanUsers);
                    }
                    tv.setVisibility(View.GONE);
                    buttonContainer.setVisibility(View.VISIBLE);
                    for (int i = 0; i< unban.size();i++){
                        positionChecked.add(savedCheckbox.get(i));
                    }
                }catch (Exception e){
                    e.printStackTrace();
                }
            }
        }
    }
    public void setUpUnbanUsersList(){
        adapter = new UnbanChatroomUserAdapter(getApplicationContext(),unban,positionChecked);
        listview.setAdapter(adapter);
    }
    public void setUpUnbanUsersListFromSaved(final ArrayList<String> checkBoxState){
        adapter = new UnbanChatroomUserAdapter(getApplicationContext(),unban,checkBoxState);
        listview.setAdapter(adapter);
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if (adapter != null) {
            ArrayList<String> invitedUsers = adapter.getUnbanUsersList();
            outState.clear();
            outState.putStringArrayList(checkBoxKeyForBundle, invitedUsers);
        }
    }
    public void sendUnbanUserList(long id){
        Chatroom chatroom = Chatroom.getChatroomDetails(id);
        VolleyHelper volleyHelper = new VolleyHelper(this, URLFactory.getUnbanChatroomUserListURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                Logger.error("REsponse users "+response);
                finish();
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });
        volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, CometChatKeys.ChatroomKeys.UNBANUSER);
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.UNBAN, adapter.getUnbanUsersListIds().toString());
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, id);
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITEDID, chatroom.password);
        volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMNAME, chatroom.name);
        volleyHelper.sendAjax();
    }
}
