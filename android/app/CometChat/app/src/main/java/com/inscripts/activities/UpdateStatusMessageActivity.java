package com.inscripts.activities;

import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Status;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import java.util.ArrayList;

public class UpdateStatusMessageActivity extends SuperActivity {

    private EditText edtStatusMessage;
    private Button btnUpdate;
    private TextView txtMessageCount;
    private int MAX_LENGTH = 140;
    private String previousStatus;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_status_message);

        edtStatusMessage = (EditText) findViewById(R.id.editTextStatusMessage);
        btnUpdate = (Button) findViewById(R.id.button_update_status_message);
        txtMessageCount = (TextView) findViewById(R.id.txt_count);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get106()) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get106());
        } else {
            setActionBarTitle(getResources().getString(R.string.title_update_status));
        }

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getUpdate()) {
            btnUpdate.setText(JsonPhp.getInstance().getLang().getMobile().getUpdate());
        }


        Drawable background = btnUpdate.getBackground();
        background.setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        previousStatus = PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS_MESSAGE);

        if(previousStatus != null){
            edtStatusMessage.setText(previousStatus);
            int statusLenght = previousStatus.length();
            String m = String.valueOf(MAX_LENGTH-statusLenght);
            txtMessageCount.setText(m);
        }

        edtStatusMessage.addTextChangedListener(new TextWatcher() {

            @Override
            public void afterTextChanged(Editable s) {}

            @Override
            public void beforeTextChanged(CharSequence s, int start,int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start,int before, int count) {
                int statusLenght = edtStatusMessage.getText().toString().length();
                String m = String.valueOf(MAX_LENGTH-statusLenght);
                txtMessageCount.setText(m);
            }
        });

        btnUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final String newStatusMessage = edtStatusMessage.getText().toString();
                if (!TextUtils.isEmpty(newStatusMessage)) {
                    VolleyHelper volley = new VolleyHelper(UpdateStatusMessageActivity.this, URLFactory.getSendOneToOneMessageURL(),
                            new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                    SessionData.getInstance().setStatusMessage(newStatusMessage);
                                    PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS_MESSAGE, newStatusMessage);

                                    ArrayList<Status> statusesList = (ArrayList<Status>) Status.getStatusFromMessage(newStatusMessage);
                                    if (null == statusesList || statusesList.size() == 0) {
                                        Status.insertStatus(newStatusMessage);
                                    }
                                    Toast.makeText(UpdateStatusMessageActivity.this, "Status Updated", Toast.LENGTH_SHORT).show();
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {
                                    if (isNoInternet) {
                                        Toast.makeText(UpdateStatusMessageActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                Toast.LENGTH_LONG).show();
                                    }
                                }
                            });

                    volley.addNameValuePair(CometChatKeys.AjaxKeys.STATUS_MESSAGE, newStatusMessage);
                    volley.sendAjax();

                } else {
                    edtStatusMessage.setError((null == JsonPhp.getInstance().getLang().getMobile().get83()) ? "Please enter a status."
                            : JsonPhp.getInstance().getLang().getMobile().get83());

                }

            }
        });

    }
}
