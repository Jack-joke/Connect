package com.inscripts.activities;

import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.Toolbar;
import android.text.InputType;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.LogoutHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.Core;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.Settings;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.BlockUnblockUser;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Iterator;

public class SettingActivity extends SuperActivity implements OnAlertDialogButtonClickListener {

    private String primaryColor;
    private LinearLayout viewStatusMessage,viewOnlineStatus,viewChatSetting,viewLanguage,viewBlockedUser,viewGames,viewShareApp,viewInviteContact,viewEditGuestname,viewAnnoucement,viewBots;
    private String set = "Set";
    private static final int EDIT_STATUS_MESSAGE = 1, EDIT_USER_NAME = 2, SET_STATUS = 3;
    private String[] statusOptions;
    private TextView tvOnlineStatusSubtitle,tvLanguageSubtitle,tvBlockUserSubtitle,tvBots;
    private ImageView imgBots,imgStatusMessage,imgOnlineStatus,imgChatSetting,imgSettinglanguage,imgBlockUser,imgSettingGames,imgShareApp,imginvitePhoneContacts,imgEditUserName,imgAnnoucement;
    private String[] langOptions, langCodes;
    private int noBlockedUser;
    private final int LOGOUT = 4;
    private Mobile mobileLangs;
    private Lang language;
    private Lang lang;
    private Core core;
    private Settings settingsLang;
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_setting);


        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getMore()) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().getMore());
            toolbar.setTitle(JsonPhp.getInstance().getLang().getMobile().getMore());
        }

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        viewStatusMessage = (LinearLayout) findViewById(R.id.ll_status_message);
        viewOnlineStatus = (LinearLayout) findViewById(R.id.ll_online_status);
        viewChatSetting = (LinearLayout) findViewById(R.id.ll_chat_setting);
        viewLanguage = (LinearLayout) findViewById(R.id.ll_setting_language);
        viewBlockedUser = (LinearLayout) findViewById(R.id.ll_block_user);
        viewGames = (LinearLayout) findViewById(R.id.ll_setting_games);
        viewShareApp = (LinearLayout) findViewById(R.id.ll_share_app);
        viewInviteContact = (LinearLayout) findViewById(R.id.ll_invite_contact);
        viewEditGuestname = (LinearLayout) findViewById(R.id.ll_edit_username);
        viewAnnoucement = (LinearLayout) findViewById(R.id.ll_announcement);
        viewBots = (LinearLayout) findViewById(R.id.ll_bots);

        tvOnlineStatusSubtitle = (TextView) findViewById(R.id.online_status_subtitle);
        tvLanguageSubtitle = (TextView) findViewById(R.id.setting_language_subtitle);
        tvBlockUserSubtitle = (TextView) findViewById(R.id.block_user_subtitle);
        tvBots = (TextView) findViewById(R.id.text_view_bots);


        imgStatusMessage = (ImageView) findViewById(R.id.image_view_status_message);
        imgOnlineStatus = (ImageView) findViewById(R.id.setting_online_status);
        imgChatSetting = (ImageView) findViewById(R.id.setting_chat_setting);
        imgSettinglanguage = (ImageView) findViewById(R.id.setting_language);
        imgBlockUser = (ImageView) findViewById(R.id.setting_block_user);
        imgSettingGames = (ImageView) findViewById(R.id.setting_games);
        imgShareApp = (ImageView) findViewById(R.id.img_share_app);
        imginvitePhoneContacts = (ImageView) findViewById(R.id.img_invite_contact);
        imgEditUserName = (ImageView) findViewById(R.id.img_edit_username);
        imgAnnoucement = (ImageView) findViewById(R.id.image_view_announcement);
        imgBots = (ImageView) findViewById(R.id.image_view_bots);


        language = JsonPhp.getInstance().getLang();
        mobileLangs = language.getMobile();
        lang = JsonPhp.getInstance().getLang();

        tvLanguageSubtitle.setText(SessionData.getInstance().getStatus());
        settingsLang = JsonPhp.getInstance().getNewMobile().getSettings();

        setThemeColor();
        String selectedLang = PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE_FULL);

        if(selectedLang != null){
            tvLanguageSubtitle.setText(selectedLang);
        }else{
            tvLanguageSubtitle.setText("Default");
        }

        if (null != JsonPhp.getInstance().getNewMobile()) {
            settingsLang = JsonPhp.getInstance().getNewMobile().getSettings();
            core = JsonPhp.getInstance().getLang().getCore();
        }

        String status = PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS);
        if(status!= null){
            switch(status){
                case CometChatKeys.StatusKeys.AVALIABLE:
                    tvOnlineStatusSubtitle.setText(core.get3());
                    break;

                case CometChatKeys.StatusKeys.BUSY:
                    tvOnlineStatusSubtitle.setText(core.get4());
                    break;

                case CometChatKeys.StatusKeys.INVISIBLE:
                    tvOnlineStatusSubtitle.setText(core.get5());
                    break;

                case CometChatKeys.StatusKeys.OFFLINE:
                    tvOnlineStatusSubtitle.setText(core.get11());
                    break;
            }
        }

        setBlockedUserText();
        setUpSetting();
        viewBots.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {


                Intent i = new Intent(SettingActivity.this,BotsActivity.class);
                startActivity(i);


            }
        });
    }

    @Override
    protected void onResume() {
        String selectedLang = PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE_FULL);
        if(tvLanguageSubtitle!= null && selectedLang != null){
            tvLanguageSubtitle.setText(selectedLang);
        }else{
            tvLanguageSubtitle.setText("Default");
        }
        super.onResume();
    }


    private void setBlockedUserText(){

        //PreferenceHelper.save("blocked_user_no",blockedUserNames.size());
        String no = PreferenceHelper.get("blocked_user_no");
        if(no != null){
            tvBlockUserSubtitle.setText(no+"");
        }else{
            tvBlockUserSubtitle.setText("0");
            VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getBlockedUserURL(),
                    new VolleyAjaxCallbacks() {

                        @Override
                        public void successCallback(String response) {
                            try {
                                ArrayList blockedUserNames = new ArrayList<>();
                                JSONObject jsonr = new JSONObject(response);
                                Iterator<String> iter = jsonr.keys();
                                while (iter.hasNext()) {
                                    JSONObject user = jsonr.getJSONObject(iter.next());
                                    blockedUserNames.add(user.getString(CometChatKeys.AjaxKeys.NAME));
                                }

                                noBlockedUser = blockedUserNames.size();
                                tvBlockUserSubtitle.setText(noBlockedUser+"");
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {

                        }
                    });
            vHelper.sendAjax();
        }

    }

    private void setThemeColor(){

        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        imgStatusMessage.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgOnlineStatus.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgChatSetting.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgSettinglanguage.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgBlockUser.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgSettingGames.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imginvitePhoneContacts.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgShareApp.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgEditUserName.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgAnnoucement.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgBots.getBackground().setColorFilter(Color.parseColor(primaryColor),PorterDuff.Mode.SRC_ATOP);
    }

    private void setUpSetting(){

        Config config = JsonPhp.getInstance().getConfig();



        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get106()) {
            TextView tvStatusMessage = (TextView) viewStatusMessage.findViewById(R.id.setting_edit_status_messgae);
            tvStatusMessage.setText(JsonPhp.getInstance().getLang().getMobile().get106());
        }

        viewStatusMessage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent statusIntent = new Intent(SettingActivity.this,StatusMessageActivity.class);
                startActivity(statusIntent);
            }
        });


        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getStatus()) {
            TextView tvOnlineStatus = (TextView) viewOnlineStatus.findViewById(R.id.online_status_title);
            tvOnlineStatus.setText(JsonPhp.getInstance().getLang().getMobile().getStatus());
        }

        viewOnlineStatus.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                showChatroomTypeDialog();
            }
        });

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get169()) {
            TextView tvChatSetting = (TextView) viewChatSetting.findViewById(R.id.chat_setting_title);
            tvChatSetting.setText(JsonPhp.getInstance().getLang().getMobile().get169());
        }

        if (!(null != config && config.getUSECOMET().equals("1") && JsonPhp.getInstance().getConfig().getreceiptsEnabled() != null && JsonPhp.getInstance().getConfig().getreceiptsEnabled().equals("1") && JsonPhp.getInstance().getConfig().getlastseenEnabled() != null && JsonPhp.getInstance().getConfig().getlastseenEnabled().equals("1"))) {
            viewChatSetting.setVisibility(View.GONE);
        }else {
            viewChatSetting.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent chatSettingIntent = new Intent(SettingActivity.this,ChatSettingsActivity.class);
                    chatSettingIntent.putExtra("isChatSetting",true);
                    startActivity(chatSettingIntent);
                }
            });

        }

        if ((!TextUtils.isEmpty(JsonPhp.getInstance().getRealtimeTranslation())
                && JsonPhp.getInstance().getRealtimeTranslation().equals("0")) || TextUtils.isEmpty(config.getRttKey())) {
            viewLanguage.setVisibility(View.GONE);
        } else {
            TextView tvLanguage = (TextView) viewLanguage.findViewById(R.id.setting_language_title);
            if (null != JsonPhp.getInstance().getLang().getRealtimetranslate()) {
                tvLanguage.setText(JsonPhp.getInstance().getLang().getRealtimetranslate().get100());
            }else{
                tvLanguage.setText(getString(R.string.Translate_conversation));
            }

            viewLanguage.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent selectLanguageIntent = new Intent(SettingActivity.this,SelectLanguageActivity.class);
                    startActivity(selectLanguageIntent);
                }
            });
        }

        if(config.getBotsEnabled() == 1){
            viewBots.setVisibility(View.VISIBLE);
            if(core.getBots() != null && !core.getBots().isEmpty()){
                tvBots.setText(core.getBots());
            }
        }else{
            viewBots.setVisibility(View.GONE);
        }


        if (BlockUnblockUser.isblockUnblockDisabled()){
            viewBlockedUser.setVisibility(View.GONE);
        }else{
            TextView tvBlockTitle = (TextView) viewBlockedUser.findViewById(R.id.block_user_title);
            if (lang.getBlock() != null){
                tvBlockTitle.setText(lang.getBlock().get4());
            }else{
                tvBlockTitle.setText(getString(R.string.title));
            }
            viewBlockedUser.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent unblockIntent = new Intent(SettingActivity.this,UnblockuserActivity.class);
                    startActivity(unblockIntent);
                }
            });
        }

        if(OtherPlugins.isSinglePlayerGamesEnabled()){
            TextView tvGameTitle = (TextView) viewGames.findViewById(R.id.setting_games_title);

            if (null != mobileLangs && null != mobileLangs.get175()) {
                tvGameTitle.setText(mobileLangs.get175());
            }else{
                tvGameTitle.setText(getString(R.string.games));
            }

            viewGames.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent gameIntent = new Intent(SettingActivity.this,SinglePlayerGameActivity.class);
                    startActivity(gameIntent);
                }
            });
        }else{
            viewGames.setVisibility(View.GONE);
        }


        assert config != null;
        if (  config.getAnnouncementEnabled() != null && config.getAnnouncementEnabled().equals("1")){
            viewAnnoucement.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent AnnouncementIntent = new Intent(SettingActivity.this, AnnouncementActivity.class);
                    startActivity(AnnouncementIntent);
                }
            });
        }else {
            viewAnnoucement.setVisibility(View.GONE);
        }



       /* if (JsonPhp.getInstance().getMobileConfig().getLogoutEnabled() != null && (!TextUtils.isEmpty(JsonPhp.getInstance().getMobileConfig().getLogoutEnabled())
                && JsonPhp.getInstance().getMobileConfig().getLogoutEnabled().equals("0"))) {

            btnLogout.setVisibility(View.GONE);

        } else {
            if(JsonPhp.getInstance().getLang().getMobile().get25()!= null){
                btnLogout.setText(JsonPhp.getInstance().getLang().getMobile().get25());
            }
            btnLogout.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    checkUserConfirmation();
                }
            });
        }*/


        viewShareApp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent shareIntent = new Intent(Intent.ACTION_SEND);
                if (null == JsonPhp.getInstance().getLang() && null == JsonPhp.getInstance().getLang().getMobile()) {
                    shareIntent.putExtra(Intent.EXTRA_TEXT, LocalConfig.getDefaultInviteMessage());
                } else {
                    shareIntent.putExtra(Intent.EXTRA_TEXT, JsonPhp.getInstance().getLang().getMobile().get77());
                }
                shareIntent.setType("text/plain");
                startActivity(shareIntent);
            }
        });

        viewInviteContact.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(new Intent(SettingActivity.this, InviteViaSmsActivity.class));
            }
        });




        if(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST)!= null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST).equals("1")){
            viewEditGuestname.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    View dialogview1 = getLayoutInflater().inflate(R.layout.cc_custom_dialog, null);

                    TextView dialogueTitle1 = (TextView) dialogview1.findViewById(R.id.textViewDialogueTitle);
                    dialogueTitle1.setVisibility(View.GONE);

                    EditText dialogueTextInput1 = (EditText) dialogview1.findViewById(R.id.edittextDialogueInput);
                    dialogueTextInput1.setInputType(InputType.TYPE_CLASS_TEXT);
                    String nameTitle = "Set User name";
                    if (null == settingsLang) {
                        dialogueTextInput1.setHint("Username");
                    } else {
                        nameTitle = settingsLang.getSetUserName();
                        dialogueTextInput1.setHint(settingsLang.getUsernameHint());
                    }
                    SessionData sessionData = SessionData.getInstance();
                    dialogueTextInput1.setText(sessionData.getName());
                    new CustomAlertDialogHelper(SettingActivity.this, nameTitle, dialogview1, set, "", JsonPhp.getInstance().getLang()
                            .getMobile().get32(), SettingActivity.this, EDIT_USER_NAME);
                }
            });
        } else if(PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO) != null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO).equals("1")){
            viewEditGuestname.setVisibility(View.VISIBLE);


            viewEditGuestname.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    View dialogview1 = getLayoutInflater().inflate(R.layout.cc_custom_dialog, null);

                    TextView dialogueTitle1 = (TextView) dialogview1.findViewById(R.id.textViewDialogueTitle);
                    dialogueTitle1.setVisibility(View.GONE);

                    EditText dialogueTextInput1 = (EditText) dialogview1.findViewById(R.id.edittextDialogueInput);
                    dialogueTextInput1.setInputType(InputType.TYPE_CLASS_TEXT);
                    String nameTitle = "Set User name";
                    if (null == settingsLang) {
                        dialogueTextInput1.setHint("Username");
                    } else {
                        nameTitle = settingsLang.getSetUserName();
                        dialogueTextInput1.setHint(settingsLang.getUsernameHint());
                    }
                    SessionData sessionData = SessionData.getInstance();
                    dialogueTextInput1.setText(sessionData.getName());
                    new CustomAlertDialogHelper(SettingActivity.this, nameTitle, dialogview1, set, "", JsonPhp.getInstance().getLang()
                            .getMobile().get32(), SettingActivity.this, EDIT_USER_NAME);
                }
            });

        }else {
            viewEditGuestname.setVisibility(View.GONE);
        }

    }

    private void checkUserConfirmation() {
        LayoutInflater inflater = getLayoutInflater();
        View dialogview = inflater.inflate(R.layout.cc_custom_dialog, null);
        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
        EditText dialogueInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
        dialogueInput.setVisibility(View.GONE);
        Lang lang = JsonPhp.getInstance().getLang();
        dialogueTitle.setText(lang.getMobile().get29());
        new CustomAlertDialogHelper(this, "", dialogview, lang.getMobile().get25(), "", lang.getMobile()
                .get32(), this, LOGOUT);
    }

    void showChatroomTypeDialog(){

        AlertDialog.Builder builder = new AlertDialog.Builder(SettingActivity.this);
        builder.setTitle("Group Type");
        View view = getLayoutInflater().inflate(R.layout.cc_custom_set_status_dialog, null);
        builder.setView(view);

        final RadioGroup radioGroup = (RadioGroup) view.findViewById(R.id.set_status_radio_grp);
        RadioButton radioButtonAviailable = (RadioButton) view.findViewById(R.id.set_status_radio_btn_available);
        RadioButton radioButtonBussy = (RadioButton) view.findViewById(R.id.set_status_radio_btn_bussy);
        RadioButton radioButtonInvisible = (RadioButton) view.findViewById(R.id.set_status_radio_btn_invisible);
        RadioButton radioButtonOfline = (RadioButton) view.findViewById(R.id.set_status_radio_btn_ofline);

        radioButtonAviailable.setText(core.get3());
        radioButtonBussy.setText(core.get4());
        radioButtonInvisible.setText(core.get5());
        radioButtonOfline.setText(core.get11());

        ColorStateList colorStateList = new ColorStateList(
                new int[][]{
                        new int[]{-android.R.attr.state_enabled},
                        new int[]{-android.R.attr.state_checked},
                        new int[]{android.R.attr.state_checked}
                },
                new int[] {
                        Color.BLACK //disabled
                        ,Color.parseColor("#8e8e92")
                        ,Color.parseColor(primaryColor)
                }
        );



        if(CommonUtils.isGreaterThanKitKat()){
            radioButtonAviailable.setButtonTintList(colorStateList);
            radioButtonBussy.setButtonTintList(colorStateList);
            radioButtonInvisible.setButtonTintList(colorStateList);
            radioButtonOfline.setButtonTintList(colorStateList);
        }


        if (TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get81())) {
            builder.setTitle("Set Status");
        } else {
            builder.setTitle(JsonPhp.getInstance().getLang().getMobile().get81());
        }

        builder.setPositiveButton(JsonPhp.getInstance().getLang().getMobile().get39(),
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // positive button logic
                        String newStatus = null;

                        int id = radioGroup.getCheckedRadioButtonId();

                        if (id == R.id.set_status_radio_btn_available) {
                            newStatus = CometChatKeys.StatusKeys.AVALIABLE;

                        } else if (id == R.id.set_status_radio_btn_bussy) {
                            newStatus = CometChatKeys.StatusKeys.BUSY;

                        } else if (id == R.id.set_status_radio_btn_invisible) {
                            newStatus = CometChatKeys.StatusKeys.INVISIBLE;

                        } else if (id == R.id.set_status_radio_btn_ofline) {
                            newStatus = CometChatKeys.StatusKeys.OFFLINE;

                        }

                        final String finalNewStatus = newStatus;
                        VolleyHelper volley = new VolleyHelper(SettingActivity.this, URLFactory.getSendOneToOneMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, finalNewStatus);
                                        SessionData.getInstance().setStatus(finalNewStatus);

                                        switch(finalNewStatus){
                                            case CometChatKeys.StatusKeys.AVALIABLE:
                                                tvOnlineStatusSubtitle.setText(core.get3());
                                                break;

                                            case CometChatKeys.StatusKeys.BUSY:
                                                tvOnlineStatusSubtitle.setText(core.get4());
                                                break;

                                            case CometChatKeys.StatusKeys.INVISIBLE:
                                                tvOnlineStatusSubtitle.setText(core.get5());
                                                break;

                                            case CometChatKeys.StatusKeys.OFFLINE:
                                                tvOnlineStatusSubtitle.setText(core.get11());
                                                break;
                                        }

                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(SettingActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                        }
                                    }
                                });

                        volley.addNameValuePair(CometChatKeys.StatusKeys.STATUS, newStatus);
                        volley.sendAjax();
                        dialog.dismiss();

                    }
                });

        String negativeText = JsonPhp.getInstance().getLang().getMobile().get32();
        builder.setNegativeButton(negativeText,
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // negative button logic

                    }
                });


        String status = PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS);

        if(status.equals(CometChatKeys.StatusKeys.BUSY)){
            radioButtonBussy.setChecked(true);
        }else if(status.equals(CometChatKeys.StatusKeys.INVISIBLE)){
            radioButtonInvisible.setChecked(true);
        }else if(status.equals(CometChatKeys.StatusKeys.OFFLINE)){
            radioButtonOfline.setChecked(true);
        }else{
            radioButtonAviailable.setChecked(true);
        }


            final android.support.v7.app.AlertDialog dialog = builder.create();

        // display dialog


        dialog.setOnShowListener( new DialogInterface.OnShowListener() {
            @Override
            public void onShow(DialogInterface arg0) {
                dialog.getButton(android.support.v7.app.AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.parseColor(primaryColor));
                dialog.getButton(android.support.v7.app.AlertDialog.BUTTON_POSITIVE).setTextColor(Color.parseColor(primaryColor));
            }
        });

        dialog.show();
    }


    @Override
    public void onButtonClick(final android.app.AlertDialog alertDialog, View v, int which, int popupId) {
        if (which == DialogInterface.BUTTON_POSITIVE) {
            switch (popupId) {
                case LOGOUT:
                    if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO)) {
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO);
                        SessionData.getInstance().setBaseData("");
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_NAME);
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_PASSWORD);
                        LogoutHelper.chatLogout();
                        alertDialog.dismiss();
                        finish();
                        return;
                    }
                    LogoutHelper.chatLogout();
                    alertDialog.dismiss();
                    finish();
                    break;


                case EDIT_USER_NAME:
                    EditText statusMessageField1 = (EditText) v.findViewById(R.id.edittextDialogueInput);
                    final String newUserName = statusMessageField1.getText().toString();
                    if (!TextUtils.isEmpty(newUserName)) {
                        VolleyHelper volley = new VolleyHelper(SettingActivity.this, URLFactory.getSendOneToOneMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        SessionData.getInstance().setName(newUserName);

                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_NAME, newUserName);
                                        alertDialog.dismiss();
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(SettingActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                            alertDialog.dismiss();
                                        }
                                    }
                                });

                        volley.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "change_name");
                        volley.addNameValuePair(CometChatKeys.AjaxKeys.NAME, newUserName);
                        volley.sendAjax();

                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                        SessionData.getInstance().setName(newUserName);
                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_NAME, newUserName);
                        alertDialog.dismiss();
                    } else {
                        statusMessageField1.setError((null == JsonPhp.getInstance().getLang()) ? "Please enter a username."
                                : JsonPhp.getInstance().getLang().getMobile().get47());
                        alertDialog.dismiss();

                    }
                    break;
            }
        }else{
            alertDialog.dismiss();
        }
    }
}
