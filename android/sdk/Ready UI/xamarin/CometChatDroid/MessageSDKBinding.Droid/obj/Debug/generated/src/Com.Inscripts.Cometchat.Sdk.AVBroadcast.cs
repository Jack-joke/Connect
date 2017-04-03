using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/AVBroadcast", DoNotGenerateAcw=true)]
	public partial class AVBroadcast : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/AVBroadcast", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AVBroadcast); }
		}

		protected AVBroadcast (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_isCrEnabled;
		public static unsafe bool IsCrEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='isCrEnabled' and count(parameter)=0]"
			[Register ("isCrEnabled", "()Z", "GetIsCrEnabledHandler")]
			get {
				if (id_isCrEnabled == IntPtr.Zero)
					id_isCrEnabled = JNIEnv.GetStaticMethodID (class_ref, "isCrEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_isEnabled;
		public static unsafe bool IsEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='isEnabled' and count(parameter)=0]"
			[Register ("isEnabled", "()Z", "GetIsEnabledHandler")]
			get {
				if (id_isEnabled == IntPtr.Zero)
					id_isEnabled = JNIEnv.GetStaticMethodID (class_ref, "isEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isEnabled);
				} finally {
				}
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
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_addVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='addVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
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

		static Delegate cb_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetEndBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool, IntPtr, IntPtr, IntPtr>) n_EndBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_EndBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, bool p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.EndBroadcast (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='endBroadcast' and count(parameter)=4 and parameter[1][@type='boolean'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("endBroadcast", "(ZLjava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetEndBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void EndBroadcast (bool p0, string p1, string p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "endBroadcast", "(ZLjava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_endBroadcast_ZLjava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "endBroadcast", "(ZLjava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_getAVBroadcastInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='getAVBroadcastInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getAVBroadcastInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AVBroadcast;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.AVBroadcast GetAVBroadcastInstance (global::Android.Content.Context p0)
		{
			if (id_getAVBroadcastInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getAVBroadcastInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getAVBroadcastInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/AVBroadcast;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVBroadcastInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getGroupName_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='getGroupName' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetGroupName (string p0, bool p1)
		{
			if (id_getGroupName_Ljava_lang_String_Z == IntPtr.Zero)
				id_getGroupName_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getGroupName", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getGroupName_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getInviteGroupName_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='getInviteGroupName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getInviteGroupName", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetInviteGroupName (string p0)
		{
			if (id_getInviteGroupName_Ljava_lang_String_ == IntPtr.Zero)
				id_getInviteGroupName_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getInviteGroupName", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInviteGroupName_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetInviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_InviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_InviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.InviteUsersInBroadcast (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='inviteUsersInBroadcast' and count(parameter)=3 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("inviteUsersInBroadcast", "(Lorg/json/JSONArray;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetInviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void InviteUsersInBroadcast (global::Org.Json.JSONArray p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "inviteUsersInBroadcast", "(Lorg/json/JSONArray;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inviteUsersInBroadcast_Lorg_json_JSONArray_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inviteUsersInBroadcast", "(Lorg/json/JSONArray;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_isAVBroadcast_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='isAVBroadcast' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcast", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcast (string p0)
		{
			if (id_isAVBroadcast_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcast_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcast", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcast_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVBroadcastEnd_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='isAVBroadcastEnd' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcastEnd", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcastEnd (string p0)
		{
			if (id_isAVBroadcastEnd_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcastEnd_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcastEnd", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcastEnd_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isAVBroadcastInvite_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='isAVBroadcastInvite' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isAVBroadcastInvite", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsAVBroadcastInvite (string p0)
		{
			if (id_isAVBroadcastInvite_Ljava_lang_String_ == IntPtr.Zero)
				id_isAVBroadcastInvite_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isAVBroadcastInvite", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isAVBroadcastInvite_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveVideoOnRotation (p0);
		}
#pragma warning restore 0169

		static IntPtr id_removeVideoOnRotation_Landroid_widget_RelativeLayout_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='removeVideoOnRotation' and count(parameter)=1 and parameter[1][@type='android.widget.RelativeLayout']]"
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

		static Delegate cb_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendAVBroadcastRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='sendAVBroadcastRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendAVBroadcastRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendAVBroadcastRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendAVBroadcastRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAVBroadcastRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAVBroadcastRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool, IntPtr, IntPtr, IntPtr>) n_StartBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, bool p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Cometchat.Sdk.AVBroadcast __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.AVBroadcast> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p2 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.StartBroadcast (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='AVBroadcast']/method[@name='startBroadcast' and count(parameter)=4 and parameter[1][@type='boolean'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.widget.RelativeLayout'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startBroadcast", "(ZLjava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartBroadcast (bool p0, string p1, global::Android.Widget.RelativeLayout p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startBroadcast", "(ZLjava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startBroadcast_ZLjava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startBroadcast", "(ZLjava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
