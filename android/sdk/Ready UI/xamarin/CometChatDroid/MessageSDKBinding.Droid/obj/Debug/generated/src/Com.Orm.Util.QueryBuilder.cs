using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='QueryBuilder']"
	[global::Android.Runtime.Register ("com/orm/util/QueryBuilder", DoNotGenerateAcw=true)]
	public partial class QueryBuilder : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/QueryBuilder", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (QueryBuilder); }
		}

		protected QueryBuilder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='QueryBuilder']/constructor[@name='QueryBuilder' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe QueryBuilder ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (QueryBuilder)) {
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

		static IntPtr id_getColumnType_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='QueryBuilder']/method[@name='getColumnType' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("getColumnType", "(Ljava/lang/Class;)Ljava/lang/String;", "")]
		public static unsafe string GetColumnType (global::Java.Lang.Class p0)
		{
			if (id_getColumnType_Ljava_lang_Class_ == IntPtr.Zero)
				id_getColumnType_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "getColumnType", "(Ljava/lang/Class;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getColumnType_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
