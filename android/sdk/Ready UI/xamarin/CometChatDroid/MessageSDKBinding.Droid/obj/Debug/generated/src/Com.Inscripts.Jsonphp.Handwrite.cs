using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Handwrite", DoNotGenerateAcw=true)]
	public partial class Handwrite : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Handwrite", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Handwrite); }
		}

		protected Handwrite (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/constructor[@name='Handwrite' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Handwrite ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Handwrite)) {
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

		static Delegate cb_get0;
#pragma warning disable 0169
		static Delegate GetGet0Handler ()
		{
			if (cb_get0 == null)
				cb_get0 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get0);
			return cb_get0;
		}

		static IntPtr n_Get0 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get0 ());
		}
#pragma warning restore 0169

		static IntPtr id_get0;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='get0' and count(parameter)=0]"
		[Register ("get0", "()Ljava/lang/String;", "GetGet0Handler")]
		public virtual unsafe string Get0 ()
		{
			if (id_get0 == IntPtr.Zero)
				id_get0 = JNIEnv.GetMethodID (class_ref, "get0", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get0), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get0", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get1;
#pragma warning disable 0169
		static Delegate GetGet1Handler ()
		{
			if (cb_get1 == null)
				cb_get1 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get1);
			return cb_get1;
		}

		static IntPtr n_Get1 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get1 ());
		}
#pragma warning restore 0169

		static IntPtr id_get1;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='get1' and count(parameter)=0]"
		[Register ("get1", "()Ljava/lang/String;", "GetGet1Handler")]
		public virtual unsafe string Get1 ()
		{
			if (id_get1 == IntPtr.Zero)
				id_get1 = JNIEnv.GetMethodID (class_ref, "get1", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get1), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get1", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get2;
#pragma warning disable 0169
		static Delegate GetGet2Handler ()
		{
			if (cb_get2 == null)
				cb_get2 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get2);
			return cb_get2;
		}

		static IntPtr n_Get2 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get2 ());
		}
#pragma warning restore 0169

		static IntPtr id_get2;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='get2' and count(parameter)=0]"
		[Register ("get2", "()Ljava/lang/String;", "GetGet2Handler")]
		public virtual unsafe string Get2 ()
		{
			if (id_get2 == IntPtr.Zero)
				id_get2 = JNIEnv.GetMethodID (class_ref, "get2", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get2), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get2", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get3;
#pragma warning disable 0169
		static Delegate GetGet3Handler ()
		{
			if (cb_get3 == null)
				cb_get3 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get3);
			return cb_get3;
		}

		static IntPtr n_Get3 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get3 ());
		}
#pragma warning restore 0169

		static IntPtr id_get3;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='get3' and count(parameter)=0]"
		[Register ("get3", "()Ljava/lang/String;", "GetGet3Handler")]
		public virtual unsafe string Get3 ()
		{
			if (id_get3 == IntPtr.Zero)
				id_get3 = JNIEnv.GetMethodID (class_ref, "get3", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get3), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get3", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_set0_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet0_Ljava_lang_String_Handler ()
		{
			if (cb_set0_Ljava_lang_String_ == null)
				cb_set0_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set0_Ljava_lang_String_);
			return cb_set0_Ljava_lang_String_;
		}

		static void n_Set0_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set0 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set0_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='set0' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set0", "(Ljava/lang/String;)V", "GetSet0_Ljava_lang_String_Handler")]
		public virtual unsafe void Set0 (string p0)
		{
			if (id_set0_Ljava_lang_String_ == IntPtr.Zero)
				id_set0_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set0", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set0_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set0", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set1_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet1_Ljava_lang_String_Handler ()
		{
			if (cb_set1_Ljava_lang_String_ == null)
				cb_set1_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set1_Ljava_lang_String_);
			return cb_set1_Ljava_lang_String_;
		}

		static void n_Set1_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set1 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set1_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='set1' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set1", "(Ljava/lang/String;)V", "GetSet1_Ljava_lang_String_Handler")]
		public virtual unsafe void Set1 (string p0)
		{
			if (id_set1_Ljava_lang_String_ == IntPtr.Zero)
				id_set1_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set1", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set1_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set1", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set2_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet2_Ljava_lang_String_Handler ()
		{
			if (cb_set2_Ljava_lang_String_ == null)
				cb_set2_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set2_Ljava_lang_String_);
			return cb_set2_Ljava_lang_String_;
		}

		static void n_Set2_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set2 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set2_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='set2' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set2", "(Ljava/lang/String;)V", "GetSet2_Ljava_lang_String_Handler")]
		public virtual unsafe void Set2 (string p0)
		{
			if (id_set2_Ljava_lang_String_ == IntPtr.Zero)
				id_set2_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set2", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set2_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set2", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set3_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet3_Ljava_lang_String_Handler ()
		{
			if (cb_set3_Ljava_lang_String_ == null)
				cb_set3_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set3_Ljava_lang_String_);
			return cb_set3_Ljava_lang_String_;
		}

		static void n_Set3_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Handwrite __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set3 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set3_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Handwrite']/method[@name='set3' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set3", "(Ljava/lang/String;)V", "GetSet3_Ljava_lang_String_Handler")]
		public virtual unsafe void Set3 (string p0)
		{
			if (id_set3_Ljava_lang_String_ == IntPtr.Zero)
				id_set3_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set3", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set3_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set3", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
