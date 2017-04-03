using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Login", DoNotGenerateAcw=true)]
	public partial class Login : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Login", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Login); }
		}

		protected Login (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/constructor[@name='Login' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Login ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Login)) {
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

		static Delegate cb_getCountryCode;
#pragma warning disable 0169
		static Delegate GetGetCountryCodeHandler ()
		{
			if (cb_getCountryCode == null)
				cb_getCountryCode = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCountryCode);
			return cb_getCountryCode;
		}

		static IntPtr n_GetCountryCode (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CountryCode);
		}
#pragma warning restore 0169

		static IntPtr id_getCountryCode;
		public virtual unsafe string CountryCode {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getCountryCode' and count(parameter)=0]"
			[Register ("getCountryCode", "()Ljava/lang/String;", "GetGetCountryCodeHandler")]
			get {
				if (id_getCountryCode == IntPtr.Zero)
					id_getCountryCode = JNIEnv.GetMethodID (class_ref, "getCountryCode", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCountryCode), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCountryCode", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInvalidPassword;
#pragma warning disable 0169
		static Delegate GetGetInvalidPasswordHandler ()
		{
			if (cb_getInvalidPassword == null)
				cb_getInvalidPassword = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInvalidPassword);
			return cb_getInvalidPassword;
		}

		static IntPtr n_GetInvalidPassword (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InvalidPassword);
		}
#pragma warning restore 0169

		static IntPtr id_getInvalidPassword;
		public virtual unsafe string InvalidPassword {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getInvalidPassword' and count(parameter)=0]"
			[Register ("getInvalidPassword", "()Ljava/lang/String;", "GetGetInvalidPasswordHandler")]
			get {
				if (id_getInvalidPassword == IntPtr.Zero)
					id_getInvalidPassword = JNIEnv.GetMethodID (class_ref, "getInvalidPassword", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInvalidPassword), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInvalidPassword", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInvalidPhone;
#pragma warning disable 0169
		static Delegate GetGetInvalidPhoneHandler ()
		{
			if (cb_getInvalidPhone == null)
				cb_getInvalidPhone = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInvalidPhone);
			return cb_getInvalidPhone;
		}

		static IntPtr n_GetInvalidPhone (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InvalidPhone);
		}
#pragma warning restore 0169

		static IntPtr id_getInvalidPhone;
		public virtual unsafe string InvalidPhone {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getInvalidPhone' and count(parameter)=0]"
			[Register ("getInvalidPhone", "()Ljava/lang/String;", "GetGetInvalidPhoneHandler")]
			get {
				if (id_getInvalidPhone == IntPtr.Zero)
					id_getInvalidPhone = JNIEnv.GetMethodID (class_ref, "getInvalidPhone", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInvalidPhone), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInvalidPhone", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInvalidUrl;
#pragma warning disable 0169
		static Delegate GetGetInvalidUrlHandler ()
		{
			if (cb_getInvalidUrl == null)
				cb_getInvalidUrl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInvalidUrl);
			return cb_getInvalidUrl;
		}

		static IntPtr n_GetInvalidUrl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InvalidUrl);
		}
#pragma warning restore 0169

		static IntPtr id_getInvalidUrl;
		public virtual unsafe string InvalidUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getInvalidUrl' and count(parameter)=0]"
			[Register ("getInvalidUrl", "()Ljava/lang/String;", "GetGetInvalidUrlHandler")]
			get {
				if (id_getInvalidUrl == IntPtr.Zero)
					id_getInvalidUrl = JNIEnv.GetMethodID (class_ref, "getInvalidUrl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInvalidUrl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInvalidUrl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInvalidUsername;
#pragma warning disable 0169
		static Delegate GetGetInvalidUsernameHandler ()
		{
			if (cb_getInvalidUsername == null)
				cb_getInvalidUsername = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInvalidUsername);
			return cb_getInvalidUsername;
		}

		static IntPtr n_GetInvalidUsername (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InvalidUsername);
		}
#pragma warning restore 0169

		static IntPtr id_getInvalidUsername;
		public virtual unsafe string InvalidUsername {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getInvalidUsername' and count(parameter)=0]"
			[Register ("getInvalidUsername", "()Ljava/lang/String;", "GetGetInvalidUsernameHandler")]
			get {
				if (id_getInvalidUsername == IntPtr.Zero)
					id_getInvalidUsername = JNIEnv.GetMethodID (class_ref, "getInvalidUsername", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInvalidUsername), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInvalidUsername", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Loader);
		}
#pragma warning restore 0169

		static IntPtr id_getLoader;
		public virtual unsafe string Loader {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getLoader' and count(parameter)=0]"
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

		static Delegate cb_getLoginButtonText;
#pragma warning disable 0169
		static Delegate GetGetLoginButtonTextHandler ()
		{
			if (cb_getLoginButtonText == null)
				cb_getLoginButtonText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginButtonText);
			return cb_getLoginButtonText;
		}

		static IntPtr n_GetLoginButtonText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginButtonText);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginButtonText;
		public virtual unsafe string LoginButtonText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getLoginButtonText' and count(parameter)=0]"
			[Register ("getLoginButtonText", "()Ljava/lang/String;", "GetGetLoginButtonTextHandler")]
			get {
				if (id_getLoginButtonText == IntPtr.Zero)
					id_getLoginButtonText = JNIEnv.GetMethodID (class_ref, "getLoginButtonText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginButtonText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginButtonText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginViaEmail;
#pragma warning disable 0169
		static Delegate GetGetLoginViaEmailHandler ()
		{
			if (cb_getLoginViaEmail == null)
				cb_getLoginViaEmail = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginViaEmail);
			return cb_getLoginViaEmail;
		}

		static IntPtr n_GetLoginViaEmail (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginViaEmail);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginViaEmail;
		public virtual unsafe string LoginViaEmail {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getLoginViaEmail' and count(parameter)=0]"
			[Register ("getLoginViaEmail", "()Ljava/lang/String;", "GetGetLoginViaEmailHandler")]
			get {
				if (id_getLoginViaEmail == IntPtr.Zero)
					id_getLoginViaEmail = JNIEnv.GetMethodID (class_ref, "getLoginViaEmail", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginViaEmail), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginViaEmail", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPasswordBlank;
#pragma warning disable 0169
		static Delegate GetGetPasswordBlankHandler ()
		{
			if (cb_getPasswordBlank == null)
				cb_getPasswordBlank = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPasswordBlank);
			return cb_getPasswordBlank;
		}

		static IntPtr n_GetPasswordBlank (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PasswordBlank);
		}
#pragma warning restore 0169

		static IntPtr id_getPasswordBlank;
		public virtual unsafe string PasswordBlank {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getPasswordBlank' and count(parameter)=0]"
			[Register ("getPasswordBlank", "()Ljava/lang/String;", "GetGetPasswordBlankHandler")]
			get {
				if (id_getPasswordBlank == IntPtr.Zero)
					id_getPasswordBlank = JNIEnv.GetMethodID (class_ref, "getPasswordBlank", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPasswordBlank), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPasswordBlank", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPasswordHint;
#pragma warning disable 0169
		static Delegate GetGetPasswordHintHandler ()
		{
			if (cb_getPasswordHint == null)
				cb_getPasswordHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPasswordHint);
			return cb_getPasswordHint;
		}

		static IntPtr n_GetPasswordHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PasswordHint);
		}
#pragma warning restore 0169

		static IntPtr id_getPasswordHint;
		public virtual unsafe string PasswordHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getPasswordHint' and count(parameter)=0]"
			[Register ("getPasswordHint", "()Ljava/lang/String;", "GetGetPasswordHintHandler")]
			get {
				if (id_getPasswordHint == IntPtr.Zero)
					id_getPasswordHint = JNIEnv.GetMethodID (class_ref, "getPasswordHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPasswordHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPasswordHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPhoneBlank;
#pragma warning disable 0169
		static Delegate GetGetPhoneBlankHandler ()
		{
			if (cb_getPhoneBlank == null)
				cb_getPhoneBlank = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPhoneBlank);
			return cb_getPhoneBlank;
		}

		static IntPtr n_GetPhoneBlank (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PhoneBlank);
		}
#pragma warning restore 0169

		static IntPtr id_getPhoneBlank;
		public virtual unsafe string PhoneBlank {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getPhoneBlank' and count(parameter)=0]"
			[Register ("getPhoneBlank", "()Ljava/lang/String;", "GetGetPhoneBlankHandler")]
			get {
				if (id_getPhoneBlank == IntPtr.Zero)
					id_getPhoneBlank = JNIEnv.GetMethodID (class_ref, "getPhoneBlank", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPhoneBlank), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPhoneBlank", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPhoneHint;
#pragma warning disable 0169
		static Delegate GetGetPhoneHintHandler ()
		{
			if (cb_getPhoneHint == null)
				cb_getPhoneHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPhoneHint);
			return cb_getPhoneHint;
		}

		static IntPtr n_GetPhoneHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PhoneHint);
		}
#pragma warning restore 0169

		static IntPtr id_getPhoneHint;
		public virtual unsafe string PhoneHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getPhoneHint' and count(parameter)=0]"
			[Register ("getPhoneHint", "()Ljava/lang/String;", "GetGetPhoneHintHandler")]
			get {
				if (id_getPhoneHint == IntPtr.Zero)
					id_getPhoneHint = JNIEnv.GetMethodID (class_ref, "getPhoneHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPhoneHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPhoneHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRegisterLinkText;
#pragma warning disable 0169
		static Delegate GetGetRegisterLinkTextHandler ()
		{
			if (cb_getRegisterLinkText == null)
				cb_getRegisterLinkText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRegisterLinkText);
			return cb_getRegisterLinkText;
		}

		static IntPtr n_GetRegisterLinkText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RegisterLinkText);
		}
#pragma warning restore 0169

		static IntPtr id_getRegisterLinkText;
		public virtual unsafe string RegisterLinkText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getRegisterLinkText' and count(parameter)=0]"
			[Register ("getRegisterLinkText", "()Ljava/lang/String;", "GetGetRegisterLinkTextHandler")]
			get {
				if (id_getRegisterLinkText == IntPtr.Zero)
					id_getRegisterLinkText = JNIEnv.GetMethodID (class_ref, "getRegisterLinkText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRegisterLinkText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRegisterLinkText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRegisterNumberButtonText;
#pragma warning disable 0169
		static Delegate GetGetRegisterNumberButtonTextHandler ()
		{
			if (cb_getRegisterNumberButtonText == null)
				cb_getRegisterNumberButtonText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRegisterNumberButtonText);
			return cb_getRegisterNumberButtonText;
		}

		static IntPtr n_GetRegisterNumberButtonText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RegisterNumberButtonText);
		}
#pragma warning restore 0169

		static IntPtr id_getRegisterNumberButtonText;
		public virtual unsafe string RegisterNumberButtonText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getRegisterNumberButtonText' and count(parameter)=0]"
			[Register ("getRegisterNumberButtonText", "()Ljava/lang/String;", "GetGetRegisterNumberButtonTextHandler")]
			get {
				if (id_getRegisterNumberButtonText == IntPtr.Zero)
					id_getRegisterNumberButtonText = JNIEnv.GetMethodID (class_ref, "getRegisterNumberButtonText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRegisterNumberButtonText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRegisterNumberButtonText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRememberMe;
#pragma warning disable 0169
		static Delegate GetGetRememberMeHandler ()
		{
			if (cb_getRememberMe == null)
				cb_getRememberMe = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRememberMe);
			return cb_getRememberMe;
		}

		static IntPtr n_GetRememberMe (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RememberMe);
		}
#pragma warning restore 0169

		static IntPtr id_getRememberMe;
		public virtual unsafe string RememberMe {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getRememberMe' and count(parameter)=0]"
			[Register ("getRememberMe", "()Ljava/lang/String;", "GetGetRememberMeHandler")]
			get {
				if (id_getRememberMe == IntPtr.Zero)
					id_getRememberMe = JNIEnv.GetMethodID (class_ref, "getRememberMe", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRememberMe), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRememberMe", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSelectList;
#pragma warning disable 0169
		static Delegate GetGetSelectListHandler ()
		{
			if (cb_getSelectList == null)
				cb_getSelectList = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSelectList);
			return cb_getSelectList;
		}

		static IntPtr n_GetSelectList (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SelectList);
		}
#pragma warning restore 0169

		static IntPtr id_getSelectList;
		public virtual unsafe string SelectList {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getSelectList' and count(parameter)=0]"
			[Register ("getSelectList", "()Ljava/lang/String;", "GetGetSelectListHandler")]
			get {
				if (id_getSelectList == IntPtr.Zero)
					id_getSelectList = JNIEnv.GetMethodID (class_ref, "getSelectList", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSelectList), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSelectList", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUrlBlank;
#pragma warning disable 0169
		static Delegate GetGetUrlBlankHandler ()
		{
			if (cb_getUrlBlank == null)
				cb_getUrlBlank = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUrlBlank);
			return cb_getUrlBlank;
		}

		static IntPtr n_GetUrlBlank (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UrlBlank);
		}
#pragma warning restore 0169

		static IntPtr id_getUrlBlank;
		public virtual unsafe string UrlBlank {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getUrlBlank' and count(parameter)=0]"
			[Register ("getUrlBlank", "()Ljava/lang/String;", "GetGetUrlBlankHandler")]
			get {
				if (id_getUrlBlank == IntPtr.Zero)
					id_getUrlBlank = JNIEnv.GetMethodID (class_ref, "getUrlBlank", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUrlBlank), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUrlBlank", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUrlHint;
#pragma warning disable 0169
		static Delegate GetGetUrlHintHandler ()
		{
			if (cb_getUrlHint == null)
				cb_getUrlHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUrlHint);
			return cb_getUrlHint;
		}

		static IntPtr n_GetUrlHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UrlHint);
		}
#pragma warning restore 0169

		static IntPtr id_getUrlHint;
		public virtual unsafe string UrlHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getUrlHint' and count(parameter)=0]"
			[Register ("getUrlHint", "()Ljava/lang/String;", "GetGetUrlHintHandler")]
			get {
				if (id_getUrlHint == IntPtr.Zero)
					id_getUrlHint = JNIEnv.GetMethodID (class_ref, "getUrlHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUrlHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUrlHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUsernameBlank;
#pragma warning disable 0169
		static Delegate GetGetUsernameBlankHandler ()
		{
			if (cb_getUsernameBlank == null)
				cb_getUsernameBlank = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUsernameBlank);
			return cb_getUsernameBlank;
		}

		static IntPtr n_GetUsernameBlank (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UsernameBlank);
		}
#pragma warning restore 0169

		static IntPtr id_getUsernameBlank;
		public virtual unsafe string UsernameBlank {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getUsernameBlank' and count(parameter)=0]"
			[Register ("getUsernameBlank", "()Ljava/lang/String;", "GetGetUsernameBlankHandler")]
			get {
				if (id_getUsernameBlank == IntPtr.Zero)
					id_getUsernameBlank = JNIEnv.GetMethodID (class_ref, "getUsernameBlank", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUsernameBlank), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUsernameBlank", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUsernameHint;
#pragma warning disable 0169
		static Delegate GetGetUsernameHintHandler ()
		{
			if (cb_getUsernameHint == null)
				cb_getUsernameHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUsernameHint);
			return cb_getUsernameHint;
		}

		static IntPtr n_GetUsernameHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Login __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UsernameHint);
		}
#pragma warning restore 0169

		static IntPtr id_getUsernameHint;
		public virtual unsafe string UsernameHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Login']/method[@name='getUsernameHint' and count(parameter)=0]"
			[Register ("getUsernameHint", "()Ljava/lang/String;", "GetGetUsernameHintHandler")]
			get {
				if (id_getUsernameHint == IntPtr.Zero)
					id_getUsernameHint = JNIEnv.GetMethodID (class_ref, "getUsernameHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUsernameHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUsernameHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
