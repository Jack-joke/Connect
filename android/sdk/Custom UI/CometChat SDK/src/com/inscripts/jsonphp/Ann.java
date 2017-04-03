package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Ann {

	@SerializedName("tab_text")
	@Expose
	private String tabText;
	@SerializedName("read_more")
	@Expose
	private String readMore;
	@SerializedName("read_less")
	@Expose
	private String readLess;

	/**
	 * 
	 * @return The tabText
	 */
	public String getTabText() {
		return tabText;
	}

	/**
	 * 
	 * @param tabText
	 *            The tab_text
	 */
	public void setTabText(String tabText) {
		this.tabText = tabText;
	}

	/**
	 * 
	 * @return The readMore
	 */
	public String getReadMore() {
		return readMore;
	}

	/**
	 * 
	 * @param readMore
	 *            The read_more
	 */
	public void setReadMore(String readMore) {
		this.readMore = readMore;
	}

	/**
	 * 
	 * @return The readLess
	 */
	public String getReadLess() {
		return readLess;
	}

	/**
	 * 
	 * @param readLess
	 *            The read_less
	 */
	public void setReadLess(String readLess) {
		this.readLess = readLess;
	}

}
