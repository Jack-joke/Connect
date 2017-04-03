using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/MessageHelper", DoNotGenerateAcw=true)]
	public partial class MessageHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/MessageHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MessageHelper); }
		}

		protected MessageHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/constructor[@name='MessageHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe MessageHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (MessageHelper)) {
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
		public static unsafe global::Com.Inscripts.Helpers.MessageHelper Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/helpers/MessageHelper;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/helpers/MessageHelper;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetAddNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_AddNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_);
			return cb_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_AddNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Helpers.MessageHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p1 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICometchatCallbacks p2 = (global::Com.Inscripts.Interfaces.ICometchatCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICometchatCallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.AddNewBuddy (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='addNewBuddy' and count(parameter)=4 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='android.content.Context'] and parameter[3][@type='com.inscripts.interfaces.CometchatCallbacks'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("addNewBuddy", "(Ljava/lang/Long;Landroid/content/Context;Lcom/inscripts/interfaces/CometchatCallbacks;Lcom/inscripts/interfaces/Callbacks;)V", "GetAddNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void AddNewBuddy (global::Java.Lang.Long p0, global::Android.Content.Context p1, global::Com.Inscripts.Interfaces.ICometchatCallbacks p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "addNewBuddy", "(Ljava/lang/Long;Landroid/content/Context;Lcom/inscripts/interfaces/CometchatCallbacks;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addNewBuddy_Ljava_lang_Long_Landroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addNewBuddy", "(Ljava/lang/Long;Landroid/content/Context;Lcom/inscripts/interfaces/CometchatCallbacks;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_handleChatroomMessage_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetHandleChatroomMessage_Lorg_json_JSONObject_Handler ()
		{
			if (cb_handleChatroomMessage_Lorg_json_JSONObject_ == null)
				cb_handleChatroomMessage_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_HandleChatroomMessage_Lorg_json_JSONObject_);
			return cb_handleChatroomMessage_Lorg_json_JSONObject_;
		}

		static bool n_HandleChatroomMessage_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Helpers.MessageHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.HandleChatroomMessage (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_handleChatroomMessage_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='handleChatroomMessage' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("handleChatroomMessage", "(Lorg/json/JSONObject;)Z", "GetHandleChatroomMessage_Lorg_json_JSONObject_Handler")]
		public virtual unsafe bool HandleChatroomMessage (global::Org.Json.JSONObject p0)
		{
			if (id_handleChatroomMessage_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_handleChatroomMessage_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "handleChatroomMessage", "(Lorg/json/JSONObject;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_handleChatroomMessage_Lorg_json_JSONObject_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "handleChatroomMessage", "(Lorg/json/JSONObject;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z;
#pragma warning disable 0169
		static Delegate GetHandleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ZHandler ()
		{
			if (cb_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z == null)
				cb_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_HandleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z);
			return cb_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z;
		}

		static IntPtr n_HandleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2)
		{
			global::Com.Inscripts.Helpers.MessageHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.HandleChatroomMessage (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='handleChatroomMessage' and count(parameter)=3 and parameter[1][@type='org.json.JSONObject'] and parameter[2][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks'] and parameter[3][@type='boolean']]"
		[Register ("handleChatroomMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Z)Lorg/json/JSONObject;", "GetHandleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ZHandler")]
		public virtual unsafe global::Org.Json.JSONObject HandleChatroomMessage (global::Org.Json.JSONObject p0, global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1, bool p2)
		{
			if (id_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z == IntPtr.Zero)
				id_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z = JNIEnv.GetMethodID (class_ref, "handleChatroomMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Z)Lorg/json/JSONObject;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Org.Json.JSONObject __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_handleChatroomMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Z, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "handleChatroomMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Z)Lorg/json/JSONObject;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetHandleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_Handler ()
		{
			if (cb_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_ == null)
				cb_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>) n_HandleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_);
			return cb_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_;
		}

		static bool n_HandleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Helpers.MessageHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Models.Buddy p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Buddy> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p1 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p1, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.HandleOneOnOneMessage (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='handleOneOnOneMessage' and count(parameter)=2 and parameter[1][@type='com.inscripts.models.Buddy'] and parameter[2][@type='org.json.JSONObject']]"
		[Register ("handleOneOnOneMessage", "(Lcom/inscripts/models/Buddy;Lorg/json/JSONObject;)Z", "GetHandleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_Handler")]
		public virtual unsafe bool HandleOneOnOneMessage (global::Com.Inscripts.Models.Buddy p0, global::Org.Json.JSONObject p1)
		{
			if (id_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "handleOneOnOneMessage", "(Lcom/inscripts/models/Buddy;Lorg/json/JSONObject;)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_handleOneOnOneMessage_Lcom_inscripts_models_Buddy_Lorg_json_JSONObject_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "handleOneOnOneMessage", "(Lcom/inscripts/models/Buddy;Lorg/json/JSONObject;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z;
#pragma warning disable 0169
		static Delegate GetHandleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_ZHandler ()
		{
			if (cb_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z == null)
				cb_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_HandleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z);
			return cb_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z;
		}

		static IntPtr n_HandleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2)
		{
			global::Com.Inscripts.Helpers.MessageHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.MessageHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.HandleOneOnOneMessage (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='MessageHelper']/method[@name='handleOneOnOneMessage' and count(parameter)=3 and parameter[1][@type='org.json.JSONObject'] and parameter[2][@type='com.inscripts.interfaces.SubscribeCallbacks'] and parameter[3][@type='boolean']]"
		[Register ("handleOneOnOneMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeCallbacks;Z)Lorg/json/JSONObject;", "GetHandleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_ZHandler")]
		public virtual unsafe global::Org.Json.JSONObject HandleOneOnOneMessage (global::Org.Json.JSONObject p0, global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1, bool p2)
		{
			if (id_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z == IntPtr.Zero)
				id_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z = JNIEnv.GetMethodID (class_ref, "handleOneOnOneMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeCallbacks;Z)Lorg/json/JSONObject;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Org.Json.JSONObject __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_handleOneOnOneMessage_Lorg_json_JSONObject_Lcom_inscripts_interfaces_SubscribeCallbacks_Z, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "handleOneOnOneMessage", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/SubscribeCallbacks;Z)Lorg/json/JSONObject;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
