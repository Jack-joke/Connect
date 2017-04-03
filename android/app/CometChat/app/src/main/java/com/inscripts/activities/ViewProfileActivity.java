package com.inscripts.activities;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.content.res.ColorStateList;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.os.Parcelable;
import android.provider.MediaStore;
import android.support.v7.app.AlertDialog;
import android.text.Html;
import android.text.InputType;
import android.text.TextUtils;
import android.view.View;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.avatarServices.AvatarService;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.Core;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.NewMobile;
import com.inscripts.jsonphp.Settings;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;

import org.json.JSONObject;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class ViewProfileActivity extends SuperActivity implements View.OnClickListener, OnAlertDialogButtonClickListener {

    private static Uri fileUri, tempFileURI;
    private LinearLayout viewStatusMessage, viewOnlineStatus;
    private ImageView imgStatusMessage, imgOnlineStatus, imgEditUserName;
    private ProfileRoundedImageView avatarImage;
    private TextView username;
    private TextView tvOnlineStatusSubtitle;
    private Settings settingsLang;
    private Core core;

    private String primaryColor;
    private String set = "Set";
    private static final int EDIT_USER_NAME = 2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_profile);

        if (null != JsonPhp.getInstance().getNewMobile()) {
            settingsLang = JsonPhp.getInstance().getNewMobile().getSettings();
            core = JsonPhp.getInstance().getLang().getCore();
        }

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().getViewProfile()) {
            setActionBarTitle(JsonPhp.getInstance().getLang().getMobile().getViewProfile());
        }

        viewStatusMessage = (LinearLayout) findViewById(R.id.ll_status_message);
        viewOnlineStatus = (LinearLayout) findViewById(R.id.ll_online_status);

        tvOnlineStatusSubtitle = (TextView) findViewById(R.id.online_status_subtitle);

        imgStatusMessage = (ImageView) findViewById(R.id.image_view_status_message);
        imgOnlineStatus = (ImageView) findViewById(R.id.setting_online_status);
        imgEditUserName = (ImageView) findViewById(R.id.iv_edit_username);

        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        setupProfile();
        setThemeColor();

        String status = PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS);
        if (status != null) {
            switch (status) {
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
        setupSetting();
    }

    private void setThemeColor() {
        setActionBarColor(primaryColor);
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));

        imgStatusMessage.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        imgOnlineStatus.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
    }

    private void setupProfile() {
        SessionData sessionData = SessionData.getInstance();
        try {
            username = (TextView) findViewById(R.id.textViewProfileUserName);
            avatarImage = (ProfileRoundedImageView) findViewById(R.id.imageViewUserProfilePhoto);
            ImageView ivEditImage = (ImageView) findViewById(R.id.iv_change_profile);

            avatarImage.setBorderWidth(1);
            ivEditImage.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);

            if (!TextUtils.isEmpty(sessionData.getName())) {
                if (!sessionData.getName().startsWith("Guest-")) {
                    username.setText(Html.fromHtml("Guest-" + sessionData.getName() ));
                } else {
                    username.setText(Html.fromHtml(sessionData.getName()));
                }
            }

            String url = sessionData.getAvatarLink();
            if (null != url) {
//                LocalStorageFactory.getPicassoInstance().load(url).placeholder(R.drawable.default_avatar)
//                        .into(avatarImage);
                LocalStorageFactory.LoadImageUsingURL(this, url,avatarImage,R.drawable.default_avatar);
            }

//            if (null != settingsLang) {
//                changePicHint.setText(settingsLang.getChangeProfilePic());
//            }

            MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
            FrameLayout imageContainer = (FrameLayout) findViewById(R.id.relativeLayoutProfilePicContainer);
            if (mobileConfig != null) {
                if (Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                    ivEditImage.setVisibility(View.GONE);
                } else {
                    ivEditImage.setOnClickListener(this);
                }
            } else {
                if (LocalConfig.LOGIN_TYPE == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                    ivEditImage.setVisibility(View.GONE);
                } else {
                    ivEditImage.setOnClickListener(this);
                }
            }
//            ivEditImage.setVisibility(View.VISIBLE);
//            ivEditImage.setOnClickListener(this);

        } catch (Exception e) {
            avatarImage.setImageResource(R.drawable.default_avatar);
            username.setText(sessionData.getName());
            Logger.error("ViewProfileActivity : Cannot setup profile: setupProfile() : " + e.getMessage());
            e.printStackTrace();
        }
    }

    private void setupSetting() {

        Config config = JsonPhp.getInstance().getConfig();

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get106()) {
            TextView tvStatusMessage = (TextView) viewStatusMessage.findViewById(R.id.setting_edit_status_messgae);
            tvStatusMessage.setText(JsonPhp.getInstance().getLang().getMobile().get106());
        }

        viewStatusMessage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent statusIntent = new Intent(ViewProfileActivity.this, StatusMessageActivity.class);
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

        if (PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST) != null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST).equals("1")) {
            imgEditUserName.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    View dialogview1 = getLayoutInflater().inflate(R.layout.custom_dialog, null);

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

                    String name = "";
                    if (!TextUtils.isEmpty(sessionData.getName()) && sessionData.getName().startsWith("Guest-")) {
                        name = sessionData.getName().substring(6);
                    } else {
                        name = sessionData.getName();
                    }
                    dialogueTextInput1.setText(name);
                    new CustomAlertDialogHelper(ViewProfileActivity.this, nameTitle, dialogview1, set, "", JsonPhp.getInstance().getLang()
                            .getMobile().get32(), ViewProfileActivity.this, EDIT_USER_NAME);
                }
            });
        } else if (PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO) != null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO).equals("1")) {
            imgEditUserName.setVisibility(View.VISIBLE);

            imgEditUserName.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    View dialogview1 = getLayoutInflater().inflate(R.layout.custom_dialog, null);

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
                    String name = "";
                    if (!TextUtils.isEmpty(sessionData.getName()) && sessionData.getName().startsWith("Guest-")) {
                        name = sessionData.getName().substring(6);
                    } else {
                        name = sessionData.getName();
                    }
                    dialogueTextInput1.setText(name);
                    new CustomAlertDialogHelper(ViewProfileActivity.this, nameTitle, dialogview1, set, "", JsonPhp.getInstance().getLang()
                            .getMobile().get32(), ViewProfileActivity.this, EDIT_USER_NAME);
                }
            });

        } else {
            imgEditUserName.setVisibility(View.GONE);
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            if (resultCode == Activity.RESULT_OK) {
                if (requestCode == 1) {
                    boolean isCamera;
                    isCamera = ((data == null) || (data.hasExtra(MediaStore.EXTRA_OUTPUT)));

                    Intent intent = new Intent("com.android.camera.action.CROP");
                    if (isCamera) {
                        intent.setDataAndType(fileUri, StaticMembers.IMAGE_TYPE);
                    } else {
                        intent.setDataAndType(data.getData(), StaticMembers.IMAGE_TYPE);
                    }

                    intent.putExtra("crop", "true");
                    intent.putExtra("aspectX", 1);
                    intent.putExtra("aspectY", 1);
                    // intent.putExtra("outputX", 150);
                    // intent.putExtra("outputY", 150);
                    intent.putExtra("scale", true);
                    intent.putExtra("noFaceDetection", true);
                    intent.putExtra("return-data", false);
                    tempFileURI = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);

                    intent.putExtra(MediaStore.EXTRA_OUTPUT, tempFileURI);
                    startActivityForResult(intent, 2);
                } else if (requestCode == 2) {
                    Bitmap profilePic = null;
                    String fileName, filePath;
                    Bundle extras = data.getExtras();
                    if (null != extras) {
                        profilePic = extras.getParcelable("data");
                    }
                    if (profilePic == null) {
                        File image = new File(tempFileURI.getPath());
                        fileName = image.getName();
                        BitmapFactory.Options bmOptions = new BitmapFactory.Options();
                        try {
                            profilePic = BitmapFactory.decodeFile(image.getPath(), bmOptions);
                        } catch (Exception e) {
                            e.printStackTrace();
                        } catch (OutOfMemoryError e) {
                            bmOptions.inSampleSize = 2;
                            profilePic = BitmapFactory.decodeFile(image.getPath(), bmOptions);
                        }
                        avatarImage.setImageBitmap(profilePic);
                    } else {
                        avatarImage.setImageBitmap(profilePic);
                        filePath = LocalStorageFactory.getFilePathFromIntent(data);
                        if (null == filePath) {
                            fileName = "temp.png";
                        } else {
                            fileName = filePath.substring(filePath.lastIndexOf("/") + 1, filePath.length());
                        }
                    }

                    fileName = fileName.replaceAll("-", "").replaceAll(" ", "_").replaceAll("_", "");

                    changeAvatar(profilePic, fileName, new CometchatCallbacks() {

                        @Override
                        public void successCallback() {
                            SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                            Toast.makeText(ViewProfileActivity.this, getResources().getString(R.string.avatar_changed_success), Toast.LENGTH_SHORT).show();
                        }

                        @Override
                        public void failCallback() {
                            Logger.error("change avatar failed");
                            Toast.makeText(ViewProfileActivity.this, getResources().getString(R.string.avatar_changed_failure), Toast.LENGTH_SHORT).show();
                        }
                    });
                } else if (requestCode == 3) {
                    if (data != null) {
                        fileUri = data.getData();
                        Intent intent = new Intent("com.android.camera.action.CROP");
                        intent.setData(fileUri);
                        intent.putExtra("crop", "true");
                        intent.putExtra("aspectX", 1);
                        intent.putExtra("aspectY", 2);
                        intent.putExtra("scale", true);
                        intent.putExtra("noFaceDetection", true);
                        intent.putExtra("return-data", false);
                        tempFileURI = Uri.fromFile(getOutputCroppedFile(StaticMembers.MEDIA_TYPE_IMAGE));
                        intent.putExtra(MediaStore.EXTRA_OUTPUT, tempFileURI);
                        startActivityForResult(intent, 4);

                    }
                } else if (requestCode == 4) {
                    Bitmap profilePic;
                    Bundle extras = data.getExtras();
                    profilePic = extras.getParcelable("data");
                    if (profilePic == null) {
                        File image = new File(tempFileURI.getPath());
                        PreferenceHelper.save(PreferenceKeys.DataKeys.WALLPAPER_FILENAME, String.valueOf(image.getPath()));
                        Toast.makeText(this, "Wallpaper Set", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void onButtonClick(final android.app.AlertDialog alertDialog, View v, int which, int popupId) {
        if (which == DialogInterface.BUTTON_POSITIVE) {
            switch (popupId) {
                case EDIT_USER_NAME:
                    EditText statusMessageField1 = (EditText) v.findViewById(R.id.edittextDialogueInput);
                    final String newUserName = statusMessageField1.getText().toString();
                    if (!TextUtils.isEmpty(newUserName)) {
                        String url = "";
                        String key = "";

                        if ((PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST) != null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST).equals("1")) ||
                                (PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO) != null && PreferenceHelper.get(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO).equals("1"))) {
                            url = URLFactory.getSendOneToOneMessageURL();
                            key = CometChatKeys.AjaxKeys.GUEST_NAME;
                        } else {
                            url = URLFactory.getPhoneRegisterURL();
                            key = CometChatKeys.AjaxKeys.ACTION;
                        }

                        VolleyHelper volley = new VolleyHelper(ViewProfileActivity.this, url,
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        Logger.error("ViewProfileAcivity : onButtonClick() : success : " + response);
                                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        SessionData.getInstance().setName(newUserName);
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_NAME, newUserName);

                                        String displayName = "";
                                        if (!TextUtils.isEmpty(newUserName) && !newUserName.startsWith("Guest-")) {
                                            displayName = "Guest-" + newUserName;
                                        }
                                        username.setText(displayName);

                                        alertDialog.dismiss();
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        Logger.error("ViewProfileAcivity : onButtonClick() : failure : " + response);
                                        if (isNoInternet) {
                                            Toast.makeText(ViewProfileActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                            alertDialog.dismiss();
                                        }
                                    }
                                });
                        if (key.equalsIgnoreCase(CometChatKeys.AjaxKeys.GUEST_NAME)) {
                            volley.addNameValuePair(key, newUserName);
                        } else {
                            volley.addNameValuePair(key, "change_name");
                        }

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

                default:
                    Logger.error("ViewProfileActivity : onButtonClick : default case");
                    break;
            }
        } else {
            alertDialog.dismiss();
        }
    }

    private void showChatroomTypeDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(ViewProfileActivity.this);
        builder.setTitle("Group Type");
        View view = getLayoutInflater().inflate(R.layout.custom_set_status_dialog, null);
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
                new int[]{
                        Color.BLACK //disabled
                        , Color.parseColor("#8e8e92")
                        , Color.parseColor(primaryColor)
                }
        );

        if (CommonUtils.isGreaterThanKitKat()) {
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

                        switch (id) {

                            case R.id.set_status_radio_btn_available:
                                newStatus = CometChatKeys.StatusKeys.AVALIABLE;
                                break;

                            case R.id.set_status_radio_btn_bussy:
                                newStatus = CometChatKeys.StatusKeys.BUSY;
                                break;

                            case R.id.set_status_radio_btn_invisible:
                                newStatus = CometChatKeys.StatusKeys.INVISIBLE;
                                break;

                            case R.id.set_status_radio_btn_ofline:
                                newStatus = CometChatKeys.StatusKeys.OFFLINE;
                                break;
                        }

                        final String finalNewStatus = newStatus;
                        VolleyHelper volley = new VolleyHelper(ViewProfileActivity.this, URLFactory.getSendOneToOneMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, finalNewStatus);
                                        SessionData.getInstance().setStatus(finalNewStatus);

                                        switch (finalNewStatus) {
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
                                            Toast.makeText(ViewProfileActivity.this, StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
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

        if (status.equals(CometChatKeys.StatusKeys.BUSY)) {
            radioButtonBussy.setChecked(true);
        } else if (status.equals(CometChatKeys.StatusKeys.INVISIBLE)) {
            radioButtonInvisible.setChecked(true);
        } else if (status.equals(CometChatKeys.StatusKeys.OFFLINE)) {
            radioButtonOfline.setChecked(true);
        } else {
            radioButtonAviailable.setChecked(true);
        }

        final android.support.v7.app.AlertDialog dialog = builder.create();

        // display dialog

        dialog.setOnShowListener(new DialogInterface.OnShowListener() {
            @Override
            public void onShow(DialogInterface arg0) {
                dialog.getButton(android.support.v7.app.AlertDialog.BUTTON_NEGATIVE).setTextColor(Color.parseColor(primaryColor));
                dialog.getButton(android.support.v7.app.AlertDialog.BUTTON_POSITIVE).setTextColor(Color.parseColor(primaryColor));
            }
        });

        dialog.show();
    }

    private static File getOutputCroppedFile(int type) {
        File mediaStorageDir = new File(Environment.getExternalStorageDirectory(), PreferenceHelper.getContext()
                .getString(R.string.app_name));

        if (!mediaStorageDir.exists()) {
            if (!mediaStorageDir.mkdirs()) {
                return null;
            }
        }
        // Create a media file name
        String timeStamp = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date());
        File mediaFile = null;
        if (type == StaticMembers.MEDIA_TYPE_IMAGE) {
            String imageStoragePath = LocalStorageFactory.getWallpaperStoragePath();
            LocalStorageFactory.createDirectory(imageStoragePath);
            String filename = "IMG" + timeStamp + ".jpg";
            mediaFile = new File(imageStoragePath + filename);
        }
        return mediaFile;
    }

    @Override
    public void onClick(View v) {
        NewMobile newmobilelangs = JsonPhp.getInstance().getNewMobile();

        switch (v.getId()) {

            case R.id.iv_change_profile:
                Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);

                List<Intent> cameraIntents = new ArrayList<Intent>();
                PackageManager packageManager = getPackageManager();
                List<ResolveInfo> listCam = packageManager.queryIntentActivities(cameraIntent, 0);
                for (ResolveInfo res : listCam) {
                    String packageName = res.activityInfo.packageName;
                    Intent intent = new Intent(cameraIntent);
                    intent.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
                    intent.setPackage(packageName);
                    intent.putExtra("return-data", true);
                    cameraIntents.add(intent);
                }

                Intent galleryIntent = new Intent(Intent.ACTION_PICK, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                galleryIntent.setType(StaticMembers.IMAGE_TYPE);

                Intent chooserIntent;
                if (null == newmobilelangs && null == newmobilelangs.getCommon().getCompleteAction()) {
                    chooserIntent = Intent.createChooser(galleryIntent, "Complete action using");
                } else {
                    chooserIntent = Intent.createChooser(galleryIntent, newmobilelangs.getCommon()
                            .getCompleteAction());
                }
                chooserIntent.putExtra(Intent.EXTRA_INITIAL_INTENTS, cameraIntents.toArray(new Parcelable[cameraIntents.size()]));
                startActivityForResult(chooserIntent, 1);
                break;

            default:
                Logger.error("ViewProfileActivity : onClick() : default case executed");
                break;
        }
    }

    public void changeAvatar(Bitmap bitmap, String filename, final CometchatCallbacks callbacks) {
        try {
            Handler handler = new Handler() {

                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    String response = msg.obj.toString();
                    Logger.error("Response of change avatar =" + response);
                    switch (msg.what) {
                        case 200:
                            try {
                                JSONObject jsonresponse = new JSONObject(response);
                                if (jsonresponse.getString("status").equals("1")) {
                                    callbacks.successCallback();
                                    SessionData.getInstance().setAvatarLink(jsonresponse.getString("avatar"));
                                }
                            } catch (Exception e) {
                                callbacks.failCallback();
                                e.printStackTrace();
                            }
                            break;
                        default:
                            break;
                    }
                }
            };

//            ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
//                    URLFactory.getPhoneRegisterURL(), handler);
//            if (bitmap != null) {
//                ByteArrayOutputStream outstr = new ByteArrayOutputStream();
//                String fileExtension = filename.substring(filename.lastIndexOf(".") + 1);
//                if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
//                    bitmap.compress(Bitmap.CompressFormat.JPEG, 100, outstr);
//                } else {
//                    bitmap.compress(Bitmap.CompressFormat.PNG, 100, outstr);
//                }
//                byte[] outputData = outstr.toByteArray();
//
//                File compressedImageFile = LocalStorageFactory.writeFile(LocalStorageFactory.getImageStoragePath(),
//                        filename, outputData);
//                imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "change_avatar");
//                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, compressedImageFile);
//                imageSendHelper.sendImageAjax();
//            }
            AvatarService.setHandler(handler);
            AvatarService.startActionChangeAvatar(this, filename, callbacks, bitmap);
        } catch (Exception e) {
            callbacks.failCallback();
            e.printStackTrace();
        }
    }
}
