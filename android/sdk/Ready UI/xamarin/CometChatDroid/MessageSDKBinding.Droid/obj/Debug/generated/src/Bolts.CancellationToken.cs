using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='CancellationToken']"
	[global::Android.Runtime.Register ("bolts/CancellationToken", DoNotGenerateAcw=true)]
	public partial class CancellationToken : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("bolts/CancellationToken", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CancellationToken); }
		}

		protected CancellationToken (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_isCancellationRequested;
#pragma warning disable 0169
		static Delegate GetIsCancellationRequestedHandler ()
		{
			if (cb_isCancellationRequested == null)
				cb_isCancellationRequested = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsCancellationRequested);
			return cb_isCancellationRequested;
		}

		static bool n_IsCancellationRequested (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.CancellationToken __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCancellationRequested;
		}
#pragma warning restore 0169

		static IntPtr id_isCancellationRequested;
		public virtual unsafe bool IsCancellationRequested {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationToken']/method[@name='isCancellationRequested' and count(parameter)=0]"
			[Register ("isCancellationRequested", "()Z", "GetIsCancellationRequestedHandler")]
			get {
				if (id_isCancellationRequested == IntPtr.Zero)
					id_isCancellationRequested = JNIEnv.GetMethodID (class_ref, "isCancellationRequested", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCancellationRequested);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCancellationRequested", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_register_Ljava_lang_Runnable_;
#pragma warning disable 0169
		static Delegate GetRegister_Ljava_lang_Runnable_Handler ()
		{
			if (cb_register_Ljava_lang_Runnable_ == null)
				cb_register_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Register_Ljava_lang_Runnable_);
			return cb_register_Ljava_lang_Runnable_;
		}

		static IntPtr n_Register_Ljava_lang_Runnable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.CancellationToken __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.IRunnable p0 = (global::Java.Lang.IRunnable)global::Java.Lang.Object.GetObject<global::Java.Lang.IRunnable> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Register (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_register_Ljava_lang_Runnable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationToken']/method[@name='register' and count(parameter)=1 and parameter[1][@type='java.lang.Runnable']]"
		[Register ("register", "(Ljava/lang/Runnable;)Lbolts/CancellationTokenRegistration;", "GetRegister_Ljava_lang_Runnable_Handler")]
		public virtual unsafe global::Bolts.CancellationTokenRegistration Register (global::Java.Lang.IRunnable p0)
		{
			if (id_register_Ljava_lang_Runnable_ == IntPtr.Zero)
				id_register_Ljava_lang_Runnable_ = JNIEnv.GetMethodID (class_ref, "register", "(Ljava/lang/Runnable;)Lbolts/CancellationTokenRegistration;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Bolts.CancellationTokenRegistration __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenRegistration> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_register_Ljava_lang_Runnable_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenRegistration> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "register", "(Ljava/lang/Runnable;)Lbolts/CancellationTokenRegistration;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_throwIfCancellationRequested;
#pragma warning disable 0169
		static Delegate GetThrowIfCancellationRequestedHandler ()
		{
			if (cb_throwIfCancellationRequested == null)
				cb_throwIfCancellationRequested = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ThrowIfCancellationRequested);
			return cb_throwIfCancellationRequested;
		}

		static void n_ThrowIfCancellationRequested (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.CancellationToken __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ThrowIfCancellationRequested ();
		}
#pragma warning restore 0169

		static IntPtr id_throwIfCancellationRequested;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationToken']/method[@name='throwIfCancellationRequested' and count(parameter)=0]"
		[Register ("throwIfCancellationRequested", "()V", "GetThrowIfCancellationRequestedHandler")]
		public virtual unsafe void ThrowIfCancellationRequested ()
		{
			if (id_throwIfCancellationRequested == IntPtr.Zero)
				id_throwIfCancellationRequested = JNIEnv.GetMethodID (class_ref, "throwIfCancellationRequested", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_throwIfCancellationRequested);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "throwIfCancellationRequested", "()V"));
			} finally {
			}
		}

	}
}
