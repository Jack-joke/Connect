using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Css", DoNotGenerateAcw=true)]
	public partial class Css : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Css", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Css); }
		}

		protected Css (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/constructor[@name='Css' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Css ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Css)) {
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

		static Delegate cb_getBarBackground;
#pragma warning disable 0169
		static Delegate GetGetBarBackgroundHandler ()
		{
			if (cb_getBarBackground == null)
				cb_getBarBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarBackground);
			return cb_getBarBackground;
		}

		static IntPtr n_GetBarBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getBarBackground;
		public virtual unsafe string BarBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarBackground' and count(parameter)=0]"
			[Register ("getBarBackground", "()Ljava/lang/String;", "GetGetBarBackgroundHandler")]
			get {
				if (id_getBarBackground == IntPtr.Zero)
					id_getBarBackground = JNIEnv.GetMethodID (class_ref, "getBarBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarBorder;
#pragma warning disable 0169
		static Delegate GetGetBarBorderHandler ()
		{
			if (cb_getBarBorder == null)
				cb_getBarBorder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarBorder);
			return cb_getBarBorder;
		}

		static IntPtr n_GetBarBorder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarBorder);
		}
#pragma warning restore 0169

		static IntPtr id_getBarBorder;
		public virtual unsafe string BarBorder {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarBorder' and count(parameter)=0]"
			[Register ("getBarBorder", "()Ljava/lang/String;", "GetGetBarBorderHandler")]
			get {
				if (id_getBarBorder == IntPtr.Zero)
					id_getBarBorder = JNIEnv.GetMethodID (class_ref, "getBarBorder", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarBorder), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarBorder", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarBorderLight;
#pragma warning disable 0169
		static Delegate GetGetBarBorderLightHandler ()
		{
			if (cb_getBarBorderLight == null)
				cb_getBarBorderLight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarBorderLight);
			return cb_getBarBorderLight;
		}

		static IntPtr n_GetBarBorderLight (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarBorderLight);
		}
#pragma warning restore 0169

		static IntPtr id_getBarBorderLight;
		public virtual unsafe string BarBorderLight {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarBorderLight' and count(parameter)=0]"
			[Register ("getBarBorderLight", "()Ljava/lang/String;", "GetGetBarBorderLightHandler")]
			get {
				if (id_getBarBorderLight == IntPtr.Zero)
					id_getBarBorderLight = JNIEnv.GetMethodID (class_ref, "getBarBorderLight", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarBorderLight), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarBorderLight", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarColor;
#pragma warning disable 0169
		static Delegate GetGetBarColorHandler ()
		{
			if (cb_getBarColor == null)
				cb_getBarColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarColor);
			return cb_getBarColor;
		}

		static IntPtr n_GetBarColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarColor);
		}
#pragma warning restore 0169

		static Delegate cb_setBarColor_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetBarColor_Ljava_lang_String_Handler ()
		{
			if (cb_setBarColor_Ljava_lang_String_ == null)
				cb_setBarColor_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetBarColor_Ljava_lang_String_);
			return cb_setBarColor_Ljava_lang_String_;
		}

		static void n_SetBarColor_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BarColor = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBarColor;
		static IntPtr id_setBarColor_Ljava_lang_String_;
		public virtual unsafe string BarColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarColor' and count(parameter)=0]"
			[Register ("getBarColor", "()Ljava/lang/String;", "GetGetBarColorHandler")]
			get {
				if (id_getBarColor == IntPtr.Zero)
					id_getBarColor = JNIEnv.GetMethodID (class_ref, "getBarColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='setBarColor' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setBarColor", "(Ljava/lang/String;)V", "GetSetBarColor_Ljava_lang_String_Handler")]
			set {
				if (id_setBarColor_Ljava_lang_String_ == IntPtr.Zero)
					id_setBarColor_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setBarColor", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBarColor_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBarColor", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getBarColorDisabled;
#pragma warning disable 0169
		static Delegate GetGetBarColorDisabledHandler ()
		{
			if (cb_getBarColorDisabled == null)
				cb_getBarColorDisabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarColorDisabled);
			return cb_getBarColorDisabled;
		}

		static IntPtr n_GetBarColorDisabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarColorDisabled);
		}
#pragma warning restore 0169

		static IntPtr id_getBarColorDisabled;
		public virtual unsafe string BarColorDisabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarColorDisabled' and count(parameter)=0]"
			[Register ("getBarColorDisabled", "()Ljava/lang/String;", "GetGetBarColorDisabledHandler")]
			get {
				if (id_getBarColorDisabled == IntPtr.Zero)
					id_getBarColorDisabled = JNIEnv.GetMethodID (class_ref, "getBarColorDisabled", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarColorDisabled), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarColorDisabled", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarFontFamily;
#pragma warning disable 0169
		static Delegate GetGetBarFontFamilyHandler ()
		{
			if (cb_getBarFontFamily == null)
				cb_getBarFontFamily = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarFontFamily);
			return cb_getBarFontFamily;
		}

		static IntPtr n_GetBarFontFamily (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarFontFamily);
		}
#pragma warning restore 0169

		static IntPtr id_getBarFontFamily;
		public virtual unsafe string BarFontFamily {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarFontFamily' and count(parameter)=0]"
			[Register ("getBarFontFamily", "()Ljava/lang/String;", "GetGetBarFontFamilyHandler")]
			get {
				if (id_getBarFontFamily == IntPtr.Zero)
					id_getBarFontFamily = JNIEnv.GetMethodID (class_ref, "getBarFontFamily", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarFontFamily), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarFontFamily", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarFontSize;
#pragma warning disable 0169
		static Delegate GetGetBarFontSizeHandler ()
		{
			if (cb_getBarFontSize == null)
				cb_getBarFontSize = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarFontSize);
			return cb_getBarFontSize;
		}

		static IntPtr n_GetBarFontSize (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarFontSize);
		}
#pragma warning restore 0169

		static IntPtr id_getBarFontSize;
		public virtual unsafe string BarFontSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarFontSize' and count(parameter)=0]"
			[Register ("getBarFontSize", "()Ljava/lang/String;", "GetGetBarFontSizeHandler")]
			get {
				if (id_getBarFontSize == IntPtr.Zero)
					id_getBarFontSize = JNIEnv.GetMethodID (class_ref, "getBarFontSize", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarFontSize), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarFontSize", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarGradientEnd;
#pragma warning disable 0169
		static Delegate GetGetBarGradientEndHandler ()
		{
			if (cb_getBarGradientEnd == null)
				cb_getBarGradientEnd = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarGradientEnd);
			return cb_getBarGradientEnd;
		}

		static IntPtr n_GetBarGradientEnd (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarGradientEnd);
		}
#pragma warning restore 0169

		static IntPtr id_getBarGradientEnd;
		public virtual unsafe string BarGradientEnd {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarGradientEnd' and count(parameter)=0]"
			[Register ("getBarGradientEnd", "()Ljava/lang/String;", "GetGetBarGradientEndHandler")]
			get {
				if (id_getBarGradientEnd == IntPtr.Zero)
					id_getBarGradientEnd = JNIEnv.GetMethodID (class_ref, "getBarGradientEnd", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarGradientEnd), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarGradientEnd", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarGradientStart;
#pragma warning disable 0169
		static Delegate GetGetBarGradientStartHandler ()
		{
			if (cb_getBarGradientStart == null)
				cb_getBarGradientStart = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarGradientStart);
			return cb_getBarGradientStart;
		}

		static IntPtr n_GetBarGradientStart (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarGradientStart);
		}
#pragma warning restore 0169

		static IntPtr id_getBarGradientStart;
		public virtual unsafe string BarGradientStart {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarGradientStart' and count(parameter)=0]"
			[Register ("getBarGradientStart", "()Ljava/lang/String;", "GetGetBarGradientStartHandler")]
			get {
				if (id_getBarGradientStart == IntPtr.Zero)
					id_getBarGradientStart = JNIEnv.GetMethodID (class_ref, "getBarGradientStart", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarGradientStart), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarGradientStart", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getBarTextBackground;
#pragma warning disable 0169
		static Delegate GetGetBarTextBackgroundHandler ()
		{
			if (cb_getBarTextBackground == null)
				cb_getBarTextBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBarTextBackground);
			return cb_getBarTextBackground;
		}

		static IntPtr n_GetBarTextBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.BarTextBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getBarTextBackground;
		public virtual unsafe string BarTextBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getBarTextBackground' and count(parameter)=0]"
			[Register ("getBarTextBackground", "()Ljava/lang/String;", "GetGetBarTextBackgroundHandler")]
			get {
				if (id_getBarTextBackground == IntPtr.Zero)
					id_getBarTextBackground = JNIEnv.GetMethodID (class_ref, "getBarTextBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBarTextBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBarTextBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabBackground;
#pragma warning disable 0169
		static Delegate GetGetTabBackgroundHandler ()
		{
			if (cb_getTabBackground == null)
				cb_getTabBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabBackground);
			return cb_getTabBackground;
		}

		static IntPtr n_GetTabBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getTabBackground;
		public virtual unsafe string TabBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabBackground' and count(parameter)=0]"
			[Register ("getTabBackground", "()Ljava/lang/String;", "GetGetTabBackgroundHandler")]
			get {
				if (id_getTabBackground == IntPtr.Zero)
					id_getTabBackground = JNIEnv.GetMethodID (class_ref, "getTabBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabBorder;
#pragma warning disable 0169
		static Delegate GetGetTabBorderHandler ()
		{
			if (cb_getTabBorder == null)
				cb_getTabBorder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabBorder);
			return cb_getTabBorder;
		}

		static IntPtr n_GetTabBorder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabBorder);
		}
#pragma warning restore 0169

		static IntPtr id_getTabBorder;
		public virtual unsafe string TabBorder {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabBorder' and count(parameter)=0]"
			[Register ("getTabBorder", "()Ljava/lang/String;", "GetGetTabBorderHandler")]
			get {
				if (id_getTabBorder == IntPtr.Zero)
					id_getTabBorder = JNIEnv.GetMethodID (class_ref, "getTabBorder", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabBorder), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabBorder", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabBorderLight;
#pragma warning disable 0169
		static Delegate GetGetTabBorderLightHandler ()
		{
			if (cb_getTabBorderLight == null)
				cb_getTabBorderLight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabBorderLight);
			return cb_getTabBorderLight;
		}

		static IntPtr n_GetTabBorderLight (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabBorderLight);
		}
#pragma warning restore 0169

		static IntPtr id_getTabBorderLight;
		public virtual unsafe string TabBorderLight {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabBorderLight' and count(parameter)=0]"
			[Register ("getTabBorderLight", "()Ljava/lang/String;", "GetGetTabBorderLightHandler")]
			get {
				if (id_getTabBorderLight == IntPtr.Zero)
					id_getTabBorderLight = JNIEnv.GetMethodID (class_ref, "getTabBorderLight", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabBorderLight), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabBorderLight", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabBorderLighter;
#pragma warning disable 0169
		static Delegate GetGetTabBorderLighterHandler ()
		{
			if (cb_getTabBorderLighter == null)
				cb_getTabBorderLighter = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabBorderLighter);
			return cb_getTabBorderLighter;
		}

		static IntPtr n_GetTabBorderLighter (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabBorderLighter);
		}
#pragma warning restore 0169

		static IntPtr id_getTabBorderLighter;
		public virtual unsafe string TabBorderLighter {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabBorderLighter' and count(parameter)=0]"
			[Register ("getTabBorderLighter", "()Ljava/lang/String;", "GetGetTabBorderLighterHandler")]
			get {
				if (id_getTabBorderLighter == IntPtr.Zero)
					id_getTabBorderLighter = JNIEnv.GetMethodID (class_ref, "getTabBorderLighter", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabBorderLighter), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabBorderLighter", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabColor;
#pragma warning disable 0169
		static Delegate GetGetTabColorHandler ()
		{
			if (cb_getTabColor == null)
				cb_getTabColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabColor);
			return cb_getTabColor;
		}

		static IntPtr n_GetTabColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTabColor;
		public virtual unsafe string TabColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabColor' and count(parameter)=0]"
			[Register ("getTabColor", "()Ljava/lang/String;", "GetGetTabColorHandler")]
			get {
				if (id_getTabColor == IntPtr.Zero)
					id_getTabColor = JNIEnv.GetMethodID (class_ref, "getTabColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabColorSelf;
#pragma warning disable 0169
		static Delegate GetGetTabColorSelfHandler ()
		{
			if (cb_getTabColorSelf == null)
				cb_getTabColorSelf = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabColorSelf);
			return cb_getTabColorSelf;
		}

		static IntPtr n_GetTabColorSelf (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabColorSelf);
		}
#pragma warning restore 0169

		static IntPtr id_getTabColorSelf;
		public virtual unsafe string TabColorSelf {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabColorSelf' and count(parameter)=0]"
			[Register ("getTabColorSelf", "()Ljava/lang/String;", "GetGetTabColorSelfHandler")]
			get {
				if (id_getTabColorSelf == IntPtr.Zero)
					id_getTabColorSelf = JNIEnv.GetMethodID (class_ref, "getTabColorSelf", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabColorSelf), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabColorSelf", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabFontFamily;
#pragma warning disable 0169
		static Delegate GetGetTabFontFamilyHandler ()
		{
			if (cb_getTabFontFamily == null)
				cb_getTabFontFamily = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabFontFamily);
			return cb_getTabFontFamily;
		}

		static IntPtr n_GetTabFontFamily (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabFontFamily);
		}
#pragma warning restore 0169

		static IntPtr id_getTabFontFamily;
		public virtual unsafe string TabFontFamily {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabFontFamily' and count(parameter)=0]"
			[Register ("getTabFontFamily", "()Ljava/lang/String;", "GetGetTabFontFamilyHandler")]
			get {
				if (id_getTabFontFamily == IntPtr.Zero)
					id_getTabFontFamily = JNIEnv.GetMethodID (class_ref, "getTabFontFamily", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabFontFamily), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabFontFamily", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabFontSize;
#pragma warning disable 0169
		static Delegate GetGetTabFontSizeHandler ()
		{
			if (cb_getTabFontSize == null)
				cb_getTabFontSize = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabFontSize);
			return cb_getTabFontSize;
		}

		static IntPtr n_GetTabFontSize (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabFontSize);
		}
#pragma warning restore 0169

		static IntPtr id_getTabFontSize;
		public virtual unsafe string TabFontSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabFontSize' and count(parameter)=0]"
			[Register ("getTabFontSize", "()Ljava/lang/String;", "GetGetTabFontSizeHandler")]
			get {
				if (id_getTabFontSize == IntPtr.Zero)
					id_getTabFontSize = JNIEnv.GetMethodID (class_ref, "getTabFontSize", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabFontSize), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabFontSize", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabFontSizeSmall;
#pragma warning disable 0169
		static Delegate GetGetTabFontSizeSmallHandler ()
		{
			if (cb_getTabFontSizeSmall == null)
				cb_getTabFontSizeSmall = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabFontSizeSmall);
			return cb_getTabFontSizeSmall;
		}

		static IntPtr n_GetTabFontSizeSmall (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabFontSizeSmall);
		}
#pragma warning restore 0169

		static IntPtr id_getTabFontSizeSmall;
		public virtual unsafe string TabFontSizeSmall {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabFontSizeSmall' and count(parameter)=0]"
			[Register ("getTabFontSizeSmall", "()Ljava/lang/String;", "GetGetTabFontSizeSmallHandler")]
			get {
				if (id_getTabFontSizeSmall == IntPtr.Zero)
					id_getTabFontSizeSmall = JNIEnv.GetMethodID (class_ref, "getTabFontSizeSmall", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabFontSizeSmall), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabFontSizeSmall", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabLinkColor;
#pragma warning disable 0169
		static Delegate GetGetTabLinkColorHandler ()
		{
			if (cb_getTabLinkColor == null)
				cb_getTabLinkColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabLinkColor);
			return cb_getTabLinkColor;
		}

		static IntPtr n_GetTabLinkColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabLinkColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTabLinkColor;
		public virtual unsafe string TabLinkColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabLinkColor' and count(parameter)=0]"
			[Register ("getTabLinkColor", "()Ljava/lang/String;", "GetGetTabLinkColorHandler")]
			get {
				if (id_getTabLinkColor == IntPtr.Zero)
					id_getTabLinkColor = JNIEnv.GetMethodID (class_ref, "getTabLinkColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabLinkColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabLinkColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabSubBackground;
#pragma warning disable 0169
		static Delegate GetGetTabSubBackgroundHandler ()
		{
			if (cb_getTabSubBackground == null)
				cb_getTabSubBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabSubBackground);
			return cb_getTabSubBackground;
		}

		static IntPtr n_GetTabSubBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabSubBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getTabSubBackground;
		public virtual unsafe string TabSubBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabSubBackground' and count(parameter)=0]"
			[Register ("getTabSubBackground", "()Ljava/lang/String;", "GetGetTabSubBackgroundHandler")]
			get {
				if (id_getTabSubBackground == IntPtr.Zero)
					id_getTabSubBackground = JNIEnv.GetMethodID (class_ref, "getTabSubBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabSubBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabSubBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabSubColor;
#pragma warning disable 0169
		static Delegate GetGetTabSubColorHandler ()
		{
			if (cb_getTabSubColor == null)
				cb_getTabSubColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabSubColor);
			return cb_getTabSubColor;
		}

		static IntPtr n_GetTabSubColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabSubColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTabSubColor;
		public virtual unsafe string TabSubColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabSubColor' and count(parameter)=0]"
			[Register ("getTabSubColor", "()Ljava/lang/String;", "GetGetTabSubColorHandler")]
			get {
				if (id_getTabSubColor == IntPtr.Zero)
					id_getTabSubColor = JNIEnv.GetMethodID (class_ref, "getTabSubColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabSubColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabSubColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleBackgroudLight;
#pragma warning disable 0169
		static Delegate GetGetTabTitleBackgroudLightHandler ()
		{
			if (cb_getTabTitleBackgroudLight == null)
				cb_getTabTitleBackgroudLight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleBackgroudLight);
			return cb_getTabTitleBackgroudLight;
		}

		static IntPtr n_GetTabTitleBackgroudLight (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleBackgroudLight);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleBackgroudLight;
		public virtual unsafe string TabTitleBackgroudLight {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleBackgroudLight' and count(parameter)=0]"
			[Register ("getTabTitleBackgroudLight", "()Ljava/lang/String;", "GetGetTabTitleBackgroudLightHandler")]
			get {
				if (id_getTabTitleBackgroudLight == IntPtr.Zero)
					id_getTabTitleBackgroudLight = JNIEnv.GetMethodID (class_ref, "getTabTitleBackgroudLight", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleBackgroudLight), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleBackgroudLight", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleBackground;
#pragma warning disable 0169
		static Delegate GetGetTabTitleBackgroundHandler ()
		{
			if (cb_getTabTitleBackground == null)
				cb_getTabTitleBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleBackground);
			return cb_getTabTitleBackground;
		}

		static IntPtr n_GetTabTitleBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleBackground;
		public virtual unsafe string TabTitleBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleBackground' and count(parameter)=0]"
			[Register ("getTabTitleBackground", "()Ljava/lang/String;", "GetGetTabTitleBackgroundHandler")]
			get {
				if (id_getTabTitleBackground == IntPtr.Zero)
					id_getTabTitleBackground = JNIEnv.GetMethodID (class_ref, "getTabTitleBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleBorder;
#pragma warning disable 0169
		static Delegate GetGetTabTitleBorderHandler ()
		{
			if (cb_getTabTitleBorder == null)
				cb_getTabTitleBorder = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleBorder);
			return cb_getTabTitleBorder;
		}

		static IntPtr n_GetTabTitleBorder (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleBorder);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleBorder;
		public virtual unsafe string TabTitleBorder {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleBorder' and count(parameter)=0]"
			[Register ("getTabTitleBorder", "()Ljava/lang/String;", "GetGetTabTitleBorderHandler")]
			get {
				if (id_getTabTitleBorder == IntPtr.Zero)
					id_getTabTitleBorder = JNIEnv.GetMethodID (class_ref, "getTabTitleBorder", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleBorder), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleBorder", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleColor;
#pragma warning disable 0169
		static Delegate GetGetTabTitleColorHandler ()
		{
			if (cb_getTabTitleColor == null)
				cb_getTabTitleColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleColor);
			return cb_getTabTitleColor;
		}

		static IntPtr n_GetTabTitleColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleColor;
		public virtual unsafe string TabTitleColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleColor' and count(parameter)=0]"
			[Register ("getTabTitleColor", "()Ljava/lang/String;", "GetGetTabTitleColorHandler")]
			get {
				if (id_getTabTitleColor == IntPtr.Zero)
					id_getTabTitleColor = JNIEnv.GetMethodID (class_ref, "getTabTitleColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleFontFamily;
#pragma warning disable 0169
		static Delegate GetGetTabTitleFontFamilyHandler ()
		{
			if (cb_getTabTitleFontFamily == null)
				cb_getTabTitleFontFamily = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleFontFamily);
			return cb_getTabTitleFontFamily;
		}

		static IntPtr n_GetTabTitleFontFamily (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleFontFamily);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleFontFamily;
		public virtual unsafe string TabTitleFontFamily {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleFontFamily' and count(parameter)=0]"
			[Register ("getTabTitleFontFamily", "()Ljava/lang/String;", "GetGetTabTitleFontFamilyHandler")]
			get {
				if (id_getTabTitleFontFamily == IntPtr.Zero)
					id_getTabTitleFontFamily = JNIEnv.GetMethodID (class_ref, "getTabTitleFontFamily", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleFontFamily), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleFontFamily", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleFontSize;
#pragma warning disable 0169
		static Delegate GetGetTabTitleFontSizeHandler ()
		{
			if (cb_getTabTitleFontSize == null)
				cb_getTabTitleFontSize = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleFontSize);
			return cb_getTabTitleFontSize;
		}

		static IntPtr n_GetTabTitleFontSize (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleFontSize);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleFontSize;
		public virtual unsafe string TabTitleFontSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleFontSize' and count(parameter)=0]"
			[Register ("getTabTitleFontSize", "()Ljava/lang/String;", "GetGetTabTitleFontSizeHandler")]
			get {
				if (id_getTabTitleFontSize == IntPtr.Zero)
					id_getTabTitleFontSize = JNIEnv.GetMethodID (class_ref, "getTabTitleFontSize", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleFontSize), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleFontSize", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleFontSizeLarge;
#pragma warning disable 0169
		static Delegate GetGetTabTitleFontSizeLargeHandler ()
		{
			if (cb_getTabTitleFontSizeLarge == null)
				cb_getTabTitleFontSizeLarge = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleFontSizeLarge);
			return cb_getTabTitleFontSizeLarge;
		}

		static IntPtr n_GetTabTitleFontSizeLarge (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleFontSizeLarge);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleFontSizeLarge;
		public virtual unsafe string TabTitleFontSizeLarge {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleFontSizeLarge' and count(parameter)=0]"
			[Register ("getTabTitleFontSizeLarge", "()Ljava/lang/String;", "GetGetTabTitleFontSizeLargeHandler")]
			get {
				if (id_getTabTitleFontSizeLarge == IntPtr.Zero)
					id_getTabTitleFontSizeLarge = JNIEnv.GetMethodID (class_ref, "getTabTitleFontSizeLarge", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleFontSizeLarge), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleFontSizeLarge", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleGradientEnd;
#pragma warning disable 0169
		static Delegate GetGetTabTitleGradientEndHandler ()
		{
			if (cb_getTabTitleGradientEnd == null)
				cb_getTabTitleGradientEnd = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleGradientEnd);
			return cb_getTabTitleGradientEnd;
		}

		static IntPtr n_GetTabTitleGradientEnd (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleGradientEnd);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleGradientEnd;
		public virtual unsafe string TabTitleGradientEnd {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleGradientEnd' and count(parameter)=0]"
			[Register ("getTabTitleGradientEnd", "()Ljava/lang/String;", "GetGetTabTitleGradientEndHandler")]
			get {
				if (id_getTabTitleGradientEnd == IntPtr.Zero)
					id_getTabTitleGradientEnd = JNIEnv.GetMethodID (class_ref, "getTabTitleGradientEnd", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleGradientEnd), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleGradientEnd", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleGradientStart;
#pragma warning disable 0169
		static Delegate GetGetTabTitleGradientStartHandler ()
		{
			if (cb_getTabTitleGradientStart == null)
				cb_getTabTitleGradientStart = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleGradientStart);
			return cb_getTabTitleGradientStart;
		}

		static IntPtr n_GetTabTitleGradientStart (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleGradientStart);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleGradientStart;
		public virtual unsafe string TabTitleGradientStart {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleGradientStart' and count(parameter)=0]"
			[Register ("getTabTitleGradientStart", "()Ljava/lang/String;", "GetGetTabTitleGradientStartHandler")]
			get {
				if (id_getTabTitleGradientStart == IntPtr.Zero)
					id_getTabTitleGradientStart = JNIEnv.GetMethodID (class_ref, "getTabTitleGradientStart", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleGradientStart), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleGradientStart", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabTitleTextBackground;
#pragma warning disable 0169
		static Delegate GetGetTabTitleTextBackgroundHandler ()
		{
			if (cb_getTabTitleTextBackground == null)
				cb_getTabTitleTextBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabTitleTextBackground);
			return cb_getTabTitleTextBackground;
		}

		static IntPtr n_GetTabTitleTextBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabTitleTextBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getTabTitleTextBackground;
		public virtual unsafe string TabTitleTextBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTabTitleTextBackground' and count(parameter)=0]"
			[Register ("getTabTitleTextBackground", "()Ljava/lang/String;", "GetGetTabTitleTextBackgroundHandler")]
			get {
				if (id_getTabTitleTextBackground == IntPtr.Zero)
					id_getTabTitleTextBackground = JNIEnv.GetMethodID (class_ref, "getTabTitleTextBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabTitleTextBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabTitleTextBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipBackground;
#pragma warning disable 0169
		static Delegate GetGetTooltipBackgroundHandler ()
		{
			if (cb_getTooltipBackground == null)
				cb_getTooltipBackground = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipBackground);
			return cb_getTooltipBackground;
		}

		static IntPtr n_GetTooltipBackground (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipBackground);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipBackground;
		public virtual unsafe string TooltipBackground {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipBackground' and count(parameter)=0]"
			[Register ("getTooltipBackground", "()Ljava/lang/String;", "GetGetTooltipBackgroundHandler")]
			get {
				if (id_getTooltipBackground == IntPtr.Zero)
					id_getTooltipBackground = JNIEnv.GetMethodID (class_ref, "getTooltipBackground", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipBackground), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipBackground", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipBreak;
#pragma warning disable 0169
		static Delegate GetGetTooltipBreakHandler ()
		{
			if (cb_getTooltipBreak == null)
				cb_getTooltipBreak = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipBreak);
			return cb_getTooltipBreak;
		}

		static IntPtr n_GetTooltipBreak (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipBreak);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipBreak;
		public virtual unsafe string TooltipBreak {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipBreak' and count(parameter)=0]"
			[Register ("getTooltipBreak", "()Ljava/lang/String;", "GetGetTooltipBreakHandler")]
			get {
				if (id_getTooltipBreak == IntPtr.Zero)
					id_getTooltipBreak = JNIEnv.GetMethodID (class_ref, "getTooltipBreak", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipBreak), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipBreak", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipColor;
#pragma warning disable 0169
		static Delegate GetGetTooltipColorHandler ()
		{
			if (cb_getTooltipColor == null)
				cb_getTooltipColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipColor);
			return cb_getTooltipColor;
		}

		static IntPtr n_GetTooltipColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipColor);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipColor;
		public virtual unsafe string TooltipColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipColor' and count(parameter)=0]"
			[Register ("getTooltipColor", "()Ljava/lang/String;", "GetGetTooltipColorHandler")]
			get {
				if (id_getTooltipColor == IntPtr.Zero)
					id_getTooltipColor = JNIEnv.GetMethodID (class_ref, "getTooltipColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipColorLight;
#pragma warning disable 0169
		static Delegate GetGetTooltipColorLightHandler ()
		{
			if (cb_getTooltipColorLight == null)
				cb_getTooltipColorLight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipColorLight);
			return cb_getTooltipColorLight;
		}

		static IntPtr n_GetTooltipColorLight (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipColorLight);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipColorLight;
		public virtual unsafe string TooltipColorLight {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipColorLight' and count(parameter)=0]"
			[Register ("getTooltipColorLight", "()Ljava/lang/String;", "GetGetTooltipColorLightHandler")]
			get {
				if (id_getTooltipColorLight == IntPtr.Zero)
					id_getTooltipColorLight = JNIEnv.GetMethodID (class_ref, "getTooltipColorLight", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipColorLight), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipColorLight", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipFontFamily;
#pragma warning disable 0169
		static Delegate GetGetTooltipFontFamilyHandler ()
		{
			if (cb_getTooltipFontFamily == null)
				cb_getTooltipFontFamily = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipFontFamily);
			return cb_getTooltipFontFamily;
		}

		static IntPtr n_GetTooltipFontFamily (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipFontFamily);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipFontFamily;
		public virtual unsafe string TooltipFontFamily {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipFontFamily' and count(parameter)=0]"
			[Register ("getTooltipFontFamily", "()Ljava/lang/String;", "GetGetTooltipFontFamilyHandler")]
			get {
				if (id_getTooltipFontFamily == IntPtr.Zero)
					id_getTooltipFontFamily = JNIEnv.GetMethodID (class_ref, "getTooltipFontFamily", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipFontFamily), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipFontFamily", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTooltipFontSize;
#pragma warning disable 0169
		static Delegate GetGetTooltipFontSizeHandler ()
		{
			if (cb_getTooltipFontSize == null)
				cb_getTooltipFontSize = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTooltipFontSize);
			return cb_getTooltipFontSize;
		}

		static IntPtr n_GetTooltipFontSize (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Css __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Css> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TooltipFontSize);
		}
#pragma warning restore 0169

		static IntPtr id_getTooltipFontSize;
		public virtual unsafe string TooltipFontSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Css']/method[@name='getTooltipFontSize' and count(parameter)=0]"
			[Register ("getTooltipFontSize", "()Ljava/lang/String;", "GetGetTooltipFontSizeHandler")]
			get {
				if (id_getTooltipFontSize == IntPtr.Zero)
					id_getTooltipFontSize = JNIEnv.GetMethodID (class_ref, "getTooltipFontSize", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTooltipFontSize), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTooltipFontSize", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
