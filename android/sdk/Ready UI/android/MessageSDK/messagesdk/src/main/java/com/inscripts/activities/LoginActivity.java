/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.text.util.Linkify;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.StaticMembers.JsonPhpLangs;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.regex.Pattern;

public class LoginActivity extends SuperActivity {

    private static final String EDIT_TEXT_USERNAME = "ET_USERNAME";
    private static final String EDIT_TEXT_PASSWORD = "ET_PASSWORD";

    private static ProgressBar wheel;

    private int attempt;
    private EditText userNameField, passwordField;
    private CheckBox checkBox;
    private Button loginBtn;
    private ImageView backButton;
    private Lang lang;
    private Mobile mobileLangs;
    private LinearLayout loginContainer;
    private ImageView whiteLabbledApp;
    public static boolean showAnimation = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        attempt = 1;

      /*  WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();*/

        setContentView(R.layout.cc_activity_login);

        wheel = (ProgressBar) findViewById(R.id.progressWheel);
        loginContainer = (LinearLayout) findViewById(R.id.linearLayoutLoginContainer);

        PreferenceHelper.initialize(getApplicationContext());
        lang = JsonPhp.getInstance().getLang();
        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = lang.getMobile();
        }

        setupFields();
        autoFill(savedInstanceState);
        setupBackButton();

        if (null == SessionData.getInstance().getBaseData()) {
            SessionData.getInstance().setBaseData("");
        }

        loginBtn = (Button) findViewById(R.id.buttonLogin);
        if (lang != null) {
            loginBtn.setText(lang.getMobile().get12());
        }
        loginBtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                String username = userNameField.getText().toString().trim();
                String password = passwordField.getText().toString().trim();

                userNameField.setError(null);
                passwordField.setError(null);
                InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                inputMethodManager.hideSoftInputFromWindow(loginBtn.getApplicationWindowToken(), 0);

                chatLogin(username, password);
            }
        });

        applyThemeColor();
        if (LocalConfig.isWhiteLabelled() && showAnimation) {
            whiteLabbledApp = (ImageView) findViewById(R.id.imageViewWhiteLabbledCometchatLogo);
            whiteLabbledApp.setVisibility(View.VISIBLE);
        }
    }

    /**
     * Initializes and sets up all input fields
     */
    private void setupFields() {
        userNameField = (EditText) findViewById(R.id.editTextUsername);
        passwordField = (EditText) findViewById(R.id.editTextPassword);
        checkBox = (CheckBox) findViewById(R.id.checkBoxRemember);

        userNameField.setTextColor(Color.BLACK);
        passwordField.setTextColor(Color.BLACK);
        checkBox.setTextColor(Color.BLACK);

        if (null != lang) {
            userNameField.setHint(lang.getMobile().get10());
            passwordField.setHint(lang.getMobile().get11());
            checkBox.setText(lang.getMobile().get54());
        }
    }

    /**
     * Setup the guest login, social auth and register links if applicable
     */

    private void setupBackButton() {

        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);
        if (mobileConfig != null) {

            // New apps
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2 || !LocalConfig.isWhiteLabelled()) {
                backButton.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        onBackPressed();
                    }
                });
            } else {
                backButton.setVisibility(View.GONE);
            }
        } else if (LocalConfig.LOGIN_TYPE == 2 || LocalConfig.LOGIN_TYPE == 3 ||
                (LocalConfig.LOGIN_TYPE == 1 && !LocalConfig.isWhiteLabelled())) {

            // Old apps
            backButton.setOnClickListener(new OnClickListener() {

                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });
        } else {
            backButton.setVisibility(View.GONE);
        }
    }

    /**
     * Checks preferences for saved values and fills them if the user has asked
     * to remembered them.
     */

    private void autoFill(Bundle fields) {

        if (null != fields) {
            userNameField.setText(fields.getString(EDIT_TEXT_USERNAME));
            passwordField.setText(fields.getString(EDIT_TEXT_PASSWORD));
        }

        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL)
                && !PreferenceHelper.get(PreferenceKeys.LoginKeys.OLD_LOGIN_URL).equalsIgnoreCase(
                URLFactory.getLoginURL())) {
            PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_NAME);
            PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_PASSWORD);
        }

        if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.REMEMBER_ME)
                && CometChatKeys.LoginKeys.USER_REMEMBER.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.REMEMBER_ME))) {

            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGIN_NAME)) {
                userNameField.setText(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGIN_NAME));
            }

            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGIN_PASSWORD)) {
                passwordField.setText(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGIN_PASSWORD));
            }
            checkBox.setChecked(true);
        } else {
            PreferenceHelper.save(PreferenceKeys.LoginKeys.REMEMBER_ME, CometChatKeys.LoginKeys.DONT_REMEMBER_USER);
        }
    }

    /**
     * Validate all fields and attempt to login. Recursively calls itself after
     * appending "cometchat" or "chat" to the baseURL, if CometChat is not found
     * in the URL location.
     */
    @SuppressLint("HandlerLeak")
    private void chatLogin(final String username, final String password) {
        try {
            /* Validation */
            if (!TextUtils.isEmpty(username)) {
                if (!TextUtils.isEmpty(password)) {

                    startProgressWheel();
                    loginBtn.setEnabled(false);

                    VolleyAjaxCallbacks callbacks = new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                Logger.error("Login resp: " + response + "|");
                                JSONObject version = new JSONObject(response);
                                if (version.has("version")) {
                                    String versionCode = version.getString("version");
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, versionCode);
                                }
                                Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                                if (htmlPattern.matcher(response).matches()) {
                                    failCallback(response, false);
                                } else if (CommonUtils.isJSONValid(response)) {
                                    performAppLogin(response, username, password);
                                } else {
                                    showVersionErrorPopUp(LoginActivity.this);
                                    loginBtn.setEnabled(true);
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            loginBtn.setEnabled(true);
                            if (isNoInternet) {
                                Toast.makeText(
                                        LoginActivity.this,
                                        (null == lang) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : lang.getMobile()
                                                .get24(), Toast.LENGTH_SHORT).show();
                                stopProgressWheel();
                            } else {
                                if (attempt == 1) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_1);
                                    attempt = 2;
                                    chatLogin(username, password);
                                } else if (attempt == 2) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_2);
                                    attempt = 3;
                                    chatLogin(username, password);
                                } else if (attempt == 3) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_3);
                                    attempt = 4;
                                    chatLogin(username, password);
                                } else if (attempt == 4) {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_5);
                                    attempt = 5;
                                    chatLogin(username, password);
                                } else {
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                                    lang = JsonPhp.getInstance().getLang();
                                    attempt = 1;
                                    stopProgressWheel();
                                }
                            }
                        }
                    };

					/* Send login AJAX request to the server */
                    if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.OLD_LOGIN_URL)) {
                        PreferenceHelper.save(PreferenceKeys.LoginKeys.OLD_LOGIN_URL, URLFactory.getLoginURL());
                    }

                    VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getLoginURL(), callbacks);
                    vHelper.addNameValuePair(AjaxKeys.USERNAME, username);
                    vHelper.addNameValuePair(AjaxKeys.PASSWORD, password);
                    vHelper.sendAjax();
                } else {
                    lang = JsonPhp.getInstance().getLang();
                    if (null != lang) {
                        passwordField.setError(lang.getMobile().get46());
                    } else {
                        passwordField.setError(JsonPhpLangs.EMPTY_PASSWORD_ERROR_MESSAGE);
                    }
                    passwordField.requestFocus();
                }
            } else {
                lang = JsonPhp.getInstance().getLang();
                if (null != lang) {
                    userNameField.setError(lang.getMobile().get47());
                } else {
                    userNameField.setError(JsonPhpLangs.EMPTY_USERNAME_ERROR_MESSAGE);
                }
                userNameField.requestFocus();
            }
            /* Validation ends */
        } catch (Exception e) {
            Logger.error("Exception in LoginActivity: " + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    public void performAppLogin(String response, String username, String password) {
        try {
            String baseData = new JSONObject(response).getString(AjaxKeys.BASE_DATA);

            if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                /* Valid user */
                SessionData.getInstance().setBaseData(baseData);

				/*
                 * Check if different user is logged in
				 */
                if (PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                    if (!baseData.equalsIgnoreCase(PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA))) {
                        removeExistingData();
                    }
                }


                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);

                if (checkBox.isChecked()) {
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_NAME, username);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_PASSWORD, password);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.REMEMBER_ME, CometChatKeys.LoginKeys.USER_REMEMBER);
                } else {
                   /* PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.BASE_URL);
                    PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_NAME);
                    PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_PASSWORD);*/
                    PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.REMEMBER_ME);
                }

                PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);


                Intent intent = new Intent(LoginActivity.this, CometChatActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

                startActivity(intent);
                loginBtn.setEnabled(true);

                overridePendingTransition(R.anim.slide_in_up, 0);
                stopProgressWheel();
                finish();

            } else {
                /* Wrong credentials */
                stopProgressWheel();
                loginBtn.setEnabled(true);
                if (!TextUtils.isEmpty(username) && !TextUtils.isEmpty(password)) {
                    passwordField.setText("");
                    userNameField.requestFocus();
                    lang = JsonPhp.getInstance().getLang();
                    if (null != lang) {
                        userNameField.setError(lang.getMobile().get49());
                        passwordField.setError(lang.getMobile().get50());
                    } else {
                        userNameField.setError(JsonPhpLangs.WRONG_USERNAME_MESSAGE);
                        passwordField.setError(JsonPhpLangs.WRONG_PASSWORD_MESSAGE);
                    }
                } else {
                    new AlertDialog.Builder(this).setCancelable(true).setIcon(android.R.drawable.ic_dialog_info)
                            .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                }
                            }).setMessage("Please register on the website to be able to login from the app.").create()
                            .show();
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void applyThemeColor() {
        try {
            MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
            if (null != theme && null != theme.getLoginPlaceholder()
                    && null != theme.getLoginForegroundText() && null != theme.getLoginBackground() && null != theme.getLoginText() && null != theme.getLoginButton()) {

				/* Input fields start */
                int placeholderColor = Color.parseColor(theme.getLoginPlaceholder());
                userNameField.setHintTextColor(placeholderColor);
                passwordField.setHintTextColor(placeholderColor);

                int foregroundTextColor = Color.parseColor(theme.getLoginText());
                userNameField.setTextColor(foregroundTextColor);
                passwordField.setTextColor(foregroundTextColor);
                /* Input fields end */

                int foregroundColor = Color.parseColor(theme.getLoginButton());
                checkBox.setTextColor(foregroundColor);
                //loginBtn.getBackground().setColorFilter(foregroundColor, PorterDuff.Mode.SRC_ATOP);
                loginBtn.setBackgroundColor(foregroundColor);
                if (!TextUtils.isEmpty(theme.getLoginButtonText())) {
                    //loginBtn.setTextColor(foregroundColor);
                    loginBtn.setTextColor(Color.parseColor(theme.getLoginButtonText()));
                }

                loginContainer.getBackground().setColorFilter(Color.parseColor(theme.getLoginBackground()), PorterDuff.Mode.SRC_ATOP);
                //loginParentContainer.setBackgroundColor(Color.parseColor(theme.getLoginBackground()));
                checkBox.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));

                Drawable myIcon = getResources().getDrawable(R.drawable.cc_ic_custom_back_arrow);
                if (null != myIcon) {
                    myIcon.setColorFilter(foregroundColor, PorterDuff.Mode.SRC_ATOP);
                    backButton.setImageDrawable(myIcon);
                }

            } else if (null != theme.getLoginBackground() && null != theme.getLoginForeground() && null != theme.getLoginButtonPressed() && null != theme.getLoginForegroundText() && null != theme.getLoginPlaceholder()) {
                int placeholderColor = Color.parseColor(theme.getLoginPlaceholder());
                int loginforeground = Color.parseColor(theme.getLoginForeground());
                int button = Color.parseColor(theme.getLoginButtonPressed());

                userNameField.setHintTextColor(placeholderColor);
                passwordField.setHintTextColor(placeholderColor);
                userNameField.setTextColor(loginforeground);
                passwordField.setTextColor(loginforeground);
                checkBox.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
                loginBtn.setBackgroundColor(button);
                loginContainer.getBackground().setColorFilter(Color.parseColor(theme.getLoginBackground()), PorterDuff.Mode.SRC_ATOP);
                // loginParentContainer.setBackgroundColor(Color.parseColor(theme.getLoginBackground()));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void showVersionErrorPopUp(final Context context) {
        stopProgressWheel();

        ClickableSpan spanMessage = new ClickableSpan() {

            @Override
            public void onClick(View widget) {
                Intent browserIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(URLFactory.LEGACY_APP_LINK));
                browserIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                context.startActivity(browserIntent);
            }
        };

        SpannableString clickableMessage = new SpannableString(JsonPhpLangs.VERSION_UPGRADE_REQUIRED);
        clickableMessage.setSpan(spanMessage, 99, 109, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        Linkify.addLinks(clickableMessage, Linkify.WEB_URLS);

        TextView message = new TextView(context);
        message.setText(clickableMessage);
        message.setMovementMethod(LinkMovementMethod.getInstance());
        message.setPadding(20, 20, 20, 20);
        message.setTextSize(17);

        new AlertDialog.Builder(context).setCancelable(true).setIcon(android.R.drawable.ic_dialog_info)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int id) {
                    }
                }).setView(message).create().show();

    }

    private static void startProgressWheel() {
        wheel.setVisibility(View.VISIBLE);
    }

    private static void stopProgressWheel() {
        wheel.setVisibility(View.INVISIBLE);
    }

    /**
     * Clears all databaseEntries if a new user logs in.
     */
    public static void removeExistingData() {
        try {
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.BASE_DATA);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_ID);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_NAME);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_LINK);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_ON);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_SOUND);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE);
        } catch (Exception e) {
            Logger.error("Loginactivity.java removeExistingData(): Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putString(EDIT_TEXT_USERNAME, userNameField.getText().toString());
        outState.putString(EDIT_TEXT_PASSWORD, passwordField.getText().toString());
    }

    @Override
    public void finish() {
        super.finish();
        stopProgressWheel();
    }

}
