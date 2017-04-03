using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ReportConversation']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/ReportConversation", DoNotGenerateAcw=true)]
	public partial class ReportConversation : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/ReportConversation", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ReportConversation); }
		}

		protected ReportConversation (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ReportConversation']/constructor[@name='ReportConversation' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ReportConversation ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ReportConversation)) {
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

		static IntPtr id_isDisabled;
		public static unsafe bool IsDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ReportConversation']/method[@name='isDisabled' and count(parameter)=0]"
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

		static IntPtr id_report_Ljava_lang_Long_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ReportConversation']/method[@name='report' and count(parameter)=2 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='java.lang.String']]"
		[Register ("report", "(Ljava/lang/Long;Ljava/lang/String;)V", "")]
		public static unsafe void Report (global::Java.Lang.Long p0, string p1)
		{
			if (id_report_Ljava_lang_Long_Ljava_lang_String_ == IntPtr.Zero)
				id_report_Ljava_lang_Long_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "report", "(Ljava/lang/Long;Ljava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_report_Ljava_lang_Long_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
