/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.text.TextUtils;
import android.view.View;
import android.widget.RelativeLayout;
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
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONException;
import org.json.JSONObject;

public class SplashScreenActivity extends Activity {

    private Mobile mobileLangs;
    private Lang lang;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_splash_screen);
        PreferenceHelper.initialize(getApplicationContext());

        LocalConfig.initialize(this);
        PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,"#56a8e3");
        PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,"#3177a8");

        RelativeLayout relativeLayout = (RelativeLayout) findViewById(R.id.splash_container);
        relativeLayout.setBackgroundColor(Color.parseColor(LocalConfig.getSplashBackgroundColor()));

       /* TelephonyManager telephonyManager = (TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE);


        JSONObject deviceInfo = new JSONObject();

        try {
            PackageInfo packageinfo = getPackageManager().getPackageInfo(getPackageName(), 0);
            deviceInfo.put("d",android.os.Build.MODEL);
//            deviceInfo.put("imei",telephonyManager.getDeviceId());
            JSONObject os = new JSONObject();
            os.put("n","a");
            os.put("v",android.os.Build.VERSION.SDK_INT);
            deviceInfo.put("os",os);
            deviceInfo.put("v",packageinfo.versionName.toString());

        } catch (JSONException e) {
            e.printStackTrace();
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        PreferenceHelper.save(PreferenceKeys.UserKeys.DEVICE_INFO,deviceInfo.toString());*/


       /* PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY,"#002832");
        PreferenceHelper.save(PreferenceKeys.Colors.COLOR_PRIMARY_DARK,"#002832");*/

        JSONObject deviceInfo = new JSONObject();

        try {
            PackageInfo packageinfo = getPackageManager().getPackageInfo(getPackageName(), 0);
            deviceInfo.put("d",android.os.Build.MODEL);
            JSONObject os = new JSONObject();
            os.put("n","a");
            os.put("v",android.os.Build.VERSION.SDK_INT);
            deviceInfo.put("os",os);
            deviceInfo.put("v",packageinfo.versionName.toString());

        } catch (JSONException e) {
            e.printStackTrace();
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }
        PreferenceHelper.save(PreferenceKeys.UserKeys.DEVICE_INFO,deviceInfo.toString());
        final boolean isLoggedIn = PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN)
                && CometChatKeys.LoginKeys.USER_LOGGED_IN.equals(PreferenceHelper
                .get(PreferenceKeys.LoginKeys.LOGGED_IN));

        final ProgressWheel wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        wheel.setVisibility(View.VISIBLE);
        wheel.spin();
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.BASE_DATA)) {
            SessionData.getInstance().setBaseData(PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
        } else {
            PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA,"");
            SessionData.getInstance().setBaseData("");
        }
        lang = JsonPhp.getInstance().getLang();

        if (null != lang) {
            mobileLangs = lang.getMobile();
        }
        if (!CommonUtils.isConnected()){
            if (null != mobileLangs) {
                if (null != mobileLangs.get24()){
                    Toast.makeText(getApplicationContext(), mobileLangs.get24(), Toast.LENGTH_SHORT).show();
                }else{
                    Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                }
            }else{
                Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
            }
        }

        if (isLoggedIn) {

            // Fetch json.php and start CometChatActivity

            String url = LocalConfig.getSiteUrl();
            if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.BASE_URL)) {
                url = PreferenceHelper.get(PreferenceKeys.LoginKeys.BASE_URL);
            }

            if (!LocalConfig.getIsCOD().isEmpty() && LocalConfig.getIsCOD().equals("1")){
                LoginHelper.checkDomain(SplashScreenActivity.this, url, new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                            @Override
                            public void successCallback() {
                                Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                startActivity(intent);
                                finish();
                                wheel.setVisibility(View.GONE);
                            }

                            @Override
                            public void failCallback() {
                                if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                                    Toast.makeText(SplashScreenActivity.this, "No language or theme present", Toast.LENGTH_LONG).show();
                                }
                                Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                startActivity(intent);
                                finish();
                                wheel.setVisibility(View.GONE);
                            }
                        });
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            startActivity(intent);
                            finish();
                        } else {
                            if (response.equals(StaticMembers.DOMAIN_ERROR)) {
                                Toast.makeText(getApplicationContext(), response, Toast.LENGTH_LONG).show();
                            } else {
                                Logger.error("Check domain faiiled isloggedin");
                                Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                startActivity(intent);
                                finish();
                            }
                        }
                        wheel.setVisibility(View.GONE);
                    }
                });
            }else{
                PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                    @Override
                    public void successCallback() {
                        Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        startActivity(intent);
                        finish();
                        wheel.setVisibility(View.GONE);
                    }

                    @Override
                    public void failCallback() {
                        if (!PreferenceHelper.contains(PreferenceKeys.DataKeys.JSON_PHP_DATA)) {
                            Toast.makeText(SplashScreenActivity.this, "No language or theme present", Toast.LENGTH_LONG).show();
                        }
                        Intent intent = new Intent(SplashScreenActivity.this, CometChatActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                        startActivity(intent);
                        finish();
                        wheel.setVisibility(View.GONE);
                    }
                });
            }

        } else {
            if (TextUtils.isEmpty(LocalConfig.getSiteUrl())) {

                // Stock app
                new Handler().postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        Intent intent = new Intent(SplashScreenActivity.this, UrlInitializerActivityNew.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        startActivity(intent);
                        finish();
                    }
                }, LocalConfig.SPLASH_TIMEOUT);
            } else {

                // White labelled
                LoginHelper.checkDomain(SplashScreenActivity.this, LocalConfig.getSiteUrl(), new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(final String response) {

                        // response contains the URL to be used for json.php
                        PreferenceHelper.save(PreferenceKeys.LoginKeys.BASE_URL, response);
                        PreferenceHelper.save(PreferenceKeys.LoginKeys.COMETCHAT_FOLDER,
                                StaticMembers.COMETCHAT_LOGINURL_SUFFIX_0);

                        /* COD Whitelabel */

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
                                                    SplashScreenActivity.this);
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
                                                }

                                                @Override
                                                public void failCallback() {
                                                    Toast.makeText(SplashScreenActivity.this, StaticMembers.DOMAIN_ERROR, Toast.LENGTH_LONG).show();
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
                                    LoginHelper.checkLoginTypeAndStart(SplashScreenActivity.this);
                                    overridePendingTransition(0,0);
                                }

                                @Override
                                public void failCallback() {
                                    Toast.makeText(SplashScreenActivity.this, StaticMembers.DOMAIN_ERROR, Toast.LENGTH_LONG).show();
                                }
                            });
                        }

                        /* COD Whitelabel */

                        PreferenceHelper.searchJsonPhp(new CometchatCallbacks() {

                            @Override
                            public void successCallback() {
                                boolean isPhonenumberType = false;
                                if (LocalConfig.isWhiteLabelled()) {
                                    MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
                                    if (null != mobileConfig) {
                                        if ("1".equals(mobileConfig.getPhoneNumberEnabled()) || "2".equals(mobileConfig.getPhoneNumberEnabled())) {
                                            isPhonenumberType = true;
                                        }
                                    } else if (LocalConfig.LOGIN_TYPE == 2 || LocalConfig.LOGIN_TYPE == 3) {
                                        isPhonenumberType = true;
                                    }
                                }
                                if (isPhonenumberType) {
                                    Intent loginIntent;
                                    if ("1".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.REGISTRATION_STATUS))) {
                                        // Number is registered. Go to
                                        // verification
                                        // screen.
                                        loginIntent = new Intent(getApplicationContext(), VerificationActivity.class);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                        startActivity(loginIntent);
                                    } else if ("2".equals(PreferenceHelper
                                            .get(PreferenceKeys.DataKeys.REGISTRATION_STATUS))) {
                                        // Number is verified. Go to Create
                                        // profile
                                        // screen.
                                        loginIntent = new Intent(getApplicationContext(), CreateProfileActivity.class);
                                        loginIntent.putExtra(PreferenceKeys.DataKeys.TEMP_ID,
                                                PreferenceHelper.get(PreferenceKeys.DataKeys.TEMP_ID));
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                        startActivity(loginIntent);
                                    } else if ("3".equals(PreferenceHelper
                                            .get(PreferenceKeys.DataKeys.REGISTRATION_STATUS))) {
                                        loginIntent = new Intent(getApplicationContext(), CometChatActivity.class);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                        startActivity(loginIntent);
                                    } else {
                                        // Fresh number.
                                        loginIntent = new Intent(getApplicationContext(), PhoneNumberActivity.class);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                        loginIntent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                        startActivity(loginIntent);
                                    }
                                } else {
                                    LoginHelper.checkLoginTypeAndStart(SplashScreenActivity.this);
                                }
                                wheel.setVisibility(View.INVISIBLE);
                                finish();
                            }

                            @Override
                            public void failCallback() {
                                Toast.makeText(SplashScreenActivity.this, StaticMembers.DOMAIN_ERROR, Toast.LENGTH_LONG).show();
                                wheel.setVisibility(View.INVISIBLE);
                            }
                        });
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        wheel.setVisibility(View.INVISIBLE);
                        if (isNoInternet) {
                            Toast.makeText(getApplicationContext(), StaticMembers.PLEASE_CHECK_YOUR_INTERNET, Toast.LENGTH_SHORT).show();
                        } else {
                            if (response.equals(StaticMembers.DOMAIN_ERROR)) {
                                Toast.makeText(SplashScreenActivity.this, response, Toast.LENGTH_LONG).show();
                            } else {
                                Logger.error("Check domain failed is not loggedin");
                            }
                        }
                    }
                });
            }
        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        if (!CommonUtils.isConnected()){
            if (null != mobileLangs) {
                if (null != mobileLangs.get24()){
                    Toast.makeText(getApplicationContext(), mobileLangs.get24(), Toast.LENGTH_SHORT).show();
                }else{
                    Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
                }
            }else{
                Toast.makeText(getApplicationContext(), "Unable to connect. Please check your internet connection.", Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    public void onBackPressed() {
        //Do Nothing
    }
}