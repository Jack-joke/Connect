package com.inscripts.jsonphp;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Home {

	@SerializedName("tab_text")
	@Expose
	private String tabText;

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

}
