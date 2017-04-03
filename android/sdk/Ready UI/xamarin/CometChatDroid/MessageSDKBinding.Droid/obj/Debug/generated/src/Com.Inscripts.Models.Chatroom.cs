using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']"
	[global::Android.Runtime.Register ("com/inscripts/models/Chatroom", DoNotGenerateAcw=true)]
	public partial class Chatroom : global::Com.Orm.SugarRecord {


		static IntPtr chatroomId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='chatroomId']"
		[Register ("chatroomId")]
		public long ChatroomId {
			get {
				if (chatroomId_jfieldId == IntPtr.Zero)
					chatroomId_jfieldId = JNIEnv.GetFieldID (class_ref, "chatroomId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, chatroomId_jfieldId);
			}
			set {
				if (chatroomId_jfieldId == IntPtr.Zero)
					chatroomId_jfieldId = JNIEnv.GetFieldID (class_ref, "chatroomId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, chatroomId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr createdBy_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='createdBy']"
		[Register ("createdBy")]
		public int CreatedBy {
			get {
				if (createdBy_jfieldId == IntPtr.Zero)
					createdBy_jfieldId = JNIEnv.GetFieldID (class_ref, "createdBy", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, createdBy_jfieldId);
			}
			set {
				if (createdBy_jfieldId == IntPtr.Zero)
					createdBy_jfieldId = JNIEnv.GetFieldID (class_ref, "createdBy", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, createdBy_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr lastUpdated_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='lastUpdated']"
		[Register ("lastUpdated")]
		public long LastUpdated {
			get {
				if (lastUpdated_jfieldId == IntPtr.Zero)
					lastUpdated_jfieldId = JNIEnv.GetFieldID (class_ref, "lastUpdated", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, lastUpdated_jfieldId);
			}
			set {
				if (lastUpdated_jfieldId == IntPtr.Zero)
					lastUpdated_jfieldId = JNIEnv.GetFieldID (class_ref, "lastUpdated", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, lastUpdated_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr memberCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='memberCount']"
		[Register ("memberCount")]
		public int MemberCount {
			get {
				if (memberCount_jfieldId == IntPtr.Zero)
					memberCount_jfieldId = JNIEnv.GetFieldID (class_ref, "memberCount", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, memberCount_jfieldId);
			}
			set {
				if (memberCount_jfieldId == IntPtr.Zero)
					memberCount_jfieldId = JNIEnv.GetFieldID (class_ref, "memberCount", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, memberCount_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr name_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='name']"
		[Register ("name")]
		public string Name {
			get {
				if (name_jfieldId == IntPtr.Zero)
					name_jfieldId = JNIEnv.GetFieldID (class_ref, "name", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, name_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (name_jfieldId == IntPtr.Zero)
					name_jfieldId = JNIEnv.GetFieldID (class_ref, "name", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, name_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr onlineCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='onlineCount']"
		[Register ("onlineCount")]
		public int OnlineCount {
			get {
				if (onlineCount_jfieldId == IntPtr.Zero)
					onlineCount_jfieldId = JNIEnv.GetFieldID (class_ref, "onlineCount", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, onlineCount_jfieldId);
			}
			set {
				if (onlineCount_jfieldId == IntPtr.Zero)
					onlineCount_jfieldId = JNIEnv.GetFieldID (class_ref, "onlineCount", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, onlineCount_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr password_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='password']"
		[Register ("password")]
		public string Password {
			get {
				if (password_jfieldId == IntPtr.Zero)
					password_jfieldId = JNIEnv.GetFieldID (class_ref, "password", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, password_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (password_jfieldId == IntPtr.Zero)
					password_jfieldId = JNIEnv.GetFieldID (class_ref, "password", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, password_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr status_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='status']"
		[Register ("status")]
		public int Status {
			get {
				if (status_jfieldId == IntPtr.Zero)
					status_jfieldId = JNIEnv.GetFieldID (class_ref, "status", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, status_jfieldId);
			}
			set {
				if (status_jfieldId == IntPtr.Zero)
					status_jfieldId = JNIEnv.GetFieldID (class_ref, "status", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, status_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr type_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='type']"
		[Register ("type")]
		public int Type {
			get {
				if (type_jfieldId == IntPtr.Zero)
					type_jfieldId = JNIEnv.GetFieldID (class_ref, "type", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, type_jfieldId);
			}
			set {
				if (type_jfieldId == IntPtr.Zero)
					type_jfieldId = JNIEnv.GetFieldID (class_ref, "type", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, type_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr unreadCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/field[@name='unreadCount']"
		[Register ("unreadCount")]
		public int UnreadCount {
			get {
				if (unreadCount_jfieldId == IntPtr.Zero)
					unreadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "unreadCount", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, unreadCount_jfieldId);
			}
			set {
				if (unreadCount_jfieldId == IntPtr.Zero)
					unreadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "unreadCount", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, unreadCount_jfieldId, value);
				} finally {
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/models/Chatroom", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Chatroom); }
		}

		protected Chatroom (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/constructor[@name='Chatroom' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Chatroom ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Chatroom)) {
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

		static IntPtr id_getAllChatrooms;
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Chatroom> AllChatrooms {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='getAllChatrooms' and count(parameter)=0]"
			[Register ("getAllChatrooms", "()Ljava/util/List;", "GetGetAllChatroomsHandler")]
			get {
				if (id_getAllChatrooms == IntPtr.Zero)
					id_getAllChatrooms = JNIEnv.GetStaticMethodID (class_ref, "getAllChatrooms", "()Ljava/util/List;");
				try {
					return global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Chatroom>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllChatrooms), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_deleteChatroom_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='deleteChatroom' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("deleteChatroom", "(Ljava/lang/Long;)V", "")]
		public static unsafe void DeleteChatroom (global::Java.Lang.Long p0)
		{
			if (id_deleteChatroom_Ljava_lang_Long_ == IntPtr.Zero)
				id_deleteChatroom_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "deleteChatroom", "(Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteChatroom_Ljava_lang_Long_, __args);
			} finally {
			}
		}

		static IntPtr id_getChatroomDetails_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='getChatroomDetails' and count(parameter)=1 and parameter[1][@type='java.lang.Integer']]"
		[Register ("getChatroomDetails", "(Ljava/lang/Integer;)Lcom/inscripts/models/Chatroom;", "")]
		public static unsafe global::Com.Inscripts.Models.Chatroom GetChatroomDetails (global::Java.Lang.Integer p0)
		{
			if (id_getChatroomDetails_Ljava_lang_Integer_ == IntPtr.Zero)
				id_getChatroomDetails_Ljava_lang_Integer_ = JNIEnv.GetStaticMethodID (class_ref, "getChatroomDetails", "(Ljava/lang/Integer;)Lcom/inscripts/models/Chatroom;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.Chatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Chatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomDetails_Ljava_lang_Integer_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getChatroomDetails_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='getChatroomDetails' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("getChatroomDetails", "(Ljava/lang/Long;)Lcom/inscripts/models/Chatroom;", "")]
		public static unsafe global::Com.Inscripts.Models.Chatroom GetChatroomDetails (global::Java.Lang.Long p0)
		{
			if (id_getChatroomDetails_Ljava_lang_Long_ == IntPtr.Zero)
				id_getChatroomDetails_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "getChatroomDetails", "(Ljava/lang/Long;)Lcom/inscripts/models/Chatroom;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.Chatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Chatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomDetails_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getChatroomDetails_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='getChatroomDetails' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getChatroomDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Chatroom;", "")]
		public static unsafe global::Com.Inscripts.Models.Chatroom GetChatroomDetails (string p0)
		{
			if (id_getChatroomDetails_Ljava_lang_String_ == IntPtr.Zero)
				id_getChatroomDetails_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getChatroomDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Chatroom;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Models.Chatroom __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Chatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomDetails_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_searchChatrooms_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='searchChatrooms' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("searchChatrooms", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Chatroom> SearchChatrooms (string p0)
		{
			if (id_searchChatrooms_Ljava_lang_String_ == IntPtr.Zero)
				id_searchChatrooms_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "searchChatrooms", "(Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Chatroom> __ret = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Chatroom>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_searchChatrooms_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_updateAllChatrooms_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Chatroom']/method[@name='updateAllChatrooms' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("updateAllChatrooms", "(Lorg/json/JSONObject;)V", "")]
		public static unsafe void UpdateAllChatrooms (global::Org.Json.JSONObject p0)
		{
			if (id_updateAllChatrooms_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_updateAllChatrooms_Lorg_json_JSONObject_ = JNIEnv.GetStaticMethodID (class_ref, "updateAllChatrooms", "(Lorg/json/JSONObject;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_updateAllChatrooms_Lorg_json_JSONObject_, __args);
			} finally {
			}
		}

	}
}
