/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.utils;

import com.inscripts.interfaces.VolleyAjaxCallbacks;

import java.util.Timer;
import java.util.TimerTask;

public class TimerClass {

    long id;
    Timer timer;

    public TimerClass(long id) {
        this.id = id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public void setTimer(final VolleyAjaxCallbacks callbacks) {
        if (timer != null) {
            timer.cancel();
        } else {
            timer = new Timer();
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    callbacks.successCallback(String.valueOf(id));
                }
            }, 5000);
        }
    }
}
