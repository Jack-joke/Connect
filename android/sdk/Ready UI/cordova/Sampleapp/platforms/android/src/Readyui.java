import android.util.Log;

import com.inscripts.cometchat.sdk.MessageSDK;
import com.inscripts.interfaces.Callbacks;

import org.apache.cordova.CallbackContext;
import org.apache.cordova.CordovaInterface;
import org.apache.cordova.CordovaPlugin;
import org.apache.cordova.CordovaWebView;
import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

public class Readyui extends CordovaPlugin {

    /**
     * Constructor.
     */
    public Readyui() {
    }

    /**
     * Sets the context of the Command. This can then be used to do things like
     * get file paths associated with the Activity.
     *
     * @param cordova The context of the main Activity.
     * @param webView The CordovaWebView Cordova is running in.
     */

    public void initialize(CordovaInterface cordova, CordovaWebView webView) {
        super.initialize(cordova, webView);

    }

    public boolean execute(String action, JSONArray args, CallbackContext callbackContext) throws JSONException {
        action = action.trim().toLowerCase();
        if (action.equals("seturl")) {
            String url = args.getString(0);
            MessageSDK.setUrl(cordova.getActivity().getApplicationContext(), url, new Callbacks() {
                @Override
                public void successCallback(JSONObject jsonObject) {
                    Log.e("abc", "url success " + jsonObject);
                }

                @Override
                public void failCallback(JSONObject jsonObject) {

                }
            });
        } else if (action.equals("login")) {
            String username = args.getString(0).trim();
            String password = args.getString(1).trim();
            MessageSDK.login(cordova.getActivity().getApplicationContext(), username, password, new Callbacks() {
                @Override
                public void successCallback(JSONObject jsonObject) {
                    Log.e("abc", "login success " + jsonObject);
                }

                @Override
                public void failCallback(JSONObject jsonObject) {
                    Log.e("abc", "login fail " + jsonObject);
                }
            });

        } else if (action.equals("launchcometchat")) {
            MessageSDK.launchCometChat(cordova.getActivity(), new Callbacks() {
                @Override
                public void successCallback(JSONObject jsonObject) {

                }

                @Override
                public void failCallback(JSONObject jsonObject) {

                }
            });
        } else if(action.equals("chatwithme")){
            String userid = args.getString(0).trim();
            MessageSDK.launchChatWindow(false, cordova.getActivity(), userid, new Callbacks() {
                @Override
                public void successCallback(JSONObject jsonObject) {

                }

                @Override
                public void failCallback(JSONObject jsonObject) {

                }
            });
        }
        return true;
    }
}