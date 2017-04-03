using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/ImageUploadHelper", DoNotGenerateAcw=true)]
	public partial class ImageUploadHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/ImageUploadHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ImageUploadHelper); }
		}

		protected ImageUploadHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_os_Handler_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/constructor[@name='ImageUploadHelper' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.os.Handler']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Handler;)V", "")]
		public unsafe ImageUploadHelper (global::Android.Content.Context p0, string p1, global::Android.OS.Handler p2)
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
				if (GetType () != typeof (ImageUploadHelper)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Handler;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Handler;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_os_Handler_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_os_Handler_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;Landroid/os/Handler;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_os_Handler_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_os_Handler_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_addFile_Ljava_lang_String_Ljava_io_File_;
#pragma warning disable 0169
		static Delegate GetAddFile_Ljava_lang_String_Ljava_io_File_Handler ()
		{
			if (cb_addFile_Ljava_lang_String_Ljava_io_File_ == null)
				cb_addFile_Ljava_lang_String_Ljava_io_File_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AddFile_Ljava_lang_String_Ljava_io_File_);
			return cb_addFile_Ljava_lang_String_Ljava_io_File_;
		}

		static void n_AddFile_Ljava_lang_String_Ljava_io_File_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.IO.File p1 = global::Java.Lang.Object.GetObject<global::Java.IO.File> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddFile (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addFile_Ljava_lang_String_Ljava_io_File_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='addFile' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.io.File']]"
		[Register ("addFile", "(Ljava/lang/String;Ljava/io/File;)V", "GetAddFile_Ljava_lang_String_Ljava_io_File_Handler")]
		public virtual unsafe void AddFile (string p0, global::Java.IO.File p1)
		{
			if (id_addFile_Ljava_lang_String_Ljava_io_File_ == IntPtr.Zero)
				id_addFile_Ljava_lang_String_Ljava_io_File_ = JNIEnv.GetMethodID (class_ref, "addFile", "(Ljava/lang/String;Ljava/io/File;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addFile_Ljava_lang_String_Ljava_io_File_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addFile", "(Ljava/lang/String;Ljava/io/File;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Integer p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Integer']]"
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
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Long']]"
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
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddNameValuePair (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_addNameValuePair_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='addNameValuePair' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
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
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Boolean p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Boolean> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SendCallBack (p0);
		}
#pragma warning restore 0169

		static IntPtr id_sendCallBack_Ljava_lang_Boolean_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='sendCallBack' and count(parameter)=1 and parameter[1][@type='java.lang.Boolean']]"
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

		static Delegate cb_sendImageAjax;
#pragma warning disable 0169
		static Delegate GetSendImageAjaxHandler ()
		{
			if (cb_sendImageAjax == null)
				cb_sendImageAjax = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SendImageAjax);
			return cb_sendImageAjax;
		}

		static void n_SendImageAjax (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Helpers.ImageUploadHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Helpers.ImageUploadHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SendImageAjax ();
		}
#pragma warning restore 0169

		static IntPtr id_sendImageAjax;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='ImageUploadHelper']/method[@name='sendImageAjax' and count(parameter)=0]"
		[Register ("sendImageAjax", "()V", "GetSendImageAjaxHandler")]
		public virtual unsafe void SendImageAjax ()
		{
			if (id_sendImageAjax == IntPtr.Zero)
				id_sendImageAjax = JNIEnv.GetMethodID (class_ref, "sendImageAjax", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_sendImageAjax);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "sendImageAjax", "()V"));
			} finally {
			}
		}

	}
}
