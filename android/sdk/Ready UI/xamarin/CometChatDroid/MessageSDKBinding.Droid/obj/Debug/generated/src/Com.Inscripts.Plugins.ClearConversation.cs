using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ClearConversation']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/ClearConversation", DoNotGenerateAcw=true)]
	public partial class ClearConversation : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/ClearConversation", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ClearConversation); }
		}

		protected ClearConversation (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ClearConversation']/constructor[@name='ClearConversation' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ClearConversation ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ClearConversation)) {
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

		static IntPtr id_isCrDisabled;
		public static unsafe bool IsCrDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ClearConversation']/method[@name='isCrDisabled' and count(parameter)=0]"
			[Register ("isCrDisabled", "()Z", "GetIsCrDisabledHandler")]
			get {
				if (id_isCrDisabled == IntPtr.Zero)
					id_isCrDisabled = JNIEnv.GetStaticMethodID (class_ref, "isCrDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isDisabled;
		public static unsafe bool IsDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ClearConversation']/method[@name='isDisabled' and count(parameter)=0]"
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

	}
}
