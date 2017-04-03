using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='AggregateException']"
	[global::Android.Runtime.Register ("bolts/AggregateException", DoNotGenerateAcw=true)]
	public partial class AggregateException : global::Java.Lang.Exception {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("bolts/AggregateException", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AggregateException); }
		}

		protected AggregateException (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Ljava_util_List_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/constructor[@name='AggregateException' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;? extends java.lang.Throwable&gt;']]"
		[Register (".ctor", "(Ljava/util/List;)V", "")]
		public unsafe AggregateException (global::System.Collections.Generic.IList<global::Java.Lang.Throwable> p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p0 = global::Android.Runtime.JavaList<global::Java.Lang.Throwable>.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				if (GetType () != typeof (AggregateException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/util/List;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Ljava/util/List;)V", __args);
					return;
				}

				if (id_ctor_Ljava_util_List_ == IntPtr.Zero)
					id_ctor_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/util/List;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_util_List_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Ljava_util_List_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_ctor_Ljava_lang_String_Ljava_util_List_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/constructor[@name='AggregateException' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.util.List&lt;? extends java.lang.Throwable&gt;']]"
		[Register (".ctor", "(Ljava/lang/String;Ljava/util/List;)V", "")]
		public unsafe AggregateException (string p0, global::System.Collections.Generic.IList<global::Java.Lang.Throwable> p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Java.Lang.Throwable>.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (AggregateException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/String;Ljava/util/List;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Ljava/lang/String;Ljava/util/List;)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_String_Ljava_util_List_ == IntPtr.Zero)
					id_ctor_Ljava_lang_String_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/String;Ljava/util/List;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_String_Ljava_util_List_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Ljava_lang_String_Ljava_util_List_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_ctor_Ljava_lang_String_arrayLjava_lang_Throwable_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/constructor[@name='AggregateException' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Throwable[]']]"
		[Register (".ctor", "(Ljava/lang/String;[Ljava/lang/Throwable;)V", "")]
		public unsafe AggregateException (string p0, global::Java.Lang.Throwable[] p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Throwable) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (AggregateException)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/String;[Ljava/lang/Throwable;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, "(Ljava/lang/String;[Ljava/lang/Throwable;)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_String_arrayLjava_lang_Throwable_ == IntPtr.Zero)
					id_ctor_Ljava_lang_String_arrayLjava_lang_Throwable_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/String;[Ljava/lang/Throwable;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_String_arrayLjava_lang_Throwable_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Throwable) this).Handle, class_ref, id_ctor_Ljava_lang_String_arrayLjava_lang_Throwable_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_getErrors;
#pragma warning disable 0169
		static Delegate GetGetErrorsHandler ()
		{
			if (cb_getErrors == null)
				cb_getErrors = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetErrors);
			return cb_getErrors;
		}

		static IntPtr n_GetErrors (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.AggregateException __this = global::Java.Lang.Object.GetObject<global::Bolts.AggregateException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::Java.Lang.Exception>.ToLocalJniHandle (__this.Errors);
		}
#pragma warning restore 0169

		static IntPtr id_getErrors;
		[Obsolete (@"deprecated")]
		public virtual unsafe global::System.Collections.Generic.IList<global::Java.Lang.Exception> Errors {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/method[@name='getErrors' and count(parameter)=0]"
			[Register ("getErrors", "()Ljava/util/List;", "GetGetErrorsHandler")]
			get {
				if (id_getErrors == IntPtr.Zero)
					id_getErrors = JNIEnv.GetMethodID (class_ref, "getErrors", "()Ljava/util/List;");
				try {

					if (GetType () == ThresholdType)
						return global::Android.Runtime.JavaList<global::Java.Lang.Exception>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getErrors), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaList<global::Java.Lang.Exception>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getErrors", "()Ljava/util/List;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInnerThrowables;
#pragma warning disable 0169
		static Delegate GetGetInnerThrowablesHandler ()
		{
			if (cb_getInnerThrowables == null)
				cb_getInnerThrowables = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInnerThrowables);
			return cb_getInnerThrowables;
		}

		static IntPtr n_GetInnerThrowables (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.AggregateException __this = global::Java.Lang.Object.GetObject<global::Bolts.AggregateException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::Java.Lang.Throwable>.ToLocalJniHandle (__this.InnerThrowables);
		}
#pragma warning restore 0169

		static IntPtr id_getInnerThrowables;
		public virtual unsafe global::System.Collections.Generic.IList<global::Java.Lang.Throwable> InnerThrowables {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/method[@name='getInnerThrowables' and count(parameter)=0]"
			[Register ("getInnerThrowables", "()Ljava/util/List;", "GetGetInnerThrowablesHandler")]
			get {
				if (id_getInnerThrowables == IntPtr.Zero)
					id_getInnerThrowables = JNIEnv.GetMethodID (class_ref, "getInnerThrowables", "()Ljava/util/List;");
				try {

					if (GetType () == ThresholdType)
						return global::Android.Runtime.JavaList<global::Java.Lang.Throwable>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getInnerThrowables), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaList<global::Java.Lang.Throwable>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInnerThrowables", "()Ljava/util/List;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCauses;
#pragma warning disable 0169
		static Delegate GetGetCausesHandler ()
		{
			if (cb_getCauses == null)
				cb_getCauses = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCauses);
			return cb_getCauses;
		}

		static IntPtr n_GetCauses (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.AggregateException __this = global::Java.Lang.Object.GetObject<global::Bolts.AggregateException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray (__this.GetCauses ());
		}
#pragma warning restore 0169

		static IntPtr id_getCauses;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='AggregateException']/method[@name='getCauses' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("getCauses", "()[Ljava/lang/Throwable;", "GetGetCausesHandler")]
		public virtual unsafe global::Java.Lang.Throwable[] GetCauses ()
		{
			if (id_getCauses == IntPtr.Zero)
				id_getCauses = JNIEnv.GetMethodID (class_ref, "getCauses", "()[Ljava/lang/Throwable;");
			try {

				if (GetType () == ThresholdType)
					return (global::Java.Lang.Throwable[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getCauses), JniHandleOwnership.TransferLocalRef, typeof (global::Java.Lang.Throwable));
				else
					return (global::Java.Lang.Throwable[]) JNIEnv.GetArray (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCauses", "()[Ljava/lang/Throwable;")), JniHandleOwnership.TransferLocalRef, typeof (global::Java.Lang.Throwable));
			} finally {
			}
		}

	}
}
