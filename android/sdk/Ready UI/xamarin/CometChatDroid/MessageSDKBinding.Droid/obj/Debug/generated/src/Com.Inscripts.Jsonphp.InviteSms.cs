using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/InviteSms", DoNotGenerateAcw=true)]
	public partial class InviteSms : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/InviteSms", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (InviteSms); }
		}

		protected InviteSms (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/constructor[@name='InviteSms' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe InviteSms ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (InviteSms)) {
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

		static Delegate cb_getActionbar;
#pragma warning disable 0169
		static Delegate GetGetActionbarHandler ()
		{
			if (cb_getActionbar == null)
				cb_getActionbar = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetActionbar);
			return cb_getActionbar;
		}

		static IntPtr n_GetActionbar (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Actionbar);
		}
#pragma warning restore 0169

		static IntPtr id_getActionbar;
		public virtual unsafe string Actionbar {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getActionbar' and count(parameter)=0]"
			[Register ("getActionbar", "()Ljava/lang/String;", "GetGetActionbarHandler")]
			get {
				if (id_getActionbar == IntPtr.Zero)
					id_getActionbar = JNIEnv.GetMethodID (class_ref, "getActionbar", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getActionbar), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getActionbar", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCannotSend;
#pragma warning disable 0169
		static Delegate GetGetCannotSendHandler ()
		{
			if (cb_getCannotSend == null)
				cb_getCannotSend = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCannotSend);
			return cb_getCannotSend;
		}

		static IntPtr n_GetCannotSend (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CannotSend);
		}
#pragma warning restore 0169

		static IntPtr id_getCannotSend;
		public virtual unsafe string CannotSend {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getCannotSend' and count(parameter)=0]"
			[Register ("getCannotSend", "()Ljava/lang/String;", "GetGetCannotSendHandler")]
			get {
				if (id_getCannotSend == IntPtr.Zero)
					id_getCannotSend = JNIEnv.GetMethodID (class_ref, "getCannotSend", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCannotSend), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCannotSend", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getContactsHint;
#pragma warning disable 0169
		static Delegate GetGetContactsHintHandler ()
		{
			if (cb_getContactsHint == null)
				cb_getContactsHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetContactsHint);
			return cb_getContactsHint;
		}

		static IntPtr n_GetContactsHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ContactsHint);
		}
#pragma warning restore 0169

		static IntPtr id_getContactsHint;
		public virtual unsafe string ContactsHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getContactsHint' and count(parameter)=0]"
			[Register ("getContactsHint", "()Ljava/lang/String;", "GetGetContactsHintHandler")]
			get {
				if (id_getContactsHint == IntPtr.Zero)
					id_getContactsHint = JNIEnv.GetMethodID (class_ref, "getContactsHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getContactsHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getContactsHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getContactsLabel;
#pragma warning disable 0169
		static Delegate GetGetContactsLabelHandler ()
		{
			if (cb_getContactsLabel == null)
				cb_getContactsLabel = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetContactsLabel);
			return cb_getContactsLabel;
		}

		static IntPtr n_GetContactsLabel (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ContactsLabel);
		}
#pragma warning restore 0169

		static IntPtr id_getContactsLabel;
		public virtual unsafe string ContactsLabel {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getContactsLabel' and count(parameter)=0]"
			[Register ("getContactsLabel", "()Ljava/lang/String;", "GetGetContactsLabelHandler")]
			get {
				if (id_getContactsLabel == IntPtr.Zero)
					id_getContactsLabel = JNIEnv.GetMethodID (class_ref, "getContactsLabel", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getContactsLabel), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getContactsLabel", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSmsAndroid;
#pragma warning disable 0169
		static Delegate GetGetSmsAndroidHandler ()
		{
			if (cb_getSmsAndroid == null)
				cb_getSmsAndroid = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSmsAndroid);
			return cb_getSmsAndroid;
		}

		static IntPtr n_GetSmsAndroid (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SmsAndroid);
		}
#pragma warning restore 0169

		static IntPtr id_getSmsAndroid;
		public virtual unsafe string SmsAndroid {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getSmsAndroid' and count(parameter)=0]"
			[Register ("getSmsAndroid", "()Ljava/lang/String;", "GetGetSmsAndroidHandler")]
			get {
				if (id_getSmsAndroid == IntPtr.Zero)
					id_getSmsAndroid = JNIEnv.GetMethodID (class_ref, "getSmsAndroid", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSmsAndroid), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSmsAndroid", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSmsHint;
#pragma warning disable 0169
		static Delegate GetGetSmsHintHandler ()
		{
			if (cb_getSmsHint == null)
				cb_getSmsHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSmsHint);
			return cb_getSmsHint;
		}

		static IntPtr n_GetSmsHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SmsHint);
		}
#pragma warning restore 0169

		static IntPtr id_getSmsHint;
		public virtual unsafe string SmsHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getSmsHint' and count(parameter)=0]"
			[Register ("getSmsHint", "()Ljava/lang/String;", "GetGetSmsHintHandler")]
			get {
				if (id_getSmsHint == IntPtr.Zero)
					id_getSmsHint = JNIEnv.GetMethodID (class_ref, "getSmsHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSmsHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSmsHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSmsIos;
#pragma warning disable 0169
		static Delegate GetGetSmsIosHandler ()
		{
			if (cb_getSmsIos == null)
				cb_getSmsIos = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSmsIos);
			return cb_getSmsIos;
		}

		static IntPtr n_GetSmsIos (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.InviteSms __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SmsIos);
		}
#pragma warning restore 0169

		static IntPtr id_getSmsIos;
		public virtual unsafe string SmsIos {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='InviteSms']/method[@name='getSmsIos' and count(parameter)=0]"
			[Register ("getSmsIos", "()Ljava/lang/String;", "GetGetSmsIosHandler")]
			get {
				if (id_getSmsIos == IntPtr.Zero)
					id_getSmsIos = JNIEnv.GetMethodID (class_ref, "getSmsIos", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSmsIos), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSmsIos", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
