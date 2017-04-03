using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/CometChatroom", DoNotGenerateAcw=true)]
	public partial class CometChatroom : global::Java.Lang.Object {


		static IntPtr useHTML_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/field[@name='useHTML']"
		[Register ("useHTML")]
		public static bool UseHTML {
			get {
				if (useHTML_jfieldId == IntPtr.Zero)
					useHTML_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "useHTML", "Z");
				return JNIEnv.GetStaticBooleanField (class_ref, useHTML_jfieldId);
			}
			set {
				if (useHTML_jfieldId == IntPtr.Zero)
					useHTML_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "useHTML", "Z");
				try {
					JNIEnv.SetStaticField (class_ref, useHTML_jfieldId, value);
				} finally {
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/CometChatroom", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometChatroom); }
		}

		protected CometChatroom (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_getCurrentChatroom;
#pragma warning disable 0169
		static Delegate GetGetCurrentChatroomHandler ()
		{
			if (cb_getCurrentChatroom == null)
				cb_getCurrentChatroom = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCurrentChatroom);
			return cb_getCurrentChatroom;
		}

		static IntPtr n_GetCurrentChatroom (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CurrentChatroom);
		}
#pragma warning restore 0169

		static IntPtr id_getCurrentChatroom;
		public virtual unsafe string CurrentChatroom {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='getCurrentChatroom' and count(parameter)=0]"
			[Register ("getCurrentChatroom", "()Ljava/lang/String;", "GetGetCurrentChatroomHandler")]
			get {
				if (id_getCurrentChatroom == IntPtr.Zero)
					id_getCurrentChatroom = JNIEnv.GetMethodID (class_ref, "getCurrentChatroom", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentChatroom), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCurrentChatroom", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetCreateChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_CreateChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_);
			return cb_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_CreateChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Enums.ChatroomType p2 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.ChatroomType> (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.CreateChatroom (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='createChatroom' and count(parameter)=4 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.enums.ChatroomType'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("createChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/ChatroomType;Lcom/inscripts/interfaces/Callbacks;)V", "GetCreateChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void CreateChatroom (string p0, string p1, global::Com.Inscripts.Enums.ChatroomType p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "createChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/ChatroomType;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_createChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_ChatroomType_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "createChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/ChatroomType;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetDeleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_DeleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_DeleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.DeleteChatroom (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='deleteChatroom' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("deleteChatroom", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetDeleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void DeleteChatroom (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "deleteChatroom", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_deleteChatroom_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "deleteChatroom", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetAllChatrooms_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetAllChatrooms_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetAllChatrooms_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetAllChatrooms (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='getAllChatrooms' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getAllChatrooms", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetAllChatrooms_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetAllChatrooms (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getAllChatrooms", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getAllChatrooms_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAllChatrooms", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.GetChatroomChatHistory (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='getChatroomChatHistory' and count(parameter)=3 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='java.lang.Long'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getChatroomChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V", "GetGetChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetChatroomChatHistory (global::Java.Lang.Long p0, global::Java.Lang.Long p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getChatroomChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static IntPtr id_getInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/CometChatroom;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.CometChatroom GetInstance (global::Android.Content.Context p0)
		{
			if (id_getInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/CometChatroom;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.CometChatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetInviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_InviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_);
			return cb_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_InviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.InviteUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='inviteUser' and count(parameter)=2 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("inviteUser", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V", "GetInviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void InviteUser (global::Org.Json.JSONArray p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "inviteUser", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_inviteUser_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "inviteUser", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_isSubscribedToChatroom_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetIsSubscribedToChatroom_Ljava_lang_String_Handler ()
		{
			if (cb_isSubscribedToChatroom_Ljava_lang_String_ == null)
				cb_isSubscribedToChatroom_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_IsSubscribedToChatroom_Ljava_lang_String_);
			return cb_isSubscribedToChatroom_Ljava_lang_String_;
		}

		static bool n_IsSubscribedToChatroom_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.IsSubscribedToChatroom (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_isSubscribedToChatroom_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='isSubscribedToChatroom' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isSubscribedToChatroom", "(Ljava/lang/String;)Z", "GetIsSubscribedToChatroom_Ljava_lang_String_Handler")]
		public virtual unsafe bool IsSubscribedToChatroom (string p0)
		{
			if (id_isSubscribedToChatroom_Ljava_lang_String_ == IntPtr.Zero)
				id_isSubscribedToChatroom_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "isSubscribedToChatroom", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isSubscribedToChatroom_Ljava_lang_String_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isSubscribedToChatroom", "(Ljava/lang/String;)Z"), __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetJoinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_JoinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_JoinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.JoinChatroom (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='joinChatroom' and count(parameter)=4 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("joinChatroom", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetJoinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void JoinChatroom (string p0, string p1, string p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "joinChatroom", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_joinChatroom_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "joinChatroom", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static Delegate cb_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetLeaveChatroom_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_LeaveChatroom_Lcom_inscripts_interfaces_Callbacks_);
			return cb_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_LeaveChatroom_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.LeaveChatroom (p0);
		}
#pragma warning restore 0169

		static IntPtr id_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='leaveChatroom' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("leaveChatroom", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetLeaveChatroom_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void LeaveChatroom (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "leaveChatroom", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_leaveChatroom_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "leaveChatroom", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static IntPtr id_leaveChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='leaveChatroom' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks']]"
		[Register ("leaveChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V", "")]
		public static unsafe void LeaveChatroom (string p0, string p1, global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p2)
		{
			if (id_leaveChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == IntPtr.Zero)
				id_leaveChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "leaveChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_leaveChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRenameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_RenameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RenameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.RenameChatroom (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='renameChatroom' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("renameChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetRenameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RenameChatroom (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "renameChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_renameChatroom_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "renameChatroom", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendAudioFile (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendAudioFile' and count(parameter)=2 and parameter[1][@type='java.io.File'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendAudioFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendAudioFile (global::Java.IO.File p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendAudioFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAudioFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAudioFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendFile (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendFile' and count(parameter)=2 and parameter[1][@type='java.io.File'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendFile (global::Java.IO.File p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendFile_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendFile", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendImage (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendImage' and count(parameter)=2 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImage", "(Landroid/graphics/Bitmap;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImage (global::Android.Graphics.Bitmap p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImage", "(Landroid/graphics/Bitmap;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImage_Landroid_graphics_Bitmap_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImage", "(Landroid/graphics/Bitmap;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendImage (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendImage' and count(parameter)=2 and parameter[1][@type='java.io.File'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImage", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImage (global::Java.IO.File p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImage", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImage_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImage", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendMessage (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendMessage' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendMessage", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendMessage (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendMessage", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendMessage", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendSticker (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendSticker' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendSticker", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendSticker (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendSticker", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendSticker_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendSticker", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendVideo (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendVideo' and count(parameter)=2 and parameter[1][@type='java.io.File'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendVideo", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendVideo (global::Java.IO.File p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendVideo", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendVideo_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendVideo", "(Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendVideo (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='sendVideo' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendVideo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendVideo (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendVideo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendVideo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendVideo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
#pragma warning disable 0169
		static Delegate GetSubscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_Handler ()
		{
			if (cb_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == null)
				cb_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool, IntPtr>) n_Subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_);
			return cb_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		}

		static void n_Subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_ (IntPtr jnienv, IntPtr native__this, bool p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Subscribe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='subscribe' and count(parameter)=2 and parameter[1][@type='boolean'] and parameter[2][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks']]"
		[Register ("subscribe", "(ZLcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V", "GetSubscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_Handler")]
		public virtual unsafe void Subscribe (bool p0, global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1)
		{
			if (id_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_ == IntPtr.Zero)
				id_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_ = JNIEnv.GetMethodID (class_ref, "subscribe", "(ZLcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_subscribe_ZLcom_inscripts_interfaces_SubscribeChatroomCallbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "subscribe", "(ZLcom/inscripts/interfaces/SubscribeChatroomCallbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_unsubscribe;
#pragma warning disable 0169
		static Delegate GetUnsubscribeHandler ()
		{
			if (cb_unsubscribe == null)
				cb_unsubscribe = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Unsubscribe);
			return cb_unsubscribe;
		}

		static void n_Unsubscribe (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Unsubscribe ();
		}
#pragma warning restore 0169

		static IntPtr id_unsubscribe;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatroom']/method[@name='unsubscribe' and count(parameter)=0]"
		[Register ("unsubscribe", "()V", "GetUnsubscribeHandler")]
		public virtual unsafe void Unsubscribe ()
		{
			if (id_unsubscribe == IntPtr.Zero)
				id_unsubscribe = JNIEnv.GetMethodID (class_ref, "unsubscribe", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_unsubscribe);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unsubscribe", "()V"));
			} finally {
			}
		}

	}
}
