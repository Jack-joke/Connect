/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.LightingColorFilter;
import android.graphics.PorterDuff;
import android.graphics.drawable.GradientDrawable;
import android.graphics.drawable.LayerDrawable;
import android.graphics.drawable.RotateDrawable;
import android.media.MediaPlayer;
import android.media.ThumbnailUtils;
import android.net.Uri;
import android.os.Handler;
import android.provider.BaseColumns;
import android.provider.MediaStore;
import android.provider.MediaStore.MediaColumns;
import android.support.v4.util.LongSparseArray;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.text.style.StyleSpan;
import android.text.util.Linkify;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.RelativeLayout;
import android.widget.SeekBar;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.resource.drawable.GlideDrawable;
import com.bumptech.glide.request.RequestListener;
import com.bumptech.glide.request.target.Target;
import com.inscripts.R;
import com.inscripts.activities.ImagePreviewActivity;
import com.inscripts.activities.WhiteboardActivity;
import com.inscripts.activities.WriteBoardActivity;
import com.inscripts.custom.EmojiTextView;
import com.inscripts.custom.EmoticonUtils;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.BitmapProcessingHelper;
import com.inscripts.helpers.FileOpenIntentHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Audiochat;
import com.inscripts.jsonphp.Avchat;
import com.inscripts.jsonphp.Chatrooms;
import com.inscripts.jsonphp.Filetransfer;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Bot;
import com.inscripts.models.Buddy;
import com.inscripts.models.OneOnOneMessage;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.ChatroomManager;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.videochat.VideoChatActivity;

import org.json.JSONException;
import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.File;
import java.util.List;

import se.emilsjolander.stickylistheaders.StickyListHeadersAdapter;

public class OneToOneMessageAdapter extends ArrayAdapter<OneOnOneMessage> implements StickyListHeadersAdapter {

    private static final int TYPES_COUNT = 2;
    private static final int TYPE_LEFT = 0;
    private static final int TYPE_RIGHT = 1;
    private Activity context;
    private BitmapFactory.Options options;
    private static LongSparseArray<Bitmap> videoThumbnails;
    private static LongSparseArray<Integer> audioDurations;
    Handler seekHandler = new Handler();
    private Runnable timerRunnable;
    private String currentPlayingSong = "", leftBubbleTextColor, rightBubbleTextColor;
    MediaPlayer player;
    boolean cometservice = false, showticks = false;
    static MobileTheme mobileTheme;
    Long currentlyPlayingId = 0l;

    public OneToOneMessageAdapter(Activity context, List<OneOnOneMessage> messageList) {
        super(context, R.layout.cc_custom_chat_message_one_on_one_left, messageList);
        options = new BitmapFactory.Options();
        options.inPreferredConfig = Bitmap.Config.RGB_565;
        this.context = context;
        videoThumbnails = new LongSparseArray<>();
        audioDurations = new LongSparseArray<>();
        player = CommonUtils.getPlayerInstance();
        cometservice = null != JsonPhp.getInstance().getConfig() && JsonPhp.getInstance().getConfig().getUSECOMET().equals("1");
        showticks = (cometservice && !TextUtils.isEmpty(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE)) && ((Integer.parseInt(PreferenceHelper.get(PreferenceKeys.LoginKeys.VERSION_CODE_VALUE))) >= 570));

    }

    @Override
    public void notifyDataSetChanged() {
        super.notifyDataSetChanged();
        if (getCount() == 0) {
            audioDurations.clear();
            currentPlayingSong = "";
            currentlyPlayingId = 0l;
        }
    }

    @Override
    public int getViewTypeCount() {
        return TYPES_COUNT;
    }

    @Override
    public int getItemViewType(int position) {
        OneOnOneMessage message = getItem(position);
        if (0 == message.self) {
            return TYPE_LEFT;
        }
        return TYPE_RIGHT;
    }

    @Override
    public View getHeaderView(int position, View convertView, ViewGroup parent) {
        HeaderViewHolder holder = new HeaderViewHolder();
        if (position >= Integer.parseInt(LocalConfig.getMessageLimit())) {
            position = position - 1;
        }
        if (convertView == null) {
            holder = new HeaderViewHolder();
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.cc_message_list_header, parent,
                    false);
            holder.date = (TextView) convertView.findViewById(R.id.message_date);
            convertView.setTag(holder);
        } else {
            holder = (HeaderViewHolder) convertView.getTag();
        }
        OneOnOneMessage message = getItem(position);
        holder.date.setText(CommonUtils.getFormattedDate(message.sentTimestamp));
        return convertView;
    }

    @Override
    public long getHeaderId(int position) {
        try {
            OneOnOneMessage message = getItem(position);
            return Long.parseLong(CommonUtils.getDateId(message.sentTimestamp));
        } catch (Exception e) {
            e.printStackTrace();
            return 0;
        }
    }


    private static class Holder {
        public EmojiTextView message,tvOnlySmiley;
        public TextView messageTimestamp, audioTime, avchatMessageTimeStamp, avchatMessage;
        public ImageView imageHolder, audioPlayButton, videoThumb, videoMessageButton, messageTick,customImageHolder;
        public RelativeLayout normalMessageContainer, avchatMessageContainer, audioNoteContainer;
        public View messageArrow;
        public ProgressBar wheel;
        public RoundedImageView avatar;
        public SeekBar audioSeekbar;
    }

    class HeaderViewHolder {
        TextView date;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View vi = convertView;
        /* Setup one to one holder */
        Holder holder = new Holder();
        String leftBubbleColor, rightBubbleColor;
        mobileTheme = JsonPhp.getInstance().getMobileTheme();
        if (vi == null) {
            if (null == mobileTheme) {
                mobileTheme = JsonPhp.getInstance().getMobileTheme();
            }

            if (null != mobileTheme && null != mobileTheme.getLeftBubbleColor() && null != mobileTheme.getLeftBubbleTextColor() && null != mobileTheme.getRightBubbleColor() && null != mobileTheme.getRightBubbleTextColor()) {
                //leftBubbleColor = mobileTheme.getLeftBubbleColor();
                //leftBubbleTextColor = mobileTheme.getLeftBubbleTextColor();
                leftBubbleColor = "#e6e9ed";
                leftBubbleTextColor ="#8e8e92";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
                rightBubbleTextColor = mobileTheme.getRightBubbleTextColor();
            } else {
                leftBubbleColor = "#e6e9ed";
                leftBubbleTextColor = "#8e8e92";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
                rightBubbleTextColor = "#FFFFFF";
            }

            if (getItemViewType(position) == TYPE_RIGHT) {
                vi = LayoutInflater.from(getContext()).inflate(R.layout.cc_custom_chat_message_one_on_one_right, parent,
                        false);
                holder.message = (EmojiTextView) vi.findViewById(R.id.textViewOneOnOneMessageRight);
                holder.messageTimestamp = (TextView) vi.findViewById(R.id.textViewOneOnOneTimestampRight);
                holder.imageHolder = (ImageView) vi.findViewById(R.id.imageViewOneOnOneImageMessageRight);
                holder.videoThumb = (ImageView) vi.findViewById(R.id.imageViewOneOnOneVideoMessageRight);
                holder.videoMessageButton = (ImageView) vi.findViewById(R.id.imageViewOneOnOneVideoMessageButton);
                holder.normalMessageContainer = (RelativeLayout) vi
                        .findViewById(R.id.linearLayoutParentOneOnOneMessageRightContainer);
                holder.avchatMessageContainer = (RelativeLayout) vi
                        .findViewById(R.id.relativeLayoutAVchatMessageContainer);
                holder.avchatMessageTimeStamp = (TextView) vi.findViewById(R.id.textViewAVchatMessageTimeStamp);
                holder.avchatMessage = (TextView) vi.findViewById(R.id.textViewAVchatMessage);
                holder.messageArrow = vi.findViewById(R.id.rightArrow);
                holder.wheel = (ProgressBar) vi.findViewById(R.id.progressWheelVideo);
                holder.avatar = (RoundedImageView) vi.findViewById(R.id.imageViewUserAvatar);
                holder.messageTick = (ImageView) vi.findViewById(R.id.imageviewMessageTick);
                holder.customImageHolder = (ImageView) vi.findViewById(R.id.customImageViewOneOnOneImageMessageRight);
                holder.audioNoteContainer = (RelativeLayout) vi.findViewById(R.id.relativeLayoutAudioNoteContainer);
                holder.audioPlayButton = (ImageView) vi.findViewById(R.id.imageViewPlayIcon);
                holder.tvOnlySmiley = (EmojiTextView) vi.findViewById(R.id.textViewOneOnOneMessageSmileyRight);
                holder.audioTime = (TextView) vi.findViewById(R.id.textViewTime);
                holder.audioSeekbar = (SeekBar) vi.findViewById(R.id.seek_bar);

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(rightBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawable.setColor(Color.parseColor(rightBubbleColor));

                holder.message.setTextColor(Color.parseColor(rightBubbleTextColor));
                holder.audioTime.setTextColor(Color.parseColor(rightBubbleTextColor));
                if (null != mobileTheme && null != mobileTheme.getRightBubbleTimestampColor()) {
                    holder.messageTimestamp.setTextColor(Color.parseColor(mobileTheme.getRightBubbleTimestampColor()));
                }
            } else {
                vi = LayoutInflater.from(getContext()).inflate(R.layout.cc_custom_chat_message_one_on_one_left, parent,
                        false);
                holder.message = (EmojiTextView) vi.findViewById(R.id.textViewOneToOneMessageLeft);
                holder.messageTimestamp = (TextView) vi.findViewById(R.id.textViewOneOnOneTimestampLeft);
                holder.imageHolder = (ImageView) vi.findViewById(R.id.imageViewOneOnOneImageMessageLeft);
                holder.videoThumb = (ImageView) vi.findViewById(R.id.imageViewOneOnOneVideoMessageLeft);
                holder.videoMessageButton = (ImageView) vi.findViewById(R.id.imageViewOneOnOneVideoMessageButton);
                holder.normalMessageContainer = (RelativeLayout) vi
                        .findViewById(R.id.linearLayoutParentOneOnOneMessageLeftContainer);
                holder.avchatMessageContainer = (RelativeLayout) vi
                        .findViewById(R.id.relativeLayoutAVchatMessageContainer);
                holder.avchatMessageTimeStamp = (TextView) vi.findViewById(R.id.textViewAVchatMessageTimeStamp);
                holder.avchatMessage = (TextView) vi.findViewById(R.id.textViewAVchatMessage);
                holder.messageArrow = vi.findViewById(R.id.leftArrow);
                holder.wheel = (ProgressBar) vi.findViewById(R.id.progressWheelVideo);
                holder.avatar = (RoundedImageView) vi.findViewById(R.id.imageViewUserAvatar);
                holder.messageTick = (ImageView) vi.findViewById(R.id.imageviewMessageTick);
                holder.customImageHolder = (ImageView) vi.findViewById(R.id.customImageViewOneOnOneImageMessageLeft);
                holder.tvOnlySmiley = (EmojiTextView) vi.findViewById(R.id.textViewOneOnOneMessageSmileyLeft);
                holder.audioNoteContainer = (RelativeLayout) vi.findViewById(R.id.relativeLayoutAudioNoteContainer);
                holder.audioPlayButton = (ImageView) vi.findViewById(R.id.imageViewPlayIcon);
                holder.audioTime = (TextView) vi.findViewById(R.id.textViewTime);
                holder.audioSeekbar = (SeekBar) vi.findViewById(R.id.seek_bar);

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(leftBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawable.setColor(Color.parseColor(leftBubbleColor));

                holder.message.setTextColor(Color.parseColor(leftBubbleTextColor));
                holder.audioTime.setTextColor(Color.parseColor(leftBubbleTextColor));
                if (null != mobileTheme && null != mobileTheme.getLeftBubbleTimestampColor()) {
                    holder.messageTimestamp.setTextColor(Color.parseColor(mobileTheme.getLeftBubbleTimestampColor()));
                }
            }
            vi.setTag(holder);
        } else {
            holder = (Holder) vi.getTag();
            if (null == mobileTheme) {
                mobileTheme = JsonPhp.getInstance().getMobileTheme();
            }
            if (null != mobileTheme && null != mobileTheme.getLeftBubbleColor() && null != mobileTheme.getRightBubbleColor()) {
                //leftBubbleColor = mobileTheme.getLeftBubbleColor();
                leftBubbleColor = "#e6e9ed";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            } else {
                leftBubbleColor = "#e6e9ed";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            }
            if (getItemViewType(position) == TYPE_RIGHT) {
                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(rightBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawable.setColor(Color.parseColor(rightBubbleColor));

            } else {
                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(leftBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawable.setColor(Color.parseColor(leftBubbleColor));
            }
        }

        final OneOnOneMessage message = getItem(position);

        holder.messageArrow.setVisibility(View.VISIBLE);
        holder.messageTick.setVisibility(View.VISIBLE);
        if (!CometChatKeys.MessageTypeKeys.AVCHAT.equals(message.type)) {
            if (getItemViewType(position) == TYPE_RIGHT) {
                if (showticks) {
                    switch (message.messagetick) {
                        case CometChatKeys.MessageTypeKeys.MESSAGE_SENT:
                            holder.messageTick.setImageResource(R.drawable.cc_iconsent);
                            break;
                        case CometChatKeys.MessageTypeKeys.MESSAGE_DELIVERD:
                            holder.messageTick.setImageResource(R.drawable.cc_icondeliverd);
                            break;
                        case CometChatKeys.MessageTypeKeys.MESSAGE_READ:
                            holder.messageTick.setImageResource(R.drawable.cc_iconread);
                            break;
                        default:
                            holder.messageTick.setImageResource(R.drawable.cc_iconsent);
                            break;
                    }
                } else {
                    holder.messageTick.setVisibility(View.GONE);
                }
            } else {
                holder.messageTick.setVisibility(View.GONE);
            }
        }
        String avatarUrl = "";
        holder.message.setAutoLinkMask(Linkify.ALL);
        Logger.error("One-on-One message type = "+message.type);
        switch (message.type) {
            case CometChatKeys.MessageTypeKeys.NORMAL:
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }

                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }
                }
                if (!TextUtils.isEmpty(avatarUrl)) {
                   /* LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                if (message.insertedBy == 1) {
                /* Message inserted by ajax response */
                    if (Stickers.isSticker(message.message)) {
                        holder.message.setText(Stickers.handleSticker(message.message));
                    } else {
                        if (message.message.contains("<img class=\"cometchat_smiley\"")) {
                            Spannable spannable = Smilies.convertImageTagToEmoji(message.message, context, false,
                                    R.drawable.class);
                            if(EmoticonUtils.isOnlySmileyHtmlSmiley(spannable)){
                                holder.message.setVisibility(View.GONE);
                                holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                                holder.tvOnlySmiley.setText(spannable);
                                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable.findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                                shape.setColor(Color.parseColor("#00000000"));
                                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                                drawable.setColor(Color.parseColor("#00000000"));
                            }else{
                                holder.message.setText(spannable);
                            }
                        } else {

                            if(EmoticonUtils.isOnlySmileyMessage(message.message)){
                                holder.message.setVisibility(View.GONE);
                                holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                                holder.tvOnlySmiley.setEmojiText(message.message);
                                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                                shape.setColor(Color.parseColor("#00000000"));
                                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                                drawable.setColor(Color.parseColor("#00000000"));
                            }else{
                                holder.message.setEmojiText(message.message);
                            }
                        }
                    }
                } else {
                    if (message.message.contains("<img class=\"cometchat_smiley\"")) {
                        Spannable spannable = Smilies.convertImageTagToEmoji(message.message, context, false,
                                R.drawable.class);
                        if(EmoticonUtils.isOnlySmileyHtmlSmiley(spannable)){
                            holder.message.setVisibility(View.GONE);
                            holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                            holder.tvOnlySmiley.setText(spannable);
                            LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                            GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable.findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                            shape.setColor(Color.parseColor("#00000000"));
                            GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                            drawable.setColor(Color.parseColor("#00000000"));
                        }else{
                            holder.message.setText(spannable);
                        }

                    } else if (Stickers.isSticker(message.message)) {
                        holder.message.setText(Stickers.handleSticker(message.message));
                    } else {
                        holder.message.setText(message.message);
                    }
                }
                break;


            case CometChatKeys.MessageTypeKeys.BOT_RESPONCE:
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                try {
                    JSONObject botMessageJson = new JSONObject(message.message);
                    Bot bot = Bot.getBotDetails(botMessageJson.getString("botid"));
                    if(bot!= null && bot.botAvatar!= null)
                        LocalStorageFactory.LoadImageUsingURL(context,bot.botAvatar,holder.avatar,R.drawable.cc_default_avatar);

                    switch (botMessageJson.getString("messagetype")){

                        case "image":
                            Document doc = Jsoup.parseBodyFragment(botMessageJson.getString("message"));
                            Element imageElement = doc.select("img").first();
                            final String absoluteUrl = imageElement.absUrl("src");
                            holder.customImageHolder.setVisibility(View.VISIBLE);
                            holder.message.setVisibility(View.GONE);

                            LayerDrawable ldrawableImage = (LayerDrawable) holder.messageArrow.getBackground();
                            GradientDrawable shapeImage = ((GradientDrawable) ((RotateDrawable) (ldrawableImage
                                    .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                            shapeImage.setColor(Color.parseColor("#00000000"));
                            GradientDrawable drawableImage = (GradientDrawable) holder.normalMessageContainer.getBackground();
                            drawableImage.setColor(Color.parseColor("#00000000"));

                            Glide.with(context)
                                    .load(absoluteUrl)
                                    .asGif()
                                    .fitCenter()
                                    .centerCrop()
                                    .placeholder(R.drawable.cc_thumbnail_default)
                                    .into(holder.customImageHolder);

                            holder.customImageHolder.setOnClickListener(new OnClickListener() {

                                @Override
                                public void onClick(View v) {
                                    try {
                                        Intent intent = new Intent(context, ImagePreviewActivity.class);
                                        intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, absoluteUrl);
                                        context.startActivity(intent);
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }
                            });
                            break;

                        case "anchor":
                            String temp = botMessageJson.getString("message");
                            CommonUtils.renderHtmlInATextView(context,holder.message,temp);
                            break;

                        default:
                            holder.message.setText(botMessageJson.getString("message"));
                            break;
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }

                break;
            case CometChatKeys.MessageTypeKeys.IMAGE_NEW:
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.message.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                //holder.imageHolder.setImageDrawable(context.getResources().getDrawable(R.drawable.thumbnail_default));


                final Holder finalHolder = holder;
                /*holder.wheel.setBarColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));
                holder.wheel.setBarWidth(20);*/
                /*
                LocalStorageFactory.getPicassoInstance().load(message.imageUrl).placeholder(R.drawable.thumbnail_default)
                        .resize(55, 55).into(holder.imageHolder, new Callback() {
                    @Override
                    public void onSuccess() {
                        finalHolder.wheel.setVisibility(View.GONE);
                    }

                    @Override
                    public void onError() {
                    }
                });*/

                Glide.with(context)
                        .load(message.imageUrl)
                        .listener(new RequestListener<String, GlideDrawable>() {
                            @Override
                            public boolean onException(Exception e, String model, Target<GlideDrawable> target, boolean isFirstResource) {
                                return false;
                            }

                            @Override
                            public boolean onResourceReady(GlideDrawable resource, String model, Target<GlideDrawable> target, boolean isFromMemoryCache, boolean isFirstResource) {
                                finalHolder.wheel.setVisibility(View.GONE);

                                LayerDrawable ldrawableImage = (LayerDrawable) finalHolder.messageArrow.getBackground();
                                GradientDrawable shapeImage = ((GradientDrawable) ((RotateDrawable) (ldrawableImage
                                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                                shapeImage.setColor(Color.parseColor("#00000000"));
                                GradientDrawable drawableImage = (GradientDrawable) finalHolder.normalMessageContainer.getBackground();
                                drawableImage.setColor(Color.parseColor("#00000000"));

                                finalHolder.customImageHolder.setVisibility(View.VISIBLE);
                                finalHolder.imageHolder.setVisibility(View.GONE);

                                return false;
                            }
                        })
                        .fitCenter()
                        .centerCrop()
                        .override(1000,1000)
                        .placeholder(R.drawable.cc_thumbnail_default)
                        .into(holder.customImageHolder);


                /*holder.imageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            Intent intent = new Intent(context, ImagePreviewActivity.class);
                            intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, message.message);
                            context.startActivity(intent);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });*/

                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.cc_default_avatar)
                            .resize(55, 55).into(holder.avatar);

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                break;
            case CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED:
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.message.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                //holder.imageHolder.setBackground(context.getDrawable(R.drawable.custom_downloaded_image_background));



                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }


                LayerDrawable ldrawableImage = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shapeImage = ((GradientDrawable) ((RotateDrawable) (ldrawableImage
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shapeImage.setColor(Color.parseColor("#00000000"));
                GradientDrawable drawableImage = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawableImage.setColor(Color.parseColor("#00000000"));

                File file_downloaded = new File(message.message);
                /* If image already present in directory then show it directly */
                if (file_downloaded.exists()) {
                    try {

                        Bitmap bitmap = BitmapProcessingHelper.getRoundedCroppedBitmap(BitmapFactory.decodeFile(message.message, options),50);

                        //holder.imageHolder.setImageBitmap(BitmapFactory.decodeFile(message.message, options));
                        holder.customImageHolder.setImageBitmap(bitmap);

                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                } else {
                /* Download and display image */
                    LocalStorageFactory.saveIncomingImage(message.message.substring(message.message.lastIndexOf("/") + 1),
                            message.imageUrl, null, false, String.valueOf(message.remoteId), false);
                }

                holder.customImageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            Intent intent = new Intent(context, ImagePreviewActivity.class);
                            intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, message.message);
                            context.startActivity(intent);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });

                break;
            case CometChatKeys.MessageTypeKeys.HANDWRITE_NEW:
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setImageDrawable(context.getResources().getDrawable(R.drawable.cc_thumbnail_default));

                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                   /* LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                final String[] handwriteMess = message.message.split("\\|");

                Logger.error("HandwriteMess  = "+message.message);
                holder.imageHolder.setVisibility(View.VISIBLE);
                holder.message.setText(handwriteMess[0]);
                holder.imageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            Intent intent = new Intent(context, ImagePreviewActivity.class);
                            intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, handwriteMess[1]);
                            context.startActivity(intent);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });

                break;
            case CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED:
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.VISIBLE);
                final String[] handwriteMessDownloaded = message.message.split("\\|");
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                holder.message.setText(handwriteMessDownloaded[0]);

                File handwritefile = new File(handwriteMessDownloaded[1]);
                /* If image already present in directory then show it directly */
                if (handwritefile.exists()) {
                    try {
                        holder.imageHolder.setImageBitmap(BitmapFactory.decodeFile(handwriteMessDownloaded[1], options));
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                } else {
                /* Download and display image */
                    LocalStorageFactory.saveIncomingImage(
                            handwriteMessDownloaded[1].substring(handwriteMessDownloaded[1].lastIndexOf("/") + 1),
                            message.imageUrl, holder.imageHolder, false, String.valueOf(message.remoteId), true);
                }

                holder.imageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            Intent intent = new Intent(context, ImagePreviewActivity.class);
                            intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, handwriteMessDownloaded[1]);
                            context.startActivity(intent);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });

                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_NEW:
                holder.message.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                final ProgressBar wheel = holder.wheel;
                wheel.setVisibility(View.GONE);

                final ImageView vMessageButton = holder.videoMessageButton;
                vMessageButton.setImageResource(R.drawable.cc_download_video_button);
                vMessageButton.setVisibility(View.VISIBLE);

                holder.videoThumb.setImageResource(R.drawable.cc_thumbnail_default);
                holder.videoThumb.setVisibility(View.VISIBLE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                OnClickListener videoClickListener = new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            VideoSharing.downloadAndStoreVideo(String.valueOf(message.remoteId), message.message, false, false);
                            wheel.setVisibility(View.VISIBLE);
                            vMessageButton.setVisibility(View.GONE);
                            message.type = CometChatKeys.MessageTypeKeys.VIDEO_IS_DOWNLOADING;
                            message.save();
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };

                holder.videoThumb.setOnClickListener(videoClickListener);
                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_DOWNLOADED:
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                File video = new File(message.message);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.audioNoteContainer.setVisibility(View.GONE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                if (video.exists()) {
                    holder.message.setVisibility(View.GONE);
                    holder.imageHolder.setVisibility(View.GONE);
                    holder.wheel.setVisibility(View.GONE);
                    holder.tvOnlySmiley.setVisibility(View.GONE);
                    holder.videoMessageButton.setImageResource(R.drawable.cc_play_video_button);
                    holder.videoMessageButton.setVisibility(View.VISIBLE);
                    holder.videoThumb.setVisibility(View.VISIBLE);
                    holder.customImageHolder.setVisibility(View.GONE);
                    if (videoThumbnails.get(message.id) == null) {
                        Cursor c = null;
                        try {
                            BitmapFactory.Options videoOptions = new BitmapFactory.Options();
                            videoOptions.inPreferredConfig = Bitmap.Config.RGB_565;
                            videoOptions.inSampleSize = 2;
                            Uri videoUri = MediaStore.Video.Media.EXTERNAL_CONTENT_URI;
                            String[] requierddata = {BaseColumns._ID};
                            c = context.getContentResolver().query(videoUri, requierddata,
                                    MediaColumns.DATA + " like  \"" + message.message + "\"", null, null);
                            c.moveToFirst();
                            if (c != null && c.getCount() != 0) {
                                Bitmap bmp = MediaStore.Video.Thumbnails.getThumbnail(context.getContentResolver(),
                                        c.getLong(0), MediaStore.Video.Thumbnails.MINI_KIND, videoOptions);
                                holder.videoThumb.setImageBitmap(bmp);
                                videoThumbnails.put(message.id, bmp);
                            } else {
                                Bitmap bmp = ThumbnailUtils.createVideoThumbnail(message.message,
                                        MediaStore.Video.Thumbnails.MINI_KIND);
                                holder.videoThumb.setImageBitmap(bmp);
                                videoThumbnails.put(message.id, bmp);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        } finally {
                            if (c != null && !c.isClosed()) {
                                c.close();
                            }
                        }
                    } else {
                        holder.videoThumb.setImageBitmap(videoThumbnails.get(message.id));
                    }

                    OnClickListener videoClickListener1 = new OnClickListener() {

                        @Override
                        public void onClick(View v) {
                            try {
                                FileOpenIntentHelper.openFile(v.getContext(), message.message);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    };

                    holder.videoThumb.setOnClickListener(videoClickListener1);
                } else {
                    // mess + " url = " + message.getImageUrl());
                    holder.imageHolder.setVisibility(View.GONE);
                    holder.message.setVisibility(View.VISIBLE);
                    holder.message.setText("File not found!");
                    final ProgressBar wheel2 = holder.wheel;
                    wheel2.setVisibility(View.GONE);

                    final ImageView vMessageButton1 = holder.videoMessageButton;
                    vMessageButton1.setImageResource(R.drawable.cc_download_video_button);
                    vMessageButton1.setVisibility(View.VISIBLE);

                    // holder.videoThumb.setImageResource(R.drawable.imageview_placeholder);
                    // holder.videoThumb.setVisibility(View.VISIBLE);

                    OnClickListener videoClickListener1 = new OnClickListener() {

                        @Override
                        public void onClick(View v) {
                            try {
                                VideoSharing.downloadAndStoreVideo(String.valueOf(message.remoteId), message.imageUrl,
                                        false, false);
                                wheel2.setVisibility(View.VISIBLE);
                                vMessageButton1.setVisibility(View.GONE);
                                message.type = CometChatKeys.MessageTypeKeys.VIDEO_IS_DOWNLOADING;
                                message.save();
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    };

                    holder.videoMessageButton.setOnClickListener(videoClickListener1);
                }

                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_IS_DOWNLOADING:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.videoThumb.setImageResource(R.drawable.cc_thumbnail_default);
                holder.videoThumb.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }

                holder.wheel.setVisibility(View.VISIBLE);
                holder.videoMessageButton.setVisibility(View.GONE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_UPLOAD:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

			/*
             * if (null == holder.videoThumb.getTag()) { Bitmap bmp =
			 * ThumbnailUtils.createVideoThumbnail(message.message,
			 * MediaStore.Images.Thumbnails.MINI_KIND);
			 * holder.videoThumb.setImageBitmap(bmp);
			 * holder.videoThumb.setTag(bmp); } else {
			 * holder.videoThumb.setImageBitmap((Bitmap)
			 * holder.videoThumb.getTag()); }
			 *
			 * holder.videoThumb.setVisibility(View.VISIBLE);
			 */
                ProgressBar wheel3 = holder.wheel;
                wheel3.setVisibility(View.VISIBLE);

                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_UPLOAD:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);

                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_NEW:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.avchatMessageContainer.setVisibility(View.GONE);

                holder.audioNoteContainer.setVisibility(View.VISIBLE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_IS_DOWNLOADING:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);

                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED:
                holder.message.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);

                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                final TextView audioText = holder.audioTime;
                final SeekBar audioSeekBar = holder.audioSeekbar;
                final ImageView playBtn = holder.audioPlayButton;


                audioSeekBar.getProgressDrawable().setColorFilter(Color.WHITE, PorterDuff.Mode.SRC_ATOP);
                if (android.os.Build.VERSION.SDK_INT >= 16){
                    audioSeekBar.getThumb().setColorFilter(Color.WHITE, PorterDuff.Mode.SRC_ATOP);
                }


                if (message.id == currentlyPlayingId) {
                    setBtnColor(position, holder.audioPlayButton, false);
                } else {
                    setBtnColor(position, holder.audioPlayButton, true);
                    if (audioDurations.get(message.id) == null) {
                        player.reset();
                        try {
                            File file = new File(message.message);
                            if (file.exists()) {
                                player.setDataSource(message.message);
                                player.prepare();
                            } else {
                                AudioSharing.downloadAndStoreAudio(String.valueOf(message.remoteId), message.imageUrl, false);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                        int audioDuration = player.getDuration();
                        audioDurations.put(message.id, audioDuration);
                        holder.audioTime.setText(CommonUtils.convertTimeStampToDurationTime(audioDuration));
                        //audioSeekBar.setMax(audioDuration);
                        audioSeekBar.setProgress(0);
                    } else {
                        int time = audioDurations.get(message.id);
                        holder.audioTime.setText(CommonUtils.convertTimeStampToDurationTime(time));
                        //audioSeekBar.setMax(time);
                        audioSeekBar.setProgress(0);
                    }
                }

                holder.audioPlayButton.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        if (!TextUtils.isEmpty(message.message)) {
                            try {
                                if (message.id == currentlyPlayingId) {
                                    currentPlayingSong = "";
                                    currentlyPlayingId = 0l;
                                    player.stop();
                                    player.reset();
                                    setBtnColor(position, playBtn, true);
                                    try {
                                        player.setDataSource(message.message);
                                        player.prepare();
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }

                                    int audioDuration = player.getDuration();
                                    audioText.setText(CommonUtils.convertTimeStampToDurationTime(audioDuration));
                                    audioSeekBar.setMax(audioDuration);
                                    audioSeekBar.setProgress(player.getCurrentPosition());
                                } else {
                                    playAudio(message.message, message.id, playBtn, player, position, audioText, audioSeekBar);
                                }
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        }
                    }
                });

                break;
            case CometChatKeys.MessageTypeKeys.FILE_NEW:
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.message.setVisibility(View.VISIBLE);
                holder.message.setText(createDownlodLink(message));
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADING:
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.message.setText(createDownlodLink(message));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }


                holder.wheel.setVisibility(View.VISIBLE);
                holder.videoMessageButton.setVisibility(View.GONE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADED:
                final String mess = message.message.substring(0, message.message.indexOf((").")) + 2);
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.message.setAutoLinkMask(Linkify.PHONE_NUMBERS);
                holder.message.setText(mess);
                holder.imageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }

                holder.wheel.setVisibility(View.GONE);


                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                holder.message.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        String path = message.message;
                        path = path.split("#")[1].trim();
                        //Logger.error("path =" + path);
                        try {
                            FileOpenIntentHelper.openFile(v.getContext(), path);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                    }
                });
                break;
            case CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST:
                holder.message.setVisibility(View.VISIBLE);
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.message.setText(createViewLink(message, 1));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.SCREENSHARE_REQUEST:
                holder.message.setVisibility(View.VISIBLE);
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.message.setText(createViewLink(message, 3));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.JOIN_CHATROOM_MESSAGE:
            /* Add clickable text if the message is join chatroom message */
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.message.setVisibility(View.VISIBLE);
                holder.message.setText(clickableText(message.message));
                holder.customImageHolder.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.AVCHAT:
                holder.normalMessageContainer.setVisibility(View.GONE);
                holder.avchatMessageContainer.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.messageArrow.setVisibility(View.GONE);
                holder.messageTick.setVisibility(View.GONE);
                holder.messageTimestamp.setVisibility(View.GONE);
                holder.avchatMessage.setText(processAVchatCallerName(message.message));
                holder.avchatMessageTimeStamp.setText(CommonUtils.convertTimestampToDate(message.sentTimestamp));
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                break;

            case CometChatKeys.MessageTypeKeys.WRITEBOARD_REQUEST:
                holder.message.setVisibility(View.VISIBLE);
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.message.setText(createViewLink(message, 2));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }
                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                break;

            case CometChatKeys.MessageTypeKeys.AVBROADCAST:
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }

                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);

                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                holder.message.setMovementMethod(LinkMovementMethod.getInstance());
                holder.message.setText(AVBroadcastText(message.message, message.fromId));

                break;
            case CometChatKeys.MessageTypeKeys.STICKERS:
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }
                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);

                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }
                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor("#00000000"));
                GradientDrawable drawable = (GradientDrawable) holder.normalMessageContainer.getBackground();
                drawable.setColor(Color.parseColor("#00000000"));

                holder.message.setText(Stickers.handleSticker(message.message));
                break;

            default:
                // Normal message
                holder.message.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                }

                holder.normalMessageContainer.setVisibility(View.VISIBLE);
                holder.avchatMessageContainer.setVisibility(View.GONE);
                avatarUrl = "";
                if (message.self == 1) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }

                }
                if (!avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.cc_default_avatar);
                }
                if (message.insertedBy == 1) {
                /* Message inserted by ajax response */
                    holder.message.setEmojiText(message.message);
                } else {
                    holder.message.setText(Smilies
                            .convertImageTagToEmoji(message.message, context, false, R.drawable.class));
                }
                break;
        }
        if (message.type.equals(CometChatKeys.MessageTypeKeys.AVCHAT)) {
            holder.messageTimestamp.setVisibility(View.GONE);
        } else {
            holder.messageTimestamp.setVisibility(View.VISIBLE);
            holder.messageTimestamp.setText(CommonUtils.convertTimestampToDate(message.sentTimestamp));
        }
        return vi;
    }

    private SpannableString createViewLink(final OneOnOneMessage message, int flag) {
        /**
         * flag : decides which type of request
         * If 1, used for whiteboard
         * If 2, used for writeboard
         * if 3, used for screenshare
         */
        final String mess = message.message;
        if (flag == 1) {
            int startIndex = mess.indexOf("."), endIndex = mess.indexOf("|#|");
            final SpannableString whiteboardrequest = new SpannableString(mess.substring(0, endIndex));
            try {
                final String room = mess.substring(endIndex + 3, mess.length());
                ClickableSpan span = new ClickableSpan() {
                    @Override
                    public void onClick(View widget) {
                        VolleyHelper vhelper = new VolleyHelper(context, URLFactory.getWhiteBoardURL(), new VolleyAjaxCallbacks() {
                            @Override
                            public void successCallback(String response) {
                                Intent i = new Intent(context, WhiteboardActivity.class);
                                i.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.ROOM_NAME, room);
                                context.startActivity(i);
                            }

                            @Override
                            public void failCallback(String response, boolean isNoInternet) {

                            }
                        });
                        vhelper.addNameValuePair(CometChatKeys.AjaxKeys.ACTION, CometChatKeys.AjaxKeys.ACTION_ACCEPT);
                        vhelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, message.fromId);
                        vhelper.sendAjax();
                    }
                };

                whiteboardrequest.setSpan(span, startIndex + 1, endIndex, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
            } catch (Exception e) {
                e.printStackTrace();
            }

            return whiteboardrequest;
        } else if (flag == 2) {
            int startIndex = mess.indexOf("."), endIndex = mess.indexOf("|#|");
            final SpannableString writeboardrequest = new SpannableString(mess.substring(0, endIndex));
            try {
                final String rand = mess.substring(endIndex + 3, mess.length());
                ClickableSpan span = new ClickableSpan() {
                    @Override
                    public void onClick(View widget) {
                        Intent intent = new Intent(getContext(), WriteBoardActivity.class);
                        intent.putExtra("randomId", rand);
                        context.startActivity(intent);
                    }
                };

                writeboardrequest.setSpan(span, startIndex + 1, endIndex, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

            } catch (Exception e) {
                e.printStackTrace();
            }
            return writeboardrequest;
        } else if (flag == 3) {
            int startIndex = mess.indexOf("."), endIndex = mess.indexOf("|#|");
            final SpannableString screensharerequest = new SpannableString(mess.substring(0, endIndex));
            try {
                final String rand = mess.substring(endIndex + 3, mess.length());
                ClickableSpan span = new ClickableSpan() {
                    @Override
                    public void onClick(View widget) {
                        Intent intent = new Intent(getContext(), VideoChatActivity.class);
                        intent.putExtra(StaticMembers.SCREENSHARE_MODE, true);
                        intent.putExtra(StaticMembers.INTENT_ROOM_NAME, rand);
                        intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, false);
                        intent.putExtra(StaticMembers.INTENT_AUDIO_FLAG, false);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, String.valueOf(message.fromId));
                        intent.putExtra(StaticMembers.INTENT_AVBROADCAST_FLAG, true);
                        intent.putExtra(StaticMembers.INTENT_IAMBROADCASTER_FLAG, false);
                        context.startActivity(intent);
                    }
                };

                screensharerequest.setSpan(span, startIndex + 1, endIndex, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

            } catch (Exception e) {
                e.printStackTrace();
            }
            return screensharerequest;
        }
        return null;

    }

    private Spannable AVBroadcastText(final String message, final Long buddyId) {
        final String data[] = message.split("##");

        Chatrooms chatroom = JsonPhp.getInstance().getLang().getChatrooms();
        String messageText;
        if (null == chatroom) {
            messageText = data[0] + "\nJoin";
        } else {
            messageText = data[0] + "\n" + chatroom.get19();
        }

        final SpannableString avbroadcastMessage = new SpannableString(messageText);

        ClickableSpan clickable = new ClickableSpan() {
            @Override
            public void onClick(View widget) {
                Intent intent = new Intent(context, VideoChatActivity.class);
                intent.putExtra(StaticMembers.INTENT_ROOM_NAME, data[1]);
                intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, false);
                intent.putExtra(StaticMembers.INTENT_AUDIO_FLAG, false);
                intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, String.valueOf(buddyId));
                intent.putExtra(StaticMembers.INTENT_AVBROADCAST_FLAG, true);
                intent.putExtra(StaticMembers.INTENT_IAMBROADCASTER_FLAG, false);
                context.startActivity(intent);
            }
        };

        avbroadcastMessage.setSpan(clickable, data[0].length(), messageText.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

        return avbroadcastMessage;
    }


    private Spannable clickableText(final String messageText) {
        try {
            String roomKeys[] = messageText.split(",");
            final String roomId = roomKeys[0];
            final String roomName = roomKeys[1];
            if (roomKeys[2].equals("#") && roomKeys[2].length() == 1) {
                roomKeys[2] = " ";
            }
            final String roomPassword = roomKeys[2];
            Chatrooms chatroom = JsonPhp.getInstance().getLang().getChatrooms();
            String message;
            int startIndex;
            if (null != chatroom) {
                message = chatroom.get18().replace(".", "") + roomName + ".\n" + chatroom.get19();
                startIndex = (chatroom.get18().length() + roomName.length() + 1);
            } else {
                String substring[] = CometChatKeys.ChatroomKeys.JOIN_REQUEST_MESSAGE.split("\\.");
                message = substring[0] + " " + roomName + "." + substring[1];
                startIndex = substring[0].length() + roomName.length() + 3;
            }
            SpannableString joinChatroomString = new SpannableString(message);

            ClickableSpan clickableSpan = new ClickableSpan() {
                @Override
                public void onClick(View textView) {
                    if (roomId != null && roomName != null && roomPassword != null) {
                        try {
                            final ProgressDialog progressDialog = ProgressDialog.show(context, "", JsonPhp.getInstance()
                                    .getLang().getMobile().get30());
                            progressDialog.setCancelable(false);
                            ChatroomManager.joinChatroom(Long.parseLong(roomId), roomName, roomPassword, 1, context,
                                    new CometchatCallbacks() {

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
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                }
            };
            joinChatroomString.setSpan(clickableSpan, startIndex, joinChatroomString.length(),
                    Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
            return joinChatroomString;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return new SpannableString(messageText);
    }

    private Spannable processAVchatCallerName(String messageText) {
        Avchat avchatjson = JsonPhp.getInstance().getLang().getAvchat();
        Audiochat audiochat = JsonPhp.getInstance().getLang().getAudiochat();
        SpannableString AVchatString = new SpannableString(messageText);
        final StyleSpan boldStyle = new StyleSpan(android.graphics.Typeface.BOLD);
        int startIndex = messageText.length(), endIndex = messageText.length();
        if (avchatjson != null) {
            if (messageText.contains(avchatjson.get29())) {
                startIndex = avchatjson.get29().length();
            } else if (messageText.contains(avchatjson.get30())) {
                startIndex = avchatjson.get30().length();
                if (messageText.contains(avchatjson.get32())) {
                    endIndex = messageText.indexOf(avchatjson.get32());
                } else if (messageText.contains(avchatjson.get34())) {
                    endIndex = messageText.indexOf(avchatjson.get34());
                } else if (messageText.contains(avchatjson.get36())) {
                    endIndex = messageText.indexOf(avchatjson.get36());
                }
            } else if (messageText.contains(avchatjson.get31())) {
                startIndex = messageText.length();
            } else if (messageText.contains(avchatjson.get33())) {
                startIndex = avchatjson.get34().length();
            }
        }

        if (audiochat != null) {
            if (messageText.contains(audiochat.get29())) {
                startIndex = audiochat.get29().length();
            } else if (messageText.contains(audiochat.get30())) {
                startIndex = audiochat.get30().length();
                if (messageText.contains(audiochat.get32())) {
                    endIndex = messageText.indexOf(audiochat.get32());
                } else if (messageText.contains(audiochat.get34())) {
                    endIndex = messageText.indexOf(audiochat.get34());
                } else if (messageText.contains(audiochat.get36())) {
                    endIndex = messageText.indexOf(audiochat.get36());
                }
            } else if (messageText.contains(audiochat.get31())) {
                startIndex = messageText.length();
            } else if (messageText.contains(audiochat.get33())) {
                startIndex = avchatjson.get34().length();
            }
        }
        AVchatString.setSpan(boldStyle, startIndex, endIndex, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        return AVchatString;
    }

    private Spannable createDownlodLink(final OneOnOneMessage message) {
        String originalMessage = message.message;
        String mess = originalMessage.substring(0, originalMessage.indexOf((").")) + 2);
        Filetransfer filetranslangs = JsonPhp.getInstance().getLang().getFiletransfer();
        if (filetranslangs == null) {
            mess += "\nClick here to download the file";
        } else {
            mess += "\n" + filetranslangs.get6();
        }
        SpannableString downloadLink = new SpannableString(mess);

        ClickableSpan clickableSpan = new ClickableSpan() {
            @Override
            public void onClick(View textView) {
                message.type = CometChatKeys.MessageTypeKeys.FILE_DOWNLOADING;
                message.save();
                notifyDataSetChanged();
                VideoSharing.downloadAndStoreVideo(String.valueOf(message.remoteId), message.imageUrl, false, true);
            }
        };
        int startIndex = mess.indexOf("\n") + 1;
        downloadLink.setSpan(clickableSpan, startIndex, mess.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        return downloadLink;

    }

    public void setBtnColor(int position, ImageView playbtn, boolean isPlayBtn) {
        if (getItemViewType(position) == TYPE_RIGHT) {
            if (isPlayBtn) {
                playbtn.setBackgroundResource(R.drawable.cc_play);
            } else {
                playbtn.setBackgroundResource(R.drawable.cc_pause);
            }
            playbtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor(rightBubbleTextColor)));
        } else {
            if (isPlayBtn) {
                playbtn.setBackgroundResource(R.drawable.cc_play_left);
            } else {
                playbtn.setBackgroundResource(R.drawable.cc_pause);
            }
            playbtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor(leftBubbleTextColor)));

        }
    }

    public void playAudio(String message, final long messageid, final ImageView playBtn, final MediaPlayer player, final int position, final TextView audioText, final SeekBar audioSeekBar) {
        try {
            currentPlayingSong = message;
            currentlyPlayingId = messageid;
            if (timerRunnable != null) {
                seekHandler
                        .removeCallbacks(timerRunnable);
                timerRunnable = null;
            }
            setBtnColor(position, playBtn, false);
            player.reset();
            player.setDataSource(currentPlayingSong);
            player.prepare();
            player.start();

            final int duration = player.getDuration();
            audioSeekBar.setMax(duration);
            timerRunnable = new Runnable() {
                @Override
                public void run() {

                    int pos = player.getCurrentPosition();
                    audioSeekBar.setProgress(pos);

                    if (player.isPlaying() && pos < duration) {
                        audioText.setText(CommonUtils.convertTimeStampToDurationTime(player.getCurrentPosition()));
                        seekHandler.postDelayed(this, 250);
                    } else {
                        seekHandler
                                .removeCallbacks(timerRunnable);
                        timerRunnable = null;
                    }
                }

            };
            seekHandler.postDelayed(timerRunnable, 100);
            notifyDataSetChanged();

            player.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
                @Override
                public void onCompletion(MediaPlayer mp) {
                    currentPlayingSong = "";
                    currentlyPlayingId = 0l;
                    setBtnColor(position, playBtn, true);
                    seekHandler
                            .removeCallbacks(timerRunnable);
                    timerRunnable = null;
                    mp.stop();
                    audioText.setText(CommonUtils.convertTimeStampToDurationTime(duration));
                    audioSeekBar.setProgress(0);
                }
            });

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void stopTimer() {
        if (timerRunnable != null) {
            seekHandler.removeCallbacks(timerRunnable);
            timerRunnable = null;
        }
    }

}
