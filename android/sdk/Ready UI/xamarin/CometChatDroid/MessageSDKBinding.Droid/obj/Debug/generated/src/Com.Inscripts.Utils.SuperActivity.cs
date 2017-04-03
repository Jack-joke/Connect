using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']"
	[global::Android.Runtime.Register ("com/inscripts/utils/SuperActivity", DoNotGenerateAcw=true)]
	public partial class SuperActivity : global::Android.Support.V7.App.ActionBarActivity {


		static IntPtr mobileConfig_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/field[@name='mobileConfig']"
		[Register ("mobileConfig")]
		public global::Com.Inscripts.Jsonphp.MobileConfig MobileConfig {
			get {
				if (mobileConfig_jfieldId == IntPtr.Zero)
					mobileConfig_jfieldId = JNIEnv.GetFieldID (class_ref, "mobileConfig", "Lcom/inscripts/jsonphp/MobileConfig;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, mobileConfig_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileConfig> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (mobileConfig_jfieldId == IntPtr.Zero)
					mobileConfig_jfieldId = JNIEnv.GetFieldID (class_ref, "mobileConfig", "Lcom/inscripts/jsonphp/MobileConfig;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, mobileConfig_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/utils/SuperActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SuperActivity); }
		}

		protected SuperActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/constructor[@name='SuperActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SuperActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SuperActivity)) {
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

		static Delegate cb_setActioBarSubtitle_Ljava_lang_CharSequence_;
#pragma warning disable 0169
		static Delegate GetSetActioBarSubtitle_Ljava_lang_CharSequence_Handler ()
		{
			if (cb_setActioBarSubtitle_Ljava_lang_CharSequence_ == null)
				cb_setActioBarSubtitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetActioBarSubtitle_Ljava_lang_CharSequence_);
			return cb_setActioBarSubtitle_Ljava_lang_CharSequence_;
		}

		static void n_SetActioBarSubtitle_Ljava_lang_CharSequence_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SuperActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SuperActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.ICharSequence p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetActioBarSubtitle (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setActioBarSubtitle_Ljava_lang_CharSequence_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/method[@name='setActioBarSubtitle' and count(parameter)=1 and parameter[1][@type='java.lang.CharSequence']]"
		[Register ("setActioBarSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetActioBarSubtitle_Ljava_lang_CharSequence_Handler")]
		public virtual unsafe void SetActioBarSubtitle (global::Java.Lang.ICharSequence p0)
		{
			if (id_setActioBarSubtitle_Ljava_lang_CharSequence_ == IntPtr.Zero)
				id_setActioBarSubtitle_Ljava_lang_CharSequence_ = JNIEnv.GetMethodID (class_ref, "setActioBarSubtitle", "(Ljava/lang/CharSequence;)V");
			IntPtr native_p0 = CharSequence.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setActioBarSubtitle_Ljava_lang_CharSequence_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setActioBarSubtitle", "(Ljava/lang/CharSequence;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		public void SetActioBarSubtitle (string p0)
		{
			global::Java.Lang.String jls_p0 = p0 == null ? null : new global::Java.Lang.String (p0);
			SetActioBarSubtitle (jls_p0);
			if (jls_p0 != null) jls_p0.Dispose ();
		}

		static Delegate cb_setActionBarColor_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetActionBarColor_Ljava_lang_String_Handler ()
		{
			if (cb_setActionBarColor_Ljava_lang_String_ == null)
				cb_setActionBarColor_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetActionBarColor_Ljava_lang_String_);
			return cb_setActionBarColor_Ljava_lang_String_;
		}

		static void n_SetActionBarColor_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SuperActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SuperActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetActionBarColor (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setActionBarColor_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/method[@name='setActionBarColor' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setActionBarColor", "(Ljava/lang/String;)V", "GetSetActionBarColor_Ljava_lang_String_Handler")]
		public virtual unsafe void SetActionBarColor (string p0)
		{
			if (id_setActionBarColor_Ljava_lang_String_ == IntPtr.Zero)
				id_setActionBarColor_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setActionBarColor", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setActionBarColor_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setActionBarColor", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_setActionBarImage;
#pragma warning disable 0169
		static Delegate GetSetActionBarImageHandler ()
		{
			if (cb_setActionBarImage == null)
				cb_setActionBarImage = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetActionBarImage);
			return cb_setActionBarImage;
		}

		static void n_SetActionBarImage (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Utils.SuperActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SuperActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetActionBarImage ();
		}
#pragma warning restore 0169

		static IntPtr id_setActionBarImage;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/method[@name='setActionBarImage' and count(parameter)=0]"
		[Register ("setActionBarImage", "()V", "GetSetActionBarImageHandler")]
		public virtual unsafe void SetActionBarImage ()
		{
			if (id_setActionBarImage == IntPtr.Zero)
				id_setActionBarImage = JNIEnv.GetMethodID (class_ref, "setActionBarImage", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setActionBarImage);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setActionBarImage", "()V"));
			} finally {
			}
		}

		static Delegate cb_setActionBarTitle_Ljava_lang_CharSequence_;
#pragma warning disable 0169
		static Delegate GetSetActionBarTitle_Ljava_lang_CharSequence_Handler ()
		{
			if (cb_setActionBarTitle_Ljava_lang_CharSequence_ == null)
				cb_setActionBarTitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetActionBarTitle_Ljava_lang_CharSequence_);
			return cb_setActionBarTitle_Ljava_lang_CharSequence_;
		}

		static void n_SetActionBarTitle_Ljava_lang_CharSequence_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Utils.SuperActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Utils.SuperActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.ICharSequence p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetActionBarTitle (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setActionBarTitle_Ljava_lang_CharSequence_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.utils']/class[@name='SuperActivity']/method[@name='setActionBarTitle' and count(parameter)=1 and parameter[1][@type='java.lang.CharSequence']]"
		[Register ("setActionBarTitle", "(Ljava/lang/CharSequence;)V", "GetSetActionBarTitle_Ljava_lang_CharSequence_Handler")]
		public virtual unsafe void SetActionBarTitle (global::Java.Lang.ICharSequence p0)
		{
			if (id_setActionBarTitle_Ljava_lang_CharSequence_ == IntPtr.Zero)
				id_setActionBarTitle_Ljava_lang_CharSequence_ = JNIEnv.GetMethodID (class_ref, "setActionBarTitle", "(Ljava/lang/CharSequence;)V");
			IntPtr native_p0 = CharSequence.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setActionBarTitle_Ljava_lang_CharSequence_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setActionBarTitle", "(Ljava/lang/CharSequence;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		public void SetActionBarTitle (string p0)
		{
			global::Java.Lang.String jls_p0 = p0 == null ? null : new global::Java.Lang.String (p0);
			SetActionBarTitle (jls_p0);
			if (jls_p0 != null) jls_p0.Dispose ();
		}

	}
}
