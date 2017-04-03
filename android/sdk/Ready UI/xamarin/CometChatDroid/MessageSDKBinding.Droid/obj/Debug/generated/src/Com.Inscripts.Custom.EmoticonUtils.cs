using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']"
	[global::Android.Runtime.Register ("com/inscripts/custom/EmoticonUtils", DoNotGenerateAcw=true)]
	public partial class EmoticonUtils : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/EmoticonUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (EmoticonUtils); }
		}

		protected EmoticonUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/constructor[@name='EmoticonUtils' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe EmoticonUtils ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (EmoticonUtils)) {
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

		static IntPtr id_getEmojiCount_Landroid_text_Spannable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/method[@name='getEmojiCount' and count(parameter)=1 and parameter[1][@type='android.text.Spannable']]"
		[Register ("getEmojiCount", "(Landroid/text/Spannable;)I", "")]
		public static unsafe int GetEmojiCount (global::Android.Text.ISpannable p0)
		{
			if (id_getEmojiCount_Landroid_text_Spannable_ == IntPtr.Zero)
				id_getEmojiCount_Landroid_text_Spannable_ = JNIEnv.GetStaticMethodID (class_ref, "getEmojiCount", "(Landroid/text/Spannable;)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_getEmojiCount_Landroid_text_Spannable_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getHtmlSmileyCount_Landroid_text_Spannable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/method[@name='getHtmlSmileyCount' and count(parameter)=1 and parameter[1][@type='android.text.Spannable']]"
		[Register ("getHtmlSmileyCount", "(Landroid/text/Spannable;)I", "")]
		public static unsafe int GetHtmlSmileyCount (global::Android.Text.ISpannable p0)
		{
			if (id_getHtmlSmileyCount_Landroid_text_Spannable_ == IntPtr.Zero)
				id_getHtmlSmileyCount_Landroid_text_Spannable_ = JNIEnv.GetStaticMethodID (class_ref, "getHtmlSmileyCount", "(Landroid/text/Spannable;)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_getHtmlSmileyCount_Landroid_text_Spannable_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getSmiledText_Landroid_content_Context_Ljava_lang_CharSequence_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/method[@name='getSmiledText' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.CharSequence'] and parameter[3][@type='int']]"
		[Register ("getSmiledText", "(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/text/Spannable;", "")]
		public static unsafe global::Android.Text.ISpannable GetSmiledText (global::Android.Content.Context p0, global::Java.Lang.ICharSequence p1, int p2)
		{
			if (id_getSmiledText_Landroid_content_Context_Ljava_lang_CharSequence_I == IntPtr.Zero)
				id_getSmiledText_Landroid_content_Context_Ljava_lang_CharSequence_I = JNIEnv.GetStaticMethodID (class_ref, "getSmiledText", "(Landroid/content/Context;Ljava/lang/CharSequence;I)Landroid/text/Spannable;");
			IntPtr native_p1 = CharSequence.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				global::Android.Text.ISpannable __ret = global::Java.Lang.Object.GetObject<global::Android.Text.ISpannable> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSmiledText_Landroid_content_Context_Ljava_lang_CharSequence_I, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		public static global::Android.Text.ISpannable GetSmiledText (global::Android.Content.Context p0, string p1, int p2)
		{
			global::Java.Lang.String jls_p1 = p1 == null ? null : new global::Java.Lang.String (p1);
			global::Android.Text.ISpannable __result = GetSmiledText (p0, jls_p1, p2);
			if (jls_p1 != null) jls_p1.Dispose ();
			return __result;
		}

		static IntPtr id_isOnlySmileyHtmlSmiley_Landroid_text_Spannable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/method[@name='isOnlySmileyHtmlSmiley' and count(parameter)=1 and parameter[1][@type='android.text.Spannable']]"
		[Register ("isOnlySmileyHtmlSmiley", "(Landroid/text/Spannable;)Z", "")]
		public static unsafe bool IsOnlySmileyHtmlSmiley (global::Android.Text.ISpannable p0)
		{
			if (id_isOnlySmileyHtmlSmiley_Landroid_text_Spannable_ == IntPtr.Zero)
				id_isOnlySmileyHtmlSmiley_Landroid_text_Spannable_ = JNIEnv.GetStaticMethodID (class_ref, "isOnlySmileyHtmlSmiley", "(Landroid/text/Spannable;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isOnlySmileyHtmlSmiley_Landroid_text_Spannable_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_isOnlySmileyMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonUtils']/method[@name='isOnlySmileyMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isOnlySmileyMessage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsOnlySmileyMessage (string p0)
		{
			if (id_isOnlySmileyMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_isOnlySmileyMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isOnlySmileyMessage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isOnlySmileyMessage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
