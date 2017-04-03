/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.GradientDrawable;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.R;
import com.inscripts.custom.CustomAlertDialogHelper;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.EncryptionHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.OnAlertDialogButtonClickListener;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.tubb.smrv.SwipeHorizontalMenuLayout;

import org.json.JSONObject;

import java.util.List;

import se.emilsjolander.stickylistheaders.StickyListHeadersAdapter;

public class ChatroomsListAdapter extends ArrayAdapter<Chatroom> implements OnAlertDialogButtonClickListener,StickyListHeadersAdapter {

    private MobileTheme mobileTheme;
    private Css css;
    private static ProgressDialog progressDialog;
    private Context context;
    private Lang language;
    private long chatroomId ;
    private String chatroomPassword ;
    private int createdBy ;
    private String chatroomName ;
    private boolean isClearCount;

    public ChatroomsListAdapter(Context context, List<Chatroom> objects) {
        super(context, R.layout.cc_custom_list_item_chatrooms, objects);
        this.context = context;
        language = JsonPhp.getInstance().getLang();
    }

    @Override
    public void onButtonClick(final AlertDialog dialog, View v, int which, int popupId) {

        final EditText chatroomPasswordInput = (EditText) v.findViewById(R.id.edittextDialogueInput);

        if (which == DialogInterface.BUTTON_NEGATIVE) { // Cancel
            dialog.dismiss();
        } else if (which == DialogInterface.BUTTON_POSITIVE) { // Join
            try {
                progressDialog = ProgressDialog.show(getContext(), "", JsonPhp.getInstance().getLang().getMobile()
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
                                                    Toast.makeText(PreferenceHelper.getContext(),
                                                            language.getChatrooms().get37(), Toast.LENGTH_SHORT).show();
                                                    dialog.dismiss();
                                                }
                                                if (null != progressDialog) {
                                                    progressDialog.dismiss();
                                                }
                                            } else if (joinResponse.equals("INVALID_CHATROOM")) {
                                                Toast.makeText(PreferenceHelper.getContext(),
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

    @Override
    public View getHeaderView(int position, View convertView, ViewGroup parent) {
        HeaderViewHolder holder;
        if (convertView == null) {
            holder = new ChatroomsListAdapter.HeaderViewHolder();
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.cc_chatroom_list_header, parent, false);
            holder.chatroomStatus = (TextView) convertView.findViewById(R.id.message_date);
            convertView.setTag(holder);
        } else {
            holder = (ChatroomsListAdapter.HeaderViewHolder) convertView.getTag();
        }
        Chatroom chatroom = getItem(position);

        if(chatroom.status == 1)
            holder.chatroomStatus.setText("JOINED GROUPS");
        else
            holder.chatroomStatus.setText("OTHER GROUPS");

        return convertView;
    }

    @Override
    public long getHeaderId(int position) {
        Chatroom chatroom = getItem(position);
        return chatroom.status;
    }


    class HeaderViewHolder {
        public TextView chatroomStatus;
    }

    private static class ViewHolder {
        public TextView chatroomNameField,unreadCount,usersOnline,usersOnlineMessage;
        public ImageView protectedStatus,imageviewchatroomAvatar;//chatroomDelete,chatroomRename,;
        public SwipeHorizontalMenuLayout sml;
        public RelativeLayout container;
        public Button menuBtnRight,menuBtnRename;
    }

    @Override
    public View getView(int position, View convertView, final ViewGroup parent) {
        View view = convertView;
        final ViewHolder holder;

        if (null == view) {
            view = LayoutInflater.from(parent.getContext()).inflate(R.layout.cc_item_chatroom_list, parent, false);
            holder = new ViewHolder();
            holder.chatroomNameField = (TextView) view.findViewById(R.id.textviewChatroomName);
            holder.unreadCount = (TextView) view.findViewById(R.id.textviewChatroomUnreadCount);
            holder.usersOnline = (TextView) view.findViewById(R.id.textViewChatroomUsersOnline);
            holder.imageviewchatroomAvatar = (ImageView) view.findViewById(R.id.imageviewchatroomAvatar);
            holder.protectedStatus = (ImageView) view.findViewById(R.id.imageViewChatoomProtected);
            holder.usersOnlineMessage = (TextView) view.findViewById(R.id.textviewUsersOnlineMessage);
            /*holder.chatroomDelete = (ImageView) view.findViewById(R.id.imageViewDeleteChatroom);
            holder.chatroomRename = (ImageView) view.findViewById(R.id.imageViewRenameChatroom);*/
            holder.sml = (SwipeHorizontalMenuLayout) view.findViewById(R.id.sml);
            holder.menuBtnRight = (Button) view.findViewById(R.id.btOpen);
            holder.menuBtnRename = (Button) view.findViewById(R.id.btRightRename);
            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        holder.sml.setSwipeEnable(true);
        // holder.menuBtnLeft.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
        holder.menuBtnRename.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));


        final Chatroom chatroom = getItem(position);
        int unreadCount = chatroom.unreadCount;

        holder.imageviewchatroomAvatar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        if (0 == unreadCount) {
            holder.unreadCount.setVisibility(View.INVISIBLE);
        } else {
            GradientDrawable drawable = (GradientDrawable) holder.unreadCount.getBackground();
            drawable.setColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            holder.unreadCount.setVisibility(View.VISIBLE);
            holder.unreadCount.setText(String.valueOf(unreadCount));
        }

        if (chatroom.type == CometChatKeys.ChatroomKeys.TypeKeys.PASSWORD_PROTECTED) {
            holder.protectedStatus.setVisibility(View.VISIBLE);
        } else {
            holder.protectedStatus.setVisibility(View.GONE);
        }
        if (chatroom.createdBy == 1){
           /* holder.chatroomDelete.setVisibility(View.VISIBLE);
            holder.chatroomRename.setVisibility(View.VISIBLE);*/
            holder.menuBtnRename.setVisibility(View.VISIBLE);
            holder.menuBtnRight.setText("DELETE");
        }else{
           /* holder.chatroomDelete.setVisibility(View.GONE);
            holder.chatroomRename.setVisibility(View.GONE);*/
            holder.menuBtnRename.setVisibility(View.GONE);
            holder.menuBtnRight.setText("LEAVE GROUP");
        }

        holder.chatroomNameField.setText(Html.fromHtml(chatroom.name));

        if (null != JsonPhp.getInstance().getConfig().getCrHideUserCount() && JsonPhp.getInstance().getConfig().getCrHideUserCount().equals("1")) {
            holder.usersOnline.setVisibility(View.INVISIBLE);
            holder.usersOnlineMessage.setVisibility(View.INVISIBLE);
        } else {
            holder.usersOnline.setVisibility(View.VISIBLE);
            holder.usersOnlineMessage.setVisibility(View.VISIBLE);
            holder.usersOnline.setText(String.valueOf(chatroom.onlineCount));
            holder.usersOnlineMessage.setText(JsonPhp.getInstance().getLang().getMobile().get35() + ": ");
        }

       /* holder.chatroomDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ChatroomManager.deleteChatroom(getContext(), chatroom.chatroomId);
            }
        });

        holder.chatroomRename.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ChatroomManager.renameChatroom(getContext(), chatroom.chatroomId, chatroom.name, chatroom);
            }
        });*/


        holder.menuBtnRight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(chatroom.createdBy == 1){ // delete
                    ChatroomManager.deleteChatroom(getContext(), chatroom.chatroomId);
                    Toast.makeText(context, chatroom.name + "Deleted .", Toast.LENGTH_SHORT).show();
                }else{ //leave
                    ChatroomManager.leaveChatroom(chatroom.chatroomId, "0");
                    Toast.makeText(context, chatroom.name + "Left .", Toast.LENGTH_SHORT).show();
                }
                holder.sml.smoothCloseMenu();
            }
        });

        holder.menuBtnRename.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ChatroomManager.renameChatroom(getContext(), chatroom.chatroomId, chatroom.name, chatroom);
                holder.sml.smoothCloseMenu();
            }
        });


    /*    holder.menuBtnLeft.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ChatroomMessage.clearConversation(chatroom.chatroomId);
                holder.sml.smoothCloseMenu();
            }
        });*/


        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    if (CommonUtils.isConnected()) {
                        // Logger.error("chatroomid: " + chatroom.chatroomId + " " +
                        // chatroom.unreadCount);
               /* if (0 != chatroom.unreadCount) {*/
                        chatroom.unreadCount = 0;
                        chatroom.save();
                        isClearCount = true;

                        //PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_BADGE_COUNT, 0);
                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_CHATROOM_MESSAGE, 1);
                        PreferenceHelper.getContext().sendBroadcast(iintent);
                        SessionData.getInstance().setChatbadgeMissed(true);
                /*}*/

                        notifyDataSetChanged();

                        chatroomId = chatroom.chatroomId;
                        chatroomPassword = chatroom.password;
                        int createdBy = chatroom.createdBy;
                        chatroomName = chatroom.name;


                        SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_CHATROOM);

                        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID)
                                && chatroomId == Long.parseLong(PreferenceHelper
                                .get(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID))) {
                            ChatroomManager.startChatroomActivity(chatroomId, chatroomName, parent.getContext());
                        } else {
                            if (createdBy == 1 || createdBy == 2) {
                        /*
                         * ChatRoom is created by self or i am moderator of
						 * chatroom
						 */
                                progressDialog = ProgressDialog.show(parent.getContext(), "", JsonPhp.getInstance().getLang()
                                        .getMobile().get30());
                                progressDialog.setCancelable(false);

                                ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                        (Activity) parent.getContext(), new CometchatCallbacks() {

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
                                        progressDialog = ProgressDialog.show(parent.getContext(), "", JsonPhp.getInstance().getLang()
                                                .getMobile().get30());
                                        progressDialog.setCancelable(false);

                                        ChatroomManager.joinChatroom(chatroomId, chatroomName, chatroomPassword, createdBy,
                                                (Activity) parent.getContext(), new CometchatCallbacks() {

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
                                        View dialogview = ((Activity) parent.getContext()).getLayoutInflater().inflate(R.layout.cc_custom_dialog, null);

                                        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
                                        dialogueTitle.setText(language.getChatrooms().get8());

                                        EditText dialogueTextInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
                                        dialogueTextInput.setHint(language.getChatrooms().get32());

                                        new CustomAlertDialogHelper(parent.getContext(), "", dialogview, language.getChatrooms().get19(),
                                                "", language.getChatrooms().get51(),ChatroomsListAdapter.this, 1);
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
                        Toast.makeText(parent.getContext(), language.getMobile().get24(), Toast.LENGTH_SHORT).show();
                    }
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });

        return view;
    }


}
