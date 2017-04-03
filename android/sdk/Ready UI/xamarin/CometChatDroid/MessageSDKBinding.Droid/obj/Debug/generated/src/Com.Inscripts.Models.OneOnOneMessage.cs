using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']"
	[global::Android.Runtime.Register ("com/inscripts/models/OneOnOneMessage", DoNotGenerateAcw=true)]
	public partial class OneOnOneMessage : global::Com.Orm.SugarRecord {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLOUMN_MESSAGE_TICK']"
		[Register ("COLOUMN_MESSAGE_TICK")]
		public const string ColoumnMessageTick = (string) "messagetick";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_FROM']"
		[Register ("COLUMN_FROM")]
		public const string ColumnFrom = (string) "from";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_ID']"
		[Register ("COLUMN_ID")]
		public const string ColumnId = (string) "id";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_IMAGE_URL']"
		[Register ("COLUMN_IMAGE_URL")]
		public const string ColumnImageUrl = (string) "image_url";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_MESSAGE']"
		[Register ("COLUMN_MESSAGE")]
		public const string ColumnMessage = (string) "message";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_MESSAGE_INSERTED_BY']"
		[Register ("COLUMN_MESSAGE_INSERTED_BY")]
		public const string ColumnMessageInsertedBy = (string) "inserted_by";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_SELF']"
		[Register ("COLUMN_SELF")]
		public const string ColumnSelf = (string) "self";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='COLUMN_TO']"
		[Register ("COLUMN_TO")]
		public const string ColumnTo = (string) "to";

		static IntPtr fromId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='fromId']"
		[Register ("fromId")]
		public long FromId {
			get {
				if (fromId_jfieldId == IntPtr.Zero)
					fromId_jfieldId = JNIEnv.GetFieldID (class_ref, "fromId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, fromId_jfieldId);
			}
			set {
				if (fromId_jfieldId == IntPtr.Zero)
					fromId_jfieldId = JNIEnv.GetFieldID (class_ref, "fromId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, fromId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr imageUrl_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='imageUrl']"
		[Register ("imageUrl")]
		public string ImageUrl {
			get {
				if (imageUrl_jfieldId == IntPtr.Zero)
					imageUrl_jfieldId = JNIEnv.GetFieldID (class_ref, "imageUrl", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, imageUrl_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (imageUrl_jfieldId == IntPtr.Zero)
					imageUrl_jfieldId = JNIEnv.GetFieldID (class_ref, "imageUrl", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, imageUrl_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr insertedBy_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='insertedBy']"
		[Register ("insertedBy")]
		public int InsertedBy {
			get {
				if (insertedBy_jfieldId == IntPtr.Zero)
					insertedBy_jfieldId = JNIEnv.GetFieldID (class_ref, "insertedBy", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, insertedBy_jfieldId);
			}
			set {
				if (insertedBy_jfieldId == IntPtr.Zero)
					insertedBy_jfieldId = JNIEnv.GetFieldID (class_ref, "insertedBy", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, insertedBy_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr message_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='message']"
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

		static IntPtr messagetick_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='messagetick']"
		[Register ("messagetick")]
		public int Messagetick {
			get {
				if (messagetick_jfieldId == IntPtr.Zero)
					messagetick_jfieldId = JNIEnv.GetFieldID (class_ref, "messagetick", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, messagetick_jfieldId);
			}
			set {
				if (messagetick_jfieldId == IntPtr.Zero)
					messagetick_jfieldId = JNIEnv.GetFieldID (class_ref, "messagetick", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, messagetick_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr read_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='read']"
		[Register ("read")]
		public int Read {
			get {
				if (read_jfieldId == IntPtr.Zero)
					read_jfieldId = JNIEnv.GetFieldID (class_ref, "read", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, read_jfieldId);
			}
			set {
				if (read_jfieldId == IntPtr.Zero)
					read_jfieldId = JNIEnv.GetFieldID (class_ref, "read", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, read_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr remoteId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='remoteId']"
		[Register ("remoteId")]
		public long RemoteId {
			get {
				if (remoteId_jfieldId == IntPtr.Zero)
					remoteId_jfieldId = JNIEnv.GetFieldID (class_ref, "remoteId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, remoteId_jfieldId);
			}
			set {
				if (remoteId_jfieldId == IntPtr.Zero)
					remoteId_jfieldId = JNIEnv.GetFieldID (class_ref, "remoteId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, remoteId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr self_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='self']"
		[Register ("self")]
		public int Self {
			get {
				if (self_jfieldId == IntPtr.Zero)
					self_jfieldId = JNIEnv.GetFieldID (class_ref, "self", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, self_jfieldId);
			}
			set {
				if (self_jfieldId == IntPtr.Zero)
					self_jfieldId = JNIEnv.GetFieldID (class_ref, "self", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, self_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr sentTimestamp_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='sentTimestamp']"
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

		static IntPtr toId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='toId']"
		[Register ("toId")]
		public long ToId {
			get {
				if (toId_jfieldId == IntPtr.Zero)
					toId_jfieldId = JNIEnv.GetFieldID (class_ref, "toId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, toId_jfieldId);
			}
			set {
				if (toId_jfieldId == IntPtr.Zero)
					toId_jfieldId = JNIEnv.GetFieldID (class_ref, "toId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, toId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr type_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/field[@name='type']"
		[Register ("type")]
		public string Type {
			get {
				if (type_jfieldId == IntPtr.Zero)
					type_jfieldId = JNIEnv.GetFieldID (class_ref, "type", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, type_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (type_jfieldId == IntPtr.Zero)
					type_jfieldId = JNIEnv.GetFieldID (class_ref, "type", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, type_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/models/OneOnOneMessage", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OneOnOneMessage); }
		}

		protected OneOnOneMessage (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Lorg_json_JSONObject_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/constructor[@name='OneOnOneMessage' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register (".ctor", "(Lorg/json/JSONObject;)V", "")]
		public unsafe OneOnOneMessage (global::Org.Json.JSONObject p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (OneOnOneMessage)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Lorg/json/JSONObject;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Lorg/json/JSONObject;)V", __args);
					return;
				}

				if (id_ctor_Lorg_json_JSONObject_ == IntPtr.Zero)
					id_ctor_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Lorg/json/JSONObject;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Lorg_json_JSONObject_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Lorg_json_JSONObject_, __args);
			} finally {
			}
		}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/constructor[@name='OneOnOneMessage' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe OneOnOneMessage ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (OneOnOneMessage)) {
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

		static IntPtr id_ctor_Ljava_lang_Long_JJLjava_lang_String_JIILjava_lang_String_Ljava_lang_String_Ljava_lang_Integer_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/constructor[@name='OneOnOneMessage' and count(parameter)=11 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='long'] and parameter[6][@type='int'] and parameter[7][@type='int'] and parameter[8][@type='java.lang.String'] and parameter[9][@type='java.lang.String'] and parameter[10][@type='java.lang.Integer'] and parameter[11][@type='int']]"
		[Register (".ctor", "(Ljava/lang/Long;JJLjava/lang/String;JIILjava/lang/String;Ljava/lang/String;Ljava/lang/Integer;I)V", "")]
		public unsafe OneOnOneMessage (global::Java.Lang.Long p0, long p1, long p2, string p3, long p4, int p5, int p6, string p7, string p8, global::Java.Lang.Integer p9, int p10)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p7 = JNIEnv.NewString (p7);
			IntPtr native_p8 = JNIEnv.NewString (p8);
			try {
				JValue* __args = stackalloc JValue [11];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				__args [6] = new JValue (p6);
				__args [7] = new JValue (native_p7);
				__args [8] = new JValue (native_p8);
				__args [9] = new JValue (p9);
				__args [10] = new JValue (p10);
				if (GetType () != typeof (OneOnOneMessage)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/Long;JJLjava/lang/String;JIILjava/lang/String;Ljava/lang/String;Ljava/lang/Integer;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Long;JJLjava/lang/String;JIILjava/lang/String;Ljava/lang/String;Ljava/lang/Integer;I)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_Long_JJLjava_lang_String_JIILjava_lang_String_Ljava_lang_String_Ljava_lang_Integer_I == IntPtr.Zero)
					id_ctor_Ljava_lang_Long_JJLjava_lang_String_JIILjava_lang_String_Ljava_lang_String_Ljava_lang_Integer_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Long;JJLjava/lang/String;JIILjava/lang/String;Ljava/lang/String;Ljava/lang/Integer;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Long_JJLjava_lang_String_JIILjava_lang_String_Ljava_lang_String_Ljava_lang_Integer_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Long_JJLjava_lang_String_JIILjava_lang_String_Ljava_lang_String_Ljava_lang_Integer_I, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p7);
				JNIEnv.DeleteLocalRef (native_p8);
			}
		}

		static IntPtr id_clearConversation_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/method[@name='clearConversation' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("clearConversation", "(Ljava/lang/String;)V", "")]
		public static unsafe void ClearConversation (string p0)
		{
			if (id_clearConversation_Ljava_lang_String_ == IntPtr.Zero)
				id_clearConversation_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "clearConversation", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_clearConversation_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_findById_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/method[@name='findById' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("findById", "(Ljava/lang/String;)Lcom/inscripts/models/OneOnOneMessage;", "")]
		public static unsafe global::Com.Inscripts.Models.OneOnOneMessage FindById (string p0)
		{
			if (id_findById_Ljava_lang_String_ == IntPtr.Zero)
				id_findById_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/String;)Lcom/inscripts/models/OneOnOneMessage;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Models.OneOnOneMessage __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.OneOnOneMessage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_findById_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/method[@name='findById' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("findById", "(J)Lcom/inscripts/models/OneOnOneMessage;", "")]
		public static unsafe global::Com.Inscripts.Models.OneOnOneMessage FindById (long p0)
		{
			if (id_findById_J == IntPtr.Zero)
				id_findById_J = JNIEnv.GetStaticMethodID (class_ref, "findById", "(J)Lcom/inscripts/models/OneOnOneMessage;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.OneOnOneMessage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_getAllMessages_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/method[@name='getAllMessages' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("getAllMessages", "(Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.OneOnOneMessage> GetAllMessages (string p0, string p1)
		{
			if (id_getAllMessages_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_getAllMessages_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getAllMessages", "(Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				global::System.Collections.Generic.IList<global::Com.Inscripts.Models.OneOnOneMessage> __ret = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.OneOnOneMessage>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllMessages_Ljava_lang_String_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_getAllMessages_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='OneOnOneMessage']/method[@name='getAllMessages' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("getAllMessages", "(JJ)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.OneOnOneMessage> GetAllMessages (long p0, long p1)
		{
			if (id_getAllMessages_JJ == IntPtr.Zero)
				id_getAllMessages_JJ = JNIEnv.GetStaticMethodID (class_ref, "getAllMessages", "(JJ)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return global::Android.Runtime.JavaList<global::Com.Inscripts.Models.OneOnOneMessage>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllMessages_JJ, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
