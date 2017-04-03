/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.FragmentTransaction;

import com.inscripts.countrypicker.CountryPicker;
import com.inscripts.countrypicker.CountryPickerListener;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.utils.SuperActivity;

public class SelectCountryActivity extends SuperActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_select_country);

        setActionBarTitle(this.getTitle());

        final FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        final CountryPicker picker = new CountryPicker();
        transaction.replace(R.id.relativeLayoutSelectCountry, picker);
        transaction.commit();

        picker.setListener(new CountryPickerListener() {

            @Override
            public void onSelectCountry(String name, String code) {
                try {
                    Intent i = new Intent();
                    i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SELECTED_COUNTRY_CODE, code);
                    i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.SELECTED_COUNTRY_NAME, name);
                    setResult(RESULT_OK, i);
                    finish();
                } catch (Exception e) {
                    setResult(RESULT_CANCELED, null);
                    finish();
                    e.printStackTrace();
                }
            }
        });
    }
}
