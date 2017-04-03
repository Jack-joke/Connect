/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.BroadcastReceiver;
import android.content.ClipData;
import android.content.ClipboardManager;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.content.res.Configuration;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.media.MediaPlayer;
import android.media.MediaRecorder;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.support.design.widget.BottomSheetBehavior;
import android.support.v4.app.ActivityCompat;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.InputType;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.util.DisplayMetrics;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewConfiguration;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.RelativeLayout;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.Keyboards.SmileyKeyBoard;
import com.inscripts.Keyboards.StickerKeyboard;
import com.inscripts.R;
import com.inscripts.adapters.OneToOneMessageAdapter;
import com.inscripts.cometchat.sdk.AVBroadcast;
import com.inscripts.custom.ConfirmationWindow;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatOneOnOne;
import com.inscripts.helpers.PopupHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.EmojiClickInterface;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.StickerClickInterface;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.BroadcastReceiverKeys.HeartbeatKeys;
import com.inscripts.keys.BroadcastReceiverKeys.IntentExtrasKeys;
import com.inscripts.keys.BroadcastReceiverKeys.ListUpdatationKeys;
import com.inscripts.keys.BroadcastReceiverKeys.NewMessageKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.BlockUnblockUser;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.ReportConversation;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoChat;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.transports.CometserviceOneOnOne;
import com.inscripts.transports.WebsyncOneOnOne;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.inscripts.utils.TimerClass;
import com.inscripts.videochat.OutgoingCallActivity;
import com.inscripts.videochat.VideoChatActivity;

import org.json.JSONObject;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Field;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import se.emilsjolander.stickylistheaders.StickyListHeadersListView;

public class SingleChatActivity extends SuperActivity implements OnAlertDialogButtonClickListener, EmojiClickInterface {

    private String firstName, picassImageName, sendMessageUrl, audioFileNamewithPath, shareImageUri, shareVideoUri, shareAudioUri;
    private StickyListHeadersListView chatListView;
    private ImageButton smilieyButton, voiceNotebtn, stickerButton,cameraButton, buttonArrowUp, buttonArrowDown;
    private EditText messageField;
    private OneToOneMessageAdapter adapter;
    private List<OneOnOneMessage> messageList;
    private BroadcastReceiver customReceiver;
    private final int REPORT_CONVERSATION_POPUP = 1, IMAGE_SEND_PREVIEW_POPUP = 2, VIDEO_SEND_PREVIEW_POPUP = 3,
            PICASSA_IMAGE_PREVIEW_POPUP = 4, BLOCK_USER_POPUP = 5, AUDIO_SEND_PREVIEW_POPUP = 6;
    private Intent data;
    private SmileyKeyBoard smiliKeyBoard;
    private Bitmap picassaBitmap;
    private SessionData sessionData;
    private Lang lang;
    private boolean noCometService, isRecording = false, isVoiceNoteplaying = false;
    private Config config;
    private Long minHeartbeat, buddyId;
    private static Buddy buddy;
    private MediaRecorder voiceRecorder;
    private Runnable timerRunnable;
    Handler seekHandler = new Handler();
    //private CustomListView chatContainer;
    private StickerKeyboard stickerKeyboard;
    private static Uri fileUri;
    private Toolbar toolbar;
    boolean flag = true, openchatonly = false;
    private ImageView dirtyView;
    private RelativeLayout customMenu;
    //ChatMenu Variables
    private BottomSheetBehavior sheetBehavior;
    private BottomSheetBehavior sheetCameraBehavior;
    private RelativeLayout chatFooter;
    private ImageButton btnChatMenuMore, btnChatMenuKeyBoard, btnChatMenuSharePhoto, btnChatMenuShareVideo, btnChatMenuBroadcast, getBtnChatMenuSticker;
    private LinearLayout viewShareWiteboard, viewCollaborativeDocument, viewHandwriteMessage ,viewCapturePhoto , viewCaptureVideo;
    private ImageView whiteboardImageView, collaborativeDocumentImageView, handwriteMessageImageView, capturePhotoImageView , capturevideoImageView;

    private LinearLayout chatMenuLayout;
    private LinearLayout cameraMenuLayout;
    private RelativeLayout chatLayout;
    private LinearLayout bottomSheetlayout;
    private LinearLayout cameraSheetLayout;
    private String primaryColor;
    private ImageButton sendButton;
    private ImageButton btnMenu;



    @TargetApi(Build.VERSION_CODES.JELLY_BEAN)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_chat_activity_cordinate);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);

        Intent intent = getIntent();

        if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.DIRECT_OPEN_CHAT)) {
            openchatonly = true;
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            toolbar.setNavigationIcon(R.drawable.cc_ic_action_cancel);
        } else {
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        }

        if (intent.hasExtra(IntentExtrasKeys.BUDDY_ID)) {
            buddyId = intent.getLongExtra(IntentExtrasKeys.BUDDY_ID, 0);
            buddy = Buddy.getBuddyDetails(buddyId);
        } else {
            if (null != buddy) {
                buddyId = buddy.buddyId;
            }
        }

        if (intent.hasExtra(IntentExtrasKeys.BUDDY_NAME)) {
            firstName = intent.getStringExtra(IntentExtrasKeys.BUDDY_NAME);
        } else {
            if (null != buddy) {
                firstName = buddy.name;
            }
        }
        updateLastSeenActivity();

        /*chatContainer = (CustomListView) findViewById(R.id.listViewChatMessages);
        String bmString = PreferenceHelper.get(PreferenceKeys.DataKeys.WALLPAPER_FILENAME);
        Logger.error("bmString" + bmString);
        if (bmString == null || bmString.isEmpty() || bmString == "default.png") {
            chatContainer.setBackgroundColor(Color.WHITE);
        } else {
            Bitmap bm = BitmapFactory.decodeFile(bmString);
            BitmapDrawable bitmapDrawable = new BitmapDrawable(bm);
            chatContainer.setBackground(bitmapDrawable);
        }*/

        // PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID,
        // buddyId);

        sessionData = SessionData.getInstance();
        lang = JsonPhp.getInstance().getLang();
        config = JsonPhp.getInstance().getConfig();
        noCometService = config.getUSECOMET().equals("0");

        if (intent.hasExtra("ImageUri")) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_IMAGE_URL)) {
                shareImageUri = intent.getStringExtra("ImageUri");
                checkUserConfirmation(shareImageUri, false);
            }
        }
        if (intent.hasExtra("VideoUri")) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_VIDEO_URL)) {
                shareVideoUri = intent.getStringExtra("VideoUri");
                checkUserConfirmation(shareVideoUri, true);
            }
        }
        if (intent.hasExtra("AudioUri")) {
            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_AUDIO_URL)) {
                shareAudioUri = intent.getStringExtra("AudioUri");
                shareAudioUri = shareAudioUri.replace("file://", "");
                Uri uri = Uri.parse(shareAudioUri);
                //String AudioUri = AudioSharing.getRealPathFromURI(this, uri);
                AudioSharing.sendAudio(this, uri, buddyId, false);
            }
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_AUDIO_URL);
        }

        if (noCometService) {
            minHeartbeat = Long.parseLong(config.getMinHeartbeat());
        } else {
            minHeartbeat = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
        }

        chatListView = (StickyListHeadersListView) findViewById(R.id.listViewChatMessages);
        messageField = (EditText) findViewById(R.id.editTextChatMessage);
        sendButton = (ImageButton) findViewById(R.id.buttonSendMessage);
        voiceNotebtn = (ImageButton) findViewById(R.id.buttonSendVoice);

        smilieyButton = (ImageButton) findViewById(R.id.img_btn_smiley);
        smiliKeyBoard = new SmileyKeyBoard();
        smiliKeyBoard.enable(this, this, R.id.footer_for_emoticons, messageField);
        chatFooter = (RelativeLayout) findViewById(R.id.relativeLayoutControlsHolder);
        smiliKeyBoard.checkKeyboardHeight(chatFooter);
        smiliKeyBoard.enableFooterView(messageField);

        if(PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT).equals("0")){
            smiliKeyBoard.setKeyBoardHeight(Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT)));
        }else{
            DisplayMetrics displayMetrics = new DisplayMetrics();
            getWindowManager().getDefaultDisplay().getMetrics(displayMetrics);
            smiliKeyBoard.setKeyBoardHeight(displayMetrics.heightPixels/3);
        }

        chatLayout = (RelativeLayout) findViewById(R.id.relativeLayoutChatActivity);
        stickerButton = (ImageButton) findViewById(R.id.btn_chat_menu_sticker);

        bottomSheetlayout = (LinearLayout) findViewById(R.id.bottom_sheet);
        sheetBehavior = BottomSheetBehavior.from(bottomSheetlayout);
        cameraSheetLayout = (LinearLayout) findViewById(R.id.bottom_sheet_camera);
        sheetCameraBehavior = BottomSheetBehavior.from(cameraSheetLayout);
        customMenu = (RelativeLayout) findViewById(R.id.relativeLayoutMenu1);

        btnChatMenuMore = (ImageButton) findViewById(R.id.btn_chat_menu_more);
        btnChatMenuBroadcast = (ImageButton) findViewById(R.id.btn_chat_menu_broadcast);
        btnChatMenuKeyBoard = (ImageButton) findViewById(R.id.btn_chat_menu_keyboard);
        btnChatMenuSharePhoto = (ImageButton) findViewById(R.id.btn_chat_menu_share_image);
        btnChatMenuShareVideo = (ImageButton) findViewById(R.id.btn_chat_menu_share_video);
        getBtnChatMenuSticker = (ImageButton) findViewById(R.id.btn_chat_menu_sticker);
        viewHandwriteMessage = (LinearLayout) findViewById(R.id.ll_handwrite_message);
        viewShareWiteboard = (LinearLayout) findViewById(R.id.ll_share_whiteboard);
        viewCollaborativeDocument = (LinearLayout) findViewById(R.id.ll_collaborative_document);
        viewCapturePhoto = (LinearLayout) findViewById(R.id.ll_capture_photo);
        viewCaptureVideo = (LinearLayout) findViewById(R.id.ll_capture_video);
        whiteboardImageView = (ImageView) findViewById(R.id.action_bar_menu_share_whiteboard);
        collaborativeDocumentImageView = (ImageView) findViewById(R.id.action_bar_menu_collaborative_document);
        handwriteMessageImageView = (ImageView) findViewById(R.id.action_bar_menu_handwrite_message);
        capturePhotoImageView = (ImageView) findViewById(R.id.camera_menu_capture_photo);
        capturevideoImageView = (ImageView) findViewById(R.id.camera_menu_capture_video);
        chatMenuLayout = (LinearLayout) findViewById(R.id.custom_bottom_sheet_menu);
        cameraMenuLayout = (LinearLayout) findViewById(R.id.custom_bottom_sheet_camera_menu);
        cameraButton = (ImageButton) findViewById(R.id.img_btn_camera);
        buttonArrowUp = (ImageButton) findViewById(R.id.ButtonArrowUp);
        buttonArrowDown = (ImageButton) findViewById(R.id.ButtonArrowDown);
        dirtyView = (ImageView) findViewById(R.id.dirty_view);
        btnMenu = (ImageButton) findViewById(R.id.img_btn_chat_more);

        sheetBehavior.setBottomSheetCallback(new BottomSheetBehavior.BottomSheetCallback() {
            boolean first = true;

            @Override
            public void onStateChanged(View bottomSheet, int newState) {

            }

            @Override
            public void onSlide(View bottomSheet, float slideOffset) {
                if (first) {
                    first = false;
                    bottomSheet.setTranslationY(0);
                }
            }
        });

        setThemeColor();


        sheetCameraBehavior.setBottomSheetCallback(new BottomSheetBehavior.BottomSheetCallback() {
            boolean first = true;

            @Override
            public void onStateChanged(View bottomSheet, int newState) {

            }

            @Override
            public void onSlide(View bottomSheet, float slideOffset) {
                if (first) {
                    first = false;
                    bottomSheet.setTranslationY(0);
                }
            }
        });

        if (Stickers.isEnabled()) {
            stickerKeyboard = new StickerKeyboard();
            stickerKeyboard.enable(this, new StickerClickInterface() {
                @Override
                public void getClickedSticker(int gridviewItemPosition) {
                    String data = stickerKeyboard.getClickedSticker(gridviewItemPosition);
                    sendSticker(data);

                }
            }, R.id.footer_for_emoticons, messageField);
            stickerKeyboard.checkKeyboardHeight(chatFooter);
            stickerKeyboard.enableFooterView(messageField);
        } else {
            stickerButton.setVisibility(View.GONE);
        }

        PreferenceHelper.initialize(getApplicationContext());

        setActionBarTitle(firstName);
        setupOneToOneListView();
        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                try {
                    SessionData.getInstance().setOneToOneBroadCastMissed(false);
                    if (intent.hasExtra(IntentExtrasKeys.NEW_MESSAGE)) {
                        messageList = OneOnOneMessage.getAllMessages(sessionData.getId(), buddyId);
                        if (intent.hasExtra(IntentExtrasKeys.MESSAGE_TICK)) {
                            String value = intent.getStringExtra(IntentExtrasKeys.MESSAGE_TICK);
                            if (value.equals(IntentExtrasKeys.MESSAGE_READ)) {
                                for (OneOnOneMessage msg : messageList) {
                                    if (msg.messagetick != CometChatKeys.MessageTypeKeys.MESSAGE_READ) {
                                        msg.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_READ;
                                        msg.save();
                                    }
                                }
                            }
                        } else {
                            if (!noCometService && !TextUtils.isEmpty(buddy.cometid) && Integer.parseInt(PreferenceHelper.get(PreferenceKeys.UserKeys.READ_TICK)) == 1) {
                                int index = messageList.size();
                                if (index != 0) {
                                    OneOnOneMessage msg = messageList.get(index - 1);
                                    if (msg != null && msg.self == 0 && msg.messagetick != CometChatKeys.MessageTypeKeys.MESSAGE_READ) {
                                        String transport = config.getTRANSPORT();
                                        if (transport.equals("cometservice")) {
                                            CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getReadTickMessage(String.valueOf(msg.remoteId)));
                                        } else if (transport.equals("cometservice-selfhosted")) {
                                            WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getReadTickMessage(String.valueOf(msg.remoteId)));
                                        }
                                    }
                                }
                            }
                        }
                        adapter.clear();
                        adapter.addAll(messageList);
                        //adapter.notifyDataSetChanged();
                        chatListView.setSelection(adapter.getCount() - 1);
                        /*
                         * Uri notification =
						 * android.provider.Settings.System.DEFAULT_NOTIFICATION_URI
						 * ; Ringtone r =
						 * RingtoneManager.getRingtone(getApplicationContext(),
						 * notification); r.play();
						 */

                    } else if (intent.hasExtra(IntentExtrasKeys.IMAGE_SENDING)) {
                        /*
                         * OneToOneMessage messagePojo = new OneToOneMessage("",
						 * String.valueOf(SessionData.getInstance() .getId()),
						 * buddyId,
						 * intent.getStringExtra(CometChatKeys.FileUploadKeys
						 * .FILENAME), System.currentTimeMillis(), "1", "1",
						 * CometChatKeys.MessageTypeKeys.IMAGE, "");
						 * addOneToOneMessage(messagePojo);
						 */
                    } else if (intent.hasExtra(IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED)) {
                        adapter.notifyDataSetChanged();
                        // chatListView.setSelection(adapter.getCount() - 1);
                    } else if (intent.hasExtra(IntentExtrasKeys.VIDEO_SENDING)) {
                        OneOnOneMessage messagePojo = new OneOnOneMessage(0L, sessionData.getId(), buddyId,
                                intent.getStringExtra(CometChatKeys.FileUploadKeys.FILENAME),
                                System.currentTimeMillis(), 1, 1, CometChatKeys.MessageTypeKeys.VIDEO_UPLOAD, "", 0, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);
                        addMessage(messagePojo);
                    } else if (intent.hasExtra(IntentExtrasKeys.SUBTITLE_CHANGE)) {
                        String value = intent.getStringExtra(IntentExtrasKeys.SUBTITLE_CHANGE);
                        long iBuddyId = intent.getLongExtra(IntentExtrasKeys.BUDDY_ID, 0);
                        if (value.equals(IntentExtrasKeys.TYPING_START) && (iBuddyId == buddyId)) {
                            if (JsonPhp.getInstance().getConfig().gettypingEnabled() != null && JsonPhp.getInstance().getConfig().gettypingEnabled().equals("1")) {
                                if (PreferenceHelper.get(PreferenceKeys.UserKeys.TYPING_SETTING) != null && PreferenceHelper.get(PreferenceKeys.UserKeys.TYPING_SETTING).equals("1")) {
                                    setActioBarSubtitle(null == lang.getMobile().get157() ? "typing..." : lang.getMobile().get157());
                                }
                            }
                            TimerClass timer = new TimerClass(buddyId);
                            timer.setTimer(new VolleyAjaxCallbacks() {
                                @Override
                                public void successCallback(String response) {
                                    //setActioBarSubtitle("");
                                    Intent intent = new Intent(
                                            NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE);
                                    intent.putExtra(IntentExtrasKeys.SUBTITLE_CHANGE, IntentExtrasKeys.TYPING_STOP);
                                    intent.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                                    sendBroadcast(intent);
                                    // setActioBarSubtitle("")uiyuykhkjhk
                                    // jgjgjhgghj;
                                    updateLastSeenActivity();
                                }

                                @Override
                                public void failCallback(String response, boolean isNoInternet) {

                                }
                            });

                        } else if (value.equals(IntentExtrasKeys.TYPING_STOP)) {
                            if (JsonPhp.getInstance().getConfig().gettypingEnabled() != null && JsonPhp.getInstance().getConfig().gettypingEnabled().equals("1")) {
                                if (PreferenceHelper.get(PreferenceKeys.UserKeys.TYPING_SETTING) != null && PreferenceHelper.get(PreferenceKeys.UserKeys.TYPING_SETTING).equals("1")) {
                                    setActioBarSubtitle("");
                                }
                            }
                            updateLastSeenActivity();
                        } else if (value.equals(IntentExtrasKeys.REFRESH_LASTSEEN)) {
                            updateLastSeenActivity();
                        }
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };
        btnMenu.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                if (customMenu.getVisibility() == View.GONE) {
                    customMenu.setVisibility(View.VISIBLE);
                    btnMenu.setRotation(btnMenu.getRotation() + 180);
                } else {

                    customMenu.setVisibility(View.GONE);
                    btnMenu.setRotation(btnMenu.getRotation() + 180);
                }

                if(Stickers.isEnabled() && stickerKeyboard.isKeyboardVisibile()){
                    stickerKeyboard.dismissKeyboard();
                }

            }
        });

        cameraButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                Logger.error("Camera button clicked");
                dirtyView.setVisibility(View.VISIBLE);
                hideSoftKeyboard(SingleChatActivity.this);
                sheetCameraBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
            }
        });

        dirtyView.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                //sheetCameraBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                dirtyView.setVisibility(View.GONE);
            }
        });
        sendButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                sendMessage();
                if (!TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) && (Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) >= 564)) {
                    sendButton.setVisibility(View.GONE);
                    voiceNotebtn.setVisibility(View.VISIBLE);
                }
            }
        });

        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE) {
            String sendText = "Send";
            if (null != lang && null != lang.getMobile().get28()) {
                sendText = lang.getMobile().get28();
            }
            messageField.setImeActionLabel(sendText, EditorInfo.IME_ACTION_SEND);
        }

        messageField.setOnKeyListener(new View.OnKeyListener() {
            @Override
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if ((event.getAction() == KeyEvent.ACTION_DOWN) && (keyCode == KeyEvent.KEYCODE_ENTER) && getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE) {
                    sendMessage();
                    voiceNotebtn.setVisibility(View.VISIBLE);
                    return true;
                }
                return false;
            }
        });

        flag = true;
        messageField.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (!TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) && (Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) >= 564)) {
                    int len = messageField.getText().toString().length();
                    if (len > 0) {
                        voiceNotebtn.setVisibility(View.INVISIBLE);
                        sendButton.setVisibility(View.VISIBLE);
                    } else {
                        voiceNotebtn.setVisibility(View.VISIBLE);
                        sendButton.setVisibility(View.INVISIBLE);
                    }
                }
            }

            @Override
            public void afterTextChanged(Editable s) {
                if (!noCometService && config.gettypingEnabled() != null && config.gettypingEnabled().equals("1")) {
                    if (flag) {
                        flag = false;
                        try {
                            if (!TextUtils.isEmpty(buddy.cometid)) {
                                String transport = config.getTRANSPORT();
                                if (transport.equals("cometservice")) {
                                    CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getTypingStartMessage());
                                } else if (transport.equals("cometservice-selfhosted")) {
                                    WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getTypingStartMessage());
                                }

                                Timer timer = new Timer();
                                timer.schedule(new TimerTask() {
                                    @Override
                                    public void run() {
                                        flag = true;
                                    }
                                }, 5000);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }
            }
        });

        smilieyButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                smiliKeyBoard.showKeyboard(chatFooter);
            }
        });

        stickerButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                stickerKeyboard.showKeyboard(chatFooter);
            }
        });

        if (TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE))) {
            voiceNotebtn.setVisibility(View.INVISIBLE);
            sendButton.setVisibility(View.VISIBLE);
        } else if (Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) < 564) {
            voiceNotebtn.setVisibility(View.INVISIBLE);
            sendButton.setVisibility(View.VISIBLE);
        }
        voiceNotebtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                toggleRecording();
            }
        });

		/* Added to show Option menu on lower versions of android */
        try {
            ViewConfiguration config = ViewConfiguration.get(this);
            Field menuKeyField = ViewConfiguration.class.getDeclaredField(StaticMembers.PERMANENT_MENU_KEY);
            if (menuKeyField != null) {
                menuKeyField.setAccessible(true);
                menuKeyField.setBoolean(config, false);
            }
        } catch (Exception ex) {
            Logger.error(this.getClass().getSimpleName() + ": Exception at force menu");
        }
        sendMessageUrl = URLFactory.getSendOneToOneMessageURL();

        setUpChatMenu();
    }

    private void updateLastSeenActivity() {
        if (JsonPhp.getInstance().getConfig().getlastseenEnabled() != null && JsonPhp.getInstance().getConfig().getlastseenEnabled().equals("1")) {
            Buddy nbuddy = Buddy.getBuddyDetails(buddyId);
            if (nbuddy.lstn == 0 && !TextUtils.isEmpty(nbuddy.lastseen)) {
                final String status = CommonUtils.checkOnlineStatus(Long.parseLong(nbuddy.lastseen));
                if (!TextUtils.isEmpty(status)) {
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            setActioBarSubtitle(status);
                        }
                    });
                }
            } else {
                setActioBarSubtitle("");
            }
        }
    }

    public static void hideSoftKeyboard(Activity activity) {
        InputMethodManager inputMethodManager =
                (InputMethodManager) activity.getSystemService(
                        Activity.INPUT_METHOD_SERVICE);
        inputMethodManager.hideSoftInputFromWindow(
                activity.getCurrentFocus().getWindowToken(), 0);
    }



    private void toggleRecording() {
        try {
            if (isRecording) {
                isRecording = false;
                voiceNotebtn.setImageResource(R.drawable.cc_ic_custom_send_voice);
                messageField.setEnabled(true);
                messageField.setAlpha(1F);
                smilieyButton.setEnabled(true);
                smilieyButton.setAlpha(1F);

                if (voiceRecorder != null) {
                    voiceRecorder.stop();
                    voiceRecorder.release();
                    voiceRecorder = null;
                    String sendDialogButton = lang.getMobile().get28();
                    String cancelDialogButton = lang.getMobile().get32();
                    final View dialogview = getLayoutInflater().inflate(R.layout.cc_custom_voice_note_preview, null);
                    final ImageView playBtn = (ImageView) dialogview.findViewById(R.id.imageViewPlayIconPreview);
                    final SeekBar seekbar = (SeekBar) dialogview.findViewById(R.id.seek_barPreview);
                    final TextView textView1 = (TextView) dialogview.findViewById(R.id.textViewTimePreview);
                    final MediaPlayer player = CommonUtils.getPlayerInstance();
                    playBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor("#000000")));
                    player.reset();
                    try {
                        player.setDataSource(audioFileNamewithPath);
                        player.prepare();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }

                    final int audioTimetest = player.getDuration();
                    textView1.setText(CommonUtils.convertTimeStampToDurationTime(audioTimetest));
                    seekbar.setMax(audioTimetest);
                    seekbar.setProgress(player.getCurrentPosition());


                    playBtn.setOnClickListener(new OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            if (isVoiceNoteplaying) {
                                isVoiceNoteplaying = false;
                                playBtn.setBackgroundResource(R.drawable.cc_play);
                                if (player.isPlaying()) {
                                    try {
                                        player.stop();
                                        seekbar.setProgress(0);
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }
                            } else {
                                isVoiceNoteplaying = true;
                                playBtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor("#000000")));
                                playBtn.setBackgroundResource(R.drawable.cc_pause);
                                try {
                                    player.reset();
                                    player.setDataSource(audioFileNamewithPath);
                                    player.prepare();
                                    player.start();


                                    timerRunnable = new Runnable() {
                                        @Override
                                        public void run() {
                                            if (player != null) {
                                                seekbar.setProgress(player
                                                        .getCurrentPosition());
                                                if (player.isPlaying()
                                                        && player.getCurrentPosition() < audioTimetest) {

                                                    textView1.setText(CommonUtils.convertTimeStampToDurationTime(player.getCurrentPosition()));
                                                    seekHandler.postDelayed(this, 500);
                                                } else {
                                                    seekHandler
                                                            .removeCallbacks(timerRunnable);
                                                    //seekHandler.removeCallbacks(this);
                                                }
                                            }
                                        }
                                    };

                                    seekHandler.postDelayed(timerRunnable, 100);
                                    player.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
                                        @Override
                                        public void onCompletion(MediaPlayer mp) {
                                            playBtn.setBackgroundResource(R.drawable.cc_play);
                                            seekHandler
                                                    .removeCallbacks(timerRunnable);
                                            //seekHandler.removeCallbacks(this);
                                            mp.stop();
                                            isVoiceNoteplaying = false;
                                            seekbar.setProgress(0);
                                        }
                                    });
                                } catch (Exception e) {
                                    e.printStackTrace();
                                }
                            }
                        }
                    });
                    new CustomAlertDialogHelper(this, "", dialogview, sendDialogButton, "", cancelDialogButton, this,
                            AUDIO_SEND_PREVIEW_POPUP);
                }
            } else {
                messageField.setEnabled(false);
                messageField.setAlpha(0.6F);
                smilieyButton.setEnabled(false);
                smilieyButton.setAlpha(0.5F);

                isRecording = true;
                voiceNotebtn.setImageResource(R.drawable.cc_ic_custom_send_voice_record);
                voiceRecorder = new MediaRecorder();
                voiceRecorder.setAudioSource(MediaRecorder.AudioSource.MIC);
                voiceRecorder.setOutputFormat(MediaRecorder.OutputFormat.THREE_GPP);
                voiceRecorder.setAudioEncoder(MediaRecorder.OutputFormat.AMR_NB);
                audioFileNamewithPath = AudioSharing.getOutputMediaFile();
                voiceRecorder.setOutputFile(audioFileNamewithPath);


                voiceRecorder.prepare();
                voiceRecorder.start();
                Toast.makeText(getApplicationContext(), null == lang.getMobile().get165() ? "Recording.." : lang.getMobile().get165(),
                        Toast.LENGTH_LONG).show();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }



    private void setThemeColor() {
        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
       // setActionBarColor(primaryColor);
        sendButton.getDrawable().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        collaborativeDocumentImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        whiteboardImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        handwriteMessageImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        capturevideoImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        capturePhotoImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        capturePhotoImageView.getDrawable().setColorFilter(Color.parseColor("#FFFFFF"), PorterDuff.Mode.SRC_ATOP);
        cameraButton.getDrawable().setColorFilter(Color.parseColor("#8e8e92"), PorterDuff.Mode.SRC_ATOP);
    }


    private void setUpChatMenu(){

        if (ImageSharing.isDisabled()) {
            btnChatMenuSharePhoto.setVisibility(View.GONE);
            viewCapturePhoto.setVisibility(View.GONE);
        }else {

            btnChatMenuSharePhoto.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isStoragePermissionGranted()){
                        imageUpload();
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }

                }
            });

            if(lang.getCore().get67() != null){
                TextView tvCapturePhoto = (TextView)viewCapturePhoto.findViewById(R.id.textCapturePhoto);
                tvCapturePhoto.setText(lang.getCore().get67());
            }
            viewCapturePhoto.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    if(isCameraPermissionGranted()){
                        capturePhoto();
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }

        if (VideoSharing.isDisabled()) {
            btnChatMenuShareVideo.setVisibility(View.GONE);
            viewCaptureVideo.setVisibility(View.GONE);
        }else {
            btnChatMenuShareVideo.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isStoragePermissionGranted()){
                        videoUpload();
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });


            if(lang.getCore().get69() != null){
                TextView tvCaptureVideo = (TextView)viewCaptureVideo.findViewById(R.id.textCaptureVideo);
                tvCaptureVideo.setText(lang.getCore().get69());
            }
            viewCaptureVideo.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);

                    if(isCameraPermissionGranted()){
                        videoCapture();
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });

        }

        if(ImageSharing.isDisabled() && VideoSharing.isDisabled()){
            cameraButton.setVisibility(View.GONE);
        }


        /**  Incase of basic uncoment the below line**/
        //btnChatMenuBroadcast.setVisibility(View.GONE);



        if (!AVBroadcast.isEnabled()) {
            btnChatMenuBroadcast.setVisibility(View.GONE);
        }else{
            btnChatMenuBroadcast.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isCameraPermissionGranted()){
                        startBrodcast();
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }

        if (OtherPlugins.isWhiteBoarddisabled()) {
            viewShareWiteboard.setVisibility(View.GONE);
        }else {
            TextView tvWhiteBoard = (TextView) viewShareWiteboard.findViewById(R.id.textWhiteBoard);
            if(lang.getWhiteboard().get0() != null){
                tvWhiteBoard.setText(lang.getWhiteboard().get0());
            }
            viewShareWiteboard.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    startWhiteBoard();
                }
            });
        }

        if (OtherPlugins.isWriteBoarddisabled()) {
            viewCollaborativeDocument.setVisibility(View.GONE);
        }else{
            TextView tvWriteBoard = (TextView) viewCollaborativeDocument.findViewById(R.id.textCollaborative);
            if(lang.getWriteboard().get7()!= null){
                tvWriteBoard.setText(lang.getWriteboard().get7());
            }
            viewCollaborativeDocument.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    startWriteBoard();
                }
            });
        }

        if (OtherPlugins.isHandwriteDisabled()) {
            viewHandwriteMessage.setVisibility(View.GONE);

        }else{
            TextView tvHandwrite = (TextView) viewHandwriteMessage.findViewById(R.id.textHandwrite);
            if(lang.getHandwrite().get0() != null){
                tvHandwrite.setText(lang.getHandwrite().get0());
            }
            viewHandwriteMessage.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    startHandwrite();
                }
            });
        }

        if(OtherPlugins.isWhiteBoarddisabled() && OtherPlugins.isWriteBoarddisabled() && OtherPlugins.isHandwriteDisabled()){
            btnChatMenuMore.setVisibility(View.INVISIBLE);
        }else{
            btnChatMenuMore.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    dirtyView.setVisibility(View.VISIBLE);
                    chatMenuLayout.setVisibility(View.VISIBLE);
                    sheetBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
                }
            });
        }


        if(ImageSharing.isDisabled() && VideoSharing.isDisabled() && !AVBroadcast.isEnabled() && OtherPlugins.isWhiteBoarddisabled() && OtherPlugins.isHandwriteDisabled() && OtherPlugins.isWhiteBoarddisabled() && OtherPlugins.isWriteBoarddisabled() && OtherPlugins.isHandwriteDisabled()){
            btnMenu.setVisibility(View.GONE);
        }else {

            btnChatMenuKeyBoard.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {


                    Logger.error("Toggle keyBoard button Clicked");

                    InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
               /* inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);*/

                    if (Stickers.isEnabled() && stickerKeyboard.isKeyboardVisibile()) {
                        stickerKeyboard.showKeyboard(chatFooter);

                        if (!inputMethodManager.isActive()) {
                            inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);
                        }

                    } else {
                        inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);
                    }
                }
            });
        }


        getBtnChatMenuSticker.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                stickerKeyboard.showKeyboard(chatFooter);
            }
        });
    }


    public  boolean isStoragePermissionGranted() {
        if (Build.VERSION.SDK_INT >= 23) {
            if (checkSelfPermission(android.Manifest.permission.WRITE_EXTERNAL_STORAGE)
                    == PackageManager.PERMISSION_GRANTED) {
                Logger.error("Permission is granted");
                return true;
            } else {

                Logger.error("Permission is revoked");
                ActivityCompat.requestPermissions(this, new String[]{android.Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1);
                return false;
            }
        }
        else { //permission is automatically granted on sdk<23 upon installation
            Logger.error("Permission is granted");
            return true;
        }


    }

    public boolean isCameraPermissionGranted(){
        if (Build.VERSION.SDK_INT >= 23) {
            if (checkSelfPermission(android.Manifest.permission.CAMERA)
                    == PackageManager.PERMISSION_GRANTED) {
                return true;
            } else {

                ActivityCompat.requestPermissions(this, new String[]{android.Manifest.permission.CAMERA}, 1);
                return false;
            }
        }
        else { //permission is automatically granted on sdk<23 upon installation
            Logger.error("Permission is granted");
            return true;
        }
    }

    public boolean isRecordAudioPermissionGranted(){
        if (Build.VERSION.SDK_INT >= 23) {
            if (checkSelfPermission(android.Manifest.permission.RECORD_AUDIO) == PackageManager.PERMISSION_GRANTED) {
                return true;
            } else {
                ActivityCompat.requestPermissions(this, new String[]{android.Manifest.permission.RECORD_AUDIO}, 1);
                return false;
            }
        }
        else { //permission is automatically granted on sdk<23 upon installation
            Logger.error("Permission is granted");
            return true;
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.cc_single_chat_activity_menu, menu);

        if (VideoChat.isDisabled()) {
            menu.findItem(R.id.custom_action_video_call).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_video_call).setTitle(lang.getAvchat().get0());
        }


        if (VideoChat.isAudioChatDisabled()) {
            menu.findItem(R.id.custom_action_audio_call).setVisible(false);
        }



       /* if (ReportConversation.isDisabled()) {
            menu.findItem(R.id.custom_action_report_conversation).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_report_conversation).setTitle(lang.getReport().get0());
        }

        if (ClearConversation.isDisabled()) {
            menu.findItem(R.id.custom_action_clear_conversation).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_clear_conversation).setTitle(lang.getCore().get64());
        }

        if (ImageSharing.isDisabled()) {
            menu.findItem(R.id.custom_action_image_upload_single_chat).setVisible(false);
            menu.findItem(R.id.custom_action_captured_image_upload_single_chat).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_image_upload_single_chat).setTitle(lang.getCore().get66());
            menu.findItem(R.id.custom_action_captured_image_upload_single_chat).setTitle(lang.getCore().get67());
        }

        if (VideoSharing.isDisabled()) {
            menu.findItem(R.id.custom_action_video_upload_single_chat).setVisible(false);
            menu.findItem(R.id.custom_action_video_capture_single_chat).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_video_upload_single_chat).setTitle(lang.getCore().get68());
            menu.findItem(R.id.custom_action_video_capture_single_chat).setTitle(lang.getCore().get69());
        }

        if (BlockUnblockUser.isblockUnblockDisabled()) {
            menu.findItem(R.id.custom_action_block_user).setVisible(false);
        } else {
            if (lang.getBlock() != null)
                menu.findItem(R.id.custom_action_block_user).setTitle(lang.getBlock().get0());
        }

        if (VideoChat.isAudioChatDisabled()) {
            menu.findItem(R.id.custom_action_audio_call).setVisible(false);
        }

        if (AVBroadcast.isEnabled()) {
            if (null != lang.getMobile().get163()) {
                menu.findItem(R.id.custom_action_video_broadcast_single_chat).setTitle(lang.getMobile().get163());
            }
        } else {
            menu.findItem(R.id.custom_action_video_broadcast_single_chat).setVisible(false);
        }

        if (!TextUtils.isEmpty(lang.getMobile().get92())) {
            menu.findItem(R.id.custom_action_view_profile).setTitle(lang.getMobile().get92());
        }

        if (OtherPlugins.isWhiteBoarddisabled()) {
            menu.findItem(R.id.custom_action_start_whiteboard).setVisible(false);
        } else {
            if (lang.getWhiteboard() != null) {
                menu.findItem(R.id.custom_action_start_whiteboard).setTitle(lang.getWhiteboard().get0());
            }
        }

        if (OtherPlugins.isWriteBoarddisabled()) {
            menu.findItem(R.id.custom_action_start_writeboard).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_start_writeboard).setVisible(true);
            if (lang.getWriteboard() != null) {
                menu.findItem(R.id.custom_action_start_writeboard).setTitle(lang.getWriteboard().get7());
            }
        }
        if (OtherPlugins.isHandwriteDisabled()) {
            menu.findItem(R.id.custom_action_start_handwrite).setVisible(false);
        } else {
            if (lang.getHandwrite() != null) {
                menu.findItem(R.id.custom_action_start_handwrite).setTitle(lang.getHandwrite().get0());
            }
        }*/

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        int i = item.getItemId();
        if (i == R.id.custom_action_more) {
            final View menuItemView = findViewById(R.id.custom_action_more);

            if (!sheetBehavior.isHideable()) {
                sheetBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
            }
            showCustomActionBarPopup(menuItemView);

        } else if (i == R.id.custom_action_video_call) {
            if (CommonUtils.isConnected()) {
                if (Build.VERSION.SDK_INT >= 16) {
                    if(isCameraPermissionGranted()){
                        showCallPopup(false);
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(this, lang.getAvchat().get42(), Toast.LENGTH_LONG).show();
                }
            } else {
                Toast.makeText(this, lang.getMobile().get24(), Toast.LENGTH_LONG).show();
            }

        } else if (i == R.id.custom_action_audio_call) {
            if (CommonUtils.isConnected()) {
                if (Build.VERSION.SDK_INT >= 16) {
                    if(isRecordAudioPermissionGranted()){
                        showCallPopup(true);
                    }else{
                        Toast.makeText(SingleChatActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(this, lang.getAvchat().get42(), Toast.LENGTH_LONG).show();
                }
            } else {
                Toast.makeText(this, lang.getMobile().get24(), Toast.LENGTH_LONG).show();
            }


           /* case R.id.custom_action_clear_conversation:
                OneOnOneMessage.clearConversation(String.valueOf(buddyId));
                txt.setVisibility(View.GONE);
                messageList.clear();
                adapter.clear();
                break;
            case R.id.custom_action_start_handwrite:
                startHandwrite();
                break;
            case R.id.custom_action_video_call:
                if (CommonUtils.isConnected()) {
                    if (android.os.Build.VERSION.SDK_INT >= 16) {
                        showCallPopup(false);
                    } else {
                        Toast.makeText(this, lang.getAvchat().get42(), Toast.LENGTH_LONG).show();
                    }
                } else {
                    Toast.makeText(this, lang.getMobile().get24(), Toast.LENGTH_LONG).show();
                }
                break;
            case R.id.custom_action_report_conversation:
                reportConversation();
                break;
            case R.id.custom_action_image_upload_single_chat:
                imageUpload();
                break;
            case android.R.id.home:
                onBackPressed();
                break;
            case R.id.custom_action_captured_image_upload_single_chat:
                capturePhoto();
                break;
            case R.id.custom_action_video_upload_single_chat:
                videoUpload();
                break;
            case R.id.custom_action_video_capture_single_chat:
                videoCapture();
                break;

            case R.id.custom_action_block_user:
                blockUser();
                break;
            case R.id.custom_action_audio_call:
                if (CommonUtils.isConnected()) {
                    if (android.os.Build.VERSION.SDK_INT >= 16) {
                        showCallPopup(true);
                    } else {
                        Toast.makeText(this, lang.getAvchat().get42(), Toast.LENGTH_LONG).show();
                    }
                } else {
                    Toast.makeText(this, lang.getMobile().get24(), Toast.LENGTH_LONG).show();
                }
                break;
            case R.id.custom_action_view_profile:
                Intent i = new Intent(getApplicationContext(), ViewUserProfileActivity.class);
                i.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                startActivity(i);
                break;
            case R.id.custom_action_video_broadcast_single_chat:
                startBrodcast();
                break;
            case R.id.custom_action_start_whiteboard:
                startWhiteBoard();
                break;
            case R.id.custom_action_start_writeboard:
                startWriteBoard();
                break;
            default:
                break;*/
        }
        return super.onOptionsItemSelected(item);
    }

    private void showCustomActionBarPopup(View view) {
        final PopupWindow showPopup = PopupHelper.newBasicPopupWindow(getApplicationContext());
        LayoutInflater inflater = (LayoutInflater) getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View popupView = inflater.inflate(R.layout.cc_custom_single_chat_action_bar_menu, null);
        showPopup.setContentView(popupView);

        LinearLayout viewProfile = (LinearLayout) popupView.findViewById(R.id.ll_view_profile);
        LinearLayout clearConversation = (LinearLayout) popupView.findViewById(R.id.ll_clear_conversation);
        LinearLayout reportConversation = (LinearLayout) popupView.findViewById(R.id.ll_report_conversation);
        LinearLayout blockuser = (LinearLayout) popupView.findViewById(R.id.ll_block_user);

        ImageView viewProfileImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_view_profile);
        ImageView clearConversationImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_clear_conversation);
        ImageView reportConversarionImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_report_conversation);
        ImageView blockUserImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_block_user);

        String primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        viewProfileImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        clearConversationImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        reportConversarionImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        blockUserImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);

        TextView tvViewProfile = (TextView) popupView.findViewById(R.id.tv_view_profile);
        TextView tvClearConversation = (TextView) popupView.findViewById(R.id.tv_clear_conversation);
        TextView tvReportConversation = (TextView) popupView.findViewById(R.id.tv_reportConversation);
        TextView tvBlockuser = (TextView) popupView.findViewById(R.id.tv_block_user);


        if (null != JsonPhp.getInstance().getLang() && null != JsonPhp.getInstance().getLang().getMobile().get92()) {
            tvViewProfile.setText(JsonPhp.getInstance().getLang().getMobile().get92());
        }

        if (null != lang.getCore().get64()) {
            tvClearConversation.setText(lang.getCore().get64());
        }

        if (null != lang.getReport() && null != lang.getReport().get0()) {
            tvReportConversation.setText(lang.getReport().get0());
        }

        if (null != lang.getBlock() && null != lang.getBlock().get0()) {
            tvBlockuser.setText(lang.getBlock().get0());
        }

        viewProfile.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                Intent i = new Intent(getApplicationContext(), ViewUserProfileActivity.class);
                i.putExtra(IntentExtrasKeys.BUDDY_ID, buddyId);
                startActivity(i);
            }
        });

        clearConversation.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                OneOnOneMessage.clearConversation(String.valueOf(buddyId));
                messageList.clear();
                adapter.clear();
                showPopup.dismiss();
            }
        });

        reportConversation.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                reportConversation();
                showPopup.dismiss();
            }
        });

        blockuser.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                blockUser();
                showPopup.dismiss();
            }
        });

        showPopup.setWidth(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setHeight(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setAnimationStyle(R.style.Animations_GrowFromTop);
        showPopup.showAsDropDown(view);
    }

    private void startWhiteBoard() {
        VolleyHelper vhelper = new VolleyHelper(this, URLFactory.getWhiteBoardURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                try {
                    JSONObject details = new JSONObject(response);
                    if (details.has("room")) {
                        Intent i = new Intent(getApplicationContext(), WhiteboardActivity.class);
                        i.putExtra(IntentExtrasKeys.ROOM_NAME, details.getString("room"));
                        startActivity(i);
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                Logger.error("white board sucess fail");
            }
        });

        vhelper.addNameValuePair(AjaxKeys.ACTION, AjaxKeys.WHITEBOARD);
        vhelper.addNameValuePair(AjaxKeys.ID, buddyId);
        vhelper.sendCallBack(false);
        vhelper.addNameValuePair(AjaxKeys.RANDOM, System.currentTimeMillis());
        vhelper.sendAjax();
    }
    private void startWriteBoard() {
        final String randomId = String.valueOf(System.currentTimeMillis());
        VolleyHelper vhelper = new VolleyHelper(this, URLFactory.getWriteBoardURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                Intent intent = new Intent(getApplicationContext(), WriteBoardActivity.class);
                intent.putExtra(IntentExtrasKeys.RANDOMID, randomId);
                startActivity(intent);
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
            }
        });

        vhelper.addNameValuePair(AjaxKeys.ID, randomId);
        vhelper.addNameValuePair(AjaxKeys.TO, buddyId);
        vhelper.sendCallBack(false);
        vhelper.sendAjax();
    }

    private void blockUser() {
        LayoutInflater inflater = getLayoutInflater();
        View dialogview = inflater.inflate(R.layout.cc_custom_dialog, null);
        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
        EditText dialogueInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
        dialogueInput.setVisibility(View.GONE);

        String yes = StaticMembers.POSITIVE_TITLE, no = StaticMembers.NEGATIVE_TITLE;

        if (lang.getMobile().get33() != null) {
            yes = lang.getMobile().get33();
        }
        if (lang.getMobile().get34() != null) {
            no = lang.getMobile().get34();
        }

        if (lang.getBlock().get1() == null) {
            dialogueTitle.setText(StaticMembers.BLOCK_USER_WARNING_TEXT);
        } else {
            dialogueTitle.setText(lang.getBlock().get1());
        }

        new CustomAlertDialogHelper(this, "", dialogview, yes, "", no, this, BLOCK_USER_POPUP);

    }

    private void reportConversation() {
        if (messageList.size() > 0) {
            LayoutInflater inflater = getLayoutInflater();
            View dialogview = inflater.inflate(R.layout.cc_custom_dialog, null);
            TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
            EditText dialogueInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);

            dialogueTitle.setText(lang.getReport().get1());

            dialogueInput.setHint(lang.getMobile().get27());
            dialogueInput.setInputType(InputType.TYPE_CLASS_TEXT);
            String cancelDialogButton = lang.getMobile().get32();
            if (TextUtils.isEmpty(cancelDialogButton)) {
                cancelDialogButton = lang.getChatrooms().get51();
            }
            new CustomAlertDialogHelper(this, "", dialogview, lang.getMobile().get31(), "", cancelDialogButton, this,
                    REPORT_CONVERSATION_POPUP);
        } else {
            Toast.makeText(this, lang.getReport().get5(), Toast.LENGTH_LONG).show();
        }
    }

    private void startBrodcast() {
        VolleyHelper vhelper = new VolleyHelper(getApplicationContext(), URLFactory.getAVBroadcastRequestURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                if (response.contains("jqcc") && response.contains("(")) {
                    String data[] = response.split("\\(");
                    String roomName = data[1].substring(0, data[1].length() - 1);
                    Intent intent = new Intent(SingleChatActivity.this, VideoChatActivity.class);
                    intent.putExtra(StaticMembers.INTENT_ROOM_NAME, roomName);
                    intent.putExtra(StaticMembers.INTENT_AVBROADCAST_FLAG, true);
                    intent.putExtra(StaticMembers.INTENT_IAMBROADCASTER_FLAG, true);
                    intent.putExtra(IntentExtrasKeys.BUDDY_ID, String.valueOf(buddyId));
                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    getApplicationContext().startActivity(intent);
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                Logger.error("respnse fail =" + response);
            }
        });

        vhelper.addNameValuePair(AjaxKeys.AVBROADCAST, "0");
        vhelper.addNameValuePair(AjaxKeys.CHATROOM_TYPE, "1");
        vhelper.addNameValuePair(AjaxKeys.TO, buddyId);
        vhelper.sendAjax();

    }


    private void videoCapture() {
        Intent intent = new Intent(MediaStore.ACTION_VIDEO_CAPTURE);
        if (!CommonUtils.isSamsungWithApi16()) {
            fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_VIDEO, false);
            intent.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
        }

        intent.putExtra(MediaStore.EXTRA_VIDEO_QUALITY, 0);
        intent.putExtra(MediaStore.EXTRA_SIZE_LIMIT, LocalConfig.getFileUploadLimit());
        startActivityForResult(intent, StaticMembers.CAPTURE_VIDEO_REQUEST_ONE_ON_ONE);
    }

    private void videoUpload() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        intent.setType(StaticMembers.VIDEO_TYPE);
        startActivityForResult(intent, StaticMembers.CHOOSE_VIDEO_REQUEST_ONE_ON_ONE);
    }

    private void capturePhoto() {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, false);
        intent.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
        startActivityForResult(intent, StaticMembers.CAPTURE_PHOTO_REQUEST_ONE_ON_ONE);
    }

    private void imageUpload() {
        Intent intent = new Intent(Intent.ACTION_PICK);
        intent.setType(StaticMembers.IMAGE_TYPE);
        startActivityForResult(intent, StaticMembers.CHOOSE_IMAGE_REQUEST_ONE_ON_ONE);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            if (resultCode == RESULT_OK) {
                switch (requestCode) {
                    case StaticMembers.CHOOSE_IMAGE_REQUEST_ONE_ON_ONE:
                        checkUserConfirmation(data, false);
                        break;
                    case StaticMembers.CAPTURE_PHOTO_REQUEST_ONE_ON_ONE:
                        new ImageSharing().sendImageOneOnOne(this, fileUri, buddyId);
                        break;
                    case StaticMembers.CHOOSE_VIDEO_REQUEST_ONE_ON_ONE:
                        checkUserConfirmation(data, true);
                        break;
                    case StaticMembers.CAPTURE_VIDEO_REQUEST_ONE_ON_ONE:
                        if (CommonUtils.isSamsungWithApi16()) {
                            VideoSharing.sendVideoOneOnOne(this, data, buddyId);
                        } else {
                            VideoSharing.sendVideoOneOnOne(this, new File(new URI(fileUri.toString())).getAbsolutePath(),
                                    buddyId);
                        }
                        break;
                    default:
                        break;
                }
            }
        } catch (Exception e) {
            Logger.error("SingleChatActivity.java onActivityResult() : Exception =" + e.getLocalizedMessage());
            e.printStackTrace();
        }
    }

    private void checkUserConfirmation(String selectedString, boolean isVideo) {
        if (!selectedString.isEmpty()) {
            try {
                data = Intent.getIntent(selectedString);
            } catch (URISyntaxException e) {
                e.printStackTrace();
            }
            if (data != null) checkUserConfirmation(data, isVideo);
        }
    }

    private void startHandwrite(){
        Logger.error("clicked startHandwrite");

        Intent i = new Intent(getApplicationContext(), HandwriteActivity.class);
        i.putExtra(AjaxKeys.SENDERNAME, buddy.name);
        i.putExtra(AjaxKeys.BASE_DATA, PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
        i.putExtra(AjaxKeys.ID, buddyId);

        startActivity(i);
    }

    private void checkUserConfirmation(Intent data, boolean isVideo) {

        if (data != null) {
            Uri selectedImageUri = data.getData();
            LayoutInflater inflater = getLayoutInflater();
            View dialogview = inflater.inflate(R.layout.cc_custom_image_preview, null);
            ImageView imagePreview = (ImageView) dialogview.findViewById(R.id.imageViewLargePreview);
            ImageView closePopup = (ImageView) dialogview.findViewById(R.id.imageViewClosePreviewPopup);
            closePopup.setVisibility(View.GONE);
            this.data = data;
            String sendDialogButton = "Send", cancelDialogButton = "Cancel";

            if (lang != null) {
                sendDialogButton = lang.getMobile().get28();
                cancelDialogButton = lang.getMobile().get32();
            }


            if (TextUtils.isEmpty(cancelDialogButton)) {
                cancelDialogButton = lang.getChatrooms().get51();
            }
            if (isVideo) {
                Bitmap bitmap = null;
                if (CommonUtils.isSamsung()) {
                    bitmap = MediaStore.Video.Thumbnails.getThumbnail(getContentResolver(),
                            Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Video.Thumbnails.MINI_KIND,
                            (BitmapFactory.Options) null);
                } else if (CommonUtils.isXiaomi()) {
                    try {
                        bitmap = MediaStore.Video.Thumbnails.getThumbnail(getContentResolver(),
                                Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Video.Thumbnails.MINI_KIND,
                                (BitmapFactory.Options) null);
                    } catch (Exception e) {
                        e.printStackTrace();
                        bitmap = null;
                    }
                    if (bitmap == null) {
                        bitmap = VideoSharing.getVideoBitmap(selectedImageUri, this);
                    }
                } else if (Build.VERSION.SDK_INT > 19) {
                    try {
                        String wholeID = DocumentsContract.getDocumentId(selectedImageUri);
                        String id = wholeID.split(":")[1];
                        bitmap = MediaStore.Video.Thumbnails.getThumbnail(getContentResolver(),
                                Long.parseLong(id), MediaStore.Video.Thumbnails.MINI_KIND,
                                (BitmapFactory.Options) null);
                    } catch (Exception e) {
                        e.printStackTrace();
                        bitmap = null;
                    }
                    if (bitmap == null) {
                        bitmap = VideoSharing.getVideoBitmap(selectedImageUri, this);
                    }
                } else {
                    InputStream is = null;
                    try {
                        is = getContentResolver().openInputStream(selectedImageUri);
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    }

                    bitmap = BitmapFactory.decodeStream(is);
                    try {
                        is.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }

                imagePreview.setImageBitmap(bitmap);
                ImageView playButtonImage = (ImageView) dialogview
                        .findViewById(R.id.imageViewVideoPlayButtonForPreview);
                playButtonImage.setVisibility(View.VISIBLE);

                new CustomAlertDialogHelper(this, "", dialogview, sendDialogButton, "", cancelDialogButton, this,
                        VIDEO_SEND_PREVIEW_POPUP);
            } else {
                Bitmap bitmap = null;
                if (CommonUtils.isSamsung()) {
                    bitmap = MediaStore.Images.Thumbnails.getThumbnail(getContentResolver(),
                            Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Images.Thumbnails.MINI_KIND,
                            (BitmapFactory.Options) null);
                    if (bitmap == null) {
                        bitmap = ImageSharing.getImageBitmap(selectedImageUri, this);
                    }
                } else if (CommonUtils.isXiaomi()) {
                    try {
                        bitmap = MediaStore.Images.Thumbnails.getThumbnail(getContentResolver(),
                                Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Images.Thumbnails.MINI_KIND,
                                (BitmapFactory.Options) null);
                        if (bitmap == null) {
                            bitmap = ImageSharing.getImageBitmap(selectedImageUri, this);
                        }
                    } catch (Exception e) {
                        try {
                            InputStream is = getContentResolver().openInputStream(selectedImageUri);
                            bitmap = BitmapFactory.decodeStream(is);
                        } catch (Exception e1) {
                            e1.printStackTrace();
                        }
                    }

                    /*bitmap = MediaStore.Images.Thumbnails.getThumbnail(getContentResolver(),
                            Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Images.Thumbnails.MINI_KIND,
                            (BitmapFactory.Options) null);*/

                } else if (Build.VERSION.SDK_INT > 19) {
                    try {
                        String wholeID = DocumentsContract.getDocumentId(selectedImageUri);
                        String id = wholeID.split(":")[1];
                        bitmap = MediaStore.Images.Thumbnails.getThumbnail(getContentResolver(),
                                Long.parseLong(id), MediaStore.Images.Thumbnails.MINI_KIND,
                                (BitmapFactory.Options) null);
                    } catch (Exception e) {
                        e.printStackTrace();
                        InputStream is = null;
                        String myPath;
                        if (selectedImageUri.getAuthority() != null) {
                            try {
                                is = getContentResolver().openInputStream(selectedImageUri);
                                Bitmap bmp = BitmapFactory.decodeStream(is);
                                String path = ImageSharing.writeToTempImageAndGetPathUri(this, bmp).toString();
                                Uri pathUri = Uri.parse(path);
                                if (pathUri != null) {
                                    String[] filePathColumn = {MediaStore.MediaColumns.DATA};
                                    Cursor cursor = PreferenceHelper.getContext().getContentResolver()
                                            .query(pathUri, filePathColumn, null, null, null);
                                    cursor.moveToFirst();
                                    myPath = cursor.getString(cursor.getColumnIndex(filePathColumn[0]));
                                    File imgFile = new File(myPath);
                                    if (imgFile.exists()) {
                                        bitmap = BitmapFactory.decodeFile(imgFile.getAbsolutePath());
                                    }
                                    cursor.close();
                                } else {
                                    myPath = null;
                                }
                            } catch (FileNotFoundException e2) {
                                Toast.makeText(getApplicationContext(), "Cant Send Empty File ", Toast.LENGTH_SHORT).show();
                                e2.printStackTrace();
                            } finally {
                                try {
                                    if (is != null)
                                        is.close();
                                } catch (IOException e3) {
                                    e3.printStackTrace();
                                }
                            }
                        }
                    }

                } else {
                    InputStream is = null;
                    try {
                        is = getContentResolver().openInputStream(selectedImageUri);
                    } catch (FileNotFoundException e) {
                        e.printStackTrace();
                    }

                    bitmap = BitmapFactory.decodeStream(is);
                    try {
                        is.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }

                if (null == bitmap) {
                    Uri imageUri = data.getData();
                    if (null != imageUri) {
                        /* Check weather picasa image is selected from gallery */
                        if (imageUri.toString().startsWith("content://com.sec.android.gallery3d")
                                || imageUri.toString().startsWith("content://com.android.gallery3d")) {
                            try {
                                BitmapFactory.Options options = new BitmapFactory.Options();
                                final InputStream ist = getContentResolver().openInputStream(imageUri);
                                picassaBitmap = BitmapFactory.decodeStream(ist, null, options);
                                ist.close();
                                if (null != picassaBitmap) {
                                    picassImageName = imageUri.toString().substring(
                                            imageUri.toString().lastIndexOf("/") + 1);
                                    imagePreview.setImageBitmap(picassaBitmap);
                                    new CustomAlertDialogHelper(this, "", dialogview, sendDialogButton, "",
                                            cancelDialogButton, this, PICASSA_IMAGE_PREVIEW_POPUP);
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    }
                } else {
                    imagePreview.setImageBitmap(bitmap);
                    new CustomAlertDialogHelper(this, "", dialogview, sendDialogButton, "", cancelDialogButton, this,
                            IMAGE_SEND_PREVIEW_POPUP);
                }
            }
        }
    }

    @Override
    public void onButtonClick(final AlertDialog alertDialog, View v, int which, int popupId) {
        switch (popupId) {
            case REPORT_CONVERSATION_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    EditText dialogueInput = (EditText) v.findViewById(R.id.edittextDialogueInput);
                    String reasonForReporting = dialogueInput.getText().toString().trim();

                    if (reasonForReporting.length() > 0) {
                        ReportConversation.report(buddyId, reasonForReporting);
                        alertDialog.dismiss();
                    } else {
                        if (lang.getReport() != null && lang.getReport().get6() != null){
                            dialogueInput.setError(lang.getReport().get6());
                        }else{
                            dialogueInput.setError("Reason must be filled out.");
                        }
                    }
                }
                if (which == DialogInterface.BUTTON_NEGATIVE) {
                    alertDialog.dismiss();
                }
                break;
            case IMAGE_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (data != null) {
                        new ImageSharing().sendImageOneOnOne(this, data, buddyId);
                    } else {

                        try {
                            Intent dataImage = null;
                            dataImage = Intent.getIntent(PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL));
                            new ImageSharing().sendImageOneOnOne(this, dataImage, buddyId);
                        } catch (URISyntaxException e) {
                            e.printStackTrace();
                        }
                    }

                }
                alertDialog.dismiss();
                data = null;
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_IMAGE_URL);
                break;
            case PICASSA_IMAGE_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (null != picassaBitmap) {
                        new ImageSharing().sendImageOneOnOne(this, picassImageName, picassaBitmap, buddyId);
                    }
                }
                alertDialog.dismiss();
                break;

            case VIDEO_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (data != null) {
                        VideoSharing.sendVideoOneOnOne(this, data, buddyId);
                    } else {
                        try {
                            Intent dataVideo = null;
                            dataVideo = Intent.getIntent(PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL));
                            VideoSharing.sendVideoOneOnOne(this, dataVideo, buddyId);
                        } catch (URISyntaxException e) {
                            e.printStackTrace();
                        }
                    }
                }
                alertDialog.dismiss();
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_VIDEO_URL);
                data = null;
                break;
            case BLOCK_USER_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    BlockUnblockUser.blockUser(buddyId, getApplicationContext(), new CometchatCallbacks() {

                        @Override
                        public void successCallback() {
                            try {
                                //Buddy.deleteById(buddyId);
                                if (buddy == null) {
                                    buddy = Buddy.getBuddyDetails(buddyId);
                                }
                                buddy.showuser = 0;
                                buddy.save();
                                Intent intent = new Intent(HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                                intent.putExtra(ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                                sendBroadcast(intent);
                                sessionData.setBuddyListBroadcastMissed(true);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                            alertDialog.dismiss();
                            finish();
                        }

                        @Override
                        public void failCallback() {
                            alertDialog.dismiss();
                            Toast.makeText(
                                    getApplicationContext(),
                                    (null == lang.getMobile().get69() ? StaticMembers.ERROR_BLOCKING_USER : lang
                                            .getMobile().get69()), Toast.LENGTH_SHORT).show();

                        }
                    });
                } else if (which == DialogInterface.BUTTON_NEGATIVE) {
                    alertDialog.dismiss();
                }
                break;
            case AUDIO_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    AudioSharing.sendAudio(this, audioFileNamewithPath, buddyId, false);
                    alertDialog.dismiss();
                } else if (which == DialogInterface.BUTTON_NEGATIVE) {
                    try {
                        new File(audioFileNamewithPath).delete();
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                    alertDialog.dismiss();
                }
                break;
            default:
                break;
        }
    }

    private void showCallPopup(final boolean isAudioOnlyCall) {
        try {
            String yes = StaticMembers.POSITIVE_TITLE, no = StaticMembers.NEGATIVE_TITLE;
            if (lang.getMobile().get33() != null) {
                yes = lang.getMobile().get33();
            }
            if (lang.getMobile().get34() != null) {
                no = lang.getMobile().get34();
            }

            ConfirmationWindow cWindow = new ConfirmationWindow(this, yes, no) {

                @Override
                protected void setNegativeResponse() {
                    super.setNegativeResponse();
                }

                @Override
                protected void setPositiveResponse() {
                    super.setPositiveResponse();
                    initiateCall(isAudioOnlyCall);
                }
            };
            if (isAudioOnlyCall) {
                cWindow.setMessage((lang.getAudiochat() == null) ? "Call" : lang.getAudiochat().get28() + " "
                        + firstName + "?");
            } else {
                cWindow.setMessage((lang.getAvchat() == null) ? "Call" : lang.getAvchat().get28() + " " + firstName
                        + "?");
            }

            cWindow.show();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("HandlerLeak")
    private void initiateCall(final boolean isAudioOnlyCall) {
        VolleyHelper vHelper = new VolleyHelper(getApplicationContext(), isAudioOnlyCall ? URLFactory.getAudioChatURL()
                : URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                try {
                    Intent intent = new Intent(SingleChatActivity.this, OutgoingCallActivity.class);
                    intent.putExtra(CometChatKeys.AVchatKeys.CALLER_ID, String.valueOf(buddyId));
                    intent.putExtra(CometChatKeys.AudiochatKeys.AUDIO_ONLY_CALL, isAudioOnlyCall);
                    startActivity(intent);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {

            }
        });
        vHelper.addNameValuePair(AjaxKeys.TO, buddyId);
        vHelper.addNameValuePair(AjaxKeys.ACTION, StaticMembers.REQUEST);
        vHelper.sendAjax();

    }

    private void setupOneToOneListView() {
        messageList = OneOnOneMessage.getAllMessages(sessionData.getId(), buddyId);
        adapter = new OneToOneMessageAdapter(this, messageList);
        chatListView.setAdapter(adapter);
        chatListView.setSelection(adapter.getCount());
        if (!noCometService && !TextUtils.isEmpty(buddy.cometid) && Integer.parseInt(PreferenceHelper.get(PreferenceKeys.UserKeys.READ_TICK)) == 1) {
            int index = messageList.size();
            if (index != 0) {
                OneOnOneMessage msg = messageList.get(index - 1);
                if (msg != null && msg.self == 0 && msg.messagetick != CometChatKeys.MessageTypeKeys.MESSAGE_READ) {
                    String transport = config.getTRANSPORT();
                    msg.messagetick = CometChatKeys.MessageTypeKeys.MESSAGE_READ;
                    msg.save();
                    if (transport.equals("cometservice")) {
                        CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getReadTickMessage(String.valueOf(msg.remoteId)));
                    } else if (transport.equals("cometservice-selfhosted")) {
                        WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getReadTickMessage(String.valueOf(msg.remoteId)));
                    }

                }
            }
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        menu.add(0, v.getId(), 0, "Copy");
        menu.setHeaderTitle("Select The Action");
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        try {
            OneOnOneMessage message = messageList.get(info.position);
            if (message.type == CometChatKeys.MessageTypeKeys.NORMAL) {
                ClipboardManager clipboard = (ClipboardManager) getSystemService(CLIPBOARD_SERVICE);
                ClipData clip = ClipData.newPlainText("Copied_text", message.message);
                clipboard.setPrimaryClip(clip);
            }
        } catch (Exception e) {
            Logger.error("oncontextitemselected excetion = " + e.getLocalizedMessage());
        }

        return super.onContextItemSelected(item);
    }


    public void sendSticker(String message) {
        try {
            final OneOnOneMessage mess = new OneOnOneMessage(0L, sessionData.getId(), buddyId, message, 0, 1, 1,
                    CometChatKeys.MessageTypeKeys.STICKERS, "", 1, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);

            VolleyHelper helper = new VolleyHelper(this, URLFactory.getSendStickerURL(), new VolleyAjaxCallbacks() {

                @Override
                public void successCallback(String response) {
                    try {
                        JSONObject sendResponse = new JSONObject(response.substring(response.indexOf("{"), response.lastIndexOf("}") + 1));
                        Long id = sendResponse.getLong(AjaxKeys.ID);
                        if (id == -1) {
                            Logger.error("you are banned by other user");
                        } else {
                            mess.remoteId = id;
                            mess.sentTimestamp = System.currentTimeMillis();
                            mess.message = sendResponse.getString("m");
                            addMessage(mess);
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                    if (isNoInternet) {
                        Toast.makeText(
                                getApplicationContext(),
                                (null == lang) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : lang.getMobile()
                                        .get24(), Toast.LENGTH_SHORT).show();
                    }
                }
            });
            helper.addNameValuePair(AjaxKeys.TO, String.valueOf(buddyId));
            helper.addNameValuePair(AjaxKeys.CATEGORY, Stickers.getCategory(message));
            helper.addNameValuePair(AjaxKeys.KEY, message);
            helper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "0");
            helper.addNameValuePair("caller", "");
            helper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("HandlerLeak")
    private void sendMessage() {
        try {
            String message = messageField.getText().toString().trim();
            if (null != message && message.length() > 0) {
                messageField.getText().clear();
                if (noCometService) {
                    resetOneOnOneHeartbeat();
                } else {
                    if (!TextUtils.isEmpty(buddy.cometid)) {
                        if (config.gettypingEnabled() != null && config.gettypingEnabled().equals("1")) {
                            String transport = config.getTRANSPORT();
                            if (transport.equals("cometservice")) {
                                CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getTypingStopMessage());
                            } else if (transport.equals("cometservice-selfhosted")) {
                                WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getTypingStopMessage());
                            }
                        }
                    }
                }
                /* Initialize the message pojo */
                final OneOnOneMessage mess = new OneOnOneMessage(0L, sessionData.getId(), buddyId, message, 0, 1, 1,
                        CometChatKeys.MessageTypeKeys.NORMAL, "", 1, CometChatKeys.MessageTypeKeys.MESSAGE_SENT);

                VolleyHelper helper = new VolleyHelper(this, sendMessageUrl, new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            Logger.error("ressult =" + response);
                            JSONObject sendResponse = new JSONObject(response);
                            Long id = sendResponse.getLong(AjaxKeys.ID);
                            if (id == -1) {
                                Logger.error("you are banned by other user");
                            } else {
                                mess.remoteId = id;
                                /*if (sendResponse.has(AjaxKeys.SENT)) {
                                    mess.sentTimestamp = sendResponse.getLong(AjaxKeys.SENT);
                                } else {*/
                                    mess.sentTimestamp = System.currentTimeMillis();
                                addMessage(mess);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Toast.makeText(
                                    getApplicationContext(),
                                    (null == lang) ? StaticMembers.PLEASE_CHECK_YOUR_INTERNET : lang.getMobile()
                                            .get24(), Toast.LENGTH_SHORT).show();
                        }
                    }
                });
                helper.addNameValuePair(AjaxKeys.MESSAGE, message);
                helper.addNameValuePair(AjaxKeys.TO, String.valueOf(buddyId));
                helper.sendAjax();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void resetOneOnOneHeartbeat() {
        sessionData.setOneOnOneHeartBeatIdealCount(1);
        if (!noCometService) {
            sessionData.setOneOnOneHeartbeatInterval(minHeartbeat);
            HeartbeatOneOnOne.getInstance().changeOneOnOneHeartbeatInverval();
        } else {
            if (sessionData.getOneOnOneHeartbeatInterval() > minHeartbeat) {
                sessionData.setOneOnOneHeartbeatInterval(minHeartbeat);
                HeartbeatOneOnOne.getInstance().changeOneOnOneHeartbeatInverval();
            }
        }
    }

    private void addMessage(OneOnOneMessage message) {
        OneOnOneMessage pojo = OneOnOneMessage.findById(message.remoteId);
        if (null == pojo) {
            message.save();
        }
        adapter.add(message);
        chatListView.setSelection(adapter.getCount() - 1);
        Buddy buddy = Buddy.getBuddyDetails(buddyId);
        buddy.lastUpdated = System.currentTimeMillis();
        buddy.save();
        // messageList.add(message);
    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            registerReceiver(customReceiver, new IntentFilter(NewMessageKeys.EVENT_NEW_MESSAGE_ONE_ON_ONE));
        }

        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, buddyId);

        SessionData session = SessionData.getInstance();
        if (session.isOneToOneBroadCastMissed()) {
            session.setOneToOneBroadCastMissed(false);
            messageList = OneOnOneMessage.getAllMessages(session.getId(), buddyId);
            if (null != adapter && null != chatListView) {
                adapter.clear();
                adapter.addAll(messageList);
                adapter.notifyDataSetChanged();
                chatListView.setSelection(adapter.getCount() - 1);
            }
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        if (customReceiver != null) {
            unregisterReceiver(customReceiver);
        }
        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_VIDEO_URL);
        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_IMAGE_URL);
        PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_AUDIO_URL);
        // PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, "0");
    }

    @Override
    protected void onResume() {
        super.onResume();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, buddyId);
    }

    @Override
    protected void onPause() {
        super.onPause();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, "0");
    }

    @Override
    public void finish() {
        super.finish();
        /* Set current windowid to 0 to allow unreadcount to be updated */
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_BUDDY_ID, "0");
        MediaPlayer player = CommonUtils.getPlayerInstance();
        if (adapter != null) {
            adapter.stopTimer();
        }
        if (player.isPlaying()) {
            player.stop();
            player.release();
        }
        if (!noCometService && config.gettypingEnabled() != null && config.gettypingEnabled().equals("1")) {
            if (!TextUtils.isEmpty(buddy.cometid)) {
                String transport = config.getTRANSPORT();
                if (transport.equals("cometservice")) {
                    CometserviceOneOnOne.sendMessage(buddy.cometid, CommonUtils.getTypingStopMessage());
                } else if (transport.equals("cometservice-selfhosted")) {
                    WebsyncOneOnOne.getInstance().publish(buddy.cometid, CommonUtils.getTypingStopMessage());
                }
            }
        }
        CommonUtils.resetPlayerInstance();
        overridePendingTransition(0, 0);
        smiliKeyBoard.dismissKeyboard();
    }

    @Override
    public void onBackPressed() {
        if (openchatonly) {
            BlankActivity.blankActivity.finish();
            finish();
            overridePendingTransition(0, R.anim.slide_out_down);

        } else {
            Intent intent = new Intent(this, CometChatActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            startActivity(intent);
            super.onBackPressed();
        }
    }

    @Override
    public void getClickedEmoji(int gridviewItemPosition) {
        smiliKeyBoard.getClickedEmoji(gridviewItemPosition);
    }

}
