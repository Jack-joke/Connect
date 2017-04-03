package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class JsonPhp {

	@Expose
	private String pushNotifications;
	@Expose
	private String cookieprefix;
	@Expose
	private String pushAPIKey;
	@Expose
	private String pushOauthSecret;
	@Expose
	private String pushOauthKey;
	@Expose
	private String pushNotificationName;
	@Expose
	private String langhash;
	@Expose
	private Lang lang;
	@Expose
	private String csshash;
	@Expose
	private Css css;
	@SerializedName("mobile_theme")
	@Expose
	private MobileTheme mobileTheme;
	@SerializedName("mobile_config")
	@Expose
	private MobileConfig mobileConfig;
	@SerializedName("new_mobile")
	@Expose
	private NewMobile newMobile;
	@Expose
	private String confighash;
	@Expose
	private Config config;
	@SerializedName("avchat_enabled")
	@Expose
	private String avchatEnabled;
	@Expose
	private String webRTCServer;
	@SerializedName("filetransfer_enabled")
	@Expose
	private String filetransferEnabled;
	@SerializedName("audiochat_enabled")
	@Expose
	private String audiochatEnabled;
	@SerializedName("report_enabled")
	@Expose
	private String reportEnabled;
	@SerializedName("block_user_enabled")
	@Expose
	private String blockUserEnabled;
	@SerializedName("clearconversation_enabled")
	@Expose
	private String clearconversationEnabled;
	@SerializedName("crclearconversation_enabled")
	@Expose
	private String crclearconversationEnabled;
	@SerializedName("crfiletransfer_enabled")
	@Expose
	private String crfiletransferEnabled;
	@SerializedName("allowusers_createchatroom")
	@Expose
	private String allowusersCreatechatroom;
	@SerializedName("chatroomsmodule_enabled")
	@Expose
	private String chatroomsmoduleEnabled;
	@SerializedName("realtime_translation")
	@Expose
	private String realtimeTranslation;
	@SerializedName("ob_gzhandler")
	@Expose
	private Integer obGzhandler;
	@SerializedName("header_image")
	@Expose
	private HeaderImage headerImage;
	@SerializedName("ad_unit_id")
	@Expose
	private String adUnitId;
	@SerializedName("websync_server")
	@Expose
	private String websyncServer;

	/**
	 * @return The pushNotifications
	 */
	public String getPushNotifications() {
		return pushNotifications;
	}

	/**
	 * @param pushNotifications
	 *            The pushNotifications
	 */
	public void setPushNotifications(String pushNotifications) {
		this.pushNotifications = pushNotifications;
	}

	/**
	 * @return The cookieprefix
	 */
	public String getCookieprefix() {
		return cookieprefix;
	}

	/**
	 * @param cookieprefix
	 *            The cookieprefix
	 */
	public void setCookieprefix(String cookieprefix) {
		this.cookieprefix = cookieprefix;
	}

	/**
	 * @return The pushAPIKey
	 */
	public String getPushAPIKey() {
		return pushAPIKey;
	}

	/**
	 * @param pushAPIKey
	 *            The pushAPIKey
	 */
	public void setPushAPIKey(String pushAPIKey) {
		this.pushAPIKey = pushAPIKey;
	}

	/**
	 * @return The pushOauthSecret
	 */
	public String getPushOauthSecret() {
		return pushOauthSecret;
	}

	/**
	 * @param pushOauthSecret
	 *            The pushOauthSecret
	 */
	public void setPushOauthSecret(String pushOauthSecret) {
		this.pushOauthSecret = pushOauthSecret;
	}

	/**
	 * @return The pushOauthKey
	 */
	public String getPushOauthKey() {
		return pushOauthKey;
	}

	/**
	 * @param pushOauthKey
	 *            The pushOauthKey
	 */
	public void setPushOauthKey(String pushOauthKey) {
		this.pushOauthKey = pushOauthKey;
	}

	/**
	 * @return The pushNotificationName
	 */
	public String getPushNotificationName() {
		return pushNotificationName;
	}

	/**
	 * @param pushNotificationName
	 *            The pushNotificationName
	 */
	public void setPushNotificationName(String pushNotificationName) {
		this.pushNotificationName = pushNotificationName;
	}

	/**
	 * @return The langhash
	 */
	public String getLanghash() {
		return langhash;
	}

	/**
	 * @param langhash
	 *            The langhash
	 */
	public void setLanghash(String langhash) {
		this.langhash = langhash;
	}

	/**
	 * @return The lang
	 */
	public Lang getLang() {
		return lang;
	}

	/**
	 * @param lang
	 *            The lang
	 */
	public void setLang(Lang lang) {
		this.lang = lang;
	}

	/**
	 * @return The csshash
	 */
	public String getCsshash() {
		return csshash;
	}

	/**
	 * @param csshash
	 *            The csshash
	 */
	public void setCsshash(String csshash) {
		this.csshash = csshash;
	}

	/**
	 * @return The css
	 */
	public Css getCss() {
		return css;
	}

	/**
	 * @param css
	 *            The css
	 */
	public void setCss(Css css) {
		this.css = css;
	}

	/**
	 * @return The mobileTheme
	 */
	public MobileTheme getMobileTheme() {
		return mobileTheme;
	}

	/**
	 * @param mobileTheme
	 *            The mobile_theme
	 */
	public void setMobileTheme(MobileTheme mobileTheme) {
		this.mobileTheme = mobileTheme;
	}

	public MobileConfig getMobileConfig() {
		return mobileConfig;
	}

	public void setMobileConfig(MobileConfig mobileConfig) {
		this.mobileConfig = mobileConfig;
	}

	/**
	 * @return The newMobile
	 */
	public NewMobile getNewMobile() {
		return newMobile;
	}

	/**
	 * @param newMobile
	 *            The new_mobile
	 */
	public void setNewMobile(NewMobile newMobile) {
		this.newMobile = newMobile;
	}

	/**
	 * @return The confighash
	 */
	public String getConfighash() {
		return confighash;
	}

	/**
	 * @param confighash
	 *            The confighash
	 */
	public void setConfighash(String confighash) {
		this.confighash = confighash;
	}

	/**
	 * @return The config
	 */
	public Config getConfig() {
		return config;
	}

	/**
	 * @param config
	 *            The config
	 */
	public void setConfig(Config config) {
		this.config = config;
	}

	/**
	 * @return The avchatEnabled
	 */
	public String getAvchatEnabled() {
		return avchatEnabled;
	}

	/**
	 * @param avchatEnabled
	 *            The avchat_enabled
	 */
	public void setAvchatEnabled(String avchatEnabled) {
		this.avchatEnabled = avchatEnabled;
	}

	/**
	 * @return The webRTCServer
	 */
	public String getWebRTCServer() {
		return webRTCServer;
	}

	/**
	 * @param webRTCServer
	 *            The webRTCServer
	 */
	public void setWebRTCServer(String webRTCServer) {
		this.webRTCServer = webRTCServer;
	}

	/**
	 * @return The filetransferEnabled
	 */
	public String getFiletransferEnabled() {
		return filetransferEnabled;
	}

	/**
	 * @param filetransferEnabled
	 *            The filetransfer_enabled
	 */
	public void setFiletransferEnabled(String filetransferEnabled) {
		this.filetransferEnabled = filetransferEnabled;
	}

	/**
	 * @return The audiochatEnabled
	 */
	public String getAudiochatEnabled() {
		return audiochatEnabled;
	}

	/**
	 * @param audiochatEnabled
	 *            The audiochat_enabled
	 */
	public void setAudiochatEnabled(String audiochatEnabled) {
		this.audiochatEnabled = audiochatEnabled;
	}

	/**
	 * @return The reportEnabled
	 */
	public String getReportEnabled() {
		return reportEnabled;
	}

	/**
	 * @param reportEnabled
	 *            The report_enabled
	 */
	public void setReportEnabled(String reportEnabled) {
		this.reportEnabled = reportEnabled;
	}

	/**
	 * @return The blockUserEnabled
	 */
	public String getBlockUserEnabled() {
		return blockUserEnabled;
	}

	/**
	 * @param blockUserEnabled
	 *            The block_user_enabled
	 */
	public void setBlockUserEnabled(String blockUserEnabled) {
		this.blockUserEnabled = blockUserEnabled;
	}

	/**
	 * @return The clearconversationEnabled
	 */
	public String getClearconversationEnabled() {
		return clearconversationEnabled;
	}

	/**
	 * @param clearconversationEnabled
	 *            The clearconversation_enabled
	 */
	public void setClearconversationEnabled(String clearconversationEnabled) {
		this.clearconversationEnabled = clearconversationEnabled;
	}

	/**
	 * @return The crclearconversationEnabled
	 */
	public String getCrclearconversationEnabled() {
		return crclearconversationEnabled;
	}

	/**
	 * @param crclearconversationEnabled
	 *            The crclearconversation_enabled
	 */
	public void setCrclearconversationEnabled(String crclearconversationEnabled) {
		this.crclearconversationEnabled = crclearconversationEnabled;
	}

	/**
	 * @return The crfiletransferEnabled
	 */
	public String getCrfiletransferEnabled() {
		return crfiletransferEnabled;
	}

	/**
	 * @param crfiletransferEnabled
	 *            The crfiletransfer_enabled
	 */
	public void setCrfiletransferEnabled(String crfiletransferEnabled) {
		this.crfiletransferEnabled = crfiletransferEnabled;
	}

	/**
	 * @return The allowusersCreatechatroom
	 */
	public String getAllowusersCreatechatroom() {
		return allowusersCreatechatroom;
	}

	/**
	 * @param allowusersCreatechatroom
	 *            The allowusers_createchatroom
	 */
	public void setAllowusersCreatechatroom(String allowusersCreatechatroom) {
		this.allowusersCreatechatroom = allowusersCreatechatroom;
	}

	/**
	 * @return The chatroomsmoduleEnabled
	 */
	public String getChatroomsmoduleEnabled() {
		return chatroomsmoduleEnabled;
	}

	/**
	 * @param chatroomsmoduleEnabled
	 *            The chatroomsmodule_enabled
	 */
	public void setChatroomsmoduleEnabled(String chatroomsmoduleEnabled) {
		this.chatroomsmoduleEnabled = chatroomsmoduleEnabled;
	}

	/**
	 * @return The realtimeTranslation
	 */
	public String getRealtimeTranslation() {
		return realtimeTranslation;
	}

	/**
	 * @param realtimeTranslation
	 *            The realtime_translation
	 */
	public void setRealtimeTranslation(String realtimeTranslation) {
		this.realtimeTranslation = realtimeTranslation;
	}

	/**
	 * @return The obGzhandler
	 */
	public Integer getObGzhandler() {
		return obGzhandler;
	}

	/**
	 * @param obGzhandler
	 *            The ob_gzhandler
	 */
	public void setObGzhandler(Integer obGzhandler) {
		this.obGzhandler = obGzhandler;
	}

	/**
	 * @return The headerImage
	 */
	public HeaderImage getHeaderImage() {
		return headerImage;
	}

	/**
	 * @param headerImage
	 *            The header_image
	 */
	public void setHeaderImage(HeaderImage headerImage) {
		this.headerImage = headerImage;
	}

	/**
	 * @return The adUnitId
	 */
	public String getAdUnitId() {
		return adUnitId;
	}

	/**
	 * @param adUnitId
	 *            The ad_unit_id
	 */
	public void setAdUnitId(String adUnitId) {
		this.adUnitId = adUnitId;
	}

	public String getWebsyncServer() {
		return websyncServer;
	}

	public void setWebsyncServer(String websyncServer) {
		this.websyncServer = websyncServer;
	}

	private static JsonPhp jsonPhp = null;

	public static void setInstance(JsonPhp readValue) {
		jsonPhp = readValue;
	}

	public static JsonPhp getInstance() {
		if (null == jsonPhp) {
			jsonPhp = new JsonPhp();
		}
		return jsonPhp;
	}

	public static boolean isNull() {
		return jsonPhp == null;
	}
}