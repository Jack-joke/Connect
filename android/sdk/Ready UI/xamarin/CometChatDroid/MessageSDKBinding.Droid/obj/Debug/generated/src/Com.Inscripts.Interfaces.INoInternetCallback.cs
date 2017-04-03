using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='NoInternetCallback']"
	[Register ("com/inscripts/interfaces/NoInternetCallback", "", "Com.Inscripts.Interfaces.INoInternetCallbackInvoker")]
	public partial interface INoInternetCallback : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='NoInternetCallback']/method[@name='noInternet' and count(parameter)=0]"
		[Register ("noInternet", "()V", "GetNoInternetHandler:Com.Inscripts.Interfaces.INoInternetCallbackInvoker, MessageSDKBinding.Droid")]
		void NoInternet ();

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/NoInternetCallback", DoNotGenerateAcw=true)]
	internal class INoInternetCallbackInvoker : global::Java.Lang.Object, INoInternetCallback {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/NoInternetCallback");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (INoInternetCallbackInvoker); }
		}

		IntPtr class_ref;

		public static INoInternetCallback GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<INoInternetCallback> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.NoInternetCallback"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public INoInternetCallbackInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_noInternet;
#pragma warning disable 0169
		static Delegate GetNoInternetHandler ()
		{
			if (cb_noInternet == null)
				cb_noInternet = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_NoInternet);
			return cb_noInternet;
		}

		static void n_NoInternet (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Interfaces.INoInternetCallback __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.INoInternetCallback> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.NoInternet ();
		}
#pragma warning restore 0169

		IntPtr id_noInternet;
		public unsafe void NoInternet ()
		{
			if (id_noInternet == IntPtr.Zero)
				id_noInternet = JNIEnv.GetMethodID (class_ref, "noInternet", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_noInternet);
		}

	}

}
