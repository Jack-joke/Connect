package com.inscripts.activities;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.annotation.ColorInt;
import android.support.design.widget.TextInputLayout;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
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

import java.lang.reflect.Field;
import java.util.regex.Pattern;

public class UrlInitializerActivityNew extends SuperActivity {

    private ImageView imgCometChatLogo,imgBackArrow;
    private Button btnUrlLoginButton;
    private TextView tvTryDemo;
    private String initialUrl,noInternetError;
    private EditText baseURLField;
    private ProgressWheel wheel;
    private Lang lang;
    private Mobile mobileLangs;
    private TextInputLayout tilBaseUrl;
    private boolean noInternet = false;
    RelativeLayout containerTryDemo;
    private static String guestPassword = "CC^CONTROL_GUEST";
    private int buttonClickStatus = 1; //1 for checkurl and 2 for try a demo
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        WindowManager.LayoutParams attributes = getWindow().getAttributes();
        attributes.flags |= WindowManager.LayoutParams.FLAG_FULLSCREEN;
        getWindow().setAttributes(attributes);
        getSupportActionBar().hide();

        setContentView(R.layout.activity_url_initializer_activity_new);



        btnUrlLoginButton = (Button) findViewById(R.id.buttonDemoLogin);
        tvTryDemo = (TextView) findViewById(R.id.textViewTryDemo);
        baseURLField = (EditText) findViewById(R.id.editTextURL);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        tilBaseUrl = (TextInputLayout) findViewById(R.id.input_layout_txt_url);
        imgCometChatLogo = (ImageView) findViewById(R.id.imageViewCometchatLogo);
        imgBackArrow = (ImageView) findViewById(R.id.ic_back_arrow);
        containerTryDemo = (RelativeLayout) findViewById(R.id.container_try_demo);



        if(null != PreferenceHelper.get(PreferenceKeys.LoginKeys.INITIAL_URL))
        baseURLField.setText(PreferenceHelper.get(PreferenceKeys.LoginKeys.INITIAL_URL));

        lang = JsonPhp.getInstance().getLang();
        if (null != lang) {
            mobileLangs = lang.getMobile();
        }
        PreferenceHelper.initialize(this);


        setThemeColor();
        
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

        baseURLField.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {
            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                baseURLField.setError(null);
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });


        tvTryDemo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                tilBaseUrl.setHint("Guest Name");
                buttonClickStatus = 2;
                baseURLField.setText("");
                imgBackArrow.setVisibility(View.VISIBLE);
                containerTryDemo.setVisibility(View.GONE);
                tilBaseUrl.setError(null);
            }
        });

        imgBackArrow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                tilBaseUrl.setHint("Website URL");
                buttonClickStatus = 1;
                imgBackArrow.setVisibility(View.GONE);
                containerTryDemo.setVisibility(View.VISIBLE);
            }
        });

        btnUrlLoginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                initialUrl = baseURLField.getText().toString().trim();
                tilBaseUrl.setError(null);


                if(buttonClickStatus == 1){
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
                            LoginHelper.checkDomain(UrlInitializerActivityNew.this, initialUrl, new VolleyAjaxCallbacks() {

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
                                                                UrlInitializerActivityNew.this);
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
                                                                tilBaseUrl.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                                                                tilBaseUrl.setEnabled(true);
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
                                                LoginHelper.checkLoginTypeAndStart(UrlInitializerActivityNew.this);
                                                baseURLField.setEnabled(true);
                                                dismissProgressWheel();
                                            }

                                            @Override
                                            public void failCallback() {
                                                tilBaseUrl.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                                                baseURLField.setEnabled(true);
                                                dismissProgressWheel();
                                            }
                                        });
                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (!isNoInternet) {
                                        if (response.contains(StaticMembers.DOMAIN_ERROR)) {
                                            Toast.makeText(UrlInitializerActivityNew.this, StaticMembers.DOMAIN_ERROR, Toast.LENGTH_LONG).show();
                                        } else {
                                            tilBaseUrl.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                                        }
                                        baseURLField.setEnabled(true);
                                        dismissProgressWheel();
                                    } else {
                                        if (noInternetError != null && !noInternetError.isEmpty())
                                            Toast.makeText(UrlInitializerActivityNew.this, noInternetError, Toast.LENGTH_LONG).show();
                                        else
                                            Toast.makeText(UrlInitializerActivityNew.this, "No Internet Connection", Toast.LENGTH_LONG).show();
                                        dismissProgressWheel();
                                        baseURLField.setEnabled(true);
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
                                    LoginHelper.checkLoginTypeAndStart(UrlInitializerActivityNew.this);
                                    baseURLField.setEnabled(true);
                                    dismissProgressWheel();
                                }

                                @Override
                                public void failCallback() {
                                    tilBaseUrl.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                                    baseURLField.setEnabled(true);
                                    dismissProgressWheel();
                                }
                            });
                        }
                    } else {
                        // Invalid URL
                        if (null != lang) {
                            tilBaseUrl.setError(lang.getMobile().get48());
                        } else {
                            tilBaseUrl.setError(StaticMembers.JsonPhpLangs.INVALID_URL_MESSAGE);
                            //tilBaseUrl.setti
                        }
                        dismissProgressWheel();
                        baseURLField.setEnabled(true);
                    }
                }else{

                    PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, LocalConfig.DEMO_SITE_URL);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                            StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO, "1");


                    final String name = baseURLField.getText().toString().trim();
                    if (TextUtils.isEmpty(name)) {
                        if (null != mobileLangs && null != mobileLangs.get149()) {
                            tilBaseUrl.setError(mobileLangs.get149());
                        } else {
                            tilBaseUrl.setError("Please enter guest name");
                        }
                        dismissProgressWheel();
                    } else {
                        wheel.setVisibility(View.VISIBLE);
                        wheel.spin();

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
                                                        Intent intent = new Intent(UrlInitializerActivityNew.this, CometChatActivity.class);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                        startActivity(intent);
                                                        finish();
                                                        dismissProgressWheel();
                                                    }

                                                    @Override
                                                    public void failCallback() {
                                                        Logger.error("JSONPhp not found");
                                                        Intent intent = new Intent(UrlInitializerActivityNew.this, CometChatActivity.class);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                        startActivity(intent);
                                                        finish();
                                                        dismissProgressWheel();
                                                    }
                                                });
                                            } else {
                                                Logger.error("Starting chat");
                                                Intent intent = new Intent(UrlInitializerActivityNew.this, CometChatActivity.class);
                                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                                startActivity(intent);
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
                                    LoginActivity.showVersionErrorPopUp(UrlInitializerActivityNew.this);
                                    dismissProgressWheel();
                                }
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {
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
    }


    private void setThemeColor(){
        btnUrlLoginButton.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        imgBackArrow.setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        tvTryDemo.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        setInputTextLayoutColor(baseURLField,Color.parseColor("#a2a2a5"));
        wheel.setBarColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));

        imgCometChatLogo.setColorFilter(Color.BLACK, PorterDuff.Mode.SRC_ATOP);
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

    private void dismissProgressWheel() {
        wheel.setProgress(0f);
        wheel.stopSpinning();
        wheel.setVisibility(View.INVISIBLE);
    }
}
