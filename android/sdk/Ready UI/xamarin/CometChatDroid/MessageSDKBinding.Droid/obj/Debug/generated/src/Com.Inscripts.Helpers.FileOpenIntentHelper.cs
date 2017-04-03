using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='FileOpenIntentHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/FileOpenIntentHelper", DoNotGenerateAcw=true)]
	public partial class FileOpenIntentHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/FileOpenIntentHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FileOpenIntentHelper); }
		}

		protected FileOpenIntentHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='FileOpenIntentHelper']/constructor[@name='FileOpenIntentHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe FileOpenIntentHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (FileOpenIntentHelper)) {
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

		static IntPtr id_openFile_Landroid_content_Context_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='FileOpenIntentHelper']/method[@name='openFile' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String']]"
		[Register ("openFile", "(Landroid/content/Context;Ljava/lang/String;)V", "")]
		public static unsafe void OpenFile (global::Android.Content.Context p0, string p1)
		{
			if (id_openFile_Landroid_content_Context_Ljava_lang_String_ == IntPtr.Zero)
				id_openFile_Landroid_content_Context_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "openFile", "(Landroid/content/Context;Ljava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_openFile_Landroid_content_Context_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
