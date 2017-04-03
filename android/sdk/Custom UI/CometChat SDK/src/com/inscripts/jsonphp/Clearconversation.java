package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Clearconversation {

	@SerializedName("0")
	@Expose
	private String _0;
	@Expose
	private String hash;

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
