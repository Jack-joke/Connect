/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.View;
import android.webkit.CookieManager;
import android.webkit.CookieSyncManager;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;

import com.inscripts.R;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;

public class WhiteboardActivity extends ActionBarActivity {

    private String roomName = "";
    private WebView webview;
    private Bundle webViewBundle;
    private ProgressBar pBar;
    private Lang lang;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_whiteboard);
        Intent intent = getIntent();
        webview = (WebView) findViewById(R.id.webViewwhiteboard);
        pBar = (ProgressBar) findViewById(R.id.progressBarWebView);
        if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.ROOM_NAME)) {
            roomName = intent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.ROOM_NAME);
        }
        lang = JsonPhp.getInstance().getLang();
        if (lang != null && lang.getWhiteboard() != null && getSupportActionBar()!=null) {
            getSupportActionBar().setTitle(lang.getWhiteboard().get9());
        }
        webview.getSettings().setJavaScriptEnabled(true);
        webview.getSettings().setDomStorageEnabled(true);
        CookieSyncManager cookieSyncManager = CookieSyncManager.createInstance(webview.getContext());
        CookieManager cookieManager = CookieManager.getInstance();
        cookieManager.setAcceptCookie(true);
        webview.setWebViewClient(new WebViewClient() {
            @Override
            public void onPageStarted(WebView view, String url, Bitmap favicon) {
                super.onPageStarted(view, url, favicon);
            }

            @Override
            public void onPageFinished(WebView view, String url) {
                super.onPageFinished(view, url);
            }

        });
        webview.setWebChromeClient(new WebChromeClient() {
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
        String newUA = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.152 Safari/537.36";
        webview.getSettings().setUserAgentString(newUA);
        if (webViewBundle == null) {
            Config config = JsonPhp.getInstance().getConfig();
            if (config != null && !TextUtils.isEmpty(config.getWhiteboardUrl())) {
                String url = config.getWhiteboardUrl();
                if (!url.startsWith("http") || !url.startsWith("https")) {
                    url = "http://" + url;
                    url = url.replace("////", "//");
                }
                if (url.endsWith("/")) {
                    url += "d/draw-";
                } else {
                    url += "/d/draw-";
                }
                webview.loadUrl(url + roomName);
            } else {
                webview.loadUrl("http://b.chatforyoursite.com/d/draw-" + roomName);
            }
        } else {
            webview.restoreState(webViewBundle);
        }

        webview.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if (event.getAction() == KeyEvent.ACTION_DOWN) {
                    WebView webView = (WebView) v;
                    switch (keyCode) {
                        case KeyEvent.KEYCODE_BACK:
                            if (webView.canGoBack()) {
                                webView.goBack();
                                return true;
                            }
                            break;
                    }
                }
                return false;
            }
        });

    }

    @Override
    public void onPause() {
        super.onPause();
        webViewBundle = new Bundle();
        webview.saveState(webViewBundle);
    }

}
