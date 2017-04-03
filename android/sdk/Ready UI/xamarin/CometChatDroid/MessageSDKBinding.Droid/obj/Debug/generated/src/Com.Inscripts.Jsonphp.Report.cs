using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Report", DoNotGenerateAcw=true)]
	public partial class Report : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Report", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Report); }
		}

		protected Report (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/constructor[@name='Report' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Report ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Report)) {
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

		static Delegate cb_getHash;
#pragma warning disable 0169
		static Delegate GetGetHashHandler ()
		{
			if (cb_getHash == null)
				cb_getHash = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHash);
			return cb_getHash;
		}

		static IntPtr n_GetHash (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Hash);
		}
#pragma warning restore 0169

		static IntPtr id_getHash;
		public virtual unsafe string Hash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='getHash' and count(parameter)=0]"
			[Register ("getHash", "()Ljava/lang/String;", "GetGetHashHandler")]
			get {
				if (id_getHash == IntPtr.Zero)
					id_getHash = JNIEnv.GetMethodID (class_ref, "getHash", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHash), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHash", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
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
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get0 ());
		}
#pragma warning restore 0169

		static IntPtr id_get0;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get0' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get1 ());
		}
#pragma warning restore 0169

		static IntPtr id_get1;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get1' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get2 ());
		}
#pragma warning restore 0169

		static IntPtr id_get2;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get2' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get3 ());
		}
#pragma warning restore 0169

		static IntPtr id_get3;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get3' and count(parameter)=0]"
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

		static Delegate cb_get4;
#pragma warning disable 0169
		static Delegate GetGet4Handler ()
		{
			if (cb_get4 == null)
				cb_get4 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get4);
			return cb_get4;
		}

		static IntPtr n_Get4 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get4 ());
		}
#pragma warning restore 0169

		static IntPtr id_get4;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get4' and count(parameter)=0]"
		[Register ("get4", "()Ljava/lang/String;", "GetGet4Handler")]
		public virtual unsafe string Get4 ()
		{
			if (id_get4 == IntPtr.Zero)
				id_get4 = JNIEnv.GetMethodID (class_ref, "get4", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get4), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get4", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get5;
#pragma warning disable 0169
		static Delegate GetGet5Handler ()
		{
			if (cb_get5 == null)
				cb_get5 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get5);
			return cb_get5;
		}

		static IntPtr n_Get5 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get5 ());
		}
#pragma warning restore 0169

		static IntPtr id_get5;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get5' and count(parameter)=0]"
		[Register ("get5", "()Ljava/lang/String;", "GetGet5Handler")]
		public virtual unsafe string Get5 ()
		{
			if (id_get5 == IntPtr.Zero)
				id_get5 = JNIEnv.GetMethodID (class_ref, "get5", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get5), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get5", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get6;
#pragma warning disable 0169
		static Delegate GetGet6Handler ()
		{
			if (cb_get6 == null)
				cb_get6 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get6);
			return cb_get6;
		}

		static IntPtr n_Get6 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Report __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get6 ());
		}
#pragma warning restore 0169

		static IntPtr id_get6;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Report']/method[@name='get6' and count(parameter)=0]"
		[Register ("get6", "()Ljava/lang/String;", "GetGet6Handler")]
		public virtual unsafe string Get6 ()
		{
			if (id_get6 == IntPtr.Zero)
				id_get6 = JNIEnv.GetMethodID (class_ref, "get6", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get6), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get6", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
