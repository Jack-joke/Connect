CometChat Android SDK READY UI Android
=

The ReadyUI is developed by using Android Studio. It comprises of our CometChat android app UI and old SDK functionality in single package.

The generated SDK is in *.aar file format which has the layouts, images, libraries, jnilibs inside it.

The folder "MessageSDK" contains the source code for SDK and the folder "Librarytestapp" contains the source code for our sample app of SDK.

To use the code, import the MessageSDK project and LibraryTestApp project in Android Studio. Clean and build the MessageSDK project which will create the message-sdk.aar or app-sdk.aar file in build/outputs folder. Copy this file on some other location , rename it to cometchat-sdk.aar and paste it in LibraryTestApp's messagesdk module so that you can use it in sample app.

Refer [this link](https://docs.google.com/a/inscripts.in/document/d/16PTS4r14a4UHGMOcm_W9QgdTFMiyuEXavVkHudevWUA/edit?usp=sharing) to get details about how to package the SDK and make it ready for publishing and [this link](https://docs.google.com/a/inscripts.in/document/d/1195SJAJ9wf_G4q9eQfenjg2ByAHTFaXicyPp9I4fSJ8/edit?usp=sharing) to package sample app and make it ready for publishing.