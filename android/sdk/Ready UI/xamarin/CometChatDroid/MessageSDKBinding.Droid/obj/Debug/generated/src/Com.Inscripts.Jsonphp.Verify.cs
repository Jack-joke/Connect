using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Verify", DoNotGenerateAcw=true)]
	public partial class Verify : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Verify", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Verify); }
		}

		protected Verify (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/constructor[@name='Verify' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Verify ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Verify)) {
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
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Actionbar);
		}
#pragma warning restore 0169

		static IntPtr id_getActionbar;
		public virtual unsafe string Actionbar {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getActionbar' and count(parameter)=0]"
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

		static Delegate cb_getChangeEmail;
#pragma warning disable 0169
		static Delegate GetGetChangeEmailHandler ()
		{
			if (cb_getChangeEmail == null)
				cb_getChangeEmail = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChangeEmail);
			return cb_getChangeEmail;
		}

		static IntPtr n_GetChangeEmail (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChangeEmail);
		}
#pragma warning restore 0169

		static IntPtr id_getChangeEmail;
		public virtual unsafe string ChangeEmail {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getChangeEmail' and count(parameter)=0]"
			[Register ("getChangeEmail", "()Ljava/lang/String;", "GetGetChangeEmailHandler")]
			get {
				if (id_getChangeEmail == IntPtr.Zero)
					id_getChangeEmail = JNIEnv.GetMethodID (class_ref, "getChangeEmail", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChangeEmail), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChangeEmail", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getFieldHint;
#pragma warning disable 0169
		static Delegate GetGetFieldHintHandler ()
		{
			if (cb_getFieldHint == null)
				cb_getFieldHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFieldHint);
			return cb_getFieldHint;
		}

		static IntPtr n_GetFieldHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.FieldHint);
		}
#pragma warning restore 0169

		static IntPtr id_getFieldHint;
		public virtual unsafe string FieldHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getFieldHint' and count(parameter)=0]"
			[Register ("getFieldHint", "()Ljava/lang/String;", "GetGetFieldHintHandler")]
			get {
				if (id_getFieldHint == IntPtr.Zero)
					id_getFieldHint = JNIEnv.GetMethodID (class_ref, "getFieldHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFieldHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFieldHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoader;
#pragma warning disable 0169
		static Delegate GetGetLoaderHandler ()
		{
			if (cb_getLoader == null)
				cb_getLoader = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoader);
			return cb_getLoader;
		}

		static IntPtr n_GetLoader (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Loader);
		}
#pragma warning restore 0169

		static IntPtr id_getLoader;
		public virtual unsafe string Loader {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getLoader' and count(parameter)=0]"
			[Register ("getLoader", "()Ljava/lang/String;", "GetGetLoaderHandler")]
			get {
				if (id_getLoader == IntPtr.Zero)
					id_getLoader = JNIEnv.GetMethodID (class_ref, "getLoader", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoader), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoader", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getResendButton;
#pragma warning disable 0169
		static Delegate GetGetResendButtonHandler ()
		{
			if (cb_getResendButton == null)
				cb_getResendButton = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetResendButton);
			return cb_getResendButton;
		}

		static IntPtr n_GetResendButton (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ResendButton);
		}
#pragma warning restore 0169

		static IntPtr id_getResendButton;
		public virtual unsafe string ResendButton {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getResendButton' and count(parameter)=0]"
			[Register ("getResendButton", "()Ljava/lang/String;", "GetGetResendButtonHandler")]
			get {
				if (id_getResendButton == IntPtr.Zero)
					id_getResendButton = JNIEnv.GetMethodID (class_ref, "getResendButton", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getResendButton), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getResendButton", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getVerifyButton;
#pragma warning disable 0169
		static Delegate GetGetVerifyButtonHandler ()
		{
			if (cb_getVerifyButton == null)
				cb_getVerifyButton = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetVerifyButton);
			return cb_getVerifyButton;
		}

		static IntPtr n_GetVerifyButton (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.VerifyButton);
		}
#pragma warning restore 0169

		static IntPtr id_getVerifyButton;
		public virtual unsafe string VerifyButton {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getVerifyButton' and count(parameter)=0]"
			[Register ("getVerifyButton", "()Ljava/lang/String;", "GetGetVerifyButtonHandler")]
			get {
				if (id_getVerifyButton == IntPtr.Zero)
					id_getVerifyButton = JNIEnv.GetMethodID (class_ref, "getVerifyButton", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVerifyButton), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getVerifyButton", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getWrongCode;
#pragma warning disable 0169
		static Delegate GetGetWrongCodeHandler ()
		{
			if (cb_getWrongCode == null)
				cb_getWrongCode = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWrongCode);
			return cb_getWrongCode;
		}

		static IntPtr n_GetWrongCode (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Verify __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WrongCode);
		}
#pragma warning restore 0169

		static IntPtr id_getWrongCode;
		public virtual unsafe string WrongCode {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Verify']/method[@name='getWrongCode' and count(parameter)=0]"
			[Register ("getWrongCode", "()Ljava/lang/String;", "GetGetWrongCodeHandler")]
			get {
				if (id_getWrongCode == IntPtr.Zero)
					id_getWrongCode = JNIEnv.GetMethodID (class_ref, "getWrongCode", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWrongCode), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWrongCode", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
