package com.inscripts.fragments;

import android.annotation.SuppressLint;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.SearchView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;

import com.github.clans.fab.FloatingActionButton;
import com.inscripts.activities.AnnouncementActivity;
import com.inscripts.activities.R;
import com.inscripts.activities.SettingActivity;
import com.inscripts.adapters.RecentListAdapter;
import com.inscripts.factories.DataCursorLoader;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.models.Conversation;
import com.inscripts.utils.Logger;


public class RecentFragment extends Fragment implements LoaderManager.LoaderCallbacks<Cursor> , SearchView.OnQueryTextListener {

    private static final java.lang.String TAG = RecentFragment.class.getSimpleName();
    private FloatingActionButton fabNewGroup;
    private final int CHATS_LOADER = 1;
    private final int CHATS_SEARCH_LOADER =2;
    private RecyclerView recentRecyclerView;
    private RecentListAdapter recentListAdapter;
    private BroadcastReceiver customReceiver;
    private SearchView searchView;
    private boolean isSearching = false,isSearchStart = true,lastSearchisZero = false;
    private static String onoSearchText = "";

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
    }


    @Override
    public void onResume() {
        super.onResume();
        onFragmentResume();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {


        fabNewGroup = (FloatingActionButton) getActivity().findViewById(R.id.fabNewGroupChat);

        View view = inflater.inflate(R.layout.fragment_chat, container, false);

        recentRecyclerView = (RecyclerView) view.findViewById(R.id.recent_recyler_view);
        recentRecyclerView.setLayoutManager(new LinearLayoutManager(getContext()));
        recentRecyclerView.setAdapter(recentListAdapter);
        if (getLoaderManager().getLoader(CHATS_LOADER) == null) {
            getLoaderManager().initLoader(CHATS_LOADER, null, this);
        }else {
            getLoaderManager().restartLoader(CHATS_LOADER, null, this);
        }

        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                try {
                    Bundle extras = intent.getExtras();
                    if (extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_RECENT_FRAGMENT)) {
                       /* if (!isSearching) {
                            updateBuddyList();
                        }*/
                        onFragmentResume();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };
        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {

        try {
            MenuItem searchMenuItem = menu.findItem(R.id.custom_action_search);
            searchView = (SearchView) MenuItemCompat.getActionView(searchMenuItem);
            searchView.setOnQueryTextListener(this);

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

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
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
        }
        return super.onOptionsItemSelected(item);
    }


    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {
            if (null != fabNewGroup) {
                fabNewGroup.setVisibility(View.VISIBLE);
            }
        }
    }

    public void onFragmentResume(){
        Logger.error(TAG,"onFragmentResume called");
            if (getLoaderManager().getLoader(CHATS_LOADER) != null) {
            getLoaderManager().restartLoader(CHATS_LOADER, null, this);
        }
    }

    @Override
    public Loader<Cursor> onCreateLoader(int id, Bundle bundle) {

        String selection;
        String[] selectionArgs;

        switch (id) {
            case CHATS_LOADER:
                selection = Conversation.getAllConversationQuery();
                return new DataCursorLoader(getContext(), selection, null);

            case CHATS_SEARCH_LOADER:
                String searchText = bundle.getString("search_key");
                Logger.error(TAG,"SearchText value = "+searchText);
                selection = Conversation.getSearchConversationQuery(searchText);
                return new DataCursorLoader(getContext(), selection, null);

            default:
                return null;
        }
    }

    @Override
    public void onLoadFinished(Loader<Cursor> loader, Cursor data) {
        Logger.error(TAG,"Recent on load data = "+ data.getCount());

            if(recentListAdapter == null){
                recentListAdapter = new RecentListAdapter(getActivity(),this,data);
                recentRecyclerView.setAdapter(recentListAdapter);
            }else {
                recentListAdapter.swapCursor(data);
            }
    }

    @Override
    public void onLoaderReset(Loader<Cursor> loader) {

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
        try {
            super.onStop();
            if (null != customReceiver) {
                getActivity().unregisterReceiver(customReceiver);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onQueryTextSubmit(String query) {
        return false;
    }

    @Override
    public boolean onQueryTextChange(String searchText) {
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

        return true;
    }

    private void searchUser(String searchText, boolean search) {
        Logger.error(TAG,"Search user called with key "+searchText);
        if (search) {
            isSearching = true;
            Bundle bundle = new Bundle();
            bundle.putString("search_key",searchText);
            if (getLoaderManager().getLoader(CHATS_SEARCH_LOADER) == null) {
                getLoaderManager().initLoader(CHATS_SEARCH_LOADER, bundle, this);
            }else {
                getLoaderManager().restartLoader(CHATS_SEARCH_LOADER, bundle, this);
            }

        } else {
            getLoaderManager().restartLoader(CHATS_LOADER, null, this);
        }

     /*   if (null == list || list.size() == 0) {
            if (!search) {
                noUsersOnline.setText(noBuddyText);
            } else {
                noUsersOnline.setText(language.getCore().get58());
            }
            relativeLayoutNoUsers.setVisibility(View.VISIBLE);
        } else {
            relativeLayoutNoUsers.setVisibility(View.GONE);
        }*/

    }

}
