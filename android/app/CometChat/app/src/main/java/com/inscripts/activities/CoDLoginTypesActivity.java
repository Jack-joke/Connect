/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.utils.LocalConfig;

public class CoDLoginTypesActivity extends Activity {

    private Lang lang;

    private Button loginBtn, bottomGuestLoginBtn;
    private ImageView backBtn;
    private Mobile mobileLangs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cod_login_types);

        lang = JsonPhp.getInstance().getLang();
        if (null != lang) {
            mobileLangs = lang.getMobile();
        }

        loginBtn = (Button) findViewById(R.id.buttonLogin);
        bottomGuestLoginBtn = (Button) findViewById(R.id.buttonLoginAsGuest);
        backBtn = (ImageView) findViewById(R.id.imageViewBottomBack);

        if (null != mobileLangs) {
            if (null != mobileLangs.get12()) {
                loginBtn.setText(lang.getMobile().get12());
            }
            if (null != mobileLangs.get146()) {
                bottomGuestLoginBtn.setText(mobileLangs.get146());
            }
        }

        if (!LocalConfig.getSiteUrl().isEmpty()) {
            backBtn.setVisibility(View.GONE);
        }

        loginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent i = new Intent(getApplicationContext(), CoDLoginActivity.class);
                i.putExtra("Url", getIntent().getStringExtra("Url"));
                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                getApplicationContext().startActivity(i);
            }
        });
        bottomGuestLoginBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i = new Intent(CoDLoginTypesActivity.this, GuestLoginActivity.class);
                i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(i);
            }
        });
        backBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBackPressed();
            }
        });
        applyThemeColor();
    }
    private void applyThemeColor() {
        MobileTheme theme = JsonPhp.getInstance().getMobileTheme();
        if (null != theme && null != theme.getLoginPlaceholder()
                && null != theme.getLoginForegroundText() && null != theme.getLoginBackground() && null != theme.getLoginText() && null != theme.getLoginButton()) {
            int foregroundColor = Color.parseColor(theme.getLoginButton());
            loginBtn.setBackgroundColor(foregroundColor);
            if (!TextUtils.isEmpty(theme.getLoginButtonText())) {
                loginBtn.setTextColor(Color.parseColor(theme.getLoginButtonText()));
            }
            bottomGuestLoginBtn.setTextColor(foregroundColor);
            bottomGuestLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, foregroundColor));
        } else if (null != theme.getLoginBackground() && null != theme.getLoginForeground() && null != theme.getLoginButtonPressed()) {
            int button = Color.parseColor(theme.getLoginButtonPressed());
            bottomGuestLoginBtn.setTextColor(button);
            bottomGuestLoginBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, button));
            loginBtn.setBackgroundColor(button);
        }
    }

    @Override
    public void onBackPressed() {
        if (LocalConfig.getSiteUrl().isEmpty()) {
            super.onBackPressed();
        }
    }
}