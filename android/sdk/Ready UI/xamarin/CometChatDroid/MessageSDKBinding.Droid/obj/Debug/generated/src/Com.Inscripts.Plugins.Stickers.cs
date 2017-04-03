using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/Stickers", DoNotGenerateAcw=true)]
	public partial class Stickers : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/Stickers", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Stickers); }
		}

		protected Stickers (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/constructor[@name='Stickers' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Stickers ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Stickers)) {
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

		static IntPtr id_isEnabled;
		public static unsafe bool IsEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/method[@name='isEnabled' and count(parameter)=0]"
			[Register ("isEnabled", "()Z", "GetIsEnabledHandler")]
			get {
				if (id_isEnabled == IntPtr.Zero)
					id_isEnabled = JNIEnv.GetStaticMethodID (class_ref, "isEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_getCategory_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/method[@name='getCategory' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getCategory", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetCategory (string p0)
		{
			if (id_getCategory_Ljava_lang_String_ == IntPtr.Zero)
				id_getCategory_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getCategory", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCategory_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getSticker_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/method[@name='getSticker' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getSticker", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetSticker (string p0)
		{
			if (id_getSticker_Ljava_lang_String_ == IntPtr.Zero)
				id_getSticker_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getSticker", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSticker_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_handleSticker_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/method[@name='handleSticker' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("handleSticker", "(Ljava/lang/String;)Landroid/text/SpannableString;", "")]
		public static unsafe global::Android.Text.SpannableString HandleSticker (string p0)
		{
			if (id_handleSticker_Ljava_lang_String_ == IntPtr.Zero)
				id_handleSticker_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "handleSticker", "(Ljava/lang/String;)Landroid/text/SpannableString;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Android.Text.SpannableString __ret = global::Java.Lang.Object.GetObject<global::Android.Text.SpannableString> (JNIEnv.CallStaticObjectMethod  (class_ref, id_handleSticker_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isSticker_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Stickers']/method[@name='isSticker' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isSticker", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsSticker (string p0)
		{
			if (id_isSticker_Ljava_lang_String_ == IntPtr.Zero)
				id_isSticker_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isSticker", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isSticker_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
