package inscripts.com.librarytestapp;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.Toast;

import com.inscripts.Keyboards.SmileyKeyBoard;
import com.inscripts.Keyboards.StickerKeyboard;
import com.inscripts.cometchat.sdk.CometChatroom;
import com.inscripts.cometchat.sdk.GroupAVChat;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.interfaces.EmojiClickInterface;
import com.inscripts.interfaces.StickerClickInterface;
import com.inscripts.utils.Logger;

import org.json.JSONObject;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URI;
import java.util.ArrayList;

import adapter.ChatroomChatAdapter;
import helper.DatabaseHandler;
import helper.Keys.SharedPreferenceKeys;
import helper.SharedPreferenceHelper;
import helper.Utils;
import pojo.ChatroomChatMessage;

public class ChatroomChatActivity extends ActionBarActivity implements EmojiClickInterface {

    private String chatroomName, chatroomId;
    private EditText messageField;
    private Button sendbtn;
    private CometChatroom cometChatroom;
    private ArrayList<ChatroomChatMessage> messageList;
    private ChatroomChatAdapter adapter;
    private ListView chatListView;
    private BroadcastReceiver customReceiver;
    private static Uri fileUri;
    private SmileyKeyBoard smiliKeyBoard;
    private ImageButton smilieyButton, stickerButton;
    private StickerKeyboard stickerKeyboard;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.sample_activity_chat);
        Intent intent = getIntent();

        if (intent.hasExtra("cName")) {
            chatroomName = intent.getStringExtra("cName");
        }
        if (intent.hasExtra("chatroomid")) {
            chatroomId = intent.getStringExtra("chatroomid");
        }

        getSupportActionBar().setTitle(chatroomName);

        messageField = (EditText) findViewById(R.id.editTextChatMessage);
        sendbtn = (Button) findViewById(R.id.buttonSendMessage);
        cometChatroom = CometChatroom.getInstance(getApplicationContext());

        chatListView = (ListView) findViewById(R.id.listViewChatMessages);
        messageList = new ArrayList<>();
        DatabaseHandler helper = new DatabaseHandler(this);
        messageList = helper.getAllChatroomMessage(
                Long.parseLong(SharedPreferenceHelper.get(SharedPreferenceKeys.myId)), Long.parseLong(chatroomId));
        adapter = new ChatroomChatAdapter(this, messageList);
        chatListView.setAdapter(adapter);

        smilieyButton = (ImageButton) findViewById(R.id.buttonSendSmiley);
        stickerButton = (ImageButton) findViewById(R.id.buttonSendSticker);
        smiliKeyBoard = new SmileyKeyBoard();
        smiliKeyBoard.enable(this, this, R.id.footer_for_emoticons, messageField);
        final RelativeLayout chatFooter = (RelativeLayout) findViewById(R.id.relativeBottomArea);
        smiliKeyBoard.checkKeyboardHeight(chatFooter);
        smiliKeyBoard.enableFooterView(messageField);

        stickerKeyboard = new StickerKeyboard();
        stickerKeyboard.enable(this, new StickerClickInterface() {
            @Override
            public void getClickedSticker(int gridviewItemPosition) {
                final String data = stickerKeyboard.getClickedSticker(gridviewItemPosition);
                cometChatroom.sendSticker(data, new Callbacks() {

                    @Override
                    public void successCallback(JSONObject response) {
                        try {
                            ChatroomChatMessage newmessage = new ChatroomChatMessage(response.getString("id"), data,
                                    Utils.convertTimestampToDate(System.currentTimeMillis()), "Me :", true, "18",
                                    SharedPreferenceHelper.get(SharedPreferenceKeys.myId), chatroomId);
                            DatabaseHandler helper = new DatabaseHandler(getApplicationContext());
                            helper.insertChatroomMessage(newmessage);
                            addMessage(newmessage);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback(JSONObject response) {

                    }
                });
            }
        }, R.id.footer_for_emoticons, messageField);
        stickerKeyboard.checkKeyboardHeight(chatFooter);
        //StickerKeyboard.setStickerSize(400);
        stickerKeyboard.enableFooterView(messageField);

        sendbtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                sendMessage();
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

        customReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(Context context, Intent intent) {
                if (intent.hasExtra("Newmessage")) {
                    String message = intent.getStringExtra("Message");
                    String userName = intent.getStringExtra("from") + " :";
                    String messageId = intent.getStringExtra("message_id");
                    String time = Utils.convertTimestampToDate(Utils.correctTimestamp(Long.parseLong(intent
                            .getStringExtra("time"))));
                    String from = intent.getStringExtra("fromid");
                    String to;
                    String messagetype = intent.getStringExtra("message_type");

                    if (intent.hasExtra("to")) {
                        to = intent.getStringExtra("to");
                    } else {
                        to = SharedPreferenceHelper.get(SharedPreferenceKeys.myId);
                    }
                    boolean ismyMessage = intent.getBooleanExtra("selfmessage", false);
                    ChatroomChatMessage newmessage;
                    if (intent.hasExtra("imageMessage")) {
                        if (intent.hasExtra("myphoto")) {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, true,
                                    messagetype, from, to);
                        } else {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, false,
                                    messagetype, from, to);
                        }
                    } else if (intent.hasExtra("videoMessage")) {
                        if (intent.hasExtra("myvideo")) {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, true,
                                    messagetype, from, to);
                        } else {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, false,
                                    messagetype, from, to);
                        }
                    } else {
                        if (ismyMessage) {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, true,
                                    messagetype, from, to);
                        } else {
                            newmessage = new ChatroomChatMessage(messageId, message, time, userName, false,
                                    messagetype, from, to);
                        }
                    }
                    addMessage(newmessage);
                }
            }

        };
    }

    @Override
    public void getClickedEmoji(int gridviewItemPosition) {
        smiliKeyBoard.getClickedEmoji(gridviewItemPosition);
    }

    private void sendMessage() {
        final String message = messageField.getText().toString().trim();
        if (!TextUtils.isEmpty(message)) {
            messageField.setText("");
            /*
			 * Send message to active chatroom.
			 */
            cometChatroom.sendMessage(chatroomId,message, new Callbacks() {

                @Override
                public void successCallback(JSONObject response) {
                    try {
                        ChatroomChatMessage newmessage = new ChatroomChatMessage(response.getString("id"), message,
                                Utils.convertTimestampToDate(System.currentTimeMillis()), "Me :", true, "10",
                                SharedPreferenceHelper.get(SharedPreferenceKeys.myId), chatroomId);
                        DatabaseHandler helper = new DatabaseHandler(getApplicationContext());
                        helper.insertChatroomMessage(newmessage);
                        addMessage(newmessage);

                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }

                @Override
                public void failCallback(JSONObject response) {
                    Logger.debug("send message fail = " + response);
                }
            });
        }
    }

    private void addMessage(ChatroomChatMessage newmessage) {
        if (newmessage != null) {
            boolean duplicate = false;
            for (ChatroomChatMessage msg : messageList) {
                if (msg != null) {
                    if (msg.getMessage_id().equals(newmessage.getMessage_id())) {
                        duplicate = true;
                        break;
                    }
                }
            }
            if (!duplicate) {
                messageList.add(newmessage);
                adapter.notifyDataSetChanged();
                chatListView.setSelection(messageList.size() - 1);
            }
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.chatroom_chat, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        switch (id) {
            case R.id.action_call_cruser:
                GroupAVChat grpavchat = GroupAVChat.getGroupChatInstance(this);
                grpavchat.sendConferenceRequest(new Callbacks() {

                    @Override
                    public void successCallback(JSONObject response) {
                        Intent intent = new Intent(getApplicationContext(), AVChatActivity.class);
                        intent.putExtra("isChatroom", "1");
                        startActivity(intent);
                    }

                    @Override
                    public void failCallback(JSONObject response) {

                    }
                });
                break;

            case R.id.action_send_image:
                Bitmap bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.desert);
                cometChatroom.sendImage(bitmap, new Callbacks() {

                    @Override
                    public void successCallback(JSONObject response) {

                    }

                    @Override
                    public void failCallback(JSONObject response) {
                        Toast.makeText(getApplicationContext(), "Image send failed", Toast.LENGTH_SHORT).show();
                    }
                });
            case R.id.action_pick_image:
                Intent intent = new Intent(Intent.ACTION_GET_CONTENT, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                intent.setType("image/*");
                startActivityForResult(intent, 1);
                break;
            case R.id.action_capture_photo:
                Intent intent1 = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                fileUri = Utils.getOutputMediaFile(1, false);
                intent1.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);
                startActivityForResult(intent1, 2);
                break;
            case R.id.action_capture_video:
                Intent intent2 = new Intent(MediaStore.ACTION_VIDEO_CAPTURE);
                fileUri = Utils.getOutputMediaFile(2, false);
                intent2.putExtra(MediaStore.EXTRA_OUTPUT, fileUri);

                intent2.putExtra(MediaStore.EXTRA_VIDEO_QUALITY, 0);
                intent2.putExtra(MediaStore.EXTRA_SIZE_LIMIT, 15000000); // 15 Mb
                startActivityForResult(intent2, 3);
                break;
            case R.id.action_share_video:
                Intent intent3 = new Intent(Intent.ACTION_GET_CONTENT, MediaStore.Images.Media.EXTERNAL_CONTENT_URI);
                intent3.setType("video/*");
                startActivityForResult(intent3, 4);
                break;
            case R.id.action_share_audio:
                AssetManager mgr = this.getAssets();
                try {
                    AssetManager am = getAssets();
                    InputStream inputStream = am.open("song.aac");
                    File file = new File(getCacheDir() + "/song.aac");

                    try {
                        OutputStream outputStream = new FileOutputStream(file);
                        byte buffer[] = new byte[1024];
                        int length = 0;

                        while ((length = inputStream.read(buffer)) > 0) {
                            outputStream.write(buffer, 0, length);
                        }

                        outputStream.close();
                        inputStream.close();

                    } catch (IOException e) {

                    }
                    cometChatroom.sendAudioFile(file, new Callbacks() {

                        @Override
                        public void successCallback(JSONObject response) {
                            Logger.error("success " + response);
                            try {
                                ChatroomChatMessage newmessage = new ChatroomChatMessage(response.getString("id"), response
                                        .getString("original_file"), Utils.convertTimestampToDate(System
                                        .currentTimeMillis()), "Me :", true, "16", SharedPreferenceHelper
                                        .get(SharedPreferenceKeys.myId), chatroomId);
                                addMessage(newmessage);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }

                        @Override
                        public void failCallback(JSONObject response) {
                            Logger.error("fail " + response);
                        }
                    });

                } catch (Exception e) {
                    e.printStackTrace();
                }
                break;
            case R.id.action_share_file:
                Intent ii = new Intent(Intent.ACTION_GET_CONTENT);
                ii.setType("File/*");
                startActivityForResult(ii, 1234);
                break;
            case R.id.action_getchathistory:
                cometChatroom.getChatroomChatHistory(Long.parseLong(chatroomId), -1L, new Callbacks() {
                    @Override
                    public void successCallback(JSONObject jsonObject) {
                        Log.e("abc","response of history "+jsonObject);
                    }

                    @Override
                    public void failCallback(JSONObject jsonObject) {

                    }
                });

            default:
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        try {
            if (resultCode == RESULT_OK) {
                if (requestCode == 1) {
                    String path = Utils.getPath(data.getData(), true);

                    cometChatroom.sendImage(new File(path), new Callbacks() {

                        @Override
                        public void successCallback(JSONObject response) {
                            Logger.debug("share video send succes = " + response);
                        }

                        @Override
                        public void failCallback(JSONObject response) {
                            Logger.debug("share video send fail = " + response);
                        }
                    });
                } else if (requestCode == 2) {
                    Uri selectedImageUri = data.getData();
                    File newfile = new File(new URI(fileUri.toString()));
                    String filePath = newfile.getAbsolutePath();
                    BitmapFactory.Options options = new BitmapFactory.Options();
                    options.inSampleSize = 2;
                    Bitmap image = BitmapFactory.decodeFile(filePath, options);
                    if (image != null) {
                        cometChatroom.sendImage(image, new Callbacks() {

                            @Override
                            public void successCallback(JSONObject response) {
                                Logger.debug("image send succes = " + response);
                            }

                            @Override
                            public void failCallback(JSONObject response) {
                                Logger.debug("image send fail = " + response);

                            }
                        });
                    }
                } else if (requestCode == 3) {
                    try {
                        File newfile = new File(new URI(fileUri.toString()));
                        cometChatroom.sendVideo(newfile, new Callbacks() {

                            @Override
                            public void successCallback(JSONObject response) {
                                Logger.debug("video send succes = " + response);
                            }

                            @Override
                            public void failCallback(JSONObject response) {
                                Logger.debug("video send fail = " + response);
                            }
                        });
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                } else if (requestCode == 4) {
                    try {
                        String path = Utils.getPath(data.getData(), false);
                        cometChatroom.sendVideo(path, new Callbacks() {

                            @Override
                            public void successCallback(JSONObject response) {
                                Logger.debug("share video send succes = " + response);
                            }

                            @Override
                            public void failCallback(JSONObject response) {
                                Logger.debug("share video send fail = " + response);
                            }
                        });
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                } else if (requestCode == 1234) {
                    try {
                        File f = new File(data.getData().getPath());
                        cometChatroom.sendFile(f, new Callbacks() {

                            @Override
                            public void successCallback(JSONObject response) {
                                Logger.error("success " + response);
                                try {
                                    ChatroomChatMessage newmessage = new ChatroomChatMessage(response.getString("id"),
                                            response.getString("original_file"), Utils.convertTimestampToDate(System
                                            .currentTimeMillis()), "Me :", true, "17", SharedPreferenceHelper
                                            .get(SharedPreferenceKeys.myId), chatroomId);
                                    addMessage(newmessage);
                                } catch (Exception e) {
                                    e.printStackTrace();
                                }
                            }

                            @Override
                            public void failCallback(JSONObject response) {

                            }
                        });
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void onStart() {
        super.onStart();
        if (customReceiver != null) {
            registerReceiver(customReceiver, new IntentFilter("Chatroom_message"));
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        if (customReceiver != null) {
            unregisterReceiver(customReceiver);
        }
    }
}
