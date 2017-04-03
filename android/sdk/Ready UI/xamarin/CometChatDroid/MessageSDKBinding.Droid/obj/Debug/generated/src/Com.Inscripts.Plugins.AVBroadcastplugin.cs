using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/AVBroadcastplugin", DoNotGenerateAcw=true)]
	public partial class AVBroadcastplugin : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/AVBroadcastplugin", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AVBroadcastplugin); }
		}

		protected AVBroadcastplugin (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/constructor[@name='AVBroadcastplugin' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe AVBroadcastplugin ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (AVBroadcastplugin)) {
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

		static IntPtr id_isCrEnabled;
		public static unsafe bool IsCrEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isCrEnabled' and count(parameter)=0]"
			[Register ("isCrEnabled", "()Z", "GetIsCrEnabledHandler")]
			get {
				if (id_isCrEnabled == IntPtr.Zero)
					id_isCrEnabled = JNIEnv.GetStaticMethodID (class_ref, "isCrEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_isEnabled;
		public static unsafe bool IsEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isEnabled' and count(parameter)=0]"
			[Register ("isEnabled", "()Z", "GetIsEnabledHandler")]
			get {
				if (id_isEnabled == IntPtr.Zero)
					id_isEnabled = JNIEnv.GetStaticMethodID (class_ref, "isEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_getCRGroupName_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='getCRGroupName' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getCRGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetCRGroupName (string p0, bool p1)
		{
			if (id_getCRGroupName_Ljava_lang_String_Z == IntPtr.Zero)
				id_getCRGroupName_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getCRGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCRGroupName_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getGroupName_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='getGroupName' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetGroupName (string p0, bool p1)
		{
			if (id_getGroupName_Ljava_lang_String_Z == IntPtr.Zero)
				id_getGroupName_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getGroupName_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getInviteGroupName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='getInviteGroupName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getInviteGroupName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetInviteGroupName (string p0)
		{
			if (id_getInviteGroupName_Ljava_lang_String_ == IntPtr.Zero)
				id_getInviteGroupName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getInviteGroupName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInviteGroupName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVBroadcast_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isAVBroadcast' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcast", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcast (string p0)
		{
			if (id_isAVBroadcast_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcast_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcast", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcast_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVBroadcastEnd_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isAVBroadcastEnd' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcastEnd", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcastEnd (string p0)
		{
			if (id_isAVBroadcastEnd_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcastEnd_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcastEnd", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcastEnd_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVBroadcastInvite_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isAVBroadcastInvite' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcastInvite", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcastInvite (string p0)
		{
			if (id_isAVBroadcastInvite_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcastInvite_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcastInvite", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcastInvite_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isCrAVBroadcast_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AVBroadcastplugin']/method[@name='isCrAVBroadcast' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isCrAVBroadcast", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsCrAVBroadcast (string p0)
		{
			if (id_isCrAVBroadcast_Ljava_lang_String_ == IntPtr.Zero)
				id_isCrAVBroadcast_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isCrAVBroadcast", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrAVBroadcast_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
