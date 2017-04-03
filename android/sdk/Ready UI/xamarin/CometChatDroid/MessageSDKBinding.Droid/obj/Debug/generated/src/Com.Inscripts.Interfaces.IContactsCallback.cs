using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='ContactsCallback']"
	[Register ("com/inscripts/interfaces/ContactsCallback", "", "Com.Inscripts.Interfaces.IContactsCallbackInvoker")]
	public partial interface IContactsCallback : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='ContactsCallback']/method[@name='failCallback' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("failCallback", "(Ljava/lang/String;)V", "GetFailCallback_Ljava_lang_String_Handler:Com.Inscripts.Interfaces.IContactsCallbackInvoker, MessageSDKBinding.Droid")]
		void FailCallback (string p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='ContactsCallback']/method[@name='successCallback' and count(parameter)=1 and parameter[1][@type='java.util.ArrayList&lt;com.inscripts.pojos.ContactPojo&gt;']]"
		[Register ("successCallback", "(Ljava/util/ArrayList;)V", "GetSuccessCallback_Ljava_util_ArrayList_Handler:Com.Inscripts.Interfaces.IContactsCallbackInvoker, MessageSDKBinding.Droid")]
		void SuccessCallback (global::System.Collections.Generic.IList<global::Com.Inscripts.Pojos.ContactPojo> p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/ContactsCallback", DoNotGenerateAcw=true)]
	internal class IContactsCallbackInvoker : global::Java.Lang.Object, IContactsCallback {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/ContactsCallback");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IContactsCallbackInvoker); }
		}

		IntPtr class_ref;

		public static IContactsCallback GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IContactsCallback> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.ContactsCallback"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IContactsCallbackInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_failCallback_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetFailCallback_Ljava_lang_String_Handler ()
		{
			if (cb_failCallback_Ljava_lang_String_ == null)
				cb_failCallback_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_FailCallback_Ljava_lang_String_);
			return cb_failCallback_Ljava_lang_String_;
		}

		static void n_FailCallback_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.IContactsCallback __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IContactsCallback> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FailCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_failCallback_Ljava_lang_String_;
		public unsafe void FailCallback (string p0)
		{
			if (id_failCallback_Ljava_lang_String_ == IntPtr.Zero)
				id_failCallback_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "failCallback", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_failCallback_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate cb_successCallback_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetSuccessCallback_Ljava_util_ArrayList_Handler ()
		{
			if (cb_successCallback_Ljava_util_ArrayList_ == null)
				cb_successCallback_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SuccessCallback_Ljava_util_ArrayList_);
			return cb_successCallback_Ljava_util_ArrayList_;
		}

		static void n_SuccessCallback_Ljava_util_ArrayList_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Interfaces.IContactsCallback __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IContactsCallback> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var p0 = global::Android.Runtime.JavaList<global::Com.Inscripts.Pojos.ContactPojo>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SuccessCallback (p0);
		}
#pragma warning restore 0169

		IntPtr id_successCallback_Ljava_util_ArrayList_;
		public unsafe void SuccessCallback (global::System.Collections.Generic.IList<global::Com.Inscripts.Pojos.ContactPojo> p0)
		{
			if (id_successCallback_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_successCallback_Ljava_util_ArrayList_ = JNIEnv.GetMethodID (class_ref, "successCallback", "(Ljava/util/ArrayList;)V");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::Com.Inscripts.Pojos.ContactPojo>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_successCallback_Ljava_util_ArrayList_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

	}

}
