using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/VolleyHelper", DoNotGenerateAcw=true)]
	public partial class VolleyHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/VolleyHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (VolleyHelper); }
		}

		protected VolleyHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/constructor[@name='VolleyHelper' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='com.inscripts.interfaces.VolleyAjaxCallbacks']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", "")]
		public unsafe VolleyHelper (global::Android.Content.Context p0, string p1, global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (VolleyHelper)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;Lcom/inscripts/interfaces/VolleyAjaxCallbacks;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Lcom_inscripts_interfaces_VolleyAjaxCallbacks_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_lang_String_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/constructor[@name='VolleyHelper' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/lang/String;)V", "")]
		public unsafe VolleyHelper (global::Android.Content.Context p0, string p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (VolleyHelper)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/lang/String;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/lang/String;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_lang_String_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_;
#pragma warning disable 0169
		static Delegate GetAddNameValuePair_Ljava_lang_String_Ljava_lang_Integer_Handler ()
		{
			if (cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_ == null)
				cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddNameValuePair_Ljava_lang_String_Ljava_lang_Integer_);
			return cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_;
		}

		static void n_AddNameValuePair_Ljava_lang_String_Ljava_lang_Integer_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Integer p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Integer']]"
		[Register ("addNameValuePair", "(Ljava/lang/String;Ljava/lang/Integer;)V", "GetAddNameValuePair_Ljava_lang_String_Ljava_lang_Integer_Handler")]
		public virtual unsafe void AddNameValuePair (string p0, global::Java.Lang.Integer p1)
		{
			if (id_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_ == IntPtr.Zero)
				id_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_ = JNIEnv.GetMethodID (class_ref, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/Integer;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/Integer;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetAddNameValuePair_Ljava_lang_String_Ljava_lang_Long_Handler ()
		{
			if (cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_ == null)
				cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddNameValuePair_Ljava_lang_String_Ljava_lang_Long_);
			return cb_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_;
		}

		static void n_AddNameValuePair_Ljava_lang_String_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Long']]"
		[Register ("addNameValuePair", "(Ljava/lang/String;Ljava/lang/Long;)V", "GetAddNameValuePair_Ljava_lang_String_Ljava_lang_Long_Handler")]
		public virtual unsafe void AddNameValuePair (string p0, global::Java.Lang.Long p1)
		{
			if (id_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_ == IntPtr.Zero)
				id_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/Long;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/Long;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_addNameValuePair_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetAddNameValuePair_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_addNameValuePair_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_addNameValuePair_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddNameValuePair_Ljava_lang_String_Ljava_lang_String_);
			return cb_addNameValuePair_Ljava_lang_String_Ljava_lang_String_;
		}

		static void n_AddNameValuePair_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("addNameValuePair", "(Ljava/lang/String;Ljava/lang/String;)V", "GetAddNameValuePair_Ljava_lang_String_Ljava_lang_String_Handler")]
		public virtual unsafe void AddNameValuePair (string p0, string p1)
		{
			if (id_addNameValuePair_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_addNameValuePair_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addNameValuePair_Ljava_lang_String_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addNameValuePair", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_sendAjax;
#pragma warning disable 0169
		static Delegate GetSendAjaxHandler ()
		{
			if (cb_sendAjax == null)
				cb_sendAjax = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SendAjax);
			return cb_sendAjax;
		}

		static void n_SendAjax (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SendAjax ();
		}
#pragma warning restore 0169

		static IntPtr id_sendAjax;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='sendAjax' and count(parameter)=0]"
		[Register ("sendAjax", "()V", "GetSendAjaxHandler")]
		public virtual unsafe void SendAjax ()
		{
			if (id_sendAjax == IntPtr.Zero)
				id_sendAjax = JNIEnv.GetMethodID (class_ref, "sendAjax", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendAjax);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendAjax", "()V"));
			} finally {
			}
		}

		static Delegate cb_sendCallBack_Ljava_lang_Boolean_;
#pragma warning disable 0169
		static Delegate GetSendCallBack_Ljava_lang_Boolean_Handler ()
		{
			if (cb_sendCallBack_Ljava_lang_Boolean_ == null)
				cb_sendCallBack_Ljava_lang_Boolean_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SendCallBack_Ljava_lang_Boolean_);
			return cb_sendCallBack_Ljava_lang_Boolean_;
		}

		static void n_SendCallBack_Ljava_lang_Boolean_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SendCallBack (p0);
		}
#pragma warning restore 0169

		static IntPtr id_sendCallBack_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='sendCallBack' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
		[Register ("sendCallBack", "(Ljava/lang/Boolean;)V", "GetSendCallBack_Ljava_lang_Boolean_Handler")]
		public virtual unsafe void SendCallBack (global::Java.Lang.Boolean p0)
		{
			if (id_sendCallBack_Ljava_lang_Boolean_ == IntPtr.Zero)
				id_sendCallBack_Ljava_lang_Boolean_ = JNIEnv.GetMethodID (class_ref, "sendCallBack", "(Ljava/lang/Boolean;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendCallBack_Ljava_lang_Boolean_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendCallBack", "(Ljava/lang/Boolean;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setRequestType_I;
#pragma warning disable 0169
		static Delegate GetSetRequestType_IHandler ()
		{
			if (cb_setRequestType_I == null)
				cb_setRequestType_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetRequestType_I);
			return cb_setRequestType_I;
		}

		static void n_SetRequestType_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Helpers.VolleyHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.VolleyHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetRequestType (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setRequestType_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='VolleyHelper']/method[@name='setRequestType' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setRequestType", "(I)V", "GetSetRequestType_IHandler")]
		public virtual unsafe void SetRequestType (int p0)
		{
			if (id_setRequestType_I == IntPtr.Zero)
				id_setRequestType_I = JNIEnv.GetMethodID (class_ref, "setRequestType", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRequestType_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setRequestType", "(I)V"), __args);
			} finally {
			}
		}

	}
}
