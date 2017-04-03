/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.os.Bundle;
import android.text.Html;
import android.text.TextUtils;
import android.view.View;
import android.view.WindowManager;
import android.view.animation.AccelerateInterpolator;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;
import android.view.animation.Animation.AnimationListener;
import android.view.animation.TranslateAnimation;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.LoginHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONObject;

import java.util.regex.Pattern;


/**
 * Used only for stock app
 */
public class UrlInitializerActivity extends SuperActivity {

    private Lang lang;
    private String initialUrl, noInternetError;
    private EditText baseURLField;
    private ProgressWheel wheel;

    private int buttonClickStatus = 1; //1 for checkurl and 2 for try a demo
    private Button nextButton, hiddenButton;
    private Button demoButton;
    private static String guestPassword = "CC^CONTROL_GUEST";
    private Mobile mobileLangs;
    private MobileTheme mobileTheme;
    private boolean showAnimation = true, noInternet = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_url_initializer);

        lang = JsonPhp.getInstance().getLang();
        if (null != lang) {
            mobileLangs = lang.getMobile();
            mobileTheme = JsonPhp.getInstance().getMobileTheme();
        }

        baseURLField = (EditText) findViewById(R.id.editTextURL);

        wheel = (ProgressWheel) findViewById(R.id.progressWheel);

        nextButton = (Button) findViewById(R.id.buttonCheckURL);
        hiddenButton = (Button) findViewById(R.id.buttonDemoLogin);
        demoButton = (Button) findViewById(R.id.textViewTryDemo);

        if (null != mobileLangs) {
            if (null != mobileLangs.get152()) {
                nextButton.setText(mobileLangs.get152());
            }
            if (null != mobileLangs.get151()) {
                demoButton.setText(mobileLangs.get151());
            }
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

        hiddenButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                inputMethodManager.hideSoftInputFromWindow(hiddenButton.getApplicationWindowToken(), 0);

                if (buttonClickStatus == 1) {
                    initialUrl = baseURLField.getText().toString().trim();
                    baseURLField.setError(null);

                    if (!TextUtils.isEmpty(initialUrl)) {
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
                        // Check for CoD
                        boolean callCheckDomain = false;
                        if (LocalConfig.isWhiteLabelled()) {
                            if (!LocalConfig.getIsCOD().isEmpty() && LocalConfig.getIsCOD().equals("1")) {
                                callCheckDomain = true;
                            }
                        } else {
                            callCheckDomain = true;
                        }
                        if (callCheckDomain) {
                            LoginHelper.checkDomain(UrlInitializerActivity.this, initialUrl, new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(final String response) {

                                    // response contains the URL to be used for json.php
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, response);
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);

                                    if (SessionData.getInstance().isCometOnDemand()) {

                                        String sendurl = "http://" + PreferenceHelper.get(PreferenceKeys.DataKeys.COD_ID) + URLFactory.getCodLoginUrl();
                                        VolleyHelper helper = new VolleyHelper(getApplicationContext(), sendurl, new VolleyAjaxCallbacks() {
                                            @Override
                                            public void successCallback(String response) {
                                                try {
                                                    JSONObject json = new JSONObject(response);
                                                    if (json.has("failed")) {
                                                        JSONObject jsonObject = json.getJSONObject("failed");
                                                        String message = "Error Message";
                                                        if (jsonObject.has("message")) {
                                                            message = jsonObject.getString("message");
                                                        }

                                                        AlertDialog.Builder alertDialog2 = new AlertDialog.Builder(
                                                                UrlInitializerActivity.this);
                                                        alertDialog2.setTitle("Error");
                                                        alertDialog2.setMessage(message);
                                                        alertDialog2.setCancelable(false);
                                                        alertDialog2.setIcon(android.R.drawable.ic_dialog_alert);
                                                        alertDialog2.setNegativeButton("OK",
                                                                new DialogInterface.OnClickListener() {
                                                                    public void onClick(DialogInterface dialog, int which) {
                                                                        dialog.cancel();
                                                                    }
                                                                });
                                                        alertDialog2.show();
                                                        baseURLField.setEnabled(true);
                                                        dismissProgressWheel();

                                                    } else {
                                                        JSONObject jsonObject = json.getJSONObject("success");
                                                        String url = null;
                                                        int ccAuth = 0, guest = 0;

                                                        if (jsonObject.has("redirect_url")) {
                                                            url = "http://" + jsonObject.getString("redirect_url");
                                                        }
                                                        if (jsonObject.has("use_ccauth")) {
                                                            ccAuth = jsonObject.getInt("use_ccauth");
                                                        }
                                                        if (jsonObject.has("guest_mode")) {
                                                            guest = jsonObject.getInt("guest_mode");
                                                        }
                                                        if (jsonObject.has("version")) {
                                                            PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, jsonObject.getString("version"));
                                                        }

                                                        final String Url = url;
                                                        final int CCAuth = ccAuth;
                                                        final int Guest = guest;
                                                        PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                                                            @Override
                                                            public void successCallback() {
                                                                Intent i;
                                                                if (CCAuth == 1) {
                                                                    i = new Intent(getApplicationContext(), SocialAuthActivity.class);
                                                                } else if(Guest == 1) {
                                                                    i = new Intent(getApplicationContext(), CoDLoginTypesActivity.class);
                                                                    i.putExtra("Url", Url);
                                                                } else {
                                                                    i = new Intent(getApplicationContext(), CoDLoginActivity.class);
                                                                    i.putExtra("Url", Url);
                                                                }
                                                                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                                getApplicationContext().startActivity(i);
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
                                                    }
                                                } catch (Exception e) {
                                                    e.printStackTrace();
                                                }
                                            }

                                            @Override
                                            public void failCallback(String response, boolean isNoInternet) {
                                                hiddenButton.setEnabled(true);
                                                Logger.error("No Internet");
                                            }
                                        });
                                        if (LocalConfig.isWhiteLabelled()) {
                                            helper.addNameValuePair(CometChatKeys.AjaxKeys.PLATFORM, "whitelabeledapp");
                                        } else {
                                            helper.addNameValuePair(CometChatKeys.AjaxKeys.PLATFORM, "brandedapp");
                                        }
                                        helper.sendAjax();

                                    } else {

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
                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (!isNoInternet) {
                                        if (response.contains(StaticMembers.DOMAIN_ERROR)) {
                                            Toast.makeText(UrlInitializerActivity.this, StaticMembers.DOMAIN_ERROR, Toast.LENGTH_LONG).show();
                                        } else {
                                            baseURLField.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                                        }
                                        baseURLField.setEnabled(true);
                                        hiddenButton.setEnabled(true);
                                        dismissProgressWheel();
                                    } else {
                                        if (noInternetError != null && !noInternetError.isEmpty())
                                            Toast.makeText(UrlInitializerActivity.this, noInternetError, Toast.LENGTH_LONG).show();
                                        else
                                            Toast.makeText(UrlInitializerActivity.this, "No Internet Connection", Toast.LENGTH_LONG).show();
                                        dismissProgressWheel();
                                        baseURLField.setEnabled(true);
                                        hiddenButton.setEnabled(true);
                                        noInternet = true;
                                    }
                                }

                            });
                            if (!noInternet) {
                                wheel.setVisibility(View.VISIBLE);
                                wheel.spin();
                                baseURLField.setEnabled(false);
                            }
                            noInternet = false;
                        } else {
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
                        }
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
                } else {
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, LocalConfig.DEMO_SITE_URL);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO, "1");


                    final String name = baseURLField.getText().toString().trim();
                    if (TextUtils.isEmpty(name)) {
                        if (null != mobileLangs && null != mobileLangs.get149()) {
                            baseURLField.setError(mobileLangs.get149());
                        } else {
                            baseURLField.setError("Please enter guest name");
                        }
                        dismissProgressWheel();
                    } else {
                        wheel.setVisibility(View.VISIBLE);
                        wheel.spin();
                        inputMethodManager.hideSoftInputFromWindow(hiddenButton.getApplicationWindowToken(), 0);
                        hiddenButton.setEnabled(false);
                        VolleyHelper volleyHelper = new VolleyHelper(getApplicationContext(), URLFactory.getLoginURL(), new VolleyAjaxCallbacks() {
                            @Override
                            public void successCallback(String response) {
                                Logger.error("Guest login success Response=" + response);
                                Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                                try {
                                    JSONObject version = new JSONObject(response);
                                    if (version.has("version")) {
                                        String versionCode = version.getString("version");
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, versionCode);
                                    }
                                }catch (Exception e){
                                    e.printStackTrace();
                                }

                                if (htmlPattern.matcher(response).matches()) {
                                    failCallback(response, false);
                                } else if (CommonUtils.isJSONValid(response)) {
                                    try {
                                        String baseData = new JSONObject(response).getString(CometChatKeys.AjaxKeys.BASE_DATA);
                                        if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                                            SessionData.getInstance().setBaseData(baseData);

                                            LoginActivity.removeExistingData();

                                            PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                                            PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_NAME, name);
                                            PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_PASSWORD, guestPassword);
                                            PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                                            if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
                                                PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                                                    @Override
                                                    public void successCallback() {
                                                        Intent intent = new Intent(UrlInitializerActivity.this, CometChatActivity.class);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                        startActivity(intent);
                                                        finish();
                                                        dismissProgressWheel();
                                                    }

                                                    @Override
                                                    public void failCallback() {
                                                        Logger.error("JSONPhp not found");
                                                        Intent intent = new Intent(UrlInitializerActivity.this, CometChatActivity.class);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                        startActivity(intent);
                                                        hiddenButton.setEnabled(true);
                                                        finish();
                                                        dismissProgressWheel();
                                                    }
                                                });
                                            } else {
                                                Logger.error("Starting chat");
                                                Intent intent = new Intent(UrlInitializerActivity.this, CometChatActivity.class);
                                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                startActivity(intent);
                                                hiddenButton.setEnabled(true);
                                                finish();
                                                dismissProgressWheel();
                                            }
                                        } else {
                                            Toast.makeText(getApplicationContext(), "Unable to login", Toast.LENGTH_SHORT).show();
                                            dismissProgressWheel();
                                        }

                                    } catch (Exception e) {
                                        e.printStackTrace();
                                        dismissProgressWheel();
                                    }

                                } else {
                                    hiddenButton.setEnabled(true);
                                    LoginActivity.showVersionErrorPopUp(UrlInitializerActivity.this);
                                    dismissProgressWheel();
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
                                hiddenButton.setEnabled(true);
                                Logger.error("Guest login fail Response=" + response);
                                dismissProgressWheel();
                            }
                        });

                        SessionData.getInstance().setBaseData("");
                        PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
                        volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, name);
                        volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, guestPassword);
                        volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.GUEST_LOGIN, "1");
                        volleyHelper.sendAjax();
                    }
                }
            }
        });

        nextButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                buttonClickStatus = 1;
                try {
                    demoButton.setAnimation(null);
                    demoButton.setVisibility(View.INVISIBLE);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                animate();
            }
        });

        demoButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                buttonClickStatus = 2;
                try {
                    nextButton.setAnimation(null);
                    nextButton.setVisibility(View.INVISIBLE);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                animate();
            }
        });

        if (null != mobileTheme && null != mobileTheme.getLoginButton() && null != mobileTheme.getLoginButtonText()) {

            int btnColor = Color.parseColor(mobileTheme.getLoginButton());
            int btnTextColor = Color.parseColor(mobileTheme.getLoginButtonText());

            nextButton.setBackgroundColor(btnColor);
            nextButton.setTextColor(btnTextColor);

            demoButton.getBackground().setColorFilter(new
                    LightingColorFilter(Color.WHITE, btnColor));
            demoButton.setTextColor(btnColor);

            //hiddenButton.setBackgroundColor(btnColor);
            hiddenButton.setTextColor(btnTextColor);

            wheel.setBarColor(btnColor);

            baseURLField.setTextColor(Color.parseColor(mobileTheme.getLoginText()));
            baseURLField.setHintTextColor(Color.parseColor(mobileTheme.getLoginTextHint()));
        }
    }

    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if (showAnimation && hasFocus) {
            showAnimation = false;
            Animation fade_in = new AlphaAnimation(0, 1);
            fade_in.setInterpolator(new AccelerateInterpolator());
            fade_in.setFillAfter(true);
            fade_in.setDuration(1200);
            demoButton.startAnimation(fade_in);
            nextButton.startAnimation(fade_in);
        }
    }

    private void animate() {
        hiddenButton.setVisibility(View.INVISIBLE);
        int translationDistance;
        if (buttonClickStatus == 1) {
            translationDistance = nextButton.getTop() - hiddenButton.getTop();
        } else {
            translationDistance = demoButton.getTop() - hiddenButton.getTop();
        }
        TranslateAnimation mAnimation = new TranslateAnimation(0, 0, 0, -translationDistance);
        mAnimation.setDuration(400);
        mAnimation.setFillAfter(true);
        mAnimation.setAnimationListener(new AnimationListener() {

            @Override
            public void onAnimationStart(Animation animation) {
            }

            @Override
            public void onAnimationRepeat(Animation animation) {
            }

            @Override
            public void onAnimationEnd(Animation animation) {
                baseURLField.setVisibility(View.VISIBLE);
                if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.INITIAL_URL)) {
                    if (buttonClickStatus == 1) {
                        baseURLField.setText(PreferenceHelper.get(PreferenceKeys.LoginKeys.INITIAL_URL));
                    }
                } else {
                    baseURLField.setText("");
                }
                baseURLField.setError(null);
                baseURLField.setEnabled(true);
                hiddenButton.setVisibility(View.VISIBLE);
                try {
                    nextButton.setAnimation(null);
                    demoButton.setAnimation(null);
                    demoButton.setVisibility(View.INVISIBLE);
                    nextButton.setVisibility(View.INVISIBLE);
                } catch (Exception e) {
                    e.printStackTrace();
                }
                if (buttonClickStatus == 1) {
                    if (null != mobileLangs && null != mobileLangs.get153()) {
                        hiddenButton.setText(mobileLangs.get153());
                    } else {
                        hiddenButton.setText("Next");
                    }
                    if (null != JsonPhp.getInstance().getNewMobile() && null != JsonPhp.getInstance().getNewMobile().getLogin().getUrlHint()) {
                        baseURLField.setHint(JsonPhp.getInstance().getNewMobile().getLogin().getUrlHint());
                    } else {
                        baseURLField.setHint("http://www.yourwebsite.com");
                    }
                } else {
                    if (null != JsonPhp.getInstance().getNewMobile() && null != JsonPhp.getInstance().getNewMobile().getLogin().getLoginButtonText()) {
                        hiddenButton.setText(JsonPhp.getInstance().getNewMobile().getLogin().getLoginButtonText());
                    } else {
                        hiddenButton.setText("Login");
                    }
                    baseURLField.setText("");
                    if (null != mobileLangs && null != mobileLangs.get148()) {
                        baseURLField.setHint(mobileLangs.get148());
                    } else {
                        baseURLField.setHint(Html.fromHtml("Guest-<i>Your Name</i>"));
                    }
                }
            }
        });
        if (buttonClickStatus == 1) {
            nextButton.startAnimation(mAnimation);
        } else {
            demoButton.startAnimation(mAnimation);
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
        wheel.setProgress(0f);
        wheel.stopSpinning();
        wheel.setVisibility(View.INVISIBLE);
    }

    @Override
    public void onBackPressed() {
        if (hiddenButton.getVisibility() == View.VISIBLE) {
            nextButton.setVisibility(View.VISIBLE);
            demoButton.setVisibility(View.VISIBLE);
            baseURLField.setVisibility(View.INVISIBLE);
            hiddenButton.setVisibility(View.INVISIBLE);
            if (null != wheel && wheel.isSpinning()) {
                dismissProgressWheel();
            }
        } else {
            super.onBackPressed();
        }
    }
}
