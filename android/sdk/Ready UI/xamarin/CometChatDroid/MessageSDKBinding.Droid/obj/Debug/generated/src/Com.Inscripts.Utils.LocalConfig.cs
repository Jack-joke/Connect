using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']"
	[global::Android.Runtime.Register ("com/inscripts/utils/LocalConfig", DoNotGenerateAcw=true)]
	public partial class LocalConfig : global::Java.Lang.Object {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='DEMO_SITE_URL']"
		[Register ("DEMO_SITE_URL")]
		public const string DemoSiteUrl = (string) "https://chat.phpchatsoftware.com";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='INCOMING_CALL_TIMEOUT']"
		[Register ("INCOMING_CALL_TIMEOUT")]
		public const long IncomingCallTimeout = (long) 50000L;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='LOGIN_TYPE']"
		[Register ("LOGIN_TYPE")]
		[Obsolete ("deprecated")]
		public const int LoginType = (int) 1;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='OUTGOING_CALL_TIMEOUT']"
		[Register ("OUTGOING_CALL_TIMEOUT")]
		public const long OutgoingCallTimeout = (long) 55000L;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='SCROLL_BUTTON_TIMEOUT']"
		[Register ("SCROLL_BUTTON_TIMEOUT")]
		public const long ScrollButtonTimeout = (long) 3000L;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/field[@name='SPLASH_TIMEOUT']"
		[Register ("SPLASH_TIMEOUT")]
		public const int SplashTimeout = (int) 2000;
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/utils/LocalConfig", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LocalConfig); }
		}

		protected LocalConfig (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_getDefaultInviteMessage;
		public static unsafe string DefaultInviteMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getDefaultInviteMessage' and count(parameter)=0]"
			[Register ("getDefaultInviteMessage", "()Ljava/lang/String;", "GetGetDefaultInviteMessageHandler")]
			get {
				if (id_getDefaultInviteMessage == IntPtr.Zero)
					id_getDefaultInviteMessage = JNIEnv.GetStaticMethodID (class_ref, "getDefaultInviteMessage", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDefaultInviteMessage), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getFacebookAppId;
		public static unsafe string FacebookAppId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getFacebookAppId' and count(parameter)=0]"
			[Register ("getFacebookAppId", "()Ljava/lang/String;", "GetGetFacebookAppIdHandler")]
			get {
				if (id_getFacebookAppId == IntPtr.Zero)
					id_getFacebookAppId = JNIEnv.GetStaticMethodID (class_ref, "getFacebookAppId", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getFacebookAppId), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getFileUploadLimit;
		public static unsafe long FileUploadLimit {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getFileUploadLimit' and count(parameter)=0]"
			[Register ("getFileUploadLimit", "()J", "GetGetFileUploadLimitHandler")]
			get {
				if (id_getFileUploadLimit == IntPtr.Zero)
					id_getFileUploadLimit = JNIEnv.GetStaticMethodID (class_ref, "getFileUploadLimit", "()J");
				try {
					return JNIEnv.CallStaticLongMethod  (class_ref, id_getFileUploadLimit);
				} finally {
				}
			}
		}

		static IntPtr id_getIsCOD;
		public static unsafe string IsCOD {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getIsCOD' and count(parameter)=0]"
			[Register ("getIsCOD", "()Ljava/lang/String;", "GetGetIsCODHandler")]
			get {
				if (id_getIsCOD == IntPtr.Zero)
					id_getIsCOD = JNIEnv.GetStaticMethodID (class_ref, "getIsCOD", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getIsCOD), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_isWhiteLabelled;
		public static unsafe bool IsWhiteLabelled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='isWhiteLabelled' and count(parameter)=0]"
			[Register ("isWhiteLabelled", "()Z", "GetIsWhiteLabelledHandler")]
			get {
				if (id_isWhiteLabelled == IntPtr.Zero)
					id_isWhiteLabelled = JNIEnv.GetStaticMethodID (class_ref, "isWhiteLabelled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isWhiteLabelled);
				} finally {
				}
			}
		}

		static IntPtr id_getMessageLimit;
		public static unsafe string MessageLimit {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getMessageLimit' and count(parameter)=0]"
			[Register ("getMessageLimit", "()Ljava/lang/String;", "GetGetMessageLimitHandler")]
			get {
				if (id_getMessageLimit == IntPtr.Zero)
					id_getMessageLimit = JNIEnv.GetStaticMethodID (class_ref, "getMessageLimit", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getMessageLimit), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getParseAppId;
		public static unsafe string ParseAppId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getParseAppId' and count(parameter)=0]"
			[Register ("getParseAppId", "()Ljava/lang/String;", "GetGetParseAppIdHandler")]
			get {
				if (id_getParseAppId == IntPtr.Zero)
					id_getParseAppId = JNIEnv.GetStaticMethodID (class_ref, "getParseAppId", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getParseAppId), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getParseClientKey;
		public static unsafe string ParseClientKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getParseClientKey' and count(parameter)=0]"
			[Register ("getParseClientKey", "()Ljava/lang/String;", "GetGetParseClientKeyHandler")]
			get {
				if (id_getParseClientKey == IntPtr.Zero)
					id_getParseClientKey = JNIEnv.GetStaticMethodID (class_ref, "getParseClientKey", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getParseClientKey), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSiteUrl;
		public static unsafe string SiteUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getSiteUrl' and count(parameter)=0]"
			[Register ("getSiteUrl", "()Ljava/lang/String;", "GetGetSiteUrlHandler")]
			get {
				if (id_getSiteUrl == IntPtr.Zero)
					id_getSiteUrl = JNIEnv.GetStaticMethodID (class_ref, "getSiteUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSiteUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSplashBackgroundColor;
		public static unsafe string SplashBackgroundColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getSplashBackgroundColor' and count(parameter)=0]"
			[Register ("getSplashBackgroundColor", "()Ljava/lang/String;", "GetGetSplashBackgroundColorHandler")]
			get {
				if (id_getSplashBackgroundColor == IntPtr.Zero)
					id_getSplashBackgroundColor = JNIEnv.GetStaticMethodID (class_ref, "getSplashBackgroundColor", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSplashBackgroundColor), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getTwitterKey;
		public static unsafe string TwitterKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getTwitterKey' and count(parameter)=0]"
			[Register ("getTwitterKey", "()Ljava/lang/String;", "GetGetTwitterKeyHandler")]
			get {
				if (id_getTwitterKey == IntPtr.Zero)
					id_getTwitterKey = JNIEnv.GetStaticMethodID (class_ref, "getTwitterKey", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTwitterKey), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getTwitterSecret;
		public static unsafe string TwitterSecret {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getTwitterSecret' and count(parameter)=0]"
			[Register ("getTwitterSecret", "()Ljava/lang/String;", "GetGetTwitterSecretHandler")]
			get {
				if (id_getTwitterSecret == IntPtr.Zero)
					id_getTwitterSecret = JNIEnv.GetStaticMethodID (class_ref, "getTwitterSecret", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTwitterSecret), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getUserRegistrationLink;
		public static unsafe string UserRegistrationLink {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getUserRegistrationLink' and count(parameter)=0]"
			[Register ("getUserRegistrationLink", "()Ljava/lang/String;", "GetGetUserRegistrationLinkHandler")]
			get {
				if (id_getUserRegistrationLink == IntPtr.Zero)
					id_getUserRegistrationLink = JNIEnv.GetStaticMethodID (class_ref, "getUserRegistrationLink", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getUserRegistrationLink), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getString_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='getString' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getString", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetString (string p0)
		{
			if (id_getString_Ljava_lang_String_ == IntPtr.Zero)
				id_getString_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getString", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getString_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_initialize_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='LocalConfig']/method[@name='initialize' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("initialize", "(Landroid/content/Context;)V", "")]
		public static unsafe void Initialize (global::Android.Content.Context p0)
		{
			if (id_initialize_Landroid_content_Context_ == IntPtr.Zero)
				id_initialize_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "initialize", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_initialize_Landroid_content_Context_, __args);
			} finally {
			}
		}

	}
}
