using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='FileSharing']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/FileSharing", DoNotGenerateAcw=true)]
	public partial class FileSharing : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/FileSharing", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FileSharing); }
		}

		protected FileSharing (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='FileSharing']/constructor[@name='FileSharing' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe FileSharing ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (FileSharing)) {
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

		static IntPtr id_sendFile_Landroid_app_Activity_Landroid_net_Uri_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='FileSharing']/method[@name='sendFile' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='android.net.Uri'] and parameter[3][@type='long'] and parameter[4][@type='boolean']]"
		[Register ("sendFile", "(Landroid/app/Activity;Landroid/net/Uri;JZ)V", "")]
		public static unsafe void SendFile (global::Android.App.Activity p0, global::Android.Net.Uri p1, long p2, bool p3)
		{
			if (id_sendFile_Landroid_app_Activity_Landroid_net_Uri_JZ == IntPtr.Zero)
				id_sendFile_Landroid_app_Activity_Landroid_net_Uri_JZ = JNIEnv.GetStaticMethodID (class_ref, "sendFile", "(Landroid/app/Activity;Landroid/net/Uri;JZ)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendFile_Landroid_app_Activity_Landroid_net_Uri_JZ, __args);
			} finally {
			}
		}

		static IntPtr id_sendFile_Landroid_app_Activity_Ljava_lang_String_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='FileSharing']/method[@name='sendFile' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='long'] and parameter[4][@type='boolean']]"
		[Register ("sendFile", "(Landroid/app/Activity;Ljava/lang/String;JZ)V", "")]
		public static unsafe void SendFile (global::Android.App.Activity p0, string p1, long p2, bool p3)
		{
			if (id_sendFile_Landroid_app_Activity_Ljava_lang_String_JZ == IntPtr.Zero)
				id_sendFile_Landroid_app_Activity_Ljava_lang_String_JZ = JNIEnv.GetStaticMethodID (class_ref, "sendFile", "(Landroid/app/Activity;Ljava/lang/String;JZ)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendFile_Landroid_app_Activity_Ljava_lang_String_JZ, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
