package com.inscripts.heartbeats;


import android.app.IntentService;
import android.content.Intent;
import android.text.Spannable;

import com.inscripts.activities.R;
import com.inscripts.emoji.custom.EmoticonUtils;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.models.Buddy;
import com.inscripts.models.Conversation;
import com.inscripts.plugins.Smilies;
import com.inscripts.utils.Logger;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Iterator;
import java.util.List;

public class RecentSyncService extends IntentService {
    final static String TAG = RecentSyncService.class.getSimpleName();

    public RecentSyncService() {
        super(TAG);
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        Logger.error(TAG,"onHandleIntent called");
        List<Conversation> conversationList = Conversation.getAllConversations();
        JSONObject recentJsonObject = new JSONObject();
        for(Iterator iterator = conversationList.iterator();iterator.hasNext();){
            Conversation conversation = (Conversation) iterator.next();
            try {
            if(conversation.chatroomID == 0){ //One-on-One

                JSONObject innerObject = new JSONObject();

                innerObject.put("t",conversation.timestamp);
                innerObject.put("msgid",-1);
                innerObject.put("n",conversation.name);
                if(!isSmileyMessage(conversation.lstMessage))
                    innerObject.put("msg",conversation.lstMessage);
                else{
                    JSONObject smileymessage = new JSONObject();
                    smileymessage.put("m",conversation.lstMessage);
                    smileymessage.put("type","smiley");
                    innerObject.put("msg","CC^CONTROL_"+smileymessage.toString());
                    Logger.error(TAG,"Smiley message value = "+ "CC^CONTROL_"+smileymessage.toString());
                }
                recentJsonObject.put(String.valueOf(conversation.buddyID),innerObject);
            }else{  // chatroom
                JSONObject innerObject = new JSONObject();
                innerObject.put("t",conversation.timestamp);
                innerObject.put("msg",conversation.lstMessage);
                innerObject.put("msgid",-1);
                innerObject.put("n",conversation.name);
                recentJsonObject.put("_"+String.valueOf(conversation.chatroomID),innerObject);
            }

            } catch (JSONException e) {
                e.printStackTrace();
            }
        }

        Logger.error(TAG,"Recent Json value = "+recentJsonObject.toString());

        final VolleyHelper vHelper = new VolleyHelper(this, URLFactory.getRecieveURL(), new VolleyAjaxCallbacks() {

            @Override
            public void successCallback(String response) {
                Logger.error(TAG,"Success responce = "+response);

                try {
                    String temp = new JSONObject(response).getString("recentchats");
                    JSONObject jsonObject = new JSONObject(temp);
                    Logger.error(TAG,"recent chats = "+jsonObject);
                    for(Iterator iterator = jsonObject.keys();iterator.hasNext();){
                        String key = (String)iterator.next();
                        Logger.error(TAG,"Key = "+key);
                        String innerString= jsonObject.getString(key);
                        JSONObject innerJsonObject = new JSONObject(innerString);
                        String msg = innerJsonObject.getString("msg");
                        if(msg.contains("CC^CONTROL_")){
                            String trimmedMsg = msg.replace("CC^CONTROL_","");
                            JSONObject trimmed = new JSONObject(trimmedMsg);
                            Logger.error(TAG,"Trimmed type = "+trimmed.getString("type"));
                            switch (trimmed.getString("type")){

                                case "smiley":
                                    msg = trimmed.getString("m");
                                    break;
                            }
                        }

                        if(key.contains("_")){ //is chatroom
                            String chatroomId = key.replace("_","").trim();
                            if (Conversation.isNewChatroomConversation(chatroomId)) {
                                Logger.error(TAG, "Is New Chatroom Conversation");
                                Conversation conversation = new Conversation();
                                conversation.chatroomID = Long.parseLong(chatroomId);
                                conversation.timestamp = innerJsonObject.getLong("t");
                                conversation.lstMessage = msg;
                                conversation.name = innerJsonObject.getString("n");
                                conversation.avtarUrl = "";
                                conversation.save();
                            } else {
                                Logger.error(TAG, "Is old chatroom Conversation");
                                Conversation conversation = Conversation.getConversationByChatroomID(chatroomId);
                                if (conversation != null) {
                                    conversation.timestamp = innerJsonObject.getLong("t");
                                    conversation.lstMessage = msg;
                                    conversation.save();
                                }
                            }
                        }else{ // is buddy
                            Logger.error(TAG,"is new buddy conversation ? "+Conversation.isNewBuddyConversation(key));
                            if (Conversation.isNewBuddyConversation(key)) {
                                Logger.error(TAG, "Is New Conversation");
                                Conversation conversation = new Conversation();
                                conversation.buddyID = Long.parseLong(key);
                                conversation.timestamp =innerJsonObject.getLong("t");
                                conversation.lstMessage =msg;
                                Buddy buddy = Buddy.getBuddyDetails(key);
                                if(buddy != null){
                                    conversation.name = buddy.name;
                                    conversation.avtarUrl = buddy.avatarURL;
                                }else{
                                    conversation.name = innerJsonObject.getString("n");
                                    conversation.avtarUrl = "";
                                }
                                conversation.save();

                            } else {
                                Logger.error(TAG, "Is old Conversation");
                                Conversation conversation = Conversation.getConversationByBuddyID(key);
                                if (conversation != null) {
                                    conversation.timestamp =innerJsonObject.getLong("t");
                                    conversation.lstMessage = msg;
                                    Buddy buddy = Buddy.getBuddyDetails(key);
                                    if(buddy != null){
                                        conversation.name = buddy.name;
                                        conversation.avtarUrl = buddy.avatarURL;
                                    }else{
                                        conversation.name = innerJsonObject.getString("n");
                                        conversation.avtarUrl = "";
                                    }
                                    conversation.save();
                                }
                            }
                        }
                    }
                } catch (JSONException e) {
                    e.printStackTrace();
                }

                Intent iintent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.ONE_ON_ONE_HEARTBEAT_NOTIFICATION);
                iintent.putExtra(BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_RECENT_FRAGMENT, 1);
                PreferenceHelper.getContext().sendBroadcast(iintent);
            }

            @Override
            public void failCallback(String response, boolean isNoInternet) {
                Logger.error(TAG,"fail responce = "+response);
            }
        });

        vHelper.addNameValuePair("recentchats",recentJsonObject.toString());
        vHelper.sendAjax();
    }


    private boolean isSmileyMessage(String message){

        if (message.contains("<img class=\"cometchat_smiley\"")){
            Spannable spannable = Smilies.convertImageTagToEmoji(message, this, false,
                    R.drawable.class);
            return EmoticonUtils.isOnlySmileyHtmlSmiley(spannable);
        }else{

            return EmoticonUtils.isSmileyMessage(message);
        }

    }
}
