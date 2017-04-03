using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/AudioSharing", DoNotGenerateAcw=true)]
	public partial class AudioSharing : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/AudioSharing", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AudioSharing); }
		}

		protected AudioSharing (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/constructor[@name='AudioSharing' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe AudioSharing ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (AudioSharing)) {
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

		static IntPtr id_getOutputMediaFile;
		public static unsafe string OutputMediaFile {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='getOutputMediaFile' and count(parameter)=0]"
			[Register ("getOutputMediaFile", "()Ljava/lang/String;", "GetGetOutputMediaFileHandler")]
			get {
				if (id_getOutputMediaFile == IntPtr.Zero)
					id_getOutputMediaFile = JNIEnv.GetStaticMethodID (class_ref, "getOutputMediaFile", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getOutputMediaFile), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_downloadAndStoreAudio_Ljava_lang_String_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='downloadAndStoreAudio' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean']]"
		[Register ("downloadAndStoreAudio", "(Ljava/lang/String;Ljava/lang/String;Z)V", "")]
		public static unsafe void DownloadAndStoreAudio (string p0, string p1, bool p2)
		{
			if (id_downloadAndStoreAudio_Ljava_lang_String_Ljava_lang_String_Z == IntPtr.Zero)
				id_downloadAndStoreAudio_Ljava_lang_String_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "downloadAndStoreAudio", "(Ljava/lang/String;Ljava/lang/String;Z)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_downloadAndStoreAudio_Ljava_lang_String_Ljava_lang_String_Z, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_getRealPathFromURI_Landroid_content_Context_Landroid_net_Uri_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='getRealPathFromURI' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.net.Uri']]"
		[Register ("getRealPathFromURI", "(Landroid/content/Context;Landroid/net/Uri;)Ljava/lang/String;", "")]
		public static unsafe string GetRealPathFromURI (global::Android.Content.Context p0, global::Android.Net.Uri p1)
		{
			if (id_getRealPathFromURI_Landroid_content_Context_Landroid_net_Uri_ == IntPtr.Zero)
				id_getRealPathFromURI_Landroid_content_Context_Landroid_net_Uri_ = JNIEnv.GetStaticMethodID (class_ref, "getRealPathFromURI", "(Landroid/content/Context;Landroid/net/Uri;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRealPathFromURI_Landroid_content_Context_Landroid_net_Uri_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_isIncomingAudio_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='isIncomingAudio' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isIncomingAudio", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsIncomingAudio (string p0)
		{
			if (id_isIncomingAudio_Ljava_lang_String_ == IntPtr.Zero)
				id_isIncomingAudio_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isIncomingAudio", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isIncomingAudio_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_sendAudio_Landroid_app_Activity_Landroid_net_Uri_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='sendAudio' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='android.net.Uri'] and parameter[3][@type='long'] and parameter[4][@type='boolean']]"
		[Register ("sendAudio", "(Landroid/app/Activity;Landroid/net/Uri;JZ)V", "")]
		public static unsafe void SendAudio (global::Android.App.Activity p0, global::Android.Net.Uri p1, long p2, bool p3)
		{
			if (id_sendAudio_Landroid_app_Activity_Landroid_net_Uri_JZ == IntPtr.Zero)
				id_sendAudio_Landroid_app_Activity_Landroid_net_Uri_JZ = JNIEnv.GetStaticMethodID (class_ref, "sendAudio", "(Landroid/app/Activity;Landroid/net/Uri;JZ)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendAudio_Landroid_app_Activity_Landroid_net_Uri_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_sendAudio_Landroid_app_Activity_Ljava_lang_String_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='AudioSharing']/method[@name='sendAudio' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='long'] and parameter[4][@type='boolean']]"
		[Register ("sendAudio", "(Landroid/app/Activity;Ljava/lang/String;JZ)V", "")]
		public static unsafe void SendAudio (global::Android.App.Activity p0, string p1, long p2, bool p3)
		{
			if (id_sendAudio_Landroid_app_Activity_Ljava_lang_String_JZ == IntPtr.Zero)
				id_sendAudio_Landroid_app_Activity_Ljava_lang_String_JZ = JNIEnv.GetStaticMethodID (class_ref, "sendAudio", "(Landroid/app/Activity;Ljava/lang/String;JZ)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendAudio_Landroid_app_Activity_Ljava_lang_String_JZ, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
