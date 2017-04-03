using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keys {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']"
	[global::Android.Runtime.Register ("com/inscripts/keys/JsonParsingKeys", DoNotGenerateAcw=true)]
	public partial class JsonParsingKeys : global::Java.Lang.Object {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='ANNOUNCEMENT_TIME']"
		[Register ("ANNOUNCEMENT_TIME")]
		public const string AnnouncementTime = (string) "t";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='AVATAR_LINK']"
		[Register ("AVATAR_LINK")]
		public const string AvatarLink = (string) "a";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='BOT_AVATAR']"
		[Register ("BOT_AVATAR")]
		public const string BotAvatar = (string) "a";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='BOT_DESCRIPTION']"
		[Register ("BOT_DESCRIPTION")]
		public const string BotDescription = (string) "d";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='BOT_ID']"
		[Register ("BOT_ID")]
		public const string BotId = (string) "id";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='BOT_NAME']"
		[Register ("BOT_NAME")]
		public const string BotName = (string) "n";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='CHATROOM_NAME']"
		[Register ("CHATROOM_NAME")]
		public const string ChatroomName = (string) "name";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='CHATROOM_PASSWORD']"
		[Register ("CHATROOM_PASSWORD")]
		public const string ChatroomPassword = (string) "i";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='CHATROOM_STATUS']"
		[Register ("CHATROOM_STATUS")]
		public const string ChatroomStatus = (string) "j";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='CREATED_BY']"
		[Register ("CREATED_BY")]
		public const string CreatedBy = (string) "s";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='CSCHANNEL']"
		[Register ("CSCHANNEL")]
		public const string Cschannel = (string) "ch";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='ID']"
		[Register ("ID")]
		public const string Id = (string) "id";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='LASTSEEN']"
		[Register ("LASTSEEN")]
		public const string Lastseen = (string) "ls";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='LINK']"
		[Register ("LINK")]
		public const string Link = (string) "l";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='LSTN']"
		[Register ("LSTN")]
		public const string Lstn = (string) "lstn";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='NAME']"
		[Register ("NAME")]
		public const string Name = (string) "n";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='ONLINE']"
		[Register ("ONLINE")]
		public const string Online = (string) "online";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='STATUS']"
		[Register ("STATUS")]
		public const string Status = (string) "s";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='STATUS_MESSAGE']"
		[Register ("STATUS_MESSAGE")]
		public const string StatusMessage = (string) "m";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='TEMP_ID']"
		[Register ("TEMP_ID")]
		public const string TempId = (string) "temp_id";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/field[@name='TYPE']"
		[Register ("TYPE")]
		public const string Type = (string) "type";
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/keys/JsonParsingKeys", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (JsonParsingKeys); }
		}

		protected JsonParsingKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='JsonParsingKeys']/constructor[@name='JsonParsingKeys' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe JsonParsingKeys ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (JsonParsingKeys)) {
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

	}
}
