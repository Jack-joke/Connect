package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Common {

	@Expose
	private String set;
	@SerializedName("complete_action")
	@Expose
	private String completeAction;
	@SerializedName("inapp_notification_message")
	@Expose
	private String inappNotificationMessage;

	/**
	 * 
	 * @return The set
	 */
	public String getSet() {
		return set;
	}

	/**
	 * 
	 * @param set
	 *            The set
	 */
	public void setSet(String set) {
		this.set = set;
	}

	/**
	 * 
	 * @return The completeAction
	 */
	public String getCompleteAction() {
		return completeAction;
	}

	/**
	 * 
	 * @param completeAction
	 *            The complete_action
	 */
	public void setCompleteAction(String completeAction) {
		this.completeAction = completeAction;
	}

	/**
	 * 
	 * @return The inappNotificationMessage
	 */
	public String getInappNotificationMessage() {
		return inappNotificationMessage;
	}

	/**
	 * 
	 * @param inappNotificationMessage
	 *            The inapp_notification_message
	 */
	public void setInappNotificationMessage(String inappNotificationMessage) {
		this.inappNotificationMessage = inappNotificationMessage;
	}

}
