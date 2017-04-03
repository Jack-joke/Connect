using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Smilies']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/Smilies", DoNotGenerateAcw=true)]
	public partial class Smilies : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/Smilies", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Smilies); }
		}

		protected Smilies (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Smilies']/constructor[@name='Smilies' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Smilies ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Smilies)) {
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

		static IntPtr id_convertImageTagToEmoji_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Smilies']/method[@name='convertImageTagToEmoji' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("convertImageTagToEmoji", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string ConvertImageTagToEmoji (string p0)
		{
			if (id_convertImageTagToEmoji_Ljava_lang_String_ == IntPtr.Zero)
				id_convertImageTagToEmoji_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "convertImageTagToEmoji", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_convertImageTagToEmoji_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_convertImageTagToEmoji_Ljava_lang_String_Landroid_content_Context_ZLjava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='Smilies']/method[@name='convertImageTagToEmoji' and count(parameter)=4 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.content.Context'] and parameter[3][@type='boolean'] and parameter[4][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("convertImageTagToEmoji", "(Ljava/lang/String;Landroid/content/Context;ZLjava/lang/Class;)Landroid/text/SpannableString;", "")]
		public static unsafe global::Android.Text.SpannableString ConvertImageTagToEmoji (string p0, global::Android.Content.Context p1, bool p2, global::Java.Lang.Class p3)
		{
			if (id_convertImageTagToEmoji_Ljava_lang_String_Landroid_content_Context_ZLjava_lang_Class_ == IntPtr.Zero)
				id_convertImageTagToEmoji_Ljava_lang_String_Landroid_content_Context_ZLjava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "convertImageTagToEmoji", "(Ljava/lang/String;Landroid/content/Context;ZLjava/lang/Class;)Landroid/text/SpannableString;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				global::Android.Text.SpannableString __ret = global::Java.Lang.Object.GetObject<global::Android.Text.SpannableString> (JNIEnv.CallStaticObjectMethod  (class_ref, id_convertImageTagToEmoji_Ljava_lang_String_Landroid_content_Context_ZLjava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
