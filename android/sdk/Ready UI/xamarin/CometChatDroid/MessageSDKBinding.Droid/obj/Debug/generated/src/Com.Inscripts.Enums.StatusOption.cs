using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Enums {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']"
	[global::Android.Runtime.Register ("com/inscripts/enums/StatusOption", DoNotGenerateAcw=true)]
	public sealed partial class StatusOption : global::Java.Lang.Enum {


		static IntPtr AVAILABLE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/field[@name='AVAILABLE']"
		[Register ("AVAILABLE")]
		public static global::Com.Inscripts.Enums.StatusOption Available {
			get {
				if (AVAILABLE_jfieldId == IntPtr.Zero)
					AVAILABLE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "AVAILABLE", "Lcom/inscripts/enums/StatusOption;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, AVAILABLE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr BUSY_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/field[@name='BUSY']"
		[Register ("BUSY")]
		public static global::Com.Inscripts.Enums.StatusOption Busy {
			get {
				if (BUSY_jfieldId == IntPtr.Zero)
					BUSY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "BUSY", "Lcom/inscripts/enums/StatusOption;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, BUSY_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr INVISIBLE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/field[@name='INVISIBLE']"
		[Register ("INVISIBLE")]
		public static global::Com.Inscripts.Enums.StatusOption Invisible {
			get {
				if (INVISIBLE_jfieldId == IntPtr.Zero)
					INVISIBLE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "INVISIBLE", "Lcom/inscripts/enums/StatusOption;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, INVISIBLE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr OFFLINE_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/field[@name='OFFLINE']"
		[Register ("OFFLINE")]
		public static global::Com.Inscripts.Enums.StatusOption Offline {
			get {
				if (OFFLINE_jfieldId == IntPtr.Zero)
					OFFLINE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "OFFLINE", "Lcom/inscripts/enums/StatusOption;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, OFFLINE_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/enums/StatusOption", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StatusOption); }
		}

		internal StatusOption (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_valueOf_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("valueOf", "(Ljava/lang/String;)Lcom/inscripts/enums/StatusOption;", "")]
		public static unsafe global::Com.Inscripts.Enums.StatusOption ValueOf (string p0)
		{
			if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
				id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/inscripts/enums/StatusOption;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Enums.StatusOption __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_values;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.enums']/class[@name='StatusOption']/method[@name='values' and count(parameter)=0]"
		[Register ("values", "()[Lcom/inscripts/enums/StatusOption;", "")]
		public static unsafe global::Com.Inscripts.Enums.StatusOption[] Values ()
		{
			if (id_values == IntPtr.Zero)
				id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/inscripts/enums/StatusOption;");
			try {
				return (global::Com.Inscripts.Enums.StatusOption[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Inscripts.Enums.StatusOption));
			} finally {
			}
		}

	}
}
