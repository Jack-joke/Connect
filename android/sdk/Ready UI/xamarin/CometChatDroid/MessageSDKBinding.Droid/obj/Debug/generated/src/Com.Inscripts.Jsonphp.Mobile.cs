using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Mobile", DoNotGenerateAcw=true)]
	public partial class Mobile : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Mobile", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Mobile); }
		}

		protected Mobile (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/constructor[@name='Mobile' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Mobile ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Mobile)) {
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Hash);
		}
#pragma warning restore 0169

		static IntPtr id_getHash;
		public virtual unsafe string Hash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='getHash' and count(parameter)=0]"
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

		static Delegate cb_getMore;
#pragma warning disable 0169
		static Delegate GetGetMoreHandler ()
		{
			if (cb_getMore == null)
				cb_getMore = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMore);
			return cb_getMore;
		}

		static IntPtr n_GetMore (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.More);
		}
#pragma warning restore 0169

		static IntPtr id_getMore;
		public virtual unsafe string More {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='getMore' and count(parameter)=0]"
			[Register ("getMore", "()Ljava/lang/String;", "GetGetMoreHandler")]
			get {
				if (id_getMore == IntPtr.Zero)
					id_getMore = JNIEnv.GetMethodID (class_ref, "getMore", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMore), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMore", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getStatus;
#pragma warning disable 0169
		static Delegate GetGetStatusHandler ()
		{
			if (cb_getStatus == null)
				cb_getStatus = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetStatus);
			return cb_getStatus;
		}

		static IntPtr n_GetStatus (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Status);
		}
#pragma warning restore 0169

		static IntPtr id_getStatus;
		public virtual unsafe string Status {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='getStatus' and count(parameter)=0]"
			[Register ("getStatus", "()Ljava/lang/String;", "GetGetStatusHandler")]
			get {
				if (id_getStatus == IntPtr.Zero)
					id_getStatus = JNIEnv.GetMethodID (class_ref, "getStatus", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getStatus), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStatus", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUpdate;
#pragma warning disable 0169
		static Delegate GetGetUpdateHandler ()
		{
			if (cb_getUpdate == null)
				cb_getUpdate = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUpdate);
			return cb_getUpdate;
		}

		static IntPtr n_GetUpdate (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Update);
		}
#pragma warning restore 0169

		static IntPtr id_getUpdate;
		public virtual unsafe string Update {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='getUpdate' and count(parameter)=0]"
			[Register ("getUpdate", "()Ljava/lang/String;", "GetGetUpdateHandler")]
			get {
				if (id_getUpdate == IntPtr.Zero)
					id_getUpdate = JNIEnv.GetMethodID (class_ref, "getUpdate", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUpdate), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUpdate", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get0 ());
		}
#pragma warning restore 0169

		static IntPtr id_get0;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get0' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get1 ());
		}
#pragma warning restore 0169

		static IntPtr id_get1;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get1' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get10 ());
		}
#pragma warning restore 0169

		static IntPtr id_get10;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get10' and count(parameter)=0]"
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

		static Delegate cb_get100;
#pragma warning disable 0169
		static Delegate GetGet100Handler ()
		{
			if (cb_get100 == null)
				cb_get100 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get100);
			return cb_get100;
		}

		static IntPtr n_Get100 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get100 ());
		}
#pragma warning restore 0169

		static IntPtr id_get100;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get100' and count(parameter)=0]"
		[Register ("get100", "()Ljava/lang/String;", "GetGet100Handler")]
		public virtual unsafe string Get100 ()
		{
			if (id_get100 == IntPtr.Zero)
				id_get100 = JNIEnv.GetMethodID (class_ref, "get100", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get100), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get100", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get101;
#pragma warning disable 0169
		static Delegate GetGet101Handler ()
		{
			if (cb_get101 == null)
				cb_get101 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get101);
			return cb_get101;
		}

		static IntPtr n_Get101 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get101 ());
		}
#pragma warning restore 0169

		static IntPtr id_get101;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get101' and count(parameter)=0]"
		[Register ("get101", "()Ljava/lang/String;", "GetGet101Handler")]
		public virtual unsafe string Get101 ()
		{
			if (id_get101 == IntPtr.Zero)
				id_get101 = JNIEnv.GetMethodID (class_ref, "get101", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get101), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get101", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get102;
#pragma warning disable 0169
		static Delegate GetGet102Handler ()
		{
			if (cb_get102 == null)
				cb_get102 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get102);
			return cb_get102;
		}

		static IntPtr n_Get102 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get102 ());
		}
#pragma warning restore 0169

		static IntPtr id_get102;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get102' and count(parameter)=0]"
		[Register ("get102", "()Ljava/lang/String;", "GetGet102Handler")]
		public virtual unsafe string Get102 ()
		{
			if (id_get102 == IntPtr.Zero)
				id_get102 = JNIEnv.GetMethodID (class_ref, "get102", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get102), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get102", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get106;
#pragma warning disable 0169
		static Delegate GetGet106Handler ()
		{
			if (cb_get106 == null)
				cb_get106 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get106);
			return cb_get106;
		}

		static IntPtr n_Get106 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get106 ());
		}
#pragma warning restore 0169

		static IntPtr id_get106;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get106' and count(parameter)=0]"
		[Register ("get106", "()Ljava/lang/String;", "GetGet106Handler")]
		public virtual unsafe string Get106 ()
		{
			if (id_get106 == IntPtr.Zero)
				id_get106 = JNIEnv.GetMethodID (class_ref, "get106", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get106), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get106", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get11 ());
		}
#pragma warning restore 0169

		static IntPtr id_get11;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get11' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get12 ());
		}
#pragma warning restore 0169

		static IntPtr id_get12;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get12' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get13 ());
		}
#pragma warning restore 0169

		static IntPtr id_get13;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get13' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get14 ());
		}
#pragma warning restore 0169

		static IntPtr id_get14;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get14' and count(parameter)=0]"
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

		static Delegate cb_get144;
#pragma warning disable 0169
		static Delegate GetGet144Handler ()
		{
			if (cb_get144 == null)
				cb_get144 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get144);
			return cb_get144;
		}

		static IntPtr n_Get144 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get144 ());
		}
#pragma warning restore 0169

		static IntPtr id_get144;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get144' and count(parameter)=0]"
		[Register ("get144", "()Ljava/lang/String;", "GetGet144Handler")]
		public virtual unsafe string Get144 ()
		{
			if (id_get144 == IntPtr.Zero)
				id_get144 = JNIEnv.GetMethodID (class_ref, "get144", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get144), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get144", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get145;
#pragma warning disable 0169
		static Delegate GetGet145Handler ()
		{
			if (cb_get145 == null)
				cb_get145 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get145);
			return cb_get145;
		}

		static IntPtr n_Get145 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get145 ());
		}
#pragma warning restore 0169

		static IntPtr id_get145;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get145' and count(parameter)=0]"
		[Register ("get145", "()Ljava/lang/String;", "GetGet145Handler")]
		public virtual unsafe string Get145 ()
		{
			if (id_get145 == IntPtr.Zero)
				id_get145 = JNIEnv.GetMethodID (class_ref, "get145", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get145), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get145", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get146;
#pragma warning disable 0169
		static Delegate GetGet146Handler ()
		{
			if (cb_get146 == null)
				cb_get146 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get146);
			return cb_get146;
		}

		static IntPtr n_Get146 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get146 ());
		}
#pragma warning restore 0169

		static IntPtr id_get146;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get146' and count(parameter)=0]"
		[Register ("get146", "()Ljava/lang/String;", "GetGet146Handler")]
		public virtual unsafe string Get146 ()
		{
			if (id_get146 == IntPtr.Zero)
				id_get146 = JNIEnv.GetMethodID (class_ref, "get146", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get146), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get146", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get147;
#pragma warning disable 0169
		static Delegate GetGet147Handler ()
		{
			if (cb_get147 == null)
				cb_get147 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get147);
			return cb_get147;
		}

		static IntPtr n_Get147 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get147 ());
		}
#pragma warning restore 0169

		static IntPtr id_get147;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get147' and count(parameter)=0]"
		[Register ("get147", "()Ljava/lang/String;", "GetGet147Handler")]
		public virtual unsafe string Get147 ()
		{
			if (id_get147 == IntPtr.Zero)
				id_get147 = JNIEnv.GetMethodID (class_ref, "get147", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get147), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get147", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get148;
#pragma warning disable 0169
		static Delegate GetGet148Handler ()
		{
			if (cb_get148 == null)
				cb_get148 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get148);
			return cb_get148;
		}

		static IntPtr n_Get148 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get148 ());
		}
#pragma warning restore 0169

		static IntPtr id_get148;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get148' and count(parameter)=0]"
		[Register ("get148", "()Ljava/lang/String;", "GetGet148Handler")]
		public virtual unsafe string Get148 ()
		{
			if (id_get148 == IntPtr.Zero)
				id_get148 = JNIEnv.GetMethodID (class_ref, "get148", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get148), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get148", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get149;
#pragma warning disable 0169
		static Delegate GetGet149Handler ()
		{
			if (cb_get149 == null)
				cb_get149 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get149);
			return cb_get149;
		}

		static IntPtr n_Get149 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get149 ());
		}
#pragma warning restore 0169

		static IntPtr id_get149;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get149' and count(parameter)=0]"
		[Register ("get149", "()Ljava/lang/String;", "GetGet149Handler")]
		public virtual unsafe string Get149 ()
		{
			if (id_get149 == IntPtr.Zero)
				id_get149 = JNIEnv.GetMethodID (class_ref, "get149", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get149), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get149", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get15 ());
		}
#pragma warning restore 0169

		static IntPtr id_get15;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get15' and count(parameter)=0]"
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

		static Delegate cb_get150;
#pragma warning disable 0169
		static Delegate GetGet150Handler ()
		{
			if (cb_get150 == null)
				cb_get150 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get150);
			return cb_get150;
		}

		static IntPtr n_Get150 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get150 ());
		}
#pragma warning restore 0169

		static IntPtr id_get150;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get150' and count(parameter)=0]"
		[Register ("get150", "()Ljava/lang/String;", "GetGet150Handler")]
		public virtual unsafe string Get150 ()
		{
			if (id_get150 == IntPtr.Zero)
				id_get150 = JNIEnv.GetMethodID (class_ref, "get150", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get150), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get150", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get151;
#pragma warning disable 0169
		static Delegate GetGet151Handler ()
		{
			if (cb_get151 == null)
				cb_get151 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get151);
			return cb_get151;
		}

		static IntPtr n_Get151 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get151 ());
		}
#pragma warning restore 0169

		static IntPtr id_get151;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get151' and count(parameter)=0]"
		[Register ("get151", "()Ljava/lang/String;", "GetGet151Handler")]
		public virtual unsafe string Get151 ()
		{
			if (id_get151 == IntPtr.Zero)
				id_get151 = JNIEnv.GetMethodID (class_ref, "get151", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get151), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get151", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get152;
#pragma warning disable 0169
		static Delegate GetGet152Handler ()
		{
			if (cb_get152 == null)
				cb_get152 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get152);
			return cb_get152;
		}

		static IntPtr n_Get152 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get152 ());
		}
#pragma warning restore 0169

		static IntPtr id_get152;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get152' and count(parameter)=0]"
		[Register ("get152", "()Ljava/lang/String;", "GetGet152Handler")]
		public virtual unsafe string Get152 ()
		{
			if (id_get152 == IntPtr.Zero)
				id_get152 = JNIEnv.GetMethodID (class_ref, "get152", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get152), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get152", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get153;
#pragma warning disable 0169
		static Delegate GetGet153Handler ()
		{
			if (cb_get153 == null)
				cb_get153 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get153);
			return cb_get153;
		}

		static IntPtr n_Get153 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get153 ());
		}
#pragma warning restore 0169

		static IntPtr id_get153;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get153' and count(parameter)=0]"
		[Register ("get153", "()Ljava/lang/String;", "GetGet153Handler")]
		public virtual unsafe string Get153 ()
		{
			if (id_get153 == IntPtr.Zero)
				id_get153 = JNIEnv.GetMethodID (class_ref, "get153", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get153), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get153", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get154;
#pragma warning disable 0169
		static Delegate GetGet154Handler ()
		{
			if (cb_get154 == null)
				cb_get154 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get154);
			return cb_get154;
		}

		static IntPtr n_Get154 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get154 ());
		}
#pragma warning restore 0169

		static IntPtr id_get154;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get154' and count(parameter)=0]"
		[Register ("get154", "()Ljava/lang/String;", "GetGet154Handler")]
		public virtual unsafe string Get154 ()
		{
			if (id_get154 == IntPtr.Zero)
				id_get154 = JNIEnv.GetMethodID (class_ref, "get154", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get154), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get154", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get155;
#pragma warning disable 0169
		static Delegate GetGet155Handler ()
		{
			if (cb_get155 == null)
				cb_get155 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get155);
			return cb_get155;
		}

		static IntPtr n_Get155 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get155 ());
		}
#pragma warning restore 0169

		static IntPtr id_get155;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get155' and count(parameter)=0]"
		[Register ("get155", "()Ljava/lang/String;", "GetGet155Handler")]
		public virtual unsafe string Get155 ()
		{
			if (id_get155 == IntPtr.Zero)
				id_get155 = JNIEnv.GetMethodID (class_ref, "get155", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get155), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get155", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get156;
#pragma warning disable 0169
		static Delegate GetGet156Handler ()
		{
			if (cb_get156 == null)
				cb_get156 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get156);
			return cb_get156;
		}

		static IntPtr n_Get156 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get156 ());
		}
#pragma warning restore 0169

		static IntPtr id_get156;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get156' and count(parameter)=0]"
		[Register ("get156", "()Ljava/lang/String;", "GetGet156Handler")]
		public virtual unsafe string Get156 ()
		{
			if (id_get156 == IntPtr.Zero)
				id_get156 = JNIEnv.GetMethodID (class_ref, "get156", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get156), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get156", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get157;
#pragma warning disable 0169
		static Delegate GetGet157Handler ()
		{
			if (cb_get157 == null)
				cb_get157 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get157);
			return cb_get157;
		}

		static IntPtr n_Get157 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get157 ());
		}
#pragma warning restore 0169

		static IntPtr id_get157;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get157' and count(parameter)=0]"
		[Register ("get157", "()Ljava/lang/String;", "GetGet157Handler")]
		public virtual unsafe string Get157 ()
		{
			if (id_get157 == IntPtr.Zero)
				id_get157 = JNIEnv.GetMethodID (class_ref, "get157", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get157), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get157", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get158;
#pragma warning disable 0169
		static Delegate GetGet158Handler ()
		{
			if (cb_get158 == null)
				cb_get158 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get158);
			return cb_get158;
		}

		static IntPtr n_Get158 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get158 ());
		}
#pragma warning restore 0169

		static IntPtr id_get158;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get158' and count(parameter)=0]"
		[Register ("get158", "()Ljava/lang/String;", "GetGet158Handler")]
		public virtual unsafe string Get158 ()
		{
			if (id_get158 == IntPtr.Zero)
				id_get158 = JNIEnv.GetMethodID (class_ref, "get158", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get158), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get158", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get159;
#pragma warning disable 0169
		static Delegate GetGet159Handler ()
		{
			if (cb_get159 == null)
				cb_get159 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get159);
			return cb_get159;
		}

		static IntPtr n_Get159 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get159 ());
		}
#pragma warning restore 0169

		static IntPtr id_get159;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get159' and count(parameter)=0]"
		[Register ("get159", "()Ljava/lang/String;", "GetGet159Handler")]
		public virtual unsafe string Get159 ()
		{
			if (id_get159 == IntPtr.Zero)
				id_get159 = JNIEnv.GetMethodID (class_ref, "get159", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get159), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get159", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get16 ());
		}
#pragma warning restore 0169

		static IntPtr id_get16;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get16' and count(parameter)=0]"
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

		static Delegate cb_get160;
#pragma warning disable 0169
		static Delegate GetGet160Handler ()
		{
			if (cb_get160 == null)
				cb_get160 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get160);
			return cb_get160;
		}

		static IntPtr n_Get160 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get160 ());
		}
#pragma warning restore 0169

		static IntPtr id_get160;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get160' and count(parameter)=0]"
		[Register ("get160", "()Ljava/lang/String;", "GetGet160Handler")]
		public virtual unsafe string Get160 ()
		{
			if (id_get160 == IntPtr.Zero)
				id_get160 = JNIEnv.GetMethodID (class_ref, "get160", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get160), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get160", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get161;
#pragma warning disable 0169
		static Delegate GetGet161Handler ()
		{
			if (cb_get161 == null)
				cb_get161 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get161);
			return cb_get161;
		}

		static IntPtr n_Get161 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get161 ());
		}
#pragma warning restore 0169

		static IntPtr id_get161;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get161' and count(parameter)=0]"
		[Register ("get161", "()Ljava/lang/String;", "GetGet161Handler")]
		public virtual unsafe string Get161 ()
		{
			if (id_get161 == IntPtr.Zero)
				id_get161 = JNIEnv.GetMethodID (class_ref, "get161", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get161), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get161", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get162;
#pragma warning disable 0169
		static Delegate GetGet162Handler ()
		{
			if (cb_get162 == null)
				cb_get162 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get162);
			return cb_get162;
		}

		static IntPtr n_Get162 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get162 ());
		}
#pragma warning restore 0169

		static IntPtr id_get162;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get162' and count(parameter)=0]"
		[Register ("get162", "()Ljava/lang/String;", "GetGet162Handler")]
		public virtual unsafe string Get162 ()
		{
			if (id_get162 == IntPtr.Zero)
				id_get162 = JNIEnv.GetMethodID (class_ref, "get162", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get162), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get162", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get163;
#pragma warning disable 0169
		static Delegate GetGet163Handler ()
		{
			if (cb_get163 == null)
				cb_get163 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get163);
			return cb_get163;
		}

		static IntPtr n_Get163 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get163 ());
		}
#pragma warning restore 0169

		static IntPtr id_get163;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get163' and count(parameter)=0]"
		[Register ("get163", "()Ljava/lang/String;", "GetGet163Handler")]
		public virtual unsafe string Get163 ()
		{
			if (id_get163 == IntPtr.Zero)
				id_get163 = JNIEnv.GetMethodID (class_ref, "get163", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get163), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get163", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get164;
#pragma warning disable 0169
		static Delegate GetGet164Handler ()
		{
			if (cb_get164 == null)
				cb_get164 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get164);
			return cb_get164;
		}

		static IntPtr n_Get164 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get164 ());
		}
#pragma warning restore 0169

		static IntPtr id_get164;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get164' and count(parameter)=0]"
		[Register ("get164", "()Ljava/lang/String;", "GetGet164Handler")]
		public virtual unsafe string Get164 ()
		{
			if (id_get164 == IntPtr.Zero)
				id_get164 = JNIEnv.GetMethodID (class_ref, "get164", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get164), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get164", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get165;
#pragma warning disable 0169
		static Delegate GetGet165Handler ()
		{
			if (cb_get165 == null)
				cb_get165 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get165);
			return cb_get165;
		}

		static IntPtr n_Get165 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get165 ());
		}
#pragma warning restore 0169

		static IntPtr id_get165;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get165' and count(parameter)=0]"
		[Register ("get165", "()Ljava/lang/String;", "GetGet165Handler")]
		public virtual unsafe string Get165 ()
		{
			if (id_get165 == IntPtr.Zero)
				id_get165 = JNIEnv.GetMethodID (class_ref, "get165", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get165), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get165", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get166;
#pragma warning disable 0169
		static Delegate GetGet166Handler ()
		{
			if (cb_get166 == null)
				cb_get166 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get166);
			return cb_get166;
		}

		static IntPtr n_Get166 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get166 ());
		}
#pragma warning restore 0169

		static IntPtr id_get166;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get166' and count(parameter)=0]"
		[Register ("get166", "()Ljava/lang/String;", "GetGet166Handler")]
		public virtual unsafe string Get166 ()
		{
			if (id_get166 == IntPtr.Zero)
				id_get166 = JNIEnv.GetMethodID (class_ref, "get166", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get166), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get166", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get167;
#pragma warning disable 0169
		static Delegate GetGet167Handler ()
		{
			if (cb_get167 == null)
				cb_get167 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get167);
			return cb_get167;
		}

		static IntPtr n_Get167 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get167 ());
		}
#pragma warning restore 0169

		static IntPtr id_get167;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get167' and count(parameter)=0]"
		[Register ("get167", "()Ljava/lang/String;", "GetGet167Handler")]
		public virtual unsafe string Get167 ()
		{
			if (id_get167 == IntPtr.Zero)
				id_get167 = JNIEnv.GetMethodID (class_ref, "get167", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get167), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get167", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get168;
#pragma warning disable 0169
		static Delegate GetGet168Handler ()
		{
			if (cb_get168 == null)
				cb_get168 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get168);
			return cb_get168;
		}

		static IntPtr n_Get168 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get168 ());
		}
#pragma warning restore 0169

		static IntPtr id_get168;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get168' and count(parameter)=0]"
		[Register ("get168", "()Ljava/lang/String;", "GetGet168Handler")]
		public virtual unsafe string Get168 ()
		{
			if (id_get168 == IntPtr.Zero)
				id_get168 = JNIEnv.GetMethodID (class_ref, "get168", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get168), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get168", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get169;
#pragma warning disable 0169
		static Delegate GetGet169Handler ()
		{
			if (cb_get169 == null)
				cb_get169 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get169);
			return cb_get169;
		}

		static IntPtr n_Get169 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get169 ());
		}
#pragma warning restore 0169

		static IntPtr id_get169;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get169' and count(parameter)=0]"
		[Register ("get169", "()Ljava/lang/String;", "GetGet169Handler")]
		public virtual unsafe string Get169 ()
		{
			if (id_get169 == IntPtr.Zero)
				id_get169 = JNIEnv.GetMethodID (class_ref, "get169", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get169), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get169", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get17 ());
		}
#pragma warning restore 0169

		static IntPtr id_get17;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get17' and count(parameter)=0]"
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

		static Delegate cb_get170;
#pragma warning disable 0169
		static Delegate GetGet170Handler ()
		{
			if (cb_get170 == null)
				cb_get170 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get170);
			return cb_get170;
		}

		static IntPtr n_Get170 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get170 ());
		}
#pragma warning restore 0169

		static IntPtr id_get170;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get170' and count(parameter)=0]"
		[Register ("get170", "()Ljava/lang/String;", "GetGet170Handler")]
		public virtual unsafe string Get170 ()
		{
			if (id_get170 == IntPtr.Zero)
				id_get170 = JNIEnv.GetMethodID (class_ref, "get170", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get170), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get170", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get171;
#pragma warning disable 0169
		static Delegate GetGet171Handler ()
		{
			if (cb_get171 == null)
				cb_get171 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get171);
			return cb_get171;
		}

		static IntPtr n_Get171 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get171 ());
		}
#pragma warning restore 0169

		static IntPtr id_get171;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get171' and count(parameter)=0]"
		[Register ("get171", "()Ljava/lang/String;", "GetGet171Handler")]
		public virtual unsafe string Get171 ()
		{
			if (id_get171 == IntPtr.Zero)
				id_get171 = JNIEnv.GetMethodID (class_ref, "get171", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get171), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get171", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get172;
#pragma warning disable 0169
		static Delegate GetGet172Handler ()
		{
			if (cb_get172 == null)
				cb_get172 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get172);
			return cb_get172;
		}

		static IntPtr n_Get172 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get172 ());
		}
#pragma warning restore 0169

		static IntPtr id_get172;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get172' and count(parameter)=0]"
		[Register ("get172", "()Ljava/lang/String;", "GetGet172Handler")]
		public virtual unsafe string Get172 ()
		{
			if (id_get172 == IntPtr.Zero)
				id_get172 = JNIEnv.GetMethodID (class_ref, "get172", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get172), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get172", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get173;
#pragma warning disable 0169
		static Delegate GetGet173Handler ()
		{
			if (cb_get173 == null)
				cb_get173 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get173);
			return cb_get173;
		}

		static IntPtr n_Get173 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get173 ());
		}
#pragma warning restore 0169

		static IntPtr id_get173;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get173' and count(parameter)=0]"
		[Register ("get173", "()Ljava/lang/String;", "GetGet173Handler")]
		public virtual unsafe string Get173 ()
		{
			if (id_get173 == IntPtr.Zero)
				id_get173 = JNIEnv.GetMethodID (class_ref, "get173", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get173), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get173", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get174;
#pragma warning disable 0169
		static Delegate GetGet174Handler ()
		{
			if (cb_get174 == null)
				cb_get174 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get174);
			return cb_get174;
		}

		static IntPtr n_Get174 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get174 ());
		}
#pragma warning restore 0169

		static IntPtr id_get174;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get174' and count(parameter)=0]"
		[Register ("get174", "()Ljava/lang/String;", "GetGet174Handler")]
		public virtual unsafe string Get174 ()
		{
			if (id_get174 == IntPtr.Zero)
				id_get174 = JNIEnv.GetMethodID (class_ref, "get174", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get174), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get174", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get175;
#pragma warning disable 0169
		static Delegate GetGet175Handler ()
		{
			if (cb_get175 == null)
				cb_get175 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get175);
			return cb_get175;
		}

		static IntPtr n_Get175 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get175 ());
		}
#pragma warning restore 0169

		static IntPtr id_get175;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get175' and count(parameter)=0]"
		[Register ("get175", "()Ljava/lang/String;", "GetGet175Handler")]
		public virtual unsafe string Get175 ()
		{
			if (id_get175 == IntPtr.Zero)
				id_get175 = JNIEnv.GetMethodID (class_ref, "get175", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get175), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get175", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get176;
#pragma warning disable 0169
		static Delegate GetGet176Handler ()
		{
			if (cb_get176 == null)
				cb_get176 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get176);
			return cb_get176;
		}

		static IntPtr n_Get176 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get176 ());
		}
#pragma warning restore 0169

		static IntPtr id_get176;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get176' and count(parameter)=0]"
		[Register ("get176", "()Ljava/lang/String;", "GetGet176Handler")]
		public virtual unsafe string Get176 ()
		{
			if (id_get176 == IntPtr.Zero)
				id_get176 = JNIEnv.GetMethodID (class_ref, "get176", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get176), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get176", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get177;
#pragma warning disable 0169
		static Delegate GetGet177Handler ()
		{
			if (cb_get177 == null)
				cb_get177 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get177);
			return cb_get177;
		}

		static IntPtr n_Get177 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get177 ());
		}
#pragma warning restore 0169

		static IntPtr id_get177;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get177' and count(parameter)=0]"
		[Register ("get177", "()Ljava/lang/String;", "GetGet177Handler")]
		public virtual unsafe string Get177 ()
		{
			if (id_get177 == IntPtr.Zero)
				id_get177 = JNIEnv.GetMethodID (class_ref, "get177", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get177), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get177", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get178;
#pragma warning disable 0169
		static Delegate GetGet178Handler ()
		{
			if (cb_get178 == null)
				cb_get178 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get178);
			return cb_get178;
		}

		static IntPtr n_Get178 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get178 ());
		}
#pragma warning restore 0169

		static IntPtr id_get178;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get178' and count(parameter)=0]"
		[Register ("get178", "()Ljava/lang/String;", "GetGet178Handler")]
		public virtual unsafe string Get178 ()
		{
			if (id_get178 == IntPtr.Zero)
				id_get178 = JNIEnv.GetMethodID (class_ref, "get178", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get178), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get178", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get179;
#pragma warning disable 0169
		static Delegate GetGet179Handler ()
		{
			if (cb_get179 == null)
				cb_get179 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get179);
			return cb_get179;
		}

		static IntPtr n_Get179 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get179 ());
		}
#pragma warning restore 0169

		static IntPtr id_get179;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get179' and count(parameter)=0]"
		[Register ("get179", "()Ljava/lang/String;", "GetGet179Handler")]
		public virtual unsafe string Get179 ()
		{
			if (id_get179 == IntPtr.Zero)
				id_get179 = JNIEnv.GetMethodID (class_ref, "get179", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get179), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get179", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get18 ());
		}
#pragma warning restore 0169

		static IntPtr id_get18;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get18' and count(parameter)=0]"
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

		static Delegate cb_get180;
#pragma warning disable 0169
		static Delegate GetGet180Handler ()
		{
			if (cb_get180 == null)
				cb_get180 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get180);
			return cb_get180;
		}

		static IntPtr n_Get180 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get180 ());
		}
#pragma warning restore 0169

		static IntPtr id_get180;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get180' and count(parameter)=0]"
		[Register ("get180", "()Ljava/lang/String;", "GetGet180Handler")]
		public virtual unsafe string Get180 ()
		{
			if (id_get180 == IntPtr.Zero)
				id_get180 = JNIEnv.GetMethodID (class_ref, "get180", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get180), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get180", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get181;
#pragma warning disable 0169
		static Delegate GetGet181Handler ()
		{
			if (cb_get181 == null)
				cb_get181 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get181);
			return cb_get181;
		}

		static IntPtr n_Get181 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get181 ());
		}
#pragma warning restore 0169

		static IntPtr id_get181;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get181' and count(parameter)=0]"
		[Register ("get181", "()Ljava/lang/String;", "GetGet181Handler")]
		public virtual unsafe string Get181 ()
		{
			if (id_get181 == IntPtr.Zero)
				id_get181 = JNIEnv.GetMethodID (class_ref, "get181", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get181), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get181", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get182;
#pragma warning disable 0169
		static Delegate GetGet182Handler ()
		{
			if (cb_get182 == null)
				cb_get182 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get182);
			return cb_get182;
		}

		static IntPtr n_Get182 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get182 ());
		}
#pragma warning restore 0169

		static IntPtr id_get182;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get182' and count(parameter)=0]"
		[Register ("get182", "()Ljava/lang/String;", "GetGet182Handler")]
		public virtual unsafe string Get182 ()
		{
			if (id_get182 == IntPtr.Zero)
				id_get182 = JNIEnv.GetMethodID (class_ref, "get182", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get182), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get182", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get183;
#pragma warning disable 0169
		static Delegate GetGet183Handler ()
		{
			if (cb_get183 == null)
				cb_get183 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get183);
			return cb_get183;
		}

		static IntPtr n_Get183 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get183 ());
		}
#pragma warning restore 0169

		static IntPtr id_get183;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get183' and count(parameter)=0]"
		[Register ("get183", "()Ljava/lang/String;", "GetGet183Handler")]
		public virtual unsafe string Get183 ()
		{
			if (id_get183 == IntPtr.Zero)
				id_get183 = JNIEnv.GetMethodID (class_ref, "get183", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get183), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get183", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get184;
#pragma warning disable 0169
		static Delegate GetGet184Handler ()
		{
			if (cb_get184 == null)
				cb_get184 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get184);
			return cb_get184;
		}

		static IntPtr n_Get184 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get184 ());
		}
#pragma warning restore 0169

		static IntPtr id_get184;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get184' and count(parameter)=0]"
		[Register ("get184", "()Ljava/lang/String;", "GetGet184Handler")]
		public virtual unsafe string Get184 ()
		{
			if (id_get184 == IntPtr.Zero)
				id_get184 = JNIEnv.GetMethodID (class_ref, "get184", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get184), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get184", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get19 ());
		}
#pragma warning restore 0169

		static IntPtr id_get19;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get19' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get2 ());
		}
#pragma warning restore 0169

		static IntPtr id_get2;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get2' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get20 ());
		}
#pragma warning restore 0169

		static IntPtr id_get20;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get20' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get21 ());
		}
#pragma warning restore 0169

		static IntPtr id_get21;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get21' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get22 ());
		}
#pragma warning restore 0169

		static IntPtr id_get22;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get22' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get23 ());
		}
#pragma warning restore 0169

		static IntPtr id_get23;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get23' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get24 ());
		}
#pragma warning restore 0169

		static IntPtr id_get24;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get24' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get25 ());
		}
#pragma warning restore 0169

		static IntPtr id_get25;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get25' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get26 ());
		}
#pragma warning restore 0169

		static IntPtr id_get26;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get26' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get27 ());
		}
#pragma warning restore 0169

		static IntPtr id_get27;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get27' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get28 ());
		}
#pragma warning restore 0169

		static IntPtr id_get28;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get28' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get29 ());
		}
#pragma warning restore 0169

		static IntPtr id_get29;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get29' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get3 ());
		}
#pragma warning restore 0169

		static IntPtr id_get3;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get3' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get30 ());
		}
#pragma warning restore 0169

		static IntPtr id_get30;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get30' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get31 ());
		}
#pragma warning restore 0169

		static IntPtr id_get31;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get31' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get32 ());
		}
#pragma warning restore 0169

		static IntPtr id_get32;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get32' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get33 ());
		}
#pragma warning restore 0169

		static IntPtr id_get33;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get33' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get34 ());
		}
#pragma warning restore 0169

		static IntPtr id_get34;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get34' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get35 ());
		}
#pragma warning restore 0169

		static IntPtr id_get35;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get35' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get36 ());
		}
#pragma warning restore 0169

		static IntPtr id_get36;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get36' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get37 ());
		}
#pragma warning restore 0169

		static IntPtr id_get37;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get37' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get38 ());
		}
#pragma warning restore 0169

		static IntPtr id_get38;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get38' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get39 ());
		}
#pragma warning restore 0169

		static IntPtr id_get39;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get39' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get4 ());
		}
#pragma warning restore 0169

		static IntPtr id_get4;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get4' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get40 ());
		}
#pragma warning restore 0169

		static IntPtr id_get40;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get40' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get41 ());
		}
#pragma warning restore 0169

		static IntPtr id_get41;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get41' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get42 ());
		}
#pragma warning restore 0169

		static IntPtr id_get42;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get42' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get43 ());
		}
#pragma warning restore 0169

		static IntPtr id_get43;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get43' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get44 ());
		}
#pragma warning restore 0169

		static IntPtr id_get44;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get44' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get45 ());
		}
#pragma warning restore 0169

		static IntPtr id_get45;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get45' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get46 ());
		}
#pragma warning restore 0169

		static IntPtr id_get46;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get46' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get47 ());
		}
#pragma warning restore 0169

		static IntPtr id_get47;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get47' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get48 ());
		}
#pragma warning restore 0169

		static IntPtr id_get48;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get48' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get49 ());
		}
#pragma warning restore 0169

		static IntPtr id_get49;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get49' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get5 ());
		}
#pragma warning restore 0169

		static IntPtr id_get5;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get5' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get50 ());
		}
#pragma warning restore 0169

		static IntPtr id_get50;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get50' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get51 ());
		}
#pragma warning restore 0169

		static IntPtr id_get51;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get51' and count(parameter)=0]"
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

		static Delegate cb_get52;
#pragma warning disable 0169
		static Delegate GetGet52Handler ()
		{
			if (cb_get52 == null)
				cb_get52 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get52);
			return cb_get52;
		}

		static IntPtr n_Get52 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get52 ());
		}
#pragma warning restore 0169

		static IntPtr id_get52;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get52' and count(parameter)=0]"
		[Register ("get52", "()Ljava/lang/String;", "GetGet52Handler")]
		public virtual unsafe string Get52 ()
		{
			if (id_get52 == IntPtr.Zero)
				id_get52 = JNIEnv.GetMethodID (class_ref, "get52", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get52), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get52", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get53;
#pragma warning disable 0169
		static Delegate GetGet53Handler ()
		{
			if (cb_get53 == null)
				cb_get53 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get53);
			return cb_get53;
		}

		static IntPtr n_Get53 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get53 ());
		}
#pragma warning restore 0169

		static IntPtr id_get53;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get53' and count(parameter)=0]"
		[Register ("get53", "()Ljava/lang/String;", "GetGet53Handler")]
		public virtual unsafe string Get53 ()
		{
			if (id_get53 == IntPtr.Zero)
				id_get53 = JNIEnv.GetMethodID (class_ref, "get53", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get53), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get53", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get54;
#pragma warning disable 0169
		static Delegate GetGet54Handler ()
		{
			if (cb_get54 == null)
				cb_get54 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get54);
			return cb_get54;
		}

		static IntPtr n_Get54 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get54 ());
		}
#pragma warning restore 0169

		static IntPtr id_get54;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get54' and count(parameter)=0]"
		[Register ("get54", "()Ljava/lang/String;", "GetGet54Handler")]
		public virtual unsafe string Get54 ()
		{
			if (id_get54 == IntPtr.Zero)
				id_get54 = JNIEnv.GetMethodID (class_ref, "get54", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get54), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get54", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get55;
#pragma warning disable 0169
		static Delegate GetGet55Handler ()
		{
			if (cb_get55 == null)
				cb_get55 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get55);
			return cb_get55;
		}

		static IntPtr n_Get55 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get55 ());
		}
#pragma warning restore 0169

		static IntPtr id_get55;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get55' and count(parameter)=0]"
		[Register ("get55", "()Ljava/lang/String;", "GetGet55Handler")]
		public virtual unsafe string Get55 ()
		{
			if (id_get55 == IntPtr.Zero)
				id_get55 = JNIEnv.GetMethodID (class_ref, "get55", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get55), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get55", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get56;
#pragma warning disable 0169
		static Delegate GetGet56Handler ()
		{
			if (cb_get56 == null)
				cb_get56 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get56);
			return cb_get56;
		}

		static IntPtr n_Get56 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get56 ());
		}
#pragma warning restore 0169

		static IntPtr id_get56;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get56' and count(parameter)=0]"
		[Register ("get56", "()Ljava/lang/String;", "GetGet56Handler")]
		public virtual unsafe string Get56 ()
		{
			if (id_get56 == IntPtr.Zero)
				id_get56 = JNIEnv.GetMethodID (class_ref, "get56", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get56), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get56", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get57;
#pragma warning disable 0169
		static Delegate GetGet57Handler ()
		{
			if (cb_get57 == null)
				cb_get57 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get57);
			return cb_get57;
		}

		static IntPtr n_Get57 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get57 ());
		}
#pragma warning restore 0169

		static IntPtr id_get57;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get57' and count(parameter)=0]"
		[Register ("get57", "()Ljava/lang/String;", "GetGet57Handler")]
		public virtual unsafe string Get57 ()
		{
			if (id_get57 == IntPtr.Zero)
				id_get57 = JNIEnv.GetMethodID (class_ref, "get57", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get57), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get57", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get58;
#pragma warning disable 0169
		static Delegate GetGet58Handler ()
		{
			if (cb_get58 == null)
				cb_get58 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get58);
			return cb_get58;
		}

		static IntPtr n_Get58 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get58 ());
		}
#pragma warning restore 0169

		static IntPtr id_get58;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get58' and count(parameter)=0]"
		[Register ("get58", "()Ljava/lang/String;", "GetGet58Handler")]
		public virtual unsafe string Get58 ()
		{
			if (id_get58 == IntPtr.Zero)
				id_get58 = JNIEnv.GetMethodID (class_ref, "get58", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get58), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get58", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get59;
#pragma warning disable 0169
		static Delegate GetGet59Handler ()
		{
			if (cb_get59 == null)
				cb_get59 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get59);
			return cb_get59;
		}

		static IntPtr n_Get59 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get59 ());
		}
#pragma warning restore 0169

		static IntPtr id_get59;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get59' and count(parameter)=0]"
		[Register ("get59", "()Ljava/lang/String;", "GetGet59Handler")]
		public virtual unsafe string Get59 ()
		{
			if (id_get59 == IntPtr.Zero)
				id_get59 = JNIEnv.GetMethodID (class_ref, "get59", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get59), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get59", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get6 ());
		}
#pragma warning restore 0169

		static IntPtr id_get6;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get6' and count(parameter)=0]"
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

		static Delegate cb_get60;
#pragma warning disable 0169
		static Delegate GetGet60Handler ()
		{
			if (cb_get60 == null)
				cb_get60 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get60);
			return cb_get60;
		}

		static IntPtr n_Get60 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get60 ());
		}
#pragma warning restore 0169

		static IntPtr id_get60;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get60' and count(parameter)=0]"
		[Register ("get60", "()Ljava/lang/String;", "GetGet60Handler")]
		public virtual unsafe string Get60 ()
		{
			if (id_get60 == IntPtr.Zero)
				id_get60 = JNIEnv.GetMethodID (class_ref, "get60", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get60), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get60", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get61;
#pragma warning disable 0169
		static Delegate GetGet61Handler ()
		{
			if (cb_get61 == null)
				cb_get61 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get61);
			return cb_get61;
		}

		static IntPtr n_Get61 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get61 ());
		}
#pragma warning restore 0169

		static IntPtr id_get61;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get61' and count(parameter)=0]"
		[Register ("get61", "()Ljava/lang/String;", "GetGet61Handler")]
		public virtual unsafe string Get61 ()
		{
			if (id_get61 == IntPtr.Zero)
				id_get61 = JNIEnv.GetMethodID (class_ref, "get61", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get61), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get61", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get62;
#pragma warning disable 0169
		static Delegate GetGet62Handler ()
		{
			if (cb_get62 == null)
				cb_get62 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get62);
			return cb_get62;
		}

		static IntPtr n_Get62 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get62 ());
		}
#pragma warning restore 0169

		static IntPtr id_get62;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get62' and count(parameter)=0]"
		[Register ("get62", "()Ljava/lang/String;", "GetGet62Handler")]
		public virtual unsafe string Get62 ()
		{
			if (id_get62 == IntPtr.Zero)
				id_get62 = JNIEnv.GetMethodID (class_ref, "get62", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get62), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get62", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get63;
#pragma warning disable 0169
		static Delegate GetGet63Handler ()
		{
			if (cb_get63 == null)
				cb_get63 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get63);
			return cb_get63;
		}

		static IntPtr n_Get63 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get63 ());
		}
#pragma warning restore 0169

		static IntPtr id_get63;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get63' and count(parameter)=0]"
		[Register ("get63", "()Ljava/lang/String;", "GetGet63Handler")]
		public virtual unsafe string Get63 ()
		{
			if (id_get63 == IntPtr.Zero)
				id_get63 = JNIEnv.GetMethodID (class_ref, "get63", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get63), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get63", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get64;
#pragma warning disable 0169
		static Delegate GetGet64Handler ()
		{
			if (cb_get64 == null)
				cb_get64 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get64);
			return cb_get64;
		}

		static IntPtr n_Get64 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get64 ());
		}
#pragma warning restore 0169

		static IntPtr id_get64;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get64' and count(parameter)=0]"
		[Register ("get64", "()Ljava/lang/String;", "GetGet64Handler")]
		public virtual unsafe string Get64 ()
		{
			if (id_get64 == IntPtr.Zero)
				id_get64 = JNIEnv.GetMethodID (class_ref, "get64", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get64), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get64", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get65;
#pragma warning disable 0169
		static Delegate GetGet65Handler ()
		{
			if (cb_get65 == null)
				cb_get65 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get65);
			return cb_get65;
		}

		static IntPtr n_Get65 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get65 ());
		}
#pragma warning restore 0169

		static IntPtr id_get65;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get65' and count(parameter)=0]"
		[Register ("get65", "()Ljava/lang/String;", "GetGet65Handler")]
		public virtual unsafe string Get65 ()
		{
			if (id_get65 == IntPtr.Zero)
				id_get65 = JNIEnv.GetMethodID (class_ref, "get65", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get65), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get65", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get66;
#pragma warning disable 0169
		static Delegate GetGet66Handler ()
		{
			if (cb_get66 == null)
				cb_get66 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get66);
			return cb_get66;
		}

		static IntPtr n_Get66 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get66 ());
		}
#pragma warning restore 0169

		static IntPtr id_get66;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get66' and count(parameter)=0]"
		[Register ("get66", "()Ljava/lang/String;", "GetGet66Handler")]
		public virtual unsafe string Get66 ()
		{
			if (id_get66 == IntPtr.Zero)
				id_get66 = JNIEnv.GetMethodID (class_ref, "get66", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get66), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get66", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get67;
#pragma warning disable 0169
		static Delegate GetGet67Handler ()
		{
			if (cb_get67 == null)
				cb_get67 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get67);
			return cb_get67;
		}

		static IntPtr n_Get67 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get67 ());
		}
#pragma warning restore 0169

		static IntPtr id_get67;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get67' and count(parameter)=0]"
		[Register ("get67", "()Ljava/lang/String;", "GetGet67Handler")]
		public virtual unsafe string Get67 ()
		{
			if (id_get67 == IntPtr.Zero)
				id_get67 = JNIEnv.GetMethodID (class_ref, "get67", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get67), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get67", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get68;
#pragma warning disable 0169
		static Delegate GetGet68Handler ()
		{
			if (cb_get68 == null)
				cb_get68 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get68);
			return cb_get68;
		}

		static IntPtr n_Get68 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get68 ());
		}
#pragma warning restore 0169

		static IntPtr id_get68;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get68' and count(parameter)=0]"
		[Register ("get68", "()Ljava/lang/String;", "GetGet68Handler")]
		public virtual unsafe string Get68 ()
		{
			if (id_get68 == IntPtr.Zero)
				id_get68 = JNIEnv.GetMethodID (class_ref, "get68", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get68), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get68", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get69;
#pragma warning disable 0169
		static Delegate GetGet69Handler ()
		{
			if (cb_get69 == null)
				cb_get69 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get69);
			return cb_get69;
		}

		static IntPtr n_Get69 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get69 ());
		}
#pragma warning restore 0169

		static IntPtr id_get69;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get69' and count(parameter)=0]"
		[Register ("get69", "()Ljava/lang/String;", "GetGet69Handler")]
		public virtual unsafe string Get69 ()
		{
			if (id_get69 == IntPtr.Zero)
				id_get69 = JNIEnv.GetMethodID (class_ref, "get69", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get69), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get69", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get7 ());
		}
#pragma warning restore 0169

		static IntPtr id_get7;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get7' and count(parameter)=0]"
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

		static Delegate cb_get70;
#pragma warning disable 0169
		static Delegate GetGet70Handler ()
		{
			if (cb_get70 == null)
				cb_get70 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get70);
			return cb_get70;
		}

		static IntPtr n_Get70 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get70 ());
		}
#pragma warning restore 0169

		static IntPtr id_get70;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get70' and count(parameter)=0]"
		[Register ("get70", "()Ljava/lang/String;", "GetGet70Handler")]
		public virtual unsafe string Get70 ()
		{
			if (id_get70 == IntPtr.Zero)
				id_get70 = JNIEnv.GetMethodID (class_ref, "get70", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get70), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get70", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get71;
#pragma warning disable 0169
		static Delegate GetGet71Handler ()
		{
			if (cb_get71 == null)
				cb_get71 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get71);
			return cb_get71;
		}

		static IntPtr n_Get71 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get71 ());
		}
#pragma warning restore 0169

		static IntPtr id_get71;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get71' and count(parameter)=0]"
		[Register ("get71", "()Ljava/lang/String;", "GetGet71Handler")]
		public virtual unsafe string Get71 ()
		{
			if (id_get71 == IntPtr.Zero)
				id_get71 = JNIEnv.GetMethodID (class_ref, "get71", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get71), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get71", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get72;
#pragma warning disable 0169
		static Delegate GetGet72Handler ()
		{
			if (cb_get72 == null)
				cb_get72 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get72);
			return cb_get72;
		}

		static IntPtr n_Get72 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get72 ());
		}
#pragma warning restore 0169

		static IntPtr id_get72;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get72' and count(parameter)=0]"
		[Register ("get72", "()Ljava/lang/String;", "GetGet72Handler")]
		public virtual unsafe string Get72 ()
		{
			if (id_get72 == IntPtr.Zero)
				id_get72 = JNIEnv.GetMethodID (class_ref, "get72", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get72), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get72", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get73;
#pragma warning disable 0169
		static Delegate GetGet73Handler ()
		{
			if (cb_get73 == null)
				cb_get73 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get73);
			return cb_get73;
		}

		static IntPtr n_Get73 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get73 ());
		}
#pragma warning restore 0169

		static IntPtr id_get73;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get73' and count(parameter)=0]"
		[Register ("get73", "()Ljava/lang/String;", "GetGet73Handler")]
		public virtual unsafe string Get73 ()
		{
			if (id_get73 == IntPtr.Zero)
				id_get73 = JNIEnv.GetMethodID (class_ref, "get73", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get73), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get73", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get74;
#pragma warning disable 0169
		static Delegate GetGet74Handler ()
		{
			if (cb_get74 == null)
				cb_get74 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get74);
			return cb_get74;
		}

		static IntPtr n_Get74 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get74 ());
		}
#pragma warning restore 0169

		static IntPtr id_get74;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get74' and count(parameter)=0]"
		[Register ("get74", "()Ljava/lang/String;", "GetGet74Handler")]
		public virtual unsafe string Get74 ()
		{
			if (id_get74 == IntPtr.Zero)
				id_get74 = JNIEnv.GetMethodID (class_ref, "get74", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get74), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get74", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get75;
#pragma warning disable 0169
		static Delegate GetGet75Handler ()
		{
			if (cb_get75 == null)
				cb_get75 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get75);
			return cb_get75;
		}

		static IntPtr n_Get75 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get75 ());
		}
#pragma warning restore 0169

		static IntPtr id_get75;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get75' and count(parameter)=0]"
		[Register ("get75", "()Ljava/lang/String;", "GetGet75Handler")]
		public virtual unsafe string Get75 ()
		{
			if (id_get75 == IntPtr.Zero)
				id_get75 = JNIEnv.GetMethodID (class_ref, "get75", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get75), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get75", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get76;
#pragma warning disable 0169
		static Delegate GetGet76Handler ()
		{
			if (cb_get76 == null)
				cb_get76 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get76);
			return cb_get76;
		}

		static IntPtr n_Get76 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get76 ());
		}
#pragma warning restore 0169

		static IntPtr id_get76;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get76' and count(parameter)=0]"
		[Register ("get76", "()Ljava/lang/String;", "GetGet76Handler")]
		public virtual unsafe string Get76 ()
		{
			if (id_get76 == IntPtr.Zero)
				id_get76 = JNIEnv.GetMethodID (class_ref, "get76", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get76), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get76", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get77;
#pragma warning disable 0169
		static Delegate GetGet77Handler ()
		{
			if (cb_get77 == null)
				cb_get77 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get77);
			return cb_get77;
		}

		static IntPtr n_Get77 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get77 ());
		}
#pragma warning restore 0169

		static IntPtr id_get77;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get77' and count(parameter)=0]"
		[Register ("get77", "()Ljava/lang/String;", "GetGet77Handler")]
		public virtual unsafe string Get77 ()
		{
			if (id_get77 == IntPtr.Zero)
				id_get77 = JNIEnv.GetMethodID (class_ref, "get77", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get77), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get77", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get78;
#pragma warning disable 0169
		static Delegate GetGet78Handler ()
		{
			if (cb_get78 == null)
				cb_get78 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get78);
			return cb_get78;
		}

		static IntPtr n_Get78 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get78 ());
		}
#pragma warning restore 0169

		static IntPtr id_get78;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get78' and count(parameter)=0]"
		[Register ("get78", "()Ljava/lang/String;", "GetGet78Handler")]
		public virtual unsafe string Get78 ()
		{
			if (id_get78 == IntPtr.Zero)
				id_get78 = JNIEnv.GetMethodID (class_ref, "get78", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get78), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get78", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get79;
#pragma warning disable 0169
		static Delegate GetGet79Handler ()
		{
			if (cb_get79 == null)
				cb_get79 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get79);
			return cb_get79;
		}

		static IntPtr n_Get79 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get79 ());
		}
#pragma warning restore 0169

		static IntPtr id_get79;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get79' and count(parameter)=0]"
		[Register ("get79", "()Ljava/lang/String;", "GetGet79Handler")]
		public virtual unsafe string Get79 ()
		{
			if (id_get79 == IntPtr.Zero)
				id_get79 = JNIEnv.GetMethodID (class_ref, "get79", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get79), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get79", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get8 ());
		}
#pragma warning restore 0169

		static IntPtr id_get8;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get8' and count(parameter)=0]"
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

		static Delegate cb_get80;
#pragma warning disable 0169
		static Delegate GetGet80Handler ()
		{
			if (cb_get80 == null)
				cb_get80 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get80);
			return cb_get80;
		}

		static IntPtr n_Get80 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get80 ());
		}
#pragma warning restore 0169

		static IntPtr id_get80;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get80' and count(parameter)=0]"
		[Register ("get80", "()Ljava/lang/String;", "GetGet80Handler")]
		public virtual unsafe string Get80 ()
		{
			if (id_get80 == IntPtr.Zero)
				id_get80 = JNIEnv.GetMethodID (class_ref, "get80", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get80), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get80", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get81;
#pragma warning disable 0169
		static Delegate GetGet81Handler ()
		{
			if (cb_get81 == null)
				cb_get81 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get81);
			return cb_get81;
		}

		static IntPtr n_Get81 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get81 ());
		}
#pragma warning restore 0169

		static IntPtr id_get81;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get81' and count(parameter)=0]"
		[Register ("get81", "()Ljava/lang/String;", "GetGet81Handler")]
		public virtual unsafe string Get81 ()
		{
			if (id_get81 == IntPtr.Zero)
				id_get81 = JNIEnv.GetMethodID (class_ref, "get81", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get81), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get81", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get82;
#pragma warning disable 0169
		static Delegate GetGet82Handler ()
		{
			if (cb_get82 == null)
				cb_get82 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get82);
			return cb_get82;
		}

		static IntPtr n_Get82 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get82 ());
		}
#pragma warning restore 0169

		static IntPtr id_get82;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get82' and count(parameter)=0]"
		[Register ("get82", "()Ljava/lang/String;", "GetGet82Handler")]
		public virtual unsafe string Get82 ()
		{
			if (id_get82 == IntPtr.Zero)
				id_get82 = JNIEnv.GetMethodID (class_ref, "get82", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get82), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get82", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get83;
#pragma warning disable 0169
		static Delegate GetGet83Handler ()
		{
			if (cb_get83 == null)
				cb_get83 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get83);
			return cb_get83;
		}

		static IntPtr n_Get83 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get83 ());
		}
#pragma warning restore 0169

		static IntPtr id_get83;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get83' and count(parameter)=0]"
		[Register ("get83", "()Ljava/lang/String;", "GetGet83Handler")]
		public virtual unsafe string Get83 ()
		{
			if (id_get83 == IntPtr.Zero)
				id_get83 = JNIEnv.GetMethodID (class_ref, "get83", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get83), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get83", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get84;
#pragma warning disable 0169
		static Delegate GetGet84Handler ()
		{
			if (cb_get84 == null)
				cb_get84 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get84);
			return cb_get84;
		}

		static IntPtr n_Get84 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get84 ());
		}
#pragma warning restore 0169

		static IntPtr id_get84;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get84' and count(parameter)=0]"
		[Register ("get84", "()Ljava/lang/String;", "GetGet84Handler")]
		public virtual unsafe string Get84 ()
		{
			if (id_get84 == IntPtr.Zero)
				id_get84 = JNIEnv.GetMethodID (class_ref, "get84", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get84), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get84", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get85;
#pragma warning disable 0169
		static Delegate GetGet85Handler ()
		{
			if (cb_get85 == null)
				cb_get85 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get85);
			return cb_get85;
		}

		static IntPtr n_Get85 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get85 ());
		}
#pragma warning restore 0169

		static IntPtr id_get85;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get85' and count(parameter)=0]"
		[Register ("get85", "()Ljava/lang/String;", "GetGet85Handler")]
		public virtual unsafe string Get85 ()
		{
			if (id_get85 == IntPtr.Zero)
				id_get85 = JNIEnv.GetMethodID (class_ref, "get85", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get85), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get85", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get86;
#pragma warning disable 0169
		static Delegate GetGet86Handler ()
		{
			if (cb_get86 == null)
				cb_get86 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get86);
			return cb_get86;
		}

		static IntPtr n_Get86 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get86 ());
		}
#pragma warning restore 0169

		static IntPtr id_get86;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get86' and count(parameter)=0]"
		[Register ("get86", "()Ljava/lang/String;", "GetGet86Handler")]
		public virtual unsafe string Get86 ()
		{
			if (id_get86 == IntPtr.Zero)
				id_get86 = JNIEnv.GetMethodID (class_ref, "get86", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get86), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get86", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get87;
#pragma warning disable 0169
		static Delegate GetGet87Handler ()
		{
			if (cb_get87 == null)
				cb_get87 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get87);
			return cb_get87;
		}

		static IntPtr n_Get87 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get87 ());
		}
#pragma warning restore 0169

		static IntPtr id_get87;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get87' and count(parameter)=0]"
		[Register ("get87", "()Ljava/lang/String;", "GetGet87Handler")]
		public virtual unsafe string Get87 ()
		{
			if (id_get87 == IntPtr.Zero)
				id_get87 = JNIEnv.GetMethodID (class_ref, "get87", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get87), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get87", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get88;
#pragma warning disable 0169
		static Delegate GetGet88Handler ()
		{
			if (cb_get88 == null)
				cb_get88 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get88);
			return cb_get88;
		}

		static IntPtr n_Get88 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get88 ());
		}
#pragma warning restore 0169

		static IntPtr id_get88;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get88' and count(parameter)=0]"
		[Register ("get88", "()Ljava/lang/String;", "GetGet88Handler")]
		public virtual unsafe string Get88 ()
		{
			if (id_get88 == IntPtr.Zero)
				id_get88 = JNIEnv.GetMethodID (class_ref, "get88", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get88), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get88", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get89;
#pragma warning disable 0169
		static Delegate GetGet89Handler ()
		{
			if (cb_get89 == null)
				cb_get89 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get89);
			return cb_get89;
		}

		static IntPtr n_Get89 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get89 ());
		}
#pragma warning restore 0169

		static IntPtr id_get89;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get89' and count(parameter)=0]"
		[Register ("get89", "()Ljava/lang/String;", "GetGet89Handler")]
		public virtual unsafe string Get89 ()
		{
			if (id_get89 == IntPtr.Zero)
				id_get89 = JNIEnv.GetMethodID (class_ref, "get89", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get89), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get89", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get9 ());
		}
#pragma warning restore 0169

		static IntPtr id_get9;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get9' and count(parameter)=0]"
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

		static Delegate cb_get90;
#pragma warning disable 0169
		static Delegate GetGet90Handler ()
		{
			if (cb_get90 == null)
				cb_get90 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get90);
			return cb_get90;
		}

		static IntPtr n_Get90 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get90 ());
		}
#pragma warning restore 0169

		static IntPtr id_get90;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get90' and count(parameter)=0]"
		[Register ("get90", "()Ljava/lang/String;", "GetGet90Handler")]
		public virtual unsafe string Get90 ()
		{
			if (id_get90 == IntPtr.Zero)
				id_get90 = JNIEnv.GetMethodID (class_ref, "get90", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get90), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get90", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get91;
#pragma warning disable 0169
		static Delegate GetGet91Handler ()
		{
			if (cb_get91 == null)
				cb_get91 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get91);
			return cb_get91;
		}

		static IntPtr n_Get91 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get91 ());
		}
#pragma warning restore 0169

		static IntPtr id_get91;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get91' and count(parameter)=0]"
		[Register ("get91", "()Ljava/lang/String;", "GetGet91Handler")]
		public virtual unsafe string Get91 ()
		{
			if (id_get91 == IntPtr.Zero)
				id_get91 = JNIEnv.GetMethodID (class_ref, "get91", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get91), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get91", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get92;
#pragma warning disable 0169
		static Delegate GetGet92Handler ()
		{
			if (cb_get92 == null)
				cb_get92 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get92);
			return cb_get92;
		}

		static IntPtr n_Get92 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get92 ());
		}
#pragma warning restore 0169

		static IntPtr id_get92;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get92' and count(parameter)=0]"
		[Register ("get92", "()Ljava/lang/String;", "GetGet92Handler")]
		public virtual unsafe string Get92 ()
		{
			if (id_get92 == IntPtr.Zero)
				id_get92 = JNIEnv.GetMethodID (class_ref, "get92", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get92), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get92", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get93;
#pragma warning disable 0169
		static Delegate GetGet93Handler ()
		{
			if (cb_get93 == null)
				cb_get93 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get93);
			return cb_get93;
		}

		static IntPtr n_Get93 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get93 ());
		}
#pragma warning restore 0169

		static IntPtr id_get93;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get93' and count(parameter)=0]"
		[Register ("get93", "()Ljava/lang/String;", "GetGet93Handler")]
		public virtual unsafe string Get93 ()
		{
			if (id_get93 == IntPtr.Zero)
				id_get93 = JNIEnv.GetMethodID (class_ref, "get93", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get93), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get93", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get94;
#pragma warning disable 0169
		static Delegate GetGet94Handler ()
		{
			if (cb_get94 == null)
				cb_get94 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get94);
			return cb_get94;
		}

		static IntPtr n_Get94 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get94 ());
		}
#pragma warning restore 0169

		static IntPtr id_get94;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get94' and count(parameter)=0]"
		[Register ("get94", "()Ljava/lang/String;", "GetGet94Handler")]
		public virtual unsafe string Get94 ()
		{
			if (id_get94 == IntPtr.Zero)
				id_get94 = JNIEnv.GetMethodID (class_ref, "get94", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get94), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get94", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get95;
#pragma warning disable 0169
		static Delegate GetGet95Handler ()
		{
			if (cb_get95 == null)
				cb_get95 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get95);
			return cb_get95;
		}

		static IntPtr n_Get95 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get95 ());
		}
#pragma warning restore 0169

		static IntPtr id_get95;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get95' and count(parameter)=0]"
		[Register ("get95", "()Ljava/lang/String;", "GetGet95Handler")]
		public virtual unsafe string Get95 ()
		{
			if (id_get95 == IntPtr.Zero)
				id_get95 = JNIEnv.GetMethodID (class_ref, "get95", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get95), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get95", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get96;
#pragma warning disable 0169
		static Delegate GetGet96Handler ()
		{
			if (cb_get96 == null)
				cb_get96 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get96);
			return cb_get96;
		}

		static IntPtr n_Get96 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get96 ());
		}
#pragma warning restore 0169

		static IntPtr id_get96;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get96' and count(parameter)=0]"
		[Register ("get96", "()Ljava/lang/String;", "GetGet96Handler")]
		public virtual unsafe string Get96 ()
		{
			if (id_get96 == IntPtr.Zero)
				id_get96 = JNIEnv.GetMethodID (class_ref, "get96", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get96), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get96", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get97;
#pragma warning disable 0169
		static Delegate GetGet97Handler ()
		{
			if (cb_get97 == null)
				cb_get97 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get97);
			return cb_get97;
		}

		static IntPtr n_Get97 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get97 ());
		}
#pragma warning restore 0169

		static IntPtr id_get97;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get97' and count(parameter)=0]"
		[Register ("get97", "()Ljava/lang/String;", "GetGet97Handler")]
		public virtual unsafe string Get97 ()
		{
			if (id_get97 == IntPtr.Zero)
				id_get97 = JNIEnv.GetMethodID (class_ref, "get97", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get97), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get97", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get98;
#pragma warning disable 0169
		static Delegate GetGet98Handler ()
		{
			if (cb_get98 == null)
				cb_get98 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get98);
			return cb_get98;
		}

		static IntPtr n_Get98 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get98 ());
		}
#pragma warning restore 0169

		static IntPtr id_get98;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get98' and count(parameter)=0]"
		[Register ("get98", "()Ljava/lang/String;", "GetGet98Handler")]
		public virtual unsafe string Get98 ()
		{
			if (id_get98 == IntPtr.Zero)
				id_get98 = JNIEnv.GetMethodID (class_ref, "get98", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get98), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get98", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_get99;
#pragma warning disable 0169
		static Delegate GetGet99Handler ()
		{
			if (cb_get99 == null)
				cb_get99 = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Get99);
			return cb_get99;
		}

		static IntPtr n_Get99 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Mobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get99 ());
		}
#pragma warning restore 0169

		static IntPtr id_get99;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Mobile']/method[@name='get99' and count(parameter)=0]"
		[Register ("get99", "()Ljava/lang/String;", "GetGet99Handler")]
		public virtual unsafe string Get99 ()
		{
			if (id_get99 == IntPtr.Zero)
				id_get99 = JNIEnv.GetMethodID (class_ref, "get99", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_get99), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "get99", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
