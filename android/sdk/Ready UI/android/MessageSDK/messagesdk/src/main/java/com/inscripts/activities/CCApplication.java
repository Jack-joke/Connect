/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Context;
import android.support.multidex.MultiDex;
import android.support.multidex.MultiDexApplication;

import com.inscripts.utils.LocalConfig;
import com.orm.SugarContext;

public class CCApplication extends MultiDexApplication {

    @Override
    public void onCreate() {
        super.onCreate();
        try {
            LocalConfig.initialize(this);
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

    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(base);
        MultiDex.install(this);
    }
}