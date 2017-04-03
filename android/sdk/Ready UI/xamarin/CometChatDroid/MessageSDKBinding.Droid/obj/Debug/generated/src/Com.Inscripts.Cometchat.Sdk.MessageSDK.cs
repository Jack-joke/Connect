using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/MessageSDK", DoNotGenerateAcw=true)]
	public partial class MessageSDK : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/MessageSDK", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MessageSDK); }
		}

		protected MessageSDK (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/constructor[@name='MessageSDK' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe MessageSDK ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (MessageSDK)) {
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

		static IntPtr id_initializeCometChat_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='initializeCometChat' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("initializeCometChat", "(Landroid/content/Context;)V", "")]
		public static unsafe void InitializeCometChat (global::Android.Content.Context p0)
		{
			if (id_initializeCometChat_Landroid_content_Context_ == IntPtr.Zero)
				id_initializeCometChat_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "initializeCometChat", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_initializeCometChat_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static IntPtr id_launchChatWindow_ZLandroid_app_Activity_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='launchChatWindow' and count(parameter)=4 and parameter[1][@type='boolean'] and parameter[2][@type='android.app.Activity'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("launchChatWindow", "(ZLandroid/app/Activity;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "")]
		public static unsafe void LaunchChatWindow (bool p0, global::Android.App.Activity p1, string p2, global::Com.Inscripts.Interfaces.ICallbacks p3)
		{
			if (id_launchChatWindow_ZLandroid_app_Activity_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_launchChatWindow_ZLandroid_app_Activity_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetStaticMethodID (class_ref, "launchChatWindow", "(ZLandroid/app/Activity;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_launchChatWindow_ZLandroid_app_Activity_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_launchCometChat_Landroid_app_Activity_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='launchCometChat' and count(parameter)=2 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("launchCometChat", "(Landroid/app/Activity;Lcom/inscripts/interfaces/Callbacks;)V", "")]
		public static unsafe void LaunchCometChat (global::Android.App.Activity p0, global::Com.Inscripts.Interfaces.ICallbacks p1)
		{
			if (id_launchCometChat_Landroid_app_Activity_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_launchCometChat_Landroid_app_Activity_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetStaticMethodID (class_ref, "launchCometChat", "(Landroid/app/Activity;Lcom/inscripts/interfaces/Callbacks;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_launchCometChat_Landroid_app_Activity_Lcom_inscripts_interfaces_Callbacks_, __args);
			} finally {
			}
		}

		static IntPtr id_login_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='login' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.LoginCallbacks']]"
		[Register ("login", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;)V", "")]
		public static unsafe void Login (global::Android.Content.Context p0, string p1, global::Com.Inscripts.Interfaces.ILoginCallbacks p2)
		{
			if (id_login_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_ == IntPtr.Zero)
				id_login_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "login", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_login_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_login_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='login' and count(parameter)=4 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='com.inscripts.interfaces.LoginCallbacks']]"
		[Register ("login", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;)V", "")]
		public static unsafe void Login (global::Android.Content.Context p0, string p1, string p2, global::Com.Inscripts.Interfaces.ILoginCallbacks p3)
		{
			if (id_login_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_ == IntPtr.Zero)
				id_login_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "login", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/LoginCallbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_login_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_LoginCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_setLanguage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='setLanguage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setLanguage", "(Ljava/lang/String;)V", "")]
		public static unsafe void SetLanguage (string p0)
		{
			if (id_setLanguage_Ljava_lang_String_ == IntPtr.Zero)
				id_setLanguage_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "setLanguage", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setLanguage_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_setUrl_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='MessageSDK']/method[@name='setUrl' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("setUrl", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V", "")]
		public static unsafe void SetUrl (global::Android.Content.Context p0, string p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_setUrl_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_setUrl_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetStaticMethodID (class_ref, "setUrl", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setUrl_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_Callbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
