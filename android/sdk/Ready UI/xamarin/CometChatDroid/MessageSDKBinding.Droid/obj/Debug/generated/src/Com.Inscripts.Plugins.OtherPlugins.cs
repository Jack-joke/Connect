using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/OtherPlugins", DoNotGenerateAcw=true)]
	public partial class OtherPlugins : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/OtherPlugins", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OtherPlugins); }
		}

		protected OtherPlugins (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/constructor[@name='OtherPlugins' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe OtherPlugins ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (OtherPlugins)) {
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

		static IntPtr id_isBroadcastMessageEnabled;
		public static unsafe bool IsBroadcastMessageEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isBroadcastMessageEnabled' and count(parameter)=0]"
			[Register ("isBroadcastMessageEnabled", "()Z", "GetIsBroadcastMessageEnabledHandler")]
			get {
				if (id_isBroadcastMessageEnabled == IntPtr.Zero)
					id_isBroadcastMessageEnabled = JNIEnv.GetStaticMethodID (class_ref, "isBroadcastMessageEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isBroadcastMessageEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_isCrWhiteBoarddisabled;
		public static unsafe bool IsCrWhiteBoarddisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isCrWhiteBoarddisabled' and count(parameter)=0]"
			[Register ("isCrWhiteBoarddisabled", "()Z", "GetIsCrWhiteBoarddisabledHandler")]
			get {
				if (id_isCrWhiteBoarddisabled == IntPtr.Zero)
					id_isCrWhiteBoarddisabled = JNIEnv.GetStaticMethodID (class_ref, "isCrWhiteBoarddisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrWhiteBoarddisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isCrWriteBoarddisabled;
		public static unsafe bool IsCrWriteBoarddisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isCrWriteBoarddisabled' and count(parameter)=0]"
			[Register ("isCrWriteBoarddisabled", "()Z", "GetIsCrWriteBoarddisabledHandler")]
			get {
				if (id_isCrWriteBoarddisabled == IntPtr.Zero)
					id_isCrWriteBoarddisabled = JNIEnv.GetStaticMethodID (class_ref, "isCrWriteBoarddisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrWriteBoarddisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isHandwriteDisabled;
		public static unsafe bool IsHandwriteDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isHandwriteDisabled' and count(parameter)=0]"
			[Register ("isHandwriteDisabled", "()Z", "GetIsHandwriteDisabledHandler")]
			get {
				if (id_isHandwriteDisabled == IntPtr.Zero)
					id_isHandwriteDisabled = JNIEnv.GetStaticMethodID (class_ref, "isHandwriteDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isHandwriteDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isSinglePlayerGamesEnabled;
		public static unsafe bool IsSinglePlayerGamesEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isSinglePlayerGamesEnabled' and count(parameter)=0]"
			[Register ("isSinglePlayerGamesEnabled", "()Z", "GetIsSinglePlayerGamesEnabledHandler")]
			get {
				if (id_isSinglePlayerGamesEnabled == IntPtr.Zero)
					id_isSinglePlayerGamesEnabled = JNIEnv.GetStaticMethodID (class_ref, "isSinglePlayerGamesEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isSinglePlayerGamesEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_isWhiteBoarddisabled;
		public static unsafe bool IsWhiteBoarddisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isWhiteBoarddisabled' and count(parameter)=0]"
			[Register ("isWhiteBoarddisabled", "()Z", "GetIsWhiteBoarddisabledHandler")]
			get {
				if (id_isWhiteBoarddisabled == IntPtr.Zero)
					id_isWhiteBoarddisabled = JNIEnv.GetStaticMethodID (class_ref, "isWhiteBoarddisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isWhiteBoarddisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isWriteBoarddisabled;
		public static unsafe bool IsWriteBoarddisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isWriteBoarddisabled' and count(parameter)=0]"
			[Register ("isWriteBoarddisabled", "()Z", "GetIsWriteBoarddisabledHandler")]
			get {
				if (id_isWriteBoarddisabled == IntPtr.Zero)
					id_isWriteBoarddisabled = JNIEnv.GetStaticMethodID (class_ref, "isWriteBoarddisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isWriteBoarddisabled);
				} finally {
				}
			}
		}

		static IntPtr id_getHandwriteImageUrl_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getHandwriteImageUrl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getHandwriteImageUrl", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetHandwriteImageUrl (string p0)
		{
			if (id_getHandwriteImageUrl_Ljava_lang_String_ == IntPtr.Zero)
				id_getHandwriteImageUrl_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getHandwriteImageUrl", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getHandwriteImageUrl_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getMessageID_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getMessageID' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getMessageID", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetMessageID (string p0)
		{
			if (id_getMessageID_Ljava_lang_String_ == IntPtr.Zero)
				id_getMessageID_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getMessageID", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getMessageID_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getRandomId_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getRandomId' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getRandomId", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetRandomId (string p0)
		{
			if (id_getRandomId_Ljava_lang_String_ == IntPtr.Zero)
				id_getRandomId_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getRandomId", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRandomId_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getTickMessageDetail_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getTickMessageDetail' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getTickMessageDetail", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetTickMessageDetail (string p0)
		{
			if (id_getTickMessageDetail_Ljava_lang_String_ == IntPtr.Zero)
				id_getTickMessageDetail_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getTickMessageDetail", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTickMessageDetail_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getWhiteBoardRoomName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getWhiteBoardRoomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getWhiteBoardRoomName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetWhiteBoardRoomName (string p0)
		{
			if (id_getWhiteBoardRoomName_Ljava_lang_String_ == IntPtr.Zero)
				id_getWhiteBoardRoomName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getWhiteBoardRoomName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWhiteBoardRoomName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getWriteBoardRoomName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='getWriteBoardRoomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getWriteBoardRoomName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetWriteBoardRoomName (string p0)
		{
			if (id_getWriteBoardRoomName_Ljava_lang_String_ == IntPtr.Zero)
				id_getWriteBoardRoomName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getWriteBoardRoomName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWriteBoardRoomName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isBotResponce_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isBotResponce' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isBotResponce", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsBotResponce (string p0)
		{
			if (id_isBotResponce_Ljava_lang_String_ == IntPtr.Zero)
				id_isBotResponce_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isBotResponce", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isBotResponce_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isGameAccept_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isGameAccept' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isGameAccept", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsGameAccept (string p0)
		{
			if (id_isGameAccept_Ljava_lang_String_ == IntPtr.Zero)
				id_isGameAccept_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isGameAccept", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isGameAccept_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isGameRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isGameRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isGameRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsGameRequest (string p0)
		{
			if (id_isGameRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isGameRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isGameRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isGameRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isHandWrite_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isHandWrite' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isHandWrite", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsHandWrite (string p0)
		{
			if (id_isHandWrite_Ljava_lang_String_ == IntPtr.Zero)
				id_isHandWrite_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isHandWrite", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isHandWrite_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isMessageDelivery_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isMessageDelivery' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isMessageDelivery", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsMessageDelivery (string p0)
		{
			if (id_isMessageDelivery_Ljava_lang_String_ == IntPtr.Zero)
				id_isMessageDelivery_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isMessageDelivery", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isMessageDelivery_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isMessageRead_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isMessageRead' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isMessageRead", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsMessageRead (string p0)
		{
			if (id_isMessageRead_Ljava_lang_String_ == IntPtr.Zero)
				id_isMessageRead_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isMessageRead", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isMessageRead_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isMessageReadDelivered_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isMessageReadDelivered' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isMessageReadDelivered", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsMessageReadDelivered (string p0)
		{
			if (id_isMessageReadDelivered_Ljava_lang_String_ == IntPtr.Zero)
				id_isMessageReadDelivered_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isMessageReadDelivered", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isMessageReadDelivered_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isScreehShareRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isScreehShareRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isScreehShareRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsScreehShareRequest (string p0)
		{
			if (id_isScreehShareRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isScreehShareRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isScreehShareRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isScreehShareRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isTypingStart_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isTypingStart' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isTypingStart", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsTypingStart (string p0)
		{
			if (id_isTypingStart_Ljava_lang_String_ == IntPtr.Zero)
				id_isTypingStart_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isTypingStart", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isTypingStart_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isTypingStop_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isTypingStop' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isTypingStop", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsTypingStop (string p0)
		{
			if (id_isTypingStop_Ljava_lang_String_ == IntPtr.Zero)
				id_isTypingStop_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isTypingStop", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isTypingStop_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isWhiteBoardRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isWhiteBoardRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isWhiteBoardRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsWhiteBoardRequest (string p0)
		{
			if (id_isWhiteBoardRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isWhiteBoardRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isWhiteBoardRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isWhiteBoardRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isWriteBoardRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='isWriteBoardRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isWriteBoardRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsWriteBoardRequest (string p0)
		{
			if (id_isWriteBoardRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isWriteBoardRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isWriteBoardRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isWriteBoardRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_iscrHandwriteDisabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='OtherPlugins']/method[@name='iscrHandwriteDisabled' and count(parameter)=0]"
		[Register ("iscrHandwriteDisabled", "()Z", "")]
		public static unsafe bool IscrHandwriteDisabled ()
		{
			if (id_iscrHandwriteDisabled == IntPtr.Zero)
				id_iscrHandwriteDisabled = JNIEnv.GetStaticMethodID (class_ref, "iscrHandwriteDisabled", "()Z");
			try {
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_iscrHandwriteDisabled);
			} finally {
			}
		}

	}
}
