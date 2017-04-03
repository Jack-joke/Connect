/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.sticker.adapter;

import android.app.Activity;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.view.ViewGroup;
import android.widget.GridView;

import com.astuetz.viewpager.extensions.PagerSlidingTabStrip;
import com.inscripts.activities.R;
import com.inscripts.sticker.mapping.RecentlyUsedStickers;
import com.inscripts.sticker.mapping.StickerDrawableArrayListBear;
import com.inscripts.sticker.mapping.StickerDrawableArrayListGeek;
import com.inscripts.sticker.mapping.StickerDrawableArrayListGery;
import com.inscripts.sticker.mapping.StickerDrawableArrayListHappyGhost;
import com.inscripts.sticker.mapping.StickerDrawableArrayListLittleDyno;
import com.inscripts.sticker.mapping.StickerDrawableArrayListMomon;
import com.inscripts.sticker.mapping.StickerDrawableArrayListMonster;
import com.inscripts.sticker.mapping.StickerDrawableArrayListPenguin;
import com.inscripts.sticker.mapping.StickerDrawableArrayListPirate;
import com.inscripts.sticker.mapping.StickerDrawableArrayListSkaterBoy;
import com.inscripts.sticker.mapping.StickerDrawableArrayListVampire;
import com.inscripts.sticker.mapping.StickerHashmapPatternToDrawable;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class SlidingStripAdapter extends PagerAdapter implements PagerSlidingTabStrip.IconTabProvider,RecentlyUsedStickers.RefreshGridViewAdapterListener  {

    private Activity context;
    private int osVersion;
    private StickerGridviewImageAdapter.StickerClickInterface clickListener;
    private StickerGridviewImageAdapter gridviewImageAdapter;
    private StickerGridviewImageAdapter gridviewImageAdapterFirstTab;

    private int[] mIcons = { R.drawable.clock_tab, R.drawable.bear_1, R.drawable.geek_1, R.drawable.gery_1,R.drawable.happ_1,R.drawable.litt_1,R.drawable.momo_1,R.drawable.mons_1,R.drawable.peng_1,R.drawable.pira_1,R.drawable.skat_1,R.drawable.vamp_1};

    public SlidingStripAdapter(Activity context, int backgroundColor, int textColor,
                               StickerGridviewImageAdapter.StickerClickInterface clickListener){
        this.context = context;
        this.clickListener = clickListener;
        osVersion = android.os.Build.VERSION.SDK_INT;
    }

    @Override
    public int getPageIconResId(int position) {
        return mIcons[position];
    }

    @Override
    public int getCount() {
        return mIcons.length;
    }

    @Override
    public boolean isViewFromObject(View view, Object object) {
        return view == ((View) object);
    }

    @Override
    public Object instantiateItem(ViewGroup container, int pagePosition) {
        View view = context.getLayoutInflater().inflate(R.layout.gridview_layout_sticker_popup, null);
        GridView gridView = (GridView) view.findViewById(R.id.grid_view_stickerpopup);
        gridviewImageAdapter = null;
        switch (pagePosition) {
            case 0:
                if (osVersion >= 11) {
                    // preference.getArrayList(StaticMembers.PREFSAVE_ARRAYLIST__KEY);
                    HashSet<String> set = new HashSet<>();
                    List<String> listUnicode = new ArrayList<>(set);
                    RecentlyUsedStickers.stickerUnicodeArrayListRecentcategory= (ArrayList<String>) listUnicode;
                    ArrayList<Integer> stickerDrawable = new ArrayList<>();
                    int recentEmojiCount = listUnicode.size();
                    for (int j = 0; j < recentEmojiCount; j++) {
                        String key = listUnicode.get(j);
                        stickerDrawable.add(StickerHashmapPatternToDrawable.stickerMap.get(key));
                    }
                    RecentlyUsedStickers.stickerDrawableArrayListRecentCategory = stickerDrawable;
                    gridviewImageAdapterFirstTab = new StickerGridviewImageAdapter(context,
                            RecentlyUsedStickers.stickerDrawableArrayListRecentCategory, clickListener);
                    gridView.setAdapter(gridviewImageAdapterFirstTab);

                    ((ViewPager) container).addView(view, 0);
                } else {
                    gridviewImageAdapterFirstTab = new StickerGridviewImageAdapter(context,
                            RecentlyUsedStickers.stickerDrawableArrayListRecentCategory, clickListener);
                    gridView.setAdapter(gridviewImageAdapterFirstTab);

                    ((ViewPager) container).addView(view, 0);
                }
                break;
            case 1:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListBear.stickerBear, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);

                break;
            case 2:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListGeek.stickerGeek, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 3:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListGery.stickerGery, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 4:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListHappyGhost.stickerHappyGhost, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 5:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListLittleDyno.stickerLittleDyno, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 6:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListMomon.stickerMomon, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 7:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListMonster.stickerMonster, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 8:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListPenguin.stickerPenguin, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 9:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListPirate.stickerPirate, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 10:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListSkaterBoy.stickerSkaterBoy, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            case 11:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListVampire.stickerVampire, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
            default:
                gridviewImageAdapter = new StickerGridviewImageAdapter(context,
                        StickerDrawableArrayListBear.stickerBear, clickListener);
                gridView.setAdapter(gridviewImageAdapter);
                // gridView.setOnItemClickListener(this);
                ((ViewPager) container).addView(view, 0);
                break;
        }

        return view;
    }
    @Override
    public void onNewStickerUsed() {
        gridviewImageAdapterFirstTab.notifyDataSetChanged();
    }
}