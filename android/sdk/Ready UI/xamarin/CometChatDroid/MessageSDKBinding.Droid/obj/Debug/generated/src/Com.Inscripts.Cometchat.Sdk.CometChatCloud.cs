using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/CometChatCloud", DoNotGenerateAcw=true)]
	public partial class CometChatCloud : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/CometChatCloud", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometChatCloud); }
		}

		protected CometChatCloud (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetAddFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_);
			return cb_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_AddFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddFriends (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='addFriends' and count(parameter)=2 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("addFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V", "GetAddFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void AddFriends (global::Org.Json.JSONArray p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "addFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetCreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_CreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_CreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5, IntPtr native_p6)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString (native_p4, JniHandleOwnership.DoNotTransfer);
			string p5 = JNIEnv.GetString (native_p5, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p6 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p6, JniHandleOwnership.DoNotTransfer);
			__this.CreateUser (p0, p1, p2, p3, p4, p5, p6);
		}
#pragma warning restore 0169

		static IntPtr id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='createUser' and count(parameter)=7 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='java.lang.String'] and parameter[7][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetCreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void CreateUser (string p0, string p1, string p2, string p3, string p4, string p5, global::Com.Inscripts.Interfaces.ICallbacks p6)
		{
			if (id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [7];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (native_p5);
				__args [6] = new JValue (p6);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

		static IntPtr id_getInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='getInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/CometChatCloud;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.CometChatCloud GetInstance (global::Android.Content.Context p0)
		{
			if (id_getInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/CometChatCloud;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRemoveFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_RemoveFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_);
			return cb_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RemoveFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.RemoveFriends (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='removeFriends' and count(parameter)=2 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("removeFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V", "GetRemoveFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RemoveFriends (global::Org.Json.JSONArray p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "removeFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "removeFriends", "(Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRemoveUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_RemoveUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_);
			return cb_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RemoveUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.RemoveUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='removeUser' and count(parameter)=2 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("removeUser", "(Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V", "GetRemoveUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RemoveUser (global::Java.Lang.Long p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "removeUser", "(Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeUser_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "removeUser", "(Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetRemoveUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_RemoveUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_RemoveUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.RemoveUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='removeUser' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("removeUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetRemoveUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void RemoveUser (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "removeUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "removeUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetUpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == null)
				cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_UpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_);
			return cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		}

		static void n_UpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5, IntPtr native_p6, bool p7, IntPtr native_p8)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChatCloud __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChatCloud> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			string p4 = JNIEnv.GetString (native_p4, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Enums.StatusOption p5 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (native_p5, JniHandleOwnership.DoNotTransfer);
			string p6 = JNIEnv.GetString (native_p6, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p8 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p8, JniHandleOwnership.DoNotTransfer);
			__this.UpdateUser (p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
#pragma warning restore 0169

		static IntPtr id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChatCloud']/method[@name='updateUser' and count(parameter)=9 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='com.inscripts.enums.StatusOption'] and parameter[7][@type='java.lang.String'] and parameter[8][@type='boolean'] and parameter[9][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/StatusOption;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V", "GetUpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void UpdateUser (string p0, string p1, string p2, string p3, string p4, global::Com.Inscripts.Enums.StatusOption p5, string p6, bool p7, global::Com.Inscripts.Interfaces.ICallbacks p8)
		{
			if (id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/StatusOption;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p6 = JNIEnv.NewString (p6);
			try {
				JValue* __args = stackalloc JValue [9];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (native_p6);
				__args [7] = new JValue (p7);
				__args [8] = new JValue (p8);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_enums_StatusOption_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/enums/StatusOption;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p6);
			}
		}

	}
}
