using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']"
	[Register ("com/inscripts/interfaces/LoginCallbacks", "", "Com.Inscripts.Interfaces.ILoginCallbacksInvoker")]
	public partial interface ILoginCallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='chatWindowListner' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("chatWindowListner", "(Lorg/json/JSONObject;)V", "GetChatWindowListner_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void ChatWindowListner (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='chatroomInfoCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("chatroomInfoCallback", "(Lorg/json/JSONObject;)V", "GetChatroomInfoCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void ChatroomInfoCallback (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='failCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("failCallback", "(Lorg/json/JSONObject;)V", "GetFailCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void FailCallback (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='onMessageReceive' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onMessageReceive", "(Lorg/json/JSONObject;)V", "GetOnMessageReceive_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnMessageReceive (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='successCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("successCallback", "(Lorg/json/JSONObject;)V", "GetSuccessCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void SuccessCallback (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='LoginCallbacks']/method[@name='userInfoCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("userInfoCallback", "(Lorg/json/JSONObject;)V", "GetUserInfoCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ILoginCallbacksInvoker, MessageSDKBinding.Droid")]
		void UserInfoCallback (global::Org.Json.JSONObject p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/LoginCallbacks", DoNotGenerateAcw=true)]
	internal class ILoginCallbacksInvoker : global::Java.Lang.Object, ILoginCallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/LoginCallbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ILoginCallbacksInvoker); }
		}

		IntPtr class_ref;

		public static ILoginCallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ILoginCallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.LoginCallbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ILoginCallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_chatWindowListner_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetChatWindowListner_Lorg_json_JSONObject_Handler ()
		{
			if (cb_chatWindowListner_Lorg_json_JSONObject_ == null)
				cb_chatWindowListner_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ChatWindowListner_Lorg_json_JSONObject_);
			return cb_chatWindowListner_Lorg_json_JSONObject_;
		}

		static void n_ChatWindowListner_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatWindowListner (p0);
		}
#pragma warning restore 0169

		IntPtr id_chatWindowListner_Lorg_json_JSONObject_;
		public unsafe void ChatWindowListner (global::Org.Json.JSONObject p0)
		{
			if (id_chatWindowListner_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_chatWindowListner_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "chatWindowListner", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_chatWindowListner_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_chatroomInfoCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetChatroomInfoCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_chatroomInfoCallback_Lorg_json_JSONObject_ == null)
				cb_chatroomInfoCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ChatroomInfoCallback_Lorg_json_JSONObject_);
			return cb_chatroomInfoCallback_Lorg_json_JSONObject_;
		}

		static void n_ChatroomInfoCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomInfoCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_chatroomInfoCallback_Lorg_json_JSONObject_;
		public unsafe void ChatroomInfoCallback (global::Org.Json.JSONObject p0)
		{
			if (id_chatroomInfoCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_chatroomInfoCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "chatroomInfoCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_chatroomInfoCallback_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_failCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetFailCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_failCallback_Lorg_json_JSONObject_ == null)
				cb_failCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_FailCallback_Lorg_json_JSONObject_);
			return cb_failCallback_Lorg_json_JSONObject_;
		}

		static void n_FailCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FailCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_failCallback_Lorg_json_JSONObject_;
		public unsafe void FailCallback (global::Org.Json.JSONObject p0)
		{
			if (id_failCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_failCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "failCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_failCallback_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onMessageReceive_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnMessageReceive_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onMessageReceive_Lorg_json_JSONObject_ == null)
				cb_onMessageReceive_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnMessageReceive_Lorg_json_JSONObject_);
			return cb_onMessageReceive_Lorg_json_JSONObject_;
		}

		static void n_OnMessageReceive_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnMessageReceive (p0);
		}
#pragma warning restore 0169

		IntPtr id_onMessageReceive_Lorg_json_JSONObject_;
		public unsafe void OnMessageReceive (global::Org.Json.JSONObject p0)
		{
			if (id_onMessageReceive_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onMessageReceive_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onMessageReceive", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onMessageReceive_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_successCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetSuccessCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_successCallback_Lorg_json_JSONObject_ == null)
				cb_successCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SuccessCallback_Lorg_json_JSONObject_);
			return cb_successCallback_Lorg_json_JSONObject_;
		}

		static void n_SuccessCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SuccessCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_successCallback_Lorg_json_JSONObject_;
		public unsafe void SuccessCallback (global::Org.Json.JSONObject p0)
		{
			if (id_successCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_successCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "successCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_successCallback_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_userInfoCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetUserInfoCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_userInfoCallback_Lorg_json_JSONObject_ == null)
				cb_userInfoCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_UserInfoCallback_Lorg_json_JSONObject_);
			return cb_userInfoCallback_Lorg_json_JSONObject_;
		}

		static void n_UserInfoCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ILoginCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ILoginCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.UserInfoCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_userInfoCallback_Lorg_json_JSONObject_;
		public unsafe void UserInfoCallback (global::Org.Json.JSONObject p0)
		{
			if (id_userInfoCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_userInfoCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "userInfoCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_userInfoCallback_Lorg_json_JSONObject_, __args);
		}

	}

}
