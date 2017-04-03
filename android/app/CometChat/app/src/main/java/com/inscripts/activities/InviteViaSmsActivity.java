/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.Manifest;
import android.app.PendingIntent;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.v4.app.ActivityCompat;
import android.telephony.SmsManager;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.adapters.InviteViaSmsAdapter;
import com.inscripts.custom.ContactsCompletionView;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.ContactsCallback;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.InviteSms;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.pojos.ContactPojo;
import com.inscripts.utils.AsyncTaskContactRetrieve;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SuperActivity;
import com.pnikosis.materialishprogress.ProgressWheel;
import com.tokenautocomplete.TokenCompleteTextView;

import java.util.ArrayList;
import java.util.List;

public class InviteViaSmsActivity extends SuperActivity implements TokenCompleteTextView.TokenListener {

    private ContactsCompletionView completionView;
    private InviteViaSmsAdapter adapter;
    private List<Object> contacts;
    private InviteSms inviteSmsLangs;
    private Mobile mobileLangs;
    private MobileTheme theme;
    private Css css;
    private String primaryColor;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invite_via_sms);
        ActivityCompat.requestPermissions(this,new String[]{Manifest.permission.SEND_SMS},1);
        if (null != JsonPhp.getInstance().getNewMobile()) {
            inviteSmsLangs = JsonPhp.getInstance().getNewMobile().getInviteSms();
        }

        if (null != JsonPhp.getInstance().getLang()) {
            mobileLangs = JsonPhp.getInstance().getLang().getMobile();
        }

        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        setActionBarColor(primaryColor);
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));

        final EditText inviteMessage = (EditText) InviteViaSmsActivity.this.findViewById(R.id.editTextInviteSMS);
        TextView toLabel = (TextView) findViewById(R.id.textViewInviteLabel);

        final ProgressWheel wheel = (ProgressWheel) findViewById(R.id.progressWheel);
        if (null != JsonPhp.getInstance().getMobileTheme()) {
            theme = JsonPhp.getInstance().getMobileTheme();
        }
        css = JsonPhp.getInstance().getCss();

        wheel.setVisibility(View.VISIBLE);
        wheel.spin();

        Button inviteButton = (Button) findViewById(R.id.buttonInviteUser);
        completionView = (ContactsCompletionView) findViewById(R.id.inviteSMSSearch);

        completionView.setEnabled(false);
        completionView.setAlpha(0.5F);

        new AsyncTaskContactRetrieve(this, new ContactsCallback() {

            @Override
            public void successCallback(ArrayList<ContactPojo> allContacts) {
                if (0 < allContacts.size()) {
                    adapter = new InviteViaSmsAdapter(InviteViaSmsActivity.this, allContacts);
                    completionView.allowDuplicates(false);
                    completionView.setAdapter(adapter);
                    completionView.setTokenListener(InviteViaSmsActivity.this);
                    completionView.setTokenClickStyle(TokenCompleteTextView.TokenClickStyle.Delete);
                    completionView.setHint(null == inviteSmsLangs ? "Type a name" : inviteSmsLangs.getContactsHint());
                    wheel.stopSpinning();
                    wheel.setVisibility(View.GONE);
                    completionView.setEnabled(true);
                    completionView.setAlpha(1F);
                } else {
                    Toast.makeText(InviteViaSmsActivity.this,
                            (null == mobileLangs) ? "No contacts found." : mobileLangs.get73(), Toast.LENGTH_LONG)
                            .show();
                    wheel.stopSpinning();
                    wheel.setVisibility(View.GONE);
                }
            }

            @Override
            public void failCallback(String errorMessage) {
                wheel.stopSpinning();
                wheel.setVisibility(View.GONE);
            }
        }).execute();


        inviteButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                String message = inviteMessage.getText().toString().trim();

                if (!TextUtils.isEmpty(message)) {
                    contacts = completionView.getObjects();
                    sendSMS(message);
                } else {
                    Toast.makeText(InviteViaSmsActivity.this,
                            (null == mobileLangs) ? "Cannot send empty message." : mobileLangs.get71(),
                            Toast.LENGTH_LONG).show();
                }
            }
        });

        if (null != inviteSmsLangs) {
            inviteMessage.setText(inviteSmsLangs.getSmsAndroid());
            setActionBarTitle(inviteSmsLangs.getActionbar());
            inviteMessage.setHint(inviteSmsLangs.getSmsHint());
        } else {
            inviteMessage.setText(LocalConfig.getDefaultInviteMessage());
        }

        if (mobileLangs != null) {

            inviteButton.setText(mobileLangs.get36());
            setActionBarTitle(mobileLangs.get68());
            toLabel.setText(mobileLangs.get79());
            if (!TextUtils.isEmpty(inviteMessage.getText().toString())) {
                inviteMessage.setText(mobileLangs.get77());
            }
        }

       /* if (null != theme && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            inviteButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            inviteButton.setTextColor(btnColor);
            wheel.setBarColor(btnColor);
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            inviteButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            inviteButton.setTextColor(btnColor);
            wheel.setBarColor(btnColor);
        }*/

        inviteButton.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
    }

    private void sendSMS(String message) {
        if (null != contacts && contacts.size() > 0) {
            for (Object contact : contacts) {
                String phone = ((ContactPojo) contact).phone;
                if (!TextUtils.isEmpty(phone)) {
                    sendSMS(phone, message);
                }
            }
            finish();
        } else {
            Toast.makeText(InviteViaSmsActivity.this,
                    (null == mobileLangs) ? "No contacts selected." : mobileLangs.get72(), Toast.LENGTH_LONG).show();
            completionView.requestFocus();
        }
    }

    private void sendSMS(String phoneNumber, String message) {
        String SENT = "SMS_SENT";
        String DELIVERED = "SMS_DELIVERED";

        PendingIntent sentPI = PendingIntent.getBroadcast(this, 0, new Intent(SENT), 0);
        PendingIntent deliveredPI = PendingIntent.getBroadcast(this, 0, new Intent(DELIVERED), 0);
        SmsManager sms = SmsManager.getDefault();
        sms.sendTextMessage(phoneNumber, null, message, sentPI, deliveredPI);

        // ---when the SMS has been sent---
        /*
		 * registerReceiver(new BroadcastReceiver() {
		 * 
		 * @Override public void onReceive(Context arg0, Intent arg1) { switch
		 * (getResultCode()) { case Activity.RESULT_OK: ContentValues values =
		 * new ContentValues(); for (int i = 0; i < MobNumber.size() - 1; i++) {
		 * values.put("address", MobNumber.get(i).toString()); //
		 * txtPhoneNo.getText().toString()); values.put("body",
		 * MessageText.getText().toString()); }
		 * 
		 * getContentResolver().insert(Uri.parse("content://sms/sent"), values);
		 * Toast.makeText(getBaseContext(), "SMS sent",
		 * Toast.LENGTH_SHORT).show(); break; case
		 * SmsManager.RESULT_ERROR_GENERIC_FAILURE:
		 * Toast.makeText(getBaseContext(), "Generic failure",
		 * Toast.LENGTH_SHORT).show(); break; case
		 * SmsManager.RESULT_ERROR_NO_SERVICE: Toast.makeText(getBaseContext(),
		 * "No service", Toast.LENGTH_SHORT).show(); break; case
		 * SmsManager.RESULT_ERROR_NULL_PDU: Toast.makeText(getBaseContext(),
		 * "Null PDU", Toast.LENGTH_SHORT).show(); break; case
		 * SmsManager.RESULT_ERROR_RADIO_OFF: Toast.makeText(getBaseContext(),
		 * "Radio off", Toast.LENGTH_SHORT).show(); break; } } }, new
		 * IntentFilter(SENT));
		 * 
		 * // ---when the SMS has been delivered--- registerReceiver(new
		 * BroadcastReceiver() {
		 * 
		 * @Override public void onReceive(Context arg0, Intent arg1) { switch
		 * (getResultCode()) { case Activity.RESULT_OK:
		 * Toast.makeText(getBaseContext(), "SMS delivered",
		 * Toast.LENGTH_SHORT).show(); break; case Activity.RESULT_CANCELED:
		 * Toast.makeText(getBaseContext(), "SMS not delivered",
		 * Toast.LENGTH_SHORT).show(); break; } } }, new
		 * IntentFilter(DELIVERED));
		 */
    }

    @Override
    public void onTokenAdded(Object arg0) {
        if (null != adapter && null != arg0) {
            adapter.remove((ContactPojo) arg0);
        }
    }

    @Override
    public void onTokenRemoved(Object arg0) {
        if (null != adapter && null != arg0) {
            adapter.add((ContactPojo) arg0);
        }
    }
}