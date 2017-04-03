/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.adapters;

import android.content.Context;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.text.Html;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

import com.inscripts.activities.R;
import com.inscripts.custom.RoundedImageView;
import com.inscripts.factories.LocalStorageFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.models.Buddy;
import com.inscripts.utils.CommonUtils;

import java.util.ArrayList;
import java.util.List;

public class InviteUserListAdapter extends ArrayAdapter<Buddy> {

	private ArrayList<String> inviteList;
    private String primaryColor;

	public InviteUserListAdapter(Context context, List<Buddy> objects, ArrayList<String> savedCheckbox) {
		super(context, 0, objects);
        primaryColor = PreferenceHelper.get(PreferenceKeys.Colors.COLOR_PRIMARY);
		inviteList = new ArrayList<String>();
		if (null != savedCheckbox) {
			for (String i : savedCheckbox) {
				inviteList.add(i);
			}
		}
	}

	private static class ViewHolder {
		public TextView userName;
		public TextView userStatus;
		public CheckBox inviteUserCheckBox;
		public ImageView userStatusImage;
		public RoundedImageView userAvatar;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		View view = convertView;
		ViewHolder holder;

		if (null == view) {
			view = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_list_item_invite_users, parent,
					false);
			holder = new ViewHolder();

			holder.userName = (TextView) view.findViewById(R.id.textViewUserToInvite);
			holder.userStatus = (TextView) view.findViewById(R.id.textViewUserStatusToInvite);
			holder.inviteUserCheckBox = (CheckBox) view.findViewById(R.id.checkBoxInviteUser);
			holder.userStatusImage = (ImageView) view.findViewById(R.id.imageViewStatusIconToInvite);
			holder.userAvatar = (RoundedImageView) view.findViewById(R.id.imageViewUserAvatar);

			view.setTag(holder);
		} else {
			holder = (ViewHolder) view.getTag();
		}

        ColorStateList colorStateList = new ColorStateList(
                new int[][]{

                        new int[]{-android.R.attr.state_enabled},
                        new int[]{-android.R.attr.state_checked},
                        new int[]{android.R.attr.state_checked}
                },
                new int[] {
                        Color.BLACK //disabled
                        ,Color.parseColor("#E0E0E0")
                        ,Color.parseColor(primaryColor)
                }
        );

		if (CommonUtils.isGreaterThanKitKat()) {
			holder.inviteUserCheckBox.setButtonTintList(colorStateList);
		}

		Buddy buddy = getItem(position);
		String buddyId = String.valueOf(buddy.buddyId);
		/*LocalStorageFactory.getPicassoInstance().load(buddy.avatarURL).placeholder(R.drawable.default_avatar)
				.resize(55, 55).into(holder.userAvatar);*/

        LocalStorageFactory.LoadImageUsingURL(parent.getContext(),buddy.avatarURL,holder.userAvatar,R.drawable.default_avatar);

		holder.userName.setText(Html.fromHtml(buddy.name));
		holder.userStatus.setText(Html.fromHtml(buddy.statusMessage));
		holder.inviteUserCheckBox.setChecked(inviteList.contains(buddyId));
		holder.inviteUserCheckBox.setTag(buddyId);

		/* Set color according to the status. */
		switch (buddy.status) {
		case CometChatKeys.StatusKeys.AVALIABLE:
			holder.userStatusImage.setImageResource(R.drawable.ic_user_available);
			break;
		case CometChatKeys.StatusKeys.AWAY:
			holder.userStatusImage.setImageResource(R.drawable.ic_user_away);
			break;
		case CometChatKeys.StatusKeys.BUSY:
			holder.userStatusImage.setImageResource(R.drawable.ic_user_busy);
			break;
		case CometChatKeys.StatusKeys.OFFLINE:
			holder.userStatusImage.setImageResource(R.drawable.ic_user_offline);
			break;
		case CometChatKeys.StatusKeys.INVISIBLE:
			holder.userStatusImage.setImageResource(R.drawable.ic_user_offline);
			break;
		default:
            holder.userStatusImage.setImageResource(R.drawable.ic_user_available);
			break;
		}
		return view;
	}

	public void toggleInvite(String id) {
		if (inviteList.contains(id)) {
			inviteList.remove(id);
		} else {
			inviteList.add(id);
		}
	}

	public int getInvitedUsersCount() {
		return inviteList.size();
	}

	public ArrayList<String> getInviteUsersList() {
		return inviteList;
	}

	public void clearInviteList() {
		inviteList.clear();
	}
}