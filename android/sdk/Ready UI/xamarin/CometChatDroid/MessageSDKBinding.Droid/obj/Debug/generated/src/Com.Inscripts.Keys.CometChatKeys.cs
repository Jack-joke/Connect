using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keys {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys']"
	[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys", DoNotGenerateAcw=true)]
	public partial class CometChatKeys : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AVBroadcastKeys", DoNotGenerateAcw=true)]
		public partial class AVBroadcastKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='AVBROADCAST_INVITE_MESSAGE']"
			[Register ("AVBROADCAST_INVITE_MESSAGE")]
			public const string AvbroadcastInviteMessage = (string) "AVBROADCAST_INVITE_MESSAGE";

			static IntPtr BROADCAST_END_KEY_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='BROADCAST_END_KEY']"
			[Register ("BROADCAST_END_KEY")]
			public static global::Java.Lang.ICharSequence BroadcastEndKey {
				get {
					if (BROADCAST_END_KEY_jfieldId == IntPtr.Zero)
						BROADCAST_END_KEY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "BROADCAST_END_KEY", "Ljava/lang/CharSequence;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, BROADCAST_END_KEY_jfieldId);
					return global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='BROADCAST_REQUEST_KEY']"
			[Register ("BROADCAST_REQUEST_KEY")]
			public const string BroadcastRequestKey = (string) "jqcc.ccbroadcast.accept(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='CRBROADCAST_REQUEST_KEY']"
			[Register ("CRBROADCAST_REQUEST_KEY")]
			public const string CrbroadcastRequestKey = (string) "jqcc.ccbroadcast.join(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='END_AVCALL_MESSAGE']"
			[Register ("END_AVCALL_MESSAGE")]
			public const string EndAvcallMessage = (string) "AVBROADCAST_END";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/field[@name='INCOMING_AVBROADCAST_MESSAGE']"
			[Register ("INCOMING_AVBROADCAST_MESSAGE")]
			public const string IncomingAvbroadcastMessage = (string) "INCOMING_AVBROADCAST_REQUEST";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AVBroadcastKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AVBroadcastKeys); }
			}

			protected AVBroadcastKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVBroadcastKeys']/constructor[@name='CometChatKeys.AVBroadcastKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AVBroadcastKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AVBroadcastKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AVchatKeys", DoNotGenerateAcw=true)]
		public partial class AVchatKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='ACCEPTED']"
			[Register ("ACCEPTED")]
			public const string Accepted = (string) "accept";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AUDIOCALL_ACCECPTED_MESSAGE']"
			[Register ("AUDIOCALL_ACCECPTED_MESSAGE")]
			public const string AudiocallAccecptedMessage = (string) "AUDIOCHAT_CALL_ACCEPTED";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AUDIOCALL_REJECTED_MESSAGE']"
			[Register ("AUDIOCALL_REJECTED_MESSAGE")]
			public const string AudiocallRejectedMessage = (string) "AUDIOCHAT_REJECT_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AUDIOCALL_SENTSUCCESSFUL_MESSAGE']"
			[Register ("AUDIOCALL_SENTSUCCESSFUL_MESSAGE")]
			public const string AudiocallSentsuccessfulMessage = (string) "AUDIOCHAT_CALL_SENT_SUCCESS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AVCALL_ACCECPTED_MESSAGE']"
			[Register ("AVCALL_ACCECPTED_MESSAGE")]
			public const string AvcallAccecptedMessage = (string) "AVCHAT_CALL_ACCEPTED";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AVCALL_REJECTED_MESSAGE']"
			[Register ("AVCALL_REJECTED_MESSAGE")]
			public const string AvcallRejectedMessage = (string) "AVCHAT_REJECT_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='AVCALL_SENTSUCCESSFUL_MESSAGE']"
			[Register ("AVCALL_SENTSUCCESSFUL_MESSAGE")]
			public const string AvcallSentsuccessfulMessage = (string) "AVCHAT_CALL_SENT_SUCCESS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='BUSY_AUDIOCALL_MESSAGE']"
			[Register ("BUSY_AUDIOCALL_MESSAGE")]
			public const string BusyAudiocallMessage = (string) "AUDIOCHAT_BUSY_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='BUSY_AVCALL_MESSAGE']"
			[Register ("BUSY_AVCALL_MESSAGE")]
			public const string BusyAvcallMessage = (string) "AVCHAT_BUSY_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='CALLER_ID']"
			[Register ("CALLER_ID")]
			public const string CallerId = (string) "CALLER_ID";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='CALLER_NAME']"
			[Register ("CALLER_NAME")]
			public const string CallerName = (string) "name";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='CANCEL_AUDIOCALL_MESSAGE']"
			[Register ("CANCEL_AUDIOCALL_MESSAGE")]
			public const string CancelAudiocallMessage = (string) "AUDIOCHAT_CANCEL_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='CANCEL_AVCALL_MESSAGE']"
			[Register ("CANCEL_AVCALL_MESSAGE")]
			public const string CancelAvcallMessage = (string) "AVCHAT_CANCEL_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='END_AUDIOCALL_MESSAGE']"
			[Register ("END_AUDIOCALL_MESSAGE")]
			public const string EndAudiocallMessage = (string) "AUDIOCHAT_END_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='END_AVCALL_MESSAGE']"
			[Register ("END_AVCALL_MESSAGE")]
			public const string EndAvcallMessage = (string) "AVCHAT_END_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='GRP']"
			[Register ("GRP")]
			public const string Grp = (string) "grp";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='HAS_ACCEPTED_REQUEST']"
			[Register ("HAS_ACCEPTED_REQUEST")]
			public const string HasAcceptedRequest = (string) "jqcc.ccavchat.accept_fid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='HAS_SENT_REQUEST_SUCCESSFULLY']"
			[Register ("HAS_SENT_REQUEST_SUCCESSFULLY")]
			public const string HasSentRequestSuccessfully = (string) "jqcc.ccavchat.cancel_call(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='INCOMING_AUDIOCALL_MESSAGE']"
			[Register ("INCOMING_AUDIOCALL_MESSAGE")]
			public const string IncomingAudiocallMessage = (string) "AUDIOCHAT_INCOMING_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='INCOMING_AUDIOCALL_WHILE_USER_BUSY_MESSAGE']"
			[Register ("INCOMING_AUDIOCALL_WHILE_USER_BUSY_MESSAGE")]
			public const string IncomingAudiocallWhileUserBusyMessage = (string) "AUDIOCHAT_INCOMING_CALL_USER_BUSY";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='INCOMING_AVCALL_MESSAGE']"
			[Register ("INCOMING_AVCALL_MESSAGE")]
			public const string IncomingAvcallMessage = (string) "AVCHAT_INCOMING_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='INCOMING_AVCALL_WHILE_USER_BUSY_MESSAGE']"
			[Register ("INCOMING_AVCALL_WHILE_USER_BUSY_MESSAGE")]
			public const string IncomingAvcallWhileUserBusyMessage = (string) "AVCHAT_INCOMING_CALL_USER_BUSY";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='JOIN']"
			[Register ("JOIN")]
			public const string Join = (string) "join";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='JOIN_KEY']"
			[Register ("JOIN_KEY")]
			public const string JoinKey = (string) "jqcc.ccavchat.join(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='NOANSWER_AUDIOCALL_MESSAGE']"
			[Register ("NOANSWER_AUDIOCALL_MESSAGE")]
			public const string NoanswerAudiocallMessage = (string) "AUDIOCHAT_NO_ANSWER";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='NOANSWER_AVCALL_MESSAGE']"
			[Register ("NOANSWER_AVCALL_MESSAGE")]
			public const string NoanswerAvcallMessage = (string) "AVCHAT_NO_ANSWER";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='REQUEST_KEY']"
			[Register ("REQUEST_KEY")]
			public const string RequestKey = (string) "jqcc.ccavchat.accept(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='ROOM_NAME']"
			[Register ("ROOM_NAME")]
			public const string RoomName = (string) "ROOM_NAME";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='TYPE']"
			[Register ("TYPE")]
			public const string Type = (string) "type";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_BUSY_CALL']"
			[Register ("VIDEO_BUSY_CALL")]
			public const string VideoBusyCall = (string) "CC^CONTROL_PLUGIN_AVCHAT_BUSYCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_CALL_CANCEL']"
			[Register ("VIDEO_CALL_CANCEL")]
			public const string VideoCallCancel = (string) "CC^CONTROL_PLUGIN_AVCHAT_CANCELCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_CALL_ENDED']"
			[Register ("VIDEO_CALL_ENDED")]
			public const string VideoCallEnded = (string) "CC^CONTROL_PLUGIN_AVCHAT_ENDCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_CALL_REJECTED']"
			[Register ("VIDEO_CALL_REJECTED")]
			public const string VideoCallRejected = (string) "CC^CONTROL_PLUGIN_AVCHAT_REJECTCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_CrREQUEST_KEY']"
			[Register ("VIDEO_CrREQUEST_KEY")]
			public const string VIDEOCrREQUESTKEY = (string) "jqcc.ccavchat.join(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/field[@name='VIDEO_NO_ANSWER']"
			[Register ("VIDEO_NO_ANSWER")]
			public const string VideoNoAnswer = (string) "CC^CONTROL_PLUGIN_AVCHAT_NOANSWER";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AVchatKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AVchatKeys); }
			}

			protected AVchatKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AVchatKeys']/constructor[@name='CometChatKeys.AVchatKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AVchatKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AVchatKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AjaxKeys", DoNotGenerateAcw=true)]
		public partial class AjaxKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ACCEPT_NULL']"
			[Register ("ACCEPT_NULL")]
			public const string AcceptNull = (string) "accept_null";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ACTION']"
			[Register ("ACTION")]
			public const string Action = (string) "action";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ACTION_ACCEPT']"
			[Register ("ACTION_ACCEPT")]
			public const string ActionAccept = (string) "accept";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ACTIVE_CHATWINDOW_ID']"
			[Register ("ACTIVE_CHATWINDOW_ID")]
			public const string ActiveChatwindowId = (string) "activeChatboxIds";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ANNOUNCEMENT']"
			[Register ("ANNOUNCEMENT")]
			public const string Announcement = (string) "an";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='API_KEY']"
			[Register ("API_KEY")]
			public const string ApiKey = (string) "api-key";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='APP_INFO']"
			[Register ("APP_INFO")]
			public const string AppInfo = (string) "appinfo";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='AVATAR']"
			[Register ("AVATAR")]
			public const string Avatar = (string) "avatar";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='AVBROADCAST']"
			[Register ("AVBROADCAST")]
			public const string Avbroadcast = (string) "broadcast";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BASE_DATA']"
			[Register ("BASE_DATA")]
			public const string BaseData = (string) "basedata";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BOT_ID']"
			[Register ("BOT_ID")]
			public const string BotId = (string) "botid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BOT_LIST']"
			[Register ("BOT_LIST")]
			public const string BotList = (string) "botlist";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BOT_LIST_HAST']"
			[Register ("BOT_LIST_HAST")]
			public const string BotListHast = (string) "botlh";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BOT_RESPONCE_TYPE']"
			[Register ("BOT_RESPONCE_TYPE")]
			public const string BotResponceType = (string) "bot_responce_type";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BUDDY_LIST']"
			[Register ("BUDDY_LIST")]
			public const string BuddyList = (string) "buddylist";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='BUDDY_LIST_HASH']"
			[Register ("BUDDY_LIST_HASH")]
			public const string BuddyListHash = (string) "blh";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CALLBACK']"
			[Register ("CALLBACK")]
			public const string Callback = (string) "callback";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CALLBACK_FN']"
			[Register ("CALLBACK_FN")]
			public const string CallbackFn = (string) "callbackfn";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CALLBACK_FN_VALUE']"
			[Register ("CALLBACK_FN_VALUE")]
			public const string CallbackFnValue = (string) "mobileapp";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CALLID']"
			[Register ("CALLID")]
			public const string Callid = (string) "callid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CATEGORY']"
			[Register ("CATEGORY")]
			public const string Category = (string) "category";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATBOX']"
			[Register ("CHATBOX")]
			public const string Chatbox = (string) "chatbox";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOMID']"
			[Register ("CHATROOMID")]
			public const string Chatroomid = (string) "chatroomid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOM_INITIALIZE']"
			[Register ("CHATROOM_INITIALIZE")]
			public const string ChatroomInitialize = (string) "crinitialize";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOM_LIST']"
			[Register ("CHATROOM_LIST")]
			public const string ChatroomList = (string) "chatrooms";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOM_MESSAGES']"
			[Register ("CHATROOM_MESSAGES")]
			public const string ChatroomMessages = (string) "crmessages";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOM_TIMESTAMP']"
			[Register ("CHATROOM_TIMESTAMP")]
			public const string ChatroomTimestamp = (string) "crtimestamp";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CHATROOM_TYPE']"
			[Register ("CHATROOM_TYPE")]
			public const string ChatroomType = (string) "type";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='COMETID']"
			[Register ("COMETID")]
			public const string Cometid = (string) "cometid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='CONTACT_LIST']"
			[Register ("CONTACT_LIST")]
			public const string ContactList = (string) "contacts_list";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='COUNT']"
			[Register ("COUNT")]
			public const string Count = (string) "count";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='DEVICE_TYPE']"
			[Register ("DEVICE_TYPE")]
			public const string DeviceType = (string) "device_type";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='DISPLAY_NAME']"
			[Register ("DISPLAY_NAME")]
			public const string DisplayName = (string) "displayname";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='EMAIL']"
			[Register ("EMAIL")]
			public const string Email = (string) "email";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='FORCE']"
			[Register ("FORCE")]
			public const string Force = (string) "force";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='FORCE_LIST']"
			[Register ("FORCE_LIST")]
			public const string ForceList = (string) "f";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='FRIENDS']"
			[Register ("FRIENDS")]
			public const string Friends = (string) "friends";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='FROM']"
			[Register ("FROM")]
			public const string From = (string) "from";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='GUEST_LOGIN']"
			[Register ("GUEST_LOGIN")]
			public const string GuestLogin = (string) "guest_login";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ID']"
			[Register ("ID")]
			public const string Id = (string) "id";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='INITIALIZE']"
			[Register ("INITIALIZE")]
			public const string Initialize = (string) "initialize";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='JSON_RESPONSE_HASH']"
			[Register ("JSON_RESPONSE_HASH")]
			public const string JsonResponseHash = (string) "response_hash";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='KEY']"
			[Register ("KEY")]
			public const string Key = (string) "key";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='LANG_COOKIE']"
			[Register ("LANG_COOKIE")]
			public const string LangCookie = (string) "cookie_cc_lang";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='LASTSEENSETTINGFLAG']"
			[Register ("LASTSEENSETTINGFLAG")]
			public const string Lastseensettingflag = (string) "lastseenSettingsFlag";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='LINK']"
			[Register ("LINK")]
			public const string Link = (string) "link";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='MESSAGE']"
			[Register ("MESSAGE")]
			public const string Message = (string) "message";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='MESSAGES']"
			[Register ("MESSAGES")]
			public const string Messages = (string) "messages";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='NAME']"
			[Register ("NAME")]
			public const string Name = (string) "name";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='NEW_EMAIL']"
			[Register ("NEW_EMAIL")]
			public const string NewEmail = (string) "new_email";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='NEW_PASSWORD']"
			[Register ("NEW_PASSWORD")]
			public const string NewPassword = (string) "newpassword";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='OLD']"
			[Register ("OLD")]
			public const string Old = (string) "old";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='ORIGINAL_FILE']"
			[Register ("ORIGINAL_FILE")]
			public const string OriginalFile = (string) "original_file";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='PASSWORD']"
			[Register ("PASSWORD")]
			public const string Password = (string) "password";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='PHONE_NUMBER']"
			[Register ("PHONE_NUMBER")]
			public const string PhoneNumber = (string) "phone";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='PHONE_NUMBER_HASH']"
			[Register ("PHONE_NUMBER_HASH")]
			public const string PhoneNumberHash = (string) "phone_hash";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='PLATFORM']"
			[Register ("PLATFORM")]
			public const string Platform = (string) "platform";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='PREPEND']"
			[Register ("PREPEND")]
			public const string Prepend = (string) "prepend";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='RANDOM']"
			[Register ("RANDOM")]
			public const string Random = (string) "random";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='RESULT']"
			[Register ("RESULT")]
			public const string Result = (string) "result";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SAME_AVATAR']"
			[Register ("SAME_AVATAR")]
			public const string SameAvatar = (string) "same_avatar";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SDK_PARAM']"
			[Register ("SDK_PARAM")]
			public const string SdkParam = (string) "cc_sdk";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SELF']"
			[Register ("SELF")]
			public const string Self = (string) "self";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SENDERNAME']"
			[Register ("SENDERNAME")]
			public const string Sendername = (string) "sendername";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SENT']"
			[Register ("SENT")]
			public const string Sent = (string) "sent";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='STATUS_MESSAGE']"
			[Register ("STATUS_MESSAGE")]
			public const string StatusMessage = (string) "statusmessage";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='SUBACTION']"
			[Register ("SUBACTION")]
			public const string Subaction = (string) "subaction";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='TEMP_ID']"
			[Register ("TEMP_ID")]
			public const string TempId = (string) "temp_id";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='TIMESTAMP']"
			[Register ("TIMESTAMP")]
			public const string Timestamp = (string) "timestamp";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='TO']"
			[Register ("TO")]
			public const string To = (string) "to";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='UID']"
			[Register ("UID")]
			public const string Uid = (string) "uid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='USERID']"
			[Register ("USERID")]
			public const string Userid = (string) "userid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='USERNAME']"
			[Register ("USERNAME")]
			public const string Username = (string) "username";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='USERS']"
			[Register ("USERS")]
			public const string Users = (string) "users";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='USER_STATUS']"
			[Register ("USER_STATUS")]
			public const string UserStatus = (string) "userstatus";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='VERIFICATION_CODE']"
			[Register ("VERIFICATION_CODE")]
			public const string VerificationCode = (string) "veri_code";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='VERSION2']"
			[Register ("VERSION2")]
			public const string Version2 = (string) "v2";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='VERSION3']"
			[Register ("VERSION3")]
			public const string Version3 = (string) "v3";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='WHITEBOARD']"
			[Register ("WHITEBOARD")]
			public const string Whiteboard = (string) "whiteboard";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/field[@name='WRITEBOARD_USERNAME']"
			[Register ("WRITEBOARD_USERNAME")]
			public const string WriteboardUsername = (string) "?userName=";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AjaxKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AjaxKeys); }
			}

			protected AjaxKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AjaxKeys']/constructor[@name='CometChatKeys.AjaxKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AjaxKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AjaxKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AudiochatKeys", DoNotGenerateAcw=true)]
		public partial class AudiochatKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_BUSY_CALL']"
			[Register ("AUDIO_BUSY_CALL")]
			public const string AudioBusyCall = (string) "CC^CONTROL_PLUGIN_AUDIOCHAT_BUSYCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_CALL_CANCEL']"
			[Register ("AUDIO_CALL_CANCEL")]
			public const string AudioCallCancel = (string) "CC^CONTROL_PLUGIN_AUDIOCHAT_CANCELCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_CALL_ENDED']"
			[Register ("AUDIO_CALL_ENDED")]
			public const string AudioCallEnded = (string) "CC^CONTROL_PLUGIN_AUDIOCHAT_ENDCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_CALL_REJECTED']"
			[Register ("AUDIO_CALL_REJECTED")]
			public const string AudioCallRejected = (string) "CC^CONTROL_PLUGIN_AUDIOCHAT_REJECTCALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_CrREQUEST_KEY']"
			[Register ("AUDIO_CrREQUEST_KEY")]
			public const string AUDIOCrREQUESTKEY = (string) "jqcc.ccaudiochat.join(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_NO_ANSWER']"
			[Register ("AUDIO_NO_ANSWER")]
			public const string AudioNoAnswer = (string) "CC^CONTROL_PLUGIN_AUDIOCHAT_NOANSWER";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='AUDIO_ONLY_CALL']"
			[Register ("AUDIO_ONLY_CALL")]
			public const string AudioOnlyCall = (string) "AUDIO_ONLY_CALL";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='HAS_ACCEPTED_REQUEST']"
			[Register ("HAS_ACCEPTED_REQUEST")]
			public const string HasAcceptedRequest = (string) "jqcc.ccaudiochat.accept_fid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='HAS_SENT_REQUEST_SUCCESSFULLY']"
			[Register ("HAS_SENT_REQUEST_SUCCESSFULLY")]
			public const string HasSentRequestSuccessfully = (string) "jqcc.ccaudiochat.cancel_call(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/field[@name='REQUEST_KEY']"
			[Register ("REQUEST_KEY")]
			public const string RequestKey = (string) "jqcc.ccaudiochat.accept(";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AudiochatKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AudiochatKeys); }
			}

			protected AudiochatKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AudiochatKeys']/constructor[@name='CometChatKeys.AudiochatKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AudiochatKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AudiochatKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvBroadcastMessageTypeKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AvBroadcastMessageTypeKeys", DoNotGenerateAcw=true)]
		public partial class AvBroadcastMessageTypeKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvBroadcastMessageTypeKeys']/field[@name='AVBROADCAST_MESSAGE_TYPE_END_CALL']"
			[Register ("AVBROADCAST_MESSAGE_TYPE_END_CALL")]
			public const int AvbroadcastMessageTypeEndCall = (int) 42;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvBroadcastMessageTypeKeys']/field[@name='AVBROADCAST_MESSAGE_TYPE_INCOMING_CALL']"
			[Register ("AVBROADCAST_MESSAGE_TYPE_INCOMING_CALL")]
			public const int AvbroadcastMessageTypeIncomingCall = (int) 41;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvBroadcastMessageTypeKeys']/field[@name='AVBROADCAST_MESSAGE_TYPE_INVITE']"
			[Register ("AVBROADCAST_MESSAGE_TYPE_INVITE")]
			public const int AvbroadcastMessageTypeInvite = (int) 43;
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AvBroadcastMessageTypeKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AvBroadcastMessageTypeKeys); }
			}

			protected AvBroadcastMessageTypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvBroadcastMessageTypeKeys']/constructor[@name='CometChatKeys.AvBroadcastMessageTypeKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AvBroadcastMessageTypeKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AvBroadcastMessageTypeKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$AvchatMessageTypeKeys", DoNotGenerateAcw=true)]
		public partial class AvchatMessageTypeKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_BUSY_CALL']"
			[Register ("AVCHAT_MESSAGE_TYPE_BUSY_CALL")]
			public const int AvchatMessageTypeBusyCall = (int) 38;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED']"
			[Register ("AVCHAT_MESSAGE_TYPE_CALL_ACCEPTED")]
			public const int AvchatMessageTypeCallAccepted = (int) 31;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_CANCEL_CALL']"
			[Register ("AVCHAT_MESSAGE_TYPE_CANCEL_CALL")]
			public const int AvchatMessageTypeCancelCall = (int) 36;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_END_CALL']"
			[Register ("AVCHAT_MESSAGE_TYPE_END_CALL")]
			public const int AvchatMessageTypeEndCall = (int) 34;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_INCOMING_CALL']"
			[Register ("AVCHAT_MESSAGE_TYPE_INCOMING_CALL")]
			public const int AvchatMessageTypeIncomingCall = (int) 32;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE']"
			[Register ("AVCHAT_MESSAGE_TYPE_INCOMING_CALL_WHILE_USER_BUSY_MESSAGE")]
			public const int AvchatMessageTypeIncomingCallWhileUserBusyMessage = (int) 33;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_NO_ANSWER']"
			[Register ("AVCHAT_MESSAGE_TYPE_NO_ANSWER")]
			public const int AvchatMessageTypeNoAnswer = (int) 37;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/field[@name='AVCHAT_MESSAGE_TYPE_REJECT_CALL']"
			[Register ("AVCHAT_MESSAGE_TYPE_REJECT_CALL")]
			public const int AvchatMessageTypeRejectCall = (int) 35;
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$AvchatMessageTypeKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AvchatMessageTypeKeys); }
			}

			protected AvchatMessageTypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.AvchatMessageTypeKeys']/constructor[@name='CometChatKeys.AvchatMessageTypeKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe AvchatMessageTypeKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (AvchatMessageTypeKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$ChatroomActionMessageTypeKeys", DoNotGenerateAcw=true)]
		public partial class ChatroomActionMessageTypeKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']/field[@name='CHATROOM_BANNED']"
			[Register ("CHATROOM_BANNED")]
			public const int ChatroomBanned = (int) 11;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']/field[@name='CHATROOM_DELETED']"
			[Register ("CHATROOM_DELETED")]
			public const int ChatroomDeleted = (int) 12;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']/field[@name='CHATROOM_KICKED']"
			[Register ("CHATROOM_KICKED")]
			public const int ChatroomKicked = (int) 10;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']/field[@name='CHATROOM_MESSAGE_DELETED']"
			[Register ("CHATROOM_MESSAGE_DELETED")]
			public const int ChatroomMessageDeleted = (int) 13;
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$ChatroomActionMessageTypeKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ChatroomActionMessageTypeKeys); }
			}

			protected ChatroomActionMessageTypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomActionMessageTypeKeys']/constructor[@name='CometChatKeys.ChatroomActionMessageTypeKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ChatroomActionMessageTypeKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ChatroomActionMessageTypeKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$ChatroomKeys", DoNotGenerateAcw=true)]
		public partial class ChatroomKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='BAN']"
			[Register ("BAN")]
			public const string Ban = (string) "ban";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='BANNED']"
			[Register ("BANNED")]
			public const string Banned = (string) "banned";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='BAN_FLAG']"
			[Register ("BAN_FLAG")]
			public const string BanFlag = (string) "banflag";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='BAN_ID']"
			[Register ("BAN_ID")]
			public const string BanId = (string) "banid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='BAN_KEY']"
			[Register ("BAN_KEY")]
			public const string BanKey = (string) "CC^CONTROL_banned";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CHATROOM_ID']"
			[Register ("CHATROOM_ID")]
			public const string ChatroomId = (string) "currentroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CHATROOM_ID_FIELD']"
			[Register ("CHATROOM_ID_FIELD")]
			public const string ChatroomIdField = (string) "id";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CHATROOM_LIST_HASH']"
			[Register ("CHATROOM_LIST_HASH")]
			public const string ChatroomListHash = (string) "clh";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CHATROOM_MEMBERS_HASH']"
			[Register ("CHATROOM_MEMBERS_HASH")]
			public const string ChatroomMembersHash = (string) "ulh";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CHATROOM_NAME']"
			[Register ("CHATROOM_NAME")]
			public const string ChatroomName = (string) "currentroomname";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CNAME']"
			[Register ("CNAME")]
			public const string Cname = (string) "cname";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CURRENT_P']"
			[Register ("CURRENT_P")]
			public const string CurrentP = (string) "currentp";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='CURRENT_ROOM']"
			[Register ("CURRENT_ROOM")]
			public const string CurrentRoom = (string) "currentroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='DELETE_MESSAGE_KEY']"
			[Register ("DELETE_MESSAGE_KEY")]
			public const string DeleteMessageKey = (string) "CC^CONTROL_deletemessage";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='ERROR']"
			[Register ("ERROR")]
			public const string Error = (string) "error";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='FLAG']"
			[Register ("FLAG")]
			public const string Flag = (string) "flag";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='FROMID']"
			[Register ("FROMID")]
			public const string Fromid = (string) "fromid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='INVITE']"
			[Register ("INVITE")]
			public const string Invite = (string) "invite[]";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='INVITEDID']"
			[Register ("INVITEDID")]
			public const string Invitedid = (string) "inviteid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='JOIN_KEY']"
			[Register ("JOIN_KEY")]
			public const string JoinKey = (string) "jqcc.cometchat.joinChatroom(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='JOIN_REQUEST_MESSAGE']"
			[Register ("JOIN_REQUEST_MESSAGE")]
			public const string JoinRequestMessage = (string) "Has invited you to join a chatroom.\u000AJoin";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='KICK']"
			[Register ("KICK")]
			public const string Kick = (string) "kick";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='KICKED']"
			[Register ("KICKED")]
			public const string Kicked = (string) "kicked";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='KICKID']"
			[Register ("KICKID")]
			public const string Kickid = (string) "kickid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='KICK_KEY']"
			[Register ("KICK_KEY")]
			public const string KickKey = (string) "CC^CONTROL_kicked";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='MEMBERS']"
			[Register ("MEMBERS")]
			public const string Members = (string) "users";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='ROOMID']"
			[Register ("ROOMID")]
			public const string Roomid = (string) "roomid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='ROOMNAME']"
			[Register ("ROOMNAME")]
			public const string Roomname = (string) "roomname";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='ROOM_DOES_NOT_EXISTS']"
			[Register ("ROOM_DOES_NOT_EXISTS")]
			public const string RoomDoesNotExists = (string) "ROOM_DOES_NOT_EXISTS";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/field[@name='TEXT_COLOR']"
			[Register ("TEXT_COLOR")]
			public const string TextColor = (string) "text_color";
			// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys.TypeKeys']"
			[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$ChatroomKeys$TypeKeys", DoNotGenerateAcw=true)]
			public partial class TypeKeys : global::Java.Lang.Object {


				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys.TypeKeys']/field[@name='INVITE_ONLY']"
				[Register ("INVITE_ONLY")]
				public const int InviteOnly = (int) 2;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys.TypeKeys']/field[@name='PASSWORD_PROTECTED']"
				[Register ("PASSWORD_PROTECTED")]
				public const int PasswordProtected = (int) 1;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys.TypeKeys']/field[@name='PUBLIC']"
				[Register ("PUBLIC")]
				public const int Public = (int) 0;
				internal static IntPtr java_class_handle;
				internal static IntPtr class_ref {
					get {
						return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$ChatroomKeys$TypeKeys", ref java_class_handle);
					}
				}

				protected override IntPtr ThresholdClass {
					get { return class_ref; }
				}

				protected override global::System.Type ThresholdType {
					get { return typeof (TypeKeys); }
				}

				protected TypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

				static IntPtr id_ctor;
				// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys.TypeKeys']/constructor[@name='CometChatKeys.ChatroomKeys.TypeKeys' and count(parameter)=0]"
				[Register (".ctor", "()V", "")]
				public unsafe TypeKeys ()
					: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
				{
					if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
						return;

					try {
						if (GetType () != typeof (TypeKeys)) {
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
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$ChatroomKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ChatroomKeys); }
			}

			protected ChatroomKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ChatroomKeys']/constructor[@name='CometChatKeys.ChatroomKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ChatroomKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ChatroomKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$ErrorKeys", DoNotGenerateAcw=true)]
		public partial class ErrorKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND']"
			[Register ("CODE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND")]
			public const string CodeAudiochatCallDetailsNotFound = (string) "602";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_CONTAINER_EMPTY']"
			[Register ("CODE_AUDIOCHAT_CONTAINER_EMPTY")]
			public const string CodeAudiochatContainerEmpty = (string) "603";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_INCORRECT_USER']"
			[Register ("CODE_AUDIOCHAT_INCORRECT_USER")]
			public const string CodeAudiochatIncorrectUser = (string) "601";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_NOT_ENABLED']"
			[Register ("CODE_AUDIOCHAT_NOT_ENABLED")]
			public const string CodeAudiochatNotEnabled = (string) "600";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_NOT_SUPPORTED']"
			[Register ("CODE_AUDIOCHAT_NOT_SUPPORTED")]
			public const string CodeAudiochatNotSupported = (string) "604";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AUDIOCHAT_USER_BUSY']"
			[Register ("CODE_AUDIOCHAT_USER_BUSY")]
			public const string CodeAudiochatUserBusy = (string) "605";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND']"
			[Register ("CODE_AVBROADCAST_CALL_DETAILS_NOT_FOUND")]
			public const string CodeAvbroadcastCallDetailsNotFound = (string) "702";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVBROADCAST_CONTAINER_EMPTY']"
			[Register ("CODE_AVBROADCAST_CONTAINER_EMPTY")]
			public const string CodeAvbroadcastContainerEmpty = (string) "703";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVBROADCAST_NOT_ENABLED']"
			[Register ("CODE_AVBROADCAST_NOT_ENABLED")]
			public const string CodeAvbroadcastNotEnabled = (string) "700";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVBROADCAST_NOT_SUPPORTED']"
			[Register ("CODE_AVBROADCAST_NOT_SUPPORTED")]
			public const string CodeAvbroadcastNotSupported = (string) "704";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_CALL_DETAILS_NOT_FOUND']"
			[Register ("CODE_AVCHAT_CALL_DETAILS_NOT_FOUND")]
			public const string CodeAvchatCallDetailsNotFound = (string) "502";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_CONTAINER_EMPTY']"
			[Register ("CODE_AVCHAT_CONTAINER_EMPTY")]
			public const string CodeAvchatContainerEmpty = (string) "503";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_INCORRECT_USER']"
			[Register ("CODE_AVCHAT_INCORRECT_USER")]
			public const string CodeAvchatIncorrectUser = (string) "501";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_NOT_ENABLED']"
			[Register ("CODE_AVCHAT_NOT_ENABLED")]
			public const string CodeAvchatNotEnabled = (string) "500";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_NOT_SUPPORTED']"
			[Register ("CODE_AVCHAT_NOT_SUPPORTED")]
			public const string CodeAvchatNotSupported = (string) "504";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_AVCHAT_USER_BUSY']"
			[Register ("CODE_AVCHAT_USER_BUSY")]
			public const string CodeAvchatUserBusy = (string) "505";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_BROADCAST_MESSAGE_DISABLED']"
			[Register ("CODE_BROADCAST_MESSAGE_DISABLED")]
			public const string CodeBroadcastMessageDisabled = (string) "303";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CHATROOMID_MISMATCH']"
			[Register ("CODE_CHATROOMID_MISMATCH")]
			public const string CodeChatroomidMismatch = (string) "404";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CHATROOM_CREATION_ERROR']"
			[Register ("CODE_CHATROOM_CREATION_ERROR")]
			public const string CodeChatroomCreationError = (string) "401";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CHATROOM_DELETION_ERROR']"
			[Register ("CODE_CHATROOM_DELETION_ERROR")]
			public const string CodeChatroomDeletionError = (string) "406";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CHATROOM_DONT_EXIST']"
			[Register ("CODE_CHATROOM_DONT_EXIST")]
			public const string CodeChatroomDontExist = (string) "405";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CHATROOM_NOT_JOINED']"
			[Register ("CODE_CHATROOM_NOT_JOINED")]
			public const string CodeChatroomNotJoined = (string) "400";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_COMETCHAT_NOT_FOUND']"
			[Register ("CODE_COMETCHAT_NOT_FOUND")]
			public const string CodeCometchatNotFound = (string) "108";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_COMETSERVICE_NOT_ENABLED']"
			[Register ("CODE_COMETSERVICE_NOT_ENABLED")]
			public const string CodeCometserviceNotEnabled = (string) "304";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED']"
			[Register ("CODE_COMETSERVICE_SELFHOSTED_NOT_ENABLED")]
			public const string CodeCometserviceSelfhostedNotEnabled = (string) "306";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CONFIGURE_TRANSLATE_PLUGIN']"
			[Register ("CODE_CONFIGURE_TRANSLATE_PLUGIN")]
			public const string CodeConfigureTranslatePlugin = (string) "109";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_CONNECTION_TO_HOST_404']"
			[Register ("CODE_CONNECTION_TO_HOST_404")]
			public const string CodeConnectionToHost404 = (string) "101";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_EMPTY_RESPONSE']"
			[Register ("CODE_EMPTY_RESPONSE")]
			public const string CodeEmptyResponse = (string) "201";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_FILE_DOES_NOT_EXIST']"
			[Register ("CODE_FILE_DOES_NOT_EXIST")]
			public const string CodeFileDoesNotExist = (string) "106";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_GAMES_NOT_ENABLED']"
			[Register ("CODE_GAMES_NOT_ENABLED")]
			public const string CodeGamesNotEnabled = (string) "113";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_INITAL_SETTING_ERROR']"
			[Register ("CODE_INITAL_SETTING_ERROR")]
			public const string CodeInitalSettingError = (string) "104";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_INVALID_URL']"
			[Register ("CODE_INVALID_URL")]
			public const string CodeInvalidUrl = (string) "202";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_JOIN_CHATROOM_BANNED']"
			[Register ("CODE_JOIN_CHATROOM_BANNED")]
			public const string CodeJoinChatroomBanned = (string) "403";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_JOIN_CHATROOM_WRONG_PWD']"
			[Register ("CODE_JOIN_CHATROOM_WRONG_PWD")]
			public const string CodeJoinChatroomWrongPwd = (string) "402";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_JSON_PARSING_ERROR']"
			[Register ("CODE_JSON_PARSING_ERROR")]
			public const string CodeJsonParsingError = (string) "103";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_LOGGEDOUT_HEARTBEAT']"
			[Register ("CODE_LOGGEDOUT_HEARTBEAT")]
			public const string CodeLoggedoutHeartbeat = (string) "105";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_NO_INTERNET_CONNECTION']"
			[Register ("CODE_NO_INTERNET_CONNECTION")]
			public const string CodeNoInternetConnection = (string) "100";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_PLAN_NOT_SUPPORTED']"
			[Register ("CODE_PLAN_NOT_SUPPORTED")]
			public const string CodePlanNotSupported = (string) "206";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_PLUGIN_INFO_NOTFOUND']"
			[Register ("CODE_PLUGIN_INFO_NOTFOUND")]
			public const string CodePluginInfoNotfound = (string) "110";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_RANDOM_EXCEPTION']"
			[Register ("CODE_RANDOM_EXCEPTION")]
			public const string CodeRandomException = (string) "107";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_REPORTCONVERSATION_NOT_ENABLED']"
			[Register ("CODE_REPORTCONVERSATION_NOT_ENABLED")]
			public const string CodeReportconversationNotEnabled = (string) "309";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_ROOM_ALREADY_EXIST']"
			[Register ("CODE_ROOM_ALREADY_EXIST")]
			public const string CodeRoomAlreadyExist = (string) "407";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_STICKER_PLUGIN_NOT_ENABLED']"
			[Register ("CODE_STICKER_PLUGIN_NOT_ENABLED")]
			public const string CodeStickerPluginNotEnabled = (string) "111";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_SUBSCRIPTION_EXPRIED']"
			[Register ("CODE_SUBSCRIPTION_EXPRIED")]
			public const string CodeSubscriptionExpried = (string) "205";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_TYPING_NOT_ENABLED']"
			[Register ("CODE_TYPING_NOT_ENABLED")]
			public const string CodeTypingNotEnabled = (string) "305";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USERID_WRONG']"
			[Register ("CODE_USERID_WRONG")]
			public const string CodeUseridWrong = (string) "200";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USERNAME_PASSWORD_WRONG']"
			[Register ("CODE_USERNAME_PASSWORD_WRONG")]
			public const string CodeUsernamePasswordWrong = (string) "204";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USER_NOT_BLOCKED']"
			[Register ("CODE_USER_NOT_BLOCKED")]
			public const string CodeUserNotBlocked = (string) "300";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USER_NOT_DELETED']"
			[Register ("CODE_USER_NOT_DELETED")]
			public const string CodeUserNotDeleted = (string) "302";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USER_NOT_FOUND']"
			[Register ("CODE_USER_NOT_FOUND")]
			public const string CodeUserNotFound = (string) "112";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USER_NOT_LOGGEDIN']"
			[Register ("CODE_USER_NOT_LOGGEDIN")]
			public const string CodeUserNotLoggedin = (string) "102";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_USER_NOT_UNBLOCKED']"
			[Register ("CODE_USER_NOT_UNBLOCKED")]
			public const string CodeUserNotUnblocked = (string) "301";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_VERSION_OLD']"
			[Register ("CODE_VERSION_OLD")]
			public const string CodeVersionOld = (string) "203";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_WHITEBOARD_NOT_ENABLED']"
			[Register ("CODE_WHITEBOARD_NOT_ENABLED")]
			public const string CodeWhiteboardNotEnabled = (string) "307";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_WRITEBOARD_NOT_ENABLED']"
			[Register ("CODE_WRITEBOARD_NOT_ENABLED")]
			public const string CodeWriteboardNotEnabled = (string) "308";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='CODE_YOU_ARE_NOT_OWNER']"
			[Register ("CODE_YOU_ARE_NOT_OWNER")]
			public const string CodeYouAreNotOwner = (string) "408";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND']"
			[Register ("MESSAGE_AUDIOCHAT_CALL_DETAILS_NOT_FOUND")]
			public const string MessageAudiochatCallDetailsNotFound = (string) "No Call Details found";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_CONTAINER_EMPTY']"
			[Register ("MESSAGE_AUDIOCHAT_CONTAINER_EMPTY")]
			public const string MessageAudiochatContainerEmpty = (string) "Container is empty";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_INCORRECT_USER']"
			[Register ("MESSAGE_AUDIOCHAT_INCORRECT_USER")]
			public const string MessageAudiochatIncorrectUser = (string) "User id provided for AudioChat call is incorrect";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_NOT_SUPPORTED']"
			[Register ("MESSAGE_AUDIOCHAT_NOT_SUPPORTED")]
			public const string MessageAudiochatNotSupported = (string) "Your device does not support this feature";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED']"
			[Register ("MESSAGE_AUDIOCHAT_PLUGIN_NOT_ENABLED")]
			public const string MessageAudiochatPluginNotEnabled = (string) "AudioChat plugin not enabled";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AUDIOCHAT_USER_BUSY']"
			[Register ("MESSAGE_AUDIOCHAT_USER_BUSY")]
			public const string MessageAudiochatUserBusy = (string) "User is already busy in a call";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND']"
			[Register ("MESSAGE_AVBROADCAST_CALL_DETAILS_NOT_FOUND")]
			public const string MessageAvbroadcastCallDetailsNotFound = (string) "No broadcast Details found";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVBROADCAST_CONTAINER_EMPTY']"
			[Register ("MESSAGE_AVBROADCAST_CONTAINER_EMPTY")]
			public const string MessageAvbroadcastContainerEmpty = (string) "Container is empty";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVBROADCAST_NOT_SUPPORTED']"
			[Register ("MESSAGE_AVBROADCAST_NOT_SUPPORTED")]
			public const string MessageAvbroadcastNotSupported = (string) "Your device does not support this feature";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED']"
			[Register ("MESSAGE_AVBROADCAST_PLUGIN_NOT_ENABLED")]
			public const string MessageAvbroadcastPluginNotEnabled = (string) "AVBroadcast plugin not enabled";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_CALL_DETAILS_NOT_FOUND']"
			[Register ("MESSAGE_AVCHAT_CALL_DETAILS_NOT_FOUND")]
			public const string MessageAvchatCallDetailsNotFound = (string) "No Call Details found";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_CONTAINER_EMPTY']"
			[Register ("MESSAGE_AVCHAT_CONTAINER_EMPTY")]
			public const string MessageAvchatContainerEmpty = (string) "Container is empty";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_INCORRECT_USER']"
			[Register ("MESSAGE_AVCHAT_INCORRECT_USER")]
			public const string MessageAvchatIncorrectUser = (string) "User id provided for AVChat call is incorrect";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_NOT_SUPPORTED']"
			[Register ("MESSAGE_AVCHAT_NOT_SUPPORTED")]
			public const string MessageAvchatNotSupported = (string) "Your device does not support this feature";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED']"
			[Register ("MESSAGE_AVCHAT_PLUGIN_NOT_ENABLED")]
			public const string MessageAvchatPluginNotEnabled = (string) "AVChat plugin not enabled";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_AVCHAT_USER_BUSY']"
			[Register ("MESSAGE_AVCHAT_USER_BUSY")]
			public const string MessageAvchatUserBusy = (string) "User is already busy in a call";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_BROADCAST_MESSAGE_DISABLED']"
			[Register ("MESSAGE_BROADCAST_MESSAGE_DISABLED")]
			public const string MessageBroadcastMessageDisabled = (string) "Broadcast module is not enabled for SDK";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CHATROOMID_MISMATCH']"
			[Register ("MESSAGE_CHATROOMID_MISMATCH")]
			public const string MessageChatroomidMismatch = (string) "Please check your chatroomid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CHATROOM_CREATION_ERROR']"
			[Register ("MESSAGE_CHATROOM_CREATION_ERROR")]
			public const string MessageChatroomCreationError = (string) "This chatroom can't be created, it may exists";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CHATROOM_DELETE_ERROR']"
			[Register ("MESSAGE_CHATROOM_DELETE_ERROR")]
			public const string MessageChatroomDeleteError = (string) "You do not have the privileges(owner,moderator & admin) to delete this chatroom OR This chatroom doesn't exists";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CHATROOM_DONT_EXIST']"
			[Register ("MESSAGE_CHATROOM_DONT_EXIST")]
			public const string MessageChatroomDontExist = (string) "This chatroom does not exist";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CHATROOM_NOT_JOINED']"
			[Register ("MESSAGE_CHATROOM_NOT_JOINED")]
			public const string MessageChatroomNotJoined = (string) "You have not joined any chatroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_COMETCHAT_NOT_FOUND']"
			[Register ("MESSAGE_COMETCHAT_NOT_FOUND")]
			public const string MessageCometchatNotFound = (string) "CometChat is not installed at specified url";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_COMETSERVICE_NOT_ENABLED']"
			[Register ("MESSAGE_COMETSERVICE_NOT_ENABLED")]
			public const string MessageCometserviceNotEnabled = (string) "CometService is not enabled for your CometChat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED']"
			[Register ("MESSAGE_COMETSERVICE_SELFHOSTED_NOT_ENABLED")]
			public const string MessageCometserviceSelfhostedNotEnabled = (string) "CometService Selfhosted is not enabled for your CometChat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CONFIGURE_TRANSLATE_PLUGIN']"
			[Register ("MESSAGE_CONFIGURE_TRANSLATE_PLUGIN")]
			public const string MessageConfigureTranslatePlugin = (string) "Please configure Translate Conversation module on CometChat admin panel";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_CONNECTION_REFUSED_404']"
			[Register ("MESSAGE_CONNECTION_REFUSED_404")]
			public const string MessageConnectionRefused404 = (string) "Error in connection";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_EMPTY_LOGIN_RESPONSE']"
			[Register ("MESSAGE_EMPTY_LOGIN_RESPONSE")]
			public const string MessageEmptyLoginResponse = (string) "Invalid user details";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_FILE_DOES_NOT_EXIST']"
			[Register ("MESSAGE_FILE_DOES_NOT_EXIST")]
			public const string MessageFileDoesNotExist = (string) "The file does not exist on the given path.";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_GAME_PLUGIN_NOT_ENABLED']"
			[Register ("MESSAGE_GAME_PLUGIN_NOT_ENABLED")]
			public const string MessageGamePluginNotEnabled = (string) "Single player game is not enabled on your CometChat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_INVALID_URL']"
			[Register ("MESSAGE_INVALID_URL")]
			public const string MessageInvalidUrl = (string) "Invalid url or response for login is incorrect";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_JOIN_CHATROOM_BANNED']"
			[Register ("MESSAGE_JOIN_CHATROOM_BANNED")]
			public const string MessageJoinChatroomBanned = (string) "You are banned from this chatroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_JOIN_CHATROOM_WRONG_PWD']"
			[Register ("MESSAGE_JOIN_CHATROOM_WRONG_PWD")]
			public const string MessageJoinChatroomWrongPwd = (string) "Please enter correct password for chatroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_JSONPHP_ERROR']"
			[Register ("MESSAGE_JSONPHP_ERROR")]
			public const string MessageJsonphpError = (string) "Error at initializing settings";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_JSON_PARSING_ERROR']"
			[Register ("MESSAGE_JSON_PARSING_ERROR")]
			public const string MessageJsonParsingError = (string) "Error at parsing json";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_LOGGEDOUT_HEARTBEAT']"
			[Register ("MESSAGE_LOGGEDOUT_HEARTBEAT")]
			public const string MessageLoggedoutHeartbeat = (string) "Log in error in heartbeat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_NOT_CHATROOM_OWNER']"
			[Register ("MESSAGE_NOT_CHATROOM_OWNER")]
			public const string MessageNotChatroomOwner = (string) "You are not owner or moderator of chatroom";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_NOT_LOGGEDIN']"
			[Register ("MESSAGE_NOT_LOGGEDIN")]
			public const string MessageNotLoggedin = (string) "You must be logged in";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_PLEASE_CHECK_INTERNET']"
			[Register ("MESSAGE_PLEASE_CHECK_INTERNET")]
			public const string MessagePleaseCheckInternet = (string) "Please check your internet connection";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_PLEASE_UPGRADE_COMETCHAT']"
			[Register ("MESSAGE_PLEASE_UPGRADE_COMETCHAT")]
			public const string MessagePleaseUpgradeCometchat = (string) "Sorry, CometChat needs to be upgraded on the site to use this app.";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_PLUGIN_INFO_NOTFOUND']"
			[Register ("MESSAGE_PLUGIN_INFO_NOTFOUND")]
			public const string MessagePluginInfoNotfound = (string) "Plugin information not present, please subscribe to CometChat.";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_RANDOM_EXCEPTION']"
			[Register ("MESSAGE_RANDOM_EXCEPTION")]
			public const string MessageRandomException = (string) "An exception has occured. Please check the stacktrace.";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_REPORTCONVERSATION_NOT_ENABLED']"
			[Register ("MESSAGE_REPORTCONVERSATION_NOT_ENABLED")]
			public const string MessageReportconversationNotEnabled = (string) "Please enable reportconversation plugin from administration panel";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_ROOM_ALREADY_EXIST']"
			[Register ("MESSAGE_ROOM_ALREADY_EXIST")]
			public const string MessageRoomAlreadyExist = (string) "The chatroomname already exist";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_SITCKER_PLUGIN_NOT_ENABLED']"
			[Register ("MESSAGE_SITCKER_PLUGIN_NOT_ENABLED")]
			public const string MessageSitckerPluginNotEnabled = (string) "Sticker plugin is not enabled on your CometChat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_TYPING_NOT_ENABLED']"
			[Register ("MESSAGE_TYPING_NOT_ENABLED")]
			public const string MessageTypingNotEnabled = (string) "Typing is not enabled on for your CometChat";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_USER_NOT_BLOCKED']"
			[Register ("MESSAGE_USER_NOT_BLOCKED")]
			public const string MessageUserNotBlocked = (string) "An error occurred while blocking user";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_USER_NOT_DELETED']"
			[Register ("MESSAGE_USER_NOT_DELETED")]
			public const string MessageUserNotDeleted = (string) "An error occurred while deleting history of user";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_USER_NOT_FOUND']"
			[Register ("MESSAGE_USER_NOT_FOUND")]
			public const string MessageUserNotFound = (string) "User not found";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_USER_NOT_UNBLOCKED']"
			[Register ("MESSAGE_USER_NOT_UNBLOCKED")]
			public const string MessageUserNotUnblocked = (string) "An error occurred while unblocking user";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_WHITEBOARD_NOT_ENABLED']"
			[Register ("MESSAGE_WHITEBOARD_NOT_ENABLED")]
			public const string MessageWhiteboardNotEnabled = (string) "Please enable whiteboard plugin from administration panel";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_WRITEBOARD_NOT_ENABLED']"
			[Register ("MESSAGE_WRITEBOARD_NOT_ENABLED")]
			public const string MessageWriteboardNotEnabled = (string) "Please enable writeboard plugin from administration panel";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_WRONG_USERID']"
			[Register ("MESSAGE_WRONG_USERID")]
			public const string MessageWrongUserid = (string) "Incorrect userId";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/field[@name='MESSAGE_WRONG_USERNAME_PASSWORD']"
			[Register ("MESSAGE_WRONG_USERNAME_PASSWORD")]
			public const string MessageWrongUsernamePassword = (string) "Incorrect username or password";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$ErrorKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ErrorKeys); }
			}

			protected ErrorKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ErrorKeys']/constructor[@name='CometChatKeys.ErrorKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ErrorKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ErrorKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$FileUploadKeys", DoNotGenerateAcw=true)]
		public partial class FileUploadKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='CHATROOMMODE']"
			[Register ("CHATROOMMODE")]
			public const string Chatroommode = (string) "chatroommode";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='CHATROOMMODE_VALUE']"
			[Register ("CHATROOMMODE_VALUE")]
			public const string ChatroommodeValue = (string) "1";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='FILEDATA']"
			[Register ("FILEDATA")]
			public const string Filedata = (string) "Filedata";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='FILENAME']"
			[Register ("FILENAME")]
			public const string Filename = (string) "name";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='IMAGE_HEIGHT']"
			[Register ("IMAGE_HEIGHT")]
			public const string ImageHeight = (string) "imageheight";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='IMAGE_WIDTH']"
			[Register ("IMAGE_WIDTH")]
			public const string ImageWidth = (string) "imagewidth";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/field[@name='SENDERNAME']"
			[Register ("SENDERNAME")]
			public const string Sendername = (string) "sendername";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$FileUploadKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (FileUploadKeys); }
			}

			protected FileUploadKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.FileUploadKeys']/constructor[@name='CometChatKeys.FileUploadKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe FileUploadKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (FileUploadKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.LoginKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$LoginKeys", DoNotGenerateAcw=true)]
		public partial class LoginKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.LoginKeys']/field[@name='DONT_REMEMBER_USER']"
			[Register ("DONT_REMEMBER_USER")]
			public const string DontRememberUser = (string) "0";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.LoginKeys']/field[@name='USER_LOGGED_IN']"
			[Register ("USER_LOGGED_IN")]
			public const string UserLoggedIn = (string) "1";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.LoginKeys']/field[@name='USER_REMEMBER']"
			[Register ("USER_REMEMBER")]
			public const string UserRemember = (string) "1";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$LoginKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (LoginKeys); }
			}

			protected LoginKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.LoginKeys']/constructor[@name='CometChatKeys.LoginKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe LoginKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (LoginKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$MessageTypeKeys", DoNotGenerateAcw=true)]
		public partial class MessageTypeKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AUDIO_CONFERENCE']"
			[Register ("AUDIO_CONFERENCE")]
			public const string AudioConference = (string) "23";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AUDIO_DOWNLOADED']"
			[Register ("AUDIO_DOWNLOADED")]
			public const string AudioDownloaded = (string) "12";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AUDIO_IS_DOWNLOADING']"
			[Register ("AUDIO_IS_DOWNLOADING")]
			public const string AudioIsDownloading = (string) "11";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AUDIO_NEW']"
			[Register ("AUDIO_NEW")]
			public const string AudioNew = (string) "13";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AUDIO_UPLOAD']"
			[Register ("AUDIO_UPLOAD")]
			public const string AudioUpload = (string) "14";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AVBROADCAST']"
			[Register ("AVBROADCAST")]
			public const string Avbroadcast = (string) "15";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='AVCHAT']"
			[Register ("AVCHAT")]
			public const string Avchat = (string) "1";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='BOT_RESPONCE']"
			[Register ("BOT_RESPONCE")]
			public const string BotResponce = (string) "24";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='FILE_DOWNLOADED']"
			[Register ("FILE_DOWNLOADED")]
			public const string FileDownloaded = (string) "19";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='FILE_DOWNLOADING']"
			[Register ("FILE_DOWNLOADING")]
			public const string FileDownloading = (string) "18";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='FILE_NEW']"
			[Register ("FILE_NEW")]
			public const string FileNew = (string) "17";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='HANDWRITE_DOWNLOADED']"
			[Register ("HANDWRITE_DOWNLOADED")]
			public const string HandwriteDownloaded = (string) "9";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='HANDWRITE_NEW']"
			[Register ("HANDWRITE_NEW")]
			public const string HandwriteNew = (string) "7";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='IMAGE_DOWNLOADED']"
			[Register ("IMAGE_DOWNLOADED")]
			public const string ImageDownloaded = (string) "8";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='IMAGE_NEW']"
			[Register ("IMAGE_NEW")]
			public const string ImageNew = (string) "3";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='JOIN_CHATROOM_MESSAGE']"
			[Register ("JOIN_CHATROOM_MESSAGE")]
			public const string JoinChatroomMessage = (string) "2";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='MESSAGE_DELIVERD']"
			[Register ("MESSAGE_DELIVERD")]
			public const int MessageDeliverd = (int) 2;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='MESSAGE_READ']"
			[Register ("MESSAGE_READ")]
			public const int MessageRead = (int) 3;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='MESSAGE_SENT']"
			[Register ("MESSAGE_SENT")]
			public const int MessageSent = (int) 1;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='MESSAGE_TYPE']"
			[Register ("MESSAGE_TYPE")]
			public const string MessageType = (string) "messageType";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='NORMAL']"
			[Register ("NORMAL")]
			public const string Normal = (string) "0";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='SCREENSHARE_REQUEST']"
			[Register ("SCREENSHARE_REQUEST")]
			public const string ScreenshareRequest = (string) "22";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='STICKERS']"
			[Register ("STICKERS")]
			public const string Stickers = (string) "16";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='VIDEO_DOWNLOADED']"
			[Register ("VIDEO_DOWNLOADED")]
			public const string VideoDownloaded = (string) "5";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='VIDEO_IS_DOWNLOADING']"
			[Register ("VIDEO_IS_DOWNLOADING")]
			public const string VideoIsDownloading = (string) "10";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='VIDEO_NEW']"
			[Register ("VIDEO_NEW")]
			public const string VideoNew = (string) "4";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='VIDEO_UPLOAD']"
			[Register ("VIDEO_UPLOAD")]
			public const string VideoUpload = (string) "6";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='WHITEBOARD_REQUEST']"
			[Register ("WHITEBOARD_REQUEST")]
			public const string WhiteboardRequest = (string) "20";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/field[@name='WRITEBOARD_REQUEST']"
			[Register ("WRITEBOARD_REQUEST")]
			public const string WriteboardRequest = (string) "21";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$MessageTypeKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (MessageTypeKeys); }
			}

			protected MessageTypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.MessageTypeKeys']/constructor[@name='CometChatKeys.MessageTypeKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe MessageTypeKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (MessageTypeKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$OtherPluginKeys", DoNotGenerateAcw=true)]
		public partial class OtherPluginKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='GAME_ACCEPT_KEY']"
			[Register ("GAME_ACCEPT_KEY")]
			public const string GameAcceptKey = (string) "jqcc.ccgames.accept_fid(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='GAME_REQUEST_KEY']"
			[Register ("GAME_REQUEST_KEY")]
			public const string GameRequestKey = (string) "jqcc.ccgames.accept(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='HANDWRITE_KEY']"
			[Register ("HANDWRITE_KEY")]
			public const string HandwriteKey = (string) "/plugins/handwrite/uploads/";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='SCREENSHARE_REQUEST_KEY']"
			[Register ("SCREENSHARE_REQUEST_KEY")]
			public const string ScreenshareRequestKey = (string) "jqcc.ccscreenshare.accept(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='WHITEBOARD_REQUEST_KEY']"
			[Register ("WHITEBOARD_REQUEST_KEY")]
			public const string WhiteboardRequestKey = (string) "jqcc.ccwhiteboard.accept(";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/field[@name='WRITEBOARD_REQUEST_KEY']"
			[Register ("WRITEBOARD_REQUEST_KEY")]
			public const string WriteboardRequestKey = (string) "jqcc.ccwriteboard.accept(";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$OtherPluginKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (OtherPluginKeys); }
			}

			protected OtherPluginKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.OtherPluginKeys']/constructor[@name='CometChatKeys.OtherPluginKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe OtherPluginKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (OtherPluginKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ReportKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$ReportKeys", DoNotGenerateAcw=true)]
		public partial class ReportKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ReportKeys']/field[@name='RANDOM']"
			[Register ("RANDOM")]
			public const string Random = (string) "rand";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ReportKeys']/field[@name='REPORT_ISSUE']"
			[Register ("REPORT_ISSUE")]
			public const string ReportIssue = (string) "issue";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$ReportKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ReportKeys); }
			}

			protected ReportKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.ReportKeys']/constructor[@name='CometChatKeys.ReportKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ReportKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ReportKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$SDKMessageTypeKeys", DoNotGenerateAcw=true)]
		public partial class SDKMessageTypeKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='AUDIO']"
			[Register ("AUDIO")]
			public const int Audio = (int) 16;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='AUDIO_CALL']"
			[Register ("AUDIO_CALL")]
			public const int AudioCall = (int) 0;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='AVBROADCAST']"
			[Register ("AVBROADCAST")]
			public const int Avbroadcast = (int) 2;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='AVCALL']"
			[Register ("AVCALL")]
			public const int Avcall = (int) 1;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='DELETED_MESSAGE']"
			[Register ("DELETED_MESSAGE")]
			public const int DeletedMessage = (int) 15;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='FILE']"
			[Register ("FILE")]
			public const int File = (int) 17;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='HANDWRITTEN_MESSAGE']"
			[Register ("HANDWRITTEN_MESSAGE")]
			public const int HandwrittenMessage = (int) 13;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='IMAGE']"
			[Register ("IMAGE")]
			public const int Image = (int) 12;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='JOIN_CHATROOM_MESSAGE']"
			[Register ("JOIN_CHATROOM_MESSAGE")]
			public const int JoinChatroomMessage = (int) 11;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='MESSAGE_TYPE']"
			[Register ("MESSAGE_TYPE")]
			public const string MessageType = (string) "message_type";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='NORMAL']"
			[Register ("NORMAL")]
			public const int Normal = (int) 10;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='PLUGIN_TYPE']"
			[Register ("PLUGIN_TYPE")]
			public const string PluginType = (string) "pluginType";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='SCREENSHARE']"
			[Register ("SCREENSHARE")]
			public const int Screenshare = (int) 21;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='STICKER']"
			[Register ("STICKER")]
			public const int Sticker = (int) 18;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='VIDEO']"
			[Register ("VIDEO")]
			public const int Video = (int) 14;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='WHITEBOARD']"
			[Register ("WHITEBOARD")]
			public const int Whiteboard = (int) 19;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/field[@name='WRITEBOARD']"
			[Register ("WRITEBOARD")]
			public const int Writeboard = (int) 20;
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$SDKMessageTypeKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (SDKMessageTypeKeys); }
			}

			protected SDKMessageTypeKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.SDKMessageTypeKeys']/constructor[@name='CometChatKeys.SDKMessageTypeKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe SDKMessageTypeKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (SDKMessageTypeKeys)) {
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

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/CometChatKeys$StatusKeys", DoNotGenerateAcw=true)]
		public partial class StatusKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='AVALIABLE']"
			[Register ("AVALIABLE")]
			public const string Avaliable = (string) "available";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='AWAY']"
			[Register ("AWAY")]
			public const string Away = (string) "away";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='BUSY']"
			[Register ("BUSY")]
			public const string Busy = (string) "busy";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='INVISIBLE']"
			[Register ("INVISIBLE")]
			public const string Invisible = (string) "invisible";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='OFFLINE']"
			[Register ("OFFLINE")]
			public const string Offline = (string) "offline";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='STATUS']"
			[Register ("STATUS")]
			public const string Status = (string) "status";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/field[@name='STATUS_MESSAGE']"
			[Register ("STATUS_MESSAGE")]
			public const string StatusMessage = (string) "statusmessage";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys$StatusKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (StatusKeys); }
			}

			protected StatusKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys.StatusKeys']/constructor[@name='CometChatKeys.StatusKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe StatusKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (StatusKeys)) {
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
				return JNIEnv.FindClass ("com/inscripts/keys/CometChatKeys", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometChatKeys); }
		}

		protected CometChatKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='CometChatKeys']/constructor[@name='CometChatKeys' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CometChatKeys ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CometChatKeys)) {
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
