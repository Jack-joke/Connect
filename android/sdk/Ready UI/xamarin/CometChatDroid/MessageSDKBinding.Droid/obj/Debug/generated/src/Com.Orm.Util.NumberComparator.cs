using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='NumberComparator']"
	[global::Android.Runtime.Register ("com/orm/util/NumberComparator", DoNotGenerateAcw=true)]
	public partial class NumberComparator : global::Java.Lang.Object, global::Java.Util.IComparator {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/NumberComparator", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (NumberComparator); }
		}

		protected NumberComparator (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='NumberComparator']/constructor[@name='NumberComparator' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe NumberComparator ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (NumberComparator)) {
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

		static Delegate cb_compare_Ljava_lang_Object_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetCompare_Ljava_lang_Object_Ljava_lang_Object_Handler ()
		{
			if (cb_compare_Ljava_lang_Object_Ljava_lang_Object_ == null)
				cb_compare_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, int>) n_Compare_Ljava_lang_Object_Ljava_lang_Object_);
			return cb_compare_Ljava_lang_Object_Ljava_lang_Object_;
		}

		static int n_Compare_Ljava_lang_Object_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Orm.Util.NumberComparator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Util.NumberComparator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			int __ret = __this.Compare (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_compare_Ljava_lang_Object_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='NumberComparator']/method[@name='compare' and count(parameter)=2 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.lang.Object']]"
		[Register ("compare", "(Ljava/lang/Object;Ljava/lang/Object;)I", "GetCompare_Ljava_lang_Object_Ljava_lang_Object_Handler")]
		public virtual unsafe int Compare (global::Java.Lang.Object p0, global::Java.Lang.Object p1)
		{
			if (id_compare_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
				id_compare_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "compare", "(Ljava/lang/Object;Ljava/lang/Object;)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				int __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_compare_Ljava_lang_Object_Ljava_lang_Object_, __args);
				else
					__ret = JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "compare", "(Ljava/lang/Object;Ljava/lang/Object;)I"), __args);
				return __ret;
			} finally {
			}
		}

	}
}
