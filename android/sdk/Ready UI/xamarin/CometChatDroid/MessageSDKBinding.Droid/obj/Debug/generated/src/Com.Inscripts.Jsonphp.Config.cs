using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Config", DoNotGenerateAcw=true)]
	public partial class Config : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Config", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Config); }
		}

		protected Config (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/constructor[@name='Config' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Config ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Config)) {
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

		static Delegate cb_getAnnouncementEnabled;
#pragma warning disable 0169
		static Delegate GetGetAnnouncementEnabledHandler ()
		{
			if (cb_getAnnouncementEnabled == null)
				cb_getAnnouncementEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAnnouncementEnabled);
			return cb_getAnnouncementEnabled;
		}

		static IntPtr n_GetAnnouncementEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AnnouncementEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setAnnouncementEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAnnouncementEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setAnnouncementEnabled_Ljava_lang_String_ == null)
				cb_setAnnouncementEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAnnouncementEnabled_Ljava_lang_String_);
			return cb_setAnnouncementEnabled_Ljava_lang_String_;
		}

		static void n_SetAnnouncementEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AnnouncementEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAnnouncementEnabled;
		static IntPtr id_setAnnouncementEnabled_Ljava_lang_String_;
		public virtual unsafe string AnnouncementEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getAnnouncementEnabled' and count(parameter)=0]"
			[Register ("getAnnouncementEnabled", "()Ljava/lang/String;", "GetGetAnnouncementEnabledHandler")]
			get {
				if (id_getAnnouncementEnabled == IntPtr.Zero)
					id_getAnnouncementEnabled = JNIEnv.GetMethodID (class_ref, "getAnnouncementEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnouncementEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAnnouncementEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setAnnouncementEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAnnouncementEnabled", "(Ljava/lang/String;)V", "GetSetAnnouncementEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setAnnouncementEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setAnnouncementEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAnnouncementEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAnnouncementEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAnnouncementEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getArmyTime;
#pragma warning disable 0169
		static Delegate GetGetArmyTimeHandler ()
		{
			if (cb_getArmyTime == null)
				cb_getArmyTime = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetArmyTime);
			return cb_getArmyTime;
		}

		static IntPtr n_GetArmyTime (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ArmyTime);
		}
#pragma warning restore 0169

		static Delegate cb_setArmyTime_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetArmyTime_Ljava_lang_String_Handler ()
		{
			if (cb_setArmyTime_Ljava_lang_String_ == null)
				cb_setArmyTime_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetArmyTime_Ljava_lang_String_);
			return cb_setArmyTime_Ljava_lang_String_;
		}

		static void n_SetArmyTime_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ArmyTime = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getArmyTime;
		static IntPtr id_setArmyTime_Ljava_lang_String_;
		public virtual unsafe string ArmyTime {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getArmyTime' and count(parameter)=0]"
			[Register ("getArmyTime", "()Ljava/lang/String;", "GetGetArmyTimeHandler")]
			get {
				if (id_getArmyTime == IntPtr.Zero)
					id_getArmyTime = JNIEnv.GetMethodID (class_ref, "getArmyTime", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getArmyTime), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getArmyTime", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setArmyTime' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setArmyTime", "(Ljava/lang/String;)V", "GetSetArmyTime_Ljava_lang_String_Handler")]
			set {
				if (id_setArmyTime_Ljava_lang_String_ == IntPtr.Zero)
					id_setArmyTime_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setArmyTime", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setArmyTime_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setArmyTime", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAvBroadcastEnabled;
#pragma warning disable 0169
		static Delegate GetGetAvBroadcastEnabledHandler ()
		{
			if (cb_getAvBroadcastEnabled == null)
				cb_getAvBroadcastEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvBroadcastEnabled);
			return cb_getAvBroadcastEnabled;
		}

		static IntPtr n_GetAvBroadcastEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvBroadcastEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setAvBroadcastEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvBroadcastEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setAvBroadcastEnabled_Ljava_lang_String_ == null)
				cb_setAvBroadcastEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvBroadcastEnabled_Ljava_lang_String_);
			return cb_setAvBroadcastEnabled_Ljava_lang_String_;
		}

		static void n_SetAvBroadcastEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvBroadcastEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvBroadcastEnabled;
		static IntPtr id_setAvBroadcastEnabled_Ljava_lang_String_;
		public virtual unsafe string AvBroadcastEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getAvBroadcastEnabled' and count(parameter)=0]"
			[Register ("getAvBroadcastEnabled", "()Ljava/lang/String;", "GetGetAvBroadcastEnabledHandler")]
			get {
				if (id_getAvBroadcastEnabled == IntPtr.Zero)
					id_getAvBroadcastEnabled = JNIEnv.GetMethodID (class_ref, "getAvBroadcastEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvBroadcastEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvBroadcastEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setAvBroadcastEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvBroadcastEnabled", "(Ljava/lang/String;)V", "GetSetAvBroadcastEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setAvBroadcastEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvBroadcastEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvBroadcastEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvBroadcastEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvBroadcastEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAvConferenceEnabled;
#pragma warning disable 0169
		static Delegate GetGetAvConferenceEnabledHandler ()
		{
			if (cb_getAvConferenceEnabled == null)
				cb_getAvConferenceEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvConferenceEnabled);
			return cb_getAvConferenceEnabled;
		}

		static IntPtr n_GetAvConferenceEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvConferenceEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setAvConferenceEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvConferenceEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setAvConferenceEnabled_Ljava_lang_String_ == null)
				cb_setAvConferenceEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvConferenceEnabled_Ljava_lang_String_);
			return cb_setAvConferenceEnabled_Ljava_lang_String_;
		}

		static void n_SetAvConferenceEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvConferenceEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvConferenceEnabled;
		static IntPtr id_setAvConferenceEnabled_Ljava_lang_String_;
		public virtual unsafe string AvConferenceEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getAvConferenceEnabled' and count(parameter)=0]"
			[Register ("getAvConferenceEnabled", "()Ljava/lang/String;", "GetGetAvConferenceEnabledHandler")]
			get {
				if (id_getAvConferenceEnabled == IntPtr.Zero)
					id_getAvConferenceEnabled = JNIEnv.GetMethodID (class_ref, "getAvConferenceEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvConferenceEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvConferenceEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setAvConferenceEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvConferenceEnabled", "(Ljava/lang/String;)V", "GetSetAvConferenceEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setAvConferenceEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvConferenceEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvConferenceEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvConferenceEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvConferenceEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getBeepOnAllMessages;
#pragma warning disable 0169
		static Delegate GetGetBeepOnAllMessagesHandler ()
		{
			if (cb_getBeepOnAllMessages == null)
				cb_getBeepOnAllMessages = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBeepOnAllMessages);
			return cb_getBeepOnAllMessages;
		}

		static IntPtr n_GetBeepOnAllMessages (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BeepOnAllMessages);
		}
#pragma warning restore 0169

		static Delegate cb_setBeepOnAllMessages_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetBeepOnAllMessages_Ljava_lang_String_Handler ()
		{
			if (cb_setBeepOnAllMessages_Ljava_lang_String_ == null)
				cb_setBeepOnAllMessages_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBeepOnAllMessages_Ljava_lang_String_);
			return cb_setBeepOnAllMessages_Ljava_lang_String_;
		}

		static void n_SetBeepOnAllMessages_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BeepOnAllMessages = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBeepOnAllMessages;
		static IntPtr id_setBeepOnAllMessages_Ljava_lang_String_;
		public virtual unsafe string BeepOnAllMessages {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getBeepOnAllMessages' and count(parameter)=0]"
			[Register ("getBeepOnAllMessages", "()Ljava/lang/String;", "GetGetBeepOnAllMessagesHandler")]
			get {
				if (id_getBeepOnAllMessages == IntPtr.Zero)
					id_getBeepOnAllMessages = JNIEnv.GetMethodID (class_ref, "getBeepOnAllMessages", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBeepOnAllMessages), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBeepOnAllMessages", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setBeepOnAllMessages' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setBeepOnAllMessages", "(Ljava/lang/String;)V", "GetSetBeepOnAllMessages_Ljava_lang_String_Handler")]
			set {
				if (id_setBeepOnAllMessages_Ljava_lang_String_ == IntPtr.Zero)
					id_setBeepOnAllMessages_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setBeepOnAllMessages", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBeepOnAllMessages_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBeepOnAllMessages", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getBotsEnabled;
#pragma warning disable 0169
		static Delegate GetGetBotsEnabledHandler ()
		{
			if (cb_getBotsEnabled == null)
				cb_getBotsEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBotsEnabled);
			return cb_getBotsEnabled;
		}

		static int n_GetBotsEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BotsEnabled;
		}
#pragma warning restore 0169

		static IntPtr id_getBotsEnabled;
		public virtual unsafe int BotsEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getBotsEnabled' and count(parameter)=0]"
			[Register ("getBotsEnabled", "()I", "GetGetBotsEnabledHandler")]
			get {
				if (id_getBotsEnabled == IntPtr.Zero)
					id_getBotsEnabled = JNIEnv.GetMethodID (class_ref, "getBotsEnabled", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBotsEnabled);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBotsEnabled", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_getBroadcastMessageEnabled;
#pragma warning disable 0169
		static Delegate GetGetBroadcastMessageEnabledHandler ()
		{
			if (cb_getBroadcastMessageEnabled == null)
				cb_getBroadcastMessageEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBroadcastMessageEnabled);
			return cb_getBroadcastMessageEnabled;
		}

		static IntPtr n_GetBroadcastMessageEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BroadcastMessageEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setBroadcastMessageEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetBroadcastMessageEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setBroadcastMessageEnabled_Ljava_lang_String_ == null)
				cb_setBroadcastMessageEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBroadcastMessageEnabled_Ljava_lang_String_);
			return cb_setBroadcastMessageEnabled_Ljava_lang_String_;
		}

		static void n_SetBroadcastMessageEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BroadcastMessageEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBroadcastMessageEnabled;
		static IntPtr id_setBroadcastMessageEnabled_Ljava_lang_String_;
		public virtual unsafe string BroadcastMessageEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getBroadcastMessageEnabled' and count(parameter)=0]"
			[Register ("getBroadcastMessageEnabled", "()Ljava/lang/String;", "GetGetBroadcastMessageEnabledHandler")]
			get {
				if (id_getBroadcastMessageEnabled == IntPtr.Zero)
					id_getBroadcastMessageEnabled = JNIEnv.GetMethodID (class_ref, "getBroadcastMessageEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBroadcastMessageEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBroadcastMessageEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setBroadcastMessageEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setBroadcastMessageEnabled", "(Ljava/lang/String;)V", "GetSetBroadcastMessageEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setBroadcastMessageEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setBroadcastMessageEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setBroadcastMessageEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBroadcastMessageEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBroadcastMessageEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCOMETCHATROOMS;
#pragma warning disable 0169
		static Delegate GetGetCOMETCHATROOMSHandler ()
		{
			if (cb_getCOMETCHATROOMS == null)
				cb_getCOMETCHATROOMS = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCOMETCHATROOMS);
			return cb_getCOMETCHATROOMS;
		}

		static IntPtr n_GetCOMETCHATROOMS (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.COMETCHATROOMS);
		}
#pragma warning restore 0169

		static Delegate cb_setCOMETCHATROOMS_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCOMETCHATROOMS_Ljava_lang_String_Handler ()
		{
			if (cb_setCOMETCHATROOMS_Ljava_lang_String_ == null)
				cb_setCOMETCHATROOMS_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCOMETCHATROOMS_Ljava_lang_String_);
			return cb_setCOMETCHATROOMS_Ljava_lang_String_;
		}

		static void n_SetCOMETCHATROOMS_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.COMETCHATROOMS = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCOMETCHATROOMS;
		static IntPtr id_setCOMETCHATROOMS_Ljava_lang_String_;
		public virtual unsafe string COMETCHATROOMS {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCOMETCHATROOMS' and count(parameter)=0]"
			[Register ("getCOMETCHATROOMS", "()Ljava/lang/String;", "GetGetCOMETCHATROOMSHandler")]
			get {
				if (id_getCOMETCHATROOMS == IntPtr.Zero)
					id_getCOMETCHATROOMS = JNIEnv.GetMethodID (class_ref, "getCOMETCHATROOMS", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCOMETCHATROOMS), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCOMETCHATROOMS", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setCOMETCHATROOMS' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCOMETCHATROOMS", "(Ljava/lang/String;)V", "GetSetCOMETCHATROOMS_Ljava_lang_String_Handler")]
			set {
				if (id_setCOMETCHATROOMS_Ljava_lang_String_ == IntPtr.Zero)
					id_setCOMETCHATROOMS_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCOMETCHATROOMS", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCOMETCHATROOMS_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCOMETCHATROOMS", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCrHideUserCount;
#pragma warning disable 0169
		static Delegate GetGetCrHideUserCountHandler ()
		{
			if (cb_getCrHideUserCount == null)
				cb_getCrHideUserCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrHideUserCount);
			return cb_getCrHideUserCount;
		}

		static IntPtr n_GetCrHideUserCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrHideUserCount);
		}
#pragma warning restore 0169

		static IntPtr id_getCrHideUserCount;
		public virtual unsafe string CrHideUserCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCrHideUserCount' and count(parameter)=0]"
			[Register ("getCrHideUserCount", "()Ljava/lang/String;", "GetGetCrHideUserCountHandler")]
			get {
				if (id_getCrHideUserCount == IntPtr.Zero)
					id_getCrHideUserCount = JNIEnv.GetMethodID (class_ref, "getCrHideUserCount", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrHideUserCount), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrHideUserCount", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCrWhiteboardEnabled;
#pragma warning disable 0169
		static Delegate GetGetCrWhiteboardEnabledHandler ()
		{
			if (cb_getCrWhiteboardEnabled == null)
				cb_getCrWhiteboardEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrWhiteboardEnabled);
			return cb_getCrWhiteboardEnabled;
		}

		static IntPtr n_GetCrWhiteboardEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrWhiteboardEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getCrWhiteboardEnabled;
		public virtual unsafe string CrWhiteboardEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCrWhiteboardEnabled' and count(parameter)=0]"
			[Register ("getCrWhiteboardEnabled", "()Ljava/lang/String;", "GetGetCrWhiteboardEnabledHandler")]
			get {
				if (id_getCrWhiteboardEnabled == IntPtr.Zero)
					id_getCrWhiteboardEnabled = JNIEnv.GetMethodID (class_ref, "getCrWhiteboardEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrWhiteboardEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrWhiteboardEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCrWriteboardEnabled;
#pragma warning disable 0169
		static Delegate GetGetCrWriteboardEnabledHandler ()
		{
			if (cb_getCrWriteboardEnabled == null)
				cb_getCrWriteboardEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrWriteboardEnabled);
			return cb_getCrWriteboardEnabled;
		}

		static IntPtr n_GetCrWriteboardEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrWriteboardEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getCrWriteboardEnabled;
		public virtual unsafe string CrWriteboardEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCrWriteboardEnabled' and count(parameter)=0]"
			[Register ("getCrWriteboardEnabled", "()Ljava/lang/String;", "GetGetCrWriteboardEnabledHandler")]
			get {
				if (id_getCrWriteboardEnabled == IntPtr.Zero)
					id_getCrWriteboardEnabled = JNIEnv.GetMethodID (class_ref, "getCrWriteboardEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrWriteboardEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrWriteboardEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCravbroadcastEnabled;
#pragma warning disable 0169
		static Delegate GetGetCravbroadcastEnabledHandler ()
		{
			if (cb_getCravbroadcastEnabled == null)
				cb_getCravbroadcastEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCravbroadcastEnabled);
			return cb_getCravbroadcastEnabled;
		}

		static IntPtr n_GetCravbroadcastEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CravbroadcastEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setCravbroadcastEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCravbroadcastEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setCravbroadcastEnabled_Ljava_lang_String_ == null)
				cb_setCravbroadcastEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCravbroadcastEnabled_Ljava_lang_String_);
			return cb_setCravbroadcastEnabled_Ljava_lang_String_;
		}

		static void n_SetCravbroadcastEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CravbroadcastEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCravbroadcastEnabled;
		static IntPtr id_setCravbroadcastEnabled_Ljava_lang_String_;
		public virtual unsafe string CravbroadcastEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCravbroadcastEnabled' and count(parameter)=0]"
			[Register ("getCravbroadcastEnabled", "()Ljava/lang/String;", "GetGetCravbroadcastEnabledHandler")]
			get {
				if (id_getCravbroadcastEnabled == IntPtr.Zero)
					id_getCravbroadcastEnabled = JNIEnv.GetMethodID (class_ref, "getCravbroadcastEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCravbroadcastEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCravbroadcastEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setCravbroadcastEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCravbroadcastEnabled", "(Ljava/lang/String;)V", "GetSetCravbroadcastEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setCravbroadcastEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setCravbroadcastEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCravbroadcastEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCravbroadcastEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCravbroadcastEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCrhandwriteEnabled;
#pragma warning disable 0169
		static Delegate GetGetCrhandwriteEnabledHandler ()
		{
			if (cb_getCrhandwriteEnabled == null)
				cb_getCrhandwriteEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrhandwriteEnabled);
			return cb_getCrhandwriteEnabled;
		}

		static IntPtr n_GetCrhandwriteEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrhandwriteEnabled);
		}
#pragma warning restore 0169

		static IntPtr id_getCrhandwriteEnabled;
		public virtual unsafe string CrhandwriteEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCrhandwriteEnabled' and count(parameter)=0]"
			[Register ("getCrhandwriteEnabled", "()Ljava/lang/String;", "GetGetCrhandwriteEnabledHandler")]
			get {
				if (id_getCrhandwriteEnabled == IntPtr.Zero)
					id_getCrhandwriteEnabled = JNIEnv.GetMethodID (class_ref, "getCrhandwriteEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrhandwriteEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrhandwriteEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCrstyles;
#pragma warning disable 0169
		static Delegate GetGetCrstylesHandler ()
		{
			if (cb_getCrstyles == null)
				cb_getCrstyles = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrstyles);
			return cb_getCrstyles;
		}

		static IntPtr n_GetCrstyles (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Crstyles);
		}
#pragma warning restore 0169

		static IntPtr id_getCrstyles;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Crstyles Crstyles {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getCrstyles' and count(parameter)=0]"
			[Register ("getCrstyles", "()Lcom/inscripts/jsonphp/Crstyles;", "GetGetCrstylesHandler")]
			get {
				if (id_getCrstyles == IntPtr.Zero)
					id_getCrstyles = JNIEnv.GetMethodID (class_ref, "getCrstyles", "()Lcom/inscripts/jsonphp/Crstyles;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Crstyles> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrstyles), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Crstyles> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrstyles", "()Lcom/inscripts/jsonphp/Crstyles;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getDISPLAYALLUSERS;
#pragma warning disable 0169
		static Delegate GetGetDISPLAYALLUSERSHandler ()
		{
			if (cb_getDISPLAYALLUSERS == null)
				cb_getDISPLAYALLUSERS = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDISPLAYALLUSERS);
			return cb_getDISPLAYALLUSERS;
		}

		static IntPtr n_GetDISPLAYALLUSERS (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.DISPLAYALLUSERS);
		}
#pragma warning restore 0169

		static Delegate cb_setDISPLAYALLUSERS_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetDISPLAYALLUSERS_Ljava_lang_String_Handler ()
		{
			if (cb_setDISPLAYALLUSERS_Ljava_lang_String_ == null)
				cb_setDISPLAYALLUSERS_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetDISPLAYALLUSERS_Ljava_lang_String_);
			return cb_setDISPLAYALLUSERS_Ljava_lang_String_;
		}

		static void n_SetDISPLAYALLUSERS_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.DISPLAYALLUSERS = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getDISPLAYALLUSERS;
		static IntPtr id_setDISPLAYALLUSERS_Ljava_lang_String_;
		public virtual unsafe string DISPLAYALLUSERS {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getDISPLAYALLUSERS' and count(parameter)=0]"
			[Register ("getDISPLAYALLUSERS", "()Ljava/lang/String;", "GetGetDISPLAYALLUSERSHandler")]
			get {
				if (id_getDISPLAYALLUSERS == IntPtr.Zero)
					id_getDISPLAYALLUSERS = JNIEnv.GetMethodID (class_ref, "getDISPLAYALLUSERS", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDISPLAYALLUSERS), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getDISPLAYALLUSERS", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setDISPLAYALLUSERS' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setDISPLAYALLUSERS", "(Ljava/lang/String;)V", "GetSetDISPLAYALLUSERS_Ljava_lang_String_Handler")]
			set {
				if (id_setDISPLAYALLUSERS_Ljava_lang_String_ == IntPtr.Zero)
					id_setDISPLAYALLUSERS_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setDISPLAYALLUSERS", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDISPLAYALLUSERS_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setDISPLAYALLUSERS", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getFullName;
#pragma warning disable 0169
		static Delegate GetGetFullNameHandler ()
		{
			if (cb_getFullName == null)
				cb_getFullName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFullName);
			return cb_getFullName;
		}

		static IntPtr n_GetFullName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.FullName);
		}
#pragma warning restore 0169

		static Delegate cb_setFullName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetFullName_Ljava_lang_String_Handler ()
		{
			if (cb_setFullName_Ljava_lang_String_ == null)
				cb_setFullName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetFullName_Ljava_lang_String_);
			return cb_setFullName_Ljava_lang_String_;
		}

		static void n_SetFullName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FullName = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getFullName;
		static IntPtr id_setFullName_Ljava_lang_String_;
		public virtual unsafe string FullName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getFullName' and count(parameter)=0]"
			[Register ("getFullName", "()Ljava/lang/String;", "GetGetFullNameHandler")]
			get {
				if (id_getFullName == IntPtr.Zero)
					id_getFullName = JNIEnv.GetMethodID (class_ref, "getFullName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFullName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFullName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setFullName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setFullName", "(Ljava/lang/String;)V", "GetSetFullName_Ljava_lang_String_Handler")]
			set {
				if (id_setFullName_Ljava_lang_String_ == IntPtr.Zero)
					id_setFullName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setFullName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFullName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFullName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getHandwriteUrl;
#pragma warning disable 0169
		static Delegate GetGetHandwriteUrlHandler ()
		{
			if (cb_getHandwriteUrl == null)
				cb_getHandwriteUrl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHandwriteUrl);
			return cb_getHandwriteUrl;
		}

		static IntPtr n_GetHandwriteUrl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.HandwriteUrl);
		}
#pragma warning restore 0169

		static IntPtr id_getHandwriteUrl;
		public virtual unsafe string HandwriteUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getHandwriteUrl' and count(parameter)=0]"
			[Register ("getHandwriteUrl", "()Ljava/lang/String;", "GetGetHandwriteUrlHandler")]
			get {
				if (id_getHandwriteUrl == IntPtr.Zero)
					id_getHandwriteUrl = JNIEnv.GetMethodID (class_ref, "getHandwriteUrl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHandwriteUrl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHandwriteUrl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getHistoryMessageLimit;
#pragma warning disable 0169
		static Delegate GetGetHistoryMessageLimitHandler ()
		{
			if (cb_getHistoryMessageLimit == null)
				cb_getHistoryMessageLimit = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHistoryMessageLimit);
			return cb_getHistoryMessageLimit;
		}

		static IntPtr n_GetHistoryMessageLimit (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.HistoryMessageLimit);
		}
#pragma warning restore 0169

		static Delegate cb_setHistoryMessageLimit_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetHistoryMessageLimit_Ljava_lang_String_Handler ()
		{
			if (cb_setHistoryMessageLimit_Ljava_lang_String_ == null)
				cb_setHistoryMessageLimit_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetHistoryMessageLimit_Ljava_lang_String_);
			return cb_setHistoryMessageLimit_Ljava_lang_String_;
		}

		static void n_SetHistoryMessageLimit_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.HistoryMessageLimit = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getHistoryMessageLimit;
		static IntPtr id_setHistoryMessageLimit_Ljava_lang_String_;
		public virtual unsafe string HistoryMessageLimit {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getHistoryMessageLimit' and count(parameter)=0]"
			[Register ("getHistoryMessageLimit", "()Ljava/lang/String;", "GetGetHistoryMessageLimitHandler")]
			get {
				if (id_getHistoryMessageLimit == IntPtr.Zero)
					id_getHistoryMessageLimit = JNIEnv.GetMethodID (class_ref, "getHistoryMessageLimit", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHistoryMessageLimit), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHistoryMessageLimit", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setHistoryMessageLimit' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setHistoryMessageLimit", "(Ljava/lang/String;)V", "GetSetHistoryMessageLimit_Ljava_lang_String_Handler")]
			set {
				if (id_setHistoryMessageLimit_Ljava_lang_String_ == IntPtr.Zero)
					id_setHistoryMessageLimit_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setHistoryMessageLimit", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHistoryMessageLimit_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setHistoryMessageLimit", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getHomepageURL;
#pragma warning disable 0169
		static Delegate GetGetHomepageURLHandler ()
		{
			if (cb_getHomepageURL == null)
				cb_getHomepageURL = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHomepageURL);
			return cb_getHomepageURL;
		}

		static IntPtr n_GetHomepageURL (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.HomepageURL);
		}
#pragma warning restore 0169

		static Delegate cb_setHomepageURL_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetHomepageURL_Ljava_lang_String_Handler ()
		{
			if (cb_setHomepageURL_Ljava_lang_String_ == null)
				cb_setHomepageURL_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetHomepageURL_Ljava_lang_String_);
			return cb_setHomepageURL_Ljava_lang_String_;
		}

		static void n_SetHomepageURL_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.HomepageURL = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getHomepageURL;
		static IntPtr id_setHomepageURL_Ljava_lang_String_;
		public virtual unsafe string HomepageURL {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getHomepageURL' and count(parameter)=0]"
			[Register ("getHomepageURL", "()Ljava/lang/String;", "GetGetHomepageURLHandler")]
			get {
				if (id_getHomepageURL == IntPtr.Zero)
					id_getHomepageURL = JNIEnv.GetMethodID (class_ref, "getHomepageURL", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHomepageURL), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHomepageURL", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setHomepageURL' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setHomepageURL", "(Ljava/lang/String;)V", "GetSetHomepageURL_Ljava_lang_String_Handler")]
			set {
				if (id_setHomepageURL_Ljava_lang_String_ == IntPtr.Zero)
					id_setHomepageURL_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setHomepageURL", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHomepageURL_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setHomepageURL", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getIdleTimeout;
#pragma warning disable 0169
		static Delegate GetGetIdleTimeoutHandler ()
		{
			if (cb_getIdleTimeout == null)
				cb_getIdleTimeout = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetIdleTimeout);
			return cb_getIdleTimeout;
		}

		static IntPtr n_GetIdleTimeout (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.IdleTimeout);
		}
#pragma warning restore 0169

		static Delegate cb_setIdleTimeout_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetIdleTimeout_Ljava_lang_String_Handler ()
		{
			if (cb_setIdleTimeout_Ljava_lang_String_ == null)
				cb_setIdleTimeout_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetIdleTimeout_Ljava_lang_String_);
			return cb_setIdleTimeout_Ljava_lang_String_;
		}

		static void n_SetIdleTimeout_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.IdleTimeout = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getIdleTimeout;
		static IntPtr id_setIdleTimeout_Ljava_lang_String_;
		public virtual unsafe string IdleTimeout {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getIdleTimeout' and count(parameter)=0]"
			[Register ("getIdleTimeout", "()Ljava/lang/String;", "GetGetIdleTimeoutHandler")]
			get {
				if (id_getIdleTimeout == IntPtr.Zero)
					id_getIdleTimeout = JNIEnv.GetMethodID (class_ref, "getIdleTimeout", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getIdleTimeout), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getIdleTimeout", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setIdleTimeout' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setIdleTimeout", "(Ljava/lang/String;)V", "GetSetIdleTimeout_Ljava_lang_String_Handler")]
			set {
				if (id_setIdleTimeout_Ljava_lang_String_ == IntPtr.Zero)
					id_setIdleTimeout_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setIdleTimeout", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setIdleTimeout_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setIdleTimeout", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getInviteViaSms;
#pragma warning disable 0169
		static Delegate GetGetInviteViaSmsHandler ()
		{
			if (cb_getInviteViaSms == null)
				cb_getInviteViaSms = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInviteViaSms);
			return cb_getInviteViaSms;
		}

		static IntPtr n_GetInviteViaSms (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.InviteViaSms);
		}
#pragma warning restore 0169

		static Delegate cb_setInviteViaSms_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetInviteViaSms_Ljava_lang_String_Handler ()
		{
			if (cb_setInviteViaSms_Ljava_lang_String_ == null)
				cb_setInviteViaSms_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetInviteViaSms_Ljava_lang_String_);
			return cb_setInviteViaSms_Ljava_lang_String_;
		}

		static void n_SetInviteViaSms_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.InviteViaSms = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getInviteViaSms;
		static IntPtr id_setInviteViaSms_Ljava_lang_String_;
		public virtual unsafe string InviteViaSms {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getInviteViaSms' and count(parameter)=0]"
			[Register ("getInviteViaSms", "()Ljava/lang/String;", "GetGetInviteViaSmsHandler")]
			get {
				if (id_getInviteViaSms == IntPtr.Zero)
					id_getInviteViaSms = JNIEnv.GetMethodID (class_ref, "getInviteViaSms", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInviteViaSms), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInviteViaSms", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setInviteViaSms' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setInviteViaSms", "(Ljava/lang/String;)V", "GetSetInviteViaSms_Ljava_lang_String_Handler")]
			set {
				if (id_setInviteViaSms_Ljava_lang_String_ == IntPtr.Zero)
					id_setInviteViaSms_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setInviteViaSms", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setInviteViaSms_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setInviteViaSms", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getKEYA;
#pragma warning disable 0169
		static Delegate GetGetKEYAHandler ()
		{
			if (cb_getKEYA == null)
				cb_getKEYA = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetKEYA);
			return cb_getKEYA;
		}

		static IntPtr n_GetKEYA (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.KEYA);
		}
#pragma warning restore 0169

		static Delegate cb_setKEYA_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetKEYA_Ljava_lang_String_Handler ()
		{
			if (cb_setKEYA_Ljava_lang_String_ == null)
				cb_setKEYA_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetKEYA_Ljava_lang_String_);
			return cb_setKEYA_Ljava_lang_String_;
		}

		static void n_SetKEYA_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.KEYA = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getKEYA;
		static IntPtr id_setKEYA_Ljava_lang_String_;
		public virtual unsafe string KEYA {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getKEYA' and count(parameter)=0]"
			[Register ("getKEYA", "()Ljava/lang/String;", "GetGetKEYAHandler")]
			get {
				if (id_getKEYA == IntPtr.Zero)
					id_getKEYA = JNIEnv.GetMethodID (class_ref, "getKEYA", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getKEYA), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getKEYA", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setKEYA' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setKEYA", "(Ljava/lang/String;)V", "GetSetKEYA_Ljava_lang_String_Handler")]
			set {
				if (id_setKEYA_Ljava_lang_String_ == IntPtr.Zero)
					id_setKEYA_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setKEYA", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setKEYA_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setKEYA", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getKEYB;
#pragma warning disable 0169
		static Delegate GetGetKEYBHandler ()
		{
			if (cb_getKEYB == null)
				cb_getKEYB = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetKEYB);
			return cb_getKEYB;
		}

		static IntPtr n_GetKEYB (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.KEYB);
		}
#pragma warning restore 0169

		static Delegate cb_setKEYB_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetKEYB_Ljava_lang_String_Handler ()
		{
			if (cb_setKEYB_Ljava_lang_String_ == null)
				cb_setKEYB_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetKEYB_Ljava_lang_String_);
			return cb_setKEYB_Ljava_lang_String_;
		}

		static void n_SetKEYB_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.KEYB = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getKEYB;
		static IntPtr id_setKEYB_Ljava_lang_String_;
		public virtual unsafe string KEYB {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getKEYB' and count(parameter)=0]"
			[Register ("getKEYB", "()Ljava/lang/String;", "GetGetKEYBHandler")]
			get {
				if (id_getKEYB == IntPtr.Zero)
					id_getKEYB = JNIEnv.GetMethodID (class_ref, "getKEYB", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getKEYB), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getKEYB", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setKEYB' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setKEYB", "(Ljava/lang/String;)V", "GetSetKEYB_Ljava_lang_String_Handler")]
			set {
				if (id_setKEYB_Ljava_lang_String_ == IntPtr.Zero)
					id_setKEYB_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setKEYB", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setKEYB_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setKEYB", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getKEYC;
#pragma warning disable 0169
		static Delegate GetGetKEYCHandler ()
		{
			if (cb_getKEYC == null)
				cb_getKEYC = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetKEYC);
			return cb_getKEYC;
		}

		static IntPtr n_GetKEYC (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.KEYC);
		}
#pragma warning restore 0169

		static Delegate cb_setKEYC_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetKEYC_Ljava_lang_String_Handler ()
		{
			if (cb_setKEYC_Ljava_lang_String_ == null)
				cb_setKEYC_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetKEYC_Ljava_lang_String_);
			return cb_setKEYC_Ljava_lang_String_;
		}

		static void n_SetKEYC_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.KEYC = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getKEYC;
		static IntPtr id_setKEYC_Ljava_lang_String_;
		public virtual unsafe string KEYC {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getKEYC' and count(parameter)=0]"
			[Register ("getKEYC", "()Ljava/lang/String;", "GetGetKEYCHandler")]
			get {
				if (id_getKEYC == IntPtr.Zero)
					id_getKEYC = JNIEnv.GetMethodID (class_ref, "getKEYC", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getKEYC), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getKEYC", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setKEYC' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setKEYC", "(Ljava/lang/String;)V", "GetSetKEYC_Ljava_lang_String_Handler")]
			set {
				if (id_setKEYC_Ljava_lang_String_ == IntPtr.Zero)
					id_setKEYC_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setKEYC", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setKEYC_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setKEYC", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getMaxHeartbeat;
#pragma warning disable 0169
		static Delegate GetGetMaxHeartbeatHandler ()
		{
			if (cb_getMaxHeartbeat == null)
				cb_getMaxHeartbeat = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMaxHeartbeat);
			return cb_getMaxHeartbeat;
		}

		static IntPtr n_GetMaxHeartbeat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.MaxHeartbeat);
		}
#pragma warning restore 0169

		static Delegate cb_setMaxHeartbeat_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetMaxHeartbeat_Ljava_lang_String_Handler ()
		{
			if (cb_setMaxHeartbeat_Ljava_lang_String_ == null)
				cb_setMaxHeartbeat_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMaxHeartbeat_Ljava_lang_String_);
			return cb_setMaxHeartbeat_Ljava_lang_String_;
		}

		static void n_SetMaxHeartbeat_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.MaxHeartbeat = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMaxHeartbeat;
		static IntPtr id_setMaxHeartbeat_Ljava_lang_String_;
		public virtual unsafe string MaxHeartbeat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getMaxHeartbeat' and count(parameter)=0]"
			[Register ("getMaxHeartbeat", "()Ljava/lang/String;", "GetGetMaxHeartbeatHandler")]
			get {
				if (id_getMaxHeartbeat == IntPtr.Zero)
					id_getMaxHeartbeat = JNIEnv.GetMethodID (class_ref, "getMaxHeartbeat", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMaxHeartbeat), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMaxHeartbeat", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setMaxHeartbeat' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setMaxHeartbeat", "(Ljava/lang/String;)V", "GetSetMaxHeartbeat_Ljava_lang_String_Handler")]
			set {
				if (id_setMaxHeartbeat_Ljava_lang_String_ == IntPtr.Zero)
					id_setMaxHeartbeat_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setMaxHeartbeat", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMaxHeartbeat_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMaxHeartbeat", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getMessageBeep;
#pragma warning disable 0169
		static Delegate GetGetMessageBeepHandler ()
		{
			if (cb_getMessageBeep == null)
				cb_getMessageBeep = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMessageBeep);
			return cb_getMessageBeep;
		}

		static IntPtr n_GetMessageBeep (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.MessageBeep);
		}
#pragma warning restore 0169

		static Delegate cb_setMessageBeep_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetMessageBeep_Ljava_lang_String_Handler ()
		{
			if (cb_setMessageBeep_Ljava_lang_String_ == null)
				cb_setMessageBeep_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMessageBeep_Ljava_lang_String_);
			return cb_setMessageBeep_Ljava_lang_String_;
		}

		static void n_SetMessageBeep_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.MessageBeep = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMessageBeep;
		static IntPtr id_setMessageBeep_Ljava_lang_String_;
		public virtual unsafe string MessageBeep {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getMessageBeep' and count(parameter)=0]"
			[Register ("getMessageBeep", "()Ljava/lang/String;", "GetGetMessageBeepHandler")]
			get {
				if (id_getMessageBeep == IntPtr.Zero)
					id_getMessageBeep = JNIEnv.GetMethodID (class_ref, "getMessageBeep", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMessageBeep), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMessageBeep", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setMessageBeep' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setMessageBeep", "(Ljava/lang/String;)V", "GetSetMessageBeep_Ljava_lang_String_Handler")]
			set {
				if (id_setMessageBeep_Ljava_lang_String_ == IntPtr.Zero)
					id_setMessageBeep_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setMessageBeep", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMessageBeep_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMessageBeep", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getMinHeartbeat;
#pragma warning disable 0169
		static Delegate GetGetMinHeartbeatHandler ()
		{
			if (cb_getMinHeartbeat == null)
				cb_getMinHeartbeat = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMinHeartbeat);
			return cb_getMinHeartbeat;
		}

		static IntPtr n_GetMinHeartbeat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.MinHeartbeat);
		}
#pragma warning restore 0169

		static Delegate cb_setMinHeartbeat_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetMinHeartbeat_Ljava_lang_String_Handler ()
		{
			if (cb_setMinHeartbeat_Ljava_lang_String_ == null)
				cb_setMinHeartbeat_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMinHeartbeat_Ljava_lang_String_);
			return cb_setMinHeartbeat_Ljava_lang_String_;
		}

		static void n_SetMinHeartbeat_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.MinHeartbeat = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMinHeartbeat;
		static IntPtr id_setMinHeartbeat_Ljava_lang_String_;
		public virtual unsafe string MinHeartbeat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getMinHeartbeat' and count(parameter)=0]"
			[Register ("getMinHeartbeat", "()Ljava/lang/String;", "GetGetMinHeartbeatHandler")]
			get {
				if (id_getMinHeartbeat == IntPtr.Zero)
					id_getMinHeartbeat = JNIEnv.GetMethodID (class_ref, "getMinHeartbeat", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMinHeartbeat), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMinHeartbeat", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setMinHeartbeat' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setMinHeartbeat", "(Ljava/lang/String;)V", "GetSetMinHeartbeat_Ljava_lang_String_Handler")]
			set {
				if (id_setMinHeartbeat_Ljava_lang_String_ == IntPtr.Zero)
					id_setMinHeartbeat_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setMinHeartbeat", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMinHeartbeat_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMinHeartbeat", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getOneononeEnabled;
#pragma warning disable 0169
		static Delegate GetGetOneononeEnabledHandler ()
		{
			if (cb_getOneononeEnabled == null)
				cb_getOneononeEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetOneononeEnabled);
			return cb_getOneononeEnabled;
		}

		static IntPtr n_GetOneononeEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.OneononeEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setOneononeEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetOneononeEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setOneononeEnabled_Ljava_lang_String_ == null)
				cb_setOneononeEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetOneononeEnabled_Ljava_lang_String_);
			return cb_setOneononeEnabled_Ljava_lang_String_;
		}

		static void n_SetOneononeEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OneononeEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getOneononeEnabled;
		static IntPtr id_setOneononeEnabled_Ljava_lang_String_;
		public virtual unsafe string OneononeEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getOneononeEnabled' and count(parameter)=0]"
			[Register ("getOneononeEnabled", "()Ljava/lang/String;", "GetGetOneononeEnabledHandler")]
			get {
				if (id_getOneononeEnabled == IntPtr.Zero)
					id_getOneononeEnabled = JNIEnv.GetMethodID (class_ref, "getOneononeEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getOneononeEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getOneononeEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setOneononeEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setOneononeEnabled", "(Ljava/lang/String;)V", "GetSetOneononeEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setOneononeEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setOneononeEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setOneononeEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOneononeEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOneononeEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getREFRESHBUDDYLIST;
#pragma warning disable 0169
		static Delegate GetGetREFRESHBUDDYLISTHandler ()
		{
			if (cb_getREFRESHBUDDYLIST == null)
				cb_getREFRESHBUDDYLIST = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetREFRESHBUDDYLIST);
			return cb_getREFRESHBUDDYLIST;
		}

		static IntPtr n_GetREFRESHBUDDYLIST (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.REFRESHBUDDYLIST);
		}
#pragma warning restore 0169

		static Delegate cb_setREFRESHBUDDYLIST_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetREFRESHBUDDYLIST_Ljava_lang_String_Handler ()
		{
			if (cb_setREFRESHBUDDYLIST_Ljava_lang_String_ == null)
				cb_setREFRESHBUDDYLIST_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetREFRESHBUDDYLIST_Ljava_lang_String_);
			return cb_setREFRESHBUDDYLIST_Ljava_lang_String_;
		}

		static void n_SetREFRESHBUDDYLIST_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.REFRESHBUDDYLIST = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getREFRESHBUDDYLIST;
		static IntPtr id_setREFRESHBUDDYLIST_Ljava_lang_String_;
		public virtual unsafe string REFRESHBUDDYLIST {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getREFRESHBUDDYLIST' and count(parameter)=0]"
			[Register ("getREFRESHBUDDYLIST", "()Ljava/lang/String;", "GetGetREFRESHBUDDYLISTHandler")]
			get {
				if (id_getREFRESHBUDDYLIST == IntPtr.Zero)
					id_getREFRESHBUDDYLIST = JNIEnv.GetMethodID (class_ref, "getREFRESHBUDDYLIST", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getREFRESHBUDDYLIST), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getREFRESHBUDDYLIST", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setREFRESHBUDDYLIST' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setREFRESHBUDDYLIST", "(Ljava/lang/String;)V", "GetSetREFRESHBUDDYLIST_Ljava_lang_String_Handler")]
			set {
				if (id_setREFRESHBUDDYLIST_Ljava_lang_String_ == IntPtr.Zero)
					id_setREFRESHBUDDYLIST_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setREFRESHBUDDYLIST", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setREFRESHBUDDYLIST_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setREFRESHBUDDYLIST", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getRttKey;
#pragma warning disable 0169
		static Delegate GetGetRttKeyHandler ()
		{
			if (cb_getRttKey == null)
				cb_getRttKey = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRttKey);
			return cb_getRttKey;
		}

		static IntPtr n_GetRttKey (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RttKey);
		}
#pragma warning restore 0169

		static Delegate cb_setRttKey_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetRttKey_Ljava_lang_String_Handler ()
		{
			if (cb_setRttKey_Ljava_lang_String_ == null)
				cb_setRttKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetRttKey_Ljava_lang_String_);
			return cb_setRttKey_Ljava_lang_String_;
		}

		static void n_SetRttKey_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RttKey = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getRttKey;
		static IntPtr id_setRttKey_Ljava_lang_String_;
		public virtual unsafe string RttKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getRttKey' and count(parameter)=0]"
			[Register ("getRttKey", "()Ljava/lang/String;", "GetGetRttKeyHandler")]
			get {
				if (id_getRttKey == IntPtr.Zero)
					id_getRttKey = JNIEnv.GetMethodID (class_ref, "getRttKey", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRttKey), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRttKey", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setRttKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setRttKey", "(Ljava/lang/String;)V", "GetSetRttKey_Ljava_lang_String_Handler")]
			set {
				if (id_setRttKey_Ljava_lang_String_ == IntPtr.Zero)
					id_setRttKey_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setRttKey", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRttKey_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setRttKey", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getShareThisApp;
#pragma warning disable 0169
		static Delegate GetGetShareThisAppHandler ()
		{
			if (cb_getShareThisApp == null)
				cb_getShareThisApp = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetShareThisApp);
			return cb_getShareThisApp;
		}

		static IntPtr n_GetShareThisApp (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ShareThisApp);
		}
#pragma warning restore 0169

		static Delegate cb_setShareThisApp_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetShareThisApp_Ljava_lang_String_Handler ()
		{
			if (cb_setShareThisApp_Ljava_lang_String_ == null)
				cb_setShareThisApp_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetShareThisApp_Ljava_lang_String_);
			return cb_setShareThisApp_Ljava_lang_String_;
		}

		static void n_SetShareThisApp_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ShareThisApp = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getShareThisApp;
		static IntPtr id_setShareThisApp_Ljava_lang_String_;
		public virtual unsafe string ShareThisApp {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getShareThisApp' and count(parameter)=0]"
			[Register ("getShareThisApp", "()Ljava/lang/String;", "GetGetShareThisAppHandler")]
			get {
				if (id_getShareThisApp == IntPtr.Zero)
					id_getShareThisApp = JNIEnv.GetMethodID (class_ref, "getShareThisApp", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getShareThisApp), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getShareThisApp", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setShareThisApp' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setShareThisApp", "(Ljava/lang/String;)V", "GetSetShareThisApp_Ljava_lang_String_Handler")]
			set {
				if (id_setShareThisApp_Ljava_lang_String_ == IntPtr.Zero)
					id_setShareThisApp_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setShareThisApp", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShareThisApp_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShareThisApp", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getSingleGamesEnabled;
#pragma warning disable 0169
		static Delegate GetGetSingleGamesEnabledHandler ()
		{
			if (cb_getSingleGamesEnabled == null)
				cb_getSingleGamesEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSingleGamesEnabled);
			return cb_getSingleGamesEnabled;
		}

		static IntPtr n_GetSingleGamesEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.SingleGamesEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setSingleGamesEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetSingleGamesEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setSingleGamesEnabled_Ljava_lang_String_ == null)
				cb_setSingleGamesEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetSingleGamesEnabled_Ljava_lang_String_);
			return cb_setSingleGamesEnabled_Ljava_lang_String_;
		}

		static void n_SetSingleGamesEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SingleGamesEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getSingleGamesEnabled;
		static IntPtr id_setSingleGamesEnabled_Ljava_lang_String_;
		public virtual unsafe string SingleGamesEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getSingleGamesEnabled' and count(parameter)=0]"
			[Register ("getSingleGamesEnabled", "()Ljava/lang/String;", "GetGetSingleGamesEnabledHandler")]
			get {
				if (id_getSingleGamesEnabled == IntPtr.Zero)
					id_getSingleGamesEnabled = JNIEnv.GetMethodID (class_ref, "getSingleGamesEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSingleGamesEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSingleGamesEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setSingleGamesEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setSingleGamesEnabled", "(Ljava/lang/String;)V", "GetSetSingleGamesEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setSingleGamesEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setSingleGamesEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setSingleGamesEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSingleGamesEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSingleGamesEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getStickersEnabled;
#pragma warning disable 0169
		static Delegate GetGetStickersEnabledHandler ()
		{
			if (cb_getStickersEnabled == null)
				cb_getStickersEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetStickersEnabled);
			return cb_getStickersEnabled;
		}

		static IntPtr n_GetStickersEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.StickersEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setStickersEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetStickersEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setStickersEnabled_Ljava_lang_String_ == null)
				cb_setStickersEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetStickersEnabled_Ljava_lang_String_);
			return cb_setStickersEnabled_Ljava_lang_String_;
		}

		static void n_SetStickersEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StickersEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getStickersEnabled;
		static IntPtr id_setStickersEnabled_Ljava_lang_String_;
		public virtual unsafe string StickersEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getStickersEnabled' and count(parameter)=0]"
			[Register ("getStickersEnabled", "()Ljava/lang/String;", "GetGetStickersEnabledHandler")]
			get {
				if (id_getStickersEnabled == IntPtr.Zero)
					id_getStickersEnabled = JNIEnv.GetMethodID (class_ref, "getStickersEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getStickersEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStickersEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setStickersEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setStickersEnabled", "(Ljava/lang/String;)V", "GetSetStickersEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setStickersEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setStickersEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setStickersEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setStickersEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStickersEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getTRANSPORT;
#pragma warning disable 0169
		static Delegate GetGetTRANSPORTHandler ()
		{
			if (cb_getTRANSPORT == null)
				cb_getTRANSPORT = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTRANSPORT);
			return cb_getTRANSPORT;
		}

		static IntPtr n_GetTRANSPORT (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TRANSPORT);
		}
#pragma warning restore 0169

		static Delegate cb_setTRANSPORT_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetTRANSPORT_Ljava_lang_String_Handler ()
		{
			if (cb_setTRANSPORT_Ljava_lang_String_ == null)
				cb_setTRANSPORT_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetTRANSPORT_Ljava_lang_String_);
			return cb_setTRANSPORT_Ljava_lang_String_;
		}

		static void n_SetTRANSPORT_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.TRANSPORT = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getTRANSPORT;
		static IntPtr id_setTRANSPORT_Ljava_lang_String_;
		public virtual unsafe string TRANSPORT {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getTRANSPORT' and count(parameter)=0]"
			[Register ("getTRANSPORT", "()Ljava/lang/String;", "GetGetTRANSPORTHandler")]
			get {
				if (id_getTRANSPORT == IntPtr.Zero)
					id_getTRANSPORT = JNIEnv.GetMethodID (class_ref, "getTRANSPORT", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTRANSPORT), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTRANSPORT", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setTRANSPORT' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setTRANSPORT", "(Ljava/lang/String;)V", "GetSetTRANSPORT_Ljava_lang_String_Handler")]
			set {
				if (id_setTRANSPORT_Ljava_lang_String_ == IntPtr.Zero)
					id_setTRANSPORT_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setTRANSPORT", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setTRANSPORT_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setTRANSPORT", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getUSECOMET;
#pragma warning disable 0169
		static Delegate GetGetUSECOMETHandler ()
		{
			if (cb_getUSECOMET == null)
				cb_getUSECOMET = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUSECOMET);
			return cb_getUSECOMET;
		}

		static IntPtr n_GetUSECOMET (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.USECOMET);
		}
#pragma warning restore 0169

		static Delegate cb_setUSECOMET_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetUSECOMET_Ljava_lang_String_Handler ()
		{
			if (cb_setUSECOMET_Ljava_lang_String_ == null)
				cb_setUSECOMET_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetUSECOMET_Ljava_lang_String_);
			return cb_setUSECOMET_Ljava_lang_String_;
		}

		static void n_SetUSECOMET_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.USECOMET = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getUSECOMET;
		static IntPtr id_setUSECOMET_Ljava_lang_String_;
		public virtual unsafe string USECOMET {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getUSECOMET' and count(parameter)=0]"
			[Register ("getUSECOMET", "()Ljava/lang/String;", "GetGetUSECOMETHandler")]
			get {
				if (id_getUSECOMET == IntPtr.Zero)
					id_getUSECOMET = JNIEnv.GetMethodID (class_ref, "getUSECOMET", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUSECOMET), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUSECOMET", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setUSECOMET' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setUSECOMET", "(Ljava/lang/String;)V", "GetSetUSECOMET_Ljava_lang_String_Handler")]
			set {
				if (id_setUSECOMET_Ljava_lang_String_ == IntPtr.Zero)
					id_setUSECOMET_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setUSECOMET", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUSECOMET_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setUSECOMET", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getVibrate;
#pragma warning disable 0169
		static Delegate GetGetVibrateHandler ()
		{
			if (cb_getVibrate == null)
				cb_getVibrate = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetVibrate);
			return cb_getVibrate;
		}

		static IntPtr n_GetVibrate (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Vibrate);
		}
#pragma warning restore 0169

		static Delegate cb_setVibrate_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetVibrate_Ljava_lang_String_Handler ()
		{
			if (cb_setVibrate_Ljava_lang_String_ == null)
				cb_setVibrate_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetVibrate_Ljava_lang_String_);
			return cb_setVibrate_Ljava_lang_String_;
		}

		static void n_SetVibrate_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Vibrate = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getVibrate;
		static IntPtr id_setVibrate_Ljava_lang_String_;
		public virtual unsafe string Vibrate {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getVibrate' and count(parameter)=0]"
			[Register ("getVibrate", "()Ljava/lang/String;", "GetGetVibrateHandler")]
			get {
				if (id_getVibrate == IntPtr.Zero)
					id_getVibrate = JNIEnv.GetMethodID (class_ref, "getVibrate", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVibrate), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getVibrate", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setVibrate' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setVibrate", "(Ljava/lang/String;)V", "GetSetVibrate_Ljava_lang_String_Handler")]
			set {
				if (id_setVibrate_Ljava_lang_String_ == IntPtr.Zero)
					id_setVibrate_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setVibrate", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVibrate_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVibrate", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWhiteboardEnabled;
#pragma warning disable 0169
		static Delegate GetGetWhiteboardEnabledHandler ()
		{
			if (cb_getWhiteboardEnabled == null)
				cb_getWhiteboardEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWhiteboardEnabled);
			return cb_getWhiteboardEnabled;
		}

		static IntPtr n_GetWhiteboardEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WhiteboardEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setWhiteboardEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWhiteboardEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setWhiteboardEnabled_Ljava_lang_String_ == null)
				cb_setWhiteboardEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWhiteboardEnabled_Ljava_lang_String_);
			return cb_setWhiteboardEnabled_Ljava_lang_String_;
		}

		static void n_SetWhiteboardEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.WhiteboardEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWhiteboardEnabled;
		static IntPtr id_setWhiteboardEnabled_Ljava_lang_String_;
		public virtual unsafe string WhiteboardEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getWhiteboardEnabled' and count(parameter)=0]"
			[Register ("getWhiteboardEnabled", "()Ljava/lang/String;", "GetGetWhiteboardEnabledHandler")]
			get {
				if (id_getWhiteboardEnabled == IntPtr.Zero)
					id_getWhiteboardEnabled = JNIEnv.GetMethodID (class_ref, "getWhiteboardEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWhiteboardEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWhiteboardEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setWhiteboardEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setWhiteboardEnabled", "(Ljava/lang/String;)V", "GetSetWhiteboardEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setWhiteboardEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setWhiteboardEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWhiteboardEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWhiteboardEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWhiteboardEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWhiteboardUrl;
#pragma warning disable 0169
		static Delegate GetGetWhiteboardUrlHandler ()
		{
			if (cb_getWhiteboardUrl == null)
				cb_getWhiteboardUrl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWhiteboardUrl);
			return cb_getWhiteboardUrl;
		}

		static IntPtr n_GetWhiteboardUrl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WhiteboardUrl);
		}
#pragma warning restore 0169

		static Delegate cb_setWhiteboardUrl_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWhiteboardUrl_Ljava_lang_String_Handler ()
		{
			if (cb_setWhiteboardUrl_Ljava_lang_String_ == null)
				cb_setWhiteboardUrl_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWhiteboardUrl_Ljava_lang_String_);
			return cb_setWhiteboardUrl_Ljava_lang_String_;
		}

		static void n_SetWhiteboardUrl_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.WhiteboardUrl = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWhiteboardUrl;
		static IntPtr id_setWhiteboardUrl_Ljava_lang_String_;
		public virtual unsafe string WhiteboardUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getWhiteboardUrl' and count(parameter)=0]"
			[Register ("getWhiteboardUrl", "()Ljava/lang/String;", "GetGetWhiteboardUrlHandler")]
			get {
				if (id_getWhiteboardUrl == IntPtr.Zero)
					id_getWhiteboardUrl = JNIEnv.GetMethodID (class_ref, "getWhiteboardUrl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWhiteboardUrl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWhiteboardUrl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setWhiteboardUrl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setWhiteboardUrl", "(Ljava/lang/String;)V", "GetSetWhiteboardUrl_Ljava_lang_String_Handler")]
			set {
				if (id_setWhiteboardUrl_Ljava_lang_String_ == IntPtr.Zero)
					id_setWhiteboardUrl_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWhiteboardUrl", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWhiteboardUrl_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWhiteboardUrl", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWriteboardEnabled;
#pragma warning disable 0169
		static Delegate GetGetWriteboardEnabledHandler ()
		{
			if (cb_getWriteboardEnabled == null)
				cb_getWriteboardEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWriteboardEnabled);
			return cb_getWriteboardEnabled;
		}

		static IntPtr n_GetWriteboardEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WriteboardEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setWriteboardEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWriteboardEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setWriteboardEnabled_Ljava_lang_String_ == null)
				cb_setWriteboardEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWriteboardEnabled_Ljava_lang_String_);
			return cb_setWriteboardEnabled_Ljava_lang_String_;
		}

		static void n_SetWriteboardEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.WriteboardEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWriteboardEnabled;
		static IntPtr id_setWriteboardEnabled_Ljava_lang_String_;
		public virtual unsafe string WriteboardEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getWriteboardEnabled' and count(parameter)=0]"
			[Register ("getWriteboardEnabled", "()Ljava/lang/String;", "GetGetWriteboardEnabledHandler")]
			get {
				if (id_getWriteboardEnabled == IntPtr.Zero)
					id_getWriteboardEnabled = JNIEnv.GetMethodID (class_ref, "getWriteboardEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWriteboardEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWriteboardEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setWriteboardEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setWriteboardEnabled", "(Ljava/lang/String;)V", "GetSetWriteboardEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setWriteboardEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setWriteboardEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWriteboardEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWriteboardEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWriteboardEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWriteboardUrl;
#pragma warning disable 0169
		static Delegate GetGetWriteboardUrlHandler ()
		{
			if (cb_getWriteboardUrl == null)
				cb_getWriteboardUrl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWriteboardUrl);
			return cb_getWriteboardUrl;
		}

		static IntPtr n_GetWriteboardUrl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WriteboardUrl);
		}
#pragma warning restore 0169

		static IntPtr id_getWriteboardUrl;
		public virtual unsafe string WriteboardUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getWriteboardUrl' and count(parameter)=0]"
			[Register ("getWriteboardUrl", "()Ljava/lang/String;", "GetGetWriteboardUrlHandler")]
			get {
				if (id_getWriteboardUrl == IntPtr.Zero)
					id_getWriteboardUrl = JNIEnv.GetMethodID (class_ref, "getWriteboardUrl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWriteboardUrl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWriteboardUrl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getlastseenEnabled;
#pragma warning disable 0169
		static Delegate GetGetlastseenEnabledHandler ()
		{
			if (cb_getlastseenEnabled == null)
				cb_getlastseenEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetlastseenEnabled);
			return cb_getlastseenEnabled;
		}

		static IntPtr n_GetlastseenEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetlastseenEnabled ());
		}
#pragma warning restore 0169

		static IntPtr id_getlastseenEnabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getlastseenEnabled' and count(parameter)=0]"
		[Register ("getlastseenEnabled", "()Ljava/lang/String;", "GetGetlastseenEnabledHandler")]
		public virtual unsafe string GetlastseenEnabled ()
		{
			if (id_getlastseenEnabled == IntPtr.Zero)
				id_getlastseenEnabled = JNIEnv.GetMethodID (class_ref, "getlastseenEnabled", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getlastseenEnabled), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getlastseenEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_getreceiptsEnabled;
#pragma warning disable 0169
		static Delegate GetGetreceiptsEnabledHandler ()
		{
			if (cb_getreceiptsEnabled == null)
				cb_getreceiptsEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetreceiptsEnabled);
			return cb_getreceiptsEnabled;
		}

		static IntPtr n_GetreceiptsEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetreceiptsEnabled ());
		}
#pragma warning restore 0169

		static IntPtr id_getreceiptsEnabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='getreceiptsEnabled' and count(parameter)=0]"
		[Register ("getreceiptsEnabled", "()Ljava/lang/String;", "GetGetreceiptsEnabledHandler")]
		public virtual unsafe string GetreceiptsEnabled ()
		{
			if (id_getreceiptsEnabled == IntPtr.Zero)
				id_getreceiptsEnabled = JNIEnv.GetMethodID (class_ref, "getreceiptsEnabled", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getreceiptsEnabled), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getreceiptsEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_gettypingEnabled;
#pragma warning disable 0169
		static Delegate GetGettypingEnabledHandler ()
		{
			if (cb_gettypingEnabled == null)
				cb_gettypingEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GettypingEnabled);
			return cb_gettypingEnabled;
		}

		static IntPtr n_GettypingEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GettypingEnabled ());
		}
#pragma warning restore 0169

		static IntPtr id_gettypingEnabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='gettypingEnabled' and count(parameter)=0]"
		[Register ("gettypingEnabled", "()Ljava/lang/String;", "GetGettypingEnabledHandler")]
		public virtual unsafe string GettypingEnabled ()
		{
			if (id_gettypingEnabled == IntPtr.Zero)
				id_gettypingEnabled = JNIEnv.GetMethodID (class_ref, "gettypingEnabled", "()Ljava/lang/String;");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_gettypingEnabled), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "gettypingEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_setWriteboardurl_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWriteboardurl_Ljava_lang_String_Handler ()
		{
			if (cb_setWriteboardurl_Ljava_lang_String_ == null)
				cb_setWriteboardurl_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWriteboardurl_Ljava_lang_String_);
			return cb_setWriteboardurl_Ljava_lang_String_;
		}

		static void n_SetWriteboardurl_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetWriteboardurl (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setWriteboardurl_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setWriteboardurl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setWriteboardurl", "(Ljava/lang/String;)V", "GetSetWriteboardurl_Ljava_lang_String_Handler")]
		public virtual unsafe void SetWriteboardurl (string p0)
		{
			if (id_setWriteboardurl_Ljava_lang_String_ == IntPtr.Zero)
				id_setWriteboardurl_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWriteboardurl", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWriteboardurl_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWriteboardurl", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setlastseenEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetlastseenEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setlastseenEnabled_Ljava_lang_String_ == null)
				cb_setlastseenEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetlastseenEnabled_Ljava_lang_String_);
			return cb_setlastseenEnabled_Ljava_lang_String_;
		}

		static void n_SetlastseenEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetlastseenEnabled (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setlastseenEnabled_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setlastseenEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setlastseenEnabled", "(Ljava/lang/String;)V", "GetSetlastseenEnabled_Ljava_lang_String_Handler")]
		public virtual unsafe void SetlastseenEnabled (string p0)
		{
			if (id_setlastseenEnabled_Ljava_lang_String_ == IntPtr.Zero)
				id_setlastseenEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setlastseenEnabled", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setlastseenEnabled_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setlastseenEnabled", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setreceiptsEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetreceiptsEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setreceiptsEnabled_Ljava_lang_String_ == null)
				cb_setreceiptsEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetreceiptsEnabled_Ljava_lang_String_);
			return cb_setreceiptsEnabled_Ljava_lang_String_;
		}

		static void n_SetreceiptsEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetreceiptsEnabled (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setreceiptsEnabled_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='setreceiptsEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setreceiptsEnabled", "(Ljava/lang/String;)V", "GetSetreceiptsEnabled_Ljava_lang_String_Handler")]
		public virtual unsafe void SetreceiptsEnabled (string p0)
		{
			if (id_setreceiptsEnabled_Ljava_lang_String_ == IntPtr.Zero)
				id_setreceiptsEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setreceiptsEnabled", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setreceiptsEnabled_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setreceiptsEnabled", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_settypingEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSettypingEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_settypingEnabled_Ljava_lang_String_ == null)
				cb_settypingEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SettypingEnabled_Ljava_lang_String_);
			return cb_settypingEnabled_Ljava_lang_String_;
		}

		static void n_SettypingEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Config __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SettypingEnabled (p0);
		}
#pragma warning restore 0169

		static IntPtr id_settypingEnabled_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Config']/method[@name='settypingEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("settypingEnabled", "(Ljava/lang/String;)V", "GetSettypingEnabled_Ljava_lang_String_Handler")]
		public virtual unsafe void SettypingEnabled (string p0)
		{
			if (id_settypingEnabled_Ljava_lang_String_ == IntPtr.Zero)
				id_settypingEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "settypingEnabled", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_settypingEnabled_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "settypingEnabled", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
