using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/JsonPhp", DoNotGenerateAcw=true)]
	public partial class JsonPhp : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/JsonPhp", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (JsonPhp); }
		}

		protected JsonPhp (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/constructor[@name='JsonPhp' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe JsonPhp ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (JsonPhp)) {
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

		static Delegate cb_getAdUnitId;
#pragma warning disable 0169
		static Delegate GetGetAdUnitIdHandler ()
		{
			if (cb_getAdUnitId == null)
				cb_getAdUnitId = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAdUnitId);
			return cb_getAdUnitId;
		}

		static IntPtr n_GetAdUnitId (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AdUnitId);
		}
#pragma warning restore 0169

		static Delegate cb_setAdUnitId_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAdUnitId_Ljava_lang_String_Handler ()
		{
			if (cb_setAdUnitId_Ljava_lang_String_ == null)
				cb_setAdUnitId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAdUnitId_Ljava_lang_String_);
			return cb_setAdUnitId_Ljava_lang_String_;
		}

		static void n_SetAdUnitId_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AdUnitId = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAdUnitId;
		static IntPtr id_setAdUnitId_Ljava_lang_String_;
		public virtual unsafe string AdUnitId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getAdUnitId' and count(parameter)=0]"
			[Register ("getAdUnitId", "()Ljava/lang/String;", "GetGetAdUnitIdHandler")]
			get {
				if (id_getAdUnitId == IntPtr.Zero)
					id_getAdUnitId = JNIEnv.GetMethodID (class_ref, "getAdUnitId", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAdUnitId), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAdUnitId", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setAdUnitId' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAdUnitId", "(Ljava/lang/String;)V", "GetSetAdUnitId_Ljava_lang_String_Handler")]
			set {
				if (id_setAdUnitId_Ljava_lang_String_ == IntPtr.Zero)
					id_setAdUnitId_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAdUnitId", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAdUnitId_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAdUnitId", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAllowusersCreatechatroom;
#pragma warning disable 0169
		static Delegate GetGetAllowusersCreatechatroomHandler ()
		{
			if (cb_getAllowusersCreatechatroom == null)
				cb_getAllowusersCreatechatroom = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAllowusersCreatechatroom);
			return cb_getAllowusersCreatechatroom;
		}

		static IntPtr n_GetAllowusersCreatechatroom (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AllowusersCreatechatroom);
		}
#pragma warning restore 0169

		static Delegate cb_setAllowusersCreatechatroom_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAllowusersCreatechatroom_Ljava_lang_String_Handler ()
		{
			if (cb_setAllowusersCreatechatroom_Ljava_lang_String_ == null)
				cb_setAllowusersCreatechatroom_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAllowusersCreatechatroom_Ljava_lang_String_);
			return cb_setAllowusersCreatechatroom_Ljava_lang_String_;
		}

		static void n_SetAllowusersCreatechatroom_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AllowusersCreatechatroom = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAllowusersCreatechatroom;
		static IntPtr id_setAllowusersCreatechatroom_Ljava_lang_String_;
		public virtual unsafe string AllowusersCreatechatroom {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getAllowusersCreatechatroom' and count(parameter)=0]"
			[Register ("getAllowusersCreatechatroom", "()Ljava/lang/String;", "GetGetAllowusersCreatechatroomHandler")]
			get {
				if (id_getAllowusersCreatechatroom == IntPtr.Zero)
					id_getAllowusersCreatechatroom = JNIEnv.GetMethodID (class_ref, "getAllowusersCreatechatroom", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAllowusersCreatechatroom), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAllowusersCreatechatroom", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setAllowusersCreatechatroom' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAllowusersCreatechatroom", "(Ljava/lang/String;)V", "GetSetAllowusersCreatechatroom_Ljava_lang_String_Handler")]
			set {
				if (id_setAllowusersCreatechatroom_Ljava_lang_String_ == IntPtr.Zero)
					id_setAllowusersCreatechatroom_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAllowusersCreatechatroom", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAllowusersCreatechatroom_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAllowusersCreatechatroom", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAudiochatEnabled;
#pragma warning disable 0169
		static Delegate GetGetAudiochatEnabledHandler ()
		{
			if (cb_getAudiochatEnabled == null)
				cb_getAudiochatEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAudiochatEnabled);
			return cb_getAudiochatEnabled;
		}

		static IntPtr n_GetAudiochatEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AudiochatEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setAudiochatEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAudiochatEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setAudiochatEnabled_Ljava_lang_String_ == null)
				cb_setAudiochatEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAudiochatEnabled_Ljava_lang_String_);
			return cb_setAudiochatEnabled_Ljava_lang_String_;
		}

		static void n_SetAudiochatEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AudiochatEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAudiochatEnabled;
		static IntPtr id_setAudiochatEnabled_Ljava_lang_String_;
		public virtual unsafe string AudiochatEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getAudiochatEnabled' and count(parameter)=0]"
			[Register ("getAudiochatEnabled", "()Ljava/lang/String;", "GetGetAudiochatEnabledHandler")]
			get {
				if (id_getAudiochatEnabled == IntPtr.Zero)
					id_getAudiochatEnabled = JNIEnv.GetMethodID (class_ref, "getAudiochatEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudiochatEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAudiochatEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setAudiochatEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAudiochatEnabled", "(Ljava/lang/String;)V", "GetSetAudiochatEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setAudiochatEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setAudiochatEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAudiochatEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudiochatEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAudiochatEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAvchatEnabled;
#pragma warning disable 0169
		static Delegate GetGetAvchatEnabledHandler ()
		{
			if (cb_getAvchatEnabled == null)
				cb_getAvchatEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvchatEnabled);
			return cb_getAvchatEnabled;
		}

		static IntPtr n_GetAvchatEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvchatEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setAvchatEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvchatEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setAvchatEnabled_Ljava_lang_String_ == null)
				cb_setAvchatEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvchatEnabled_Ljava_lang_String_);
			return cb_setAvchatEnabled_Ljava_lang_String_;
		}

		static void n_SetAvchatEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvchatEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvchatEnabled;
		static IntPtr id_setAvchatEnabled_Ljava_lang_String_;
		public virtual unsafe string AvchatEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getAvchatEnabled' and count(parameter)=0]"
			[Register ("getAvchatEnabled", "()Ljava/lang/String;", "GetGetAvchatEnabledHandler")]
			get {
				if (id_getAvchatEnabled == IntPtr.Zero)
					id_getAvchatEnabled = JNIEnv.GetMethodID (class_ref, "getAvchatEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvchatEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvchatEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setAvchatEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvchatEnabled", "(Ljava/lang/String;)V", "GetSetAvchatEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setAvchatEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvchatEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvchatEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvchatEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvchatEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getBlockUserEnabled;
#pragma warning disable 0169
		static Delegate GetGetBlockUserEnabledHandler ()
		{
			if (cb_getBlockUserEnabled == null)
				cb_getBlockUserEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBlockUserEnabled);
			return cb_getBlockUserEnabled;
		}

		static IntPtr n_GetBlockUserEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BlockUserEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setBlockUserEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetBlockUserEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setBlockUserEnabled_Ljava_lang_String_ == null)
				cb_setBlockUserEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBlockUserEnabled_Ljava_lang_String_);
			return cb_setBlockUserEnabled_Ljava_lang_String_;
		}

		static void n_SetBlockUserEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BlockUserEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBlockUserEnabled;
		static IntPtr id_setBlockUserEnabled_Ljava_lang_String_;
		public virtual unsafe string BlockUserEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getBlockUserEnabled' and count(parameter)=0]"
			[Register ("getBlockUserEnabled", "()Ljava/lang/String;", "GetGetBlockUserEnabledHandler")]
			get {
				if (id_getBlockUserEnabled == IntPtr.Zero)
					id_getBlockUserEnabled = JNIEnv.GetMethodID (class_ref, "getBlockUserEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBlockUserEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBlockUserEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setBlockUserEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setBlockUserEnabled", "(Ljava/lang/String;)V", "GetSetBlockUserEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setBlockUserEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setBlockUserEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setBlockUserEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBlockUserEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBlockUserEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getChatWallpaper;
#pragma warning disable 0169
		static Delegate GetGetChatWallpaperHandler ()
		{
			if (cb_getChatWallpaper == null)
				cb_getChatWallpaper = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatWallpaper);
			return cb_getChatWallpaper;
		}

		static IntPtr n_GetChatWallpaper (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChatWallpaper);
		}
#pragma warning restore 0169

		static Delegate cb_setChatWallpaper_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatWallpaper_Ljava_lang_String_Handler ()
		{
			if (cb_setChatWallpaper_Ljava_lang_String_ == null)
				cb_setChatWallpaper_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatWallpaper_Ljava_lang_String_);
			return cb_setChatWallpaper_Ljava_lang_String_;
		}

		static void n_SetChatWallpaper_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatWallpaper = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatWallpaper;
		static IntPtr id_setChatWallpaper_Ljava_lang_String_;
		public virtual unsafe string ChatWallpaper {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getChatWallpaper' and count(parameter)=0]"
			[Register ("getChatWallpaper", "()Ljava/lang/String;", "GetGetChatWallpaperHandler")]
			get {
				if (id_getChatWallpaper == IntPtr.Zero)
					id_getChatWallpaper = JNIEnv.GetMethodID (class_ref, "getChatWallpaper", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatWallpaper), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatWallpaper", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setChatWallpaper' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setChatWallpaper", "(Ljava/lang/String;)V", "GetSetChatWallpaper_Ljava_lang_String_Handler")]
			set {
				if (id_setChatWallpaper_Ljava_lang_String_ == IntPtr.Zero)
					id_setChatWallpaper_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatWallpaper", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatWallpaper_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatWallpaper", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getChatroomsmoduleEnabled;
#pragma warning disable 0169
		static Delegate GetGetChatroomsmoduleEnabledHandler ()
		{
			if (cb_getChatroomsmoduleEnabled == null)
				cb_getChatroomsmoduleEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatroomsmoduleEnabled);
			return cb_getChatroomsmoduleEnabled;
		}

		static IntPtr n_GetChatroomsmoduleEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChatroomsmoduleEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomsmoduleEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatroomsmoduleEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setChatroomsmoduleEnabled_Ljava_lang_String_ == null)
				cb_setChatroomsmoduleEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatroomsmoduleEnabled_Ljava_lang_String_);
			return cb_setChatroomsmoduleEnabled_Ljava_lang_String_;
		}

		static void n_SetChatroomsmoduleEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomsmoduleEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomsmoduleEnabled;
		static IntPtr id_setChatroomsmoduleEnabled_Ljava_lang_String_;
		public virtual unsafe string ChatroomsmoduleEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getChatroomsmoduleEnabled' and count(parameter)=0]"
			[Register ("getChatroomsmoduleEnabled", "()Ljava/lang/String;", "GetGetChatroomsmoduleEnabledHandler")]
			get {
				if (id_getChatroomsmoduleEnabled == IntPtr.Zero)
					id_getChatroomsmoduleEnabled = JNIEnv.GetMethodID (class_ref, "getChatroomsmoduleEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomsmoduleEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomsmoduleEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setChatroomsmoduleEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setChatroomsmoduleEnabled", "(Ljava/lang/String;)V", "GetSetChatroomsmoduleEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setChatroomsmoduleEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setChatroomsmoduleEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatroomsmoduleEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomsmoduleEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomsmoduleEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getClearconversationEnabled;
#pragma warning disable 0169
		static Delegate GetGetClearconversationEnabledHandler ()
		{
			if (cb_getClearconversationEnabled == null)
				cb_getClearconversationEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetClearconversationEnabled);
			return cb_getClearconversationEnabled;
		}

		static IntPtr n_GetClearconversationEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ClearconversationEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setClearconversationEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetClearconversationEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setClearconversationEnabled_Ljava_lang_String_ == null)
				cb_setClearconversationEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetClearconversationEnabled_Ljava_lang_String_);
			return cb_setClearconversationEnabled_Ljava_lang_String_;
		}

		static void n_SetClearconversationEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearconversationEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getClearconversationEnabled;
		static IntPtr id_setClearconversationEnabled_Ljava_lang_String_;
		public virtual unsafe string ClearconversationEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getClearconversationEnabled' and count(parameter)=0]"
			[Register ("getClearconversationEnabled", "()Ljava/lang/String;", "GetGetClearconversationEnabledHandler")]
			get {
				if (id_getClearconversationEnabled == IntPtr.Zero)
					id_getClearconversationEnabled = JNIEnv.GetMethodID (class_ref, "getClearconversationEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getClearconversationEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getClearconversationEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setClearconversationEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setClearconversationEnabled", "(Ljava/lang/String;)V", "GetSetClearconversationEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setClearconversationEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setClearconversationEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setClearconversationEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setClearconversationEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setClearconversationEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCometchatVersion;
#pragma warning disable 0169
		static Delegate GetGetCometchatVersionHandler ()
		{
			if (cb_getCometchatVersion == null)
				cb_getCometchatVersion = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCometchatVersion);
			return cb_getCometchatVersion;
		}

		static IntPtr n_GetCometchatVersion (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CometchatVersion);
		}
#pragma warning restore 0169

		static Delegate cb_setCometchatVersion_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCometchatVersion_Ljava_lang_String_Handler ()
		{
			if (cb_setCometchatVersion_Ljava_lang_String_ == null)
				cb_setCometchatVersion_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCometchatVersion_Ljava_lang_String_);
			return cb_setCometchatVersion_Ljava_lang_String_;
		}

		static void n_SetCometchatVersion_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CometchatVersion = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCometchatVersion;
		static IntPtr id_setCometchatVersion_Ljava_lang_String_;
		public virtual unsafe string CometchatVersion {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCometchatVersion' and count(parameter)=0]"
			[Register ("getCometchatVersion", "()Ljava/lang/String;", "GetGetCometchatVersionHandler")]
			get {
				if (id_getCometchatVersion == IntPtr.Zero)
					id_getCometchatVersion = JNIEnv.GetMethodID (class_ref, "getCometchatVersion", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCometchatVersion), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCometchatVersion", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCometchatVersion' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCometchatVersion", "(Ljava/lang/String;)V", "GetSetCometchatVersion_Ljava_lang_String_Handler")]
			set {
				if (id_setCometchatVersion_Ljava_lang_String_ == IntPtr.Zero)
					id_setCometchatVersion_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCometchatVersion", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCometchatVersion_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCometchatVersion", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getConfig;
#pragma warning disable 0169
		static Delegate GetGetConfigHandler ()
		{
			if (cb_getConfig == null)
				cb_getConfig = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetConfig);
			return cb_getConfig;
		}

		static IntPtr n_GetConfig (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Config);
		}
#pragma warning restore 0169

		static Delegate cb_setConfig_Lcom_inscripts_jsonphp_Config_;
#pragma warning disable 0169
		static Delegate GetSetConfig_Lcom_inscripts_jsonphp_Config_Handler ()
		{
			if (cb_setConfig_Lcom_inscripts_jsonphp_Config_ == null)
				cb_setConfig_Lcom_inscripts_jsonphp_Config_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetConfig_Lcom_inscripts_jsonphp_Config_);
			return cb_setConfig_Lcom_inscripts_jsonphp_Config_;
		}

		static void n_SetConfig_Lcom_inscripts_jsonphp_Config_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Config p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Config = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getConfig;
		static IntPtr id_setConfig_Lcom_inscripts_jsonphp_Config_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Config Config {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getConfig' and count(parameter)=0]"
			[Register ("getConfig", "()Lcom/inscripts/jsonphp/Config;", "GetGetConfigHandler")]
			get {
				if (id_getConfig == IntPtr.Zero)
					id_getConfig = JNIEnv.GetMethodID (class_ref, "getConfig", "()Lcom/inscripts/jsonphp/Config;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getConfig), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Config> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getConfig", "()Lcom/inscripts/jsonphp/Config;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setConfig' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Config']]"
			[Register ("setConfig", "(Lcom/inscripts/jsonphp/Config;)V", "GetSetConfig_Lcom_inscripts_jsonphp_Config_Handler")]
			set {
				if (id_setConfig_Lcom_inscripts_jsonphp_Config_ == IntPtr.Zero)
					id_setConfig_Lcom_inscripts_jsonphp_Config_ = JNIEnv.GetMethodID (class_ref, "setConfig", "(Lcom/inscripts/jsonphp/Config;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setConfig_Lcom_inscripts_jsonphp_Config_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setConfig", "(Lcom/inscripts/jsonphp/Config;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getConfighash;
#pragma warning disable 0169
		static Delegate GetGetConfighashHandler ()
		{
			if (cb_getConfighash == null)
				cb_getConfighash = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetConfighash);
			return cb_getConfighash;
		}

		static IntPtr n_GetConfighash (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Confighash);
		}
#pragma warning restore 0169

		static Delegate cb_setConfighash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetConfighash_Ljava_lang_String_Handler ()
		{
			if (cb_setConfighash_Ljava_lang_String_ == null)
				cb_setConfighash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetConfighash_Ljava_lang_String_);
			return cb_setConfighash_Ljava_lang_String_;
		}

		static void n_SetConfighash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Confighash = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getConfighash;
		static IntPtr id_setConfighash_Ljava_lang_String_;
		public virtual unsafe string Confighash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getConfighash' and count(parameter)=0]"
			[Register ("getConfighash", "()Ljava/lang/String;", "GetGetConfighashHandler")]
			get {
				if (id_getConfighash == IntPtr.Zero)
					id_getConfighash = JNIEnv.GetMethodID (class_ref, "getConfighash", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getConfighash), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getConfighash", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setConfighash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setConfighash", "(Ljava/lang/String;)V", "GetSetConfighash_Ljava_lang_String_Handler")]
			set {
				if (id_setConfighash_Ljava_lang_String_ == IntPtr.Zero)
					id_setConfighash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setConfighash", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setConfighash_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setConfighash", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCookieprefix;
#pragma warning disable 0169
		static Delegate GetGetCookieprefixHandler ()
		{
			if (cb_getCookieprefix == null)
				cb_getCookieprefix = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCookieprefix);
			return cb_getCookieprefix;
		}

		static IntPtr n_GetCookieprefix (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Cookieprefix);
		}
#pragma warning restore 0169

		static Delegate cb_setCookieprefix_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCookieprefix_Ljava_lang_String_Handler ()
		{
			if (cb_setCookieprefix_Ljava_lang_String_ == null)
				cb_setCookieprefix_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCookieprefix_Ljava_lang_String_);
			return cb_setCookieprefix_Ljava_lang_String_;
		}

		static void n_SetCookieprefix_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Cookieprefix = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCookieprefix;
		static IntPtr id_setCookieprefix_Ljava_lang_String_;
		public virtual unsafe string Cookieprefix {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCookieprefix' and count(parameter)=0]"
			[Register ("getCookieprefix", "()Ljava/lang/String;", "GetGetCookieprefixHandler")]
			get {
				if (id_getCookieprefix == IntPtr.Zero)
					id_getCookieprefix = JNIEnv.GetMethodID (class_ref, "getCookieprefix", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCookieprefix), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCookieprefix", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCookieprefix' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCookieprefix", "(Ljava/lang/String;)V", "GetSetCookieprefix_Ljava_lang_String_Handler")]
			set {
				if (id_setCookieprefix_Ljava_lang_String_ == IntPtr.Zero)
					id_setCookieprefix_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCookieprefix", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCookieprefix_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCookieprefix", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCrclearconversationEnabled;
#pragma warning disable 0169
		static Delegate GetGetCrclearconversationEnabledHandler ()
		{
			if (cb_getCrclearconversationEnabled == null)
				cb_getCrclearconversationEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrclearconversationEnabled);
			return cb_getCrclearconversationEnabled;
		}

		static IntPtr n_GetCrclearconversationEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrclearconversationEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setCrclearconversationEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCrclearconversationEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setCrclearconversationEnabled_Ljava_lang_String_ == null)
				cb_setCrclearconversationEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCrclearconversationEnabled_Ljava_lang_String_);
			return cb_setCrclearconversationEnabled_Ljava_lang_String_;
		}

		static void n_SetCrclearconversationEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CrclearconversationEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCrclearconversationEnabled;
		static IntPtr id_setCrclearconversationEnabled_Ljava_lang_String_;
		public virtual unsafe string CrclearconversationEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCrclearconversationEnabled' and count(parameter)=0]"
			[Register ("getCrclearconversationEnabled", "()Ljava/lang/String;", "GetGetCrclearconversationEnabledHandler")]
			get {
				if (id_getCrclearconversationEnabled == IntPtr.Zero)
					id_getCrclearconversationEnabled = JNIEnv.GetMethodID (class_ref, "getCrclearconversationEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrclearconversationEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrclearconversationEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCrclearconversationEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCrclearconversationEnabled", "(Ljava/lang/String;)V", "GetSetCrclearconversationEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setCrclearconversationEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setCrclearconversationEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCrclearconversationEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCrclearconversationEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCrclearconversationEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCrfiletransferEnabled;
#pragma warning disable 0169
		static Delegate GetGetCrfiletransferEnabledHandler ()
		{
			if (cb_getCrfiletransferEnabled == null)
				cb_getCrfiletransferEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCrfiletransferEnabled);
			return cb_getCrfiletransferEnabled;
		}

		static IntPtr n_GetCrfiletransferEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CrfiletransferEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setCrfiletransferEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCrfiletransferEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setCrfiletransferEnabled_Ljava_lang_String_ == null)
				cb_setCrfiletransferEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCrfiletransferEnabled_Ljava_lang_String_);
			return cb_setCrfiletransferEnabled_Ljava_lang_String_;
		}

		static void n_SetCrfiletransferEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CrfiletransferEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCrfiletransferEnabled;
		static IntPtr id_setCrfiletransferEnabled_Ljava_lang_String_;
		public virtual unsafe string CrfiletransferEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCrfiletransferEnabled' and count(parameter)=0]"
			[Register ("getCrfiletransferEnabled", "()Ljava/lang/String;", "GetGetCrfiletransferEnabledHandler")]
			get {
				if (id_getCrfiletransferEnabled == IntPtr.Zero)
					id_getCrfiletransferEnabled = JNIEnv.GetMethodID (class_ref, "getCrfiletransferEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCrfiletransferEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCrfiletransferEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCrfiletransferEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCrfiletransferEnabled", "(Ljava/lang/String;)V", "GetSetCrfiletransferEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setCrfiletransferEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setCrfiletransferEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCrfiletransferEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCrfiletransferEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCrfiletransferEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCss;
#pragma warning disable 0169
		static Delegate GetGetCssHandler ()
		{
			if (cb_getCss == null)
				cb_getCss = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCss);
			return cb_getCss;
		}

		static IntPtr n_GetCss (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Css);
		}
#pragma warning restore 0169

		static Delegate cb_setCss_Lcom_inscripts_jsonphp_Css_;
#pragma warning disable 0169
		static Delegate GetSetCss_Lcom_inscripts_jsonphp_Css_Handler ()
		{
			if (cb_setCss_Lcom_inscripts_jsonphp_Css_ == null)
				cb_setCss_Lcom_inscripts_jsonphp_Css_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCss_Lcom_inscripts_jsonphp_Css_);
			return cb_setCss_Lcom_inscripts_jsonphp_Css_;
		}

		static void n_SetCss_Lcom_inscripts_jsonphp_Css_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Css p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Css = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCss;
		static IntPtr id_setCss_Lcom_inscripts_jsonphp_Css_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Css Css {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCss' and count(parameter)=0]"
			[Register ("getCss", "()Lcom/inscripts/jsonphp/Css;", "GetGetCssHandler")]
			get {
				if (id_getCss == IntPtr.Zero)
					id_getCss = JNIEnv.GetMethodID (class_ref, "getCss", "()Lcom/inscripts/jsonphp/Css;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCss), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCss", "()Lcom/inscripts/jsonphp/Css;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCss' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Css']]"
			[Register ("setCss", "(Lcom/inscripts/jsonphp/Css;)V", "GetSetCss_Lcom_inscripts_jsonphp_Css_Handler")]
			set {
				if (id_setCss_Lcom_inscripts_jsonphp_Css_ == IntPtr.Zero)
					id_setCss_Lcom_inscripts_jsonphp_Css_ = JNIEnv.GetMethodID (class_ref, "setCss", "(Lcom/inscripts/jsonphp/Css;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCss_Lcom_inscripts_jsonphp_Css_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCss", "(Lcom/inscripts/jsonphp/Css;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCsshash;
#pragma warning disable 0169
		static Delegate GetGetCsshashHandler ()
		{
			if (cb_getCsshash == null)
				cb_getCsshash = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCsshash);
			return cb_getCsshash;
		}

		static IntPtr n_GetCsshash (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Csshash);
		}
#pragma warning restore 0169

		static Delegate cb_setCsshash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCsshash_Ljava_lang_String_Handler ()
		{
			if (cb_setCsshash_Ljava_lang_String_ == null)
				cb_setCsshash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCsshash_Ljava_lang_String_);
			return cb_setCsshash_Ljava_lang_String_;
		}

		static void n_SetCsshash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Csshash = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCsshash;
		static IntPtr id_setCsshash_Ljava_lang_String_;
		public virtual unsafe string Csshash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getCsshash' and count(parameter)=0]"
			[Register ("getCsshash", "()Ljava/lang/String;", "GetGetCsshashHandler")]
			get {
				if (id_getCsshash == IntPtr.Zero)
					id_getCsshash = JNIEnv.GetMethodID (class_ref, "getCsshash", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCsshash), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCsshash", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setCsshash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCsshash", "(Ljava/lang/String;)V", "GetSetCsshash_Ljava_lang_String_Handler")]
			set {
				if (id_setCsshash_Ljava_lang_String_ == IntPtr.Zero)
					id_setCsshash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCsshash", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCsshash_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCsshash", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getFiletransferEnabled;
#pragma warning disable 0169
		static Delegate GetGetFiletransferEnabledHandler ()
		{
			if (cb_getFiletransferEnabled == null)
				cb_getFiletransferEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFiletransferEnabled);
			return cb_getFiletransferEnabled;
		}

		static IntPtr n_GetFiletransferEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.FiletransferEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setFiletransferEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetFiletransferEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setFiletransferEnabled_Ljava_lang_String_ == null)
				cb_setFiletransferEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetFiletransferEnabled_Ljava_lang_String_);
			return cb_setFiletransferEnabled_Ljava_lang_String_;
		}

		static void n_SetFiletransferEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.FiletransferEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getFiletransferEnabled;
		static IntPtr id_setFiletransferEnabled_Ljava_lang_String_;
		public virtual unsafe string FiletransferEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getFiletransferEnabled' and count(parameter)=0]"
			[Register ("getFiletransferEnabled", "()Ljava/lang/String;", "GetGetFiletransferEnabledHandler")]
			get {
				if (id_getFiletransferEnabled == IntPtr.Zero)
					id_getFiletransferEnabled = JNIEnv.GetMethodID (class_ref, "getFiletransferEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFiletransferEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFiletransferEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setFiletransferEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setFiletransferEnabled", "(Ljava/lang/String;)V", "GetSetFiletransferEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setFiletransferEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setFiletransferEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setFiletransferEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFiletransferEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFiletransferEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getHeaderImage;
#pragma warning disable 0169
		static Delegate GetGetHeaderImageHandler ()
		{
			if (cb_getHeaderImage == null)
				cb_getHeaderImage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHeaderImage);
			return cb_getHeaderImage;
		}

		static IntPtr n_GetHeaderImage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.HeaderImage);
		}
#pragma warning restore 0169

		static Delegate cb_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_;
#pragma warning disable 0169
		static Delegate GetSetHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_Handler ()
		{
			if (cb_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_ == null)
				cb_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_);
			return cb_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_;
		}

		static void n_SetHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.HeaderImage p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.HeaderImage = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getHeaderImage;
		static IntPtr id_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.HeaderImage HeaderImage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getHeaderImage' and count(parameter)=0]"
			[Register ("getHeaderImage", "()Lcom/inscripts/jsonphp/HeaderImage;", "GetGetHeaderImageHandler")]
			get {
				if (id_getHeaderImage == IntPtr.Zero)
					id_getHeaderImage = JNIEnv.GetMethodID (class_ref, "getHeaderImage", "()Lcom/inscripts/jsonphp/HeaderImage;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHeaderImage), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHeaderImage", "()Lcom/inscripts/jsonphp/HeaderImage;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setHeaderImage' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.HeaderImage']]"
			[Register ("setHeaderImage", "(Lcom/inscripts/jsonphp/HeaderImage;)V", "GetSetHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_Handler")]
			set {
				if (id_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_ == IntPtr.Zero)
					id_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_ = JNIEnv.GetMethodID (class_ref, "setHeaderImage", "(Lcom/inscripts/jsonphp/HeaderImage;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHeaderImage_Lcom_inscripts_jsonphp_HeaderImage_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setHeaderImage", "(Lcom/inscripts/jsonphp/HeaderImage;)V"), __args);
				} finally {
				}
			}
		}

		static IntPtr id_getInstance;
		static IntPtr id_setInstance_Lcom_inscripts_jsonphp_JsonPhp_;
		public static unsafe global::Com.Inscripts.Jsonphp.JsonPhp Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/jsonphp/JsonPhp;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/jsonphp/JsonPhp;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.JsonPhp']]"
			[Register ("setInstance", "(Lcom/inscripts/jsonphp/JsonPhp;)V", "GetSetInstance_Lcom_inscripts_jsonphp_JsonPhp_Handler")]
			set {
				if (id_setInstance_Lcom_inscripts_jsonphp_JsonPhp_ == IntPtr.Zero)
					id_setInstance_Lcom_inscripts_jsonphp_JsonPhp_ = JNIEnv.GetStaticMethodID (class_ref, "setInstance", "(Lcom/inscripts/jsonphp/JsonPhp;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setInstance_Lcom_inscripts_jsonphp_JsonPhp_, __args);
				} finally {
				}
			}
		}

		static IntPtr id_isNull;
		public static unsafe bool IsNull {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='isNull' and count(parameter)=0]"
			[Register ("isNull", "()Z", "GetIsNullHandler")]
			get {
				if (id_isNull == IntPtr.Zero)
					id_isNull = JNIEnv.GetStaticMethodID (class_ref, "isNull", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isNull);
				} finally {
				}
			}
		}

		static Delegate cb_getLang;
#pragma warning disable 0169
		static Delegate GetGetLangHandler ()
		{
			if (cb_getLang == null)
				cb_getLang = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLang);
			return cb_getLang;
		}

		static IntPtr n_GetLang (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Lang);
		}
#pragma warning restore 0169

		static Delegate cb_setLang_Lcom_inscripts_jsonphp_Lang_;
#pragma warning disable 0169
		static Delegate GetSetLang_Lcom_inscripts_jsonphp_Lang_Handler ()
		{
			if (cb_setLang_Lcom_inscripts_jsonphp_Lang_ == null)
				cb_setLang_Lcom_inscripts_jsonphp_Lang_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetLang_Lcom_inscripts_jsonphp_Lang_);
			return cb_setLang_Lcom_inscripts_jsonphp_Lang_;
		}

		static void n_SetLang_Lcom_inscripts_jsonphp_Lang_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Lang p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Lang = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getLang;
		static IntPtr id_setLang_Lcom_inscripts_jsonphp_Lang_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Lang Lang {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getLang' and count(parameter)=0]"
			[Register ("getLang", "()Lcom/inscripts/jsonphp/Lang;", "GetGetLangHandler")]
			get {
				if (id_getLang == IntPtr.Zero)
					id_getLang = JNIEnv.GetMethodID (class_ref, "getLang", "()Lcom/inscripts/jsonphp/Lang;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLang), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLang", "()Lcom/inscripts/jsonphp/Lang;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setLang' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Lang']]"
			[Register ("setLang", "(Lcom/inscripts/jsonphp/Lang;)V", "GetSetLang_Lcom_inscripts_jsonphp_Lang_Handler")]
			set {
				if (id_setLang_Lcom_inscripts_jsonphp_Lang_ == IntPtr.Zero)
					id_setLang_Lcom_inscripts_jsonphp_Lang_ = JNIEnv.GetMethodID (class_ref, "setLang", "(Lcom/inscripts/jsonphp/Lang;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLang_Lcom_inscripts_jsonphp_Lang_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLang", "(Lcom/inscripts/jsonphp/Lang;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getLanghash;
#pragma warning disable 0169
		static Delegate GetGetLanghashHandler ()
		{
			if (cb_getLanghash == null)
				cb_getLanghash = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLanghash);
			return cb_getLanghash;
		}

		static IntPtr n_GetLanghash (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Langhash);
		}
#pragma warning restore 0169

		static Delegate cb_setLanghash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetLanghash_Ljava_lang_String_Handler ()
		{
			if (cb_setLanghash_Ljava_lang_String_ == null)
				cb_setLanghash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetLanghash_Ljava_lang_String_);
			return cb_setLanghash_Ljava_lang_String_;
		}

		static void n_SetLanghash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Langhash = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getLanghash;
		static IntPtr id_setLanghash_Ljava_lang_String_;
		public virtual unsafe string Langhash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getLanghash' and count(parameter)=0]"
			[Register ("getLanghash", "()Ljava/lang/String;", "GetGetLanghashHandler")]
			get {
				if (id_getLanghash == IntPtr.Zero)
					id_getLanghash = JNIEnv.GetMethodID (class_ref, "getLanghash", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLanghash), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLanghash", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setLanghash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setLanghash", "(Ljava/lang/String;)V", "GetSetLanghash_Ljava_lang_String_Handler")]
			set {
				if (id_setLanghash_Ljava_lang_String_ == IntPtr.Zero)
					id_setLanghash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setLanghash", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLanghash_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLanghash", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getMobileConfig;
#pragma warning disable 0169
		static Delegate GetGetMobileConfigHandler ()
		{
			if (cb_getMobileConfig == null)
				cb_getMobileConfig = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMobileConfig);
			return cb_getMobileConfig;
		}

		static IntPtr n_GetMobileConfig (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.MobileConfig);
		}
#pragma warning restore 0169

		static Delegate cb_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_;
#pragma warning disable 0169
		static Delegate GetSetMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_Handler ()
		{
			if (cb_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_ == null)
				cb_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_);
			return cb_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_;
		}

		static void n_SetMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.MobileConfig p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.MobileConfig = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMobileConfig;
		static IntPtr id_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.MobileConfig MobileConfig {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getMobileConfig' and count(parameter)=0]"
			[Register ("getMobileConfig", "()Lcom/inscripts/jsonphp/MobileConfig;", "GetGetMobileConfigHandler")]
			get {
				if (id_getMobileConfig == IntPtr.Zero)
					id_getMobileConfig = JNIEnv.GetMethodID (class_ref, "getMobileConfig", "()Lcom/inscripts/jsonphp/MobileConfig;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMobileConfig), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMobileConfig", "()Lcom/inscripts/jsonphp/MobileConfig;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setMobileConfig' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.MobileConfig']]"
			[Register ("setMobileConfig", "(Lcom/inscripts/jsonphp/MobileConfig;)V", "GetSetMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_Handler")]
			set {
				if (id_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_ == IntPtr.Zero)
					id_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_ = JNIEnv.GetMethodID (class_ref, "setMobileConfig", "(Lcom/inscripts/jsonphp/MobileConfig;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMobileConfig_Lcom_inscripts_jsonphp_MobileConfig_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMobileConfig", "(Lcom/inscripts/jsonphp/MobileConfig;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getMobileTheme;
#pragma warning disable 0169
		static Delegate GetGetMobileThemeHandler ()
		{
			if (cb_getMobileTheme == null)
				cb_getMobileTheme = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMobileTheme);
			return cb_getMobileTheme;
		}

		static IntPtr n_GetMobileTheme (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.MobileTheme);
		}
#pragma warning restore 0169

		static Delegate cb_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_;
#pragma warning disable 0169
		static Delegate GetSetMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_Handler ()
		{
			if (cb_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_ == null)
				cb_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_);
			return cb_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_;
		}

		static void n_SetMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.MobileTheme p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.MobileTheme = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMobileTheme;
		static IntPtr id_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.MobileTheme MobileTheme {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getMobileTheme' and count(parameter)=0]"
			[Register ("getMobileTheme", "()Lcom/inscripts/jsonphp/MobileTheme;", "GetGetMobileThemeHandler")]
			get {
				if (id_getMobileTheme == IntPtr.Zero)
					id_getMobileTheme = JNIEnv.GetMethodID (class_ref, "getMobileTheme", "()Lcom/inscripts/jsonphp/MobileTheme;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMobileTheme), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMobileTheme", "()Lcom/inscripts/jsonphp/MobileTheme;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setMobileTheme' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.MobileTheme']]"
			[Register ("setMobileTheme", "(Lcom/inscripts/jsonphp/MobileTheme;)V", "GetSetMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_Handler")]
			set {
				if (id_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_ == IntPtr.Zero)
					id_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_ = JNIEnv.GetMethodID (class_ref, "setMobileTheme", "(Lcom/inscripts/jsonphp/MobileTheme;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMobileTheme_Lcom_inscripts_jsonphp_MobileTheme_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMobileTheme", "(Lcom/inscripts/jsonphp/MobileTheme;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getNewMobile;
#pragma warning disable 0169
		static Delegate GetGetNewMobileHandler ()
		{
			if (cb_getNewMobile == null)
				cb_getNewMobile = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetNewMobile);
			return cb_getNewMobile;
		}

		static IntPtr n_GetNewMobile (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.NewMobile);
		}
#pragma warning restore 0169

		static Delegate cb_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_;
#pragma warning disable 0169
		static Delegate GetSetNewMobile_Lcom_inscripts_jsonphp_NewMobile_Handler ()
		{
			if (cb_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_ == null)
				cb_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetNewMobile_Lcom_inscripts_jsonphp_NewMobile_);
			return cb_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_;
		}

		static void n_SetNewMobile_Lcom_inscripts_jsonphp_NewMobile_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.NewMobile p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.NewMobile = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getNewMobile;
		static IntPtr id_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.NewMobile NewMobile {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getNewMobile' and count(parameter)=0]"
			[Register ("getNewMobile", "()Lcom/inscripts/jsonphp/NewMobile;", "GetGetNewMobileHandler")]
			get {
				if (id_getNewMobile == IntPtr.Zero)
					id_getNewMobile = JNIEnv.GetMethodID (class_ref, "getNewMobile", "()Lcom/inscripts/jsonphp/NewMobile;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getNewMobile), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getNewMobile", "()Lcom/inscripts/jsonphp/NewMobile;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setNewMobile' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.NewMobile']]"
			[Register ("setNewMobile", "(Lcom/inscripts/jsonphp/NewMobile;)V", "GetSetNewMobile_Lcom_inscripts_jsonphp_NewMobile_Handler")]
			set {
				if (id_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_ == IntPtr.Zero)
					id_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_ = JNIEnv.GetMethodID (class_ref, "setNewMobile", "(Lcom/inscripts/jsonphp/NewMobile;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setNewMobile_Lcom_inscripts_jsonphp_NewMobile_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setNewMobile", "(Lcom/inscripts/jsonphp/NewMobile;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getObGzhandler;
#pragma warning disable 0169
		static Delegate GetGetObGzhandlerHandler ()
		{
			if (cb_getObGzhandler == null)
				cb_getObGzhandler = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetObGzhandler);
			return cb_getObGzhandler;
		}

		static IntPtr n_GetObGzhandler (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ObGzhandler);
		}
#pragma warning restore 0169

		static Delegate cb_setObGzhandler_Ljava_lang_Integer_;
#pragma warning disable 0169
		static Delegate GetSetObGzhandler_Ljava_lang_Integer_Handler ()
		{
			if (cb_setObGzhandler_Ljava_lang_Integer_ == null)
				cb_setObGzhandler_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetObGzhandler_Ljava_lang_Integer_);
			return cb_setObGzhandler_Ljava_lang_Integer_;
		}

		static void n_SetObGzhandler_Ljava_lang_Integer_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Integer p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ObGzhandler = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getObGzhandler;
		static IntPtr id_setObGzhandler_Ljava_lang_Integer_;
		public virtual unsafe global::Java.Lang.Integer ObGzhandler {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getObGzhandler' and count(parameter)=0]"
			[Register ("getObGzhandler", "()Ljava/lang/Integer;", "GetGetObGzhandlerHandler")]
			get {
				if (id_getObGzhandler == IntPtr.Zero)
					id_getObGzhandler = JNIEnv.GetMethodID (class_ref, "getObGzhandler", "()Ljava/lang/Integer;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getObGzhandler), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getObGzhandler", "()Ljava/lang/Integer;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setObGzhandler' and count(parameter)=1 and parameter[1][@type='java.lang.Integer']]"
			[Register ("setObGzhandler", "(Ljava/lang/Integer;)V", "GetSetObGzhandler_Ljava_lang_Integer_Handler")]
			set {
				if (id_setObGzhandler_Ljava_lang_Integer_ == IntPtr.Zero)
					id_setObGzhandler_Ljava_lang_Integer_ = JNIEnv.GetMethodID (class_ref, "setObGzhandler", "(Ljava/lang/Integer;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setObGzhandler_Ljava_lang_Integer_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setObGzhandler", "(Ljava/lang/Integer;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getPresetWallpaper;
#pragma warning disable 0169
		static Delegate GetGetPresetWallpaperHandler ()
		{
			if (cb_getPresetWallpaper == null)
				cb_getPresetWallpaper = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPresetWallpaper);
			return cb_getPresetWallpaper;
		}

		static IntPtr n_GetPresetWallpaper (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PresetWallpaper);
		}
#pragma warning restore 0169

		static Delegate cb_setPresetWallpaper_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPresetWallpaper_Ljava_lang_String_Handler ()
		{
			if (cb_setPresetWallpaper_Ljava_lang_String_ == null)
				cb_setPresetWallpaper_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPresetWallpaper_Ljava_lang_String_);
			return cb_setPresetWallpaper_Ljava_lang_String_;
		}

		static void n_SetPresetWallpaper_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PresetWallpaper = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPresetWallpaper;
		static IntPtr id_setPresetWallpaper_Ljava_lang_String_;
		public virtual unsafe string PresetWallpaper {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPresetWallpaper' and count(parameter)=0]"
			[Register ("getPresetWallpaper", "()Ljava/lang/String;", "GetGetPresetWallpaperHandler")]
			get {
				if (id_getPresetWallpaper == IntPtr.Zero)
					id_getPresetWallpaper = JNIEnv.GetMethodID (class_ref, "getPresetWallpaper", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPresetWallpaper), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPresetWallpaper", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPresetWallpaper' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPresetWallpaper", "(Ljava/lang/String;)V", "GetSetPresetWallpaper_Ljava_lang_String_Handler")]
			set {
				if (id_setPresetWallpaper_Ljava_lang_String_ == IntPtr.Zero)
					id_setPresetWallpaper_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPresetWallpaper", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPresetWallpaper_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPresetWallpaper", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getPushAPIKey;
#pragma warning disable 0169
		static Delegate GetGetPushAPIKeyHandler ()
		{
			if (cb_getPushAPIKey == null)
				cb_getPushAPIKey = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPushAPIKey);
			return cb_getPushAPIKey;
		}

		static IntPtr n_GetPushAPIKey (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PushAPIKey);
		}
#pragma warning restore 0169

		static Delegate cb_setPushAPIKey_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPushAPIKey_Ljava_lang_String_Handler ()
		{
			if (cb_setPushAPIKey_Ljava_lang_String_ == null)
				cb_setPushAPIKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPushAPIKey_Ljava_lang_String_);
			return cb_setPushAPIKey_Ljava_lang_String_;
		}

		static void n_SetPushAPIKey_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PushAPIKey = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPushAPIKey;
		static IntPtr id_setPushAPIKey_Ljava_lang_String_;
		public virtual unsafe string PushAPIKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPushAPIKey' and count(parameter)=0]"
			[Register ("getPushAPIKey", "()Ljava/lang/String;", "GetGetPushAPIKeyHandler")]
			get {
				if (id_getPushAPIKey == IntPtr.Zero)
					id_getPushAPIKey = JNIEnv.GetMethodID (class_ref, "getPushAPIKey", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPushAPIKey), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPushAPIKey", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPushAPIKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPushAPIKey", "(Ljava/lang/String;)V", "GetSetPushAPIKey_Ljava_lang_String_Handler")]
			set {
				if (id_setPushAPIKey_Ljava_lang_String_ == IntPtr.Zero)
					id_setPushAPIKey_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPushAPIKey", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPushAPIKey_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPushAPIKey", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getPushNotificationName;
#pragma warning disable 0169
		static Delegate GetGetPushNotificationNameHandler ()
		{
			if (cb_getPushNotificationName == null)
				cb_getPushNotificationName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPushNotificationName);
			return cb_getPushNotificationName;
		}

		static IntPtr n_GetPushNotificationName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PushNotificationName);
		}
#pragma warning restore 0169

		static Delegate cb_setPushNotificationName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPushNotificationName_Ljava_lang_String_Handler ()
		{
			if (cb_setPushNotificationName_Ljava_lang_String_ == null)
				cb_setPushNotificationName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPushNotificationName_Ljava_lang_String_);
			return cb_setPushNotificationName_Ljava_lang_String_;
		}

		static void n_SetPushNotificationName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PushNotificationName = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPushNotificationName;
		static IntPtr id_setPushNotificationName_Ljava_lang_String_;
		public virtual unsafe string PushNotificationName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPushNotificationName' and count(parameter)=0]"
			[Register ("getPushNotificationName", "()Ljava/lang/String;", "GetGetPushNotificationNameHandler")]
			get {
				if (id_getPushNotificationName == IntPtr.Zero)
					id_getPushNotificationName = JNIEnv.GetMethodID (class_ref, "getPushNotificationName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPushNotificationName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPushNotificationName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPushNotificationName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPushNotificationName", "(Ljava/lang/String;)V", "GetSetPushNotificationName_Ljava_lang_String_Handler")]
			set {
				if (id_setPushNotificationName_Ljava_lang_String_ == IntPtr.Zero)
					id_setPushNotificationName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPushNotificationName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPushNotificationName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPushNotificationName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getPushNotifications;
#pragma warning disable 0169
		static Delegate GetGetPushNotificationsHandler ()
		{
			if (cb_getPushNotifications == null)
				cb_getPushNotifications = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPushNotifications);
			return cb_getPushNotifications;
		}

		static IntPtr n_GetPushNotifications (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PushNotifications);
		}
#pragma warning restore 0169

		static Delegate cb_setPushNotifications_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPushNotifications_Ljava_lang_String_Handler ()
		{
			if (cb_setPushNotifications_Ljava_lang_String_ == null)
				cb_setPushNotifications_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPushNotifications_Ljava_lang_String_);
			return cb_setPushNotifications_Ljava_lang_String_;
		}

		static void n_SetPushNotifications_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PushNotifications = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPushNotifications;
		static IntPtr id_setPushNotifications_Ljava_lang_String_;
		public virtual unsafe string PushNotifications {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPushNotifications' and count(parameter)=0]"
			[Register ("getPushNotifications", "()Ljava/lang/String;", "GetGetPushNotificationsHandler")]
			get {
				if (id_getPushNotifications == IntPtr.Zero)
					id_getPushNotifications = JNIEnv.GetMethodID (class_ref, "getPushNotifications", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPushNotifications), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPushNotifications", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPushNotifications' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPushNotifications", "(Ljava/lang/String;)V", "GetSetPushNotifications_Ljava_lang_String_Handler")]
			set {
				if (id_setPushNotifications_Ljava_lang_String_ == IntPtr.Zero)
					id_setPushNotifications_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPushNotifications", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPushNotifications_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPushNotifications", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getPushOauthKey;
#pragma warning disable 0169
		static Delegate GetGetPushOauthKeyHandler ()
		{
			if (cb_getPushOauthKey == null)
				cb_getPushOauthKey = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPushOauthKey);
			return cb_getPushOauthKey;
		}

		static IntPtr n_GetPushOauthKey (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PushOauthKey);
		}
#pragma warning restore 0169

		static Delegate cb_setPushOauthKey_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPushOauthKey_Ljava_lang_String_Handler ()
		{
			if (cb_setPushOauthKey_Ljava_lang_String_ == null)
				cb_setPushOauthKey_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPushOauthKey_Ljava_lang_String_);
			return cb_setPushOauthKey_Ljava_lang_String_;
		}

		static void n_SetPushOauthKey_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PushOauthKey = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPushOauthKey;
		static IntPtr id_setPushOauthKey_Ljava_lang_String_;
		public virtual unsafe string PushOauthKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPushOauthKey' and count(parameter)=0]"
			[Register ("getPushOauthKey", "()Ljava/lang/String;", "GetGetPushOauthKeyHandler")]
			get {
				if (id_getPushOauthKey == IntPtr.Zero)
					id_getPushOauthKey = JNIEnv.GetMethodID (class_ref, "getPushOauthKey", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPushOauthKey), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPushOauthKey", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPushOauthKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPushOauthKey", "(Ljava/lang/String;)V", "GetSetPushOauthKey_Ljava_lang_String_Handler")]
			set {
				if (id_setPushOauthKey_Ljava_lang_String_ == IntPtr.Zero)
					id_setPushOauthKey_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPushOauthKey", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPushOauthKey_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPushOauthKey", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getPushOauthSecret;
#pragma warning disable 0169
		static Delegate GetGetPushOauthSecretHandler ()
		{
			if (cb_getPushOauthSecret == null)
				cb_getPushOauthSecret = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPushOauthSecret);
			return cb_getPushOauthSecret;
		}

		static IntPtr n_GetPushOauthSecret (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PushOauthSecret);
		}
#pragma warning restore 0169

		static Delegate cb_setPushOauthSecret_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetPushOauthSecret_Ljava_lang_String_Handler ()
		{
			if (cb_setPushOauthSecret_Ljava_lang_String_ == null)
				cb_setPushOauthSecret_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPushOauthSecret_Ljava_lang_String_);
			return cb_setPushOauthSecret_Ljava_lang_String_;
		}

		static void n_SetPushOauthSecret_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PushOauthSecret = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getPushOauthSecret;
		static IntPtr id_setPushOauthSecret_Ljava_lang_String_;
		public virtual unsafe string PushOauthSecret {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getPushOauthSecret' and count(parameter)=0]"
			[Register ("getPushOauthSecret", "()Ljava/lang/String;", "GetGetPushOauthSecretHandler")]
			get {
				if (id_getPushOauthSecret == IntPtr.Zero)
					id_getPushOauthSecret = JNIEnv.GetMethodID (class_ref, "getPushOauthSecret", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPushOauthSecret), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPushOauthSecret", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setPushOauthSecret' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setPushOauthSecret", "(Ljava/lang/String;)V", "GetSetPushOauthSecret_Ljava_lang_String_Handler")]
			set {
				if (id_setPushOauthSecret_Ljava_lang_String_ == IntPtr.Zero)
					id_setPushOauthSecret_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setPushOauthSecret", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPushOauthSecret_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPushOauthSecret", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getRealtimeTranslation;
#pragma warning disable 0169
		static Delegate GetGetRealtimeTranslationHandler ()
		{
			if (cb_getRealtimeTranslation == null)
				cb_getRealtimeTranslation = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRealtimeTranslation);
			return cb_getRealtimeTranslation;
		}

		static IntPtr n_GetRealtimeTranslation (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RealtimeTranslation);
		}
#pragma warning restore 0169

		static Delegate cb_setRealtimeTranslation_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetRealtimeTranslation_Ljava_lang_String_Handler ()
		{
			if (cb_setRealtimeTranslation_Ljava_lang_String_ == null)
				cb_setRealtimeTranslation_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetRealtimeTranslation_Ljava_lang_String_);
			return cb_setRealtimeTranslation_Ljava_lang_String_;
		}

		static void n_SetRealtimeTranslation_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RealtimeTranslation = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getRealtimeTranslation;
		static IntPtr id_setRealtimeTranslation_Ljava_lang_String_;
		public virtual unsafe string RealtimeTranslation {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getRealtimeTranslation' and count(parameter)=0]"
			[Register ("getRealtimeTranslation", "()Ljava/lang/String;", "GetGetRealtimeTranslationHandler")]
			get {
				if (id_getRealtimeTranslation == IntPtr.Zero)
					id_getRealtimeTranslation = JNIEnv.GetMethodID (class_ref, "getRealtimeTranslation", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRealtimeTranslation), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRealtimeTranslation", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setRealtimeTranslation' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setRealtimeTranslation", "(Ljava/lang/String;)V", "GetSetRealtimeTranslation_Ljava_lang_String_Handler")]
			set {
				if (id_setRealtimeTranslation_Ljava_lang_String_ == IntPtr.Zero)
					id_setRealtimeTranslation_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setRealtimeTranslation", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRealtimeTranslation_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setRealtimeTranslation", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getReportEnabled;
#pragma warning disable 0169
		static Delegate GetGetReportEnabledHandler ()
		{
			if (cb_getReportEnabled == null)
				cb_getReportEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReportEnabled);
			return cb_getReportEnabled;
		}

		static IntPtr n_GetReportEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ReportEnabled);
		}
#pragma warning restore 0169

		static Delegate cb_setReportEnabled_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetReportEnabled_Ljava_lang_String_Handler ()
		{
			if (cb_setReportEnabled_Ljava_lang_String_ == null)
				cb_setReportEnabled_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetReportEnabled_Ljava_lang_String_);
			return cb_setReportEnabled_Ljava_lang_String_;
		}

		static void n_SetReportEnabled_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ReportEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getReportEnabled;
		static IntPtr id_setReportEnabled_Ljava_lang_String_;
		public virtual unsafe string ReportEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getReportEnabled' and count(parameter)=0]"
			[Register ("getReportEnabled", "()Ljava/lang/String;", "GetGetReportEnabledHandler")]
			get {
				if (id_getReportEnabled == IntPtr.Zero)
					id_getReportEnabled = JNIEnv.GetMethodID (class_ref, "getReportEnabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReportEnabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReportEnabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setReportEnabled' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setReportEnabled", "(Ljava/lang/String;)V", "GetSetReportEnabled_Ljava_lang_String_Handler")]
			set {
				if (id_setReportEnabled_Ljava_lang_String_ == IntPtr.Zero)
					id_setReportEnabled_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setReportEnabled", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setReportEnabled_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setReportEnabled", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getResponseHash;
#pragma warning disable 0169
		static Delegate GetGetResponseHashHandler ()
		{
			if (cb_getResponseHash == null)
				cb_getResponseHash = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetResponseHash);
			return cb_getResponseHash;
		}

		static IntPtr n_GetResponseHash (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ResponseHash);
		}
#pragma warning restore 0169

		static Delegate cb_setResponseHash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetResponseHash_Ljava_lang_String_Handler ()
		{
			if (cb_setResponseHash_Ljava_lang_String_ == null)
				cb_setResponseHash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetResponseHash_Ljava_lang_String_);
			return cb_setResponseHash_Ljava_lang_String_;
		}

		static void n_SetResponseHash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ResponseHash = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getResponseHash;
		static IntPtr id_setResponseHash_Ljava_lang_String_;
		public virtual unsafe string ResponseHash {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getResponseHash' and count(parameter)=0]"
			[Register ("getResponseHash", "()Ljava/lang/String;", "GetGetResponseHashHandler")]
			get {
				if (id_getResponseHash == IntPtr.Zero)
					id_getResponseHash = JNIEnv.GetMethodID (class_ref, "getResponseHash", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getResponseHash), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getResponseHash", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setResponseHash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setResponseHash", "(Ljava/lang/String;)V", "GetSetResponseHash_Ljava_lang_String_Handler")]
			set {
				if (id_setResponseHash_Ljava_lang_String_ == IntPtr.Zero)
					id_setResponseHash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setResponseHash", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setResponseHash_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setResponseHash", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWebRTCServer;
#pragma warning disable 0169
		static Delegate GetGetWebRTCServerHandler ()
		{
			if (cb_getWebRTCServer == null)
				cb_getWebRTCServer = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWebRTCServer);
			return cb_getWebRTCServer;
		}

		static IntPtr n_GetWebRTCServer (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WebRTCServer);
		}
#pragma warning restore 0169

		static Delegate cb_setWebRTCServer_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWebRTCServer_Ljava_lang_String_Handler ()
		{
			if (cb_setWebRTCServer_Ljava_lang_String_ == null)
				cb_setWebRTCServer_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWebRTCServer_Ljava_lang_String_);
			return cb_setWebRTCServer_Ljava_lang_String_;
		}

		static void n_SetWebRTCServer_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.WebRTCServer = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWebRTCServer;
		static IntPtr id_setWebRTCServer_Ljava_lang_String_;
		public virtual unsafe string WebRTCServer {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getWebRTCServer' and count(parameter)=0]"
			[Register ("getWebRTCServer", "()Ljava/lang/String;", "GetGetWebRTCServerHandler")]
			get {
				if (id_getWebRTCServer == IntPtr.Zero)
					id_getWebRTCServer = JNIEnv.GetMethodID (class_ref, "getWebRTCServer", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWebRTCServer), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWebRTCServer", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setWebRTCServer' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setWebRTCServer", "(Ljava/lang/String;)V", "GetSetWebRTCServer_Ljava_lang_String_Handler")]
			set {
				if (id_setWebRTCServer_Ljava_lang_String_ == IntPtr.Zero)
					id_setWebRTCServer_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWebRTCServer", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWebRTCServer_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWebRTCServer", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWebsyncServer;
#pragma warning disable 0169
		static Delegate GetGetWebsyncServerHandler ()
		{
			if (cb_getWebsyncServer == null)
				cb_getWebsyncServer = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWebsyncServer);
			return cb_getWebsyncServer;
		}

		static IntPtr n_GetWebsyncServer (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.WebsyncServer);
		}
#pragma warning restore 0169

		static Delegate cb_setWebsyncServer_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetWebsyncServer_Ljava_lang_String_Handler ()
		{
			if (cb_setWebsyncServer_Ljava_lang_String_ == null)
				cb_setWebsyncServer_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWebsyncServer_Ljava_lang_String_);
			return cb_setWebsyncServer_Ljava_lang_String_;
		}

		static void n_SetWebsyncServer_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.JsonPhp __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.JsonPhp> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.WebsyncServer = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWebsyncServer;
		static IntPtr id_setWebsyncServer_Ljava_lang_String_;
		public virtual unsafe string WebsyncServer {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='getWebsyncServer' and count(parameter)=0]"
			[Register ("getWebsyncServer", "()Ljava/lang/String;", "GetGetWebsyncServerHandler")]
			get {
				if (id_getWebsyncServer == IntPtr.Zero)
					id_getWebsyncServer = JNIEnv.GetMethodID (class_ref, "getWebsyncServer", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWebsyncServer), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWebsyncServer", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='JsonPhp']/method[@name='setWebsyncServer' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setWebsyncServer", "(Ljava/lang/String;)V", "GetSetWebsyncServer_Ljava_lang_String_Handler")]
			set {
				if (id_setWebsyncServer_Ljava_lang_String_ == IntPtr.Zero)
					id_setWebsyncServer_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setWebsyncServer", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWebsyncServer_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWebsyncServer", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

	}
}
