using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='CometchatCallbacks']"
	[Register ("com/inscripts/interfaces/CometchatCallbacks", "", "Com.Inscripts.Interfaces.ICometchatCallbacksInvoker")]
	public partial interface ICometchatCallbacks : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='CometchatCallbacks']/method[@name='failCallback' and count(parameter)=0]"
		[Register ("failCallback", "()V", "GetFailCallbackHandler:Com.Inscripts.Interfaces.ICometchatCallbacksInvoker, MessageSDKBinding.Droid")]
		void FailCallback ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='CometchatCallbacks']/method[@name='successCallback' and count(parameter)=0]"
		[Register ("successCallback", "()V", "GetSuccessCallbackHandler:Com.Inscripts.Interfaces.ICometchatCallbacksInvoker, MessageSDKBinding.Droid")]
		void SuccessCallback ();

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/CometchatCallbacks", DoNotGenerateAcw=true)]
	internal class ICometchatCallbacksInvoker : global::Java.Lang.Object, ICometchatCallbacks {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/CometchatCallbacks");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ICometchatCallbacksInvoker); }
		}

		IntPtr class_ref;

		public static ICometchatCallbacks GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ICometchatCallbacks> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.CometchatCallbacks"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ICometchatCallbacksInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_failCallback;
#pragma warning disable 0169
		static Delegate GetFailCallbackHandler ()
		{
			if (cb_failCallback == null)
				cb_failCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_FailCallback);
			return cb_failCallback;
		}

		static void n_FailCallback (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Interfaces.ICometchatCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICometchatCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.FailCallback ();
		}
#pragma warning restore 0169

		IntPtr id_failCallback;
		public unsafe void FailCallback ()
		{
			if (id_failCallback == IntPtr.Zero)
				id_failCallback = JNIEnv.GetMethodID (class_ref, "failCallback", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_failCallback);
		}

		static Delegate cb_successCallback;
#pragma warning disable 0169
		static Delegate GetSuccessCallbackHandler ()
		{
			if (cb_successCallback == null)
				cb_successCallback = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SuccessCallback);
			return cb_successCallback;
		}

		static void n_SuccessCallback (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Interfaces.ICometchatCallbacks __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICometchatCallbacks> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SuccessCallback ();
		}
#pragma warning restore 0169

		IntPtr id_successCallback;
		public unsafe void SuccessCallback ()
		{
			if (id_successCallback == IntPtr.Zero)
				id_successCallback = JNIEnv.GetMethodID (class_ref, "successCallback", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_successCallback);
		}

	}

}
