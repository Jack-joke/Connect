/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Toast;

import com.facebook.model.GraphUser;
import com.facebook.widget.LoginButton;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.plus.Plus;
import com.google.android.gms.plus.model.people.Person;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.SocialAuth;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;
import com.twitter.sdk.android.core.Callback;
import com.twitter.sdk.android.core.Result;
import com.twitter.sdk.android.core.TwitterException;
import com.twitter.sdk.android.core.TwitterSession;
import com.twitter.sdk.android.core.identity.TwitterLoginButton;

import org.json.JSONObject;

import java.util.Arrays;
import java.util.regex.Pattern;

public class SocialAuthActivity extends SuperActivity {

    private LoginButton facebookLoginButton;
    private TwitterLoginButton twitterLoginButton;
    private MobileConfig mobileConfig;
    private Lang lang;
    private GoogleApiClient googleApiClient;
    private boolean gPlusIntentInProgress;
    private static final int GMAIL_SIGN_IN_REQUEST_CODE = 0;
    private ProgressWheel wheel;
    private ImageView backButton,logoLogin;
    private Button bottomGuestLoginButton , customFacebookBtn , customTwitterBtn ,  customGplusBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();

        setContentView(R.layout.activity_social_auth_only);


        facebookLoginButton = (LoginButton) findViewById(R.id.facebookLoginButton);
        twitterLoginButton = (TwitterLoginButton) findViewById(R.id.twitterLoginButton);
        logoLogin = (ImageView) findViewById(R.id.imageViewAppLogoInPhoneNumber);

        customGplusBtn = (Button) findViewById(R.id.imageButtonCustomgplusBtn);
        customTwitterBtn = (Button) findViewById(R.id.imageButtonCustomTwitterBtn);
        customFacebookBtn = (Button) findViewById(R.id.custom_facebook_button);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);


        customFacebookBtn.getBackground().setColorFilter(Color.parseColor("#3b5998"), PorterDuff.Mode.SRC_ATOP);
        customTwitterBtn.getBackground().setColorFilter(Color.parseColor("#55acee"), PorterDuff.Mode.SRC_ATOP);
        customGplusBtn.getBackground().setColorFilter(Color.parseColor("#dd4b39"), PorterDuff.Mode.SRC_ATOP);


        customFacebookBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                facebookLoginButton.performClick();
            }
        });


        lang = JsonPhp.getInstance().getLang();
        mobileConfig = JsonPhp.getInstance().getMobileConfig();

        if (null != mobileConfig) {
            prepareFacebookLoginButton();
            prepareTwitterLoginButton();
            prepareGoogleLoginButton();
        } else {
            // Never gonna happen
            Logger.error("Mobile Config is NULL");
        }

        if (LocalConfig.getIsCOD().equals("1")) {
            customGplusBtn.setVisibility(View.GONE);
        }

        setupBackButton();
        setupBottomLinks();
        applyThemeColor();
    }

    private void applyThemeColor() {
        MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
        if (null != theme && null != theme.getLoginForeground() && null != theme.getLoginButton()) {
            int foregroundColor = Color.parseColor(theme.getLoginButton());
            bottomGuestLoginButton.setTextColor(foregroundColor);
            bottomGuestLoginButton.getBackground().setColorFilter(new
                    LightingColorFilter(Color.WHITE, foregroundColor));
        } else if (null != theme && null != theme.getLoginButtonPressed()) {
            int foregroundColor = Color.parseColor(theme.getLoginButtonPressed());
            bottomGuestLoginButton.setTextColor(foregroundColor);
            bottomGuestLoginButton.getBackground().setColorFilter(new
                    LightingColorFilter(Color.WHITE, foregroundColor));
        }

        if (!LocalConfig.isWhiteLabelled()) {
            logoLogin.setColorFilter(Color.BLACK, PorterDuff.Mode.SRC_ATOP);
        }
    }

    private void setupBackButton() {

        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);
        if (null != mobileConfig) {
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2 ||
                    1 == Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) || !LocalConfig.isWhiteLabelled()) {
                backButton.setVisibility(View.VISIBLE);
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
                (LocalConfig.LOGIN_TYPE == 1 || !LocalConfig.isWhiteLabelled())) {

            // Old apps
            backButton.setVisibility(View.VISIBLE);
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

        bottomGuestLoginButton = (Button) findViewById(R.id.textViewLoginAsGuest);
        if (null != mobileConfig) {

            /** Guest link **/
            int phoneNumberEnabled = Integer.parseInt(mobileConfig.getPhoneNumberEnabled());
            if (phoneNumberEnabled == 1 || phoneNumberEnabled == 2 ||
                    1 == Integer.parseInt(mobileConfig.getUsernamePasswordEnabled())) {

                bottomGuestLoginButton.setVisibility(View.GONE);
            } else if (1 == Integer.parseInt(mobileConfig.getGuestEnabled())) {
                // This is the first screen
                bottomGuestLoginButton.setVisibility(View.VISIBLE);
                Mobile mobileLangs = JsonPhp.getInstance().getLang().getMobile();
                if (null != mobileLangs && null != mobileLangs.get146()) {
                    bottomGuestLoginButton.setText(mobileLangs.get146());
                }
                bottomGuestLoginButton.setOnClickListener(new View.OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(SocialAuthActivity.this, GuestLoginActivity.class);
                        startActivity(intent);
                    }
                });
            } else {
                bottomGuestLoginButton.setVisibility(View.GONE);
            }
        } else {
            bottomGuestLoginButton.setVisibility(View.GONE);
        }
    }

    private void prepareFacebookLoginButton() {
        if ("1".equals(mobileConfig.getFacebookEnabled())) {
            facebookLoginButton.setCompoundDrawablesWithIntrinsicBounds(0, 0, 0, 0);
            facebookLoginButton.setBackground(getDrawable(R.drawable.logout_button_background));
            facebookLoginButton.getBackground().setColorFilter(Color.parseColor("#3b5998"), PorterDuff.Mode.SRC_ATOP);
            facebookLoginButton.setReadPermissions(Arrays.asList("public_profile", "email"));
            facebookLoginButton.setUserInfoChangedCallback(new LoginButton.UserInfoChangedCallback() {
                @Override
                public void onUserInfoFetched(final GraphUser user) {
                    if (null != user) {
                        if (!"1".equals(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN))) {

                            VolleyHelper volley = new VolleyHelper(SocialAuthActivity.this, URLFactory.getLoginURL(),
                                    new VolleyAjaxCallbacks() {

                                        @Override
                                        public void successCallback(String response) {
                                            Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                                            if (htmlPattern.matcher(response).matches()) {
                                                failCallback(response, false);
                                            } else if (CommonUtils.isJSONValid(response)) {
                                                performLogin(response);
                                            } else {
                                                LoginActivity.showVersionErrorPopUp(SocialAuthActivity.this);
                                            }
                                        }

                                        @Override
                                        public void failCallback(String response, boolean isNoInternet) {
                                            stopProgressWheel();
                                            if (isNoInternet) {
                                                if (null != lang) {
                                                    Toast.makeText(SocialAuthActivity.this, lang.getMobile().get24(),
                                                            Toast.LENGTH_SHORT).show();
                                                } else {
                                                    Toast.makeText(SocialAuthActivity.this,
                                                            StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                            Toast.LENGTH_SHORT).show();
                                                }
                                            } else {
                                                Toast.makeText(SocialAuthActivity.this, "Error: " + StaticMembers.FACEBOOK_LOGIN_ERROR,
                                                        Toast.LENGTH_SHORT).show();
                                            }
                                            SocialAuth.logout();
                                        }
                                    });
                            volley.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, user.getId());
                            volley.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, "");
                            volley.addNameValuePair(CometChatKeys.SocialKeys.SOCIAL_DETAILS,
                                    SocialAuth.formatFacebookJSON(user).toString());
                            volley.sendAjax();
                            startProgressWheel();
                        } /*else {
                            Intent intent = new Intent(SocialAuthActivity.this, CometChatActivity.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            startActivity(intent);
                            finish();
                        }*/
                    }
                }
            });
        } else {
            facebookLoginButton.setVisibility(View.GONE);
        }
    }

    private void prepareTwitterLoginButton() {
        if ("1".equals(mobileConfig.getTwitterEnabled())) {
            //twitterLoginButton.setVisibility(View.VISIBLE);
            customTwitterBtn.setVisibility(View.VISIBLE);
            customTwitterBtn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    twitterLoginButton.performClick();
                }
            });

            twitterLoginButton.setCallback(new Callback<TwitterSession>() {

                @Override
                public void success(final Result<TwitterSession> result) {

                    startProgressWheel();

                    SocialAuth.getTwitterUserInfo(SocialAuthActivity.this, result, new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            VolleyHelper vHelper = new VolleyHelper(SocialAuthActivity.this, URLFactory.getLoginURL(),
                                    new VolleyAjaxCallbacks() {

                                        @Override
                                        public void successCallback(String response) {
                                            Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                                            if (htmlPattern.matcher(response).matches()) {
                                                failCallback(response, false);
                                            } else if (CommonUtils.isJSONValid(response)) {
                                                Logger.error("Twitter login successful: " + response);
                                                performLogin(response);
                                            } else {
                                                LoginActivity.showVersionErrorPopUp(SocialAuthActivity.this);
                                            }
                                        }

                                        @Override
                                        public void failCallback(String response, boolean isNoInternet) {
                                            wheel.setVisibility(View.GONE);
                                            if (isNoInternet) {
                                                Toast.makeText(
                                                        SocialAuthActivity.this,
                                                        (null == lang) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : lang
                                                                .getMobile().get24(), Toast.LENGTH_SHORT).show();
                                            } else {
                                                Toast.makeText(SocialAuthActivity.this, "Error: " + StaticMembers.TWITTER_LOGIN_ERROR, Toast.LENGTH_SHORT)
                                                        .show();
                                            }
                                            SocialAuth.logout();
                                        }
                                    });
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, result.data.getUserId());
                            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, "");
                            vHelper.addNameValuePair(CometChatKeys.SocialKeys.SOCIAL_DETAILS,
                                    SocialAuth.formatTwitterJSON(response).toString());
                            vHelper.sendAjax();
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            stopProgressWheel();
                            if (isNoInternet) {
                                if (null != lang) {
                                    Toast.makeText(SocialAuthActivity.this, lang.getMobile().get24(),
                                            Toast.LENGTH_SHORT).show();
                                } else {
                                    Toast.makeText(SocialAuthActivity.this,
                                            StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                            Toast.LENGTH_SHORT).show();
                                }
                            } else {
                                Toast.makeText(SocialAuthActivity.this, "Error: " + StaticMembers.TWITTER_LOGIN_ERROR, Toast.LENGTH_SHORT)
                                        .show();
                            }
                            SocialAuth.logout();
                        }
                    });
                }

                @Override
                public void failure(TwitterException exception) {
                    stopProgressWheel();
                    Toast.makeText(SocialAuthActivity.this, "Error: " + exception.getLocalizedMessage(), Toast.LENGTH_SHORT)
                            .show();
                    SocialAuth.logout();
                    exception.printStackTrace();
                }
            });
        } else {
            //twitterLoginButton.setVisibility(View.GONE);
            customTwitterBtn.setVisibility(View.GONE);
        }
    }

    private void stopProgressWheel() {

    }

    private void startProgressWheel() {
    }

    private void prepareGoogleLoginButton() {
        if ("1".equals(mobileConfig.getGoogleEnabled())) {
            customGplusBtn.setVisibility(View.VISIBLE);
            googleApiClient = new GoogleApiClient.Builder(this).addConnectionCallbacks(new GoogleApiClient.ConnectionCallbacks() {

                @Override
                public void onConnectionSuspended(int arg0) {
                    googleApiClient.connect();
                }

                @Override
                public void onConnected(Bundle arg0) {
                    if (Plus.PeopleApi.getCurrentPerson(googleApiClient) != null) {
                        Person currentPerson = Plus.PeopleApi.getCurrentPerson(googleApiClient);
                        Logger.error("name=" + currentPerson.getDisplayName());
                        VolleyHelper vHelper = new VolleyHelper(SocialAuthActivity.this, URLFactory.getLoginURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        Logger.error("Gmail Login resp: " + response + "|");
                                        Pattern htmlPattern = Pattern.compile(".*\\<[^>]+>.*", Pattern.DOTALL);
                                        if (htmlPattern.matcher(response).matches()) {
                                            failCallback(response, false);
                                        } else if (CommonUtils.isJSONValid(response)) {
                                            Logger.error("Google login successful: " + response);
                                            performLogin(response);
                                        } else {
                                            LoginActivity.showVersionErrorPopUp(SocialAuthActivity.this);
                                        }
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        stopProgressWheel();
                                        if (isNoInternet) {
                                            Toast.makeText(
                                                    SocialAuthActivity.this,
                                                    (null == lang) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : lang
                                                            .getMobile().get24(), Toast.LENGTH_SHORT).show();
                                        } else {
                                            Toast.makeText(SocialAuthActivity.this, "Error: " + StaticMembers.GMAIL_LOGIN_ERROR, Toast.LENGTH_SHORT)
                                                    .show();
                                        }
                                        Plus.AccountApi.clearDefaultAccount(googleApiClient);
                                        googleApiClient.disconnect();
                                    }
                                });
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.USERNAME, currentPerson.getId());
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, "");
                        vHelper.addNameValuePair(CometChatKeys.SocialKeys.SOCIAL_DETAILS,
                                SocialAuth.formatGooglePlusJSON(currentPerson, googleApiClient).toString());

                        vHelper.sendAjax();
                    }
                }
            }).addOnConnectionFailedListener(new GoogleApiClient.OnConnectionFailedListener() {

                @Override
                public void onConnectionFailed(ConnectionResult result) {
                    Logger.error("Onconnection gmail failed " + result);
                    stopProgressWheel();
                    if (!gPlusIntentInProgress && result.hasResolution()) {
                        try {
                            gPlusIntentInProgress = true;
                            startIntentSenderForResult(result.getResolution().getIntentSender(),
                                    GMAIL_SIGN_IN_REQUEST_CODE, null, 0, 0, 0);
                        } catch (Exception e) {
                            gPlusIntentInProgress = false;
                            googleApiClient.connect();
                        }
                    }
                }
            }).addApi(Plus.API).addScope(Plus.SCOPE_PLUS_LOGIN).build();

            customGplusBtn.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    googleApiClient.connect();
                    startProgressWheel();
                }
            });
            SocialAuth.setGoogleApiClient(googleApiClient);
        } else {
            customGplusBtn.setVisibility(View.GONE);
        }
    }

    public void performLogin(String response) {
        try {
            String baseData = new JSONObject(response).getString(CometChatKeys.AjaxKeys.BASE_DATA);
            if (!"0".equalsIgnoreCase(baseData) && !TextUtils.isEmpty(baseData)) {
                SessionData.getInstance().setBaseData(baseData);
                if (PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
                    if (!baseData.equalsIgnoreCase(PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA))) {
                        LoginActivity.removeExistingData();
                    }
                }

                PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);

                Intent intent = new Intent(SocialAuthActivity.this, CometChatActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(intent);
                finish();
            } else {
                Toast.makeText(this, "Couldn't log you in. Please try again.", Toast.LENGTH_LONG).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_CANCELED) {
            gPlusIntentInProgress = false;
        } else {
            if (requestCode == GMAIL_SIGN_IN_REQUEST_CODE) {
                gPlusIntentInProgress = false;

                if (null != googleApiClient && !googleApiClient.isConnecting()) {
                    googleApiClient.connect();
                }
            }
            if ("1".equals(mobileConfig.getTwitterEnabled())) {
                twitterLoginButton.onActivityResult(requestCode, resultCode, data);
            }
        }
    }

    @Override
    protected void onStop() {
        super.onStop();
        if (null != googleApiClient && googleApiClient.isConnected()) {
            googleApiClient.disconnect();
        }
    }

}
