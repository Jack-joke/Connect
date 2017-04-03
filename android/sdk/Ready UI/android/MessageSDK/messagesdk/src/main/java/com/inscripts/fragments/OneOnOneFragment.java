/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.fragments;

import android.annotation.SuppressLint;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
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
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.activities.SingleChatActivity;
import com.inscripts.adapters.BuddyListAdapter;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.TimerClass;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class OneOnOneFragment extends Fragment implements OnItemClickListener, OnQueryTextListener {
    private ListView oneToOneListview;
    private BuddyListAdapter adapter;
    private TextView noUsersOnline;
    private BroadcastReceiver customReceiver;
    private RelativeLayout relativeLayoutNoUsers;
    private boolean isCountCleared = false, isSearchStart = true, lastSearchisZero = false, isSearching = false;
    private Lang language;
    private Mobile mobileLangs;
    private String noBuddyText = StaticMembers.NO_BUDDY_TEXT;
    private static String onoSearchText = "";
    private SearchView searchView;

    private List<Buddy> list;
    private View view;

    public OneOnOneFragment() {
        setRetainInstance(true);
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        try {
            onoSearchText = "";
            language = JsonPhp.getInstance().getLang();
            mobileLangs = language.getMobile();
            setHasOptionsMenu(true);

            //list = Buddy.getAllBuddies();
            list = new ArrayList<>();

            adapter = new BuddyListAdapter(getActivity(), list);

            customReceiver = new BroadcastReceiver() {

                @Override
                public void onReceive(Context context, Intent intent) {
                    try {
                        Bundle extras = intent.getExtras();
                        if (extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT)) {
                            if (!isSearching) {
                                updateBuddyList();
                                SessionData.getInstance().setBuddyListBroadcastMissed(false);
                            }
                        } else if (intent.hasExtra(IntentExtrasKeys.SUBTITLE_CHANGE)) {
                            String value = intent.getStringExtra(IntentExtrasKeys.SUBTITLE_CHANGE);
                            long buddyId = intent.getLongExtra(IntentExtrasKeys.BUDDY_ID, 0L);
                            if (value.equals(IntentExtrasKeys.TYPING_START)) {
                                final Buddy buddy = Buddy.searchBuddy(buddyId);
                                if (null != buddy) {
                                    String allStatus = PreferenceHelper.get(PreferenceKeys.DataKeys.SAVED_STATUS);
                                    JSONObject existingdata;
                                    if (TextUtils.isEmpty(allStatus)) {
                                        existingdata = new JSONObject();
                                    } else {
                                        existingdata = new JSONObject(allStatus);
                                    }

                                    existingdata.put(String.valueOf(buddyId), buddy.statusMessage);
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.SAVED_STATUS, existingdata.toString());
                                    buddy.statusMessage = null == language.getMobile().get157() ? "typing..." : language.getMobile().get157();
                                    buddy.save();
                                    updateBuddyList();
                                    TimerClass timer = new TimerClass(buddyId);
                                    timer.setTimer(new VolleyAjaxCallbacks() {
                                        @Override
                                        public void successCallback(String response) {
                                            try {
                                                String allStatus = PreferenceHelper.get(PreferenceKeys.DataKeys.SAVED_STATUS);
                                                JSONObject existingdata;
                                                if (TextUtils.isEmpty(allStatus)) {
                                                    existingdata = new JSONObject();
                                                } else {
                                                    existingdata = new JSONObject(allStatus);
                                                }

                                                if (existingdata.has(response)) {
                                                    Buddy buddy = Buddy.searchBuddy(Long.parseLong(response));
                                                    buddy.statusMessage = existingdata.getString(response);
                                                    buddy.save();
                                                }
                                                Intent intent1 = new Intent(
                                                        BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                                                intent1.putExtra(IntentExtrasKeys.SUBTITLE_CHANGE, IntentExtrasKeys.TYPING_STOP);
                                                intent1.putExtra(IntentExtrasKeys.BUDDY_ID, Long.parseLong(response));
                                                getActivity().sendBroadcast(intent1);
                                            } catch (Exception e) {
                                                e.printStackTrace();
                                            }
                                        }

                                        @Override
                                        public void failCallback(String response, boolean isNoInternet) {

                                        }
                                    });
                                }


                            } else if (value.equals(IntentExtrasKeys.TYPING_STOP)) {
                                final Buddy buddy = Buddy.searchBuddy(buddyId);
                                if (null != buddy) {
                                    String allStatus = PreferenceHelper.get(PreferenceKeys.DataKeys.SAVED_STATUS);

                                    JSONObject existingdata;
                                    if (TextUtils.isEmpty(allStatus)) {
                                        existingdata = new JSONObject();
                                    } else {
                                        existingdata = new JSONObject(allStatus);
                                    }
                                    if (existingdata.has(String.valueOf(buddyId))) {
                                        buddy.statusMessage = existingdata.getString(String.valueOf(buddyId));
                                        buddy.save();
                                    }
                                    updateBuddyList();
                                }
                            }
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            };

            if (null != language) {
                noBuddyText = (null == language.getMobile()) ? StaticMembers.NO_BUDDY_TEXT : language.getMobile()
                        .get4();
            }

        } catch (Exception e) {
            Logger.error("Exception at onCreate of oneononefragment.java :" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        if (view == null) {
            view = inflater.inflate(R.layout.cc_fragment_one_on_one, container, false);

            try {
                relativeLayoutNoUsers = (RelativeLayout) view.findViewById(R.id.relativeLayoutNoUsersMessage);
                oneToOneListview = (ListView) view.findViewById(R.id.List_of_users);
                noUsersOnline = (TextView) view.findViewById(R.id.textViewNoUsersMessage);
                noUsersOnline.setText(noBuddyText);
                oneToOneListview.setAdapter(adapter);

                oneToOneListview.setOnItemClickListener(this);
                if (!isSearching) {
                    updateBuddyList();
                }
            } catch (Exception e) {
                Logger.error("Exception at onCreateView of oneononefragment.java :" + e.getLocalizedMessage());
                e.printStackTrace();
            }
        }
        return view;
    }

    @Override
    public void onPrepareOptionsMenu(Menu menu) {
        super.onPrepareOptionsMenu(menu);
        onQueryTextChange(onoSearchText);
        if (!TextUtils.isEmpty(onoSearchText)) {
            searchView.setIconified(false);
            searchView.setQuery(onoSearchText, false);
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        try {
            int id = item.getItemId();
           /* if (id == R.id.custom_action_unblock_user) {
                Intent i = new Intent(getActivity(), UnblockuserActivity.class);
                i.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
                startActivity(i);
            }*/

        } catch (Exception e) {
            e.printStackTrace();
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
       // menu.findItem(R.id.custom_action_create_chatroom).setVisible(false);
        try {
            MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
            searchView = (SearchView) MenuItemCompat.getActionView(searchMenuItem);
            searchView.setOnQueryTextListener(this);
            if (null != language && null != language.getMobile().get15()) {
                searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>" + language.getMobile().get15()
                        + "</font>"));
            } else {
                searchView.setQueryHint(Html.fromHtml("<font color = #ffffff>Search Users</font>"));
            }

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
           /* menu.findItem(R.id.custom_action_unblock_user).setVisible(false);

            if (BlockUnblockUser.isblockUnblockDisabled()) {
                menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
            } else {
                if (null != language && language.getBlock() != null) {
                    menu.findItem(R.id.custom_action_unblock_user).setTitle(language.getBlock().get4());
                }
            }*/

            SessionData session = SessionData.getInstance();
            if (session.isBuddyListBroadcastMissed()) {
                session.setBuddyListBroadcastMissed(false);
                updateBuddyList();
            }
        } catch (Exception e) {
            Logger.error("onCreateOptionsMenu in oneononefragment.java Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
        super.onCreateOptionsMenu(menu, inflater);
    }

    /**
     * Populate the content of listview
     */
    private void updateBuddyList() {
        try {
            //list = Buddy.getAllBuddies();
            list = Buddy.getAllVisibieBuddies();
            if (null != list && list.size() > 0) {
                relativeLayoutNoUsers.setVisibility(View.GONE);
                adapter.clear();
                adapter.addAll(list);
                //adapter.notifyDataSetChanged();
            } else {
                adapter.clear();
                noUsersOnline.setText(noBuddyText);
                relativeLayoutNoUsers.setVisibility(View.VISIBLE);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

        Buddy buddy = (Buddy) parent.getItemAtPosition(position);
        Intent intent = new Intent(getActivity(), SingleChatActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
        intent.putExtra(IntentExtrasKeys.BUDDY_ID, buddy.buddyId);
        if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL).isEmpty()) {
            intent.putExtra("ImageUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL));
        }
        if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL).isEmpty()) {
            intent.putExtra("VideoUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL));
        }
        if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL).isEmpty()) {
            intent.putExtra("AudioUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL));
        }
        intent.putExtra(IntentExtrasKeys.BUDDY_NAME, buddy.name);

        //PushNotificationsManager.clearAllNotifications();

		/* Clear the unread count*/
        isCountCleared = true;
        SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_ONE_ON_ONE);
        startActivity(intent);

        if (0L != buddy.unreadCount) {
            buddy.unreadCount = 0;
            buddy.save();
            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
            iintent.putExtra(IntentExtrasKeys.NEW_MESSAGE, 1);
            PreferenceHelper.getContext().sendBroadcast(iintent);
            SessionData.getInstance().setChatbadgeMissed(true);
            //adapter.notifyDataSetChanged();
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            getActivity().registerReceiver(customReceiver,
                    new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION));
        }
        /*SessionData session = SessionData.getInstance();
        if (session.isBuddyListBroadcastMissed()) {
            session.setBuddyListBroadcastMissed(false);
            updateBuddyList();
        }*/
    }

    @Override
    public void onStop() {
        try {
            super.onStop();
            if (null != customReceiver) {
                getActivity().unregisterReceiver(customReceiver);
            }
        /*
         * If any buddy is selected for chat then refresh the buddy list to
		 * clear the unread count
		 */
            if (isCountCleared) {
                isCountCleared = false;
                //updateBuddyList();
                adapter.notifyDataSetChanged();
            }
            isSearchStart = false;
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onQueryTextChange(String searchText) {
        if (oneToOneListview != null && oneToOneListview.getAdapter() != null) {
            searchText = searchText.replaceAll("^\\s+", "");
            if (!searchView.isIconified() && !TextUtils.isEmpty(searchText)) {
                onoSearchText = searchText;
            }
            if (!TextUtils.isEmpty(searchText)) {
                searchUser(searchText, true);
                isSearchStart = true;
                lastSearchisZero = false;
            } else {
                /*
                 * If view is loaded again because of tab switching then dont
				 * call this method
				 */

                if (isSearchStart) {
                    if (!lastSearchisZero) {
                        lastSearchisZero = true;
                        onoSearchText = searchText;
                        searchUser(searchText, false);
                    }
                }
            }
        }
        return true;
    }

    private void searchUser(String searchText, boolean search) {
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
            relativeLayoutNoUsers.setVisibility(View.VISIBLE);
        } else {
            relativeLayoutNoUsers.setVisibility(View.GONE);
        }

        adapter.clear();
        adapter.addAll(list);
        //adapter.notifyDataSetChanged();
    }

    @Override
    public boolean onQueryTextSubmit(String arg0) {
        return false;
    }
}
