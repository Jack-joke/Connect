/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.support.v7.widget.RecyclerView;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.activities.R;
import com.inscripts.activities.SingleChatActivity;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.RecyclerViewCursorAdapter;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.BlockUnblockUser;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.tubb.smrv.SwipeHorizontalMenuLayout;


public class BuddyListRecyclerAdapter extends RecyclerViewCursorAdapter<BuddyListRecyclerAdapter.BuddyItemHolder> {

    private static final String TAG = BuddyListRecyclerAdapter.class.getSimpleName();
    private Context context;
    private SessionData sessionData;
    private Lang lang;

    public BuddyListRecyclerAdapter(Context context ,Cursor c) {
        super(c);
        this.context = context;
        sessionData = SessionData.getInstance();
        lang = JsonPhp.getInstance().getLang();
    }


    @Override
    public BuddyItemHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_buddy, parent, false);
        return new BuddyItemHolder(v);
    }

    @Override
    public void onBindViewHolder(final BuddyItemHolder holder, final Cursor cursor) {

        holder.sml.setSwipeEnable(true);
        holder.menuBtnLeft.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));

        holder.userName.setText(Html.fromHtml(cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_NAME))));
        holder.userStatus.setText(Html.fromHtml(cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_STATUS_MESSAGE))));

        holder.avatar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        String avatarURL = cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_AVATAR_URL));
        LocalStorageFactory.LoadImageUsingURL(context,avatarURL,holder.avatar,R.drawable.vector_drawable_ic_default_avtar);

        //if (0 == cursor.getInt(cursor.getColumnIndex(Buddy.COLUMN_UNREAD_COUNT))){
            holder.unreadCount.setVisibility(View.GONE);
        /*} else {
            GradientDrawable drawable = (GradientDrawable) holder.unreadCount.getBackground();
            drawable.setColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            holder.unreadCount.setVisibility(View.VISIBLE);
            holder.unreadCount.setText(String.valueOf(cursor.getInt(cursor.getColumnIndex(Buddy.COLUMN_UNREAD_COUNT))));
        }*/

        switch (cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_STATUS)).toLowerCase()) {
            case CometChatKeys.StatusKeys.AVALIABLE:
                holder.statusImage.setImageResource(R.drawable.status_online);
                break;
            case CometChatKeys.StatusKeys.AWAY:
                holder.statusImage.setImageResource(R.drawable.status_available);
                break;
            case CometChatKeys.StatusKeys.BUSY:
                holder.statusImage.setImageResource(R.drawable.status_bussy);
                break;
            case CometChatKeys.StatusKeys.OFFLINE:
                holder.statusImage.setImageResource(R.drawable.status_ofline);
                break;
            case CometChatKeys.StatusKeys.INVISIBLE:
                holder.statusImage.setImageResource(R.drawable.status_ofline);
                break;
            default:
                holder.statusImage.setImageResource(R.drawable.status_available);
                break;
        }


        holder.view.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_BUDDY_ID)));
        holder.menuBtnRight.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_BUDDY_ID)));
        holder.menuBtnLeft.setTag(R.string.buddy_id,cursor.getString(cursor.getColumnIndex(Buddy.COLUMN_BUDDY_ID)));

        holder.view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Buddy buddy = Buddy.getBuddyDetails((String) view.getTag(R.string.buddy_id));

                if(holder.sml.isMenuOpen()){
                    holder.sml.smoothCloseMenu();
                }else{
                    holder.sml.smoothOpenBeginMenu();
                    holder.sml.smoothCloseMenu();

                    Intent intent = new Intent(context, SingleChatActivity.class);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID,buddy.buddyId);
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
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_NAME, buddy.name);


                    SessionData.getInstance().setTopFragment(StaticMembers.TOP_FRAGMENT_ONE_ON_ONE);
                    context.startActivity(intent);

                    if (0L != buddy.unreadCount) {
                        buddy.unreadCount = 0;
                        buddy.save();
                        Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ANNOUNCEMENT_BADGE_UPDATION);
                        iintent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.NEW_MESSAGE, 1);
                        PreferenceHelper.getContext().sendBroadcast(iintent);
                        SessionData.getInstance().setChatbadgeMissed(true);
                        notifyDataSetChanged();
                    }
                }

            }
        });

        holder.menuBtnRight.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(final View view) {

                BlockUnblockUser.blockUser(Long.parseLong(String.valueOf(view.getTag(R.string.buddy_id))), context, new CometchatCallbacks() {

                    @Override
                    public void successCallback() {

                        Buddy buddy = Buddy.getBuddyDetails(String.valueOf(view.getTag(R.string.buddy_id)));
                        try {
                            //Buddy.deleteById(buddyId);
                            if (buddy == null) {
                                 buddy = Buddy.getBuddyDetails(buddy.buddyId);
                            }
                            buddy.showuser = 0;
                            buddy.save();
                            Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                            intent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_BUDDY_LIST_FRAGMENT, 1);
                            context.sendBroadcast(intent);
                            sessionData.setBuddyListBroadcastMissed(true);

                            Toast.makeText(context, buddy.name + " Blocked", Toast.LENGTH_SHORT).show();
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }

                    @Override
                    public void failCallback() {

                        Toast.makeText(
                                context,
                                (null == lang.getMobile().get69() ? StaticMembers.ERROR_BLOCKING_USER : lang
                                        .getMobile().get69()), Toast.LENGTH_SHORT).show();

                    }
                });
                holder.sml.smoothCloseMenu();
            }
        });

        holder.menuBtnLeft.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                holder.sml.smoothCloseMenu();
                OneOnOneMessage.clearConversation(String.valueOf(view.getTag(R.string.buddy_id)));
                Toast.makeText(context,"Chat Cleared", Toast.LENGTH_SHORT).show();
            }
        });
    }

    static class BuddyItemHolder extends RecyclerView.ViewHolder {

        public TextView userName;
        public TextView userStatus;
        public TextView unreadCount;
        public RoundedImageView avatar;
        public ImageView avtar_image;
        public ImageView statusImage;
        public SwipeHorizontalMenuLayout sml;
        public Button menuBtnLeft;
        public Button menuBtnRight;
        public View view;

        public BuddyItemHolder(View view) {
            super(view);
            avatar = (RoundedImageView) view.findViewById(R.id.imageViewUserAvatar);
            userName = (TextView) view.findViewById(R.id.textviewUserName);
            userStatus = (TextView) view.findViewById(R.id.textviewUserStatus);
            statusImage = (ImageView) view.findViewById(R.id.imageViewStatusIcon);
            unreadCount = (TextView) view.findViewById(R.id.textviewSingleChatUnreadCount);
            menuBtnLeft = (Button) view.findViewById(R.id.btLeft);
            menuBtnRight = (Button) view.findViewById(R.id.btOpen);
            sml = (SwipeHorizontalMenuLayout) view.findViewById(R.id.sml);
            this.view = view;
        }
    }
}

