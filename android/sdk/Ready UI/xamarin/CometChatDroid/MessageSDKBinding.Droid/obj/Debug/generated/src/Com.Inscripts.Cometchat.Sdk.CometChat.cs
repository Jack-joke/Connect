using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/CometChat", DoNotGenerateAcw=true)]
	public partial class CometChat : global::Java.Lang.Object {


		static IntPtr isSubscribedCalled_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/field[@name='isSubscribedCalled']"
		[Register ("isSubscribedCalled")]
		protected static bool IsSubscribedCalled {
			get {
				if (isSubscribedCalled_jfieldId == IntPtr.Zero)
					isSubscribedCalled_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "isSubscribedCalled", "Z");
				return JNIEnv.GetStaticBooleanField (class_ref, isSubscribedCalled_jfieldId);
			}
			set {
				if (isSubscribedCalled_jfieldId == IntPtr.Zero)
					isSubscribedCalled_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "isSubscribedCalled", "Z");
				try {
					JNIEnv.SetStaticField (class_ref, isSubscribedCalled_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr useHTML_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/field[@name='useHTML']"
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
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/CometChat", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometChat); }
		}

		protected CometChat (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_isLoggedIn;
		public static unsafe bool IsLoggedIn {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='isLoggedIn' and count(parameter)=0]"
			[Register ("isLoggedIn", "()Z", "GetIsLoggedInHandler")]
			get {
				if (id_isLoggedIn == IntPtr.Zero)
					id_isLoggedIn = JNIEnv.GetStaticMethodID (class_ref, "isLoggedIn", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isLoggedIn);
				} finally {
				}
			}
		}

		static IntPtr id_getSDKVersion;
		public static unsafe string SDKVersion {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getSDKVersion' and count(parameter)=0]"
			[Register ("getSDKVersion", "()Ljava/lang/String;", "GetGetSDKVersionHandler")]
			get {
				if (id_getSDKVersion == IntPtr.Zero)
					id_getSDKVersion = JNIEnv.GetStaticMethodID (class_ref, "getSDKVersion", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSDKVersion), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

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
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddFriends (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='addFriends' and count(parameter)=2 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
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

		static Delegate cb_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetBlockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_BlockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_BlockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.BlockUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='blockUser' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("blockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetBlockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void BlockUser (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "blockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_blockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "blockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetBroadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_BroadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_);
			return cb_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_BroadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p1 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.BroadcastMessage (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='broadcastMessage' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='org.json.JSONArray'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("broadcastMessage", "(Ljava/lang/String;Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V", "GetBroadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void BroadcastMessage (string p0, global::Org.Json.JSONArray p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "broadcastMessage", "(Ljava/lang/String;Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_broadcastMessage_Ljava_lang_String_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "broadcastMessage", "(Ljava/lang/String;Lorg/json/JSONArray;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetCreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_CreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_);
			return cb_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_CreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p4 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p4, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p5 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p5, JniHandleOwnership.DoNotTransfer);
			__this.CreateUser (p0, p1, p2, p3, p4, p5);
		}
#pragma warning restore 0169

		static IntPtr id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='createUser' and count(parameter)=6 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.io.File'] and parameter[6][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V", "GetCreateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void CreateUser (string p0, string p1, string p2, string p3, global::Java.IO.File p4, global::Com.Inscripts.Interfaces.ICallbacks p5)
		{
			if (id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_createUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "createUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static Delegate cb_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetAllAnnouncements (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getAllAnnouncements' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getAllAnnouncements", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetAllAnnouncements (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getAllAnnouncements", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getAllAnnouncements_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAllAnnouncements", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetBlockedUserList_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetBlockedUserList_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetBlockedUserList_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetBlockedUserList (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getBlockedUserList' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getBlockedUserList", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetBlockedUserList_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetBlockedUserList (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getBlockedUserList", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getBlockedUserList_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBlockedUserList", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.GetChatHistory (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getChatHistory' and count(parameter)=3 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='java.lang.Long'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V", "GetGetChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetChatHistory (global::Java.Lang.Long p0, global::Java.Lang.Long p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getChatHistory_Ljava_lang_Long_Ljava_lang_Long_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatHistory", "(Ljava/lang/Long;Ljava/lang/Long;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static IntPtr id_getInstance_Landroid_content_Context_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getInstance' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String']]"
		[Register ("getInstance", "(Landroid/content/Context;Ljava/lang/String;)Lcom/inscripts/cometchat/sdk/CometChat;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.CometChat GetInstance (global::Android.Content.Context p0, string p1)
		{
			if (id_getInstance_Landroid_content_Context_Ljava_lang_String_ == IntPtr.Zero)
				id_getInstance_Landroid_content_Context_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "(Landroid/content/Context;Ljava/lang/String;)Lcom/inscripts/cometchat/sdk/CometChat;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				global::Com.Inscripts.Cometchat.Sdk.CometChat __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance_Landroid_content_Context_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetOnlineUsers_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetOnlineUsers_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetOnlineUsers_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetOnlineUsers (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getOnlineUsers' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getOnlineUsers", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetOnlineUsers_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetOnlineUsers (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getOnlineUsers", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getOnlineUsers_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getOnlineUsers", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetPluginInfo_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetPluginInfo_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetPluginInfo_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetPluginInfo (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getPluginInfo' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getPluginInfo", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetPluginInfo_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetPluginInfo (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getPluginInfo", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getPluginInfo_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPluginInfo", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_GetSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.GetSinglePlayerGamesUrl (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getSinglePlayerGamesUrl' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getSinglePlayerGamesUrl", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetGetSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetSinglePlayerGamesUrl (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getSinglePlayerGamesUrl", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getSinglePlayerGamesUrl_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSinglePlayerGamesUrl", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGetUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GetUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.GetUserInfo (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='getUserInfo' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("getUserInfo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetGetUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GetUserInfo (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "getUserInfo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getUserInfo_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUserInfo", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetGuestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GuestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_GuestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.GuestLogin (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='guestLogin' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("guestLogin", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetGuestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void GuestLogin (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "guestLogin", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_guestLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "guestLogin", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetIsCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_IsCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_IsCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.IsCometChatInstalled (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='isCometChatInstalled' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("isCometChatInstalled", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetIsCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void IsCometChatInstalled (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "isCometChatInstalled", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_isCometChatInstalled_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCometChatInstalled", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetIsTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool, IntPtr, IntPtr>) n_IsTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_IsTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, bool p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.IsTyping (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='isTyping' and count(parameter)=3 and parameter[1][@type='boolean'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("isTyping", "(ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetIsTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void IsTyping (bool p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "isTyping", "(ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_isTyping_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isTyping", "(ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_Login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_Login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.Login (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='login' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("login", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetLogin_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void Login (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "login", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_login_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "login", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_Login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_Login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.Login (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='login' and count(parameter)=4 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("login", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void Login (string p0, string p1, string p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "login", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
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
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_login_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "login", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static Delegate cb_logout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetLogout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_logout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_logout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Logout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_logout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_Logout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p0 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Logout (p0);
		}
#pragma warning restore 0169

		static IntPtr id_logout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='logout' and count(parameter)=1 and parameter[1][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("logout", "(Lcom/inscripts/interfaces/Callbacks;)V", "GetLogout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void Logout (global::Com.Inscripts.Interfaces.ICallbacks p0)
		{
			if (id_logout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_logout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "logout", "(Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_logout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "logout", "(Lcom/inscripts/interfaces/Callbacks;)V"), __args);
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
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONArray p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.RemoveFriends (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_removeFriends_Lorg_json_JSONArray_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='removeFriends' and count(parameter)=2 and parameter[1][@type='org.json.JSONArray'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
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
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.RemoveUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_removeUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='removeUser' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
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

		static Delegate cb_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetReportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ReportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_ReportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.ReportConversation (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='reportConversation' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("reportConversation", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetReportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void ReportConversation (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "reportConversation", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_reportConversation_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "reportConversation", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendAudioFile (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendAudioFile' and count(parameter)=3 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendAudioFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendAudioFile (global::Java.IO.File p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendAudioFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAudioFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAudioFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendDeliverdReceipt (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendDeliverdReceipt' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendDeliverdReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendDeliverdReceipt (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendDeliverdReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendDeliverdReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendDeliverdReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendFile (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendFile' and count(parameter)=3 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendFile (global::Java.IO.File p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendFile_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendFile", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImage (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendImage' and count(parameter)=3 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImage", "(Landroid/graphics/Bitmap;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImage (global::Android.Graphics.Bitmap p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImage", "(Landroid/graphics/Bitmap;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImage_Landroid_graphics_Bitmap_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImage", "(Landroid/graphics/Bitmap;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImage (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendImage' and count(parameter)=3 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImage", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImage (global::Java.IO.File p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImage", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImage_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImage", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
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
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendMessage (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendMessage_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendMessage' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
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

		static Delegate cb_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendReadReceipt (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendReadReceipt' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendReadReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendReadReceipt (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendReadReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendReadReceipt_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendReadReceipt", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendSticker (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendSticker' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendSticker", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendSticker (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendSticker", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendSticker_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendSticker", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendVideo (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendVideo' and count(parameter)=3 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendVideo", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendVideo (global::Java.IO.File p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendVideo", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendVideo_Ljava_io_File_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendVideo", "(Ljava/io/File;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendVideo (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendVideo' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendVideo", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendVideo (string p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendVideo", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendVideo_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendVideo", "(Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendWhiteBoardRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendWhiteBoardRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendWhiteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendWhiteBoardRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendWhiteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendWhiteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendWhiteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendWriteBoardRequest (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='sendWriteBoardRequest' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendWriteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendWriteBoardRequest (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendWriteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendWriteBoardRequest_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendWriteBoardRequest", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setCometChatUrl_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCometChatUrl_Ljava_lang_String_Handler ()
		{
			if (cb_setCometChatUrl_Ljava_lang_String_ == null)
				cb_setCometChatUrl_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCometChatUrl_Ljava_lang_String_);
			return cb_setCometChatUrl_Ljava_lang_String_;
		}

		static void n_SetCometChatUrl_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetCometChatUrl (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setCometChatUrl_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='setCometChatUrl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setCometChatUrl", "(Ljava/lang/String;)V", "GetSetCometChatUrl_Ljava_lang_String_Handler")]
		public virtual unsafe void SetCometChatUrl (string p0)
		{
			if (id_setCometChatUrl_Ljava_lang_String_ == IntPtr.Zero)
				id_setCometChatUrl_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCometChatUrl", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCometChatUrl_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCometChatUrl", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_setDevelopmentMode_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='setDevelopmentMode' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setDevelopmentMode", "(Z)V", "")]
		public static unsafe void SetDevelopmentMode (bool p0)
		{
			if (id_setDevelopmentMode_Z == IntPtr.Zero)
				id_setDevelopmentMode_Z = JNIEnv.GetStaticMethodID (class_ref, "setDevelopmentMode", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setDevelopmentMode_Z, __args);
			} finally {
			}
		}

		static Delegate cb_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSetStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SetStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_);
			return cb_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SetStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Enums.StatusOption p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.StatusOption> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetStatus (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='setStatus' and count(parameter)=2 and parameter[1][@type='com.inscripts.enums.StatusOption'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("setStatus", "(Lcom/inscripts/enums/StatusOption;Lcom/inscripts/interfaces/Callbacks;)V", "GetSetStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SetStatus (global::Com.Inscripts.Enums.StatusOption p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "setStatus", "(Lcom/inscripts/enums/StatusOption;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setStatus_Lcom_inscripts_enums_StatusOption_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStatus", "(Lcom/inscripts/enums/StatusOption;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSetStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SetStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SetStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetStatusMessage (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='setStatusMessage' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("setStatusMessage", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSetStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SetStatusMessage (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "setStatusMessage", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setStatusMessage_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStatusMessage", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSetTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_SetTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_);
			return cb_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SetTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Enums.Languages p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.Languages> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetTranslateLanguage (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='setTranslateLanguage' and count(parameter)=2 and parameter[1][@type='com.inscripts.enums.Languages'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("setTranslateLanguage", "(Lcom/inscripts/enums/Languages;Lcom/inscripts/interfaces/Callbacks;)V", "GetSetTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SetTranslateLanguage (global::Com.Inscripts.Enums.Languages p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "setTranslateLanguage", "(Lcom/inscripts/enums/Languages;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setTranslateLanguage_Lcom_inscripts_enums_Languages_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setTranslateLanguage", "(Lcom/inscripts/enums/Languages;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_;
#pragma warning disable 0169
		static Delegate GetSubscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_Handler ()
		{
			if (cb_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_ == null)
				cb_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool, IntPtr>) n_Subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_);
			return cb_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_;
		}

		static void n_Subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_ (IntPtr jnienv, IntPtr native__this, bool p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Subscribe (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='subscribe' and count(parameter)=2 and parameter[1][@type='boolean'] and parameter[2][@type='com.inscripts.interfaces.SubscribeCallbacks']]"
		[Register ("subscribe", "(ZLcom/inscripts/interfaces/SubscribeCallbacks;)V", "GetSubscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_Handler")]
		public virtual unsafe void Subscribe (bool p0, global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1)
		{
			if (id_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_ == IntPtr.Zero)
				id_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_ = JNIEnv.GetMethodID (class_ref, "subscribe", "(ZLcom/inscripts/interfaces/SubscribeCallbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_subscribe_ZLcom_inscripts_interfaces_SubscribeCallbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "subscribe", "(ZLcom/inscripts/interfaces/SubscribeCallbacks;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetUnblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_UnblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_UnblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p1 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.UnblockUser (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='unblockUser' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("unblockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetUnblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void UnblockUser (string p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "unblockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_unblockUser_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unblockUser", "(Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Unsubscribe ();
		}
#pragma warning restore 0169

		static IntPtr id_unsubscribe;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='unsubscribe' and count(parameter)=0]"
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

		static Delegate cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetUpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == null)
				cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_UpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_);
			return cb_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		}

		static void n_UpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4, IntPtr native_p5, bool p6, IntPtr native_p7)
		{
			global::Com.Inscripts.Cometchat.Sdk.CometChat __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.CometChat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p4 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p4, JniHandleOwnership.DoNotTransfer);
			string p5 = JNIEnv.GetString (native_p5, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p7 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p7, JniHandleOwnership.DoNotTransfer);
			__this.UpdateUser (p0, p1, p2, p3, p4, p5, p6, p7);
		}
#pragma warning restore 0169

		static IntPtr id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='CometChat']/method[@name='updateUser' and count(parameter)=8 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.io.File'] and parameter[6][@type='java.lang.String'] and parameter[7][@type='boolean'] and parameter[8][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V", "GetUpdateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void UpdateUser (string p0, string p1, string p2, string p3, global::Java.IO.File p4, string p5, bool p6, global::Com.Inscripts.Interfaces.ICallbacks p7)
		{
			if (id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [8];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				__args [6] = new JValue (p6);
				__args [7] = new JValue (p7);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_updateUser_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "updateUser", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

	}
}
