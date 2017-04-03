/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.interfaces;

import org.json.JSONObject;

public interface Callbacks {
    void successCallback(JSONObject response);

    void failCallback(JSONObject response);

}
