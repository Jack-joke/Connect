using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='SugarConfig']"
	[global::Android.Runtime.Register ("com/orm/util/SugarConfig", DoNotGenerateAcw=true)]
	public partial class SugarConfig : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/SugarConfig", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarConfig); }
		}

		protected SugarConfig (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='SugarConfig']/constructor[@name='SugarConfig' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SugarConfig ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SugarConfig)) {
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

		static IntPtr id_clearCache;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='SugarConfig']/method[@name='clearCache' and count(parameter)=0]"
		[Register ("clearCache", "()V", "")]
		public static unsafe void ClearCache ()
		{
			if (id_clearCache == IntPtr.Zero)
				id_clearCache = JNIEnv.GetStaticMethodID (class_ref, "clearCache", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_clearCache);
			} finally {
			}
		}

		static IntPtr id_getFields_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='SugarConfig']/method[@name='getFields' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("getFields", "(Ljava/lang/Class;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> GetFields (global::Java.Lang.Class p0)
		{
			if (id_getFields_Ljava_lang_Class_ == IntPtr.Zero)
				id_getFields_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "getFields", "(Ljava/lang/Class;)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> __ret = global::Android.Runtime.JavaList<global::Java.Lang.Reflect.Field>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getFields_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_setFields_Ljava_lang_Class_Ljava_util_List_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='SugarConfig']/method[@name='setFields' and count(parameter)=2 and parameter[1][@type='java.lang.Class&lt;?&gt;'] and parameter[2][@type='java.util.List&lt;java.lang.reflect.Field&gt;']]"
		[Register ("setFields", "(Ljava/lang/Class;Ljava/util/List;)V", "")]
		public static unsafe void SetFields (global::Java.Lang.Class p0, global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> p1)
		{
			if (id_setFields_Ljava_lang_Class_Ljava_util_List_ == IntPtr.Zero)
				id_setFields_Ljava_lang_Class_Ljava_util_List_ = JNIEnv.GetStaticMethodID (class_ref, "setFields", "(Ljava/lang/Class;Ljava/util/List;)V");
			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Java.Lang.Reflect.Field>.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setFields_Ljava_lang_Class_Ljava_util_List_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
