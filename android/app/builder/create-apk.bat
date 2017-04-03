@ECHO OFF

:: Copy all images
XCOPY /v /e /y ".\app_images" "..\CometChat\app\src\main\res\*.*"

:: Copy configuration
XCOPY /f /y ".\config.properties" ".\..\CometChat\app\src\main\assets\config.properties"

CD ".\..\CometChat"

CALL .\gradlew.bat clean

:: CALL .\gradlew.bat assembleDebug
CALL .\gradlew.bat assembleRelease

:: Navigate to starting directory
CD ..\builder

:: Copy APK into the builder folder
XCOPY /f /y ".\..\CometChat\app\build\outputs\apk\app-release.apk" ".\app-release.apk"

ECHO You will find the "app-release.apk" inside the "builder" folder.