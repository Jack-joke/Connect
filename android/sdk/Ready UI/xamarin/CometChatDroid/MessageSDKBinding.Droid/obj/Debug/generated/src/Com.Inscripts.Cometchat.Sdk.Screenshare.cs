using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Cometchat.Sdk {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='Screenshare']"
	[global::Android.Runtime.Register ("com/inscripts/cometchat/sdk/Screenshare", DoNotGenerateAcw=true)]
	public partial class Screenshare : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/cometchat/sdk/Screenshare", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Screenshare); }
		}

		protected Screenshare (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_getScreenshareInstance_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='Screenshare']/method[@name='getScreenshareInstance' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getScreenshareInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/Screenshare;", "")]
		public static unsafe global::Com.Inscripts.Cometchat.Sdk.Screenshare GetScreenshareInstance (global::Android.Content.Context p0)
		{
			if (id_getScreenshareInstance_Landroid_content_Context_ == IntPtr.Zero)
				id_getScreenshareInstance_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getScreenshareInstance", "(Landroid/content/Context;)Lcom/inscripts/cometchat/sdk/Screenshare;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Inscripts.Cometchat.Sdk.Screenshare __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.Screenshare> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getScreenshareInstance_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_StartScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Cometchat.Sdk.Screenshare __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Cometchat.Sdk.Screenshare> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.RelativeLayout p1 = global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.StartScreenShare (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.cometchat.sdk']/class[@name='Screenshare']/method[@name='startScreenShare' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.widget.RelativeLayout'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startScreenShare", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartScreenShare (string p0, global::Android.Widget.RelativeLayout p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startScreenShare", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startScreenShare_Ljava_lang_String_Landroid_widget_RelativeLayout_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startScreenShare", "(Ljava/lang/String;Landroid/widget/RelativeLayout;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
