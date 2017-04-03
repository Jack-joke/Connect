using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='EncryptionHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/EncryptionHelper", DoNotGenerateAcw=true)]
	public partial class EncryptionHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/EncryptionHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (EncryptionHelper); }
		}

		protected EncryptionHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='EncryptionHelper']/constructor[@name='EncryptionHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe EncryptionHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (EncryptionHelper)) {
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

		static IntPtr id_encodeIntoMD5_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='EncryptionHelper']/method[@name='encodeIntoMD5' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("encodeIntoMD5", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string EncodeIntoMD5 (string p0)
		{
			if (id_encodeIntoMD5_Ljava_lang_String_ == IntPtr.Zero)
				id_encodeIntoMD5_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "encodeIntoMD5", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_encodeIntoMD5_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_encodeIntoShaOne_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='EncryptionHelper']/method[@name='encodeIntoShaOne' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("encodeIntoShaOne", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string EncodeIntoShaOne (string p0)
		{
			if (id_encodeIntoShaOne_Ljava_lang_String_ == IntPtr.Zero)
				id_encodeIntoShaOne_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "encodeIntoShaOne", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_encodeIntoShaOne_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
