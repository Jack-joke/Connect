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
import android.widget.CheckBox;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.pojos.UnbanUsers;

import java.util.ArrayList;

public class UnbanChatroomUserAdapter extends ArrayAdapter<UnbanUsers> {
    LayoutInflater inflater;
    Context context;
    ArrayList list;
    ArrayList<String> positionChecked;
    ArrayList<Long> checkedID = new ArrayList<Long>();

    public UnbanChatroomUserAdapter(Context context, ArrayList<UnbanUsers> objects, ArrayList<String> positionChecked) {
        super(context, 0, objects);
        this.context= context;
        this.positionChecked = positionChecked;
        inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    private class ViewHolder {
        private TextView tv;
        private RoundedImageView imageView;
        private CheckBox cb;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        ViewHolder holder;
        if (null == convertView) {
            convertView = inflater.inflate(R.layout.custom_list_item_unban_user, null);
            holder = new ViewHolder();
            holder.tv = (TextView) convertView.findViewById(R.id.textViewChatroomMemberName);
            holder.imageView = (RoundedImageView) convertView.findViewById(R.id.imageViewShowUserAvatar);
            holder.cb = (CheckBox) convertView.findViewById(R.id.checkbox);
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }
        UnbanUsers member = getItem(position);
        holder.tv.setText(Html.fromHtml(member.getName()));
        /*LocalStorageFactory.getPicassoInstance().load(member.getAvatarUrl()).placeholder(R.drawable.default_avatar)
                .resize(42, 42).into(holder.imageView);*/

        LocalStorageFactory.LoadImageUsingURL(context,member.getAvatarUrl(),holder.imageView,R.drawable.default_avatar);

        if (positionChecked.get(position).equals("true")){
            holder.cb.setChecked(true);
        }else{
            holder.cb.setChecked(false);
        }

        return convertView;
    }
    public ArrayList<String> getUnbanUsersList() {
        return positionChecked;
    }
    public ArrayList<Long> getUnbanUsersListIds() {
        checkedID.clear();
        for (int i = 0; i< positionChecked.size(); i++){
            if (positionChecked.get(i).equals("true")){
                UnbanUsers member = getItem(i);
                checkedID.add(member.getId());
            }
        }

        return checkedID;
    }
    public void toggleUnban(int pos, String value) {
        positionChecked.set(pos, value);
    }
}
