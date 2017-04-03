# Copy all images
cp -R -f ./app_images/ ../CometChat/app/src/main/res

# Copy configuration
cp -R -f ./config.properties ./../CometChat/app/src/main/assets/config.properties

cd ./../CometChat

sudo chmod +x gradlew
./gradlew clean

# ./gradlew assembleDebug
./gradlew assembleRelease

cd ../builder

# Copy APK into the builder folder
cp -R -f ./../CometChat/app/build/outputs/apk/app-release.apk ./app-release.apk

echo "You will find the 'app-release.apk' inside the 'builder' folder."
exit