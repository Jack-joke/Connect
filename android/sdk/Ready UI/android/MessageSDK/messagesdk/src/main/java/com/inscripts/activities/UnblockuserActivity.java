/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.adapters.UnblockUserListAdapter;
import com.inscripts.custom.CustomChatActivity;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;

public class UnblockuserActivity extends CustomChatActivity {

    private ListView blockUserList;
    private UnblockUserListAdapter adapter;
    private TextView noUsers;
    private Button cancel, unblock;
    private String checkBoxKeyForBundle = "checkBoxState", userNames = "userNames", userIds = "userIds";
    private ArrayList<String> savedCheckbox, blockedUserIds;
    private ArrayList<String> blockedUserNames;
    private ProgressBar wheel;
    private Lang lang;
    private MobileTheme theme;
    private Css css;
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_unblockuser);
        String title = getResources().getString(R.string.unblock_user);
        lang = JsonPhp.getInstance().getLang();

        title = (null == lang.getBlock()) ? title : lang.getBlock().get3();
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        setActionBarTitle(title);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        theme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();

        wheel = (ProgressBar) findViewById(R.id.progressWheel);

        cancel = (Button) findViewById(R.id.buttonCancelUnblock);
        unblock = (Button) findViewById(R.id.buttonUnblockUser);
        unblock.setAlpha(0.5F);
        unblock.setEnabled(false);
        String unblockText = (null == lang.getMobile().get80()) ? getResources()
                .getString(R.string.unblock_button_text) : lang.getMobile().get80();
        String cancelText = (null == lang.getMobile().get32()) ? getResources().getString(R.string.cancel_invite_users)
                : lang.getMobile().get32();

        cancel.setText(cancelText);
        unblock.setText(unblockText);

        if (null != theme && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            cancel.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            unblock.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancel.setTextColor(btnColor);
            unblock.setTextColor(btnColor);
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            cancel.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            unblock.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancel.setTextColor(btnColor);
            unblock.setTextColor(btnColor);
        }


        blockUserList = (ListView) findViewById(R.id.listViewBlockedUser);
        noUsers = (TextView) findViewById(R.id.textViewNoBlockUser);

        savedCheckbox = new ArrayList<String>();
        if (null != savedInstanceState) {
            savedCheckbox = savedInstanceState.getStringArrayList(checkBoxKeyForBundle);

            blockedUserIds = savedInstanceState.getStringArrayList(userIds);
            blockedUserNames = savedInstanceState.getStringArrayList(userNames);
        }

        if (blockedUserNames == null && blockedUserIds == null) {
            startWheel();
            VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getBlockedUserURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                blockedUserNames = new ArrayList<>();
                                blockedUserIds = new ArrayList<>();
                                JSONObject jsonr = new JSONObject(response);
                                Iterator<String> iter = jsonr.keys();
                                while (iter.hasNext()) {
                                    JSONObject user = jsonr.getJSONObject(iter.next());
                                    blockedUserIds.add(user.getString(AjaxKeys.ID));
                                    blockedUserNames.add(user.getString(AjaxKeys.NAME));
                                }

                                setupBlockedList();
                                stopWheel();
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            stopWheel();
                        }
                    });
            vHelper.sendAjax();
        } else {
            setupBlockedList();
        }

        cancel.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                stopWheel();
                finish();
            }
        });

        final String errorText = (null == lang.getMobile().get70()) ? StaticMembers.ERROR_UNBLOCKING_USER : lang
                .getMobile().get70();

        unblock.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                if (adapter.getCount() > 0) {
                    ArrayList<String> checkedUsers = adapter.getCheckedUsersList();
                    if (checkedUsers.size() == 0) {
                        Toast.makeText(getApplicationContext(), lang.getMobile().get67(), Toast.LENGTH_SHORT).show();
                    } else {
                        for (String toId : checkedUsers) {
                            VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory
                                    .getUnblockUserURL(), new VolleyAjaxCallbacks() {

                                @Override
                                public void successCallback(String response) {
                                    try {
                                        JSONObject blockresponse = new JSONObject(response);
                                        if (blockresponse.getString(AjaxKeys.RESULT).equals("0")) {
                                            Toast.makeText(getApplicationContext(), errorText, Toast.LENGTH_SHORT)
                                                    .show();
                                        }
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {

                                }
                            });
                            vHelper.addNameValuePair(AjaxKeys.TO, toId);
                            vHelper.sendAjax();
                        }
                        finish();
                    }
                } else {
                    Toast.makeText(getApplicationContext(), noUsers.getText(), Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            finish();
        }
        return super.onOptionsItemSelected(item);
    }

    private void setupBlockedList() {
        adapter = new UnblockUserListAdapter(getApplicationContext(), blockedUserNames, blockedUserIds, savedCheckbox);
        blockUserList.setAdapter(adapter);
        blockUserList.setOnItemClickListener(new OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                CheckBox checkBox = (CheckBox) view.findViewById(R.id.checkBoxUnblockUser);
                checkBox.setChecked(!checkBox.isChecked());
                adapter.toggleUnblock(checkBox.getTag().toString());
            }
        });

        if (blockedUserNames.size() == 0) {
            if (null == lang.getBlock()) {
                noUsers.setText(getResources().getString(R.string.no_blocked_users));
            } else {
                noUsers.setText(lang.getBlock().get6());
            }
            noUsers.setVisibility(View.VISIBLE);
            unblock.setAlpha(0.5F);
            unblock.setEnabled(false);
            noUsers.setVisibility(View.VISIBLE);
        } else {
            unblock.setAlpha(1F);
            unblock.setEnabled(true);
        }
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if (null != adapter) {
            ArrayList<String> blockedUsers = adapter.getCheckedUsersList();
            outState.clear();
            outState.putStringArrayList(checkBoxKeyForBundle, blockedUsers);
            if (null != blockedUsers) {
                outState.putStringArrayList(userNames, blockedUserNames);
            }
            if (null != blockedUserIds) {
                outState.putStringArrayList(userIds, blockedUserIds);
            }
        }
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
    }

    @Override
    public void finish() {
        super.finish();
        stopWheel();
        overridePendingTransition(0, 0);
    }

    private void startWheel() {
        wheel.setVisibility(View.VISIBLE);
    }

    private void stopWheel() {
        wheel.setVisibility(View.GONE);
    }
}
