package com.inscripts.services;


import android.app.NotificationManager;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.IBinder;
import android.os.ResultReceiver;
import android.support.annotation.Nullable;
import android.support.v4.app.NotificationCompat;

import com.inscripts.activities.R;
import com.inscripts.factories.URLFactory;
import com.inscripts.helpers.PreferenceHelper;
import com.inscripts.keys.CometChatKeys;
import com.inscripts.keys.PreferenceKeys;
import com.inscripts.utils.AndroidMultiPartEntity;
import com.inscripts.utils.Logger;
import com.inscripts.utils.SessionData;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.mime.content.FileBody;
import org.apache.http.entity.mime.content.StringBody;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

import java.io.File;
import java.io.IOException;

public class FileUploadService extends Service {
    private static final String TAG = FileUploadService.class.getSimpleName();
    private static final String APPLICATION = "CometChat";
    private ResultReceiver resultReceiver;
    NotificationManager mNotifyManager;
    NotificationCompat.Builder mBuilder;

  /*  public FileUploadService() {
        super(TAG);
    }*/

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    private String toId,fileName,filePath,imageHeight,imageWidth;
    private float totalSize;
    private long msgId;

  /*  @Override
    protected void onHandleIntent(Intent intent) {
        Logger.error(TAG,"inside onHandleIntent");
        filePath = intent.getStringExtra(CometChatKeys.FileUploadKeys.FILEDATA);
        toId = intent.getStringExtra(CometChatKeys.AjaxKeys.TO);
        fileName = intent.getStringExtra(CometChatKeys.FileUploadKeys.FILENAME);
        imageHeight = intent.getStringExtra(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT);
        imageWidth = intent.getStringExtra(CometChatKeys.FileUploadKeys.IMAGE_WIDTH);
         resultReceiver = intent.getParcelableExtra("Result_receiver");

        Logger.error(TAG,"image result receiver = "+resultReceiver);
        Logger.error(TAG,"to Id = "+toId);
        Logger.error(TAG,"file name  = "+fileName);
        Logger.error(TAG,"imageheight  = "+imageHeight);
        Logger.error(TAG,"imagewidth  = "+imageWidth);


        new UploadFileToServer().execute();
       // uploadFileToServer(toId,fpath,fileName,imageHeight,imageWidht);
    }*/

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        mNotifyManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        mBuilder = new NotificationCompat.Builder(FileUploadService.this);
        mBuilder.setContentTitle("File uploaded").setSmallIcon(
                R.drawable.ic_launcher);

        Logger.error(TAG,"onStartCommand");
        filePath = intent.getStringExtra(CometChatKeys.FileUploadKeys.FILEDATA);
        toId = intent.getStringExtra(CometChatKeys.AjaxKeys.TO);
        fileName = intent.getStringExtra(CometChatKeys.FileUploadKeys.FILENAME);
        imageHeight = intent.getStringExtra(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT);
        imageWidth = intent.getStringExtra(CometChatKeys.FileUploadKeys.IMAGE_WIDTH);
        resultReceiver = intent.getParcelableExtra("Result_receiver");
        msgId = intent.getLongExtra("LocalMsgId",-1);

        new UploadFileToServer().execute();
        //uploadFileToServer(toId,filePath,fileName,imageHeight,imageWidth);
        return Service.START_STICKY;
    }


   /* void uploadFileToServer(final String toId, String path, final String fileName , final String imageheight, final String imageWidth){
        Logger.error(TAG, "inside Upload Service");
        final String fpath = path;
        new Thread(new Runnable() {
            @Override
            public void run() {
                HttpClient httpClient = new DefaultHttpClient();
                final HttpPost postRequest = new HttpPost(URLFactory.getFileUploadURL());
                MultipartEntityBuilder builder = MultipartEntityBuilder.create();
                builder.setMode(HttpMultipartMode.BROWSER_COMPATIBLE);
                FileBody fileBody = new FileBody(new File(fpath));
                builder.addTextBody(CometChatKeys.AjaxKeys.TO,String.valueOf(toId));
                builder.addTextBody(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT,imageheight);
                builder.addTextBody(CometChatKeys.FileUploadKeys.IMAGE_WIDTH,imageWidth);
                builder.addTextBody(CometChatKeys.FileUploadKeys.FILENAME,fileName);
                builder.addTextBody(CometChatKeys.AjaxKeys.BASE_DATA, SessionData.getInstance().getBaseData());
                builder.addTextBody(CometChatKeys.AjaxKeys.CALLBACK_FN, CometChatKeys.AjaxKeys.CALLBACK_FN_VALUE);
                builder.addTextBody(CometChatKeys.AjaxKeys.VERSION2,"1");
                builder.addTextBody(CometChatKeys.AjaxKeys.VERSION3,"1");

                builder.addPart(CometChatKeys.FileUploadKeys.FILEDATA, fileBody);
                final HttpEntity entity = builder.build();

                ProgressHttpEntityWrapper.ProgressCallback progressCallback = new ProgressHttpEntityWrapper.ProgressCallback(){
                    @Override
                    public void progress(final float progress) throws InterruptedException {
                        //Use the progress
                        Logger.error("Progress = "+progress);
                        Bundle bundle = new Bundle();
                        bundle.putFloat("progress",progress);
                        resultReceiver.send(200,bundle);
                    }

                };

                postRequest.setEntity(new ProgressHttpEntityWrapper(entity, progressCallback));
                //  postRequest.setEntity(entity);
                try {
                    HttpResponse response = httpClient.execute(postRequest);
                    BufferedReader reader = new BufferedReader(new InputStreamReader(response.getEntity().getContent(), "UTF-8"));
                    String sResponse;
                    StringBuilder serverResponse = new StringBuilder();
                    while ((sResponse = reader.readLine()) != null) {
                        serverResponse = serverResponse.append(sResponse);
                    }
                    String sendResponse = serverResponse.toString();
                    Logger.error(TAG ,"upload file success responce = "+ sendResponse);
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }).start();


    }*/

    private class UploadFileToServer extends AsyncTask<Void, Integer, String> {

        protected void onPreExecute() {
            // setting progress bar to zero
            Logger.error(TAG,"OnPreExecute");
            mBuilder.setProgress(100, 0, false);
            mNotifyManager.notify(0, mBuilder.build());
            super.onPreExecute();
        }

        @Override
        protected void onProgressUpdate(Integer... progress) {
            mBuilder.setProgress(100,
                    Integer.parseInt(String.valueOf(progress[0])), false);
            Bundle bundle = new Bundle();
            bundle.putFloat("progress",Integer.parseInt(String.valueOf(progress[0])));
            resultReceiver.send(200,bundle);
            Logger.error(TAG,"Progress value = "+String.valueOf(progress[0]));
            mNotifyManager.notify(0, mBuilder.build());
        }

        @Override
        protected String doInBackground(Void... params) {
            return uploadFile();
        }

        private String uploadFile() {
            String responseString = null;

            HttpClient httpclient = new DefaultHttpClient();
            String callback = "?callback=jqcc"+ PreferenceHelper.get(PreferenceKeys.DataKeys.IMEI_DATA)+"_"+System.currentTimeMillis()+"_"+msgId;

            Logger.error(TAG,"Callback value = "+callback);
            HttpPost httppost = new HttpPost(URLFactory.getFileUploadURL()+callback);

            try {
                AndroidMultiPartEntity entity = new AndroidMultiPartEntity(
                        new AndroidMultiPartEntity.ProgressListener() {
                            public void transferred(long num) {
                                Logger.error(TAG,"num = "+num);
                                Logger.error(TAG,"Div value = "+((num / (float) totalSize) * 100));
                                publishProgress((int) ((num / (float) totalSize) * 100));
                            }
                        });

                FileBody fileBody = new FileBody(new File(filePath));
                entity.addPart(CometChatKeys.FileUploadKeys.FILEDATA, fileBody);



                entity.addPart(CometChatKeys.AjaxKeys.TO,new StringBody(String.valueOf(toId)));
                entity.addPart(CometChatKeys.FileUploadKeys.IMAGE_HEIGHT,new StringBody(imageHeight));
                entity.addPart(CometChatKeys.FileUploadKeys.IMAGE_WIDTH,new StringBody(imageWidth));
                entity.addPart(CometChatKeys.FileUploadKeys.FILENAME,new StringBody(fileName));
                entity.addPart(CometChatKeys.AjaxKeys.BASE_DATA, new StringBody(SessionData.getInstance().getBaseData()));
                entity.addPart(CometChatKeys.AjaxKeys.CALLBACK_FN, new StringBody(CometChatKeys.AjaxKeys.CALLBACK_FN_VALUE));
                entity.addPart(CometChatKeys.AjaxKeys.VERSION2,new StringBody("1"));
                entity.addPart(CometChatKeys.AjaxKeys.VERSION3,new StringBody("1"));

                totalSize = entity.getContentLength();
                httppost.setEntity(entity);

                // Making server call
                HttpResponse response = httpclient.execute(httppost);
                HttpEntity r_entity = response.getEntity();

                int statusCode = response.getStatusLine().getStatusCode();
                if (statusCode == 200) {
                    // Server response
                    responseString = EntityUtils.toString(r_entity);
                    Logger.error("Responce string = "+responseString);
                } else {
                    responseString = "Error occurred! Http Status Code: "
                            + statusCode;
                }

            } catch (ClientProtocolException e) {
                responseString = e.toString();
            } catch (IOException e) {
                responseString = e.toString();


            }
            return responseString;

        }

        @Override
        protected void onPostExecute(String result) {
            //session.showNot(result);
            mBuilder.setContentText("Upload complete").setProgress(0, 0,false);
            mNotifyManager.notify(6532365, mBuilder.build());
            mNotifyManager.cancel(6532365);
            super.onPostExecute(result);
        }
    }

}
