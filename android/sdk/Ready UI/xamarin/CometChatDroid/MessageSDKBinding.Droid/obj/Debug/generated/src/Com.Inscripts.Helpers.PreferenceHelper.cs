using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/PreferenceHelper", DoNotGenerateAcw=true)]
	public partial class PreferenceHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/PreferenceHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (PreferenceHelper); }
		}

		protected PreferenceHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/constructor[@name='PreferenceHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe PreferenceHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (PreferenceHelper)) {
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

		static IntPtr id_getContext;
		public static unsafe global::Android.Content.Context Context {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='getContext' and count(parameter)=0]"
			[Register ("getContext", "()Landroid/content/Context;", "GetGetContextHandler")]
			get {
				if (id_getContext == IntPtr.Zero)
					id_getContext = JNIEnv.GetStaticMethodID (class_ref, "getContext", "()Landroid/content/Context;");
				try {
					return global::Java.Lang.Object.GetObject<global::Android.Content.Context> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getContext), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_cleanUp;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='cleanUp' and count(parameter)=0]"
		[Register ("cleanUp", "()V", "")]
		public static unsafe void CleanUp ()
		{
			if (id_cleanUp == IntPtr.Zero)
				id_cleanUp = JNIEnv.GetStaticMethodID (class_ref, "cleanUp", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_cleanUp);
			} finally {
			}
		}

		static IntPtr id_contains_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='contains' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("contains", "(Ljava/lang/String;)Ljava/lang/Boolean;", "")]
		public static unsafe global::Java.Lang.Boolean Contains (string p0)
		{
			if (id_contains_Ljava_lang_String_ == IntPtr.Zero)
				id_contains_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "contains", "(Ljava/lang/String;)Ljava/lang/Boolean;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Java.Lang.Boolean __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (JNIEnv.CallStaticObjectMethod  (class_ref, id_contains_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_get_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='get' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("get", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string Get (string p0)
		{
			if (id_get_Ljava_lang_String_ == IntPtr.Zero)
				id_get_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "get", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_get_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_initialize_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='initialize' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("initialize", "(Landroid/content/Context;)V", "")]
		public static unsafe void Initialize (global::Android.Content.Context p0)
		{
			if (id_initialize_Landroid_content_Context_ == IntPtr.Zero)
				id_initialize_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "initialize", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_initialize_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static IntPtr id_removeKey_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='removeKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("removeKey", "(Ljava/lang/String;)V", "")]
		public static unsafe void RemoveKey (string p0)
		{
			if (id_removeKey_Ljava_lang_String_ == IntPtr.Zero)
				id_removeKey_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "removeKey", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_removeKey_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_save_Ljava_lang_String_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='save' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Integer']]"
		[Register ("save", "(Ljava/lang/String;Ljava/lang/Integer;)V", "")]
		public static unsafe void Save (string p0, global::Java.Lang.Integer p1)
		{
			if (id_save_Ljava_lang_String_Ljava_lang_Integer_ == IntPtr.Zero)
				id_save_Ljava_lang_String_Ljava_lang_Integer_ = JNIEnv.GetStaticMethodID (class_ref, "save", "(Ljava/lang/String;Ljava/lang/Integer;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_save_Ljava_lang_String_Ljava_lang_Integer_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_save_Ljava_lang_String_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='save' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Long']]"
		[Register ("save", "(Ljava/lang/String;Ljava/lang/Long;)V", "")]
		public static unsafe void Save (string p0, global::Java.Lang.Long p1)
		{
			if (id_save_Ljava_lang_String_Ljava_lang_Long_ == IntPtr.Zero)
				id_save_Ljava_lang_String_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "save", "(Ljava/lang/String;Ljava/lang/Long;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_save_Ljava_lang_String_Ljava_lang_Long_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_save_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='save' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("save", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public static unsafe void Save (string p0, string p1)
		{
			if (id_save_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_save_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "save", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_save_Ljava_lang_String_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_searchJsonPhp_Lcom_inscripts_interfaces_CometchatCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PreferenceHelper']/method[@name='searchJsonPhp' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.CometchatCallbacks']]"
		[Register ("searchJsonPhp", "(Lcom/inscripts/interfaces/CometchatCallbacks;)V", "")]
		public static unsafe void SearchJsonPhp (global::Com.Inscripts.Interfaces.ICometchatCallbacks p0)
		{
			if (id_searchJsonPhp_Lcom_inscripts_interfaces_CometchatCallbacks_ == IntPtr.Zero)
				id_searchJsonPhp_Lcom_inscripts_interfaces_CometchatCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "searchJsonPhp", "(Lcom/inscripts/interfaces/CometchatCallbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_searchJsonPhp_Lcom_inscripts_interfaces_CometchatCallbacks_, __args);
			} finally {
			}
		}

	}
}
