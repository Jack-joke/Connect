/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import com.inscripts.activities.R;
import com.inscripts.pojos.Wallpaper;
import java.util.List;

public class WallpaperAdpater extends ArrayAdapter<Wallpaper> {
    ViewHolder holder;

    public WallpaperAdpater(Context context, List<Wallpaper> resource) {
        super(context, R.layout.list_row, resource);
    }

    class ViewHolder {
        ImageView icon;
        TextView title;
    }

    public View getView(int position, View convertView,ViewGroup parent) {
            final LayoutInflater inflater = (LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);

            if (convertView == null) {
                convertView = inflater.inflate(R.layout.list_row, null);
                holder = new ViewHolder();
                holder.icon = (ImageView) convertView.findViewById(R.id.icon);
                holder.title = (TextView) convertView.findViewById(R.id.title);

                convertView.setTag(holder);
            } else {
                holder = (ViewHolder) convertView.getTag();
            }

        Wallpaper wall = getItem(position);
        holder.title.setText(wall.getTitle());
        holder.icon.setImageResource(wall.getImage());

        return convertView;
        }
    }