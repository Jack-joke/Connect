using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Core", DoNotGenerateAcw=true)]
	public partial class Core : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Core", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Core); }
		}

		protected Core (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/constructor[@name='Core' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Core ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Core)) {
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Hash);
		}
#pragma warning restore 0169

		static Delegate cb_setHash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetHash_Ljava_lang_String_Handler ()
		{
			if (cb_setHash_Ljava_lang_String_ == null)
				cb_setHash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetHash_Ljava_lang_String_);
			return cb_setHash_Ljava_lang_String_;
		}

		static void n_SetHash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Hash = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getHash;
		static IntPtr id_setHash_Ljava_lang_String_;
		public virtual unsafe string Hash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='getHash' and count(parameter)=0]"
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
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='setHash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setHash", "(Ljava/lang/String;)V", "GetSetHash_Ljava_lang_String_Handler")]
			set {
				if (id_setHash_Ljava_lang_String_ == IntPtr.Zero)
					id_setHash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setHash", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHash_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setHash", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getLangToday;
#pragma warning disable 0169
		static Delegate GetGetLangTodayHandler ()
		{
			if (cb_getLangToday == null)
				cb_getLangToday = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLangToday);
			return cb_getLangToday;
		}

		static IntPtr n_GetLangToday (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LangToday);
		}
#pragma warning restore 0169

		static IntPtr id_getLangToday;
		public virtual unsafe string LangToday {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='getLangToday' and count(parameter)=0]"
			[Register ("getLangToday", "()Ljava/lang/String;", "GetGetLangTodayHandler")]
			get {
				if (id_getLangToday == IntPtr.Zero)
					id_getLangToday = JNIEnv.GetMethodID (class_ref, "getLangToday", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLangToday), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLangToday", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLangYesterday;
#pragma warning disable 0169
		static Delegate GetGetLangYesterdayHandler ()
		{
			if (cb_getLangYesterday == null)
				cb_getLangYesterday = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLangYesterday);
			return cb_getLangYesterday;
		}

		static IntPtr n_GetLangYesterday (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LangYesterday);
		}
#pragma warning restore 0169

		static IntPtr id_getLangYesterday;
		public virtual unsafe string LangYesterday {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='getLangYesterday' and count(parameter)=0]"
			[Register ("getLangYesterday", "()Ljava/lang/String;", "GetGetLangYesterdayHandler")]
			get {
				if (id_getLangYesterday == IntPtr.Zero)
					id_getLangYesterday = JNIEnv.GetMethodID (class_ref, "getLangYesterday", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLangYesterday), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLangYesterday", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get0 ());
		}
#pragma warning restore 0169

		static IntPtr id_get0;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get0' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get1 ());
		}
#pragma warning restore 0169

		static IntPtr id_get1;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get1' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get10 ());
		}
#pragma warning restore 0169

		static IntPtr id_get10;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get10' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get11 ());
		}
#pragma warning restore 0169

		static IntPtr id_get11;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get11' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get12 ());
		}
#pragma warning restore 0169

		static IntPtr id_get12;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get12' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get13 ());
		}
#pragma warning restore 0169

		static IntPtr id_get13;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get13' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get14 ());
		}
#pragma warning restore 0169

		static IntPtr id_get14;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get14' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get15 ());
		}
#pragma warning restore 0169

		static IntPtr id_get15;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get15' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get16 ());
		}
#pragma warning restore 0169

		static IntPtr id_get16;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get16' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get17 ());
		}
#pragma warning restore 0169

		static IntPtr id_get17;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get17' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get18 ());
		}
#pragma warning restore 0169

		static IntPtr id_get18;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get18' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get19 ());
		}
#pragma warning restore 0169

		static IntPtr id_get19;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get19' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get2 ());
		}
#pragma warning restore 0169

		static IntPtr id_get2;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get2' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get20 ());
		}
#pragma warning restore 0169

		static IntPtr id_get20;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get20' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get21 ());
		}
#pragma warning restore 0169

		static IntPtr id_get21;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get21' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get22 ());
		}
#pragma warning restore 0169

		static IntPtr id_get22;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get22' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get23 ());
		}
#pragma warning restore 0169

		static IntPtr id_get23;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get23' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get24 ());
		}
#pragma warning restore 0169

		static IntPtr id_get24;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get24' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get25 ());
		}
#pragma warning restore 0169

		static IntPtr id_get25;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get25' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get26 ());
		}
#pragma warning restore 0169

		static IntPtr id_get26;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get26' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get27 ());
		}
#pragma warning restore 0169

		static IntPtr id_get27;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get27' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get28 ());
		}
#pragma warning restore 0169

		static IntPtr id_get28;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get28' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get29 ());
		}
#pragma warning restore 0169

		static IntPtr id_get29;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get29' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get3 ());
		}
#pragma warning restore 0169

		static IntPtr id_get3;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get3' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get30 ());
		}
#pragma warning restore 0169

		static IntPtr id_get30;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get30' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get31 ());
		}
#pragma warning restore 0169

		static IntPtr id_get31;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get31' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get32 ());
		}
#pragma warning restore 0169

		static IntPtr id_get32;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get32' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get33 ());
		}
#pragma warning restore 0169

		static IntPtr id_get33;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get33' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get34 ());
		}
#pragma warning restore 0169

		static IntPtr id_get34;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get34' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get35 ());
		}
#pragma warning restore 0169

		static IntPtr id_get35;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get35' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get36 ());
		}
#pragma warning restore 0169

		static IntPtr id_get36;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get36' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get37 ());
		}
#pragma warning restore 0169

		static IntPtr id_get37;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get37' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get38 ());
		}
#pragma warning restore 0169

		static IntPtr id_get38;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get38' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get39 ());
		}
#pragma warning restore 0169

		static IntPtr id_get39;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get39' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get4 ());
		}
#pragma warning restore 0169

		static IntPtr id_get4;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get4' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get40 ());
		}
#pragma warning restore 0169

		static IntPtr id_get40;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get40' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get41 ());
		}
#pragma warning restore 0169

		static IntPtr id_get41;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get41' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get42 ());
		}
#pragma warning restore 0169

		static IntPtr id_get42;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get42' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get43 ());
		}
#pragma warning restore 0169

		static IntPtr id_get43;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get43' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get44 ());
		}
#pragma warning restore 0169

		static IntPtr id_get44;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get44' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get45 ());
		}
#pragma warning restore 0169

		static IntPtr id_get45;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get45' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get46 ());
		}
#pragma warning restore 0169

		static IntPtr id_get46;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get46' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get47 ());
		}
#pragma warning restore 0169

		static IntPtr id_get47;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get47' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get48 ());
		}
#pragma warning restore 0169

		static IntPtr id_get48;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get48' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get49 ());
		}
#pragma warning restore 0169

		static IntPtr id_get49;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get49' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get5 ());
		}
#pragma warning restore 0169

		static IntPtr id_get5;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get5' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get50 ());
		}
#pragma warning restore 0169

		static IntPtr id_get50;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get50' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get51 ());
		}
#pragma warning restore 0169

		static IntPtr id_get51;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get51' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get52 ());
		}
#pragma warning restore 0169

		static IntPtr id_get52;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get52' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get53 ());
		}
#pragma warning restore 0169

		static IntPtr id_get53;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get53' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get54 ());
		}
#pragma warning restore 0169

		static IntPtr id_get54;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get54' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get55 ());
		}
#pragma warning restore 0169

		static IntPtr id_get55;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get55' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get56 ());
		}
#pragma warning restore 0169

		static IntPtr id_get56;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get56' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get57 ());
		}
#pragma warning restore 0169

		static IntPtr id_get57;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get57' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get58 ());
		}
#pragma warning restore 0169

		static IntPtr id_get58;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get58' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get59 ());
		}
#pragma warning restore 0169

		static IntPtr id_get59;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get59' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get6 ());
		}
#pragma warning restore 0169

		static IntPtr id_get6;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get6' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get60 ());
		}
#pragma warning restore 0169

		static IntPtr id_get60;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get60' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get61 ());
		}
#pragma warning restore 0169

		static IntPtr id_get61;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get61' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get62 ());
		}
#pragma warning restore 0169

		static IntPtr id_get62;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get62' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get63 ());
		}
#pragma warning restore 0169

		static IntPtr id_get63;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get63' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get64 ());
		}
#pragma warning restore 0169

		static IntPtr id_get64;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get64' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get65 ());
		}
#pragma warning restore 0169

		static IntPtr id_get65;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get65' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get66 ());
		}
#pragma warning restore 0169

		static IntPtr id_get66;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get66' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get67 ());
		}
#pragma warning restore 0169

		static IntPtr id_get67;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get67' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get68 ());
		}
#pragma warning restore 0169

		static IntPtr id_get68;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get68' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get69 ());
		}
#pragma warning restore 0169

		static IntPtr id_get69;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get69' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get7 ());
		}
#pragma warning restore 0169

		static IntPtr id_get7;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get7' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get70 ());
		}
#pragma warning restore 0169

		static IntPtr id_get70;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get70' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get71 ());
		}
#pragma warning restore 0169

		static IntPtr id_get71;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get71' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get72 ());
		}
#pragma warning restore 0169

		static IntPtr id_get72;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get72' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get73 ());
		}
#pragma warning restore 0169

		static IntPtr id_get73;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get73' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get74 ());
		}
#pragma warning restore 0169

		static IntPtr id_get74;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get74' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get75 ());
		}
#pragma warning restore 0169

		static IntPtr id_get75;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get75' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get76 ());
		}
#pragma warning restore 0169

		static IntPtr id_get76;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get76' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get8 ());
		}
#pragma warning restore 0169

		static IntPtr id_get8;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get8' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Get9 ());
		}
#pragma warning restore 0169

		static IntPtr id_get9;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='get9' and count(parameter)=0]"
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set0 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set0_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set0' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
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

		static Delegate cb_set10_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet10_Ljava_lang_String_Handler ()
		{
			if (cb_set10_Ljava_lang_String_ == null)
				cb_set10_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set10_Ljava_lang_String_);
			return cb_set10_Ljava_lang_String_;
		}

		static void n_Set10_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set10 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set10_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set10' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set10", "(Ljava/lang/String;)V", "GetSet10_Ljava_lang_String_Handler")]
		public virtual unsafe void Set10 (string p0)
		{
			if (id_set10_Ljava_lang_String_ == IntPtr.Zero)
				id_set10_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set10", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set10_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set10", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set11_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet11_Ljava_lang_String_Handler ()
		{
			if (cb_set11_Ljava_lang_String_ == null)
				cb_set11_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set11_Ljava_lang_String_);
			return cb_set11_Ljava_lang_String_;
		}

		static void n_Set11_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set11 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set11_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set11' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set11", "(Ljava/lang/String;)V", "GetSet11_Ljava_lang_String_Handler")]
		public virtual unsafe void Set11 (string p0)
		{
			if (id_set11_Ljava_lang_String_ == IntPtr.Zero)
				id_set11_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set11", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set11_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set11", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set12_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet12_Ljava_lang_String_Handler ()
		{
			if (cb_set12_Ljava_lang_String_ == null)
				cb_set12_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set12_Ljava_lang_String_);
			return cb_set12_Ljava_lang_String_;
		}

		static void n_Set12_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set12 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set12_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set12' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set12", "(Ljava/lang/String;)V", "GetSet12_Ljava_lang_String_Handler")]
		public virtual unsafe void Set12 (string p0)
		{
			if (id_set12_Ljava_lang_String_ == IntPtr.Zero)
				id_set12_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set12", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set12_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set12", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set13_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet13_Ljava_lang_String_Handler ()
		{
			if (cb_set13_Ljava_lang_String_ == null)
				cb_set13_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set13_Ljava_lang_String_);
			return cb_set13_Ljava_lang_String_;
		}

		static void n_Set13_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set13 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set13_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set13' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set13", "(Ljava/lang/String;)V", "GetSet13_Ljava_lang_String_Handler")]
		public virtual unsafe void Set13 (string p0)
		{
			if (id_set13_Ljava_lang_String_ == IntPtr.Zero)
				id_set13_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set13", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set13_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set13", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set14_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet14_Ljava_lang_String_Handler ()
		{
			if (cb_set14_Ljava_lang_String_ == null)
				cb_set14_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set14_Ljava_lang_String_);
			return cb_set14_Ljava_lang_String_;
		}

		static void n_Set14_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set14 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set14_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set14' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set14", "(Ljava/lang/String;)V", "GetSet14_Ljava_lang_String_Handler")]
		public virtual unsafe void Set14 (string p0)
		{
			if (id_set14_Ljava_lang_String_ == IntPtr.Zero)
				id_set14_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set14", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set14_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set14", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set15_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet15_Ljava_lang_String_Handler ()
		{
			if (cb_set15_Ljava_lang_String_ == null)
				cb_set15_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set15_Ljava_lang_String_);
			return cb_set15_Ljava_lang_String_;
		}

		static void n_Set15_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set15 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set15_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set15' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set15", "(Ljava/lang/String;)V", "GetSet15_Ljava_lang_String_Handler")]
		public virtual unsafe void Set15 (string p0)
		{
			if (id_set15_Ljava_lang_String_ == IntPtr.Zero)
				id_set15_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set15", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set15_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set15", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set16_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet16_Ljava_lang_String_Handler ()
		{
			if (cb_set16_Ljava_lang_String_ == null)
				cb_set16_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set16_Ljava_lang_String_);
			return cb_set16_Ljava_lang_String_;
		}

		static void n_Set16_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set16 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set16_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set16' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set16", "(Ljava/lang/String;)V", "GetSet16_Ljava_lang_String_Handler")]
		public virtual unsafe void Set16 (string p0)
		{
			if (id_set16_Ljava_lang_String_ == IntPtr.Zero)
				id_set16_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set16", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set16_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set16", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set17_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet17_Ljava_lang_String_Handler ()
		{
			if (cb_set17_Ljava_lang_String_ == null)
				cb_set17_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set17_Ljava_lang_String_);
			return cb_set17_Ljava_lang_String_;
		}

		static void n_Set17_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set17 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set17_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set17' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set17", "(Ljava/lang/String;)V", "GetSet17_Ljava_lang_String_Handler")]
		public virtual unsafe void Set17 (string p0)
		{
			if (id_set17_Ljava_lang_String_ == IntPtr.Zero)
				id_set17_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set17", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set17_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set17", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set18_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet18_Ljava_lang_String_Handler ()
		{
			if (cb_set18_Ljava_lang_String_ == null)
				cb_set18_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set18_Ljava_lang_String_);
			return cb_set18_Ljava_lang_String_;
		}

		static void n_Set18_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set18 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set18_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set18' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set18", "(Ljava/lang/String;)V", "GetSet18_Ljava_lang_String_Handler")]
		public virtual unsafe void Set18 (string p0)
		{
			if (id_set18_Ljava_lang_String_ == IntPtr.Zero)
				id_set18_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set18", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set18_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set18", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set19_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet19_Ljava_lang_String_Handler ()
		{
			if (cb_set19_Ljava_lang_String_ == null)
				cb_set19_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set19_Ljava_lang_String_);
			return cb_set19_Ljava_lang_String_;
		}

		static void n_Set19_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set19 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set19_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set19' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set19", "(Ljava/lang/String;)V", "GetSet19_Ljava_lang_String_Handler")]
		public virtual unsafe void Set19 (string p0)
		{
			if (id_set19_Ljava_lang_String_ == IntPtr.Zero)
				id_set19_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set19", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set19_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set19", "(Ljava/lang/String;)V"), __args);
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set1 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set1_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set1' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
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

		static Delegate cb_set20_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet20_Ljava_lang_String_Handler ()
		{
			if (cb_set20_Ljava_lang_String_ == null)
				cb_set20_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set20_Ljava_lang_String_);
			return cb_set20_Ljava_lang_String_;
		}

		static void n_Set20_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set20 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set20_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set20' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set20", "(Ljava/lang/String;)V", "GetSet20_Ljava_lang_String_Handler")]
		public virtual unsafe void Set20 (string p0)
		{
			if (id_set20_Ljava_lang_String_ == IntPtr.Zero)
				id_set20_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set20", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set20_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set20", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set21_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet21_Ljava_lang_String_Handler ()
		{
			if (cb_set21_Ljava_lang_String_ == null)
				cb_set21_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set21_Ljava_lang_String_);
			return cb_set21_Ljava_lang_String_;
		}

		static void n_Set21_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set21 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set21_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set21' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set21", "(Ljava/lang/String;)V", "GetSet21_Ljava_lang_String_Handler")]
		public virtual unsafe void Set21 (string p0)
		{
			if (id_set21_Ljava_lang_String_ == IntPtr.Zero)
				id_set21_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set21", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set21_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set21", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set22_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet22_Ljava_lang_String_Handler ()
		{
			if (cb_set22_Ljava_lang_String_ == null)
				cb_set22_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set22_Ljava_lang_String_);
			return cb_set22_Ljava_lang_String_;
		}

		static void n_Set22_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set22 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set22_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set22' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set22", "(Ljava/lang/String;)V", "GetSet22_Ljava_lang_String_Handler")]
		public virtual unsafe void Set22 (string p0)
		{
			if (id_set22_Ljava_lang_String_ == IntPtr.Zero)
				id_set22_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set22", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set22_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set22", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set23_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet23_Ljava_lang_String_Handler ()
		{
			if (cb_set23_Ljava_lang_String_ == null)
				cb_set23_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set23_Ljava_lang_String_);
			return cb_set23_Ljava_lang_String_;
		}

		static void n_Set23_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set23 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set23_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set23' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set23", "(Ljava/lang/String;)V", "GetSet23_Ljava_lang_String_Handler")]
		public virtual unsafe void Set23 (string p0)
		{
			if (id_set23_Ljava_lang_String_ == IntPtr.Zero)
				id_set23_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set23", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set23_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set23", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set24_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet24_Ljava_lang_String_Handler ()
		{
			if (cb_set24_Ljava_lang_String_ == null)
				cb_set24_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set24_Ljava_lang_String_);
			return cb_set24_Ljava_lang_String_;
		}

		static void n_Set24_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set24 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set24_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set24' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set24", "(Ljava/lang/String;)V", "GetSet24_Ljava_lang_String_Handler")]
		public virtual unsafe void Set24 (string p0)
		{
			if (id_set24_Ljava_lang_String_ == IntPtr.Zero)
				id_set24_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set24", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set24_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set24", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set25_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet25_Ljava_lang_String_Handler ()
		{
			if (cb_set25_Ljava_lang_String_ == null)
				cb_set25_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set25_Ljava_lang_String_);
			return cb_set25_Ljava_lang_String_;
		}

		static void n_Set25_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set25 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set25_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set25' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set25", "(Ljava/lang/String;)V", "GetSet25_Ljava_lang_String_Handler")]
		public virtual unsafe void Set25 (string p0)
		{
			if (id_set25_Ljava_lang_String_ == IntPtr.Zero)
				id_set25_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set25", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set25_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set25", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set26_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet26_Ljava_lang_String_Handler ()
		{
			if (cb_set26_Ljava_lang_String_ == null)
				cb_set26_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set26_Ljava_lang_String_);
			return cb_set26_Ljava_lang_String_;
		}

		static void n_Set26_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set26 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set26_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set26' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set26", "(Ljava/lang/String;)V", "GetSet26_Ljava_lang_String_Handler")]
		public virtual unsafe void Set26 (string p0)
		{
			if (id_set26_Ljava_lang_String_ == IntPtr.Zero)
				id_set26_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set26", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set26_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set26", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set27_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet27_Ljava_lang_String_Handler ()
		{
			if (cb_set27_Ljava_lang_String_ == null)
				cb_set27_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set27_Ljava_lang_String_);
			return cb_set27_Ljava_lang_String_;
		}

		static void n_Set27_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set27 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set27_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set27' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set27", "(Ljava/lang/String;)V", "GetSet27_Ljava_lang_String_Handler")]
		public virtual unsafe void Set27 (string p0)
		{
			if (id_set27_Ljava_lang_String_ == IntPtr.Zero)
				id_set27_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set27", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set27_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set27", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set28_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet28_Ljava_lang_String_Handler ()
		{
			if (cb_set28_Ljava_lang_String_ == null)
				cb_set28_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set28_Ljava_lang_String_);
			return cb_set28_Ljava_lang_String_;
		}

		static void n_Set28_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set28 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set28_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set28' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set28", "(Ljava/lang/String;)V", "GetSet28_Ljava_lang_String_Handler")]
		public virtual unsafe void Set28 (string p0)
		{
			if (id_set28_Ljava_lang_String_ == IntPtr.Zero)
				id_set28_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set28", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set28_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set28", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set29_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet29_Ljava_lang_String_Handler ()
		{
			if (cb_set29_Ljava_lang_String_ == null)
				cb_set29_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set29_Ljava_lang_String_);
			return cb_set29_Ljava_lang_String_;
		}

		static void n_Set29_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set29 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set29_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set29' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set29", "(Ljava/lang/String;)V", "GetSet29_Ljava_lang_String_Handler")]
		public virtual unsafe void Set29 (string p0)
		{
			if (id_set29_Ljava_lang_String_ == IntPtr.Zero)
				id_set29_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set29", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set29_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set29", "(Ljava/lang/String;)V"), __args);
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set2 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set2_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set2' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
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

		static Delegate cb_set30_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet30_Ljava_lang_String_Handler ()
		{
			if (cb_set30_Ljava_lang_String_ == null)
				cb_set30_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set30_Ljava_lang_String_);
			return cb_set30_Ljava_lang_String_;
		}

		static void n_Set30_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set30 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set30_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set30' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set30", "(Ljava/lang/String;)V", "GetSet30_Ljava_lang_String_Handler")]
		public virtual unsafe void Set30 (string p0)
		{
			if (id_set30_Ljava_lang_String_ == IntPtr.Zero)
				id_set30_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set30", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set30_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set30", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set31_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet31_Ljava_lang_String_Handler ()
		{
			if (cb_set31_Ljava_lang_String_ == null)
				cb_set31_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set31_Ljava_lang_String_);
			return cb_set31_Ljava_lang_String_;
		}

		static void n_Set31_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set31 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set31_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set31' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set31", "(Ljava/lang/String;)V", "GetSet31_Ljava_lang_String_Handler")]
		public virtual unsafe void Set31 (string p0)
		{
			if (id_set31_Ljava_lang_String_ == IntPtr.Zero)
				id_set31_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set31", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set31_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set31", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set32_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet32_Ljava_lang_String_Handler ()
		{
			if (cb_set32_Ljava_lang_String_ == null)
				cb_set32_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set32_Ljava_lang_String_);
			return cb_set32_Ljava_lang_String_;
		}

		static void n_Set32_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set32 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set32_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set32' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set32", "(Ljava/lang/String;)V", "GetSet32_Ljava_lang_String_Handler")]
		public virtual unsafe void Set32 (string p0)
		{
			if (id_set32_Ljava_lang_String_ == IntPtr.Zero)
				id_set32_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set32", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set32_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set32", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set33_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet33_Ljava_lang_String_Handler ()
		{
			if (cb_set33_Ljava_lang_String_ == null)
				cb_set33_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set33_Ljava_lang_String_);
			return cb_set33_Ljava_lang_String_;
		}

		static void n_Set33_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set33 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set33_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set33' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set33", "(Ljava/lang/String;)V", "GetSet33_Ljava_lang_String_Handler")]
		public virtual unsafe void Set33 (string p0)
		{
			if (id_set33_Ljava_lang_String_ == IntPtr.Zero)
				id_set33_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set33", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set33_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set33", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set34_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet34_Ljava_lang_String_Handler ()
		{
			if (cb_set34_Ljava_lang_String_ == null)
				cb_set34_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set34_Ljava_lang_String_);
			return cb_set34_Ljava_lang_String_;
		}

		static void n_Set34_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set34 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set34_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set34' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set34", "(Ljava/lang/String;)V", "GetSet34_Ljava_lang_String_Handler")]
		public virtual unsafe void Set34 (string p0)
		{
			if (id_set34_Ljava_lang_String_ == IntPtr.Zero)
				id_set34_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set34", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set34_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set34", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set35_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet35_Ljava_lang_String_Handler ()
		{
			if (cb_set35_Ljava_lang_String_ == null)
				cb_set35_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set35_Ljava_lang_String_);
			return cb_set35_Ljava_lang_String_;
		}

		static void n_Set35_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set35 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set35_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set35' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set35", "(Ljava/lang/String;)V", "GetSet35_Ljava_lang_String_Handler")]
		public virtual unsafe void Set35 (string p0)
		{
			if (id_set35_Ljava_lang_String_ == IntPtr.Zero)
				id_set35_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set35", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set35_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set35", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set36_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet36_Ljava_lang_String_Handler ()
		{
			if (cb_set36_Ljava_lang_String_ == null)
				cb_set36_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set36_Ljava_lang_String_);
			return cb_set36_Ljava_lang_String_;
		}

		static void n_Set36_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set36 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set36_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set36' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set36", "(Ljava/lang/String;)V", "GetSet36_Ljava_lang_String_Handler")]
		public virtual unsafe void Set36 (string p0)
		{
			if (id_set36_Ljava_lang_String_ == IntPtr.Zero)
				id_set36_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set36", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set36_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set36", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set37_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet37_Ljava_lang_String_Handler ()
		{
			if (cb_set37_Ljava_lang_String_ == null)
				cb_set37_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set37_Ljava_lang_String_);
			return cb_set37_Ljava_lang_String_;
		}

		static void n_Set37_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set37 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set37_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set37' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set37", "(Ljava/lang/String;)V", "GetSet37_Ljava_lang_String_Handler")]
		public virtual unsafe void Set37 (string p0)
		{
			if (id_set37_Ljava_lang_String_ == IntPtr.Zero)
				id_set37_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set37", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set37_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set37", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set38_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet38_Ljava_lang_String_Handler ()
		{
			if (cb_set38_Ljava_lang_String_ == null)
				cb_set38_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set38_Ljava_lang_String_);
			return cb_set38_Ljava_lang_String_;
		}

		static void n_Set38_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set38 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set38_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set38' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set38", "(Ljava/lang/String;)V", "GetSet38_Ljava_lang_String_Handler")]
		public virtual unsafe void Set38 (string p0)
		{
			if (id_set38_Ljava_lang_String_ == IntPtr.Zero)
				id_set38_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set38", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set38_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set38", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set39_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet39_Ljava_lang_String_Handler ()
		{
			if (cb_set39_Ljava_lang_String_ == null)
				cb_set39_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set39_Ljava_lang_String_);
			return cb_set39_Ljava_lang_String_;
		}

		static void n_Set39_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set39 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set39_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set39' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set39", "(Ljava/lang/String;)V", "GetSet39_Ljava_lang_String_Handler")]
		public virtual unsafe void Set39 (string p0)
		{
			if (id_set39_Ljava_lang_String_ == IntPtr.Zero)
				id_set39_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set39", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set39_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set39", "(Ljava/lang/String;)V"), __args);
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
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set3 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set3_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set3' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
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

		static Delegate cb_set40_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet40_Ljava_lang_String_Handler ()
		{
			if (cb_set40_Ljava_lang_String_ == null)
				cb_set40_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set40_Ljava_lang_String_);
			return cb_set40_Ljava_lang_String_;
		}

		static void n_Set40_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set40 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set40_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set40' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set40", "(Ljava/lang/String;)V", "GetSet40_Ljava_lang_String_Handler")]
		public virtual unsafe void Set40 (string p0)
		{
			if (id_set40_Ljava_lang_String_ == IntPtr.Zero)
				id_set40_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set40", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set40_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set40", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set41_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet41_Ljava_lang_String_Handler ()
		{
			if (cb_set41_Ljava_lang_String_ == null)
				cb_set41_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set41_Ljava_lang_String_);
			return cb_set41_Ljava_lang_String_;
		}

		static void n_Set41_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set41 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set41_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set41' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set41", "(Ljava/lang/String;)V", "GetSet41_Ljava_lang_String_Handler")]
		public virtual unsafe void Set41 (string p0)
		{
			if (id_set41_Ljava_lang_String_ == IntPtr.Zero)
				id_set41_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set41", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set41_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set41", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set42_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet42_Ljava_lang_String_Handler ()
		{
			if (cb_set42_Ljava_lang_String_ == null)
				cb_set42_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set42_Ljava_lang_String_);
			return cb_set42_Ljava_lang_String_;
		}

		static void n_Set42_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set42 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set42_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set42' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set42", "(Ljava/lang/String;)V", "GetSet42_Ljava_lang_String_Handler")]
		public virtual unsafe void Set42 (string p0)
		{
			if (id_set42_Ljava_lang_String_ == IntPtr.Zero)
				id_set42_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set42", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set42_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set42", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set43_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet43_Ljava_lang_String_Handler ()
		{
			if (cb_set43_Ljava_lang_String_ == null)
				cb_set43_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set43_Ljava_lang_String_);
			return cb_set43_Ljava_lang_String_;
		}

		static void n_Set43_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set43 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set43_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set43' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set43", "(Ljava/lang/String;)V", "GetSet43_Ljava_lang_String_Handler")]
		public virtual unsafe void Set43 (string p0)
		{
			if (id_set43_Ljava_lang_String_ == IntPtr.Zero)
				id_set43_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set43", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set43_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set43", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set44_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet44_Ljava_lang_String_Handler ()
		{
			if (cb_set44_Ljava_lang_String_ == null)
				cb_set44_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set44_Ljava_lang_String_);
			return cb_set44_Ljava_lang_String_;
		}

		static void n_Set44_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set44 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set44_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set44' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set44", "(Ljava/lang/String;)V", "GetSet44_Ljava_lang_String_Handler")]
		public virtual unsafe void Set44 (string p0)
		{
			if (id_set44_Ljava_lang_String_ == IntPtr.Zero)
				id_set44_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set44", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set44_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set44", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set45_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet45_Ljava_lang_String_Handler ()
		{
			if (cb_set45_Ljava_lang_String_ == null)
				cb_set45_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set45_Ljava_lang_String_);
			return cb_set45_Ljava_lang_String_;
		}

		static void n_Set45_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set45 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set45_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set45' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set45", "(Ljava/lang/String;)V", "GetSet45_Ljava_lang_String_Handler")]
		public virtual unsafe void Set45 (string p0)
		{
			if (id_set45_Ljava_lang_String_ == IntPtr.Zero)
				id_set45_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set45", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set45_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set45", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set46_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet46_Ljava_lang_String_Handler ()
		{
			if (cb_set46_Ljava_lang_String_ == null)
				cb_set46_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set46_Ljava_lang_String_);
			return cb_set46_Ljava_lang_String_;
		}

		static void n_Set46_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set46 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set46_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set46' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set46", "(Ljava/lang/String;)V", "GetSet46_Ljava_lang_String_Handler")]
		public virtual unsafe void Set46 (string p0)
		{
			if (id_set46_Ljava_lang_String_ == IntPtr.Zero)
				id_set46_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set46", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set46_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set46", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set47_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet47_Ljava_lang_String_Handler ()
		{
			if (cb_set47_Ljava_lang_String_ == null)
				cb_set47_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set47_Ljava_lang_String_);
			return cb_set47_Ljava_lang_String_;
		}

		static void n_Set47_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set47 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set47_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set47' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set47", "(Ljava/lang/String;)V", "GetSet47_Ljava_lang_String_Handler")]
		public virtual unsafe void Set47 (string p0)
		{
			if (id_set47_Ljava_lang_String_ == IntPtr.Zero)
				id_set47_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set47", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set47_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set47", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set48_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet48_Ljava_lang_String_Handler ()
		{
			if (cb_set48_Ljava_lang_String_ == null)
				cb_set48_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set48_Ljava_lang_String_);
			return cb_set48_Ljava_lang_String_;
		}

		static void n_Set48_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set48 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set48_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set48' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set48", "(Ljava/lang/String;)V", "GetSet48_Ljava_lang_String_Handler")]
		public virtual unsafe void Set48 (string p0)
		{
			if (id_set48_Ljava_lang_String_ == IntPtr.Zero)
				id_set48_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set48", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set48_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set48", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set49_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet49_Ljava_lang_String_Handler ()
		{
			if (cb_set49_Ljava_lang_String_ == null)
				cb_set49_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set49_Ljava_lang_String_);
			return cb_set49_Ljava_lang_String_;
		}

		static void n_Set49_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set49 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set49_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set49' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set49", "(Ljava/lang/String;)V", "GetSet49_Ljava_lang_String_Handler")]
		public virtual unsafe void Set49 (string p0)
		{
			if (id_set49_Ljava_lang_String_ == IntPtr.Zero)
				id_set49_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set49", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set49_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set49", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set4_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet4_Ljava_lang_String_Handler ()
		{
			if (cb_set4_Ljava_lang_String_ == null)
				cb_set4_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set4_Ljava_lang_String_);
			return cb_set4_Ljava_lang_String_;
		}

		static void n_Set4_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set4 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set4_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set4' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set4", "(Ljava/lang/String;)V", "GetSet4_Ljava_lang_String_Handler")]
		public virtual unsafe void Set4 (string p0)
		{
			if (id_set4_Ljava_lang_String_ == IntPtr.Zero)
				id_set4_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set4", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set4_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set4", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set50_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet50_Ljava_lang_String_Handler ()
		{
			if (cb_set50_Ljava_lang_String_ == null)
				cb_set50_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set50_Ljava_lang_String_);
			return cb_set50_Ljava_lang_String_;
		}

		static void n_Set50_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set50 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set50_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set50' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set50", "(Ljava/lang/String;)V", "GetSet50_Ljava_lang_String_Handler")]
		public virtual unsafe void Set50 (string p0)
		{
			if (id_set50_Ljava_lang_String_ == IntPtr.Zero)
				id_set50_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set50", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set50_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set50", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set51_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet51_Ljava_lang_String_Handler ()
		{
			if (cb_set51_Ljava_lang_String_ == null)
				cb_set51_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set51_Ljava_lang_String_);
			return cb_set51_Ljava_lang_String_;
		}

		static void n_Set51_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set51 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set51_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set51' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set51", "(Ljava/lang/String;)V", "GetSet51_Ljava_lang_String_Handler")]
		public virtual unsafe void Set51 (string p0)
		{
			if (id_set51_Ljava_lang_String_ == IntPtr.Zero)
				id_set51_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set51", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set51_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set51", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set52_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet52_Ljava_lang_String_Handler ()
		{
			if (cb_set52_Ljava_lang_String_ == null)
				cb_set52_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set52_Ljava_lang_String_);
			return cb_set52_Ljava_lang_String_;
		}

		static void n_Set52_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set52 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set52_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set52' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set52", "(Ljava/lang/String;)V", "GetSet52_Ljava_lang_String_Handler")]
		public virtual unsafe void Set52 (string p0)
		{
			if (id_set52_Ljava_lang_String_ == IntPtr.Zero)
				id_set52_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set52", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set52_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set52", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set53_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet53_Ljava_lang_String_Handler ()
		{
			if (cb_set53_Ljava_lang_String_ == null)
				cb_set53_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set53_Ljava_lang_String_);
			return cb_set53_Ljava_lang_String_;
		}

		static void n_Set53_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set53 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set53_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set53' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set53", "(Ljava/lang/String;)V", "GetSet53_Ljava_lang_String_Handler")]
		public virtual unsafe void Set53 (string p0)
		{
			if (id_set53_Ljava_lang_String_ == IntPtr.Zero)
				id_set53_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set53", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set53_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set53", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set54_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet54_Ljava_lang_String_Handler ()
		{
			if (cb_set54_Ljava_lang_String_ == null)
				cb_set54_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set54_Ljava_lang_String_);
			return cb_set54_Ljava_lang_String_;
		}

		static void n_Set54_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set54 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set54_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set54' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set54", "(Ljava/lang/String;)V", "GetSet54_Ljava_lang_String_Handler")]
		public virtual unsafe void Set54 (string p0)
		{
			if (id_set54_Ljava_lang_String_ == IntPtr.Zero)
				id_set54_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set54", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set54_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set54", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set55_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet55_Ljava_lang_String_Handler ()
		{
			if (cb_set55_Ljava_lang_String_ == null)
				cb_set55_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set55_Ljava_lang_String_);
			return cb_set55_Ljava_lang_String_;
		}

		static void n_Set55_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set55 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set55_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set55' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set55", "(Ljava/lang/String;)V", "GetSet55_Ljava_lang_String_Handler")]
		public virtual unsafe void Set55 (string p0)
		{
			if (id_set55_Ljava_lang_String_ == IntPtr.Zero)
				id_set55_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set55", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set55_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set55", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set56_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet56_Ljava_lang_String_Handler ()
		{
			if (cb_set56_Ljava_lang_String_ == null)
				cb_set56_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set56_Ljava_lang_String_);
			return cb_set56_Ljava_lang_String_;
		}

		static void n_Set56_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set56 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set56_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set56' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set56", "(Ljava/lang/String;)V", "GetSet56_Ljava_lang_String_Handler")]
		public virtual unsafe void Set56 (string p0)
		{
			if (id_set56_Ljava_lang_String_ == IntPtr.Zero)
				id_set56_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set56", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set56_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set56", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set57_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet57_Ljava_lang_String_Handler ()
		{
			if (cb_set57_Ljava_lang_String_ == null)
				cb_set57_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set57_Ljava_lang_String_);
			return cb_set57_Ljava_lang_String_;
		}

		static void n_Set57_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set57 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set57_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set57' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set57", "(Ljava/lang/String;)V", "GetSet57_Ljava_lang_String_Handler")]
		public virtual unsafe void Set57 (string p0)
		{
			if (id_set57_Ljava_lang_String_ == IntPtr.Zero)
				id_set57_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set57", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set57_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set57", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set58_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet58_Ljava_lang_String_Handler ()
		{
			if (cb_set58_Ljava_lang_String_ == null)
				cb_set58_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set58_Ljava_lang_String_);
			return cb_set58_Ljava_lang_String_;
		}

		static void n_Set58_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set58 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set58_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set58' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set58", "(Ljava/lang/String;)V", "GetSet58_Ljava_lang_String_Handler")]
		public virtual unsafe void Set58 (string p0)
		{
			if (id_set58_Ljava_lang_String_ == IntPtr.Zero)
				id_set58_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set58", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set58_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set58", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set59_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet59_Ljava_lang_String_Handler ()
		{
			if (cb_set59_Ljava_lang_String_ == null)
				cb_set59_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set59_Ljava_lang_String_);
			return cb_set59_Ljava_lang_String_;
		}

		static void n_Set59_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set59 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set59_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set59' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set59", "(Ljava/lang/String;)V", "GetSet59_Ljava_lang_String_Handler")]
		public virtual unsafe void Set59 (string p0)
		{
			if (id_set59_Ljava_lang_String_ == IntPtr.Zero)
				id_set59_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set59", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set59_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set59", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set5_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet5_Ljava_lang_String_Handler ()
		{
			if (cb_set5_Ljava_lang_String_ == null)
				cb_set5_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set5_Ljava_lang_String_);
			return cb_set5_Ljava_lang_String_;
		}

		static void n_Set5_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set5 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set5_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set5' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set5", "(Ljava/lang/String;)V", "GetSet5_Ljava_lang_String_Handler")]
		public virtual unsafe void Set5 (string p0)
		{
			if (id_set5_Ljava_lang_String_ == IntPtr.Zero)
				id_set5_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set5", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set5_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set5", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set60_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet60_Ljava_lang_String_Handler ()
		{
			if (cb_set60_Ljava_lang_String_ == null)
				cb_set60_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set60_Ljava_lang_String_);
			return cb_set60_Ljava_lang_String_;
		}

		static void n_Set60_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set60 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set60_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set60' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set60", "(Ljava/lang/String;)V", "GetSet60_Ljava_lang_String_Handler")]
		public virtual unsafe void Set60 (string p0)
		{
			if (id_set60_Ljava_lang_String_ == IntPtr.Zero)
				id_set60_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set60", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set60_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set60", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set61_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet61_Ljava_lang_String_Handler ()
		{
			if (cb_set61_Ljava_lang_String_ == null)
				cb_set61_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set61_Ljava_lang_String_);
			return cb_set61_Ljava_lang_String_;
		}

		static void n_Set61_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set61 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set61_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set61' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set61", "(Ljava/lang/String;)V", "GetSet61_Ljava_lang_String_Handler")]
		public virtual unsafe void Set61 (string p0)
		{
			if (id_set61_Ljava_lang_String_ == IntPtr.Zero)
				id_set61_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set61", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set61_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set61", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set62_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet62_Ljava_lang_String_Handler ()
		{
			if (cb_set62_Ljava_lang_String_ == null)
				cb_set62_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set62_Ljava_lang_String_);
			return cb_set62_Ljava_lang_String_;
		}

		static void n_Set62_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set62 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set62_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set62' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set62", "(Ljava/lang/String;)V", "GetSet62_Ljava_lang_String_Handler")]
		public virtual unsafe void Set62 (string p0)
		{
			if (id_set62_Ljava_lang_String_ == IntPtr.Zero)
				id_set62_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set62", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set62_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set62", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set63_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet63_Ljava_lang_String_Handler ()
		{
			if (cb_set63_Ljava_lang_String_ == null)
				cb_set63_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set63_Ljava_lang_String_);
			return cb_set63_Ljava_lang_String_;
		}

		static void n_Set63_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set63 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set63_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set63' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set63", "(Ljava/lang/String;)V", "GetSet63_Ljava_lang_String_Handler")]
		public virtual unsafe void Set63 (string p0)
		{
			if (id_set63_Ljava_lang_String_ == IntPtr.Zero)
				id_set63_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set63", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set63_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set63", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set64_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet64_Ljava_lang_String_Handler ()
		{
			if (cb_set64_Ljava_lang_String_ == null)
				cb_set64_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set64_Ljava_lang_String_);
			return cb_set64_Ljava_lang_String_;
		}

		static void n_Set64_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set64 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set64_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set64' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set64", "(Ljava/lang/String;)V", "GetSet64_Ljava_lang_String_Handler")]
		public virtual unsafe void Set64 (string p0)
		{
			if (id_set64_Ljava_lang_String_ == IntPtr.Zero)
				id_set64_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set64", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set64_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set64", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set65_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet65_Ljava_lang_String_Handler ()
		{
			if (cb_set65_Ljava_lang_String_ == null)
				cb_set65_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set65_Ljava_lang_String_);
			return cb_set65_Ljava_lang_String_;
		}

		static void n_Set65_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set65 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set65_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set65' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set65", "(Ljava/lang/String;)V", "GetSet65_Ljava_lang_String_Handler")]
		public virtual unsafe void Set65 (string p0)
		{
			if (id_set65_Ljava_lang_String_ == IntPtr.Zero)
				id_set65_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set65", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set65_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set65", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set66_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet66_Ljava_lang_String_Handler ()
		{
			if (cb_set66_Ljava_lang_String_ == null)
				cb_set66_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set66_Ljava_lang_String_);
			return cb_set66_Ljava_lang_String_;
		}

		static void n_Set66_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set66 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set66_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set66' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set66", "(Ljava/lang/String;)V", "GetSet66_Ljava_lang_String_Handler")]
		public virtual unsafe void Set66 (string p0)
		{
			if (id_set66_Ljava_lang_String_ == IntPtr.Zero)
				id_set66_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set66", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set66_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set66", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set67_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet67_Ljava_lang_String_Handler ()
		{
			if (cb_set67_Ljava_lang_String_ == null)
				cb_set67_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set67_Ljava_lang_String_);
			return cb_set67_Ljava_lang_String_;
		}

		static void n_Set67_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set67 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set67_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set67' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set67", "(Ljava/lang/String;)V", "GetSet67_Ljava_lang_String_Handler")]
		public virtual unsafe void Set67 (string p0)
		{
			if (id_set67_Ljava_lang_String_ == IntPtr.Zero)
				id_set67_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set67", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set67_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set67", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set68_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet68_Ljava_lang_String_Handler ()
		{
			if (cb_set68_Ljava_lang_String_ == null)
				cb_set68_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set68_Ljava_lang_String_);
			return cb_set68_Ljava_lang_String_;
		}

		static void n_Set68_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set68 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set68_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set68' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set68", "(Ljava/lang/String;)V", "GetSet68_Ljava_lang_String_Handler")]
		public virtual unsafe void Set68 (string p0)
		{
			if (id_set68_Ljava_lang_String_ == IntPtr.Zero)
				id_set68_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set68", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set68_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set68", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set69_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet69_Ljava_lang_String_Handler ()
		{
			if (cb_set69_Ljava_lang_String_ == null)
				cb_set69_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set69_Ljava_lang_String_);
			return cb_set69_Ljava_lang_String_;
		}

		static void n_Set69_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set69 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set69_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set69' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set69", "(Ljava/lang/String;)V", "GetSet69_Ljava_lang_String_Handler")]
		public virtual unsafe void Set69 (string p0)
		{
			if (id_set69_Ljava_lang_String_ == IntPtr.Zero)
				id_set69_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set69", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set69_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set69", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set6_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet6_Ljava_lang_String_Handler ()
		{
			if (cb_set6_Ljava_lang_String_ == null)
				cb_set6_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set6_Ljava_lang_String_);
			return cb_set6_Ljava_lang_String_;
		}

		static void n_Set6_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set6 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set6_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set6' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set6", "(Ljava/lang/String;)V", "GetSet6_Ljava_lang_String_Handler")]
		public virtual unsafe void Set6 (string p0)
		{
			if (id_set6_Ljava_lang_String_ == IntPtr.Zero)
				id_set6_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set6", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set6_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set6", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set70_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet70_Ljava_lang_String_Handler ()
		{
			if (cb_set70_Ljava_lang_String_ == null)
				cb_set70_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set70_Ljava_lang_String_);
			return cb_set70_Ljava_lang_String_;
		}

		static void n_Set70_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set70 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set70_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set70' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set70", "(Ljava/lang/String;)V", "GetSet70_Ljava_lang_String_Handler")]
		public virtual unsafe void Set70 (string p0)
		{
			if (id_set70_Ljava_lang_String_ == IntPtr.Zero)
				id_set70_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set70", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set70_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set70", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set71_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet71_Ljava_lang_String_Handler ()
		{
			if (cb_set71_Ljava_lang_String_ == null)
				cb_set71_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set71_Ljava_lang_String_);
			return cb_set71_Ljava_lang_String_;
		}

		static void n_Set71_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set71 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set71_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set71' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set71", "(Ljava/lang/String;)V", "GetSet71_Ljava_lang_String_Handler")]
		public virtual unsafe void Set71 (string p0)
		{
			if (id_set71_Ljava_lang_String_ == IntPtr.Zero)
				id_set71_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set71", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set71_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set71", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set72_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet72_Ljava_lang_String_Handler ()
		{
			if (cb_set72_Ljava_lang_String_ == null)
				cb_set72_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set72_Ljava_lang_String_);
			return cb_set72_Ljava_lang_String_;
		}

		static void n_Set72_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set72 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set72_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set72' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set72", "(Ljava/lang/String;)V", "GetSet72_Ljava_lang_String_Handler")]
		public virtual unsafe void Set72 (string p0)
		{
			if (id_set72_Ljava_lang_String_ == IntPtr.Zero)
				id_set72_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set72", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set72_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set72", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set73_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet73_Ljava_lang_String_Handler ()
		{
			if (cb_set73_Ljava_lang_String_ == null)
				cb_set73_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set73_Ljava_lang_String_);
			return cb_set73_Ljava_lang_String_;
		}

		static void n_Set73_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set73 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set73_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set73' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set73", "(Ljava/lang/String;)V", "GetSet73_Ljava_lang_String_Handler")]
		public virtual unsafe void Set73 (string p0)
		{
			if (id_set73_Ljava_lang_String_ == IntPtr.Zero)
				id_set73_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set73", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set73_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set73", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set74_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet74_Ljava_lang_String_Handler ()
		{
			if (cb_set74_Ljava_lang_String_ == null)
				cb_set74_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set74_Ljava_lang_String_);
			return cb_set74_Ljava_lang_String_;
		}

		static void n_Set74_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set74 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set74_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set74' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set74", "(Ljava/lang/String;)V", "GetSet74_Ljava_lang_String_Handler")]
		public virtual unsafe void Set74 (string p0)
		{
			if (id_set74_Ljava_lang_String_ == IntPtr.Zero)
				id_set74_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set74", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set74_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set74", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set75_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet75_Ljava_lang_String_Handler ()
		{
			if (cb_set75_Ljava_lang_String_ == null)
				cb_set75_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set75_Ljava_lang_String_);
			return cb_set75_Ljava_lang_String_;
		}

		static void n_Set75_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set75 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set75_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set75' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set75", "(Ljava/lang/String;)V", "GetSet75_Ljava_lang_String_Handler")]
		public virtual unsafe void Set75 (string p0)
		{
			if (id_set75_Ljava_lang_String_ == IntPtr.Zero)
				id_set75_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set75", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set75_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set75", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set76_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet76_Ljava_lang_String_Handler ()
		{
			if (cb_set76_Ljava_lang_String_ == null)
				cb_set76_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set76_Ljava_lang_String_);
			return cb_set76_Ljava_lang_String_;
		}

		static void n_Set76_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set76 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set76_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set76' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set76", "(Ljava/lang/String;)V", "GetSet76_Ljava_lang_String_Handler")]
		public virtual unsafe void Set76 (string p0)
		{
			if (id_set76_Ljava_lang_String_ == IntPtr.Zero)
				id_set76_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set76", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set76_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set76", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set7_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet7_Ljava_lang_String_Handler ()
		{
			if (cb_set7_Ljava_lang_String_ == null)
				cb_set7_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set7_Ljava_lang_String_);
			return cb_set7_Ljava_lang_String_;
		}

		static void n_Set7_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set7 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set7_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set7' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set7", "(Ljava/lang/String;)V", "GetSet7_Ljava_lang_String_Handler")]
		public virtual unsafe void Set7 (string p0)
		{
			if (id_set7_Ljava_lang_String_ == IntPtr.Zero)
				id_set7_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set7", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set7_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set7", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set8_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet8_Ljava_lang_String_Handler ()
		{
			if (cb_set8_Ljava_lang_String_ == null)
				cb_set8_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set8_Ljava_lang_String_);
			return cb_set8_Ljava_lang_String_;
		}

		static void n_Set8_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set8 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set8_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set8' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set8", "(Ljava/lang/String;)V", "GetSet8_Ljava_lang_String_Handler")]
		public virtual unsafe void Set8 (string p0)
		{
			if (id_set8_Ljava_lang_String_ == IntPtr.Zero)
				id_set8_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set8", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set8_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set8", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_set9_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSet9_Ljava_lang_String_Handler ()
		{
			if (cb_set9_Ljava_lang_String_ == null)
				cb_set9_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Set9_Ljava_lang_String_);
			return cb_set9_Ljava_lang_String_;
		}

		static void n_Set9_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Core __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Set9 (p0);
		}
#pragma warning restore 0169

		static IntPtr id_set9_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Core']/method[@name='set9' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("set9", "(Ljava/lang/String;)V", "GetSet9_Ljava_lang_String_Handler")]
		public virtual unsafe void Set9 (string p0)
		{
			if (id_set9_Ljava_lang_String_ == IntPtr.Zero)
				id_set9_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "set9", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_set9_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "set9", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
