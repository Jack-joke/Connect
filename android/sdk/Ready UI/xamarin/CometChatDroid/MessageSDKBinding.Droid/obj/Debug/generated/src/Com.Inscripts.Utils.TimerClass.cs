using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.utils']/class[@name='TimerClass']"
	[global::Android.Runtime.Register ("com/inscripts/utils/TimerClass", DoNotGenerateAcw=true)]
	public partial class TimerClass : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/utils/TimerClass", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (TimerClass); }
		}

		protected TimerClass (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_J;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.utils']/class[@name='TimerClass']/constructor[@name='TimerClass' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register (".ctor", "(J)V", "")]
		public unsafe TimerClass (long p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (TimerClass)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(J)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(J)V", __args);
					return;
				}

				if (id_ctor_J == IntPtr.Zero)
					id_ctor_J = JNIEnv.GetMethodID (class_ref, "<init>", "(J)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_J, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_J, __args);
			} finally {
			}
		}

		static Delegate cb_setId_J;
#pragma warning disable 0169
		static Delegate GetSetId_JHandler ()
		{
			if (cb_setId_J == null)
				cb_setId_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetId_J);
			return cb_setId_J;
		}

		static void n_SetId_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Utils.TimerClass __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.TimerClass> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetId (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setId_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='TimerClass']/method[@name='setId' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("setId", "(J)V", "GetSetId_JHandler")]
		public virtual unsafe void SetId (long p0)
		{
			if (id_setId_J == IntPtr.Zero)
				id_setId_J = JNIEnv.GetMethodID (class_ref, "setId", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setId_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setId", "(J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
#pragma warning disable 0169
		static Delegate GetSetTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_Handler ()
		{
			if (cb_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ == null)
				cb_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_);
			return cb_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
		}

		static void n_SetTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.TimerClass __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.TimerClass> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks p0 = (global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetTimer (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='TimerClass']/method[@name='setTimer' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.VolleyAjaxCallbacks']]"
		[Register ("setTimer", "(Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", "GetSetTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_Handler")]
		public virtual unsafe void SetTimer (global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks p0)
		{
			if (id_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ == IntPtr.Zero)
				id_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ = JNIEnv.GetMethodID (class_ref, "setTimer", "(Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setTimer_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setTimer", "(Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V"), __args);
			} finally {
			}
		}

	}
}
