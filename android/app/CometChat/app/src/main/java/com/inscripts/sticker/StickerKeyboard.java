/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.sticker;


import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.Rect;
import android.os.Build;
import android.support.v4.view.ViewPager;
import android.view.Display;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewTreeObserver;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;

import com.astuetz.viewpager.extensions.PagerSlidingTabStrip;
import com.inscripts.activities.R;
import com.inscripts.emoji.SmileyKeyBoard;
import com.inscripts.sticker.adapter.SlidingStripAdapter;
import com.inscripts.sticker.adapter.StickerGridviewImageAdapter;
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
import com.inscripts.sticker.mapping.StickerPatternArrayListBear;
import com.inscripts.sticker.mapping.StickerPatternArrayListGeek;
import com.inscripts.sticker.mapping.StickerPatternArrayListGery;
import com.inscripts.sticker.mapping.StickerPatternArrayListHappyGhost;
import com.inscripts.sticker.mapping.StickerPatternArrayListLittleDyno;
import com.inscripts.sticker.mapping.StickerPatternArrayListMomon;
import com.inscripts.sticker.mapping.StickerPatternArrayListMonster;
import com.inscripts.sticker.mapping.StickerPatternArrayListPenguin;
import com.inscripts.sticker.mapping.StickerPatternArrayListPirate;
import com.inscripts.sticker.mapping.StickerPatternArrayListSkaterBoy;
import com.inscripts.sticker.mapping.StickerPatternArrayListVampire;


public class StickerKeyboard {
    private View popUpView;
    private ViewPager viewPager;
    //private PagerAdapterStickerPopup adapterEmojiPopup;
    private PopupWindow popupWindow;
    private LinearLayout emoticonsCover;
    private int previousHeightDiffrence = 0, keyboardHeight;
    private boolean isKeyBoardVisible;
    private ImageView ivEmojiClear;
    private Activity activity;
    int count = 0;
    private static ViewTreeObserver.OnGlobalLayoutListener layoutListener;
    private SlidingStripAdapter adapterEmojiPopup;

    public void enable(Activity activity, StickerGridviewImageAdapter.StickerClickInterface clickListener, Integer emojiFooterId,
                       final EditText edtMessage) {
        this.activity = activity;
        popUpView = activity.getLayoutInflater().inflate(R.layout.activity_fixed_tabs_sticker, null);
        viewPager = (ViewPager) popUpView.findViewById(R.id.pager_popviewPopupEmoji);
        viewPager.setOffscreenPageLimit(12);
        emoticonsCover = (LinearLayout) activity.findViewById(emojiFooterId);
        ivEmojiClear = (ImageView) popUpView.findViewById(R.id.ivClearEmoji);
        //adapterEmojiPopup = new PagerAdapterStickerPopup(activity, 12, Color.CYAN, Color.BLACK, clickListener);
        //viewPager.setAdapter(adapterEmojiPopup);
        //viewPager.setCurrentItem(1);
        /*FixedTabsView fixedTabs = (FixedTabsView) popUpView.findViewById(R.id.fixed_tabsPopupEmoji);
        FixedIconTabsAdapter fixedIconTabsAdapter = new FixedIconTabsAdapter(activity);
        fixedTabs.setAdapter(fixedIconTabsAdapter);
        fixedTabs.setViewPager(viewPager);*/

        PagerSlidingTabStrip tabs = (PagerSlidingTabStrip) popUpView.findViewById(R.id.tabs);
        adapterEmojiPopup= new SlidingStripAdapter(activity, Color.CYAN, Color.BLACK, clickListener);

        viewPager.setAdapter(adapterEmojiPopup);
        tabs.setViewPager(viewPager);
        viewPager.setCurrentItem(1);
        // Creating a pop window for emoticons keyboard

        popupWindow = new PopupWindow(popUpView, ViewGroup.LayoutParams.MATCH_PARENT, keyboardHeight, false);

        ivEmojiClear.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                KeyEvent event = new KeyEvent(0, 0, 0, KeyEvent.KEYCODE_DEL, 0, 0, 0, 0, KeyEvent.KEYCODE_ENDCALL);
                edtMessage.dispatchKeyEvent(event);
            }
        });

		/*
         * popupWindow.setOnDismissListener(new OnDismissListener() {
		 *
		 * @Override public void onDismiss(DialogInterface dialog) { if
		 * (osVersion >= 11) { Set<String> set = new
		 * HashSet<String>(RecentlyUsedEmoji
		 * .emojiUnicodeArrayListRecentcategory); //
		 * preference.saveArrayList(StaticMembers.PREFSAVE_ARRAYLIST__KEY,set);
		 * } } });
		 */
    }

    public void showKeyboard(View parentLayout) {
        calculateKeyboardHeight(parentLayout);
        if (!popupWindow.isShowing()) {
            popupWindow.setHeight(keyboardHeight);
            if (isKeyBoardVisible) {
                checkKeyboardHeight(parentLayout, false);
                emoticonsCover.setVisibility(View.GONE);
            } else {
                checkKeyboardHeight(parentLayout, true);
                emoticonsCover.setVisibility(View.VISIBLE);
            }
            popupWindow.showAtLocation(parentLayout, Gravity.BOTTOM, 0, 0);
        } else {
            checkKeyboardHeight(parentLayout, false);
            emoticonsCover.setVisibility(View.GONE);
            popupWindow.dismiss();
        }
    }

    public void dismissKeyboard() {

        if (popupWindow.isShowing()) {
            emoticonsCover.setVisibility(View.GONE);
            popupWindow.dismiss();
        }
    }

    public boolean isKeyboardVisibile() {
        return null != popupWindow && popupWindow.isShowing();
    }

    @SuppressLint("NewApi")
    public void checkKeyboardHeight(final View parentLayout) {
        layoutListener = new ViewTreeObserver.OnGlobalLayoutListener() {
            @Override
            public void onGlobalLayout() {
                if (count < 10) {
                    calculateKeyboardHeight(parentLayout);
                    count++;
                } else {
                    count = 0;
                    if (Build.VERSION.SDK_INT < Build.VERSION_CODES.JELLY_BEAN) {
                        parentLayout.getViewTreeObserver().removeGlobalOnLayoutListener(layoutListener);
                    } else {
                        parentLayout.getViewTreeObserver().removeOnGlobalLayoutListener(layoutListener);
                    }
                }
            }
        };

        parentLayout.getViewTreeObserver().addOnGlobalLayoutListener(layoutListener);

    }

    @SuppressLint("NewApi")
    private void checkKeyboardHeight(final View parentLayout, boolean removeLayoutListener) {
        layoutListener = new ViewTreeObserver.OnGlobalLayoutListener() {
            @Override
            public void onGlobalLayout() {
                calculateKeyboardHeight(parentLayout);
            }
        };
        if (removeLayoutListener) {
            if (Build.VERSION.SDK_INT < Build.VERSION_CODES.JELLY_BEAN) {
                parentLayout.getViewTreeObserver().removeGlobalOnLayoutListener(layoutListener);
            } else {
                parentLayout.getViewTreeObserver().removeOnGlobalLayoutListener(layoutListener);
            }
        } else {
            parentLayout.getViewTreeObserver().addOnGlobalLayoutListener(layoutListener);
        }
    }

    private void calculateKeyboardHeight(final View parentLayout) {
        Rect r = new Rect();
        parentLayout.getWindowVisibleDisplayFrame(r);

        int screenHeight = parentLayout.getRootView().getHeight();

        int heightDifference = screenHeight - (r.bottom);
        if (getScreenOrientation() == Configuration.ORIENTATION_PORTRAIT) {
            if (Build.VERSION.SDK_INT > Build.VERSION_CODES.KITKAT_WATCH) {
                int bottomNavigationHeight;
                Resources resources = activity.getResources();
                int resourceId = resources.getIdentifier("navigation_bar_height", "dimen", "android");
                if (resourceId > 0) {
                    bottomNavigationHeight = resources.getDimensionPixelSize(resourceId);
                } else {
                    bottomNavigationHeight = 100;
                }
                heightDifference = heightDifference - bottomNavigationHeight;
            }
            if (previousHeightDiffrence - heightDifference > 50) {
                popupWindow.dismiss();
            }
            previousHeightDiffrence = heightDifference;
            if (heightDifference > 100) {
                isKeyBoardVisible = true;
                changeKeyboardHeight(heightDifference);
            } else {
                isKeyBoardVisible = false;

            }
        } else if (getScreenOrientation() == Configuration.ORIENTATION_LANDSCAPE) {
            heightDifference = screenHeight / 2 - 50;
            changeKeyboardHeight(heightDifference);
        }
    }

    public int getScreenOrientation() {
        Display getOrient = activity.getWindowManager().getDefaultDisplay();
        int orientation = Configuration.ORIENTATION_UNDEFINED;
        if (getOrient.getWidth() == getOrient.getHeight()) {
            orientation = Configuration.ORIENTATION_SQUARE;
        } else {
            if (getOrient.getWidth() < getOrient.getHeight()) {
                orientation = Configuration.ORIENTATION_PORTRAIT;
            } else {
                orientation = Configuration.ORIENTATION_LANDSCAPE;
            }
        }
        return orientation;
    }

    public void changeKeyboardHeight(int height) {
        keyboardHeight = height;
        LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, keyboardHeight);
        emoticonsCover.setLayoutParams(params);
    }

    public void enableFooterView(EditText messageField) {

        messageField.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                if(SmileyKeyBoard.isKeyboardVisibile()){
                    SmileyKeyBoard.dismissKeyboard();
                } else if(isKeyboardVisibile()) {
                    dismissKeyboard();
                }
            }
        });
    }

    public String getClickedSticker(int gridviewItemPosition) {
        int pagePosition = viewPager.getCurrentItem();
        String unicodeToBeSend = "";
        int drawableId = 0;
        switch (pagePosition) {
            case 0: {
                drawableId = RecentlyUsedStickers.stickerDrawableArrayListRecentCategory.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = RecentlyUsedStickers.stickerUnicodeArrayListRecentcategory.get(gridviewItemPosition);
                break;
            }
            case 1: {
                drawableId = StickerDrawableArrayListBear.stickerBear.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListBear.stickerBear.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);

                break;
            }
            case 2: {
                drawableId = StickerDrawableArrayListGeek.stickerGeek.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListGeek.stickerGeek.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 3: {
                drawableId = StickerDrawableArrayListGery.stickerGery.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListGery.stickerGery.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }

            case 4: {
                drawableId = StickerDrawableArrayListHappyGhost.stickerHappyGhost.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListHappyGhost.stickerHappyGhost.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 5: {
                drawableId = StickerDrawableArrayListLittleDyno.stickerLittleDyno.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListLittleDyno.stickerLittleDyno.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 6: {
                drawableId = StickerDrawableArrayListMomon.stickerMomon.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListMomon.stickerMomon.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 7: {
                drawableId = StickerDrawableArrayListMonster.stickerMonster.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListMonster.stickerMonster.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 8: {
                drawableId = StickerDrawableArrayListPenguin.stickerPenguin.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListPenguin.stickerPenguin.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 9: {
                drawableId = StickerDrawableArrayListPirate.stickerPirate.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListPirate.stickerPirate.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 10: {
                drawableId = StickerDrawableArrayListSkaterBoy.stickerSkaterBoy.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListSkaterBoy.stickerSkaterBoy.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 11: {
                drawableId = StickerDrawableArrayListVampire.stickerVampire.get(gridviewItemPosition);
                //drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = StickerPatternArrayListVampire.stickerVampire.get(gridviewItemPosition);
                RecentlyUsedStickers.addSticker(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            default:
                break;
        }
        return unicodeToBeSend;
    }
}
