/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.activities;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.AlertDialog;
import android.content.BroadcastReceiver;
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
import android.text.TextUtils;
import android.text.TextWatcher;
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
import android.widget.GridView;
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
import com.inscripts.adapters.ChatroomMessageAdapter;
import com.inscripts.adapters.SelectColorGridAdapter;
import com.inscripts.cometchat.sdk.AVBroadcast;
import com.inscripts.custom.ConfirmationWindow;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.helpers.PopupHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.EmojiClickInterface;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.StickerClickInterface;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.AjaxKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.ImageSharing;
import com.inscripts.plugins.OtherPlugins;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoChat;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.pojos.ColorPojo;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.utils.SuperActivity;
import com.inscripts.videochat.VideoChatActivity;

import org.json.JSONObject;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Field;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import se.emilsjolander.stickylistheaders.StickyListHeadersListView;

import static com.inscripts.activities.SingleChatActivity.hideSoftKeyboard;


public class ChatroomActivity extends SuperActivity implements OnAlertDialogButtonClickListener, EmojiClickInterface {

    private String message, chatroomName, meText, picassImageName, sendMessageUrl, audioFileNamewithPath, shareImageUri, shareVideoUri, shareAudioUri;
    private long chatroomId;
    private StickyListHeadersListView chatListView;
    private ImageButton sendButton, smilieyButton, voiceNotebtn, stickerButton;
    private EditText messageField;
    private ChatroomMessageAdapter adapter;
    private List<ChatroomMessage> messageList;
    private BroadcastReceiver customReceiver;
    private static Uri fileUri;
    private Intent data;
    private SessionData sessionData;
    private SmileyKeyBoard smiliKeyBoard;
    private final int IMAGE_SEND_PREVIEW_POPUP = 1, VIDEO_SEND_PREVIEW_POPUP = 2, PICASSA_IMAGE_PREVIEW_POPUP = 3, AUDIO_SEND_PREVIEW_POPUP = 4;
    private boolean noCometService, isRecording = false, isVoiceNoteplaying = false;
    private Bitmap picassaBitmap;
    private Lang lang;
    private Config config;
    private Long minHeartbeat;
    //private CustomListView chatContainer;
    private MediaRecorder voiceRecorder;
    private Runnable timerRunnable;
    Handler seekHandler = new Handler();
    private Toolbar toolbar;
    private StickerKeyboard stickerKeyboard;
    private ImageView dirtyView;
    private String primaryColor;
    /** Chat Menu buttons **/
    private ImageButton btnChatMenuMore,btnChatMenuKeyBoard,btnChatMenuSharePhoto,btnChatMenuShareVideo,btnChatMenuBroadcast, btnChatMenuSticker ,expandChatMenuBtn ,cameraButton;
    private LinearLayout bottomSheetCameraLayout;
    private LinearLayout viewShareWiteboard,viewCollaborativeDocument,viewHandwriteMessage,viewCapturePhoto , viewCaptureVideo;;
    private ImageView whiteboardImageView,collaborativeDocumentImageView,HandwriteMessageImageView, capturePhotoImageView , capturevideoImageView;
    private LinearLayout chatMenuLayout;
    private LinearLayout cameraMenuLayout;
    private SelectColorGridAdapter gridAdapter;
    private String selectedColor;
    private ArrayList<ColorPojo> colorList;
    private LinearLayout cameraSheetLayout;
    private LinearLayout bottomSheetlayout;
    private LinearLayout bottomSheetSelectColor;
    private BottomSheetBehavior sheetBehavior;
    private BottomSheetBehavior sheetCameraBehavior;
    private BottomSheetBehavior sheetBehaviorSelectColor;
    private RelativeLayout viewChatMenu;
    private RelativeLayout chatFooter;
    private RelativeLayout chatLayout;

    @TargetApi(Build.VERSION_CODES.JELLY_BEAN)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.cc_chat_activity_cordinate);
        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        setActionBarColor(null);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        sessionData = SessionData.getInstance();
        lang = JsonPhp.getInstance().getLang();
        config = JsonPhp.getInstance().getConfig();
        noCometService = config.getUSECOMET().equals("0");
        if (noCometService) {
            minHeartbeat = Long.parseLong(config.getMinHeartbeat());
        } else {
            minHeartbeat = Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000;
        }

        Intent intent = getIntent();
        if (intent.hasExtra(StaticMembers.INTENT_CHATROOM_ID)) {
            chatroomId = intent.getLongExtra(StaticMembers.INTENT_CHATROOM_ID, 0);
        } else {
            chatroomId = sessionData.getCurrentChatroom();
        }

        if (intent.hasExtra("ImageUri")) {
            shareImageUri = intent.getStringExtra("ImageUri");
            checkUserConfirmation(shareImageUri, false);
        }
        if (intent.hasExtra("VideoUri")) {
            shareVideoUri = intent.getStringExtra("VideoUri");
            checkUserConfirmation(shareVideoUri, true);
        }
        if (intent.hasExtra("AudioUri")) {
            shareAudioUri = intent.getStringExtra("AudioUri");
            Uri uri = Uri.parse(shareAudioUri);
            //String AudioUri = AudioSharing.getRealPathFromURI(this, uri);
            AudioSharing.sendAudio(this, uri, chatroomId, true);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_AUDIO_URL);
        }

        /*chatContainer = (CustomListView) findViewById(R.id.listViewChatMessages);
        String bmString = PreferenceHelper.get(PreferenceKeys.DataKeys.WALLPAPER_FILENAME);
        Logger.error("bmString" + bmString);
        if (bmString == null || bmString.isEmpty() || bmString == "default.png") {
            chatContainer.setBackgroundColor(Color.WHITE);
        } else {
            Bitmap bm = BitmapFactory.decodeFile(bmString);
            BitmapDrawable bitmapDrawable = new BitmapDrawable(bm);
            //bitmapDrawable.setTileModeXY();
            bitmapDrawable.setTileModeXY(Shader.TileMode.CLAMP, Shader.TileMode.CLAMP);
            chatContainer.setBackground(bitmapDrawable);
        }*/

        if (intent.hasExtra(StaticMembers.INTENT_CHATROOM_NAME)) {
            chatroomName = intent.getStringExtra(StaticMembers.INTENT_CHATROOM_NAME);
            if (TextUtils.isEmpty(sessionData.getCurrentChatroomName())) {
                sessionData.setCurrentChatroomName(chatroomName);
            }
        } else {
            chatroomName = sessionData.getCurrentChatroomName();
        }

        chatListView = (StickyListHeadersListView) findViewById(R.id.listViewChatMessages);
        messageField = (EditText) findViewById(R.id.editTextChatMessage);
        sendButton = (ImageButton) findViewById(R.id.buttonSendMessage);
        voiceNotebtn = (ImageButton) findViewById(R.id.buttonSendVoice);
        chatLayout = (RelativeLayout) findViewById(R.id.relativeLayoutChatActivity);
        smilieyButton = (ImageButton) findViewById(R.id.img_btn_smiley);
        smiliKeyBoard = new SmileyKeyBoard();
        smiliKeyBoard.enable(this, this, R.id.footer_for_emoticons, messageField);
        chatFooter = (RelativeLayout) findViewById(R.id.relativeLayoutControlsHolder);
        smiliKeyBoard.checkKeyboardHeight(chatFooter);
        smiliKeyBoard.enableFooterView(messageField);
        viewChatMenu = (RelativeLayout) findViewById(R.id.relativeLayoutMenu1);
        expandChatMenuBtn = (ImageButton) findViewById(R.id.img_btn_chat_more);
        btnChatMenuMore = (ImageButton) findViewById(R.id.btn_chat_menu_more);
        btnChatMenuBroadcast = (ImageButton) findViewById(R.id.btn_chat_menu_broadcast);
        btnChatMenuKeyBoard = (ImageButton) findViewById(R.id.btn_chat_menu_keyboard);
        btnChatMenuSharePhoto = (ImageButton) findViewById(R.id.btn_chat_menu_share_image);
        btnChatMenuShareVideo = (ImageButton) findViewById(R.id.btn_chat_menu_share_video);
        btnChatMenuSticker = (ImageButton) findViewById(R.id.btn_chat_menu_sticker);
        chatLayout = (RelativeLayout) findViewById(R.id.relativeLayoutChatActivity);
        dirtyView = (ImageView) findViewById(R.id.dirty_view);
        bottomSheetlayout = (LinearLayout) findViewById(R.id.bottom_sheet);
        viewHandwriteMessage = (LinearLayout) findViewById(R.id.ll_handwrite_message);
        viewShareWiteboard = (LinearLayout) findViewById(R.id.ll_share_whiteboard);
        viewCollaborativeDocument = (LinearLayout) findViewById(R.id.ll_collaborative_document);
        whiteboardImageView = (ImageView) findViewById(R.id.action_bar_menu_share_whiteboard);
        collaborativeDocumentImageView = (ImageView) findViewById(R.id.action_bar_menu_collaborative_document);
        HandwriteMessageImageView = (ImageView) findViewById(R.id.action_bar_menu_handwrite_message);
        smilieyButton = (ImageButton) findViewById(R.id.img_btn_smiley);
        capturePhotoImageView = (ImageView) findViewById(R.id.camera_menu_capture_photo);
        capturevideoImageView = (ImageView) findViewById(R.id.camera_menu_capture_video);
        viewCapturePhoto = (LinearLayout) findViewById(R.id.ll_capture_photo);
        viewCaptureVideo = (LinearLayout) findViewById(R.id.ll_capture_video);
        chatMenuLayout = (LinearLayout) findViewById(R.id.custom_bottom_sheet_menu);
        cameraMenuLayout = (LinearLayout) findViewById(R.id.custom_bottom_sheet_camera_menu);
        bottomSheetSelectColor = (LinearLayout) findViewById(R.id.bottom_sheet_select_color);
        cameraButton = (ImageButton) findViewById(R.id.img_btn_camera);
        sheetBehavior = BottomSheetBehavior.from(bottomSheetlayout);
        sheetBehaviorSelectColor = BottomSheetBehavior.from(bottomSheetSelectColor);

        cameraSheetLayout = (LinearLayout) findViewById(R.id.bottom_sheet_camera);
        sheetCameraBehavior = BottomSheetBehavior.from(cameraSheetLayout);

        setThemeColor();

        stickerButton = (ImageButton) findViewById(R.id.btn_chat_menu_sticker);
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


        if (null == lang.getMobile().get6()) {
            meText = StaticMembers.ME_TEXT;
        } else {
            meText = lang.getMobile().get6();
        }

        setActionBarTitle(chatroomName);
        setupChatroomListView();
        if (TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE))) {
            voiceNotebtn.setVisibility(View.INVISIBLE);
            sendButton.setVisibility(View.VISIBLE);
        } else if (Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) < 564) {
            voiceNotebtn.setVisibility(View.INVISIBLE);
            sendButton.setVisibility(View.VISIBLE);
        }

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
                    return true;
                }
                return false;
            }
        });

        messageField.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (!TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) && Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) >= 564) {
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

        voiceNotebtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                toggleRecording();
            }
        });

        expandChatMenuBtn.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {

                if(viewChatMenu.getVisibility()==View.VISIBLE){
                    viewChatMenu.setVisibility(View.GONE);
                    expandChatMenuBtn.setRotation(expandChatMenuBtn.getRotation() + 180);
                }else{
                    viewChatMenu.setVisibility(View.VISIBLE);
                    expandChatMenuBtn.setRotation(expandChatMenuBtn.getRotation() + 180);
                }
                //smiliKeyBoard.showKeyboard(chatFooter);

                if(Stickers.isEnabled() && stickerKeyboard!= null && stickerKeyboard.isKeyboardVisibile()){
                    stickerKeyboard.dismissKeyboard();
                }
            }
        });

        cameraButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                dirtyView.setVisibility(View.VISIBLE);
                //sheetCameraBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
               /* chatMenuLayout.setVisibility(View.GONE);
                cameraMenuLayout.setVisibility(View.VISIBLE);*/
                hideSoftKeyboard(ChatroomActivity.this);
                sheetCameraBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
            }
        });

        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                try {
                    SessionData.getInstance().setChatroomBroadcastMissed(false);
                    if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE)) {
                        messageList = ChatroomMessage.getAllMessages(chatroomId);
                        adapter.clear();
                        adapter.addAll(messageList);
                        chatListView.setSelection(adapter.getCount() - 1);
                    } else if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.IMAGE_SENDING)) {
                        /*
                         * ChatroomMessage messagePojo = new ChatroomMessage("",
						 * String.valueOf(SessionData.getInstance() .getId()),
						 * chatroomId,
						 * intent.getStringExtra(CometChatKeys.FileUploadKeys
						 * .FILENAME), System.currentTimeMillis(), meText,
						 * CometChatKeys.MessageTypeKeys.IMAGE, "");
						 * addChatroomMessage(messagePojo);
						 */
                    } else if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.UNSUPPORTED_SMILEY_DOWNLOADED)) {
                        adapter.notifyDataSetChanged();
                        // chatListView.setSelection(adapter.getCount() - 1);
                    } else if (intent.hasExtra(BroadcastReceiverKeys.IntentExtrasKeys.VIDEO_SENDING)) {
                        /*
                         * ChatroomMessage messagePojo = new ChatroomMessage("",
						 * String.valueOf(SessionData.getInstance() .getId()),
						 * chatroomId,
						 * intent.getStringExtra(CometChatKeys.FileUploadKeys
						 * .FILENAME), System.currentTimeMillis(), meText,
						 * CometChatKeys.MessageTypeKeys.VIDEO_UPLOAD, "");
						 * addChatroomMessage(messagePojo);
						 */
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        };

		/* Added to show Option menu on lower versions of android */
        try {
            ViewConfiguration config = ViewConfiguration.get(this);
            Field menuKeyField = ViewConfiguration.class.getDeclaredField(StaticMembers.PERMANENT_MENU_KEY);
            if (menuKeyField != null) {
                menuKeyField.setAccessible(true);
                menuKeyField.setBoolean(config, false);
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }

        Config config = JsonPhp.getInstance().getConfig();

        if (config.getCOMETCHATROOMS() != null && config.getCOMETCHATROOMS().equals("1")) {
            String transport = JsonPhp.getInstance().getConfig().getTRANSPORT();
            if (transport.equals("cometservice")) {
                if (!ChatroomManager.isSubscribedToChatroom(chatroomId)) {
                    CometserviceChatroom.getInstance().startChatroomCometService(chatroomId);
                }
            } else if (transport.equals("cometservice-selfhosted")) {
                if (!ChatroomManager.isSubscribedToChatroom(chatroomId)) {
                    WebsyncChatroom.getInstance().connect(
                            JsonPhp.getInstance().getWebsyncServer(), String.valueOf(chatroomId),
                            sessionData.getChatroomCometId());
                }
            }
        }

        sessionData.setCurrentChatroom(chatroomId);
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, chatroomId);
        sendMessageUrl = URLFactory.getSendChatroomMessageURL();
        setUpColorPicker();
        setUpChatMenu();
    }




    private void setThemeColor(){
        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        //setActionBarColor(primaryColor);
        //setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));
        collaborativeDocumentImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        whiteboardImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        HandwriteMessageImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        capturePhotoImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        capturePhotoImageView.getDrawable().setColorFilter(Color.WHITE, PorterDuff.Mode.SRC_ATOP);
        capturevideoImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        cameraButton.getDrawable().setColorFilter(Color.parseColor("#8e8e92"), PorterDuff.Mode.SRC_ATOP);
    }


    private void setUpColorPicker(){

        Config config = JsonPhp.getInstance().getConfig();

        if (null == config.getCrstyles()) {
            return;
        }
        //Logger.error("color list size  = "+ config.getCrstyles().getTextcolor().size());

        ArrayList textcolorList = config.getCrstyles().getTextcolor();
        colorList = new ArrayList();


        for(Iterator iterator = textcolorList.iterator(); iterator.hasNext();){

            String color = (String) iterator.next();

            if(selectedColor!= null  && selectedColor.equals("#"+color))
                colorList.add(new ColorPojo("#"+color,true));
            else
                colorList.add(new ColorPojo("#"+color,false));
        }

        final GridView gridView = (GridView) findViewById(R.id.select_color_grid_view);
        gridAdapter = new SelectColorGridAdapter(ChatroomActivity.this,colorList);
        gridView.setAdapter(gridAdapter);
        gridView.setOnItemClickListener(new AdapterView.OnItemClickListener() {

            @Override
            public void onItemClick(AdapterView<?> parent, View view,int position, long id) {

                ImageView imageView = (ImageView) view.findViewById(R.id.grid_image);

                Logger.error("Positon = "+position);
                for(int i= 0 ; i<colorList.size(); i++){
                    if(i == position){
                        colorList.get(i).setSelected(true);
                        selectedColor = colorList.get(i).getColor();
                        PreferenceHelper.save(PreferenceKeys.Colors.COLOR_CHATROOM_CHAT,selectedColor);
                        //imageView.setImageDrawable(getResources().getDrawable(R.drawable.ic_check));
                    }
                    else
                        colorList.get(i).setSelected(false);
                }
                sheetBehaviorSelectColor.setState(BottomSheetBehavior.STATE_COLLAPSED);
                gridAdapter.notifyDataSetChanged();
                viewChatMenu.setVisibility(View.VISIBLE);
            }
        });
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

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.cc_chatroom_activity_menu, menu);
        Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);


        if (VideoChat.isCrAudioCallDisabled()) {
            menu.findItem(R.id.custom_action_audio_call).setVisible(false);
        }

        if (VideoChat.isConferenceDisabled()) {
            menu.findItem(R.id.custom_action_video_call).setVisible(false);
        }

        /*if (ImageSharing.isCrDisabled()) {
            menu.findItem(R.id.custom_action_image_upload_chatroom).setVisible(false);
            menu.findItem(R.id.custom_action_captured_image_upload_chatroom).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_image_upload_chatroom).setTitle(lang.getCore().get66());
            menu.findItem(R.id.custom_action_captured_image_upload_chatroom).setTitle(lang.getCore().get67());
        }

        if (ClearConversation.isCrDisabled()) {
            menu.findItem(R.id.custom_action_clear_conversation).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_clear_conversation).setTitle(lang.getCore().get64());
        }*/

       /* menu.findItem(R.id.custom_action_invite_users).setTitle(lang.getCore().get71());
        menu.findItem(R.id.custom_action_leave_chatroom).setTitle(lang.getCore().get70());*/

        /*if (VideoSharing.isCrDisabled()) {
            menu.findItem(R.id.custom_action_video_upload_chatroom).setVisible(false);
            menu.findItem(R.id.custom_action_video_capture_chatroom).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_video_upload_chatroom).setTitle(lang.getCore().get68());
            menu.findItem(R.id.custom_action_video_capture_chatroom).setTitle(lang.getCore().get69());
        }
        if (null != lang.getMobile().get90()) {
            menu.findItem(R.id.custom_action_view_chatroom_users).setTitle(lang.getMobile().get90());
        }

        if (VideoChat.isConferenceDisabled()) {
            menu.findItem(R.id.custom_action_video_call).setVisible(false);
        }
        if (VideoChat.isCrAudioCallDisabled()) {
            menu.findItem(R.id.custom_action_audio_call).setVisible(false);
        }

        if (AVBroadcast.isCrEnabled()) {
            if (null != lang.getMobile().get163()) {
                menu.findItem(R.id.custom_action_video_broadcast_chatroom).setTitle(lang.getMobile().get163());
            }
        } else {
            menu.findItem(R.id.custom_action_video_broadcast_chatroom).setVisible(false);
        }

        if (OtherPlugins.isCrWhiteBoarddisabled()) {
            menu.findItem(R.id.custom_action_start_whiteboard).setVisible(false);
        }
        if (OtherPlugins.iscrHandwriteDisabled()) {
            menu.findItem(R.id.custom_action_start_handwrite).setVisible(false);
        } else {
            if (lang.getHandwrite() != null) {
                menu.findItem(R.id.custom_action_start_handwrite).setTitle(lang.getHandwrite().get0());
            }
        }

        if (OtherPlugins.isCrWriteBoarddisabled()) {
            menu.findItem(R.id.custom_action_start_writeboard_chatroom).setVisible(false);
        } else {
            menu.findItem(R.id.custom_action_start_writeboard_chatroom).setVisible(true);
            if (lang.getWriteboard() != null) {
                menu.findItem(R.id.custom_action_start_writeboard_chatroom).setTitle(lang.getWriteboard().get7());
            }
        }

        if (versionnumber >= 600 && ((null != chatroom && chatroom.createdBy == 1) ||
                (null != SessionData.getInstance().getIsModerator() && SessionData.getInstance().getIsModerator().equals("1")))) {
            menu.findItem(R.id.custom_action_unban_users).setTitle(lang.getChatrooms().get68());
            menu.findItem(R.id.custom_action_unban_users).setVisible(true);
        } else {
            menu.findItem(R.id.custom_action_unban_users).setVisible(false);
        }*/
        return super.onCreateOptionsMenu(menu);
    }


    @Override
    public boolean onOptionsItemSelected(MenuItem item) {

        int i = item.getItemId();
        if (i == R.id.custom_action_more) {
            final View menuItemView = findViewById(R.id.custom_action_more);
            sheetBehaviorSelectColor.setState(BottomSheetBehavior.STATE_COLLAPSED);
            showCustomActionBarPopup(menuItemView);

        } else if (i == android.R.id.home) {
            finish();

        } else if (i == R.id.custom_action_video_call) {
            if (CommonUtils.isConnected()) {
                if (Build.VERSION.SDK_INT >= 16) {
                    if(isCameraPermissionGranted()){
                        showCallPopup(false);
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
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
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    Toast.makeText(this, lang.getAvchat().get42(), Toast.LENGTH_LONG).show();
                }
            } else {
                Toast.makeText(this, lang.getMobile().get24(), Toast.LENGTH_LONG).show();
            }




          /*  case R.id.custom_action_clear_conversation:
                ChatroomMessage.clearConversation(chatroomId);
                messageList.clear();
                adapter.clear();
                adapter.notifyDataSetChanged();
                break;
            case R.id.custom_action_leave_chatroom:
                ChatroomManager.leaveChatroom(chatroomId, "0");
                finish();
                break;
            case R.id.custom_action_start_handwrite:
                startHandwrite();
                break;
            case R.id.custom_action_invite_users:
                inviteUsers();
                break;
            case R.id.custom_action_image_upload_chatroom:
                imageUpload();
                break;
            case R.id.custom_action_captured_image_upload_chatroom:
                capturePhoto();
                break;
            case R.id.custom_action_video_upload_chatroom:
                videoUpload();
                break;
            case R.id.custom_action_video_capture_chatroom:
                videoCapture();
                break;

            case R.id.custom_action_view_chatroom_users:
                viewChatroomUsers();
                break;
            case R.id.custom_action_video_broadcast_chatroom:
                startbroadcast();
                break;

            case R.id.custom_action_start_whiteboard:
                startWhiteBoard();
                break;
            case R.id.custom_action_start_writeboard_chatroom:
                startWriteBoard();
                break;
            case R.id.custom_action_unban_users:
                Intent i = new Intent(ChatroomActivity.this, UnbanChatroomUserActivity.class);
                i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.CHATROOM_ID, chatroomId);
                startActivity(i);
                break;*/
        } else {
        }
        return super.onOptionsItemSelected(item);
    }

    private void showCustomActionBarPopup(View view) {
        hideSoftKeyboard(ChatroomActivity.this);
        final PopupWindow showPopup = PopupHelper.newBasicPopupWindow(getApplicationContext());
        LayoutInflater inflater = (LayoutInflater)getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View popupView = inflater.inflate(R.layout.cc_custom_chat_room_action_bar_menu, null);
        showPopup.setContentView(popupView);

        LinearLayout viewMember = (LinearLayout) popupView.findViewById(R.id.ll_view_member);
        LinearLayout clearConversation = (LinearLayout) popupView.findViewById(R.id.ll_chatroom_clear_conversation);
        LinearLayout inviteUser = (LinearLayout) popupView.findViewById(R.id.ll_invite_user);
        LinearLayout leaveChatroom = (LinearLayout) popupView.findViewById(R.id.ll_leave_chatroom);
        LinearLayout pickColor = (LinearLayout) popupView.findViewById(R.id.ll_pick_color);


        ImageView viewProfileImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_view_profile);
        ImageView clearConversationImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_clear_conversation);
        ImageView inviteUsersImageView = (ImageView) popupView.findViewById(R.id.image_view_menu_invite_users);
        ImageView blockUserImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_leave_chatroom);
        ImageView pickcolorImageView = (ImageView) popupView.findViewById(R.id.action_bar_menu_pick_color);

        String primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
        viewProfileImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        clearConversationImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        inviteUsersImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        blockUserImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);
        pickcolorImageView.getBackground().setColorFilter(Color.parseColor(primaryColor), PorterDuff.Mode.SRC_ATOP);


        TextView tvViewMenber = (TextView) popupView.findViewById(R.id.textViewMember);
        TextView tvClearConversation = (TextView) popupView.findViewById(R.id.textClearConversation);
        TextView tvInviteUser = (TextView) popupView.findViewById(R.id.textInviteUsers);
        TextView tvLeaveChatroom = (TextView) popupView.findViewById(R.id.textLeaveChatroom);

        if (null != lang.getChatrooms().getViewUsers()) {
            tvViewMenber.setText(lang.getChatrooms().getViewUsers());
        }

        if (null != lang.getCore().get64()) {
            tvClearConversation.setText(lang.getCore().get64());
        }

        if (null != lang.getCore().get71()) {
            tvInviteUser.setText(lang.getCore().get71());
        }

        if (null != lang.getCore().get70()) {
            tvLeaveChatroom.setText(lang.getCore().get70());
        }

        viewMember.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                viewChatroomUsers();
            }
        });

        clearConversation.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                ChatroomMessage.clearConversation(chatroomId);
                messageList.clear();
                adapter.clear();
                adapter.notifyDataSetChanged();
            }
        });

        inviteUser.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                inviteUsers();
            }
        });

        leaveChatroom.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                showPopup.dismiss();
                ChatroomManager.leaveChatroom(chatroomId, "0");
                finish();
            }
        });

        pickColor.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                showPopup.dismiss();

                dirtyView.setVisibility(View.VISIBLE);
                sheetBehaviorSelectColor.setState(BottomSheetBehavior.STATE_EXPANDED);
                if(selectedColor != null)
                    gridAdapter.notifyDataSetChanged();
            }
        });

        showPopup.setWidth(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setHeight(Toolbar.LayoutParams.WRAP_CONTENT);
        showPopup.setAnimationStyle(R.style.Animations_GrowFromTop);
        showPopup.showAsDropDown(view);
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
                cWindow.setMessage((lang.getAudiochat() == null) ? "Call " + chatroomName : lang.getAudiochat().get28() + " " + chatroomName + "?");
            } else {
                cWindow.setMessage((lang.getAvchat() == null) ? "Call " + chatroomName : lang.getAvchat().get28() + " " + chatroomName + " ?");
            }

            cWindow.show();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("HandlerLeak")
    private void initiateCall(final boolean isAudioOnlyCall) {

        final String chatroomid = PreferenceHelper.get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
        if (!TextUtils.isEmpty(chatroomid)) {
            VolleyHelper vhelper = new VolleyHelper(getApplicationContext(), URLFactory.getAVChatURL(), new VolleyAjaxCallbacks() {
                @Override
                public void successCallback(String response) {
                    String roomid = VideoChat.setAVConferenceRoomName(response);
                    if (roomid.equals("")) {
                        //show error
                    } else {
                        VideoChat.startConference(roomid, ChatroomActivity.this);
                    }
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                }
            });
            vhelper.addNameValuePair(AjaxKeys.TO, chatroomid);
            vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
            vhelper.addNameValuePair(AjaxKeys.ACTION, StaticMembers.REQUEST);
            vhelper.sendAjax();
        }
    }

    private void viewChatroomUsers() {
        Intent intent = new Intent(this, ShowChatroomUsersActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
        startActivity(intent);
    }

    private void videoCapture() {
        Intent intent = new Intent(MediaStore.ACTION_VIDEO_CAPTURE);
        if (!CommonUtils.isSamsungWithApi16()) {
            fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_VIDEO, false);
            intent.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
        }

        intent.putExtra(MediaStore.EXTRA_VIDEO_QUALITY, 0);
        intent.putExtra(MediaStore.EXTRA_SIZE_LIMIT, LocalConfig.getFileUploadLimit());
        startActivityForResult(intent, StaticMembers.CAPTURE_VIDEO_REQUEST_CHATROOM);
    }

    private void videoUpload() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        intent.setType(StaticMembers.VIDEO_TYPE);
        startActivityForResult(intent, StaticMembers.CHOOSE_VIDEO_REQUEST_CHATROOM);
    }

    private void capturePhoto() {
        Intent intent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
        fileUri = ImageSharing.getOutputMediaFileUri(StaticMembers.MEDIA_TYPE_IMAGE, true);
        intent.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
        startActivityForResult(intent, StaticMembers.CAPTURE_PHOTO_REQUEST_CHATROOM);
    }

    private void imageUpload() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
        intent.setType(StaticMembers.IMAGE_TYPE);
        startActivityForResult(intent, StaticMembers.CHOOSE_IMAGE_REQUEST_CHATROOM);
    }

    private void inviteUsers() {
        Intent intent = new Intent(ChatroomActivity.this, InviteUserActivity.class);
        intent.putExtra(StaticMembers.INTENT_CHATROOM_ID, chatroomId);
        intent.putExtra(StaticMembers.INTENT_CHATROOM_NAME, chatroomName);
        intent.addFlags(Intent.FLAG_ACTIVITY_NO_ANIMATION);
        startActivity(intent);
    }

    private void setUpChatMenu(){
        if (ImageSharing.isCrDisabled()) {
            btnChatMenuSharePhoto.setVisibility(View.GONE);
            viewCapturePhoto.setVisibility(View.GONE);
        }else{
            if(lang.getCore().get67() != null){
                TextView tvCapturePhoto = (TextView)viewCapturePhoto.findViewById(R.id.textCapturePhoto);
                tvCapturePhoto.setText(lang.getCore().get67());
            }
            viewCapturePhoto.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    //sheetCameraBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    if(isCameraPermissionGranted()){
                        capturePhoto();
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });

            btnChatMenuSharePhoto.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isStoragePermissionGranted()){
                        imageUpload();
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }

                }
            });

        }



        if (VideoSharing.isCrDisabled()) {
            btnChatMenuShareVideo.setVisibility(View.GONE);
            viewCaptureVideo.setVisibility(View.GONE);
        }else{
            btnChatMenuShareVideo.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isStoragePermissionGranted()){
                        videoUpload();
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
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
                    //sheetCameraBehavior.setState(BottomSheetBehavior.STATE_COLLAPSED);
                    if(isCameraPermissionGranted()){
                        videoCapture();
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }

                }
            });

        }

        if(ImageSharing.isCrDisabled() && VideoSharing.isCrDisabled()){
            cameraButton.setVisibility(View.GONE);
        }

        if (!AVBroadcast.isCrEnabled()) {
            btnChatMenuBroadcast.setVisibility(View.GONE);
        }else{
            btnChatMenuBroadcast.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    if(isCameraPermissionGranted()){
                        startbroadcast();
                    }else{
                        Toast.makeText(ChatroomActivity.this, "Permission Not Available", Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }

        if (OtherPlugins.isCrWhiteBoarddisabled()) {
            viewShareWiteboard.setVisibility(View.GONE);
        }else{
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

        if (OtherPlugins.isCrWriteBoarddisabled()) {
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

        if (OtherPlugins.iscrHandwriteDisabled()) {
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

        if(OtherPlugins.isCrWhiteBoarddisabled() && OtherPlugins.iscrHandwriteDisabled() && OtherPlugins.iscrHandwriteDisabled()){
            btnChatMenuMore.setVisibility(View.INVISIBLE);
        }else {
            btnChatMenuMore.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {
                    chatMenuLayout.setVisibility(View.VISIBLE);
                 /*   cameraMenuLayout.setVisibility(View.GONE);
                    dirtyView.setVisibility(View.VISIBLE);*/
                    sheetBehavior.setState(BottomSheetBehavior.STATE_EXPANDED);
                }
            });
        }


        if(ImageSharing.isCrDisabled() && VideoSharing.isCrDisabled() && !AVBroadcast.isCrEnabled() && OtherPlugins.iscrHandwriteDisabled() && OtherPlugins.isCrWhiteBoarddisabled() && OtherPlugins.isCrWhiteBoarddisabled() && OtherPlugins.iscrHandwriteDisabled()){
            expandChatMenuBtn.setVisibility(View.GONE);
        }else{
            btnChatMenuKeyBoard.setOnClickListener(new OnClickListener() {
                @Override
                public void onClick(View view) {



                    InputMethodManager inputMethodManager=(InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
               /* inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);*/

                    if(Stickers.isEnabled() && stickerKeyboard.isKeyboardVisibile()){
                        stickerKeyboard.showKeyboard(chatFooter);

                        if(!inputMethodManager.isActive()){
                            inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);
                        }

                    }else {
                        inputMethodManager.toggleSoftInputFromWindow(chatLayout.getApplicationWindowToken(), InputMethodManager.SHOW_FORCED, 0);
                    }
                }
            });
        }


        smilieyButton.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                smiliKeyBoard.showKeyboard(chatFooter);

                if(SmileyKeyBoard.isKeyboardVisibile()){
                    btnChatMenuKeyBoard.setEnabled(false);
                }else{
                    btnChatMenuKeyBoard.setEnabled(true);
                }
            }
        });

        btnChatMenuSticker.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                stickerKeyboard.showKeyboard(chatFooter);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            if (resultCode == RESULT_OK) {
                switch (requestCode) {
                    case StaticMembers.CHOOSE_IMAGE_REQUEST_CHATROOM:
                        checkUserConfirmation(data, false);
                        break;
                    case StaticMembers.CAPTURE_PHOTO_REQUEST_CHATROOM:
                        new ImageSharing().sendImageChatroom(this, fileUri, chatroomId);
                        break;
                    case StaticMembers.CHOOSE_VIDEO_REQUEST_CHATROOM:
                        checkUserConfirmation(data, true);
                        break;
                    case StaticMembers.CAPTURE_VIDEO_REQUEST_CHATROOM:
                        if (CommonUtils.isSamsungWithApi16()) {
                            VideoSharing.sendVideoChatroom(this, data, chatroomId);
                        } else {
                            VideoSharing.sendVideoChatroom(this, new File(new URI(fileUri.toString())).getAbsolutePath(),
                                    chatroomId);
                        }
                        break;
                    default:
                        break;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }



    private void startWhiteBoard() {
        VolleyHelper vhelper = new VolleyHelper(this, URLFactory.getWhiteBoardURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                try {
                    JSONObject details = new JSONObject(response);
                    if (details.has("room")) {
                        Intent i = new Intent(getApplicationContext(), WhiteboardActivity.class);
                        i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.ROOM_NAME, details.getString("room"));
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
        vhelper.addNameValuePair(AjaxKeys.ID, chatroomId);
        vhelper.addNameValuePair(AjaxKeys.SUBACTION, "request");
        vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
        vhelper.sendCallBack(false);
        vhelper.addNameValuePair(AjaxKeys.RANDOM, System.currentTimeMillis());
        vhelper.sendAjax();
    }

    private void startHandwrite() {
        Intent i = new Intent(getApplicationContext(), HandwriteActivity.class);
        i.putExtra(AjaxKeys.SENDERNAME, chatroomName);
        i.putExtra(AjaxKeys.BASE_DATA, PreferenceHelper.get(PreferenceKeys.DataKeys.BASE_DATA));
        i.putExtra("ischatroom", "1");
        i.putExtra(AjaxKeys.ID, chatroomId);
        startActivity(i);
    }


    private void startbroadcast() {
        VolleyHelper vhelper = new VolleyHelper(getApplicationContext(), URLFactory.getCRAVBroadcastRequestURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                if (response.contains("jqcc") && response.contains("(")) {
                    String data[] = response.split("\\(");
                    String roomName = data[1].substring(0, data[1].length() - 1);
                    Intent intent = new Intent(ChatroomActivity.this, VideoChatActivity.class);
                    intent.putExtra(StaticMembers.INTENT_ROOM_NAME, roomName);
                    intent.putExtra(StaticMembers.INTENT_AVBROADCAST_FLAG, true);
                    intent.putExtra(StaticMembers.INTENT_IAMBROADCASTER_FLAG, true);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, String.valueOf(chatroomId));
                    intent.putExtra(StaticMembers.CHATROOMMODE, true);
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
        vhelper.addNameValuePair(CometChatKeys.AVchatKeys.GRP, chatroomId);
        vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
        vhelper.sendAjax();
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
            if (checkSelfPermission(android.Manifest.permission.RECORD_AUDIO)
                    == PackageManager.PERMISSION_GRANTED) {
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

    private void startWriteBoard() {
        final String randomId = String.valueOf(System.currentTimeMillis());
        VolleyHelper vhelper = new VolleyHelper(this, URLFactory.getCrWriteBoardURL(), new VolleyAjaxCallbacks() {
            @Override
            public void successCallback(String response) {
                Intent intent = new Intent(getApplicationContext(), WriteBoardActivity.class);
                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.RANDOMID, randomId);
                startActivity(intent);
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
            }
        });

        vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
        vhelper.addNameValuePair(CometChatKeys.ChatroomKeys.ROOMID, chatroomId);
        vhelper.addNameValuePair(AjaxKeys.ID, randomId);
        vhelper.sendCallBack(false);
        vhelper.sendAjax();
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
            String sendDialogButton = lang.getMobile().get28();
            String cancelDialogButton = lang.getChatrooms().get51();

            if (isVideo) {
                Bitmap bitmap;
                if (CommonUtils.isSamsung()) {
                    bitmap = MediaStore.Video.Thumbnails.getThumbnail(getContentResolver(),
                            Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Video.Thumbnails.MINI_KIND,
                            null);
                } else if (CommonUtils.isXiaomi()) {
                    try {
                        bitmap = MediaStore.Video.Thumbnails.getThumbnail(getContentResolver(),
                                Long.parseLong(selectedImageUri.getLastPathSegment()), MediaStore.Video.Thumbnails.MINI_KIND,
                                null);

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
                                null);
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
                                    new CustomAlertDialogHelper(this, "Confirm sending", dialogview, sendDialogButton,
                                            "", cancelDialogButton, this, PICASSA_IMAGE_PREVIEW_POPUP);
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
    public void onButtonClick(AlertDialog alertDialog, View v, int which, int popupId) {
        switch (popupId) {
            case IMAGE_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (data != null) {
                        new ImageSharing().sendImageChatroom(this, data, chatroomId);
                    } else {
                        try {
                            Intent dataImage = null;
                            dataImage = Intent.getIntent(PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL));
                            new ImageSharing().sendImageChatroom(this, dataImage, chatroomId);
                        } catch (URISyntaxException e) {
                            e.printStackTrace();
                        }
                    }
                }
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_IMAGE_URL);
                alertDialog.dismiss();
                data = null;
                break;
            case PICASSA_IMAGE_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (null != picassaBitmap) {
                        new ImageSharing().sendImageChatroom(this, picassImageName, picassaBitmap, chatroomId);
                    }
                }
                alertDialog.dismiss();
                break;
            case VIDEO_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    if (data != null) {
                        VideoSharing.sendVideoChatroom(this, data, chatroomId);
                    } else {
                        try {
                            Intent dataVideo = null;
                            dataVideo = Intent.getIntent(PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL));
                            VideoSharing.sendVideoChatroom(this, dataVideo, chatroomId);
                        } catch (URISyntaxException e) {
                            e.printStackTrace();
                        }
                    }
                }
                alertDialog.dismiss();
                PreferenceHelper.removeKey(PreferenceKeys.DataKeys.SHARE_VIDEO_URL);
                data = null;
                break;
            case AUDIO_SEND_PREVIEW_POPUP:
                if (which == DialogInterface.BUTTON_POSITIVE) {
                    AudioSharing.sendAudio(this, audioFileNamewithPath, chatroomId, true);
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

    private void setupChatroomListView() {
        messageList = ChatroomMessage.getAllMessages(chatroomId);
        adapter = new ChatroomMessageAdapter(this, messageList);
        chatListView.setAdapter(adapter);
        chatListView.setSelection(adapter.getCount() - 1);
    }

    public void sendSticker(String message) {
        try {
            final ChatroomMessage mess = new ChatroomMessage(0, sessionData.getId(), chatroomId, message,
                    System.currentTimeMillis(), meText, CometChatKeys.MessageTypeKeys.STICKERS, "",
                    StaticMembers.MY_DEFAULT_TEXT_COLOR, 1);

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
                            addChatroomMessage(mess);
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
            helper.addNameValuePair(AjaxKeys.TO, String.valueOf(chatroomId));
            helper.addNameValuePair(AjaxKeys.CATEGORY, Stickers.getCategory(message));
            helper.addNameValuePair(AjaxKeys.KEY, message);
            helper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
            helper.addNameValuePair("caller", "");
            helper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @SuppressLint("HandlerLeak")
    private void sendMessage() {
        try {
            message = messageField.getText().toString().trim();

            if (null != message && message.length() > 0) {
                if (noCometService) {
                    resetChatroomHeartbeat();
                }
                messageField.setText("");

                if(selectedColor == null)
                    selectedColor = StaticMembers.MY_DEFAULT_TEXT_COLOR;

                final ChatroomMessage messagePojo = new ChatroomMessage(0, sessionData.getId(), chatroomId, message,
                        System.currentTimeMillis(), meText, CometChatKeys.MessageTypeKeys.NORMAL, "",
                        selectedColor, 1);
                // addChatroomMessage(messagePojo);

                VolleyHelper volleyHelper = new VolleyHelper(this, sendMessageUrl, new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            JSONObject sendResponse = new JSONObject(response);
                            //Logger.error("send message respose = " + response);
                            messagePojo.remoteId = sendResponse.getLong(CometChatKeys.AjaxKeys.ID);
                            messagePojo.sentTimestamp = System.currentTimeMillis();
                            addChatroomMessage(messagePojo);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Toast.makeText(getApplicationContext(), lang.getMobile().get24(), Toast.LENGTH_SHORT)
                                    .show();
                        }
                    }
                });
                volleyHelper.addNameValuePair(CometChatKeys.AjaxKeys.MESSAGE, message);
                if(selectedColor != null){
                    volleyHelper.addNameValuePair("cookie_"+JsonPhp.getInstance().getCookieprefix()+"chatroomcolor",selectedColor.replace("#",""));
                }
                volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, String.valueOf(chatroomId));
                volleyHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_NAME, chatroomName);
                volleyHelper.sendAjax();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void resetChatroomHeartbeat() {
        sessionData.setChatroomHeartbeatIdealCount(1);
        if (!noCometService) {
            sessionData.setChatroomHeartbeatInterval(minHeartbeat);
            HeartbeatChatroom.getInstance().changeChatroomHeartbeatInverval();
        } else {
            if (sessionData.getChatroomHeartbeatInterval() > minHeartbeat) {
                sessionData.setChatroomHeartbeatInterval(minHeartbeat);
                HeartbeatChatroom.getInstance().changeChatroomHeartbeatInverval();
            }
        }
    }

    private void addChatroomMessage(ChatroomMessage message) {
        ChatroomMessage pojo = ChatroomMessage.findById(message.remoteId);
        if (pojo == null) {
            message.save();
        }
        adapter.add(message);
        chatListView.setSelection(adapter.getCount() - 1);
    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            registerReceiver(customReceiver, new IntentFilter(
                    BroadcastReceiverKeys.NewMessageKeys.EVENT_NEW_MESSAGE_CHATROOM));
        }

        SessionData session = SessionData.getInstance();
        if (session.isChatroomBroadcastMissed()) {
            session.setChatroomBroadcastMissed(false);
            if (null != adapter && null != chatListView) {
                messageList = ChatroomMessage.getAllMessages(chatroomId);
                adapter.clear();
                adapter.addAll(messageList);
            }
        }
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, chatroomId);
    }

    @Override
    public void onStop() {
        super.onStop();
        if (customReceiver != null) {
            unregisterReceiver(customReceiver);
        }
        // PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID,
        // "0");
    }

    @Override
    protected void onResume() {
        super.onResume();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, chatroomId);
    }

    @Override
    protected void onPause() {
        super.onPause();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
    }

    @Override
    public void finish() {
        super.finish();
        //smiliKeyBoard.dismissKeyboard();
        PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
        MediaPlayer player = CommonUtils.getPlayerInstance();
        if (adapter != null) {
            adapter.stopTimer();
        }
        if (player.isPlaying()) {
            player.stop();
            player.release();
        }
        overridePendingTransition(0, 0);
        CommonUtils.resetPlayerInstance();
    }

    @Override
    public void onBackPressed() {
        Intent intent = new Intent(this, CometChatActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        startActivity(intent);
        super.onBackPressed();
    }

    @Override
    public void getClickedEmoji(int gridviewItemPosition) {
        smiliKeyBoard.getClickedEmoji(gridviewItemPosition);
    }
}
