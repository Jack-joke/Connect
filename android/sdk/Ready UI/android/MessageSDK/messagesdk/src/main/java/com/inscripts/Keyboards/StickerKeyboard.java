/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.Keyboards;


import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.Rect;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.support.v4.view.ViewPager;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ImageSpan;
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
import com.inscripts.R;
import com.inscripts.adapters.SlidingStripAdapter;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.StickerClickInterface;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.mapping.RecentlyUsedStickers;
import com.inscripts.mapping.StickerDrawableArrayListBear;
import com.inscripts.mapping.StickerDrawableArrayListGeek;
import com.inscripts.mapping.StickerDrawableArrayListGery;
import com.inscripts.mapping.StickerDrawableArrayListHappyGhost;
import com.inscripts.mapping.StickerDrawableArrayListLittleDyno;
import com.inscripts.mapping.StickerDrawableArrayListMomon;
import com.inscripts.mapping.StickerDrawableArrayListMonster;
import com.inscripts.mapping.StickerDrawableArrayListPenguin;
import com.inscripts.mapping.StickerDrawableArrayListPirate;
import com.inscripts.mapping.StickerDrawableArrayListSkaterBoy;
import com.inscripts.mapping.StickerDrawableArrayListVampire;
import com.inscripts.mapping.StickerHashmapPatternToDrawable;
import com.inscripts.mapping.StickerPatternArrayListBear;
import com.inscripts.mapping.StickerPatternArrayListGeek;
import com.inscripts.mapping.StickerPatternArrayListGery;
import com.inscripts.mapping.StickerPatternArrayListHappyGhost;
import com.inscripts.mapping.StickerPatternArrayListLittleDyno;
import com.inscripts.mapping.StickerPatternArrayListMomon;
import com.inscripts.mapping.StickerPatternArrayListMonster;
import com.inscripts.mapping.StickerPatternArrayListPenguin;
import com.inscripts.mapping.StickerPatternArrayListPirate;
import com.inscripts.mapping.StickerPatternArrayListSkaterBoy;
import com.inscripts.mapping.StickerPatternArrayListVampire;


public class StickerKeyboard {
    private View popUpView;
    private ViewPager viewPager;
    //private PagerAdapterStickerPopup adapterEmojiPopup;
    private PopupWindow popupWindow;
    private LinearLayout emoticonsCover;
    private int previousHeightDiffrence = 0, keyboardHeight ,userKeyboardHeight = -1;
    private boolean isKeyBoardVisible;
    private ImageView ivEmojiClear;
    private Activity activity;
    int count = 0;
    private static ViewTreeObserver.OnGlobalLayoutListener layoutListener;
    private SlidingStripAdapter adapterEmojiPopup;
    private static int stickerSize = 0;


    public void enable(Activity activity, StickerClickInterface clickListener, Integer emojiFooterId,
                       final EditText edtMessage) {
        this.activity = activity;
        popUpView = activity.getLayoutInflater().inflate(R.layout.cc_activity_fixed_tabs_sticker, null);
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
        adapterEmojiPopup = new SlidingStripAdapter(activity, Color.CYAN, Color.BLACK, clickListener);

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

    /**
     * Set height for sticker keyboard.
     * The sticker keyboard adjusts its height to match the height of your in-build keyboard. If the height is not
     * matching, then you can use this function to set the height.
     * @param height
     *            Pass the height in pixels e.g 600 without any unit.<br>
     *            Pass -1 to reset the keyboard height and let sticker keyboard to handle the height adjustment
     */
    public void setKeyBoardHeight(int height) {
        userKeyboardHeight = height;
    }

    /**
     * Change the size of sticker which will be shown in your chat
     * @param size
     */
    public static void setStickerSize(int size) {
        stickerSize = size;
    }

    /**
     * Show sticker message to sticker image
     * @param context
     * @param message
     * @return
     */
    public static SpannableString showSticker(Context context, String message) {
        Resources res = context.getResources();
        Integer abc = StickerHashmapPatternToDrawable.stickerMap.get(message);
        SpannableString spannable = new SpannableString(message);
        if (abc == null) {
            return spannable;
        } else {
            Drawable drawable = res.getDrawable(abc);
            if (stickerSize < 350) {
                stickerSize = 350;
            }
            drawable.setBounds(0, 0, stickerSize, stickerSize);
            spannable.setSpan(new ImageSpan(drawable), 0, message.length(), Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
            return spannable;
        }
    }


    public void showKeyboard(View parentLayout) {
        calculateKeyboardHeight(parentLayout, getScreenOrientation());
        if (PreferenceHelper.contains(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT)) {
            if (keyboardHeight != Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT))) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT, keyboardHeight);
            }
        } else {
            PreferenceHelper.save(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT, keyboardHeight);
        }
        if (!popupWindow.isShowing()) {
            if (userKeyboardHeight == -1) {
                popupWindow.setHeight(keyboardHeight);
            } else {
                popupWindow.setHeight(userKeyboardHeight);
            }
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
        final int screenOrientation = getScreenOrientation();
        layoutListener = new ViewTreeObserver.OnGlobalLayoutListener() {
            @Override
            public void onGlobalLayout() {
                if (count < 10) {
                    calculateKeyboardHeight(parentLayout, screenOrientation);
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
        final int screenOrientation = getScreenOrientation();
        layoutListener = new ViewTreeObserver.OnGlobalLayoutListener() {
            @Override
            public void onGlobalLayout() {
                if (count < 10) {
                    calculateKeyboardHeight(parentLayout, screenOrientation);
                    count++;
                } else {
                    count = 0;
                }
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

    private void calculateKeyboardHeight(final View parentLayout, int screenOrientation) {
        Rect r = new Rect();
        parentLayout.getWindowVisibleDisplayFrame(r);

        int screenHeight = parentLayout.getRootView().getHeight();

        int heightDifference = screenHeight - (r.bottom);
        if (screenOrientation == Configuration.ORIENTATION_PORTRAIT) {
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
                if (heightDifference == 0) {
                    if (PreferenceHelper.contains(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT)) {
                        heightDifference = Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT));
                    } else {
                        heightDifference = screenHeight / 2 - 50;
                    }
                    changeKeyboardHeight(heightDifference);
                }
                isKeyBoardVisible = false;

            }
        } else if (screenOrientation == Configuration.ORIENTATION_LANDSCAPE) {
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
                if (SmileyKeyBoard.isKeyboardVisibile()) {
                    SmileyKeyBoard.dismissKeyboard();
                } else if (isKeyboardVisibile()) {
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
