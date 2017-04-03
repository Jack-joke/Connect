using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keys {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys']"
	[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys", DoNotGenerateAcw=true)]
	public partial class PreferenceKeys : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.Colors']"
		[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys$Colors", DoNotGenerateAcw=true)]
		public partial class Colors : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.Colors']/field[@name='COLOR_CHATROOM_CHAT']"
			[Register ("COLOR_CHATROOM_CHAT")]
			public const string ColorChatroomChat = (string) "COLOR_CHATROOM_CHAT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.Colors']/field[@name='COLOR_PRIMARY']"
			[Register ("COLOR_PRIMARY")]
			public const string ColorPrimary = (string) "PRIMARY_COLOR";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.Colors']/field[@name='COLOR_PRIMARY_DARK']"
			[Register ("COLOR_PRIMARY_DARK")]
			public const string ColorPrimaryDark = (string) "PRIMARY_COLOR_DARK";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys$Colors", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Colors); }
			}

			protected Colors (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.Colors']/constructor[@name='PreferenceKeys.Colors' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe Colors ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (Colors)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
						return;
					}

					if (id_ctor == IntPtr.Zero)
						id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys$DataKeys", DoNotGenerateAcw=true)]
		public partial class DataKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='ACTIVE_AVCHAT_BUDDY_ID']"
			[Register ("ACTIVE_AVCHAT_BUDDY_ID")]
			public const string ActiveAvchatBuddyId = (string) "ACTIVE_AVCHAT_BUDDY_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='ACTIVE_BUDDY_ID']"
			[Register ("ACTIVE_BUDDY_ID")]
			public const string ActiveBuddyId = (string) "ACTIVE_BUDDY_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='ACTIVE_CHATROOM_ID']"
			[Register ("ACTIVE_CHATROOM_ID")]
			public const string ActiveChatroomId = (string) "ACTIVE_CHATROOM_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='ANN_BADGE_COUNT']"
			[Register ("ANN_BADGE_COUNT")]
			public const string AnnBadgeCount = (string) "ANN_BADGE_COUNT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='API_KEY']"
			[Register ("API_KEY")]
			public const string ApiKey = (string) "COD_API_KEY";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='APP_INFO']"
			[Register ("APP_INFO")]
			public const string AppInfo = (string) "APP_INFO";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='BASE_DATA']"
			[Register ("BASE_DATA")]
			public const string BaseData = (string) "BASE_DATA";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='CHATROOM_COMET_ID']"
			[Register ("CHATROOM_COMET_ID")]
			public const string ChatroomCometId = (string) "CHATROOM_COMET_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='COD_ID']"
			[Register ("COD_ID")]
			public const string CodId = (string) "COD_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='CURRENT_CHATROOM_ID']"
			[Register ("CURRENT_CHATROOM_ID")]
			public const string CurrentChatroomId = (string) "CURRENT_CHATROOM_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='CURRENT_CHATROOM_PASSWORD']"
			[Register ("CURRENT_CHATROOM_PASSWORD")]
			public const string CurrentChatroomPassword = (string) "CURRENT_CHATROOM_PASSWORD";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='DEVELOPMENT_MODE']"
			[Register ("DEVELOPMENT_MODE")]
			public const string DevelopmentMode = (string) "SDK_DEVELOPMENT_MODE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='EMOJI_KEYBOARD_HEIGHT']"
			[Register ("EMOJI_KEYBOARD_HEIGHT")]
			public const string EmojiKeyboardHeight = (string) "EMOJI_KBD_HEIGHT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='IS_TAB_WINDOW_OPEN']"
			[Register ("IS_TAB_WINDOW_OPEN")]
			public const string IsTabWindowOpen = (string) "TABS_OPEN";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='JSON_CHATROOM_MEMBERS']"
			[Register ("JSON_CHATROOM_MEMBERS")]
			public const string JsonChatroomMembers = (string) "CHATROOM_MEMBERS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='JSON_PHP_DATA']"
			[Register ("JSON_PHP_DATA")]
			public const string JsonPhpData = (string) "JSON_PHP_DATA";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='JSON_RESPONSE_HASH']"
			[Register ("JSON_RESPONSE_HASH")]
			public const string JsonResponseHash = (string) "JSON_RESPONSE_HASH";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='LOAD_EARLIER_COUNT']"
			[Register ("LOAD_EARLIER_COUNT")]
			public const string LoadEarlierCount = (string) "LOAD_EARLIER_COUNT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='MY_PHONE_NUMBER']"
			[Register ("MY_PHONE_NUMBER")]
			public const string MyPhoneNumber = (string) "MY_PHONE_NUMBER";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='NOTIFICATION_STACK']"
			[Register ("NOTIFICATION_STACK")]
			public const string NotificationStack = (string) "NOTIFICATION_STACK";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='REGISTRATION_STATUS']"
			[Register ("REGISTRATION_STATUS")]
			public const string RegistrationStatus = (string) "REGISTRATION_STATUS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SAVED_STATUS']"
			[Register ("SAVED_STATUS")]
			public const string SavedStatus = (string) "SAVED_STATUS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SELECTED_LANGUAGE']"
			[Register ("SELECTED_LANGUAGE")]
			public const string SelectedLanguage = (string) "SELECTED_LANGUAGE_ONO";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SELECTED_LANGUAGE_DATA']"
			[Register ("SELECTED_LANGUAGE_DATA")]
			public const string SelectedLanguageData = (string) "SELECTED_LANGUAGE_DATA";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SELECTED_LANGUAGE_FULL']"
			[Register ("SELECTED_LANGUAGE_FULL")]
			public const string SelectedLanguageFull = (string) "SELECTED_LANGUAGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SERVER_DIFFERENCE']"
			[Register ("SERVER_DIFFERENCE")]
			public const string ServerDifference = (string) "SERVER_DIFFERENCE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SHARE_AUDIO_URL']"
			[Register ("SHARE_AUDIO_URL")]
			public const string ShareAudioUrl = (string) "SHARE_AUDIO_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SHARE_FILE_URL']"
			[Register ("SHARE_FILE_URL")]
			public const string ShareFileUrl = (string) "SHARE_FILE_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SHARE_IMAGE_URL']"
			[Register ("SHARE_IMAGE_URL")]
			public const string ShareImageUrl = (string) "SHARE_IMAGE_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='SHARE_VIDEO_URL']"
			[Register ("SHARE_VIDEO_URL")]
			public const string ShareVideoUrl = (string) "SHARE_VIDEO_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='TEMP_ID']"
			[Register ("TEMP_ID")]
			public const string TempId = (string) "TEMP_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='USER_STATUS']"
			[Register ("USER_STATUS")]
			public const string UserStatus = (string) "USER_STATUS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/field[@name='WALLPAPER_FILENAME']"
			[Register ("WALLPAPER_FILENAME")]
			public const string WallpaperFilename = (string) "WALLPAPER_FILENAME";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys$DataKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (DataKeys); }
			}

			protected DataKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.DataKeys']/constructor[@name='PreferenceKeys.DataKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe DataKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (DataKeys)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
						return;
					}

					if (id_ctor == IntPtr.Zero)
						id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys$HashKeys", DoNotGenerateAcw=true)]
		public partial class HashKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/field[@name='APP_LOGO_TIMESTAMP']"
			[Register ("APP_LOGO_TIMESTAMP")]
			public const string AppLogoTimestamp = (string) "APP_LOGO_TIMESTAMP";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/field[@name='BOT_LIST_HASH']"
			[Register ("BOT_LIST_HASH")]
			public const string BotListHash = (string) "BOT_LIST_HAST";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/field[@name='BUDDY_LIST_HASH']"
			[Register ("BUDDY_LIST_HASH")]
			public const string BuddyListHash = (string) "BUDDY_LIST_HASH";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/field[@name='CHATROOM_LIST_HASH']"
			[Register ("CHATROOM_LIST_HASH")]
			public const string ChatroomListHash = (string) "CHATROOM_LIST_HASH";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/field[@name='CHATROOM_MEMBERS_HASH']"
			[Register ("CHATROOM_MEMBERS_HASH")]
			public const string ChatroomMembersHash = (string) "USER_LIST_HASH";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys$HashKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (HashKeys); }
			}

			protected HashKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.HashKeys']/constructor[@name='PreferenceKeys.HashKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe HashKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (HashKeys)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
						return;
					}

					if (id_ctor == IntPtr.Zero)
						id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys$LoginKeys", DoNotGenerateAcw=true)]
		public partial class LoginKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='BASE_URL']"
			[Register ("BASE_URL")]
			public const string BaseUrl = (string) "BASE_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='COMETCHAT_FOLDER']"
			[Register ("COMETCHAT_FOLDER")]
			public const string CometchatFolder = (string) "COMETCHAT_FOLDER";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='CURRENT_PHONE']"
			[Register ("CURRENT_PHONE")]
			public const string CurrentPhone = (string) "CURRENT_PHONE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='INITIAL_URL']"
			[Register ("INITIAL_URL")]
			public const string InitialUrl = (string) "INITIAL_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGGED_IN']"
			[Register ("LOGGED_IN")]
			public const string LoggedIn = (string) "LOGGED_IN";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGGED_IN_AS_COD']"
			[Register ("LOGGED_IN_AS_COD")]
			public const string LoggedInAsCod = (string) "LOGGED_IN_AS_COD";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGGED_IN_AS_DEMO']"
			[Register ("LOGGED_IN_AS_DEMO")]
			public const string LoggedInAsDemo = (string) "LOGGED_IN_AS_DEMO";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGGED_IN_AS_GUEST']"
			[Register ("LOGGED_IN_AS_GUEST")]
			public const string LoggedInAsGuest = (string) "LOGGED_IN_AS_GUEST";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGIN_NAME']"
			[Register ("LOGIN_NAME")]
			public const string LoginName = (string) "USERNAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGIN_PASSWORD']"
			[Register ("LOGIN_PASSWORD")]
			public const string LoginPassword = (string) "PASSWORD";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='LOGIN_SITE_URL']"
			[Register ("LOGIN_SITE_URL")]
			public const string LoginSiteUrl = (string) "SDK_BASE_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='OLD_LOGIN_URL']"
			[Register ("OLD_LOGIN_URL")]
			public const string OldLoginUrl = (string) "OLD_LOGIN_URL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='REMEMBER_ME']"
			[Register ("REMEMBER_ME")]
			public const string RememberMe = (string) "REMEMBER_ME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='VERSION_CODE']"
			[Register ("VERSION_CODE")]
			public const string VersionCode = (string) "VERSION_CODE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/field[@name='VERSION_CODE_VALUE']"
			[Register ("VERSION_CODE_VALUE")]
			public const string VersionCodeValue = (string) "VERSION_CODE_VALUE";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys$LoginKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (LoginKeys); }
			}

			protected LoginKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.LoginKeys']/constructor[@name='PreferenceKeys.LoginKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe LoginKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (LoginKeys)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
						return;
					}

					if (id_ctor == IntPtr.Zero)
						id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/PreferenceKeys$UserKeys", DoNotGenerateAcw=true)]
		public partial class UserKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='CHANGE_EMAIL']"
			[Register ("CHANGE_EMAIL")]
			public const string ChangeEmail = (string) "CHANGE_EMAIL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='LAST_SEEN_SETTING']"
			[Register ("LAST_SEEN_SETTING")]
			public const string LastSeenSetting = (string) "LAST_SEEN_SETTING";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='NOTIFICATION_ON']"
			[Register ("NOTIFICATION_ON")]
			public const string NotificationOn = (string) "NOTIFICATION_ON";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='NOTIFICATION_SOUND']"
			[Register ("NOTIFICATION_SOUND")]
			public const string NotificationSound = (string) "NOTIFICATION_SOUND";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='NOTIFICATION_VIBRATE']"
			[Register ("NOTIFICATION_VIBRATE")]
			public const string NotificationVibrate = (string) "NOTIFICATION_VIBRATE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='READ_TICK']"
			[Register ("READ_TICK")]
			public const string ReadTick = (string) "READ_TICK_ON";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='SECOND_VERI_CODE']"
			[Register ("SECOND_VERI_CODE")]
			public const string SecondVeriCode = (string) "SECOND_VERI_CODE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='STATUS']"
			[Register ("STATUS")]
			public const string Status = (string) "STATUS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='STATUS_MESSAGE']"
			[Register ("STATUS_MESSAGE")]
			public const string StatusMessage = (string) "STATUS_MESSAGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='TYPING_SETTING']"
			[Register ("TYPING_SETTING")]
			public const string TypingSetting = (string) "TYPING_SETTING";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_EMAIL']"
			[Register ("USER_EMAIL")]
			public const string UserEmail = (string) "USER_EMAIL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_ID']"
			[Register ("USER_ID")]
			public const string UserId = (string) "USER_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_LINK']"
			[Register ("USER_LINK")]
			public const string UserLink = (string) "USER_LINK";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_NAME']"
			[Register ("USER_NAME")]
			public const string UserName = (string) "USER_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_PREVIOUS_AVATAR']"
			[Register ("USER_PREVIOUS_AVATAR")]
			public const string UserPreviousAvatar = (string) "USER_PREVIOUS_AVATAR";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='USER_PREVIOUS_NAME']"
			[Register ("USER_PREVIOUS_NAME")]
			public const string UserPreviousName = (string) "USER_PREVIOUS_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='VIDEO_FILE_NAME']"
			[Register ("VIDEO_FILE_NAME")]
			public const string VideoFileName = (string) "VIDEO_FILE_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/field[@name='WEBRTC_CHANNEL']"
			[Register ("WEBRTC_CHANNEL")]
			public const string WebrtcChannel = (string) "WEBRTC_CHANNEL";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys$UserKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (UserKeys); }
			}

			protected UserKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys.UserKeys']/constructor[@name='PreferenceKeys.UserKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe UserKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (UserKeys)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
						return;
					}

					if (id_ctor == IntPtr.Zero)
						id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/keys/PreferenceKeys", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (PreferenceKeys); }
		}

		protected PreferenceKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='PreferenceKeys']/constructor[@name='PreferenceKeys' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe PreferenceKeys ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (PreferenceKeys)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
					return;
				}

				if (id_ctor == IntPtr.Zero)
					id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor);
			} finally {
			}
		}

	}
}
