/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.countrypicker;

/**
 * Inform the client which country has been selected
 * 
 */
public interface CountryPickerListener {
	public void onSelectCountry(String name, String code);
}
