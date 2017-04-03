using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/CreateProfile", DoNotGenerateAcw=true)]
	public partial class CreateProfile : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/CreateProfile", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CreateProfile); }
		}

		protected CreateProfile (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/constructor[@name='CreateProfile' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CreateProfile ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CreateProfile)) {
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
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Actionbar);
		}
#pragma warning restore 0169

		static IntPtr id_getActionbar;
		public virtual unsafe string Actionbar {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getActionbar' and count(parameter)=0]"
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

		static Delegate cb_getConfpwdEmpty;
#pragma warning disable 0169
		static Delegate GetGetConfpwdEmptyHandler ()
		{
			if (cb_getConfpwdEmpty == null)
				cb_getConfpwdEmpty = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetConfpwdEmpty);
			return cb_getConfpwdEmpty;
		}

		static IntPtr n_GetConfpwdEmpty (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ConfpwdEmpty);
		}
#pragma warning restore 0169

		static IntPtr id_getConfpwdEmpty;
		public virtual unsafe string ConfpwdEmpty {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getConfpwdEmpty' and count(parameter)=0]"
			[Register ("getConfpwdEmpty", "()Ljava/lang/String;", "GetGetConfpwdEmptyHandler")]
			get {
				if (id_getConfpwdEmpty == IntPtr.Zero)
					id_getConfpwdEmpty = JNIEnv.GetMethodID (class_ref, "getConfpwdEmpty", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getConfpwdEmpty), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getConfpwdEmpty", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCreateButton;
#pragma warning disable 0169
		static Delegate GetGetCreateButtonHandler ()
		{
			if (cb_getCreateButton == null)
				cb_getCreateButton = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCreateButton);
			return cb_getCreateButton;
		}

		static IntPtr n_GetCreateButton (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CreateButton);
		}
#pragma warning restore 0169

		static IntPtr id_getCreateButton;
		public virtual unsafe string CreateButton {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getCreateButton' and count(parameter)=0]"
			[Register ("getCreateButton", "()Ljava/lang/String;", "GetGetCreateButtonHandler")]
			get {
				if (id_getCreateButton == IntPtr.Zero)
					id_getCreateButton = JNIEnv.GetMethodID (class_ref, "getCreateButton", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCreateButton), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCreateButton", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getEmailEmpty;
#pragma warning disable 0169
		static Delegate GetGetEmailEmptyHandler ()
		{
			if (cb_getEmailEmpty == null)
				cb_getEmailEmpty = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetEmailEmpty);
			return cb_getEmailEmpty;
		}

		static IntPtr n_GetEmailEmpty (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.EmailEmpty);
		}
#pragma warning restore 0169

		static IntPtr id_getEmailEmpty;
		public virtual unsafe string EmailEmpty {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getEmailEmpty' and count(parameter)=0]"
			[Register ("getEmailEmpty", "()Ljava/lang/String;", "GetGetEmailEmptyHandler")]
			get {
				if (id_getEmailEmpty == IntPtr.Zero)
					id_getEmailEmpty = JNIEnv.GetMethodID (class_ref, "getEmailEmpty", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getEmailEmpty), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getEmailEmpty", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getErrUsername;
#pragma warning disable 0169
		static Delegate GetGetErrUsernameHandler ()
		{
			if (cb_getErrUsername == null)
				cb_getErrUsername = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetErrUsername);
			return cb_getErrUsername;
		}

		static IntPtr n_GetErrUsername (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ErrUsername);
		}
#pragma warning restore 0169

		static IntPtr id_getErrUsername;
		public virtual unsafe string ErrUsername {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getErrUsername' and count(parameter)=0]"
			[Register ("getErrUsername", "()Ljava/lang/String;", "GetGetErrUsernameHandler")]
			get {
				if (id_getErrUsername == IntPtr.Zero)
					id_getErrUsername = JNIEnv.GetMethodID (class_ref, "getErrUsername", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getErrUsername), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getErrUsername", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.FieldHint);
		}
#pragma warning restore 0169

		static IntPtr id_getFieldHint;
		public virtual unsafe string FieldHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getFieldHint' and count(parameter)=0]"
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

		static Delegate cb_getIncorrectPassword;
#pragma warning disable 0169
		static Delegate GetGetIncorrectPasswordHandler ()
		{
			if (cb_getIncorrectPassword == null)
				cb_getIncorrectPassword = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetIncorrectPassword);
			return cb_getIncorrectPassword;
		}

		static IntPtr n_GetIncorrectPassword (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.IncorrectPassword);
		}
#pragma warning restore 0169

		static IntPtr id_getIncorrectPassword;
		public virtual unsafe string IncorrectPassword {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getIncorrectPassword' and count(parameter)=0]"
			[Register ("getIncorrectPassword", "()Ljava/lang/String;", "GetGetIncorrectPasswordHandler")]
			get {
				if (id_getIncorrectPassword == IntPtr.Zero)
					id_getIncorrectPassword = JNIEnv.GetMethodID (class_ref, "getIncorrectPassword", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getIncorrectPassword), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIncorrectPassword", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Loader);
		}
#pragma warning restore 0169

		static IntPtr id_getLoader;
		public virtual unsafe string Loader {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getLoader' and count(parameter)=0]"
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

		static Delegate cb_getPasswordMismatch;
#pragma warning disable 0169
		static Delegate GetGetPasswordMismatchHandler ()
		{
			if (cb_getPasswordMismatch == null)
				cb_getPasswordMismatch = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPasswordMismatch);
			return cb_getPasswordMismatch;
		}

		static IntPtr n_GetPasswordMismatch (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PasswordMismatch);
		}
#pragma warning restore 0169

		static IntPtr id_getPasswordMismatch;
		public virtual unsafe string PasswordMismatch {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getPasswordMismatch' and count(parameter)=0]"
			[Register ("getPasswordMismatch", "()Ljava/lang/String;", "GetGetPasswordMismatchHandler")]
			get {
				if (id_getPasswordMismatch == IntPtr.Zero)
					id_getPasswordMismatch = JNIEnv.GetMethodID (class_ref, "getPasswordMismatch", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPasswordMismatch), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPasswordMismatch", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPhotoHint;
#pragma warning disable 0169
		static Delegate GetGetPhotoHintHandler ()
		{
			if (cb_getPhotoHint == null)
				cb_getPhotoHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPhotoHint);
			return cb_getPhotoHint;
		}

		static IntPtr n_GetPhotoHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.CreateProfile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PhotoHint);
		}
#pragma warning restore 0169

		static IntPtr id_getPhotoHint;
		public virtual unsafe string PhotoHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='CreateProfile']/method[@name='getPhotoHint' and count(parameter)=0]"
			[Register ("getPhotoHint", "()Ljava/lang/String;", "GetGetPhotoHintHandler")]
			get {
				if (id_getPhotoHint == IntPtr.Zero)
					id_getPhotoHint = JNIEnv.GetMethodID (class_ref, "getPhotoHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPhotoHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPhotoHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
