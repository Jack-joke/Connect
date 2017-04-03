using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='VolleyAjaxCallbacks']"
	[Register ("com/inscripts/interfaces/VolleyAjaxCallbacks", "", "Com.Inscripts.Interfaces.IVolleyAjaxCallbacksInvoker")]
	public partial interface IVolleyAjaxCallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='VolleyAjaxCallbacks']/method[@name='failCallback' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("failCallback", "(Ljava/lang/String;Z)V", "GetFailCallback_Ljava_lang_String_ZHandler:Com.Inscripts.Interfaces.IVolleyAjaxCallbacksInvoker, MessageSDKBinding.Droid")]
		void FailCallback (string p0, bool p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='VolleyAjaxCallbacks']/method[@name='successCallback' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("successCallback", "(Ljava/lang/String;)V", "GetSuccessCallback_Ljava_lang_String_Handler:Com.Inscripts.Interfaces.IVolleyAjaxCallbacksInvoker, MessageSDKBinding.Droid")]
		void SuccessCallback (string p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/VolleyAjaxCallbacks", DoNotGenerateAcw=true)]
	internal class IVolleyAjaxCallbacksInvoker : global::Java.Lang.Object, IVolleyAjaxCallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/VolleyAjaxCallbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IVolleyAjaxCallbacksInvoker); }
		}

		IntPtr class_ref;

		public static IVolleyAjaxCallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IVolleyAjaxCallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.VolleyAjaxCallbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IVolleyAjaxCallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_failCallback_Ljava_lang_String_Z;
#pragma warning disable 0169
		static Delegate GetFailCallback_Ljava_lang_String_ZHandler ()
		{
			if (cb_failCallback_Ljava_lang_String_Z == null)
				cb_failCallback_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_FailCallback_Ljava_lang_String_Z);
			return cb_failCallback_Ljava_lang_String_Z;
		}

		static void n_FailCallback_Ljava_lang_String_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FailCallback (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_failCallback_Ljava_lang_String_Z;
		public unsafe void FailCallback (string p0, bool p1)
		{
			if (id_failCallback_Ljava_lang_String_Z == IntPtr.Zero)
				id_failCallback_Ljava_lang_String_Z = JNIEnv.GetMethodID (class_ref, "failCallback", "(Ljava/lang/String;Z)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_failCallback_Ljava_lang_String_Z, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate cb_successCallback_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSuccessCallback_Ljava_lang_String_Handler ()
		{
			if (cb_successCallback_Ljava_lang_String_ == null)
				cb_successCallback_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SuccessCallback_Ljava_lang_String_);
			return cb_successCallback_Ljava_lang_String_;
		}

		static void n_SuccessCallback_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IVolleyAjaxCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SuccessCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_successCallback_Ljava_lang_String_;
		public unsafe void SuccessCallback (string p0)
		{
			if (id_successCallback_Ljava_lang_String_ == IntPtr.Zero)
				id_successCallback_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "successCallback", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_successCallback_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

	}

}
