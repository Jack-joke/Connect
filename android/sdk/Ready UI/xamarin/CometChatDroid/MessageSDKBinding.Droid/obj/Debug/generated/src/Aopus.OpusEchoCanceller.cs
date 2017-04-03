using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Aopus {

	// Metadata.xml XPath class reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']"
	[global::Android.Runtime.Register ("aopus/OpusEchoCanceller", DoNotGenerateAcw=true)]
	public partial class OpusEchoCanceller : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("aopus/OpusEchoCanceller", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OpusEchoCanceller); }
		}

		protected OpusEchoCanceller (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_II;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']/constructor[@name='OpusEchoCanceller' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register (".ctor", "(II)V", "")]
		public unsafe OpusEchoCanceller (int p0, int p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (OpusEchoCanceller)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(II)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(II)V", __args);
					return;
				}

				if (id_ctor_II == IntPtr.Zero)
					id_ctor_II = JNIEnv.GetMethodID (class_ref, "<init>", "(II)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_II, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_II, __args);
			} finally {
			}
		}

		static Delegate cb_getAcousticEchoCanceller;
#pragma warning disable 0169
		static Delegate GetGetAcousticEchoCancellerHandler ()
		{
			if (cb_getAcousticEchoCanceller == null)
				cb_getAcousticEchoCanceller = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAcousticEchoCanceller);
			return cb_getAcousticEchoCanceller;
		}

		static IntPtr n_GetAcousticEchoCanceller (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.OpusEchoCanceller __this = global::Java.Lang.Object.GetObject<global::Aopus.OpusEchoCanceller> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.AcousticEchoCanceller);
		}
#pragma warning restore 0169

		static Delegate cb_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_;
#pragma warning disable 0169
		static Delegate GetSetAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_Handler ()
		{
			if (cb_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_ == null)
				cb_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_);
			return cb_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_;
		}

		static void n_SetAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Aopus.OpusEchoCanceller __this = global::Java.Lang.Object.GetObject<global::Aopus.OpusEchoCanceller> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Aaudioprocessing.AcousticEchoCanceller p0 = global::Java.Lang.Object.GetObject<global::Aaudioprocessing.AcousticEchoCanceller> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AcousticEchoCanceller = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAcousticEchoCanceller;
		static IntPtr id_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_;
		public virtual unsafe global::Aaudioprocessing.AcousticEchoCanceller AcousticEchoCanceller {
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']/method[@name='getAcousticEchoCanceller' and count(parameter)=0]"
			[Register ("getAcousticEchoCanceller", "()Laaudioprocessing/AcousticEchoCanceller;", "GetGetAcousticEchoCancellerHandler")]
			get {
				if (id_getAcousticEchoCanceller == IntPtr.Zero)
					id_getAcousticEchoCanceller = JNIEnv.GetMethodID (class_ref, "getAcousticEchoCanceller", "()Laaudioprocessing/AcousticEchoCanceller;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Aaudioprocessing.AcousticEchoCanceller> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAcousticEchoCanceller), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Aaudioprocessing.AcousticEchoCanceller> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAcousticEchoCanceller", "()Laaudioprocessing/AcousticEchoCanceller;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']/method[@name='setAcousticEchoCanceller' and count(parameter)=1 and parameter[1][@type='aaudioprocessing.AcousticEchoCanceller']]"
			[Register ("setAcousticEchoCanceller", "(Laaudioprocessing/AcousticEchoCanceller;)V", "GetSetAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_Handler")]
			set {
				if (id_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_ == IntPtr.Zero)
					id_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_ = JNIEnv.GetMethodID (class_ref, "setAcousticEchoCanceller", "(Laaudioprocessing/AcousticEchoCanceller;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAcousticEchoCanceller_Laaudioprocessing_AcousticEchoCanceller_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAcousticEchoCanceller", "(Laaudioprocessing/AcousticEchoCanceller;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_start;
#pragma warning disable 0169
		static Delegate GetStartHandler ()
		{
			if (cb_start == null)
				cb_start = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Start);
			return cb_start;
		}

		static void n_Start (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.OpusEchoCanceller __this = global::Java.Lang.Object.GetObject<global::Aopus.OpusEchoCanceller> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Start ();
		}
#pragma warning restore 0169

		static IntPtr id_start;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']/method[@name='start' and count(parameter)=0]"
		[Register ("start", "()V", "GetStartHandler")]
		public virtual unsafe void Start ()
		{
			if (id_start == IntPtr.Zero)
				id_start = JNIEnv.GetMethodID (class_ref, "start", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_start);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "start", "()V"));
			} finally {
			}
		}

		static Delegate cb_stop;
#pragma warning disable 0169
		static Delegate GetStopHandler ()
		{
			if (cb_stop == null)
				cb_stop = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Stop);
			return cb_stop;
		}

		static void n_Stop (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.OpusEchoCanceller __this = global::Java.Lang.Object.GetObject<global::Aopus.OpusEchoCanceller> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Stop ();
		}
#pragma warning restore 0169

		static IntPtr id_stop;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusEchoCanceller']/method[@name='stop' and count(parameter)=0]"
		[Register ("stop", "()V", "GetStopHandler")]
		public virtual unsafe void Stop ()
		{
			if (id_stop == IntPtr.Zero)
				id_stop = JNIEnv.GetMethodID (class_ref, "stop", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stop);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "stop", "()V"));
			} finally {
			}
		}

	}
}
