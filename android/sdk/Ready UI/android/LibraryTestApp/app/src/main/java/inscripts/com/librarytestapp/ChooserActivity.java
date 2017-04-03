package inscripts.com.librarytestapp;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.View;
import android.widget.Button;


public class ChooserActivity extends ActionBarActivity {

    private Button sdk,readyui;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chooser);

        sdk = (Button) findViewById(R.id.btnCoreSDK);
        readyui = (Button) findViewById(R.id.btnReadyUI);

        sdk.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(), SampleCometChatActivity.class));
            }
        });

        readyui.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(getApplicationContext(), LauncherActivity.class));
            }
        });
    }
}
