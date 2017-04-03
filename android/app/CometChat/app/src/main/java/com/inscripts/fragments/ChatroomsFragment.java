/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.SearchView.OnQueryTextListener;
import android.text.Html;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnFocusChangeListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.EditText;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.github.clans.fab.FloatingActionButton;
import com.github.clans.fab.FloatingActionMenu;
import com.inscripts.activities.AnnouncementActivity;
import com.inscripts.activities.CreateChatroomActivity;
import com.inscripts.activities.R;
import com.inscripts.activities.SettingActivity;
import com.inscripts.adapters.ChatroomListAdapter;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import java.util.List;

import se.emilsjolander.stickylistheaders.StickyListHeadersListView;

public class ChatroomsFragment extends Fragment implements OnItemClickListener, OnAlertDialogButtonClickListener,
        OnQueryTextListener {

    private StickyListHeadersListView chatroomListview;
    private static ChatroomListAdapter adapter;
    private RelativeLayout noChatrooms;
    private int createdBy;
    private long chatroomId;
    private String chatroomPassword, chatroomName, noChatroomtext = StaticMembers.NO_CHATROOM_TEXT;
    private static BroadcastReceiver customReceiver;
    private boolean isClearCount = false, isSearchStart = false, lastSearchisEmpty = false, isSearching = false;
    private TextView noChatroomsTextView;
    private Lang language;
    private static String crSearchText = "";
    private SearchView searchView;
    private List<Chatroom> list;
    private static ProgressDialog progressDialog;
    FloatingActionButton fabNewChatroom;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        crSearchText = "";
        language = JsonPhp.getInstance().getLang();
        setHasOptionsMenu(true);
        adapter = new ChatroomListAdapter(getActivity(), Chatroom.getAllChatrooms());
        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                if (intent.hasExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT)) {
                    SessionData.getInstance().setChatroomListBroadcastMissed(false);
                    if (!isSearching) {
                        updateChatroomList();
                    }
                }
            }
        };

        if (null != language) {
            noChatroomtext = (null == language.getChatrooms()) ? StaticMembers.NO_CHATROOM_TEXT : language.getChatrooms()
                    .get53();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_chatrooms, container, false);
        fabNewChatroom = (FloatingActionButton) view.findViewById(R.id.fabNewChatRoom);
        chatroomListview = (StickyListHeadersListView) view.findViewById(R.id.List_of_chatrooms);
        noChatrooms = (RelativeLayout) view.findViewById(R.id.relativeLayoutNoChatroomsMessage);
        noChatroomsTextView = (TextView) view.findViewById(R.id.textViewNoChatrooms);
        noChatroomsTextView.setText(noChatroomtext);
        chatroomListview.setAdapter(adapter);
        chatroomListview.setOnItemClickListener(this);
        if (!isSearching) {
            updateChatroomList();
        }


        if(JsonPhp.getInstance().getAllowusersCreatechatroom().equals("1")){
            fabNewChatroom.setColorNormal(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            fabNewChatroom.setColorPressed(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            fabNewChatroom.setColorRipple(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            fabNewChatroom.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    createChatroom();
                }
            });
        }else {
            fabNewChatroom.setVisibility(View.GONE);
        }
        return view;
    }

    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        super.onPrepareOptionsMenu(menu);
        onQueryTextChange(crSearchText);
        if (!TextUtils.isEmpty(crSearchText)) {
            searchView.setIconified(false);
            searchView.setQuery(crSearchText, false);
        }

    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        try {
            MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
            searchView = (SearchView) MenuItemCompat.getActionView(searchMenuItem);
            if (null != language && null != language.getMobile().get16()) {
                searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>" + language.getMobile().get15()
                        + "</font>"));
            } else {
                searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>Search Users</font>"));
            }
            searchView.setOnQueryTextListener(this);

            searchView.setOnQueryTextFocusChangeListener(new OnFocusChangeListener() {

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
            if (JsonPhp.getInstance().getAllowusersCreatechatroom().equals("1")) {
                menu.findItem(R.id.custom_action_create_chatroom).setTitle(language.getCore().get72());
            } else {
                menu.findItem(R.id.custom_action_create_chatroom).setVisible(false);
            }
            menu.findItem(R.id.custom_action_create_chatroom).setVisible(false);
            menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
            menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
            menu.findItem(R.id.custom_notification).setVisible(true);
            menu.findItem(R.id.custom_action_search).setVisible(true);
            menu.findItem(R.id.custom_setting).setVisible(true);
            menu.findItem(R.id.add_group).setVisible(false);
        } catch (Exception e) {
            Logger.error("onCreateOptionsMenu in chatroom.java Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
        super.onCreateOptionsMenu(menu, inflater);
    }

    private void createChatroom() {
        Intent intent = new Intent(getActivity(), CreateChatroomActivity.class);
        startActivity(intent);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {

            case R.id.custom_notification:
                Intent AnnouncementIntent = new Intent(getActivity(), AnnouncementActivity.class);
                startActivity(AnnouncementIntent);
                break;
            case R.id.custom_action_create_chatroom:
                createChatroom();
                break;

            case R.id.custom_setting:
                Intent settingIntent = new Intent(getActivity(), SettingActivity.class);
                startActivity(settingIntent);
                break;

            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }

    /**
     * Refresh the cursor if the ListView completely
     */
    private void updateChatroomList() {
        try {
            list = Chatroom.getAllChatrooms();
            if (null != list && list.size() > 0) {
                noChatrooms.setVisibility(View.GONE);
                adapter.clear();
                adapter.addAll(list);
                //adapter.notifyDataSetChanged();
            } else {
                adapter.clear();
                noChatroomsTextView.setText(noChatroomtext);
                noChatrooms.setVisibility(View.VISIBLE);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("InflateParams")
    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        try {
            PushNotificationsManager.clearAllNotifications();
            if (CommonUtils.isConnected()) {

                Chatroom chatroom = (Chatroom) parent.getItemAtPosition(position);

                // Logger.error("chatroomid: " + chatroom.chatroomId + " " +
                // chatroom.unreadCount);
               /* if (0 != chatroom.unreadCount) {*/
                    chatroom.unreadCount = 0;
                    chatroom.save();
                    isClearCount = true;

                    //PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT, 0);
                    Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                    iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_CHATROOM_MESSAGE, 1);
                    PreferenceHelper.getContext().sendBroadcast(iintent);
                    SessionData.getInstance().setChatbadgeMissed(true);
                /*}*/

                //adapter.notifyDataSetChanged();

                chatroomId = chatroom.chatroomId;
                chatroomPassword = chatroom.password;
                createdBy = chatroom.createdBy;
                chatroomName = chatroom.name;

                SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_CHATROOM);

                if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)
                        && chatroomId == Long.parseLong(PreferenceHelper
                        .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))) {
                    ChatroomManager.startChatroomActivity(chatroomId, chatroomName, getActivity());
                } else {
                    if (createdBy == 1 || createdBy == 2) {
                        /*
                         * ChatRoom is created by self or i am moderator of
						 * chatroom
						 */
                        progressDialog = ProgressDialog.show(getActivity(), "", JsonPhp.getInstance().getLang()
                                .getMobile().get30());
                        progressDialog.setCancelable(false);

                        ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                getActivity(), new CometchatCallbacks() {

                                    @Override
                                    public void successCallback() {
                                        if (null != progressDialog) {
                                            progressDialog.dismiss();
                                        }
                                    }

                                    @Override
                                    public void failCallback() {
                                        if (null != progressDialog) {
                                            progressDialog.dismiss();
                                        }
                                    }
                                });
                    } else if (createdBy == 0) {
                        switch (chatroom.type) {
                            case CometChatKeys.ChatroomKeys.TypeKeys.PUBLIC:
                                progressDialog = ProgressDialog.show(getActivity(), "", JsonPhp.getInstance().getLang()
                                        .getMobile().get30());
                                progressDialog.setCancelable(false);

                                ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                        getActivity(), new CometchatCallbacks() {

                                            @Override
                                            public void successCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }

                                            @Override
                                            public void failCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }
                                        });
                                break;
                            case CometChatKeys.ChatroomKeys.TypeKeys.PASSWORD_PROTECTED:
							/*
							 * Chatroom is password protected and not created by
							 * self
							 */
                                View dialogview = getActivity().getLayoutInflater().inflate(R.layout.custom_dialog, null);

                                TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
                                dialogueTitle.setText(language.getChatrooms().get8());

                                EditText dialogueTextInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
                                dialogueTextInput.setHint(language.getChatrooms().get32());

                                new CustomAlertDialogHelper(getActivity(), "", dialogview, language.getChatrooms().get19(),
                                        "", language.getChatrooms().get51(), this, 1);
                                break;
                            case CometChatKeys.ChatroomKeys.TypeKeys.INVITE_ONLY:
							/*
							 * Invite only room , get the invitation from
							 * oneOnOne heartbeat and then join it. This room is
							 * not listed in chatroomlist
							 */
                                progressDialog = ProgressDialog.show(getActivity(), "", JsonPhp.getInstance().getLang()
                                        .getMobile().get30());
                                progressDialog.setCancelable(false);

                                ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                        getActivity(), new CometchatCallbacks() {

                                            @Override
                                            public void successCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }

                                            @Override
                                            public void failCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }
                                        });
                                break;
                            default:
                                break;
                        }
                    }
                }
            } else {
                Toast.makeText(getActivity(), language.getMobile().get24(), Toast.LENGTH_SHORT).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /* Dialog onclick of custom alertdialog */
    @SuppressLint("HandlerLeak")
    @Override
    public void onButtonClick(final AlertDialog dialog, View v, int which, int popupId) {
        final EditText chatroomPasswordInput = (EditText) v.findViewById(R.id.edittextDialogueInput);

        if (which == DialogInterface.BUTTON_NEGATIVE) { // Cancel
            dialog.dismiss();
        } else if (which == DialogInterface.BUTTON_POSITIVE) { // Join
            try {
                progressDialog = ProgressDialog.show(getActivity(), "", JsonPhp.getInstance().getLang().getMobile()
                        .get30());
                progressDialog.setCancelable(false);
                chatroomPassword = chatroomPasswordInput.getText().toString();
                if (chatroomPassword.length() == 0) {
                    chatroomPasswordInput.setText("");
                    chatroomPasswordInput.setError(language.getChatrooms().get23());
                    progressDialog.dismiss();
                } else {
                    try {
                        chatroomPassword = EncryptionHelper.encodeIntoShaOne(chatroomPassword);
                        VolleyHelper vHelper = new VolleyHelper(getActivity(), URLFactory.getChatroomPasswordUrl(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        try {
                                            // Logger.error("response ="+response);
                                            JSONObject chatroomJson = new JSONObject(response);
                                            String joinResponse = chatroomJson.getString("s");
                                            if (joinResponse.equals("INVALID_PASSWORD")) {
												/*
												 * Wrong password value returned
												 * 0
												 */
                                                chatroomPasswordInput.setText("");
                                                chatroomPasswordInput.setError(language.getChatrooms().get23());
                                                SessionData.getInstance().setCurrentChatroomPassword("");
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else if (joinResponse.equals("BANNED")) {
												/*
												 * User is banned for this
												 * chatroom value returned 2
												 */
                                                if (createdBy != 1) {
                                                    Toast.makeText(PreferenceHelper.getContext(),
                                                            language.getChatrooms().get37(), Toast.LENGTH_SHORT).show();
                                                    dialog.dismiss();
                                                }
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else if (joinResponse.equals("INVALID_CHATROOM")) {
                                                Toast.makeText(PreferenceHelper.getContext(),
                                                        JsonPhp.getInstance().getLang().getChatrooms().get55(),
                                                        Toast.LENGTH_SHORT).show();
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else {
												/* User is valid */
                                                dialog.dismiss();
                                                Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
                                                if (0 != chatroom.unreadCount) {
                                                    chatroom.unreadCount = 0;
                                                    chatroom.save();
                                                    isClearCount = true;
                                                }
                                                ChatroomManager.joinChatroom(chatroomId, chatroomName,
                                                        chatroomPassword, 0, getActivity(), new CometchatCallbacks() {

                                                            @Override
                                                            public void successCallback() {
                                                                if (null != progressDialog) {
                                                                    progressDialog.dismiss();
                                                                }
                                                            }

                                                            @Override
                                                            public void failCallback() {
                                                                if (null != progressDialog) {
                                                                    progressDialog.dismiss();
                                                                }
                                                            }
                                                        });
                                            }
                                            // loader.setVisibility(View.GONE);
                                        } catch (Exception e) {
                                            e.printStackTrace();
                                        }
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(getActivity(), language.getMobile().get24(),
                                                    Toast.LENGTH_SHORT).show();
                                        }
                                        if (null != progressDialog) {
                                            progressDialog.dismiss();
                                        }
                                    }
                                });
                        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD,
                                String.valueOf(chatroomId));
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, chatroomPassword);
                        vHelper.sendAjax();

                    } catch (Exception e) {
                        Logger.error("Error at SHA1:UnsupportedEncodingException FOR PASSWORD "
                                + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {
                Logger.error("chatroomFragment.java onButtonClick() : Exception=" + e.getLocalizedMessage());
                e.printStackTrace();
            }
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        FloatingActionMenu fabMenu = (FloatingActionMenu) getActivity().findViewById(R.id.fabMenu);
     //   fabMenu.hideMenu(true);
        if (customReceiver != null) {
            getActivity().registerReceiver(customReceiver,
                    new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION));
        }

        SessionData session = SessionData.getInstance();
        if (session.isChatroomListBroadcastMissed()) {
            session.setChatroomListBroadcastMissed(false);
            updateChatroomList();
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        try {

            if (customReceiver != null) {
                getActivity().unregisterReceiver(customReceiver);
            }

		/*
		 * If any chatroom is clicked then refresh the chatroom list to clear
		 * the unread count
		 */
            if (isClearCount) {
                isClearCount = false;
                //updateChatroomList();
                adapter.notifyDataSetChanged();
            }
            isSearchStart = false;
            if (null != progressDialog) {
                progressDialog.dismiss();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onQueryTextChange(String searchText) {
        if (chatroomListview != null && chatroomListview.getAdapter() != null) {
			/* Remove all leading spaces */
            searchText = searchText.replaceAll("^\\s+", "");
            if (!searchView.isIconified() && !TextUtils.isEmpty(searchText)) {
                crSearchText = searchText;
            }
            if (!TextUtils.isEmpty(searchText)) {
                searchChatroom(searchText, true);
                isSearchStart = true;
                lastSearchisEmpty = false;
            } else {
				/*
				 * If view is loaded again because of tab switching then dont
				 * call this method
				 */
                if (isSearchStart) {
                    if (!lastSearchisEmpty) {
                        lastSearchisEmpty = true;
                        crSearchText = searchText;
                        searchChatroom(searchText, false);
                    }
                }
            }
        }
        return true;
    }

    private void searchChatroom(String searchText, boolean search) {
        if (search) {
            isSearching = true;
            list = Chatroom.searchChatrooms(searchText);
        } else {
            isSearching = false;
            list = Chatroom.getAllChatrooms();
        }

        if (null == list || list.size() == 0) {
            if (!search) {
                noChatroomsTextView.setText(noChatroomtext);
            } else {
                noChatroomsTextView.setText(language.getChatrooms().get38());
            }
            noChatrooms.setVisibility(View.VISIBLE);
        } else {
            noChatrooms.setVisibility(View.GONE);
        }

        adapter.clear();
        adapter.addAll(list);
    }


    @Override
    public boolean onQueryTextSubmit(String arg0) {
        return false;
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {

            FloatingActionMenu fabMenu = (FloatingActionMenu)getActivity().findViewById(R.id.fabMenu);;
            fabMenu.setVisibility(View.GONE);
        }
    }

}
