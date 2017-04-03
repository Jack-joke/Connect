using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Models {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']"
	[global::Android.Runtime.Register ("com/inscripts/models/Bot", DoNotGenerateAcw=true)]
	public partial class Bot : global::Com.Orm.SugarRecord {


		static IntPtr botAvatar_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/field[@name='botAvatar']"
		[Register ("botAvatar")]
		public string BotAvatar {
			get {
				if (botAvatar_jfieldId == IntPtr.Zero)
					botAvatar_jfieldId = JNIEnv.GetFieldID (class_ref, "botAvatar", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, botAvatar_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (botAvatar_jfieldId == IntPtr.Zero)
					botAvatar_jfieldId = JNIEnv.GetFieldID (class_ref, "botAvatar", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, botAvatar_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr botDescription_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/field[@name='botDescription']"
		[Register ("botDescription")]
		public string BotDescription {
			get {
				if (botDescription_jfieldId == IntPtr.Zero)
					botDescription_jfieldId = JNIEnv.GetFieldID (class_ref, "botDescription", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, botDescription_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (botDescription_jfieldId == IntPtr.Zero)
					botDescription_jfieldId = JNIEnv.GetFieldID (class_ref, "botDescription", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, botDescription_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr botId_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/field[@name='botId']"
		[Register ("botId")]
		public long BotId {
			get {
				if (botId_jfieldId == IntPtr.Zero)
					botId_jfieldId = JNIEnv.GetFieldID (class_ref, "botId", "J");
				return JNIEnv.GetLongField (((global::Java.Lang.Object) this).Handle, botId_jfieldId);
			}
			set {
				if (botId_jfieldId == IntPtr.Zero)
					botId_jfieldId = JNIEnv.GetFieldID (class_ref, "botId", "J");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, botId_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr botName_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/field[@name='botName']"
		[Register ("botName")]
		public string BotName {
			get {
				if (botName_jfieldId == IntPtr.Zero)
					botName_jfieldId = JNIEnv.GetFieldID (class_ref, "botName", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, botName_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (botName_jfieldId == IntPtr.Zero)
					botName_jfieldId = JNIEnv.GetFieldID (class_ref, "botName", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, botName_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/models/Bot", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Bot); }
		}

		protected Bot (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/constructor[@name='Bot' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Bot ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Bot)) {
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

		static IntPtr id_getAllbots;
		public static unsafe global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Bot> Allbots {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/method[@name='getAllbots' and count(parameter)=0]"
			[Register ("getAllbots", "()Ljava/util/List;", "GetGetAllbotsHandler")]
			get {
				if (id_getAllbots == IntPtr.Zero)
					id_getAllbots = JNIEnv.GetStaticMethodID (class_ref, "getAllbots", "()Ljava/util/List;");
				try {
					return global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Bot>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllbots), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBotDetails_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/method[@name='getBotDetails' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getBotDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Bot;", "")]
		public static unsafe global::Com.Inscripts.Models.Bot GetBotDetails (string p0)
		{
			if (id_getBotDetails_Ljava_lang_String_ == IntPtr.Zero)
				id_getBotDetails_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getBotDetails", "(Ljava/lang/String;)Lcom/inscripts/models/Bot;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Models.Bot __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Models.Bot> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBotDetails_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_updateAllBots_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.models']/class[@name='Bot']/method[@name='updateAllBots' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("updateAllBots", "(Lorg/json/JSONObject;)V", "")]
		public static unsafe void UpdateAllBots (global::Org.Json.JSONObject p0)
		{
			if (id_updateAllBots_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_updateAllBots_Lorg_json_JSONObject_ = JNIEnv.GetStaticMethodID (class_ref, "updateAllBots", "(Lorg/json/JSONObject;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_updateAllBots_Lorg_json_JSONObject_, __args);
			} finally {
			}
		}

	}
}
