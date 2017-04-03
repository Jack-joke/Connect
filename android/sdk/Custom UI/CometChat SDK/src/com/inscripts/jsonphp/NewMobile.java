package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class NewMobile {

	@Expose
	private Common common;
	@Expose
	private Settings settings;
	@Expose
	private Ann ann;
	@Expose
	private Home home;
	@Expose
	private Login login;
	@Expose
	private Verify verify;
	@SerializedName("create_profile")
	@Expose
	private CreateProfile createProfile;
	@SerializedName("invite_sms")
	@Expose
	private InviteSms inviteSms;

	/**
	 * 
	 * @return The common
	 */
	public Common getCommon() {
		return common;
	}

	/**
	 * 
	 * @param common
	 *            The common
	 */
	public void setCommon(Common common) {
		this.common = common;
	}

	/**
	 * 
	 * @return The settings
	 */
	public Settings getSettings() {
		return settings;
	}

	/**
	 * 
	 * @param settings
	 *            The settings
	 */
	public void setSettings(Settings settings) {
		this.settings = settings;
	}

	/**
	 * 
	 * @return The ann
	 */
	public Ann getAnn() {
		return ann;
	}

	/**
	 * 
	 * @param ann
	 *            The ann
	 */
	public void setAnn(Ann ann) {
		this.ann = ann;
	}

	/**
	 * 
	 * @return The home
	 */
	public Home getHome() {
		return home;
	}

	/**
	 * 
	 * @param home
	 *            The home
	 */
	public void setHome(Home home) {
		this.home = home;
	}

	/**
	 * 
	 * @return The login
	 */
	public Login getLogin() {
		return login;
	}

	/**
	 * 
	 * @param login
	 *            The login
	 */
	public void setLogin(Login login) {
		this.login = login;
	}

	/**
	 * 
	 * @return The verify
	 */
	public Verify getVerify() {
		return verify;
	}

	/**
	 * 
	 * @param verify
	 *            The verify
	 */
	public void setVerify(Verify verify) {
		this.verify = verify;
	}

	/**
	 * 
	 * @return The createProfile
	 */
	public CreateProfile getCreateProfile() {
		return createProfile;
	}

	/**
	 * 
	 * @param createProfile
	 *            The create_profile
	 */
	public void setCreateProfile(CreateProfile createProfile) {
		this.createProfile = createProfile;
	}

	/**
	 * 
	 * @return The inviteSms
	 */
	public InviteSms getInviteSms() {
		return inviteSms;
	}

	/**
	 * 
	 * @param inviteSms
	 *            The invite_sms
	 */
	public void setInviteSms(InviteSms inviteSms) {
		this.inviteSms = inviteSms;
	}
}