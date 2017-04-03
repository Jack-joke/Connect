/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.v7.widget.SwitchCompat;
import android.view.View;
import android.widget.CompoundButton;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SuperActivity;

public class ChatSettingsActivity extends SuperActivity {

    private SwitchCompat soundSwitch, vibrateSwitch, readTickSwitch, lastseenswitch;
    private SwitchCompat notificationSwitch;
    private String flag = "true";
    private boolean isChatSetting = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_notification_settings);

        setActionBarTitle(this.getTitle());
        TextView notificationTitle, soundTitle, vibrateTitle, readTickText, readTitle, lastSeenText, lastSeenSettingText,notificationText;
        Mobile mobileLangs;
        View readlineview,lastSeenView;
        RelativeLayout relativeLayoutReadTickContainer, lastSeenRelative;
        RelativeLayout chatSettingContainer,notificationContainer;

        Config config = JsonPhp.getInstance().getConfig();

        notificationSwitch = (SwitchCompat) findViewById(R.id.switchNotification);
        soundSwitch = (SwitchCompat) findViewById(R.id.switchNotificationSound);
        vibrateSwitch = (SwitchCompat) findViewById(R.id.switchNotificationVibrate);
        readTickSwitch = (SwitchCompat) findViewById(R.id.switchReadTick);
        lastseenswitch = (SwitchCompat) findViewById(R.id.switchLastSeen);
        notificationTitle = (TextView) findViewById(R.id.ShowNotificationText);
        soundTitle = (TextView) findViewById(R.id.textViewNotificaionSound);
        vibrateTitle = (TextView) findViewById(R.id.textViewNotificationVibrate);
        readTickText = (TextView) findViewById(R.id.textViewReadTickToggle);
        readTitle = (TextView) findViewById(R.id.readReceiptText);
        lastSeenText = (TextView) findViewById(R.id.textViewLastSeenToggle);
        lastSeenSettingText = (TextView) findViewById(R.id.lastSeenSettingText);
        notificationText = (TextView) findViewById(R.id.textViewNotificationToggle);
        chatSettingContainer = (RelativeLayout) findViewById(R.id.chatSettingContainer);
        notificationContainer = (RelativeLayout) findViewById(R.id.relativeLayoutNotificationContainer);
        relativeLayoutReadTickContainer = (RelativeLayout) findViewById(R.id.relativeLayoutReadTickContainer);
        lastSeenRelative = (RelativeLayout) findViewById(R.id.lastSeenRelative);

        readlineview = (View) findViewById(R.id.lineViewReadTick);
        isChatSetting = getIntent().getBooleanExtra("isChatSetting",false);

        if(isChatSetting){
            chatSettingContainer.setVisibility(View.VISIBLE);
            notificationContainer.setVisibility(View.GONE);
            if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get169()) {
                setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get169());
            }
        }else{
            chatSettingContainer.setVisibility(View.GONE);
            notificationContainer.setVisibility(View.VISIBLE);
            if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get96()) {
                setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get96());
            }
        }





        if (null != config && config.getUSECOMET().equals("1") && JsonPhp.getInstance().getConfig().getreceiptsEnabled() != null && JsonPhp.getInstance().getConfig().getreceiptsEnabled().equals("1")) {
            relativeLayoutReadTickContainer.setVisibility(View.VISIBLE);
            readlineview.setVisibility(View.VISIBLE);
        }else{
            relativeLayoutReadTickContainer.setVisibility(View.GONE);
            readlineview.setVisibility(View.GONE);
        }

        if (JsonPhp.getInstance().getConfig().getlastseenEnabled() != null && JsonPhp.getInstance().getConfig().getlastseenEnabled().equals("1")){
            lastSeenRelative.setVisibility(View.VISIBLE);
           // lastSeenView.setVisibility(View.VISIBLE);
        }else{
            lastSeenRelative.setVisibility(View.GONE);
          //  lastSeenView.setVisibility(View.GONE);
        }

        /*notificationContainer = (RelativeLayout) findViewById(R.id.relativeLayoutNotificationContainer);
        soundContainer = (RelativeLayout) findViewById(R.id.relativeLayoutSoundContainer);
        vibrateContainer = (RelativeLayout) findViewById(R.id.relativeLayoutVibrateContainer);*/


        setupSwitches();
        mobileLangs = JsonPhp.getInstance().getLang().getMobile();
        if (null != mobileLangs) {
            if (null != mobileLangs.get96()) {
                notificationTitle.setText(mobileLangs.get96());
            }
            if (null != mobileLangs.get97()) {
                notificationText.setText(mobileLangs.get97());
            }
            if (null != mobileLangs.get98()) {
                soundTitle.setText(mobileLangs.get98());
            }
            if (null != mobileLangs.get99()) {
                vibrateTitle.setText(mobileLangs.get99());
            }
            if (null != mobileLangs.get167()) {
                //readTickText.setText(mobileLangs.get167());
                readTickText.setText("By enabling read reciepts you will see the time and date your messages are read.");
            }
            if (null != mobileLangs.get168()) {
                readTitle.setText(mobileLangs.get168());
            }
           /* if (null != mobileLangs.get169()) {
                setActionBarTitle(mobileLangs.get169());
            }*/
            if (null != mobileLangs.get170()) {
                lastSeenSettingText.setText(mobileLangs.get170());

            }
            if (null != mobileLangs.get171()) {
                //lastSeenText.setText(mobileLangs.get171());
                lastSeenText.setText("By enabling last seen, the time and date you were last online will be displayed to others.");
            }

        }

        readTickSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    readTickSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    readTickSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.READ_TICK, "1");
                } else {
                    readTickSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                    readTickSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.READ_TICK, "0");
                }
            }
        });


        lastseenswitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {

            @Override
            public void onCheckedChanged(CompoundButton buttonView, final boolean isChecked) {

                Logger.error("Last seen changed listner isChecked = "+isChecked);
                if(isChecked){
                    lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                }else{
                    lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

                    lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                }



                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getLastSeenSettingRequestURL(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        Logger.error("Success responce called"+response);

                        if (isChecked) {
                            lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                            lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                            PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_SEEN_SETTING, "1");
                            flag = "true";
                        } else {
                            lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                            lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                            PreferenceHelper.save(PreferenceKeys.UserKeys.LAST_SEEN_SETTING, "0");
                            flag = "false";
                        }
                    }
                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        Logger.error("Failed responce called"+response);
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

        notificationSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    notificationSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    notificationSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_ON, "1");
                    activiateSwitches(true);
                } else {
                    notificationSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                    notificationSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_ON, "0");
                    activiateSwitches(false);
                }
            }
        });

        soundSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    soundSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    soundSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_SOUND, "1");
                } else {
                    soundSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                    soundSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_SOUND, "0");
                }
            }
        });

        vibrateSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    vibrateSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    vibrateSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE, "1");
                } else {
                    vibrateSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                    vibrateSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                    PreferenceHelper.save(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE, "0");
                }
            }
        });

        setThemeColor();
    }

    @SuppressLint("NewApi")
    private void setupSwitches() {
        if (PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_ON).equals("1")) {
            notificationSwitch.setChecked(true);
            activiateSwitches(true);
            soundSwitch.setChecked(PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_SOUND).equals("1"));
            vibrateSwitch.setChecked(PreferenceHelper.get(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE).equals("1"));
        } else {
            notificationSwitch.setChecked(false);
            activiateSwitches(false);
        }
        if (PreferenceHelper.get(PreferenceKeys.UserKeys.READ_TICK).equals("1")) {
            readTickSwitch.setChecked(true);
        } else {
            readTickSwitch.setChecked(false);
        }

        Logger.error("Last seen setting = "+PreferenceHelper.get(PreferenceKeys.UserKeys.LAST_SEEN_SETTING));
        if (PreferenceHelper.get(PreferenceKeys.UserKeys.LAST_SEEN_SETTING).equals("1")) {
            lastseenswitch.setChecked(true);
        } else {
            lastseenswitch.setChecked(false);
        }
    }

    private void activiateSwitches(boolean isActivated) {
        soundSwitch.setClickable(isActivated);
        soundSwitch.setEnabled(isActivated);
        soundSwitch.setChecked(isActivated);
        vibrateSwitch.setClickable(isActivated);
        vibrateSwitch.setEnabled(isActivated);
        vibrateSwitch.setChecked(isActivated);
    }

    private void setThemeColor(){
        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));


        if(soundSwitch.isChecked()){
            soundSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
            soundSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            soundSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            soundSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

        if(vibrateSwitch.isChecked()){
            vibrateSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);

            String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            p = p.substring(1,p.length());
            p = "#99"+p;
            vibrateSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            vibrateSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            vibrateSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

        if(notificationSwitch.isChecked()){
            notificationSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);

            String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            p = p.substring(1,p.length());
            p = "#99"+p;
            notificationSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            notificationSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            notificationSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

        if(readTickSwitch.isChecked()){
            readTickSwitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);

            String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            p = p.substring(1,p.length());
            p = "#99"+p;
            readTickSwitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            readTickSwitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            readTickSwitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

        if(lastseenswitch.isChecked()){
            lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);

            String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            p = p.substring(1,p.length());
            p = "#99"+p;
            lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            lastseenswitch.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            lastseenswitch.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

    }

    private String getTransparentPrimaryColor(String t){
        String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        p = t+(p.substring(1,p.length()));
        return p;
    }
}
