using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/MobileTheme", DoNotGenerateAcw=true)]
	public partial class MobileTheme : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/MobileTheme", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (MobileTheme); }
		}

		protected MobileTheme (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/constructor[@name='MobileTheme' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe MobileTheme ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (MobileTheme)) {
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

		static Delegate cb_getActionbarColor;
#pragma warning disable 0169
		static Delegate GetGetActionbarColorHandler ()
		{
			if (cb_getActionbarColor == null)
				cb_getActionbarColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetActionbarColor);
			return cb_getActionbarColor;
		}

		static IntPtr n_GetActionbarColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ActionbarColor);
		}
#pragma warning restore 0169

		static IntPtr id_getActionbarColor;
		public virtual unsafe string ActionbarColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getActionbarColor' and count(parameter)=0]"
			[Register ("getActionbarColor", "()Ljava/lang/String;", "GetGetActionbarColorHandler")]
			get {
				if (id_getActionbarColor == IntPtr.Zero)
					id_getActionbarColor = JNIEnv.GetMethodID (class_ref, "getActionbarColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getActionbarColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getActionbarColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getActionbarTextColor;
#pragma warning disable 0169
		static Delegate GetGetActionbarTextColorHandler ()
		{
			if (cb_getActionbarTextColor == null)
				cb_getActionbarTextColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetActionbarTextColor);
			return cb_getActionbarTextColor;
		}

		static IntPtr n_GetActionbarTextColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ActionbarTextColor);
		}
#pragma warning restore 0169

		static IntPtr id_getActionbarTextColor;
		public virtual unsafe string ActionbarTextColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getActionbarTextColor' and count(parameter)=0]"
			[Register ("getActionbarTextColor", "()Ljava/lang/String;", "GetGetActionbarTextColorHandler")]
			get {
				if (id_getActionbarTextColor == IntPtr.Zero)
					id_getActionbarTextColor = JNIEnv.GetMethodID (class_ref, "getActionbarTextColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getActionbarTextColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getActionbarTextColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLeftBubbleColor;
#pragma warning disable 0169
		static Delegate GetGetLeftBubbleColorHandler ()
		{
			if (cb_getLeftBubbleColor == null)
				cb_getLeftBubbleColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLeftBubbleColor);
			return cb_getLeftBubbleColor;
		}

		static IntPtr n_GetLeftBubbleColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LeftBubbleColor);
		}
#pragma warning restore 0169

		static IntPtr id_getLeftBubbleColor;
		public virtual unsafe string LeftBubbleColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLeftBubbleColor' and count(parameter)=0]"
			[Register ("getLeftBubbleColor", "()Ljava/lang/String;", "GetGetLeftBubbleColorHandler")]
			get {
				if (id_getLeftBubbleColor == IntPtr.Zero)
					id_getLeftBubbleColor = JNIEnv.GetMethodID (class_ref, "getLeftBubbleColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLeftBubbleColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLeftBubbleColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLeftBubbleTextColor;
#pragma warning disable 0169
		static Delegate GetGetLeftBubbleTextColorHandler ()
		{
			if (cb_getLeftBubbleTextColor == null)
				cb_getLeftBubbleTextColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLeftBubbleTextColor);
			return cb_getLeftBubbleTextColor;
		}

		static IntPtr n_GetLeftBubbleTextColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LeftBubbleTextColor);
		}
#pragma warning restore 0169

		static IntPtr id_getLeftBubbleTextColor;
		public virtual unsafe string LeftBubbleTextColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLeftBubbleTextColor' and count(parameter)=0]"
			[Register ("getLeftBubbleTextColor", "()Ljava/lang/String;", "GetGetLeftBubbleTextColorHandler")]
			get {
				if (id_getLeftBubbleTextColor == IntPtr.Zero)
					id_getLeftBubbleTextColor = JNIEnv.GetMethodID (class_ref, "getLeftBubbleTextColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLeftBubbleTextColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLeftBubbleTextColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLeftBubbleTimestampColor;
#pragma warning disable 0169
		static Delegate GetGetLeftBubbleTimestampColorHandler ()
		{
			if (cb_getLeftBubbleTimestampColor == null)
				cb_getLeftBubbleTimestampColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLeftBubbleTimestampColor);
			return cb_getLeftBubbleTimestampColor;
		}

		static IntPtr n_GetLeftBubbleTimestampColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LeftBubbleTimestampColor);
		}
#pragma warning restore 0169

		static IntPtr id_getLeftBubbleTimestampColor;
		public virtual unsafe string LeftBubbleTimestampColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLeftBubbleTimestampColor' and count(parameter)=0]"
			[Register ("getLeftBubbleTimestampColor", "()Ljava/lang/String;", "GetGetLeftBubbleTimestampColorHandler")]
			get {
				if (id_getLeftBubbleTimestampColor == IntPtr.Zero)
					id_getLeftBubbleTimestampColor = JNIEnv.GetMethodID (class_ref, "getLeftBubbleTimestampColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLeftBubbleTimestampColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLeftBubbleTimestampColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginBackground;
#pragma warning disable 0169
		static Delegate GetGetLoginBackgroundHandler ()
		{
			if (cb_getLoginBackground == null)
				cb_getLoginBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginBackground);
			return cb_getLoginBackground;
		}

		static IntPtr n_GetLoginBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginBackground;
		public virtual unsafe string LoginBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginBackground' and count(parameter)=0]"
			[Register ("getLoginBackground", "()Ljava/lang/String;", "GetGetLoginBackgroundHandler")]
			get {
				if (id_getLoginBackground == IntPtr.Zero)
					id_getLoginBackground = JNIEnv.GetMethodID (class_ref, "getLoginBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginButton;
#pragma warning disable 0169
		static Delegate GetGetLoginButtonHandler ()
		{
			if (cb_getLoginButton == null)
				cb_getLoginButton = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginButton);
			return cb_getLoginButton;
		}

		static IntPtr n_GetLoginButton (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginButton);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginButton;
		public virtual unsafe string LoginButton {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginButton' and count(parameter)=0]"
			[Register ("getLoginButton", "()Ljava/lang/String;", "GetGetLoginButtonHandler")]
			get {
				if (id_getLoginButton == IntPtr.Zero)
					id_getLoginButton = JNIEnv.GetMethodID (class_ref, "getLoginButton", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginButton), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginButton", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginButtonPressed;
#pragma warning disable 0169
		static Delegate GetGetLoginButtonPressedHandler ()
		{
			if (cb_getLoginButtonPressed == null)
				cb_getLoginButtonPressed = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginButtonPressed);
			return cb_getLoginButtonPressed;
		}

		static IntPtr n_GetLoginButtonPressed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginButtonPressed);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginButtonPressed;
		public virtual unsafe string LoginButtonPressed {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginButtonPressed' and count(parameter)=0]"
			[Register ("getLoginButtonPressed", "()Ljava/lang/String;", "GetGetLoginButtonPressedHandler")]
			get {
				if (id_getLoginButtonPressed == IntPtr.Zero)
					id_getLoginButtonPressed = JNIEnv.GetMethodID (class_ref, "getLoginButtonPressed", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginButtonPressed), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginButtonPressed", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginButtonText;
#pragma warning disable 0169
		static Delegate GetGetLoginButtonTextHandler ()
		{
			if (cb_getLoginButtonText == null)
				cb_getLoginButtonText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginButtonText);
			return cb_getLoginButtonText;
		}

		static IntPtr n_GetLoginButtonText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginButtonText);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginButtonText;
		public virtual unsafe string LoginButtonText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginButtonText' and count(parameter)=0]"
			[Register ("getLoginButtonText", "()Ljava/lang/String;", "GetGetLoginButtonTextHandler")]
			get {
				if (id_getLoginButtonText == IntPtr.Zero)
					id_getLoginButtonText = JNIEnv.GetMethodID (class_ref, "getLoginButtonText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginButtonText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginButtonText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginForeground;
#pragma warning disable 0169
		static Delegate GetGetLoginForegroundHandler ()
		{
			if (cb_getLoginForeground == null)
				cb_getLoginForeground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginForeground);
			return cb_getLoginForeground;
		}

		static IntPtr n_GetLoginForeground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginForeground);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginForeground;
		public virtual unsafe string LoginForeground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginForeground' and count(parameter)=0]"
			[Register ("getLoginForeground", "()Ljava/lang/String;", "GetGetLoginForegroundHandler")]
			get {
				if (id_getLoginForeground == IntPtr.Zero)
					id_getLoginForeground = JNIEnv.GetMethodID (class_ref, "getLoginForeground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginForeground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginForeground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginForegroundText;
#pragma warning disable 0169
		static Delegate GetGetLoginForegroundTextHandler ()
		{
			if (cb_getLoginForegroundText == null)
				cb_getLoginForegroundText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginForegroundText);
			return cb_getLoginForegroundText;
		}

		static IntPtr n_GetLoginForegroundText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginForegroundText);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginForegroundText;
		public virtual unsafe string LoginForegroundText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginForegroundText' and count(parameter)=0]"
			[Register ("getLoginForegroundText", "()Ljava/lang/String;", "GetGetLoginForegroundTextHandler")]
			get {
				if (id_getLoginForegroundText == IntPtr.Zero)
					id_getLoginForegroundText = JNIEnv.GetMethodID (class_ref, "getLoginForegroundText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginForegroundText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginForegroundText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginPlaceholder;
#pragma warning disable 0169
		static Delegate GetGetLoginPlaceholderHandler ()
		{
			if (cb_getLoginPlaceholder == null)
				cb_getLoginPlaceholder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginPlaceholder);
			return cb_getLoginPlaceholder;
		}

		static IntPtr n_GetLoginPlaceholder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginPlaceholder);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginPlaceholder;
		public virtual unsafe string LoginPlaceholder {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginPlaceholder' and count(parameter)=0]"
			[Register ("getLoginPlaceholder", "()Ljava/lang/String;", "GetGetLoginPlaceholderHandler")]
			get {
				if (id_getLoginPlaceholder == IntPtr.Zero)
					id_getLoginPlaceholder = JNIEnv.GetMethodID (class_ref, "getLoginPlaceholder", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginPlaceholder), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginPlaceholder", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginText;
#pragma warning disable 0169
		static Delegate GetGetLoginTextHandler ()
		{
			if (cb_getLoginText == null)
				cb_getLoginText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginText);
			return cb_getLoginText;
		}

		static IntPtr n_GetLoginText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginText);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginText;
		public virtual unsafe string LoginText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginText' and count(parameter)=0]"
			[Register ("getLoginText", "()Ljava/lang/String;", "GetGetLoginTextHandler")]
			get {
				if (id_getLoginText == IntPtr.Zero)
					id_getLoginText = JNIEnv.GetMethodID (class_ref, "getLoginText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getLoginTextHint;
#pragma warning disable 0169
		static Delegate GetGetLoginTextHintHandler ()
		{
			if (cb_getLoginTextHint == null)
				cb_getLoginTextHint = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetLoginTextHint);
			return cb_getLoginTextHint;
		}

		static IntPtr n_GetLoginTextHint (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.LoginTextHint);
		}
#pragma warning restore 0169

		static IntPtr id_getLoginTextHint;
		public virtual unsafe string LoginTextHint {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getLoginTextHint' and count(parameter)=0]"
			[Register ("getLoginTextHint", "()Ljava/lang/String;", "GetGetLoginTextHintHandler")]
			get {
				if (id_getLoginTextHint == IntPtr.Zero)
					id_getLoginTextHint = JNIEnv.GetMethodID (class_ref, "getLoginTextHint", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getLoginTextHint), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getLoginTextHint", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPrimarkDaryColor;
#pragma warning disable 0169
		static Delegate GetGetPrimarkDaryColorHandler ()
		{
			if (cb_getPrimarkDaryColor == null)
				cb_getPrimarkDaryColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPrimarkDaryColor);
			return cb_getPrimarkDaryColor;
		}

		static IntPtr n_GetPrimarkDaryColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PrimarkDaryColor);
		}
#pragma warning restore 0169

		static IntPtr id_getPrimarkDaryColor;
		public virtual unsafe string PrimarkDaryColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getPrimarkDaryColor' and count(parameter)=0]"
			[Register ("getPrimarkDaryColor", "()Ljava/lang/String;", "GetGetPrimarkDaryColorHandler")]
			get {
				if (id_getPrimarkDaryColor == IntPtr.Zero)
					id_getPrimarkDaryColor = JNIEnv.GetMethodID (class_ref, "getPrimarkDaryColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPrimarkDaryColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPrimarkDaryColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getPrimaryColor;
#pragma warning disable 0169
		static Delegate GetGetPrimaryColorHandler ()
		{
			if (cb_getPrimaryColor == null)
				cb_getPrimaryColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPrimaryColor);
			return cb_getPrimaryColor;
		}

		static IntPtr n_GetPrimaryColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.PrimaryColor);
		}
#pragma warning restore 0169

		static IntPtr id_getPrimaryColor;
		public virtual unsafe string PrimaryColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getPrimaryColor' and count(parameter)=0]"
			[Register ("getPrimaryColor", "()Ljava/lang/String;", "GetGetPrimaryColorHandler")]
			get {
				if (id_getPrimaryColor == IntPtr.Zero)
					id_getPrimaryColor = JNIEnv.GetMethodID (class_ref, "getPrimaryColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPrimaryColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPrimaryColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRightBubbleColor;
#pragma warning disable 0169
		static Delegate GetGetRightBubbleColorHandler ()
		{
			if (cb_getRightBubbleColor == null)
				cb_getRightBubbleColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRightBubbleColor);
			return cb_getRightBubbleColor;
		}

		static IntPtr n_GetRightBubbleColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RightBubbleColor);
		}
#pragma warning restore 0169

		static IntPtr id_getRightBubbleColor;
		public virtual unsafe string RightBubbleColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getRightBubbleColor' and count(parameter)=0]"
			[Register ("getRightBubbleColor", "()Ljava/lang/String;", "GetGetRightBubbleColorHandler")]
			get {
				if (id_getRightBubbleColor == IntPtr.Zero)
					id_getRightBubbleColor = JNIEnv.GetMethodID (class_ref, "getRightBubbleColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRightBubbleColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRightBubbleColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRightBubbleTextColor;
#pragma warning disable 0169
		static Delegate GetGetRightBubbleTextColorHandler ()
		{
			if (cb_getRightBubbleTextColor == null)
				cb_getRightBubbleTextColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRightBubbleTextColor);
			return cb_getRightBubbleTextColor;
		}

		static IntPtr n_GetRightBubbleTextColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RightBubbleTextColor);
		}
#pragma warning restore 0169

		static IntPtr id_getRightBubbleTextColor;
		public virtual unsafe string RightBubbleTextColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getRightBubbleTextColor' and count(parameter)=0]"
			[Register ("getRightBubbleTextColor", "()Ljava/lang/String;", "GetGetRightBubbleTextColorHandler")]
			get {
				if (id_getRightBubbleTextColor == IntPtr.Zero)
					id_getRightBubbleTextColor = JNIEnv.GetMethodID (class_ref, "getRightBubbleTextColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRightBubbleTextColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRightBubbleTextColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getRightBubbleTimestampColor;
#pragma warning disable 0169
		static Delegate GetGetRightBubbleTimestampColorHandler ()
		{
			if (cb_getRightBubbleTimestampColor == null)
				cb_getRightBubbleTimestampColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetRightBubbleTimestampColor);
			return cb_getRightBubbleTimestampColor;
		}

		static IntPtr n_GetRightBubbleTimestampColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RightBubbleTimestampColor);
		}
#pragma warning restore 0169

		static IntPtr id_getRightBubbleTimestampColor;
		public virtual unsafe string RightBubbleTimestampColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getRightBubbleTimestampColor' and count(parameter)=0]"
			[Register ("getRightBubbleTimestampColor", "()Ljava/lang/String;", "GetGetRightBubbleTimestampColorHandler")]
			get {
				if (id_getRightBubbleTimestampColor == IntPtr.Zero)
					id_getRightBubbleTimestampColor = JNIEnv.GetMethodID (class_ref, "getRightBubbleTimestampColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRightBubbleTimestampColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getRightBubbleTimestampColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabHighlightColor;
#pragma warning disable 0169
		static Delegate GetGetTabHighlightColorHandler ()
		{
			if (cb_getTabHighlightColor == null)
				cb_getTabHighlightColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabHighlightColor);
			return cb_getTabHighlightColor;
		}

		static IntPtr n_GetTabHighlightColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.MobileTheme __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.MobileTheme> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabHighlightColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTabHighlightColor;
		public virtual unsafe string TabHighlightColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='MobileTheme']/method[@name='getTabHighlightColor' and count(parameter)=0]"
			[Register ("getTabHighlightColor", "()Ljava/lang/String;", "GetGetTabHighlightColorHandler")]
			get {
				if (id_getTabHighlightColor == IntPtr.Zero)
					id_getTabHighlightColor = JNIEnv.GetMethodID (class_ref, "getTabHighlightColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabHighlightColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabHighlightColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
