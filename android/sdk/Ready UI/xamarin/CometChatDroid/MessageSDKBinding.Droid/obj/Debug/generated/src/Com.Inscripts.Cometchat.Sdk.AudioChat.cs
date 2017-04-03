using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/AudioChat", DoNotGenerateAcw=true)]
	public partial class AudioChat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/AudioChat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AudioChat); }
		}

		protected AudioChat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetAcceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AcceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_AcceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AcceptAudioChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='acceptAudioChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("acceptAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetAcceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void AcceptAudioChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "acceptAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_acceptAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "acceptAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetCancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_CancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_CancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.CancelAudioChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='cancelAudioChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("cancelAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetCancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void CancelAudioChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "cancelAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_cancelAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetEndAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_EndAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_EndAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.EndAudioChatCall (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='endAudioChatCall' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("endAudioChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetEndAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void EndAudioChatCall (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "endAudioChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_endAudioChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "endAudioChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_getInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AudioChat;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.AudioChat GetInstance (global::Android.Content.Context p0)
		{
			if (id_getInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AudioChat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.AudioChat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_RejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.RejectAudioChatRequest (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='rejectAudioChatRequest' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("rejectAudioChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetRejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RejectAudioChatRequest (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "rejectAudioChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_rejectAudioChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "rejectAudioChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendAudioChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='sendAudioChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendAudioChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAudioChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAudioChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendBusyTone (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='sendBusyTone' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendBusyTone", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendBusyTone (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendBusyTone", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendBusyTone", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendNoAnswerCall (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='sendNoAnswerCall' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendNoAnswerCall", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendNoAnswerCall (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendNoAnswerCall", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendNoAnswerCall", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_StartAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p1 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.StartAudioChatCall (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='startAudioChatCall' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.widget.RelativeLayout'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startAudioChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartAudioChatCall (string p0, global::Android.Widget.RelativeLayout p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startAudioChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startAudioChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startAudioChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SwitchSpeakers (p0);
		}
#pragma warning restore 0169

		static IntPtr id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='switchSpeakers' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
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
			global::Com.Inscripts.Cometchat.Sdk.AudioChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AudioChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleAudio (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleAudio_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AudioChat']/method[@name='toggleAudio' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
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

	}
}
