/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.annotation.ColorInt;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Chatrooms;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.lang.reflect.Field;

import static com.inscripts.activities.BlankActivity.stopWheel;

public class CreateChatroomActivity extends SuperActivity {

    private EditText chatroomNameField;
    private EditText chatroomTypeField;
    private TextView chatroomCancle;
    private Button btnCreateChatroom;
    private EditText chatroomPasswordField;

    /*  private Spinner chatroomTypeSelector;
      private TextView passswordLabel, nameLabel, typeLabel;
      private Button createButton, cancelButton;*/
    private String chatroomName, chatroomType, chatroomPassword;
    private TextInputLayout textInputLayoutChatRoomName,textInputLayoutChatroomType,textInputLayoutPassword;
    private Chatrooms chatroomLang;
    private Toolbar toolbar;
  /*  private MobileTheme theme;
    private Css css;*/

    private String primaryColor;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_activity_create_chatroom);


        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        chatroomNameField = (EditText) findViewById(R.id.input_chatroom_name);
        chatroomTypeField = (EditText) findViewById(R.id.input_type);
        chatroomPasswordField = (EditText) findViewById(R.id.input_password);
        chatroomCancle = (TextView) findViewById(R.id.btn_text_cancle);
        btnCreateChatroom = (Button) findViewById(R.id.buttonCreateChatroom);
        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        textInputLayoutChatRoomName = (TextInputLayout) findViewById(R.id.input_layout_chatrroom_name);
        textInputLayoutChatroomType = (TextInputLayout) findViewById(R.id.input_layout_chatroom_type);
        textInputLayoutPassword = (TextInputLayout) findViewById(R.id.input_layout_password);
        chatroomTypeField.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                showChatroomTypeDialog();

            }
        });
        chatroomLang = JsonPhp.getInstance().getLang().getChatrooms();



        /*Set Languages*/
        setActionBarTitle(chatroomLang.get2());
        textInputLayoutChatRoomName.setHint(chatroomLang.get27());
        textInputLayoutPassword.setHint(chatroomLang.get32());
        textInputLayoutChatroomType.setHint(chatroomLang.get28());
        chatroomCancle.setText(JsonPhp.getInstance().getLang().getMobile().get32());
        btnCreateChatroom.setText(JsonPhp.getInstance().getLang().getMobile().get41());

        chatroomNameField.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                textInputLayoutChatRoomName.setError(null);
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        btnCreateChatroom.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                chatroomName = chatroomNameField.getText().toString().trim();
                chatroomPassword = chatroomPasswordField.getText().toString().trim();
                chatroomType = chatroomTypeField.getText().toString().trim();

                if(chatroomName.isEmpty() && chatroomType.isEmpty()){
                    textInputLayoutChatRoomName.setError(chatroomLang.get50());
                    chatroomTypeField.setError("Please select Group Type");
                }else if(chatroomName.isEmpty()){
                    textInputLayoutChatRoomName.setError(chatroomLang.get50());
                }else if(chatroomType.isEmpty()){
                    chatroomTypeField.setError("Please select Group Type");
                }

                if(chatroomPasswordField.getVisibility() == View.VISIBLE && chatroomPassword.isEmpty()){
                    chatroomPasswordField.setText("");
                    textInputLayoutPassword.setError(chatroomLang.get26());
                }

                if (!chatroomName.isEmpty() && !chatroomType.isEmpty()) {

                    if (chatroomType.equals(chatroomLang.get30())) {

                        if (!chatroomPassword.isEmpty()) {
                            createChatroom(chatroomName, chatroomPassword, chatroomType);
                        } /*else {
                            chatroomPasswordField.setText("");
                            chatroomPasswordField.setError(chatroomLang.get26());
                        }*/
                    } else {
                        createChatroom(chatroomName, chatroomPassword, chatroomType);
                    }

                } /*else {
                    chatroomNameField.setText("");
                    assert textInputLayoutChatRoomName!= null;
                    textInputLayoutChatRoomName.setError(chatroomLang.get50());
                    chatroomTypeField.setError("Please select Group Type");
                }*/
            }
        });

        chatroomCancle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        /*chatroomNameField = (EditText) findViewById(R.id.editTextChatroomName);
        chatroomPasswordField = (EditText) findViewById(R.id.editTextChatroomPassword);
        chatroomTypeSelector = (Spinner) findViewById(R.id.spinnerChatroomType);
        passswordLabel = (TextView) findViewById(R.id.textViewChatroomPassword);
        createButton = (Button) findViewById(R.id.buttonCreateChatroom);
        cancelButton = (Button) findViewById(R.id.buttonCancel);
//        typeLabel = (TextView) findViewById(R.id.textViewChatroomType);
//        nameLabel = (TextView) findViewById(R.id.textViewChatroomName);
        wheel = (ProgressWheel) findViewById(R.id.progressWheel);

        theme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();


//        chatroomPasswordField.setVisibility(View.GONE);
//        passswordLabel.setVisibility(View.GONE);

        chatroomLang = JsonPhp.getInstance().getLang().getChatrooms();

        setActionBarTitle(chatroomLang.get2());
//        passswordLabel.setText(chatroomLang.get32());
//        typeLabel.setText(chatroomLang.get28());
//        nameLabel.setText(chatroomLang.get27());

        List<String> spinnerArray = new ArrayList<String>();
        spinnerArray.add(chatroomLang.get29());
        spinnerArray.add(chatroomLang.get30());
        spinnerArray.add(chatroomLang.get31());

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,
                spinnerArray);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//        chatroomTypeSelector.setAdapter(adapter);

//        chatroomTypeSelector.setOnItemSelectedListener(new OnItemSelectedListener() {
//
//            @Override
//            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
//                if (position == CometChatKeys.ChatroomKeys.TypeKeys.PASSWORD_PROTECTED) {
//                    passswordLabel.setVisibility(View.VISIBLE);
//                    chatroomPasswordField.setVisibility(View.VISIBLE);
//                    passswordLabel.setText(JsonPhp.getInstance().getLang().getChatrooms().get32());
//                    chatroomPasswordField.requestFocus();
//                } else {
//                    chatroomPasswordField.setVisibility(View.GONE);
//                    passswordLabel.setVisibility(View.GONE);
//                }
//            }
//
//            @Override
//            public void onNothingSelected(AdapterView<?> parent) {
//            }
//        });

        etChatroomType.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                new MaterialDialog.Builder(CreateChatroomActivity.this)
                        .title("Group Type")
                        .items(R.array.chatroom_type_array)
                        .itemsCallbackSingleChoice(-1, new MaterialDialog.ListCallbackSingleChoice() {
                            @Override
                            public boolean onSelection(MaterialDialog dialog, View itemView, int which, CharSequence text) {
                                Toast.makeText(CreateChatroomActivity.this, "Clicked", Toast.LENGTH_LONG).show();
                                return false;
                            }
                        })
                        .positiveText(R.string.dialog_positive_text)
                        .negativeText(R.string.dialog_negative_text)
                        .show();
            }
        });

        cancelButton.setText(JsonPhp.getInstance().getLang().getMobile().get32());
        createButton.setText(JsonPhp.getInstance().getLang().getMobile().get41());
        cancelButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                finish();
            }
        });
        createButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View view) {
                chatroomName = chatroomNameField.getText().toString().trim();
//                chatroomPassword = chatroomPasswordField.getText().toString().trim();
//                chatroomType = String.valueOf(chatroomTypeSelector.getSelectedItemPosition());

                if (!chatroomName.isEmpty()) {
                    if (chatroomType.equals(String.valueOf(CometChatKeys.ChatroomKeys.TypeKeys.PASSWORD_PROTECTED))) {
                        if (!chatroomPassword.isEmpty()) {
                            createChatroom(chatroomName, chatroomPassword, chatroomType);
                        } else {
//                            chatroomPasswordField.setText("");
//                            chatroomPasswordField.setError(chatroomLang.get26());
                        }
                    } else {
                        createChatroom(chatroomName, chatroomPassword, chatroomType);
                    }

                } else {
                    chatroomNameField.setText("");
                    chatroomNameField.setError(chatroomLang.get50());
                }
            }
        });

        if (null != theme && null != theme.getActionbarColor()) {
            int btnColor = Color.parseColor(theme.getActionbarColor());
            cancelButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            createButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelButton.setTextColor(btnColor);
            createButton.setTextColor(btnColor);
            wheel.setBarColor(btnColor);
        } else if (null != css && null != css.getTabTitleBackground()) {
            int btnColor = Color.parseColor(css.getTabTitleBackground());
            cancelButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            createButton.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, btnColor));
            cancelButton.setTextColor(btnColor);
            createButton.setTextColor(btnColor);
            wheel.setBarColor(btnColor);
        }*/

        setThemeColor();
    }


    void setThemeColor(){
        chatroomCancle.setTextColor(Color.parseColor(primaryColor));
        setInputTextLayoutColor(chatroomNameField,Color.parseColor("#a2a2a5"));
        setInputTextLayoutColor(chatroomTypeField,Color.parseColor("#a2a2a5"));
        setInputTextLayoutColor(chatroomPasswordField,Color.parseColor("#a2a2a5"));
        Drawable background = btnCreateChatroom.getBackground();
        background.setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
    }


    public static void setInputTextLayoutColor(EditText editText, @ColorInt int color) {
        TextInputLayout til = (TextInputLayout) editText.getParent();
        try {
            Field fDefaultTextColor = TextInputLayout.class.getDeclaredField("mDefaultTextColor");
            fDefaultTextColor.setAccessible(true);
            fDefaultTextColor.set(til, new ColorStateList(new int[][]{{0}}, new int[]{color}));

            Field fFocusedTextColor = TextInputLayout.class.getDeclaredField("mFocusedTextColor");
            fFocusedTextColor.setAccessible(true);
            fFocusedTextColor.set(til, new ColorStateList(new int[][]{{0}}, new int[]{color}));
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    void showChatroomTypeDialog(){

        AlertDialog.Builder builder = new AlertDialog.Builder(CreateChatroomActivity.this);
        if(chatroomLang.getGroupType()!= null){
            builder.setTitle(chatroomLang.getGroupType());
        }else{
            builder.setTitle("Group Type");
        }
        View view = getLayoutInflater().inflate(R.layout.cc_custom_create_chatroom_dialog, null);
        builder.setView(view);

        final RadioGroup radioGroup = (RadioGroup) view.findViewById(R.id.create_chatroom_radio_grp);
        RadioButton radioButtonPublic = (RadioButton) view.findViewById(R.id.create_chatroom_radio_btn_public);
        RadioButton radioButtonPassword = (RadioButton) view.findViewById(R.id.create_chatroom_radio_btn_password);
        RadioButton radioButtonPublicinvite = (RadioButton) view.findViewById(R.id.create_chatroom_radio_btn_invite);

        radioButtonPublic.setText(chatroomLang.get29());
        radioButtonPassword.setText(chatroomLang.get30());
        radioButtonPublicinvite.setText(chatroomLang.get31());

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
        if (CommonUtils.isGreaterThanKitKat()) {
            radioButtonPublic.setButtonTintList(colorStateList);
            radioButtonPassword.setButtonTintList(colorStateList);
            radioButtonPublicinvite.setButtonTintList(colorStateList);
        }

        builder.setPositiveButton(JsonPhp.getInstance().getLang().getMobile().get39(),
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // positive button logic
                        int id = radioGroup.getCheckedRadioButtonId();
                        textInputLayoutChatroomType.setError(null);
                        if (id == R.id.create_chatroom_radio_btn_public) {
                            chatroomType = chatroomLang.get29();
                            chatroomTypeField.setText(chatroomType);
                            chatroomPasswordField.setVisibility(View.GONE);

                        } else if (id == R.id.create_chatroom_radio_btn_password) {
                            chatroomType = chatroomLang.get30();
                            chatroomTypeField.setText(chatroomType);
                            chatroomPasswordField.setVisibility(View.VISIBLE);

                        } else if (id == R.id.create_chatroom_radio_btn_invite) {
                            chatroomType = chatroomLang.get31();
                            chatroomTypeField.setText(chatroomType);
                            chatroomPasswordField.setVisibility(View.GONE);

                        }

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


        String type = chatroomTypeField.getText().toString();
        if(type.equals(chatroomLang.get30())){
            radioButtonPassword.setChecked(true);
        }else if(type.equals(chatroomLang.get31())){
            radioButtonPublicinvite.setChecked(true);
        }else{
            radioButtonPublic.setChecked(true);
        }


        final AlertDialog dialog = builder.create();

        // display dialog


        dialog.setOnShowListener( new DialogInterface.OnShowListener() {
            @Override
            public void onShow(DialogInterface arg0) {
                dialog.getButton(AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.parseColor(primaryColor));
                dialog.getButton(AlertDialog.BUTTON_POSITIVE).setTextColor(Color.parseColor(primaryColor));
            }
        });

        dialog.show();
    }


    @SuppressLint("HandlerLeak")
    private void createChatroom(final String chatroomName, final String chatroomPassword, String chatroomType) {
        VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), URLFactory.getCreateChatroomURL(),
                new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        long chatroomId;
                        try {
                            JSONObject json = new JSONObject(response);
                            chatroomId = json.getLong("id");
                        } catch (Exception e) {
                            chatroomId = Long.parseLong(response);
                        }
                        if (chatroomId == 0) {
                            Toast.makeText(getApplicationContext(), chatroomLang.get38(), Toast.LENGTH_SHORT).show();
                            stopWheel();
                        } else {
                            try {
                                ChatroomManager.joinChatroom(chatroomId, chatroomName, EncryptionHelper.encodeIntoShaOne(chatroomPassword), 1, CreateChatroomActivity.this, new CometchatCallbacks() {
                                    @Override
                                    public void successCallback() {
                                        stopWheel();
                                        finish();
                                    }

                                    @Override
                                    public void failCallback() {
                                        stopWheel();
                                    }
                                });
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Toast.makeText(getApplicationContext(), StaticMembers.PLEASE_CHECK_YOUR_INTERNET, Toast.LENGTH_SHORT).show();
                        } else {
                            Toast.makeText(CreateChatroomActivity.this, "An error occured. Please contact the website administrator.", Toast.LENGTH_LONG).show();
                        }
                    }
                });

        if(chatroomType.equals(chatroomLang.get30())){  // Password protected
            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CHATROOM_TYPE, 1);
        }else if(chatroomType.equals(chatroomLang.get31())){ // invite only
            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CHATROOM_TYPE, 2);
        }else {
            vHelper.addNameValuePair(CometChatKeys.AjaxKeys.CHATROOM_TYPE, 0);
        }
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, chatroomPassword);
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.NAME, chatroomName);
        vHelper.sendAjax();
    }

    @Override
    public void finish() {
        super.finish();
    }


}
