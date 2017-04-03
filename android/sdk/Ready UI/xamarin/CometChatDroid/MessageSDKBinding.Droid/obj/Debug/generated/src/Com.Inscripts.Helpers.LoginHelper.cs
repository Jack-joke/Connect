using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LoginHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/LoginHelper", DoNotGenerateAcw=true)]
	public partial class LoginHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/LoginHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LoginHelper); }
		}

		protected LoginHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LoginHelper']/constructor[@name='LoginHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe LoginHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (LoginHelper)) {
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

		static IntPtr id_checkDomain_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LoginHelper']/method[@name='checkDomain' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.VolleyAjaxCallbacks']]"
		[Register ("checkDomain", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", "")]
		public static unsafe void CheckDomain (global::Android.Content.Context p0, string p1, global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks p2)
		{
			if (id_checkDomain_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ == IntPtr.Zero)
				id_checkDomain_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "checkDomain", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_checkDomain_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_checkLoginTypeAndStart_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='LoginHelper']/method[@name='checkLoginTypeAndStart' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("checkLoginTypeAndStart", "(Landroid/content/Context;)V", "")]
		public static unsafe void CheckLoginTypeAndStart (global::Android.Content.Context p0)
		{
			if (id_checkLoginTypeAndStart_Landroid_content_Context_ == IntPtr.Zero)
				id_checkLoginTypeAndStart_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "checkLoginTypeAndStart", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_checkLoginTypeAndStart_Landroid_content_Context_, __args);
			} finally {
			}
		}

	}
}
