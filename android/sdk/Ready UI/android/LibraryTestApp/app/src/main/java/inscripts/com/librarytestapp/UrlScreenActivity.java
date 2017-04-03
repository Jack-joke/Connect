package inscripts.com.librarytestapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

import helper.Keys.SharedPreferenceKeys;
import helper.SharedPreferenceHelper;


public class UrlScreenActivity extends ActionBarActivity {

    private Button nextBtn;
    private EditText urlField;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_url_screen);
        nextBtn = (Button) findViewById(R.id.buttonNext);

        SharedPreferenceHelper.initialize(this);

        urlField = (EditText) findViewById(R.id.editTextUrlField);


        /* For cloud */
        //urlField.setHint("Enter API KEY");

        /* For selfhosted */
        urlField.setHint("Enter url");

        urlField.setText("http://192.168.0.111/git/cometchat/client/web/");

        SharedPreferenceHelper.save(SharedPreferenceKeys.API_KEY, "7808ebda5f6c611695c58f0911e9ff6f");

        nextBtn.setOnClickListener(new OnClickListener() {

            @Override
            public void onClick(View arg0) {

                final String url = urlField.getText().toString().trim();
                if (TextUtils.isEmpty(url)) {
                    urlField.setError("Please enter url");
                } else {
                    Intent intent = new Intent(UrlScreenActivity.this, LoginTypeActivity.class);
                    SharedPreferenceHelper.save(SharedPreferenceKeys.SITE_URL, url);
                    startActivity(intent);
                }
            }
        });

        boolean isLoggedin = SharedPreferenceHelper.contains(SharedPreferenceKeys.IS_LOGGEDIN)
                && SharedPreferenceHelper.get(SharedPreferenceKeys.IS_LOGGEDIN).equals("1");
        if (isLoggedin) {
            Intent i = new Intent(this, ChooserActivity.class);
            i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            i.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
            startActivity(i);
            finish();
        }
    }
}