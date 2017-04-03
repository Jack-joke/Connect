using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']"
	[global::Android.Runtime.Register ("com/inscripts/models/Announcement", DoNotGenerateAcw=true)]
	public partial class Announcement : global::Com.Orm.SugarRecord {


		static IntPtr announcementId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/field[@name='announcementId']"
		[Register ("announcementId")]
		public long AnnouncementId {
			get {
				if (announcementId_jfieldId == IntPtr.Zero)
					announcementId_jfieldId = JNIEnv.GetFieldID (class_ref, "announcementId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, announcementId_jfieldId);
			}
			set {
				if (announcementId_jfieldId == IntPtr.Zero)
					announcementId_jfieldId = JNIEnv.GetFieldID (class_ref, "announcementId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, announcementId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr message_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/field[@name='message']"
		[Register ("message")]
		public string Message {
			get {
				if (message_jfieldId == IntPtr.Zero)
					message_jfieldId = JNIEnv.GetFieldID (class_ref, "message", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, message_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (message_jfieldId == IntPtr.Zero)
					message_jfieldId = JNIEnv.GetFieldID (class_ref, "message", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, message_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr sentTimestamp_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/field[@name='sentTimestamp']"
		[Register ("sentTimestamp")]
		public long SentTimestamp {
			get {
				if (sentTimestamp_jfieldId == IntPtr.Zero)
					sentTimestamp_jfieldId = JNIEnv.GetFieldID (class_ref, "sentTimestamp", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, sentTimestamp_jfieldId);
			}
			set {
				if (sentTimestamp_jfieldId == IntPtr.Zero)
					sentTimestamp_jfieldId = JNIEnv.GetFieldID (class_ref, "sentTimestamp", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, sentTimestamp_jfieldId, value);
				} finally {
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/models/Announcement", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Announcement); }
		}

		protected Announcement (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/constructor[@name='Announcement' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Announcement ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Announcement)) {
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

		static IntPtr id_getAllAnnouncements;
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Announcement> AllAnnouncements {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/method[@name='getAllAnnouncements' and count(parameter)=0]"
			[Register ("getAllAnnouncements", "()Ljava/util/List;", "GetGetAllAnnouncementsHandler")]
			get {
				if (id_getAllAnnouncements == IntPtr.Zero)
					id_getAllAnnouncements = JNIEnv.GetStaticMethodID (class_ref, "getAllAnnouncements", "()Ljava/util/List;");
				try {
					return global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Announcement>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllAnnouncements), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_deleteAnnouncement_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/method[@name='deleteAnnouncement' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("deleteAnnouncement", "(Ljava/lang/Long;)V", "")]
		public static unsafe void DeleteAnnouncement (global::Java.Lang.Long p0)
		{
			if (id_deleteAnnouncement_Ljava_lang_Long_ == IntPtr.Zero)
				id_deleteAnnouncement_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "deleteAnnouncement", "(Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteAnnouncement_Ljava_lang_Long_, __args);
			} finally {
			}
		}

		static IntPtr id_findById_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/method[@name='findById' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("findById", "(Ljava/lang/Long;)Lcom/inscripts/models/Announcement;", "")]
		public static unsafe global::Com.Inscripts.Models.Announcement FindById (global::Java.Lang.Long p0)
		{
			if (id_findById_Ljava_lang_Long_ == IntPtr.Zero)
				id_findById_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/Long;)Lcom/inscripts/models/Announcement;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.Announcement __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Announcement> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_updateAnnouncements_Lorg_json_JSONObject_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Announcement']/method[@name='updateAnnouncements' and count(parameter)=2 and parameter[1][@type='org.json.JSONObject'] and parameter[2][@type='int']]"
		[Register ("updateAnnouncements", "(Lorg/json/JSONObject;I)V", "")]
		public static unsafe void UpdateAnnouncements (global::Org.Json.JSONObject p0, int p1)
		{
			if (id_updateAnnouncements_Lorg_json_JSONObject_I == IntPtr.Zero)
				id_updateAnnouncements_Lorg_json_JSONObject_I = JNIEnv.GetStaticMethodID (class_ref, "updateAnnouncements", "(Lorg/json/JSONObject;I)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_updateAnnouncements_Lorg_json_JSONObject_I, __args);
			} finally {
			}
		}

	}
}
