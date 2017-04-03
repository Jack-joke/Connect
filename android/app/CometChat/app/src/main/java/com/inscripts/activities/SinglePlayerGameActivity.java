/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;


import android.os.Bundle;
import android.webkit.ConsoleMessage;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.SuperActivity;

public class SinglePlayerGameActivity extends SuperActivity {

    private WebView webView;
    String mFirstUrlLoaded = "";
    private Lang language;
    private Mobile mobileLangs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_single_player_game);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        language = JsonPhp.getInstance().getLang();
        mobileLangs = language.getMobile();
        if (null != mobileLangs && null != mobileLangs.get176()) {
            setActionBarTitle(mobileLangs.get176());
        }else{
            setActionBarTitle("Single Player Games");
        }
        webView = (WebView) findViewById(R.id.webview);
        webView.getSettings().setUseWideViewPort(true);
        webView.getSettings().setLoadWithOverviewMode(false);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.setVerticalScrollBarEnabled(true);
        webView.setHorizontalScrollbarOverlay(true);
        webView.loadUrl(URLFactory.getSinglePlayerGameURL());
        mFirstUrlLoaded = URLFactory.getSinglePlayerGameURL();
        //webView.getSettings().setBuiltInZoomControls(true);

        webView.setWebViewClient(new WebViewClient() {

            @Override
            public boolean shouldOverrideUrlLoading(WebView view, String url) {
                if (!mFirstUrlLoaded.equals(url)){
                    webView.getSettings().setLoadWithOverviewMode(true);
                    getSupportActionBar().hide();
                }
                return super.shouldOverrideUrlLoading(view, url);
            }
        });


        webView.setWebChromeClient(new WebChromeClient() {
            @Override
            public boolean onConsoleMessage(ConsoleMessage consoleMessage) {
                super.onConsoleMessage(consoleMessage);
                return true;
            }
        });
    }

    @Override
    protected void onPause() {
        super.onPause();
    }

    @Override
    public void onBackPressed() {

        if (!mFirstUrlLoaded.equals(webView.getUrl())) {
            webView.loadUrl(URLFactory.getSinglePlayerGameURL());
            webView.getSettings().setLoadWithOverviewMode(false);
            getSupportActionBar().show();
        } else {
            super.onBackPressed();
        }
    }
}