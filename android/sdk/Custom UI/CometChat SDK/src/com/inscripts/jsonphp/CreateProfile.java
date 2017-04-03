package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class CreateProfile {

	@Expose
	private String actionbar;
	@Expose
	private String loader;
	@SerializedName("create_button")
	@Expose
	private String createButton;
	@SerializedName("field_hint")
	@Expose
	private String fieldHint;
	@SerializedName("err_username")
	@Expose
	private String errUsername;
	@SerializedName("photo_hint")
	@Expose
	private String photoHint;
	@SerializedName("password_mismatch")
	@Expose
	private String passwordMismatch;
	@SerializedName("confpwd_empty")
	@Expose
	private String confpwdEmpty;
	@SerializedName("incorrect_password")
	@Expose
	private String incorrectPassword;
	@SerializedName("email_empty")
	@Expose
	private String emailEmpty;

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
	 * @return The createButton
	 */
	public String getCreateButton() {
		return createButton;
	}

	/**
	 * 
	 * @param createButton
	 *            The create_button
	 */
	public void setCreateButton(String createButton) {
		this.createButton = createButton;
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
	 * @return The errUsername
	 */
	public String getErrUsername() {
		return errUsername;
	}

	/**
	 * 
	 * @param errUsername
	 *            The err_username
	 */
	public void setErrUsername(String errUsername) {
		this.errUsername = errUsername;
	}

	/**
	 * 
	 * @return The photoHint
	 */
	public String getPhotoHint() {
		return photoHint;
	}

	/**
	 * 
	 * @param photoHint
	 *            The photo_hint
	 */
	public void setPhotoHint(String photoHint) {
		this.photoHint = photoHint;
	}

	/**
	 * 
	 * @return The passwordMismatch
	 */
	public String getPasswordMismatch() {
		return passwordMismatch;
	}

	/**
	 * 
	 * @param passwordMismatch
	 *            The password_mismatch
	 */
	public void setPasswordMismatch(String passwordMismatch) {
		this.passwordMismatch = passwordMismatch;
	}

	/**
	 * 
	 * @return The confpwdEmpty
	 */
	public String getConfpwdEmpty() {
		return confpwdEmpty;
	}

	/**
	 * 
	 * @param confpwdEmpty
	 *            The confpwd_empty
	 */
	public void setConfpwdEmpty(String confpwdEmpty) {
		this.confpwdEmpty = confpwdEmpty;
	}

	/**
	 * 
	 * @return The incorrectPassword
	 */
	public String getIncorrectPassword() {
		return incorrectPassword;
	}

	/**
	 * 
	 * @param incorrectPassword
	 *            The incorrect_password
	 */
	public void setIncorrectPassword(String incorrectPassword) {
		this.incorrectPassword = incorrectPassword;
	}

	/**
	 * 
	 * @return The emailEmpty
	 */
	public String getEmailEmpty() {
		return emailEmpty;
	}

	/**
	 * 
	 * @param emailEmpty
	 *            The email_empty
	 */
	public void setEmailEmpty(String emailEmpty) {
		this.emailEmpty = emailEmpty;
	}

}
