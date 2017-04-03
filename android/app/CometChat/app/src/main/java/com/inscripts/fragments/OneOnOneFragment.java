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
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.support.v4.app.Fragment;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.SearchView.OnQueryTextListener;
import android.text.Html;
import android.text.TextUtils;
import android.util.DisplayMetrics;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnFocusChangeListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.github.clans.fab.FloatingActionButton;
import com.github.clans.fab.FloatingActionMenu;
import com.inscripts.activities.AnnouncementActivity;
import com.inscripts.activities.BroadcastMessageActivity;
import com.inscripts.activities.R;
import com.inscripts.activities.SettingActivity;
import com.inscripts.activities.SingleChatActivity;
import com.inscripts.activities.SinglePlayerGameActivity;
import com.inscripts.activities.UnblockuserActivity;
import com.inscripts.adapters.BuddyListRecyclerAdapter;
import com.inscripts.factories.DataCursorLoader;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.BlockUnblockUser;
import com.inscripts.plugins.BroadcastMessage;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.TimerClass;
import com.tubb.smrv.SwipeMenuRecyclerView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

import static com.inscripts.models.Buddy.COLUMN_LAST_UPDATED;
import static com.inscripts.models.Buddy.SHOW_USER;

public class OneOnOneFragment extends Fragment implements OnItemClickListener, OnQueryTextListener, FloatingActionMenu.OnMenuToggleListener,LoaderManager.LoaderCallbacks<Cursor>{
    private static final java.lang.String TAG = OneOnOneFragment.class.getSimpleName();
    //private SwipeMenuListView oneToOneListview;
    SwipeMenuRecyclerView oneToOneListview;
   // private BuddyListAdapter adapter;
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
    private View view, shadowView;
    private FloatingActionMenu fabmenu;
    private FloatingActionButton fabBroadcast, fabSinglePlayer, fabNewVideoChat, fabGroup, fabNewBroadcast;

    private final int BUDDY_LOADER = 1;
    private final int BUDDY_SEARCH_LOADER =2;
    private BuddyListRecyclerAdapter buddyListRecyclerAdapter;


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

            //adapter = new BuddyListAdapter(getActivity(), list);

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
                                                intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SUBTITLE_CHANGE, BroadcastReceiverKeys.IntentExtrasKeys.TYPING_STOP);
                                                intent1.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, Long.parseLong(response));
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
            view = inflater.inflate(R.layout.fragment_one_on_one, container, false);

            try {
                relativeLayoutNoUsers = (RelativeLayout) view.findViewById(R.id.relativeLayoutNoUsersMessage);
                //oneToOneListview = (SwipeMenuListView) view.findViewById(R.id.List_of_users);
                oneToOneListview = (SwipeMenuRecyclerView) view.findViewById(R.id.List_of_users);
                oneToOneListview.setLayoutManager(new LinearLayoutManager(getContext()));
                noUsersOnline = (TextView) view.findViewById(R.id.textViewNoUsersMessage);
                noUsersOnline.setText(noBuddyText);
                fabBroadcast = (FloatingActionButton) getActivity().findViewById(R.id.fabNewBroadcast);
                /*fabNewVideoChat = (FloatingActionButton) view.findViewById(R.id.fabNewVideoChat);
                fabSinglePlayer = (FloatingActionButton) view.findViewById(R.id.fabSinglePlayer);*/
                fabmenu = (FloatingActionMenu) view.findViewById(R.id.fabMenu);
                fabGroup = (FloatingActionButton) getActivity().findViewById(R.id.fabNewGroupChat);
                //shadowView = (View) view.findViewById(R.id.shadowView);
                //oneToOneListview.setAdapter(adapter);


                if (BroadcastMessage.isEnabled() || OtherPlugins.isSinglePlayerGamesEnabled()){
                    MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
                    Css css = JsonPhp.getInstance().getCss();
                    int color = 0;
                    if (null != theme && null != theme.getActionbarColor()) {
                        color = Color.parseColor(theme.getActionbarColor());
                    } else if (null != css) {
                        color = Color.parseColor(css.getTabTitleBackground());
                    }
                    //fabmenu.setVisibility(View.VISIBLE);
                    fabmenu.setOnMenuToggleListener(this);
                    fabmenu.setMenuButtonColorNormal(color);
                    fabmenu.setMenuButtonColorPressed(color);
                    fabmenu.setMenuButtonColorRipple(color);

                    if (BroadcastMessage.isEnabled()) {
                        fabBroadcast.setColorNormal(color);
                        fabBroadcast.setColorPressed(color);
                        fabBroadcast.setColorRipple(color);
                        if (null != mobileLangs && null != mobileLangs.get154()) {
                            fabBroadcast.setLabelText(mobileLangs.get154());
                        }
                        fabBroadcast.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Intent intent = new Intent(getActivity(), BroadcastMessageActivity.class);
                                startActivity(intent);
                            }
                        });

                    } else {
                        fabBroadcast.setVisibility(View.GONE);
                    }

                    fabNewVideoChat.setColorNormal(color);
                    fabNewVideoChat.setColorPressed(color);
                    fabNewVideoChat.setColorRipple(color);

                    if (OtherPlugins.isSinglePlayerGamesEnabled()){
                        fabSinglePlayer.setColorNormal(color);
                        fabSinglePlayer.setColorPressed(color);
                        fabSinglePlayer.setColorRipple(color);
                        if (null != mobileLangs && null != mobileLangs.get175()) {
                            //fabSinglePlayer.setLabelText(mobileLangs.get175());
                        }
                        fabSinglePlayer.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                if (CommonUtils.isConnected()){
                                    Intent intent = new Intent(getActivity(), SinglePlayerGameActivity.class);
                                    startActivity(intent);
                                }else{
                                    if (null != mobileLangs) {
                                        if (null != mobileLangs.get24()){
                                            Toast.makeText(getActivity(), mobileLangs.get24(), Toast.LENGTH_SHORT).show();
                                        }else{
                                            Toast.makeText(getActivity(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                                        }
                                    }else{
                                        Toast.makeText(getActivity(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                                    }
                                }
                            }
                        });
                    }else{
                        fabSinglePlayer.setVisibility(View.GONE);
                    }
                }else{
                    fabBroadcast.setVisibility(View.GONE);
                    fabSinglePlayer.setVisibility(View.GONE);
                }

                //oneToOneListview.setOnItemClickListener(this);
                if (!isSearching) {
                    updateBuddyList();
                }
            } catch (Exception e) {
                Logger.error("Exception at onCreateView of oneononefragment.java :" + e.getLocalizedMessage());
                e.printStackTrace();
            }
        }

        if (getLoaderManager().getLoader(BUDDY_LOADER) == null) {
            getLoaderManager().initLoader(BUDDY_LOADER, null, this);
        }

        return view;
    }


    @Override
    public void onResume() {
        super.onResume();

        if (getLoaderManager().getLoader(BUDDY_LOADER) != null) {
            updateBuddyList();
        }
    }


    public int dpToPx(int dp) {
        DisplayMetrics displayMetrics = getContext().getResources().getDisplayMetrics();
        int px = Math.round(dp * (displayMetrics.xdpi / DisplayMetrics.DENSITY_DEFAULT));
        return px;
    }


    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {

            FloatingActionMenu fabMenu = (FloatingActionMenu)getActivity().findViewById(R.id.fabMenu);;
            fabMenu.setVisibility(View.VISIBLE);
        }
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
            switch (item.getItemId()) {

                case R.id.custom_notification:
                    Intent AnnouncementIntent = new Intent(getActivity(), AnnouncementActivity.class);
                    startActivity(AnnouncementIntent);
                    break;

                case R.id.custom_setting:
                    Intent settingIntent = new Intent(getActivity(), SettingActivity.class);
                    startActivity(settingIntent);
                    break;
                case R.id.custom_action_unblock_user:
                    Intent i = new Intent(getActivity(), UnblockuserActivity.class);
                    startActivity(i);
                    break;
                case R.id.custom_action_refresh_buddylist:
                    Cursor cursor = getActivity().getContentResolver().query(
                            ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);
                    JSONArray jsonarray = new JSONArray();
                    while (cursor.moveToNext()) {
                        String phoneNumber = cursor.getString(cursor
                                .getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));
                        if (phoneNumber.length() > 7) {
                            jsonarray.put(phoneNumber.trim().replaceAll("[^0-9]", ""));
                        }
                    }
                    cursor.close();
                    VolleyHelper vHelper = new VolleyHelper(getActivity(), URLFactory.getPhoneRegisterURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    Logger.error("srespo=" + response);
                                    try {
                                        JSONObject jresponse = new JSONObject(response);
                                        if (jresponse.getString("status").equals("1")) {
                                            SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        }
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    Logger.error("frespo=" + response);
                                }
                            });
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "update_friends");
                    int len = jsonarray.length();
                    if (len == 0) {
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CONTACT_LIST, "empty list");
                    } else {
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CONTACT_LIST, jsonarray.toString());
                    }
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.COUNT, len);
                    vHelper.sendAjax();
                    break;
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        menu.findItem(R.id.custom_action_create_chatroom).setVisible(false);
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

            if (BlockUnblockUser.isblockUnblockDisabled()) {
                menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
            } else {
                if (null != language && language.getBlock() != null) {
                    menu.findItem(R.id.custom_action_unblock_user).setTitle(language.getBlock().get4());
                }
            }

            MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
            if (mobileConfig != null) {
                int phoneLoginType = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
                if (Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) == 1 || phoneLoginType < 3) {
                    menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
                }
            } else {
                if (LocalConfig.LOGIN_TYPE < 3) {
                    menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
                }
            }
            SessionData session = SessionData.getInstance();
            if (session.isBuddyListBroadcastMissed()) {
                session.setBuddyListBroadcastMissed(false);
                updateBuddyList();
            }
            menu.findItem(R.id.custom_notification).setVisible(true);
            menu.findItem(R.id.custom_action_search).setVisible(true);
            menu.findItem(R.id.custom_setting).setVisible(true);
            menu.findItem(R.id.add_group).setVisible(false);
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
        getLoaderManager().restartLoader(BUDDY_LOADER, null, this);
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(getContext(), "Clicked", Toast.LENGTH_SHORT).show();
        Buddy buddy = (Buddy) parent.getItemAtPosition(position);
        Intent intent = new Intent(getActivity(), SingleChatActivity.class);
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
        if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL).isEmpty()) {
            intent.putExtra("FileUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL));
        }
        intent.putExtra(IntentExtrasKeys.BUDDY_NAME, buddy.name);

        PushNotificationsManager.clearAllNotifications();

		/* Clear the unread count */
        isCountCleared = true;
        SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_ONE_ON_ONE);
        startActivity(intent);

        if (0L != buddy.unreadCount) {
            buddy.unreadCount = 0;
            buddy.save();
           /* int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_CHAT_BADGE));
            count--;
            if (count >= 0) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, count);
            }*/
            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
            iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
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
               // adapter.notifyDataSetChanged();
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

                    /* * If view is loaded again because of tab switching then dont
                     * call this method*/


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
        Logger.error(TAG,"Search user called with key "+searchText);
        if (search) {
            isSearching = true;
            Bundle bundle = new Bundle();
            bundle.putString("search_key",searchText);
            if (getLoaderManager().getLoader(BUDDY_SEARCH_LOADER) == null) {
                getLoaderManager().initLoader(BUDDY_SEARCH_LOADER, bundle, this);
            }else {
                getLoaderManager().restartLoader(BUDDY_SEARCH_LOADER, bundle, this);
            }

            list = Buddy.searchBuddies(searchText);
        } else {
            getLoaderManager().restartLoader(BUDDY_LOADER, null, this);
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

        //adapter.clear();
        //adapter.addAll(list);
        //adapter.notifyDataSetChanged();
    }

    @Override
    public boolean onQueryTextSubmit(String arg0) {
        return false;
    }

    @Override
    public void onMenuToggle(boolean opened) {
        Logger.error("YES-ENABLE:" + opened);
        /*FragmentManager manager = getActivity().getSupportFragmentManager();
        FragmentTransaction ft = manager.beginTransaction();
        ft.setCustomAnimations(android.R.anim.fade_in,android.R.anim.fade_out);
        ft.replace(R.id.shadowView, new OneOnOneFragment());
        ft.commit();*/
        if (opened) {
            //shadowView.setVisibility(View.VISIBLE);
        } else  {
            //shadowView.setVisibility(View.GONE);
        }
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle bundle) {
        String selection;
        String[] selectionArgs;

        switch (id) {
            case BUDDY_LOADER:
                selection =  "SELECT * FROM `" + Buddy.TABLE_NAME + "` WHERE `" + SHOW_USER + "` = 1 ORDER BY `" + COLUMN_LAST_UPDATED + "` DESC;";
                return new DataCursorLoader(getContext(), selection, null);

            case BUDDY_SEARCH_LOADER:

                String searchText = bundle.getString("search_key");
                Logger.error(TAG,"SearchText value = "+searchText);
                if(!TextUtils.isEmpty(searchText)){
                    selection = "SELECT * FROM `" + Buddy.TABLE_NAME + "` WHERE `" + Buddy.COLUMN_NAME + "` LIKE '%" + searchText
                            + "%' AND `" + Buddy.SHOW_USER + "`=1 ORDER BY `" + Buddy.COLUMN_LAST_UPDATED + "` DESC";
                    return new DataCursorLoader(getContext(), selection, null);
                }

            default:
                return null;
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {

        switch (loader.getId()) {
            case BUDDY_LOADER:
                Logger.error(TAG,"on load data = "+ data.getCount());
                break;

            case BUDDY_SEARCH_LOADER:
                Logger.error(TAG,"on search data load = "+ data.getCount());
        }
        if(buddyListRecyclerAdapter == null){
            buddyListRecyclerAdapter = new BuddyListRecyclerAdapter(getContext(),data);
            oneToOneListview.setAdapter(buddyListRecyclerAdapter);
        }
        buddyListRecyclerAdapter.swapCursor(data);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {
        switch (loader.getId()) {
            case BUDDY_LOADER:
                if (buddyListRecyclerAdapter != null) {
                    buddyListRecyclerAdapter.swapCursor(null);
                }
                break;
            default:
                break;
        }
    }
}
