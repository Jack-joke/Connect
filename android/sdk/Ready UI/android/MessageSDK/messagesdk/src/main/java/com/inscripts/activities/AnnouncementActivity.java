package com.inscripts.activities;

import android.content.BroadcastReceiver;
import android.content.IntentFilter;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.widget.Toolbar;
import android.view.KeyEvent;
import android.view.View;
import android.webkit.CookieManager;
import android.webkit.CookieSyncManager;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SuperActivity;

public class AnnouncementActivity extends SuperActivity {

    private WebView homesite;
    private String announcementTabUrl;
    private TextView noInternetText;
    private SwipeRefreshLayout swipeRefreshLayout;
    private BroadcastReceiver customReceiver;
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_fragment_annoucement);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        homesite = (WebView) findViewById(R.id.webViewAnnouncement);
        swipeRefreshLayout = (SwipeRefreshLayout) findViewById(R.id.swipe_refresh_layout);
        noInternetText = (TextView) findViewById(R.id.textViewNoInternet);
        if (null != JsonPhp.getInstance().getLang().getMobile().get24()){
            noInternetText.setText(JsonPhp.getInstance().getLang().getMobile().get24());
        }
        swipeRefreshLayout.setOnRefreshListener(new SwipeRefreshLayout.OnRefreshListener() {
            @Override
            public void onRefresh() {
                swipeRefreshLayout.setRefreshing(false);
                refreshWebView();
            }
        });


        homesite.setWebChromeClient(new WebChromeClient() {

            @Override
            public void onProgressChanged(WebView view, int progress) {
                super.onProgressChanged(view, progress);
            }
        });

        homesite.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if (event.getAction()==KeyEvent.ACTION_DOWN){
                    WebView webView = (WebView) v;
                    switch(keyCode){
                        case KeyEvent.KEYCODE_BACK:
                            if (webView.canGoBack()){
                                webView.goBack();
                                return true;
                            }
                            break;
                    }
                }
                return false;
            }
        });

        homesite.setWebViewClient(new WebViewClient(){
            @Override
            public void onPageStarted(WebView view, String url, Bitmap favicon) {
                super.onPageStarted(view, url, favicon);
                CookieSyncManager cookieSyncManager = CookieSyncManager.createInstance(AnnouncementActivity.this);
                CookieManager cookieManager = CookieManager.getInstance();
                cookieManager.setAcceptCookie(true);
                cookieManager.setCookie(url, "cc_platform_cod=android;");
                cookieSyncManager.sync();
            }

            @Override
            public void onPageFinished(WebView view, String url) {
                super.onPageFinished(view, url);
                swipeRefreshLayout.setRefreshing(false);
            }
        });


        homesite.getSettings().setAppCacheMaxSize( 5 * 1024 * 1024 ); // 5MB
        homesite.getSettings().setAppCachePath(this.getCacheDir().getAbsolutePath());
        homesite.getSettings().setAllowFileAccess( true );

        homesite.getSettings().setDomStorageEnabled(true);
        homesite.getSettings().setJavaScriptEnabled(true);
        homesite.getSettings().setAppCacheEnabled(true);
        homesite.getSettings().setBuiltInZoomControls(false);
        announcementTabUrl = URLFactory.getAnnouncementTabUrl();
        Logger.error("Annoucement Url = "+announcementTabUrl);
        homesite.getSettings().setCacheMode(WebSettings.LOAD_CACHE_ELSE_NETWORK);
        homesite.getSettings().setUserAgentString("cc_android");
        refreshWebView();

    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            registerReceiver(customReceiver, new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_UPDATATION));
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        if (null != customReceiver) {
            unregisterReceiver(customReceiver);
        }
    }

    private void refreshWebView() {
        if ( !CommonUtils.isConnected()) {
            homesite.setVisibility(View.GONE);
            noInternetText.setVisibility(View.VISIBLE);
        } else {
            homesite.setVisibility(View.VISIBLE);
            noInternetText.setVisibility(View.GONE);
            homesite.loadUrl(announcementTabUrl);
        }

    }
}
