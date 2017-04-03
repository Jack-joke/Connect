using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Heartbeats {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']"
	[global::Android.Runtime.Register ("com/inscripts/heartbeats/HeartbeatChatroom", DoNotGenerateAcw=true)]
	public partial class HeartbeatChatroom : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/heartbeats/HeartbeatChatroom", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HeartbeatChatroom); }
		}

		protected HeartbeatChatroom (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/constructor[@name='HeartbeatChatroom' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HeartbeatChatroom ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HeartbeatChatroom)) {
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
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatChatroom Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/heartbeats/HeartbeatChatroom;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/heartbeats/HeartbeatChatroom;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getReadyUIListner;
#pragma warning disable 0169
		static Delegate GetGetReadyUIListnerHandler ()
		{
			if (cb_getReadyUIListner == null)
				cb_getReadyUIListner = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReadyUIListner);
			return cb_getReadyUIListner;
		}

		static IntPtr n_GetReadyUIListner (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ReadyUIListner);
		}
#pragma warning restore 0169

		static IntPtr id_getReadyUIListner;
		public virtual unsafe global::Com.Inscripts.Interfaces.ILoginCallbacks ReadyUIListner {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='getReadyUIListner' and count(parameter)=0]"
			[Register ("getReadyUIListner", "()Lcom/inscripts/interfaces/LoginCallbacks;", "GetGetReadyUIListnerHandler")]
			get {
				if (id_getReadyUIListner == IntPtr.Zero)
					id_getReadyUIListner = JNIEnv.GetMethodID (class_ref, "getReadyUIListner", "()Lcom/inscripts/interfaces/LoginCallbacks;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReadyUIListner), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReadyUIListner", "()Lcom/inscripts/interfaces/LoginCallbacks;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_changeChatroomHeartbeatInverval;
#pragma warning disable 0169
		static Delegate GetChangeChatroomHeartbeatInvervalHandler ()
		{
			if (cb_changeChatroomHeartbeatInverval == null)
				cb_changeChatroomHeartbeatInverval = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ChangeChatroomHeartbeatInverval);
			return cb_changeChatroomHeartbeatInverval;
		}

		static void n_ChangeChatroomHeartbeatInverval (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChangeChatroomHeartbeatInverval ();
		}
#pragma warning restore 0169

		static IntPtr id_changeChatroomHeartbeatInverval;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='changeChatroomHeartbeatInverval' and count(parameter)=0]"
		[Register ("changeChatroomHeartbeatInverval", "()V", "GetChangeChatroomHeartbeatInvervalHandler")]
		public virtual unsafe void ChangeChatroomHeartbeatInverval ()
		{
			if (id_changeChatroomHeartbeatInverval == IntPtr.Zero)
				id_changeChatroomHeartbeatInverval = JNIEnv.GetMethodID (class_ref, "changeChatroomHeartbeatInverval", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_changeChatroomHeartbeatInverval);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "changeChatroomHeartbeatInverval", "()V"));
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.LoginCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HeartbeatChatroom;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatChatroom GetInstance (global::Com.Inscripts.Interfaces.ILoginCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/LoginCallbacks;)Lcom/inscripts/heartbeats/HeartbeatChatroom;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HeartbeatChatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_LoginCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks']]"
		[Register ("getInstance", "(Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)Lcom/inscripts/heartbeats/HeartbeatChatroom;", "")]
		public static unsafe global::Com.Inscripts.Heartbeats.HeartbeatChatroom GetInstance (global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p0)
		{
			if (id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == IntPtr.Zero)
				id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)Lcom/inscripts/heartbeats/HeartbeatChatroom;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Heartbeats.HeartbeatChatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_, __args), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Heartbeats.HeartbeatChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetForceHeartbeat ();
		}
#pragma warning restore 0169

		static IntPtr id_setForceHeartbeat;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='setForceHeartbeat' and count(parameter)=0]"
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
			global::Com.Inscripts.Heartbeats.HeartbeatChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StartHeartbeat (p0);
		}
#pragma warning restore 0169

		static IntPtr id_startHeartbeat_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='startHeartbeat' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
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

		static Delegate cb_stopHeartbeatChatroom;
#pragma warning disable 0169
		static Delegate GetStopHeartbeatChatroomHandler ()
		{
			if (cb_stopHeartbeatChatroom == null)
				cb_stopHeartbeatChatroom = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_StopHeartbeatChatroom);
			return cb_stopHeartbeatChatroom;
		}

		static void n_StopHeartbeatChatroom (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Heartbeats.HeartbeatChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Heartbeats.HeartbeatChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.StopHeartbeatChatroom ();
		}
#pragma warning restore 0169

		static IntPtr id_stopHeartbeatChatroom;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.heartbeats']/class[@name='HeartbeatChatroom']/method[@name='stopHeartbeatChatroom' and count(parameter)=0]"
		[Register ("stopHeartbeatChatroom", "()V", "GetStopHeartbeatChatroomHandler")]
		public virtual unsafe void StopHeartbeatChatroom ()
		{
			if (id_stopHeartbeatChatroom == IntPtr.Zero)
				id_stopHeartbeatChatroom = JNIEnv.GetMethodID (class_ref, "stopHeartbeatChatroom", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stopHeartbeatChatroom);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "stopHeartbeatChatroom", "()V"));
			} finally {
			}
		}

	}
}
