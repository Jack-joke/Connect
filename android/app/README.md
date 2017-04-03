CometChat Android Mobile App
=

CometChat Android mobile app is developed using Android studio.

This project has 2 main folders

 - builder
 - CometChat

The builder folder contains buildscript to build the whiltelabel app from command prompt. The CometChat folder contains source code for our app.

**Steps to open project in Android Studio**

 - Open Android studio
 - Select "Open an existing Android Studio project"
 - Select the folder where the CometChat project you have downloaded and expand it
 - Select build.gradle file

This will load the project.

**Steps to generate signed app**

 - Select "Generate Signed APK..." from "Build" menu
 - It will ask for keystore path, here select choose existing
 - Provide path to the stockapp.keystore which is located inside "Builder" folder
 - Provide Key store password as "tirocks"
 - Provide Key alias as "tidev"
 - Provide Key password as "tirocks"
 - Click on "Next" button
 - Provide destination path where "signed" apk will get created and click on "Finish"

