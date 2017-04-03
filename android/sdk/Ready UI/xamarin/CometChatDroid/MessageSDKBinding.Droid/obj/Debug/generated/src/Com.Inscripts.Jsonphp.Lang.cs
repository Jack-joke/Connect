using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Lang", DoNotGenerateAcw=true)]
	public partial class Lang : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Lang", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Lang); }
		}

		protected Lang (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/constructor[@name='Lang' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Lang ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Lang)) {
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

		static Delegate cb_getAnnouncements;
#pragma warning disable 0169
		static Delegate GetGetAnnouncementsHandler ()
		{
			if (cb_getAnnouncements == null)
				cb_getAnnouncements = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAnnouncements);
			return cb_getAnnouncements;
		}

		static IntPtr n_GetAnnouncements (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Announcements);
		}
#pragma warning restore 0169

		static Delegate cb_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_;
#pragma warning disable 0169
		static Delegate GetSetAnnouncements_Lcom_inscripts_jsonphp_Announcements_Handler ()
		{
			if (cb_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_ == null)
				cb_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAnnouncements_Lcom_inscripts_jsonphp_Announcements_);
			return cb_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_;
		}

		static void n_SetAnnouncements_Lcom_inscripts_jsonphp_Announcements_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Announcements p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Announcements> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Announcements = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAnnouncements;
		static IntPtr id_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Announcements Announcements {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getAnnouncements' and count(parameter)=0]"
			[Register ("getAnnouncements", "()Lcom/inscripts/jsonphp/Announcements;", "GetGetAnnouncementsHandler")]
			get {
				if (id_getAnnouncements == IntPtr.Zero)
					id_getAnnouncements = JNIEnv.GetMethodID (class_ref, "getAnnouncements", "()Lcom/inscripts/jsonphp/Announcements;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Announcements> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnouncements), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Announcements> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAnnouncements", "()Lcom/inscripts/jsonphp/Announcements;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setAnnouncements' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Announcements']]"
			[Register ("setAnnouncements", "(Lcom/inscripts/jsonphp/Announcements;)V", "GetSetAnnouncements_Lcom_inscripts_jsonphp_Announcements_Handler")]
			set {
				if (id_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_ == IntPtr.Zero)
					id_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_ = JNIEnv.GetMethodID (class_ref, "setAnnouncements", "(Lcom/inscripts/jsonphp/Announcements;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAnnouncements_Lcom_inscripts_jsonphp_Announcements_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAnnouncements", "(Lcom/inscripts/jsonphp/Announcements;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getAudiochat;
#pragma warning disable 0169
		static Delegate GetGetAudiochatHandler ()
		{
			if (cb_getAudiochat == null)
				cb_getAudiochat = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAudiochat);
			return cb_getAudiochat;
		}

		static IntPtr n_GetAudiochat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Audiochat);
		}
#pragma warning restore 0169

		static Delegate cb_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_;
#pragma warning disable 0169
		static Delegate GetSetAudiochat_Lcom_inscripts_jsonphp_Audiochat_Handler ()
		{
			if (cb_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_ == null)
				cb_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAudiochat_Lcom_inscripts_jsonphp_Audiochat_);
			return cb_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_;
		}

		static void n_SetAudiochat_Lcom_inscripts_jsonphp_Audiochat_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Audiochat p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Audiochat = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAudiochat;
		static IntPtr id_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Audiochat Audiochat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getAudiochat' and count(parameter)=0]"
			[Register ("getAudiochat", "()Lcom/inscripts/jsonphp/Audiochat;", "GetGetAudiochatHandler")]
			get {
				if (id_getAudiochat == IntPtr.Zero)
					id_getAudiochat = JNIEnv.GetMethodID (class_ref, "getAudiochat", "()Lcom/inscripts/jsonphp/Audiochat;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudiochat), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Audiochat> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAudiochat", "()Lcom/inscripts/jsonphp/Audiochat;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setAudiochat' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Audiochat']]"
			[Register ("setAudiochat", "(Lcom/inscripts/jsonphp/Audiochat;)V", "GetSetAudiochat_Lcom_inscripts_jsonphp_Audiochat_Handler")]
			set {
				if (id_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_ == IntPtr.Zero)
					id_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_ = JNIEnv.GetMethodID (class_ref, "setAudiochat", "(Lcom/inscripts/jsonphp/Audiochat;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudiochat_Lcom_inscripts_jsonphp_Audiochat_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAudiochat", "(Lcom/inscripts/jsonphp/Audiochat;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getAvchat;
#pragma warning disable 0169
		static Delegate GetGetAvchatHandler ()
		{
			if (cb_getAvchat == null)
				cb_getAvchat = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvchat);
			return cb_getAvchat;
		}

		static IntPtr n_GetAvchat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Avchat);
		}
#pragma warning restore 0169

		static Delegate cb_setAvchat_Lcom_inscripts_jsonphp_Avchat_;
#pragma warning disable 0169
		static Delegate GetSetAvchat_Lcom_inscripts_jsonphp_Avchat_Handler ()
		{
			if (cb_setAvchat_Lcom_inscripts_jsonphp_Avchat_ == null)
				cb_setAvchat_Lcom_inscripts_jsonphp_Avchat_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvchat_Lcom_inscripts_jsonphp_Avchat_);
			return cb_setAvchat_Lcom_inscripts_jsonphp_Avchat_;
		}

		static void n_SetAvchat_Lcom_inscripts_jsonphp_Avchat_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Avchat p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Avchat> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Avchat = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvchat;
		static IntPtr id_setAvchat_Lcom_inscripts_jsonphp_Avchat_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Avchat Avchat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getAvchat' and count(parameter)=0]"
			[Register ("getAvchat", "()Lcom/inscripts/jsonphp/Avchat;", "GetGetAvchatHandler")]
			get {
				if (id_getAvchat == IntPtr.Zero)
					id_getAvchat = JNIEnv.GetMethodID (class_ref, "getAvchat", "()Lcom/inscripts/jsonphp/Avchat;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Avchat> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvchat), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Avchat> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvchat", "()Lcom/inscripts/jsonphp/Avchat;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setAvchat' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Avchat']]"
			[Register ("setAvchat", "(Lcom/inscripts/jsonphp/Avchat;)V", "GetSetAvchat_Lcom_inscripts_jsonphp_Avchat_Handler")]
			set {
				if (id_setAvchat_Lcom_inscripts_jsonphp_Avchat_ == IntPtr.Zero)
					id_setAvchat_Lcom_inscripts_jsonphp_Avchat_ = JNIEnv.GetMethodID (class_ref, "setAvchat", "(Lcom/inscripts/jsonphp/Avchat;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvchat_Lcom_inscripts_jsonphp_Avchat_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvchat", "(Lcom/inscripts/jsonphp/Avchat;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getBlock;
#pragma warning disable 0169
		static Delegate GetGetBlockHandler ()
		{
			if (cb_getBlock == null)
				cb_getBlock = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBlock);
			return cb_getBlock;
		}

		static IntPtr n_GetBlock (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Block);
		}
#pragma warning restore 0169

		static Delegate cb_setBlock_Lcom_inscripts_jsonphp_Block_;
#pragma warning disable 0169
		static Delegate GetSetBlock_Lcom_inscripts_jsonphp_Block_Handler ()
		{
			if (cb_setBlock_Lcom_inscripts_jsonphp_Block_ == null)
				cb_setBlock_Lcom_inscripts_jsonphp_Block_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBlock_Lcom_inscripts_jsonphp_Block_);
			return cb_setBlock_Lcom_inscripts_jsonphp_Block_;
		}

		static void n_SetBlock_Lcom_inscripts_jsonphp_Block_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Block p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Block> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Block = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBlock;
		static IntPtr id_setBlock_Lcom_inscripts_jsonphp_Block_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Block Block {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getBlock' and count(parameter)=0]"
			[Register ("getBlock", "()Lcom/inscripts/jsonphp/Block;", "GetGetBlockHandler")]
			get {
				if (id_getBlock == IntPtr.Zero)
					id_getBlock = JNIEnv.GetMethodID (class_ref, "getBlock", "()Lcom/inscripts/jsonphp/Block;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Block> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBlock), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Block> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBlock", "()Lcom/inscripts/jsonphp/Block;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setBlock' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Block']]"
			[Register ("setBlock", "(Lcom/inscripts/jsonphp/Block;)V", "GetSetBlock_Lcom_inscripts_jsonphp_Block_Handler")]
			set {
				if (id_setBlock_Lcom_inscripts_jsonphp_Block_ == IntPtr.Zero)
					id_setBlock_Lcom_inscripts_jsonphp_Block_ = JNIEnv.GetMethodID (class_ref, "setBlock", "(Lcom/inscripts/jsonphp/Block;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBlock_Lcom_inscripts_jsonphp_Block_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBlock", "(Lcom/inscripts/jsonphp/Block;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getChatrooms;
#pragma warning disable 0169
		static Delegate GetGetChatroomsHandler ()
		{
			if (cb_getChatrooms == null)
				cb_getChatrooms = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatrooms);
			return cb_getChatrooms;
		}

		static IntPtr n_GetChatrooms (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Chatrooms);
		}
#pragma warning restore 0169

		static Delegate cb_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_;
#pragma warning disable 0169
		static Delegate GetSetChatrooms_Lcom_inscripts_jsonphp_Chatrooms_Handler ()
		{
			if (cb_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_ == null)
				cb_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatrooms_Lcom_inscripts_jsonphp_Chatrooms_);
			return cb_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_;
		}

		static void n_SetChatrooms_Lcom_inscripts_jsonphp_Chatrooms_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Chatrooms p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Chatrooms> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Chatrooms = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatrooms;
		static IntPtr id_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Chatrooms Chatrooms {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getChatrooms' and count(parameter)=0]"
			[Register ("getChatrooms", "()Lcom/inscripts/jsonphp/Chatrooms;", "GetGetChatroomsHandler")]
			get {
				if (id_getChatrooms == IntPtr.Zero)
					id_getChatrooms = JNIEnv.GetMethodID (class_ref, "getChatrooms", "()Lcom/inscripts/jsonphp/Chatrooms;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Chatrooms> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatrooms), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Chatrooms> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatrooms", "()Lcom/inscripts/jsonphp/Chatrooms;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setChatrooms' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Chatrooms']]"
			[Register ("setChatrooms", "(Lcom/inscripts/jsonphp/Chatrooms;)V", "GetSetChatrooms_Lcom_inscripts_jsonphp_Chatrooms_Handler")]
			set {
				if (id_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_ == IntPtr.Zero)
					id_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_ = JNIEnv.GetMethodID (class_ref, "setChatrooms", "(Lcom/inscripts/jsonphp/Chatrooms;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatrooms_Lcom_inscripts_jsonphp_Chatrooms_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatrooms", "(Lcom/inscripts/jsonphp/Chatrooms;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getClearconversation;
#pragma warning disable 0169
		static Delegate GetGetClearconversationHandler ()
		{
			if (cb_getClearconversation == null)
				cb_getClearconversation = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetClearconversation);
			return cb_getClearconversation;
		}

		static IntPtr n_GetClearconversation (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Clearconversation);
		}
#pragma warning restore 0169

		static Delegate cb_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_;
#pragma warning disable 0169
		static Delegate GetSetClearconversation_Lcom_inscripts_jsonphp_Clearconversation_Handler ()
		{
			if (cb_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_ == null)
				cb_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetClearconversation_Lcom_inscripts_jsonphp_Clearconversation_);
			return cb_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_;
		}

		static void n_SetClearconversation_Lcom_inscripts_jsonphp_Clearconversation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Clearconversation p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Clearconversation> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Clearconversation = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getClearconversation;
		static IntPtr id_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Clearconversation Clearconversation {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getClearconversation' and count(parameter)=0]"
			[Register ("getClearconversation", "()Lcom/inscripts/jsonphp/Clearconversation;", "GetGetClearconversationHandler")]
			get {
				if (id_getClearconversation == IntPtr.Zero)
					id_getClearconversation = JNIEnv.GetMethodID (class_ref, "getClearconversation", "()Lcom/inscripts/jsonphp/Clearconversation;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Clearconversation> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getClearconversation), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Clearconversation> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getClearconversation", "()Lcom/inscripts/jsonphp/Clearconversation;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setClearconversation' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Clearconversation']]"
			[Register ("setClearconversation", "(Lcom/inscripts/jsonphp/Clearconversation;)V", "GetSetClearconversation_Lcom_inscripts_jsonphp_Clearconversation_Handler")]
			set {
				if (id_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_ == IntPtr.Zero)
					id_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_ = JNIEnv.GetMethodID (class_ref, "setClearconversation", "(Lcom/inscripts/jsonphp/Clearconversation;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setClearconversation_Lcom_inscripts_jsonphp_Clearconversation_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setClearconversation", "(Lcom/inscripts/jsonphp/Clearconversation;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCore;
#pragma warning disable 0169
		static Delegate GetGetCoreHandler ()
		{
			if (cb_getCore == null)
				cb_getCore = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCore);
			return cb_getCore;
		}

		static IntPtr n_GetCore (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Core);
		}
#pragma warning restore 0169

		static Delegate cb_setCore_Lcom_inscripts_jsonphp_Core_;
#pragma warning disable 0169
		static Delegate GetSetCore_Lcom_inscripts_jsonphp_Core_Handler ()
		{
			if (cb_setCore_Lcom_inscripts_jsonphp_Core_ == null)
				cb_setCore_Lcom_inscripts_jsonphp_Core_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCore_Lcom_inscripts_jsonphp_Core_);
			return cb_setCore_Lcom_inscripts_jsonphp_Core_;
		}

		static void n_SetCore_Lcom_inscripts_jsonphp_Core_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Core p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Core = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCore;
		static IntPtr id_setCore_Lcom_inscripts_jsonphp_Core_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Core Core {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getCore' and count(parameter)=0]"
			[Register ("getCore", "()Lcom/inscripts/jsonphp/Core;", "GetGetCoreHandler")]
			get {
				if (id_getCore == IntPtr.Zero)
					id_getCore = JNIEnv.GetMethodID (class_ref, "getCore", "()Lcom/inscripts/jsonphp/Core;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCore), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Core> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCore", "()Lcom/inscripts/jsonphp/Core;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setCore' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Core']]"
			[Register ("setCore", "(Lcom/inscripts/jsonphp/Core;)V", "GetSetCore_Lcom_inscripts_jsonphp_Core_Handler")]
			set {
				if (id_setCore_Lcom_inscripts_jsonphp_Core_ == IntPtr.Zero)
					id_setCore_Lcom_inscripts_jsonphp_Core_ = JNIEnv.GetMethodID (class_ref, "setCore", "(Lcom/inscripts/jsonphp/Core;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCore_Lcom_inscripts_jsonphp_Core_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCore", "(Lcom/inscripts/jsonphp/Core;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getFiletransfer;
#pragma warning disable 0169
		static Delegate GetGetFiletransferHandler ()
		{
			if (cb_getFiletransfer == null)
				cb_getFiletransfer = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFiletransfer);
			return cb_getFiletransfer;
		}

		static IntPtr n_GetFiletransfer (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Filetransfer);
		}
#pragma warning restore 0169

		static Delegate cb_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_;
#pragma warning disable 0169
		static Delegate GetSetFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_Handler ()
		{
			if (cb_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_ == null)
				cb_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_);
			return cb_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_;
		}

		static void n_SetFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Filetransfer p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Filetransfer> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Filetransfer = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getFiletransfer;
		static IntPtr id_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Filetransfer Filetransfer {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getFiletransfer' and count(parameter)=0]"
			[Register ("getFiletransfer", "()Lcom/inscripts/jsonphp/Filetransfer;", "GetGetFiletransferHandler")]
			get {
				if (id_getFiletransfer == IntPtr.Zero)
					id_getFiletransfer = JNIEnv.GetMethodID (class_ref, "getFiletransfer", "()Lcom/inscripts/jsonphp/Filetransfer;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Filetransfer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFiletransfer), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Filetransfer> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getFiletransfer", "()Lcom/inscripts/jsonphp/Filetransfer;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setFiletransfer' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Filetransfer']]"
			[Register ("setFiletransfer", "(Lcom/inscripts/jsonphp/Filetransfer;)V", "GetSetFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_Handler")]
			set {
				if (id_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_ == IntPtr.Zero)
					id_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_ = JNIEnv.GetMethodID (class_ref, "setFiletransfer", "(Lcom/inscripts/jsonphp/Filetransfer;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFiletransfer_Lcom_inscripts_jsonphp_Filetransfer_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFiletransfer", "(Lcom/inscripts/jsonphp/Filetransfer;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getHandwrite;
#pragma warning disable 0169
		static Delegate GetGetHandwriteHandler ()
		{
			if (cb_getHandwrite == null)
				cb_getHandwrite = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHandwrite);
			return cb_getHandwrite;
		}

		static IntPtr n_GetHandwrite (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Handwrite);
		}
#pragma warning restore 0169

		static IntPtr id_getHandwrite;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Handwrite Handwrite {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getHandwrite' and count(parameter)=0]"
			[Register ("getHandwrite", "()Lcom/inscripts/jsonphp/Handwrite;", "GetGetHandwriteHandler")]
			get {
				if (id_getHandwrite == IntPtr.Zero)
					id_getHandwrite = JNIEnv.GetMethodID (class_ref, "getHandwrite", "()Lcom/inscripts/jsonphp/Handwrite;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHandwrite), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Handwrite> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHandwrite", "()Lcom/inscripts/jsonphp/Handwrite;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getMobile;
#pragma warning disable 0169
		static Delegate GetGetMobileHandler ()
		{
			if (cb_getMobile == null)
				cb_getMobile = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMobile);
			return cb_getMobile;
		}

		static IntPtr n_GetMobile (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Mobile);
		}
#pragma warning restore 0169

		static Delegate cb_setMobile_Lcom_inscripts_jsonphp_Mobile_;
#pragma warning disable 0169
		static Delegate GetSetMobile_Lcom_inscripts_jsonphp_Mobile_Handler ()
		{
			if (cb_setMobile_Lcom_inscripts_jsonphp_Mobile_ == null)
				cb_setMobile_Lcom_inscripts_jsonphp_Mobile_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetMobile_Lcom_inscripts_jsonphp_Mobile_);
			return cb_setMobile_Lcom_inscripts_jsonphp_Mobile_;
		}

		static void n_SetMobile_Lcom_inscripts_jsonphp_Mobile_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Mobile p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Mobile = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getMobile;
		static IntPtr id_setMobile_Lcom_inscripts_jsonphp_Mobile_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Mobile Mobile {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getMobile' and count(parameter)=0]"
			[Register ("getMobile", "()Lcom/inscripts/jsonphp/Mobile;", "GetGetMobileHandler")]
			get {
				if (id_getMobile == IntPtr.Zero)
					id_getMobile = JNIEnv.GetMethodID (class_ref, "getMobile", "()Lcom/inscripts/jsonphp/Mobile;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMobile), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Mobile> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMobile", "()Lcom/inscripts/jsonphp/Mobile;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setMobile' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Mobile']]"
			[Register ("setMobile", "(Lcom/inscripts/jsonphp/Mobile;)V", "GetSetMobile_Lcom_inscripts_jsonphp_Mobile_Handler")]
			set {
				if (id_setMobile_Lcom_inscripts_jsonphp_Mobile_ == IntPtr.Zero)
					id_setMobile_Lcom_inscripts_jsonphp_Mobile_ = JNIEnv.GetMethodID (class_ref, "setMobile", "(Lcom/inscripts/jsonphp/Mobile;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMobile_Lcom_inscripts_jsonphp_Mobile_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMobile", "(Lcom/inscripts/jsonphp/Mobile;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getRealtimetranslate;
#pragma warning disable 0169
		static Delegate GetGetRealtimetranslateHandler ()
		{
			if (cb_getRealtimetranslate == null)
				cb_getRealtimetranslate = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRealtimetranslate);
			return cb_getRealtimetranslate;
		}

		static IntPtr n_GetRealtimetranslate (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Realtimetranslate);
		}
#pragma warning restore 0169

		static Delegate cb_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_;
#pragma warning disable 0169
		static Delegate GetSetRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_Handler ()
		{
			if (cb_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_ == null)
				cb_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_);
			return cb_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_;
		}

		static void n_SetRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Realtimetranslate p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Realtimetranslate> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Realtimetranslate = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getRealtimetranslate;
		static IntPtr id_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Realtimetranslate Realtimetranslate {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getRealtimetranslate' and count(parameter)=0]"
			[Register ("getRealtimetranslate", "()Lcom/inscripts/jsonphp/Realtimetranslate;", "GetGetRealtimetranslateHandler")]
			get {
				if (id_getRealtimetranslate == IntPtr.Zero)
					id_getRealtimetranslate = JNIEnv.GetMethodID (class_ref, "getRealtimetranslate", "()Lcom/inscripts/jsonphp/Realtimetranslate;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Realtimetranslate> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRealtimetranslate), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Realtimetranslate> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRealtimetranslate", "()Lcom/inscripts/jsonphp/Realtimetranslate;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setRealtimetranslate' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Realtimetranslate']]"
			[Register ("setRealtimetranslate", "(Lcom/inscripts/jsonphp/Realtimetranslate;)V", "GetSetRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_Handler")]
			set {
				if (id_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_ == IntPtr.Zero)
					id_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_ = JNIEnv.GetMethodID (class_ref, "setRealtimetranslate", "(Lcom/inscripts/jsonphp/Realtimetranslate;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRealtimetranslate_Lcom_inscripts_jsonphp_Realtimetranslate_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setRealtimetranslate", "(Lcom/inscripts/jsonphp/Realtimetranslate;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getReport;
#pragma warning disable 0169
		static Delegate GetGetReportHandler ()
		{
			if (cb_getReport == null)
				cb_getReport = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReport);
			return cb_getReport;
		}

		static IntPtr n_GetReport (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Report);
		}
#pragma warning restore 0169

		static Delegate cb_setReport_Lcom_inscripts_jsonphp_Report_;
#pragma warning disable 0169
		static Delegate GetSetReport_Lcom_inscripts_jsonphp_Report_Handler ()
		{
			if (cb_setReport_Lcom_inscripts_jsonphp_Report_ == null)
				cb_setReport_Lcom_inscripts_jsonphp_Report_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetReport_Lcom_inscripts_jsonphp_Report_);
			return cb_setReport_Lcom_inscripts_jsonphp_Report_;
		}

		static void n_SetReport_Lcom_inscripts_jsonphp_Report_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Report p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Report = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getReport;
		static IntPtr id_setReport_Lcom_inscripts_jsonphp_Report_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Report Report {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getReport' and count(parameter)=0]"
			[Register ("getReport", "()Lcom/inscripts/jsonphp/Report;", "GetGetReportHandler")]
			get {
				if (id_getReport == IntPtr.Zero)
					id_getReport = JNIEnv.GetMethodID (class_ref, "getReport", "()Lcom/inscripts/jsonphp/Report;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReport), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Report> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReport", "()Lcom/inscripts/jsonphp/Report;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setReport' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Report']]"
			[Register ("setReport", "(Lcom/inscripts/jsonphp/Report;)V", "GetSetReport_Lcom_inscripts_jsonphp_Report_Handler")]
			set {
				if (id_setReport_Lcom_inscripts_jsonphp_Report_ == IntPtr.Zero)
					id_setReport_Lcom_inscripts_jsonphp_Report_ = JNIEnv.GetMethodID (class_ref, "setReport", "(Lcom/inscripts/jsonphp/Report;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setReport_Lcom_inscripts_jsonphp_Report_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setReport", "(Lcom/inscripts/jsonphp/Report;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getRtl;
#pragma warning disable 0169
		static Delegate GetGetRtlHandler ()
		{
			if (cb_getRtl == null)
				cb_getRtl = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRtl);
			return cb_getRtl;
		}

		static IntPtr n_GetRtl (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Rtl);
		}
#pragma warning restore 0169

		static Delegate cb_setRtl_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetRtl_Ljava_lang_String_Handler ()
		{
			if (cb_setRtl_Ljava_lang_String_ == null)
				cb_setRtl_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetRtl_Ljava_lang_String_);
			return cb_setRtl_Ljava_lang_String_;
		}

		static void n_SetRtl_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Rtl = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getRtl;
		static IntPtr id_setRtl_Ljava_lang_String_;
		public virtual unsafe string Rtl {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getRtl' and count(parameter)=0]"
			[Register ("getRtl", "()Ljava/lang/String;", "GetGetRtlHandler")]
			get {
				if (id_getRtl == IntPtr.Zero)
					id_getRtl = JNIEnv.GetMethodID (class_ref, "getRtl", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRtl), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRtl", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setRtl' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setRtl", "(Ljava/lang/String;)V", "GetSetRtl_Ljava_lang_String_Handler")]
			set {
				if (id_setRtl_Ljava_lang_String_ == IntPtr.Zero)
					id_setRtl_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setRtl", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRtl_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setRtl", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getWhiteboard;
#pragma warning disable 0169
		static Delegate GetGetWhiteboardHandler ()
		{
			if (cb_getWhiteboard == null)
				cb_getWhiteboard = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWhiteboard);
			return cb_getWhiteboard;
		}

		static IntPtr n_GetWhiteboard (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Whiteboard);
		}
#pragma warning restore 0169

		static Delegate cb_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_;
#pragma warning disable 0169
		static Delegate GetSetWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_Handler ()
		{
			if (cb_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_ == null)
				cb_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_);
			return cb_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_;
		}

		static void n_SetWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Whiteboard p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Whiteboard> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Whiteboard = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getWhiteboard;
		static IntPtr id_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Whiteboard Whiteboard {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getWhiteboard' and count(parameter)=0]"
			[Register ("getWhiteboard", "()Lcom/inscripts/jsonphp/Whiteboard;", "GetGetWhiteboardHandler")]
			get {
				if (id_getWhiteboard == IntPtr.Zero)
					id_getWhiteboard = JNIEnv.GetMethodID (class_ref, "getWhiteboard", "()Lcom/inscripts/jsonphp/Whiteboard;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Whiteboard> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWhiteboard), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Whiteboard> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWhiteboard", "()Lcom/inscripts/jsonphp/Whiteboard;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='setWhiteboard' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Whiteboard']]"
			[Register ("setWhiteboard", "(Lcom/inscripts/jsonphp/Whiteboard;)V", "GetSetWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_Handler")]
			set {
				if (id_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_ == IntPtr.Zero)
					id_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_ = JNIEnv.GetMethodID (class_ref, "setWhiteboard", "(Lcom/inscripts/jsonphp/Whiteboard;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWhiteboard_Lcom_inscripts_jsonphp_Whiteboard_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setWhiteboard", "(Lcom/inscripts/jsonphp/Whiteboard;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getWriteboard;
#pragma warning disable 0169
		static Delegate GetGetWriteboardHandler ()
		{
			if (cb_getWriteboard == null)
				cb_getWriteboard = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetWriteboard);
			return cb_getWriteboard;
		}

		static IntPtr n_GetWriteboard (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Lang __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Lang> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Writeboard);
		}
#pragma warning restore 0169

		static IntPtr id_getWriteboard;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Writeboard Writeboard {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Lang']/method[@name='getWriteboard' and count(parameter)=0]"
			[Register ("getWriteboard", "()Lcom/inscripts/jsonphp/Writeboard;", "GetGetWriteboardHandler")]
			get {
				if (id_getWriteboard == IntPtr.Zero)
					id_getWriteboard = JNIEnv.GetMethodID (class_ref, "getWriteboard", "()Lcom/inscripts/jsonphp/Writeboard;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Writeboard> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getWriteboard), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Writeboard> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getWriteboard", "()Lcom/inscripts/jsonphp/Writeboard;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
