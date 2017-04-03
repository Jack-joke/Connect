using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/AVChat", DoNotGenerateAcw=true)]
	public partial class AVChat : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/AVChat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AVChat); }
		}

		protected AVChat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetAcceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AcceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_AcceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AcceptAVChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='acceptAVChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("acceptAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetAcceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void AcceptAVChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "acceptAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_acceptAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "acceptAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_addVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='addVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
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

		static Delegate cb_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetCancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_CancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_CancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.CancelAVChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='cancelAVChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("cancelAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetCancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void CancelAVChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "cancelAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_cancelAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cancelAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetEndAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_EndAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_EndAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.EndAVChatCall (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='endAVChatCall' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("endAVChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetEndAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void EndAVChatCall (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "endAVChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_endAVChatCall_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "endAVChatCall", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_getAVChatInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='getAVChatInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getAVChatInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AVChat;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.AVChat GetAVChatInstance (global::Android.Content.Context p0)
		{
			if (id_getAVChatInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getAVChatInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getAVChatInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AVChat;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.AVChat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVChatInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_RejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.RejectAVChatRequest (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='rejectAVChatRequest' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("rejectAVChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetRejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RejectAVChatRequest (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "rejectAVChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_rejectAVChatRequest_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "rejectAVChatRequest", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_removeVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='removeVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
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

		static Delegate cb_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendAVChatRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='sendAVChatRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendAVChatRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAVChatRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAVChatRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendBusyTone (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendBusyTone_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='sendBusyTone' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendNoAnswerCall (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendNoAnswerCall_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='sendNoAnswerCall' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
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

		static Delegate cb_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_StartAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p1 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.StartAVChatCall (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='startAVChatCall' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.widget.RelativeLayout'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startAVChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartAVChatCall (string p0, global::Android.Widget.RelativeLayout p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startAVChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startAVChatCall_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startAVChatCall", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SwitchCamera ();
		}
#pragma warning restore 0169

		static IntPtr id_switchCamera;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='switchCamera' and count(parameter)=0]"
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SwitchSpeakers (p0);
		}
#pragma warning restore 0169

		static IntPtr id_switchSpeakers_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='switchSpeakers' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleAudio (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleAudio_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='toggleAudio' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
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
			global::Com.Inscripts.Cometchat.Sdk.AVChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleVideo (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleVideo_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVChat']/method[@name='toggleVideo' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
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
