using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']"
	[global::Android.Runtime.Register ("com/inscripts/models/Buddy", DoNotGenerateAcw=true)]
	public partial class Buddy : global::Com.Orm.SugarRecord {


		static IntPtr avatarURL_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='avatarURL']"
		[Register ("avatarURL")]
		public string AvatarURL {
			get {
				if (avatarURL_jfieldId == IntPtr.Zero)
					avatarURL_jfieldId = JNIEnv.GetFieldID (class_ref, "avatarURL", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, avatarURL_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (avatarURL_jfieldId == IntPtr.Zero)
					avatarURL_jfieldId = JNIEnv.GetFieldID (class_ref, "avatarURL", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, avatarURL_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr buddyId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='buddyId']"
		[Register ("buddyId")]
		public long BuddyId {
			get {
				if (buddyId_jfieldId == IntPtr.Zero)
					buddyId_jfieldId = JNIEnv.GetFieldID (class_ref, "buddyId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, buddyId_jfieldId);
			}
			set {
				if (buddyId_jfieldId == IntPtr.Zero)
					buddyId_jfieldId = JNIEnv.GetFieldID (class_ref, "buddyId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, buddyId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr cometid_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='cometid']"
		[Register ("cometid")]
		public string Cometid {
			get {
				if (cometid_jfieldId == IntPtr.Zero)
					cometid_jfieldId = JNIEnv.GetFieldID (class_ref, "cometid", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, cometid_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (cometid_jfieldId == IntPtr.Zero)
					cometid_jfieldId = JNIEnv.GetFieldID (class_ref, "cometid", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, cometid_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr lastUpdated_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='lastUpdated']"
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

		static IntPtr lastseen_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='lastseen']"
		[Register ("lastseen")]
		public string Lastseen {
			get {
				if (lastseen_jfieldId == IntPtr.Zero)
					lastseen_jfieldId = JNIEnv.GetFieldID (class_ref, "lastseen", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, lastseen_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (lastseen_jfieldId == IntPtr.Zero)
					lastseen_jfieldId = JNIEnv.GetFieldID (class_ref, "lastseen", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, lastseen_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr link_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='link']"
		[Register ("link")]
		public string Link {
			get {
				if (link_jfieldId == IntPtr.Zero)
					link_jfieldId = JNIEnv.GetFieldID (class_ref, "link", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, link_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (link_jfieldId == IntPtr.Zero)
					link_jfieldId = JNIEnv.GetFieldID (class_ref, "link", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, link_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr lstn_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='lstn']"
		[Register ("lstn")]
		public int Lstn {
			get {
				if (lstn_jfieldId == IntPtr.Zero)
					lstn_jfieldId = JNIEnv.GetFieldID (class_ref, "lstn", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, lstn_jfieldId);
			}
			set {
				if (lstn_jfieldId == IntPtr.Zero)
					lstn_jfieldId = JNIEnv.GetFieldID (class_ref, "lstn", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, lstn_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr name_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='name']"
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

		static IntPtr showuser_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='showuser']"
		[Register ("showuser")]
		public int Showuser {
			get {
				if (showuser_jfieldId == IntPtr.Zero)
					showuser_jfieldId = JNIEnv.GetFieldID (class_ref, "showuser", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, showuser_jfieldId);
			}
			set {
				if (showuser_jfieldId == IntPtr.Zero)
					showuser_jfieldId = JNIEnv.GetFieldID (class_ref, "showuser", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, showuser_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr status_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='status']"
		[Register ("status")]
		public string Status {
			get {
				if (status_jfieldId == IntPtr.Zero)
					status_jfieldId = JNIEnv.GetFieldID (class_ref, "status", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, status_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (status_jfieldId == IntPtr.Zero)
					status_jfieldId = JNIEnv.GetFieldID (class_ref, "status", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, status_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr statusMessage_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='statusMessage']"
		[Register ("statusMessage")]
		public string StatusMessage {
			get {
				if (statusMessage_jfieldId == IntPtr.Zero)
					statusMessage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusMessage", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, statusMessage_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (statusMessage_jfieldId == IntPtr.Zero)
					statusMessage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusMessage", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, statusMessage_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr unreadCount_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/field[@name='unreadCount']"
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
				return JNIEnv.FindClass ("com/inscripts/models/Buddy", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Buddy); }
		}

		protected Buddy (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/constructor[@name='Buddy' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Buddy ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Buddy)) {
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

		static IntPtr id_getAllVisibieBuddies;
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> AllVisibieBuddies {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getAllVisibieBuddies' and count(parameter)=0]"
			[Register ("getAllVisibieBuddies", "()Ljava/util/List;", "GetGetAllVisibieBuddiesHandler")]
			get {
				if (id_getAllVisibieBuddies == IntPtr.Zero)
					id_getAllVisibieBuddies = JNIEnv.GetStaticMethodID (class_ref, "getAllVisibieBuddies", "()Ljava/util/List;");
				try {
					return global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Buddy>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllVisibieBuddies), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getUnreadBuddyCount;
		public static unsafe int UnreadBuddyCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getUnreadBuddyCount' and count(parameter)=0]"
			[Register ("getUnreadBuddyCount", "()I", "GetGetUnreadBuddyCountHandler")]
			get {
				if (id_getUnreadBuddyCount == IntPtr.Zero)
					id_getUnreadBuddyCount = JNIEnv.GetStaticMethodID (class_ref, "getUnreadBuddyCount", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getUnreadBuddyCount);
				} finally {
				}
			}
		}

		static IntPtr id_getBuddyDetails_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getBuddyDetails' and count(parameter)=1 and parameter[1][@type='java.lang.Integer']]"
		[Register ("getBuddyDetails", "(Ljava/lang/Integer;)Lcom/inscripts/models/Buddy;", "")]
		public static unsafe global::Com.Inscripts.Models.Buddy GetBuddyDetails (global::Java.Lang.Integer p0)
		{
			if (id_getBuddyDetails_Ljava_lang_Integer_ == IntPtr.Zero)
				id_getBuddyDetails_Ljava_lang_Integer_ = JNIEnv.GetStaticMethodID (class_ref, "getBuddyDetails", "(Ljava/lang/Integer;)Lcom/inscripts/models/Buddy;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.Buddy __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Buddy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBuddyDetails_Ljava_lang_Integer_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getBuddyDetails_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getBuddyDetails' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("getBuddyDetails", "(Ljava/lang/Long;)Lcom/inscripts/models/Buddy;", "")]
		public static unsafe global::Com.Inscripts.Models.Buddy GetBuddyDetails (global::Java.Lang.Long p0)
		{
			if (id_getBuddyDetails_Ljava_lang_Long_ == IntPtr.Zero)
				id_getBuddyDetails_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "getBuddyDetails", "(Ljava/lang/Long;)Lcom/inscripts/models/Buddy;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.Buddy __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Buddy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBuddyDetails_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getBuddyDetails_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getBuddyDetails' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getBuddyDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Buddy;", "")]
		public static unsafe global::Com.Inscripts.Models.Buddy GetBuddyDetails (string p0)
		{
			if (id_getBuddyDetails_Ljava_lang_String_ == IntPtr.Zero)
				id_getBuddyDetails_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getBuddyDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Buddy;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Models.Buddy __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Buddy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBuddyDetails_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getExternalBuddies_Ljava_util_Set_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='getExternalBuddies' and count(parameter)=1 and parameter[1][@type='java.util.Set&lt;java.lang.String&gt;']]"
		[Register ("getExternalBuddies", "(Ljava/util/Set;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> GetExternalBuddies (global::System.Collections.Generic.ICollection<string> p0)
		{
			if (id_getExternalBuddies_Ljava_util_Set_ == IntPtr.Zero)
				id_getExternalBuddies_Ljava_util_Set_ = JNIEnv.GetStaticMethodID (class_ref, "getExternalBuddies", "(Ljava/util/Set;)Ljava/util/List;");
			IntPtr native_p0 = global::Android.Runtime.JavaSet<string>.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> __ret = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Buddy>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getExternalBuddies_Ljava_util_Set_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_insertNewBuddy_Lorg_json_JSONObject_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='insertNewBuddy' and count(parameter)=2 and parameter[1][@type='org.json.JSONObject'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("insertNewBuddy", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/Callbacks;)V", "")]
		public static unsafe void InsertNewBuddy (global::Org.Json.JSONObject p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_insertNewBuddy_Lorg_json_JSONObject_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_insertNewBuddy_Lorg_json_JSONObject_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetStaticMethodID (class_ref, "insertNewBuddy", "(Lorg/json/JSONObject;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_insertNewBuddy_Lorg_json_JSONObject_Lcom_inscripts_interfaces_Callbacks_, __args);
			} finally {
			}
		}

		static IntPtr id_searchBuddies_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='searchBuddies' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("searchBuddies", "(Ljava/lang/String;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> SearchBuddies (string p0)
		{
			if (id_searchBuddies_Ljava_lang_String_ == IntPtr.Zero)
				id_searchBuddies_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "searchBuddies", "(Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> __ret = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Buddy>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_searchBuddies_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_searchBuddy_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='searchBuddy' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("searchBuddy", "(J)Lcom/inscripts/models/Buddy;", "")]
		public static unsafe global::Com.Inscripts.Models.Buddy SearchBuddy (long p0)
		{
			if (id_searchBuddy_J == IntPtr.Zero)
				id_searchBuddy_J = JNIEnv.GetStaticMethodID (class_ref, "searchBuddy", "(J)Lcom/inscripts/models/Buddy;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Buddy> (JNIEnv.CallStaticObjectMethod  (class_ref, id_searchBuddy_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_updateAllBuddies_Lorg_json_JSONArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='updateAllBuddies' and count(parameter)=1 and parameter[1][@type='org.json.JSONArray']]"
		[Register ("updateAllBuddies", "(Lorg/json/JSONArray;)V", "")]
		public static unsafe void UpdateAllBuddies (global::Org.Json.JSONArray p0)
		{
			if (id_updateAllBuddies_Lorg_json_JSONArray_ == IntPtr.Zero)
				id_updateAllBuddies_Lorg_json_JSONArray_ = JNIEnv.GetStaticMethodID (class_ref, "updateAllBuddies", "(Lorg/json/JSONArray;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_updateAllBuddies_Lorg_json_JSONArray_, __args);
			} finally {
			}
		}

		static IntPtr id_updateAllBuddies_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Buddy']/method[@name='updateAllBuddies' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("updateAllBuddies", "(Lorg/json/JSONObject;)V", "")]
		public static unsafe void UpdateAllBuddies (global::Org.Json.JSONObject p0)
		{
			if (id_updateAllBuddies_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_updateAllBuddies_Lorg_json_JSONObject_ = JNIEnv.GetStaticMethodID (class_ref, "updateAllBuddies", "(Lorg/json/JSONObject;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_updateAllBuddies_Lorg_json_JSONObject_, __args);
			} finally {
			}
		}

	}
}
