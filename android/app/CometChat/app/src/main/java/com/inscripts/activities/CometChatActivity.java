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
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewConfiguration;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.github.clans.fab.FloatingActionButton;
import com.github.clans.fab.FloatingActionMenu;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdSize;
import com.google.android.gms.ads.AdView;
import com.google.firebase.messaging.FirebaseMessaging;
import com.inscripts.adapters.ViewPagerAdapter;
import com.inscripts.custom.BadgeView;
import com.inscripts.factories.DataCursorLoader;
import com.inscripts.fragments.ChatroomsFragment;
import com.inscripts.fragments.OneOnOneFragment;
import com.inscripts.fragments.RecentFragment;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.heartbeats.HybridHeartbeat;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.NoInternetCallback;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.Conversation;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.plugins.PushNotificationsManager.PushNotificationKeys;
import com.inscripts.plugins.VideoChat;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.CustomActivity;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.videochat.IncomingCallActivity;

import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class CometChatActivity extends CustomActivity implements FloatingActionMenu.OnMenuToggleListener  {

    private static final String TAG = CometChatActivity.class.getSimpleName();
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
    private TabLayout tabs;
    //private SlidingTabLayout tabLayout;
    private TabLayout tabLayout;
    private ViewPager viewPager;
    private Lang lang;
    private View shadowView;
    private FloatingActionMenu fabMenu;
    private FloatingActionButton fabNewBroadcast;
    private FloatingActionButton fabNewGroup;
    private boolean chatroomChannnelSubFlag = true;

    @Override
    protected void onResume() {

        if(fabMenu != null){
            fabMenu.close(false);
        }

        super.onResume();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cometchat);
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
            tabs = (TabLayout) findViewById(R.id.tabs);
            setSupportActionBar(toolbar);
            viewPager = (ViewPager) findViewById(R.id.viewpager);
            tabLayout = (TabLayout) findViewById(R.id.tabs);
            shadowView = (View) findViewById(R.id.shadowView);
            fabMenu = (FloatingActionMenu)findViewById(R.id.fabMenu);
            fabNewBroadcast = (FloatingActionButton) findViewById(R.id.fabNewBroadcast);
            fabNewGroup = (FloatingActionButton) findViewById(R.id.fabNewGroupChat);


            fabMenu.setVisibility(View.VISIBLE);
            fabMenu.setIconAnimated(false);
            fabMenu.setOnMenuToggleListener(this);


            //setup fabmenu
            if(!JsonPhp.getInstance().getAllowusersCreatechatroom().equals("1")){
                fabNewGroup.setVisibility(View.GONE);
            }

            if(!JsonPhp.getInstance().getConfig().getBroadcastMessageEnabled().equals("1")){
                fabNewBroadcast.setVisibility(View.GONE);
            }

            //tabLayout.setDistributeEvenly(true); // To make the Tabs Fixed set this true, This makes the tabs Space Evenly in Available width
            if (null != PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE) && !(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE)).isEmpty()) {
                int versionnumber = CommonUtils.getVersionCode(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE));
                PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE, versionnumber);
            }

            //set Dynamic color
            handleIntent(getApplicationContext(), getIntent());

            mobileTheme = JsonPhp.getInstance().getMobileTheme();
            css = JsonPhp.getInstance().getCss();
            if (mobileTheme != null && null != mobileTheme.getActionbarColor() && null != mobileTheme.getTabHighlightColor()) {
                tabHighLightColor = mobileTheme.getTabHighlightColor();
                actionBarColor = mobileTheme.getActionbarColor();
            } else if (null != css) {
                tabHighLightColor = css.getTabTitleBackground();
                actionBarColor = css.getTabTitleBackground();
            } else {
                tabHighLightColor = StaticMembers.COMETCHAT_DARK_GREEN;
                actionBarColor = StaticMembers.COMETCHAT_DARK_GREEN;
            }
            lang = JsonPhp.getInstance().getLang();

            setActionBarTitle(this.getTitle());


            if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getNewBroadcast()) {
                fabNewBroadcast.setLabelText(JsonPhp.getInstance().getLang().getMobile().getNewBroadcast());
            }

            if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getNewGroup()) {
                fabNewGroup.setLabelText(JsonPhp.getInstance().getLang().getMobile().getNewGroup());
            }

            initializeTabs();
            initializeSessionData();
            if (!isHeartbeatInitialized) {
                initializeHearBeats();
                isHeartbeatInitialized = true;
            }

            String ad_unit_id = JsonPhp.getInstance().getAdUnitId();
            if (!TextUtils.isEmpty(ad_unit_id)) {
                AdView myadView = new AdView(this);
                myadView.setAdSize(AdSize.SMART_BANNER);
                myadView.setAdUnitId(ad_unit_id);

                myadView.setId(R.id.buttonLogin);

                final RelativeLayout r = (RelativeLayout) findViewById(R.id.relativeLayoutParentCometchatActivity);
                RelativeLayout.LayoutParams params1 = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MATCH_PARENT,
                        RelativeLayout.LayoutParams.WRAP_CONTENT);
                params1.alignWithParent = true;
                params1.addRule(RelativeLayout.ALIGN_PARENT_BOTTOM);
                params1.addRule(RelativeLayout.CENTER_VERTICAL);
                //params1.addRule(RelativeLayout.BELOW,viewPager.getId());
                myadView.setLayoutParams(params1);
                r.addView(myadView);

                final RelativeLayout r1 = (RelativeLayout) findViewById(R.id.toolbarContainer);
                RelativeLayout.LayoutParams params2 = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.MATCH_PARENT,
                        RelativeLayout.LayoutParams.MATCH_PARENT);
                params2.addRule(RelativeLayout.ABOVE, myadView.getId());
                r1.setLayoutParams(params2);

                //AdRequest abc = new AdRequest.Builder().build();
                AdRequest abc = new AdRequest.Builder().build();
                myadView.loadAd(abc);
                myadView.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
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
                    } else if (extras.containsKey(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE)) {
                        updateBuddyListBadge();
                    } else if (extras.containsKey(BroadcastReceiverKeys.IntentExtrasKeys.NEW_CHATROOM_MESSAGE)) {
                        updateChatroomBadgeCount();
                    }
                }
            };

            if(chatroomChannnelSubFlag){
                updateSubscribeChatroom();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        setThemeColor();
        checkPermission();

        shadowView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(shadowView.getVisibility() == View.VISIBLE){
                    shadowView.setVisibility(View.GONE);
                    fabMenu.close(false);
                }
            }
        });

        fabNewBroadcast.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                fabMenu.close(true);
                Intent intent = new Intent(CometChatActivity.this,BroadcastMessageActivity.class);
                startActivity(intent);
            }
        });

        fabNewGroup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                fabMenu.close(true);
                Intent intent = new Intent(CometChatActivity.this,CreateChatroomActivity.class);
                startActivity(intent);
            }
        });

    }

    private void setThemeColor(){
        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        tabLayout.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabMenu.setMenuButtonColorNormal(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabMenu.setMenuButtonColorPressed(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabMenu.setMenuButtonColorRipple(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewBroadcast.setColorNormal(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewBroadcast.setColorPressed(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewBroadcast.setColorRipple(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewGroup.setColorNormal(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewGroup.setColorPressed(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        fabNewGroup.setColorRipple(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
    }

    private void updateSubscribeChatroom() {
        chatroomChannnelSubFlag = false;
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)) {
            String channelListStr = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
            if (!TextUtils.isEmpty(channelListStr)) {
                channelListStr = channelListStr.substring(1, channelListStr.length() - 1);
            }
            List<String> items = Arrays.asList(channelListStr.split("\\s*,\\s*"));
            if (items.size() > 0) {
                for (int i = 0; i < items.size(); i++) {
                    if (!TextUtils.isEmpty(items.get(i))) {
                        FirebaseMessaging.getInstance().subscribeToTopic(items.get(i));
                    }
                }
            }
        }
    }

    private void checkPermission(){

        int PERMISSION_ALL = 1;

        String[] PERMISSIONS = {android.Manifest.permission.WRITE_EXTERNAL_STORAGE,android.Manifest.permission.RECORD_AUDIO,android.Manifest.permission.RECORD_AUDIO,android.Manifest.permission.CAMERA , Manifest.permission.READ_CONTACTS , Manifest.permission.SEND_SMS , Manifest.permission.READ_PHONE_STATE};

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

        if (!PreferenceHelper.contains(PreferenceKeys.HashKeys.BOT_LIST_HASH)) {
            PreferenceHelper.save(PreferenceKeys.HashKeys.BOT_LIST_HASH, "");
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

    private void updateBuddyListBadge() {
        SessionData.getInstance().setChatbadgeMissed(false);
        try {

            String badgeCount = String.valueOf(Conversation.getUnreadConversationCount());
            Logger.error("Conversations badge count = "+badgeCount);
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
            /*if (tabLayout != null) {
                tabLayout.updateBadgeCount(oneononeTabText, badgeCount);
            }*/
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void updateChatroomBadgeCount() {
       /* try {
            //String badgeCount = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT);
            String chatroomTabText = StaticMembers.CHATROOM_TAB_TEXT;
            String badgeCount = String.valueOf(Chatroom.getUnreadChatroomCount());
            Logger.error("Chatroom badge count value = "+ badgeCount);
            TabLayout.Tab tab = tabLayout.getTabAt(1);
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
                tabLayout.updateBadgeCount(chatroomTabText, badgeCount);
            }*//*
        } catch (Exception e) {
            e.printStackTrace();
        }*/
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
                            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS)){
                                Set<String> set = PreferenceHelper.getStringSet(PreferenceKeys.DataKeys.SUBSCRIBED_CHANNELS);
                                List<String> sample=new ArrayList<String>(set);
                                for (int i = 0 ; i<sample.size(); i++){
                                    CometserviceChatroom.getInstance().startChatroomCometService(sample.get(i));
                                }
                            }
                        } else if (transport.equals("cometservice-selfhosted")) {
                            WebsyncChatroom.getInstance().connect(
                                    JsonPhp.getInstance().getWebsyncServer(), String.valueOf(session.getCurrentChatroom()),
                                    session.getChatroomCometId());
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

                hybridHeartbeat.startHeartbeat(getApplicationContext(), new NoInternetCallback() {
                    @Override
                    public void noInternet() {
                        activity.runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                if (internetFlag) {
                                    Toast.makeText(getApplicationContext(), JsonPhp.getInstance().getLang().getMobile().get24(), Toast.LENGTH_SHORT).show();
                                }
                            }
                        });

                    }
                });

            } else {
                heartbeatOneOnOne.startHeartbeat(getApplicationContext(), new NoInternetCallback() {
                    @Override
                    public void noInternet() {
                        activity.runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                if (internetFlag) {
                                    Toast.makeText(getApplicationContext(), JsonPhp.getInstance().getLang().getMobile().get24(), Toast.LENGTH_SHORT).show();
                                }
                            }
                        });

                    }
                });

                if (JsonPhp.getInstance().getChatroomsmoduleEnabled() != null
                        && JsonPhp.getInstance().getChatroomsmoduleEnabled().equals("1")) {
                    heartbeatChatroom.startHeartbeat(getApplicationContext());
                }

            }

        }catch (Exception e){
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

            Config config = JsonPhp.getInstance().getConfig();

            RecentFragment recentFragment = null;

            Logger.error("Is bots enabled = "+config.getBotsEnabled());
            if (null == config.getOneononeEnabled()) {
                recentFragment = new RecentFragment();
                adapter.addFragment(recentFragment, recentsTabText, R.drawable.ic_tab_one_on_one);
            } else if (config.getOneononeEnabled().equals("1")) {
                adapter.addFragment(new RecentFragment(), recentsTabText, R.drawable.ic_tab_one_on_one);
            }

            if (null == config.getOneononeEnabled()) {
                adapter.addFragment(new OneOnOneFragment(), oneOnOneTabText, R.drawable.ic_tab_one_on_one);
            } else if (config.getOneononeEnabled().equals("1")) {
                adapter.addFragment(new OneOnOneFragment(), oneOnOneTabText, R.drawable.ic_tab_one_on_one);
            }

            if (null == JsonPhp.getInstance().getChatroomsmoduleEnabled()) {
                adapter.addFragment(new ChatroomsFragment(), chatroomTabText, R.drawable.ic_tab_chatroom);
            } else if (JsonPhp.getInstance().getChatroomsmoduleEnabled().equals("1")) {
                adapter.addFragment(new ChatroomsFragment(), chatroomTabText, R.drawable.ic_tab_chatroom);
            }

            viewPager.setAdapter(adapter);
            tabLayout.setupWithViewPager(viewPager);

            if(lang.getMobile().getTabtitle_contact()!= null){
                oneOnOneTabText = lang.getMobile().getTabtitle_contact();
            }

            if(lang.getMobile().getTabtitle_groups() != null){
                chatroomTabText = lang.getMobile().getTabtitle_groups();
            }

            //set custom tab view
            TabLayout.Tab tabRecent = tabLayout.getTabAt(0);  // Recent
            LinearLayout viewRecent = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
            TextView tvRecent = (TextView) viewRecent.findViewById(R.id.tv_tab_title);
            tvRecent.setTextColor(tabLayout.getTabTextColors());
            BadgeView badgeViewRecent = (BadgeView) viewRecent.findViewById(R.id.batch_view);
            badgeViewRecent.setVisibility(View.GONE);
            tvRecent.setText(recentsTabText);
            tabRecent.setCustomView(viewRecent);

            //set custom tab view
            TabLayout.Tab tab = tabLayout.getTabAt(1);  // One-On-One
            LinearLayout view = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
            TextView tv = (TextView) view.findViewById(R.id.tv_tab_title);
            tv.setTextColor(tabLayout.getTabTextColors());
            BadgeView badgeView = (BadgeView) view.findViewById(R.id.batch_view);
            badgeView.setVisibility(View.GONE);
            tv.setText(oneOnOneTabText);
            tab.setCustomView(view);


            TabLayout.Tab tab2 = tabLayout.getTabAt(2); // Groups
            LinearLayout view2 = (LinearLayout) LayoutInflater.from(this).inflate(R.layout.custom_tab, null);
            TextView tv2 = (TextView) view2.findViewById(R.id.tv_tab_title);
            tv2.setTextColor(tabLayout.getTabTextColors());
            BadgeView badgeView2= (BadgeView) view2.findViewById(R.id.batch_view);
            badgeView2.setVisibility(View.GONE);
            tv2.setText(chatroomTabText);
            tab2.setCustomView(view2);


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

                    if(selectedTab.equals(StaticMembers.RECENTS_TAB_TEXT)){
                            RecentFragment recentFragment1 = (RecentFragment) ViewPagerAdapter.mFragmentList.get(position);
                            recentFragment1.onFragmentResume();
                    }
                }

                @Override
                public void onPageScrollStateChanged(int state) {

                }
            });

            updateBuddyListBadge();
            updateChatroomBadgeCount();

            tabActivity = this;
        } catch (Exception e) {
            e.printStackTrace();
        }
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
        PushNotificationsManager.clearAllNotifications();
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

        if(hybridHeartbeat != null){
            hybridHeartbeat.stopHeartbeatHybrid();
        }

        /* if cometservice is enabled unsubscribe from channel */
        Config config = JsonPhp.getInstance().getConfig();
        if (null != config && config.getUSECOMET().equals("1")) {

            String transport = config.getTRANSPORT();
            if (transport.equals("cometservice")) {
                CometserviceOneOnOne.getInstance().unSubscribe();
            } else if (transport.equals("cometservice-selfhosted")) {
                WebsyncOneOnOne.getInstance().unsubscribe();
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
            registerReceiver(customReceiver, new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION));
            registerReceiver(customReceiver, new IntentFilter(BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE));
        }
        SessionData session = SessionData.getInstance();
        if (session.isAnnouncementListBroadcastMissed()) {
            session.setAnnouncementListBroadcastMissed(false);
            updateAnnouncementBadgeCount();
        } else if (session.isChatbadgeMissed()) {
            updateBuddyListBadge();
        }
        PushNotificationsManager.clearAllNotifications();
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
        try {
            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                    && "1".equals(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN))) {
                String action = mainIntent.getAction();

                PushNotificationsManager.clearAllNotifications();


                if(mainIntent.hasExtra(PushNotificationsManager.FireBasePushNotificationKeys.IS_FIREBASE_NOTIFICATION)){

                    String messgeStr = mainIntent.getStringExtra(PushNotificationKeys.MESSAGE);
                    JSONObject message = new JSONObject(messgeStr);
                    long buddyId = message.getLong(PushNotificationKeys.FROM_ID);
                    String notificationMessage = message.getString(PushNotificationKeys.MESSAGE);

                    Long time = message.getLong("sent") * 1000;

                    if (message.has("cid")){
                        long chatroomId;
                        if (message.has(CometChatKeys.ChatroomKeys.CID)){
                            chatroomId = Long.parseLong(message.getString(CometChatKeys.ChatroomKeys.CID));
                        }else{
                            chatroomId = Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));
                        }
                        Pattern pattern = Pattern.compile("@(.*?):");
                        Matcher matcher = pattern.matcher(notificationMessage);
                        matcher.find();
                        notificationMessage = matcher.group(1);

                        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
                        if (null != chatroom) {
                            chatroom.unreadCount = 0;
                            chatroom.save();

                            Intent chatroomIntent = new Intent(context, ChatroomActivity.class);
                            chatroomIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_ID, chatroomId);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_NAME, notificationMessage);
                            context.startActivity(chatroomIntent);

                            Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                            intent.putExtra(
                                    BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);
                        } else {
                            // Chatroom doesn't exist locally.
                            Logger.error("chatroom is not present in our db");
                            HeartbeatChatroom.getInstance().setForceHeartbeat();
                        }
                    }else{
                        String messageType = mainIntent.getStringExtra(PushNotificationsManager.FireBasePushNotificationKeys.MESSAGE_TYPE);
                        if(messageType.equals(PushNotificationsManager.FireBasePushNotificationKeys.IS_AUDIO_CALL)){
                            if ((System.currentTimeMillis() - time) < 60000) {
                                String roomName = mainIntent.getStringExtra("grp");
                                Intent avChatIntent = new Intent(context, IncomingCallActivity.class);
                                avChatIntent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, buddyId);
                                avChatIntent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, roomName);
                                avChatIntent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, true);
                                PreferenceHelper.save("FCMBuddyID",buddyId);
                                startActivity(avChatIntent);
                            }

                        }else if(messageType.equals(PushNotificationsManager.FireBasePushNotificationKeys.IS_AV_CALL)){

                            if ((System.currentTimeMillis() - time) < 60000) {
                                String roomName = mainIntent.getStringExtra(PushNotificationsManager.FireBasePushNotificationKeys.ROOMNAME);
                                Intent avChatIntent = new Intent(context, IncomingCallActivity.class);
                                avChatIntent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, buddyId);
                                avChatIntent.putExtra(CometChatKeys.AVchatKeys.ROOM_NAME, roomName);
                                PreferenceHelper.save("FCMBuddyID",buddyId);
                                startActivity(avChatIntent);
                            }
                        }else{
                            Buddy buddy = Buddy.getBuddyDetails(buddyId);
                            buddy.unreadCount = 0;
                            buddy.save();

                            int colonPosition = notificationMessage.indexOf(":");
                            notificationMessage = notificationMessage.substring(0, colonPosition);

                            Intent singleChatIntent = new Intent(context, SingleChatActivity.class);
                            singleChatIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_NAME, notificationMessage);
                            context.startActivity(singleChatIntent);

                            Intent intent = new Intent(
                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);

                            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                            iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(iintent);
                            SessionData.getInstance().setChatbadgeMissed(true);
                        }
                    }
                }

                if (mainIntent.hasExtra(PushNotificationKeys.DATA)) {

                    JSONObject json = new JSONObject(mainIntent.getStringExtra(PushNotificationKeys.DATA));
                    String messgeStr = json.getString(PushNotificationKeys.MESSAGE);
                    JSONObject message = new JSONObject(messgeStr);

                    String notificationMessage = message.getString(PushNotificationKeys.MESSAGE);

                    if (json.has(PushNotificationKeys.IS_CHATROOM)) {
                        long chatroomId;
                        if (message.has(CometChatKeys.ChatroomKeys.CID)){
                            chatroomId = Long.parseLong(message.getString(CometChatKeys.ChatroomKeys.CID));
                        }else{
                            chatroomId = Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID));
                        }
                        Pattern pattern = Pattern.compile("@(.*?):");
                        Matcher matcher = pattern.matcher(notificationMessage);
                        matcher.find();
                        notificationMessage = matcher.group(1);

                        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
                        if (null != chatroom) {
                            chatroom.unreadCount = 0;
                            chatroom.save();

                            Intent chatroomIntent = new Intent(context, ChatroomActivity.class);
                            chatroomIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_ID, chatroomId);
                            chatroomIntent.putExtra(StaticMembers.INTENT_CHATROOM_NAME, notificationMessage);
                            context.startActivity(chatroomIntent);

                            Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                            intent.putExtra(
                                    BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);
                        } else {
                            // Chatroom doesn't exist locally.
                            Logger.error("chatroom is not present in our db");
                            HeartbeatChatroom.getInstance().setForceHeartbeat();
                        }
                    } else if (json.has(PushNotificationKeys.IS_ANNOUNCEMENT)) {
                    } else {
                        /*
                         * Directly show Incoming call screen if it is an av
                         * chat request.
                         */
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

                            Intent singleChatIntent = new Intent(context, SingleChatActivity.class);
                            singleChatIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                            singleChatIntent.putExtra(IntentExtrasKeys.BUDDY_NAME, notificationMessage);
                            context.startActivity(singleChatIntent);

                            Intent intent = new Intent(
                                    BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);

                            Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                            iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                            PreferenceHelper.getContext().sendBroadcast(iintent);
                            SessionData.getInstance().setChatbadgeMissed(true);
                        }
                    }
                } else if (Intent.ACTION_SEND.equals(action)) {
                    Bundle extras = mainIntent.getExtras();
                    String type = mainIntent.getType();
                    if (extras != null && extras.containsKey(Intent.EXTRA_STREAM)) {
                        Uri uri = extras.getParcelable(Intent.EXTRA_STREAM);
                        if (!type.isEmpty() && CommonUtils.checkImageType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_IMAGE_URL, String.valueOf(uri));
                        } else if (!type.isEmpty() && CommonUtils.checkVideoType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_VIDEO_URL, String.valueOf(uri));
                        } else if (!type.isEmpty() && CommonUtils.checkAudioType(type)) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_AUDIO_URL, String.valueOf(uri));
                        } else if (!type.isEmpty() && (CommonUtils.checkApplicationType(type) || CommonUtils.checkTextType(type))) {
                            PreferenceHelper.save(PreferenceKeys.DataKeys.SHARE_FILE_URL, String.valueOf(uri));
                        } else {
                            String last = uri.getLastPathSegment();
                            if (!CommonUtils.setFileType(last, uri)) {
                                if (null != lang && null != lang.getMobile().get178()) {
                                    Toast.makeText(getApplicationContext(), lang.getMobile().get178(), Toast.LENGTH_LONG).show();
                                } else {
                                    Toast.makeText(getApplicationContext(), "File format not supported. ", Toast.LENGTH_LONG).show();
                                }
                            }
                        }
                    } else {
                        if (null != lang && null != lang.getMobile().get178()) {
                            Toast.makeText(getApplicationContext(), lang.getMobile().get178(), Toast.LENGTH_LONG).show();
                        } else {
                            Toast.makeText(getApplicationContext(), "File format not supported. ", Toast.LENGTH_LONG).show();
                        }
                    }
                    mainIntent.removeExtra(Intent.EXTRA_STREAM);
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
        }
    }

    @Override
    public void onMenuToggle(boolean opened) {

        if (opened) {
            Fragment fr = getSupportFragmentManager().findFragmentByTag("android:switcher:" + R.id.viewpager + ":" + viewPager.getCurrentItem());
            if (fr instanceof ChatroomsFragment) {
                Intent intent = new Intent(this, CreateChatroomActivity.class);
                startActivity(intent);
            } else {
                //fabMenu.setMenuButtonLabelText("New Chat");
                fabMenu.getMenuIconView().setImageResource(R.drawable.compose_floating);
                shadowView.setVisibility(View.VISIBLE);
                fabMenu.animate();
            }
        } else  {
            fabMenu.getMenuIconView().setImageResource(R.drawable.compose_floating);
            shadowView.setVisibility(View.GONE);
        }
    }
}
