/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.emoji.adapter;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;

import com.astuetz.viewpager.extensions.TabsAdapter;
import com.astuetz.viewpager.extensions.ViewPagerTabButton;
import com.inscripts.activities.R;

public class FixedIconTabsAdapter implements TabsAdapter {

	private Activity mContext;

	/*private int[] mIcons = { R.drawable.clock_tab, R.drawable.smiley_tab, R.drawable.flower_tab, R.drawable.bell_tab,
			R.drawable.car_tab, R.drawable.filter_tab };*/

    private int[] mIcons = { R.drawable.clock, R.drawable.ic_color_smile, R.drawable.ic_color_panda, R.drawable.ic_color_ball_soccer,
            R.drawable.ic_color_car, R.drawable.ic_color_keyboard };

	public FixedIconTabsAdapter(Activity ctx) {
		this.mContext = ctx;
	}

	@Override
	public View getView(int position) {
		ViewPagerTabButton tab;
		LayoutInflater inflater = mContext.getLayoutInflater();
		tab = (ViewPagerTabButton) inflater.inflate(R.layout.tab_fixed, null);
		if (position < mIcons.length)
			tab.setCompoundDrawablesWithIntrinsicBounds(null, mContext.getResources().getDrawable(mIcons[position]),
					null, null);
		return tab;
	}

}
