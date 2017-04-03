using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Transports {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']"
	[global::Android.Runtime.Register ("com/inscripts/transports/CometserviceChatroom", DoNotGenerateAcw=true)]
	public partial class CometserviceChatroom : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/transports/CometserviceChatroom", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometserviceChatroom); }
		}

		protected CometserviceChatroom (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']/constructor[@name='CometserviceChatroom' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CometserviceChatroom ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CometserviceChatroom)) {
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
		public static unsafe global::Com.Inscripts.Transports.CometserviceChatroom Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/transports/CometserviceChatroom;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/transports/CometserviceChatroom;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceChatroom> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_startChatroomCometService_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetStartChatroomCometService_Ljava_lang_Long_Handler ()
		{
			if (cb_startChatroomCometService_Ljava_lang_Long_ == null)
				cb_startChatroomCometService_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_StartChatroomCometService_Ljava_lang_Long_);
			return cb_startChatroomCometService_Ljava_lang_Long_;
		}

		static void n_StartChatroomCometService_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Transports.CometserviceChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StartChatroomCometService (p0);
		}
#pragma warning restore 0169

		static IntPtr id_startChatroomCometService_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']/method[@name='startChatroomCometService' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("startChatroomCometService", "(Ljava/lang/Long;)V", "GetStartChatroomCometService_Ljava_lang_Long_Handler")]
		public virtual unsafe void StartChatroomCometService (global::Java.Lang.Long p0)
		{
			if (id_startChatroomCometService_Ljava_lang_Long_ == IntPtr.Zero)
				id_startChatroomCometService_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "startChatroomCometService", "(Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startChatroomCometService_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startChatroomCometService", "(Ljava/lang/Long;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_;
#pragma warning disable 0169
		static Delegate GetStartChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_Handler ()
		{
			if (cb_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_ == null)
				cb_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_StartChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_);
			return cb_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_;
		}

		static void n_StartChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Transports.CometserviceChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1 = (global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.ICallbacks p2 = (global::Com.Inscripts.Interfaces.ICallbacks)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.ICallbacks> (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.StartChatroomCometService (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']/method[@name='startChatroomCometService' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='com.inscripts.interfaces.SubscribeChatroomCallbacks'] and parameter[3][@type='com.inscripts.interfaces.Callbacks']]"
		[Register ("startChatroomCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Lcom/inscripts/interfaces/Callbacks;)V", "GetStartChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_Handler")]
		public virtual unsafe void StartChatroomCometService (string p0, global::Com.Inscripts.Interfaces.ISubscribeChatroomCallbacks p1, global::Com.Inscripts.Interfaces.ICallbacks p2)
		{
			if (id_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_ == IntPtr.Zero)
				id_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_ = JNIEnv.GetMethodID (class_ref, "startChatroomCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Lcom/inscripts/interfaces/Callbacks;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_startChatroomCometService_Ljava_lang_String_Lcom_inscripts_interfaces_SubscribeChatroomCallbacks_Lcom_inscripts_interfaces_Callbacks_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "startChatroomCometService", "(Ljava/lang/String;Lcom/inscripts/interfaces/SubscribeChatroomCallbacks;Lcom/inscripts/interfaces/Callbacks;)V"), __args);
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
			global::Com.Inscripts.Transports.CometserviceChatroom __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Transports.CometserviceChatroom> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.UnSubscribe ();
		}
#pragma warning restore 0169

		static IntPtr id_unSubscribe;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.transports']/class[@name='CometserviceChatroom']/method[@name='unSubscribe' and count(parameter)=0]"
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
