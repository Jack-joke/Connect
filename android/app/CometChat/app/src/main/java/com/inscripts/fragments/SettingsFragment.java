/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.fragments;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.os.Parcelable;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.text.Html;
import android.text.InputType;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.activities.ChatSettingsActivity;
import com.inscripts.activities.CoDLoginActivity;
import com.inscripts.activities.GuestLoginActivity;
import com.inscripts.activities.InviteViaSmsActivity;
import com.inscripts.activities.R;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.custom.ProfileRoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.LogoutHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.Core;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.NewMobile;
import com.inscripts.jsonphp.Settings;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.CometChatKeys.StatusKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.PushNotificationsManager;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

public class SettingsFragment extends Fragment implements OnAlertDialogButtonClickListener, OnClickListener {

    private ProfileRoundedImageView avatarImage;
    private TextView username, statusMessage;
    private ImageView status;
    private static final int EDIT_STATUS_MESSAGE = 1, EDIT_USER_NAME = 2, SET_STATUS = 3;
    private final int LOGOUT = 4;
    private String[] langOptions, langCodes;
    private static Uri fileUri, tempFileURI;
    private Settings settingsLang;
    private Lang lang;
    private Mobile mobileLangs;
    private BroadcastReceiver customReceiver;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setHasOptionsMenu(true);
        lang = JsonPhp.getInstance().getLang();

        if (null != lang) {
            mobileLangs = lang.getMobile();
        }

        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                Bundle extras = intent.getExtras();
                if (extras.containsKey(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_USER_STATUS)) {
                    if (SessionData.getInstance().getStatusMessage() != null) {
                        statusMessage.setText(Html.fromHtml(SessionData.getInstance().getStatusMessage()));
                    } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.STATUS_MESSAGE)) {
                        statusMessage.setText(Html.fromHtml(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS_MESSAGE)));
                    } else {
                        statusMessage.setText(R.string.default_status_message);
                    }
                }
            }
        };
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_settings, container, false);
        if (null != JsonPhp.getInstance().getNewMobile()) {
            settingsLang = JsonPhp.getInstance().getNewMobile().getSettings();
        }
        setupProfileActions(view);
        setupProfile(view);
        return view;
    }

    private void setupProfileActions(View view) {
        RelativeLayout editStatusButton = (RelativeLayout) view.findViewById(R.id.linearLayoutEditStatusMessage);
        editStatusButton.setOnClickListener(this);
        RelativeLayout setStatusButton = (RelativeLayout) view.findViewById(R.id.linearLayoutSetStatus);
        setStatusButton.setOnClickListener(this);
        RelativeLayout inviteUsersButton = (RelativeLayout) view.findViewById(R.id.linearLayoutInviteUsers);
        inviteUsersButton.setOnClickListener(this);
        RelativeLayout logoutButton = (RelativeLayout) view.findViewById(R.id.linearLayoutLogout);
        logoutButton.setOnClickListener(this);
        RelativeLayout translateButton = (RelativeLayout) view.findViewById(R.id.linearLayoutTranslateConversation);
        RelativeLayout notifications = (RelativeLayout) view.findViewById(R.id.relativeLayoutNotificationSettings);
        notifications.setOnClickListener(this);
        RelativeLayout editUserName = (RelativeLayout) view.findViewById(R.id.relativeLayoutEditUserName);
        RelativeLayout shareApp = (RelativeLayout) view.findViewById(R.id.relativeLayoutShareApp);
        //RelativeLayout setWallpaper = (RelativeLayout) view.findViewById(R.id.relativeLayoutChatWallpaper);


        Config config = JsonPhp.getInstance().getConfig();

        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get169()) {
            TextView tv = (TextView) notifications.findViewById(R.id.textViewNotificationSettings);
            tv.setText(JsonPhp.getInstance().getLang().getMobile().get169());
        }
        if ((!TextUtils.isEmpty(JsonPhp.getInstance().getRealtimeTranslation())
                && JsonPhp.getInstance().getRealtimeTranslation().equals("0")) || TextUtils.isEmpty(config.getRttKey())) {
            translateButton.setVisibility(View.GONE);
        } else {
            translateButton.setOnClickListener(this);
            TextView t = (TextView) view.findViewById(R.id.textViewTranslateConversation);
            if (null != JsonPhp.getInstance().getLang().getRealtimetranslate()) {
                t.setText(JsonPhp.getInstance().getLang().getRealtimetranslate().get100());
            }
        }

        if (JsonPhp.getInstance().getMobileConfig().getLogoutEnabled() != null && (!TextUtils.isEmpty(JsonPhp.getInstance().getMobileConfig().getLogoutEnabled())
                && JsonPhp.getInstance().getMobileConfig().getLogoutEnabled().equals("0"))) {
            logoutButton.setVisibility(View.GONE);
        } else {
            translateButton.setOnClickListener(this);
            TextView t = (TextView) view.findViewById(R.id.textViewTranslateConversation);
            if (null != JsonPhp.getInstance().getLang().getRealtimetranslate()) {
                t.setText(JsonPhp.getInstance().getLang().getRealtimetranslate().get100());
            }
        }

/*WallPaper *//*
        if((!TextUtils.isEmpty(JsonPhp.getInstance().getChatWallpaper()) && JsonPhp.getInstance().getChatWallpaper().equals("0"))){
            setWallpaper.setVisibility(View.GONE);
        }else{
            setWallpaper.setOnClickListener(this);
            TextView t = (TextView) view.findViewById(R.id.textChatWallpaper);
            if(null != JsonPhp.getInstance().getLang().getRealtimetranslate()){
                t.setText(JsonPhp.getInstance().getLang().getRealtimetranslate().get100());
            }
        }
*//*WallPaper */

        MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();

        if (mobileConfig != null) {
            if (Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                editUserName.setVisibility(View.GONE);
            } else {
                editUserName.setOnClickListener(this);
            }
        } else {
            if (LocalConfig.LOGIN_TYPE == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                editUserName.setVisibility(View.GONE);
            } else {
                editUserName.setOnClickListener(this);
            }
        }

        if (null != config && null != config.getInviteViaSms()) {
            if (config.getInviteViaSms().equals("0")) {
                inviteUsersButton.setVisibility(View.GONE);
            } else {
                inviteUsersButton.setVisibility(View.VISIBLE);
                inviteUsersButton.setOnClickListener(this);
                if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get78()) {
                    TextView t = (TextView) view.findViewById(R.id.textViewInviteUsers);
                    t.setText(JsonPhp.getInstance().getLang().getMobile().get78());
                }
            }
        } else {
            inviteUsersButton.setVisibility(View.GONE);
        }

        if (null != config && null != config.getShareThisApp()) {
            if (config.getShareThisApp().equals("0")) {
                shareApp.setVisibility(View.GONE);
            } else {
                shareApp.setVisibility(View.VISIBLE);
                shareApp.setOnClickListener(this);
                if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get88()) {
                    TextView t = (TextView) view.findViewById(R.id.textViewShareApp);
                    t.setText(JsonPhp.getInstance().getLang().getMobile().get88());
                }
            }
        } else {
            shareApp.setVisibility(View.GONE);
        }

    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        try {
            MenuItem item = menu.findItem(R.id.custom_action_create_chatroom);
            item.setVisible(false);
            item = menu.findItem(R.id.custom_action_search);
            try {
                InputMethodManager mgr = (InputMethodManager) getActivity().getSystemService(
                        Context.INPUT_METHOD_SERVICE);
                if (null != getView() && null != getView().getWindowToken()) {
                    mgr.hideSoftInputFromWindow(getView().getWindowToken(), 0);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            item.setVisible(false);
            menu.findItem(R.id.custom_action_unblock_user).setVisible(false);
            menu.findItem(R.id.custom_action_refresh_buddylist).setVisible(false);
            super.onCreateOptionsMenu(menu, inflater);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void setupProfile(View view) {
        SessionData sessionData = SessionData.getInstance();
        try {
            username = (TextView) view.findViewById(R.id.textViewProfileUserName);
            avatarImage = (ProfileRoundedImageView) view.findViewById(R.id.imageViewUserProfilePhoto);
            status = (ImageView) view.findViewById(R.id.imageViewProfileUserStatus);
            TextView changePicHint = (TextView) view.findViewById(R.id.textViewChangeProfilePicHint);
            TextView changeName = (TextView) view.findViewById(R.id.textViewSetUserName);
            TextView changeStatusMessage = (TextView) view.findViewById(R.id.textViewSetStatusMessage);
            TextView changeStatus = (TextView) view.findViewById(R.id.textViewSetStatus);
            TextView invitePhone = (TextView) view.findViewById(R.id.textViewInviteUsers);
            TextView logout = (TextView) view.findViewById(R.id.textViewLogout);
            statusMessage = (TextView) view.findViewById(R.id.textViewProfileUserStatusMessage);

            if (!TextUtils.isEmpty(sessionData.getName())) {
                username.setText(Html.fromHtml(sessionData.getName()));
            }
            String url = sessionData.getAvatarLink();
            if (null != url) {
                /*LocalStorageFactory.getPicassoInstance().load(url).placeholder(R.drawable.default_avatar)
                        .into(avatarImage);*/
                LocalStorageFactory.LoadImageUsingURL(getActivity(),url,avatarImage,R.drawable.default_avatar);
            }

            if (sessionData.getStatusMessage() != null) {
                statusMessage.setText(Html.fromHtml(sessionData.getStatusMessage()));
            } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.STATUS_MESSAGE)) {
                statusMessage.setText(Html.fromHtml(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS_MESSAGE)));
            } else {
                statusMessage.setText(R.string.default_status_message);
            }

            if (sessionData.getStatus() != null) {
                String state = sessionData.getStatus();
                setStatusImage(state);
            } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.STATUS)) {
                setStatusImage(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS));
            } else {
                status.setImageResource(R.drawable.ic_user_available);
            }

            logout.setText(JsonPhp.getInstance().getLang().getMobile().get25());

            if (null != settingsLang) {
                changePicHint.setText(settingsLang.getChangeProfilePic());
                changeName.setText(settingsLang.getEditUsername());
                changeStatusMessage.setText(settingsLang.getEditStatusMessage());
                changeStatus.setText(settingsLang.getSetStatus());
                invitePhone.setText(settingsLang.getInviteViasms());
            }

            MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
            RelativeLayout imageContainer = (RelativeLayout) view.findViewById(R.id.relativeLayoutProfilePicContainer);
            if (mobileConfig != null) {
                if (Integer.parseInt(mobileConfig.getUsernamePasswordEnabled()) == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                    changePicHint.setVisibility(View.GONE);
                } else {
                    imageContainer.setOnClickListener(this);
                }
            } else {
                if (LocalConfig.LOGIN_TYPE == 1 || PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                    changePicHint.setVisibility(View.GONE);
                } else {
                    imageContainer.setOnClickListener(this);
                }
            }
        } catch (Exception e) {
            avatarImage.setImageResource(R.drawable.default_avatar);
            username.setText(sessionData.getName());
            if (PreferenceHelper.contains(PreferenceKeys.UserKeys.STATUS)) {
                setStatusImage(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS));
            } else {
                status.setImageResource(R.drawable.ic_user_available);
            }
            Logger.error("Cannot setup profile: " + e.getMessage());
            e.printStackTrace();
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
                    Bitmap profilePic;
                    String fileName, filePath;
                    Bundle extras = data.getExtras();
                    profilePic = extras.getParcelable("data");
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
                        }

                        @Override
                        public void failCallback() {
                            Logger.error("change avatar failed");
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
                        Toast.makeText(getActivity(), "Wallpaper Set", Toast.LENGTH_SHORT).show();
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

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

    private void setStatusImage(String string) {
        if (null == string) {
            status.setImageResource(R.drawable.ic_user_available);
        } else {
            switch (string) {
                case CometChatKeys.StatusKeys.AVALIABLE:
                    status.setImageResource(R.drawable.ic_user_available);
                    break;
                case CometChatKeys.StatusKeys.AWAY:
                    status.setImageResource(R.drawable.ic_user_away);
                    break;
                case CometChatKeys.StatusKeys.BUSY:
                    status.setImageResource(R.drawable.ic_user_busy);
                    break;
                case CometChatKeys.StatusKeys.OFFLINE:
                    status.setImageResource(R.drawable.ic_user_offline);
                    break;
                case CometChatKeys.StatusKeys.INVISIBLE:
                    status.setImageResource(R.drawable.ic_user_offline);
                    break;
                default:
                    status.setImageResource(R.drawable.ic_user_available);
                    break;
            }
        }
    }

    private void checkUserConfirmation() {
        LayoutInflater inflater = getActivity().getLayoutInflater();
        View dialogview = inflater.inflate(R.layout.custom_dialog, null);
        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
        EditText dialogueInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
        dialogueInput.setVisibility(View.GONE);
        Lang lang = JsonPhp.getInstance().getLang();
        dialogueTitle.setText(lang.getMobile().get29());
        new CustomAlertDialogHelper(getActivity(), "", dialogview, lang.getMobile().get25(), "", lang.getMobile()
                .get32(), this, LOGOUT);
    }

    @Override
    public void onButtonClick(final AlertDialog alertDialog, View v, int which, int popupId) {
        if (which == DialogInterface.BUTTON_POSITIVE) {
            switch (popupId) {
                case EDIT_STATUS_MESSAGE:
                    EditText statusMessageField = (EditText) v.findViewById(R.id.edittextDialogueInput);
                    final String newStatusMessage = statusMessageField.getText().toString();
                    if (!TextUtils.isEmpty(newStatusMessage)) {
                        VolleyHelper volley = new VolleyHelper(getActivity(), URLFactory.getSendOneToOneMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        statusMessage.setText(newStatusMessage);
                                        SessionData.getInstance().setStatusMessage(newStatusMessage);
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS_MESSAGE, newStatusMessage);
                                        alertDialog.dismiss();
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(getActivity(), StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                            alertDialog.dismiss();
                                        }
                                    }
                                });

                        volley.addNameValuePair(AjaxKeys.STATUS_MESSAGE, newStatusMessage);
                        volley.sendAjax();

                    } else {
                        statusMessageField
                                .setError((null == JsonPhp.getInstance().getLang().getMobile().get83()) ? "Please enter a status."
                                        : JsonPhp.getInstance().getLang().getMobile().get83());
                        alertDialog.dismiss();
                    }
                    break;
                case EDIT_USER_NAME:
                    EditText statusMessageField1 = (EditText) v.findViewById(R.id.edittextDialogueInput);
                    final String newUserName = statusMessageField1.getText().toString();
                    if (!TextUtils.isEmpty(newUserName)) {
                        VolleyHelper volley = new VolleyHelper(getActivity(), URLFactory.getPhoneRegisterURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        SessionData.getInstance().setUserInfoHeartBeatFlag("1");
                                        username.setText(newUserName);
                                        SessionData.getInstance().setName(newUserName);

                                        PreferenceHelper.save(PreferenceKeys.UserKeys.USER_NAME, newUserName);
                                        alertDialog.dismiss();
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(getActivity(), StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                            alertDialog.dismiss();
                                        }
                                    }
                                });

                        volley.addNameValuePair(AjaxKeys.ACTION, "change_name");
                        volley.addNameValuePair(AjaxKeys.NAME, newUserName);
                        volley.sendAjax();
                    } else {
                        statusMessageField1.setError((null == JsonPhp.getInstance().getLang()) ? "Please enter a username."
                                : JsonPhp.getInstance().getLang().getMobile().get47());
                        alertDialog.dismiss();

                    }
                    break;
                case SET_STATUS:
                    alertDialog.dismiss();
                    break;
                case LOGOUT:
                    //Leave All chatroom code
                   /* if (PreferenceHelper.get("joinChatroomsList") != null && !PreferenceHelper.get("joinChatroomsList").isEmpty()) {
                        try {
                            JSONObject temp = new JSONObject(PreferenceHelper.get("joinChatroomsList"));
                            Iterator<String> it = temp.keys();

                            while (it.hasNext()) {
                                ChatroomManager.leaveChatroom(Long.valueOf(it.next()), "0");

                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        PreferenceHelper.removeKey("joinChatroomsList");

                    }*/
                    if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO)) {

                        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)) {
                            PushNotificationsManager.unsubscribeAll();
                            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                        }
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGGED_IN_AS_DEMO);
                        SessionData.getInstance().setBaseData("");
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_NAME);
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGIN_PASSWORD);
                        LogoutHelper.chatLogout();
                        alertDialog.dismiss();
                        getActivity().finish();
                        return;
                    }
                    if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST)) {

                        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST)) {
                            PushNotificationsManager.unsubscribeAll();
                            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CHATROOM_CHANNEL_LIST);
                        }
                        Intent intent = new Intent(getActivity(), GuestLoginActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        startActivity(intent);
                        LogoutHelper.chatLogout();
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGGED_IN_AS_GUEST);
                        SessionData.getInstance().setBaseData("");
                        PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA, "");
                        alertDialog.dismiss();
                        getActivity().finish();
                        return;
                    }
                    if (PreferenceHelper.contains(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD)) {
                        Intent intent = new Intent(getActivity(), CoDLoginActivity.class);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                        startActivity(intent);
                        LogoutHelper.chatLogout();
                        PreferenceHelper.removeKey(PreferenceKeys.LoginKeys.LOGGED_IN_AS_COD);
                        SessionData.getInstance().setBaseData("");
                        alertDialog.dismiss();
                        getActivity().finish();
                        return;
                    }
                    LogoutHelper.chatLogout();
                    alertDialog.dismiss();
                    getActivity().finish();
                    break;
                default:
                    alertDialog.dismiss();
                    break;
            }
        }
        if (alertDialog.isShowing()) {
            alertDialog.dismiss();
        }
    }

    @Override
    public void onClick(View v) {
        String set = "Set";
        NewMobile newmobilelangs = JsonPhp.getInstance().getNewMobile();
        if (null != newmobilelangs && null != newmobilelangs.getCommon() && null != newmobilelangs.getCommon().getSet()) {
            set = newmobilelangs.getCommon().getSet();
        }
        switch (v.getId()) {
            case R.id.linearLayoutEditStatusMessage:
                View dialogview = getActivity().getLayoutInflater().inflate(R.layout.custom_dialog, null);

                TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
                dialogueTitle.setVisibility(View.GONE);

                EditText dialogueTextInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
                dialogueTextInput.setInputType(InputType.TYPE_CLASS_TEXT);
                String statusTitle = "Set Status Message";
                if (null == settingsLang) {
                    dialogueTextInput.setHint("Status Message");
                } else {
                    if (null != settingsLang.getStatusMessageHint() && null != settingsLang.getSetStatusMessage()) {
                        dialogueTextInput.setHint(settingsLang.getStatusMessageHint());
                        statusTitle = settingsLang.getSetStatusMessage();
                    }
                }

                dialogueTextInput.setSelectAllOnFocus(true);
                if (SessionData.getInstance().getStatusMessage() != null) {
                    dialogueTextInput.setText(SessionData.getInstance().getStatusMessage());
                } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.STATUS_MESSAGE)) {
                    dialogueTextInput.setText(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS_MESSAGE));
                } else {
                    dialogueTextInput.setText("");
                }

                new CustomAlertDialogHelper(getActivity(), statusTitle, dialogview, set, "", JsonPhp.getInstance()
                        .getLang().getMobile().get32(), this, EDIT_STATUS_MESSAGE);
                break;
            case R.id.linearLayoutSetStatus:
                showStatusDialog();
                break;
            case R.id.linearLayoutInviteUsers:
                startActivity(new Intent(getActivity(), InviteViaSmsActivity.class));
                break;
            case R.id.linearLayoutLogout:
                checkUserConfirmation();
                break;
            case R.id.linearLayoutTranslateConversation:
                showLanguageDialuge();
                break;
            case R.id.relativeLayoutEditUserName:
                View dialogview1 = getActivity().getLayoutInflater().inflate(R.layout.custom_dialog, null);

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
                dialogueTextInput1.setText(username.getText().toString());
                new CustomAlertDialogHelper(getActivity(), nameTitle, dialogview1, set, "", JsonPhp.getInstance().getLang()
                        .getMobile().get32(), this, EDIT_USER_NAME);
                break;
            case R.id.relativeLayoutProfilePicContainer:
                Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);

                List<Intent> cameraIntents = new ArrayList<Intent>();
                PackageManager packageManager = getActivity().getPackageManager();
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
            case R.id.relativeLayoutShareApp:
                Intent shareIntent = new Intent(Intent.ACTION_SEND);
                if (null == JsonPhp.getInstance().getLang() && null == JsonPhp.getInstance().getLang().getMobile()) {
                    shareIntent.putExtra(Intent.EXTRA_TEXT, LocalConfig.getDefaultInviteMessage());
                } else {
                    shareIntent.putExtra(Intent.EXTRA_TEXT, JsonPhp.getInstance().getLang().getMobile().get77());
                }
                shareIntent.setType("text/plain");
                startActivity(shareIntent);
                break;
            case R.id.relativeLayoutNotificationSettings:
                Intent notificationsIntent = new Intent(getActivity(), ChatSettingsActivity.class);
                startActivity(notificationsIntent);
                break;
            /*case R.id.relativeLayoutChatWallpaper:

                final Dialog dialog = new Dialog(getActivity(),R.style.CustomDialogWallpaper);
                LayoutInflater li = LayoutInflater.from(getActivity());
                View view = li.inflate(R.layout.wallpaper_layout, null);
                ListView lv = (ListView) view.findViewById(R.id.walllist);
                final List<Wallpaper> wallpaperList = getData();
                WallpaperAdpater wadpater = new WallpaperAdpater(getActivity(), wallpaperList);
                lv.setAdapter(wadpater);
                lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Wallpaper selected = wallpaperList.get(position);
                        int image = selected.getImage();

                        switch (image) {
                            case R.drawable.ic_gallery:
                                Intent intent = new Intent();
                                intent.setType(StaticMembers.IMAGE_TYPE);
                                intent.setAction(Intent.ACTION_PICK);
                                startActivityForResult(intent, 3);
                                dialog.dismiss();
                                break;
                            case R.drawable.ic_launcher:
                                openWallpaper();
                                break;
                            case R.drawable.ic_nowall:
                                PreferenceHelper.save(PreferenceKeys.DataKeys.WALLPAPER_FILENAME, "");
                                dialog.cancel();
                                break;
                            default:
                                break;
                        }
                    }
                });
                dialog.setContentView(view);
                dialog.show();*/

        }
    }

    /*private void openWallpaper() {
        Intent i = new Intent(getActivity(),WallpaperActivity.class);
        startActivity(i);
    }*/

    /*public static List<Wallpaper> getData() {
        List<Wallpaper> data = new ArrayList<>();

        if((TextUtils.isEmpty(JsonPhp.getInstance().getPresetWallpaper()) && null != JsonPhp.getInstance().getPresetWallpaper())){
            if (null == JsonPhp.getInstance().getLang() && null == JsonPhp.getInstance().getLang().getMobile() && null == JsonPhp.getInstance().getLang().getMobile().get154()) {
                data.add(new Wallpaper(StaticMembers.APP_WALLPAPER_TEXT, R.drawable.ic_launcher));
            } else {
                data.add(new Wallpaper(JsonPhp.getInstance().getLang().getMobile().get154(), R.drawable.ic_launcher));
            }
        }


        if (null == JsonPhp.getInstance().getLang() && null == JsonPhp.getInstance().getLang().getMobile()) {
            data.add(new Wallpaper(JsonPhp.getInstance().getLang().getMobile().get155(), R.drawable.ic_gallery));
            data.add(new Wallpaper(JsonPhp.getInstance().getLang().getMobile().get156(), R.drawable.ic_nowall));
        } else {
            data.add(new Wallpaper(StaticMembers.DEFAULT_WALLPAPER_TEXT, R.drawable.ic_gallery));
            data.add(new Wallpaper(StaticMembers.NO_WALLPAPER_TEXT, R.drawable.ic_nowall));
        }


        String[] titles = {"Documents", "CometChat App", "No wallpaper"};
        int[] images = {R.drawable.ic_gallery, R.drawable.ic_launcher, R.drawable.ic_nowall};
        for (int i = 0; i < titles.length && i < images.length; i++) {
            data.add(new Wallpaper(titles[i], images[i]));
        }
        return data;
    }*/

    private void showLanguageDialuge() {
        langOptions = new String[]{"Default", "Afrikaans", "Albanian", "Arabic", "Belarusian", "Bulgarian",
                "Catalan", "Chinese (Simpl)", "Chinese (Trad)", "Croatian", "Czech", "Danish", "Dutch", "English",
                "Estonian", "Filipino", "Finnish", "French", "Galician", "German", "Greek", "Haitian Creole", "Hebrew",
                "Hindi", "Hungarian", "Icelandic", "Indonesian", "Irish", "Italian", "Japanese", "Korean", "Latvian",
                "Lithuanian", "Macedonian", "Malay", "Maltese", "Norwegian", "Persian", "Polish", "Portuguese",
                "Romanian", "Russian", "Serbian", "Slovak", "Slovenian", "Spanish", "Swahili", "Swedish", "Thai",
                "Turkish", "Ukrainian", "Vietnamese", "Welsh", "Yiddish"};

        langCodes = new String[]{"", "af", "sq", "ar", "be", "bg", "ca", "zh-CN", "zh-TW", "hr", "cs", "da", "nl",
                "en", "et", "tl", "fi", "fr", "gl", "de", "el", "ht", "iw", "hi", "hu", "is", "id", "ga", "it", "ja",
                "ko", "lv", "lt", "mk", "ms", "mt", "no", "fa", "pl", "pt", "ro", "ru", "sr", "sk", "sl", "es", "sw",
                "sv", "th", "tr", "uk", "vi", "cy", "yi"};

        android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(getActivity());

        if (TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get82())) {
            builder.setTitle("Set language");
        } else {
            builder.setTitle(JsonPhp.getInstance().getLang().getMobile().get82());
        }
        builder.setNegativeButton(JsonPhp.getInstance().getLang().getMobile().get32(),
                new DialogInterface.OnClickListener() {

                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });

        builder.setSingleChoiceItems(langOptions,
                Arrays.asList(langCodes).indexOf(PreferenceHelper.get(PreferenceKeys.DataKeys.SELECTED_LANGUAGE)),
                new DialogInterface.OnClickListener() {

                    private String newLang;

                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        newLang = langCodes[which];
                        PreferenceHelper.save(PreferenceKeys.DataKeys.SELECTED_LANGUAGE, newLang);
                        dialog.dismiss();

                    }
                });
        builder.show();

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

            ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getPhoneRegisterURL(), handler);
            if (bitmap != null) {
                ByteArrayOutputStream outstr = new ByteArrayOutputStream();
                String fileExtension = filename.substring(filename.lastIndexOf(".") + 1);
                if (fileExtension.equalsIgnoreCase("jpg") || fileExtension.equalsIgnoreCase("jpeg")) {
                    bitmap.compress(Bitmap.CompressFormat.JPEG, 100, outstr);
                } else {
                    bitmap.compress(Bitmap.CompressFormat.PNG, 100, outstr);
                }
                byte[] outputData = outstr.toByteArray();

                File compressedImageFile = LocalStorageFactory.writeFile(LocalStorageFactory.getImageStoragePath(),
                        filename, outputData);
                imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "change_avatar");
                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, compressedImageFile);
                imageSendHelper.sendImageAjax();
            }
        } catch (Exception e) {
            callbacks.failCallback();
            e.printStackTrace();
        }
    }


    String[] statusOptions, statusMessages;

    public void showStatusDialog() {
        Core core;
        if (null != JsonPhp.getInstance()) {
            core = JsonPhp.getInstance().getLang().getCore();
        } else {
            core = null;
        }

        if (null != core) {
            statusOptions = new String[]{core.get3(), core.get4(), core.get5()};
            statusMessages = new String[]{core.get30(), core.get31(), core.get32()};
        } else {
            statusOptions = new String[]{"Available", "Busy", "Invisible"};
            statusMessages = new String[]{"I'm available", "I'm Busy", "I'm Offline"};
        }

        /**
         * Map properly with newStatus
         */
        final String[] statusOpts = {StatusKeys.AVALIABLE, StatusKeys.BUSY, StatusKeys.INVISIBLE};
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        if (TextUtils.isEmpty(JsonPhp.getInstance().getLang().getMobile().get81())) {
            builder.setTitle("Set Status");
        } else {
            builder.setTitle(JsonPhp.getInstance().getLang().getMobile().get81());
        }
        builder.setNegativeButton(JsonPhp.getInstance().getLang().getMobile().get32(),
                new DialogInterface.OnClickListener() {

                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });

        builder.setSingleChoiceItems(statusOptions,
                Arrays.asList(statusOpts).indexOf(PreferenceHelper.get(PreferenceKeys.UserKeys.STATUS)),
                new DialogInterface.OnClickListener() {

                    private String newStatus, newStatusMessage;
                    boolean flag = false;

                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        newStatus = statusOpts[which];
                        newStatusMessage = statusMessages[which];
                        VolleyHelper volley = new VolleyHelper(getActivity(), URLFactory.getSendOneToOneMessageURL(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS, newStatus);
                                        Logger.error("new status " + newStatus);
                                        setStatusImage(newStatus);
                                        String tempStatus = SessionData.getInstance().getStatusMessage();
                                        int i;
                                        for (i = 0; i < 3; i++) {
                                            if (tempStatus.equals(statusMessages[i])) {
                                                flag = true;
                                            }
                                        }
                                        tempStatus = null;
                                        if (flag) {
                                            statusMessage.setText(newStatusMessage);
                                            SessionData.getInstance().setStatusMessage(newStatusMessage);
                                        } else {
                                            statusMessage.setText(SessionData.getInstance().getStatusMessage());
                                        }
                                        SessionData.getInstance().setStatus(newStatus);
                                        PreferenceHelper.save(PreferenceKeys.UserKeys.STATUS_MESSAGE, SessionData.getInstance().getStatusMessage());
                                        flag = false;

                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(getActivity(), StaticMembers.PLEASE_CHECK_YOUR_INTERNET,
                                                    Toast.LENGTH_LONG).show();
                                        }
                                    }
                                });
                        volley.addNameValuePair(StatusKeys.STATUS, newStatus);
                        volley.sendAjax();
                        dialog.dismiss();
                    }
                });
        builder.show();

    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            getActivity().registerReceiver(customReceiver,
                    new IntentFilter(BroadcastReceiverKeys.IntentExtrasKeys.USER_STATUS));
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        if (null != customReceiver) {
            getActivity().unregisterReceiver(customReceiver);
        }
    }
}
