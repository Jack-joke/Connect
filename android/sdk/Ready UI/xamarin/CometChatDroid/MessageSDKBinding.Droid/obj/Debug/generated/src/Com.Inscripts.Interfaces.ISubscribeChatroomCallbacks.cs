using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']"
	[Register ("com/inscripts/interfaces/SubscribeChatroomCallbacks", "", "Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker")]
	public partial interface ISubscribeChatroomCallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='gotChatroomList' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotChatroomList", "(Lorg/json/JSONObject;)V", "GetGotChatroomList_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotChatroomList (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='gotChatroomMembers' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotChatroomMembers", "(Lorg/json/JSONObject;)V", "GetGotChatroomMembers_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotChatroomMembers (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='onAVChatMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onAVChatMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnAVChatMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnAVChatMessageReceived (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='onActionMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onActionMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnActionMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnActionMessageReceived (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='onError' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onError", "(Lorg/json/JSONObject;)V", "GetOnError_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnError (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='onLeaveChatroom' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onLeaveChatroom", "(Lorg/json/JSONObject;)V", "GetOnLeaveChatroom_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnLeaveChatroom (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeChatroomCallbacks']/method[@name='onMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeChatroomCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnMessageReceived (global::Org.Json.JSONObject p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/SubscribeChatroomCallbacks", DoNotGenerateAcw=true)]
	internal class ISubscribeChatroomCallbacksInvoker : global::Java.Lang.Object, ISubscribeChatroomCallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/SubscribeChatroomCallbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ISubscribeChatroomCallbacksInvoker); }
		}

		IntPtr class_ref;

		public static ISubscribeChatroomCallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ISubscribeChatroomCallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.SubscribeChatroomCallbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ISubscribeChatroomCallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_gotChatroomList_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotChatroomList_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotChatroomList_Lorg_json_JSONObject_ == null)
				cb_gotChatroomList_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotChatroomList_Lorg_json_JSONObject_);
			return cb_gotChatroomList_Lorg_json_JSONObject_;
		}

		static void n_GotChatroomList_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotChatroomList (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotChatroomList_Lorg_json_JSONObject_;
		public unsafe void GotChatroomList (global::Org.Json.JSONObject p0)
		{
			if (id_gotChatroomList_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotChatroomList_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotChatroomList", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotChatroomList_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_gotChatroomMembers_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotChatroomMembers_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotChatroomMembers_Lorg_json_JSONObject_ == null)
				cb_gotChatroomMembers_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotChatroomMembers_Lorg_json_JSONObject_);
			return cb_gotChatroomMembers_Lorg_json_JSONObject_;
		}

		static void n_GotChatroomMembers_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotChatroomMembers (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotChatroomMembers_Lorg_json_JSONObject_;
		public unsafe void GotChatroomMembers (global::Org.Json.JSONObject p0)
		{
			if (id_gotChatroomMembers_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotChatroomMembers_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotChatroomMembers", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotChatroomMembers_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onAVChatMessageReceived_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnAVChatMessageReceived_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onAVChatMessageReceived_Lorg_json_JSONObject_ == null)
				cb_onAVChatMessageReceived_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnAVChatMessageReceived_Lorg_json_JSONObject_);
			return cb_onAVChatMessageReceived_Lorg_json_JSONObject_;
		}

		static void n_OnAVChatMessageReceived_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnAVChatMessageReceived (p0);
		}
#pragma warning restore 0169

		IntPtr id_onAVChatMessageReceived_Lorg_json_JSONObject_;
		public unsafe void OnAVChatMessageReceived (global::Org.Json.JSONObject p0)
		{
			if (id_onAVChatMessageReceived_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onAVChatMessageReceived_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onAVChatMessageReceived", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onAVChatMessageReceived_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onActionMessageReceived_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnActionMessageReceived_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onActionMessageReceived_Lorg_json_JSONObject_ == null)
				cb_onActionMessageReceived_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnActionMessageReceived_Lorg_json_JSONObject_);
			return cb_onActionMessageReceived_Lorg_json_JSONObject_;
		}

		static void n_OnActionMessageReceived_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnActionMessageReceived (p0);
		}
#pragma warning restore 0169

		IntPtr id_onActionMessageReceived_Lorg_json_JSONObject_;
		public unsafe void OnActionMessageReceived (global::Org.Json.JSONObject p0)
		{
			if (id_onActionMessageReceived_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onActionMessageReceived_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onActionMessageReceived", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onActionMessageReceived_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onError_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnError_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onError_Lorg_json_JSONObject_ == null)
				cb_onError_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnError_Lorg_json_JSONObject_);
			return cb_onError_Lorg_json_JSONObject_;
		}

		static void n_OnError_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnError (p0);
		}
#pragma warning restore 0169

		IntPtr id_onError_Lorg_json_JSONObject_;
		public unsafe void OnError (global::Org.Json.JSONObject p0)
		{
			if (id_onError_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onError_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onError", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onError_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onLeaveChatroom_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnLeaveChatroom_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onLeaveChatroom_Lorg_json_JSONObject_ == null)
				cb_onLeaveChatroom_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnLeaveChatroom_Lorg_json_JSONObject_);
			return cb_onLeaveChatroom_Lorg_json_JSONObject_;
		}

		static void n_OnLeaveChatroom_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnLeaveChatroom (p0);
		}
#pragma warning restore 0169

		IntPtr id_onLeaveChatroom_Lorg_json_JSONObject_;
		public unsafe void OnLeaveChatroom (global::Org.Json.JSONObject p0)
		{
			if (id_onLeaveChatroom_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onLeaveChatroom_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onLeaveChatroom", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onLeaveChatroom_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_onMessageReceived_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetOnMessageReceived_Lorg_json_JSONObject_Handler ()
		{
			if (cb_onMessageReceived_Lorg_json_JSONObject_ == null)
				cb_onMessageReceived_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnMessageReceived_Lorg_json_JSONObject_);
			return cb_onMessageReceived_Lorg_json_JSONObject_;
		}

		static void n_OnMessageReceived_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnMessageReceived (p0);
		}
#pragma warning restore 0169

		IntPtr id_onMessageReceived_Lorg_json_JSONObject_;
		public unsafe void OnMessageReceived (global::Org.Json.JSONObject p0)
		{
			if (id_onMessageReceived_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_onMessageReceived_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "onMessageReceived", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onMessageReceived_Lorg_json_JSONObject_, __args);
		}

	}

}
