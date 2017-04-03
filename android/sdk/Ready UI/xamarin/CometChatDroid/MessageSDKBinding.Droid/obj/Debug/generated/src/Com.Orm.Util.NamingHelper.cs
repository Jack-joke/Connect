using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']"
	[global::Android.Runtime.Register ("com/orm/util/NamingHelper", DoNotGenerateAcw=true)]
	public partial class NamingHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/NamingHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (NamingHelper); }
		}

		protected NamingHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']/constructor[@name='NamingHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe NamingHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (NamingHelper)) {
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

		static IntPtr id_customSQLNameFOrmattor_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']/method[@name='customSQLNameFOrmattor' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("customSQLNameFOrmattor", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string CustomSQLNameFOrmattor (string p0)
		{
			if (id_customSQLNameFOrmattor_Ljava_lang_String_ == IntPtr.Zero)
				id_customSQLNameFOrmattor_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "customSQLNameFOrmattor", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_customSQLNameFOrmattor_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_toSQLName_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']/method[@name='toSQLName' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("toSQLName", "(Ljava/lang/Class;)Ljava/lang/String;", "")]
		public static unsafe string ToSQLName (global::Java.Lang.Class p0)
		{
			if (id_toSQLName_Ljava_lang_Class_ == IntPtr.Zero)
				id_toSQLName_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "toSQLName", "(Ljava/lang/Class;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_toSQLName_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_toSQLName_Ljava_lang_reflect_Field_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']/method[@name='toSQLName' and count(parameter)=1 and parameter[1][@type='java.lang.reflect.Field']]"
		[Register ("toSQLName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;", "")]
		public static unsafe string ToSQLName (global::Java.Lang.Reflect.Field p0)
		{
			if (id_toSQLName_Ljava_lang_reflect_Field_ == IntPtr.Zero)
				id_toSQLName_Ljava_lang_reflect_Field_ = JNIEnv.GetStaticMethodID (class_ref, "toSQLName", "(Ljava/lang/reflect/Field;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_toSQLName_Ljava_lang_reflect_Field_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_toSQLNameDefault_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='NamingHelper']/method[@name='toSQLNameDefault' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("toSQLNameDefault", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string ToSQLNameDefault (string p0)
		{
			if (id_toSQLNameDefault_Ljava_lang_String_ == IntPtr.Zero)
				id_toSQLNameDefault_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "toSQLNameDefault", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_toSQLNameDefault_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
