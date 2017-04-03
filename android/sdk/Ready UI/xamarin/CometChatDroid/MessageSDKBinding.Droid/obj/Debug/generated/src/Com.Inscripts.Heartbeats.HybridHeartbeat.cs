using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Heartbeats {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']"
	[global::Android.Runtime.Register ("com/inscripts/heartbeats/HybridHeartbeat", DoNotGenerateAcw=true)]
	public partial class HybridHeartbeat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/heartbeats/HybridHeartbeat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HybridHeartbeat); }
		}

		protected HybridHeartbeat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/constructor[@name='HybridHeartbeat' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HybridHeartbeat ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HybridHeartbeat)) {
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
		public static unsafe global::Com.Inscripts.Heartbeats.HybridHeartbeat Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/heartbeats/HybridHeartbeat;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/heartbeats/HybridHeartbeat;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_changeHybridHeartbeatInverval;
#pragma warning disable 0169
		static Delegate GetChangeHybridHeartbeatInvervalHandler ()
		{
			if (cb_changeHybridHeartbeatInverval == null)
				cb_changeHybridHeartbeatInverval = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ChangeHybridHeartbeatInverval);
			return cb_changeHybridHeartbeatInverval;
		}

		static void n_ChangeHybridHeartbeatInverval (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HybridHeartbeat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChangeHybridHeartbeatInverval ();
		}
#pragma warning restore 0169

		static IntPtr id_changeHybridHeartbeatInverval;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='changeHybridHeartbeatInverval' and count(parameter)=0]"
		[Register ("changeHybridHeartbeatInverval", "()V", "GetChangeHybridHeartbeatInvervalHandler")]
		public virtual unsafe void ChangeHybridHeartbeatInverval ()
		{
			if (id_changeHybridHeartbeatInverval == IntPtr.Zero)
				id_changeHybridHeartbeatInverval = JNIEnv.GetMethodID (class_ref, "changeHybridHeartbeatInverval", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_changeHybridHeartbeatInverval);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "changeHybridHeartbeatInverval", "()V"));
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.LoginCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HybridHeartbeat GetInstance (global::Com.Inscripts.Interfaces.ILoginCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HybridHeartbeat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.SubscribeCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/SubscribeCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HybridHeartbeat GetInstance (global::Com.Inscripts.Interfaces.ISubscribeCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/SubscribeCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HybridHeartbeat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_SubscribeCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HybridHeartbeat GetInstance (global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)Lcom/inscripts/heartbeats/HybridHeartbeat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HybridHeartbeat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_setForceHeartbeat;
#pragma warning disable 0169
		static Delegate GetSetForceHeartbeatHandler ()
		{
			if (cb_setForceHeartbeat == null)
				cb_setForceHeartbeat = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetForceHeartbeat);
			return cb_setForceHeartbeat;
		}

		static void n_SetForceHeartbeat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HybridHeartbeat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetForceHeartbeat ();
		}
#pragma warning restore 0169

		static IntPtr id_setForceHeartbeat;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='setForceHeartbeat' and count(parameter)=0]"
		[Register ("setForceHeartbeat", "()V", "GetSetForceHeartbeatHandler")]
		public virtual unsafe void SetForceHeartbeat ()
		{
			if (id_setForceHeartbeat == IntPtr.Zero)
				id_setForceHeartbeat = JNIEnv.GetMethodID (class_ref, "setForceHeartbeat", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setForceHeartbeat);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setForceHeartbeat", "()V"));
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
			global::Com.Inscripts.Heartbeats.HybridHeartbeat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StartHeartbeat (p0);
		}
#pragma warning restore 0169

		static IntPtr id_startHeartbeat_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='startHeartbeat' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
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

		static Delegate cb_stopHeartbeatHybrid;
#pragma warning disable 0169
		static Delegate GetStopHeartbeatHybridHandler ()
		{
			if (cb_stopHeartbeatHybrid == null)
				cb_stopHeartbeatHybrid = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_StopHeartbeatHybrid);
			return cb_stopHeartbeatHybrid;
		}

		static void n_StopHeartbeatHybrid (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HybridHeartbeat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HybridHeartbeat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.StopHeartbeatHybrid ();
		}
#pragma warning restore 0169

		static IntPtr id_stopHeartbeatHybrid;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HybridHeartbeat']/method[@name='stopHeartbeatHybrid' and count(parameter)=0]"
		[Register ("stopHeartbeatHybrid", "()V", "GetStopHeartbeatHybridHandler")]
		public virtual unsafe void StopHeartbeatHybrid ()
		{
			if (id_stopHeartbeatHybrid == IntPtr.Zero)
				id_stopHeartbeatHybrid = JNIEnv.GetMethodID (class_ref, "stopHeartbeatHybrid", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stopHeartbeatHybrid);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "stopHeartbeatHybrid", "()V"));
			} finally {
			}
		}

	}
}
