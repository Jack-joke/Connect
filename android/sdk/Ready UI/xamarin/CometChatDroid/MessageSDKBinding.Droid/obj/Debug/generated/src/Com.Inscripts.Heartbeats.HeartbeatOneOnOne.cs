using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Heartbeats {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']"
	[global::Android.Runtime.Register ("com/inscripts/heartbeats/HeartbeatOneOnOne", DoNotGenerateAcw=true)]
	public partial class HeartbeatOneOnOne : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/heartbeats/HeartbeatOneOnOne", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HeartbeatOneOnOne); }
		}

		protected HeartbeatOneOnOne (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/constructor[@name='HeartbeatOneOnOne' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HeartbeatOneOnOne ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HeartbeatOneOnOne)) {
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

		static IntPtr id_getInstance;
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/heartbeats/HeartbeatOneOnOne;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/heartbeats/HeartbeatOneOnOne;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getReadyUIListener;
#pragma warning disable 0169
		static Delegate GetGetReadyUIListenerHandler ()
		{
			if (cb_getReadyUIListener == null)
				cb_getReadyUIListener = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReadyUIListener);
			return cb_getReadyUIListener;
		}

		static IntPtr n_GetReadyUIListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ReadyUIListener);
		}
#pragma warning restore 0169

		static IntPtr id_getReadyUIListener;
		public virtual unsafe global::Com.Inscripts.Interfaces.ILoginCallbacks ReadyUIListener {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='getReadyUIListener' and count(parameter)=0]"
			[Register ("getReadyUIListener", "()Lcom/inscripts/interfaces/LoginCallbacks;", "GetGetReadyUIListenerHandler")]
			get {
				if (id_getReadyUIListener == IntPtr.Zero)
					id_getReadyUIListener = JNIEnv.GetMethodID (class_ref, "getReadyUIListener", "()Lcom/inscripts/interfaces/LoginCallbacks;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReadyUIListener), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReadyUIListener", "()Lcom/inscripts/interfaces/LoginCallbacks;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_changeOneOnOneHeartbeatInverval;
#pragma warning disable 0169
		static Delegate GetChangeOneOnOneHeartbeatInvervalHandler ()
		{
			if (cb_changeOneOnOneHeartbeatInverval == null)
				cb_changeOneOnOneHeartbeatInverval = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ChangeOneOnOneHeartbeatInverval);
			return cb_changeOneOnOneHeartbeatInverval;
		}

		static void n_ChangeOneOnOneHeartbeatInverval (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChangeOneOnOneHeartbeatInverval ();
		}
#pragma warning restore 0169

		static IntPtr id_changeOneOnOneHeartbeatInverval;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='changeOneOnOneHeartbeatInverval' and count(parameter)=0]"
		[Register ("changeOneOnOneHeartbeatInverval", "()V", "GetChangeOneOnOneHeartbeatInvervalHandler")]
		public virtual unsafe void ChangeOneOnOneHeartbeatInverval ()
		{
			if (id_changeOneOnOneHeartbeatInverval == IntPtr.Zero)
				id_changeOneOnOneHeartbeatInverval = JNIEnv.GetMethodID (class_ref, "changeOneOnOneHeartbeatInverval", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_changeOneOnOneHeartbeatInverval);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "changeOneOnOneHeartbeatInverval", "()V"));
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.LoginCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HeartbeatOneOnOne;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne GetInstance (global::Com.Inscripts.Interfaces.ILoginCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HeartbeatOneOnOne;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.SubscribeCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/SubscribeCallbacks;)Lcom/inscripts/heartbeats/HeartbeatOneOnOne;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne GetInstance (global::Com.Inscripts.Interfaces.ISubscribeCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/SubscribeCallbacks;)Lcom/inscripts/heartbeats/HeartbeatOneOnOne;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_startHeartbeat_Landroid_content_Context_;
#pragma warning disable 0169
		static Delegate GetStartHeartbeat_Landroid_content_Context_Handler ()
		{
			if (cb_startHeartbeat_Landroid_content_Context_ == null)
				cb_startHeartbeat_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_StartHeartbeat_Landroid_content_Context_);
			return cb_startHeartbeat_Landroid_content_Context_;
		}

		static void n_StartHeartbeat_Landroid_content_Context_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StartHeartbeat (p0);
		}
#pragma warning restore 0169

		static IntPtr id_startHeartbeat_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='startHeartbeat' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("startHeartbeat", "(Landroid/content/Context;)V", "GetStartHeartbeat_Landroid_content_Context_Handler")]
		public virtual unsafe void StartHeartbeat (global::Android.Content.Context p0)
		{
			if (id_startHeartbeat_Landroid_content_Context_ == IntPtr.Zero)
				id_startHeartbeat_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "startHeartbeat", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startHeartbeat_Landroid_content_Context_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startHeartbeat", "(Landroid/content/Context;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_stopHeartbeatOneOnOne;
#pragma warning disable 0169
		static Delegate GetStopHeartbeatOneOnOneHandler ()
		{
			if (cb_stopHeartbeatOneOnOne == null)
				cb_stopHeartbeatOneOnOne = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_StopHeartbeatOneOnOne);
			return cb_stopHeartbeatOneOnOne;
		}

		static void n_StopHeartbeatOneOnOne (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.StopHeartbeatOneOnOne ();
		}
#pragma warning restore 0169

		static IntPtr id_stopHeartbeatOneOnOne;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatOneOnOne']/method[@name='stopHeartbeatOneOnOne' and count(parameter)=0]"
		[Register ("stopHeartbeatOneOnOne", "()V", "GetStopHeartbeatOneOnOneHandler")]
		public virtual unsafe void StopHeartbeatOneOnOne ()
		{
			if (id_stopHeartbeatOneOnOne == IntPtr.Zero)
				id_stopHeartbeatOneOnOne = JNIEnv.GetMethodID (class_ref, "stopHeartbeatOneOnOne", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stopHeartbeatOneOnOne);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "stopHeartbeatOneOnOne", "()V"));
			} finally {
			}
		}

	}
}
