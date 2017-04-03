/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.os.Bundle;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.SearchView;
import android.text.Html;
import android.text.TextUtils;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.adapters.InviteUserListAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Set;

public class InviteUserActivity extends SuperActivity implements OnItemClickListener, SearchView.OnQueryTextListener {

    private long chatroomId;
    private InviteUserListAdapter adapter;
    private ListView inviteUserListView;
    private Button cancelButton, inviteButton;
    private String chatroomName;
    private static String checkBoxKeyForBundle = "checkBoxState";
    private TextView noUsersOnline;
    private MobileTheme theme;
    private Css css;
    private SearchView searchView;
    private Lang language;
    private String noBuddyText = StaticMembers.NO_BUDDY_TEXT;
    private static String onoSearchText = "";
    private boolean isSearching=false;
    private boolean isChecked;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent intent = getIntent();
        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        chatroomId = intent.getLongExtra(StaticMembers.INTENT_CHATROOM_ID, 0);
        chatroomName = intent.getStringExtra(StaticMembers.INTENT_CHATROOM_NAME);

        setActionBarTitle(JsonPhp.getInstance().getLang().getChatrooms().get20());
        setContentView(R.layout.activity_invite_users);

        inviteUserListView = (ListView) findViewById(R.id.listViewInviteUsers);
        cancelButton = (Button) findViewById(R.id.buttonCancelInvite);
        inviteButton = (Button) findViewById(R.id.buttonInviteUser);
        noUsersOnline = (TextView) findViewById(R.id.textviewNoUsersToInvite);
        cancelButton.setText(JsonPhp.getInstance().getLang().getMobile().get32());
        inviteButton.setText(JsonPhp.getInstance().getLang().getMobile().get36());

        cancelButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                finish();
            }
        });

        if (null != JsonPhp.getInstance().getLang()) {
            language = JsonPhp.getInstance().getLang();
            noBuddyText = (null == language.getMobile()) ? StaticMembers.NO_BUDDY_TEXT : language.getMobile()
                    .get4();
        }


        theme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();

        ArrayList<String> savedCheckbox = new ArrayList<>();

        if (null != savedInstanceState) {
            savedCheckbox = savedInstanceState.getStringArrayList(checkBoxKeyForBundle);
        }

        try {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS)) {
                JSONObject chatroomUserList = new JSONObject(
                        PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS));
                setupInviteUserListView(chatroomUserList, savedCheckbox);
            } else {
                Logger.error("No CR member in pref");
                setupInviteUserListView(null, savedCheckbox);
            }
        } catch (Exception e) {
            Logger.error(this.getClass().getSimpleName() + ": exception in oncreate " + e.getMessage());
            e.printStackTrace();
        }

        inviteButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                try {
                    if (null != adapter) {
                        if (adapter.getInvitedUsersCount() > 0) {

                            chatroomName = new String(CommonUtils.encodeBase64(chatroomName), StaticMembers.UTF_8).trim();
                            ArrayList<String> invitedUsers = adapter.getInviteUsersList();
                            for (String id : invitedUsers) {
                                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory
                                        .getChatroomInviteURL());
                                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, chatroomId);
                                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITEDID, SessionData
                                        .getInstance().getCurrentChatroomPassword());

                                // Logger.error("Encoded CR name: " +
                                // chatroomName);
                                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMNAME, chatroomName);

                                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITE, id);

								/*
                                 * Callback is not required for sending invite
								 * users.. sendMessageTo() in chatroom.php avoid
								 * duplicate calls if callback appears
								 */

                                vHelper.sendCallBack(false);
                                vHelper.sendAjax();

                            }
                            adapter.clearInviteList();
                            finish();
                        } else {
                            Toast.makeText(getApplicationContext(),
                                    JsonPhp.getInstance().getLang().getChatrooms().get21(), Toast.LENGTH_SHORT).show();
                        }
                    }
                } catch (Exception e) {
                    Logger.error("InviteuserActivity.java: inviteButtononClick exception =" + e.getLocalizedMessage());
                    e.printStackTrace();
                }
            }
        });

        if (null != theme && null != theme.getActionbarTextColor() && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            inviteButton.setTextColor(btnColor);
            cancelButton.setTextColor(btnColor);
            inviteButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            inviteButton.setTextColor(btnColor);
            cancelButton.setTextColor(btnColor);
            inviteButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_invite_user, menu);
        MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
        searchView = (SearchView) MenuItemCompat.getActionView(searchMenuItem);
        searchView.setOnQueryTextListener(this);
        if (null != language && null != language.getMobile().get15()) {
            searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>" + language.getMobile().get15()
                    + "</font>"));
        } else {
            searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>Search Users</font>"));
        }
        searchView.setOnQueryTextFocusChangeListener(new View.OnFocusChangeListener() {

            @SuppressLint("NewApi")
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    if (TextUtils.isEmpty(searchView.getQuery())) {
                        searchView.setIconified(true);
                        isSearching = false;
                    }
                } else {
                    if (!searchView.isIconified()) {
                        searchView.setIconified(false);
                    }
                }
            }
        });

        MenuItem inviteUserItem =  menu.findItem(R.id.custom_action_done);

        if(isChecked){
            inviteUserItem.setVisible(true);
        }else{
            inviteUserItem.setVisible(false);
        }

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        if(item.getItemId() == R.id.custom_action_done){
            try {
                if (null != adapter) {
                    if (adapter.getInvitedUsersCount() > 0) {

                        chatroomName = new String(CommonUtils.encodeBase64(chatroomName), StaticMembers.UTF_8).trim();
                        ArrayList<String> invitedUsers = adapter.getInviteUsersList();
                        for (String id : invitedUsers) {
                            VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory
                                    .getChatroomInviteURL());
                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, chatroomId);
                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITEDID, SessionData
                                    .getInstance().getCurrentChatroomPassword());

                            // Logger.error("Encoded CR name: " +
                            // chatroomName);
                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMNAME, chatroomName);

                            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.INVITE, id);

								/*
                                 * Callback is not required for sending invite
								 * users.. sendMessageTo() in chatroom.php avoid
								 * duplicate calls if callback appears
								 */

                            vHelper.sendCallBack(false);
                            vHelper.sendAjax();

                        }
                        adapter.clearInviteList();
                        finish();
                    } else {
                        Toast.makeText(getApplicationContext(),
                                JsonPhp.getInstance().getLang().getChatrooms().get21(), Toast.LENGTH_SHORT).show();
                    }
                }
            } catch (Exception e) {
                Logger.error("InviteuserActivity.java: inviteButtononClick exception =" + e.getLocalizedMessage());
                e.printStackTrace();
            }
        }


        return super.onOptionsItemSelected(item);

    }

    private void setupInviteUserListView(final JSONObject chatroomMemberList, final ArrayList<String> checkBoxState) {
        List<Buddy> buddyList;
        try {
            if (null != chatroomMemberList) {
                Iterator<String> iter = chatroomMemberList.keys();
                Set<String> ids = new HashSet<>();

                while (iter.hasNext()) {
                    ids.add(chatroomMemberList.getJSONObject(iter.next()).getString(CometChatKeys.AjaxKeys.ID));
                }
                buddyList = Buddy.getExternalBuddies(ids);
            } else {
                //buddyList = Buddy.getAllBuddies();
                buddyList = Buddy.getAllVisibieBuddies();
            }

            if (null != buddyList && buddyList.size() > 0) {
                adapter = new InviteUserListAdapter(getApplicationContext(), buddyList, checkBoxState);
                inviteUserListView.setAdapter(adapter);
                inviteUserListView.setOnItemClickListener(InviteUserActivity.this);
                noUsersOnline.setVisibility(View.GONE);
                inviteButton.setAlpha(1F);
                inviteButton.setEnabled(true);
            } else {
                noUsersOnline.setVisibility(View.VISIBLE);
                noUsersOnline
                        .setText((null == JsonPhp.getInstance().getLang().getMobile()) ? StaticMembers.NO_BUDDY_TEXT
                                : JsonPhp.getInstance().getLang().getMobile().get4());
                inviteButton.setAlpha(0.5F);
                inviteButton.setEnabled(false);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if (adapter != null) {
            ArrayList<String> invitedUsers = adapter.getInviteUsersList();
            outState.clear();
            outState.putStringArrayList(checkBoxKeyForBundle, invitedUsers);
        }
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        CheckBox checkBox = (CheckBox) view.findViewById(R.id.checkBoxInviteUser);
        checkBox.setChecked(!checkBox.isChecked());
        adapter.toggleInvite(checkBox.getTag().toString());

        ArrayList<String> invitedUsers = adapter.getInviteUsersList();

        if(invitedUsers.size()>0){
           isChecked = true;
            invalidateOptionsMenu();
        }else{
            isChecked = false;
            invalidateOptionsMenu();
        }
        // Logger.error("List: " + adapter.getInviteUsersList());
    }




    @Override
    public boolean onQueryTextSubmit(String s) {
        return false;
    }

    @Override
    public boolean onQueryTextChange(String searchText) {
        if (inviteUserListView != null && inviteUserListView.getAdapter() != null) {
            searchText = searchText.replaceAll("^\\s+", "");
            if (!searchView.isIconified() && !TextUtils.isEmpty(searchText)) {
                onoSearchText = searchText;
            }
            if (!TextUtils.isEmpty(searchText)) {
                searchUser(searchText, true);
            } else {
                searchUser(searchText, false);
            }
        }
        return false;
    }

    private void searchUser(String searchText, boolean search) {
        List<Buddy> list;
        if (search) {
            isSearching = true;
            list = Buddy.searchBuddies(searchText);
        } else {
            isSearching = false;
            //list = Buddy.getAllBuddies();
            list = Buddy.getAllVisibieBuddies();
        }

        if (null == list || list.size() == 0) {
            if (!search) {
                noUsersOnline.setText(noBuddyText);
            } else {
                noUsersOnline.setText(language.getCore().get58());
            }
            noUsersOnline.setVisibility(View.VISIBLE);
        } else {
            noUsersOnline.setVisibility(View.GONE);
        }

        adapter.clear();
        adapter.addAll(list);
        //adapter.notifyDataSetChanged();
    }
}
