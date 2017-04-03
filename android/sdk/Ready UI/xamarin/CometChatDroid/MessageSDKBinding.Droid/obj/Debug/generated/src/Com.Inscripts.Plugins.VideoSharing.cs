using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/VideoSharing", DoNotGenerateAcw=true)]
	public partial class VideoSharing : global::Java.Lang.Object {


		static IntPtr CHATROOM_VIDEO_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/field[@name='CHATROOM_VIDEO']"
		[Register ("CHATROOM_VIDEO")]
		public static string ChatroomVideo {
			get {
				if (CHATROOM_VIDEO_jfieldId == IntPtr.Zero)
					CHATROOM_VIDEO_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "CHATROOM_VIDEO", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, CHATROOM_VIDEO_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (CHATROOM_VIDEO_jfieldId == IntPtr.Zero)
					CHATROOM_VIDEO_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "CHATROOM_VIDEO", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetStaticField (class_ref, CHATROOM_VIDEO_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr ONE_ON_ONE_VIDEO_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/field[@name='ONE_ON_ONE_VIDEO']"
		[Register ("ONE_ON_ONE_VIDEO")]
		public static string OneOnOneVideo {
			get {
				if (ONE_ON_ONE_VIDEO_jfieldId == IntPtr.Zero)
					ONE_ON_ONE_VIDEO_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "ONE_ON_ONE_VIDEO", "Ljava/lang/String;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, ONE_ON_ONE_VIDEO_jfieldId);
				return JNIEnv.GetString (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (ONE_ON_ONE_VIDEO_jfieldId == IntPtr.Zero)
					ONE_ON_ONE_VIDEO_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "ONE_ON_ONE_VIDEO", "Ljava/lang/String;");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JNIEnv.SetStaticField (class_ref, ONE_ON_ONE_VIDEO_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/VideoSharing", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (VideoSharing); }
		}

		protected VideoSharing (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/constructor[@name='VideoSharing' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe VideoSharing ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (VideoSharing)) {
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

		static IntPtr id_isCrDisabled;
		public static unsafe bool IsCrDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='isCrDisabled' and count(parameter)=0]"
			[Register ("isCrDisabled", "()Z", "GetIsCrDisabledHandler")]
			get {
				if (id_isCrDisabled == IntPtr.Zero)
					id_isCrDisabled = JNIEnv.GetStaticMethodID (class_ref, "isCrDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCrDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_isDisabled;
		public static unsafe bool IsDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='isDisabled' and count(parameter)=0]"
			[Register ("isDisabled", "()Z", "GetIsDisabledHandler")]
			get {
				if (id_isDisabled == IntPtr.Zero)
					id_isDisabled = JNIEnv.GetStaticMethodID (class_ref, "isDisabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isDisabled);
				} finally {
				}
			}
		}

		static IntPtr id_downloadAndStoreVideo_Ljava_lang_String_Ljava_lang_String_ZZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='downloadAndStoreVideo' and count(parameter)=4 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean'] and parameter[4][@type='boolean']]"
		[Register ("downloadAndStoreVideo", "(Ljava/lang/String;Ljava/lang/String;ZZ)V", "")]
		public static unsafe void DownloadAndStoreVideo (string p0, string p1, bool p2, bool p3)
		{
			if (id_downloadAndStoreVideo_Ljava_lang_String_Ljava_lang_String_ZZ == IntPtr.Zero)
				id_downloadAndStoreVideo_Ljava_lang_String_Ljava_lang_String_ZZ = JNIEnv.GetStaticMethodID (class_ref, "downloadAndStoreVideo", "(Ljava/lang/String;Ljava/lang/String;ZZ)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_downloadAndStoreVideo_Ljava_lang_String_Ljava_lang_String_ZZ, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_getVideoBitmap_Landroid_net_Uri_Landroid_app_Activity_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='getVideoBitmap' and count(parameter)=2 and parameter[1][@type='android.net.Uri'] and parameter[2][@type='android.app.Activity']]"
		[Register ("getVideoBitmap", "(Landroid/net/Uri;Landroid/app/Activity;)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap GetVideoBitmap (global::Android.Net.Uri p0, global::Android.App.Activity p1)
		{
			if (id_getVideoBitmap_Landroid_net_Uri_Landroid_app_Activity_ == IntPtr.Zero)
				id_getVideoBitmap_Landroid_net_Uri_Landroid_app_Activity_ = JNIEnv.GetStaticMethodID (class_ref, "getVideoBitmap", "(Landroid/net/Uri;Landroid/app/Activity;)Landroid/graphics/Bitmap;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getVideoBitmap_Landroid_net_Uri_Landroid_app_Activity_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getVideoURL_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='getVideoURL' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getVideoURL", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetVideoURL (string p0)
		{
			if (id_getVideoURL_Ljava_lang_String_ == IntPtr.Zero)
				id_getVideoURL_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getVideoURL", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getVideoURL_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isIncomingChatroomVideo_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='isIncomingChatroomVideo' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isIncomingChatroomVideo", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsIncomingChatroomVideo (string p0)
		{
			if (id_isIncomingChatroomVideo_Ljava_lang_String_ == IntPtr.Zero)
				id_isIncomingChatroomVideo_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isIncomingChatroomVideo", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isIncomingChatroomVideo_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isIncomingVideo_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='isIncomingVideo' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isIncomingVideo", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsIncomingVideo (string p0)
		{
			if (id_isIncomingVideo_Ljava_lang_String_ == IntPtr.Zero)
				id_isIncomingVideo_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isIncomingVideo", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isIncomingVideo_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_SendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_);
			return cb_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Plugins.VideoSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.VideoSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.SendVideoAjax (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='sendVideoAjax' and count(parameter)=4 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendVideoAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V", "GetSendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendVideoAjax (global::Java.IO.File p0, string p1, bool p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendVideoAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendVideoAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendVideoAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_sendVideoChatroom_Landroid_app_Activity_Landroid_content_Intent_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='sendVideoChatroom' and count(parameter)=3 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='android.content.Intent'] and parameter[3][@type='long']]"
		[Register ("sendVideoChatroom", "(Landroid/app/Activity;Landroid/content/Intent;J)V", "")]
		public static unsafe void SendVideoChatroom (global::Android.App.Activity p0, global::Android.Content.Intent p1, long p2)
		{
			if (id_sendVideoChatroom_Landroid_app_Activity_Landroid_content_Intent_J == IntPtr.Zero)
				id_sendVideoChatroom_Landroid_app_Activity_Landroid_content_Intent_J = JNIEnv.GetStaticMethodID (class_ref, "sendVideoChatroom", "(Landroid/app/Activity;Landroid/content/Intent;J)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendVideoChatroom_Landroid_app_Activity_Landroid_content_Intent_J, __args);
			} finally {
			}
		}

		static IntPtr id_sendVideoChatroom_Landroid_app_Activity_Ljava_lang_String_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='sendVideoChatroom' and count(parameter)=3 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='long']]"
		[Register ("sendVideoChatroom", "(Landroid/app/Activity;Ljava/lang/String;J)V", "")]
		public static unsafe void SendVideoChatroom (global::Android.App.Activity p0, string p1, long p2)
		{
			if (id_sendVideoChatroom_Landroid_app_Activity_Ljava_lang_String_J == IntPtr.Zero)
				id_sendVideoChatroom_Landroid_app_Activity_Ljava_lang_String_J = JNIEnv.GetStaticMethodID (class_ref, "sendVideoChatroom", "(Landroid/app/Activity;Ljava/lang/String;J)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendVideoChatroom_Landroid_app_Activity_Ljava_lang_String_J, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_sendVideoOneOnOne_Landroid_app_Activity_Landroid_content_Intent_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='sendVideoOneOnOne' and count(parameter)=3 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='android.content.Intent'] and parameter[3][@type='long']]"
		[Register ("sendVideoOneOnOne", "(Landroid/app/Activity;Landroid/content/Intent;J)V", "")]
		public static unsafe void SendVideoOneOnOne (global::Android.App.Activity p0, global::Android.Content.Intent p1, long p2)
		{
			if (id_sendVideoOneOnOne_Landroid_app_Activity_Landroid_content_Intent_J == IntPtr.Zero)
				id_sendVideoOneOnOne_Landroid_app_Activity_Landroid_content_Intent_J = JNIEnv.GetStaticMethodID (class_ref, "sendVideoOneOnOne", "(Landroid/app/Activity;Landroid/content/Intent;J)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendVideoOneOnOne_Landroid_app_Activity_Landroid_content_Intent_J, __args);
			} finally {
			}
		}

		static IntPtr id_sendVideoOneOnOne_Landroid_app_Activity_Ljava_lang_String_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='VideoSharing']/method[@name='sendVideoOneOnOne' and count(parameter)=3 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='long']]"
		[Register ("sendVideoOneOnOne", "(Landroid/app/Activity;Ljava/lang/String;J)V", "")]
		public static unsafe void SendVideoOneOnOne (global::Android.App.Activity p0, string p1, long p2)
		{
			if (id_sendVideoOneOnOne_Landroid_app_Activity_Ljava_lang_String_J == IntPtr.Zero)
				id_sendVideoOneOnOne_Landroid_app_Activity_Ljava_lang_String_J = JNIEnv.GetStaticMethodID (class_ref, "sendVideoOneOnOne", "(Landroid/app/Activity;Ljava/lang/String;J)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendVideoOneOnOne_Landroid_app_Activity_Ljava_lang_String_J, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
