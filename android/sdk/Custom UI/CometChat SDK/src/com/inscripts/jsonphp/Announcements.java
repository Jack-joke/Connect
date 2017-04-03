package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Announcements {

	@SerializedName("100")
	@Expose
	private String _100;
	@SerializedName("0")
	@Expose
	private String _0;
	@Expose
	private String hash;

	/**
	 * 
	 * @return The _100
	 */
	public String get100() {
		return _100;
	}

	/**
	 * 
	 * @param _100
	 *            The 100
	 */
	public void set100(String _100) {
		this._100 = _100;
	}

	/**
	 * 
	 * @return The _0
	 */
	public String get0() {
		return _0;
	}

	/**
	 * 
	 * @param _0
	 *            The 0
	 */
	public void set0(String _0) {
		this._0 = _0;
	}

	/**
	 * 
	 * @return The hash
	 */
	public String getHash() {
		return hash;
	}

	/**
	 * 
	 * @param hash
	 *            The hash
	 */
	public void setHash(String hash) {
		this.hash = hash;
	}

}
