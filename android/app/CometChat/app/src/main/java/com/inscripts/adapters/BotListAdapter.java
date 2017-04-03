package com.inscripts.adapters;


import android.content.Context;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Bot;
import com.inscripts.utils.Logger;

import java.util.List;

public class BotListAdapter extends BaseAdapter {

    Context context;
    List<Bot> botList;

    public BotListAdapter(Context context ,List<Bot> botList) {
        this.botList = botList;
        this.context = context;
    }

    @Override
    public int getCount() {
        return botList.size();
    }

    @Override
    public Bot getItem(int i) {
        return botList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return botList.get(i).botId;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup viewGroup) {

        View view = convertView;
        final ViewHolder holder;

        if (null == view) {
            view = LayoutInflater.from(context).inflate(R.layout.custom_list_item_bot, viewGroup, false);

            holder = new ViewHolder();
            holder.avatar = (RoundedImageView) view.findViewById(R.id.imageViewUserAvatar);
            holder.botName = (TextView) view.findViewById(R.id.textviewUserName);
            holder.botDescription = (TextView) view.findViewById(R.id.textviewBotDescription);
            holder.botKey = (TextView) view.findViewById(R.id.textviewBotKey);
            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        final Bot bot = getItem(position);

        holder.botName.setText(bot.botName);
        String keyName = bot.botName.toLowerCase().trim().replaceAll(" ","");
        holder.botKey.setText("@"+keyName.trim());
        if(bot.botDescription != null && !bot.botDescription.isEmpty()){
            holder.botDescription.setText(bot.botDescription);
        }else {
            holder.botDescription.setText("Hi.. I am helper Bot.");
        }


        holder.avatar.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
        holder.botKey.setTextColor(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)));


        /** Repacling Picasso with glide**/

        /*LocalStorageFactory.getPicassoInstance().load(bot.botAvatar).placeholder(R.drawable.vector_drawable_ic_default_avtar)
                .resize(55, 55).into(holder.avatar);*/

        LocalStorageFactory.LoadImageUsingURL(context,bot.botAvatar,holder.avatar,R.drawable.ic_robot);

       /* Glide.with(context)
                .load(bot.botAvatar)
                .centerCrop()
                .placeholder(R.drawable.vector_drawable_ic_default_avtar)
                .into(holder.avatar);*/

        return view;
    }


    private static class ViewHolder {
        public TextView botName;
        public TextView botDescription;
        public TextView botKey;
        public RoundedImageView avatar;
    }


}
