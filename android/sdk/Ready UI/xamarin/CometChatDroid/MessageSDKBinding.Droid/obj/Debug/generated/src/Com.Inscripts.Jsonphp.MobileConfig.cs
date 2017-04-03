using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/MobileConfig", DoNotGenerateAcw=true)]
	public partial class MobileConfig : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/MobileConfig", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MobileConfig); }
		}

		protected MobileConfig (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/constructor[@name='MobileConfig' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe MobileConfig ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (MobileConfig)) {
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

		static Delegate cb_getFacebookEnabled;
#pragma warning disable 0169
		static Delegate GetGetFacebookEnabledHandler ()
		{
			if (cb_getFacebookEnabled == null)
				cb_getFacebookEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFacebookEnabled);
			return cb_getFacebookEnabled;
		}

		static IntPtr n_GetFacebookEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.FacebookEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getFacebookEnabled;
		public virtual unsafe string FacebookEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getFacebookEnabled' and count(parameter)=0]"
			[Register ("getFacebookEnabled", "()Ljava/lang/String;", "GetGetFacebookEnabledHandler")]
			get {
				if (id_getFacebookEnabled == IntPtr.Zero)
					id_getFacebookEnabled = JNIEnv.GetMethodID (class_ref, "getFacebookEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFacebookEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFacebookEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getGoogleEnabled;
#pragma warning disable 0169
		static Delegate GetGetGoogleEnabledHandler ()
		{
			if (cb_getGoogleEnabled == null)
				cb_getGoogleEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetGoogleEnabled);
			return cb_getGoogleEnabled;
		}

		static IntPtr n_GetGoogleEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GoogleEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getGoogleEnabled;
		public virtual unsafe string GoogleEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getGoogleEnabled' and count(parameter)=0]"
			[Register ("getGoogleEnabled", "()Ljava/lang/String;", "GetGetGoogleEnabledHandler")]
			get {
				if (id_getGoogleEnabled == IntPtr.Zero)
					id_getGoogleEnabled = JNIEnv.GetMethodID (class_ref, "getGoogleEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getGoogleEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getGoogleEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getGuestEnabled;
#pragma warning disable 0169
		static Delegate GetGetGuestEnabledHandler ()
		{
			if (cb_getGuestEnabled == null)
				cb_getGuestEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetGuestEnabled);
			return cb_getGuestEnabled;
		}

		static IntPtr n_GetGuestEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GuestEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getGuestEnabled;
		public virtual unsafe string GuestEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getGuestEnabled' and count(parameter)=0]"
			[Register ("getGuestEnabled", "()Ljava/lang/String;", "GetGetGuestEnabledHandler")]
			get {
				if (id_getGuestEnabled == IntPtr.Zero)
					id_getGuestEnabled = JNIEnv.GetMethodID (class_ref, "getGuestEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getGuestEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getGuestEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLogoutEnabled;
#pragma warning disable 0169
		static Delegate GetGetLogoutEnabledHandler ()
		{
			if (cb_getLogoutEnabled == null)
				cb_getLogoutEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLogoutEnabled);
			return cb_getLogoutEnabled;
		}

		static IntPtr n_GetLogoutEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LogoutEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getLogoutEnabled;
		public virtual unsafe string LogoutEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getLogoutEnabled' and count(parameter)=0]"
			[Register ("getLogoutEnabled", "()Ljava/lang/String;", "GetGetLogoutEnabledHandler")]
			get {
				if (id_getLogoutEnabled == IntPtr.Zero)
					id_getLogoutEnabled = JNIEnv.GetMethodID (class_ref, "getLogoutEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLogoutEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLogoutEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPhoneNumberEnabled;
#pragma warning disable 0169
		static Delegate GetGetPhoneNumberEnabledHandler ()
		{
			if (cb_getPhoneNumberEnabled == null)
				cb_getPhoneNumberEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPhoneNumberEnabled);
			return cb_getPhoneNumberEnabled;
		}

		static IntPtr n_GetPhoneNumberEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PhoneNumberEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getPhoneNumberEnabled;
		public virtual unsafe string PhoneNumberEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getPhoneNumberEnabled' and count(parameter)=0]"
			[Register ("getPhoneNumberEnabled", "()Ljava/lang/String;", "GetGetPhoneNumberEnabledHandler")]
			get {
				if (id_getPhoneNumberEnabled == IntPtr.Zero)
					id_getPhoneNumberEnabled = JNIEnv.GetMethodID (class_ref, "getPhoneNumberEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPhoneNumberEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPhoneNumberEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSocialAuthEnabled;
#pragma warning disable 0169
		static Delegate GetGetSocialAuthEnabledHandler ()
		{
			if (cb_getSocialAuthEnabled == null)
				cb_getSocialAuthEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSocialAuthEnabled);
			return cb_getSocialAuthEnabled;
		}

		static IntPtr n_GetSocialAuthEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SocialAuthEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getSocialAuthEnabled;
		public virtual unsafe string SocialAuthEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getSocialAuthEnabled' and count(parameter)=0]"
			[Register ("getSocialAuthEnabled", "()Ljava/lang/String;", "GetGetSocialAuthEnabledHandler")]
			get {
				if (id_getSocialAuthEnabled == IntPtr.Zero)
					id_getSocialAuthEnabled = JNIEnv.GetMethodID (class_ref, "getSocialAuthEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSocialAuthEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSocialAuthEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTwitterEnabled;
#pragma warning disable 0169
		static Delegate GetGetTwitterEnabledHandler ()
		{
			if (cb_getTwitterEnabled == null)
				cb_getTwitterEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTwitterEnabled);
			return cb_getTwitterEnabled;
		}

		static IntPtr n_GetTwitterEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TwitterEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getTwitterEnabled;
		public virtual unsafe string TwitterEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getTwitterEnabled' and count(parameter)=0]"
			[Register ("getTwitterEnabled", "()Ljava/lang/String;", "GetGetTwitterEnabledHandler")]
			get {
				if (id_getTwitterEnabled == IntPtr.Zero)
					id_getTwitterEnabled = JNIEnv.GetMethodID (class_ref, "getTwitterEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTwitterEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTwitterEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getUsernamePasswordEnabled;
#pragma warning disable 0169
		static Delegate GetGetUsernamePasswordEnabledHandler ()
		{
			if (cb_getUsernamePasswordEnabled == null)
				cb_getUsernamePasswordEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUsernamePasswordEnabled);
			return cb_getUsernamePasswordEnabled;
		}

		static IntPtr n_GetUsernamePasswordEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileConfig __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UsernamePasswordEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getUsernamePasswordEnabled;
		public virtual unsafe string UsernamePasswordEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileConfig']/method[@name='getUsernamePasswordEnabled' and count(parameter)=0]"
			[Register ("getUsernamePasswordEnabled", "()Ljava/lang/String;", "GetGetUsernamePasswordEnabledHandler")]
			get {
				if (id_getUsernamePasswordEnabled == IntPtr.Zero)
					id_getUsernamePasswordEnabled = JNIEnv.GetMethodID (class_ref, "getUsernamePasswordEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUsernamePasswordEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUsernamePasswordEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
