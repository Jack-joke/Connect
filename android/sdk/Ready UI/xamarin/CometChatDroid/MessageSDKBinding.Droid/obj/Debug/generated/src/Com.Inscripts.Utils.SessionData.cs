using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']"
	[global::Android.Runtime.Register ("com/inscripts/utils/SessionData", DoNotGenerateAcw=true)]
	public partial class SessionData : global::Com.Inscripts.Pojos.User {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/utils/SessionData", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SessionData); }
		}

		protected SessionData (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/constructor[@name='SessionData' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SessionData ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SessionData)) {
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

		static Delegate cb_getAVChatCallStartTime;
#pragma warning disable 0169
		static Delegate GetGetAVChatCallStartTimeHandler ()
		{
			if (cb_getAVChatCallStartTime == null)
				cb_getAVChatCallStartTime = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetAVChatCallStartTime);
			return cb_getAVChatCallStartTime;
		}

		static long n_GetAVChatCallStartTime (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AVChatCallStartTime;
		}
#pragma warning restore 0169

		static Delegate cb_setAVChatCallStartTime_J;
#pragma warning disable 0169
		static Delegate GetSetAVChatCallStartTime_JHandler ()
		{
			if (cb_setAVChatCallStartTime_J == null)
				cb_setAVChatCallStartTime_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetAVChatCallStartTime_J);
			return cb_setAVChatCallStartTime_J;
		}

		static void n_SetAVChatCallStartTime_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AVChatCallStartTime = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAVChatCallStartTime;
		static IntPtr id_setAVChatCallStartTime_J;
		public virtual unsafe long AVChatCallStartTime {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getAVChatCallStartTime' and count(parameter)=0]"
			[Register ("getAVChatCallStartTime", "()J", "GetGetAVChatCallStartTimeHandler")]
			get {
				if (id_getAVChatCallStartTime == IntPtr.Zero)
					id_getAVChatCallStartTime = JNIEnv.GetMethodID (class_ref, "getAVChatCallStartTime", "()J");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getAVChatCallStartTime);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAVChatCallStartTime", "()J"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAVChatCallStartTime' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setAVChatCallStartTime", "(J)V", "GetSetAVChatCallStartTime_JHandler")]
			set {
				if (id_setAVChatCallStartTime_J == IntPtr.Zero)
					id_setAVChatCallStartTime_J = JNIEnv.GetMethodID (class_ref, "setAVChatCallStartTime", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAVChatCallStartTime_J, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAVChatCallStartTime", "(J)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getActiveAVchatUserID;
#pragma warning disable 0169
		static Delegate GetGetActiveAVchatUserIDHandler ()
		{
			if (cb_getActiveAVchatUserID == null)
				cb_getActiveAVchatUserID = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetActiveAVchatUserID);
			return cb_getActiveAVchatUserID;
		}

		static IntPtr n_GetActiveAVchatUserID (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ActiveAVchatUserID);
		}
#pragma warning restore 0169

		static Delegate cb_setActiveAVchatUserID_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetActiveAVchatUserID_Ljava_lang_String_Handler ()
		{
			if (cb_setActiveAVchatUserID_Ljava_lang_String_ == null)
				cb_setActiveAVchatUserID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetActiveAVchatUserID_Ljava_lang_String_);
			return cb_setActiveAVchatUserID_Ljava_lang_String_;
		}

		static void n_SetActiveAVchatUserID_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ActiveAVchatUserID = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getActiveAVchatUserID;
		static IntPtr id_setActiveAVchatUserID_Ljava_lang_String_;
		public virtual unsafe string ActiveAVchatUserID {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getActiveAVchatUserID' and count(parameter)=0]"
			[Register ("getActiveAVchatUserID", "()Ljava/lang/String;", "GetGetActiveAVchatUserIDHandler")]
			get {
				if (id_getActiveAVchatUserID == IntPtr.Zero)
					id_getActiveAVchatUserID = JNIEnv.GetMethodID (class_ref, "getActiveAVchatUserID", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getActiveAVchatUserID), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getActiveAVchatUserID", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setActiveAVchatUserID' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setActiveAVchatUserID", "(Ljava/lang/String;)V", "GetSetActiveAVchatUserID_Ljava_lang_String_Handler")]
			set {
				if (id_setActiveAVchatUserID_Ljava_lang_String_ == IntPtr.Zero)
					id_setActiveAVchatUserID_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setActiveAVchatUserID", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setActiveAVchatUserID_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setActiveAVchatUserID", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getAnnParseChannel;
#pragma warning disable 0169
		static Delegate GetGetAnnParseChannelHandler ()
		{
			if (cb_getAnnParseChannel == null)
				cb_getAnnParseChannel = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAnnParseChannel);
			return cb_getAnnParseChannel;
		}

		static IntPtr n_GetAnnParseChannel (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AnnParseChannel);
		}
#pragma warning restore 0169

		static Delegate cb_setAnnParseChannel_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAnnParseChannel_Ljava_lang_String_Handler ()
		{
			if (cb_setAnnParseChannel_Ljava_lang_String_ == null)
				cb_setAnnParseChannel_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAnnParseChannel_Ljava_lang_String_);
			return cb_setAnnParseChannel_Ljava_lang_String_;
		}

		static void n_SetAnnParseChannel_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AnnParseChannel = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAnnParseChannel;
		static IntPtr id_setAnnParseChannel_Ljava_lang_String_;
		public virtual unsafe string AnnParseChannel {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getAnnParseChannel' and count(parameter)=0]"
			[Register ("getAnnParseChannel", "()Ljava/lang/String;", "GetGetAnnParseChannelHandler")]
			get {
				if (id_getAnnParseChannel == IntPtr.Zero)
					id_getAnnParseChannel = JNIEnv.GetMethodID (class_ref, "getAnnParseChannel", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnParseChannel), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAnnParseChannel", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAnnParseChannel' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAnnParseChannel", "(Ljava/lang/String;)V", "GetSetAnnParseChannel_Ljava_lang_String_Handler")]
			set {
				if (id_setAnnParseChannel_Ljava_lang_String_ == IntPtr.Zero)
					id_setAnnParseChannel_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAnnParseChannel", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAnnParseChannel_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAnnParseChannel", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isAnnouncementListBroadcastMissed;
#pragma warning disable 0169
		static Delegate GetIsAnnouncementListBroadcastMissedHandler ()
		{
			if (cb_isAnnouncementListBroadcastMissed == null)
				cb_isAnnouncementListBroadcastMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsAnnouncementListBroadcastMissed);
			return cb_isAnnouncementListBroadcastMissed;
		}

		static bool n_IsAnnouncementListBroadcastMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AnnouncementListBroadcastMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setAnnouncementListBroadcastMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetAnnouncementListBroadcastMissed_ZHandler ()
		{
			if (cb_setAnnouncementListBroadcastMissed_Z == null)
				cb_setAnnouncementListBroadcastMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetAnnouncementListBroadcastMissed_Z);
			return cb_setAnnouncementListBroadcastMissed_Z;
		}

		static void n_SetAnnouncementListBroadcastMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AnnouncementListBroadcastMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isAnnouncementListBroadcastMissed;
		static IntPtr id_setAnnouncementListBroadcastMissed_Z;
		public virtual unsafe bool AnnouncementListBroadcastMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isAnnouncementListBroadcastMissed' and count(parameter)=0]"
			[Register ("isAnnouncementListBroadcastMissed", "()Z", "GetIsAnnouncementListBroadcastMissedHandler")]
			get {
				if (id_isAnnouncementListBroadcastMissed == IntPtr.Zero)
					id_isAnnouncementListBroadcastMissed = JNIEnv.GetMethodID (class_ref, "isAnnouncementListBroadcastMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isAnnouncementListBroadcastMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isAnnouncementListBroadcastMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAnnouncementListBroadcastMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setAnnouncementListBroadcastMissed", "(Z)V", "GetSetAnnouncementListBroadcastMissed_ZHandler")]
			set {
				if (id_setAnnouncementListBroadcastMissed_Z == IntPtr.Zero)
					id_setAnnouncementListBroadcastMissed_Z = JNIEnv.GetMethodID (class_ref, "setAnnouncementListBroadcastMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAnnouncementListBroadcastMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAnnouncementListBroadcastMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getAvChatRoomName;
#pragma warning disable 0169
		static Delegate GetGetAvChatRoomNameHandler ()
		{
			if (cb_getAvChatRoomName == null)
				cb_getAvChatRoomName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAvChatRoomName);
			return cb_getAvChatRoomName;
		}

		static IntPtr n_GetAvChatRoomName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.AvChatRoomName);
		}
#pragma warning restore 0169

		static Delegate cb_setAvChatRoomName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetAvChatRoomName_Ljava_lang_String_Handler ()
		{
			if (cb_setAvChatRoomName_Ljava_lang_String_ == null)
				cb_setAvChatRoomName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAvChatRoomName_Ljava_lang_String_);
			return cb_setAvChatRoomName_Ljava_lang_String_;
		}

		static void n_SetAvChatRoomName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AvChatRoomName = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvChatRoomName;
		static IntPtr id_setAvChatRoomName_Ljava_lang_String_;
		public virtual unsafe string AvChatRoomName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getAvChatRoomName' and count(parameter)=0]"
			[Register ("getAvChatRoomName", "()Ljava/lang/String;", "GetGetAvChatRoomNameHandler")]
			get {
				if (id_getAvChatRoomName == IntPtr.Zero)
					id_getAvChatRoomName = JNIEnv.GetMethodID (class_ref, "getAvChatRoomName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvChatRoomName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvChatRoomName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAvChatRoomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setAvChatRoomName", "(Ljava/lang/String;)V", "GetSetAvChatRoomName_Ljava_lang_String_Handler")]
			set {
				if (id_setAvChatRoomName_Ljava_lang_String_ == IntPtr.Zero)
					id_setAvChatRoomName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setAvChatRoomName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvChatRoomName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvChatRoomName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isAvchatCallRunning;
#pragma warning disable 0169
		static Delegate GetIsAvchatCallRunningHandler ()
		{
			if (cb_isAvchatCallRunning == null)
				cb_isAvchatCallRunning = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsAvchatCallRunning);
			return cb_isAvchatCallRunning;
		}

		static bool n_IsAvchatCallRunning (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AvchatCallRunning;
		}
#pragma warning restore 0169

		static Delegate cb_setAvchatCallRunning_Z;
#pragma warning disable 0169
		static Delegate GetSetAvchatCallRunning_ZHandler ()
		{
			if (cb_setAvchatCallRunning_Z == null)
				cb_setAvchatCallRunning_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetAvchatCallRunning_Z);
			return cb_setAvchatCallRunning_Z;
		}

		static void n_SetAvchatCallRunning_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AvchatCallRunning = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isAvchatCallRunning;
		static IntPtr id_setAvchatCallRunning_Z;
		public virtual unsafe bool AvchatCallRunning {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isAvchatCallRunning' and count(parameter)=0]"
			[Register ("isAvchatCallRunning", "()Z", "GetIsAvchatCallRunningHandler")]
			get {
				if (id_isAvchatCallRunning == IntPtr.Zero)
					id_isAvchatCallRunning = JNIEnv.GetMethodID (class_ref, "isAvchatCallRunning", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isAvchatCallRunning);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isAvchatCallRunning", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAvchatCallRunning' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setAvchatCallRunning", "(Z)V", "GetSetAvchatCallRunning_ZHandler")]
			set {
				if (id_setAvchatCallRunning_Z == IntPtr.Zero)
					id_setAvchatCallRunning_Z = JNIEnv.GetMethodID (class_ref, "setAvchatCallRunning", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvchatCallRunning_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvchatCallRunning", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getAvchatStatus;
#pragma warning disable 0169
		static Delegate GetGetAvchatStatusHandler ()
		{
			if (cb_getAvchatStatus == null)
				cb_getAvchatStatus = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetAvchatStatus);
			return cb_getAvchatStatus;
		}

		static int n_GetAvchatStatus (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AvchatStatus;
		}
#pragma warning restore 0169

		static Delegate cb_setAvchatStatus_I;
#pragma warning disable 0169
		static Delegate GetSetAvchatStatus_IHandler ()
		{
			if (cb_setAvchatStatus_I == null)
				cb_setAvchatStatus_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetAvchatStatus_I);
			return cb_setAvchatStatus_I;
		}

		static void n_SetAvchatStatus_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AvchatStatus = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAvchatStatus;
		static IntPtr id_setAvchatStatus_I;
		public virtual unsafe int AvchatStatus {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getAvchatStatus' and count(parameter)=0]"
			[Register ("getAvchatStatus", "()I", "GetGetAvchatStatusHandler")]
			get {
				if (id_getAvchatStatus == IntPtr.Zero)
					id_getAvchatStatus = JNIEnv.GetMethodID (class_ref, "getAvchatStatus", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getAvchatStatus);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAvchatStatus", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setAvchatStatus' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setAvchatStatus", "(I)V", "GetSetAvchatStatus_IHandler")]
			set {
				if (id_setAvchatStatus_I == IntPtr.Zero)
					id_setAvchatStatus_I = JNIEnv.GetMethodID (class_ref, "setAvchatStatus", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAvchatStatus_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAvchatStatus", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getBaseData;
#pragma warning disable 0169
		static Delegate GetGetBaseDataHandler ()
		{
			if (cb_getBaseData == null)
				cb_getBaseData = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBaseData);
			return cb_getBaseData;
		}

		static IntPtr n_GetBaseData (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BaseData);
		}
#pragma warning restore 0169

		static Delegate cb_setBaseData_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetBaseData_Ljava_lang_String_Handler ()
		{
			if (cb_setBaseData_Ljava_lang_String_ == null)
				cb_setBaseData_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBaseData_Ljava_lang_String_);
			return cb_setBaseData_Ljava_lang_String_;
		}

		static void n_SetBaseData_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BaseData = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBaseData;
		static IntPtr id_setBaseData_Ljava_lang_String_;
		public virtual unsafe string BaseData {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getBaseData' and count(parameter)=0]"
			[Register ("getBaseData", "()Ljava/lang/String;", "GetGetBaseDataHandler")]
			get {
				if (id_getBaseData == IntPtr.Zero)
					id_getBaseData = JNIEnv.GetMethodID (class_ref, "getBaseData", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBaseData), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBaseData", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setBaseData' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setBaseData", "(Ljava/lang/String;)V", "GetSetBaseData_Ljava_lang_String_Handler")]
			set {
				if (id_setBaseData_Ljava_lang_String_ == IntPtr.Zero)
					id_setBaseData_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setBaseData", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBaseData_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBaseData", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isBuddyListBroadcastMissed;
#pragma warning disable 0169
		static Delegate GetIsBuddyListBroadcastMissedHandler ()
		{
			if (cb_isBuddyListBroadcastMissed == null)
				cb_isBuddyListBroadcastMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsBuddyListBroadcastMissed);
			return cb_isBuddyListBroadcastMissed;
		}

		static bool n_IsBuddyListBroadcastMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BuddyListBroadcastMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setBuddyListBroadcastMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetBuddyListBroadcastMissed_ZHandler ()
		{
			if (cb_setBuddyListBroadcastMissed_Z == null)
				cb_setBuddyListBroadcastMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetBuddyListBroadcastMissed_Z);
			return cb_setBuddyListBroadcastMissed_Z;
		}

		static void n_SetBuddyListBroadcastMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.BuddyListBroadcastMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isBuddyListBroadcastMissed;
		static IntPtr id_setBuddyListBroadcastMissed_Z;
		public virtual unsafe bool BuddyListBroadcastMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isBuddyListBroadcastMissed' and count(parameter)=0]"
			[Register ("isBuddyListBroadcastMissed", "()Z", "GetIsBuddyListBroadcastMissedHandler")]
			get {
				if (id_isBuddyListBroadcastMissed == IntPtr.Zero)
					id_isBuddyListBroadcastMissed = JNIEnv.GetMethodID (class_ref, "isBuddyListBroadcastMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isBuddyListBroadcastMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isBuddyListBroadcastMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setBuddyListBroadcastMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setBuddyListBroadcastMissed", "(Z)V", "GetSetBuddyListBroadcastMissed_ZHandler")]
			set {
				if (id_setBuddyListBroadcastMissed_Z == IntPtr.Zero)
					id_setBuddyListBroadcastMissed_Z = JNIEnv.GetMethodID (class_ref, "setBuddyListBroadcastMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBuddyListBroadcastMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBuddyListBroadcastMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isChatbadgeMissed;
#pragma warning disable 0169
		static Delegate GetIsChatbadgeMissedHandler ()
		{
			if (cb_isChatbadgeMissed == null)
				cb_isChatbadgeMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsChatbadgeMissed);
			return cb_isChatbadgeMissed;
		}

		static bool n_IsChatbadgeMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ChatbadgeMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setChatbadgeMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetChatbadgeMissed_ZHandler ()
		{
			if (cb_setChatbadgeMissed_Z == null)
				cb_setChatbadgeMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetChatbadgeMissed_Z);
			return cb_setChatbadgeMissed_Z;
		}

		static void n_SetChatbadgeMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChatbadgeMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isChatbadgeMissed;
		static IntPtr id_setChatbadgeMissed_Z;
		public virtual unsafe bool ChatbadgeMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isChatbadgeMissed' and count(parameter)=0]"
			[Register ("isChatbadgeMissed", "()Z", "GetIsChatbadgeMissedHandler")]
			get {
				if (id_isChatbadgeMissed == IntPtr.Zero)
					id_isChatbadgeMissed = JNIEnv.GetMethodID (class_ref, "isChatbadgeMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isChatbadgeMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isChatbadgeMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatbadgeMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setChatbadgeMissed", "(Z)V", "GetSetChatbadgeMissed_ZHandler")]
			set {
				if (id_setChatbadgeMissed_Z == IntPtr.Zero)
					id_setChatbadgeMissed_Z = JNIEnv.GetMethodID (class_ref, "setChatbadgeMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatbadgeMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatbadgeMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isChatroomBroadcastMissed;
#pragma warning disable 0169
		static Delegate GetIsChatroomBroadcastMissedHandler ()
		{
			if (cb_isChatroomBroadcastMissed == null)
				cb_isChatroomBroadcastMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsChatroomBroadcastMissed);
			return cb_isChatroomBroadcastMissed;
		}

		static bool n_IsChatroomBroadcastMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ChatroomBroadcastMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomBroadcastMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetChatroomBroadcastMissed_ZHandler ()
		{
			if (cb_setChatroomBroadcastMissed_Z == null)
				cb_setChatroomBroadcastMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetChatroomBroadcastMissed_Z);
			return cb_setChatroomBroadcastMissed_Z;
		}

		static void n_SetChatroomBroadcastMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomBroadcastMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isChatroomBroadcastMissed;
		static IntPtr id_setChatroomBroadcastMissed_Z;
		public virtual unsafe bool ChatroomBroadcastMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isChatroomBroadcastMissed' and count(parameter)=0]"
			[Register ("isChatroomBroadcastMissed", "()Z", "GetIsChatroomBroadcastMissedHandler")]
			get {
				if (id_isChatroomBroadcastMissed == IntPtr.Zero)
					id_isChatroomBroadcastMissed = JNIEnv.GetMethodID (class_ref, "isChatroomBroadcastMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isChatroomBroadcastMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isChatroomBroadcastMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomBroadcastMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setChatroomBroadcastMissed", "(Z)V", "GetSetChatroomBroadcastMissed_ZHandler")]
			set {
				if (id_setChatroomBroadcastMissed_Z == IntPtr.Zero)
					id_setChatroomBroadcastMissed_Z = JNIEnv.GetMethodID (class_ref, "setChatroomBroadcastMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomBroadcastMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomBroadcastMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getChatroomCometId;
#pragma warning disable 0169
		static Delegate GetGetChatroomCometIdHandler ()
		{
			if (cb_getChatroomCometId == null)
				cb_getChatroomCometId = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatroomCometId);
			return cb_getChatroomCometId;
		}

		static IntPtr n_GetChatroomCometId (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChatroomCometId);
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomCometId_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatroomCometId_Ljava_lang_String_Handler ()
		{
			if (cb_setChatroomCometId_Ljava_lang_String_ == null)
				cb_setChatroomCometId_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatroomCometId_Ljava_lang_String_);
			return cb_setChatroomCometId_Ljava_lang_String_;
		}

		static void n_SetChatroomCometId_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomCometId = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomCometId;
		static IntPtr id_setChatroomCometId_Ljava_lang_String_;
		public virtual unsafe string ChatroomCometId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getChatroomCometId' and count(parameter)=0]"
			[Register ("getChatroomCometId", "()Ljava/lang/String;", "GetGetChatroomCometIdHandler")]
			get {
				if (id_getChatroomCometId == IntPtr.Zero)
					id_getChatroomCometId = JNIEnv.GetMethodID (class_ref, "getChatroomCometId", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomCometId), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomCometId", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomCometId' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setChatroomCometId", "(Ljava/lang/String;)V", "GetSetChatroomCometId_Ljava_lang_String_Handler")]
			set {
				if (id_setChatroomCometId_Ljava_lang_String_ == IntPtr.Zero)
					id_setChatroomCometId_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatroomCometId", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomCometId_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomCometId", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getChatroomHeartBeatTimestamp;
#pragma warning disable 0169
		static Delegate GetGetChatroomHeartBeatTimestampHandler ()
		{
			if (cb_getChatroomHeartBeatTimestamp == null)
				cb_getChatroomHeartBeatTimestamp = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatroomHeartBeatTimestamp);
			return cb_getChatroomHeartBeatTimestamp;
		}

		static IntPtr n_GetChatroomHeartBeatTimestamp (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChatroomHeartBeatTimestamp);
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomHeartBeatTimestamp_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatroomHeartBeatTimestamp_Ljava_lang_String_Handler ()
		{
			if (cb_setChatroomHeartBeatTimestamp_Ljava_lang_String_ == null)
				cb_setChatroomHeartBeatTimestamp_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatroomHeartBeatTimestamp_Ljava_lang_String_);
			return cb_setChatroomHeartBeatTimestamp_Ljava_lang_String_;
		}

		static void n_SetChatroomHeartBeatTimestamp_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomHeartBeatTimestamp = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomHeartBeatTimestamp;
		static IntPtr id_setChatroomHeartBeatTimestamp_Ljava_lang_String_;
		public virtual unsafe string ChatroomHeartBeatTimestamp {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getChatroomHeartBeatTimestamp' and count(parameter)=0]"
			[Register ("getChatroomHeartBeatTimestamp", "()Ljava/lang/String;", "GetGetChatroomHeartBeatTimestampHandler")]
			get {
				if (id_getChatroomHeartBeatTimestamp == IntPtr.Zero)
					id_getChatroomHeartBeatTimestamp = JNIEnv.GetMethodID (class_ref, "getChatroomHeartBeatTimestamp", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomHeartBeatTimestamp), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomHeartBeatTimestamp", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomHeartBeatTimestamp' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setChatroomHeartBeatTimestamp", "(Ljava/lang/String;)V", "GetSetChatroomHeartBeatTimestamp_Ljava_lang_String_Handler")]
			set {
				if (id_setChatroomHeartBeatTimestamp_Ljava_lang_String_ == IntPtr.Zero)
					id_setChatroomHeartBeatTimestamp_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatroomHeartBeatTimestamp", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomHeartBeatTimestamp_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomHeartBeatTimestamp", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getChatroomHeartbeatIdealCount;
#pragma warning disable 0169
		static Delegate GetGetChatroomHeartbeatIdealCountHandler ()
		{
			if (cb_getChatroomHeartbeatIdealCount == null)
				cb_getChatroomHeartbeatIdealCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetChatroomHeartbeatIdealCount);
			return cb_getChatroomHeartbeatIdealCount;
		}

		static int n_GetChatroomHeartbeatIdealCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ChatroomHeartbeatIdealCount;
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomHeartbeatIdealCount_I;
#pragma warning disable 0169
		static Delegate GetSetChatroomHeartbeatIdealCount_IHandler ()
		{
			if (cb_setChatroomHeartbeatIdealCount_I == null)
				cb_setChatroomHeartbeatIdealCount_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetChatroomHeartbeatIdealCount_I);
			return cb_setChatroomHeartbeatIdealCount_I;
		}

		static void n_SetChatroomHeartbeatIdealCount_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomHeartbeatIdealCount = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomHeartbeatIdealCount;
		static IntPtr id_setChatroomHeartbeatIdealCount_I;
		public virtual unsafe int ChatroomHeartbeatIdealCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getChatroomHeartbeatIdealCount' and count(parameter)=0]"
			[Register ("getChatroomHeartbeatIdealCount", "()I", "GetGetChatroomHeartbeatIdealCountHandler")]
			get {
				if (id_getChatroomHeartbeatIdealCount == IntPtr.Zero)
					id_getChatroomHeartbeatIdealCount = JNIEnv.GetMethodID (class_ref, "getChatroomHeartbeatIdealCount", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomHeartbeatIdealCount);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomHeartbeatIdealCount", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomHeartbeatIdealCount' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setChatroomHeartbeatIdealCount", "(I)V", "GetSetChatroomHeartbeatIdealCount_IHandler")]
			set {
				if (id_setChatroomHeartbeatIdealCount_I == IntPtr.Zero)
					id_setChatroomHeartbeatIdealCount_I = JNIEnv.GetMethodID (class_ref, "setChatroomHeartbeatIdealCount", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomHeartbeatIdealCount_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomHeartbeatIdealCount", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getChatroomHeartbeatInterval;
#pragma warning disable 0169
		static Delegate GetGetChatroomHeartbeatIntervalHandler ()
		{
			if (cb_getChatroomHeartbeatInterval == null)
				cb_getChatroomHeartbeatInterval = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetChatroomHeartbeatInterval);
			return cb_getChatroomHeartbeatInterval;
		}

		static long n_GetChatroomHeartbeatInterval (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ChatroomHeartbeatInterval;
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomHeartbeatInterval_J;
#pragma warning disable 0169
		static Delegate GetSetChatroomHeartbeatInterval_JHandler ()
		{
			if (cb_setChatroomHeartbeatInterval_J == null)
				cb_setChatroomHeartbeatInterval_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetChatroomHeartbeatInterval_J);
			return cb_setChatroomHeartbeatInterval_J;
		}

		static void n_SetChatroomHeartbeatInterval_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomHeartbeatInterval = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomHeartbeatInterval;
		static IntPtr id_setChatroomHeartbeatInterval_J;
		public virtual unsafe long ChatroomHeartbeatInterval {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getChatroomHeartbeatInterval' and count(parameter)=0]"
			[Register ("getChatroomHeartbeatInterval", "()J", "GetGetChatroomHeartbeatIntervalHandler")]
			get {
				if (id_getChatroomHeartbeatInterval == IntPtr.Zero)
					id_getChatroomHeartbeatInterval = JNIEnv.GetMethodID (class_ref, "getChatroomHeartbeatInterval", "()J");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomHeartbeatInterval);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomHeartbeatInterval", "()J"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomHeartbeatInterval' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setChatroomHeartbeatInterval", "(J)V", "GetSetChatroomHeartbeatInterval_JHandler")]
			set {
				if (id_setChatroomHeartbeatInterval_J == IntPtr.Zero)
					id_setChatroomHeartbeatInterval_J = JNIEnv.GetMethodID (class_ref, "setChatroomHeartbeatInterval", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomHeartbeatInterval_J, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomHeartbeatInterval", "(J)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isChatroomListBroadcastMissed;
#pragma warning disable 0169
		static Delegate GetIsChatroomListBroadcastMissedHandler ()
		{
			if (cb_isChatroomListBroadcastMissed == null)
				cb_isChatroomListBroadcastMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsChatroomListBroadcastMissed);
			return cb_isChatroomListBroadcastMissed;
		}

		static bool n_IsChatroomListBroadcastMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ChatroomListBroadcastMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomListBroadcastMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetChatroomListBroadcastMissed_ZHandler ()
		{
			if (cb_setChatroomListBroadcastMissed_Z == null)
				cb_setChatroomListBroadcastMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetChatroomListBroadcastMissed_Z);
			return cb_setChatroomListBroadcastMissed_Z;
		}

		static void n_SetChatroomListBroadcastMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomListBroadcastMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isChatroomListBroadcastMissed;
		static IntPtr id_setChatroomListBroadcastMissed_Z;
		public virtual unsafe bool ChatroomListBroadcastMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isChatroomListBroadcastMissed' and count(parameter)=0]"
			[Register ("isChatroomListBroadcastMissed", "()Z", "GetIsChatroomListBroadcastMissedHandler")]
			get {
				if (id_isChatroomListBroadcastMissed == IntPtr.Zero)
					id_isChatroomListBroadcastMissed = JNIEnv.GetMethodID (class_ref, "isChatroomListBroadcastMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isChatroomListBroadcastMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isChatroomListBroadcastMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomListBroadcastMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setChatroomListBroadcastMissed", "(Z)V", "GetSetChatroomListBroadcastMissed_ZHandler")]
			set {
				if (id_setChatroomListBroadcastMissed_Z == IntPtr.Zero)
					id_setChatroomListBroadcastMissed_Z = JNIEnv.GetMethodID (class_ref, "setChatroomListBroadcastMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomListBroadcastMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomListBroadcastMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getChatroomParseChannel;
#pragma warning disable 0169
		static Delegate GetGetChatroomParseChannelHandler ()
		{
			if (cb_getChatroomParseChannel == null)
				cb_getChatroomParseChannel = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetChatroomParseChannel);
			return cb_getChatroomParseChannel;
		}

		static IntPtr n_GetChatroomParseChannel (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ChatroomParseChannel);
		}
#pragma warning restore 0169

		static Delegate cb_setChatroomParseChannel_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatroomParseChannel_Ljava_lang_String_Handler ()
		{
			if (cb_setChatroomParseChannel_Ljava_lang_String_ == null)
				cb_setChatroomParseChannel_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatroomParseChannel_Ljava_lang_String_);
			return cb_setChatroomParseChannel_Ljava_lang_String_;
		}

		static void n_SetChatroomParseChannel_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ChatroomParseChannel = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getChatroomParseChannel;
		static IntPtr id_setChatroomParseChannel_Ljava_lang_String_;
		public virtual unsafe string ChatroomParseChannel {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getChatroomParseChannel' and count(parameter)=0]"
			[Register ("getChatroomParseChannel", "()Ljava/lang/String;", "GetGetChatroomParseChannelHandler")]
			get {
				if (id_getChatroomParseChannel == IntPtr.Zero)
					id_getChatroomParseChannel = JNIEnv.GetMethodID (class_ref, "getChatroomParseChannel", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getChatroomParseChannel), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getChatroomParseChannel", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomParseChannel' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setChatroomParseChannel", "(Ljava/lang/String;)V", "GetSetChatroomParseChannel_Ljava_lang_String_Handler")]
			set {
				if (id_setChatroomParseChannel_Ljava_lang_String_ == IntPtr.Zero)
					id_setChatroomParseChannel_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatroomParseChannel", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomParseChannel_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomParseChannel", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCometID;
#pragma warning disable 0169
		static Delegate GetGetCometIDHandler ()
		{
			if (cb_getCometID == null)
				cb_getCometID = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCometID);
			return cb_getCometID;
		}

		static IntPtr n_GetCometID (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CometID);
		}
#pragma warning restore 0169

		static Delegate cb_setCometID_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCometID_Ljava_lang_String_Handler ()
		{
			if (cb_setCometID_Ljava_lang_String_ == null)
				cb_setCometID_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCometID_Ljava_lang_String_);
			return cb_setCometID_Ljava_lang_String_;
		}

		static void n_SetCometID_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CometID = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCometID;
		static IntPtr id_setCometID_Ljava_lang_String_;
		public virtual unsafe string CometID {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getCometID' and count(parameter)=0]"
			[Register ("getCometID", "()Ljava/lang/String;", "GetGetCometIDHandler")]
			get {
				if (id_getCometID == IntPtr.Zero)
					id_getCometID = JNIEnv.GetMethodID (class_ref, "getCometID", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCometID), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCometID", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setCometID' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCometID", "(Ljava/lang/String;)V", "GetSetCometID_Ljava_lang_String_Handler")]
			set {
				if (id_setCometID_Ljava_lang_String_ == IntPtr.Zero)
					id_setCometID_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCometID", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCometID_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCometID", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCurrentChatroom;
#pragma warning disable 0169
		static Delegate GetGetCurrentChatroomHandler ()
		{
			if (cb_getCurrentChatroom == null)
				cb_getCurrentChatroom = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetCurrentChatroom);
			return cb_getCurrentChatroom;
		}

		static long n_GetCurrentChatroom (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.CurrentChatroom;
		}
#pragma warning restore 0169

		static Delegate cb_setCurrentChatroom_J;
#pragma warning disable 0169
		static Delegate GetSetCurrentChatroom_JHandler ()
		{
			if (cb_setCurrentChatroom_J == null)
				cb_setCurrentChatroom_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetCurrentChatroom_J);
			return cb_setCurrentChatroom_J;
		}

		static void n_SetCurrentChatroom_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.CurrentChatroom = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCurrentChatroom;
		static IntPtr id_setCurrentChatroom_J;
		public virtual unsafe long CurrentChatroom {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getCurrentChatroom' and count(parameter)=0]"
			[Register ("getCurrentChatroom", "()J", "GetGetCurrentChatroomHandler")]
			get {
				if (id_getCurrentChatroom == IntPtr.Zero)
					id_getCurrentChatroom = JNIEnv.GetMethodID (class_ref, "getCurrentChatroom", "()J");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentChatroom);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCurrentChatroom", "()J"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setCurrentChatroom' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setCurrentChatroom", "(J)V", "GetSetCurrentChatroom_JHandler")]
			set {
				if (id_setCurrentChatroom_J == IntPtr.Zero)
					id_setCurrentChatroom_J = JNIEnv.GetMethodID (class_ref, "setCurrentChatroom", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCurrentChatroom_J, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCurrentChatroom", "(J)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCurrentChatroomName;
#pragma warning disable 0169
		static Delegate GetGetCurrentChatroomNameHandler ()
		{
			if (cb_getCurrentChatroomName == null)
				cb_getCurrentChatroomName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCurrentChatroomName);
			return cb_getCurrentChatroomName;
		}

		static IntPtr n_GetCurrentChatroomName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CurrentChatroomName);
		}
#pragma warning restore 0169

		static Delegate cb_setCurrentChatroomName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCurrentChatroomName_Ljava_lang_String_Handler ()
		{
			if (cb_setCurrentChatroomName_Ljava_lang_String_ == null)
				cb_setCurrentChatroomName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCurrentChatroomName_Ljava_lang_String_);
			return cb_setCurrentChatroomName_Ljava_lang_String_;
		}

		static void n_SetCurrentChatroomName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CurrentChatroomName = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCurrentChatroomName;
		static IntPtr id_setCurrentChatroomName_Ljava_lang_String_;
		public virtual unsafe string CurrentChatroomName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getCurrentChatroomName' and count(parameter)=0]"
			[Register ("getCurrentChatroomName", "()Ljava/lang/String;", "GetGetCurrentChatroomNameHandler")]
			get {
				if (id_getCurrentChatroomName == IntPtr.Zero)
					id_getCurrentChatroomName = JNIEnv.GetMethodID (class_ref, "getCurrentChatroomName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentChatroomName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCurrentChatroomName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setCurrentChatroomName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCurrentChatroomName", "(Ljava/lang/String;)V", "GetSetCurrentChatroomName_Ljava_lang_String_Handler")]
			set {
				if (id_setCurrentChatroomName_Ljava_lang_String_ == IntPtr.Zero)
					id_setCurrentChatroomName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCurrentChatroomName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCurrentChatroomName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCurrentChatroomName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getCurrentChatroomPassword;
#pragma warning disable 0169
		static Delegate GetGetCurrentChatroomPasswordHandler ()
		{
			if (cb_getCurrentChatroomPassword == null)
				cb_getCurrentChatroomPassword = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCurrentChatroomPassword);
			return cb_getCurrentChatroomPassword;
		}

		static IntPtr n_GetCurrentChatroomPassword (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CurrentChatroomPassword);
		}
#pragma warning restore 0169

		static Delegate cb_setCurrentChatroomPassword_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetCurrentChatroomPassword_Ljava_lang_String_Handler ()
		{
			if (cb_setCurrentChatroomPassword_Ljava_lang_String_ == null)
				cb_setCurrentChatroomPassword_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCurrentChatroomPassword_Ljava_lang_String_);
			return cb_setCurrentChatroomPassword_Ljava_lang_String_;
		}

		static void n_SetCurrentChatroomPassword_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CurrentChatroomPassword = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCurrentChatroomPassword;
		static IntPtr id_setCurrentChatroomPassword_Ljava_lang_String_;
		public virtual unsafe string CurrentChatroomPassword {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getCurrentChatroomPassword' and count(parameter)=0]"
			[Register ("getCurrentChatroomPassword", "()Ljava/lang/String;", "GetGetCurrentChatroomPasswordHandler")]
			get {
				if (id_getCurrentChatroomPassword == IntPtr.Zero)
					id_getCurrentChatroomPassword = JNIEnv.GetMethodID (class_ref, "getCurrentChatroomPassword", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentChatroomPassword), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCurrentChatroomPassword", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setCurrentChatroomPassword' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setCurrentChatroomPassword", "(Ljava/lang/String;)V", "GetSetCurrentChatroomPassword_Ljava_lang_String_Handler")]
			set {
				if (id_setCurrentChatroomPassword_Ljava_lang_String_ == IntPtr.Zero)
					id_setCurrentChatroomPassword_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setCurrentChatroomPassword", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCurrentChatroomPassword_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCurrentChatroomPassword", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isInitialHeartbeat;
#pragma warning disable 0169
		static Delegate GetIsInitialHeartbeatHandler ()
		{
			if (cb_isInitialHeartbeat == null)
				cb_isInitialHeartbeat = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsInitialHeartbeat);
			return cb_isInitialHeartbeat;
		}

		static bool n_IsInitialHeartbeat (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.InitialHeartbeat;
		}
#pragma warning restore 0169

		static Delegate cb_setInitialHeartbeat_Z;
#pragma warning disable 0169
		static Delegate GetSetInitialHeartbeat_ZHandler ()
		{
			if (cb_setInitialHeartbeat_Z == null)
				cb_setInitialHeartbeat_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetInitialHeartbeat_Z);
			return cb_setInitialHeartbeat_Z;
		}

		static void n_SetInitialHeartbeat_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.InitialHeartbeat = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isInitialHeartbeat;
		static IntPtr id_setInitialHeartbeat_Z;
		public virtual unsafe bool InitialHeartbeat {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isInitialHeartbeat' and count(parameter)=0]"
			[Register ("isInitialHeartbeat", "()Z", "GetIsInitialHeartbeatHandler")]
			get {
				if (id_isInitialHeartbeat == IntPtr.Zero)
					id_isInitialHeartbeat = JNIEnv.GetMethodID (class_ref, "isInitialHeartbeat", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isInitialHeartbeat);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isInitialHeartbeat", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setInitialHeartbeat' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setInitialHeartbeat", "(Z)V", "GetSetInitialHeartbeat_ZHandler")]
			set {
				if (id_setInitialHeartbeat_Z == IntPtr.Zero)
					id_setInitialHeartbeat_Z = JNIEnv.GetMethodID (class_ref, "setInitialHeartbeat", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setInitialHeartbeat_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setInitialHeartbeat", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static IntPtr id_getInstance;
		static IntPtr id_setInstance_Lcom_inscripts_utils_SessionData_;
		public static unsafe global::Com.Inscripts.Utils.SessionData Instance {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getInstance' and count(parameter)=0]"
			[Register ("getInstance", "()Lcom/inscripts/utils/SessionData;", "GetGetInstanceHandler")]
			get {
				if (id_getInstance == IntPtr.Zero)
					id_getInstance = JNIEnv.GetStaticMethodID (class_ref, "getInstance", "()Lcom/inscripts/utils/SessionData;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getInstance), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setInstance' and count(parameter)=1 and parameter[1][@type='com.inscripts.utils.SessionData']]"
			[Register ("setInstance", "(Lcom/inscripts/utils/SessionData;)V", "GetSetInstance_Lcom_inscripts_utils_SessionData_Handler")]
			set {
				if (id_setInstance_Lcom_inscripts_utils_SessionData_ == IntPtr.Zero)
					id_setInstance_Lcom_inscripts_utils_SessionData_ = JNIEnv.GetStaticMethodID (class_ref, "setInstance", "(Lcom/inscripts/utils/SessionData;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setInstance_Lcom_inscripts_utils_SessionData_, __args);
				} finally {
				}
			}
		}

		static Delegate cb_isCall;
#pragma warning disable 0169
		static Delegate GetIsCallHandler ()
		{
			if (cb_isCall == null)
				cb_isCall = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsCall);
			return cb_isCall;
		}

		static bool n_IsCall (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCall;
		}
#pragma warning restore 0169

		static IntPtr id_isCall;
		public virtual unsafe bool IsCall {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isCall' and count(parameter)=0]"
			[Register ("isCall", "()Z", "GetIsCallHandler")]
			get {
				if (id_isCall == IntPtr.Zero)
					id_isCall = JNIEnv.GetMethodID (class_ref, "isCall", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCall);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCall", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_isCometOnDemand;
#pragma warning disable 0169
		static Delegate GetIsCometOnDemandHandler ()
		{
			if (cb_isCometOnDemand == null)
				cb_isCometOnDemand = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsCometOnDemand);
			return cb_isCometOnDemand;
		}

		static bool n_IsCometOnDemand (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCometOnDemand;
		}
#pragma warning restore 0169

		static Delegate cb_setIsCometOnDemand_Z;
#pragma warning disable 0169
		static Delegate GetSetIsCometOnDemand_ZHandler ()
		{
			if (cb_setIsCometOnDemand_Z == null)
				cb_setIsCometOnDemand_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetIsCometOnDemand_Z);
			return cb_setIsCometOnDemand_Z;
		}

		static void n_SetIsCometOnDemand_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.IsCometOnDemand = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isCometOnDemand;
		static IntPtr id_setIsCometOnDemand_Z;
		public virtual unsafe bool IsCometOnDemand {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isCometOnDemand' and count(parameter)=0]"
			[Register ("isCometOnDemand", "()Z", "GetIsCometOnDemandHandler")]
			get {
				if (id_isCometOnDemand == IntPtr.Zero)
					id_isCometOnDemand = JNIEnv.GetMethodID (class_ref, "isCometOnDemand", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCometOnDemand);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCometOnDemand", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setIsCometOnDemand' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setIsCometOnDemand", "(Z)V", "GetSetIsCometOnDemand_ZHandler")]
			set {
				if (id_setIsCometOnDemand_Z == IntPtr.Zero)
					id_setIsCometOnDemand_Z = JNIEnv.GetMethodID (class_ref, "setIsCometOnDemand", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setIsCometOnDemand_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setIsCometOnDemand", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isMediaPlayerOn;
#pragma warning disable 0169
		static Delegate GetIsMediaPlayerOnHandler ()
		{
			if (cb_isMediaPlayerOn == null)
				cb_isMediaPlayerOn = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsMediaPlayerOn);
			return cb_isMediaPlayerOn;
		}

		static bool n_IsMediaPlayerOn (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.MediaPlayerOn;
		}
#pragma warning restore 0169

		static Delegate cb_setMediaPlayerOn_Z;
#pragma warning disable 0169
		static Delegate GetSetMediaPlayerOn_ZHandler ()
		{
			if (cb_setMediaPlayerOn_Z == null)
				cb_setMediaPlayerOn_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetMediaPlayerOn_Z);
			return cb_setMediaPlayerOn_Z;
		}

		static void n_SetMediaPlayerOn_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.MediaPlayerOn = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isMediaPlayerOn;
		static IntPtr id_setMediaPlayerOn_Z;
		public virtual unsafe bool MediaPlayerOn {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isMediaPlayerOn' and count(parameter)=0]"
			[Register ("isMediaPlayerOn", "()Z", "GetIsMediaPlayerOnHandler")]
			get {
				if (id_isMediaPlayerOn == IntPtr.Zero)
					id_isMediaPlayerOn = JNIEnv.GetMethodID (class_ref, "isMediaPlayerOn", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isMediaPlayerOn);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isMediaPlayerOn", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setMediaPlayerOn' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setMediaPlayerOn", "(Z)V", "GetSetMediaPlayerOn_ZHandler")]
			set {
				if (id_setMediaPlayerOn_Z == IntPtr.Zero)
					id_setMediaPlayerOn_Z = JNIEnv.GetMethodID (class_ref, "setMediaPlayerOn", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaPlayerOn_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setMediaPlayerOn", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getOneOnOneHeartBeatIdealCount;
#pragma warning disable 0169
		static Delegate GetGetOneOnOneHeartBeatIdealCountHandler ()
		{
			if (cb_getOneOnOneHeartBeatIdealCount == null)
				cb_getOneOnOneHeartBeatIdealCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetOneOnOneHeartBeatIdealCount);
			return cb_getOneOnOneHeartBeatIdealCount;
		}

		static int n_GetOneOnOneHeartBeatIdealCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.OneOnOneHeartBeatIdealCount;
		}
#pragma warning restore 0169

		static Delegate cb_setOneOnOneHeartBeatIdealCount_I;
#pragma warning disable 0169
		static Delegate GetSetOneOnOneHeartBeatIdealCount_IHandler ()
		{
			if (cb_setOneOnOneHeartBeatIdealCount_I == null)
				cb_setOneOnOneHeartBeatIdealCount_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetOneOnOneHeartBeatIdealCount_I);
			return cb_setOneOnOneHeartBeatIdealCount_I;
		}

		static void n_SetOneOnOneHeartBeatIdealCount_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OneOnOneHeartBeatIdealCount = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getOneOnOneHeartBeatIdealCount;
		static IntPtr id_setOneOnOneHeartBeatIdealCount_I;
		public virtual unsafe int OneOnOneHeartBeatIdealCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getOneOnOneHeartBeatIdealCount' and count(parameter)=0]"
			[Register ("getOneOnOneHeartBeatIdealCount", "()I", "GetGetOneOnOneHeartBeatIdealCountHandler")]
			get {
				if (id_getOneOnOneHeartBeatIdealCount == IntPtr.Zero)
					id_getOneOnOneHeartBeatIdealCount = JNIEnv.GetMethodID (class_ref, "getOneOnOneHeartBeatIdealCount", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getOneOnOneHeartBeatIdealCount);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getOneOnOneHeartBeatIdealCount", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setOneOnOneHeartBeatIdealCount' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setOneOnOneHeartBeatIdealCount", "(I)V", "GetSetOneOnOneHeartBeatIdealCount_IHandler")]
			set {
				if (id_setOneOnOneHeartBeatIdealCount_I == IntPtr.Zero)
					id_setOneOnOneHeartBeatIdealCount_I = JNIEnv.GetMethodID (class_ref, "setOneOnOneHeartBeatIdealCount", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOneOnOneHeartBeatIdealCount_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOneOnOneHeartBeatIdealCount", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getOneOnOneHeartBeatTimestamp;
#pragma warning disable 0169
		static Delegate GetGetOneOnOneHeartBeatTimestampHandler ()
		{
			if (cb_getOneOnOneHeartBeatTimestamp == null)
				cb_getOneOnOneHeartBeatTimestamp = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetOneOnOneHeartBeatTimestamp);
			return cb_getOneOnOneHeartBeatTimestamp;
		}

		static IntPtr n_GetOneOnOneHeartBeatTimestamp (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.OneOnOneHeartBeatTimestamp);
		}
#pragma warning restore 0169

		static Delegate cb_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSetOneOnOneHeartBeatTimestamp_Ljava_lang_Long_Handler ()
		{
			if (cb_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_ == null)
				cb_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetOneOnOneHeartBeatTimestamp_Ljava_lang_Long_);
			return cb_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_;
		}

		static void n_SetOneOnOneHeartBeatTimestamp_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OneOnOneHeartBeatTimestamp = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getOneOnOneHeartBeatTimestamp;
		static IntPtr id_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_;
		public virtual unsafe global::Java.Lang.Long OneOnOneHeartBeatTimestamp {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getOneOnOneHeartBeatTimestamp' and count(parameter)=0]"
			[Register ("getOneOnOneHeartBeatTimestamp", "()Ljava/lang/Long;", "GetGetOneOnOneHeartBeatTimestampHandler")]
			get {
				if (id_getOneOnOneHeartBeatTimestamp == IntPtr.Zero)
					id_getOneOnOneHeartBeatTimestamp = JNIEnv.GetMethodID (class_ref, "getOneOnOneHeartBeatTimestamp", "()Ljava/lang/Long;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getOneOnOneHeartBeatTimestamp), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getOneOnOneHeartBeatTimestamp", "()Ljava/lang/Long;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setOneOnOneHeartBeatTimestamp' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
			[Register ("setOneOnOneHeartBeatTimestamp", "(Ljava/lang/Long;)V", "GetSetOneOnOneHeartBeatTimestamp_Ljava_lang_Long_Handler")]
			set {
				if (id_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_ == IntPtr.Zero)
					id_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "setOneOnOneHeartBeatTimestamp", "(Ljava/lang/Long;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOneOnOneHeartBeatTimestamp_Ljava_lang_Long_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOneOnOneHeartBeatTimestamp", "(Ljava/lang/Long;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getOneOnOneHeartbeatInterval;
#pragma warning disable 0169
		static Delegate GetGetOneOnOneHeartbeatIntervalHandler ()
		{
			if (cb_getOneOnOneHeartbeatInterval == null)
				cb_getOneOnOneHeartbeatInterval = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetOneOnOneHeartbeatInterval);
			return cb_getOneOnOneHeartbeatInterval;
		}

		static long n_GetOneOnOneHeartbeatInterval (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.OneOnOneHeartbeatInterval;
		}
#pragma warning restore 0169

		static Delegate cb_setOneOnOneHeartbeatInterval_J;
#pragma warning disable 0169
		static Delegate GetSetOneOnOneHeartbeatInterval_JHandler ()
		{
			if (cb_setOneOnOneHeartbeatInterval_J == null)
				cb_setOneOnOneHeartbeatInterval_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetOneOnOneHeartbeatInterval_J);
			return cb_setOneOnOneHeartbeatInterval_J;
		}

		static void n_SetOneOnOneHeartbeatInterval_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OneOnOneHeartbeatInterval = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getOneOnOneHeartbeatInterval;
		static IntPtr id_setOneOnOneHeartbeatInterval_J;
		public virtual unsafe long OneOnOneHeartbeatInterval {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getOneOnOneHeartbeatInterval' and count(parameter)=0]"
			[Register ("getOneOnOneHeartbeatInterval", "()J", "GetGetOneOnOneHeartbeatIntervalHandler")]
			get {
				if (id_getOneOnOneHeartbeatInterval == IntPtr.Zero)
					id_getOneOnOneHeartbeatInterval = JNIEnv.GetMethodID (class_ref, "getOneOnOneHeartbeatInterval", "()J");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getOneOnOneHeartbeatInterval);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getOneOnOneHeartbeatInterval", "()J"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setOneOnOneHeartbeatInterval' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setOneOnOneHeartbeatInterval", "(J)V", "GetSetOneOnOneHeartbeatInterval_JHandler")]
			set {
				if (id_setOneOnOneHeartbeatInterval_J == IntPtr.Zero)
					id_setOneOnOneHeartbeatInterval_J = JNIEnv.GetMethodID (class_ref, "setOneOnOneHeartbeatInterval", "(J)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOneOnOneHeartbeatInterval_J, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOneOnOneHeartbeatInterval", "(J)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isOneToOneBroadCastMissed;
#pragma warning disable 0169
		static Delegate GetIsOneToOneBroadCastMissedHandler ()
		{
			if (cb_isOneToOneBroadCastMissed == null)
				cb_isOneToOneBroadCastMissed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsOneToOneBroadCastMissed);
			return cb_isOneToOneBroadCastMissed;
		}

		static bool n_IsOneToOneBroadCastMissed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.OneToOneBroadCastMissed;
		}
#pragma warning restore 0169

		static Delegate cb_setOneToOneBroadCastMissed_Z;
#pragma warning disable 0169
		static Delegate GetSetOneToOneBroadCastMissed_ZHandler ()
		{
			if (cb_setOneToOneBroadCastMissed_Z == null)
				cb_setOneToOneBroadCastMissed_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetOneToOneBroadCastMissed_Z);
			return cb_setOneToOneBroadCastMissed_Z;
		}

		static void n_SetOneToOneBroadCastMissed_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OneToOneBroadCastMissed = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isOneToOneBroadCastMissed;
		static IntPtr id_setOneToOneBroadCastMissed_Z;
		public virtual unsafe bool OneToOneBroadCastMissed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isOneToOneBroadCastMissed' and count(parameter)=0]"
			[Register ("isOneToOneBroadCastMissed", "()Z", "GetIsOneToOneBroadCastMissedHandler")]
			get {
				if (id_isOneToOneBroadCastMissed == IntPtr.Zero)
					id_isOneToOneBroadCastMissed = JNIEnv.GetMethodID (class_ref, "isOneToOneBroadCastMissed", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isOneToOneBroadCastMissed);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isOneToOneBroadCastMissed", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setOneToOneBroadCastMissed' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setOneToOneBroadCastMissed", "(Z)V", "GetSetOneToOneBroadCastMissed_ZHandler")]
			set {
				if (id_setOneToOneBroadCastMissed_Z == IntPtr.Zero)
					id_setOneToOneBroadCastMissed_Z = JNIEnv.GetMethodID (class_ref, "setOneToOneBroadCastMissed", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOneToOneBroadCastMissed_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOneToOneBroadCastMissed", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getParseChannel;
#pragma warning disable 0169
		static Delegate GetGetParseChannelHandler ()
		{
			if (cb_getParseChannel == null)
				cb_getParseChannel = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetParseChannel);
			return cb_getParseChannel;
		}

		static IntPtr n_GetParseChannel (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ParseChannel);
		}
#pragma warning restore 0169

		static Delegate cb_setParseChannel_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetParseChannel_Ljava_lang_String_Handler ()
		{
			if (cb_setParseChannel_Ljava_lang_String_ == null)
				cb_setParseChannel_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetParseChannel_Ljava_lang_String_);
			return cb_setParseChannel_Ljava_lang_String_;
		}

		static void n_SetParseChannel_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ParseChannel = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getParseChannel;
		static IntPtr id_setParseChannel_Ljava_lang_String_;
		public virtual unsafe string ParseChannel {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getParseChannel' and count(parameter)=0]"
			[Register ("getParseChannel", "()Ljava/lang/String;", "GetGetParseChannelHandler")]
			get {
				if (id_getParseChannel == IntPtr.Zero)
					id_getParseChannel = JNIEnv.GetMethodID (class_ref, "getParseChannel", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getParseChannel), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getParseChannel", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setParseChannel' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setParseChannel", "(Ljava/lang/String;)V", "GetSetParseChannel_Ljava_lang_String_Handler")]
			set {
				if (id_setParseChannel_Ljava_lang_String_ == IntPtr.Zero)
					id_setParseChannel_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setParseChannel", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setParseChannel_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setParseChannel", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getServerTime;
#pragma warning disable 0169
		static Delegate GetGetServerTimeHandler ()
		{
			if (cb_getServerTime == null)
				cb_getServerTime = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetServerTime);
			return cb_getServerTime;
		}

		static IntPtr n_GetServerTime (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ServerTime);
		}
#pragma warning restore 0169

		static Delegate cb_setServerTime_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetServerTime_Ljava_lang_String_Handler ()
		{
			if (cb_setServerTime_Ljava_lang_String_ == null)
				cb_setServerTime_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetServerTime_Ljava_lang_String_);
			return cb_setServerTime_Ljava_lang_String_;
		}

		static void n_SetServerTime_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ServerTime = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getServerTime;
		static IntPtr id_setServerTime_Ljava_lang_String_;
		public virtual unsafe string ServerTime {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getServerTime' and count(parameter)=0]"
			[Register ("getServerTime", "()Ljava/lang/String;", "GetGetServerTimeHandler")]
			get {
				if (id_getServerTime == IntPtr.Zero)
					id_getServerTime = JNIEnv.GetMethodID (class_ref, "getServerTime", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getServerTime), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getServerTime", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setServerTime' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setServerTime", "(Ljava/lang/String;)V", "GetSetServerTime_Ljava_lang_String_Handler")]
			set {
				if (id_setServerTime_Ljava_lang_String_ == IntPtr.Zero)
					id_setServerTime_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setServerTime", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setServerTime_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setServerTime", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getTopFragment;
#pragma warning disable 0169
		static Delegate GetGetTopFragmentHandler ()
		{
			if (cb_getTopFragment == null)
				cb_getTopFragment = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTopFragment);
			return cb_getTopFragment;
		}

		static IntPtr n_GetTopFragment (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TopFragment);
		}
#pragma warning restore 0169

		static Delegate cb_setTopFragment_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetTopFragment_Ljava_lang_String_Handler ()
		{
			if (cb_setTopFragment_Ljava_lang_String_ == null)
				cb_setTopFragment_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetTopFragment_Ljava_lang_String_);
			return cb_setTopFragment_Ljava_lang_String_;
		}

		static void n_SetTopFragment_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.TopFragment = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getTopFragment;
		static IntPtr id_setTopFragment_Ljava_lang_String_;
		public virtual unsafe string TopFragment {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getTopFragment' and count(parameter)=0]"
			[Register ("getTopFragment", "()Ljava/lang/String;", "GetGetTopFragmentHandler")]
			get {
				if (id_getTopFragment == IntPtr.Zero)
					id_getTopFragment = JNIEnv.GetMethodID (class_ref, "getTopFragment", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTopFragment), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTopFragment", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setTopFragment' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setTopFragment", "(Ljava/lang/String;)V", "GetSetTopFragment_Ljava_lang_String_Handler")]
			set {
				if (id_setTopFragment_Ljava_lang_String_ == IntPtr.Zero)
					id_setTopFragment_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setTopFragment", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setTopFragment_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setTopFragment", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getUserInfoHeartBeatFlag;
#pragma warning disable 0169
		static Delegate GetGetUserInfoHeartBeatFlagHandler ()
		{
			if (cb_getUserInfoHeartBeatFlag == null)
				cb_getUserInfoHeartBeatFlag = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUserInfoHeartBeatFlag);
			return cb_getUserInfoHeartBeatFlag;
		}

		static IntPtr n_GetUserInfoHeartBeatFlag (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.UserInfoHeartBeatFlag);
		}
#pragma warning restore 0169

		static Delegate cb_setUserInfoHeartBeatFlag_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetUserInfoHeartBeatFlag_Ljava_lang_String_Handler ()
		{
			if (cb_setUserInfoHeartBeatFlag_Ljava_lang_String_ == null)
				cb_setUserInfoHeartBeatFlag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetUserInfoHeartBeatFlag_Ljava_lang_String_);
			return cb_setUserInfoHeartBeatFlag_Ljava_lang_String_;
		}

		static void n_SetUserInfoHeartBeatFlag_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.UserInfoHeartBeatFlag = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getUserInfoHeartBeatFlag;
		static IntPtr id_setUserInfoHeartBeatFlag_Ljava_lang_String_;
		public virtual unsafe string UserInfoHeartBeatFlag {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='getUserInfoHeartBeatFlag' and count(parameter)=0]"
			[Register ("getUserInfoHeartBeatFlag", "()Ljava/lang/String;", "GetGetUserInfoHeartBeatFlagHandler")]
			get {
				if (id_getUserInfoHeartBeatFlag == IntPtr.Zero)
					id_getUserInfoHeartBeatFlag = JNIEnv.GetMethodID (class_ref, "getUserInfoHeartBeatFlag", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUserInfoHeartBeatFlag), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getUserInfoHeartBeatFlag", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setUserInfoHeartBeatFlag' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setUserInfoHeartBeatFlag", "(Ljava/lang/String;)V", "GetSetUserInfoHeartBeatFlag_Ljava_lang_String_Handler")]
			set {
				if (id_setUserInfoHeartBeatFlag_Ljava_lang_String_ == IntPtr.Zero)
					id_setUserInfoHeartBeatFlag_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setUserInfoHeartBeatFlag", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setUserInfoHeartBeatFlag_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setUserInfoHeartBeatFlag", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isVibrateOn;
#pragma warning disable 0169
		static Delegate GetIsVibrateOnHandler ()
		{
			if (cb_isVibrateOn == null)
				cb_isVibrateOn = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsVibrateOn);
			return cb_isVibrateOn;
		}

		static bool n_IsVibrateOn (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.VibrateOn;
		}
#pragma warning restore 0169

		static Delegate cb_setVibrateOn_Z;
#pragma warning disable 0169
		static Delegate GetSetVibrateOn_ZHandler ()
		{
			if (cb_setVibrateOn_Z == null)
				cb_setVibrateOn_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetVibrateOn_Z);
			return cb_setVibrateOn_Z;
		}

		static void n_SetVibrateOn_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.VibrateOn = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isVibrateOn;
		static IntPtr id_setVibrateOn_Z;
		public virtual unsafe bool VibrateOn {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='isVibrateOn' and count(parameter)=0]"
			[Register ("isVibrateOn", "()Z", "GetIsVibrateOnHandler")]
			get {
				if (id_isVibrateOn == IntPtr.Zero)
					id_isVibrateOn = JNIEnv.GetMethodID (class_ref, "isVibrateOn", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isVibrateOn);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isVibrateOn", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setVibrateOn' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setVibrateOn", "(Z)V", "GetSetVibrateOn_ZHandler")]
			set {
				if (id_setVibrateOn_Z == IntPtr.Zero)
					id_setVibrateOn_Z = JNIEnv.GetMethodID (class_ref, "setVibrateOn", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVibrateOn_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVibrateOn", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_setChatroomMemberListHash_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetChatroomMemberListHash_Ljava_lang_String_Handler ()
		{
			if (cb_setChatroomMemberListHash_Ljava_lang_String_ == null)
				cb_setChatroomMemberListHash_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetChatroomMemberListHash_Ljava_lang_String_);
			return cb_setChatroomMemberListHash_Ljava_lang_String_;
		}

		static void n_SetChatroomMemberListHash_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetChatroomMemberListHash (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setChatroomMemberListHash_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='setChatroomMemberListHash' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setChatroomMemberListHash", "(Ljava/lang/String;)V", "GetSetChatroomMemberListHash_Ljava_lang_String_Handler")]
		public virtual unsafe void SetChatroomMemberListHash (string p0)
		{
			if (id_setChatroomMemberListHash_Ljava_lang_String_ == IntPtr.Zero)
				id_setChatroomMemberListHash_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setChatroomMemberListHash", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setChatroomMemberListHash_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setChatroomMemberListHash", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_update_Lorg_json_JSONObject_;
#pragma warning disable 0169
		static Delegate GetUpdate_Lorg_json_JSONObject_Handler ()
		{
			if (cb_update_Lorg_json_JSONObject_ == null)
				cb_update_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Update_Lorg_json_JSONObject_);
			return cb_update_Lorg_json_JSONObject_;
		}

		static void n_Update_Lorg_json_JSONObject_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SessionData __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SessionData> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Org.Json.JSONObject p0 = global::Java.Lang.Object.GetObject<global::Org.Json.JSONObject> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Update (p0);
		}
#pragma warning restore 0169

		static IntPtr id_update_Lorg_json_JSONObject_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SessionData']/method[@name='update' and count(parameter)=1 and parameter[1][@type='org.json.JSONObject']]"
		[Register ("update", "(Lorg/json/JSONObject;)V", "GetUpdate_Lorg_json_JSONObject_Handler")]
		public virtual unsafe void Update (global::Org.Json.JSONObject p0)
		{
			if (id_update_Lorg_json_JSONObject_ == IntPtr.Zero)
				id_update_Lorg_json_JSONObject_ = JNIEnv.GetMethodID (class_ref, "update", "(Lorg/json/JSONObject;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_update_Lorg_json_JSONObject_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "update", "(Lorg/json/JSONObject;)V"), __args);
			} finally {
			}
		}

	}
}
