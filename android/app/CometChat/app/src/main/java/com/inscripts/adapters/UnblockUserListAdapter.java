/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.CommonUtils;

import java.util.ArrayList;

public class UnblockUserListAdapter extends ArrayAdapter<String> {

    private ArrayList<String> checkedList, blockedUserIds;

    public UnblockUserListAdapter(Context context, ArrayList<String> userNames, ArrayList<String> userId,
                                  ArrayList<String> savedCheckbox) {
        super(context, 0, userNames);
        blockedUserIds = userId;

        checkedList = new ArrayList<String>();
        if (null != savedCheckbox) {
            for (String i : savedCheckbox) {
                checkedList.add(i);
            }
        }
    }

    private static class ViewHolder {
        public TextView userName;
        public CheckBox checkBox;
    }


    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        ViewHolder holder;
        View vi = convertView;
        if (vi == null) {
            vi = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_item_blocked_users, parent,
                    false);
            holder = new ViewHolder();
            holder.userName = (TextView) vi.findViewById(R.id.textViewUnblockUserName);
            holder.checkBox = (CheckBox) vi.findViewById(R.id.checkBoxUnblockUser);
            vi.setTag(holder);
        } else {
            holder = (ViewHolder) vi.getTag();
        }

        holder.userName.setText(Html.fromHtml(getItem(position)));
        String userid = blockedUserIds.get(position);
        ColorStateList colorStateList = new ColorStateList(
                new int[][]{

                        new int[]{-android.R.attr.state_enabled},
                        new int[]{-android.R.attr.state_checked},
                        new int[]{android.R.attr.state_checked}
                },
                new int[] {
                        Color.BLACK //disabled
                        ,Color.parseColor("#E0E0E0")
                        ,Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY))
                }
        );

        if (CommonUtils.isGreaterThanKitKat()) {
            holder.checkBox.setButtonTintList(colorStateList);
        }
        holder.checkBox.setChecked(checkedList.contains(userid));
        holder.checkBox.setTag(userid);
        return vi;
    }

    public ArrayList<String> getCheckedUsersList() {
        return checkedList;
    }

    public void toggleUnblock(String id) {
        if (checkedList.contains(id)) {
            checkedList.remove(id);
        } else {
            checkedList.add(id);
        }
    }

}
