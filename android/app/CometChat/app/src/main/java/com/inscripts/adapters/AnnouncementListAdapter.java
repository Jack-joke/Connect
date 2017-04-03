/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.graphics.Color;
import android.text.Html;
import android.text.TextUtils;
import android.text.method.LinkMovementMethod;
import android.text.util.Linkify;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Mobile;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.models.Announcement;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.StaticMembers;

import java.util.ArrayList;
import java.util.List;

public class AnnouncementListAdapter extends ArrayAdapter<Announcement> {

    private ArrayList<Long> readMoreItemsList, processedMessage, readMoreClicked;
    private String readmore, readless;
    private MobileTheme mobileTheme;
    private Css css;
    int actionBarColor;

    public AnnouncementListAdapter(Context context, List<Announcement> objects) {
        super(context, 0, objects);

        readMoreItemsList = new ArrayList<Long>();
        processedMessage = new ArrayList<Long>();
        readMoreClicked = new ArrayList<Long>();

        readmore = "Read More";
        readless = "Read Less";
        try {
            Mobile mobilelang = JsonPhp.getInstance().getLang().getMobile();
            if (!TextUtils.isEmpty(mobilelang.get63())) {
                readmore = mobilelang.get63();
            }
            if (!TextUtils.isEmpty(mobilelang.get64())) {
                readless = mobilelang.get64();
            }
        } catch (Exception e) {

        }

        mobileTheme = JsonPhp.getInstance().getMobileTheme();
        css = JsonPhp.getInstance().getCss();
        if (mobileTheme != null && null != mobileTheme.getActionbarColor()) {
            actionBarColor = Color.parseColor(mobileTheme.getActionbarColor());
        } else if (null != css) {
            actionBarColor = Color.parseColor(css.getTabTitleBackground());
        } else {
            actionBarColor = Color.parseColor(StaticMembers.COMETCHAT_DARK_GREEN);
        }
    }

    private static class ViewHolder {
        public TextView announcement;
        public TextView timeStamp;
        public TextView readMore;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;
        final ViewHolder holder;
        if (null == view) {
            view = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_item_announcement, parent,
                    false);
            holder = new ViewHolder();
            holder.announcement = (TextView) view.findViewById(R.id.textViewAnnouncementMessage);
            holder.timeStamp = (TextView) view.findViewById(R.id.textViewAnnouncementTime);
            holder.readMore = (TextView) view.findViewById(R.id.textViewAnnouncementReadMore);
            view.setTag(holder);
        } else {
            holder = (ViewHolder) view.getTag();
        }

        Announcement ann = getItem(position);

        final Long id = ann.announcementId;
        holder.announcement.setText(Html.fromHtml(ann.message));
        if (ann.message.contains("<a href=")) {
            holder.announcement.setMovementMethod(LinkMovementMethod.getInstance());
        } else {
            Linkify.addLinks(holder.announcement, Linkify.WEB_URLS);
        }
        holder.announcement.setTag(id);

        holder.readMore.setTextColor(actionBarColor);
        holder.timeStamp.setText(CommonUtils.convertTimestampToDate(ann.sentTimestamp));

        if (!processedMessage.contains(id)) {
            holder.announcement.post(new Runnable() {

                @Override
                public void run() {
                    Long myid = (Long) holder.announcement.getTag();
                    processedMessage.add(myid);
                    if (holder.announcement.getLineCount() > 5) {
                        holder.readMore.setText(readmore);
                        holder.readMore.setVisibility(View.VISIBLE);
                        readMoreItemsList.add(myid);
                    }
                }
            });
        }
        holder.readMore.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                Long myid = (Long) holder.announcement.getTag();
                if (readMoreClicked.contains(myid)) {
                    holder.announcement.setMaxLines(5);
                    holder.readMore.setText(readmore);
                    readMoreClicked.remove(readMoreClicked.indexOf(myid));
                } else {
                    holder.announcement.setMaxLines(Integer.MAX_VALUE);
                    holder.readMore.setText(readless);
                    readMoreClicked.add(myid);
                }
            }
        });

        if (readMoreItemsList.contains(id)) {
            holder.announcement.setMaxLines(5);
            holder.readMore.setText(readmore);
            holder.readMore.setVisibility(View.VISIBLE);
        } else {
            holder.readMore.setVisibility(View.GONE);
        }

        if (readMoreClicked.contains(id)) {
            holder.announcement.setMaxLines(Integer.MAX_VALUE);
            holder.readMore.setText(readless);
        }
        return view;
    }
}
