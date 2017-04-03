/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.webkit.CookieManager;
import android.webkit.CookieSyncManager;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;

import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;


public class CoDLoginActivity extends SuperActivity {

    private String codCode = "";
    //private final static String COD_NAMESPACE = "androidCometChat";
    private WebView codloginview;
    private ProgressBar pBar;
    private String url;

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                finish();
                break;
        }
        return super.onOptionsItemSelected(item);
    }

    @SuppressLint("NewApi")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_cod_login);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        Intent intent = getIntent();

        if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.COD_CODE)) {
            codCode = intent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.COD_CODE);
        } else {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.COD_ID)) {
                codCode = PreferenceHelper.get(PreferenceKeys.DataKeys.COD_ID);
            }
        }
        pBar = (ProgressBar) findViewById(R.id.progressBarWebView);
        codloginview = (WebView) findViewById(R.id.webViewCodLogin);
        codloginview.getSettings().setJavaScriptEnabled(true);
        /*if (!TextUtils.isEmpty(LocalConfig.getSiteUrl())) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        }*/

        try {
            codloginview.setWebViewClient(new WebViewClient() {

                @Override
                public void onPageStarted(WebView view, String url, Bitmap favicon) {
                    super.onPageStarted(view, url, favicon);
                    CookieSyncManager cookieSyncManager = CookieSyncManager.createInstance(codloginview.getContext());
                    CookieManager cookieManager = CookieManager.getInstance();
                    cookieManager.setAcceptCookie(true);
                    cookieManager.setCookie(url, "cc_platform_cod=android;");
                    cookieSyncManager.sync();
                }


                @Override
                public void onPageFinished(WebView view, final String url) {
                    setActionBarTitle(view.getTitle());
                    Logger.error("URL" + url + " cookies" + CookieManager.getInstance().getCookie(url));
                    String cookies = CookieManager.getInstance().getCookie(url).trim(), baseData = "";
                    //Logger.error("cookies =" + cookies);
                    String[] temp = cookies.split(";");
                    for (String ar1 : temp) {
                        ar1 = ar1.trim();
                        if (ar1.contains(codCode + "cc_data")) {
                            String[] temp1 = ar1.split("=");
                            baseData = temp1[1].trim();
                        }
                    }

                    if (!TextUtils.isEmpty(baseData)) {
                        try {
                            JSONObject basedataResponse = new JSONObject(new String(CommonUtils.decodeBase64(baseData), "UTF-8"));
                            if (basedataResponse.has("id")) {
                                String userId = basedataResponse.getString("id");
                                if (!TextUtils.isEmpty(userId)) {
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                                    SessionData.getInstance().setBaseData(baseData);
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD, "1");
                                    Intent intent = new Intent(CoDLoginActivity.this, CometChatActivity.class);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    startActivity(intent);


                                    CoDLoginActivity.this.runOnUiThread(new Runnable() {
                                        @Override
                                        public void run() {
                                            if (null != codloginview) {
                                                //CookieSyncManager syncManager = CookieSyncManager.createInstance(codloginview.getContext());
                                                CookieSyncManager.createInstance(getApplicationContext());
                                                CookieManager cookieManager = CookieManager.getInstance();
                                                if(android.os.Build.VERSION.SDK_INT >= 21){
                                                    cookieManager.removeAllCookies(null);
                                                }else{
                                                    cookieManager.removeAllCookie();
                                                }

                                                codloginview.clearHistory();
                                                codloginview.clearCache(true);
                                                codloginview.clearMatches();
                                            }
                                        }
                                    });
                                    finish();
                                }
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                }
            });
            codloginview.setWebChromeClient(new WebChromeClient() {

                @Override
                public void onProgressChanged(WebView view, int progress) {
                    super.onProgressChanged(view, progress);
                    if (progress < 100 && pBar.getVisibility() == View.GONE) {
                        pBar.setVisibility(View.VISIBLE);
                    }
                    pBar.setProgress(progress);
                    if (progress == 100) {
                        pBar.setVisibility(View.GONE);
                    }
                }
            });

        }catch (Exception e){
            e.printStackTrace();
        }


       /* CustomJavaScriptInterface js = new CustomJavaScriptInterface() {

            @Override
            @JavascriptInterface
            public void sendToMobile(String baseData) {
                try {
                    PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, baseData);
                    SessionData.getInstance().setBaseData(baseData);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN, CometChatKeys.LoginKeys.USER_LOGGED_IN);
                    PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD,"1");
                    Intent intent = new Intent(CoDLoginActivity.this, CometChatActivity.class);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    startActivity(intent);
                    finish();

                    CoDLoginActivity.this.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (null != codloginview) {
                                codloginview.clearHistory();
                                codloginview.clearCache(true);
                                codloginview.clearMatches();
                            }
                        }
                    });
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };*/



        codloginview.clearCache(true);
        //codloginview.addJavascriptInterface(js, COD_NAMESPACE);
        String url = intent.getStringExtra("Url");
        Map<String, String> noCacheHeaders = new HashMap<>(2);
        noCacheHeaders.put("Pragma", "no-cache");
        noCacheHeaders.put("Cache-Control", "no-cache");
        //codloginview.getSettings().setUserAgentString(COD_NAMESPACE);
        codloginview.getSettings().setCacheMode(WebSettings.LOAD_NO_CACHE);
        codloginview.getSettings().setAppCacheEnabled(false);
        codloginview.getSettings().setSaveFormData(false);
        //this.deleteDatabase("webview.db");
        //this.deleteDatabase("webviewCache.db");
        //String newUA= "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.4) Gecko/20100101 Firefox/34.0";
        String newUA = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.152 Safari/537.36";
        codloginview.getSettings().setUserAgentString(newUA);
        codloginview.clearHistory();
        /*String postData = "platform=brandedapp";
        codloginview.postUrl(url, EncodingUtils.getBytes(postData, "BASE64"));*/
        codloginview.loadUrl(url, noCacheHeaders);

    }
}
