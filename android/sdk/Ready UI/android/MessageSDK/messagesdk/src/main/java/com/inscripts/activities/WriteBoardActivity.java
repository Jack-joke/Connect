/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.os.Bundle;
import android.webkit.ConsoleMessage;
import android.webkit.WebChromeClient;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.SuperActivity;

public class WriteBoardActivity extends SuperActivity {

    private WebView webView;
    private String mdRandom;
    private Lang lang;
    private static String WRITEBOARD = "writeboard";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_write_board);

        lang = JsonPhp.getInstance().getLang();
        if (lang != null && lang.getWriteboard() != null && lang.getWriteboard().get7() != null) {
            setActionBarTitle(lang.getWriteboard().get7());
        }else{
            setActionBarTitle("Collaborative document");
        }

        Intent intent = getIntent();
        String randomId = intent.getStringExtra(BroadcastReceiverKeys.IntentExtrasKeys.RANDOMID);
        try {
            mdRandom = EncryptionHelper.encodeIntoMD5(WRITEBOARD+randomId);
        } catch (Exception e) {}
        String url = URLFactory.getWriteBoardConnectURL()+mdRandom+ CometChatKeys.AjaxKeys.WRITEBOARD_USERNAME+ SessionData.getInstance().getName();
        webView = (WebView) findViewById(R.id.webview);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.setWebViewClient(new WebViewClient());
        webView.setWebChromeClient(new WebChromeClient() {
            @Override
            public boolean onConsoleMessage(ConsoleMessage consoleMessage) {
                super.onConsoleMessage(consoleMessage);
                return true;
            }
        });
        webView.loadUrl(url);


    }
}
