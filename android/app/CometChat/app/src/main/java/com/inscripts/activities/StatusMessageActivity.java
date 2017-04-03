package com.inscripts.activities;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.ColorFilter;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.adapters.StatusMessageAdapter;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Status;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import java.util.ArrayList;

public class StatusMessageActivity extends SuperActivity implements View.OnClickListener, AdapterView.OnItemClickListener, AdapterView.OnItemLongClickListener, OnAlertDialogButtonClickListener {

    private TextView edtStatusMessage;
    private ImageView ivEditStatus;
    private String previousStatus;
    private ListView lvStatusMessage;
    StatusMessageAdapter adapter;

    ArrayList<Status> list;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_status_message);

        edtStatusMessage = (TextView) findViewById(R.id.editTextStatusMessage);
        ivEditStatus = (ImageView) findViewById(R.id.iv_edit_status);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get106()) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().get106());
        }

        TextView tvCurrentStatusTitle = (TextView) findViewById(R.id.tv_status_title);
        String statusTitle = "";
        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getCurrentStatusTitle()) {
            statusTitle = JsonPhp.getInstance().getLang().getMobile().getCurrentStatusTitle();
        } else {
            statusTitle = getResources().getString(R.string.title_current_status);
        }
        tvCurrentStatusTitle.setText(statusTitle);

        TextView tvNewStatusTitle = (TextView) findViewById(R.id.tv_status_list_title);
        String newStatusTitle = "";
        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getNewStatusTitle()) {
            newStatusTitle = JsonPhp.getInstance().getLang().getMobile().getNewStatusTitle();
        } else {
            newStatusTitle = getResources().getString(R.string.title_select_new_status);
        }
        tvNewStatusTitle.setText(newStatusTitle);

        tvCurrentStatusTitle.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        tvNewStatusTitle.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        ivEditStatus.getDrawable().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        previousStatus = PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS_MESSAGE);
        if (previousStatus != null) {
            edtStatusMessage.setText(previousStatus);
        }

        ivEditStatus.setOnClickListener(this);

        lvStatusMessage = (ListView) findViewById(R.id.lv_status);
        lvStatusMessage.setOnItemClickListener(this);
        lvStatusMessage.setOnItemLongClickListener(this);

        list = (ArrayList<Status>) Status.getAllStatusMessages();

        adapter = new StatusMessageAdapter(this, list);
        lvStatusMessage.setAdapter(adapter);
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == R.id.iv_edit_status) {
            Intent statusIntent = new Intent(this, UpdateStatusMessageActivity.class);
            startActivity(statusIntent);
        }
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        final String newStatusMessage = list.get(position).message;
        if (!TextUtils.isEmpty(newStatusMessage)) {
            VolleyHelper volley = new VolleyHelper(StatusMessageActivity.this, URLFactory.getSendOneToOneMessageURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                            SessionData.getInstance().setStatusMessage(newStatusMessage);
                            PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS_MESSAGE, newStatusMessage);
                            edtStatusMessage.setText(newStatusMessage);
                            Toast.makeText(StatusMessageActivity.this, "Status Updated", Toast.LENGTH_SHORT).show();
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            if (isNoInternet) {
                                Toast.makeText(StatusMessageActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
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

    @Override
    public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(this, "Message : " + list.get(position).message, Toast.LENGTH_SHORT).show();
        showDeletePopup(position);
        return false;
    }

    private void showDeletePopup(int position) {
        LayoutInflater inflater = getLayoutInflater();
        View dialogview = inflater.inflate(R.layout.custom_dialog, null);
        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
        EditText dialogueInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
        dialogueInput.setVisibility(View.GONE);
        Lang lang = JsonPhp.getInstance().getLang();
        dialogueTitle.setText("Delete status?");
        new CustomAlertDialogHelper(this, "", dialogview, lang.getMobile().get25(), "", lang.getMobile().get32(), this, position);
    }

    @Override
    public void onButtonClick(AlertDialog alertDialog, View v, int which, int popupId) {
        if (which == DialogInterface.BUTTON_POSITIVE) {
            if (list != null && list.size() > 0) {
                Status.deleteStatus(list.get(popupId).getId());
                list.remove(popupId);
                adapter.notifyDataSetChanged();
            }
        }
        alertDialog.dismiss();
    }
}
