using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='Callbacks']"
	[Register ("com/inscripts/interfaces/Callbacks", "", "Com.Inscripts.Interfaces.ICallbacksInvoker")]
	public partial interface ICallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='Callbacks']/method[@name='failCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("failCallback", "(Lorg/json/JSONObject;)V", "GetFailCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ICallbacksInvoker, MessageSDKBinding.Droid")]
		void FailCallback (global::Org.Json.JSONObject p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='Callbacks']/method[@name='successCallback' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("successCallback", "(Lorg/json/JSONObject;)V", "GetSuccessCallback_Lorg_json_JSONObject_Handler:Com.Inscripts.Interfaces.ICallbacksInvoker, MessageSDKBinding.Droid")]
		void SuccessCallback (global::Org.Json.JSONObject p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/Callbacks", DoNotGenerateAcw=true)]
	internal class ICallbacksInvoker : global::Java.Lang.Object, ICallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/Callbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ICallbacksInvoker); }
		}

		IntPtr class_ref;

		public static ICallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ICallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.Callbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ICallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_failCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetFailCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_failCallback_Lorg_json_JSONObject_ == null)
				cb_failCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_FailCallback_Lorg_json_JSONObject_);
			return cb_failCallback_Lorg_json_JSONObject_;
		}

		static void n_FailCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ICallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FailCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_failCallback_Lorg_json_JSONObject_;
		public unsafe void FailCallback (global::Org.Json.JSONObject p0)
		{
			if (id_failCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_failCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "failCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_failCallback_Lorg_json_JSONObject_, __args);
		}

		static Delegate cb_successCallback_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetSuccessCallback_Lorg_json_JSONObject_Handler ()
		{
			if (cb_successCallback_Lorg_json_JSONObject_ == null)
				cb_successCallback_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SuccessCallback_Lorg_json_JSONObject_);
			return cb_successCallback_Lorg_json_JSONObject_;
		}

		static void n_SuccessCallback_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ICallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SuccessCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_successCallback_Lorg_json_JSONObject_;
		public unsafe void SuccessCallback (global::Org.Json.JSONObject p0)
		{
			if (id_successCallback_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_successCallback_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "successCallback", "(Lorg/json/JSONObject;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_successCallback_Lorg_json_JSONObject_, __args);
		}

	}

}
