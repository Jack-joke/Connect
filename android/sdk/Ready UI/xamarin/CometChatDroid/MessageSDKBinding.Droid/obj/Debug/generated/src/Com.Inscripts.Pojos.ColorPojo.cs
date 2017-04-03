using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Pojos {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']"
	[global::Android.Runtime.Register ("com/inscripts/pojos/ColorPojo", DoNotGenerateAcw=true)]
	public partial class ColorPojo : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/pojos/ColorPojo", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ColorPojo); }
		}

		protected ColorPojo (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Ljava_lang_String_Z;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']/constructor[@name='ColorPojo' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register (".ctor", "(Ljava/lang/String;Z)V", "")]
		public unsafe ColorPojo (string p0, bool p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (ColorPojo)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/String;Z)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/String;Z)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_String_Z == IntPtr.Zero)
					id_ctor_Ljava_lang_String_Z = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/String;Z)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_String_Z, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_String_Z, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_getColor;
#pragma warning disable 0169
		static Delegate GetGetColorHandler ()
		{
			if (cb_getColor == null)
				cb_getColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetColor);
			return cb_getColor;
		}

		static IntPtr n_GetColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.ColorPojo __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ColorPojo> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Color);
		}
#pragma warning restore 0169

		static Delegate cb_setColor_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetColor_Ljava_lang_String_Handler ()
		{
			if (cb_setColor_Ljava_lang_String_ == null)
				cb_setColor_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetColor_Ljava_lang_String_);
			return cb_setColor_Ljava_lang_String_;
		}

		static void n_SetColor_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.ColorPojo __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ColorPojo> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Color = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getColor;
		static IntPtr id_setColor_Ljava_lang_String_;
		public virtual unsafe string Color {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']/method[@name='getColor' and count(parameter)=0]"
			[Register ("getColor", "()Ljava/lang/String;", "GetGetColorHandler")]
			get {
				if (id_getColor == IntPtr.Zero)
					id_getColor = JNIEnv.GetMethodID (class_ref, "getColor", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getColor), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getColor", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']/method[@name='setColor' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setColor", "(Ljava/lang/String;)V", "GetSetColor_Ljava_lang_String_Handler")]
			set {
				if (id_setColor_Ljava_lang_String_ == IntPtr.Zero)
					id_setColor_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setColor", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setColor_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setColor", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_isSelected;
#pragma warning disable 0169
		static Delegate GetIsSelectedHandler ()
		{
			if (cb_isSelected == null)
				cb_isSelected = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsSelected);
			return cb_isSelected;
		}

		static bool n_IsSelected (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.ColorPojo __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ColorPojo> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Selected;
		}
#pragma warning restore 0169

		static Delegate cb_setSelected_Z;
#pragma warning disable 0169
		static Delegate GetSetSelected_ZHandler ()
		{
			if (cb_setSelected_Z == null)
				cb_setSelected_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetSelected_Z);
			return cb_setSelected_Z;
		}

		static void n_SetSelected_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Pojos.ColorPojo __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.ColorPojo> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Selected = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isSelected;
		static IntPtr id_setSelected_Z;
		public virtual unsafe bool Selected {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']/method[@name='isSelected' and count(parameter)=0]"
			[Register ("isSelected", "()Z", "GetIsSelectedHandler")]
			get {
				if (id_isSelected == IntPtr.Zero)
					id_isSelected = JNIEnv.GetMethodID (class_ref, "isSelected", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isSelected);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isSelected", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='ColorPojo']/method[@name='setSelected' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setSelected", "(Z)V", "GetSetSelected_ZHandler")]
			set {
				if (id_setSelected_Z == IntPtr.Zero)
					id_setSelected_Z = JNIEnv.GetMethodID (class_ref, "setSelected", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSelected_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSelected", "(Z)V"), __args);
				} finally {
				}
			}
		}

	}
}
