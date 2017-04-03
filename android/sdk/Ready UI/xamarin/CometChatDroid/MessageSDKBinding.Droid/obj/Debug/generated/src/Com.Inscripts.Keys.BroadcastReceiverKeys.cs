using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keys {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys']"
	[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys", DoNotGenerateAcw=true)]
	public partial class BroadcastReceiverKeys : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.AvchatKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys$AvchatKeys", DoNotGenerateAcw=true)]
		public partial class AvchatKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.AvchatKeys']/field[@name='AVCHAT_CALLER_ID']"
			[Register ("AVCHAT_CALLER_ID")]
			public const string AvchatCallerId = (string) "CALLER_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.AvchatKeys']/field[@name='EVENT_AVCHAT_ACCEPTED']"
			[Register ("EVENT_AVCHAT_ACCEPTED")]
			public const string EventAvchatAccepted = (string) "CALL_ACCEPTED";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys$AvchatKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AvchatKeys); }
			}

			protected AvchatKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.AvchatKeys']/constructor[@name='BroadcastReceiverKeys.AvchatKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AvchatKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AvchatKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys$HeartbeatKeys", DoNotGenerateAcw=true)]
		public partial class HeartbeatKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']/field[@name='ANNOUNCEMENT_BADGE_UPDATION']"
			[Register ("ANNOUNCEMENT_BADGE_UPDATION")]
			public const string AnnouncementBadgeUpdation = (string) "ANNOUNCEMENT_BADGE_UPDATION";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']/field[@name='ANNOUNCEMENT_UPDATATION']"
			[Register ("ANNOUNCEMENT_UPDATATION")]
			public const string AnnouncementUpdatation = (string) "ANNOUNCEMENT_UPDATATION";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']/field[@name='CHATROOM_HEARTBEAT_UPDATAION']"
			[Register ("CHATROOM_HEARTBEAT_UPDATAION")]
			public const string ChatroomHeartbeatUpdataion = (string) "CHATROOM_HEARTBEAT_UPDATAION";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']/field[@name='ONE_ON_ONE_HEARTBEAT_NOTIFICATION']"
			[Register ("ONE_ON_ONE_HEARTBEAT_NOTIFICATION")]
			public const string OneOnOneHeartbeatNotification = (string) "ONE_ON_ONE_HEARTBEAT_UPDATAION";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys$HeartbeatKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (HeartbeatKeys); }
			}

			protected HeartbeatKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.HeartbeatKeys']/constructor[@name='BroadcastReceiverKeys.HeartbeatKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe HeartbeatKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (HeartbeatKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys$IntentExtrasKeys", DoNotGenerateAcw=true)]
		public partial class IntentExtrasKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='BUDDY_AVATAR']"
			[Register ("BUDDY_AVATAR")]
			public const string BuddyAvatar = (string) "BUDDY_AVATAR";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='BUDDY_ID']"
			[Register ("BUDDY_ID")]
			public const string BuddyId = (string) "BUDDY_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='BUDDY_NAME']"
			[Register ("BUDDY_NAME")]
			public const string BuddyName = (string) "BUDDY_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='COD_CODE']"
			[Register ("COD_CODE")]
			public const string CodCode = (string) "COD_CODE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='DIRECT_OPEN_CHAT']"
			[Register ("DIRECT_OPEN_CHAT")]
			public const string DirectOpenChat = (string) "DIRECT_OPEN_CHAT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='IMAGE_SENDING']"
			[Register ("IMAGE_SENDING")]
			public const string ImageSending = (string) "IMAGE_SENDING";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='MESSAGE_DELIVERED']"
			[Register ("MESSAGE_DELIVERED")]
			public const string MessageDelivered = (string) "MESSAGE_DELIVERED";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='MESSAGE_READ']"
			[Register ("MESSAGE_READ")]
			public const string MessageRead = (string) "MESSAGE_READ";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='MESSAGE_TICK']"
			[Register ("MESSAGE_TICK")]
			public const string MessageTick = (string) "MESSAGE_TICK";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='NEW_CHATROOM_MESSAGE']"
			[Register ("NEW_CHATROOM_MESSAGE")]
			public const string NewChatroomMessage = (string) "NEW_CHATROOM_MESSAGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='NEW_MESSAGE']"
			[Register ("NEW_MESSAGE")]
			public const string NewMessage = (string) "NEW_MESSAGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='NEW_MESSAGE_DATA']"
			[Register ("NEW_MESSAGE_DATA")]
			public const string NewMessageData = (string) "NEW_MESSAGE_DATA";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='OPEN_SETTINGS']"
			[Register ("OPEN_SETTINGS")]
			public const string OpenSettings = (string) "OPEN_SETTINGS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='RANDOMID']"
			[Register ("RANDOMID")]
			public const string Randomid = (string) "randomId";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='REFRESH_LASTSEEN']"
			[Register ("REFRESH_LASTSEEN")]
			public const string RefreshLastseen = (string) "REFRESH_LASTSEEN";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='ROOM_NAME']"
			[Register ("ROOM_NAME")]
			public const string RoomName = (string) "ROOM_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='SELECTED_COUNTRY_CODE']"
			[Register ("SELECTED_COUNTRY_CODE")]
			public const string SelectedCountryCode = (string) "SELECTED_COUNTRY_CODE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='SELECTED_COUNTRY_NAME']"
			[Register ("SELECTED_COUNTRY_NAME")]
			public const string SelectedCountryName = (string) "SELECTED_COUNTRY_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='SUBTITLE_CHANGE']"
			[Register ("SUBTITLE_CHANGE")]
			public const string SubtitleChange = (string) "SUBTITLE_CHANGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='TEMP_ID']"
			[Register ("TEMP_ID")]
			public const string TempId = (string) "TEMP_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='TYPING_START']"
			[Register ("TYPING_START")]
			public const string TypingStart = (string) "TYPING_START";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='TYPING_STOP']"
			[Register ("TYPING_STOP")]
			public const string TypingStop = (string) "TYPING_STOP";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='UNSUPPORTED_SMILEY_DOWNLOADED']"
			[Register ("UNSUPPORTED_SMILEY_DOWNLOADED")]
			public const string UnsupportedSmileyDownloaded = (string) "UNSUPPORTED_SMILEY_DOWNLOADED";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='USER_STATUS']"
			[Register ("USER_STATUS")]
			public const string UserStatus = (string) "USER_STATUS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='VERFICATION_STATUS_CASE_TWO']"
			[Register ("VERFICATION_STATUS_CASE_TWO")]
			public const string VerficationStatusCaseTwo = (string) "VERFICATION_STATUS_CASE_TWO";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/field[@name='VIDEO_SENDING']"
			[Register ("VIDEO_SENDING")]
			public const string VideoSending = (string) "VIDEO_SENDING";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys$IntentExtrasKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (IntentExtrasKeys); }
			}

			protected IntentExtrasKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.IntentExtrasKeys']/constructor[@name='BroadcastReceiverKeys.IntentExtrasKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe IntentExtrasKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (IntentExtrasKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys$ListUpdatationKeys", DoNotGenerateAcw=true)]
		public partial class ListUpdatationKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_ANNOUNCEMENT_BADGE']"
			[Register ("REFRESH_ANNOUNCEMENT_BADGE")]
			public const string RefreshAnnouncementBadge = (string) "REFRESH_ANNOUNCEMENT_BADGE";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_ANNOUNCEMENT_LIST']"
			[Register ("REFRESH_ANNOUNCEMENT_LIST")]
			public const string RefreshAnnouncementList = (string) "REFRESH_ANNOUNCEMENT_LIST";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_BOT_LIST_FRAGMENT']"
			[Register ("REFRESH_BOT_LIST_FRAGMENT")]
			public const string RefreshBotListFragment = (string) "REFRESH_BOT_LIST_FRAGMENT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_BUDDY_LIST_FRAGMENT']"
			[Register ("REFRESH_BUDDY_LIST_FRAGMENT")]
			public const string RefreshBuddyListFragment = (string) "REFRESH_FULL_BUDDY_LIST_FRAGMENT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_CHATROOM_MEMBERS']"
			[Register ("REFRESH_CHATROOM_MEMBERS")]
			public const string RefreshChatroomMembers = (string) "REFRESH_CHATROOM_MEMBERS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_FULL_CHATROOM_LIST_FRAGMENT']"
			[Register ("REFRESH_FULL_CHATROOM_LIST_FRAGMENT")]
			public const string RefreshFullChatroomListFragment = (string) "REFRESH_FULL_CHATROOM_LIST_FRAGMENT";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/field[@name='REFRESH_USER_STATUS']"
			[Register ("REFRESH_USER_STATUS")]
			public const string RefreshUserStatus = (string) "REFRESH_USER_STATUS";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys$ListUpdatationKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ListUpdatationKeys); }
			}

			protected ListUpdatationKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.ListUpdatationKeys']/constructor[@name='BroadcastReceiverKeys.ListUpdatationKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ListUpdatationKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ListUpdatationKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.NewMessageKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/BroadcastReceiverKeys$NewMessageKeys", DoNotGenerateAcw=true)]
		public partial class NewMessageKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.NewMessageKeys']/field[@name='EVENT_NEW_MESSAGE_CHATROOM']"
			[Register ("EVENT_NEW_MESSAGE_CHATROOM")]
			public const string EventNewMessageChatroom = (string) "EVENT_NEW_MESSAGE_CHATROOM";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.NewMessageKeys']/field[@name='EVENT_NEW_MESSAGE_ONE_ON_ONE']"
			[Register ("EVENT_NEW_MESSAGE_ONE_ON_ONE")]
			public const string EventNewMessageOneOnOne = (string) "EVENT_NEW_MESSAGE_ONE_ON_ONE";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys$NewMessageKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (NewMessageKeys); }
			}

			protected NewMessageKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys.NewMessageKeys']/constructor[@name='BroadcastReceiverKeys.NewMessageKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe NewMessageKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (NewMessageKeys)) {
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

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/keys/BroadcastReceiverKeys", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BroadcastReceiverKeys); }
		}

		protected BroadcastReceiverKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='BroadcastReceiverKeys']/constructor[@name='BroadcastReceiverKeys' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe BroadcastReceiverKeys ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (BroadcastReceiverKeys)) {
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
