using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Factories {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']"
	[global::Android.Runtime.Register ("com/inscripts/factories/URLFactory", DoNotGenerateAcw=true)]
	public partial class URLFactory : global::Java.Lang.Object {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/field[@name='LEGACY_APP_LINK']"
		[Register ("LEGACY_APP_LINK")]
		public const string LegacyAppLink = (string) "https://play.google.com/store/apps/details?id=com.inscripts.cometchat.legacy";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/field[@name='PROTOCOL_PREFIX']"
		[Register ("PROTOCOL_PREFIX")]
		public const string ProtocolPrefix = (string) "http://";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/field[@name='PROTOCOL_PREFIX_SECURE']"
		[Register ("PROTOCOL_PREFIX_SECURE")]
		public const string ProtocolPrefixSecure = (string) "https://";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/field[@name='TWITTER_STREAM_URL']"
		[Register ("TWITTER_STREAM_URL")]
		public const string TwitterStreamUrl = (string) "https://api.twitter.com/1.1/users/show.json?screen_name=";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/field[@name='TWITTER_TOKEN_URL']"
		[Register ("TWITTER_TOKEN_URL")]
		public const string TwitterTokenUrl = (string) "https://api.twitter.com/oauth2/token";
		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']"
		[global::Android.Runtime.Register ("com/inscripts/factories/URLFactory$CloudURLS", DoNotGenerateAcw=true)]
		public partial class CloudURLS : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='ADD_FRIENDS']"
			[Register ("ADD_FRIENDS")]
			public const string AddFriends = (string) "/api/addfriend";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='COD_LOGIN_URL']"
			[Register ("COD_LOGIN_URL")]
			public const string CodLoginUrl = (string) "/api/app_login";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='CREATE_USER']"
			[Register ("CREATE_USER")]
			public const string CreateUser = (string) "/api/createuser";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='REMOVE_FRIENDS']"
			[Register ("REMOVE_FRIENDS")]
			public const string RemoveFriends = (string) "/api/removefriend";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='REMOVE_USER']"
			[Register ("REMOVE_USER")]
			public const string RemoveUser = (string) "/api/removeuser";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/field[@name='UPDATE_USER']"
			[Register ("UPDATE_USER")]
			public const string UpdateUser = (string) "/api/updateuser";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/factories/URLFactory$CloudURLS", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (CloudURLS); }
			}

			protected CloudURLS (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/constructor[@name='URLFactory.CloudURLS' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe CloudURLS ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (CloudURLS)) {
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

			static IntPtr id_getAddFriendsURL;
			public static unsafe string AddFriendsURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getAddFriendsURL' and count(parameter)=0]"
				[Register ("getAddFriendsURL", "()Ljava/lang/String;", "GetGetAddFriendsURLHandler")]
				get {
					if (id_getAddFriendsURL == IntPtr.Zero)
						id_getAddFriendsURL = JNIEnv.GetStaticMethodID (class_ref, "getAddFriendsURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAddFriendsURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getCreateUserURL;
			public static unsafe string CreateUserURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getCreateUserURL' and count(parameter)=0]"
				[Register ("getCreateUserURL", "()Ljava/lang/String;", "GetGetCreateUserURLHandler")]
				get {
					if (id_getCreateUserURL == IntPtr.Zero)
						id_getCreateUserURL = JNIEnv.GetStaticMethodID (class_ref, "getCreateUserURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCreateUserURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getLoginURL;
			public static unsafe string LoginURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getLoginURL' and count(parameter)=0]"
				[Register ("getLoginURL", "()Ljava/lang/String;", "GetGetLoginURLHandler")]
				get {
					if (id_getLoginURL == IntPtr.Zero)
						id_getLoginURL = JNIEnv.GetStaticMethodID (class_ref, "getLoginURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getLoginURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getRemoveFriendsURL;
			public static unsafe string RemoveFriendsURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getRemoveFriendsURL' and count(parameter)=0]"
				[Register ("getRemoveFriendsURL", "()Ljava/lang/String;", "GetGetRemoveFriendsURLHandler")]
				get {
					if (id_getRemoveFriendsURL == IntPtr.Zero)
						id_getRemoveFriendsURL = JNIEnv.GetStaticMethodID (class_ref, "getRemoveFriendsURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRemoveFriendsURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getRemoveUserURL;
			public static unsafe string RemoveUserURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getRemoveUserURL' and count(parameter)=0]"
				[Register ("getRemoveUserURL", "()Ljava/lang/String;", "GetGetRemoveUserURLHandler")]
				get {
					if (id_getRemoveUserURL == IntPtr.Zero)
						id_getRemoveUserURL = JNIEnv.GetStaticMethodID (class_ref, "getRemoveUserURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRemoveUserURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

			static IntPtr id_getUpdateUserURL;
			public static unsafe string UpdateUserURL {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory.CloudURLS']/method[@name='getUpdateUserURL' and count(parameter)=0]"
				[Register ("getUpdateUserURL", "()Ljava/lang/String;", "GetGetUpdateUserURLHandler")]
				get {
					if (id_getUpdateUserURL == IntPtr.Zero)
						id_getUpdateUserURL = JNIEnv.GetStaticMethodID (class_ref, "getUpdateUserURL", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getUpdateUserURL), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/factories/URLFactory", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (URLFactory); }
		}

		protected URLFactory (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/constructor[@name='URLFactory' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe URLFactory ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (URLFactory)) {
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

		static IntPtr id_getAVBroadcastEndURL;
		public static unsafe string AVBroadcastEndURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAVBroadcastEndURL' and count(parameter)=0]"
			[Register ("getAVBroadcastEndURL", "()Ljava/lang/String;", "GetGetAVBroadcastEndURLHandler")]
			get {
				if (id_getAVBroadcastEndURL == IntPtr.Zero)
					id_getAVBroadcastEndURL = JNIEnv.GetStaticMethodID (class_ref, "getAVBroadcastEndURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVBroadcastEndURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAVBroadcastInviteURL;
		public static unsafe string AVBroadcastInviteURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAVBroadcastInviteURL' and count(parameter)=0]"
			[Register ("getAVBroadcastInviteURL", "()Ljava/lang/String;", "GetGetAVBroadcastInviteURLHandler")]
			get {
				if (id_getAVBroadcastInviteURL == IntPtr.Zero)
					id_getAVBroadcastInviteURL = JNIEnv.GetStaticMethodID (class_ref, "getAVBroadcastInviteURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVBroadcastInviteURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAVBroadcastRequestURL;
		public static unsafe string AVBroadcastRequestURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAVBroadcastRequestURL' and count(parameter)=0]"
			[Register ("getAVBroadcastRequestURL", "()Ljava/lang/String;", "GetGetAVBroadcastRequestURLHandler")]
			get {
				if (id_getAVBroadcastRequestURL == IntPtr.Zero)
					id_getAVBroadcastRequestURL = JNIEnv.GetStaticMethodID (class_ref, "getAVBroadcastRequestURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVBroadcastRequestURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAVChatURL;
		public static unsafe string AVChatURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAVChatURL' and count(parameter)=0]"
			[Register ("getAVChatURL", "()Ljava/lang/String;", "GetGetAVChatURLHandler")]
			get {
				if (id_getAVChatURL == IntPtr.Zero)
					id_getAVChatURL = JNIEnv.GetStaticMethodID (class_ref, "getAVChatURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAVChatURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAnnouncementTabUrl;
		public static unsafe string AnnouncementTabUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAnnouncementTabUrl' and count(parameter)=0]"
			[Register ("getAnnouncementTabUrl", "()Ljava/lang/String;", "GetGetAnnouncementTabUrlHandler")]
			get {
				if (id_getAnnouncementTabUrl == IntPtr.Zero)
					id_getAnnouncementTabUrl = JNIEnv.GetStaticMethodID (class_ref, "getAnnouncementTabUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAnnouncementTabUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAnnouncementUrl;
		public static unsafe string AnnouncementUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAnnouncementUrl' and count(parameter)=0]"
			[Register ("getAnnouncementUrl", "()Ljava/lang/String;", "GetGetAnnouncementUrlHandler")]
			get {
				if (id_getAnnouncementUrl == IntPtr.Zero)
					id_getAnnouncementUrl = JNIEnv.GetStaticMethodID (class_ref, "getAnnouncementUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAnnouncementUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAudioChatURL;
		public static unsafe string AudioChatURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getAudioChatURL' and count(parameter)=0]"
			[Register ("getAudioChatURL", "()Ljava/lang/String;", "GetGetAudioChatURLHandler")]
			get {
				if (id_getAudioChatURL == IntPtr.Zero)
					id_getAudioChatURL = JNIEnv.GetStaticMethodID (class_ref, "getAudioChatURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAudioChatURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBanUserURL;
		public static unsafe string BanUserURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getBanUserURL' and count(parameter)=0]"
			[Register ("getBanUserURL", "()Ljava/lang/String;", "GetGetBanUserURLHandler")]
			get {
				if (id_getBanUserURL == IntPtr.Zero)
					id_getBanUserURL = JNIEnv.GetStaticMethodID (class_ref, "getBanUserURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBanUserURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBaseURL;
		public static unsafe string BaseURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getBaseURL' and count(parameter)=0]"
			[Register ("getBaseURL", "()Ljava/lang/String;", "GetGetBaseURLHandler")]
			get {
				if (id_getBaseURL == IntPtr.Zero)
					id_getBaseURL = JNIEnv.GetStaticMethodID (class_ref, "getBaseURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBaseURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBlockUserURL;
		public static unsafe string BlockUserURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getBlockUserURL' and count(parameter)=0]"
			[Register ("getBlockUserURL", "()Ljava/lang/String;", "GetGetBlockUserURLHandler")]
			get {
				if (id_getBlockUserURL == IntPtr.Zero)
					id_getBlockUserURL = JNIEnv.GetStaticMethodID (class_ref, "getBlockUserURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBlockUserURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBlockedUserURL;
		public static unsafe string BlockedUserURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getBlockedUserURL' and count(parameter)=0]"
			[Register ("getBlockedUserURL", "()Ljava/lang/String;", "GetGetBlockedUserURLHandler")]
			get {
				if (id_getBlockedUserURL == IntPtr.Zero)
					id_getBlockedUserURL = JNIEnv.GetStaticMethodID (class_ref, "getBlockedUserURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBlockedUserURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getBroadCastMessageURL;
		public static unsafe string BroadCastMessageURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getBroadCastMessageURL' and count(parameter)=0]"
			[Register ("getBroadCastMessageURL", "()Ljava/lang/String;", "GetGetBroadCastMessageURLHandler")]
			get {
				if (id_getBroadCastMessageURL == IntPtr.Zero)
					id_getBroadCastMessageURL = JNIEnv.GetStaticMethodID (class_ref, "getBroadCastMessageURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getBroadCastMessageURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCCUserManagementURL;
		public static unsafe string CCUserManagementURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCCUserManagementURL' and count(parameter)=0]"
			[Register ("getCCUserManagementURL", "()Ljava/lang/String;", "GetGetCCUserManagementURLHandler")]
			get {
				if (id_getCCUserManagementURL == IntPtr.Zero)
					id_getCCUserManagementURL = JNIEnv.GetStaticMethodID (class_ref, "getCCUserManagementURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCCUserManagementURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCRAVBroadcastRequestURL;
		public static unsafe string CRAVBroadcastRequestURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCRAVBroadcastRequestURL' and count(parameter)=0]"
			[Register ("getCRAVBroadcastRequestURL", "()Ljava/lang/String;", "GetGetCRAVBroadcastRequestURLHandler")]
			get {
				if (id_getCRAVBroadcastRequestURL == IntPtr.Zero)
					id_getCRAVBroadcastRequestURL = JNIEnv.GetStaticMethodID (class_ref, "getCRAVBroadcastRequestURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCRAVBroadcastRequestURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getChatroomInviteURL;
		public static unsafe string ChatroomInviteURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getChatroomInviteURL' and count(parameter)=0]"
			[Register ("getChatroomInviteURL", "()Ljava/lang/String;", "GetGetChatroomInviteURLHandler")]
			get {
				if (id_getChatroomInviteURL == IntPtr.Zero)
					id_getChatroomInviteURL = JNIEnv.GetStaticMethodID (class_ref, "getChatroomInviteURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomInviteURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getChatroomLeaveURL;
		public static unsafe string ChatroomLeaveURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getChatroomLeaveURL' and count(parameter)=0]"
			[Register ("getChatroomLeaveURL", "()Ljava/lang/String;", "GetGetChatroomLeaveURLHandler")]
			get {
				if (id_getChatroomLeaveURL == IntPtr.Zero)
					id_getChatroomLeaveURL = JNIEnv.GetStaticMethodID (class_ref, "getChatroomLeaveURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomLeaveURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getChatroomPasswordUrl;
		public static unsafe string ChatroomPasswordUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getChatroomPasswordUrl' and count(parameter)=0]"
			[Register ("getChatroomPasswordUrl", "()Ljava/lang/String;", "GetGetChatroomPasswordUrlHandler")]
			get {
				if (id_getChatroomPasswordUrl == IntPtr.Zero)
					id_getChatroomPasswordUrl = JNIEnv.GetStaticMethodID (class_ref, "getChatroomPasswordUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomPasswordUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getChatroomUrl;
		public static unsafe string ChatroomUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getChatroomUrl' and count(parameter)=0]"
			[Register ("getChatroomUrl", "()Ljava/lang/String;", "GetGetChatroomUrlHandler")]
			get {
				if (id_getChatroomUrl == IntPtr.Zero)
					id_getChatroomUrl = JNIEnv.GetStaticMethodID (class_ref, "getChatroomUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getChatroomUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCodLoginUrl;
		public static unsafe string CodLoginUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCodLoginUrl' and count(parameter)=0]"
			[Register ("getCodLoginUrl", "()Ljava/lang/String;", "GetGetCodLoginUrlHandler")]
			get {
				if (id_getCodLoginUrl == IntPtr.Zero)
					id_getCodLoginUrl = JNIEnv.GetStaticMethodID (class_ref, "getCodLoginUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCodLoginUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCodUrl;
		public static unsafe string CodUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCodUrl' and count(parameter)=0]"
			[Register ("getCodUrl", "()Ljava/lang/String;", "GetGetCodUrlHandler")]
			get {
				if (id_getCodUrl == IntPtr.Zero)
					id_getCodUrl = JNIEnv.GetStaticMethodID (class_ref, "getCodUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCodUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCometChatURL;
		public static unsafe string CometChatURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCometChatURL' and count(parameter)=0]"
			[Register ("getCometChatURL", "()Ljava/lang/String;", "GetGetCometChatURLHandler")]
			get {
				if (id_getCometChatURL == IntPtr.Zero)
					id_getCometChatURL = JNIEnv.GetStaticMethodID (class_ref, "getCometChatURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCometChatURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCometOnDemandCheckerURL;
		public static unsafe string CometOnDemandCheckerURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCometOnDemandCheckerURL' and count(parameter)=0]"
			[Register ("getCometOnDemandCheckerURL", "()Ljava/lang/String;", "GetGetCometOnDemandCheckerURLHandler")]
			get {
				if (id_getCometOnDemandCheckerURL == IntPtr.Zero)
					id_getCometOnDemandCheckerURL = JNIEnv.GetStaticMethodID (class_ref, "getCometOnDemandCheckerURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCometOnDemandCheckerURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCrWriteBoardURL;
		public static unsafe string CrWriteBoardURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCrWriteBoardURL' and count(parameter)=0]"
			[Register ("getCrWriteBoardURL", "()Ljava/lang/String;", "GetGetCrWriteBoardURLHandler")]
			get {
				if (id_getCrWriteBoardURL == IntPtr.Zero)
					id_getCrWriteBoardURL = JNIEnv.GetStaticMethodID (class_ref, "getCrWriteBoardURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCrWriteBoardURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getCreateChatroomURL;
		public static unsafe string CreateChatroomURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getCreateChatroomURL' and count(parameter)=0]"
			[Register ("getCreateChatroomURL", "()Ljava/lang/String;", "GetGetCreateChatroomURLHandler")]
			get {
				if (id_getCreateChatroomURL == IntPtr.Zero)
					id_getCreateChatroomURL = JNIEnv.GetStaticMethodID (class_ref, "getCreateChatroomURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCreateChatroomURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getDeleteChatroomURL;
		public static unsafe string DeleteChatroomURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getDeleteChatroomURL' and count(parameter)=0]"
			[Register ("getDeleteChatroomURL", "()Ljava/lang/String;", "GetGetDeleteChatroomURLHandler")]
			get {
				if (id_getDeleteChatroomURL == IntPtr.Zero)
					id_getDeleteChatroomURL = JNIEnv.GetStaticMethodID (class_ref, "getDeleteChatroomURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDeleteChatroomURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getFileUploadURL;
		public static unsafe string FileUploadURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getFileUploadURL' and count(parameter)=0]"
			[Register ("getFileUploadURL", "()Ljava/lang/String;", "GetGetFileUploadURLHandler")]
			get {
				if (id_getFileUploadURL == IntPtr.Zero)
					id_getFileUploadURL = JNIEnv.GetStaticMethodID (class_ref, "getFileUploadURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getFileUploadURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getGoogleTranslateURL;
		public static unsafe string GoogleTranslateURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getGoogleTranslateURL' and count(parameter)=0]"
			[Register ("getGoogleTranslateURL", "()Ljava/lang/String;", "GetGetGoogleTranslateURLHandler")]
			get {
				if (id_getGoogleTranslateURL == IntPtr.Zero)
					id_getGoogleTranslateURL = JNIEnv.GetStaticMethodID (class_ref, "getGoogleTranslateURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getGoogleTranslateURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getHandwriteURL;
		public static unsafe string HandwriteURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getHandwriteURL' and count(parameter)=0]"
			[Register ("getHandwriteURL", "()Ljava/lang/String;", "GetGetHandwriteURLHandler")]
			get {
				if (id_getHandwriteURL == IntPtr.Zero)
					id_getHandwriteURL = JNIEnv.GetStaticMethodID (class_ref, "getHandwriteURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getHandwriteURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getInfoFromId;
		public static unsafe string InfoFromId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getInfoFromId' and count(parameter)=0]"
			[Register ("getInfoFromId", "()Ljava/lang/String;", "GetGetInfoFromIdHandler")]
			get {
				if (id_getInfoFromId == IntPtr.Zero)
					id_getInfoFromId = JNIEnv.GetStaticMethodID (class_ref, "getInfoFromId", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInfoFromId), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getJsonPhpURL;
		public static unsafe string JsonPhpURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getJsonPhpURL' and count(parameter)=0]"
			[Register ("getJsonPhpURL", "()Ljava/lang/String;", "GetGetJsonPhpURLHandler")]
			get {
				if (id_getJsonPhpURL == IntPtr.Zero)
					id_getJsonPhpURL = JNIEnv.GetStaticMethodID (class_ref, "getJsonPhpURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getJsonPhpURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getKickUserURL;
		public static unsafe string KickUserURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getKickUserURL' and count(parameter)=0]"
			[Register ("getKickUserURL", "()Ljava/lang/String;", "GetGetKickUserURLHandler")]
			get {
				if (id_getKickUserURL == IntPtr.Zero)
					id_getKickUserURL = JNIEnv.GetStaticMethodID (class_ref, "getKickUserURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getKickUserURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getLastSeenSettingRequestURL;
		public static unsafe string LastSeenSettingRequestURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getLastSeenSettingRequestURL' and count(parameter)=0]"
			[Register ("getLastSeenSettingRequestURL", "()Ljava/lang/String;", "GetGetLastSeenSettingRequestURLHandler")]
			get {
				if (id_getLastSeenSettingRequestURL == IntPtr.Zero)
					id_getLastSeenSettingRequestURL = JNIEnv.GetStaticMethodID (class_ref, "getLastSeenSettingRequestURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getLastSeenSettingRequestURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getLoginURL;
		public static unsafe string LoginURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getLoginURL' and count(parameter)=0]"
			[Register ("getLoginURL", "()Ljava/lang/String;", "GetGetLoginURLHandler")]
			get {
				if (id_getLoginURL == IntPtr.Zero)
					id_getLoginURL = JNIEnv.GetStaticMethodID (class_ref, "getLoginURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getLoginURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getLogoutURL;
		public static unsafe string LogoutURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getLogoutURL' and count(parameter)=0]"
			[Register ("getLogoutURL", "()Ljava/lang/String;", "GetGetLogoutURLHandler")]
			get {
				if (id_getLogoutURL == IntPtr.Zero)
					id_getLogoutURL = JNIEnv.GetStaticMethodID (class_ref, "getLogoutURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getLogoutURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getPhoneRegisterURL;
		public static unsafe string PhoneRegisterURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getPhoneRegisterURL' and count(parameter)=0]"
			[Register ("getPhoneRegisterURL", "()Ljava/lang/String;", "GetGetPhoneRegisterURLHandler")]
			get {
				if (id_getPhoneRegisterURL == IntPtr.Zero)
					id_getPhoneRegisterURL = JNIEnv.GetStaticMethodID (class_ref, "getPhoneRegisterURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getPhoneRegisterURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getRecieveURL;
		public static unsafe string RecieveURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getRecieveURL' and count(parameter)=0]"
			[Register ("getRecieveURL", "()Ljava/lang/String;", "GetGetRecieveURLHandler")]
			get {
				if (id_getRecieveURL == IntPtr.Zero)
					id_getRecieveURL = JNIEnv.GetStaticMethodID (class_ref, "getRecieveURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRecieveURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getRenameChatroomUrl;
		public static unsafe string RenameChatroomUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getRenameChatroomUrl' and count(parameter)=0]"
			[Register ("getRenameChatroomUrl", "()Ljava/lang/String;", "GetGetRenameChatroomUrlHandler")]
			get {
				if (id_getRenameChatroomUrl == IntPtr.Zero)
					id_getRenameChatroomUrl = JNIEnv.GetStaticMethodID (class_ref, "getRenameChatroomUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRenameChatroomUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getReportConversationURL;
		public static unsafe string ReportConversationURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getReportConversationURL' and count(parameter)=0]"
			[Register ("getReportConversationURL", "()Ljava/lang/String;", "GetGetReportConversationURLHandler")]
			get {
				if (id_getReportConversationURL == IntPtr.Zero)
					id_getReportConversationURL = JNIEnv.GetStaticMethodID (class_ref, "getReportConversationURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getReportConversationURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSendChatroomMessageURL;
		public static unsafe string SendChatroomMessageURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getSendChatroomMessageURL' and count(parameter)=0]"
			[Register ("getSendChatroomMessageURL", "()Ljava/lang/String;", "GetGetSendChatroomMessageURLHandler")]
			get {
				if (id_getSendChatroomMessageURL == IntPtr.Zero)
					id_getSendChatroomMessageURL = JNIEnv.GetStaticMethodID (class_ref, "getSendChatroomMessageURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSendChatroomMessageURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSendOneToOneMessageURL;
		public static unsafe string SendOneToOneMessageURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getSendOneToOneMessageURL' and count(parameter)=0]"
			[Register ("getSendOneToOneMessageURL", "()Ljava/lang/String;", "GetGetSendOneToOneMessageURLHandler")]
			get {
				if (id_getSendOneToOneMessageURL == IntPtr.Zero)
					id_getSendOneToOneMessageURL = JNIEnv.GetStaticMethodID (class_ref, "getSendOneToOneMessageURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSendOneToOneMessageURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSendStickerURL;
		public static unsafe string SendStickerURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getSendStickerURL' and count(parameter)=0]"
			[Register ("getSendStickerURL", "()Ljava/lang/String;", "GetGetSendStickerURLHandler")]
			get {
				if (id_getSendStickerURL == IntPtr.Zero)
					id_getSendStickerURL = JNIEnv.GetStaticMethodID (class_ref, "getSendStickerURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSendStickerURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSinglePlayerGameURL;
		public static unsafe string SinglePlayerGameURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getSinglePlayerGameURL' and count(parameter)=0]"
			[Register ("getSinglePlayerGameURL", "()Ljava/lang/String;", "GetGetSinglePlayerGameURLHandler")]
			get {
				if (id_getSinglePlayerGameURL == IntPtr.Zero)
					id_getSinglePlayerGameURL = JNIEnv.GetStaticMethodID (class_ref, "getSinglePlayerGameURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSinglePlayerGameURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getUnblockUserURL;
		public static unsafe string UnblockUserURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getUnblockUserURL' and count(parameter)=0]"
			[Register ("getUnblockUserURL", "()Ljava/lang/String;", "GetGetUnblockUserURLHandler")]
			get {
				if (id_getUnblockUserURL == IntPtr.Zero)
					id_getUnblockUserURL = JNIEnv.GetStaticMethodID (class_ref, "getUnblockUserURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getUnblockUserURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWebsiteHostURL;
		public static unsafe string WebsiteHostURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWebsiteHostURL' and count(parameter)=0]"
			[Register ("getWebsiteHostURL", "()Ljava/lang/String;", "GetGetWebsiteHostURLHandler")]
			get {
				if (id_getWebsiteHostURL == IntPtr.Zero)
					id_getWebsiteHostURL = JNIEnv.GetStaticMethodID (class_ref, "getWebsiteHostURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWebsiteHostURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWebsiteURL;
		public static unsafe string WebsiteURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWebsiteURL' and count(parameter)=0]"
			[Register ("getWebsiteURL", "()Ljava/lang/String;", "GetGetWebsiteURLHandler")]
			get {
				if (id_getWebsiteURL == IntPtr.Zero)
					id_getWebsiteURL = JNIEnv.GetStaticMethodID (class_ref, "getWebsiteURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWebsiteURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWhiteBoardURL;
		public static unsafe string WhiteBoardURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWhiteBoardURL' and count(parameter)=0]"
			[Register ("getWhiteBoardURL", "()Ljava/lang/String;", "GetGetWhiteBoardURLHandler")]
			get {
				if (id_getWhiteBoardURL == IntPtr.Zero)
					id_getWhiteBoardURL = JNIEnv.GetStaticMethodID (class_ref, "getWhiteBoardURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWhiteBoardURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWriteBoardConnectURL;
		public static unsafe string WriteBoardConnectURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWriteBoardConnectURL' and count(parameter)=0]"
			[Register ("getWriteBoardConnectURL", "()Ljava/lang/String;", "GetGetWriteBoardConnectURLHandler")]
			get {
				if (id_getWriteBoardConnectURL == IntPtr.Zero)
					id_getWriteBoardConnectURL = JNIEnv.GetStaticMethodID (class_ref, "getWriteBoardConnectURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWriteBoardConnectURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWriteBoardURL;
		public static unsafe string WriteBoardURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWriteBoardURL' and count(parameter)=0]"
			[Register ("getWriteBoardURL", "()Ljava/lang/String;", "GetGetWriteBoardURLHandler")]
			get {
				if (id_getWriteBoardURL == IntPtr.Zero)
					id_getWriteBoardURL = JNIEnv.GetStaticMethodID (class_ref, "getWriteBoardURL", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWriteBoardURL), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getWriteboardRequestUrl;
		public static unsafe string WriteboardRequestUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='getWriteboardRequestUrl' and count(parameter)=0]"
			[Register ("getWriteboardRequestUrl", "()Ljava/lang/String;", "GetGetWriteboardRequestUrlHandler")]
			get {
				if (id_getWriteboardRequestUrl == IntPtr.Zero)
					id_getWriteboardRequestUrl = JNIEnv.GetStaticMethodID (class_ref, "getWriteboardRequestUrl", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getWriteboardRequestUrl), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_buildBaseCodUrl;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.factories']/class[@name='URLFactory']/method[@name='buildBaseCodUrl' and count(parameter)=0]"
		[Register ("buildBaseCodUrl", "()V", "")]
		public static unsafe void BuildBaseCodUrl ()
		{
			if (id_buildBaseCodUrl == IntPtr.Zero)
				id_buildBaseCodUrl = JNIEnv.GetStaticMethodID (class_ref, "buildBaseCodUrl", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_buildBaseCodUrl);
			} finally {
			}
		}

	}
}
