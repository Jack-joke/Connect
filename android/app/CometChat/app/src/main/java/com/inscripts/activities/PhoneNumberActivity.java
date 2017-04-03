/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.text.TextUtils;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Login;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.JsonParsingKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;

public class PhoneNumberActivity extends SuperActivity {

    private static final String EDIT_TEXT_PHONE_NUMBER = "EDIT_TEXT_PHONE_NUMBER";

    private EditText phoneNumberField, phoneCountryCode;
    private String responseId;
    private ProgressWheel wheel;
    private static Map<String, String> country2phone = new HashMap<>();
    public static PhoneNumberActivity phoneNumberActivity;
    private final List<String> list = new ArrayList<>();
    private Login loginlang;
    private Mobile mobilelangs;
    private ArrayAdapter<String> dataAdapter;
    private ImageView backButton;
    private Button bottomGuestLoginButton, bottomSocialLoginButton, bottomUsernameLoginButton;
    private MobileTheme theme;
    private Button submitBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();

        setContentView(R.layout.activity_phonenumber);
        phoneNumberActivity = this;

        wheel = (ProgressWheel) findViewById(R.id.progressWheel);

        if (null != JsonPhp.getInstance().getNewMobile()) {
            loginlang = JsonPhp.getInstance().getNewMobile().getLogin();
        }
        mobilelangs = JsonPhp.getInstance().getLang().getMobile();
        theme = JsonPhp.getInstance().getMobileTheme();

        setupFields();
        autoFill(savedInstanceState);
        setupBackButton();
        setupBottomLinks();

        submitBtn = (Button) findViewById(R.id.buttonSubmitPhoneNumber);
        if (null != loginlang) {
            submitBtn.setText(loginlang.getRegisterNumberButtonText());
        }
        submitBtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                startWheel();
                final String phonenumber = phoneNumberField.getText().toString().trim();
                final String code = phoneCountryCode.getText().toString().trim();
                if (phonenumber.length() < 8) {
                    phoneNumberField.setError((null == loginlang) ? "Phone number can not be short than 8 numbers"
                            : loginlang.getInvalidPhone());
                    stopWheel();
                } else {
                    VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getPhoneRegisterURL()
                            , new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            Logger.error("success response " + response);
                            try {
                                JSONObject jsonResponse = new JSONObject(response);
                                if (jsonResponse.getString("status").equals("1")) {
                                    // responseId =
                                    // jsonResponse.getString(JsonParsingKeys.IDENTIFIER);
                                    responseId = jsonResponse.getString(JsonParsingKeys.TEMP_ID);
                                    Intent loginIntent = new Intent(getApplicationContext(), VerificationActivity.class);
                                    startActivity(loginIntent);
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.CURRENT_PHONE, (code + phonenumber));
                                    if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.MY_PHONE_NUMBER)) {
                                        PreferenceHelper.save(PreferenceKeys.DataKeys.MY_PHONE_NUMBER, "");
                                    }
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.TEMP_ID, responseId);
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.REGISTRATION_STATUS, "1");
                                } else {
                                    Logger.error("Phone number sending error");
                                    phoneNumberField.setError(null == loginlang ? "The phone number is invalid"
                                            : loginlang.getInvalidPhone());
                                }
                                stopWheel();
                            } catch (Exception e) {
                                e.printStackTrace();
                                stopWheel();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            stopWheel();
                        }
                    });
                    try {
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "register");
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PHONE_NUMBER, code + phonenumber);
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PHONE_NUMBER_HASH,
                                EncryptionHelper.encodeIntoMD5(code + phonenumber));
                        vHelper.sendAjax();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }
        });

        applyThemeColor();
    }

    private void setupFields() {
        phoneNumberField = (EditText) findViewById(R.id.editTextPhonenumberField);
        phoneCountryCode = (EditText) findViewById(R.id.edittextCountryCodes);
        Spinner selectCountry = (Spinner) findViewById(R.id.buttonSelectCountry);

        TelephonyManager manager = (TelephonyManager) getSystemService(Context.TELEPHONY_SERVICE);
        String currentTelephoneCode = TextUtils.isEmpty(manager.getNetworkCountryIso()) ? TextUtils.isEmpty(manager
                .getSimCountryIso()) ? country2phone.get(getResources().getConfiguration().locale.getCountry())
                : country2phone.get(manager.getSimCountryIso().toUpperCase()) : country2phone.get(manager
                .getNetworkCountryIso().toUpperCase());

        if (null != loginlang) {
            phoneNumberField.setHint(loginlang.getPhoneHint());
            phoneCountryCode.setHint(loginlang.getCountryCode());
        }

        phoneCountryCode.setText(currentTelephoneCode);

        for (Map.Entry<String, String> entry : country2phone.entrySet()) {
            if (currentTelephoneCode.equals(entry.getValue())) {
                Locale local = new Locale("", entry.getKey());
                list.add(local.getDisplayCountry());
                break;
            }
        }

        if (list.size() == 0) {
            list.add("Select country");
        }

        dataAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, list);
        selectCountry.setAdapter(dataAdapter);
        selectCountry.setOnTouchListener(new View.OnTouchListener() {

            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if (event.getAction() == MotionEvent.ACTION_DOWN) {
                    Intent i = new Intent(getApplicationContext(), SelectCountryActivity.class);
                    startActivityForResult(i, 1);
                }
                return false;
            }
        });
    }

    private void autoFill(Bundle fields) {

        if (null != fields) {
            phoneNumberField.setText(fields.getString(EDIT_TEXT_PHONE_NUMBER));
        }
    }

    private void setupBackButton() {
        backButton = (ImageView) findViewById(R.id.imageViewBottomBack);
        if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {

            // Stock app
            backButton.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });
        } else {

            // White labelled app
            backButton.setVisibility(View.GONE);
        }
    }

    private void setupBottomLinks() {

        bottomUsernameLoginButton = (Button) findViewById(R.id.textViewLoginViaEmail);
        bottomSocialLoginButton = (Button) findViewById(R.id.textViewLoginViaSocialAuth);
        bottomGuestLoginButton = (Button) findViewById(R.id.textViewLoginAsGuest);

        if (null != mobileConfig) {

            // Username password login
            if ("1".equals(mobileConfig.getUsernamePasswordEnabled())) {
                bottomUsernameLoginButton.setVisibility(View.VISIBLE);
                if (null != mobilelangs && null != mobilelangs.get147()) {
                    bottomUsernameLoginButton.setText(mobilelangs.get147());
                } else if (null != loginlang && null != loginlang.getLoginViaEmail()) {
                    bottomUsernameLoginButton.setText(loginlang.getLoginViaEmail());
                }

                bottomUsernameLoginButton.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(PhoneNumberActivity.this, LoginActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(intent);
                    }
                });
            } else {
                bottomUsernameLoginButton.setVisibility(View.GONE);
            }

            // Social auth
            if ("1".equals(mobileConfig.getSocialAuthEnabled()) && ("1".equals(mobileConfig.getFacebookEnabled()) || "1".equals(mobileConfig.getGoogleEnabled()) || "1".equals(mobileConfig.getTwitterEnabled()))) {
                bottomSocialLoginButton.setVisibility(View.VISIBLE);
                if (null != mobilelangs && null != mobilelangs.get150()) {
                    bottomSocialLoginButton.setText(mobilelangs.get150());
                }
                bottomSocialLoginButton.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(PhoneNumberActivity.this, SocialAuthActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(intent);
                    }
                });
            } else {
                bottomSocialLoginButton.setVisibility(View.GONE);
            }

            // Guest login
            if ("1".equals(mobileConfig.getGuestEnabled())) {
                bottomGuestLoginButton.setVisibility(View.VISIBLE);
                if (null != mobilelangs && null != mobilelangs.get146()) {
                    bottomGuestLoginButton.setText(mobilelangs.get146());
                }
                bottomGuestLoginButton.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent intent = new Intent(PhoneNumberActivity.this, GuestLoginActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(intent);
                    }
                });
            } else {
                bottomGuestLoginButton.setVisibility(View.GONE);
            }
        } else if (LocalConfig.LOGIN_TYPE == 1) {

            /*** Old apps ***/

            // Username password login
            bottomUsernameLoginButton.setVisibility(View.VISIBLE);
            if (null != mobilelangs && null != mobilelangs.get147()) {
                bottomUsernameLoginButton.setText(mobilelangs.get147());
            } else if (null != loginlang && null != loginlang.getLoginViaEmail()) {
                bottomUsernameLoginButton.setText(loginlang.getLoginViaEmail());
            }

            bottomUsernameLoginButton.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(PhoneNumberActivity.this, LoginActivity.class);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    startActivity(intent);
                }
            });
        } else {
            bottomUsernameLoginButton.setVisibility(View.GONE);
            bottomGuestLoginButton.setVisibility(View.GONE);
            bottomSocialLoginButton.setVisibility(View.GONE);
        }
    }

    private void applyThemeColor() {
        try {
            Drawable myIcon = getResources().getDrawable(R.drawable.ic_custom_back_arrow);
            myIcon.setColorFilter(Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN), PorterDuff.Mode.SRC_ATOP);
            backButton.setImageDrawable(myIcon);
            if (null != theme && null != theme.getLoginButton() && null != theme.getLoginButtonText() && null != theme.getLoginText()) {
                int btnColor = Color.parseColor(theme.getLoginButton());
                int textColor = Color.parseColor(theme.getLoginButtonText());
                int fieldTextColor = Color.parseColor(theme.getLoginText());
                submitBtn.setBackgroundColor(btnColor);
                submitBtn.setTextColor(textColor);

                bottomGuestLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomSocialLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomUsernameLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomGuestLoginButton.setTextColor(btnColor);
                bottomSocialLoginButton.setTextColor(btnColor);
                bottomUsernameLoginButton.setTextColor(btnColor);

                myIcon.setColorFilter(btnColor, PorterDuff.Mode.SRC_ATOP);
                backButton.setImageDrawable(myIcon);
                phoneNumberField.setTextColor(fieldTextColor);
                phoneCountryCode.setTextColor(fieldTextColor);
                wheel.setBarColor(btnColor);
            } else if (null != theme && null != theme.getLoginButtonPressed() && null != theme.getLoginForegroundText()) {
                int btnColor = Color.parseColor(theme.getLoginButtonPressed());
                int textColor = Color.parseColor(theme.getLoginForegroundText());
                submitBtn.setBackgroundColor(btnColor);
                submitBtn.setTextColor(textColor);

                bottomGuestLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomSocialLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomUsernameLoginButton.getBackground().setColorFilter(new
                        LightingColorFilter(Color.WHITE, btnColor));
                bottomGuestLoginButton.setTextColor(btnColor);
                bottomSocialLoginButton.setTextColor(btnColor);
                bottomUsernameLoginButton.setTextColor(btnColor);

                myIcon.setColorFilter(btnColor, PorterDuff.Mode.SRC_ATOP);
                backButton.setImageDrawable(myIcon);
                phoneNumberField.setTextColor(textColor);
                phoneCountryCode.setTextColor(textColor);
                wheel.setBarColor(btnColor);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent intent) {
        super.onActivityResult(requestCode, resultCode, intent);
        Logger.error("onActivityResult" + resultCode);

        if (resultCode == RESULT_OK) {
            if (requestCode == 1 && intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.SELECTED_COUNTRY_CODE)) {
                list.clear();
                list.add(intent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.SELECTED_COUNTRY_NAME));
                dataAdapter.notifyDataSetChanged();
                phoneCountryCode.setText(country2phone.get(intent
                        .getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.SELECTED_COUNTRY_CODE)));
            }
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putString(EDIT_TEXT_PHONE_NUMBER, phoneNumberField.getText().toString());
    }

    @Override
    public void finish() {
        super.finish();
        stopWheel();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        stopWheel();
    }

    private void stopWheel() {
        wheel.setProgress(0f);
        wheel.stopSpinning();
        wheel.setVisibility(View.INVISIBLE);
    }

    private void startWheel() {
        wheel.spin();
        wheel.setVisibility(View.VISIBLE);
    }

    static {
        country2phone.put("AF", "+93");
        country2phone.put("AL", "+355");
        country2phone.put("DZ", "+213");
        country2phone.put("AS", "+1");
        country2phone.put("AD", "+376");
        country2phone.put("AO", "+244");
        country2phone.put("AI", "+1");
        country2phone.put("AG", "+1");
        country2phone.put("AR", "+54");
        country2phone.put("AM", "+374");
        country2phone.put("AW", "+297");
        country2phone.put("AU", "+61");
        country2phone.put("AC", "+247");
        country2phone.put("AT", "+43");
        country2phone.put("AZ", "+994");
        country2phone.put("BS", "+1");
        country2phone.put("BH", "+973");
        country2phone.put("BD", "+880");
        country2phone.put("BB", "+1");
        country2phone.put("BY", "+375");
        country2phone.put("BE", "+32");
        country2phone.put("BZ", "+501");
        country2phone.put("BJ", "+229");
        country2phone.put("BM", "+1");
        country2phone.put("BT", "+975");
        country2phone.put("BO", "+591");
        country2phone.put("BA", "+387");
        country2phone.put("BW", "+267");
        country2phone.put("BR", "+55");
        country2phone.put("VG", "+1");
        country2phone.put("BN", "+673");
        country2phone.put("IO", "+246");
        country2phone.put("BG", "+359");
        country2phone.put("BF", "+226");
        country2phone.put("BI", "+257");
        country2phone.put("MM", "+95");
        country2phone.put("KH", "+855");
        country2phone.put("CM", "+237");
        country2phone.put("CA", "+1");
        country2phone.put("CV", "+238");
        country2phone.put("KY", "+1");
        country2phone.put("CF", "+236");
        country2phone.put("TD", "+235");
        country2phone.put("CL", "+56");
        country2phone.put("CN", "+86");
        country2phone.put("CX", "+61");
        country2phone.put("CC", "+61");
        country2phone.put("CO", "+57");
        country2phone.put("KM", "+269");
        country2phone.put("CD", "+243");
        country2phone.put("CG", "+242");
        country2phone.put("CK", "+682");
        country2phone.put("CR", "+506");
        country2phone.put("HR", "+385");
        country2phone.put("CI", "+225");
        country2phone.put("CU", "+53");
        country2phone.put("CY", "+357");
        country2phone.put("AN", "+599");
        country2phone.put("CZ", "+420");
        country2phone.put("DK", "+45");
        country2phone.put("DJ", "+253");
        country2phone.put("DM", "+1");
        country2phone.put("DO", "+1");
        country2phone.put("DO", "+1");
        country2phone.put("EC", "+593");
        country2phone.put("TL", "+670");
        country2phone.put("EG", "+20");
        country2phone.put("SV", "+503");
        country2phone.put("GQ", "+240");
        country2phone.put("ER", "+291");
        country2phone.put("EE", "+372");
        country2phone.put("ET", "+251");
        country2phone.put("FK", "+500");
        country2phone.put("FO", "+298");
        country2phone.put("FJ", "+679");
        country2phone.put("FI", "+358");
        country2phone.put("FR", "+33");
        country2phone.put("PF", "+689");
        country2phone.put("GA", "+241");
        country2phone.put("GF", "+594");
        country2phone.put("GM", "+220");
        country2phone.put("GE", "+995");
        country2phone.put("DE", "+49");
        country2phone.put("PS", "+970");
        country2phone.put("GH", "+233");
        country2phone.put("GI", "+350");
        country2phone.put("GR", "+30");
        country2phone.put("GL", "+299");
        country2phone.put("GD", "+1");
        country2phone.put("GU", "+1");
        country2phone.put("GP", "+590");
        country2phone.put("GT", "+502");
        country2phone.put("GN", "+224");
        country2phone.put("GW", "+245");
        country2phone.put("PY", "+595");
        country2phone.put("GY", "+592");
        country2phone.put("HT", "+509");
        country2phone.put("IT", "+39");
        country2phone.put("HN", "+504");
        country2phone.put("HK", "+852");
        country2phone.put("HU", "+36");
        country2phone.put("IS", "+354");
        country2phone.put("IN", "+91");
        country2phone.put("ID", "+62");
        country2phone.put("IR", "+98");
        country2phone.put("IQ", "+964");
        country2phone.put("IE", "+353");
        country2phone.put("IL", "+972");
        country2phone.put("GB", "+44");
        country2phone.put("JM", "+1");
        country2phone.put("JP", "+81");
        country2phone.put("JO", "+962");
        country2phone.put("KZ", "+7");
        country2phone.put("KE", "+254");
        country2phone.put("KI", "+686");
        country2phone.put("KP", "+850");
        country2phone.put("KR", "+82");
        country2phone.put("KW", "+965");
        country2phone.put("KG", "+996");
        country2phone.put("LA", "+856");
        country2phone.put("LV", "+371");
        country2phone.put("LB", "+961");
        country2phone.put("LS", "+266");
        country2phone.put("LR", "+231");
        country2phone.put("LY", "+218");
        country2phone.put("LI", "+423");
        country2phone.put("LT", "+370");
        country2phone.put("LU", "+352");
        country2phone.put("MO", "+853");
        country2phone.put("MK", "+389");
        country2phone.put("MG", "+261");
        country2phone.put("MW", "+265");
        country2phone.put("MY", "+60");
        country2phone.put("MV", "+960");
        country2phone.put("ML", "+223");
        country2phone.put("MT", "+356");
        country2phone.put("MH", "+692");
        country2phone.put("MR", "+222");
        country2phone.put("MQ", "+596");
        country2phone.put("MU", "+230");
        country2phone.put("YT", "+262");
        country2phone.put("MX", "+52");
        country2phone.put("FM", "+691");
        country2phone.put("MD", "+373");
        country2phone.put("MC", "+377");
        country2phone.put("MN", "+976");
        country2phone.put("ME", "+382");
        country2phone.put("MS", "+1");
        country2phone.put("MA", "+212");
        country2phone.put("MZ", "+258");
        country2phone.put("NA", "+264");
        country2phone.put("NR", "+674");
        country2phone.put("NP", "+977");
        country2phone.put("NL", "+31");
        country2phone.put("NC", "+687");
        country2phone.put("NZ", "+64");
        country2phone.put("NI", "+505");
        country2phone.put("NE", "+227");
        country2phone.put("NG", "+234");
        country2phone.put("NU", "+683");
        country2phone.put("MP", "+1");
        country2phone.put("NO", "+47");
        country2phone.put("OM", "+968");
        country2phone.put("PK", "+92");
        country2phone.put("PW", "+680");
        country2phone.put("PA", "+507");
        country2phone.put("PG", "+675");
        country2phone.put("PE", "+51");
        country2phone.put("PH", "+63");
        country2phone.put("PL", "+48");
        country2phone.put("PT", "+351");
        country2phone.put("PR", "+1");
        country2phone.put("PR", "+1");
        country2phone.put("QA", "+974");
        country2phone.put("RE", "+262");
        country2phone.put("RO", "+40");
        country2phone.put("RU", "+7");
        country2phone.put("RW", "+250");
        country2phone.put("SH", "+290");
        country2phone.put("KN", "+1");
        country2phone.put("LC", "+1");
        country2phone.put("VC", "+1");
        country2phone.put("WS", "+685");
        country2phone.put("SM", "+378");
        country2phone.put("ST", "+239");
        country2phone.put("SA", "+966");
        country2phone.put("SN", "+221");
        country2phone.put("RS", "+381");
        country2phone.put("SC", "+248");
        country2phone.put("SL", "+232");
        country2phone.put("SG", "+65");
        country2phone.put("SK", "+421");
        country2phone.put("SI", "+386");
        country2phone.put("SB", "+677");
        country2phone.put("SO", "+252");
        country2phone.put("ZA", "+27");
        country2phone.put("ES", "+34");
        country2phone.put("LK", "+94");
        country2phone.put("SD", "+249");
        country2phone.put("SR", "+597");
        country2phone.put("SZ", "+268");
        country2phone.put("SE", "+46");
        country2phone.put("CH", "+41");
        country2phone.put("SY", "+963");
        country2phone.put("TW", "+886");
        country2phone.put("TJ", "+992");
        country2phone.put("TZ", "+255");
        country2phone.put("TH", "+66");
        country2phone.put("TG", "+228");
        country2phone.put("TO", "+676");
        country2phone.put("TK", "+690");
        country2phone.put("TT", "+1");
        country2phone.put("TN", "+216");
        country2phone.put("TR", "+90");
        country2phone.put("TM", "+993");
        country2phone.put("TC", "+1");
        country2phone.put("TV", "+688");
        country2phone.put("UG", "+256");
        country2phone.put("UA", "+380");
        country2phone.put("AE", "+971");
        country2phone.put("US", "+1");
        country2phone.put("UY", "+598");
        country2phone.put("VI", "+1");
        country2phone.put("UZ", "+998");
        country2phone.put("VU", "+678");
        country2phone.put("VA", "+379");
        country2phone.put("VE", "+58");
        country2phone.put("VN", "+84");
        country2phone.put("WF", "+681");
        country2phone.put("YE", "+967");
        country2phone.put("ZM", "+260");
        country2phone.put("ZW", "+263");
        country2phone.put("GE", "+995");
        country2phone.put("NF", "+672");
        country2phone.put("PM", "+508");
        country2phone.put("IM", "+44");
        country2phone.put("JE", "+44");
        country2phone.put("SJ", "+47");
        country2phone.put("EH", "+212");
        country2phone.put("AX", "+358");
        country2phone.put("PN", "+870");
        country2phone.put("AQ", "+672");
        country2phone.put("BV", "+74");

    }
}
