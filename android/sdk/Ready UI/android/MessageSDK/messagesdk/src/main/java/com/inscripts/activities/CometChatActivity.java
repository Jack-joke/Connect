/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.Manifest;
import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Build;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.ActivityCompat;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewConfiguration;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.adapters.ViewPagerAdapter;
import com.inscripts.custom.BadgeView;
import com.inscripts.fragments.BotsFragment;
import com.inscripts.fragments.ChatroomsFragment;
import com.inscripts.fragments.OneOnOneFragment;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.helpers.PopupHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.LoginCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.plugins.BroadcastMessage;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.CustomActivity;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Field;
import java.util.List;

public class CometChatActivity extends CustomActivity {

    public static CometChatActivity tabActivity;
    private static boolean isHeartbeatInitialized = false;

    private HeartbeatOneOnOne heartbeatOneOnOne;
    private HeartbeatChatroom heartbeatChatroom;
    private HybridHeartbeat hybridHeartbeat;
    private Long interval;
    private Css css;
    private MobileTheme mobileTheme;
    private BroadcastReceiver customReceiver;
    private String actionBarColor, tabHighLightColor;
    private List<Buddy> list;
    private Activity activity;
    private boolean internetFlag = true;

    private Toolbar toolbar;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private Lang lang;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_cometchat);

        try {
            PreferenceHelper.initialize(this);
            activity = this;
            if(JsonPhp.getInstance().getMobileTheme().getPrimaryColor()!= null){
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,JsonPhp.getInstance().getMobileTheme().getPrimaryColor());
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,JsonPhp.getInstance().getMobileTheme().getPrimarkDaryColor());
            }else if(null != JsonPhp.getInstance().getMobileTheme().getActionbarColor()){
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,JsonPhp.getInstance().getMobileTheme().getActionbarColor());
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,JsonPhp.getInstance().getMobileTheme().getActionbarColor());
            } else {
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY, getResources().getColor(R.color.colorPrimary));
                PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK, getResources().getColor(R.color.colorPrimaryDark));
            }

            toolbar = (Toolbar) findViewById(R.id.toolbar);
            setSupportActionBar(toolbar);
            setActionBarColor(null);
            setActionBarTitle("Chat");
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            toolbar.setNavigationIcon(R.drawable.cc_ic_action_cancel);
            viewPager = (ViewPager) findViewById(R.id.viewpager);
            tabLayout = (TabLayout) findViewById(R.id.tabs);
            //tabLayout.setDistributeEvenly(true); // To make the Tabs Fixed set this true, This makes the tabs Space Evenly in Available width
            handleIntent(getApplicationContext(), getIntent());
            mobileTheme = JsonPhp.getInstance().getMobileTheme();


            css = JsonPhp.getInstance().getCss();

            lang = JsonPhp.getInstance().getLang();

           /* if (mobileTheme != null && null != mobileTheme.getActionbarColor() && null != mobileTheme.getTabHighlightColor()) {
                tabHighLightColor = mobileTheme.getTabHighlightColor();
                actionBarColor = mobileTheme.getActionbarColor();
            } else if (null != css) {
                tabHighLightColor = css.getTabTitleBackground();
                actionBarColor = css.getTabTitleBackground();
            } else {
                tabHighLightColor = StaticMembers.COMETCHAT_DARK_GREEN;
                actionBarColor = StaticMembers.COMETCHAT_DARK_GREEN;
            }*/

            /*RelativeLayout layout = (RelativeLayout) findViewById(R.id.custom_top_bar);
            Drawable drawable = layout.getBackground();
            drawable.setColorFilter(Color.parseColor(actionBarColor), PorterDuff.Mode.SRC_ATOP);*/

            initializeTabs();
            initializeSessionData();
            if (!isHeartbeatInitialized) {
                initializeHearBeats();
                isHeartbeatInitialized = true;
            }

            setThemeColor();
            checkPermission();

            if (null != PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE) && !(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE)).isEmpty()) {
                int versionnumber = CommonUtils.getVersionCode(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE));
                PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE, versionnumber);
            }


            /* Added to show Option menu on lower versions of android */
            try {
                ViewConfiguration config = ViewConfiguration.get(this);
                Field menuKeyField = ViewConfiguration.class.getDeclaredField(StaticMembers.PERMANENT_MENU_KEY);
                if (menuKeyField != null) {
                    menuKeyField.setAccessible(true);
                    menuKeyField.setBoolean(config, false);
                }
            } catch (Exception ex) {
                ex.printStackTrace();
            }
            customReceiver = new BroadcastReceiver() {

                @Override
                public void onReceive(Context context, Intent intent) {
                    Bundle extras = intent.getExtras();
                    if (extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_BADGE)) {
                        updateAnnouncementBadgeCount();
                        SessionData.getInstance().setAnnouncementListBroadcastMissed(false);
                    } else if (extras.containsKey(IntentExtrasKeys.NEW_MESSAGE)) {
                        //updateBuddyListBadge();
                    }
                }
            };


            LoginCallbacks loginCallbacks = HeartbeatOneOnOne.getInstance().getReadyUIListener();

            if(loginCallbacks!= null){
                JSONObject launchObject = new JSONObject();
                launchObject.put("chatWindow","opened");
                loginCallbacks.chatWindowListner(launchObject);
            }

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private void initializeSessionData() {

        SessionData session = SessionData.getInstance();

        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.USER_STATUS)) {
            try {
                session.update(new JSONObject(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_STATUS)));
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        session.setBaseData(PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
        if (PreferenceHelper.contains(PreferenceKeys.UserKeys.USER_ID)) {
            session.setId(Long.parseLong(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_ID)));
        }
        session.setInitialHeartbeat(true);

        /* Set current windowid to 0 to allow unreadcount to be updated */
        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, "0");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
        }

        if (null == session.getChatroomHeartBeatTimestamp()) {
            session.setChatroomHeartBeatTimestamp("0");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.HashKeys.BUDDY_LIST_HASH)) {
            PreferenceHelper.save(PreferenceKeys.HashKeys.BUDDY_LIST_HASH, "");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.ANN_BADGE_COUNT)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.ANN_BADGE_COUNT, 0);
        }

        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.NOTIFICATION_ON)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_ON, "1");
        }
        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.READ_TICK)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.READ_TICK, "1");
        }
        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.LAST_SEEN_SETTING)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_SEEN_SETTING, "1");
        }
        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.TYPING_SETTING)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.TYPING_SETTING, "1");
        }
        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.NOTIFICATION_SOUND)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_SOUND, "1");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE)) {
            PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE, "1");
        }

        if (JsonPhp.getInstance().getCometchatVersion() != null) {
            PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE, CommonUtils.getVersionCode(JsonPhp.getInstance().getCometchatVersion()));
        }

        /*if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.USER_CHAT_BADGE)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, "0");
        }*/

        if (TextUtils.isEmpty(session.getBaseData())) {
            session.setBaseData("");
        }

        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {
            session.setCurrentChatroom(Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)));
        } else {
            PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID, "0");
            session.setCurrentChatroom(0);
        }

        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_COMET_ID)) {
            session.setChatroomCometId(PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_COMET_ID));
        } else {
            PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_COMET_ID, "0");
            session.setChatroomCometId("0");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.SELECTED_LANGUAGE)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.SELECTED_LANGUAGE, "");
        }

        session.setVibrateOn(false);
        session.setMediaPlayerOn(false);
        session.setAvchatStatus(0);

        if (null == session.getCurrentChatroomPassword()) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD)) {
                session.setCurrentChatroomPassword(PreferenceHelper
                        .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD));
            } else {
                session.setCurrentChatroomPassword("");
            }
        }
    }

    private void updateAnnouncementBadgeCount() {
        try {
            String badgeCount = PreferenceHelper.get(PreferenceKeys.DataKeys.ANN_BADGE_COUNT);
            String announcementTabText = StaticMembers.ANNOUNCEMENT_TAB_TEXT;
            /*if (tabLayout != null) {
                tabLayout.updateBadgeCount(announcementTabText, badgeCount);
            }*/
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void setThemeColor(){
        //setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        toolbar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
        tabLayout.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
    }
    private void checkPermission(){

        int PERMISSION_ALL = 1;

        String[] PERMISSIONS = {android.Manifest.permission.WRITE_EXTERNAL_STORAGE,android.Manifest.permission.RECORD_AUDIO,android.Manifest.permission.RECORD_AUDIO,android.Manifest.permission.CAMERA , Manifest.permission.WRITE_CONTACTS , Manifest.permission.CALL_PHONE, Manifest.permission.SEND_SMS};

        if(!hasPermissions(this, PERMISSIONS)){
            ActivityCompat.requestPermissions(this, PERMISSIONS, PERMISSION_ALL);
        }

    }

    public static boolean hasPermissions(Context context, String... permissions) {
        if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && context != null && permissions != null) {
            for (String permission : permissions) {
                if (ActivityCompat.checkSelfPermission(context, permission) != PackageManager.PERMISSION_GRANTED) {
                    return false;
                }
            }
        }
        return true;
    }


    private void updateBuddyListBadge() {
        SessionData.getInstance().setChatbadgeMissed(false);
        try {

           /* String badgeCount = String.valueOf(Buddy.getUnreadBuddyCount());
            Logger.error("Buddylist badge count = "+badgeCount);
            TabLayout.Tab tab = tabLayout.getTabAt(0);
            LinearLayout view = (LinearLayout) tab.getCustomView();
            BadgeView bg = (BadgeView) view.findViewById(R.id.batch_view);
            if(Integer.parseInt(badgeCount)>0){
                bg.setVisibility(View.VISIBLE);
                bg.setText(badgeCount);
            }else{
                bg.setVisibility(View.GONE);
            }

            tab.setCustomView(view);
            *//*if (tabLayout != null) {
                tabLayout.updateBadgeCount(oneononeTabText, badgeCount);
            }*/
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void initializeHearBeats() {
        try {
            int cometChatServerVersion = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE));

            if(cometChatServerVersion >= 630){
                hybridHeartbeat = HybridHeartbeat.getInstance();
            }else{
                heartbeatOneOnOne = HeartbeatOneOnOne.getInstance();
                heartbeatChatroom = HeartbeatChatroom.getInstance();
            }

            Config config = JsonPhp.getInstance().getConfig();
            SessionData session = SessionData.getInstance();
            if (null != config && config.getUSECOMET().equals("1")) {
                interval = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
                session.setOneOnOneHeartbeatInterval(interval);
                session.setChatroomHeartbeatInterval(interval);
                if (JsonPhp.getInstance().getChatroomsmoduleEnabled() != null
                        && JsonPhp.getInstance().getChatroomsmoduleEnabled().equals("1")) {
                    if (0 != session.getCurrentChatroom()) {

                        String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
                        if (transport.equals("cometservice")) {
                            if (!ChatroomManager.isSubscribedToChatroom(session.getCurrentChatroom())) {
                                CometserviceChatroom.getInstance().startChatroomCometService(session.getCurrentChatroom());
                            }
                        } else if (transport.equals("cometservice-selfhosted")) {
                            if (!ChatroomManager.isSubscribedToChatroom(session.getCurrentChatroom())) {
                                /*WebsyncChatroom.getInstance().connect(
                                        JsonPhp.getInstance().getWebsyncServer(), String.valueOf(session.getCurrentChatroom()),
                                        session.getChatroomCometId());*/
                            }
                        }

                    }
                }
            } else {
                if (null != config && null != config.getMinHeartbeat()) {
                    interval = Long.parseLong(config.getMinHeartbeat());
                } else {
                    interval = 3000L;
                }
                // Set the heartbeat interval from JSON response
                session.setOneOnOneHeartbeatInterval(interval);
                session.setChatroomHeartbeatInterval(interval);
            }

            if(cometChatServerVersion >= 630) {
                hybridHeartbeat.startHeartbeat(getApplicationContext());

            }else{
                heartbeatOneOnOne.startHeartbeat(getApplicationContext());

                if (JsonPhp.getInstance().getChatroomsmoduleEnabled() != null
                        && JsonPhp.getInstance().getChatroomsmoduleEnabled().equals("1")) {
                    heartbeatChatroom.startHeartbeat(getApplicationContext());
                    heartbeatChatroom.setForceHeartbeat();
                }
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void initializeTabs() {
        try {
            String recentsTabText, oneOnOneTabText, chatroomTabText, botTabText,settingsTabText, announcementTabText, homeTabText;
            final ViewPagerAdapter adapter = new ViewPagerAdapter(getSupportFragmentManager());
            recentsTabText = StaticMembers.RECENTS_TAB_TEXT;
            oneOnOneTabText = StaticMembers.ONE_ON_ONE_TAB_TEXT;
            chatroomTabText = StaticMembers.CHATROOM_TAB_TEXT;
            botTabText = StaticMembers.BOT_TAB_TEXT;

            Config config = JsonPhp.getInstance().getConfig();


            Logger.error("Is bots enabled = "+config.getBotsEnabled());
            /*if (null == config.getOneononeEnabled()) {
                adapter.addFragment(new ChatFragment(), recentsTabText, R.drawable.ic_tab_one_on_one);
            } else if (config.getOneononeEnabled().equals("1")) {
                adapter.addFragment(new ChatFragment(), recentsTabText, R.drawable.ic_tab_one_on_one);
            }*/

            if (null == config.getOneononeEnabled()) {
                adapter.addFragment(new OneOnOneFragment(), oneOnOneTabText, R.drawable.cc_ic_tab_chatroom);
            } else if (config.getOneononeEnabled().equals("1")) {
                adapter.addFragment(new OneOnOneFragment(), oneOnOneTabText, R.drawable.cc_ic_tab_one_on_one);
            }

            if (null == JsonPhp.getInstance().getChatroomsmoduleEnabled()) {
                adapter.addFragment(new ChatroomsFragment(), chatroomTabText, R.drawable.cc_ic_tab_chatroom);
            } else if (JsonPhp.getInstance().getChatroomsmoduleEnabled().equals("1")) {
                adapter.addFragment(new ChatroomsFragment(), chatroomTabText, R.drawable.cc_ic_tab_chatroom);
            }


           /* if(config.getBotsEnabled() == 1)
                adapter.addFragment(new BotsFragment(),botTabText,R.drawable.cc_ic_tab_chatroom);*/

//            if (config.getAnnouncementEnabled() == null) {
//                adapter.addFragment(new AnnouncementFragment(), announcementTabText, R.drawable.ic_tab_announcement);
//            } else if (config.getAnnouncementEnabled().equals("1")) {
//                adapter.addFragment(new AnnouncementFragment(), announcementTabText, R.drawable.ic_tab_announcement);
//            }

            /*if (!TextUtils.isEmpty(config.getHomepageURL())) {
                if (LocalConfig.isWhiteLabelled()) {
                    if (!config.getHomepageURL().contains("cometchat.com")) {
                        adapter.addFragment(new HomeFragment(), homeTabText, R.drawable.ic_tab_home);
                    }
                } else if (!PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO)) {
                    adapter.addFragment(new HomeFragment(), homeTabText, R.drawable.ic_tab_home);
                }
            }*/

            //adapter.addFragment(new SettingsFragment(), settingsTabText, R.drawable.ic_tab_settings);

            viewPager.setAdapter(adapter);
            tabLayout.setupWithViewPager(viewPager);

           /* if(lang.getMobile().getTabtitle_contact()!= null){
                oneOnOneTabText = lang.getMobile().getTabtitle_contact();
            }

            if(lang.getMobile().getTabtitle_groups() != null){
                chatroomTabText = lang.getMobile().getTabtitle_groups();
            }*/

            //set custom tab view
            TabLayout.Tab tab = tabLayout.getTabAt(0);  // One-On-One
            LinearLayout view = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
            TextView tv = (TextView) view.findViewById(R.id.tv_tab_title);
            tv.setTextColor(tabLayout.getTabTextColors());
            BadgeView badgeView = (BadgeView) view.findViewById(R.id.batch_view);
            badgeView.setVisibility(View.GONE);
            tv.setText(oneOnOneTabText);
            tab.setCustomView(view);


            TabLayout.Tab tab2 = tabLayout.getTabAt(1); // Groups
            LinearLayout view2 = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
            TextView tv2 = (TextView) view2.findViewById(R.id.tv_tab_title);
            tv2.setTextColor(tabLayout.getTabTextColors());
            BadgeView badgeView2= (BadgeView) view2.findViewById(R.id.batch_view);
            badgeView2.setVisibility(View.GONE);
            tv2.setText(chatroomTabText);
            tab2.setCustomView(view2);

            /*Logger.error("Get bot enable value = "+config.getBotsEnabled());
            if(config.getBotsEnabled() == 1){
                TabLayout.Tab tab3 = tabLayout.getTabAt(2); // Bots
                LinearLayout view3 = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
                TextView tv3 = (TextView) view3.findViewById(R.id.tv_tab_title);
                tv3.setTextColor(tabLayout.getTabTextColors());
                BadgeView badgeView3= (BadgeView) view3.findViewById(R.id.batch_view);
                badgeView3.setVisibility(View.GONE);
                tv3.setText(botTabText);
                tab3.setCustomView(view3);
            }*/

            /*tabLayout.setCustomTabColorizer(new SlidingTabLayout.TabColorizer() {
                @Override
                public int getIndicatorColor(int position) {
                    return Color.parseColor(tabHighLightColor);
                }
            });*/

            SessionData session = SessionData.getInstance();

            /* Set active tab */
            String topFragment = session.getTopFragment();

            if (null == topFragment) {
                /* User list is at top */
                session.setTopFragment(StaticMembers.TOP_FRAGMENT_ONE_ON_ONE);
            }

            if (StaticMembers.TOP_FRAGMENT_CHATROOM.equals(topFragment)) {
                viewPager.setCurrentItem(1);
            } else {
                viewPager.setCurrentItem(0);
            }


            viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
                @Override
                public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

                }

                @Override
                public void onPageSelected(int position) {
                    String selectedTab = adapter.getPageName(position);
                    invalidateOptionsMenu();
                    if (selectedTab.equals(StaticMembers.ANNOUNCEMENT_TAB_TEXT)) {
                        PreferenceHelper.save(PreferenceKeys.DataKeys.ANN_BADGE_COUNT, 0);
                        updateAnnouncementBadgeCount();
                    }
                }

                @Override
                public void onPageScrollStateChanged(int state) {

                }
            });

            updateBuddyListBadge();
            //updateChatroomBadgeCount();

            tabActivity = this;
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        if (id == android.R.id.home){
            BlankActivity.blankActivity.finish();
            finish();
            overridePendingTransition(0, R.anim.slide_out_down);
            LoginCallbacks loginCallbacks = HeartbeatOneOnOne.getInstance().getReadyUIListener();

            if(loginCallbacks!= null){
                JSONObject launchObject = new JSONObject();
                try {
                    launchObject.put("chatWindow","closed");
                } catch (JSONException e) {
                    e.printStackTrace();
                }
                loginCallbacks.chatWindowListner(launchObject);
            }
        }if(id == R.id.custom_setting){
            Intent settingIntent = new Intent(this, SettingActivity.class);
            startActivity(settingIntent);
        }if(id== R.id.custom_compose){
            showCustomActionBarPopup(findViewById(R.id.custom_compose));
        }

        /*if (id == R.id.custom_action_close_chat) {
            BlankActivity.blankActivity.finish();
            finish();
            overridePendingTransition(0, R.anim.slide_out_down);
        }*/
        return super.onOptionsItemSelected(item);
    }


    private void showCustomActionBarPopup(View view) {
        final PopupWindow showPopup = PopupHelper.newBasicPopupWindow(this);
        LayoutInflater inflater = (LayoutInflater) getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View popupView = inflater.inflate(R.layout.cc_custom_main_compose_action_bar_menu, null);
        showPopup.setContentView(popupView);

        LinearLayout newGroup = (LinearLayout) popupView.findViewById(R.id.ll_new_group);
        LinearLayout newBroadcast = (LinearLayout) popupView.findViewById(R.id.ll_new_broadcast);

        ImageView newGroupmageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_new_group);
        ImageView newBroadcastImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_new_broadcast);


        String primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        newGroupmageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        newBroadcastImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);


        TextView tvNewGroup = (TextView) popupView.findViewById(R.id.tv_new_group);
        TextView tvNewBroadcast = (TextView) popupView.findViewById(R.id.tv_new_broadcast);

/*
        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get92()) {
            tvViewProfile.setText(JsonPhp.getInstance().getLang().getMobile().get92());
        }

        if (null != lang.getCore().get64()) {
            tvClearConversation.setText(lang.getCore().get64());
        }*/


        newGroup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                Intent intent = new Intent(CometChatActivity.this,CreateChatroomActivity.class);
                startActivity(intent);
            }
        });


        if(BroadcastMessage.isEnabled()){

            newBroadcast.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    showPopup.dismiss();
                    Intent intent = new Intent(CometChatActivity.this,BroadcastMessageActivity.class);
                    startActivity(intent);
                }
            });

        }else{
            newBroadcast.setVisibility(view.GONE);

        }




        showPopup.setWidth(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setHeight(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setAnimationStyle(R.style.Animations_GrowFromTop);
        showPopup.showAsDropDown(view);
    }

    /* If activity is opened from notifications */
    @Override
    public void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        Bundle extras = intent.getExtras();
        if (extras != null) {
            if (intent.hasExtra(IntentExtrasKeys.OPEN_SETTINGS)) {
                if (viewPager != null) {
                    viewPager.setCurrentItem(viewPager.getChildCount());
                }
            } else {
                PreferenceHelper.initialize(getApplicationContext());
                handleIntent(getApplicationContext(), intent);
            }
        }
        //PushNotificationsManager.clearAllNotifications();
    }

    @Override
    public void finish() {
        super.finish();

        if (heartbeatOneOnOne != null) {
            heartbeatOneOnOne.stopHeartbeatOneOnOne();
        }

        if (heartbeatChatroom != null) {
            heartbeatChatroom.stopHeartbeatChatroom();
        }

        /* if cometservice is enabled unsubscribe from channel */
        Config config = JsonPhp.getInstance().getConfig();
        if (null != config && config.getUSECOMET().equals("1")) {

            String transport = config.getTRANSPORT();
            if (transport.equals("cometservice")) {
                CometserviceOneOnOne.getInstance().unSubscribe();
            } else if (transport.equals("cometservice-selfhosted")) {
                //WebsyncOneOnOne.getInstance().unsubscribe();
            }
        }
        SessionData.getInstance().setInitialHeartbeat(false);
        isHeartbeatInitialized = false;
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, "0");
        isHeartbeatInitialized = false;
    }


    @Override
    public void onStart() {
        super.onStart();
        if (!internetFlag) internetFlag = true;
        PreferenceHelper.save(PreferenceKeys.DataKeys.IS_TAB_WINDOW_OPEN, "1");
        if (customReceiver != null) {
            registerReceiver(customReceiver, new IntentFilter(
                    BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION));
        }
        SessionData session = SessionData.getInstance();
        if (session.isAnnouncementListBroadcastMissed()) {
            session.setAnnouncementListBroadcastMissed(false);
            updateAnnouncementBadgeCount();
        } else if (session.isChatbadgeMissed()) {
            //updateBuddyListBadge();
        }
        //PushNotificationsManager.clearAllNotifications();
    }

    @Override
    public void onStop() {
        super.onStop();
        PreferenceHelper.save(PreferenceKeys.DataKeys.IS_TAB_WINDOW_OPEN, "0");
        if (null != customReceiver) {
            unregisterReceiver(customReceiver);
        }
        internetFlag = false;

        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_IMAGE_URL)) {
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_IMAGE_URL);
        }
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_VIDEO_URL)) {
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_VIDEO_URL);
        }

    }

    public void handleIntent(Context context, Intent mainIntent) {
        try{
            if (mainIntent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT)) {
                String value = mainIntent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT);

                Intent singleChatIntent = new Intent(context, SingleChatActivity.class);
                singleChatIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_ID, mainIntent.getLongExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, 0L));
                singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_NAME, mainIntent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME));
                if(value.equals("1")) {
                    singleChatIntent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT, "1");
                }
                context.startActivity(singleChatIntent);
                finish();
                overridePendingTransition(R.anim.slide_in_up, R.anim.stay);
            } else{
                overridePendingTransition(R.anim.slide_in_up, R.anim.stay);
            }
        }catch(Exception e){

        }

       /* try {
            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                    && "1".equals(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN))) {
                String action = mainIntent.getAction();

                //PushNotificationsManager.clearAllNotifications();

                if (mainIntent.hasExtra(PushNotificationKeys.DATA)) {

                    JSONObject json = new JSONObject(mainIntent.getStringExtra(PushNotificationKeys.DATA));
                    JSONObject message = json.getJSONObject(PushNotificationKeys.MESSAGE);

                    String notificationMessage = message.getString(PushNotificationKeys.MESSAGE);

                    if (json.has(PushNotificationKeys.IS_CHATROOM)
                            && PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)) {

                        long chatroomId = Long.parseLong(PreferenceHelper
                                .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));

                        Pattern pattern = Pattern.compile("@(.*?):");
                        Matcher matcher = pattern.matcher(notificationMessage);
                        matcher.find();
                        notificationMessage = matcher.group(1);

                        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
                        if (null != chatroom) {
                            chatroom.unreadCount = 0;
                            chatroom.save();

                            *//*Intent chatroomIntent = new Intent(context, ChatroomActivity.class);
                            chatroomIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_ID, chatroomId);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_NAME, notificationMessage);
                            context.startActivity(chatroomIntent);

                            Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                            intent.putExtra(
                                    BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);*//*
                        } else {
                            // Chatroom doesn't exist locally.
                            Logger.error("chatroom is not present in our db");
                            HeartbeatChatroom.getInstance().setForceHeartbeat();
                        }
                    } else if (json.has(PushNotificationKeys.IS_ANNOUNCEMENT)) {
                    } else {
                        *//*
                         * Directly show Incoming call screen if it is an av
                         * chat request.
                         *//*
                        long buddyId = message.getLong(PushNotificationKeys.FROM_ID);
                        if (json.has(PushNotificationKeys.AV_CHAT)
                                && json.getString(PushNotificationKeys.AV_CHAT).equals("1")) {
                            String roomName = VideoChat.getAVRoomName(message.getString(PushNotificationKeys.MESSAGE),
                                    false);

                            Intent avChatIntent = new Intent(context, IncomingCallActivity.class);
                            avChatIntent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, buddyId);
                            avChatIntent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, roomName);
                            context.startActivity(avChatIntent);
                        } else {

                            //Logger.error("normal message");

                            Buddy buddy = Buddy.getBuddyDetails(buddyId);
                            buddy.unreadCount = 0;
                            buddy.save();

                            int colonPosition = notificationMessage.indexOf(":");
                            notificationMessage = notificationMessage.substring(0, colonPosition);
*//*

                            Intent singleChatIntent = new Intent(context, SingleChatActivity.class);
                            singleChatIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_NAME, notificationMessage);
                            context.startActivity(singleChatIntent);
*//*

                            Intent intent = new Intent(
                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);

                            int count = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.USER_CHAT_BADGE));
                            count--;
                            if (count >= 0) {
                                PreferenceHelper.save(PreferenceKeys.DataKeys.USER_CHAT_BADGE, count);
                            }
                            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                            iintent.putExtra(IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(iintent);
                            SessionData.getInstance().setChatbadgeMissed(true);
                        }
                    }
                } else if (Intent.ACTION_SEND.equals(action)) {
                    Bundle extras = mainIntent.getExtras();
                    String type = mainIntent.getType();
                    if (extras != null && extras.containsKey(Intent.EXTRA_STREAM)) {
                        Uri uri = (Uri) extras.getParcelable(Intent.EXTRA_STREAM);
                        if (!type.isEmpty() && CommonUtils.checkImageType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_IMAGE_URL, String.valueOf(uri));
                        } else if (!type.isEmpty() && CommonUtils.checkVideoType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_VIDEO_URL, String.valueOf(uri));
                        } else if (!type.isEmpty() && CommonUtils.checkAudioType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_AUDIO_URL, String.valueOf(uri));
                        }
                    }
                    mainIntent.removeExtra(Intent.EXTRA_STREAM);
                } else if (mainIntent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT)) {
                    String value = mainIntent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT);

                    Intent singleChatIntent = new Intent(context, SingleChatActivity.class);
                    singleChatIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_ID, mainIntent.getLongExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, 0L));
                    singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_NAME, mainIntent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME));
                    if(value.equals("1")) {
                        singleChatIntent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT, "1");
                    }
                    context.startActivity(singleChatIntent);
                    finish();
                    overridePendingTransition(R.anim.slide_in_up, R.anim.stay);
                }
            } else {
                Intent intent = new Intent(context, LoginActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                context.startActivity(intent);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }*/
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        BlankActivity.blankActivity.finish();
        overridePendingTransition(0, R.anim.slide_out_down);

        LoginCallbacks loginCallbacks = HeartbeatOneOnOne.getInstance().getReadyUIListener();
        if(loginCallbacks!= null){
            JSONObject launchObject = new JSONObject();
            try {
                launchObject.put("chatWindow","closed");
            } catch (JSONException e) {
                e.printStackTrace();
            }
            loginCallbacks.chatWindowListner(launchObject);
        }
    }
}
