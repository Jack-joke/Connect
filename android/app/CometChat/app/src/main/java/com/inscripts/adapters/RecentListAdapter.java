package com.inscripts.adapters;


import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.GradientDrawable;
import android.support.v7.widget.RecyclerView;
import android.text.Html;
import android.text.Spannable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.activities.R;
import com.inscripts.activities.SingleChatActivity;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.emoji.custom.EmojiTextView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.RecyclerViewCursorAdapter;
import com.inscripts.factories.URLFactory;
import com.inscripts.fragments.RecentFragment;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.MessageHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Chatroom;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.models.Conversation;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.Smilies;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.tubb.smrv.SwipeHorizontalMenuLayout;

import org.json.JSONObject;

import static com.inscripts.helpers.PreferenceHelper.getContext;

public class RecentListAdapter  extends RecyclerViewCursorAdapter<RecentListAdapter.RecentItemHolder> implements OnAlertDialogButtonClickListener {

    private static final java.lang.String TAG = RecentListAdapter.class.getSimpleName();
    private Activity context;
    private Lang language;
    private long chatroomId ;
    private String chatroomPassword ;
    private int createdBy ;
    private String chatroomName ;
    private boolean isClearCount;
    private ProgressDialog progressDialog;
    private RecentFragment recentFragment;

    public RecentListAdapter(Activity context, RecentFragment recentFragment, Cursor c) {
        super(c);
        this.context = context;
        this.recentFragment = recentFragment;
        language = JsonPhp.getInstance().getLang();
    }

    @Override
    public void onBindViewHolder(final RecentItemHolder holder, Cursor cursor) {
        final boolean isChatroom = cursor.getLong(cursor.getColumnIndex(Conversation.COLUMN_CHATROOM_ID)) != 0;

        holder.sml.setSwipeEnable(true);
        holder.menuBtnLeft.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        holder.menuBtnRight.setText("DELETE CHAT");
        holder.userName.setText(Html.fromHtml(cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_NAME))));
        holder.statusImage.setVisibility(View.INVISIBLE);
        holder.userStatus.setVisibility(View.INVISIBLE);
        holder.userLastMessage.setVisibility(View.VISIBLE);

        String lastMessage = cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_LAST_MESSAGE));

        if (lastMessage.contains("<img class=\"cometchat_smiley\"")){
            Spannable spannable = Smilies.convertImageTagToEmoji(lastMessage, context, false,
                    R.drawable.class);
                holder.userLastMessage.setText(spannable);
        }else {
            holder.userLastMessage.setEmojiText(lastMessage,70);
        }

        if(isChatroom){
            holder.avatar.setVisibility(View.INVISIBLE);
           holder.chatroomAvtar.setVisibility(View.VISIBLE);
            holder.chatroomAvtar.setImageResource(R.drawable.vector_drawable_ic_group);
            holder.chatroomAvtar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
        }else{
            holder.avatar.setVisibility(View.VISIBLE);
            holder.chatroomAvtar.setVisibility(View.GONE);
            holder.avatar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
            String avatarURL = cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_AVTAR_URL));
            LocalStorageFactory.LoadImageUsingURL(context,avatarURL,holder.avatar,R.drawable.vector_drawable_ic_default_avtar);
        }

        if (0 == cursor.getInt(cursor.getColumnIndex(Conversation.COLUMN_UNREAD_COUNT))){
            holder.unreadCount.setVisibility(View.GONE);
        } else {
            GradientDrawable drawable = (GradientDrawable) holder.unreadCount.getBackground();
            drawable.setColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            holder.unreadCount.setVisibility(View.VISIBLE);
            holder.unreadCount.setText(String.valueOf(cursor.getInt(cursor.getColumnIndex(Buddy.COLUMN_UNREAD_COUNT))));
        }


        holder.view.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_BUDDY_ID)));
        holder.view.setTag(R.string.chatroom_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_CHATROOM_ID)));
        holder.menuBtnLeft.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_BUDDY_ID)));
        holder.menuBtnLeft.setTag(R.string.chatroom_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_CHATROOM_ID)));
        holder.menuBtnRight.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_BUDDY_ID)));
        holder.menuBtnRight.setTag(R.string.chatroom_id,cursor.getString(cursor.getColumnIndex(Conversation.COLUMN_CHATROOM_ID)));

        holder.menuBtnRight.setOnClickListener(new View.OnClickListener() { // Delete chat
            @Override
            public void onClick(View view) {

                if(isChatroom){
                    Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(view.getTag(R.string.chatroom_id)));
                    conversation.delete();
                    recentFragment.onFragmentResume();
                }else{
                    Conversation conversation = Conversation.getConversationByBuddyID(String.valueOf(view.getTag(R.string.buddy_id)));
                    conversation.delete();
                    recentFragment.onFragmentResume();
                }
            }
        });

        holder.menuBtnLeft.setOnClickListener(new View.OnClickListener() { //clear conversation
            @Override
            public void onClick(View view) {
                if(isChatroom){
                    ChatroomMessage.clearConversation(Long.parseLong((String) view.getTag(R.string.chatroom_id)));
                    Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(view.getTag(R.string.chatroom_id)));
                    if (conversation != null) {
                        conversation.lstMessage ="";
                        conversation.unreadCount =0;
                        conversation.save();
                        holder.sml.smoothCloseMenu();
                        recentFragment.onFragmentResume();
                    }
                    Toast.makeText(context,"Chat Cleared", Toast.LENGTH_SHORT).show();
                }else{
                    holder.sml.smoothCloseMenu();
                    OneOnOneMessage.clearConversation(String.valueOf(view.getTag(R.string.buddy_id)));
                    Conversation conversation = Conversation.getConversationByBuddyID(String.valueOf(view.getTag(R.string.buddy_id)));
                    if (conversation != null) {
                        conversation.lstMessage ="";
                        conversation.unreadCount =0;
                        conversation.save();
                        holder.sml.smoothCloseMenu();
                        recentFragment.onFragmentResume();
                    }
                    Toast.makeText(context,"Chat Cleared", Toast.LENGTH_SHORT).show();
                }
            }
        });

        holder.view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(isChatroom){

                    Chatroom chatroom = Chatroom.getChatroomDetails((String) view.getTag(R.string.chatroom_id));
                    assert chatroom != null;
                    if (CommonUtils.isConnected()) {
                        chatroom.unreadCount = 0;
                        chatroom.save();
                        isClearCount = true;

                        Conversation conversation = Conversation.getConversationByChatroomID((String) view.getTag(R.string.chatroom_id));
                        if(conversation != null){
                            conversation.unreadCount = 0;
                            conversation.save();
                        }

                        //PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT, 0);
                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_CHATROOM_MESSAGE, 1);
                        getContext().sendBroadcast(iintent);
                        SessionData.getInstance().setChatbadgeMissed(true);
                        notifyDataSetChanged();

                        chatroomId = chatroom.chatroomId;
                        chatroomPassword = chatroom.password;
                        createdBy = chatroom.createdBy;
                        chatroomName = chatroom.name;

                        //SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_CHATROOM);

                        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)
                                && chatroomId == Long.parseLong(PreferenceHelper
                                .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))) {
                            ChatroomManager.startChatroomActivity(chatroomId, chatroomName, context);
                        } else {
                            if (createdBy == 1 || createdBy == 2) {
                                progressDialog = ProgressDialog.show(context, "", JsonPhp.getInstance().getLang()
                                        .getMobile().get30());
                                progressDialog.setCancelable(false);

                                ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                        context, new CometchatCallbacks() {

                                            @Override
                                            public void successCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }

                                            @Override
                                            public void failCallback() {
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            }
                                        });
                            } else if (createdBy == 0) {
                                switch (chatroom.type) {
                                    case CometChatKeys.ChatroomKeys.TypeKeys.PUBLIC:
                                        progressDialog = ProgressDialog.show(context, "", JsonPhp.getInstance().getLang()
                                                .getMobile().get30());
                                        progressDialog.setCancelable(false);

                                        ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                                context, new CometchatCallbacks() {

                                                    @Override
                                                    public void successCallback() {
                                                        if (null != progressDialog) {
                                                            progressDialog.dismiss();
                                                        }
                                                    }

                                                    @Override
                                                    public void failCallback() {
                                                        if (null != progressDialog) {
                                                            progressDialog.dismiss();
                                                        }
                                                    }
                                                });
                                        break;
                                    case CometChatKeys.ChatroomKeys.TypeKeys.PASSWORD_PROTECTED:
							/*
							 * Chatroom is password protected and not created by
							 * self
							 */
                                        View dialogview = context.getLayoutInflater().inflate(R.layout.custom_dialog, null);

                                        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
                                        dialogueTitle.setText(language.getChatrooms().get8());

                                        EditText dialogueTextInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
                                        dialogueTextInput.setHint(language.getChatrooms().get32());

                                        new CustomAlertDialogHelper(context, "", dialogview, language.getChatrooms().get19(),
                                                "", language.getChatrooms().get51(),RecentListAdapter.this, 1);
                                        break;
                                    case CometChatKeys.ChatroomKeys.TypeKeys.INVITE_ONLY:
							/*
							 * Invite only room , get the invitation from
							 * oneOnOne heartbeat and then join it. This room is
							 * not listed in chatroomlist
							 */
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    } else {
                        Toast.makeText(context, language.getMobile().get24(), Toast.LENGTH_SHORT).show();
                    }

                }else{
                    final Long buddyId = Long.parseLong((String) view.getTag(R.string.buddy_id));
                    final Buddy buddy = Buddy.getBuddyDetails(buddyId);
                    if(buddy == null){
                        Logger.error(TAG,"inside buddy null");
                        MessageHelper.getInstance().addNewBuddy(buddyId, context, new CometchatCallbacks() {
                            @Override
                            public void successCallback() {
                                Buddy buddynew = Buddy.getBuddyDetails(buddyId);
                               openChatActivity(holder,buddyId,buddynew.name);
                            }

                            @Override
                            public void failCallback() {
                                Toast.makeText(context, "User not avialable", Toast.LENGTH_SHORT).show();
                            }
                        }, 0);
                    }else {
                        openChatActivity(holder,buddyId,buddy.name);
                    }
                }
            }
        });
    }

    @Override
    public RecentItemHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(context).inflate(R.layout.item_buddy, parent, false);
        return new RecentItemHolder(v);
    }

    @Override
    public void onButtonClick(final AlertDialog dialog, View v, int which, int popupId) {

        final EditText chatroomPasswordInput = (EditText) v.findViewById(R.id.edittextDialogueInput);

        if (which == DialogInterface.BUTTON_NEGATIVE) { // Cancel
            dialog.dismiss();
        } else if (which == DialogInterface.BUTTON_POSITIVE) { // Join
            try {

                Logger.error("Clicked on Join Chatroom");
                progressDialog = ProgressDialog.show(context, "", JsonPhp.getInstance().getLang().getMobile()
                        .get30());
                progressDialog.setCancelable(false);
                chatroomPassword = chatroomPasswordInput.getText().toString();
                if (chatroomPassword.length() == 0) {
                    chatroomPasswordInput.setText("");
                    chatroomPasswordInput.setError(language.getChatrooms().get23());
                    progressDialog.dismiss();
                } else {
                    try {
                        chatroomPassword = EncryptionHelper.encodeIntoShaOne(chatroomPassword);
                        Logger.error("Password Url = "+ URLFactory.getChatroomPasswordUrl());
                        VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomPasswordUrl(),
                                new VolleyAjaxCallbacks() {

                                    @Override
                                    public void successCallback(String response) {
                                        try {
                                            Logger.error("Paaword protected response ="+response);
                                            JSONObject chatroomJson = new JSONObject(response);
                                            String joinResponse = chatroomJson.getString("s");
                                            if (joinResponse.equals("INVALID_PASSWORD")) {
												/*
												 * Wrong password value returned
												 * 0
												 */
                                                chatroomPasswordInput.setText("");
                                                chatroomPasswordInput.setError(language.getChatrooms().get23());
                                                SessionData.getInstance().setCurrentChatroomPassword("");
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else if (joinResponse.equals("BANNED")) {
												/*
												 * User is banned for this
												 * chatroom value returned 2
												 */
                                                if (createdBy != 1) {
                                                    Toast.makeText(getContext(),
                                                            language.getChatrooms().get37(), Toast.LENGTH_SHORT).show();
                                                    dialog.dismiss();
                                                }
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else if (joinResponse.equals("INVALID_CHATROOM")) {
                                                Toast.makeText(getContext(),
                                                        JsonPhp.getInstance().getLang().getChatrooms().get55(),
                                                        Toast.LENGTH_SHORT).show();
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else {
												/* User is valid */
                                                dialog.dismiss();
                                                Chatroom chatroom = Chatroom.getChatroomDetails(chatroomId);
                                                if (0 != chatroom.unreadCount) {
                                                    chatroom.unreadCount = 0;
                                                    chatroom.save();
                                                    isClearCount = true;
                                                }
                                                ChatroomManager.joinChatroom(chatroomId, chatroomName,
                                                        chatroomPassword, 0, (Activity) context, new CometchatCallbacks() {

                                                            @Override
                                                            public void successCallback() {
                                                                if (null != progressDialog) {
                                                                    progressDialog.dismiss();
                                                                }
                                                            }

                                                            @Override
                                                            public void failCallback() {
                                                                if (null != progressDialog) {
                                                                    progressDialog.dismiss();
                                                                }
                                                            }
                                                        });
                                            }
                                            // loader.setVisibility(View.GONE);
                                            notifyDataSetChanged();
                                        } catch (Exception e) {
                                            e.printStackTrace();
                                        }
                                    }

                                    @Override
                                    public void failCallback(String response, boolean isNoInternet) {
                                        if (isNoInternet) {
                                            Toast.makeText(context, language.getMobile().get24(),
                                                    Toast.LENGTH_SHORT).show();
                                        }
                                        if (null != progressDialog) {
                                            progressDialog.dismiss();
                                        }
                                    }
                                });

                        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, String.valueOf(chatroomId));
                        vHelper.addNameValuePair("name",chatroomName);
                        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, chatroomPassword);
                        vHelper.sendAjax();

                    } catch (Exception e) {
                        Logger.error("Error at SHA1:UnsupportedEncodingException FOR PASSWORD "
                                + e.getLocalizedMessage());
                        e.printStackTrace();
                    }
                }
            } catch (Exception e) {
                Logger.error("chatroomFragment.java onButtonClick() : Exception=" + e.getLocalizedMessage());
                e.printStackTrace();
            }
        }

    }

    private void openChatActivity(RecentItemHolder holder , long buddyId , String buddyName){
        Conversation conversation = Conversation.getConversationByBuddyID(String.valueOf(buddyId));
        if(holder.sml.isMenuOpen()){
            holder.sml.smoothCloseMenu();
        }else{
            holder.sml.smoothOpenBeginMenu();
            holder.sml.smoothCloseMenu();

            Intent intent = new Intent(context, SingleChatActivity.class);
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID,buddyId);
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL).isEmpty()) {
                intent.putExtra("ImageUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL));
            }
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL).isEmpty()) {
                intent.putExtra("VideoUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL));
            }
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL).isEmpty()) {
                intent.putExtra("AudioUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL));
            }
            if (PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL) != null && !PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL).isEmpty()) {
                intent.putExtra("FileUri", PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_FILE_URL));
            }
            intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME, buddyName);


            SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_ONE_ON_ONE);
            context.startActivity(intent);

            if (0L != conversation.unreadCount) {
                conversation.unreadCount = 0;
                conversation.save();
                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                getContext().sendBroadcast(iintent);
                SessionData.getInstance().setChatbadgeMissed(true);
                notifyDataSetChanged();
            }
        }
    }

    static class RecentItemHolder extends RecyclerView.ViewHolder {

        public TextView userName;
        public TextView userStatus;
        public EmojiTextView userLastMessage;
        public TextView unreadCount;
        public RoundedImageView avatar;
        public ImageView chatroomAvtar;
        public ImageView statusImage;
        public SwipeHorizontalMenuLayout sml;
        public Button menuBtnLeft;
        public Button menuBtnRight;
        public View view;

        public RecentItemHolder(View view) {
            super(view);
            avatar = (RoundedImageView) view.findViewById(R.id.imageViewUserAvatar);
            chatroomAvtar = (ImageView) view.findViewById(R.id.imageviewchatroomAvatar);
            userName = (TextView) view.findViewById(R.id.textviewUserName);
            userStatus = (TextView) view.findViewById(R.id.textviewUserStatus);
            statusImage = (ImageView) view.findViewById(R.id.imageViewStatusIcon);
            unreadCount = (TextView) view.findViewById(R.id.textviewSingleChatUnreadCount);
            menuBtnLeft = (Button) view.findViewById(R.id.btLeft);
            menuBtnRight = (Button) view.findViewById(R.id.btOpen);
            userLastMessage = (EmojiTextView) view.findViewById(R.id.textviewLastMessage);
            sml = (SwipeHorizontalMenuLayout) view.findViewById(R.id.sml);
            this.view = view;
        }
    }
}

