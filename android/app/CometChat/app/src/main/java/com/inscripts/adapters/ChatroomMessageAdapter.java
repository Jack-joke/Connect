/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
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
import android.text.Html;
import android.text.Spannable;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.text.style.ClickableSpan;
import android.text.style.ForegroundColorSpan;
import android.text.util.Linkify;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.SeekBar;
import android.widget.TextView;

import com.inscripts.activities.ImagePreviewActivity;
import com.inscripts.activities.R;
import com.inscripts.activities.WhiteboardActivity;
import com.inscripts.activities.WriteBoardActivity;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.emoji.custom.EmojiTextView;
import com.inscripts.emoji.custom.EmoticonUtils;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.BitmapProcessingHelper;
import com.inscripts.helpers.FileOpenIntentHelper;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Chatrooms;
import com.inscripts.jsonphp.Filetransfer;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Bot;
import com.inscripts.models.Buddy;
import com.inscripts.models.ChatroomMessage;
import com.inscripts.plugins.AudioSharing;
import com.inscripts.plugins.Smilies;
import com.inscripts.plugins.Stickers;
import com.inscripts.plugins.VideoSharing;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;
import com.inscripts.videochat.VideoChatActivity;
import com.pnikosis.materialishprogress.ProgressWheel;

import org.json.JSONException;
import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

import java.io.File;
import java.util.List;

import se.emilsjolander.stickylistheaders.StickyListHeadersAdapter;

public class ChatroomMessageAdapter extends ArrayAdapter<ChatroomMessage> implements StickyListHeadersAdapter {

    private static final int TYPES_COUNT = 2;
    private static final int TYPE_LEFT = 0;
    private static final int TYPE_RIGHT = 1;
    private static final java.lang.String TAG = ChatroomMessageAdapter.class.getSimpleName();
    private BitmapFactory.Options options;
    private Context context;
    private static LongSparseArray<Bitmap> videoThumbnails;
    private static LongSparseArray<Integer> audioDurations;
    private String currentPlayingSong = "", leftBubbleTextColor, rightBubbleTextColor;
    MediaPlayer player;
    private Long currentPlayingSongId = 0l;
    private Runnable timerRunnable;
    Handler seekHandler = new Handler();
    static MobileTheme mobileTheme;

    public ChatroomMessageAdapter(Context context, List<ChatroomMessage> messageList) {
        super(context, 0, messageList);
        options = new BitmapFactory.Options();
        this.context = context;
        options.inPreferredConfig = Bitmap.Config.RGB_565;
        videoThumbnails = new LongSparseArray<>();
        audioDurations = new LongSparseArray<>();
        player = CommonUtils.getPlayerInstance();
    }

    @Override
    public void notifyDataSetChanged() {
        super.notifyDataSetChanged();
        if (getCount() == 0) {
            currentPlayingSong = "";
            currentPlayingSongId = 0l;
            audioDurations.clear();
        }
    }

    @Override
    public int getViewTypeCount() {
        return TYPES_COUNT;
    }

    @Override
    public int getItemViewType(int position) {
        ChatroomMessage message = getItem(position);

        if(message.type.equals(CometChatKeys.MessageTypeKeys.BOT_RESPONCE)){
            return TYPE_LEFT;
        }

        if (message.fromId == SessionData.getInstance().getId()) {
            return TYPE_RIGHT;
        }
        return TYPE_LEFT;
    }

    @Override
    public View getHeaderView(int position, View convertView, ViewGroup parent) {
        HeaderViewHolder holder = new HeaderViewHolder();
        if (convertView == null) {
            holder = new HeaderViewHolder();
            convertView = LayoutInflater.from(getContext()).inflate(R.layout.message_list_header, parent,
                    false);
            holder.date = (TextView) convertView.findViewById(R.id.message_date);
            convertView.setTag(holder);
        } else {
            holder = (HeaderViewHolder) convertView.getTag();
        }
        ChatroomMessage message = getItem(position);
        holder.date.setText(CommonUtils.getFormattedDate(message.sentTimestamp));
        return convertView;
    }

    @Override
    public long getHeaderId(int position) {
        try {
            ChatroomMessage message = getItem(position);
            return Long.parseLong(CommonUtils.getDateId(message.sentTimestamp));
        } catch (Exception e) {
            e.printStackTrace();
            return 0;
        }
    }

    private static class ChatroomViewHolder {
        public TextView senderTextField, messageTimestamp, audioTime , customSenderName;
        public EmojiTextView chatroomMessage,tvOnlySmiley;
        public ImageView imageHolder, videoThumb, videoMessageButton, audioPlayButton,customImageHolder,imagePendingMessage;
        public RelativeLayout messageContainer, audioNoteContainer;
        public View messageArrow;
        public ProgressWheel wheel;
        public RoundedImageView avatar;
        public SeekBar audioSeekbar;
    }

    class HeaderViewHolder {
        TextView date;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View vi = convertView;
        /* Setup Chatroom holder */
        ChatroomViewHolder holder = new ChatroomViewHolder();
        String leftBubbleColor, rightBubbleColor;
        mobileTheme = JsonPhp.getInstance().getMobileTheme();
        if (vi == null) {
            if (null == mobileTheme) {
                mobileTheme = JsonPhp.getInstance().getMobileTheme();
            }
            MobileTheme mobileTheme = JsonPhp.getInstance().getMobileTheme();

            if (null != mobileTheme && null != mobileTheme.getLeftBubbleColor() && null != mobileTheme.getLeftBubbleTextColor() && null != mobileTheme.getRightBubbleColor() && null != mobileTheme.getRightBubbleTextColor()) {
                /*leftBubbleColor = mobileTheme.getLeftBubbleColor();
                leftBubbleTextColor = mobileTheme.getLeftBubbleTextColor();
                rightBubbleColor = mobileTheme.getRightBubbleColor();
                rightBubbleTextColor = mobileTheme.getRightBubbleTextColor();  */

                leftBubbleColor = "#e6e9ed";
                leftBubbleTextColor = "#8e8e92";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
                rightBubbleTextColor = "#FFFFFF";

            } else {
               /* leftBubbleColor = "#EBEBEB";
                leftBubbleTextColor = "#000000";
                rightBubbleColor = JsonPhp.getInstance().getCss().getTabTitleBackground();
                rightBubbleTextColor = "#FFFFFF"; */
                leftBubbleColor = "#e6e9ed";
                leftBubbleTextColor = "#8e8e92";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
                rightBubbleTextColor = "#FFFFFF";
            }

            if (getItemViewType(position) == TYPE_RIGHT) {
                vi = LayoutInflater.from(getContext()).inflate(R.layout.custom_chat_message_chatroom_right, parent,
                        false);
                holder.chatroomMessage = (EmojiTextView) vi.findViewById(R.id.textViewChatroomMessageRight);
                holder.messageTimestamp = (TextView) vi.findViewById(R.id.textViewChatroomMessageTimestampRight);
                holder.senderTextField = (TextView) vi.findViewById(R.id.textViewChatroomSenderNameRight);
                holder.imageHolder = (ImageView) vi.findViewById(R.id.imageViewChatroomImageMessageRight);
                holder.messageContainer = (RelativeLayout) vi
                        .findViewById(R.id.linearLayoutChatroomMessageRightContainer);
                holder.messageArrow = vi.findViewById(R.id.rightArrow);

                holder.videoThumb = (ImageView) vi.findViewById(R.id.imageViewChatroomVideoMessageRight);
                holder.videoMessageButton = (ImageView) vi.findViewById(R.id.imageViewChatroomVideoMessageButton);
                holder.wheel = (ProgressWheel) vi.findViewById(R.id.progressWheelVideo);
                holder.avatar = (RoundedImageView) vi.findViewById(R.id.imageViewUserAvatar);
                holder.tvOnlySmiley = (EmojiTextView) vi.findViewById(R.id.textViewChatroomSmileyRight);
                holder.audioNoteContainer = (RelativeLayout) vi.findViewById(R.id.relativeLayoutAudioNoteContainer);
                holder.audioPlayButton = (ImageView) vi.findViewById(R.id.imageViewPlayIcon);
                holder.audioTime = (TextView) vi.findViewById(R.id.textViewTime);
                holder.audioSeekbar = (SeekBar) vi.findViewById(R.id.seek_bar);
                holder.customImageHolder = (ImageView) vi.findViewById(R.id.customImageViewOneOnOneImageMessageRight);
                holder.imagePendingMessage = (ImageView) vi.findViewById(R.id.img_message_pending);

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(rightBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                drawable.setColor(Color.parseColor(rightBubbleColor));
                holder.chatroomMessage.setTextColor(Color.parseColor(rightBubbleTextColor));
                holder.senderTextField.setTextColor(Color.parseColor(rightBubbleTextColor));
                holder.audioTime.setTextColor(Color.parseColor(rightBubbleTextColor));
                holder.imagePendingMessage.setVisibility(View.GONE);
                if (null != mobileTheme && null != mobileTheme.getLeftBubbleTimestampColor()) {
                    holder.messageTimestamp.setTextColor(Color.parseColor(mobileTheme.getLeftBubbleTimestampColor()));
                }
            } else {
                vi = LayoutInflater.from(getContext()).inflate(R.layout.custom_chat_message_chatroom_left, parent,
                        false);
                holder.chatroomMessage = (EmojiTextView) vi.findViewById(R.id.textViewChatroomMessageLeft);
                holder.messageContainer = (RelativeLayout) vi
                        .findViewById(R.id.linearLayoutChatroomMessageLeftContainer);
                holder.messageTimestamp = (TextView) vi.findViewById(R.id.textViewChatroomMessageTimestampLeft);
                holder.senderTextField = (TextView) vi.findViewById(R.id.textViewChatroomSenderNameLeft);
                holder.imageHolder = (ImageView) vi.findViewById(R.id.imageViewChatroomImageMessageLeft);
                holder.messageArrow = vi.findViewById(R.id.leftArrow);
                holder.videoThumb = (ImageView) vi.findViewById(R.id.imageViewChatroomVideoMessageLeft);
                holder.videoMessageButton = (ImageView) vi.findViewById(R.id.imageViewChatroomVideoMessageButton);
                holder.wheel = (ProgressWheel) vi.findViewById(R.id.progressWheelVideo);
                holder.avatar = (RoundedImageView) vi.findViewById(R.id.imageViewUserAvatar);
                holder.customImageHolder = (ImageView) vi.findViewById(R.id.customImageViewOneOnOneImageMessageLeft);
                holder.audioNoteContainer = (RelativeLayout) vi.findViewById(R.id.relativeLayoutAudioNoteContainer);
                holder.audioPlayButton = (ImageView) vi.findViewById(R.id.imageViewPlayIcon);
                holder.audioTime = (TextView) vi.findViewById(R.id.textViewTime);
                holder.audioSeekbar = (SeekBar) vi.findViewById(R.id.seek_bar);
                holder.tvOnlySmiley = (EmojiTextView) vi.findViewById(R.id.textViewChatroomSmileyLeft);

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(leftBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                drawable.setColor(Color.parseColor(leftBubbleColor));
                holder.chatroomMessage.setTextColor(Color.parseColor(leftBubbleTextColor));
                holder.senderTextField.setTextColor(Color.parseColor(leftBubbleTextColor));
                holder.audioTime.setTextColor(Color.parseColor(leftBubbleTextColor));
                if (null != mobileTheme && null != mobileTheme.getLeftBubbleTimestampColor()) {
                    holder.messageTimestamp.setTextColor(Color.parseColor(mobileTheme.getLeftBubbleTimestampColor()));
                }
            }
            vi.setTag(holder);
        } else {
            holder = (ChatroomViewHolder) vi.getTag();
            if (null == mobileTheme) {
                mobileTheme = JsonPhp.getInstance().getMobileTheme();
            }
            if (null != mobileTheme && null != mobileTheme.getLeftBubbleColor() && null != mobileTheme.getRightBubbleColor()) {
                //leftBubbleColor = mobileTheme.getLeftBubbleColor();
                //rightBubbleColor = mobileTheme.getRightBubbleColor();
                leftBubbleColor = "#e6e9ed";
                rightBubbleColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
            } else {
                //leftBubbleColor = "#EBEBEB";
                leftBubbleColor = "#e6e9ed";
                rightBubbleColor = JsonPhp.getInstance().getCss().getTabTitleBackground();
                //rightBubbleColor = JsonPhp.getInstance().getCss().getTabTitleBackground();
            }
            if (getItemViewType(position) == TYPE_RIGHT) {
                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(rightBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                drawable.setColor(Color.parseColor(rightBubbleColor));

            } else {
                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor(leftBubbleColor));
                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                drawable.setColor(Color.parseColor(leftBubbleColor));
            }
        }

		/* Adapter setup */
        final ChatroomMessage message = getItem(position);
        String avatarUrl = "";
        holder.chatroomMessage.setAutoLinkMask(Linkify.ALL);
        Logger.error("Checking message type = " + message.message);

        switch (message.type) {

            case CometChatKeys.MessageTypeKeys.NORMAL:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);

                    if(message.remoteId == 0L){
                        holder.imagePendingMessage.setVisibility(View.VISIBLE);
                    }else {
                        holder.imagePendingMessage.setVisibility(View.GONE);
                    }

                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
                    avatarUrl = SessionData.getInstance().getAvatarLink();
                } else {
                    Buddy buddy = Buddy.getBuddyDetails(message.fromId);
                    if (buddy != null) {
                        avatarUrl = buddy.avatarURL;
                    }
                }

                if (avatarUrl != null && !avatarUrl.equals("")) {
                    /*LocalStorageFactory.getPicassoInstance().load(avatarUrl).placeholder(R.drawable.default_avatar)
                            .resize(55, 55).into(holder.avatar);*/

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                if (message.insertedBy == 1) {
                    if (Stickers.isSticker(message.message)) {
                        holder.chatroomMessage.setText(Stickers.handleSticker(message.message));
                    } else {
                        if (message.message.contains("<img class=\"cometchat_smiley\"")) {
                            Spannable spannable = Smilies.convertImageTagToEmoji(message.message, context, false,
                                    R.drawable.class);
                            if(EmoticonUtils.isOnlySmileyHtmlSmiley(spannable)){
                                holder.chatroomMessage.setVisibility(View.GONE);
                                holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                                holder.tvOnlySmiley.setText(spannable);
                                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable.findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                                shape.setColor(Color.parseColor("#00000000"));
                                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                                drawable.setColor(Color.parseColor("#00000000"));
                            }else{
                                holder.chatroomMessage.setText(spannable);
                            }
                        } else {

                            if(EmoticonUtils.isOnlySmileyMessage(message.message)){

                                holder.chatroomMessage.setVisibility(View.GONE);
                                holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                                holder.tvOnlySmiley.setEmojiText(message.message);

                                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                                shape.setColor(Color.parseColor("#00000000"));
                                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                                drawable.setColor(Color.parseColor("#00000000"));
                            }else{
                                holder.chatroomMessage.setEmojiText(message.message);
                            }

                        }
                    }
                } else {
                    if (message.message.contains("<img class=\"cometchat_smiley\"")) {

                        Spannable spannable = Smilies.convertImageTagToEmoji(message.message, context, false,
                                R.drawable.class);
                        if(EmoticonUtils.isOnlySmileyHtmlSmiley(spannable)){
                            holder.chatroomMessage.setVisibility(View.GONE);
                            holder.tvOnlySmiley.setVisibility(View.VISIBLE);
                            holder.tvOnlySmiley.setText(spannable);
                            LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                            GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable.findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());
                            shape.setColor(Color.parseColor("#00000000"));
                            GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                            drawable.setColor(Color.parseColor("#00000000"));
                        }else{
                            holder.chatroomMessage.setText(spannable);
                        }

                    } else if (Stickers.isSticker(message.message)) {
                        holder.chatroomMessage.setText(Stickers.handleSticker(message.message));
                    } else {
                        holder.chatroomMessage.setText(message.message);
                    }
                }
                break;

            case CometChatKeys.MessageTypeKeys.BOT_RESPONCE:

                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                Logger.error("Adapter bot responce = "+message.message);

                try {
                    JSONObject botMessageJson = new JSONObject(message.message);
                    Logger.error("Bot responce in adapter = "+botMessageJson);
                    Bot bot = Bot.getBotDetails(botMessageJson.getString("botid"));

                    if(bot != null && bot.botAvatar!= null)
                    LocalStorageFactory.LoadImageUsingURL(context,bot.botAvatar,holder.avatar,R.drawable.default_avatar);

                    switch (botMessageJson.getString("messagetype")){

                        case "image":
                            Logger.error("Message = "+botMessageJson.toString());
                            Document doc = Jsoup.parseBodyFragment(botMessageJson.getString("message"));
                            Element imageElement = doc.select("img").first();
                            final String absoluteUrl = imageElement.absUrl("src");
                            holder.customImageHolder.setVisibility(View.VISIBLE);
                            holder.chatroomMessage.setVisibility(View.GONE);

                            LayerDrawable ldrawableImage = (LayerDrawable) holder.messageArrow.getBackground();
                            GradientDrawable shapeImage = ((GradientDrawable) ((RotateDrawable) (ldrawableImage
                                    .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                            shapeImage.setColor(Color.parseColor("#00000000"));
                            GradientDrawable drawableImage = (GradientDrawable) holder.messageContainer.getBackground();
                            drawableImage.setColor(Color.parseColor("#00000000"));
                            Logger.error(TAG,"Chatroom Absolute url = "+absoluteUrl);
                            LocalStorageFactory.LoadImageUsingURL(context,absoluteUrl,holder.customImageHolder,R.drawable.thumbnail_default);

                            holder.customImageHolder.setOnClickListener(new OnClickListener() {

                                @Override
                                public void onClick(View v) {
                                    try {
                                        Intent intent = new Intent(context, ImagePreviewActivity.class);
                                        intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, message.message);
                                        intent.putExtra(StaticMembers.INTENT_IMAGE_SRC,absoluteUrl);
                                        context.startActivity(intent);
                                    } catch (Exception e) {
                                        e.printStackTrace();
                                    }
                                }
                            });
                            break;

                        case "anchor":
                            String temp = botMessageJson.getString("message");
                            Logger.error("Temp = "+temp);
                            CommonUtils.renderHtmlInATextView(context,holder.chatroomMessage,temp);
                            break;

                        default:
                            holder.chatroomMessage.setText(botMessageJson.getString("message"));
                            break;
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }

                break;

            case CometChatKeys.MessageTypeKeys.IMAGE_NEW:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.VISIBLE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }


                if (message.fromId == SessionData.getInstance().getId()) {
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

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                holder.imageHolder.setImageDrawable(getContext().getResources().getDrawable(R.drawable.thumbnail_default));
                holder.imageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            try {
                                Intent intent = new Intent(getContext(), ImagePreviewActivity.class);
                                intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, message.message);
                                getContext().startActivity(intent);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });
                break;
            case CometChatKeys.MessageTypeKeys.IMAGE_DOWNLOADED:

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                    if(message.remoteId == 0L){
                        holder.imagePendingMessage.setVisibility(View.VISIBLE);
                    }else {
                        holder.imagePendingMessage.setVisibility(View.GONE);
                    }
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                String downloaded_filepath = message.message;
                File downloaded_file = new File(downloaded_filepath);

                LayerDrawable ldrawableImage = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shapeImage = ((GradientDrawable) ((RotateDrawable) (ldrawableImage
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shapeImage.setColor(Color.parseColor("#00000000"));
                GradientDrawable drawableImage = (GradientDrawable) holder.messageContainer.getBackground();
                drawableImage.setColor(Color.parseColor("#00000000"));

            /* If image already present in directory then show it directly */
                if (downloaded_file.exists()) {

                    Bitmap bitmap = BitmapProcessingHelper.getRoundedCroppedBitmap(BitmapFactory.decodeFile(message.message, options),50);

                    //holder.imageHolder.setImageBitmap(BitmapFactory.decodeFile(message.message, options));
                    holder.customImageHolder.setImageBitmap(bitmap);
                } else {
                /* Download and display image */
                    LocalStorageFactory.saveIncomingImage(
                            downloaded_filepath.substring(downloaded_filepath.lastIndexOf("/") + 1), message.imageUrl,
                            null, true, String.valueOf(message.remoteId), false);
                }

                holder.customImageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            try {
                                Intent intent = new Intent(getContext(), ImagePreviewActivity.class);
                                intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, message.message);
                                getContext().startActivity(intent);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });

                break;
            case CometChatKeys.MessageTypeKeys.HANDWRITE_NEW:

                Logger.error("Message type handwrite new ");
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.VISIBLE);
                holder.imageHolder.setImageDrawable(context.getResources().getDrawable(R.drawable.thumbnail_default));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);

                }

                final String[] handwriteMess = message.message.split("\\|");
                holder.chatroomMessage.setText(handwriteMess[0]);

                Logger.error("HandwiteMess 0 = "+handwriteMess[0]);
                Logger.error("HandwiteMess 1 = "+handwriteMess[1]);

                holder.imageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            try {
                                Intent intent = new Intent(getContext(), ImagePreviewActivity.class);
                                intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, handwriteMess[1]);
                                getContext().startActivity(intent);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });
                break;
            case CometChatKeys.MessageTypeKeys.HANDWRITE_DOWNLOADED:
                Logger.error("Message type handwrite downloaded");
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.messageContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                LayerDrawable ldrawableImageHandwrite = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shapeImageHandwrite = ((GradientDrawable) ((RotateDrawable) (ldrawableImageHandwrite
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shapeImageHandwrite.setColor(Color.parseColor("#00000000"));
                GradientDrawable drawableImageHandwrite = (GradientDrawable) holder.messageContainer.getBackground();
                drawableImageHandwrite.setColor(Color.parseColor("#00000000"));

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }


                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                final String[] handwriteMessDownloaded = message.message.split("\\|");
                final String handwritefilepath = handwriteMessDownloaded[1];
                holder.chatroomMessage.setText(handwriteMessDownloaded[0]);
                File handwritefile = new File(handwritefilepath);
                if (handwritefile.exists()) {

                    Bitmap bitmap = BitmapProcessingHelper.getRoundedCroppedBitmap(BitmapFactory.decodeFile(handwritefilepath, options),50);


                    Bitmap bitmapwitborder = BitmapProcessingHelper.addBorderToRoundedBitmap(bitmap,50,5,Color.parseColor("#cccccc"));
                    
                    holder.customImageHolder.setImageBitmap(bitmapwitborder);
                } else {
                    LocalStorageFactory.saveIncomingImage(
                            handwritefilepath.substring(handwritefilepath.lastIndexOf("/") + 1), message.imageUrl,
                            holder.customImageHolder, true, String.valueOf(message.remoteId), true);
                }

                holder.customImageHolder.setOnClickListener(new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            try {
                                Intent intent = new Intent(getContext(), ImagePreviewActivity.class);
                                intent.putExtra(StaticMembers.INTENT_IMAGE_PREVIEW_MESSAGE, handwritefilepath);
                                getContext().startActivity(intent);
                            } catch (Exception e) {
                                e.printStackTrace();
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                });
                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_NEW:
                holder.wheel.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }


                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                final ProgressWheel wheel2 = holder.wheel;
                wheel2.setVisibility(View.GONE);

                final ImageView vMessageButton = holder.videoMessageButton;
                vMessageButton.setImageResource(R.drawable.download_video_button);
                vMessageButton.setVisibility(View.VISIBLE);

                holder.videoThumb.setImageResource(R.drawable.thumbnail_default);
                holder.videoThumb.setVisibility(View.VISIBLE);

                OnClickListener videoClickListener = new OnClickListener() {

                    @Override
                    public void onClick(View v) {
                        try {
                            VideoSharing.downloadAndStoreVideo(String.valueOf(message.remoteId), message.imageUrl, true, false);
                            wheel2.setVisibility(View.VISIBLE);
                            wheel2.spin();
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
                File video = new File(message.message);
                if (video.exists()) {
                    holder.chatroomMessage.setVisibility(View.GONE);
                    holder.imageHolder.setVisibility(View.GONE);
                    holder.wheel.setVisibility(View.GONE);
                    holder.audioNoteContainer.setVisibility(View.GONE);
                    holder.videoMessageButton.setImageResource(R.drawable.play_video_button);
                    holder.videoMessageButton.setVisibility(View.VISIBLE);
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.customImageHolder.setVisibility(View.GONE);
                    holder.tvOnlySmiley.setVisibility(View.GONE);

                    if(getItemViewType(position) == TYPE_RIGHT){
                        holder.avatar.setVisibility(View.GONE);
                        holder.senderTextField.setVisibility(View.GONE);
                        if(message.remoteId == 0L){
                            holder.imagePendingMessage.setVisibility(View.VISIBLE);
                        }else {
                            holder.imagePendingMessage.setVisibility(View.GONE);
                        }
                    }else{
                        holder.avatar.setVisibility(View.VISIBLE);
                        holder.senderTextField.setVisibility(View.VISIBLE);
                    }

                    if (message.fromId == SessionData.getInstance().getId()) {
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
                        LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                    }

                    if (videoThumbnails.get(message.id) == null) {
                        try {
                            BitmapFactory.Options videoOptions = new BitmapFactory.Options();
                            videoOptions.inPreferredConfig = Bitmap.Config.RGB_565;
                            videoOptions.inSampleSize = 2;
                            Uri videoUri = MediaStore.Video.Media.EXTERNAL_CONTENT_URI;
                            String[] requierddata = {BaseColumns._ID};
                            Cursor c = context.getContentResolver().query(videoUri, requierddata,
                                    MediaColumns.DATA + " like  \"" + message.message + "\"", null, null);
                            c.moveToFirst();
                            if (c.getCount() != 0) {
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
                            c.close();
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } else {
                        holder.videoThumb.setImageBitmap(videoThumbnails.get(message.id));
                    }
                    holder.videoThumb.setVisibility(View.VISIBLE);

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
                    holder.imageHolder.setVisibility(View.GONE);
                    holder.chatroomMessage.setVisibility(View.VISIBLE);
                    holder.audioNoteContainer.setVisibility(View.GONE);
                    holder.chatroomMessage.setText("File not found. Retry?");
                    holder.customImageHolder.setVisibility(View.GONE);
                    holder.tvOnlySmiley.setVisibility(View.GONE);

                    if(getItemViewType(position) == TYPE_RIGHT){
                        holder.avatar.setVisibility(View.GONE);
                        holder.senderTextField.setVisibility(View.GONE);
                    }else{
                        holder.avatar.setVisibility(View.VISIBLE);
                        holder.senderTextField.setVisibility(View.VISIBLE);
                    }

                    final ProgressWheel wheel3 = holder.wheel;
                    wheel3.setVisibility(View.GONE);

                    final ImageView vMessageButton1 = holder.videoMessageButton;
                    vMessageButton1.setImageResource(R.drawable.download_video_button);
                    vMessageButton1.setVisibility(View.VISIBLE);

                    // holder.videoThumb.setImageResource(R.drawable.imageview_placeholder);
                    // holder.videoThumb.setVisibility(View.VISIBLE);

                    OnClickListener videoClickListener1 = new OnClickListener() {

                        @Override
                        public void onClick(View v) {
                            try {
                                VideoSharing
                                        .downloadAndStoreVideo(String.valueOf(message.remoteId), message.imageUrl, true, false);
                                wheel3.setVisibility(View.VISIBLE);
                                wheel3.spin();
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
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.VISIBLE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.videoThumb.setImageResource(R.drawable.thumbnail_default);
                holder.videoThumb.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.VIDEO_UPLOAD:
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

			/*
             * if (null == holder.bitmap) { holder.bitmap =
			 * ThumbnailUtils.createVideoThumbnail(message.message,
			 * MediaStore.Images.Thumbnails.MINI_KIND); }
			 * holder.videoThumb.setImageBitmap(holder.bitmap);
			 */
                holder.videoThumb.setVisibility(View.VISIBLE);
                final ProgressWheel wheel4 = holder.wheel;
                wheel4.setVisibility(View.VISIBLE);
                wheel4.spin();
                break;
            case CometChatKeys.MessageTypeKeys.WRITEBOARD_REQUEST:
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(createViewLink(message, 2));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);


                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                avatarUrl = "";
                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_UPLOAD:
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }
                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_NEW:
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                holder.audioNoteContainer.setVisibility(View.VISIBLE);
                avatarUrl = "";
                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_IS_DOWNLOADING:
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }
                break;
            case CometChatKeys.MessageTypeKeys.AUDIO_DOWNLOADED:
                holder.chatroomMessage.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);


                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                    if(message.remoteId == 0L){
                        holder.imagePendingMessage.setVisibility(View.VISIBLE);
                    }else {
                        holder.imagePendingMessage.setVisibility(View.GONE);
                    }
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }
                avatarUrl = "";
                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                final TextView audioText = holder.audioTime;
                final SeekBar audioSeekBar = holder.audioSeekbar;
                final ImageView playBtn = holder.audioPlayButton;

                audioSeekBar.getProgressDrawable().setColorFilter(Color.WHITE, PorterDuff.Mode.SRC_ATOP);
                audioSeekBar.getThumb().setColorFilter(Color.WHITE, PorterDuff.Mode.SRC_ATOP);
                if (message.id == currentPlayingSongId) {
                    setBtnColor(position, playBtn, false);
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
                                AudioSharing.downloadAndStoreAudio(String.valueOf(message.remoteId), message.imageUrl, true);
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
                                if (message.id == currentPlayingSongId) {
                                    currentPlayingSong = "";
                                    currentPlayingSongId = 0l;
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
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setText(createDownlodLink(message));
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                avatarUrl = "";

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADING:
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setText(createDownlodLink(message));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                holder.wheel.setVisibility(View.VISIBLE);
                holder.wheel.spin();
                holder.videoMessageButton.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;
            case CometChatKeys.MessageTypeKeys.FILE_DOWNLOADED:
                final String mess = message.message.substring(0, message.message.indexOf((").")) + 2);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.chatroomMessage.setAutoLinkMask(Linkify.PHONE_NUMBERS);
                holder.chatroomMessage.setText(mess);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.wheel.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                holder.chatroomMessage.setOnClickListener(new OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        String path = message.message;
                        path = path.split("#")[1].trim();
                        Logger.error("path =" + path);
                        try {
                            FileOpenIntentHelper.openFile(v.getContext(), path);
                        } catch (Exception e) {
                            e.printStackTrace();
                        }

                    }
                });
                break;
            case CometChatKeys.MessageTypeKeys.AVBROADCAST:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(AVBroadcastText(message.message, message.fromId, position));
                break;
            case CometChatKeys.MessageTypeKeys.WHITEBOARD_REQUEST:
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(createViewLink(message, 1));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.wheel.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                avatarUrl = "";
                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;

            case CometChatKeys.MessageTypeKeys.STICKERS:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                    if(message.remoteId == 0L){
                        holder.imagePendingMessage.setVisibility(View.VISIBLE);
                    }else {
                        holder.imagePendingMessage.setVisibility(View.GONE);
                    }
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                LayerDrawable ldrawable = (LayerDrawable) holder.messageArrow.getBackground();
                GradientDrawable shape = ((GradientDrawable) ((RotateDrawable) (ldrawable
                        .findDrawableByLayerId(R.id.layerItemRightArrow))).getDrawable());

                shape.setColor(Color.parseColor("#00000000"));
                GradientDrawable drawable = (GradientDrawable) holder.messageContainer.getBackground();
                drawable.setColor(Color.parseColor("#00000000"));

                if (message.fromId == SessionData.getInstance().getId()) {
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

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                if(message.message.contains("CC^CONTROL_")){
                    holder.chatroomMessage.setText(Stickers.handleSticker(message.message));
                }else{
                    holder.chatroomMessage.setText(Stickers.getSpannableStickerString(message.message));
                }

                break;

            case CometChatKeys.MessageTypeKeys.AVCHAT:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);

                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(AVConferenceText(message.message, message.chatroomId, position, message.fromId, false));
                break;

            case CometChatKeys.MessageTypeKeys.AUDIO_CONFERENCE:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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
                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(AVConferenceText(message.message, message.chatroomId, position, message.fromId, true));
                break;

            case CometChatKeys.MessageTypeKeys.SCREENSHARE_REQUEST:
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.chatroomMessage.setMovementMethod(LinkMovementMethod.getInstance());
                holder.chatroomMessage.setText(createViewLink(message, 3));
                holder.imageHolder.setVisibility(View.GONE);
                holder.videoThumb.setVisibility(View.GONE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                avatarUrl = "";
                if (message.fromId == SessionData.getInstance().getId()) {
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

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }
                break;

            default:
                holder.videoThumb.setVisibility(View.GONE);
                holder.videoMessageButton.setVisibility(View.GONE);
                holder.wheel.setVisibility(View.GONE);
                holder.imageHolder.setVisibility(View.GONE);
                holder.chatroomMessage.setVisibility(View.VISIBLE);
                holder.audioNoteContainer.setVisibility(View.GONE);
                holder.chatroomMessage.setTextColor(Color.parseColor(message.textColor));
                holder.avatar.setVisibility(View.VISIBLE);
                holder.customImageHolder.setVisibility(View.GONE);
                holder.tvOnlySmiley.setVisibility(View.GONE);

                if(getItemViewType(position) == TYPE_RIGHT){
                    holder.avatar.setVisibility(View.GONE);
                    holder.senderTextField.setVisibility(View.GONE);
                }else{
                    holder.avatar.setVisibility(View.VISIBLE);
                    holder.senderTextField.setVisibility(View.VISIBLE);
                }

                if (message.fromId == SessionData.getInstance().getId()) {
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

                    LocalStorageFactory.LoadImageUsingURL(context,avatarUrl,holder.avatar,R.drawable.default_avatar);
                }

                if (message.insertedBy == 1) {
                    holder.chatroomMessage.setEmojiText(message.message);
                } else {
                    holder.chatroomMessage.setText(Smilies.convertImageTagToEmoji(message.message, getContext(), true,
                            R.drawable.class));
                }

                break;
        }

        holder.messageTimestamp.setVisibility(View.VISIBLE);
        holder.messageTimestamp.setText(CommonUtils.convertTimestampToDate(message.sentTimestamp));

//        holder.senderTextField.setText(Html.fromHtml(message.senderName) + ": ");
        if (!TextUtils.isEmpty(message.senderName)) {
            holder.senderTextField.setText(Html.fromHtml(message.senderName) + ": ");
        } else {
            holder.senderTextField.setText("Unknown");
        }
        return vi;
    }

    private String getTextColor(int position) {
        if (getItemViewType(position) == TYPE_RIGHT) {
            return rightBubbleTextColor;
        } else {
            return leftBubbleTextColor;
        }
    }

    private SpannableString createViewLink(final ChatroomMessage message, int flag) {

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
                ClickableSpan span =  new ClickableSpan() {
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
                        vhelper.addNameValuePair(CometChatKeys.FileUploadKeys.CHATROOMMODE, "1");
                        vhelper.addNameValuePair(CometChatKeys.AjaxKeys.TO, SessionData.getInstance().getCurrentChatroom());
                        vhelper.sendAjax();
                    }
                };

                whiteboardrequest.setSpan(span, startIndex + 1, endIndex, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
                return whiteboardrequest;
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
        } else {
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
                        intent.putExtra(StaticMembers.CHATROOMMODE, true);
                        intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, String.valueOf(message.chatroomId));
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

    }

    private Spannable AVBroadcastText(final String message, final Long buddyId, final int position) {
        final String data[] = message.split("##");
        Chatrooms chatroom = JsonPhp.getInstance().getLang().getChatrooms();
        final SpannableString avbroadcastMessage;
        String messageText;

        if (buddyId == SessionData.getInstance().getId()) {
            messageText = data[0];
            avbroadcastMessage = new SpannableString(messageText);
        } else {
            if (null == chatroom) {
                messageText = data[0] + "\nJoin";
            } else {
                messageText = data[0] + "\n" + chatroom.get19();
            }
            avbroadcastMessage = new SpannableString(messageText);

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
                    intent.putExtra(StaticMembers.CHATROOMMODE, true);
                    context.startActivity(intent);
                }
            };

            avbroadcastMessage.setSpan(clickable, data[0].length(), messageText.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

        }
        avbroadcastMessage.setSpan(new ForegroundColorSpan(Color.parseColor(getTextColor(position))), 0, messageText.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

        return avbroadcastMessage;
    }

    private Spannable AVConferenceText(final String message, final Long chatroomId, final int position, long buddyId, final boolean isAudioCall) {
        final String data[] = message.split("##");
        Chatrooms chatroom = JsonPhp.getInstance().getLang().getChatrooms();
        String messageText;
        SpannableString avconferencemessage;
        if (buddyId == SessionData.getInstance().getId()) {
            messageText = data[0];
            avconferencemessage = new SpannableString(messageText);
        } else {
            if (null == chatroom) {
                messageText = data[0] + "\nJoin";
            } else {
                messageText = data[0] + "\n" + chatroom.get19();
            }
            avconferencemessage = new SpannableString(messageText);
            ClickableSpan clickable = new ClickableSpan() {
                @Override
                public void onClick(View widget) {
                    Intent intent = new Intent(context, VideoChatActivity.class);
                    intent.putExtra(StaticMembers.INTENT_ROOM_NAME, data[1]);
                    if (isAudioCall) {
                        intent.putExtra(StaticMembers.INTENT_CR_AUDIO_CONFERENCE_FLAG, true);
                        intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, false);
                    } else {
                        intent.putExtra(StaticMembers.INTENT_CR_AUDIO_CONFERENCE_FLAG, false);
                        intent.putExtra(StaticMembers.INTENT_VIDEO_FLAG, true);
                    }
                    intent.putExtra(StaticMembers.INTENT_AUDIO_FLAG, true);
                    intent.putExtra(BroadcastReceiverKeys.IntentExtrasKeys.BUDDY_ID, String.valueOf(chatroomId));
                    context.startActivity(intent);
                }
            };
            avconferencemessage.setSpan(clickable, data[0].length(), messageText.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        }
        avconferencemessage.setSpan(new ForegroundColorSpan(Color.parseColor(getTextColor(position))), 0, messageText.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);

        return avconferencemessage;
    }

    private Spannable createDownlodLink(final ChatroomMessage message) {
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
                VideoSharing.downloadAndStoreVideo(String.valueOf(message.remoteId), message.imageUrl, true, true);
            }
        };
        int startIndex = mess.indexOf("\n") + 1;
        downloadLink.setSpan(clickableSpan, startIndex, mess.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        return downloadLink;

    }

    public void setBtnColor(int position, ImageView playbtn, boolean isPlayBtn) {
        if (getItemViewType(position) == TYPE_RIGHT) {
            if (isPlayBtn) {
                playbtn.setBackgroundResource(R.drawable.play);
            } else {
                playbtn.setBackgroundResource(R.drawable.pause);
            }
            playbtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor(rightBubbleTextColor)));
        } else {
            if (isPlayBtn) {
                playbtn.setBackgroundResource(R.drawable.play_left);
            } else {
                playbtn.setBackgroundResource(R.drawable.pause);
            }
            playbtn.getBackground().setColorFilter(new LightingColorFilter(Color.WHITE, Color.parseColor(leftBubbleTextColor)));

        }
    }

    public void playAudio(String message, final Long messageId, final ImageView playBtn, final MediaPlayer player, final int position, final TextView audioText, final SeekBar audioSeekBar) {
        try {
            currentPlayingSong = message;
            currentPlayingSongId = messageId;
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
                    if (player.isPlaying()
                            && pos < duration) {

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