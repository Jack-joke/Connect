using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Audiochat", DoNotGenerateAcw=true)]
	public partial class Audiochat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Audiochat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Audiochat); }
		}

		protected Audiochat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/constructor[@name='Audiochat' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Audiochat ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Audiochat)) {
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Hash);
		}
#pragma warning restore 0169

		static IntPtr id_getHash;
		public virtual unsafe string Hash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='getHash' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get0 ());
		}
#pragma warning restore 0169

		static IntPtr id_get0;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get0' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get1 ());
		}
#pragma warning restore 0169

		static IntPtr id_get1;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get1' and count(parameter)=0]"
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

		static Delegate cb_get10;
#pragma warning disable 0169
		static Delegate GetGet10Handler ()
		{
			if (cb_get10 == null)
				cb_get10 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get10);
			return cb_get10;
		}

		static IntPtr n_Get10 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get10 ());
		}
#pragma warning restore 0169

		static IntPtr id_get10;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get10' and count(parameter)=0]"
		[Register ("get10", "()Ljava/lang/String;", "GetGet10Handler")]
		public virtual unsafe string Get10 ()
		{
			if (id_get10 == IntPtr.Zero)
				id_get10 = JNIEnv.GetMethodID (class_ref, "get10", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get10), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get10", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get11;
#pragma warning disable 0169
		static Delegate GetGet11Handler ()
		{
			if (cb_get11 == null)
				cb_get11 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get11);
			return cb_get11;
		}

		static IntPtr n_Get11 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get11 ());
		}
#pragma warning restore 0169

		static IntPtr id_get11;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get11' and count(parameter)=0]"
		[Register ("get11", "()Ljava/lang/String;", "GetGet11Handler")]
		public virtual unsafe string Get11 ()
		{
			if (id_get11 == IntPtr.Zero)
				id_get11 = JNIEnv.GetMethodID (class_ref, "get11", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get11), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get11", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get12;
#pragma warning disable 0169
		static Delegate GetGet12Handler ()
		{
			if (cb_get12 == null)
				cb_get12 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get12);
			return cb_get12;
		}

		static IntPtr n_Get12 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get12 ());
		}
#pragma warning restore 0169

		static IntPtr id_get12;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get12' and count(parameter)=0]"
		[Register ("get12", "()Ljava/lang/String;", "GetGet12Handler")]
		public virtual unsafe string Get12 ()
		{
			if (id_get12 == IntPtr.Zero)
				id_get12 = JNIEnv.GetMethodID (class_ref, "get12", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get12), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get12", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get13;
#pragma warning disable 0169
		static Delegate GetGet13Handler ()
		{
			if (cb_get13 == null)
				cb_get13 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get13);
			return cb_get13;
		}

		static IntPtr n_Get13 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get13 ());
		}
#pragma warning restore 0169

		static IntPtr id_get13;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get13' and count(parameter)=0]"
		[Register ("get13", "()Ljava/lang/String;", "GetGet13Handler")]
		public virtual unsafe string Get13 ()
		{
			if (id_get13 == IntPtr.Zero)
				id_get13 = JNIEnv.GetMethodID (class_ref, "get13", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get13), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get13", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get14;
#pragma warning disable 0169
		static Delegate GetGet14Handler ()
		{
			if (cb_get14 == null)
				cb_get14 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get14);
			return cb_get14;
		}

		static IntPtr n_Get14 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get14 ());
		}
#pragma warning restore 0169

		static IntPtr id_get14;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get14' and count(parameter)=0]"
		[Register ("get14", "()Ljava/lang/String;", "GetGet14Handler")]
		public virtual unsafe string Get14 ()
		{
			if (id_get14 == IntPtr.Zero)
				id_get14 = JNIEnv.GetMethodID (class_ref, "get14", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get14), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get14", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get15;
#pragma warning disable 0169
		static Delegate GetGet15Handler ()
		{
			if (cb_get15 == null)
				cb_get15 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get15);
			return cb_get15;
		}

		static IntPtr n_Get15 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get15 ());
		}
#pragma warning restore 0169

		static IntPtr id_get15;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get15' and count(parameter)=0]"
		[Register ("get15", "()Ljava/lang/String;", "GetGet15Handler")]
		public virtual unsafe string Get15 ()
		{
			if (id_get15 == IntPtr.Zero)
				id_get15 = JNIEnv.GetMethodID (class_ref, "get15", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get15), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get15", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get16;
#pragma warning disable 0169
		static Delegate GetGet16Handler ()
		{
			if (cb_get16 == null)
				cb_get16 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get16);
			return cb_get16;
		}

		static IntPtr n_Get16 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get16 ());
		}
#pragma warning restore 0169

		static IntPtr id_get16;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get16' and count(parameter)=0]"
		[Register ("get16", "()Ljava/lang/String;", "GetGet16Handler")]
		public virtual unsafe string Get16 ()
		{
			if (id_get16 == IntPtr.Zero)
				id_get16 = JNIEnv.GetMethodID (class_ref, "get16", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get16), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get16", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get17;
#pragma warning disable 0169
		static Delegate GetGet17Handler ()
		{
			if (cb_get17 == null)
				cb_get17 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get17);
			return cb_get17;
		}

		static IntPtr n_Get17 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get17 ());
		}
#pragma warning restore 0169

		static IntPtr id_get17;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get17' and count(parameter)=0]"
		[Register ("get17", "()Ljava/lang/String;", "GetGet17Handler")]
		public virtual unsafe string Get17 ()
		{
			if (id_get17 == IntPtr.Zero)
				id_get17 = JNIEnv.GetMethodID (class_ref, "get17", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get17), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get17", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get18;
#pragma warning disable 0169
		static Delegate GetGet18Handler ()
		{
			if (cb_get18 == null)
				cb_get18 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get18);
			return cb_get18;
		}

		static IntPtr n_Get18 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get18 ());
		}
#pragma warning restore 0169

		static IntPtr id_get18;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get18' and count(parameter)=0]"
		[Register ("get18", "()Ljava/lang/String;", "GetGet18Handler")]
		public virtual unsafe string Get18 ()
		{
			if (id_get18 == IntPtr.Zero)
				id_get18 = JNIEnv.GetMethodID (class_ref, "get18", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get18), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get18", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get19;
#pragma warning disable 0169
		static Delegate GetGet19Handler ()
		{
			if (cb_get19 == null)
				cb_get19 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get19);
			return cb_get19;
		}

		static IntPtr n_Get19 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get19 ());
		}
#pragma warning restore 0169

		static IntPtr id_get19;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get19' and count(parameter)=0]"
		[Register ("get19", "()Ljava/lang/String;", "GetGet19Handler")]
		public virtual unsafe string Get19 ()
		{
			if (id_get19 == IntPtr.Zero)
				id_get19 = JNIEnv.GetMethodID (class_ref, "get19", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get19), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get19", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get2 ());
		}
#pragma warning restore 0169

		static IntPtr id_get2;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get2' and count(parameter)=0]"
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

		static Delegate cb_get20;
#pragma warning disable 0169
		static Delegate GetGet20Handler ()
		{
			if (cb_get20 == null)
				cb_get20 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get20);
			return cb_get20;
		}

		static IntPtr n_Get20 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get20 ());
		}
#pragma warning restore 0169

		static IntPtr id_get20;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get20' and count(parameter)=0]"
		[Register ("get20", "()Ljava/lang/String;", "GetGet20Handler")]
		public virtual unsafe string Get20 ()
		{
			if (id_get20 == IntPtr.Zero)
				id_get20 = JNIEnv.GetMethodID (class_ref, "get20", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get20), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get20", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get21;
#pragma warning disable 0169
		static Delegate GetGet21Handler ()
		{
			if (cb_get21 == null)
				cb_get21 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get21);
			return cb_get21;
		}

		static IntPtr n_Get21 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get21 ());
		}
#pragma warning restore 0169

		static IntPtr id_get21;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get21' and count(parameter)=0]"
		[Register ("get21", "()Ljava/lang/String;", "GetGet21Handler")]
		public virtual unsafe string Get21 ()
		{
			if (id_get21 == IntPtr.Zero)
				id_get21 = JNIEnv.GetMethodID (class_ref, "get21", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get21), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get21", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get22;
#pragma warning disable 0169
		static Delegate GetGet22Handler ()
		{
			if (cb_get22 == null)
				cb_get22 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get22);
			return cb_get22;
		}

		static IntPtr n_Get22 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get22 ());
		}
#pragma warning restore 0169

		static IntPtr id_get22;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get22' and count(parameter)=0]"
		[Register ("get22", "()Ljava/lang/String;", "GetGet22Handler")]
		public virtual unsafe string Get22 ()
		{
			if (id_get22 == IntPtr.Zero)
				id_get22 = JNIEnv.GetMethodID (class_ref, "get22", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get22), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get22", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get23;
#pragma warning disable 0169
		static Delegate GetGet23Handler ()
		{
			if (cb_get23 == null)
				cb_get23 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get23);
			return cb_get23;
		}

		static IntPtr n_Get23 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get23 ());
		}
#pragma warning restore 0169

		static IntPtr id_get23;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get23' and count(parameter)=0]"
		[Register ("get23", "()Ljava/lang/String;", "GetGet23Handler")]
		public virtual unsafe string Get23 ()
		{
			if (id_get23 == IntPtr.Zero)
				id_get23 = JNIEnv.GetMethodID (class_ref, "get23", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get23), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get23", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get24;
#pragma warning disable 0169
		static Delegate GetGet24Handler ()
		{
			if (cb_get24 == null)
				cb_get24 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get24);
			return cb_get24;
		}

		static IntPtr n_Get24 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get24 ());
		}
#pragma warning restore 0169

		static IntPtr id_get24;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get24' and count(parameter)=0]"
		[Register ("get24", "()Ljava/lang/String;", "GetGet24Handler")]
		public virtual unsafe string Get24 ()
		{
			if (id_get24 == IntPtr.Zero)
				id_get24 = JNIEnv.GetMethodID (class_ref, "get24", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get24), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get24", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get25;
#pragma warning disable 0169
		static Delegate GetGet25Handler ()
		{
			if (cb_get25 == null)
				cb_get25 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get25);
			return cb_get25;
		}

		static IntPtr n_Get25 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get25 ());
		}
#pragma warning restore 0169

		static IntPtr id_get25;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get25' and count(parameter)=0]"
		[Register ("get25", "()Ljava/lang/String;", "GetGet25Handler")]
		public virtual unsafe string Get25 ()
		{
			if (id_get25 == IntPtr.Zero)
				id_get25 = JNIEnv.GetMethodID (class_ref, "get25", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get25), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get25", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get26;
#pragma warning disable 0169
		static Delegate GetGet26Handler ()
		{
			if (cb_get26 == null)
				cb_get26 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get26);
			return cb_get26;
		}

		static IntPtr n_Get26 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get26 ());
		}
#pragma warning restore 0169

		static IntPtr id_get26;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get26' and count(parameter)=0]"
		[Register ("get26", "()Ljava/lang/String;", "GetGet26Handler")]
		public virtual unsafe string Get26 ()
		{
			if (id_get26 == IntPtr.Zero)
				id_get26 = JNIEnv.GetMethodID (class_ref, "get26", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get26), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get26", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get27;
#pragma warning disable 0169
		static Delegate GetGet27Handler ()
		{
			if (cb_get27 == null)
				cb_get27 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get27);
			return cb_get27;
		}

		static IntPtr n_Get27 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get27 ());
		}
#pragma warning restore 0169

		static IntPtr id_get27;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get27' and count(parameter)=0]"
		[Register ("get27", "()Ljava/lang/String;", "GetGet27Handler")]
		public virtual unsafe string Get27 ()
		{
			if (id_get27 == IntPtr.Zero)
				id_get27 = JNIEnv.GetMethodID (class_ref, "get27", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get27), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get27", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get28;
#pragma warning disable 0169
		static Delegate GetGet28Handler ()
		{
			if (cb_get28 == null)
				cb_get28 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get28);
			return cb_get28;
		}

		static IntPtr n_Get28 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get28 ());
		}
#pragma warning restore 0169

		static IntPtr id_get28;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get28' and count(parameter)=0]"
		[Register ("get28", "()Ljava/lang/String;", "GetGet28Handler")]
		public virtual unsafe string Get28 ()
		{
			if (id_get28 == IntPtr.Zero)
				id_get28 = JNIEnv.GetMethodID (class_ref, "get28", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get28), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get28", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get29;
#pragma warning disable 0169
		static Delegate GetGet29Handler ()
		{
			if (cb_get29 == null)
				cb_get29 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get29);
			return cb_get29;
		}

		static IntPtr n_Get29 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get29 ());
		}
#pragma warning restore 0169

		static IntPtr id_get29;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get29' and count(parameter)=0]"
		[Register ("get29", "()Ljava/lang/String;", "GetGet29Handler")]
		public virtual unsafe string Get29 ()
		{
			if (id_get29 == IntPtr.Zero)
				id_get29 = JNIEnv.GetMethodID (class_ref, "get29", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get29), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get29", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get3 ());
		}
#pragma warning restore 0169

		static IntPtr id_get3;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get3' and count(parameter)=0]"
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

		static Delegate cb_get30;
#pragma warning disable 0169
		static Delegate GetGet30Handler ()
		{
			if (cb_get30 == null)
				cb_get30 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get30);
			return cb_get30;
		}

		static IntPtr n_Get30 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get30 ());
		}
#pragma warning restore 0169

		static IntPtr id_get30;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get30' and count(parameter)=0]"
		[Register ("get30", "()Ljava/lang/String;", "GetGet30Handler")]
		public virtual unsafe string Get30 ()
		{
			if (id_get30 == IntPtr.Zero)
				id_get30 = JNIEnv.GetMethodID (class_ref, "get30", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get30), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get30", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get31;
#pragma warning disable 0169
		static Delegate GetGet31Handler ()
		{
			if (cb_get31 == null)
				cb_get31 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get31);
			return cb_get31;
		}

		static IntPtr n_Get31 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get31 ());
		}
#pragma warning restore 0169

		static IntPtr id_get31;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get31' and count(parameter)=0]"
		[Register ("get31", "()Ljava/lang/String;", "GetGet31Handler")]
		public virtual unsafe string Get31 ()
		{
			if (id_get31 == IntPtr.Zero)
				id_get31 = JNIEnv.GetMethodID (class_ref, "get31", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get31), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get31", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get32;
#pragma warning disable 0169
		static Delegate GetGet32Handler ()
		{
			if (cb_get32 == null)
				cb_get32 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get32);
			return cb_get32;
		}

		static IntPtr n_Get32 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get32 ());
		}
#pragma warning restore 0169

		static IntPtr id_get32;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get32' and count(parameter)=0]"
		[Register ("get32", "()Ljava/lang/String;", "GetGet32Handler")]
		public virtual unsafe string Get32 ()
		{
			if (id_get32 == IntPtr.Zero)
				id_get32 = JNIEnv.GetMethodID (class_ref, "get32", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get32), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get32", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get33;
#pragma warning disable 0169
		static Delegate GetGet33Handler ()
		{
			if (cb_get33 == null)
				cb_get33 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get33);
			return cb_get33;
		}

		static IntPtr n_Get33 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get33 ());
		}
#pragma warning restore 0169

		static IntPtr id_get33;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get33' and count(parameter)=0]"
		[Register ("get33", "()Ljava/lang/String;", "GetGet33Handler")]
		public virtual unsafe string Get33 ()
		{
			if (id_get33 == IntPtr.Zero)
				id_get33 = JNIEnv.GetMethodID (class_ref, "get33", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get33), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get33", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get34;
#pragma warning disable 0169
		static Delegate GetGet34Handler ()
		{
			if (cb_get34 == null)
				cb_get34 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get34);
			return cb_get34;
		}

		static IntPtr n_Get34 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get34 ());
		}
#pragma warning restore 0169

		static IntPtr id_get34;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get34' and count(parameter)=0]"
		[Register ("get34", "()Ljava/lang/String;", "GetGet34Handler")]
		public virtual unsafe string Get34 ()
		{
			if (id_get34 == IntPtr.Zero)
				id_get34 = JNIEnv.GetMethodID (class_ref, "get34", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get34), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get34", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get35;
#pragma warning disable 0169
		static Delegate GetGet35Handler ()
		{
			if (cb_get35 == null)
				cb_get35 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get35);
			return cb_get35;
		}

		static IntPtr n_Get35 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get35 ());
		}
#pragma warning restore 0169

		static IntPtr id_get35;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get35' and count(parameter)=0]"
		[Register ("get35", "()Ljava/lang/String;", "GetGet35Handler")]
		public virtual unsafe string Get35 ()
		{
			if (id_get35 == IntPtr.Zero)
				id_get35 = JNIEnv.GetMethodID (class_ref, "get35", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get35), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get35", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get36;
#pragma warning disable 0169
		static Delegate GetGet36Handler ()
		{
			if (cb_get36 == null)
				cb_get36 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get36);
			return cb_get36;
		}

		static IntPtr n_Get36 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get36 ());
		}
#pragma warning restore 0169

		static IntPtr id_get36;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get36' and count(parameter)=0]"
		[Register ("get36", "()Ljava/lang/String;", "GetGet36Handler")]
		public virtual unsafe string Get36 ()
		{
			if (id_get36 == IntPtr.Zero)
				id_get36 = JNIEnv.GetMethodID (class_ref, "get36", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get36), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get36", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get37;
#pragma warning disable 0169
		static Delegate GetGet37Handler ()
		{
			if (cb_get37 == null)
				cb_get37 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get37);
			return cb_get37;
		}

		static IntPtr n_Get37 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get37 ());
		}
#pragma warning restore 0169

		static IntPtr id_get37;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get37' and count(parameter)=0]"
		[Register ("get37", "()Ljava/lang/String;", "GetGet37Handler")]
		public virtual unsafe string Get37 ()
		{
			if (id_get37 == IntPtr.Zero)
				id_get37 = JNIEnv.GetMethodID (class_ref, "get37", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get37), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get37", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get38;
#pragma warning disable 0169
		static Delegate GetGet38Handler ()
		{
			if (cb_get38 == null)
				cb_get38 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get38);
			return cb_get38;
		}

		static IntPtr n_Get38 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get38 ());
		}
#pragma warning restore 0169

		static IntPtr id_get38;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get38' and count(parameter)=0]"
		[Register ("get38", "()Ljava/lang/String;", "GetGet38Handler")]
		public virtual unsafe string Get38 ()
		{
			if (id_get38 == IntPtr.Zero)
				id_get38 = JNIEnv.GetMethodID (class_ref, "get38", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get38), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get38", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get39;
#pragma warning disable 0169
		static Delegate GetGet39Handler ()
		{
			if (cb_get39 == null)
				cb_get39 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get39);
			return cb_get39;
		}

		static IntPtr n_Get39 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get39 ());
		}
#pragma warning restore 0169

		static IntPtr id_get39;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get39' and count(parameter)=0]"
		[Register ("get39", "()Ljava/lang/String;", "GetGet39Handler")]
		public virtual unsafe string Get39 ()
		{
			if (id_get39 == IntPtr.Zero)
				id_get39 = JNIEnv.GetMethodID (class_ref, "get39", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get39), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get39", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get4 ());
		}
#pragma warning restore 0169

		static IntPtr id_get4;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get4' and count(parameter)=0]"
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

		static Delegate cb_get40;
#pragma warning disable 0169
		static Delegate GetGet40Handler ()
		{
			if (cb_get40 == null)
				cb_get40 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get40);
			return cb_get40;
		}

		static IntPtr n_Get40 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get40 ());
		}
#pragma warning restore 0169

		static IntPtr id_get40;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get40' and count(parameter)=0]"
		[Register ("get40", "()Ljava/lang/String;", "GetGet40Handler")]
		public virtual unsafe string Get40 ()
		{
			if (id_get40 == IntPtr.Zero)
				id_get40 = JNIEnv.GetMethodID (class_ref, "get40", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get40), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get40", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get41;
#pragma warning disable 0169
		static Delegate GetGet41Handler ()
		{
			if (cb_get41 == null)
				cb_get41 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get41);
			return cb_get41;
		}

		static IntPtr n_Get41 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get41 ());
		}
#pragma warning restore 0169

		static IntPtr id_get41;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get41' and count(parameter)=0]"
		[Register ("get41", "()Ljava/lang/String;", "GetGet41Handler")]
		public virtual unsafe string Get41 ()
		{
			if (id_get41 == IntPtr.Zero)
				id_get41 = JNIEnv.GetMethodID (class_ref, "get41", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get41), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get41", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get42;
#pragma warning disable 0169
		static Delegate GetGet42Handler ()
		{
			if (cb_get42 == null)
				cb_get42 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get42);
			return cb_get42;
		}

		static IntPtr n_Get42 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get42 ());
		}
#pragma warning restore 0169

		static IntPtr id_get42;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get42' and count(parameter)=0]"
		[Register ("get42", "()Ljava/lang/String;", "GetGet42Handler")]
		public virtual unsafe string Get42 ()
		{
			if (id_get42 == IntPtr.Zero)
				id_get42 = JNIEnv.GetMethodID (class_ref, "get42", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get42), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get42", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get43;
#pragma warning disable 0169
		static Delegate GetGet43Handler ()
		{
			if (cb_get43 == null)
				cb_get43 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get43);
			return cb_get43;
		}

		static IntPtr n_Get43 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get43 ());
		}
#pragma warning restore 0169

		static IntPtr id_get43;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get43' and count(parameter)=0]"
		[Register ("get43", "()Ljava/lang/String;", "GetGet43Handler")]
		public virtual unsafe string Get43 ()
		{
			if (id_get43 == IntPtr.Zero)
				id_get43 = JNIEnv.GetMethodID (class_ref, "get43", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get43), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get43", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get44;
#pragma warning disable 0169
		static Delegate GetGet44Handler ()
		{
			if (cb_get44 == null)
				cb_get44 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get44);
			return cb_get44;
		}

		static IntPtr n_Get44 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get44 ());
		}
#pragma warning restore 0169

		static IntPtr id_get44;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get44' and count(parameter)=0]"
		[Register ("get44", "()Ljava/lang/String;", "GetGet44Handler")]
		public virtual unsafe string Get44 ()
		{
			if (id_get44 == IntPtr.Zero)
				id_get44 = JNIEnv.GetMethodID (class_ref, "get44", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get44), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get44", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get45;
#pragma warning disable 0169
		static Delegate GetGet45Handler ()
		{
			if (cb_get45 == null)
				cb_get45 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get45);
			return cb_get45;
		}

		static IntPtr n_Get45 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get45 ());
		}
#pragma warning restore 0169

		static IntPtr id_get45;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get45' and count(parameter)=0]"
		[Register ("get45", "()Ljava/lang/String;", "GetGet45Handler")]
		public virtual unsafe string Get45 ()
		{
			if (id_get45 == IntPtr.Zero)
				id_get45 = JNIEnv.GetMethodID (class_ref, "get45", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get45), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get45", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get46;
#pragma warning disable 0169
		static Delegate GetGet46Handler ()
		{
			if (cb_get46 == null)
				cb_get46 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get46);
			return cb_get46;
		}

		static IntPtr n_Get46 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get46 ());
		}
#pragma warning restore 0169

		static IntPtr id_get46;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get46' and count(parameter)=0]"
		[Register ("get46", "()Ljava/lang/String;", "GetGet46Handler")]
		public virtual unsafe string Get46 ()
		{
			if (id_get46 == IntPtr.Zero)
				id_get46 = JNIEnv.GetMethodID (class_ref, "get46", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get46), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get46", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get47;
#pragma warning disable 0169
		static Delegate GetGet47Handler ()
		{
			if (cb_get47 == null)
				cb_get47 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get47);
			return cb_get47;
		}

		static IntPtr n_Get47 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get47 ());
		}
#pragma warning restore 0169

		static IntPtr id_get47;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get47' and count(parameter)=0]"
		[Register ("get47", "()Ljava/lang/String;", "GetGet47Handler")]
		public virtual unsafe string Get47 ()
		{
			if (id_get47 == IntPtr.Zero)
				id_get47 = JNIEnv.GetMethodID (class_ref, "get47", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get47), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get47", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get48;
#pragma warning disable 0169
		static Delegate GetGet48Handler ()
		{
			if (cb_get48 == null)
				cb_get48 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get48);
			return cb_get48;
		}

		static IntPtr n_Get48 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get48 ());
		}
#pragma warning restore 0169

		static IntPtr id_get48;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get48' and count(parameter)=0]"
		[Register ("get48", "()Ljava/lang/String;", "GetGet48Handler")]
		public virtual unsafe string Get48 ()
		{
			if (id_get48 == IntPtr.Zero)
				id_get48 = JNIEnv.GetMethodID (class_ref, "get48", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get48), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get48", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get49;
#pragma warning disable 0169
		static Delegate GetGet49Handler ()
		{
			if (cb_get49 == null)
				cb_get49 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get49);
			return cb_get49;
		}

		static IntPtr n_Get49 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get49 ());
		}
#pragma warning restore 0169

		static IntPtr id_get49;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get49' and count(parameter)=0]"
		[Register ("get49", "()Ljava/lang/String;", "GetGet49Handler")]
		public virtual unsafe string Get49 ()
		{
			if (id_get49 == IntPtr.Zero)
				id_get49 = JNIEnv.GetMethodID (class_ref, "get49", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get49), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get49", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get5 ());
		}
#pragma warning restore 0169

		static IntPtr id_get5;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get5' and count(parameter)=0]"
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

		static Delegate cb_get50;
#pragma warning disable 0169
		static Delegate GetGet50Handler ()
		{
			if (cb_get50 == null)
				cb_get50 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get50);
			return cb_get50;
		}

		static IntPtr n_Get50 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get50 ());
		}
#pragma warning restore 0169

		static IntPtr id_get50;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get50' and count(parameter)=0]"
		[Register ("get50", "()Ljava/lang/String;", "GetGet50Handler")]
		public virtual unsafe string Get50 ()
		{
			if (id_get50 == IntPtr.Zero)
				id_get50 = JNIEnv.GetMethodID (class_ref, "get50", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get50), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get50", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get51;
#pragma warning disable 0169
		static Delegate GetGet51Handler ()
		{
			if (cb_get51 == null)
				cb_get51 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get51);
			return cb_get51;
		}

		static IntPtr n_Get51 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get51 ());
		}
#pragma warning restore 0169

		static IntPtr id_get51;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get51' and count(parameter)=0]"
		[Register ("get51", "()Ljava/lang/String;", "GetGet51Handler")]
		public virtual unsafe string Get51 ()
		{
			if (id_get51 == IntPtr.Zero)
				id_get51 = JNIEnv.GetMethodID (class_ref, "get51", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get51), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get51", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get6 ());
		}
#pragma warning restore 0169

		static IntPtr id_get6;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get6' and count(parameter)=0]"
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

		static Delegate cb_get7;
#pragma warning disable 0169
		static Delegate GetGet7Handler ()
		{
			if (cb_get7 == null)
				cb_get7 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get7);
			return cb_get7;
		}

		static IntPtr n_Get7 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get7 ());
		}
#pragma warning restore 0169

		static IntPtr id_get7;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get7' and count(parameter)=0]"
		[Register ("get7", "()Ljava/lang/String;", "GetGet7Handler")]
		public virtual unsafe string Get7 ()
		{
			if (id_get7 == IntPtr.Zero)
				id_get7 = JNIEnv.GetMethodID (class_ref, "get7", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get7), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get7", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get8;
#pragma warning disable 0169
		static Delegate GetGet8Handler ()
		{
			if (cb_get8 == null)
				cb_get8 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get8);
			return cb_get8;
		}

		static IntPtr n_Get8 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get8 ());
		}
#pragma warning restore 0169

		static IntPtr id_get8;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get8' and count(parameter)=0]"
		[Register ("get8", "()Ljava/lang/String;", "GetGet8Handler")]
		public virtual unsafe string Get8 ()
		{
			if (id_get8 == IntPtr.Zero)
				id_get8 = JNIEnv.GetMethodID (class_ref, "get8", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get8), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get8", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get9;
#pragma warning disable 0169
		static Delegate GetGet9Handler ()
		{
			if (cb_get9 == null)
				cb_get9 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get9);
			return cb_get9;
		}

		static IntPtr n_Get9 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Audiochat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get9 ());
		}
#pragma warning restore 0169

		static IntPtr id_get9;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Audiochat']/method[@name='get9' and count(parameter)=0]"
		[Register ("get9", "()Ljava/lang/String;", "GetGet9Handler")]
		public virtual unsafe string Get9 ()
		{
			if (id_get9 == IntPtr.Zero)
				id_get9 = JNIEnv.GetMethodID (class_ref, "get9", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get9), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get9", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
