package com.inscripts.activities;

import android.content.Intent;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;

import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Bot;
import com.inscripts.utils.SuperActivity;

public class BotDetailActivity extends SuperActivity {

    private ImageView botAvtarView;
    private TextView botDescription,botName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bot_detail);

        setActionBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY));
        setStatusBarColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY_DARK));


        botAvtarView = (ImageView) findViewById(R.id.img_bot_avtar);
        botDescription = (TextView) findViewById(R.id.txt_bot_description);
        botName = (TextView) findViewById(R.id.txt_bot_name);

        Intent intent = getIntent();
        String botId = intent.getStringExtra("BOT_ID");
        Bot bot = Bot.getBotDetails(botId);
        setActionBarTitle(bot.botName);
        if(bot.botDescription!= null && bot.botDescription.isEmpty())
            botDescription.setText("Hi.. I am helper Bot.");
        else{
            botDescription.setText(bot.botDescription);
        }
        botName.setText(bot.botName);

        botAvtarView.getBackground().setColorFilter(Color.parseColor(PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY)), PorterDuff.Mode.SRC_ATOP);
       LocalStorageFactory.getPicassoInstance().load(bot.botAvatar).placeholder(R.drawable.ic_robot)
                .resize(55, 55).into(botAvtarView);

    }
}
