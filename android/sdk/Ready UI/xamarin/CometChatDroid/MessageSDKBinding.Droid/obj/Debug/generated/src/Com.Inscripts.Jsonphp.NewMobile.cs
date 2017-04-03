using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/NewMobile", DoNotGenerateAcw=true)]
	public partial class NewMobile : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/NewMobile", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (NewMobile); }
		}

		protected NewMobile (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/constructor[@name='NewMobile' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe NewMobile ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (NewMobile)) {
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

		static Delegate cb_getAnn;
#pragma warning disable 0169
		static Delegate GetGetAnnHandler ()
		{
			if (cb_getAnn == null)
				cb_getAnn = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAnn);
			return cb_getAnn;
		}

		static IntPtr n_GetAnn (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Ann);
		}
#pragma warning restore 0169

		static Delegate cb_setAnn_Lcom_inscripts_jsonphp_Ann_;
#pragma warning disable 0169
		static Delegate GetSetAnn_Lcom_inscripts_jsonphp_Ann_Handler ()
		{
			if (cb_setAnn_Lcom_inscripts_jsonphp_Ann_ == null)
				cb_setAnn_Lcom_inscripts_jsonphp_Ann_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetAnn_Lcom_inscripts_jsonphp_Ann_);
			return cb_setAnn_Lcom_inscripts_jsonphp_Ann_;
		}

		static void n_SetAnn_Lcom_inscripts_jsonphp_Ann_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Ann p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Ann = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getAnn;
		static IntPtr id_setAnn_Lcom_inscripts_jsonphp_Ann_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Ann Ann {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getAnn' and count(parameter)=0]"
			[Register ("getAnn", "()Lcom/inscripts/jsonphp/Ann;", "GetGetAnnHandler")]
			get {
				if (id_getAnn == IntPtr.Zero)
					id_getAnn = JNIEnv.GetMethodID (class_ref, "getAnn", "()Lcom/inscripts/jsonphp/Ann;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnn), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getAnn", "()Lcom/inscripts/jsonphp/Ann;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setAnn' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Ann']]"
			[Register ("setAnn", "(Lcom/inscripts/jsonphp/Ann;)V", "GetSetAnn_Lcom_inscripts_jsonphp_Ann_Handler")]
			set {
				if (id_setAnn_Lcom_inscripts_jsonphp_Ann_ == IntPtr.Zero)
					id_setAnn_Lcom_inscripts_jsonphp_Ann_ = JNIEnv.GetMethodID (class_ref, "setAnn", "(Lcom/inscripts/jsonphp/Ann;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAnn_Lcom_inscripts_jsonphp_Ann_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAnn", "(Lcom/inscripts/jsonphp/Ann;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCommon;
#pragma warning disable 0169
		static Delegate GetGetCommonHandler ()
		{
			if (cb_getCommon == null)
				cb_getCommon = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCommon);
			return cb_getCommon;
		}

		static IntPtr n_GetCommon (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Common);
		}
#pragma warning restore 0169

		static Delegate cb_setCommon_Lcom_inscripts_jsonphp_Common_;
#pragma warning disable 0169
		static Delegate GetSetCommon_Lcom_inscripts_jsonphp_Common_Handler ()
		{
			if (cb_setCommon_Lcom_inscripts_jsonphp_Common_ == null)
				cb_setCommon_Lcom_inscripts_jsonphp_Common_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCommon_Lcom_inscripts_jsonphp_Common_);
			return cb_setCommon_Lcom_inscripts_jsonphp_Common_;
		}

		static void n_SetCommon_Lcom_inscripts_jsonphp_Common_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Common p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Common = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCommon;
		static IntPtr id_setCommon_Lcom_inscripts_jsonphp_Common_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Common Common {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getCommon' and count(parameter)=0]"
			[Register ("getCommon", "()Lcom/inscripts/jsonphp/Common;", "GetGetCommonHandler")]
			get {
				if (id_getCommon == IntPtr.Zero)
					id_getCommon = JNIEnv.GetMethodID (class_ref, "getCommon", "()Lcom/inscripts/jsonphp/Common;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCommon), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Common> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCommon", "()Lcom/inscripts/jsonphp/Common;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setCommon' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Common']]"
			[Register ("setCommon", "(Lcom/inscripts/jsonphp/Common;)V", "GetSetCommon_Lcom_inscripts_jsonphp_Common_Handler")]
			set {
				if (id_setCommon_Lcom_inscripts_jsonphp_Common_ == IntPtr.Zero)
					id_setCommon_Lcom_inscripts_jsonphp_Common_ = JNIEnv.GetMethodID (class_ref, "setCommon", "(Lcom/inscripts/jsonphp/Common;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCommon_Lcom_inscripts_jsonphp_Common_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCommon", "(Lcom/inscripts/jsonphp/Common;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCreateProfile;
#pragma warning disable 0169
		static Delegate GetGetCreateProfileHandler ()
		{
			if (cb_getCreateProfile == null)
				cb_getCreateProfile = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCreateProfile);
			return cb_getCreateProfile;
		}

		static IntPtr n_GetCreateProfile (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.CreateProfile);
		}
#pragma warning restore 0169

		static Delegate cb_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_;
#pragma warning disable 0169
		static Delegate GetSetCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_Handler ()
		{
			if (cb_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_ == null)
				cb_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_);
			return cb_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_;
		}

		static void n_SetCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.CreateProfile p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CreateProfile = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCreateProfile;
		static IntPtr id_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.CreateProfile CreateProfile {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getCreateProfile' and count(parameter)=0]"
			[Register ("getCreateProfile", "()Lcom/inscripts/jsonphp/CreateProfile;", "GetGetCreateProfileHandler")]
			get {
				if (id_getCreateProfile == IntPtr.Zero)
					id_getCreateProfile = JNIEnv.GetMethodID (class_ref, "getCreateProfile", "()Lcom/inscripts/jsonphp/CreateProfile;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCreateProfile), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.CreateProfile> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCreateProfile", "()Lcom/inscripts/jsonphp/CreateProfile;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setCreateProfile' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.CreateProfile']]"
			[Register ("setCreateProfile", "(Lcom/inscripts/jsonphp/CreateProfile;)V", "GetSetCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_Handler")]
			set {
				if (id_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_ == IntPtr.Zero)
					id_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_ = JNIEnv.GetMethodID (class_ref, "setCreateProfile", "(Lcom/inscripts/jsonphp/CreateProfile;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCreateProfile_Lcom_inscripts_jsonphp_CreateProfile_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCreateProfile", "(Lcom/inscripts/jsonphp/CreateProfile;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getHome;
#pragma warning disable 0169
		static Delegate GetGetHomeHandler ()
		{
			if (cb_getHome == null)
				cb_getHome = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetHome);
			return cb_getHome;
		}

		static IntPtr n_GetHome (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Home);
		}
#pragma warning restore 0169

		static Delegate cb_setHome_Lcom_inscripts_jsonphp_Home_;
#pragma warning disable 0169
		static Delegate GetSetHome_Lcom_inscripts_jsonphp_Home_Handler ()
		{
			if (cb_setHome_Lcom_inscripts_jsonphp_Home_ == null)
				cb_setHome_Lcom_inscripts_jsonphp_Home_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetHome_Lcom_inscripts_jsonphp_Home_);
			return cb_setHome_Lcom_inscripts_jsonphp_Home_;
		}

		static void n_SetHome_Lcom_inscripts_jsonphp_Home_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Home p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Home> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Home = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getHome;
		static IntPtr id_setHome_Lcom_inscripts_jsonphp_Home_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Home Home {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getHome' and count(parameter)=0]"
			[Register ("getHome", "()Lcom/inscripts/jsonphp/Home;", "GetGetHomeHandler")]
			get {
				if (id_getHome == IntPtr.Zero)
					id_getHome = JNIEnv.GetMethodID (class_ref, "getHome", "()Lcom/inscripts/jsonphp/Home;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Home> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHome), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Home> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHome", "()Lcom/inscripts/jsonphp/Home;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setHome' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Home']]"
			[Register ("setHome", "(Lcom/inscripts/jsonphp/Home;)V", "GetSetHome_Lcom_inscripts_jsonphp_Home_Handler")]
			set {
				if (id_setHome_Lcom_inscripts_jsonphp_Home_ == IntPtr.Zero)
					id_setHome_Lcom_inscripts_jsonphp_Home_ = JNIEnv.GetMethodID (class_ref, "setHome", "(Lcom/inscripts/jsonphp/Home;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHome_Lcom_inscripts_jsonphp_Home_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setHome", "(Lcom/inscripts/jsonphp/Home;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getInviteSms;
#pragma warning disable 0169
		static Delegate GetGetInviteSmsHandler ()
		{
			if (cb_getInviteSms == null)
				cb_getInviteSms = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInviteSms);
			return cb_getInviteSms;
		}

		static IntPtr n_GetInviteSms (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.InviteSms);
		}
#pragma warning restore 0169

		static Delegate cb_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_;
#pragma warning disable 0169
		static Delegate GetSetInviteSms_Lcom_inscripts_jsonphp_InviteSms_Handler ()
		{
			if (cb_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_ == null)
				cb_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetInviteSms_Lcom_inscripts_jsonphp_InviteSms_);
			return cb_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_;
		}

		static void n_SetInviteSms_Lcom_inscripts_jsonphp_InviteSms_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.InviteSms p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.InviteSms = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getInviteSms;
		static IntPtr id_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.InviteSms InviteSms {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getInviteSms' and count(parameter)=0]"
			[Register ("getInviteSms", "()Lcom/inscripts/jsonphp/InviteSms;", "GetGetInviteSmsHandler")]
			get {
				if (id_getInviteSms == IntPtr.Zero)
					id_getInviteSms = JNIEnv.GetMethodID (class_ref, "getInviteSms", "()Lcom/inscripts/jsonphp/InviteSms;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInviteSms), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.InviteSms> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInviteSms", "()Lcom/inscripts/jsonphp/InviteSms;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setInviteSms' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.InviteSms']]"
			[Register ("setInviteSms", "(Lcom/inscripts/jsonphp/InviteSms;)V", "GetSetInviteSms_Lcom_inscripts_jsonphp_InviteSms_Handler")]
			set {
				if (id_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_ == IntPtr.Zero)
					id_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_ = JNIEnv.GetMethodID (class_ref, "setInviteSms", "(Lcom/inscripts/jsonphp/InviteSms;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setInviteSms_Lcom_inscripts_jsonphp_InviteSms_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setInviteSms", "(Lcom/inscripts/jsonphp/InviteSms;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getLogin;
#pragma warning disable 0169
		static Delegate GetGetLoginHandler ()
		{
			if (cb_getLogin == null)
				cb_getLogin = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLogin);
			return cb_getLogin;
		}

		static IntPtr n_GetLogin (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Login);
		}
#pragma warning restore 0169

		static Delegate cb_setLogin_Lcom_inscripts_jsonphp_Login_;
#pragma warning disable 0169
		static Delegate GetSetLogin_Lcom_inscripts_jsonphp_Login_Handler ()
		{
			if (cb_setLogin_Lcom_inscripts_jsonphp_Login_ == null)
				cb_setLogin_Lcom_inscripts_jsonphp_Login_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetLogin_Lcom_inscripts_jsonphp_Login_);
			return cb_setLogin_Lcom_inscripts_jsonphp_Login_;
		}

		static void n_SetLogin_Lcom_inscripts_jsonphp_Login_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Login p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Login = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getLogin;
		static IntPtr id_setLogin_Lcom_inscripts_jsonphp_Login_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Login Login {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getLogin' and count(parameter)=0]"
			[Register ("getLogin", "()Lcom/inscripts/jsonphp/Login;", "GetGetLoginHandler")]
			get {
				if (id_getLogin == IntPtr.Zero)
					id_getLogin = JNIEnv.GetMethodID (class_ref, "getLogin", "()Lcom/inscripts/jsonphp/Login;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLogin), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Login> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLogin", "()Lcom/inscripts/jsonphp/Login;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setLogin' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Login']]"
			[Register ("setLogin", "(Lcom/inscripts/jsonphp/Login;)V", "GetSetLogin_Lcom_inscripts_jsonphp_Login_Handler")]
			set {
				if (id_setLogin_Lcom_inscripts_jsonphp_Login_ == IntPtr.Zero)
					id_setLogin_Lcom_inscripts_jsonphp_Login_ = JNIEnv.GetMethodID (class_ref, "setLogin", "(Lcom/inscripts/jsonphp/Login;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setLogin_Lcom_inscripts_jsonphp_Login_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setLogin", "(Lcom/inscripts/jsonphp/Login;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getSettings;
#pragma warning disable 0169
		static Delegate GetGetSettingsHandler ()
		{
			if (cb_getSettings == null)
				cb_getSettings = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSettings);
			return cb_getSettings;
		}

		static IntPtr n_GetSettings (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Settings);
		}
#pragma warning restore 0169

		static Delegate cb_setSettings_Lcom_inscripts_jsonphp_Settings_;
#pragma warning disable 0169
		static Delegate GetSetSettings_Lcom_inscripts_jsonphp_Settings_Handler ()
		{
			if (cb_setSettings_Lcom_inscripts_jsonphp_Settings_ == null)
				cb_setSettings_Lcom_inscripts_jsonphp_Settings_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetSettings_Lcom_inscripts_jsonphp_Settings_);
			return cb_setSettings_Lcom_inscripts_jsonphp_Settings_;
		}

		static void n_SetSettings_Lcom_inscripts_jsonphp_Settings_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Settings p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Settings = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getSettings;
		static IntPtr id_setSettings_Lcom_inscripts_jsonphp_Settings_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Settings Settings {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getSettings' and count(parameter)=0]"
			[Register ("getSettings", "()Lcom/inscripts/jsonphp/Settings;", "GetGetSettingsHandler")]
			get {
				if (id_getSettings == IntPtr.Zero)
					id_getSettings = JNIEnv.GetMethodID (class_ref, "getSettings", "()Lcom/inscripts/jsonphp/Settings;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSettings), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Settings> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSettings", "()Lcom/inscripts/jsonphp/Settings;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setSettings' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Settings']]"
			[Register ("setSettings", "(Lcom/inscripts/jsonphp/Settings;)V", "GetSetSettings_Lcom_inscripts_jsonphp_Settings_Handler")]
			set {
				if (id_setSettings_Lcom_inscripts_jsonphp_Settings_ == IntPtr.Zero)
					id_setSettings_Lcom_inscripts_jsonphp_Settings_ = JNIEnv.GetMethodID (class_ref, "setSettings", "(Lcom/inscripts/jsonphp/Settings;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSettings_Lcom_inscripts_jsonphp_Settings_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSettings", "(Lcom/inscripts/jsonphp/Settings;)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getVerify;
#pragma warning disable 0169
		static Delegate GetGetVerifyHandler ()
		{
			if (cb_getVerify == null)
				cb_getVerify = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetVerify);
			return cb_getVerify;
		}

		static IntPtr n_GetVerify (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Verify);
		}
#pragma warning restore 0169

		static Delegate cb_setVerify_Lcom_inscripts_jsonphp_Verify_;
#pragma warning disable 0169
		static Delegate GetSetVerify_Lcom_inscripts_jsonphp_Verify_Handler ()
		{
			if (cb_setVerify_Lcom_inscripts_jsonphp_Verify_ == null)
				cb_setVerify_Lcom_inscripts_jsonphp_Verify_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetVerify_Lcom_inscripts_jsonphp_Verify_);
			return cb_setVerify_Lcom_inscripts_jsonphp_Verify_;
		}

		static void n_SetVerify_Lcom_inscripts_jsonphp_Verify_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.NewMobile __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.NewMobile> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Jsonphp.Verify p0 = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Verify = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getVerify;
		static IntPtr id_setVerify_Lcom_inscripts_jsonphp_Verify_;
		public virtual unsafe global::Com.Inscripts.Jsonphp.Verify Verify {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='getVerify' and count(parameter)=0]"
			[Register ("getVerify", "()Lcom/inscripts/jsonphp/Verify;", "GetGetVerifyHandler")]
			get {
				if (id_getVerify == IntPtr.Zero)
					id_getVerify = JNIEnv.GetMethodID (class_ref, "getVerify", "()Lcom/inscripts/jsonphp/Verify;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVerify), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Verify> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getVerify", "()Lcom/inscripts/jsonphp/Verify;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='NewMobile']/method[@name='setVerify' and count(parameter)=1 and parameter[1][@type='com.inscripts.jsonphp.Verify']]"
			[Register ("setVerify", "(Lcom/inscripts/jsonphp/Verify;)V", "GetSetVerify_Lcom_inscripts_jsonphp_Verify_Handler")]
			set {
				if (id_setVerify_Lcom_inscripts_jsonphp_Verify_ == IntPtr.Zero)
					id_setVerify_Lcom_inscripts_jsonphp_Verify_ = JNIEnv.GetMethodID (class_ref, "setVerify", "(Lcom/inscripts/jsonphp/Verify;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVerify_Lcom_inscripts_jsonphp_Verify_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVerify", "(Lcom/inscripts/jsonphp/Verify;)V"), __args);
				} finally {
				}
			}
		}

	}
}
