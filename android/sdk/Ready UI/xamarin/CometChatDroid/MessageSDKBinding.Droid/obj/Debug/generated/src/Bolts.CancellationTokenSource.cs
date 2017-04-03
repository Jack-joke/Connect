using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']"
	[global::Android.Runtime.Register ("bolts/CancellationTokenSource", DoNotGenerateAcw=true)]
	public partial class CancellationTokenSource : global::Java.Lang.Object, global::Java.IO.ICloseable {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("bolts/CancellationTokenSource", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CancellationTokenSource); }
		}

		protected CancellationTokenSource (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/constructor[@name='CancellationTokenSource' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CancellationTokenSource ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CancellationTokenSource)) {
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
			global::Bolts.CancellationTokenSource __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCancellationRequested;
		}
#pragma warning restore 0169

		static IntPtr id_isCancellationRequested;
		public virtual unsafe bool IsCancellationRequested {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/method[@name='isCancellationRequested' and count(parameter)=0]"
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

		static Delegate cb_getToken;
#pragma warning disable 0169
		static Delegate GetGetTokenHandler ()
		{
			if (cb_getToken == null)
				cb_getToken = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetToken);
			return cb_getToken;
		}

		static IntPtr n_GetToken (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.CancellationTokenSource __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Token);
		}
#pragma warning restore 0169

		static IntPtr id_getToken;
		public virtual unsafe global::Bolts.CancellationToken Token {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/method[@name='getToken' and count(parameter)=0]"
			[Register ("getToken", "()Lbolts/CancellationToken;", "GetGetTokenHandler")]
			get {
				if (id_getToken == IntPtr.Zero)
					id_getToken = JNIEnv.GetMethodID (class_ref, "getToken", "()Lbolts/CancellationToken;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getToken), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getToken", "()Lbolts/CancellationToken;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_cancel;
#pragma warning disable 0169
		static Delegate GetCancelHandler ()
		{
			if (cb_cancel == null)
				cb_cancel = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Cancel);
			return cb_cancel;
		}

		static void n_Cancel (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.CancellationTokenSource __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Cancel ();
		}
#pragma warning restore 0169

		static IntPtr id_cancel;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/method[@name='cancel' and count(parameter)=0]"
		[Register ("cancel", "()V", "GetCancelHandler")]
		public virtual unsafe void Cancel ()
		{
			if (id_cancel == IntPtr.Zero)
				id_cancel = JNIEnv.GetMethodID (class_ref, "cancel", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_cancel);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancel", "()V"));
			} finally {
			}
		}

		static Delegate cb_cancelAfter_J;
#pragma warning disable 0169
		static Delegate GetCancelAfter_JHandler ()
		{
			if (cb_cancelAfter_J == null)
				cb_cancelAfter_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_CancelAfter_J);
			return cb_cancelAfter_J;
		}

		static void n_CancelAfter_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Bolts.CancellationTokenSource __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.CancelAfter (p0);
		}
#pragma warning restore 0169

		static IntPtr id_cancelAfter_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/method[@name='cancelAfter' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("cancelAfter", "(J)V", "GetCancelAfter_JHandler")]
		public virtual unsafe void CancelAfter (long p0)
		{
			if (id_cancelAfter_J == IntPtr.Zero)
				id_cancelAfter_J = JNIEnv.GetMethodID (class_ref, "cancelAfter", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_cancelAfter_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelAfter", "(J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_close;
#pragma warning disable 0169
		static Delegate GetCloseHandler ()
		{
			if (cb_close == null)
				cb_close = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Close);
			return cb_close;
		}

		static void n_Close (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.CancellationTokenSource __this = global::Java.Lang.Object.GetObject<global::Bolts.CancellationTokenSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Close ();
		}
#pragma warning restore 0169

		static IntPtr id_close;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='CancellationTokenSource']/method[@name='close' and count(parameter)=0]"
		[Register ("close", "()V", "GetCloseHandler")]
		public virtual unsafe void Close ()
		{
			if (id_close == IntPtr.Zero)
				id_close = JNIEnv.GetMethodID (class_ref, "close", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_close);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "close", "()V"));
			} finally {
			}
		}

	}
}
