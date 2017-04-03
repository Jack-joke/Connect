using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='CustomJavaScriptInterface']"
	[Register ("com/inscripts/interfaces/CustomJavaScriptInterface", "", "Com.Inscripts.Interfaces.ICustomJavaScriptInterfaceInvoker")]
	public partial interface ICustomJavaScriptInterface : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='CustomJavaScriptInterface']/method[@name='sendToMobile' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("sendToMobile", "(Ljava/lang/String;)V", "GetSendToMobile_Ljava_lang_String_Handler:Com.Inscripts.Interfaces.ICustomJavaScriptInterfaceInvoker, MessageSDKBinding.Droid")]
		void SendToMobile (string p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/CustomJavaScriptInterface", DoNotGenerateAcw=true)]
	internal class ICustomJavaScriptInterfaceInvoker : global::Java.Lang.Object, ICustomJavaScriptInterface {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/CustomJavaScriptInterface");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ICustomJavaScriptInterfaceInvoker); }
		}

		IntPtr class_ref;

		public static ICustomJavaScriptInterface GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<ICustomJavaScriptInterface> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.CustomJavaScriptInterface"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public ICustomJavaScriptInterfaceInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_sendToMobile_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSendToMobile_Ljava_lang_String_Handler ()
		{
			if (cb_sendToMobile_Ljava_lang_String_ == null)
				cb_sendToMobile_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SendToMobile_Ljava_lang_String_);
			return cb_sendToMobile_Ljava_lang_String_;
		}

		static void n_SendToMobile_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.ICustomJavaScriptInterface __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICustomJavaScriptInterface> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SendToMobile (p0);
		}
#pragma warning restore 0169

		IntPtr id_sendToMobile_Ljava_lang_String_;
		public unsafe void SendToMobile (string p0)
		{
			if (id_sendToMobile_Ljava_lang_String_ == IntPtr.Zero)
				id_sendToMobile_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "sendToMobile", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendToMobile_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

	}

}
