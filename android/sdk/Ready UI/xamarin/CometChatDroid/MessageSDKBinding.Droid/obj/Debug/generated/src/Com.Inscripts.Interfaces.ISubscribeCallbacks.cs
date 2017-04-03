using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']"
	[Register ("com/inscripts/interfaces/SubscribeCallbacks", "", "Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker")]
	public partial interface ISubscribeCallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='gotAnnouncement' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotAnnouncement", "(Lorg/json/JSONObject;)V", "GetGotAnnouncement_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotAnnouncement (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='gotBotList' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotBotList", "(Lorg/json/JSONObject;)V", "GetGotBotList_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotBotList (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='gotOnlineList' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotOnlineList", "(Lorg/json/JSONObject;)V", "GetGotOnlineList_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotOnlineList (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='gotProfileInfo' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("gotProfileInfo", "(Lorg/json/JSONObject;)V", "GetGotProfileInfo_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void GotProfileInfo (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='onAVChatMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onAVChatMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnAVChatMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnAVChatMessageReceived (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='onActionMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onActionMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnActionMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnActionMessageReceived (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='onError' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onError", "(Lorg/json/JSONObject;)V", "GetOnError_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnError (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='SubscribeCallbacks']/method[@name='onMessageReceived' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("onMessageReceived", "(Lorg/json/JSONObject;)V", "GetOnMessageReceived_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ISubscribeCallbacksInvoker, MessageSDKBinding.Droid")]
		void OnMessageReceived (global::Org.Json.JSONObject p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/SubscribeCallbacks", DoNotGenerateAcw=true)]
	internal class ISubscribeCallbacksInvoker : global::Java.Lang.Object, ISubscribeCallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/SubscribeCallbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ISubscribeCallbacksInvoker); }
		}

		IntPtr class_ref;

		public static ISubscribeCallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ISubscribeCallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.SubscribeCallbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ISubscribeCallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_gotAnnouncement_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotAnnouncement_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotAnnouncement_Lorg_json_JSONObject_ == null)
				cb_gotAnnouncement_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotAnnouncement_Lorg_json_JSONObject_);
			return cb_gotAnnouncement_Lorg_json_JSONObject_;
		}

		static void n_GotAnnouncement_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotAnnouncement (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotAnnouncement_Lorg_json_JSONObject_;
		public unsafe void GotAnnouncement (global::Org.Json.JSONObject p0)
		{
			if (id_gotAnnouncement_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotAnnouncement_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotAnnouncement", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotAnnouncement_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_gotBotList_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotBotList_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotBotList_Lorg_json_JSONObject_ == null)
				cb_gotBotList_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotBotList_Lorg_json_JSONObject_);
			return cb_gotBotList_Lorg_json_JSONObject_;
		}

		static void n_GotBotList_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotBotList (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotBotList_Lorg_json_JSONObject_;
		public unsafe void GotBotList (global::Org.Json.JSONObject p0)
		{
			if (id_gotBotList_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotBotList_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotBotList", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotBotList_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_gotOnlineList_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotOnlineList_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotOnlineList_Lorg_json_JSONObject_ == null)
				cb_gotOnlineList_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotOnlineList_Lorg_json_JSONObject_);
			return cb_gotOnlineList_Lorg_json_JSONObject_;
		}

		static void n_GotOnlineList_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotOnlineList (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotOnlineList_Lorg_json_JSONObject_;
		public unsafe void GotOnlineList (global::Org.Json.JSONObject p0)
		{
			if (id_gotOnlineList_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotOnlineList_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotOnlineList", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotOnlineList_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_gotProfileInfo_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetGotProfileInfo_Lorg_json_JSONObject_Handler ()
		{
			if (cb_gotProfileInfo_Lorg_json_JSONObject_ == null)
				cb_gotProfileInfo_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GotProfileInfo_Lorg_json_JSONObject_);
			return cb_gotProfileInfo_Lorg_json_JSONObject_;
		}

		static void n_GotProfileInfo_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GotProfileInfo (p0);
		}
#pragma warning restore 0169

		IntPtr id_gotProfileInfo_Lorg_json_JSONObject_;
		public unsafe void GotProfileInfo (global::Org.Json.JSONObject p0)
		{
			if (id_gotProfileInfo_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_gotProfileInfo_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "gotProfileInfo", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_gotProfileInfo_Lorg_json_JSONObject_, __args);
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
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
