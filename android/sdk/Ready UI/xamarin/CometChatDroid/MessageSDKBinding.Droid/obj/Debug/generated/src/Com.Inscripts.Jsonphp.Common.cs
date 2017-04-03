using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Common']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Common", DoNotGenerateAcw=true)]
	public partial class Common : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Common", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Common); }
		}

		protected Common (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Common']/constructor[@name='Common' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Common ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Common)) {
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

		static Delegate cb_getCompleteAction;
#pragma warning disable 0169
		static Delegate GetGetCompleteActionHandler ()
		{
			if (cb_getCompleteAction == null)
				cb_getCompleteAction = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCompleteAction);
			return cb_getCompleteAction;
		}

		static IntPtr n_GetCompleteAction (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Common __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CompleteAction);
		}
#pragma warning restore 0169

		static IntPtr id_getCompleteAction;
		public virtual unsafe string CompleteAction {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Common']/method[@name='getCompleteAction' and count(parameter)=0]"
			[Register ("getCompleteAction", "()Ljava/lang/String;", "GetGetCompleteActionHandler")]
			get {
				if (id_getCompleteAction == IntPtr.Zero)
					id_getCompleteAction = JNIEnv.GetMethodID (class_ref, "getCompleteAction", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCompleteAction), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCompleteAction", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInappNotificationMessage;
#pragma warning disable 0169
		static Delegate GetGetInappNotificationMessageHandler ()
		{
			if (cb_getInappNotificationMessage == null)
				cb_getInappNotificationMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInappNotificationMessage);
			return cb_getInappNotificationMessage;
		}

		static IntPtr n_GetInappNotificationMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Common __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InappNotificationMessage);
		}
#pragma warning restore 0169

		static IntPtr id_getInappNotificationMessage;
		public virtual unsafe string InappNotificationMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Common']/method[@name='getInappNotificationMessage' and count(parameter)=0]"
			[Register ("getInappNotificationMessage", "()Ljava/lang/String;", "GetGetInappNotificationMessageHandler")]
			get {
				if (id_getInappNotificationMessage == IntPtr.Zero)
					id_getInappNotificationMessage = JNIEnv.GetMethodID (class_ref, "getInappNotificationMessage", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInappNotificationMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInappNotificationMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSet;
#pragma warning disable 0169
		static Delegate GetGetSetHandler ()
		{
			if (cb_getSet == null)
				cb_getSet = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSet);
			return cb_getSet;
		}

		static IntPtr n_GetSet (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Common __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Set);
		}
#pragma warning restore 0169

		static IntPtr id_getSet;
		public virtual unsafe string Set {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Common']/method[@name='getSet' and count(parameter)=0]"
			[Register ("getSet", "()Ljava/lang/String;", "GetGetSetHandler")]
			get {
				if (id_getSet == IntPtr.Zero)
					id_getSet = JNIEnv.GetMethodID (class_ref, "getSet", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSet), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSet", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
