/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Context;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.annotation.ColorInt;
import android.support.design.widget.TextInputLayout;
import android.text.TextUtils;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONObject;

import java.lang.reflect.Field;
import java.util.regex.Pattern;


public class GuestLoginActivity extends SuperActivity {

    private EditText guestNameField;
    private Button loginBtn;
    private static String guestPassword = "CC^CONTROL_GUEST";
    private ProgressWheel wheel;
    private Mobile mobileLangs;
    private ImageView backButton;
    private ImageView originalLogo;
    private TextInputLayout tllGuestname;
    //private MobileTheme mobileTheme;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();

        setContentView(R.layout.activity_guest_login);

        setActionBarTitle(this.getTitle());

       originalLogo = (ImageView) findViewById(R.id.imageViewCometchatLogo);
        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);


        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = JsonPhp.getInstance().getLang().getMobile();
           // mobileTheme = JsonPhp.getInstance().getMobileTheme();
        }

        setupBackButton();
        //setupBottomLinks();

        guestNameField = (EditText) findViewById(R.id.editTextGuestName);
        tllGuestname = (TextInputLayout) findViewById(R.id.input_layout_guest_name);
        if (null != mobileLangs && null != mobileLangs.get148()) {
           // guestNameField.setHint(mobileLangs.get148());
        } else {
            //guestNameField.setHint(Html.fromHtml("Guest-<i>Your Name</i>"));
        }

        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        loginBtn = (Button) findViewById(R.id.buttonGuestLogin);

        loginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String name = guestNameField.getText().toString().trim();
                if (TextUtils.isEmpty(name)) {
                    if (null != mobileLangs && null != mobileLangs.get149()) {
                        tllGuestname.setError(mobileLangs.get149());
                    } else {
                        tllGuestname.setError("Please enter guest name");
                    }
                } else {
                    wheel.setVisibility(View.VISIBLE);
                    wheel.spin();

                    InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
                    inputMethodManager.hideSoftInputFromWindow(loginBtn.getApplicationWindowToken(), 0);
                    loginBtn.setEnabled(false);

                    VolleyHelper volleyHelper = new VolleyHelper(getApplicationContext(), URLFactory.getLoginURL(), new VolleyAjaxCallbacks() {
                        @Override
                        public void successCallback(String response) {
                            Logger.error("Guest login success Response=" + response);
                            Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                            if (htmlPattern.matcher(response).matches()) {
                                failCallback(response, false);
                            } else if (CommonUtils.isJSONValid(response)) {
                                try {
                                    LoginActivity.removeExistingData();
                                    String baseData = new JSONObject(response).getString(CometChatKeys.AjaxKeys.BASE_DATA);
                                    if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                                        SessionData.getInstance().setBaseData(baseData);

                                        LoginActivity.removeExistingData();

                                        PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_NAME, name);
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGIN_PASSWORD, guestPassword);
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST, "1");
                                        JSONObject version = new JSONObject(response);
                                        if (version.has("version")) {
                                            String versionCode = version.getString("version");
                                            PreferenceHelper.save(PreferenceKeys.LoginKeys.VERSION_CODE, versionCode);
                                        }
                                        if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
                                            PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                                                @Override
                                                public void successCallback() {

                                                    Intent intent = new Intent(GuestLoginActivity.this, CometChatActivity.class);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                    startActivity(intent);
                                                    finish();
                                                    dismissProgressWheel();
                                                }

                                                @Override
                                                public void failCallback() {
                                                    Intent intent = new Intent(GuestLoginActivity.this, CometChatActivity.class);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                    startActivity(intent);
                                                    loginBtn.setEnabled(true);
                                                    finish();
                                                    dismissProgressWheel();
                                                }
                                            });
                                        } else {
                                            Intent intent = new Intent(GuestLoginActivity.this, CometChatActivity.class);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                            startActivity(intent);
                                            loginBtn.setEnabled(true);
                                            finish();
                                            dismissProgressWheel();
                                        }
                                    } else {
                                        Toast.makeText(getApplicationContext(), "Unable to login", Toast.LENGTH_SHORT).show();
                                        dismissProgressWheel();
                                    }

                                } catch (Exception e) {
                                    e.printStackTrace();
                                }

                            } else {
                                LoginActivity.showVersionErrorPopUp(GuestLoginActivity.this);
                                dismissProgressWheel();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            loginBtn.setEnabled(true);
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
        });
      /*  if (null != mobileTheme && null != mobileTheme.getLoginButton() && null != mobileTheme.getLoginButtonText() && null != mobileTheme.getLoginText()) {
            int btnColor = Color.parseColor(mobileTheme.getLoginButton());
            int textColor = Color.parseColor(mobileTheme.getLoginButtonText());
            loginBtn.setBackgroundColor(btnColor);
            loginBtn.setTextColor(textColor);
            guestNameField.setTextColor(Color.parseColor(mobileTheme.getLoginText()));
            wheel.setBarColor(btnColor);
        } else if (null != mobileTheme && null != mobileTheme.getLoginButtonPressed() && null != mobileTheme.getLoginForegroundText()) {
            int btnColor = Color.parseColor(mobileTheme.getLoginButtonPressed());
            int textColor = Color.parseColor(mobileTheme.getLoginForegroundText());
            loginBtn.setBackgroundColor(btnColor);
            loginBtn.setTextColor(textColor);
            guestNameField.setTextColor(textColor);
            wheel.setBarColor(btnColor);
        }*/

        setThemeColor();
    }


    private void setThemeColor(){
        loginBtn.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        if (!LocalConfig.isWhiteLabelled()) {
            originalLogo.setColorFilter(Color.BLACK, PorterDuff.Mode.SRC_ATOP);
        }
        setInputTextLayoutColor(guestNameField,Color.parseColor("#a2a2a5"));
        backButton.getDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
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


    private void setupBackButton() {
        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);
        if (mobileConfig != null) {

            // New apps
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2 ||
                    1 == Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) ||
                    1 == Integer.parseInt(mobileConfig.getSocialAuthEnabled()) ||
                    !LocalConfig.isWhiteLabelled()) {

                MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
                if (theme != null && theme.getLoginButton() != null) {
                    Drawable myIcon = getResources().getDrawable(R.drawable.ic_custom_back_arrow);
                    if (null != myIcon) {
                        myIcon.setColorFilter(Color.parseColor(theme.getLoginButton()), PorterDuff.Mode.SRC_ATOP);
                        backButton.setImageDrawable(myIcon);
                    }
                }
                backButton.setOnClickListener(new View.OnClickListener() {

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
            MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
            if (theme != null && theme.getLoginButton() != null) {
                Drawable myIcon = getResources().getDrawable(R.drawable.ic_custom_back_arrow);
                if (null != myIcon) {
                    myIcon.setColorFilter(Color.parseColor(theme.getLoginButton()), PorterDuff.Mode.SRC_ATOP);
                    backButton.setImageDrawable(myIcon);
                }
            }
            backButton.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });
        } else {
            backButton.setVisibility(View.GONE);
        }
    }

    private void setupBottomLinks() {
        if (mobileConfig != null) {

            // New apps
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2 ||
                    1 == Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) ||
                    1 == Integer.parseInt(mobileConfig.getSocialAuthEnabled()) ||
                    !LocalConfig.isWhiteLabelled()) {

                backButton.setOnClickListener(new View.OnClickListener() {

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
            backButton.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });
        } else {
            backButton.setVisibility(View.GONE);
        }
    }

    private void dismissProgressWheel() {
        wheel.setProgress(0f);
        wheel.stopSpinning();
        wheel.setVisibility(View.INVISIBLE);
    }


}
