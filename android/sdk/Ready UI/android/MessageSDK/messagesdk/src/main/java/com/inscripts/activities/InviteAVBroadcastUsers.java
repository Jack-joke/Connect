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
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.adapters.BroadcastListAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.models.Buddy;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import java.util.ArrayList;
import java.util.List;


public class InviteAVBroadcastUsers extends SuperActivity implements AdapterView.OnItemClickListener, SearchView.OnQueryTextListener {

    String roomName;
    private ListView listview;
    private TextView noUserView;
    private Mobile mobileLangs;
    private MobileTheme theme;
    private BroadcastListAdapter adapter;
    private static String checkBoxKeyForBundle = "checkBoxState";
    private SearchView searchView;
    private Lang language;
    private String noBuddyText = StaticMembers.NO_BUDDY_TEXT;
    private ProgressBar wheel;
    private Css css;
    private Button cancelBtn, sendBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_invite_avbroadcast_users);
        Intent intent = getIntent();
        roomName = intent.getStringExtra(StaticMembers.INTENT_ROOM_NAME);

        listview = (ListView) findViewById(R.id.listviewBroadcast);
        wheel = (ProgressBar) findViewById(R.id.progressWheel);
        noUserView = (TextView) findViewById(R.id.noUsersOnline);
        cancelBtn = (Button) findViewById(R.id.buttonCancelInvite);
        sendBtn = (Button) findViewById(R.id.buttonInviteUser);

        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = JsonPhp.getInstance().getLang().getMobile();
            language = JsonPhp.getInstance().getLang();
            noBuddyText = (null == language.getMobile()) ? StaticMembers.NO_BUDDY_TEXT : language.getMobile()
                    .get4();
        }

        if(language != null && null != language.getMobile() && language.getMobile().get30() != null){
            cancelBtn.setText(language.getMobile().get30());
        }

        if(language != null && null != language.getCore() && language.getCore().get71() != null){
            sendBtn.setText(language.getCore().get71());
        }

        if (null != JsonPhp.getInstance().getMobileTheme()) {
            theme = JsonPhp.getInstance().getMobileTheme();
        }

        css = JsonPhp.getInstance().getCss();

        ArrayList<String> savedCheckbox = new ArrayList<>();
        if (null != savedInstanceState) {
            savedCheckbox = savedInstanceState.getStringArrayList(checkBoxKeyForBundle);
        }

        if (null != theme && null != theme.getActionbarTextColor() && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            sendBtn.setTextColor(btnColor);
            cancelBtn.setTextColor(btnColor);
            sendBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            sendBtn.setTextColor(btnColor);
            cancelBtn.setTextColor(btnColor);
            sendBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
        }

        cancelBtn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View arg0) {
                finish();
            }
        });

        sendBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    if (null != adapter) {
                        startWheel();
                        if (adapter.getInvitedUsersCount() > 0) {
                            ArrayList<String> invitedUsers = adapter.getInviteUsersList();
                            for (String id : invitedUsers) {
                                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory
                                        .getAVBroadcastInviteURL());
                                vHelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, roomName);

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
                            stopWheel();
                            finish();
                        } else {
                            stopWheel();
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
        if (language.getAvchat().get17() == null) {
            setActionBarTitle("Invite users");
        } else {
            setActionBarTitle(language.getAvchat().get17());
        }
        setupInviteUserListView(savedCheckbox);

    }

    private void setupInviteUserListView(final ArrayList<String> checkBoxState) {
        List<Buddy> buddyList;
        try {
            //buddyList = Buddy.getAllBuddies();
            buddyList = Buddy.getAllVisibieBuddies();
            if (null != buddyList && buddyList.size() > 0) {
                adapter = new BroadcastListAdapter(getApplicationContext(), buddyList, checkBoxState);
                listview.setAdapter(adapter);
                listview.setOnItemClickListener(InviteAVBroadcastUsers.this);
                noUserView.setVisibility(View.GONE);
            } else {
                noUserView.setVisibility(View.VISIBLE);
                noUserView
                        .setText((null == JsonPhp.getInstance().getLang().getMobile()) ? StaticMembers.NO_BUDDY_TEXT
                                : JsonPhp.getInstance().getLang().getMobile().get4());
                //sendBtn.setAlpha(0.5F);
                //sendBtn.setEnabled(false);
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
        // Logger.error("List: " + adapter.getInviteUsersList());
    }

    private void startWheel() {
        wheel.setVisibility(View.VISIBLE);
    }

    private void stopWheel() {
        wheel.setVisibility(View.GONE);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.cc_menu_broadcast_message, menu);
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
                    }
                } else {
                    if (!searchView.isIconified()) {
                        searchView.setIconified(false);
                    }
                }
            }
        });

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onQueryTextSubmit(String s) {
        return false;
    }

    @Override
    public boolean onQueryTextChange(String searchText) {
        if (listview != null && listview.getAdapter() != null) {
            searchText = searchText.replaceAll("^\\s+", "");
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
            list = Buddy.searchBuddies(searchText);
        } else {
            //list = Buddy.getAllBuddies();
            list = Buddy.getAllVisibieBuddies();
        }

        if (null == list || list.size() == 0) {
            if (!search) {
                noUserView.setText(noBuddyText);
            } else {
                noUserView.setText(language.getCore().get58());
            }
            noUserView.setVisibility(View.VISIBLE);
        } else {
            noUserView.setVisibility(View.GONE);
        }

        adapter.clear();
        adapter.addAll(list);
        //adapter.notifyDataSetChanged();
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();


        return super.onOptionsItemSelected(item);
    }
}
