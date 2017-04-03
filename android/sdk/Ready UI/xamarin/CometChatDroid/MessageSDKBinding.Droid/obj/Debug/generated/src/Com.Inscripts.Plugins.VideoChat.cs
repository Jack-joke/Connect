using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/VideoChat", DoNotGenerateAcw=true)]
	public partial class VideoChat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/VideoChat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (VideoChat); }
		}

		protected VideoChat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/constructor[@name='VideoChat' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe VideoChat ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (VideoChat)) {
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

		static IntPtr id_isAudioChatDisabled;
		public static unsafe bool IsAudioChatDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatDisabled' and count(parameter)=0]"
			[Register ("isAudioChatDisabled", "()Z", "GetIsAudioChatDisabledHandler")]
			get {
				if (id_isAudioChatDisabled == IntPtr.Zero)
					id_isAudioChatDisabled = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isConferenceDisabled;
		public static unsafe bool IsConferenceDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isConferenceDisabled' and count(parameter)=0]"
			[Register ("isConferenceDisabled", "()Z", "GetIsConferenceDisabledHandler")]
			get {
				if (id_isConferenceDisabled == IntPtr.Zero)
					id_isConferenceDisabled = JNIEnv.GetStaticMethodID (class_ref, "isConferenceDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isConferenceDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isDisabled;
		public static unsafe bool IsDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isDisabled' and count(parameter)=0]"
			[Register ("isDisabled", "()Z", "GetIsDisabledHandler")]
			get {
				if (id_isDisabled == IntPtr.Zero)
					id_isDisabled = JNIEnv.GetStaticMethodID (class_ref, "isDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_getAVConferenceRoomName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='getAVConferenceRoomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getAVConferenceRoomName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetAVConferenceRoomName (string p0)
		{
			if (id_getAVConferenceRoomName_Ljava_lang_String_ == IntPtr.Zero)
				id_getAVConferenceRoomName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getAVConferenceRoomName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVConferenceRoomName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getAVRoomName_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='getAVRoomName' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getAVRoomName", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetAVRoomName (string p0, bool p1)
		{
			if (id_getAVRoomName_Ljava_lang_String_Z == IntPtr.Zero)
				id_getAVRoomName_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getAVRoomName", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVRoomName_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getAVRoomnameFromRequest_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='getAVRoomnameFromRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getAVRoomnameFromRequest", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetAVRoomnameFromRequest (string p0, bool p1)
		{
			if (id_getAVRoomnameFromRequest_Ljava_lang_String_Z == IntPtr.Zero)
				id_getAVRoomnameFromRequest_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getAVRoomnameFromRequest", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVRoomnameFromRequest_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatAccepted_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatAccepted' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatAccepted", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatAccepted (string p0)
		{
			if (id_isAVChatAccepted_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatAccepted_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatAccepted", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatAccepted_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatBusyCall_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatBusyCall' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatBusyCall", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatBusyCall (string p0)
		{
			if (id_isAVChatBusyCall_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatBusyCall_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatBusyCall", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatBusyCall_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatCallEnded_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatCallEnded' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatCallEnded", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatCallEnded (string p0)
		{
			if (id_isAVChatCallEnded_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatCallEnded_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatCallEnded", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatCallEnded_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatCallNoAnswer_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatCallNoAnswer' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatCallNoAnswer", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatCallNoAnswer (string p0)
		{
			if (id_isAVChatCallNoAnswer_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatCallNoAnswer_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatCallNoAnswer", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatCallNoAnswer_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatCallRejected_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatCallRejected' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatCallRejected", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatCallRejected (string p0)
		{
			if (id_isAVChatCallRejected_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatCallRejected_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatCallRejected", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatCallRejected_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatCancelCall_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatCancelCall' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatCancelCall", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatCancelCall (string p0)
		{
			if (id_isAVChatCancelCall_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatCancelCall_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatCancelCall", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatCancelCall_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatRequest (string p0)
		{
			if (id_isAVChatRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVChatSentSuccessful_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAVChatSentSuccessful' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVChatSentSuccessful", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVChatSentSuccessful (string p0)
		{
			if (id_isAVChatSentSuccessful_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVChatSentSuccessful_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVChatSentSuccessful", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVChatSentSuccessful_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatAccepted_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatAccepted' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatAccepted", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatAccepted (string p0)
		{
			if (id_isAudioChatAccepted_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatAccepted_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatAccepted", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatAccepted_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatBusyCall_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatBusyCall' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatBusyCall", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatBusyCall (string p0)
		{
			if (id_isAudioChatBusyCall_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatBusyCall_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatBusyCall", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatBusyCall_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatCallEnded_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatCallEnded' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatCallEnded", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatCallEnded (string p0)
		{
			if (id_isAudioChatCallEnded_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatCallEnded_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatCallEnded", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatCallEnded_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatCallNoAnswer_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatCallNoAnswer' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatCallNoAnswer", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatCallNoAnswer (string p0)
		{
			if (id_isAudioChatCallNoAnswer_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatCallNoAnswer_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatCallNoAnswer", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatCallNoAnswer_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatCallRejected_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatCallRejected' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatCallRejected", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatCallRejected (string p0)
		{
			if (id_isAudioChatCallRejected_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatCallRejected_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatCallRejected", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatCallRejected_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatCancelCall_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatCancelCall' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatCancelCall", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatCancelCall (string p0)
		{
			if (id_isAudioChatCancelCall_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatCancelCall_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatCancelCall", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatCancelCall_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatRequest (string p0)
		{
			if (id_isAudioChatRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAudioChatSentSuccessful_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isAudioChatSentSuccessful' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAudioChatSentSuccessful", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAudioChatSentSuccessful (string p0)
		{
			if (id_isAudioChatSentSuccessful_Ljava_lang_String_ == IntPtr.Zero)
				id_isAudioChatSentSuccessful_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAudioChatSentSuccessful", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAudioChatSentSuccessful_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isCrAudioCHatRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isCrAudioCHatRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isCrAudioCHatRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsCrAudioCHatRequest (string p0)
		{
			if (id_isCrAudioCHatRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isCrAudioCHatRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isCrAudioCHatRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrAudioCHatRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isCrAvchatRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='isCrAvchatRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isCrAvchatRequest", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsCrAvchatRequest (string p0)
		{
			if (id_isCrAvchatRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_isCrAvchatRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isCrAvchatRequest", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrAvchatRequest_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_setAVConferenceRoomName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='setAVConferenceRoomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setAVConferenceRoomName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string SetAVConferenceRoomName (string p0)
		{
			if (id_setAVConferenceRoomName_Ljava_lang_String_ == IntPtr.Zero)
				id_setAVConferenceRoomName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "setAVConferenceRoomName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_setAVConferenceRoomName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_startConference_Ljava_lang_String_Landroid_app_Activity_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='startConference' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.app.Activity']]"
		[Register ("startConference", "(Ljava/lang/String;Landroid/app/Activity;)V", "")]
		public static unsafe void StartConference (string p0, global::Android.App.Activity p1)
		{
			if (id_startConference_Ljava_lang_String_Landroid_app_Activity_ == IntPtr.Zero)
				id_startConference_Ljava_lang_String_Landroid_app_Activity_ = JNIEnv.GetStaticMethodID (class_ref, "startConference", "(Ljava/lang/String;Landroid/app/Activity;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_startConference_Ljava_lang_String_Landroid_app_Activity_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_startVideoCall_Ljava_lang_String_ZZLandroid_app_Activity_Ljava_lang_Class_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoChat']/method[@name='startVideoCall' and count(parameter)=6 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean'] and parameter[3][@type='boolean'] and parameter[4][@type='android.app.Activity'] and parameter[5][@type='java.lang.Class&lt;?&gt;'] and parameter[6][@type='java.lang.String']]"
		[Register ("startVideoCall", "(Ljava/lang/String;ZZLandroid/app/Activity;Ljava/lang/Class;Ljava/lang/String;)V", "")]
		public static unsafe void StartVideoCall (string p0, bool p1, bool p2, global::Android.App.Activity p3, global::Java.Lang.Class p4, string p5)
		{
			if (id_startVideoCall_Ljava_lang_String_ZZLandroid_app_Activity_Ljava_lang_Class_Ljava_lang_String_ == IntPtr.Zero)
				id_startVideoCall_Ljava_lang_String_ZZLandroid_app_Activity_Ljava_lang_Class_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "startVideoCall", "(Ljava/lang/String;ZZLandroid/app/Activity;Ljava/lang/Class;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_startVideoCall_Ljava_lang_String_ZZLandroid_app_Activity_Ljava_lang_Class_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

	}
}
