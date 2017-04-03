/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
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
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;
import com.inscripts.R;
import com.inscripts.activities.SingleChatActivity;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.BlockUnblockUser;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.tubb.smrv.SwipeHorizontalMenuLayout;

import java.util.List;

import static com.inscripts.R.drawable.status_available;

public class BuddyListAdapter extends ArrayAdapter<Buddy> {

    private static final String TAG = BuddyListAdapter.class.getSimpleName();
    MobileTheme mobileTheme;
    Css css;
    int actionBarColor;
    Context context;
    private SessionData sessionData;
    private Lang lang;

    public BuddyListAdapter(Context context, List<Buddy> objects) {
        super(context, R.layout.cc_custom_list_item_one_on_one, objects);

        this.context = context;
        mobileTheme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();
        if (mobileTheme != null && null != mobileTheme.getActionbarColor()) {
            actionBarColor = Color.parseColor(mobileTheme.getActionbarColor());
        } else if (null != css) {
            actionBarColor = Color.parseColor(css.getTabTitleBackground());
        } else {
            actionBarColor = Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN);
        }

        sessionData = SessionData.getInstance();
        lang = JsonPhp.getInstance().getLang();
    }

    @Override
    public View getView(final int position, View convertView, final ViewGroup parent) {

        View view = convertView;
        final ViewHolder holder;

        if (null == view) {
            view = LayoutInflater.from(parent.getContext())
                    .inflate(R.layout.cc_item_buddy, parent, false);

            holder = new ViewHolder();
            holder.avatar = (RoundedImageView) view.findViewById(R.id.imageViewUserAvatar);
            //holder.avtar_image = (ImageView) view.findViewById(R.id.imageViewUserAvatar);
            holder.userName = (TextView) view.findViewById(R.id.textviewUserName);
            holder.userStatus = (TextView) view.findViewById(R.id.textviewUserStatus);
            holder.statusImage = (ImageView) view.findViewById(R.id.imageViewStatusIcon);
            holder.unreadCount = (TextView) view.findViewById(R.id.textviewSingleChatUnreadCount);
            holder.menuBtnLeft = (Button) view.findViewById(R.id.btLeft);
            holder.menuBtnRight = (Button) view.findViewById(R.id.btOpen);
            holder.sml = (SwipeHorizontalMenuLayout) view.findViewById(R.id.sml);
            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        holder.sml.setSwipeEnable(true);
        final Buddy buddy = getItem(position);
        holder.menuBtnLeft.setBackgroundColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));

        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(holder.sml.isMenuOpen()){
                    holder.sml.smoothCloseMenu();
                }else{
                    holder.sml.smoothOpenBeginMenu();
                    holder.sml.smoothCloseMenu();

                    Buddy buddy = getItem(position);
                    Intent intent = new Intent(context, SingleChatActivity.class);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, buddy.buddyId);
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
            public void onClick(View view) {

                BlockUnblockUser.blockUser(buddy.buddyId, context, new CometchatCallbacks() {

                    @Override
                    public void successCallback() {
                        Buddy newBuddy;
                        try {
                            //Buddy.deleteById(buddyId);
                            if (buddy == null) {
                                newBuddy = Buddy.getBuddyDetails(buddy.buddyId);
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
                OneOnOneMessage.clearConversation(String.valueOf(buddy.buddyId));
                Toast.makeText(parent.getContext(),"Chat Cleared", Toast.LENGTH_SHORT).show();
            }
        });



        holder.userName.setText(Html.fromHtml(buddy.name));
        //holder.userName.setText("Chris Hemsworth");
        holder.userStatus.setText(Html.fromHtml(buddy.statusMessage));
        holder.avatar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);

        /** Replacing Picasso with glide **/
        /*LocalStorageFactory.getPicassoInstance().load(buddy.avatarURL).placeholder(R.drawable.vector_drawable_ic_default_avtar)
                .resize(55, 55).into(holder.avatar);*/

        LocalStorageFactory.LoadImageUsingURL(context,buddy.avatarURL,holder.avatar,R.drawable.vector_drawable_ic_default_avtar);

        if (0 == buddy.unreadCount) {
            holder.unreadCount.setVisibility(View.GONE);
        } else {
            GradientDrawable drawable = (GradientDrawable) holder.unreadCount.getBackground();
            drawable.setColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
            holder.unreadCount.setVisibility(View.VISIBLE);
            holder.unreadCount.setText(String.valueOf(buddy.unreadCount));
        }

		/* Set color according to the status. */

        switch (buddy.status.toLowerCase()) {
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
                holder.statusImage.setImageResource(status_available);
                break;
        }
        return view;
    }

    private static class ViewHolder {
        public TextView userName;
        public TextView userStatus;
        public TextView unreadCount;
        public RoundedImageView avatar;
        public ImageView avtar_image;
        public ImageView statusImage;
        public SwipeHorizontalMenuLayout sml;
        public Button menuBtnLeft;
        public Button menuBtnRight;
    }



}
