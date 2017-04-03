package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class MobileTheme {

	@SerializedName("login_background")
	@Expose
	private String loginBackground;
	@SerializedName("login_foreground")
	@Expose
	private String loginForeground;
	@SerializedName("login_placeholder")
	@Expose
	private String loginPlaceholder;
	@SerializedName("login_button_pressed")
	@Expose
	private String loginButtonPressed;
	@SerializedName("login_foreground_text")
	@Expose
	private String loginForegroundText;

	/**
	 * 
	 * @return The loginBackground
	 */
	public String getLoginBackground() {
		return loginBackground;
	}

	/**
	 * 
	 * @param loginBackground
	 *            The login_background
	 */
	public void setLoginBackground(String loginBackground) {
		this.loginBackground = loginBackground;
	}

	/**
	 * 
	 * @return The loginForeground
	 */
	public String getLoginForeground() {
		return loginForeground;
	}

	/**
	 * 
	 * @param loginForeground
	 *            The login_foreground
	 */
	public void setLoginForeground(String loginForeground) {
		this.loginForeground = loginForeground;
	}

	/**
	 * 
	 * @return The loginPlaceholder
	 */
	public String getLoginPlaceholder() {
		return loginPlaceholder;
	}

	/**
	 * 
	 * @param loginPlaceholder
	 *            The login_placeholder
	 */
	public void setLoginPlaceholder(String loginPlaceholder) {
		this.loginPlaceholder = loginPlaceholder;
	}

	/**
	 * 
	 * @return The loginButtonPressed
	 */
	public String getLoginButtonPressed() {
		return loginButtonPressed;
	}

	/**
	 * 
	 * @param loginButtonPressed
	 *            The login_button_pressed
	 */
	public void setLoginButtonPressed(String loginButtonPressed) {
		this.loginButtonPressed = loginButtonPressed;
	}

	/**
	 * 
	 * @return The loginForegroundText
	 */
	public String getLoginForegroundText() {
		return loginForegroundText;
	}

	/**
	 * 
	 * @param loginForegroundText
	 *            The login_foreground_text
	 */
	public void setLoginForegroundText(String loginForegroundText) {
		this.loginForegroundText = loginForegroundText;
	}

}
