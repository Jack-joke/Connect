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
import android.content.res.ColorStateList;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.ColorInt;
import android.support.design.widget.TextInputLayout;
import android.support.v7.widget.SwitchCompat;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.text.style.UnderlineSpan;
import android.text.util.Linkify;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.animation.AccelerateInterpolator;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;
import android.view.animation.TranslateAnimation;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Announcement;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.models.Status;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.plugins.SocialAuth;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.StaticMembers.JsonPhpLangs;
import com.inscripts.utils.SuperActivity;
import com.orm.SugarDb;
import com.orm.SugarRecord;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONObject;

import java.lang.reflect.Field;
import java.util.regex.Pattern;

public class LoginActivity extends SuperActivity {

    private static final String EDIT_TEXT_USERNAME = "ET_USERNAME";
    private static final String EDIT_TEXT_PASSWORD = "ET_PASSWORD";
    private static final String TAG = LoginActivity.class.getSimpleName();

    private static ProgressWheel wheel;

    private int attempt;
    private EditText userNameField, passwordField;
    private CheckBox checkBox;
    private TextView tvTryDemo,tvRemberMe,tvDontHaveAccount ,tvDontHaveAccount1, tvRegister , tvTryDemoBoth , tvRegisterBoth ,tvSocialLogin;
    private Button loginBtn, bottomRegisterBtn, bottomGuestLoginBtn, bottomSocialLoginBtn;
    private ImageView backButton;
    private Lang lang;
    private Mobile mobileLangs;
    private LinearLayout loginContainer;
    private ScrollView loginParentContainer;
    private ImageView whiteLabbledApp;
    public static boolean showAnimation = true;
    private ImageView originalLogo;
    private SwitchCompat switchRemberMe;
    private TextInputLayout tllUserNamel;
    private TextInputLayout tllPassword;
    private RelativeLayout containerSingle, containerBoth ;
    private View socialDivider, registerDivider;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        attempt = 1;

      /*  WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();*/

        if(JsonPhp.getInstance().getMobileTheme() != null && JsonPhp.getInstance().getMobileTheme().getPrimaryColor()!= null){
            PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,JsonPhp.getInstance().getMobileTheme().getPrimaryColor());
            PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,JsonPhp.getInstance().getMobileTheme().getPrimarkDaryColor());
        }else{
            PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,JsonPhp.getInstance().getMobileTheme().getActionbarColor());
            PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,JsonPhp.getInstance().getMobileTheme().getActionbarColor());
        }

        setContentView(R.layout.activity_login);

        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        loginParentContainer = (ScrollView) findViewById(R.id.scrollviewParentLoginContainer);
        originalLogo = (ImageView) findViewById(R.id.imageViewCometchatLogo);
        tvTryDemo = (TextView) findViewById(R.id.textViewTryDemo);
        switchRemberMe = (SwitchCompat) findViewById(R.id.switchRememberMe);
        tllUserNamel = (TextInputLayout) findViewById(R.id.input_layout_user_name);
        tllPassword = (TextInputLayout) findViewById(R.id.input_layout_password);
        tvRemberMe = (TextView) findViewById(R.id.tv_rember_me_label);
        tvDontHaveAccount = (TextView) findViewById(R.id.txtDonthaveAccount);
        tvDontHaveAccount1 = (TextView) findViewById(R.id.txtDonthaveAccount1);
        containerSingle = (RelativeLayout) findViewById(R.id.container_single);
        containerBoth = (RelativeLayout) findViewById(R.id.container_both);


        PreferenceHelper.initialize(getApplicationContext());
        lang = JsonPhp.getInstance().getLang();
        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = lang.getMobile();
        }

        setupFields();
        autoFill(savedInstanceState);
        setupBackButton();
        //setupBottomLinks();

        if (null == SessionData.getInstance().getBaseData()) {
            SessionData.getInstance().setBaseData("");
        }

        loginBtn = (Button) findViewById(R.id.buttonLogin);
        if (lang != null) {
            loginBtn.setText(lang.getMobile().get12());
        }
        loginBtn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                String username = userNameField.getText().toString().trim();
                String password = passwordField.getText().toString().trim();

                tllUserNamel.setError(null);
                tllPassword.setError(null);
                InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                inputMethodManager.hideSoftInputFromWindow(loginBtn.getApplicationWindowToken(), 0);

                chatLogin(username, password);
            }
        });

        //applyThemeColor();

        setThemeColor();

        switchRemberMe.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if (b) {
                    switchRemberMe.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);
                    switchRemberMe.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);

                } else {
                    switchRemberMe.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);
                    switchRemberMe.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
                }
            }
        });

//        if (LocalConfig.isWhiteLabelled() && showAnimation) {
//            whiteLabbledApp = (ImageView) findViewById(R.id.imageViewWhiteLabbledCometchatLogo);
//            whiteLabbledApp.setVisibility(View.VISIBLE);
//        }
    }



    private void setThemeColor(){

        if (!LocalConfig.isWhiteLabelled()) {
            originalLogo.setColorFilter(Color.BLACK, PorterDuff.Mode.SRC_ATOP);
        }

        loginBtn.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        setInputTextLayoutColor(userNameField,Color.parseColor("#a2a2a5"));
        setInputTextLayoutColor(passwordField,Color.parseColor("#a2a2a5"));

        tvTryDemo.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        tvRegister.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        tvRegisterBoth.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        tvTryDemoBoth.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));

        if(switchRemberMe.isChecked()){
            switchRemberMe.getThumbDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.MULTIPLY);

            String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            p = p.substring(1,p.length());
            p = "#99"+p;
            switchRemberMe.getTrackDrawable().setColorFilter(Color.parseColor(getTransparentPrimaryColor("#99")), PorterDuff.Mode.MULTIPLY);
        }else{
            switchRemberMe.getThumbDrawable().setColorFilter(Color.parseColor("#E0E0E0"), PorterDuff.Mode.MULTIPLY);

            switchRemberMe.getTrackDrawable().setColorFilter(Color.parseColor("#BDBDBD"), PorterDuff.Mode.MULTIPLY);
        }

        wheel.setBarColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
    }

    public static void setInputTextLayoutColor(EditText editText, @ColorInt int color) {
        TextInputLayout til = (TextInputLayout) editText.getParent();
        try {
            Field fDefaultTextColor = TextInputLayout.class.getDeclaredField("mDefaultTextColor");
            fDefaultTextColor.setAccessible(true);
            fDefaultTextColor.set(til, new ColorStateList(new int[][]{{0}}, new int[]{color}));

            Field fFocusedTextColor = TextInputLayout.class.getDeclaredField("mFocusedTextColor");
            fFocusedTextColor.setAccessible(true);
            fFocusedTextColor.set(til, new ColorStateList(new int[][]{{0}}, new int[]{color}));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private String getTransparentPrimaryColor(String t){
        String p = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        p = t+(p.substring(1,p.length()));
        return p;
    }

    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if (LocalConfig.isWhiteLabelled() && hasFocus && showAnimation) {
            whiteLabbledApp = (ImageView) findViewById(R.id.imageViewWhiteLabbledCometchatLogo);
            whiteLabbledApp.setVisibility(View.VISIBLE);
            originalLogo.setVisibility(View.INVISIBLE);
            showAnimation = false;
            ImageView originalLogo = (ImageView) findViewById(R.id.imageViewCometchatLogo);
            loginContainer = (LinearLayout) findViewById(R.id.linearLayoutLoginContainer);

            loginContainer.setVisibility(View.INVISIBLE);


            int distance = whiteLabbledApp.getTop() - originalLogo.getTop();
            TranslateAnimation mAnimation = new TranslateAnimation(0, 0, 0, -distance);
            mAnimation.setDuration(1200);
            mAnimation.setFillAfter(true);
            mAnimation.setAnimationListener(new Animation.AnimationListener() {
                @Override
                public void onAnimationStart(Animation animation) {

                }

                @Override
                public void onAnimationEnd(Animation animation) {
                    loginContainer.bringToFront();
                    Animation fade_in = new AlphaAnimation(0, 1);
                    fade_in.setInterpolator(new AccelerateInterpolator());
                    fade_in.setFillAfter(true);
                    fade_in.setDuration(600);
                    loginContainer.startAnimation(fade_in);

                  /*  Animation fade_out = new AlphaAnimation(1, 0);
                    fade_out.setInterpolator(new AccelerateInterpolator());
                    fade_out.setFillAfter(true);
                    fade_out.setDuration(300);

                    whiteLabbledApp.startAnimation(fade_out);*/

                }

                @Override
                public void onAnimationRepeat(Animation animation) {

                }
            });
            whiteLabbledApp.startAnimation(mAnimation);
        }

    }

    /**
     * Initializes and sets up all input fields
     */
    private void setupFields() {
        userNameField = (EditText) findViewById(R.id.editTextUsername);
        passwordField = (EditText) findViewById(R.id.editTextPassword);
        checkBox = (CheckBox) findViewById(R.id.checkBoxRemember);
        tvRegister = (TextView) findViewById(R.id.textViewRegister);
        userNameField.setTextColor(Color.BLACK);
        passwordField.setTextColor(Color.BLACK);
        checkBox.setTextColor(Color.BLACK);
        tvRegisterBoth = (TextView) findViewById(R.id.textViewTryDemo2);
        tvTryDemoBoth = (TextView) findViewById(R.id.textViewTryDemo1);
        tvSocialLogin = (TextView) findViewById(R.id.textViewsocial);
        socialDivider = findViewById(R.id.centerDividerSocial);
        registerDivider = findViewById(R.id.centerDivider);


        if (null != lang) {
            tllUserNamel.setHint(lang.getMobile().get10());
            tllPassword.setHint(lang.getMobile().get11());
            tvRemberMe.setText(lang.getMobile().get54());
            tvDontHaveAccount.setText(lang.getMobile().getDontHaveAccount());
            tvDontHaveAccount1.setText(lang.getMobile().getDontHaveAccount());
            tvTryDemo.setText(lang.getMobile().get151());
            tvTryDemoBoth.setText(lang.getMobile().get151());
            tvRegister.setText(lang.getMobile().get53());
            tvRegisterBoth.setText(lang.getMobile().get53());
            tvSocialLogin.setText(lang.getMobile().get150());
        }

        // Only Social login enabled condition
        boolean isSocialLoginEnabled = (null != mobileConfig.getSocialAuthEnabled() && "1".equals(mobileConfig.getSocialAuthEnabled())) && (
            (null != mobileConfig.getFacebookEnabled() && "1".equals(mobileConfig.getFacebookEnabled())) ||
            (null != mobileConfig.getGoogleEnabled() && "1".equals(mobileConfig.getGoogleEnabled())) ||
            (null != mobileConfig.getTwitterEnabled() && "1".equals(mobileConfig.getTwitterEnabled()))
        );

        if (null != JsonPhp.getInstance().getRegisterUrl() && !TextUtils.isEmpty(JsonPhp.getInstance().getRegisterUrl()) && isSocialLoginEnabled) {
            // All Social Login, Register and Guest Login is enabled
            Logger.info("YES", "all enabled");
            containerBoth.setVisibility(View.VISIBLE);
            containerSingle.setVisibility(View.GONE);
            tvSocialLogin.setVisibility(View.VISIBLE);
            socialDivider.setVisibility(View.VISIBLE);
            tvRegisterBoth.setVisibility(View.VISIBLE);
            registerDivider.setVisibility(View.VISIBLE);
            tvTryDemoBoth.setVisibility(View.VISIBLE);

        } else if ((null != JsonPhp.getInstance().getRegisterUrl() && !TextUtils.isEmpty(JsonPhp.getInstance().getRegisterUrl())) &&
                null != mobileConfig.getGuestEnabled() && 1 == Integer.parseInt(mobileConfig.getGuestEnabled())){
            // Both Register and Guest Login are enabled
            Logger.error("YES- Both register & guest enabled");
            containerBoth.setVisibility(View.VISIBLE);
            containerSingle.setVisibility(View.GONE);
            tvSocialLogin.setVisibility(View.GONE);
            socialDivider.setVisibility(View.GONE);
            registerDivider.setVisibility(View.VISIBLE);
            tvTryDemoBoth.setVisibility(View.VISIBLE);
            tvRegisterBoth.setVisibility(View.VISIBLE);

        } else if (null != JsonPhp.getInstance().getRegisterUrl() && !TextUtils.isEmpty(JsonPhp.getInstance().getRegisterUrl()) && isSocialLoginEnabled) {
            // Both Social Login and Register enabled
            Logger.error("YES- Both register & social login enabled");
            containerBoth.setVisibility(View.VISIBLE);
            containerSingle.setVisibility(View.GONE);
            tvSocialLogin.setVisibility(View.VISIBLE);
            socialDivider.setVisibility(View.VISIBLE);
            tvRegisterBoth.setVisibility(View.VISIBLE);
            registerDivider.setVisibility(View.GONE);
            tvTryDemoBoth.setVisibility(View.GONE);

        } else if (null != mobileConfig.getGuestEnabled() && 1 == Integer.parseInt(mobileConfig.getGuestEnabled()) && isSocialLoginEnabled) {
            // Both Social Login and Guest Login is enabled
            Logger.error("YES- Both guest login & social login enabled");
            containerBoth.setVisibility(View.VISIBLE);
            containerSingle.setVisibility(View.GONE);
            tvSocialLogin.setVisibility(View.VISIBLE);
            socialDivider.setVisibility(View.VISIBLE);
            tvRegisterBoth.setVisibility(View.GONE);
            registerDivider.setVisibility(View.GONE);
            tvTryDemoBoth.setVisibility(View.VISIBLE);

        } else if (isSocialLoginEnabled) {
            // Only Social Login is enabled
            Logger.error("YES: Social Login Enabled!");
            containerBoth.setVisibility(View.VISIBLE);
            containerSingle.setVisibility(View.GONE);
            tvTryDemoBoth.setVisibility(View.GONE);
            tvRegisterBoth.setVisibility(View.GONE);
            socialDivider.setVisibility(View.GONE);
            tvSocialLogin.setVisibility(View.VISIBLE);
            registerDivider.setVisibility(View.GONE);

        } else if (null != mobileConfig.getGuestEnabled() && 1 == Integer.parseInt(mobileConfig.getGuestEnabled())){
            // Only Guest is enabled
            Logger.error("YES-Guest Login is Enables");
            containerSingle.setVisibility(View.VISIBLE);
            containerBoth.setVisibility(View.GONE);
            tvTryDemo.setVisibility(View.VISIBLE);
            tvRegister.setVisibility(View.GONE);

        } else if ((null != JsonPhp.getInstance().getRegisterUrl() && !TextUtils.isEmpty(JsonPhp.getInstance().getRegisterUrl()))){
            //Only Register is enabled
            Logger.error("YES-Register Login is Enables "+ JsonPhp.getInstance().getRegisterUrl());
            containerSingle.setVisibility(View.VISIBLE);
            containerBoth.setVisibility(View.GONE);
            tvTryDemo.setVisibility(View.GONE);
            tvRegister.setVisibility(View.VISIBLE);
        }

        tvSocialLogin.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, SocialAuthActivity.class);
                startActivity(intent);
            }
        });

        tvTryDemoBoth.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, GuestLoginActivity.class);
                startActivity(intent);
            }
        });

        tvRegisterBoth.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (LocalConfig.LOGIN_TYPE == 4) {
                    Intent createProfileIntent = new Intent(getApplicationContext(), CreateProfileActivity.class);
                    startActivity(createProfileIntent);
                } else {
                    startActivity(new Intent(LoginActivity.this, RegisterActivity.class));
                }
            }
        });

        tvTryDemo.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, GuestLoginActivity.class);
                startActivity(intent);
            }
        });

        tvRegister.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (LocalConfig.LOGIN_TYPE == 4) {
                    Intent createProfileIntent = new Intent(getApplicationContext(), CreateProfileActivity.class);
                    startActivity(createProfileIntent);
                } else {
                    startActivity(new Intent(LoginActivity.this, RegisterActivity.class));
                }
            }
        });
    }

    /**
     * Setup the guest login, social auth and register links if applicable
     */
    private void setupBottomLinks() {

        bottomSocialLoginBtn = (Button) findViewById(R.id.textViewLoginViaSocialAuth);
        bottomGuestLoginBtn = (Button) findViewById(R.id.textViewLoginAsGuest);
        bottomRegisterBtn = (Button) findViewById(R.id.textViewUserRegisterLink);

        if (null != mobileConfig) {

            /** Social auth link **/
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2) {

                // First screen was phone number login
                bottomSocialLoginBtn.setVisibility(View.GONE);
            } else if ("1".equals(mobileConfig.getSocialAuthEnabled()) && ("1".equals(mobileConfig.getFacebookEnabled()) || "1".equals(mobileConfig.getGoogleEnabled()) || "1".equals(mobileConfig.getTwitterEnabled()))) {

                // This is the first screen
                bottomSocialLoginBtn.setVisibility(View.VISIBLE);
                if (null != mobileLangs && null != mobileLangs.get150()) {
                    bottomSocialLoginBtn.setText(mobileLangs.get150());
                }
                bottomSocialLoginBtn.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(LoginActivity.this, SocialAuthActivity.class);
                        startActivity(intent);
                    }
                });
            } else {
                bottomSocialLoginBtn.setVisibility(View.GONE);
            }

            /** Guest link **/
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2) {

                // First screen was phone number login
                bottomGuestLoginBtn.setVisibility(View.GONE);
            } else if (null != mobileConfig.getGuestEnabled() && 1 == Integer.parseInt(mobileConfig.getGuestEnabled())) {

                // This is the first screen
                bottomGuestLoginBtn.setVisibility(View.VISIBLE);
                if (null != mobileLangs && null != mobileLangs.get146()) {
                    bottomGuestLoginBtn.setText(mobileLangs.get146());
                }
                bottomGuestLoginBtn.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(LoginActivity.this, GuestLoginActivity.class);
                        startActivity(intent);
                    }
                });
            } else {
                bottomGuestLoginBtn.setVisibility(View.GONE);
            }
        } else {
            bottomGuestLoginBtn.setVisibility(View.GONE);
            bottomSocialLoginBtn.setVisibility(View.GONE);
        }

        // Register link
        if (null == JsonPhp.getInstance().getRegisterUrl() || TextUtils.isEmpty(JsonPhp.getInstance().getRegisterUrl())) {
                bottomRegisterBtn.setVisibility(View.GONE);
        } else {
            if (null != lang) {
                bottomRegisterBtn.setText(lang.getMobile().get53());
            }
            String abc = bottomRegisterBtn.getText().toString();
            SpannableString content = new SpannableString(abc);
            content.setSpan(new UnderlineSpan(), 0, abc.length(), 0);
            bottomRegisterBtn.setText(content);
            tvRegister.setOnClickListener(new OnClickListener() {

                @Override
                public void onClick(View v) {
                    if (LocalConfig.LOGIN_TYPE == 4) {
                        Intent createProfileIntent = new Intent(getApplicationContext(), CreateProfileActivity.class);
                        startActivity(createProfileIntent);
                    } else {
                        startActivity(new Intent(LoginActivity.this, RegisterActivity.class));
                    }
                }
            });
        }
    }

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
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, username);
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, password);
                    vHelper.sendAjax();
                } else {
                    lang = JsonPhp.getInstance().getLang();
                    if (null != lang) {
                        tllPassword.setError(lang.getMobile().get46());
                    } else {
                        tllPassword.setError(JsonPhpLangs.EMPTY_PASSWORD_ERROR_MESSAGE);
                    }
                    passwordField.requestFocus();
                }
            } else {
                lang = JsonPhp.getInstance().getLang();
                if (null != lang) {
                    tllUserNamel.setError(lang.getMobile().get47());
                } else {
                    tllUserNamel.setError(JsonPhpLangs.EMPTY_USERNAME_ERROR_MESSAGE);
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
                        insertDefaultStatus();
                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS_MESSAGE, "Default");
                    }
                }

                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);

                if (switchRemberMe.isChecked()) {
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

				/*
                 * Download app logo for whitelabel app
				 */
                if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
                    PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                        @Override
                        public void successCallback() {
                            Intent intent = new Intent(LoginActivity.this, CometChatActivity.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                            startActivity(intent);
                            finish();
                            stopProgressWheel();
                        }

                        @Override
                        public void failCallback() {
                            Intent intent = new Intent(LoginActivity.this, CometChatActivity.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            startActivity(intent);
                            loginBtn.setEnabled(true);
                            finish();
                            stopProgressWheel();
                        }
                    });
                } else {
                    Intent intent = new Intent(LoginActivity.this, CometChatActivity.class);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    startActivity(intent);
                    loginBtn.setEnabled(true);
                    finish();
                    stopProgressWheel();
                }
            } else {
                /* Wrong credentials */
                stopProgressWheel();
                loginBtn.setEnabled(true);
                if (!TextUtils.isEmpty(username) && !TextUtils.isEmpty(password)) {
                    passwordField.setText("");
                    userNameField.requestFocus();
                    lang = JsonPhp.getInstance().getLang();
                    if (null != lang) {
                        tllUserNamel.setError(lang.getMobile().get49());
                        tllPassword.setError(lang.getMobile().get50());
                    } else {
                        tllUserNamel.setError(JsonPhpLangs.WRONG_USERNAME_MESSAGE);
                        tllPassword.setError(JsonPhpLangs.WRONG_PASSWORD_MESSAGE);
                    }
                } else {
                    new AlertDialog.Builder(this).setCancelable(true).setIcon(android.R.drawable.ic_dialog_info)
                            .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                }
                            }).setMessage("Please register on the website to be able to login from the app.").create()
                            .show();
                    SocialAuth.logout();
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void insertDefaultStatus() {
        SQLiteDatabase sqLiteDatabase = new SugarDb(this).getDB();
        sqLiteDatabase.execSQL(getResources().getString(R.string.insert_default_status));
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
                bottomRegisterBtn.setTextColor(foregroundColor);
                bottomGuestLoginBtn.setTextColor(foregroundColor);
                bottomSocialLoginBtn.setTextColor(foregroundColor);

                loginParentContainer.setBackgroundColor(Color.parseColor(theme.getLoginBackground()));
                bottomRegisterBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));
                bottomGuestLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));
                bottomSocialLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));
                checkBox.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));

                Drawable myIcon = getResources().getDrawable(R.drawable.ic_custom_back_arrow);
                if (null != myIcon) {
                    myIcon.setColorFilter(foregroundColor, PorterDuff.Mode.SRC_ATOP);
                    backButton.setImageDrawable(myIcon);
                }
                wheel.setBarColor(foregroundColor);

            } else if (null != theme.getLoginBackground() && null != theme.getLoginForeground() && null != theme.getLoginButtonPressed() && null != theme.getLoginForegroundText() && null != theme.getLoginPlaceholder()) {
                int placeholderColor = Color.parseColor(theme.getLoginPlaceholder());
                int loginforeground = Color.parseColor(theme.getLoginForeground());
                int button = Color.parseColor(theme.getLoginButtonPressed());

                userNameField.setHintTextColor(placeholderColor);
                passwordField.setHintTextColor(placeholderColor);
                userNameField.setTextColor(loginforeground);
                passwordField.setTextColor(loginforeground);

                bottomRegisterBtn.setTextColor(button);
                bottomGuestLoginBtn.setTextColor(button);
                bottomSocialLoginBtn.setTextColor(button);

                bottomRegisterBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
                bottomGuestLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
                bottomSocialLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
                checkBox.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
                loginBtn.setBackgroundColor(button);
                wheel.setBarColor(button);
                loginParentContainer.setBackgroundColor(Color.parseColor(theme.getLoginBackground()));
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
        wheel.spin();
        wheel.setVisibility(View.VISIBLE);
    }

    private static void stopProgressWheel() {
        wheel.stopSpinning();
        wheel.setProgress(0f);
        wheel.setVisibility(View.INVISIBLE);
    }

    /**
     * Clears all databaseEntries if a new user logs in.
     */
    public static void removeExistingData() {
        try {
            /* Clear buddy list */
            //SugarRecord.deleteAll(Buddy.class);
            SugarRecord.deleteInTx(Buddy.class);

            if(PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)){

                PushNotificationsManager.setChatroomChannelList(null);
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                Logger.error("debug list 2 "+PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST));
            }
            if(PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)){
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
            }

            SessionData.getInstance().setChatroomHeartBeatTimestamp("0");

            Logger.error("debug timestamp  "+SessionData.getInstance().getChatroomHeartBeatTimestamp());

			/* Clear OneOnOneChat messages */
            //SugarRecord.deleteAll(OneOnOneMessage.class);
            SugarRecord.deleteInTx(OneOnOneMessage.class);

			/* Clear chatroom list */
            //SugarRecord.deleteAll(Chatroom.class);
            SugarRecord.deleteInTx(Chatroom.class);

			/* Clear all chatroom messages */
            //SugarRecord.deleteAll(ChatroomMessage.class);
            SugarRecord.deleteInTx(ChatroomMessage.class);

            //SugarRecord.deleteAll(Announcement.class);
            SugarRecord.deleteInTx(Announcement.class);

            SugarRecord.deleteInTx(Status.class);

            if(PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)){
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
            }

            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.BASE_DATA);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_ID);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_NAME);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_LINK);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_ON);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_SOUND);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.NOTIFICATION_VIBRATE);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.STATUS_MESSAGE);

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
