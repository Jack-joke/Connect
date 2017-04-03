using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/GroupAVChat", DoNotGenerateAcw=true)]
	public partial class GroupAVChat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/GroupAVChat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (GroupAVChat); }
		}

		protected GroupAVChat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_addVideoOnRotation_Landroid_widget_RelativeLayout_;
#pragma warning disable 0169
		static Delegate GetAddVideoOnRotation_Landroid_widget_RelativeLayout_Handler ()
		{
			if (cb_addVideoOnRotation_Landroid_widget_RelativeLayout_ == null)
				cb_addVideoOnRotation_Landroid_widget_RelativeLayout_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AddVideoOnRotation_Landroid_widget_RelativeLayout_);
			return cb_addVideoOnRotation_Landroid_widget_RelativeLayout_;
		}

		static void n_AddVideoOnRotation_Landroid_widget_RelativeLayout_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_addVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='addVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
		[Register ("addVideoOnRotation", "(Landroid/widget/RelativeLayout;)V", "GetAddVideoOnRotation_Landroid_widget_RelativeLayout_Handler")]
		public virtual unsafe void AddVideoOnRotation (global::Android.Widget.RelativeLayout p0)
		{
			if (id_addVideoOnRotation_Landroid_widget_RelativeLayout_ == IntPtr.Zero)
				id_addVideoOnRotation_Landroid_widget_RelativeLayout_ = JNIEnv.GetMethodID (class_ref, "addVideoOnRotation", "(Landroid/widget/RelativeLayout;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addVideoOnRotation_Landroid_widget_RelativeLayout_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addVideoOnRotation", "(Landroid/widget/RelativeLayout;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_endConference_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetEndConference_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_endConference_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_endConference_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_EndConference_Lcom_inscripts_interfaces_Callbacks_);
			return cb_endConference_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_EndConference_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.EndConference (p0);
		}
#pragma warning restore 0169

		static IntPtr id_endConference_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='endConference' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("endConference", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetEndConference_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void EndConference (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_endConference_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_endConference_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "endConference", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_endConference_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "endConference", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static IntPtr id_getGroupChatInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='getGroupChatInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getGroupChatInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/GroupAVChat;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.GroupAVChat GetGroupChatInstance (global::Android.Content.Context p0)
		{
			if (id_getGroupChatInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getGroupChatInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getGroupChatInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/GroupAVChat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getGroupChatInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_joinConference_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetJoinConference_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_joinConference_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_joinConference_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_JoinConference_Lcom_inscripts_interfaces_Callbacks_);
			return cb_joinConference_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_JoinConference_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.JoinConference (p0);
		}
#pragma warning restore 0169

		static IntPtr id_joinConference_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='joinConference' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("joinConference", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetJoinConference_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void JoinConference (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_joinConference_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_joinConference_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "joinConference", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_joinConference_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "joinConference", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_removeVideoOnRotation_Landroid_widget_RelativeLayout_;
#pragma warning disable 0169
		static Delegate GetRemoveVideoOnRotation_Landroid_widget_RelativeLayout_Handler ()
		{
			if (cb_removeVideoOnRotation_Landroid_widget_RelativeLayout_ == null)
				cb_removeVideoOnRotation_Landroid_widget_RelativeLayout_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RemoveVideoOnRotation_Landroid_widget_RelativeLayout_);
			return cb_removeVideoOnRotation_Landroid_widget_RelativeLayout_;
		}

		static void n_RemoveVideoOnRotation_Landroid_widget_RelativeLayout_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_removeVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='removeVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
		[Register ("removeVideoOnRotation", "(Landroid/widget/RelativeLayout;)V", "GetRemoveVideoOnRotation_Landroid_widget_RelativeLayout_Handler")]
		public virtual unsafe void RemoveVideoOnRotation (global::Android.Widget.RelativeLayout p0)
		{
			if (id_removeVideoOnRotation_Landroid_widget_RelativeLayout_ == IntPtr.Zero)
				id_removeVideoOnRotation_Landroid_widget_RelativeLayout_ = JNIEnv.GetMethodID (class_ref, "removeVideoOnRotation", "(Landroid/widget/RelativeLayout;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeVideoOnRotation_Landroid_widget_RelativeLayout_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "removeVideoOnRotation", "(Landroid/widget/RelativeLayout;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SendConferenceRequest (p0);
		}
#pragma warning restore 0169

		static IntPtr id_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='sendConferenceRequest' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendConferenceRequest", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetSendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendConferenceRequest (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendConferenceRequest", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendConferenceRequest_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendConferenceRequest", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_StartConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.StartConference (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='startConference' and count(parameter)=2 and parameter[1][@type='android.widget.RelativeLayout'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startConference", "(Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartConference (global::Android.Widget.RelativeLayout p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startConference", "(Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startConference_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startConference", "(Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_switchCamera;
#pragma warning disable 0169
		static Delegate GetSwitchCameraHandler ()
		{
			if (cb_switchCamera == null)
				cb_switchCamera = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SwitchCamera);
			return cb_switchCamera;
		}

		static void n_SwitchCamera (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SwitchCamera ();
		}
#pragma warning restore 0169

		static IntPtr id_switchCamera;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='switchCamera' and count(parameter)=0]"
		[Register ("switchCamera", "()V", "GetSwitchCameraHandler")]
		public virtual unsafe void SwitchCamera ()
		{
			if (id_switchCamera == IntPtr.Zero)
				id_switchCamera = JNIEnv.GetMethodID (class_ref, "switchCamera", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_switchCamera);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "switchCamera", "()V"));
			} finally {
			}
		}

		static Delegate cb_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSwitchSpeakers_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SwitchSpeakers_Lcom_inscripts_interfaces_Callbacks_);
			return cb_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SwitchSpeakers_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SwitchSpeakers (p0);
		}
#pragma warning restore 0169

		static IntPtr id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='switchSpeakers' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("switchSpeakers", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetSwitchSpeakers_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SwitchSpeakers (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "switchSpeakers", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "switchSpeakers", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_toggleAudio_Ljava_lang_Boolean_;
#pragma warning disable 0169
		static Delegate GetToggleAudio_Ljava_lang_Boolean_Handler ()
		{
			if (cb_toggleAudio_Ljava_lang_Boolean_ == null)
				cb_toggleAudio_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ToggleAudio_Ljava_lang_Boolean_);
			return cb_toggleAudio_Ljava_lang_Boolean_;
		}

		static void n_ToggleAudio_Ljava_lang_Boolean_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleAudio (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleAudio_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='toggleAudio' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
		[Register ("toggleAudio", "(Ljava/lang/Boolean;)V", "GetToggleAudio_Ljava_lang_Boolean_Handler")]
		public virtual unsafe void ToggleAudio (global::Java.Lang.Boolean p0)
		{
			if (id_toggleAudio_Ljava_lang_Boolean_ == IntPtr.Zero)
				id_toggleAudio_Ljava_lang_Boolean_ = JNIEnv.GetMethodID (class_ref, "toggleAudio", "(Ljava/lang/Boolean;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggleAudio_Ljava_lang_Boolean_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggleAudio", "(Ljava/lang/Boolean;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_toggleVideo_Ljava_lang_Boolean_;
#pragma warning disable 0169
		static Delegate GetToggleVideo_Ljava_lang_Boolean_Handler ()
		{
			if (cb_toggleVideo_Ljava_lang_Boolean_ == null)
				cb_toggleVideo_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ToggleVideo_Ljava_lang_Boolean_);
			return cb_toggleVideo_Ljava_lang_Boolean_;
		}

		static void n_ToggleVideo_Ljava_lang_Boolean_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.GroupAVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.GroupAVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleVideo (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleVideo_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='GroupAVChat']/method[@name='toggleVideo' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
		[Register ("toggleVideo", "(Ljava/lang/Boolean;)V", "GetToggleVideo_Ljava_lang_Boolean_Handler")]
		public virtual unsafe void ToggleVideo (global::Java.Lang.Boolean p0)
		{
			if (id_toggleVideo_Ljava_lang_Boolean_ == IntPtr.Zero)
				id_toggleVideo_Ljava_lang_Boolean_ = JNIEnv.GetMethodID (class_ref, "toggleVideo", "(Ljava/lang/Boolean;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggleVideo_Ljava_lang_Boolean_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggleVideo", "(Ljava/lang/Boolean;)V"), __args);
			} finally {
			}
		}

	}
}
