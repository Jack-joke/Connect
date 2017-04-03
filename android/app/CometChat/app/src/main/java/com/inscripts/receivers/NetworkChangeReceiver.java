package com.inscripts.receivers;


import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Handler;

import com.inscripts.services.OflineMessagesService;
import com.inscripts.utils.Logger;
import com.inscripts.utils.NetworkUtil;

public class NetworkChangeReceiver  extends BroadcastReceiver {
    private static final java.lang.String TAG = NetworkChangeReceiver.class.getSimpleName();

    @Override
    public void onReceive(final Context context, Intent intent) {
        Logger.error("Network change receiver");
        int status = NetworkUtil.getConnectivityStatusString(context);

        if( status == 1 || status == 2){
            Logger.error(TAG,"Conected to internet");
            context.startService(new Intent(context, OflineMessagesService.class));


            /** resend mechanism to resend the message again after 1 min**/
            Handler handler = new Handler();
            handler.postDelayed(new Runnable() {
                @Override
                public void run() {
                    Logger.error(TAG, "OflineService restarted");
                    context.startService(new Intent(context, OflineMessagesService.class));
                }
            }, 1000*60);
        }
    }
}
