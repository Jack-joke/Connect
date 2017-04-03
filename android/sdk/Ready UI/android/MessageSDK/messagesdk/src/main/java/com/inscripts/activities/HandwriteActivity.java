/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.graphics.Bitmap;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;


import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.utils.Logger;

public class HandwriteActivity extends ActionBarActivity {
    private WebView webview;
    private Bundle webViewBundle;
    private ProgressBar pBar;
    private Lang lang;
    private String sendername,basedata;
    private Long buddyid;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_handwrite);

        Intent intent = getIntent();
        webview = (WebView) findViewById(R.id.webViewHandwriteReadyui);
        pBar = (ProgressBar) findViewById(R.id.progressBarWebViewReadyui);
        getSupportActionBar().setTitle("Handwrite");

        if (intent.hasExtra(CometChatKeys.AjaxKeys.SENDERNAME) ){
            sendername = intent.getStringExtra(CometChatKeys.AjaxKeys.SENDERNAME);
        }
        if (intent.hasExtra(CometChatKeys.AjaxKeys.BASE_DATA) ){
            basedata = intent.getStringExtra(CometChatKeys.AjaxKeys.BASE_DATA);
        }
        if (intent.hasExtra(CometChatKeys.AjaxKeys.ID) ){
            //Logger.error("buddyid "+intent.getLongExtra(CometChatKeys.AjaxKeys.ID,0));
            buddyid = Long.valueOf(intent.getLongExtra(CometChatKeys.AjaxKeys.ID, 0));
        }

        webview.getSettings().setJavaScriptEnabled(true);
        webview.getSettings().setDomStorageEnabled(true);

        webview.setWebViewClient(new WebViewClient() {

            public boolean shouldOverrideUrlLoading(WebView view, String url){
                Logger.error("redirection url:"+url);
                if(url.equals("mobileapp:cc_close_webview")){
                    Logger.error("inside if");
                    finish();

                }
                return false;
            }
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
            if (config != null && !TextUtils.isEmpty(URLFactory.getHandwriteURL())) {
                String url = URLFactory.getHandwriteURL();
                /*if (!url.startsWith("http") || !url.startsWith("https")) {
                    url = "http://" + url;
                    url = url.replace("////", "//");
                }*/
               /* if (url.endsW
               ith("/")) {
                    url += "d/draw-";
                } else {
                    url += "/d/draw-";
                }*/
                url=url+"&id="+buddyid+"&sendername="+sendername+"&basedata="+basedata;
                Logger.error("url"+url);
                webview.loadUrl(url);

            } else {
                webview.loadUrl("http://b.chatforyoursite.com/d/draw-");
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
/*
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_handwrite, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }*/
}