@ECHO OFF

IF [%1]==[] GOTO :BLANK
IF [%2]==[] GOTO :BLANK

CALL keytool -genkey -v -keystore %1.keystore -alias %2 -keyalg RSA -keysize 2048 -validity 10000
GOTO :DONE

:BLANK
ECHO Missing parameters!
GOTO :DONE

:DONE
ECHO Done! You will find your keystore in this directory itself.