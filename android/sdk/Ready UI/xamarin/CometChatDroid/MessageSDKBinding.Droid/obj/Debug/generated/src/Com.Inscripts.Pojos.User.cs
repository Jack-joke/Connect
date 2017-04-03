using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Pojos {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']"
	[global::Android.Runtime.Register ("com/inscripts/pojos/User", DoNotGenerateAcw=true)]
	public partial class User : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/pojos/User", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (User); }
		}

		protected User (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/constructor[@name='User' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe User ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (User)) {
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

		static Delegate cb_getAvatarLink;
#pragma warning disable 0169
		static Delegate GetGetAvatarLinkHandler ()
		{
			if (cb_getAvatarLink == null)
				cb_getAvatarLink = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvatarLink);
			return cb_getAvatarLink;
		}

		static IntPtr n_GetAvatarLink (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvatarLink);
		}
#pragma warning restore 0169

		static Delegate cb_setAvatarLink_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvatarLink_Ljava_lang_String_Handler ()
		{
			if (cb_setAvatarLink_Ljava_lang_String_ == null)
				cb_setAvatarLink_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvatarLink_Ljava_lang_String_);
			return cb_setAvatarLink_Ljava_lang_String_;
		}

		static void n_SetAvatarLink_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvatarLink = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvatarLink;
		static IntPtr id_setAvatarLink_Ljava_lang_String_;
		public virtual unsafe string AvatarLink {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getAvatarLink' and count(parameter)=0]"
			[Register ("getAvatarLink", "()Ljava/lang/String;", "GetGetAvatarLinkHandler")]
			get {
				if (id_getAvatarLink == IntPtr.Zero)
					id_getAvatarLink = JNIEnv.GetMethodID (class_ref, "getAvatarLink", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvatarLink), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvatarLink", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setAvatarLink' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvatarLink", "(Ljava/lang/String;)V", "GetSetAvatarLink_Ljava_lang_String_Handler")]
			set {
				if (id_setAvatarLink_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvatarLink_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvatarLink", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvatarLink_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvatarLink", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getGroup;
#pragma warning disable 0169
		static Delegate GetGetGroupHandler ()
		{
			if (cb_getGroup == null)
				cb_getGroup = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetGroup);
			return cb_getGroup;
		}

		static IntPtr n_GetGroup (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Group);
		}
#pragma warning restore 0169

		static IntPtr id_getGroup;
		public virtual unsafe string Group {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getGroup' and count(parameter)=0]"
			[Register ("getGroup", "()Ljava/lang/String;", "GetGetGroupHandler")]
			get {
				if (id_getGroup == IntPtr.Zero)
					id_getGroup = JNIEnv.GetMethodID (class_ref, "getGroup", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getGroup), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getGroup", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getId;
#pragma warning disable 0169
		static Delegate GetGetIdHandler ()
		{
			if (cb_getId == null)
				cb_getId = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetId);
			return cb_getId;
		}

		static long n_GetId (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Id;
		}
#pragma warning restore 0169

		static IntPtr id_getId;
		public virtual unsafe long Id {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getId' and count(parameter)=0]"
			[Register ("getId", "()J", "GetGetIdHandler")]
			get {
				if (id_getId == IntPtr.Zero)
					id_getId = JNIEnv.GetMethodID (class_ref, "getId", "()J");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getId);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getId", "()J"));
				} finally {
				}
			}
		}

		static Delegate cb_getLink;
#pragma warning disable 0169
		static Delegate GetGetLinkHandler ()
		{
			if (cb_getLink == null)
				cb_getLink = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLink);
			return cb_getLink;
		}

		static IntPtr n_GetLink (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Link);
		}
#pragma warning restore 0169

		static Delegate cb_setLink_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetLink_Ljava_lang_String_Handler ()
		{
			if (cb_setLink_Ljava_lang_String_ == null)
				cb_setLink_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetLink_Ljava_lang_String_);
			return cb_setLink_Ljava_lang_String_;
		}

		static void n_SetLink_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Link = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getLink;
		static IntPtr id_setLink_Ljava_lang_String_;
		public virtual unsafe string Link {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getLink' and count(parameter)=0]"
			[Register ("getLink", "()Ljava/lang/String;", "GetGetLinkHandler")]
			get {
				if (id_getLink == IntPtr.Zero)
					id_getLink = JNIEnv.GetMethodID (class_ref, "getLink", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLink), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLink", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setLink' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setLink", "(Ljava/lang/String;)V", "GetSetLink_Ljava_lang_String_Handler")]
			set {
				if (id_setLink_Ljava_lang_String_ == IntPtr.Zero)
					id_setLink_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setLink", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLink_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLink", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getName;
#pragma warning disable 0169
		static Delegate GetGetNameHandler ()
		{
			if (cb_getName == null)
				cb_getName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetName);
			return cb_getName;
		}

		static IntPtr n_GetName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Name);
		}
#pragma warning restore 0169

		static Delegate cb_setName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetName_Ljava_lang_String_Handler ()
		{
			if (cb_setName_Ljava_lang_String_ == null)
				cb_setName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetName_Ljava_lang_String_);
			return cb_setName_Ljava_lang_String_;
		}

		static void n_SetName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Name = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getName;
		static IntPtr id_setName_Ljava_lang_String_;
		public virtual unsafe string Name {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getName' and count(parameter)=0]"
			[Register ("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get {
				if (id_getName == IntPtr.Zero)
					id_getName = JNIEnv.GetMethodID (class_ref, "getName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setName", "(Ljava/lang/String;)V", "GetSetName_Ljava_lang_String_Handler")]
			set {
				if (id_setName_Ljava_lang_String_ == IntPtr.Zero)
					id_setName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getStatus;
#pragma warning disable 0169
		static Delegate GetGetStatusHandler ()
		{
			if (cb_getStatus == null)
				cb_getStatus = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetStatus);
			return cb_getStatus;
		}

		static IntPtr n_GetStatus (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Status);
		}
#pragma warning restore 0169

		static Delegate cb_setStatus_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetStatus_Ljava_lang_String_Handler ()
		{
			if (cb_setStatus_Ljava_lang_String_ == null)
				cb_setStatus_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetStatus_Ljava_lang_String_);
			return cb_setStatus_Ljava_lang_String_;
		}

		static void n_SetStatus_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Status = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getStatus;
		static IntPtr id_setStatus_Ljava_lang_String_;
		public virtual unsafe string Status {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getStatus' and count(parameter)=0]"
			[Register ("getStatus", "()Ljava/lang/String;", "GetGetStatusHandler")]
			get {
				if (id_getStatus == IntPtr.Zero)
					id_getStatus = JNIEnv.GetMethodID (class_ref, "getStatus", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getStatus), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStatus", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setStatus' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setStatus", "(Ljava/lang/String;)V", "GetSetStatus_Ljava_lang_String_Handler")]
			set {
				if (id_setStatus_Ljava_lang_String_ == IntPtr.Zero)
					id_setStatus_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setStatus", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setStatus_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStatus", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getStatusMessage;
#pragma warning disable 0169
		static Delegate GetGetStatusMessageHandler ()
		{
			if (cb_getStatusMessage == null)
				cb_getStatusMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetStatusMessage);
			return cb_getStatusMessage;
		}

		static IntPtr n_GetStatusMessage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.StatusMessage);
		}
#pragma warning restore 0169

		static Delegate cb_setStatusMessage_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetStatusMessage_Ljava_lang_String_Handler ()
		{
			if (cb_setStatusMessage_Ljava_lang_String_ == null)
				cb_setStatusMessage_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetStatusMessage_Ljava_lang_String_);
			return cb_setStatusMessage_Ljava_lang_String_;
		}

		static void n_SetStatusMessage_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.StatusMessage = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getStatusMessage;
		static IntPtr id_setStatusMessage_Ljava_lang_String_;
		public virtual unsafe string StatusMessage {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getStatusMessage' and count(parameter)=0]"
			[Register ("getStatusMessage", "()Ljava/lang/String;", "GetGetStatusMessageHandler")]
			get {
				if (id_getStatusMessage == IntPtr.Zero)
					id_getStatusMessage = JNIEnv.GetMethodID (class_ref, "getStatusMessage", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getStatusMessage), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStatusMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setStatusMessage' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setStatusMessage", "(Ljava/lang/String;)V", "GetSetStatusMessage_Ljava_lang_String_Handler")]
			set {
				if (id_setStatusMessage_Ljava_lang_String_ == IntPtr.Zero)
					id_setStatusMessage_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setStatusMessage", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setStatusMessage_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStatusMessage", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getUnreadCount;
#pragma warning disable 0169
		static Delegate GetGetUnreadCountHandler ()
		{
			if (cb_getUnreadCount == null)
				cb_getUnreadCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUnreadCount);
			return cb_getUnreadCount;
		}

		static IntPtr n_GetUnreadCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UnreadCount);
		}
#pragma warning restore 0169

		static Delegate cb_setUnreadCount_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetUnreadCount_Ljava_lang_String_Handler ()
		{
			if (cb_setUnreadCount_Ljava_lang_String_ == null)
				cb_setUnreadCount_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetUnreadCount_Ljava_lang_String_);
			return cb_setUnreadCount_Ljava_lang_String_;
		}

		static void n_SetUnreadCount_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.UnreadCount = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getUnreadCount;
		static IntPtr id_setUnreadCount_Ljava_lang_String_;
		public virtual unsafe string UnreadCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='getUnreadCount' and count(parameter)=0]"
			[Register ("getUnreadCount", "()Ljava/lang/String;", "GetGetUnreadCountHandler")]
			get {
				if (id_getUnreadCount == IntPtr.Zero)
					id_getUnreadCount = JNIEnv.GetMethodID (class_ref, "getUnreadCount", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUnreadCount), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUnreadCount", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setUnreadCount' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setUnreadCount", "(Ljava/lang/String;)V", "GetSetUnreadCount_Ljava_lang_String_Handler")]
			set {
				if (id_setUnreadCount_Ljava_lang_String_ == IntPtr.Zero)
					id_setUnreadCount_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setUnreadCount", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUnreadCount_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setUnreadCount", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_setId_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSetId_Ljava_lang_Long_Handler ()
		{
			if (cb_setId_Ljava_lang_Long_ == null)
				cb_setId_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetId_Ljava_lang_Long_);
			return cb_setId_Ljava_lang_Long_;
		}

		static void n_SetId_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetId (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setId_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setId' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
		[Register ("setId", "(Ljava/lang/Long;)V", "GetSetId_Ljava_lang_Long_Handler")]
		public virtual unsafe void SetId (global::Java.Lang.Long p0)
		{
			if (id_setId_Ljava_lang_Long_ == IntPtr.Zero)
				id_setId_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "setId", "(Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setId_Ljava_lang_Long_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setId", "(Ljava/lang/Long;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setUserGroup_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetUserGroup_Ljava_lang_String_Handler ()
		{
			if (cb_setUserGroup_Ljava_lang_String_ == null)
				cb_setUserGroup_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetUserGroup_Ljava_lang_String_);
			return cb_setUserGroup_Ljava_lang_String_;
		}

		static void n_SetUserGroup_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.User __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.User> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetUserGroup (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setUserGroup_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='User']/method[@name='setUserGroup' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setUserGroup", "(Ljava/lang/String;)V", "GetSetUserGroup_Ljava_lang_String_Handler")]
		public virtual unsafe void SetUserGroup (string p0)
		{
			if (id_setUserGroup_Ljava_lang_String_ == IntPtr.Zero)
				id_setUserGroup_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setUserGroup", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUserGroup_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setUserGroup", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
