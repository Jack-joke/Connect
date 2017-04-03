using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LogoutHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/LogoutHelper", DoNotGenerateAcw=true)]
	public partial class LogoutHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/LogoutHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LogoutHelper); }
		}

		protected LogoutHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LogoutHelper']/constructor[@name='LogoutHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe LogoutHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (LogoutHelper)) {
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

		static IntPtr id_chatLogout;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LogoutHelper']/method[@name='chatLogout' and count(parameter)=0]"
		[Register ("chatLogout", "()V", "")]
		public static unsafe void ChatLogout ()
		{
			if (id_chatLogout == IntPtr.Zero)
				id_chatLogout = JNIEnv.GetStaticMethodID (class_ref, "chatLogout", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_chatLogout);
			} finally {
			}
		}

	}
}
