using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Fragments {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='BotsFragment']"
	[global::Android.Runtime.Register ("com/inscripts/fragments/BotsFragment", DoNotGenerateAcw=true)]
	public partial class BotsFragment : global::Android.Support.V4.App.Fragment {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/fragments/BotsFragment", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BotsFragment); }
		}

		protected BotsFragment (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='BotsFragment']/constructor[@name='BotsFragment' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe BotsFragment ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (BotsFragment)) {
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
