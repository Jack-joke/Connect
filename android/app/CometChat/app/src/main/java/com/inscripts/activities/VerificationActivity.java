/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.NavUtils;
import android.support.v4.app.TaskStackBuilder;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.custom.ConfirmationWindow;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.jsonphp.Verify;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONObject;

public class VerificationActivity extends SuperActivity {

    private EditText verificationField;
    private Button verificatioBtn;
    private TextView resendVerificationLink;
    private ProgressWheel wheel;
    private Verify verifylang;
    private Activity activity;
    private ImageView backButton;
    private MobileTheme theme;
    public VerificationActivity verificationActivity;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_verficiation);

        setupFields();
        setupBackButton();
        setupBottomLinks();
        verificationActivity = this;

        activity = this;
        if (null != JsonPhp.getInstance().getNewMobile()) {
            verifylang = JsonPhp.getInstance().getNewMobile().getVerify();
        }

        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        verificatioBtn = (Button) findViewById(R.id.buttonVerificationCodeSubmit);
        if (null != verifylang) {
            verificatioBtn.setText(verifylang.getVerifyButton());
            setActionBarTitle(verifylang.getActionbar());
        } else {
            setActionBarTitle(this.getTitle());
        }
        theme = JsonPhp.getInstance().getMobileTheme();
        verificatioBtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                startProgressWheel();
                String verificatiocode = verificationField.getText().toString().trim();
                if (TextUtils.isEmpty(verificatiocode)) {
                    if (null == verifylang) {
                        verificationField.setError("Please enter your verification code.");
                    } else {
                        verificationField.setError(verifylang.getWrongCode());
                    }
                } else {
                    VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getPhoneRegisterURL()
                            , new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                Logger.error("response = " + response);
                                final JSONObject jsonresponse = new JSONObject(response);
                                if (jsonresponse.getString("status").equals("1")) {
                                    PhoneNumberActivity.phoneNumberActivity.finish();
                                    if (jsonresponse.has(AjaxKeys.BASE_DATA)) {
                                        PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA,
                                                jsonresponse.getString(AjaxKeys.BASE_DATA));
                                        SessionData.getInstance().setBaseData(
                                                jsonresponse.getString(AjaxKeys.BASE_DATA));
                                    }

                                    PreferenceHelper.save(PreferenceKeys.DataKeys.REGISTRATION_STATUS, "2");
                                    Intent i = new Intent(getApplicationContext(), CreateProfileActivity.class);
                                    i.putExtra(IntentExtrasKeys.TEMP_ID,
                                            PreferenceHelper.get(PreferenceKeys.DataKeys.TEMP_ID));
                                    if (jsonresponse.has(AjaxKeys.NAME)) {
                                        i.putExtra(IntentExtrasKeys.BUDDY_NAME, jsonresponse.getString(AjaxKeys.NAME));
                                    }
                                    if (jsonresponse.has(AjaxKeys.AVATAR)) {
                                        i.putExtra(IntentExtrasKeys.BUDDY_AVATAR,
                                                jsonresponse.getString(AjaxKeys.AVATAR));
                                    }
                                    startActivity(i);
                                    finish();
                                } else if (jsonresponse.getString("status").equals("2")) {
                                    if (null != PhoneNumberActivity.phoneNumberActivity) {
                                        PhoneNumberActivity.phoneNumberActivity.finish();
                                    }
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.REGISTRATION_STATUS, "2");
                                    if (jsonresponse.has(AjaxKeys.BASE_DATA)) {
                                        PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA,
                                                jsonresponse.getString(AjaxKeys.BASE_DATA));
                                        SessionData.getInstance().setBaseData(
                                                jsonresponse.getString(AjaxKeys.BASE_DATA));
                                    }

                                    if (jsonresponse.has(AjaxKeys.AVATAR)) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR,
                                                jsonresponse.getString(AjaxKeys.AVATAR));
                                    }

                                    if (jsonresponse.has(AjaxKeys.NAME)) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_NAME,
                                                jsonresponse.getString(AjaxKeys.NAME));
                                    }

                                    if (jsonresponse.has(AjaxKeys.VERIFICATION_CODE)) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.SECOND_VERI_CODE,
                                                jsonresponse.getString(AjaxKeys.VERIFICATION_CODE));
                                    }
                                    final Intent i = new Intent(getApplicationContext(), CreateProfileActivity.class);
                                    if (jsonresponse.has(AjaxKeys.EMAIL)) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_EMAIL,
                                                jsonresponse.getString(AjaxKeys.EMAIL));

                                        String yes = StaticMembers.POSITIVE_TITLE, no = StaticMembers.NEGATIVE_TITLE;
                                        Lang lang = JsonPhp.getInstance().getLang();
                                        if (null != lang && lang.getMobile().get33() != null) {
                                            yes = lang.getMobile().get33();
                                        }
                                        if (null != lang && lang.getMobile().get34() != null) {
                                            no = lang.getMobile().get34();
                                        }

                                        ConfirmationWindow cWindow = new ConfirmationWindow(activity, yes, no) {
                                            @Override
                                            protected void setNegativeResponse() {
                                                super.setNegativeResponse();
                                                PreferenceHelper.save(PreferenceKeys.UserKeys.CHANGE_EMAIL, "1");
                                                i.putExtra(IntentExtrasKeys.VERFICATION_STATUS_CASE_TWO, "1");
                                                startActivity(i);
                                                finish();
                                            }

                                            @Override
                                            protected void setPositiveResponse() {
                                                super.setPositiveResponse();
                                                try {
                                                    PreferenceHelper.save(PreferenceKeys.UserKeys.CHANGE_EMAIL, "0");
                                                    if (jsonresponse.has(AjaxKeys.NAME)) {
                                                        i.putExtra(IntentExtrasKeys.BUDDY_NAME,
                                                                jsonresponse.getString(AjaxKeys.NAME));
                                                    }
                                                    if (jsonresponse.has(AjaxKeys.AVATAR)) {
                                                        i.putExtra(IntentExtrasKeys.BUDDY_AVATAR,
                                                                jsonresponse.getString(AjaxKeys.AVATAR));
                                                    }
                                                    i.putExtra(IntentExtrasKeys.VERFICATION_STATUS_CASE_TWO, "1");
                                                    startActivity(i);
                                                    finish();
                                                } catch (Exception e) {
                                                    e.printStackTrace();
                                                }
                                            }
                                        };
                                        cWindow.setCancelable(false);
                                        cWindow.setMessage(((null == verifylang.getChangeEmail()) ? "We found your account. Would you like to use the same email\n'"
                                                : verifylang.getChangeEmail() + "\n")
                                                + jsonresponse.getString(AjaxKeys.EMAIL) + "' ?");
                                        cWindow.show();

                                    } else {
                                        if (jsonresponse.has(AjaxKeys.NAME)) {
                                            i.putExtra(IntentExtrasKeys.BUDDY_NAME,
                                                    jsonresponse.getString(AjaxKeys.NAME));
                                        }
                                        if (jsonresponse.has(AjaxKeys.AVATAR)) {
                                            i.putExtra(IntentExtrasKeys.BUDDY_AVATAR,
                                                    jsonresponse.getString(AjaxKeys.AVATAR));
                                        }
                                        i.putExtra(IntentExtrasKeys.VERFICATION_STATUS_CASE_TWO, "1");
                                        startActivity(i);
                                        finish();
                                    }
                                } else {
                                    verificationField
                                            .setError((null == verifylang) ? "Please check the verification code."
                                                    : verifylang.getWrongCode());
                                }
                                stopProgressWheel();
                            } catch (Exception e) {
                                e.printStackTrace();
                                Toast.makeText(VerificationActivity.this, "An error occurred. Please try again in some time.", Toast.LENGTH_LONG).show();
                                stopProgressWheel();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            stopProgressWheel();
                        }
                    });
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "verify");
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.VERIFICATION_CODE, verificatiocode);
                    vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TEMP_ID,
                            PreferenceHelper.get(PreferenceKeys.DataKeys.TEMP_ID));
                    vHelper.sendAjax();
                }
            }
        });

        try {
            if (null != theme && null != theme.getLoginButton() && null != theme.getLoginButtonText()) {
                int btnColor = Color.parseColor(theme.getLoginButton());
                int textColor = Color.parseColor(theme.getLoginButtonText());
                wheel.setBarColor(btnColor);

                verificatioBtn.setBackgroundColor(btnColor);
                verificatioBtn.setTextColor(textColor);

                resendVerificationLink.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                resendVerificationLink.setTextColor(btnColor);

                Drawable myIcon = getResources().getDrawable(R.drawable.ic_custom_back_arrow);
                myIcon.setColorFilter(btnColor, PorterDuff.Mode.SRC_ATOP);
                backButton.setImageDrawable(myIcon);
                verificationField.setTextColor(Color.parseColor(theme.getLoginText()));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void startProgressWheel() {
        wheel.setVisibility(View.VISIBLE);
        wheel.spin();
    }

    private void stopProgressWheel() {
        wheel.setProgress(0f);
        wheel.stopSpinning();
        wheel.setVisibility(View.INVISIBLE);
    }

    private void setupFields() {
        verificationField = (EditText) findViewById(R.id.editTextVerificationCode);
        if (null != verifylang) {
            verificationField.setHint(verifylang.getFieldHint());
        }
    }

    private void setupBackButton() {
        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);
        backButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent upIntent = NavUtils.getParentActivityIntent(verificationActivity);
                if (verificationActivity.isTaskRoot()) {
                    TaskStackBuilder.create(verificationActivity).addNextIntentWithParentStack(upIntent).startActivities();
                } else {
                    onBackPressed();
                }
            }
        });
    }

    private void setupBottomLinks() {
        resendVerificationLink = (TextView) findViewById(R.id.textViewResendVerification);
        if (null != verifylang) {
            resendVerificationLink.setText(verifylang.getResendButton());
        }
        resendVerificationLink.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {

                VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getPhoneRegisterURL()
                        , new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        Toast.makeText(VerificationActivity.this, "Code resent. Please check your messages in some time.", Toast.LENGTH_LONG).show();
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Toast.makeText(VerificationActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET, Toast.LENGTH_LONG).show();
                        } else {
                            Toast.makeText(VerificationActivity.this, "An error occurred. Please try again in some time.", Toast.LENGTH_LONG).show();
                        }
                    }
                });
                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PHONE_NUMBER,
                        PreferenceHelper.get(PreferenceKeys.LoginKeys.CURRENT_PHONE));
                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "resend_code");
                vHelper.addNameValuePair(CometChatKeys.AjaxKeys.TEMP_ID,
                        PreferenceHelper.get(PreferenceKeys.DataKeys.TEMP_ID));
                vHelper.sendAjax();
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            Intent upIntent = NavUtils.getParentActivityIntent(this);
            if (this.isTaskRoot()) {
                TaskStackBuilder.create(this).addNextIntentWithParentStack(upIntent).startActivities();
            } else {
                NavUtils.navigateUpTo(this, upIntent);
            }
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void finish() {
        super.finish();
    }
}
