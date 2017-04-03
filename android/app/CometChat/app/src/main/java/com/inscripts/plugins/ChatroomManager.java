/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.text.InputType;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.inscripts.activities.ChatroomActivity;
import com.inscripts.activities.CometChatActivity;
import com.inscripts.activities.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.heartbeats.HeartbeatChatroom;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.helpers.VolleyHelper;
import com.inscripts.interfaces.CometchatCallbacks;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.Config;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.Lang;
import com.inscripts.jsonphp.NewMobile;
import com.inscripts.keys.BroadcastReceiverKeys;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.ChatroomKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Chatroom;
import com.inscripts.models.Conversation;
import com.inscripts.transports.CometserviceChatroom;
import com.inscripts.transports.WebsyncChatroom;
import com.inscripts.utils.CommonUtils;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;
import com.inscripts.utils.StaticMembers;

import org.json.JSONArray;
import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

public class ChatroomManager {
    private static Lang lang;
    private static String textColor;
    private static ProgressDialog progressDialog;


    /**
     * @param chatroomId : Current chatroom id
     * @param flag       : Flag to check leaveChatroom is normal or because owner of
     *                   chatroom has kicked you or banned you. <br/>
     *                   - LeaveChatroom normal means either user has manually
     *                   loggedout, set flag value to <b>"0"</b>.<br />
     *                   - If leaveChatroom because of owner has banned you from
     *                   current chatroom , then set this flag value to <b>"1"</b>. <br/>
     *                   - If leavechatroom because someone have kicked you from
     *                   current chatroom, set flag value to <b>"2"</b>.
     *
     */
    public static void leaveChatroom(final Long chatroomId, String flag) {
        try {
            final Context context = PreferenceHelper.getContext();
            VolleyHelper vHelper = new VolleyHelper(context, URLFactory.getChatroomLeaveURL());

            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID, chatroomId);

            if (flag.equals("0") || flag.equals("2")) {
                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");

                if (flag.equals("2")) {
                    CometChatActivity.tabActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(context, JsonPhp.getInstance().getLang().getChatrooms().get36(),
                                    Toast.LENGTH_LONG).show();
                        }
                    });

                }
            } else if (flag.equals("1")) {
                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_FLAG, "1");
                CometChatActivity.tabActivity.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(context, JsonPhp.getInstance().getLang().getChatrooms().get37(),
                                Toast.LENGTH_LONG).show();
                    }
                });
            } else if (flag.equals("3")) {
                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.FLAG, "0");
                if (chatroomId == Long.parseLong(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID))) {
                    CometChatActivity.tabActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Toast.makeText(context, JsonPhp.getInstance().getLang().getChatrooms().get55(),
                                    Toast.LENGTH_LONG).show();
                        }
                    });
                }
            }
            vHelper.sendAjax();

            SessionData session = SessionData.getInstance();

            if (PreferenceHelper.contains(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID)
                    && !("0".equals(PreferenceHelper.get(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID)))) {
                Intent intent = new Intent(context, CometChatActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                context.startActivity(intent);
            }

            session.setCurrentChatroom(0);
            session.setCurrentChatroomPassword("");
            session.setCurrentChatroomName("");
            session.setChatroomHeartBeatTimestamp("");

            Chatroom cr = Chatroom.getChatroomDetails(chatroomId);
            if (null != cr) {
                cr.unreadCount = 0;
                cr.save();
            }
            PushNotificationsManager.unsubscribe(true,false);
            Config config = JsonPhp.getInstance().getConfig();
            if (null != config && config.getUSECOMET().equals("1")) {
                String transport = config.getTRANSPORT();
                if (transport.equals("cometservice")) {
                    CometserviceChatroom.getInstance().unSubscribe();
                } else if (transport.equals("cometservice-selfhosted")) {
                    WebsyncChatroom.getInstance().unsubscribe();
                }
            }
            PreferenceHelper.save(PreferenceKeys.DataKeys.ACTIVE_CHATROOM_ID, "0");
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD);
            PreferenceHelper.removeKey(PreferenceKeys.DataKeys.JSON_CHATROOM_MEMBERS);

            if (PreferenceHelper.contains(CometChatKeys.ChatroomKeys.CHATROOM_JSON)){
                JSONObject temp =new JSONObject(PreferenceHelper.get(CometChatKeys.ChatroomKeys.CHATROOM_JSON));
                if(temp.has(chatroomId.toString())){
                    temp.remove(chatroomId.toString());
                    PreferenceHelper.save(CometChatKeys.ChatroomKeys.CHATROOM_JSON, temp.toString());
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void joinChatroom(final long chatroomId, final String chatroomName, final String password,
                                    final int silent, final Activity activity, final CometchatCallbacks callbacks) {
        final SessionData session = SessionData.getInstance();
        session.setCurrentChatroomPassword(password);

        VolleyHelper vHelper = new VolleyHelper(activity, URLFactory.getChatroomPasswordUrl(),

                new VolleyAjaxCallbacks() {

                    @Override
                    public void successCallback(String response) {
                        try {
                            //Logger.error("JOIN RESPONSE: " + response);
                            JSONObject chatroomJson = new JSONObject(response);
                            String joinResponse = chatroomJson.getString("s");

                            if (joinResponse.equals("BANNED")) {
                                /*
                                 * User is banned for this chatroom value
								 * returned 2
								 */
                                Toast.makeText(PreferenceHelper.getContext(),
                                        JsonPhp.getInstance().getLang().getChatrooms().get37(), Toast.LENGTH_SHORT)
                                        .show();
                            } else if (joinResponse.equals("INVALID_PASSWORD")) {
                                /* Wrong password value returned 0 */
                                Toast.makeText(PreferenceHelper.getContext(),
                                        JsonPhp.getInstance().getLang().getChatrooms().get23(), Toast.LENGTH_SHORT)
                                        .show();
                            } else if (joinResponse.equals(PreferenceKeys.DataKeys.INVALID_CHATROOM)) {
                                Toast.makeText(PreferenceHelper.getContext(),
                                        JsonPhp.getInstance().getLang().getChatrooms().get55(), Toast.LENGTH_SHORT)
                                        .show();
                            } else {
                                /* User is valid */
                                long previousChatroomId = session.getCurrentChatroom();
                                if (previousChatroomId != 0 && previousChatroomId != chatroomId) {
                                    //leave not called
                                    //leaveChatroom(previousChatroomId, "0");
                                }
                                Logger.error("channel join "+ chatroomJson.getString("push_channel"));
                                session.setChatroomParseChannel(chatroomJson.getString("push_channel"));

                                if(chatroomJson.has("cometid")) {
                                    session.setChatroomCometId(chatroomJson.getString("cometid"));
                                    PreferenceHelper.save(PreferenceKeys.DataKeys.CHATROOM_COMET_ID, chatroomJson.getString("cometid"));
                                }
                                session.setIsModerator(chatroomJson.getString("ismoderator"));

                                PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_ID, String.valueOf(chatroomId));
                                PreferenceHelper.save(PreferenceKeys.DataKeys.CURRENT_CHATROOM_PASSWORD, password);


                                startChatroomActivity(chatroomId, chatroomName, activity);
                                session.setCurrentChatroomName(chatroomName);
                                PushNotificationsManager.subscribe(true, "");

                                Config config = JsonPhp.getInstance().getConfig();
                                if (null != config && config.getUSECOMET().equals("1")) {
                                    session.setChatroomHeartbeatInterval(Long.parseLong(config.getREFRESHBUDDYLIST()) * 1000);
                                } else {
                                    session.setChatroomHeartbeatInterval(Long.parseLong(config.getMinHeartbeat()));
                                }
                                if (chatroomJson.has("timestamp")) {
                                    session.setChatroomHeartBeatTimestamp(chatroomJson.getString("timestamp"));
                                } else {
                                    session.setChatroomHeartBeatTimestamp("0");
                                }

                                HeartbeatChatroom.getInstance().changeChatroomHeartbeatInverval();

                                // return;
                            }

                        } catch (Exception e) {
                            Toast.makeText(PreferenceHelper.getContext(),
                                    JsonPhp.getInstance().getLang().getChatrooms().get56(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }
                        callbacks.successCallback();
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                        if (isNoInternet) {
                            Toast.makeText(activity, JsonPhp.getInstance().getLang().getMobile().get24(),
                                    Toast.LENGTH_SHORT).show();
                        }
                        callbacks.failCallback();
                    }
                });


        Logger.error("Password value = "+password);
        vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, String.valueOf(chatroomId));
        vHelper.addNameValuePair(CometChatKeys.AjaxKeys.PASSWORD, password);
        vHelper.sendAjax();
    }

    public static void startChatroomActivity(long chatroomId, String chatroomName, Context context) {
        Intent intent = new Intent(context, ChatroomActivity.class);
        intent.putExtra(StaticMembers.INTENT_CHATROOM_ID, chatroomId);
        intent.putExtra(StaticMembers.INTENT_CHATROOM_NAME, chatroomName);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        if(PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_IMAGE_URL)){
            intent.putExtra("ImageUri",PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_IMAGE_URL));
        }
        if(PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_VIDEO_URL)){
            intent.putExtra("VideoUri",PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_VIDEO_URL));
        }
        if(PreferenceHelper.contains(PreferenceKeys.DataKeys.SHARE_AUDIO_URL)){
            intent.putExtra("AudioUri",PreferenceHelper.get(PreferenceKeys.DataKeys.SHARE_AUDIO_URL));
        }
        context.startActivity(intent);
    }

    public static boolean isJoinChatroomMessage(String message) {
        return message.contains(CometChatKeys.ChatroomKeys.JOIN_KEY);
		/*if (message.contains(CometChatKeys.ChatroomKeys.JOIN_KEY)) {
			parseJoinRequest(message);
			return true;
		}
		return false;*/

    }

    public static boolean isDeleteMessage(String message) {
        return message.contains(ChatroomKeys.DELETE_MESSAGE_KEY);
    }

    public static String getMessageId(String message) {
        return message.split("_")[2];
    }

    public static String parseJoinRequest(String message) {
        try {
            int startIndex = message.indexOf(CometChatKeys.ChatroomKeys.JOIN_KEY);
            String submessage = message.substring(startIndex, message.length());
            String parts[] = submessage.split(","), joinRoomId, joinRoomPassword, joinRoomName;

            joinRoomPassword = parts[1].substring(1, parts[1].length() - 1);
            joinRoomName = parts[2].substring(1, parts[2].indexOf("')"));
            joinRoomName = new String(CommonUtils.decodeBase64(joinRoomName), StaticMembers.UTF_8);
            joinRoomId = parts[0].substring(CometChatKeys.ChatroomKeys.JOIN_KEY.length() + 1, parts[0].length() - 1);

            if (joinRoomPassword.equals("")) {
                joinRoomPassword = "#";
            }
            return joinRoomId + "," + joinRoomName + "," + joinRoomPassword;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "";
    }

    public static boolean isKickedChatroomMessage(String message) {
        return message.contains(CometChatKeys.ChatroomKeys.KICK_KEY);
    }

    public static boolean isDeleteChatroomMessage(String message) {
        return message.contains(ChatroomKeys.DELETE_CHATROOM_MESSAGE);
    }

    public static boolean isBannedChatroomMessage(String message) {
        return message.contains(CometChatKeys.ChatroomKeys.BAN_KEY);
    }

    public static void kickUser(String messageId) {
        try {
            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getKickUserURL());

            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
                    .getCurrentChatroom());

			/* On receiver side value of kickid = kicked */
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICKID, CometChatKeys.ChatroomKeys.KICKED);
			/* kick parameter holds timestamp */
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICK, messageId);
            vHelper.sendCallBack(false);
            vHelper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void kickUserChatroom(long kickId, int kick) {
        try {
            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getKickUserURL());
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, SessionData.getInstance()
                    .getCurrentChatroom());
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICKID, kickId);
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.KICK, kick);
            vHelper.sendCallBack(false);
            vHelper.sendAjax();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void banUser(String messageId) {
        try {
            String chatroomId = String.valueOf(SessionData.getInstance().getCurrentChatroom());

            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getBanUserURL());

            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, chatroomId);
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_ID, CometChatKeys.ChatroomKeys.BANNED);
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN, messageId);
            vHelper.sendCallBack(false);
            vHelper.sendAjax();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void banUserChatroom(long banid, long chatroomId, int ban) {
        try {
            VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getBanUserURL(), new VolleyAjaxCallbacks() {
                @Override
                public void successCallback(String response) {
                }

                @Override
                public void failCallback(String response, boolean isNoInternet) {
                }
            });
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CURRENT_ROOM, chatroomId);
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN_ID, banid);
            vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.BAN, ban);
            vHelper.addNameValuePair(ChatroomKeys.POPOUTMODE, 0);
            vHelper.sendCallBack(false);
            vHelper.sendAjax();

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static boolean isSubscribedToChatroom(Long windowId) {
        return (SessionData.getInstance().getCurrentChatroom() == windowId);
    }

    public static String getColoredText(String message, boolean isMyMessage) {
        if (isMyMessage) {
            textColor = StaticMembers.MY_DEFAULT_TEXT_COLOR;
        } else {
            textColor = StaticMembers.DEFAULT_TEXT_COLOR;
        }
        Document doc = Jsoup.parseBodyFragment(message);
        Elements spantags = doc.select(StaticMembers.SPAN_TAG);
        for (Element span : spantags) {
            String[] color = span.attr(StaticMembers.STYLE_ATTR).split(":");
            if (!isMyMessage) {
                textColor = color[1];
            }
            message = message.replace(span.outerHtml(), span.html().replace(" />", ""));
        }
        return message;
    }

    public static void deleteChatroom(Context context, final long chatroomid){
        String positive = "Yes";
        String negative = "No";
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        lang = JsonPhp.getInstance().getLang();
        if (null != lang.getChatrooms() && null != lang.getChatrooms().get59()){
            builder.setMessage(lang.getChatrooms().get59());
        }else{
            builder.setMessage("Are you sure you want to delete this chatroom?");
        }
        if (null != lang.getMobile() && null != lang.getMobile().get33()){
            positive = lang.getMobile().get33();
        }
        if (null != lang.getMobile() && null != lang.getMobile().get34()){
            negative = lang.getMobile().get34();
        }

        builder.setCancelable(true);
        builder.setPositiveButton(positive, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getDeleteChatroomURL(), new VolleyAjaxCallbacks() {
                    @Override
                    public void successCallback(String response) {
                        Chatroom.deleteChatroom(chatroomid);
                        if(!Conversation.isNewChatroomConversation(String.valueOf(chatroomid))){
                            Conversation conversation = Conversation.getConversationByChatroomID(String.valueOf(chatroomid));
                            conversation.delete();
                        }
                        Intent intent = new Intent(BroadcastReceiverKeys.HeartbeatKeys.CHATROOM_HEARTBEAT_UPDATAION);
                        intent.putExtra(
                                BroadcastReceiverKeys.ListUpdatationKeys.REFRESH_FULL_CHATROOM_LIST_FRAGMENT, 1);
                        PreferenceHelper.getContext().sendBroadcast(intent);
                        SessionData.getInstance().setChatroomListBroadcastMissed(true);
                    }

                    @Override
                    public void failCallback(String response, boolean isNoInternet) {
                    }
                });

                vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, chatroomid);
                vHelper.sendCallBack(false);
                vHelper.sendAjax();
            }
        });
        builder.setNegativeButton(negative, null);
        builder.show();
    }

    public static void renameChatroom(final Context context, final long chatroomid, final String chatroomName, final Chatroom chatroom){

        LayoutInflater inflater = (LayoutInflater) context.getSystemService( Context.LAYOUT_INFLATER_SERVICE );
        View dialogview = inflater.inflate(R.layout.custom_dialog, null);

        TextView dialogueTitle = (TextView) dialogview.findViewById(R.id.textViewDialogueTitle);
        dialogueTitle.setVisibility(View.VISIBLE);

        if (null != JsonPhp.getInstance().getLang().getMobile().get180())
            dialogueTitle.setText(JsonPhp.getInstance().getLang().getMobile().get180());
        else
            dialogueTitle.setText("Rename chatroom");


        final AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);
        alertDialogBuilder.setView(dialogview);

        String set = "Set";
        String cancel = "Cancel";

        NewMobile newmobilelangs = JsonPhp.getInstance().getNewMobile();
        if (null != newmobilelangs && null != newmobilelangs.getCommon() && null != newmobilelangs.getCommon().getSet()) {
            set = newmobilelangs.getCommon().getSet();
        }

        if (null != JsonPhp.getInstance().getLang().getChatrooms().get51()) {
            cancel = JsonPhp.getInstance().getLang().getChatrooms().get51();
        }

        alertDialogBuilder.setPositiveButton(set, null);
        alertDialogBuilder.setNegativeButton(cancel, null);
        alertDialogBuilder.setCancelable(true);

        final EditText dialogueTextInput = (EditText) dialogview.findViewById(R.id.edittextDialogueInput);
        dialogueTextInput.setInputType(InputType.TYPE_CLASS_TEXT);
        dialogueTextInput.setText(chatroomName);
        if (null != JsonPhp.getInstance().getLang().getMobile().get181())
            dialogueTextInput.setHint(JsonPhp.getInstance().getLang().getMobile().get181());
        else
            dialogueTextInput.setHint("Chatroom name");

        final AlertDialog alertDialogCreater = alertDialogBuilder.create();
        alertDialogCreater.show();

        alertDialogCreater.getButton(DialogInterface.BUTTON_POSITIVE).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String newChatroomName = dialogueTextInput.getText().toString().trim();
                if (!TextUtils.isEmpty(newChatroomName)) {

                    String message = "Renaming Chatroom";
                    if (null != JsonPhp.getInstance().getLang().getMobile().get182())
                        message = JsonPhp.getInstance().getLang().getMobile().get182();
                    progressDialog = ProgressDialog.show(context, "", message);
                    progressDialog.setCancelable(false);
                    progressDialog.show();

                    VolleyHelper vHelper = new VolleyHelper(PreferenceHelper.getContext(), URLFactory.getRenameChatroomURL(), new VolleyAjaxCallbacks() {
                        @Override
                        public void successCallback(String response) {
                            alertDialogCreater.dismiss();
                            progressDialog.dismiss();

                            if (!TextUtils.isEmpty(response) && response.equals("1")) {
                                chatroom.name = newChatroomName;
                                chatroom.save();
                                SessionData.getInstance().setCurrentChatroomName(chatroomName);
                                progressDialog.dismiss();
                            }
                        }

                        @Override
                        public void failCallback(String response, boolean isNoInternet) {
                            progressDialog.dismiss();
                            alertDialogCreater.dismiss();
                        }
                    });

                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.CHATROOM_ID_FIELD, chatroomid);
                    vHelper.addNameValuePair(CometChatKeys.ChatroomKeys.NEW_CHATROOM_NAME, newChatroomName);
                    vHelper.sendCallBack(false);
                    vHelper.sendAjax();
                } else {
                    dialogueTextInput
                            .setError((null == JsonPhp.getInstance().getLang().getChatrooms().get50()) ? "Please enter the room name."
                                    : JsonPhp.getInstance().getLang().getChatrooms().get50());
                }
            }
        });

        alertDialogCreater.getButton(DialogInterface.BUTTON_NEGATIVE).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                alertDialogCreater.dismiss();
            }
        });
    }

    public static String getTextColor() {
        return textColor;
    }

    public static boolean checkModerator(){
        boolean flag =false;
        String response = PreferenceHelper.get(PreferenceKeys.DataKeys.CHATROOM_MODERATORS_ID);
        try {
            JSONArray abc = new JSONArray(response);
            if (response.equals("[]")) {
            }else{
                for (int i=0; i<abc.length(); i++) {
                    if (Long.parseLong(abc.optString(i)) == SessionData.getInstance().getId()){
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }catch (Exception e){
            e.printStackTrace();
        }
        return flag;
    }
}
