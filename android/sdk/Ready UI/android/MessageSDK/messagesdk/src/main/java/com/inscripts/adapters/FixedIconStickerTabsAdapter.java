/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;

import com.astuetz.viewpager.extensions.TabsAdapter;
import com.astuetz.viewpager.extensions.ViewPagerTabButton;
import com.inscripts.R;

public class FixedIconStickerTabsAdapter implements TabsAdapter {

    private Activity mContext;


    private int[] mIcons = { R.drawable.clock_tab, R.drawable.bear_1, R.drawable.geek_1, R.drawable.gery_1,R.drawable.happ_1,R.drawable.litt_1,R.drawable.momo_1,R.drawable.mons_1,R.drawable.peng_1,R.drawable.pira_1,R.drawable.skat_1,R.drawable.vamp_1};

    public FixedIconStickerTabsAdapter(Activity ctx) {
        this.mContext = ctx;
    }

    @SuppressLint("NewApi")
    @Override
    public View getView(int position) {
        ViewPagerTabButton tab;
        LayoutInflater inflater = mContext.getLayoutInflater();
        tab = (ViewPagerTabButton) inflater.inflate(R.layout.cc_stickers_tab_fixed, null);
        if (position < mIcons.length)
            //tab.setBackground(mContext.getResources().getDrawable(mIcons[position]));
            //tab.setBackgroundResource(mIcons[position]);
            tab.setCompoundDrawablesWithIntrinsicBounds(null, mContext.getResources().getDrawable(mIcons[position]),
                    null, null);
        return tab;
    }

}
