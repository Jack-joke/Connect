using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='UrlInitializerActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/UrlInitializerActivity", DoNotGenerateAcw=true)]
	public partial class UrlInitializerActivity : global::Com.Inscripts.Utils.SuperActivity {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/UrlInitializerActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (UrlInitializerActivity); }
		}

		protected UrlInitializerActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='UrlInitializerActivity']/constructor[@name='UrlInitializerActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe UrlInitializerActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (UrlInitializerActivity)) {
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
