/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.CompoundButton;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.SuperActivity;

public class ChatSettingsActivity extends SuperActivity {

    private CompoundButton readTickSwitch, lastseenswitch;
    private String flag = "true";
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_notification_settings);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        setActionBarTitle(this.getTitle());
        TextView  readTickText, readTitle, lastSeenText, lastSeenSettingText;
        Mobile mobileLangs;
        View readlineview, lastSeenView;
        RelativeLayout relativeLayoutReadTickContainer, lastSeenRelative;

        Config config = JsonPhp.getInstance().getConfig();

        readTickSwitch = (CompoundButton) findViewById(R.id.switchReadTick);
        lastseenswitch = (CompoundButton) findViewById(R.id.switchLastSeen);


        readTickText = (TextView) findViewById(R.id.textViewReadTickToggle);
        readTitle = (TextView) findViewById(R.id.readReceiptText);
        lastSeenText = (TextView) findViewById(R.id.textViewLastSeenToggle);
        lastSeenSettingText = (TextView) findViewById(R.id.lastSeenSettingText);


        relativeLayoutReadTickContainer = (RelativeLayout) findViewById(R.id.relativeLayoutReadTickContainer);
        lastSeenRelative = (RelativeLayout) findViewById(R.id.lastSeenRelative);

        readlineview = (View) findViewById(R.id.lineViewReadTick);

        if (null != config && config.getUSECOMET().equals("1") && JsonPhp.getInstance().getConfig().getreceiptsEnabled() != null && JsonPhp.getInstance().getConfig().getreceiptsEnabled().equals("1")) {
            relativeLayoutReadTickContainer.setVisibility(View.VISIBLE);
            readlineview.setVisibility(View.VISIBLE);
        } else {
            relativeLayoutReadTickContainer.setVisibility(View.GONE);
            readlineview.setVisibility(View.GONE);
        }
        if (JsonPhp.getInstance().getConfig().getlastseenEnabled() != null && JsonPhp.getInstance().getConfig().getlastseenEnabled().equals("1")) {
            lastSeenRelative.setVisibility(View.VISIBLE);
        } else {
            lastSeenRelative.setVisibility(View.GONE);
        }

        /*notificationContainer = (RelativeLayout) findViewById(R.id.relativeLayoutNotificationContainer);
        soundContainer = (RelativeLayout) findViewById(R.id.relativeLayoutSoundContainer);
        vibrateContainer = (RelativeLayout) findViewById(R.id.relativeLayoutVibrateContainer);*/


        setupSwitches();
        mobileLangs = JsonPhp.getInstance().getLang().getMobile();
        if (null != mobileLangs) {
            if (null != mobileLangs.get167()) {
                readTickText.setText(mobileLangs.get167());
            }
            if (null != mobileLangs.get168()) {
                readTitle.setText(mobileLangs.get168());
            }
            if (null != mobileLangs.get169()) {
                setActionBarTitle(mobileLangs.get169());
            }
            if (null != mobileLangs.get170()) {
                lastSeenSettingText.setText(mobileLangs.get170());
            }
            if (null != mobileLangs.get171()) {
                lastSeenText.setText(mobileLangs.get171());
            }
        }

        readTickSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    PreferenceHelper.save(PreferenceKeys.UserKeys.READ_TICK, "1");
                } else {
                    PreferenceHelper.save(PreferenceKeys.UserKeys.READ_TICK, "0");
                }
            }
        });

        lastseenswitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {

            @Override
            public void onCheckedChanged(CompoundButton buttonView, final boolean isChecked) {
                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getLastSeenSettingRequestURL(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        if (isChecked) {
                            PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_SEEN_SETTING, "1");
                            flag = "true";
                        } else {
                            PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_SEEN_SETTING, "0");
                            flag = "false";
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isChecked) {
                            lastseenswitch.setChecked(false);
                        } else {
                            lastseenswitch.setChecked(true);
                        }
                    }
                });
                flag = String.valueOf(!isChecked);
                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.LASTSEENSETTINGFLAG, flag);
                vHelper.sendAjax();

            }
        });


    }

    @SuppressLint("NewApi")
    private void setupSwitches() {
        if (PreferenceHelper.get(PreferenceKeys.UserKeys.READ_TICK).equals("1")) {
            readTickSwitch.setChecked(true);
        } else {
            readTickSwitch.setChecked(false);
        }
        if (PreferenceHelper.get(PreferenceKeys.UserKeys.LAST_SEEN_SETTING).equals("1")) {
            lastseenswitch.setChecked(true);
        } else {
            lastseenswitch.setChecked(false);
        }
    }

    @Override
    public void finish() {
        super.finish();
        overridePendingTransition(0, 0);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            finish();
        }
        return super.onOptionsItemSelected(item);
    }
}
