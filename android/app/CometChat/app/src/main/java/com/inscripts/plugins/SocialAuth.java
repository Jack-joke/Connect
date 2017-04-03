/*

CometChat
Copyright (c) 2016 Inscripts
License: https://www.cometchat.com/legal/license

*/
package com.inscripts.plugins;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Base64;

import com.facebook.Session;
import com.facebook.model.GraphUser;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.plus.Plus;
import com.google.android.gms.plus.model.people.Person;
import com.inscripts.factories.URLFactory;
import com.inscripts.interfaces.VolleyAjaxCallbacks;
import com.inscripts.jsonphp.JsonPhp;
import com.inscripts.jsonphp.MobileConfig;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.CometChatKeys.SocialKeys;
import com.inscripts.utils.LocalConfig;
import com.inscripts.utils.Logger;
import com.twitter.sdk.android.Twitter;
import com.twitter.sdk.android.core.Result;
import com.twitter.sdk.android.core.TwitterSession;

import org.apache.http.HttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpParams;
import org.apache.http.util.EntityUtils;
import org.json.JSONException;
import org.json.JSONObject;

import java.net.URLEncoder;

public class SocialAuth {

    private static GoogleApiClient googleApiClient;

    public static JSONObject formatFacebookJSON(GraphUser user) {
        try {
            JSONObject socialDetais = new JSONObject();
            socialDetais.put(CometChatKeys.SocialKeys.NETWORK_TYPE, "facebook");
            socialDetais.put(SocialKeys.IDENTIFIER, user.getId());
            socialDetais.put(SocialKeys.DISPLAY_NAME, user.getProperty("name"));
            socialDetais.put(SocialKeys.EMAIL, user.asMap().get("email"));
            socialDetais.put(SocialKeys.FIRST_NAME, user.getFirstName());
            socialDetais.put(SocialKeys.LAST_NAME, user.getLastName());
            socialDetais.put(SocialKeys.USER_NAME, user.getUsername());
            socialDetais.put(SocialKeys.PHOTO_URL, getFacebookProfilePhotoLink(user.getId()));
            socialDetais.put(SocialKeys.GENDER, user.getProperty("gender"));
            socialDetais.put(SocialKeys.PROFILE_URL, user.getProperty("link"));
            return socialDetais;
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static JSONObject formatTwitterJSON(String rawUserDetails) {
        JSONObject socialDetais = new JSONObject();
        try {
            JSONObject rawDetails = new JSONObject(rawUserDetails);
            socialDetais.put(SocialKeys.NETWORK_TYPE, "twitter");
            socialDetais.put(SocialKeys.IDENTIFIER, rawDetails.getString("id"));
            socialDetais.put(SocialKeys.DISPLAY_NAME, rawDetails.getString("name"));
            socialDetais.put(SocialKeys.USER_NAME, rawDetails.getString("screen_name"));
            socialDetais.put(SocialKeys.FIRST_NAME, rawDetails.getString("name"));
            socialDetais.put(SocialKeys.PHOTO_URL, rawDetails.getString("profile_image_url_https"));
            socialDetais.put(SocialKeys.PROFILE_URL, getTwitterPublicProfileLink(rawDetails.getString("screen_name")));
            socialDetais.put(SocialKeys.LANGUAGE, rawDetails.getString("lang"));
            socialDetais.put(CometChatKeys.SocialKeys.DESCRIPTION, rawDetails.getString("description"));
        } catch (Exception e) {
            e.printStackTrace();
        }
        return socialDetais;
    }

    public static JSONObject formatGooglePlusJSON(Person person, GoogleApiClient googleApiClient) {
        JSONObject socialDetais = new JSONObject();
        try {
            socialDetais.put(SocialKeys.NETWORK_TYPE, "google");
            socialDetais.put(SocialKeys.IDENTIFIER, person.getId());
            socialDetais.put(SocialKeys.DISPLAY_NAME, person.getDisplayName());
            socialDetais.put(SocialKeys.GENDER, person.getGender() == 0 ? "Male" : "Female");
            socialDetais.put(SocialKeys.PROFILE_URL, person.getUrl());
            socialDetais.put(SocialKeys.PHOTO_URL, person.getImage().getUrl().replace("?sz=50", "?sz=100"));
            socialDetais.put(CometChatKeys.SocialKeys.EMAIL, Plus.AccountApi.getAccountName(googleApiClient));
            socialDetais.put(SocialKeys.FIRST_NAME, person.getName().getGivenName());
            socialDetais.put(SocialKeys.LAST_NAME, person.getName().getFamilyName());
        } catch (Exception e) {
            e.printStackTrace();
        }
        return socialDetais;
    }

    private static String getFacebookProfilePhotoLink(String id) {
        return "http://graph.facebook.com/" + id + "/picture";
    }

    private static String getTwitterPublicProfileLink(String username) {
        return "https://twitter.com/" + username;
    }

    public static void logout() {

        MobileConfig mobileConfig = JsonPhp.getInstance().getMobileConfig();

        if (null != mobileConfig && "1".equals(mobileConfig.getFacebookEnabled()) && null != Session.getActiveSession()) {
            Session.getActiveSession().closeAndClearTokenInformation();
        }
        if (null != mobileConfig && "1".equals(mobileConfig.getTwitterEnabled())) {
            Twitter.logOut();
        }
        if (null != mobileConfig && "1".equals(mobileConfig.getGoogleEnabled()) && null != googleApiClient) {
            if (googleApiClient.isConnected()) {
                Plus.AccountApi.clearDefaultAccount(googleApiClient);
                googleApiClient.disconnect();
            }
        }
    }

    public static void setGoogleApiClient(GoogleApiClient googleApiClient) {
        SocialAuth.googleApiClient = googleApiClient;
    }

    public static void getTwitterUserInfo(final Context context, final Result<TwitterSession> result, final VolleyAjaxCallbacks volleyAjaxCallbacks) {

        new AsyncTask<Void, Void, Void>() {

            private boolean success = true;
            private String responseString;

            @Override
            protected Void doInBackground(Void... params) {
                try {
                    // URL encode the consumer key and secret
                    String urlApiKey = URLEncoder.encode(LocalConfig.getTwitterKey(), "UTF-8");
                    String urlApiSecret = URLEncoder.encode(LocalConfig.getTwitterSecret(), "UTF-8");

                    // Concatenate the encoded consumer key, a colon character,
                    // and the encoded consumer secret
                    String combined = urlApiKey + ":" + urlApiSecret;

                    // Base64 encode the string
                    String base64Encoded = Base64.encodeToString(combined.getBytes(), Base64.NO_WRAP);

                    // Step 2: Obtain a bearer token
                    HttpPost httpPost = new HttpPost(URLFactory.TWITTER_TOKEN_URL);
                    httpPost.setHeader("Authorization", "Basic " + base64Encoded);
                    httpPost.setHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
                    httpPost.setEntity(new StringEntity("grant_type=client_credentials"));

                    DefaultHttpClient httpClient = new DefaultHttpClient(new BasicHttpParams());
                    HttpResponse response = httpClient.execute(httpPost);
                    responseString = EntityUtils.toString(response.getEntity());
                    Logger.error("Twitter1: " + responseString);
                    JSONObject responseJson = new JSONObject(responseString);
                    String accessToken = responseJson.getString("access_token");
                    String tokenType = responseJson.getString("token_type");

                    HttpGet httpget = new HttpGet(URLFactory.TWITTER_STREAM_URL + result.data.getUserName());
                    httpget.setHeader("Authorization", tokenType + " " + accessToken);
                    httpget.setHeader("Content-Type", "application/json");
                    httpget.setHeader("Host", "api.twitter.com");

                    HttpParams parameters = httpget.getParams();
                    parameters.setParameter("user_id", "327289069");
                    parameters.setParameter("screen_name", result.data.getUserName());
                    parameters.setParameter("include_entities", false);
                    httpget.setParams(parameters);

                    httpClient = new DefaultHttpClient(new BasicHttpParams());
                    response = httpClient.execute(httpget);
                    int statusCode = response.getStatusLine().getStatusCode();
                    responseString = EntityUtils.toString(response.getEntity());
                    Logger.error("Twitter2: " + responseString);
                    if (statusCode == 200) {
                        success = true;
                    } else {
                        success = false;
                    }
                } catch (Exception ex) {
                    responseString = ex.getLocalizedMessage();
                    success = false;
                    ex.printStackTrace();
                }
                return null;
            }

            @Override
            protected void onPostExecute(Void aVoid) {
                super.onPostExecute(aVoid);
                if (success) {
                    volleyAjaxCallbacks.successCallback(responseString);
                } else {
                    volleyAjaxCallbacks.failCallback(responseString, false);
                }
            }
        }.execute();
    }
}