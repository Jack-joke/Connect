/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.support.v7.app.AppCompatActivity;
import android.text.Html;
import android.text.TextUtils;
import android.view.Window;
import android.view.WindowManager;

import com.facebook.AppEventsLogger;
import com.facebook.Session;
import com.facebook.SessionState;
import com.facebook.UiLifecycleHelper;
import com.google.gson.Gson;
import com.inscripts.activities.R;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.PreferenceKeys;

import java.io.File;

/**
 * Parent Activity class for all activties having a top bar
 */
public class SuperActivity extends AppCompatActivity {

    private static int flag = 0;
    private UiLifecycleHelper uiHelper;
    private Session.StatusCallback callback;
    public MobileConfig mobileConfig;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        mobileConfig = JsonPhp.getInstance().getMobileConfig();


        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            Session session = new Session.Builder(getBaseContext()).setApplicationId(LocalConfig.getFacebookAppId()).build();
            Session.setActiveSession(session);
            callback = new Session.StatusCallback() {
                @Override
                public void call(Session session, SessionState state, Exception exception) {
                    onSessionStateChange(session, state, exception);
                }
            };

            uiHelper = new UiLifecycleHelper(this, callback);
            uiHelper.onCreate(savedInstanceState);
        }

        PreferenceHelper.initialize(getApplicationContext());

        try {
            if (flag == 0 && PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                String jsonPreferences = PreferenceHelper.get(PreferenceKeys.DataKeys.JSON_PHP_DATA);
                if (jsonPreferences != null && jsonPreferences.length() > 0) {
                    Gson gson = new Gson();
                    JsonPhp.setInstance(gson.fromJson(jsonPreferences, JsonPhp.class));
                    flag = 1;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        setActionBarColor(null);
        setStatusBarColor("#3177a8");
    }

   // private static final long DISCONNECT_TIMEOUT = 60000; // 5 min = 5 * 60 * 1000 ms

    //private static Handler disconnectHandler = new Handler();

    /*private static Runnable disconnectCallback = new Runnable() {

        @Override
        public void run() {
            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(),
                    URLFactory.getSendOneToOneMessageURL());
            vHelper.addNameValuePair(CometChatKeys.StatusKeys.STATUS, CometChatKeys.StatusKeys.AWAY);
            vHelper.sendAjax();
            PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, CometChatKeys.StatusKeys.AWAY);
        }
    };*/

    /*private static void resetDisconnectTimer() {
        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                && CometChatKeys.LoginKeys.USER_LOGGED_IN.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN))) {
            disconnectHandler.removeCallbacks(disconnectCallback);
            disconnectHandler.postDelayed(disconnectCallback, DISCONNECT_TIMEOUT);
        }
    }*/


    private void onSessionStateChange(Session session, SessionState state, Exception exception) {
        if (state.isOpened()) {
        } else if (state.isClosed()) {
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        // resetDisconnectTimer();
    }

    @Override
    protected void onResume() {
        super.onResume();

        if (null != mobileConfig && "1".equals(mobileConfig.getTwitterEnabled())) {
            Session session = Session.getActiveSession();
            if (session != null && (session.isOpened() || session.isClosed())) {
                onSessionStateChange(session, session.getState(), null);
            }
        }
        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            uiHelper.onResume();
            AppEventsLogger.activateApp(this);
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_CANCELED) {
            if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
                Session session = new Session.Builder(getBaseContext()).setApplicationId(LocalConfig.getFacebookAppId()).build();
                if (session.isOpened()) {
                    session.closeAndClearTokenInformation();
                    Session.setActiveSession(session);
                } else {
                    Session.setActiveSession(session);
                }
            }
        } else if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            uiHelper.onActivityResult(requestCode, resultCode, data);
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            uiHelper.onPause();
            AppEventsLogger.deactivateApp(this);
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            uiHelper.onDestroy();
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled())) {
            uiHelper.onSaveInstanceState(outState);
        }
    }

    /**
     * Sets the title and it's color. Also hides the icon. If a blank or null string is passed, it will set app name into the title.
     */
    public void setActionBarTitle(CharSequence title) {
        try {
            getSupportActionBar().setIcon(android.R.color.transparent);
            MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
            if (!TextUtils.isEmpty(title)) {
                if (null != theme) {
                    this.setTitle(Html.fromHtml("<font color='" + theme.getActionbarTextColor() + "'>" + title + "</font>"));
                } else {
                    this.setTitle(Html.fromHtml(title.toString()));
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void setActioBarSubtitle(CharSequence title) {
        try {
            getSupportActionBar().setIcon(android.R.color.transparent);
            MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
            if (!TextUtils.isEmpty(title)) {
                if (null != theme) {
                    getSupportActionBar().setSubtitle(Html.fromHtml("<small><font color='" + theme.getActionbarTextColor() + "'>" + title + "</font></small>"));

                } else {
                    getSupportActionBar().setSubtitle(Html.fromHtml(title.toString()));
                }
            } else {
                getSupportActionBar().setSubtitle(null);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Sets the icon hides the title
     */
    public void setActionBarImage() {
        try {
            File f = new File(LocalStorageFactory.getAppLogoStoragePath() + StaticMembers.APP_ICON_NAME_FOR_WHITE_LABEL);
            if (f.exists() && !TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
                // Only for white labelled apps.
                Drawable topBarImage = Drawable.createFromPath(f.getPath());
                ActionBar ab = getSupportActionBar();

                int height = topBarImage.getMinimumHeight();
                int width = topBarImage.getMinimumWidth();

                if (width == height) {
                /* Don't show the image if it is square */
                    setActionBarTitle(getString(R.string.app_name));
                } else if (width > height && (width - height) >= 20) {
                /* Hide title and show only image if the image is rectangular */
                    ab.setDisplayShowTitleEnabled(false);
                    ab.setDisplayShowTitleEnabled(false);
                    ab.setHomeButtonEnabled(true);
                    ab.setDefaultDisplayHomeAsUpEnabled(true);
                    ab.setDisplayShowHomeEnabled(true);
                    ab.setIcon(topBarImage);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     * Sets the action bar color. If a blank or null string is passed, it will be set from the theme/css.
     */
    public void setActionBarColor(String color) {
        try {
            ActionBar actionbar = getSupportActionBar();
            if (!TextUtils.isEmpty(color) && actionbar != null) {
                actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(color)));
            } else {
                MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
                Css css = JsonPhp.getInstance().getCss();
                if (null != theme && null != theme.getActionbarColor() && actionbar != null) {
                    actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(theme.getActionbarColor())));
                } else if (null != css && actionbar != null) {
                    actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(css.getTabTitleBackground())));
                } else if (actionbar != null) {
                    actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN)));
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    /**
     * Sets the status bar color. If a blank or null string is passed, it will be set from the theme/css.
     */
    public void setStatusBarColor(String color) {
        try {
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
                Window window = getWindow();
                window.addFlags(WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS);
                if (!TextUtils.isEmpty(color) && window != null) {
                        window.setStatusBarColor(Color.parseColor(color));
                } else {
                    MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
                    Css css = JsonPhp.getInstance().getCss();
                    if (null != theme && null != theme.getActionbarColor() && window != null) {
                        //actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(theme.getActionbarColor())));
                    } else if (null != css && window != null) {
                        //actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(css.getTabTitleBackground())));
                    } else if (window != null) {
                        //actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN)));
                    }
                }
                window.setStatusBarColor(Color.parseColor(color));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
