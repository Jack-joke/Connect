using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='BlankActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/BlankActivity", DoNotGenerateAcw=true)]
	public partial class BlankActivity : global::Android.Support.V7.App.ActionBarActivity {


		static IntPtr blankActivity_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='BlankActivity']/field[@name='blankActivity']"
		[Register ("blankActivity")]
		public static global::Com.Inscripts.Activities.BlankActivity BlankAct {
			get {
				if (blankActivity_jfieldId == IntPtr.Zero)
					blankActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "blankActivity", "Lcom/inscripts/activities/BlankActivity;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, blankActivity_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.BlankActivity> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (blankActivity_jfieldId == IntPtr.Zero)
					blankActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "blankActivity", "Lcom/inscripts/activities/BlankActivity;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, blankActivity_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/BlankActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BlankActivity); }
		}

		protected BlankActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='BlankActivity']/constructor[@name='BlankActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe BlankActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (BlankActivity)) {
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

		static IntPtr id_stopWheel;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='BlankActivity']/method[@name='stopWheel' and count(parameter)=0]"
		[Register ("stopWheel", "()V", "")]
		public static unsafe void StopWheel ()
		{
			if (id_stopWheel == IntPtr.Zero)
				id_stopWheel = JNIEnv.GetStaticMethodID (class_ref, "stopWheel", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_stopWheel);
			} finally {
			}
		}

	}
}
