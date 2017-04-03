/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.Keyboards;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.Rect;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.support.v4.view.ViewPager;
import android.view.Display;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup.LayoutParams;
import android.view.ViewTreeObserver;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;

import com.astuetz.viewpager.extensions.FixedTabsView;
import com.inscripts.R;
import com.inscripts.adapters.FixedIconTabsAdapter;
import com.inscripts.adapters.PagerAdapterEmojiPopup;
import com.inscripts.custom.EmoticonHandler;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.interfaces.EmojiClickInterface;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.mapping.EmojiDrawableArrayListCarCategory;
import com.inscripts.mapping.EmojiDrawableArrayListNatureCategory;
import com.inscripts.mapping.EmojiDrawableArrayListObjectsCategory;
import com.inscripts.mapping.EmojiDrawableArrayListPeopleCategory;
import com.inscripts.mapping.EmojiDrawableArrayListSymbolsCategory;
import com.inscripts.mapping.EmojiUnicodeArrayListCarCategory;
import com.inscripts.mapping.EmojiUnicodeArrayListNatureCategory;
import com.inscripts.mapping.EmojiUnicodeArrayListObjectsCategory;
import com.inscripts.mapping.EmojiUnicodeArrayListPeopleCategory;
import com.inscripts.mapping.EmojiUnicodeArrayListSymbolsCategory;
import com.inscripts.mapping.RecentlyUsedEmoji;

public class SmileyKeyBoard {
    private View popUpView;
    private ViewPager viewPager;
    private PagerAdapterEmojiPopup adapterEmojiPopup;
    private static PopupWindow popupWindow;
    private static LinearLayout emoticonsCover;
    private int previousHeightDiffrence = 0, keyboardHeight, userKeyboardHeight = -1;
    private boolean isSystemKeyBoardVisible;
    private ImageView ivEmojiClear;
    private Activity activity;
    private EmoticonHandler mEmoticonHandler;
    int count = 0;
    private static ViewTreeObserver.OnGlobalLayoutListener layoutListener;

    public void enable(Activity activity, EmojiClickInterface clickListener, Integer emojiFooterId,
                       final EditText edtMessage) {
        this.activity = activity;
        popUpView = activity.getLayoutInflater().inflate(R.layout.cc_activity_fixed_tabs, null);
        viewPager = (ViewPager) popUpView.findViewById(R.id.pager_popviewPopupEmoji);
        viewPager.setOffscreenPageLimit(6);
        emoticonsCover = (LinearLayout) activity.findViewById(emojiFooterId);
        ivEmojiClear = (ImageView) popUpView.findViewById(R.id.ivClearEmoji);
        adapterEmojiPopup = new PagerAdapterEmojiPopup(activity, 6, Color.CYAN, Color.BLACK, clickListener);
        viewPager.setAdapter(adapterEmojiPopup);
        viewPager.setCurrentItem(1);
        FixedTabsView fixedTabs = (FixedTabsView) popUpView.findViewById(R.id.fixed_tabsPopupEmoji);

        FixedIconTabsAdapter fixedIconTabsAdapter = new FixedIconTabsAdapter(activity);
        fixedTabs.setAdapter(fixedIconTabsAdapter);
        fixedTabs.setViewPager(viewPager);
        mEmoticonHandler = new EmoticonHandler(edtMessage, activity.getApplicationContext());
        // Creating a pop window for emoticons keyboard

        popupWindow = new PopupWindow(popUpView, LayoutParams.MATCH_PARENT, keyboardHeight, false);

        ivEmojiClear.setOnClickListener(new OnClickListener() {

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
     * Set height for emoji keyboard.
     * The emoji keyboard adjusts its height to match the height of your in-build keyboard. If the height is not
     * matching, then you can use this function to set the height.
     * @param height
     *            Pass the height in pixels e.g 600 without any unit.<br>
     *            Pass -1 to reset the keyboard height and let emoji keyboard to handle the height adjustment
     */
    public void setKeyBoardHeight(int height) {
        userKeyboardHeight = height;
    }
    public void showKeyboard(View parentLayout) {

        calculateKeyboardHeight(parentLayout, getScreenOrientation());
        /*if (PreferenceHelper.contains(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT)) {
            if (keyboardHeight != 0 && keyboardHeight != Integer.parseInt(PreferenceHelper.get(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT))) {
                PreferenceHelper.save(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT, keyboardHeight);
            }
        } else {
            PreferenceHelper.save(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT, keyboardHeight);
        }*/


        if(keyboardHeight != 0){
            PreferenceHelper.save(PreferenceKeys.DataKeys.EMOJI_KEYBOARD_HEIGHT, keyboardHeight);
        }


        if (!popupWindow.isShowing()) {
            if (userKeyboardHeight == -1) {
                popupWindow.setHeight(keyboardHeight);
            } else {
                popupWindow.setHeight(userKeyboardHeight);
            }
            if (isSystemKeyBoardVisible) {
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

    public static void dismissKeyboard() {
        if (popupWindow.isShowing()) {
            emoticonsCover.setVisibility(View.GONE);
            popupWindow.dismiss();
        }
    }

    public static boolean isKeyboardVisibile() {
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
        final int screenorientation = getScreenOrientation();
        layoutListener = new ViewTreeObserver.OnGlobalLayoutListener() {
            @Override
            public void onGlobalLayout() {
                if (count < 10) {
                    calculateKeyboardHeight(parentLayout, screenorientation);
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

    private void calculateKeyboardHeight(final View parentLayout, int screenorientation) {
        Rect r = new Rect();
        parentLayout.getWindowVisibleDisplayFrame(r);

        int screenHeight = parentLayout.getRootView().getHeight();

        int heightDifference = screenHeight - (r.bottom);
        if (screenorientation == Configuration.ORIENTATION_PORTRAIT) {
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
                isSystemKeyBoardVisible = true;
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
                isSystemKeyBoardVisible = false;
            }
        } else if (screenorientation == Configuration.ORIENTATION_LANDSCAPE) {
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
        LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT, keyboardHeight);
        emoticonsCover.setLayoutParams(params);
    }

    public void enableFooterView(EditText messageField) {

        messageField.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View v) {
                dismissKeyboard();
            }
        });
    }

    public void getClickedEmoji(int gridviewItemPosition) {
        int pagePosition = viewPager.getCurrentItem();
        int drawableId = 0;
        Drawable drawable = null;
        String unicodeToBeSend = "";
        switch (pagePosition) {

            case 0: {
                drawableId = RecentlyUsedEmoji.emojiDrawableArrayListRecentCategory.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = RecentlyUsedEmoji.emojiUnicodeArrayListRecentcategory.get(gridviewItemPosition);
                break;
            }
            case 1: {
                drawableId = EmojiDrawableArrayListPeopleCategory.emojiPeople.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = EmojiUnicodeArrayListPeopleCategory.unicodePeople.get(gridviewItemPosition);
                RecentlyUsedEmoji.addEmoji(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 2: {
                drawableId = EmojiDrawableArrayListNatureCategory.emojiNature.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = EmojiUnicodeArrayListNatureCategory.unicodeNature.get(gridviewItemPosition);
                RecentlyUsedEmoji.addEmoji(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 3: {
                drawableId = EmojiDrawableArrayListObjectsCategory.emojiObjects.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = EmojiUnicodeArrayListObjectsCategory.unicodeObjects.get(gridviewItemPosition);
                RecentlyUsedEmoji.addEmoji(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }
            case 4: {
                drawableId = EmojiDrawableArrayListCarCategory.emojicars.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = EmojiUnicodeArrayListCarCategory.unicodeCar.get(gridviewItemPosition);
                RecentlyUsedEmoji.addEmoji(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }

            case 5: {
                drawableId = EmojiDrawableArrayListSymbolsCategory.emojiSymbols.get(gridviewItemPosition);
                drawable = activity.getResources().getDrawable(drawableId);
                unicodeToBeSend = EmojiUnicodeArrayListSymbolsCategory.unicodeSymbols.get(gridviewItemPosition);
                RecentlyUsedEmoji.addEmoji(unicodeToBeSend, drawableId, adapterEmojiPopup);
                break;
            }

            default:
                break;
        }

        mEmoticonHandler.insert(unicodeToBeSend + " ", drawable);
    }
}
