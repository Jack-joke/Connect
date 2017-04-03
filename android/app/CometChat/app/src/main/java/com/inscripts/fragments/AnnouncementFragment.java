/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.fragments;

import android.annotation.SuppressLint;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.widget.SwipeRefreshLayout;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.webkit.CookieManager;
import android.webkit.CookieSyncManager;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;
import android.widget.TextView;
import com.inscripts.activities.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.SessionData;

public class AnnouncementFragment extends Fragment{

	private WebView homesite;
	private String announcementTabUrl;
	private ProgressBar pBar;
	private TextView noInternetText;
	private SwipeRefreshLayout swipeRefreshLayout;
	private BroadcastReceiver customReceiver;
	private boolean isVisiblefragment = false;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setHasOptionsMenu(true);

		customReceiver = new BroadcastReceiver() {

			@Override
			public void onReceive(Context context, Intent intent) {
				Bundle extras = intent.getExtras();
				if (extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_LIST)) {
					refreshWebView();
					SessionData.getInstance().setAnnouncementListBroadcastMissed(false);
				}
			}
		};
	}

	@Override
	@SuppressLint("SetJavaScriptEnabled")
	public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_annoucement, container, false);
		homesite = (WebView) view.findViewById(R.id.webViewAnnouncement);
		pBar = (ProgressBar) view.findViewById(R.id.progressBarWebView);
		swipeRefreshLayout = (SwipeRefreshLayout) view.findViewById(R.id.swipe_refresh_layout);
		noInternetText = (TextView) view.findViewById(R.id.textViewNoInternet);
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

			@Override
			public void onPageFinished(WebView view, String url) {
				super.onPageFinished(view, url);
				swipeRefreshLayout.setRefreshing(false);
			}
		});


		homesite.getSettings().setAppCacheMaxSize( 5 * 1024 * 1024 ); // 5MB
		homesite.getSettings().setAppCachePath( getActivity().getCacheDir().getAbsolutePath() );
		homesite.getSettings().setAllowFileAccess( true );

		homesite.getSettings().setDomStorageEnabled(true);
		homesite.getSettings().setJavaScriptEnabled(true);
		homesite.getSettings().setAppCacheEnabled(true);
		homesite.getSettings().setBuiltInZoomControls(false);
		announcementTabUrl = URLFactory.getAnnouncementTabUrl();
		homesite.getSettings().setCacheMode(WebSettings.LOAD_CACHE_ELSE_NETWORK);
		homesite.getSettings().setUserAgentString("cc_android");
		refreshWebView();

		return view;
	}

	@Override
	public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
		MenuItem item = menu.findItem(R.id.custom_action_create_chatroom);
		item.setVisible(false);
		item = menu.findItem(R.id.custom_action_search);
		try {
			InputMethodManager mgr = (InputMethodManager) getActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
			if (null != getView() && null != getView().getWindowToken()) {
				mgr.hideSoftInputFromWindow(getView().getWindowToken(), 0);
			}

			item.setVisible(false);
			menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
			menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
		} catch (Exception e) {
			e.printStackTrace();
		}
		super.onCreateOptionsMenu(menu, inflater);
	}

	@Override
	public void onStart() {
		super.onStart();
		if (customReceiver != null) {
			getActivity().registerReceiver(customReceiver,
					new IntentFilter(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_UPDATATION));
		}
	}

	@Override
	public void onStop() {
		super.onStop();
		if (null != customReceiver) {
			getActivity().unregisterReceiver(customReceiver);
		}
	}

	@Override
	public void setUserVisibleHint(boolean isVisibleToUser) {
		isVisiblefragment = isVisibleToUser;
	}

	private void refreshWebView() {
		if ( !CommonUtils.isConnected()) {
			homesite.setVisibility(View.GONE);
			pBar.setVisibility(View.GONE);
			noInternetText.setVisibility(View.VISIBLE);
		} else {
			homesite.setVisibility(View.VISIBLE);
			pBar.setVisibility(View.VISIBLE);
			noInternetText.setVisibility(View.GONE);
			homesite.loadUrl(announcementTabUrl);
			if (isVisiblefragment) {
				Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
				PreferenceHelper.save(PreferenceKeys.DataKeys.ANN_BADGE_COUNT, 0);
				intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_ANNOUNCEMENT_BADGE, 1);
				getActivity().sendBroadcast(intent);
			}
		}

	}

}
