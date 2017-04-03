package adapter;


import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.utils.Logger;

import java.util.List;

import inscripts.com.librarytestapp.R;
import pojo.Bot;

public class BotListAdapter extends BaseAdapter {

    Context context;
    List<Bot> botList;

    public BotListAdapter(Context context , List<Bot> botList) {
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

            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        final Bot bot = getItem(position);

        holder.botName.setText(bot.botName);
        holder.botDescription.setText(bot.botDescription);
        Logger.error("Bot avatr value = "+bot.botAvatar);

        /** Repacling Picasso with glide**/

        LocalStorageFactory.LoadImageUsingURL(context,bot.botAvatar,holder.avatar, R.drawable.ic_robot);

        return view;
    }


    private static class ViewHolder {
        public TextView botName;
        public TextView botDescription;
        public RoundedImageView avatar;
    }


}
