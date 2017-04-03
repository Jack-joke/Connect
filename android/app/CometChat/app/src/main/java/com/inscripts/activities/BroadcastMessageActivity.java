/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.SearchView;
import android.text.Editable;
import android.text.Html;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.adapters.BroadcastListAdapter;
import com.inscripts.emoji.SmileyKeyBoard;
import com.inscripts.emoji.adapter.EmojiGridviewImageAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import java.util.ArrayList;
import java.util.List;

public class BroadcastMessageActivity extends SuperActivity implements AdapterView.OnItemClickListener, SearchView.OnQueryTextListener, EmojiGridviewImageAdapter.EmojiClickInterface {

    private ListView listview;
    private ImageButton sendBtn, smilieyButton;
    private TextView noUserView;
    private Mobile mobileLangs;
    private MobileTheme theme;
    private EditText messageField;
    private Css css;
    private BroadcastListAdapter adapter;
    private static String checkBoxKeyForBundle = "checkBoxState";
    private ProgressWheel wheel;
    private SearchView searchView;
    private Lang language;
    private String noBuddyText = StaticMembers.NO_BUDDY_TEXT;
    private SmileyKeyBoard smiliKeyBoard;
    private boolean isCometService = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_broadcast_message);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));


        listview = (ListView) findViewById(R.id.listviewBroadcast);
        sendBtn = (ImageButton) findViewById(R.id.buttonSendMessage);
        noUserView = (TextView) findViewById(R.id.noUsersOnline);
        messageField = (EditText) findViewById(R.id.editTextChatMessage);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);


        smilieyButton = (ImageButton) findViewById(R.id.img_btn_chat_more);
        smiliKeyBoard = new SmileyKeyBoard();
        smiliKeyBoard.enable(this, this, R.id.footer_for_emoticons, messageField);
        final RelativeLayout chatFooter = (RelativeLayout) findViewById(R.id.relativeLayoutControlsHolder);
        smiliKeyBoard.checkKeyboardHeight(chatFooter);
        smiliKeyBoard.enableFooterView(messageField);

        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = JsonPhp.getInstance().getLang().getMobile();
            language = JsonPhp.getInstance().getLang();
            noBuddyText = (null == language.getMobile()) ? StaticMembers.NO_BUDDY_TEXT : language.getMobile()
                    .get4();
        }

        isCometService = JsonPhp.getInstance().getConfig().getUSECOMET().equals("1");
        if (mobileLangs.get154() == null) {
            setActionBarTitle("Broadcast Message");
        } else {
            setActionBarTitle(mobileLangs.get154());
        }

        if (null != JsonPhp.getInstance().getMobileTheme()) {
            theme = JsonPhp.getInstance().getMobileTheme();
        }

        css = JsonPhp.getInstance().getCss();

        if (null != theme && null != theme.getActionbarColor()) {
            wheel.setBarColor(Color.parseColor(theme.getActionbarColor()));
        } else if (null != css && null != css.getTabTitleBackground()) {
            wheel.setBarColor(Color.parseColor(css.getTabTitleBackground()));
        }

        smilieyButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                smiliKeyBoard.showKeyboard(chatFooter);
            }
        });

        sendBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    if (null != adapter) {

                        if(!messageField.getText().toString().trim().isEmpty()){
                            if (adapter.getInvitedUsersCount() > 0) {
                                startWheel();
                                final ArrayList<String> invitedUsers = adapter.getInviteUsersList();
                                String userIds = "";
                                for (String id : invitedUsers) {
                                    userIds += "," + id;
                                }
                                userIds = userIds.substring(1, userIds.length());
                                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory
                                        .getBroadCastMessageURL(), new VolleyAjaxCallbacks() {
                                    @Override
                                    public void successCallback(String response) {
                                        if (isCometService) {
                                            try {
                                                Object json = new JSONTokener(response).nextValue();
                                                if (json instanceof JSONArray) {
                                                    json = null;
                                                    try {
                                                        long myid = SessionData.getInstance().getId(), time = System.currentTimeMillis();
                                                        String message = messageField.getText().toString();

                                                        JSONArray broadcastResponse = new JSONArray(response);
                                                        int i, len = broadcastResponse.length();
                                                        JSONObject data;
                                                        for (i = 0; i < len; i++) {
                                                            data = broadcastResponse.getJSONObject(i);
                                                            final OneOnOneMessage mess = new OneOnOneMessage(data.getLong(CometChatKeys.AjaxKeys.ID), myid, data.getLong(CometChatKeys.AjaxKeys.FROM), message, time, 1, 1,
                                                                    CometChatKeys.MessageTypeKeys.NORMAL, "", 1, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);
                                                            mess.save();
                                                        }
                                                        if (len > 0) {
                                                            Intent intent = new Intent(
                                                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                                                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                                                            sendBroadcast(intent);
                                                            SessionData.getInstance().setBuddyListBroadcastMissed(true);
                                                        }
                                                    } catch (Exception e) {
                                                        e.printStackTrace();
                                                    }
                                                }
                                            } catch (Exception e) {
                                                e.printStackTrace();
                                            }
                                        }
                                        stopWheel();
                                        messageField.setText("");
                                        finish();
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        startWheel();
                                        if (isNoInternet) {
                                            Toast.makeText(
                                                    getApplicationContext(),
                                                    (null == JsonPhp.getInstance().getLang()) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : JsonPhp.getInstance().getLang().getMobile()
                                                            .get24(), Toast.LENGTH_SHORT).show();
                                        }
                                    }
                                });

                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.MESSAGE, messageField.getText().toString());
                                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, userIds);
                                vHelper.sendAjax();


                            } else {
                                Toast.makeText(getApplicationContext(),
                                        JsonPhp.getInstance().getLang().getChatrooms().get21(), Toast.LENGTH_SHORT).show();
                            }
                        }else{
                            messageField.setText("");
                            Toast.makeText(BroadcastMessageActivity.this, "Message cannot be empty", Toast.LENGTH_SHORT).show();
                        }

                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });

        messageField.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (count > 0) {
                    sendBtn.setEnabled(true);
                    sendBtn.setAlpha(1F);
                } else {
                    sendBtn.setEnabled(false);
                    sendBtn.setAlpha(0.5F);
                }
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });
        messageField.clearFocus();
        ArrayList<String> savedCheckbox = new ArrayList<>();
        if (null != savedInstanceState) {
            savedCheckbox = savedInstanceState.getStringArrayList(checkBoxKeyForBundle);
        }

        sendBtn.setAlpha(0.5F);
        sendBtn.setEnabled(false);
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
                listview.setOnItemClickListener(BroadcastMessageActivity.this);
                noUserView.setVisibility(View.GONE);
            } else {
                noUserView.setVisibility(View.VISIBLE);
                noUserView
                        .setText((null == JsonPhp.getInstance().getLang().getMobile()) ? StaticMembers.NO_BUDDY_TEXT
                                : JsonPhp.getInstance().getLang().getMobile().get4());
                sendBtn.setAlpha(0.5F);
                sendBtn.setEnabled(false);
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
        wheel.spin();
        wheel.setVisibility(View.VISIBLE);
    }

    private void stopWheel() {
        wheel.stopSpinning();
        wheel.setProgress(0f);
        wheel.setVisibility(View.GONE);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_broadcast_message, menu);
        MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
        mobileLangs = JsonPhp.getInstance().getLang().getMobile();

        if (null != mobileLangs){
            if (null != mobileLangs.get173()) {
                menu.findItem(R.id.action_selectAll).setTitle(mobileLangs.get173());
            }else{
                menu.findItem(R.id.action_selectAll);
            }
            if (null != mobileLangs.get174()) {
                menu.findItem(R.id.action_deselectAll).setTitle(mobileLangs.get174());
            }else{
                menu.findItem(R.id.action_deselectAll);
            }
        }else{
            menu.findItem(R.id.action_selectAll);
            menu.findItem(R.id.action_deselectAll);
        }

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
    public boolean onOptionsItemSelected(MenuItem item) {

        switch (item.getItemId()) {
            case R.id.action_selectAll:
                if (null != adapter){
                    for (int i = 0; i < adapter.getCount(); i++) {
                        RelativeLayout rView = (RelativeLayout) adapter.getView(i, null, listview);
                        CheckBox cb = (CheckBox) rView.findViewById(R.id.checkBoxInviteUser);
                        adapter.addInvite(cb.getTag().toString());
                    }
                    adapter.notifyDataSetChanged();
                }
                break;
            case R.id.action_deselectAll:
                if (null != adapter) {
                    for (int i = 0; i < adapter.getCount(); i++) {
                        RelativeLayout rView = (RelativeLayout) adapter.getView(i, null, listview);
                        CheckBox cb = (CheckBox) rView.findViewById(R.id.checkBoxInviteUser);
                        adapter.removeInvite(cb.getTag().toString());
                    }
                    adapter.notifyDataSetChanged();
                }
                break;
        }
        return super.onOptionsItemSelected(item);
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
    public void finish() {
        super.finish();
        smiliKeyBoard.dismissKeyboard();
    }

    @Override
    public void onBackPressed() {
        if (null != smiliKeyBoard && smiliKeyBoard.isKeyboardVisibile()) {
            smiliKeyBoard.dismissKeyboard();
        } else {
            Intent intent = new Intent(this, CometChatActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            startActivity(intent);
            super.onBackPressed();
        }
    }

    @Override
    public void getClickedEmoji(int gridviewItemPosition) {
        smiliKeyBoard.getClickedEmoji(gridviewItemPosition);
    }
}
