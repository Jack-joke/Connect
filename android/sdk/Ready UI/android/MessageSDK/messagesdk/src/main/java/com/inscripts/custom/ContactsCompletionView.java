/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.custom;

import android.content.Context;
import android.graphics.Color;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.inscripts.R;
import com.inscripts.jsonphp.Css;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileTheme;
import com.inscripts.pojos.ContactPojo;
import com.inscripts.utils.StaticMembers;
import com.tokenautocomplete.TokenCompleteTextView;

public class ContactsCompletionView extends TokenCompleteTextView {

    public ContactsCompletionView(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    protected View getViewForObject(Object object) {
        ContactPojo contact = (ContactPojo) object;

        LayoutInflater l = (LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        LinearLayout view = (LinearLayout) l.inflate(R.layout.cc_contact_token,
                (ViewGroup) ContactsCompletionView.this.getParent(), false);
        ((TextView) view.findViewById(R.id.name)).setText(contact.name);

        String color;
        MobileTheme mobileTheme = JsonPhp.getInstance().getMobileTheme();
        Css css = JsonPhp.getInstance().getCss();
        if (mobileTheme != null && null != mobileTheme.getActionbarColor()) {
            color = mobileTheme.getActionbarColor();
        } else if (null != css) {
            color = css.getTabTitleBackground();
        } else {
            color = StaticMembers.COMETCHAT_DARK_GREEN;
        }
        view.setBackgroundColor(Color.parseColor(color));
        return view;
    }

    @Override
    protected Object defaultObject(String completionText) {
        return new ContactPojo(completionText, completionText.replace(" ", ""));
    }

    @Override
    protected void onSelectionChanged(int arg0, int arg1) {
        try {
            super.onSelectionChanged(arg0, arg1);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}