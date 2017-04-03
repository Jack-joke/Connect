/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.pojos;

public class CustomSettingsItem {

	private int type;
	private String itemName;

	public CustomSettingsItem(int icon, String itemName) {
		setType(icon);
		setItemName(itemName);
	}

	/**
	 * @return the icon
	 */
	public int getType() {
		return type;
	}

	/**
	 * @param type
	 *            the icon to set
	 */
	public void setType(int type) {
		this.type = type;
	}

	/**
	 * @return the itemName
	 */
	public String getItemName() {
		return itemName;
	}

	/**
	 * @param itemName
	 *            the itemName to set
	 */
	public void setItemName(String itemName) {
		this.itemName = itemName;
	}

}
