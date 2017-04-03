/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.os.Parcelable;
import android.provider.ContactsContract;
import android.provider.MediaStore;
import android.text.TextUtils;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.ImageUploadHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.CreateProfile;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Announcement;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.orm.SugarRecord;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.util.ArrayList;
import java.util.List;

public class CreateProfileActivity extends SuperActivity {

    private Button createProfileButton;
    private ImageView userProfile;
    private static Uri fileUri, tempFileURI;
    private EditText userName, userEmail, userPassword, userConfirmPwd;
    private static Bitmap profileBitmap;
    private String temp_id, fileName;
    private boolean isProfileExist = false, useSameEmail = true;
    private ProgressDialog progressDialog;
    private CreateProfile createProfileLangs;
    private MobileTheme theme;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_profile);

        setActionBarTitle(this.getTitle());

        Intent intent = getIntent();
        temp_id = PreferenceHelper.get(PreferenceKeys.DataKeys.TEMP_ID);

        createProfileButton = (Button) findViewById(R.id.buttonCreateProfile);
        userProfile = (ImageView) findViewById(R.id.imageViewUserProfileUploadImage);
        userName = (EditText) findViewById(R.id.editTextUploadUserName);
        userEmail = (EditText) findViewById(R.id.editTextUserEmailIdField);
        userPassword = (EditText) findViewById(R.id.editTextUserPasswordField);
        userConfirmPwd = (EditText) findViewById(R.id.editTextUserConfirmPasswordField);

        if (PreferenceHelper.contains(PreferenceKeys.UserKeys.CHANGE_EMAIL)) {
            userEmail.setText(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_EMAIL));
            if ("1".equals(PreferenceHelper.get(PreferenceKeys.UserKeys.CHANGE_EMAIL))) {
                userEmail.setFocusable(true);
                userEmail.setFocusableInTouchMode(true);
                userEmail.setClickable(true);
                userEmail.setCursorVisible(true);
                useSameEmail = false;

                userEmail.setText("");
                userName.setText("");
                userProfile.setImageResource(R.drawable.default_avatar);
                profileBitmap = null;
            }
        } else {
            userEmail.setFocusable(true);
            userEmail.setFocusableInTouchMode(true);
            userEmail.setClickable(true);
            userEmail.setCursorVisible(true);
            useSameEmail = false;
        }

        if (!intent.hasExtra(IntentExtrasKeys.VERFICATION_STATUS_CASE_TWO)) {
            userEmail.setFocusable(true);
            userEmail.setFocusableInTouchMode(true);
            userEmail.setClickable(true);
        }

        MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();
        if ((mobileConfig != null && Integer.parseInt(mobileConfig.getPhoneNumberEnabled()) < 2) || LocalConfig.LOGIN_TYPE < 3) {
            userEmail.setVisibility(View.GONE);
            userPassword.setVisibility(View.GONE);
            userConfirmPwd.setVisibility(View.GONE);
        }

        if (intent.hasExtra(IntentExtrasKeys.BUDDY_NAME)) {
            userName.setText(intent.getStringExtra(IntentExtrasKeys.BUDDY_NAME));
            PreferenceHelper.save(PreferenceKeys.UserKeys.USER_PREVIOUS_NAME,
                    intent.getStringExtra(IntentExtrasKeys.BUDDY_NAME));
        } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.USER_PREVIOUS_NAME)) {
            userName.setText(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_PREVIOUS_NAME));
        }

        if (intent.hasExtra(IntentExtrasKeys.BUDDY_AVATAR)) {
            String url = intent.getStringExtra(IntentExtrasKeys.BUDDY_AVATAR);
            isProfileExist = true;
            if (!url.contains(URLFactory.PROTOCOL_PREFIX) && !url.contains(URLFactory.PROTOCOL_PREFIX_SECURE)) {
                url = URLFactory.getWebsiteURL() + url;
            }
            PreferenceHelper.save(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR, url);
            /*LocalStorageFactory.getPicassoInstance().load(url).placeholder(R.drawable.default_avatar).resize(100, 100)
                    .into(userProfile);*/
            LocalStorageFactory.LoadImageUsingURL(this,url,userProfile,R.drawable.default_avatar);

        } else if (PreferenceHelper.contains(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR)) {
            /*LocalStorageFactory.getPicassoInstance()
                    .load(PreferenceHelper.get(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR))
                    .placeholder(R.drawable.default_avatar).resize(100, 100).into(userProfile);*/
            LocalStorageFactory.LoadImageUsingURL(this,PreferenceHelper.get(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR),userProfile,R.drawable.default_avatar);
        }

        if (null != JsonPhp.getInstance().getNewMobile()) {
            createProfileLangs = JsonPhp.getInstance().getNewMobile().getCreateProfile();
        }

        RelativeLayout selectImage = (RelativeLayout) findViewById(R.id.relativeLayout1);
        selectImage.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent cameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);
                String path = fileUri.getPath();
                fileName = path.substring(path.lastIndexOf("/") + 1, path.length());

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
                if (null == JsonPhp.getInstance().getNewMobile()) {
                    chooserIntent = Intent.createChooser(galleryIntent, "Complete action using");
                } else {
                    chooserIntent = Intent.createChooser(galleryIntent, JsonPhp.getInstance().getNewMobile()
                            .getCommon().getCompleteAction());
                }
                chooserIntent.putExtra(Intent.EXTRA_INITIAL_INTENTS, cameraIntents.toArray(new Parcelable[]{}));
                startActivityForResult(chooserIntent, 1);
            }
        });

        createProfileButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {

                progressDialog = ProgressDialog.show(CreateProfileActivity.this, "",
                        (null == createProfileLangs) ? "Creating your profile." : createProfileLangs.getLoader());
                progressDialog.setCancelable(false);
                userName.clearFocus();
                userPassword.clearFocus();
                userConfirmPwd.clearFocus();
                try {
                    String name = userName.getText().toString().trim(), email = userEmail.getText().toString().trim(), pwd = userPassword
                            .getText().toString().trim(), cPwd = userConfirmPwd.getText().toString().trim();
                    boolean validData = true;
                    if (TextUtils.isEmpty(name)) {
                        userName.setError((null == createProfileLangs) ? "Please enter a username" : createProfileLangs
                                .getErrUsername());
                        progressDialog.dismiss();
                        validData = false;
                    }

                    if (LocalConfig.LOGIN_TYPE == 3 || LocalConfig.LOGIN_TYPE == 4) {
                        if (TextUtils.isEmpty(email)) {
                            userEmail.setError((null == createProfileLangs || null == createProfileLangs
                                    .getEmailEmpty()) ? "Please enter email address" : createProfileLangs
                                    .getEmailEmpty());
                            userEmail.requestFocus();
                            validData = false;
                        }
                        if (TextUtils.isEmpty(pwd)) {
                            userPassword
                                    .setError((null == JsonPhp.getInstance().getNewMobile()) ? "Please enter password"
                                            : JsonPhp.getInstance().getNewMobile().getLogin().getPasswordBlank());
                            userPassword.requestFocus();
                            validData = false;
                        }
                        if (TextUtils.isEmpty(cPwd)) {
                            userConfirmPwd.setError((null == createProfileLangs || null == createProfileLangs
                                    .getConfpwdEmpty()) ? "Please enter confirm password" : createProfileLangs
                                    .getConfpwdEmpty());
                            userConfirmPwd.requestFocus();
                            validData = false;
                        }

                        if ((!TextUtils.isEmpty(pwd) && !TextUtils.isEmpty(cPwd)) && !(pwd.equals(cPwd))) {
                            userPassword.setError((null == createProfileLangs.getPasswordMismatch()) ? "Password do not match"
                                    : createProfileLangs.getPasswordMismatch());
                            userConfirmPwd.setError((null == createProfileLangs.getPasswordMismatch()) ? "Password do not match"
                                    : createProfileLangs.getPasswordMismatch());
                            userConfirmPwd.requestFocus();
                            validData = false;
                        }
                    } else {
                        email = pwd = cPwd = "123";
                    }
                    if (validData) {
                        // Keep imageData optional.
                        createProfile(profileBitmap, name, temp_id, isProfileExist, email, pwd, cPwd,
                                new CometchatCallbacks() {

                                    @Override
                                    public void successCallback() {
                                        if (LocalConfig.LOGIN_TYPE != 4) {
                                            if (!PreferenceHelper.get(PreferenceKeys.LoginKeys.CURRENT_PHONE).equals(
                                                    PreferenceHelper.get(PreferenceKeys.DataKeys.MY_PHONE_NUMBER))) {
                                                removeExistingData();
                                            }

                                            PreferenceHelper.save(PreferenceKeys.DataKeys.MY_PHONE_NUMBER,
                                                    PreferenceHelper.get(PreferenceKeys.LoginKeys.CURRENT_PHONE));
                                            sendContacts(CreateProfileActivity.this);
                                        }
                                        PreferenceHelper.save(PreferenceKeys.LoginKeys.LOGGED_IN,
                                                CometChatKeys.LoginKeys.USER_LOGGED_IN);

                                        PreferenceHelper.save(PreferenceKeys.DataKeys.REGISTRATION_STATUS, "2");
                                        PreferenceHelper.removeKey(PreferenceKeys.UserKeys.SECOND_VERI_CODE);
                                        PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_PREVIOUS_AVATAR);
                                        PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_PREVIOUS_NAME);
                                        PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_EMAIL);
                                        PreferenceHelper.removeKey(PreferenceKeys.UserKeys.CHANGE_EMAIL);

                                        Intent intent = new Intent(CreateProfileActivity.this, CometChatActivity.class);
                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                        startActivity(intent);
                                        finish();

                                        progressDialog.dismiss();
                                    }

                                    @Override
                                    public void failCallback() {
                                        progressDialog.dismiss();
                                    }
                                });

                    } else {
                        progressDialog.dismiss();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                    progressDialog.dismiss();
                }
            }
        });

        if (null != createProfileLangs) {
            createProfileButton.setText(createProfileLangs.getCreateButton());
            userName.setHint(createProfileLangs.getFieldHint());
            TextView tv = (TextView) findViewById(R.id.myImageViewText);
            tv.setText(createProfileLangs.getPhotoHint());
        }

		/* Display home navigation forcefully */
        if (LocalConfig.LOGIN_TYPE == 4) {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }

        theme = JsonPhp.getInstance().getMobileTheme();
        if (null != theme && null != theme.getLoginButton() && null != theme.getLoginButtonText()) {
            createProfileButton.setBackgroundColor(Color.parseColor(theme.getLoginButton()));
            createProfileButton.setTextColor(Color.parseColor(theme.getLoginButtonText()));
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == android.R.id.home) {
            finish();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    public static void sendContacts(Context context) {
        Cursor cursor = context.getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null,
                null, null, null);
        JSONArray jsonarray = new JSONArray();
        if (null != cursor) {
            while (cursor.moveToNext()) {
                String phoneNumber = cursor.getString(cursor.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));
                if (phoneNumber.length() > 7) {
                    jsonarray.put(phoneNumber.trim().replaceAll("[^0-9]", ""));
                }
            }
            cursor.close();
        }

        // No need to process the response "as of now".
        VolleyHelper vvHelper = new VolleyHelper(context, URLFactory.getPhoneRegisterURL());
        vvHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "update_friends");
        vvHelper.addNameValuePair(CometChatKeys.AjaxKeys.CONTACT_LIST, jsonarray.toString());
        vvHelper.addNameValuePair(CometChatKeys.AjaxKeys.COUNT, jsonarray.length());
        vvHelper.sendAjax();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            if (resultCode == RESULT_OK) {
                if (requestCode == 1) {
                    boolean isCamera;
                    if (data == null) {
                        isCamera = true;
                    } else {
                        isCamera = data.hasExtra(MediaStore.EXTRA_OUTPUT);
                    }

                    Intent intent = new Intent("com.android.camera.action.CROP");
                    if (isCamera) {
                        intent.setDataAndType(fileUri, StaticMembers.IMAGE_TYPE);
                    } else {
                        intent.setDataAndType(data.getData(), StaticMembers.IMAGE_TYPE);
                    }

                    intent.putExtra("crop", "true");
                    intent.putExtra("aspectX", 1);
                    intent.putExtra("aspectY", 1);
                    //intent.putExtra("outputX", 150);
                    //intent.putExtra("outputY", 150);
                    intent.putExtra("noFaceDetection", true);
                    intent.putExtra("scale", true);
                    intent.putExtra("return-data", false);
                    tempFileURI = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);
                    intent.putExtra(MediaStore.EXTRA_OUTPUT, tempFileURI);
                    startActivityForResult(intent, 2);
                } else if (requestCode == 2) {
                    Bundle extras = data.getExtras();
                    if (extras != null) {
                        profileBitmap = extras.getParcelable("data");
                        if (profileBitmap == null) {
                            File image = new File(tempFileURI.getPath());
                            BitmapFactory.Options bmOptions = new BitmapFactory.Options();
                            try {
                                profileBitmap = BitmapFactory.decodeFile(image.getPath(), bmOptions);
                            } catch (Exception e) {
                                e.printStackTrace();
                            } catch (OutOfMemoryError e) {
                                bmOptions.inSampleSize = 2;
                                profileBitmap = BitmapFactory.decodeFile(image.getPath(), bmOptions);
                            }
                        }
                    } else {
                        if(data.getData()==null){
                            profileBitmap = (Bitmap)data.getExtras().get("data");
                        }else{
                            profileBitmap = MediaStore.Images.Media.getBitmap(this.getContentResolver(), data.getData());
                        }
                    }
                    userProfile.setImageBitmap(profileBitmap);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void createProfile(Bitmap bitmap, String name, String temp_id, boolean isProfileExist, String email,
                               String pwd, String cPwd, final CometchatCallbacks callbacks) {
        try {
            Handler handler = new Handler() {

                @Override
                public void handleMessage(Message msg) {
                    super.handleMessage(msg);
                    switch (msg.what) {
                        case 200:
                            String response = msg.obj.toString();
                            Logger.error("profile pic ajax=" + response);
                            try {
                                JSONObject jsonresponse = new JSONObject(response);
                                if (jsonresponse.getString("status").equals("1")) {
                                    if (jsonresponse.has(AjaxKeys.BASE_DATA)) {
                                        if (!TextUtils.isEmpty(jsonresponse.getString(AjaxKeys.BASE_DATA))
                                                && !"null".equals(jsonresponse.getString(AjaxKeys.BASE_DATA))) {
                                            PreferenceHelper.save(PreferenceKeys.DataKeys.BASE_DATA,
                                                    jsonresponse.getString(AjaxKeys.BASE_DATA));
                                            SessionData.getInstance().setBaseData(
                                                    jsonresponse.getString(AjaxKeys.BASE_DATA));
                                        }
                                        callbacks.successCallback();
                                    }
                                } else if (jsonresponse.getString("status").equals("3")) {
                                    userPassword
                                            .setError((null == createProfileLangs.getIncorrectPassword()) ? "Please check the password"
                                                    : createProfileLangs.getIncorrectPassword());
                                    userConfirmPwd.getText().clear();
                                    userPassword.requestFocus();
                                    callbacks.failCallback();
                                } else if (jsonresponse.getString("status").equals("4")) {
                                    userName.setError("This user name already exists");
                                    callbacks.failCallback();
                                } else {
                                    callbacks.failCallback();
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                            }

                            break;
                        default:
                            callbacks.failCallback();
                            break;
                    }

                }
            };
            if (null == fileName) {
                fileName = System.currentTimeMillis() + ".jpg";
            }
            ImageUploadHelper imageSendHelper = new ImageUploadHelper(PreferenceHelper.getContext(),
                    URLFactory.getPhoneRegisterURL(), handler);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, "create_profile");
            if (bitmap != null) {
                ByteArrayOutputStream outstr = new ByteArrayOutputStream();
                bitmap.compress(Bitmap.CompressFormat.JPEG, 100, outstr);
                byte[] outputData = outstr.toByteArray();

                File compressedImageFile = LocalStorageFactory.writeFile(LocalStorageFactory.getImageStoragePath(),
                        fileName, outputData);
                imageSendHelper.addFile(CometChatKeys.FileUploadKeys.FILEDATA, compressedImageFile);
            } else {
                if (isProfileExist) {
                    imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.SAME_AVATAR, "1");
                }
            }
            if (useSameEmail) {
                imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.NEW_EMAIL, "false");
            } else {
                imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.NEW_EMAIL, "1");
            }
            if (LocalConfig.LOGIN_TYPE == 4) {
                temp_id = "321321";
            }
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.TEMP_ID, temp_id);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.NAME, name);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.EMAIL, email);
            imageSendHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, pwd);

            imageSendHelper.sendImageAjax();
        } catch (Exception e) {
            callbacks.failCallback();
            e.printStackTrace();
        }
    }

    @Override
    public void finish() {
        super.finish();
        if (null != progressDialog) {
            progressDialog.dismiss();
        }
    }

    private void removeExistingData() {
        try {
            /* Clear buddy list */
            SugarRecord.deleteAll(Buddy.class);

			/* Clear OneOnOneChat messages */
            SugarRecord.deleteAll(OneOnOneMessage.class);

			/* Clear chatroom list */
            SugarRecord.deleteAll(Chatroom.class);

			/* Clear all chatroom messages */
            SugarRecord.deleteAll(ChatroomMessage.class);

            SugarRecord.deleteAll(Announcement.class);

            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_ID);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_NAME);
            PreferenceHelper.removeKey(PreferenceKeys.UserKeys.USER_LINK);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SELECTED_LANGUAGE);

        } catch (Exception e) {
            Logger.error("Loginactivity.java removeExistingData(): Exception = " + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

}
