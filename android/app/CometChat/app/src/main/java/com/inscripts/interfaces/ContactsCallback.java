/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

import com.inscripts.pojos.ContactPojo;

import java.util.ArrayList;

public interface ContactsCallback {

	public void successCallback(ArrayList<ContactPojo> contactList);

	public void failCallback(String errorMessage);

}
