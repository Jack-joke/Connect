using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/ChatroomManager", DoNotGenerateAcw=true)]
	public partial class ChatroomManager : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/ChatroomManager", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ChatroomManager); }
		}

		protected ChatroomManager (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/constructor[@name='ChatroomManager' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ChatroomManager ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ChatroomManager)) {
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

		static IntPtr id_getTextColor;
		public static unsafe string TextColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='getTextColor' and count(parameter)=0]"
			[Register ("getTextColor", "()Ljava/lang/String;", "GetGetTextColorHandler")]
			get {
				if (id_getTextColor == IntPtr.Zero)
					id_getTextColor = JNIEnv.GetStaticMethodID (class_ref, "getTextColor", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTextColor), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_banUser_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='banUser' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("banUser", "(Ljava/lang/String;)V", "")]
		public static unsafe void BanUser (string p0)
		{
			if (id_banUser_Ljava_lang_String_ == IntPtr.Zero)
				id_banUser_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "banUser", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_banUser_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_deleteChatroom_Landroid_content_Context_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='deleteChatroom' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='long']]"
		[Register ("deleteChatroom", "(Landroid/content/Context;J)V", "")]
		public static unsafe void DeleteChatroom (global::Android.Content.Context p0, long p1)
		{
			if (id_deleteChatroom_Landroid_content_Context_J == IntPtr.Zero)
				id_deleteChatroom_Landroid_content_Context_J = JNIEnv.GetStaticMethodID (class_ref, "deleteChatroom", "(Landroid/content/Context;J)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteChatroom_Landroid_content_Context_J, __args);
			} finally {
			}
		}

		static IntPtr id_getColoredText_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='getColoredText' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("getColoredText", "(Ljava/lang/String;Z)Ljava/lang/String;", "")]
		public static unsafe string GetColoredText (string p0, bool p1)
		{
			if (id_getColoredText_Ljava_lang_String_Z == IntPtr.Zero)
				id_getColoredText_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "getColoredText", "(Ljava/lang/String;Z)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getColoredText_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getMessageId_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='getMessageId' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getMessageId", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetMessageId (string p0)
		{
			if (id_getMessageId_Ljava_lang_String_ == IntPtr.Zero)
				id_getMessageId_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getMessageId", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getMessageId_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isBannedChatroomMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isBannedChatroomMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isBannedChatroomMessage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsBannedChatroomMessage (string p0)
		{
			if (id_isBannedChatroomMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_isBannedChatroomMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isBannedChatroomMessage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isBannedChatroomMessage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isDeleteMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isDeleteMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isDeleteMessage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsDeleteMessage (string p0)
		{
			if (id_isDeleteMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_isDeleteMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isDeleteMessage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isDeleteMessage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isJoinChatroomMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isJoinChatroomMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isJoinChatroomMessage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsJoinChatroomMessage (string p0)
		{
			if (id_isJoinChatroomMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_isJoinChatroomMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isJoinChatroomMessage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isJoinChatroomMessage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isKickedChatroomMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isKickedChatroomMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isKickedChatroomMessage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsKickedChatroomMessage (string p0)
		{
			if (id_isKickedChatroomMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_isKickedChatroomMessage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isKickedChatroomMessage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isKickedChatroomMessage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isMessageDeletedFromChatroom_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isMessageDeletedFromChatroom' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isMessageDeletedFromChatroom", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsMessageDeletedFromChatroom (string p0)
		{
			if (id_isMessageDeletedFromChatroom_Ljava_lang_String_ == IntPtr.Zero)
				id_isMessageDeletedFromChatroom_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isMessageDeletedFromChatroom", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isMessageDeletedFromChatroom_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isSubscribedToChatroom_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='isSubscribedToChatroom' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("isSubscribedToChatroom", "(Ljava/lang/Long;)Z", "")]
		public static unsafe bool IsSubscribedToChatroom (global::Java.Lang.Long p0)
		{
			if (id_isSubscribedToChatroom_Ljava_lang_Long_ == IntPtr.Zero)
				id_isSubscribedToChatroom_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "isSubscribedToChatroom", "(Ljava/lang/Long;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isSubscribedToChatroom_Ljava_lang_Long_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_joinChatroom_JLjava_lang_String_Ljava_lang_String_ILandroid_app_Activity_Lcom_inscripts_interfaces_CometchatCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='joinChatroom' and count(parameter)=6 and parameter[1][@type='long'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='int'] and parameter[5][@type='android.app.Activity'] and parameter[6][@type='com.inscripts.interfaces.CometchatCallbacks']]"
		[Register ("joinChatroom", "(JLjava/lang/String;Ljava/lang/String;ILandroid/app/Activity;Lcom/inscripts/interfaces/CometchatCallbacks;)V", "")]
		public static unsafe void JoinChatroom (long p0, string p1, string p2, int p3, global::Android.App.Activity p4, global::Com.Inscripts.Interfaces.ICometchatCallbacks p5)
		{
			if (id_joinChatroom_JLjava_lang_String_Ljava_lang_String_ILandroid_app_Activity_Lcom_inscripts_interfaces_CometchatCallbacks_ == IntPtr.Zero)
				id_joinChatroom_JLjava_lang_String_Ljava_lang_String_ILandroid_app_Activity_Lcom_inscripts_interfaces_CometchatCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "joinChatroom", "(JLjava/lang/String;Ljava/lang/String;ILandroid/app/Activity;Lcom/inscripts/interfaces/CometchatCallbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_joinChatroom_JLjava_lang_String_Ljava_lang_String_ILandroid_app_Activity_Lcom_inscripts_interfaces_CometchatCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_kickUser_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='kickUser' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("kickUser", "(Ljava/lang/String;)V", "")]
		public static unsafe void KickUser (string p0)
		{
			if (id_kickUser_Ljava_lang_String_ == IntPtr.Zero)
				id_kickUser_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "kickUser", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_kickUser_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_leaveChatroom_Ljava_lang_Long_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='leaveChatroom' and count(parameter)=2 and parameter[1][@type='java.lang.Long'] and parameter[2][@type='java.lang.String']]"
		[Register ("leaveChatroom", "(Ljava/lang/Long;Ljava/lang/String;)V", "")]
		public static unsafe void LeaveChatroom (global::Java.Lang.Long p0, string p1)
		{
			if (id_leaveChatroom_Ljava_lang_Long_Ljava_lang_String_ == IntPtr.Zero)
				id_leaveChatroom_Ljava_lang_Long_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "leaveChatroom", "(Ljava/lang/Long;Ljava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_leaveChatroom_Ljava_lang_Long_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_parseJoinRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='parseJoinRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("parseJoinRequest", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string ParseJoinRequest (string p0)
		{
			if (id_parseJoinRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_parseJoinRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "parseJoinRequest", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_parseJoinRequest_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_processJoinRequest_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='processJoinRequest' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("processJoinRequest", "(Ljava/lang/String;)Lorg/json/JSONObject;", "")]
		public static unsafe global::Org.Json.JSONObject ProcessJoinRequest (string p0)
		{
			if (id_processJoinRequest_Ljava_lang_String_ == IntPtr.Zero)
				id_processJoinRequest_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "processJoinRequest", "(Ljava/lang/String;)Lorg/json/JSONObject;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Org.Json.JSONObject __ret = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (JNIEnv.CallStaticObjectMethod  (class_ref, id_processJoinRequest_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_renameChatroom_Landroid_content_Context_JLjava_lang_String_Lcom_inscripts_models_Chatroom_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='renameChatroom' and count(parameter)=4 and parameter[1][@type='android.content.Context'] and parameter[2][@type='long'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.models.Chatroom']]"
		[Register ("renameChatroom", "(Landroid/content/Context;JLjava/lang/String;Lcom/inscripts/models/Chatroom;)V", "")]
		public static unsafe void RenameChatroom (global::Android.Content.Context p0, long p1, string p2, global::Com.Inscripts.Models.Chatroom p3)
		{
			if (id_renameChatroom_Landroid_content_Context_JLjava_lang_String_Lcom_inscripts_models_Chatroom_ == IntPtr.Zero)
				id_renameChatroom_Landroid_content_Context_JLjava_lang_String_Lcom_inscripts_models_Chatroom_ = JNIEnv.GetStaticMethodID (class_ref, "renameChatroom", "(Landroid/content/Context;JLjava/lang/String;Lcom/inscripts/models/Chatroom;)V");
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_renameChatroom_Landroid_content_Context_JLjava_lang_String_Lcom_inscripts_models_Chatroom_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_startChatroomActivity_JLjava_lang_String_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ChatroomManager']/method[@name='startChatroomActivity' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.content.Context']]"
		[Register ("startChatroomActivity", "(JLjava/lang/String;Landroid/content/Context;)V", "")]
		public static unsafe void StartChatroomActivity (long p0, string p1, global::Android.Content.Context p2)
		{
			if (id_startChatroomActivity_JLjava_lang_String_Landroid_content_Context_ == IntPtr.Zero)
				id_startChatroomActivity_JLjava_lang_String_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "startChatroomActivity", "(JLjava/lang/String;Landroid/content/Context;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_startChatroomActivity_JLjava_lang_String_Landroid_content_Context_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
