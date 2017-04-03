package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Verify {

	@Expose
	private String actionbar;
	@Expose
	private String loader;
	@SerializedName("field_hint")
	@Expose
	private String fieldHint;
	@SerializedName("verify_button")
	@Expose
	private String verifyButton;
	@SerializedName("resend_button")
	@Expose
	private String resendButton;
	@SerializedName("wrong_code")
	@Expose
	private String wrongCode;
	@SerializedName("change_email")
	@Expose
	private String changeEmail;

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
	 * @return The loader
	 */
	public String getLoader() {
		return loader;
	}

	/**
	 * 
	 * @param loader
	 *            The loader
	 */
	public void setLoader(String loader) {
		this.loader = loader;
	}

	/**
	 * 
	 * @return The fieldHint
	 */
	public String getFieldHint() {
		return fieldHint;
	}

	/**
	 * 
	 * @param fieldHint
	 *            The field_hint
	 */
	public void setFieldHint(String fieldHint) {
		this.fieldHint = fieldHint;
	}

	/**
	 * 
	 * @return The verifyButton
	 */
	public String getVerifyButton() {
		return verifyButton;
	}

	/**
	 * 
	 * @param verifyButton
	 *            The verify_button
	 */
	public void setVerifyButton(String verifyButton) {
		this.verifyButton = verifyButton;
	}

	/**
	 * 
	 * @return The resendButton
	 */
	public String getResendButton() {
		return resendButton;
	}

	/**
	 * 
	 * @param resendButton
	 *            The resend_button
	 */
	public void setResendButton(String resendButton) {
		this.resendButton = resendButton;
	}

	/**
	 * 
	 * @return The wrongCode
	 */
	public String getWrongCode() {
		return wrongCode;
	}

	/**
	 * 
	 * @param wrongCode
	 *            The wrong_code
	 */
	public void setWrongCode(String wrongCode) {
		this.wrongCode = wrongCode;
	}

	/**
	 * 
	 * @return The changeEmail
	 */
	public String getChangeEmail() {
		return changeEmail;
	}

	/**
	 * 
	 * @param changeEmail
	 *            The change_email
	 */
	public void setChangeEmail(String changeEmail) {
		this.changeEmail = changeEmail;
	}

}