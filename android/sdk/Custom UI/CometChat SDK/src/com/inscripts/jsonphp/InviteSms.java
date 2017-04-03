package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class InviteSms {

	@Expose
	private String actionbar;
	@SerializedName("contacts_hint")
	@Expose
	private String contactsHint;
	@SerializedName("contacts_label")
	@Expose
	private String contactsLabel;
	@SerializedName("sms_hint")
	@Expose
	private String smsHint;
	@SerializedName("sms_android")
	@Expose
	private String smsAndroid;
	@SerializedName("sms_ios")
	@Expose
	private String smsIos;
	@SerializedName("cannot_send")
	@Expose
	private String cannotSend;

	/**
	 * 
	 * @return The actionbar
	 */
	public String getActionbar() {
		return actionbar;
	}

	/**
	 * 
	 * @param actionbar
	 *            The actionbar
	 */
	public void setActionbar(String actionbar) {
		this.actionbar = actionbar;
	}

	/**
	 * 
	 * @return The contactsHint
	 */
	public String getContactsHint() {
		return contactsHint;
	}

	/**
	 * 
	 * @param contactsHint
	 *            The contacts_hint
	 */
	public void setContactsHint(String contactsHint) {
		this.contactsHint = contactsHint;
	}

	/**
	 * 
	 * @return The contactsLabel
	 */
	public String getContactsLabel() {
		return contactsLabel;
	}

	/**
	 * 
	 * @param contactsLabel
	 *            The contacts_label
	 */
	public void setContactsLabel(String contactsLabel) {
		this.contactsLabel = contactsLabel;
	}

	/**
	 * 
	 * @return The smsHint
	 */
	public String getSmsHint() {
		return smsHint;
	}

	/**
	 * 
	 * @param smsHint
	 *            The sms_hint
	 */
	public void setSmsHint(String smsHint) {
		this.smsHint = smsHint;
	}

	/**
	 * 
	 * @return The smsAndroid
	 */
	public String getSmsAndroid() {
		return smsAndroid;
	}

	/**
	 * 
	 * @param smsAndroid
	 *            The sms_android
	 */
	public void setSmsAndroid(String smsAndroid) {
		this.smsAndroid = smsAndroid;
	}

	/**
	 * 
	 * @return The smsIos
	 */
	public String getSmsIos() {
		return smsIos;
	}

	/**
	 * 
	 * @param smsIos
	 *            The sms_ios
	 */
	public void setSmsIos(String smsIos) {
		this.smsIos = smsIos;
	}

	/**
	 * 
	 * @return The cannotSend
	 */
	public String getCannotSend() {
		return cannotSend;
	}

	/**
	 * 
	 * @param cannotSend
	 *            The cannot_send
	 */
	public void setCannotSend(String cannotSend) {
		this.cannotSend = cannotSend;
	}

}
