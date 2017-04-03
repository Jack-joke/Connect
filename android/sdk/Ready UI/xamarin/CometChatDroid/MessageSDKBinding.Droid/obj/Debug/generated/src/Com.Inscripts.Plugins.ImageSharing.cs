using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/ImageSharing", DoNotGenerateAcw=true)]
	public partial class ImageSharing : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/ImageSharing", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ImageSharing); }
		}

		protected ImageSharing (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/constructor[@name='ImageSharing' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ImageSharing ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ImageSharing)) {
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
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='isCrDisabled' and count(parameter)=0]"
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
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='isDisabled' and count(parameter)=0]"
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

		static IntPtr id_getImageBitmap_Landroid_net_Uri_Landroid_app_Activity_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='getImageBitmap' and count(parameter)=2 and parameter[1][@type='android.net.Uri'] and parameter[2][@type='android.app.Activity']]"
		[Register ("getImageBitmap", "(Landroid/net/Uri;Landroid/app/Activity;)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap GetImageBitmap (global::Android.Net.Uri p0, global::Android.App.Activity p1)
		{
			if (id_getImageBitmap_Landroid_net_Uri_Landroid_app_Activity_ == IntPtr.Zero)
				id_getImageBitmap_Landroid_net_Uri_Landroid_app_Activity_ = JNIEnv.GetStaticMethodID (class_ref, "getImageBitmap", "(Landroid/net/Uri;Landroid/app/Activity;)Landroid/graphics/Bitmap;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getImageBitmap_Landroid_net_Uri_Landroid_app_Activity_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getImageURL_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='getImageURL' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getImageURL", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public static unsafe string GetImageURL (string p0)
		{
			if (id_getImageURL_Ljava_lang_String_ == IntPtr.Zero)
				id_getImageURL_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getImageURL", "(Ljava/lang/String;)Ljava/lang/String;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getImageURL_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getOutputMediaFileUri_IZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='getOutputMediaFileUri' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='boolean']]"
		[Register ("getOutputMediaFileUri", "(IZ)Landroid/net/Uri;", "")]
		public static unsafe global::Android.Net.Uri GetOutputMediaFileUri (int p0, bool p1)
		{
			if (id_getOutputMediaFileUri_IZ == IntPtr.Zero)
				id_getOutputMediaFileUri_IZ = JNIEnv.GetStaticMethodID (class_ref, "getOutputMediaFileUri", "(IZ)Landroid/net/Uri;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getOutputMediaFileUri_IZ, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_isFileTransfer_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='isFileTransfer' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isFileTransfer", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsFileTransfer (string p0)
		{
			if (id_isFileTransfer_Ljava_lang_String_ == IntPtr.Zero)
				id_isFileTransfer_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isFileTransfer", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isFileTransfer_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isIncomingChatroomImage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='isIncomingChatroomImage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isIncomingChatroomImage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsIncomingChatroomImage (string p0)
		{
			if (id_isIncomingChatroomImage_Ljava_lang_String_ == IntPtr.Zero)
				id_isIncomingChatroomImage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isIncomingChatroomImage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isIncomingChatroomImage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_isIncomingImage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='isIncomingImage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("isIncomingImage", "(Ljava/lang/String;)Z", "")]
		public static unsafe bool IsIncomingImage (string p0)
		{
			if (id_isIncomingImage_Ljava_lang_String_ == IntPtr.Zero)
				id_isIncomingImage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "isIncomingImage", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_isIncomingImage_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr, IntPtr>) n_SendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_);
			return cb_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2, IntPtr native_p3, IntPtr native_p4)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p0 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString (native_p3, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p4 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p4, JniHandleOwnership.DoNotTransfer);
			__this.SendImageAjax (p0, p1, p2, p3, p4);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageAjax' and count(parameter)=5 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImageAjax", "(Landroid/graphics/Bitmap;Ljava/lang/String;ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "GetSendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImageAjax (global::Android.Graphics.Bitmap p0, string p1, bool p2, string p3, global::Com.Inscripts.Interfaces.ICallbacks p4)
		{
			if (id_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImageAjax", "(Landroid/graphics/Bitmap;Ljava/lang/String;ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (p4);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageAjax_Landroid_graphics_Bitmap_Ljava_lang_String_ZLjava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageAjax", "(Landroid/graphics/Bitmap;Ljava/lang/String;ZLjava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static Delegate cb_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetSendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == null)
				cb_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_SendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_);
			return cb_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		}

		static void n_SendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p0 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p3 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.SendImageAjax (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageAjax' and count(parameter)=4 and parameter[1][@type='java.io.File'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("sendImageAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V", "GetSendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void SendImageAjax (global::Java.IO.File p0, string p1, bool p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "sendImageAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageAjax_Ljava_io_File_Ljava_lang_String_ZLcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageAjax", "(Ljava/io/File;Ljava/lang/String;ZLcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J;
#pragma warning disable 0169
		static Delegate GetSendImageChatroom_Landroid_content_Context_Landroid_content_Intent_JHandler ()
		{
			if (cb_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J == null)
				cb_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, long>) n_SendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J);
			return cb_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J;
		}

		static void n_SendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, long p2)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Intent p1 = global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SendImageChatroom (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageChatroom' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.content.Intent'] and parameter[3][@type='long']]"
		[Register ("sendImageChatroom", "(Landroid/content/Context;Landroid/content/Intent;J)V", "GetSendImageChatroom_Landroid_content_Context_Landroid_content_Intent_JHandler")]
		public virtual unsafe void SendImageChatroom (global::Android.Content.Context p0, global::Android.Content.Intent p1, long p2)
		{
			if (id_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J == IntPtr.Zero)
				id_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J = JNIEnv.GetMethodID (class_ref, "sendImageChatroom", "(Landroid/content/Context;Landroid/content/Intent;J)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageChatroom_Landroid_content_Context_Landroid_content_Intent_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageChatroom", "(Landroid/content/Context;Landroid/content/Intent;J)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_Handler ()
		{
			if (cb_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ == null)
				cb_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_);
			return cb_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
		}

		static void n_SendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p1 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImageChatroom (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageChatroom' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.net.Uri'] and parameter[3][@type='java.lang.Long']]"
		[Register ("sendImageChatroom", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V", "GetSendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_Handler")]
		public virtual unsafe void SendImageChatroom (global::Android.Content.Context p0, global::Android.Net.Uri p1, global::Java.Lang.Long p2)
		{
			if (id_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ == IntPtr.Zero)
				id_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "sendImageChatroom", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageChatroom_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageChatroom", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
#pragma warning disable 0169
		static Delegate GetSendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_JHandler ()
		{
			if (cb_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J == null)
				cb_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, long>) n_SendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J);
			return cb_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
		}

		static void n_SendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, long p3)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p2 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImageChatroom (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageChatroom' and count(parameter)=4 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.graphics.Bitmap'] and parameter[4][@type='long']]"
		[Register ("sendImageChatroom", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V", "GetSendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_JHandler")]
		public virtual unsafe void SendImageChatroom (global::Android.Content.Context p0, string p1, global::Android.Graphics.Bitmap p2, long p3)
		{
			if (id_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J == IntPtr.Zero)
				id_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J = JNIEnv.GetMethodID (class_ref, "sendImageChatroom", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageChatroom_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageChatroom", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_Handler ()
		{
			if (cb_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_ == null)
				cb_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_);
			return cb_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_;
		}

		static void n_SendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Intent p1 = global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImageOneOnOne (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageOneOnOne' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.content.Intent'] and parameter[3][@type='java.lang.Long']]"
		[Register ("sendImageOneOnOne", "(Landroid/content/Context;Landroid/content/Intent;Ljava/lang/Long;)V", "GetSendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_Handler")]
		public virtual unsafe void SendImageOneOnOne (global::Android.Content.Context p0, global::Android.Content.Intent p1, global::Java.Lang.Long p2)
		{
			if (id_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_ == IntPtr.Zero)
				id_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "sendImageOneOnOne", "(Landroid/content/Context;Landroid/content/Intent;Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageOneOnOne_Landroid_content_Context_Landroid_content_Intent_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageOneOnOne", "(Landroid/content/Context;Landroid/content/Intent;Ljava/lang/Long;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_Handler ()
		{
			if (cb_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ == null)
				cb_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_SendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_);
			return cb_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
		}

		static void n_SendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Net.Uri p1 = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImageOneOnOne (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageOneOnOne' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.net.Uri'] and parameter[3][@type='java.lang.Long']]"
		[Register ("sendImageOneOnOne", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V", "GetSendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_Handler")]
		public virtual unsafe void SendImageOneOnOne (global::Android.Content.Context p0, global::Android.Net.Uri p1, global::Java.Lang.Long p2)
		{
			if (id_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ == IntPtr.Zero)
				id_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "sendImageOneOnOne", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageOneOnOne_Landroid_content_Context_Landroid_net_Uri_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageOneOnOne", "(Landroid/content/Context;Landroid/net/Uri;Ljava/lang/Long;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
#pragma warning disable 0169
		static Delegate GetSendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_JHandler ()
		{
			if (cb_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J == null)
				cb_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, long>) n_SendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J);
			return cb_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
		}

		static void n_SendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, long p3)
		{
			global::Com.Inscripts.Plugins.ImageSharing __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Plugins.ImageSharing> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Bitmap p2 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.SendImageOneOnOne (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='sendImageOneOnOne' and count(parameter)=4 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.graphics.Bitmap'] and parameter[4][@type='long']]"
		[Register ("sendImageOneOnOne", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V", "GetSendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_JHandler")]
		public virtual unsafe void SendImageOneOnOne (global::Android.Content.Context p0, string p1, global::Android.Graphics.Bitmap p2, long p3)
		{
			if (id_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J == IntPtr.Zero)
				id_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J = JNIEnv.GetMethodID (class_ref, "sendImageOneOnOne", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageOneOnOne_Landroid_content_Context_Ljava_lang_String_Landroid_graphics_Bitmap_J, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageOneOnOne", "(Landroid/content/Context;Ljava/lang/String;Landroid/graphics/Bitmap;J)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToTempImageAndGetPathUri_Landroid_content_Context_Landroid_graphics_Bitmap_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='ImageSharing']/method[@name='writeToTempImageAndGetPathUri' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.graphics.Bitmap']]"
		[Register ("writeToTempImageAndGetPathUri", "(Landroid/content/Context;Landroid/graphics/Bitmap;)Landroid/net/Uri;", "")]
		public static unsafe global::Android.Net.Uri WriteToTempImageAndGetPathUri (global::Android.Content.Context p0, global::Android.Graphics.Bitmap p1)
		{
			if (id_writeToTempImageAndGetPathUri_Landroid_content_Context_Landroid_graphics_Bitmap_ == IntPtr.Zero)
				id_writeToTempImageAndGetPathUri_Landroid_content_Context_Landroid_graphics_Bitmap_ = JNIEnv.GetStaticMethodID (class_ref, "writeToTempImageAndGetPathUri", "(Landroid/content/Context;Landroid/graphics/Bitmap;)Landroid/net/Uri;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Android.Net.Uri __ret = global::Java.Lang.Object.GetObject<global::Android.Net.Uri> (JNIEnv.CallStaticObjectMethod  (class_ref, id_writeToTempImageAndGetPathUri_Landroid_content_Context_Landroid_graphics_Bitmap_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
