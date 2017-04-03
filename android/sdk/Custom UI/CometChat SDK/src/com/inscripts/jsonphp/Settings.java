package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Settings {

	@SerializedName("change_profile_pic")
	@Expose
	private String changeProfilePic;
	@SerializedName("edit_status_message")
	@Expose
	private String editStatusMessage;
	@SerializedName("status_message_hint")
	@Expose
	private String statusMessageHint;
	@SerializedName("set_status_message")
	@Expose
	private String setStatusMessage;
	@SerializedName("invite_viasms")
	@Expose
	private String inviteViasms;
	@SerializedName("edit_username")
	@Expose
	private String editUsername;
	@SerializedName("set_user_name")
	@Expose
	private String setUserName;
	@SerializedName("username_hint")
	@Expose
	private String usernameHint;
	@SerializedName("set_status")
	@Expose
	private String setStatus;
	@SerializedName("set_language")
	@Expose
	private String setLanguage;

	/**
	 * 
	 * @return The changeProfilePic
	 */
	public String getChangeProfilePic() {
		return changeProfilePic;
	}

	/**
	 * 
	 * @param changeProfilePic
	 *            The change_profile_pic
	 */
	public void setChangeProfilePic(String changeProfilePic) {
		this.changeProfilePic = changeProfilePic;
	}

	/**
	 * 
	 * @return The editStatusMessage
	 */
	public String getEditStatusMessage() {
		return editStatusMessage;
	}

	/**
	 * 
	 * @param editStatusMessage
	 *            The edit_status_message
	 */
	public void setEditStatusMessage(String editStatusMessage) {
		this.editStatusMessage = editStatusMessage;
	}

	/**
	 * 
	 * @return The statusMessageHint
	 */
	public String getStatusMessageHint() {
		return statusMessageHint;
	}

	/**
	 * 
	 * @param statusMessageHint
	 *            The status_message_hint
	 */
	public void setStatusMessageHint(String statusMessageHint) {
		this.statusMessageHint = statusMessageHint;
	}

	/**
	 * 
	 * @return The setStatusMessage
	 */
	public String getSetStatusMessage() {
		return setStatusMessage;
	}

	/**
	 * 
	 * @param setStatusMessage
	 *            The set_status_message
	 */
	public void setSetStatusMessage(String setStatusMessage) {
		this.setStatusMessage = setStatusMessage;
	}

	/**
	 * 
	 * @return The inviteViasms
	 */
	public String getInviteViasms() {
		return inviteViasms;
	}

	/**
	 * 
	 * @param inviteViasms
	 *            The invite_viasms
	 */
	public void setInviteViasms(String inviteViasms) {
		this.inviteViasms = inviteViasms;
	}

	/**
	 * 
	 * @return The editUsername
	 */
	public String getEditUsername() {
		return editUsername;
	}

	/**
	 * 
	 * @param editUsername
	 *            The edit_username
	 */
	public void setEditUsername(String editUsername) {
		this.editUsername = editUsername;
	}

	/**
	 * 
	 * @return The setUserName
	 */
	public String getSetUserName() {
		return setUserName;
	}

	/**
	 * 
	 * @param setUserName
	 *            The set_user_name
	 */
	public void setSetUserName(String setUserName) {
		this.setUserName = setUserName;
	}

	/**
	 * 
	 * @return The usernameHint
	 */
	public String getUsernameHint() {
		return usernameHint;
	}

	/**
	 * 
	 * @param usernameHint
	 *            The username_hint
	 */
	public void setUsernameHint(String usernameHint) {
		this.usernameHint = usernameHint;
	}

	/**
	 * 
	 * @return The setStatus
	 */
	public String getSetStatus() {
		return setStatus;
	}

	/**
	 * 
	 * @param setStatus
	 *            The set_status
	 */
	public void setSetStatus(String setStatus) {
		this.setStatus = setStatus;
	}

	/**
	 * 
	 * @return The setLanguage
	 */
	public String getSetLanguage() {
		return setLanguage;
	}

	/**
	 * 
	 * @param setLanguage
	 *            The set_language
	 */
	public void setSetLanguage(String setLanguage) {
		this.setLanguage = setLanguage;
	}

}
