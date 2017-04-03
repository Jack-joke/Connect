using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']"
	[global::Android.Runtime.Register ("com/inscripts/models/ChatroomMessage", DoNotGenerateAcw=true)]
	public partial class ChatroomMessage : global::Com.Orm.SugarRecord {


		static IntPtr chatroomId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='chatroomId']"
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

		static IntPtr fromId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='fromId']"
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

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='imageUrl']"
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

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='insertedBy']"
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

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='message']"
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

		static IntPtr remoteId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='remoteId']"
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

		static IntPtr senderName_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='senderName']"
		[Register ("senderName")]
		public string SenderName {
			get {
				if (senderName_jfieldId == IntPtr.Zero)
					senderName_jfieldId = JNIEnv.GetFieldID (class_ref, "senderName", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, senderName_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (senderName_jfieldId == IntPtr.Zero)
					senderName_jfieldId = JNIEnv.GetFieldID (class_ref, "senderName", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, senderName_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr sentTimestamp_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='sentTimestamp']"
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

		static IntPtr textColor_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='textColor']"
		[Register ("textColor")]
		public string TextColor {
			get {
				if (textColor_jfieldId == IntPtr.Zero)
					textColor_jfieldId = JNIEnv.GetFieldID (class_ref, "textColor", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, textColor_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (textColor_jfieldId == IntPtr.Zero)
					textColor_jfieldId = JNIEnv.GetFieldID (class_ref, "textColor", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, textColor_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr type_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/field[@name='type']"
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
				return JNIEnv.FindClass ("com/inscripts/models/ChatroomMessage", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ChatroomMessage); }
		}

		protected ChatroomMessage (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Lorg_json_JSONObject_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/constructor[@name='ChatroomMessage' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register (".ctor", "(Lorg/json/JSONObject;)V", "")]
		public unsafe ChatroomMessage (global::Org.Json.JSONObject p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (ChatroomMessage)) {
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

		static IntPtr id_ctor_JJLjava_lang_Long_Ljava_lang_String_JLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/constructor[@name='ChatroomMessage' and count(parameter)=10 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='java.lang.Long'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='long'] and parameter[6][@type='java.lang.String'] and parameter[7][@type='java.lang.String'] and parameter[8][@type='java.lang.String'] and parameter[9][@type='java.lang.String'] and parameter[10][@type='int']]"
		[Register (".ctor", "(JJLjava/lang/Long;Ljava/lang/String;JLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V", "")]
		public unsafe ChatroomMessage (long p0, long p1, global::Java.Lang.Long p2, string p3, long p4, string p5, string p6, string p7, string p8, int p9)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			IntPtr native_p6 = JNIEnv.NewString (p6);
			IntPtr native_p7 = JNIEnv.NewString (p7);
			IntPtr native_p8 = JNIEnv.NewString (p8);
			try {
				JValue* __args = stackalloc JValue [10];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				__args [6] = new JValue (native_p6);
				__args [7] = new JValue (native_p7);
				__args [8] = new JValue (native_p8);
				__args [9] = new JValue (p9);
				if (GetType () != typeof (ChatroomMessage)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(JJLjava/lang/Long;Ljava/lang/String;JLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(JJLjava/lang/Long;Ljava/lang/String;JLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V", __args);
					return;
				}

				if (id_ctor_JJLjava_lang_Long_Ljava_lang_String_JLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_I == IntPtr.Zero)
					id_ctor_JJLjava_lang_Long_Ljava_lang_String_JLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_I = JNIEnv.GetMethodID (class_ref, "<init>", "(JJLjava/lang/Long;Ljava/lang/String;JLjava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_JJLjava_lang_Long_Ljava_lang_String_JLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_JJLjava_lang_Long_Ljava_lang_String_JLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_I, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p5);
				JNIEnv.DeleteLocalRef (native_p6);
				JNIEnv.DeleteLocalRef (native_p7);
				JNIEnv.DeleteLocalRef (native_p8);
			}
		}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/constructor[@name='ChatroomMessage' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ChatroomMessage ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ChatroomMessage)) {
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

		static IntPtr id_clearConversation_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/method[@name='clearConversation' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("clearConversation", "(Ljava/lang/Long;)V", "")]
		public static unsafe void ClearConversation (global::Java.Lang.Long p0)
		{
			if (id_clearConversation_Ljava_lang_Long_ == IntPtr.Zero)
				id_clearConversation_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "clearConversation", "(Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_clearConversation_Ljava_lang_Long_, __args);
			} finally {
			}
		}

		static IntPtr id_deleteMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/method[@name='deleteMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("deleteMessage", "(Ljava/lang/String;)V", "")]
		public static unsafe void DeleteMessage (string p0)
		{
			if (id_deleteMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_deleteMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "deleteMessage", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteMessage_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_findById_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/method[@name='findById' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("findById", "(Ljava/lang/Long;)Lcom/inscripts/models/ChatroomMessage;", "")]
		public static unsafe global::Com.Inscripts.Models.ChatroomMessage FindById (global::Java.Lang.Long p0)
		{
			if (id_findById_Ljava_lang_Long_ == IntPtr.Zero)
				id_findById_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/Long;)Lcom/inscripts/models/ChatroomMessage;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Models.ChatroomMessage __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.ChatroomMessage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_findById_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/method[@name='findById' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("findById", "(Ljava/lang/String;)Lcom/inscripts/models/ChatroomMessage;", "")]
		public static unsafe global::Com.Inscripts.Models.ChatroomMessage FindById (string p0)
		{
			if (id_findById_Ljava_lang_String_ == IntPtr.Zero)
				id_findById_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/String;)Lcom/inscripts/models/ChatroomMessage;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Models.ChatroomMessage __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.ChatroomMessage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getAllMessages_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='ChatroomMessage']/method[@name='getAllMessages' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("getAllMessages", "(Ljava/lang/Long;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.ChatroomMessage> GetAllMessages (global::Java.Lang.Long p0)
		{
			if (id_getAllMessages_Ljava_lang_Long_ == IntPtr.Zero)
				id_getAllMessages_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "getAllMessages", "(Ljava/lang/Long;)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::System.Collections.Generic.IList<global::Com.Inscripts.Models.ChatroomMessage> __ret = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.ChatroomMessage>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllMessages_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
