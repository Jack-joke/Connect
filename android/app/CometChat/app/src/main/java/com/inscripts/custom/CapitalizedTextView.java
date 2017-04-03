package com.inscripts.custom;


import android.content.Context;
import android.util.AttributeSet;
import android.widget.TextView;

public class CapitalizedTextView extends TextView {

    public CapitalizedTextView(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    public void setText(CharSequence text, BufferType type) {
        if (text.length() > 0) {
            text = String.valueOf(text.charAt(0)).toUpperCase() + text.subSequence(1, text.length());
        }
        super.setText(text, type);
    }
}