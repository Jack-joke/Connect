using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Transports {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']"
	[global::Android.Runtime.Register ("com/inscripts/transports/CometserviceOneOnOne", DoNotGenerateAcw=true)]
	public partial class CometserviceOneOnOne : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/transports/CometserviceOneOnOne", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometserviceOneOnOne); }
		}

		protected CometserviceOneOnOne (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/constructor[@name='CometserviceOneOnOne' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CometserviceOneOnOne ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CometserviceOneOnOne)) {
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
		public static unsafe global::Com.Inscripts.Transports.CometserviceOneOnOne Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/transports/CometserviceOneOnOne;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/transports/CometserviceOneOnOne;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceOneOnOne> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_sendMessage_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='sendMessage' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("sendMessage", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public static unsafe void SendMessage (string p0, string p1)
		{
			if (id_sendMessage_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_sendMessage_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "sendMessage", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendMessage_Ljava_lang_String_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_sendMessage_Ljava_lang_String_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='sendMessage' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='org.json.JSONObject']]"
		[Register ("sendMessage", "(Ljava/lang/String;Lorg/json/JSONObject;)V", "")]
		public static unsafe void SendMessage (string p0, global::Org.Json.JSONObject p1)
		{
			if (id_sendMessage_Ljava_lang_String_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_sendMessage_Ljava_lang_String_Lorg_json_JSONObject_ = JNIEnv.GetStaticMethodID (class_ref, "sendMessage", "(Ljava/lang/String;Lorg/json/JSONObject;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_sendMessage_Ljava_lang_String_Lorg_json_JSONObject_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_startCometService_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetStartCometService_Ljava_lang_String_Handler ()
		{
			if (cb_startCometService_Ljava_lang_String_ == null)
				cb_startCometService_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_StartCometService_Ljava_lang_String_);
			return cb_startCometService_Ljava_lang_String_;
		}

		static void n_StartCometService_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Transports.CometserviceOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StartCometService (p0);
		}
#pragma warning restore 0169

		static IntPtr id_startCometService_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='startCometService' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("startCometService", "(Ljava/lang/String;)V", "GetStartCometService_Ljava_lang_String_Handler")]
		public virtual unsafe void StartCometService (string p0)
		{
			if (id_startCometService_Ljava_lang_String_ == IntPtr.Zero)
				id_startCometService_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "startCometService", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startCometService_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startCometService", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_;
#pragma warning disable 0169
		static Delegate GetStartCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_Handler ()
		{
			if (cb_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ == null)
				cb_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_StartCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_);
			return cb_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_;
		}

		static void n_StartCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Transports.CometserviceOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.StartCometService (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='startCometService' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.SubscribeCallbacks']]"
		[Register ("startCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeCallbacks;)V", "GetStartCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_Handler")]
		public virtual unsafe void StartCometService (string p0, global::Com.Inscripts.Interfaces.ISubscribeCallbacks p1)
		{
			if (id_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ == IntPtr.Zero)
				id_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_ = JNIEnv.GetMethodID (class_ref, "startCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeCallbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeCallbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeCallbacks;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_unSubscribe;
#pragma warning disable 0169
		static Delegate GetUnSubscribeHandler ()
		{
			if (cb_unSubscribe == null)
				cb_unSubscribe = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_UnSubscribe);
			return cb_unSubscribe;
		}

		static void n_UnSubscribe (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Transports.CometserviceOneOnOne __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceOneOnOne> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.UnSubscribe ();
		}
#pragma warning restore 0169

		static IntPtr id_unSubscribe;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceOneOnOne']/method[@name='unSubscribe' and count(parameter)=0]"
		[Register ("unSubscribe", "()V", "GetUnSubscribeHandler")]
		public virtual unsafe void UnSubscribe ()
		{
			if (id_unSubscribe == IntPtr.Zero)
				id_unSubscribe = JNIEnv.GetMethodID (class_ref, "unSubscribe", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_unSubscribe);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "unSubscribe", "()V"));
			} finally {
			}
		}

	}
}
