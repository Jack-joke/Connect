/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.fragments;

import android.annotation.SuppressLint;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.CookieManager;
import android.webkit.CookieSyncManager;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;

import com.inscripts.R;
import com.inscripts.jsonphp.JsonPhp;

public class HomeFragment extends Fragment {

    private WebView homesite;
    private String homeTabUrl;
    private ProgressBar pBar;
    private Bundle webViewBundle;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
        setRetainInstance(true);
    }

    @Override
    @SuppressLint("SetJavaScriptEnabled")
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.cc_fragment_home, container, false);
        homesite = (WebView) view.findViewById(R.id.webViewHome);
        pBar = (ProgressBar) view.findViewById(R.id.progressBarWebView);

        homesite.setWebChromeClient(new WebChromeClient() {

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
                CookieSyncManager cookieSyncManager = CookieSyncManager.createInstance(getActivity().getApplicationContext());
                CookieManager cookieManager = CookieManager.getInstance();
                cookieManager.setAcceptCookie(true);
                cookieManager.setCookie(url, "cc_platform_cod=android;");
                cookieSyncManager.sync();
            }
        });
        homesite.getSettings().setDomStorageEnabled(true);
        homesite.getSettings().setJavaScriptEnabled(true);
        homesite.getSettings().setAppCacheEnabled(true);
        homesite.getSettings().setBuiltInZoomControls(true);
        homeTabUrl = JsonPhp.getInstance().getConfig().getHomepageURL();
        homesite.getSettings().setCacheMode(WebSettings.LOAD_CACHE_ELSE_NETWORK);

        if (webViewBundle == null) {
            homesite.loadUrl(homeTabUrl);
        } else {
            homesite.restoreState(webViewBundle);
        }
        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
       /* try {
            MenuItem item = menu.findItem(R.id.custom_action_create_chatroom);
            item.setVisible(false);
            item = menu.findItem(R.id.custom_action_search);
            item.setVisible(false);
            menu.findItem(R.id.custom_action_unblock_user).setVisible(false);

            super.onCreateOptionsMenu(menu, inflater);
        } catch (Exception e) {
            e.printStackTrace();
        }*/
    }

    @Override
    public void onPause() {
        super.onPause();
        webViewBundle = new Bundle();
        homesite.saveState(webViewBundle);
    }
}