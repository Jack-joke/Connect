package inscripts.com.librarytestapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.inscripts.cometchat.sdk.CometChat;
import com.inscripts.interfaces.Callbacks;
import com.inscripts.utils.Logger;

import org.json.JSONObject;

import helper.Keys.SharedPreferenceKeys;
import helper.SharedPreferenceHelper;

public class LoginActivity extends ActionBarActivity {

    EditText usernameField, passwordField;
    Button loginBtn;
    private CometChat cometchat;
    private boolean isReadyUI = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        usernameField = (EditText) findViewById(R.id.editTextUserName);
        passwordField = (EditText) findViewById(R.id.editTextPassword);
        loginBtn = (Button) findViewById(R.id.buttonLogin);

        Intent intent = getIntent();
        if (intent.hasExtra("readyui")) {
            isReadyUI = true;
        }

        final String apikey = SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY);
        final String siteUrl = SharedPreferenceHelper.get(SharedPreferenceKeys.SITE_URL);

        final String loginType = SharedPreferenceHelper.get(SharedPreferenceKeys.LOGIN_TYPE);

        switch (loginType) {

            case "1":
                usernameField.setHint("Enter userid");
                passwordField.setVisibility(View.GONE);
                break;
            case "3":
                usernameField.setHint("Enter guest name");
                passwordField.setVisibility(View.GONE);
                break;

            case "2":
                usernameField.setText("test-48");
                passwordField.setText("cometchat");
                break;
            default:
                break;
        }

        cometchat = CometChat.getInstance(getApplicationContext(),
                SharedPreferenceHelper.get(SharedPreferenceKeys.API_KEY));

        loginBtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {
                try {
                    final String username = usernameField.getText().toString().trim();
                    if (loginType.equals("2")) {
                        final String password = passwordField.getText().toString().trim();

                        if (TextUtils.isEmpty(username) || TextUtils.isEmpty(password)) {
                            usernameField.setError("Please enter name");
                            passwordField.setError("Please enter password");
                        } else {
                            /* For COD login */

							/*cometchat.login(username, password, new Callbacks() {

								@Override
								public void successCallback(JSONObject response) {
									SharedPreferenceHelper.save(SharedPreferenceKeys.USER_NAME, username);
									SharedPreferenceHelper.save(SharedPreferenceKeys.PASSWORD, password);
									Logger.debug("sresponse->" + response);
									LogsActivity.addToLog("Login successCallback");
									startCometchat();
								}

								@Override
								public void failCallback(JSONObject response) {
									usernameField.setError("Incorrect username");
									passwordField.setError("Incorrect password");
									Logger.debug("fresponse->" + response);
									LogsActivity.addToLog("Login failCallback");
								}
							});*/


                            /* For Without COD login */

                            cometchat.login(siteUrl, username, password, new Callbacks() {

                                @Override
                                public void successCallback(JSONObject response) {
                                    SharedPreferenceHelper.save(SharedPreferenceKeys.USER_NAME, username);
                                    SharedPreferenceHelper.save(SharedPreferenceKeys.PASSWORD, password);
                                    Logger.debug("sresponse->" + response);
                                    LogsActivity.addToLog("Login successCallback");
                                    startCometchat();
                                }

                                @Override
                                public void failCallback(JSONObject response) {
                                    usernameField.setError("Incorrect username");
                                    passwordField.setError("Incorrect password");
                                    Logger.debug("fresponse->" + response);
                                    LogsActivity.addToLog("Login failCallback");
                                }
                            });
                        }

                    } else {
                        if (TextUtils.isEmpty(username)) {
                            if (loginType.equals("1")) {
                                usernameField.setError("Please enter userid");
                            } else {
                                usernameField.setError("Please enter name");
                            }
                        } else {
                            if (loginType.equals("1")) { // Login with userid

								/* For COD login */

                                /*cometchat.login(username, new Callbacks() {

									@Override
									public void successCallback(JSONObject success) {
										Logger.debug("Login success: " + success);
										SharedPreferenceHelper.save(SharedPreferenceKeys.USER_NAME, username);
										LogsActivity.addToLog("Login successCallback");
										startCometchat();
									}

									@Override
									public void failCallback(JSONObject fail) {
										LogsActivity.addToLog("Login failCallback");
										Logger.debug("Login fail: " + fail);
										usernameField.setError("Incorrect userid");
									}
								});*/

                                   /* For Without COD login */
                                cometchat.login(siteUrl, username, new Callbacks() {

                                    @Override
                                    public void successCallback(JSONObject success) {
                                        Logger.debug("Login success: " + success);
                                        SharedPreferenceHelper.save(SharedPreferenceKeys.USER_NAME, username);
                                        LogsActivity.addToLog("Login successCallback");
                                        startCometchat();
                                    }

                                    @Override
                                    public void failCallback(JSONObject fail) {
                                        LogsActivity.addToLog("Login failCallback");
                                        Logger.debug("Login fail: " + fail);
                                        usernameField.setError("Incorrect userid");
                                    }
                                });

                            } else if (loginType.equals("3")) {
                                cometchat.guestLogin(siteUrl, username, new Callbacks() {

                                    @Override
                                    public void successCallback(JSONObject response) {
                                        Logger.debug("sresponse->" + response);
                                        SharedPreferenceHelper.save(SharedPreferenceKeys.USER_NAME, username);
                                        LogsActivity.addToLog("Login successCallback");
                                        startCometchat();
                                    }

                                    @Override
                                    public void failCallback(JSONObject response) {
                                        Logger.debug("fresponse->" + response);
                                        LogsActivity.addToLog("Login failCallback");
                                        Toast.makeText(getApplicationContext(), "Unable to login as guest",
                                                Toast.LENGTH_SHORT).show();
                                    }
                                });
                            }
                        }
                    }

                } catch (Exception e) {
                    e.printStackTrace();
                }
            }
        });

		/*cometchat.isCometChatInstalled("my url", new Callbacks() {

			@Override
			public void successCallback(JSONObject response) {
				Logger.debug("in success " + response);

			}

			@Override
			public void failCallback(JSONObject response) {
				Logger.debug("in fail " + response);
			}
		});*/
    }

    private void startCometchat() {
        SharedPreferenceHelper.save(SharedPreferenceKeys.IS_LOGGEDIN, "1");
        Intent intent = new Intent(LoginActivity.this, ChooserActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
        finish();
    }
}
