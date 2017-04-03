using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']"
	[global::Android.Runtime.Register ("com/inscripts/custom/ConfirmationWindow", DoNotGenerateAcw=true)]
	public partial class ConfirmationWindow : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/ConfirmationWindow", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ConfirmationWindow); }
		}

		protected ConfirmationWindow (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/constructor[@name='ConfirmationWindow' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe ConfirmationWindow (global::Android.Content.Context p0, string p1, string p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				if (GetType () != typeof (ConfirmationWindow)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static Delegate cb_setCancelable_Z;
#pragma warning disable 0169
		static Delegate GetSetCancelable_ZHandler ()
		{
			if (cb_setCancelable_Z == null)
				cb_setCancelable_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetCancelable_Z);
			return cb_setCancelable_Z;
		}

		static void n_SetCancelable_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.ConfirmationWindow __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.ConfirmationWindow> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetCancelable (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setCancelable_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/method[@name='setCancelable' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setCancelable", "(Z)V", "GetSetCancelable_ZHandler")]
		public virtual unsafe void SetCancelable (bool p0)
		{
			if (id_setCancelable_Z == IntPtr.Zero)
				id_setCancelable_Z = JNIEnv.GetMethodID (class_ref, "setCancelable", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCancelable_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCancelable", "(Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setMessage_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetMessage_Ljava_lang_String_Handler ()
		{
			if (cb_setMessage_Ljava_lang_String_ == null)
				cb_setMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_SetMessage_Ljava_lang_String_);
			return cb_setMessage_Ljava_lang_String_;
		}

		static IntPtr n_SetMessage_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.ConfirmationWindow __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.ConfirmationWindow> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.SetMessage (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_setMessage_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/method[@name='setMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setMessage", "(Ljava/lang/String;)Landroid/app/AlertDialog$Builder;", "GetSetMessage_Ljava_lang_String_Handler")]
		public virtual unsafe global::Android.App.AlertDialog.Builder SetMessage (string p0)
		{
			if (id_setMessage_Ljava_lang_String_ == IntPtr.Zero)
				id_setMessage_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setMessage", "(Ljava/lang/String;)Landroid/app/AlertDialog$Builder;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Android.App.AlertDialog.Builder __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.App.AlertDialog.Builder> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_setMessage_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.App.AlertDialog.Builder> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMessage", "(Ljava/lang/String;)Landroid/app/AlertDialog$Builder;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setNegativeResponse;
#pragma warning disable 0169
		static Delegate GetSetNegativeResponseHandler ()
		{
			if (cb_setNegativeResponse == null)
				cb_setNegativeResponse = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetNegativeResponse);
			return cb_setNegativeResponse;
		}

		static void n_SetNegativeResponse (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.ConfirmationWindow __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.ConfirmationWindow> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetNegativeResponse ();
		}
#pragma warning restore 0169

		static IntPtr id_setNegativeResponse;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/method[@name='setNegativeResponse' and count(parameter)=0]"
		[Register ("setNegativeResponse", "()V", "GetSetNegativeResponseHandler")]
		protected virtual unsafe void SetNegativeResponse ()
		{
			if (id_setNegativeResponse == IntPtr.Zero)
				id_setNegativeResponse = JNIEnv.GetMethodID (class_ref, "setNegativeResponse", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setNegativeResponse);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setNegativeResponse", "()V"));
			} finally {
			}
		}

		static Delegate cb_setPositiveResponse;
#pragma warning disable 0169
		static Delegate GetSetPositiveResponseHandler ()
		{
			if (cb_setPositiveResponse == null)
				cb_setPositiveResponse = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetPositiveResponse);
			return cb_setPositiveResponse;
		}

		static void n_SetPositiveResponse (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.ConfirmationWindow __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.ConfirmationWindow> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetPositiveResponse ();
		}
#pragma warning restore 0169

		static IntPtr id_setPositiveResponse;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/method[@name='setPositiveResponse' and count(parameter)=0]"
		[Register ("setPositiveResponse", "()V", "GetSetPositiveResponseHandler")]
		protected virtual unsafe void SetPositiveResponse ()
		{
			if (id_setPositiveResponse == IntPtr.Zero)
				id_setPositiveResponse = JNIEnv.GetMethodID (class_ref, "setPositiveResponse", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPositiveResponse);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPositiveResponse", "()V"));
			} finally {
			}
		}

		static Delegate cb_show;
#pragma warning disable 0169
		static Delegate GetShowHandler ()
		{
			if (cb_show == null)
				cb_show = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Show);
			return cb_show;
		}

		static void n_Show (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.ConfirmationWindow __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.ConfirmationWindow> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Show ();
		}
#pragma warning restore 0169

		static IntPtr id_show;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='ConfirmationWindow']/method[@name='show' and count(parameter)=0]"
		[Register ("show", "()V", "GetShowHandler")]
		public virtual unsafe void Show ()
		{
			if (id_show == IntPtr.Zero)
				id_show = JNIEnv.GetMethodID (class_ref, "show", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_show);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "show", "()V"));
			} finally {
			}
		}

	}
}
