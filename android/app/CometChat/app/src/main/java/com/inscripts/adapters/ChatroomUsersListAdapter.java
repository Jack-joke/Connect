/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.pojos.ChatroomMembers;

import java.util.ArrayList;

public class ChatroomUsersListAdapter extends ArrayAdapter<ChatroomMembers> {
    LayoutInflater inflater;

    public ChatroomUsersListAdapter(Context context, ArrayList<ChatroomMembers> objects) {
        super(context, 0, objects);
        inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    private class ViewHolder {
        private TextView tv;
        private RoundedImageView imageView;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder holder;
        if (null == convertView) {
            convertView = inflater.inflate(R.layout.custom_list_item_chatroom_members, null);
            holder = new ViewHolder();
            holder.tv = (TextView) convertView.findViewById(R.id.textViewChatroomMemberName);
            holder.imageView = (RoundedImageView) convertView.findViewById(R.id.imageViewShowUserAvatar);
            convertView.setTag(holder);

        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        ChatroomMembers member = getItem(position);
        holder.tv.setText(Html.fromHtml(member.getName()));

        /** Repacling Picasso with glide**/
        /*LocalStorageFactory.getPicassoInstance().load(member.getAvatarUrl()).placeholder(R.drawable.default_avatar)
                .resize(42, 42).into(holder.imageView);*/

        LocalStorageFactory.LoadImageUsingURL(parent.getContext(),member.getAvatarUrl(),holder.imageView,R.drawable.default_avatar);

        return convertView;
    }
}
