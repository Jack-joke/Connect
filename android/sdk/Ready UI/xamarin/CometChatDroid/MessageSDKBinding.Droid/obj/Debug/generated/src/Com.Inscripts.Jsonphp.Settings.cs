using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Settings", DoNotGenerateAcw=true)]
	public partial class Settings : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Settings", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Settings); }
		}

		protected Settings (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/constructor[@name='Settings' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Settings ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Settings)) {
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

		static Delegate cb_getChangeProfilePic;
#pragma warning disable 0169
		static Delegate GetGetChangeProfilePicHandler ()
		{
			if (cb_getChangeProfilePic == null)
				cb_getChangeProfilePic = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChangeProfilePic);
			return cb_getChangeProfilePic;
		}

		static IntPtr n_GetChangeProfilePic (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChangeProfilePic);
		}
#pragma warning restore 0169

		static IntPtr id_getChangeProfilePic;
		public virtual unsafe string ChangeProfilePic {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getChangeProfilePic' and count(parameter)=0]"
			[Register ("getChangeProfilePic", "()Ljava/lang/String;", "GetGetChangeProfilePicHandler")]
			get {
				if (id_getChangeProfilePic == IntPtr.Zero)
					id_getChangeProfilePic = JNIEnv.GetMethodID (class_ref, "getChangeProfilePic", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChangeProfilePic), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChangeProfilePic", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getEditStatusMessage;
#pragma warning disable 0169
		static Delegate GetGetEditStatusMessageHandler ()
		{
			if (cb_getEditStatusMessage == null)
				cb_getEditStatusMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetEditStatusMessage);
			return cb_getEditStatusMessage;
		}

		static IntPtr n_GetEditStatusMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.EditStatusMessage);
		}
#pragma warning restore 0169

		static Delegate cb_setEditStatusMessage_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetEditStatusMessage_Ljava_lang_String_Handler ()
		{
			if (cb_setEditStatusMessage_Ljava_lang_String_ == null)
				cb_setEditStatusMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetEditStatusMessage_Ljava_lang_String_);
			return cb_setEditStatusMessage_Ljava_lang_String_;
		}

		static void n_SetEditStatusMessage_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.EditStatusMessage = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getEditStatusMessage;
		static IntPtr id_setEditStatusMessage_Ljava_lang_String_;
		public virtual unsafe string EditStatusMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getEditStatusMessage' and count(parameter)=0]"
			[Register ("getEditStatusMessage", "()Ljava/lang/String;", "GetGetEditStatusMessageHandler")]
			get {
				if (id_getEditStatusMessage == IntPtr.Zero)
					id_getEditStatusMessage = JNIEnv.GetMethodID (class_ref, "getEditStatusMessage", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getEditStatusMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getEditStatusMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='setEditStatusMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setEditStatusMessage", "(Ljava/lang/String;)V", "GetSetEditStatusMessage_Ljava_lang_String_Handler")]
			set {
				if (id_setEditStatusMessage_Ljava_lang_String_ == IntPtr.Zero)
					id_setEditStatusMessage_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setEditStatusMessage", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setEditStatusMessage_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEditStatusMessage", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getEditUsername;
#pragma warning disable 0169
		static Delegate GetGetEditUsernameHandler ()
		{
			if (cb_getEditUsername == null)
				cb_getEditUsername = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetEditUsername);
			return cb_getEditUsername;
		}

		static IntPtr n_GetEditUsername (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.EditUsername);
		}
#pragma warning restore 0169

		static Delegate cb_setEditUsername_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetEditUsername_Ljava_lang_String_Handler ()
		{
			if (cb_setEditUsername_Ljava_lang_String_ == null)
				cb_setEditUsername_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetEditUsername_Ljava_lang_String_);
			return cb_setEditUsername_Ljava_lang_String_;
		}

		static void n_SetEditUsername_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.EditUsername = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getEditUsername;
		static IntPtr id_setEditUsername_Ljava_lang_String_;
		public virtual unsafe string EditUsername {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getEditUsername' and count(parameter)=0]"
			[Register ("getEditUsername", "()Ljava/lang/String;", "GetGetEditUsernameHandler")]
			get {
				if (id_getEditUsername == IntPtr.Zero)
					id_getEditUsername = JNIEnv.GetMethodID (class_ref, "getEditUsername", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getEditUsername), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getEditUsername", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='setEditUsername' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setEditUsername", "(Ljava/lang/String;)V", "GetSetEditUsername_Ljava_lang_String_Handler")]
			set {
				if (id_setEditUsername_Ljava_lang_String_ == IntPtr.Zero)
					id_setEditUsername_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setEditUsername", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setEditUsername_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEditUsername", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getInviteViasms;
#pragma warning disable 0169
		static Delegate GetGetInviteViasmsHandler ()
		{
			if (cb_getInviteViasms == null)
				cb_getInviteViasms = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInviteViasms);
			return cb_getInviteViasms;
		}

		static IntPtr n_GetInviteViasms (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InviteViasms);
		}
#pragma warning restore 0169

		static IntPtr id_getInviteViasms;
		public virtual unsafe string InviteViasms {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getInviteViasms' and count(parameter)=0]"
			[Register ("getInviteViasms", "()Ljava/lang/String;", "GetGetInviteViasmsHandler")]
			get {
				if (id_getInviteViasms == IntPtr.Zero)
					id_getInviteViasms = JNIEnv.GetMethodID (class_ref, "getInviteViasms", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInviteViasms), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInviteViasms", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSetLanguage;
#pragma warning disable 0169
		static Delegate GetGetSetLanguageHandler ()
		{
			if (cb_getSetLanguage == null)
				cb_getSetLanguage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSetLanguage);
			return cb_getSetLanguage;
		}

		static IntPtr n_GetSetLanguage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SetLanguage);
		}
#pragma warning restore 0169

		static IntPtr id_getSetLanguage;
		public virtual unsafe string SetLanguage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getSetLanguage' and count(parameter)=0]"
			[Register ("getSetLanguage", "()Ljava/lang/String;", "GetGetSetLanguageHandler")]
			get {
				if (id_getSetLanguage == IntPtr.Zero)
					id_getSetLanguage = JNIEnv.GetMethodID (class_ref, "getSetLanguage", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSetLanguage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSetLanguage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSetStatus;
#pragma warning disable 0169
		static Delegate GetGetSetStatusHandler ()
		{
			if (cb_getSetStatus == null)
				cb_getSetStatus = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSetStatus);
			return cb_getSetStatus;
		}

		static IntPtr n_GetSetStatus (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SetStatus);
		}
#pragma warning restore 0169

		static IntPtr id_getSetStatus;
		public virtual unsafe string SetStatus {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getSetStatus' and count(parameter)=0]"
			[Register ("getSetStatus", "()Ljava/lang/String;", "GetGetSetStatusHandler")]
			get {
				if (id_getSetStatus == IntPtr.Zero)
					id_getSetStatus = JNIEnv.GetMethodID (class_ref, "getSetStatus", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSetStatus), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSetStatus", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSetStatusMessage;
#pragma warning disable 0169
		static Delegate GetGetSetStatusMessageHandler ()
		{
			if (cb_getSetStatusMessage == null)
				cb_getSetStatusMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSetStatusMessage);
			return cb_getSetStatusMessage;
		}

		static IntPtr n_GetSetStatusMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SetStatusMessage);
		}
#pragma warning restore 0169

		static IntPtr id_getSetStatusMessage;
		public virtual unsafe string SetStatusMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getSetStatusMessage' and count(parameter)=0]"
			[Register ("getSetStatusMessage", "()Ljava/lang/String;", "GetGetSetStatusMessageHandler")]
			get {
				if (id_getSetStatusMessage == IntPtr.Zero)
					id_getSetStatusMessage = JNIEnv.GetMethodID (class_ref, "getSetStatusMessage", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSetStatusMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSetStatusMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getSetUserName;
#pragma warning disable 0169
		static Delegate GetGetSetUserNameHandler ()
		{
			if (cb_getSetUserName == null)
				cb_getSetUserName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSetUserName);
			return cb_getSetUserName;
		}

		static IntPtr n_GetSetUserName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SetUserName);
		}
#pragma warning restore 0169

		static IntPtr id_getSetUserName;
		public virtual unsafe string SetUserName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getSetUserName' and count(parameter)=0]"
			[Register ("getSetUserName", "()Ljava/lang/String;", "GetGetSetUserNameHandler")]
			get {
				if (id_getSetUserName == IntPtr.Zero)
					id_getSetUserName = JNIEnv.GetMethodID (class_ref, "getSetUserName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSetUserName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSetUserName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getStatusMessageHint;
#pragma warning disable 0169
		static Delegate GetGetStatusMessageHintHandler ()
		{
			if (cb_getStatusMessageHint == null)
				cb_getStatusMessageHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetStatusMessageHint);
			return cb_getStatusMessageHint;
		}

		static IntPtr n_GetStatusMessageHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.StatusMessageHint);
		}
#pragma warning restore 0169

		static IntPtr id_getStatusMessageHint;
		public virtual unsafe string StatusMessageHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getStatusMessageHint' and count(parameter)=0]"
			[Register ("getStatusMessageHint", "()Ljava/lang/String;", "GetGetStatusMessageHintHandler")]
			get {
				if (id_getStatusMessageHint == IntPtr.Zero)
					id_getStatusMessageHint = JNIEnv.GetMethodID (class_ref, "getStatusMessageHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getStatusMessageHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStatusMessageHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
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
			global::Com.Inscripts.Jsonphp.Settings __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UsernameHint);
		}
#pragma warning restore 0169

		static IntPtr id_getUsernameHint;
		public virtual unsafe string UsernameHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Settings']/method[@name='getUsernameHint' and count(parameter)=0]"
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
