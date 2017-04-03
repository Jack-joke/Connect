using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']"
	[global::Android.Runtime.Register ("com/inscripts/utils/CommonUtils", DoNotGenerateAcw=true)]
	public partial class CommonUtils : global::Java.Lang.Object {


		static IntPtr usertoChannelMap_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/field[@name='usertoChannelMap']"
		[Register ("usertoChannelMap")]
		public static global::System.Collections.IDictionary UsertoChannelMap {
			get {
				if (usertoChannelMap_jfieldId == IntPtr.Zero)
					usertoChannelMap_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "usertoChannelMap", "Ljava/util/HashMap;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, usertoChannelMap_jfieldId);
				return global::Android.Runtime.JavaDictionary.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (usertoChannelMap_jfieldId == IntPtr.Zero)
					usertoChannelMap_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "usertoChannelMap", "Ljava/util/HashMap;");
				IntPtr native_value = global::Android.Runtime.JavaDictionary.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, usertoChannelMap_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/utils/CommonUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CommonUtils); }
		}

		protected CommonUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/constructor[@name='CommonUtils' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CommonUtils ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CommonUtils)) {
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

		static IntPtr id_isConnected;
		public static unsafe bool IsConnected {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isConnected' and count(parameter)=0]"
			[Register ("isConnected", "()Z", "GetIsConnectedHandler")]
			get {
				if (id_isConnected == IntPtr.Zero)
					id_isConnected = JNIEnv.GetStaticMethodID (class_ref, "isConnected", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isConnected);
				} finally {
				}
			}
		}

		static IntPtr id_isGreaterThanKitKat;
		public static unsafe bool IsGreaterThanKitKat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isGreaterThanKitKat' and count(parameter)=0]"
			[Register ("isGreaterThanKitKat", "()Z", "GetIsGreaterThanKitKatHandler")]
			get {
				if (id_isGreaterThanKitKat == IntPtr.Zero)
					id_isGreaterThanKitKat = JNIEnv.GetStaticMethodID (class_ref, "isGreaterThanKitKat", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isGreaterThanKitKat);
				} finally {
				}
			}
		}

		static IntPtr id_isSamsung;
		public static unsafe bool IsSamsung {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isSamsung' and count(parameter)=0]"
			[Register ("isSamsung", "()Z", "GetIsSamsungHandler")]
			get {
				if (id_isSamsung == IntPtr.Zero)
					id_isSamsung = JNIEnv.GetStaticMethodID (class_ref, "isSamsung", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isSamsung);
				} finally {
				}
			}
		}

		static IntPtr id_isSamsungWithApi16;
		public static unsafe bool IsSamsungWithApi16 {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isSamsungWithApi16' and count(parameter)=0]"
			[Register ("isSamsungWithApi16", "()Z", "GetIsSamsungWithApi16Handler")]
			get {
				if (id_isSamsungWithApi16 == IntPtr.Zero)
					id_isSamsungWithApi16 = JNIEnv.GetStaticMethodID (class_ref, "isSamsungWithApi16", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isSamsungWithApi16);
				} finally {
				}
			}
		}

		static IntPtr id_isXiaomi;
		public static unsafe bool IsXiaomi {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isXiaomi' and count(parameter)=0]"
			[Register ("isXiaomi", "()Z", "GetIsXiaomiHandler")]
			get {
				if (id_isXiaomi == IntPtr.Zero)
					id_isXiaomi = JNIEnv.GetStaticMethodID (class_ref, "isXiaomi", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isXiaomi);
				} finally {
				}
			}
		}

		static IntPtr id_getPlayerInstance;
		public static unsafe global::Android.Media.MediaPlayer PlayerInstance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getPlayerInstance' and count(parameter)=0]"
			[Register ("getPlayerInstance", "()Landroid/media/MediaPlayer;", "GetGetPlayerInstanceHandler")]
			get {
				if (id_getPlayerInstance == IntPtr.Zero)
					id_getPlayerInstance = JNIEnv.GetStaticMethodID (class_ref, "getPlayerInstance", "()Landroid/media/MediaPlayer;");
				try {
					return global::Java.Lang.Object.GetObject<global::Android.Media.MediaPlayer> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getPlayerInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getTypingStartMessage;
		public static unsafe string TypingStartMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getTypingStartMessage' and count(parameter)=0]"
			[Register ("getTypingStartMessage", "()Ljava/lang/String;", "GetGetTypingStartMessageHandler")]
			get {
				if (id_getTypingStartMessage == IntPtr.Zero)
					id_getTypingStartMessage = JNIEnv.GetStaticMethodID (class_ref, "getTypingStartMessage", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTypingStartMessage), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getTypingStopMessage;
		public static unsafe string TypingStopMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getTypingStopMessage' and count(parameter)=0]"
			[Register ("getTypingStopMessage", "()Ljava/lang/String;", "GetGetTypingStopMessageHandler")]
			get {
				if (id_getTypingStopMessage == IntPtr.Zero)
					id_getTypingStopMessage = JNIEnv.GetStaticMethodID (class_ref, "getTypingStopMessage", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTypingStopMessage), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_allowHttpsConnection;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='allowHttpsConnection' and count(parameter)=0]"
		[Register ("allowHttpsConnection", "()V", "")]
		public static unsafe void AllowHttpsConnection ()
		{
			if (id_allowHttpsConnection == IntPtr.Zero)
				id_allowHttpsConnection = JNIEnv.GetStaticMethodID (class_ref, "allowHttpsConnection", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_allowHttpsConnection);
			} finally {
			}
		}

		static IntPtr id_checkAudioType_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='checkAudioType' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("checkAudioType", "(Ljava/lang/String;)Ljava/lang/Boolean;", "")]
		public static unsafe global::Java.Lang.Boolean CheckAudioType (string p0)
		{
			if (id_checkAudioType_Ljava_lang_String_ == IntPtr.Zero)
				id_checkAudioType_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "checkAudioType", "(Ljava/lang/String;)Ljava/lang/Boolean;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Java.Lang.Boolean __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (JNIEnv.CallStaticObjectMethod  (class_ref, id_checkAudioType_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_checkImageType_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='checkImageType' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("checkImageType", "(Ljava/lang/String;)Ljava/lang/Boolean;", "")]
		public static unsafe global::Java.Lang.Boolean CheckImageType (string p0)
		{
			if (id_checkImageType_Ljava_lang_String_ == IntPtr.Zero)
				id_checkImageType_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "checkImageType", "(Ljava/lang/String;)Ljava/lang/Boolean;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Java.Lang.Boolean __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (JNIEnv.CallStaticObjectMethod  (class_ref, id_checkImageType_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_checkOnlineStatus_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='checkOnlineStatus' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("checkOnlineStatus", "(Ljava/lang/Long;)Ljava/lang/String;", "")]
		public static unsafe string CheckOnlineStatus (global::Java.Lang.Long p0)
		{
			if (id_checkOnlineStatus_Ljava_lang_Long_ == IntPtr.Zero)
				id_checkOnlineStatus_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "checkOnlineStatus", "(Ljava/lang/Long;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_checkOnlineStatus_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_checkVideoType_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='checkVideoType' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("checkVideoType", "(Ljava/lang/String;)Ljava/lang/Boolean;", "")]
		public static unsafe global::Java.Lang.Boolean CheckVideoType (string p0)
		{
			if (id_checkVideoType_Ljava_lang_String_ == IntPtr.Zero)
				id_checkVideoType_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "checkVideoType", "(Ljava/lang/String;)Ljava/lang/Boolean;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Java.Lang.Boolean __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (JNIEnv.CallStaticObjectMethod  (class_ref, id_checkVideoType_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_convertTimeStampToDurationTime_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='convertTimeStampToDurationTime' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("convertTimeStampToDurationTime", "(J)Ljava/lang/String;", "")]
		public static unsafe string ConvertTimeStampToDurationTime (long p0)
		{
			if (id_convertTimeStampToDurationTime_J == IntPtr.Zero)
				id_convertTimeStampToDurationTime_J = JNIEnv.GetStaticMethodID (class_ref, "convertTimeStampToDurationTime", "(J)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_convertTimeStampToDurationTime_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_convertTimestampToDate_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='convertTimestampToDate' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("convertTimestampToDate", "(J)Ljava/lang/String;", "")]
		public static unsafe string ConvertTimestampToDate (long p0)
		{
			if (id_convertTimestampToDate_J == IntPtr.Zero)
				id_convertTimestampToDate_J = JNIEnv.GetStaticMethodID (class_ref, "convertTimestampToDate", "(J)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_convertTimestampToDate_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_correctIncomingTimestamp_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='correctIncomingTimestamp' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("correctIncomingTimestamp", "(J)J", "")]
		public static unsafe long CorrectIncomingTimestamp (long p0)
		{
			if (id_correctIncomingTimestamp_J == IntPtr.Zero)
				id_correctIncomingTimestamp_J = JNIEnv.GetStaticMethodID (class_ref, "correctIncomingTimestamp", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_correctIncomingTimestamp_J, __args);
			} finally {
			}
		}

		static IntPtr id_createErrorJson_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='createErrorJson' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("createErrorJson", "(Ljava/lang/String;Ljava/lang/String;)Lorg/json/JSONObject;", "")]
		public static unsafe global::Org.Json.JSONObject CreateErrorJson (string p0, string p1)
		{
			if (id_createErrorJson_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_createErrorJson_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "createErrorJson", "(Ljava/lang/String;Ljava/lang/String;)Lorg/json/JSONObject;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				global::Org.Json.JSONObject __ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallStaticObjectMethod  (class_ref, id_createErrorJson_Ljava_lang_String_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_decodeBase64_arrayB;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='decodeBase64' and count(parameter)=1 and parameter[1][@type='byte[]']]"
		[Register ("decodeBase64", "([B)[B", "")]
		public static unsafe byte[] DecodeBase64 (byte[] p0)
		{
			if (id_decodeBase64_arrayB == IntPtr.Zero)
				id_decodeBase64_arrayB = JNIEnv.GetStaticMethodID (class_ref, "decodeBase64", "([B)[B");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_decodeBase64_arrayB, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_decodeBase64_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='decodeBase64' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("decodeBase64", "(Ljava/lang/String;)[B", "")]
		public static unsafe byte[] DecodeBase64 (string p0)
		{
			if (id_decodeBase64_Ljava_lang_String_ == IntPtr.Zero)
				id_decodeBase64_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "decodeBase64", "(Ljava/lang/String;)[B");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_decodeBase64_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_encodeBase64_arrayB;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='encodeBase64' and count(parameter)=1 and parameter[1][@type='byte[]']]"
		[Register ("encodeBase64", "([B)[B", "")]
		public static unsafe byte[] EncodeBase64 (byte[] p0)
		{
			if (id_encodeBase64_arrayB == IntPtr.Zero)
				id_encodeBase64_arrayB = JNIEnv.GetStaticMethodID (class_ref, "encodeBase64", "([B)[B");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_encodeBase64_arrayB, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_encodeBase64_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='encodeBase64' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("encodeBase64", "(Ljava/lang/String;)[B", "")]
		public static unsafe byte[] EncodeBase64 (string p0)
		{
			if (id_encodeBase64_Ljava_lang_String_ == IntPtr.Zero)
				id_encodeBase64_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "encodeBase64", "(Ljava/lang/String;)[B");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_encodeBase64_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_encodeURIComponent_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='encodeURIComponent' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("encodeURIComponent", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string EncodeURIComponent (string p0)
		{
			if (id_encodeURIComponent_Ljava_lang_String_ == IntPtr.Zero)
				id_encodeURIComponent_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "encodeURIComponent", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_encodeURIComponent_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getDateId_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getDateId' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getDateId", "(J)Ljava/lang/String;", "")]
		public static unsafe string GetDateId (long p0)
		{
			if (id_getDateId_J == IntPtr.Zero)
				id_getDateId_J = JNIEnv.GetStaticMethodID (class_ref, "getDateId", "(J)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDateId_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_getDeliveredTickMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getDeliveredTickMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getDeliveredTickMessage", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetDeliveredTickMessage (string p0)
		{
			if (id_getDeliveredTickMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_getDeliveredTickMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getDeliveredTickMessage", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDeliveredTickMessage_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getFormattedDate_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getFormattedDate' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("getFormattedDate", "(J)Ljava/lang/String;", "")]
		public static unsafe string GetFormattedDate (long p0)
		{
			if (id_getFormattedDate_J == IntPtr.Zero)
				id_getFormattedDate_J = JNIEnv.GetStaticMethodID (class_ref, "getFormattedDate", "(J)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getFormattedDate_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_getReadTickMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getReadTickMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getReadTickMessage", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetReadTickMessage (string p0)
		{
			if (id_getReadTickMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_getReadTickMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getReadTickMessage", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getReadTickMessage_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getScreenType_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getScreenType' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getScreenType", "(Landroid/content/Context;)Ljava/lang/String;", "")]
		public static unsafe string GetScreenType (global::Android.Content.Context p0)
		{
			if (id_getScreenType_Landroid_content_Context_ == IntPtr.Zero)
				id_getScreenType_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getScreenType", "(Landroid/content/Context;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getScreenType_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getVersionCode_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getVersionCode' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getVersionCode", "(Ljava/lang/String;)I", "")]
		public static unsafe int GetVersionCode (string p0)
		{
			if (id_getVersionCode_Ljava_lang_String_ == IntPtr.Zero)
				id_getVersionCode_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getVersionCode", "(Ljava/lang/String;)I");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_getVersionCode_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getVibratorInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='getVibratorInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getVibratorInstance", "(Landroid/content/Context;)Landroid/os/Vibrator;", "")]
		public static unsafe global::Android.OS.Vibrator GetVibratorInstance (global::Android.Content.Context p0)
		{
			if (id_getVibratorInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getVibratorInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getVibratorInstance", "(Landroid/content/Context;)Landroid/os/Vibrator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Android.OS.Vibrator __ret = global::Java.Lang.Object.GetObject<global::Android.OS.Vibrator> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getVibratorInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_handleLink_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='handleLink' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("handleLink", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string HandleLink (string p0)
		{
			if (id_handleLink_Ljava_lang_String_ == IntPtr.Zero)
				id_handleLink_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "handleLink", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_handleLink_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_handleSpecialHtmlCharacters_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='handleSpecialHtmlCharacters' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("handleSpecialHtmlCharacters", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string HandleSpecialHtmlCharacters (string p0)
		{
			if (id_handleSpecialHtmlCharacters_Ljava_lang_String_ == IntPtr.Zero)
				id_handleSpecialHtmlCharacters_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "handleSpecialHtmlCharacters", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_handleSpecialHtmlCharacters_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isJSONValid_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='isJSONValid' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isJSONValid", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsJSONValid (string p0)
		{
			if (id_isJSONValid_Ljava_lang_String_ == IntPtr.Zero)
				id_isJSONValid_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isJSONValid", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isJSONValid_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='performChatlogin' and count(parameter)=5 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.Callbacks'] and parameter[5][@type='int']]"
		[Register ("performChatlogin", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;I)V", "")]
		public static unsafe void PerformChatlogin (global::Android.Content.Context p0, string p1, string p2, global::Com.Inscripts.Interfaces.ICallbacks p3, int p4)
		{
			if (id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_I == IntPtr.Zero)
				id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_I = JNIEnv.GetStaticMethodID (class_ref, "performChatlogin", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;I)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_I, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='performChatlogin' and count(parameter)=5 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.LoginCallbacks'] and parameter[5][@type='int']]"
		[Register ("performChatlogin", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;I)V", "")]
		public static unsafe void PerformChatlogin (global::Android.Content.Context p0, string p1, string p2, global::Com.Inscripts.Interfaces.ILoginCallbacks p3, int p4)
		{
			if (id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_I == IntPtr.Zero)
				id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_I = JNIEnv.GetStaticMethodID (class_ref, "performChatlogin", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;I)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_performChatlogin_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_I, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_playRingtone_Landroid_app_Activity_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='playRingtone' and count(parameter)=2 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='java.lang.String']]"
		[Register ("playRingtone", "(Landroid/app/Activity;Ljava/lang/String;)V", "")]
		public static unsafe void PlayRingtone (global::Android.App.Activity p0, string p1)
		{
			if (id_playRingtone_Landroid_app_Activity_Ljava_lang_String_ == IntPtr.Zero)
				id_playRingtone_Landroid_app_Activity_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "playRingtone", "(Landroid/app/Activity;Ljava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_playRingtone_Landroid_app_Activity_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_processAvatarUrl_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='processAvatarUrl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("processAvatarUrl", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string ProcessAvatarUrl (string p0)
		{
			if (id_processAvatarUrl_Ljava_lang_String_ == IntPtr.Zero)
				id_processAvatarUrl_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "processAvatarUrl", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_processAvatarUrl_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_renderHtmlInATextView_Landroid_content_Context_Landroid_widget_TextView_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='renderHtmlInATextView' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.widget.TextView'] and parameter[3][@type='java.lang.String']]"
		[Register ("renderHtmlInATextView", "(Landroid/content/Context;Landroid/widget/TextView;Ljava/lang/String;)V", "")]
		public static unsafe void RenderHtmlInATextView (global::Android.Content.Context p0, global::Android.Widget.TextView p1, string p2)
		{
			if (id_renderHtmlInATextView_Landroid_content_Context_Landroid_widget_TextView_Ljava_lang_String_ == IntPtr.Zero)
				id_renderHtmlInATextView_Landroid_content_Context_Landroid_widget_TextView_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "renderHtmlInATextView", "(Landroid/content/Context;Landroid/widget/TextView;Ljava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_renderHtmlInATextView_Landroid_content_Context_Landroid_widget_TextView_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_resetPlayerInstance;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='resetPlayerInstance' and count(parameter)=0]"
		[Register ("resetPlayerInstance", "()V", "")]
		public static unsafe void ResetPlayerInstance ()
		{
			if (id_resetPlayerInstance == IntPtr.Zero)
				id_resetPlayerInstance = JNIEnv.GetStaticMethodID (class_ref, "resetPlayerInstance", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_resetPlayerInstance);
			} finally {
			}
		}

		static IntPtr id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='sendCallBackError' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.SubscribeCallbacks']]"
		[Register ("sendCallBackError", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeCallbacks;)V", "")]
		public static unsafe void SendCallBackError (string p0, string p1, global::Com.Inscripts.Interfaces.ISubscribeCallbacks p2)
		{
			if (id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ == IntPtr.Zero)
				id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "sendCallBackError", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeCallbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='sendCallBackError' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks']]"
		[Register ("sendCallBackError", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V", "")]
		public static unsafe void SendCallBackError (string p0, string p1, global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p2)
		{
			if (id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == IntPtr.Zero)
				id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "sendCallBackError", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendCallBackError_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_stopRingtone;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='stopRingtone' and count(parameter)=0]"
		[Register ("stopRingtone", "()V", "")]
		public static unsafe void StopRingtone ()
		{
			if (id_stopRingtone == IntPtr.Zero)
				id_stopRingtone = JNIEnv.GetStaticMethodID (class_ref, "stopRingtone", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_stopRingtone);
			} finally {
			}
		}

		static IntPtr id_stopVibrate_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='stopVibrate' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("stopVibrate", "(Landroid/content/Context;)V", "")]
		public static unsafe void StopVibrate (global::Android.Content.Context p0)
		{
			if (id_stopVibrate_Landroid_content_Context_ == IntPtr.Zero)
				id_stopVibrate_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "stopVibrate", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_stopVibrate_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static IntPtr id_translateMessage_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='translateMessage' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.VolleyAjaxCallbacks']]"
		[Register ("translateMessage", "(Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", "")]
		public static unsafe void TranslateMessage (string p0, global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks p1)
		{
			if (id_translateMessage_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ == IntPtr.Zero)
				id_translateMessage_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "translateMessage", "(Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_translateMessage_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_ucWords_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='ucWords' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("ucWords", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string UcWords (string p0)
		{
			if (id_ucWords_Ljava_lang_String_ == IntPtr.Zero)
				id_ucWords_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "ucWords", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_ucWords_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_xorWithKey_arrayBarrayB;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='CommonUtils']/method[@name='xorWithKey' and count(parameter)=2 and parameter[1][@type='byte[]'] and parameter[2][@type='byte[]']]"
		[Register ("xorWithKey", "([B[B)[B", "")]
		public static unsafe byte[] XorWithKey (byte[] p0, byte[] p1)
		{
			if (id_xorWithKey_arrayBarrayB == IntPtr.Zero)
				id_xorWithKey_arrayBarrayB = JNIEnv.GetStaticMethodID (class_ref, "xorWithKey", "([B[B)[B");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_xorWithKey_arrayBarrayB, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

	}
}
