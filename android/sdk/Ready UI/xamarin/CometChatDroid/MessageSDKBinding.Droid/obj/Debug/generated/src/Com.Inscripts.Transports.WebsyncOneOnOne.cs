using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Transports {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']"
	[global::Android.Runtime.Register ("com/inscripts/transports/WebsyncOneOnOne", DoNotGenerateAcw=true)]
	public partial class WebsyncOneOnOne : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/transports/WebsyncOneOnOne", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (WebsyncOneOnOne); }
		}

		protected WebsyncOneOnOne (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/constructor[@name='WebsyncOneOnOne' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe WebsyncOneOnOne ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (WebsyncOneOnOne)) {
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

		static IntPtr id_getInstance;
		public static unsafe global::Com.Inscripts.Transports.WebsyncOneOnOne Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/transports/WebsyncOneOnOne;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/transports/WebsyncOneOnOne;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.WebsyncOneOnOne> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_connect_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetConnect_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_connect_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_connect_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Connect_Ljava_lang_String_Ljava_lang_String_);
			return cb_connect_Ljava_lang_String_Ljava_lang_String_;
		}

		static void n_Connect_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Transports.WebsyncOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.WebsyncOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Connect (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_connect_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/method[@name='connect' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("connect", "(Ljava/lang/String;Ljava/lang/String;)V", "GetConnect_Ljava_lang_String_Ljava_lang_String_Handler")]
		public virtual unsafe void Connect (string p0, string p1)
		{
			if (id_connect_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_connect_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "connect", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_connect_Ljava_lang_String_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "connect", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_publish_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetPublish_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_publish_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_publish_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Publish_Ljava_lang_String_Ljava_lang_String_);
			return cb_publish_Ljava_lang_String_Ljava_lang_String_;
		}

		static void n_Publish_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Transports.WebsyncOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.WebsyncOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Publish (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_publish_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/method[@name='publish' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("publish", "(Ljava/lang/String;Ljava/lang/String;)V", "GetPublish_Ljava_lang_String_Ljava_lang_String_Handler")]
		public virtual unsafe void Publish (string p0, string p1)
		{
			if (id_publish_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_publish_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "publish", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_publish_Ljava_lang_String_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "publish", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_subscribe_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSubscribe_Ljava_lang_String_Handler ()
		{
			if (cb_subscribe_Ljava_lang_String_ == null)
				cb_subscribe_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Subscribe_Ljava_lang_String_);
			return cb_subscribe_Ljava_lang_String_;
		}

		static void n_Subscribe_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Transports.WebsyncOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.WebsyncOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Subscribe (p0);
		}
#pragma warning restore 0169

		static IntPtr id_subscribe_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/method[@name='subscribe' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("subscribe", "(Ljava/lang/String;)V", "GetSubscribe_Ljava_lang_String_Handler")]
		public virtual unsafe void Subscribe (string p0)
		{
			if (id_subscribe_Ljava_lang_String_ == IntPtr.Zero)
				id_subscribe_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "subscribe", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_subscribe_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "subscribe", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_unsubscribe;
#pragma warning disable 0169
		static Delegate GetUnsubscribeHandler ()
		{
			if (cb_unsubscribe == null)
				cb_unsubscribe = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Unsubscribe);
			return cb_unsubscribe;
		}

		static void n_Unsubscribe (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Transports.WebsyncOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.WebsyncOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Unsubscribe ();
		}
#pragma warning restore 0169

		static IntPtr id_unsubscribe;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='WebsyncOneOnOne']/method[@name='unsubscribe' and count(parameter)=0]"
		[Register ("unsubscribe", "()V", "GetUnsubscribeHandler")]
		public virtual unsafe void Unsubscribe ()
		{
			if (id_unsubscribe == IntPtr.Zero)
				id_unsubscribe = JNIEnv.GetMethodID (class_ref, "unsubscribe", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_unsubscribe);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unsubscribe", "()V"));
			} finally {
			}
		}

	}
}
