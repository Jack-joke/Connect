/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.LoginHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;


/**
 * Used only for stock app
 */
public class UrlInitializerActivity extends SuperActivity {

    private Lang lang;
    private String initialUrl, noInternetError;
    private EditText baseURLField;
    private ProgressBar wheel;

    private Button hiddenButton;

    private Mobile mobileLangs;
    private MobileTheme mobileTheme;
    private Toolbar toolbar;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.cc_activity_url_initializer);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);

        lang = JsonPhp.getInstance().getLang();
        if (null != lang) {
            mobileLangs = lang.getMobile();
            mobileTheme = JsonPhp.getInstance().getMobileTheme();
        }

        baseURLField = (EditText) findViewById(R.id.editTextURL);

        wheel = (ProgressBar) findViewById(R.id.progressWheel);

        hiddenButton = (Button) findViewById(R.id.buttonDemoLogin);

        if (null != mobileLangs) {
            if (null != mobileLangs.get24()) {
                noInternetError = mobileLangs.get24();
            }
        }

        if (!CommonUtils.isConnected()) {
            if (null != mobileLangs) {
                if (null != mobileLangs.get24()) {
                    Toast.makeText(getApplicationContext(), mobileLangs.get24(), Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                }
            } else {
                Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
            }
        }

        final boolean isLoggedIn = PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                && CometChatKeys.LoginKeys.USER_LOGGED_IN.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN));

        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
        }

        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH)) {
            PreferenceHelper.save(PreferenceKeys.DataKeys.JSON_RESPONSE_HASH, "");
        }

        hiddenButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                inputMethodManager.hideSoftInputFromWindow(hiddenButton.getApplicationWindowToken(), 0);


                initialUrl = baseURLField.getText().toString().trim();
                baseURLField.setError(null);

                if (!TextUtils.isEmpty(initialUrl)) {
                    wheel.setVisibility(View.VISIBLE);
                    if (!initialUrl.endsWith("/")) {
                        initialUrl += "/";
                    }

                    // Check if url contains http:// or https://
                    if (!(initialUrl.contains(URLFactory.PROTOCOL_PREFIX) || initialUrl
                            .contains(URLFactory.PROTOCOL_PREFIX_SECURE))) {
                        initialUrl = URLFactory.PROTOCOL_PREFIX + initialUrl;
                    }
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.INITIAL_URL, initialUrl);
                    hiddenButton.setEnabled(false);


                    PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, initialUrl);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);

                    PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                        @Override
                        public void successCallback() {
                            LoginHelper.checkLoginTypeAndStart(UrlInitializerActivity.this);
                            baseURLField.setEnabled(true);
                            dismissProgressWheel();
                        }

                        @Override
                        public void failCallback() {
                            baseURLField.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                            baseURLField.setEnabled(true);
                            hiddenButton.setEnabled(true);
                            dismissProgressWheel();
                        }
                    });

                } else {
                    // Invalid URL
                    if (null != lang) {
                        baseURLField.setError(lang.getMobile().get48());
                    } else {
                        baseURLField.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                    }
                    dismissProgressWheel();
                    baseURLField.requestFocus();
                    baseURLField.setEnabled(true);
                }
            }
        });


        if (null != mobileTheme && null != mobileTheme.getLoginButton() && null != mobileTheme.getLoginButtonText()) {

            int btnColor = Color.parseColor(mobileTheme.getLoginButton());
            int btnTextColor = Color.parseColor(mobileTheme.getLoginButtonText());

            hiddenButton.setBackgroundColor(btnColor);
            hiddenButton.setTextColor(btnTextColor);


            baseURLField.setTextColor(Color.parseColor(mobileTheme.getLoginText()));
            baseURLField.setHintTextColor(Color.parseColor(mobileTheme.getLoginTextHint()));
        }


    }


    @Override
    protected void onStop() {
        hiddenButton.setEnabled(true);
        super.onStop();
    }

    @Override
    protected void onResume() {
        super.onResume();
        if (!CommonUtils.isConnected()) {
            if (null != mobileLangs) {
                if (null != mobileLangs.get24()) {
                    Toast.makeText(getApplicationContext(), mobileLangs.get24(), Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                }
            } else {
                Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
            }
        }
    }

    private void dismissProgressWheel() {
        wheel.setVisibility(View.INVISIBLE);
    }

}
