/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.text.Html;
import android.text.TextUtils;

import com.google.gson.Gson;
import com.inscripts.R;
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
public class SuperActivity extends ActionBarActivity {

    private static int flag = 0;
    public MobileConfig mobileConfig;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        mobileConfig = JsonPhp.getInstance().getMobileConfig();

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
                Drawable d = getResources().getDrawable(R.drawable.cc_rounded_top_corners);

                if (null != theme && null != theme.getActionbarColor() && actionbar != null) {
                    //actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(theme.getActionbarColor())));
                    if (d != null) {
                        d.setColorFilter(Color.parseColor(theme.getActionbarColor()), PorterDuff.Mode.SRC_ATOP);
                        actionbar.setBackgroundDrawable(d);
                    }
                } else if (null != css && actionbar != null) {
                    // actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(css.getTabTitleBackground())));
                    if (d != null) {
                        d.setColorFilter(Color.parseColor(css.getTabTitleBackground()), PorterDuff.Mode.SRC_ATOP);
                        actionbar.setBackgroundDrawable(d);
                    }
                } else if (actionbar != null) {
                    //actionbar.setBackgroundDrawable(new ColorDrawable(Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN)));
                    if (d != null) {
                        d.setColorFilter(Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN), PorterDuff.Mode.SRC_ATOP);
                        actionbar.setBackgroundDrawable(d);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
