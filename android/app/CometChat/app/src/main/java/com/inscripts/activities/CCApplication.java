/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.support.multidex.MultiDexApplication;

import com.crashlytics.android.Crashlytics;
import com.inscripts.utils.LocalConfig;
import com.orm.SugarContext;
import com.parse.Parse;
import com.twitter.sdk.android.Twitter;
import com.twitter.sdk.android.core.TwitterAuthConfig;

import io.fabric.sdk.android.Fabric;

public class CCApplication extends MultiDexApplication {

    @Override
    public void onCreate() {
        super.onCreate();
        try {
            LocalConfig.initialize(this);
            Parse.initialize(this, LocalConfig.getParseAppId(), LocalConfig.getParseClientKey());
            TwitterAuthConfig authConfig = new TwitterAuthConfig(LocalConfig.getTwitterKey(), LocalConfig.getTwitterSecret());
            Fabric.with(this, new Crashlytics(), new Twitter(authConfig));
            SugarContext.init(this);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void onTerminate() {
        super.onTerminate();
        SugarContext.terminate();
    }
}