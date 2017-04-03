using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Pojos {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']"
	[global::Android.Runtime.Register ("com/inscripts/pojos/ChatroomMembers", DoNotGenerateAcw=true)]
	public partial class ChatroomMembers : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/pojos/ChatroomMembers", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ChatroomMembers); }
		}

		protected ChatroomMembers (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/constructor[@name='ChatroomMembers' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ChatroomMembers ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ChatroomMembers)) {
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

		static Delegate cb_getAvatarUrl;
#pragma warning disable 0169
		static Delegate GetGetAvatarUrlHandler ()
		{
			if (cb_getAvatarUrl == null)
				cb_getAvatarUrl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvatarUrl);
			return cb_getAvatarUrl;
		}

		static IntPtr n_GetAvatarUrl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvatarUrl);
		}
#pragma warning restore 0169

		static Delegate cb_setAvatarUrl_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvatarUrl_Ljava_lang_String_Handler ()
		{
			if (cb_setAvatarUrl_Ljava_lang_String_ == null)
				cb_setAvatarUrl_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvatarUrl_Ljava_lang_String_);
			return cb_setAvatarUrl_Ljava_lang_String_;
		}

		static void n_SetAvatarUrl_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvatarUrl = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvatarUrl;
		static IntPtr id_setAvatarUrl_Ljava_lang_String_;
		public virtual unsafe string AvatarUrl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='getAvatarUrl' and count(parameter)=0]"
			[Register ("getAvatarUrl", "()Ljava/lang/String;", "GetGetAvatarUrlHandler")]
			get {
				if (id_getAvatarUrl == IntPtr.Zero)
					id_getAvatarUrl = JNIEnv.GetMethodID (class_ref, "getAvatarUrl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvatarUrl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvatarUrl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='setAvatarUrl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvatarUrl", "(Ljava/lang/String;)V", "GetSetAvatarUrl_Ljava_lang_String_Handler")]
			set {
				if (id_setAvatarUrl_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvatarUrl_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvatarUrl", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvatarUrl_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvatarUrl", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getBanned;
#pragma warning disable 0169
		static Delegate GetGetBannedHandler ()
		{
			if (cb_getBanned == null)
				cb_getBanned = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBanned);
			return cb_getBanned;
		}

		static int n_GetBanned (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Banned;
		}
#pragma warning restore 0169

		static Delegate cb_setBanned_I;
#pragma warning disable 0169
		static Delegate GetSetBanned_IHandler ()
		{
			if (cb_setBanned_I == null)
				cb_setBanned_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBanned_I);
			return cb_setBanned_I;
		}

		static void n_SetBanned_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Banned = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBanned;
		static IntPtr id_setBanned_I;
		public virtual unsafe int Banned {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='getBanned' and count(parameter)=0]"
			[Register ("getBanned", "()I", "GetGetBannedHandler")]
			get {
				if (id_getBanned == IntPtr.Zero)
					id_getBanned = JNIEnv.GetMethodID (class_ref, "getBanned", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBanned);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBanned", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='setBanned' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBanned", "(I)V", "GetSetBanned_IHandler")]
			set {
				if (id_setBanned_I == IntPtr.Zero)
					id_setBanned_I = JNIEnv.GetMethodID (class_ref, "setBanned", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBanned_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBanned", "(I)V"), __args);
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
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Id;
		}
#pragma warning restore 0169

		static Delegate cb_setId_J;
#pragma warning disable 0169
		static Delegate GetSetId_JHandler ()
		{
			if (cb_setId_J == null)
				cb_setId_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetId_J);
			return cb_setId_J;
		}

		static void n_SetId_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Id = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getId;
		static IntPtr id_setId_J;
		public virtual unsafe long Id {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='getId' and count(parameter)=0]"
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
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='setId' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setId", "(J)V", "GetSetId_JHandler")]
			set {
				if (id_setId_J == IntPtr.Zero)
					id_setId_J = JNIEnv.GetMethodID (class_ref, "setId", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setId_J, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setId", "(J)V"), __args);
				} finally {
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
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Com.Inscripts.Pojos.ChatroomMembers __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ChatroomMembers> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Name = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getName;
		static IntPtr id_setName_Ljava_lang_String_;
		public virtual unsafe string Name {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='getName' and count(parameter)=0]"
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
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ChatroomMembers']/method[@name='setName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
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

	}
}
