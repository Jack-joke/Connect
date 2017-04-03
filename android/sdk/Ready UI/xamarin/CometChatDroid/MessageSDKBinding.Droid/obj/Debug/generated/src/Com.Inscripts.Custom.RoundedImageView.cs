using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']"
	[global::Android.Runtime.Register ("com/inscripts/custom/RoundedImageView", DoNotGenerateAcw=true)]
	public partial class RoundedImageView : global::Android.Widget.ImageView {


		static IntPtr DEFAULT_BORDER_COLOR_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/field[@name='DEFAULT_BORDER_COLOR']"
		[Register ("DEFAULT_BORDER_COLOR")]
		public int DefaultBorderColor {
			get {
				if (DEFAULT_BORDER_COLOR_jfieldId == IntPtr.Zero)
					DEFAULT_BORDER_COLOR_jfieldId = JNIEnv.GetFieldID (class_ref, "DEFAULT_BORDER_COLOR", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, DEFAULT_BORDER_COLOR_jfieldId);
			}
			set {
				if (DEFAULT_BORDER_COLOR_jfieldId == IntPtr.Zero)
					DEFAULT_BORDER_COLOR_jfieldId = JNIEnv.GetFieldID (class_ref, "DEFAULT_BORDER_COLOR", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, DEFAULT_BORDER_COLOR_jfieldId, value);
				} finally {
				}
			}
		}

		static IntPtr DEFAULT_BORDER_WIDTH_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/field[@name='DEFAULT_BORDER_WIDTH']"
		[Register ("DEFAULT_BORDER_WIDTH")]
		public int DefaultBorderWidth {
			get {
				if (DEFAULT_BORDER_WIDTH_jfieldId == IntPtr.Zero)
					DEFAULT_BORDER_WIDTH_jfieldId = JNIEnv.GetFieldID (class_ref, "DEFAULT_BORDER_WIDTH", "I");
				return JNIEnv.GetIntField (((global::Java.Lang.Object) this).Handle, DEFAULT_BORDER_WIDTH_jfieldId);
			}
			set {
				if (DEFAULT_BORDER_WIDTH_jfieldId == IntPtr.Zero)
					DEFAULT_BORDER_WIDTH_jfieldId = JNIEnv.GetFieldID (class_ref, "DEFAULT_BORDER_WIDTH", "I");
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, DEFAULT_BORDER_WIDTH_jfieldId, value);
				} finally {
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/RoundedImageView", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RoundedImageView); }
		}

		protected RoundedImageView (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/constructor[@name='RoundedImageView' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe RoundedImageView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (RoundedImageView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/constructor[@name='RoundedImageView' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe RoundedImageView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (RoundedImageView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/constructor[@name='RoundedImageView' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe RoundedImageView (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (RoundedImageView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static Delegate cb_getBorderColor;
#pragma warning disable 0169
		static Delegate GetGetBorderColorHandler ()
		{
			if (cb_getBorderColor == null)
				cb_getBorderColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBorderColor);
			return cb_getBorderColor;
		}

		static int n_GetBorderColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.RoundedImageView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BorderColor;
		}
#pragma warning restore 0169

		static Delegate cb_setBorderColor_I;
#pragma warning disable 0169
		static Delegate GetSetBorderColor_IHandler ()
		{
			if (cb_setBorderColor_I == null)
				cb_setBorderColor_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBorderColor_I);
			return cb_setBorderColor_I;
		}

		static void n_SetBorderColor_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.RoundedImageView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.BorderColor = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBorderColor;
		static IntPtr id_setBorderColor_I;
		public virtual unsafe int BorderColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/method[@name='getBorderColor' and count(parameter)=0]"
			[Register ("getBorderColor", "()I", "GetGetBorderColorHandler")]
			get {
				if (id_getBorderColor == IntPtr.Zero)
					id_getBorderColor = JNIEnv.GetMethodID (class_ref, "getBorderColor", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBorderColor);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBorderColor", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/method[@name='setBorderColor' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBorderColor", "(I)V", "GetSetBorderColor_IHandler")]
			set {
				if (id_setBorderColor_I == IntPtr.Zero)
					id_setBorderColor_I = JNIEnv.GetMethodID (class_ref, "setBorderColor", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBorderColor_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBorderColor", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getBorderWidth;
#pragma warning disable 0169
		static Delegate GetGetBorderWidthHandler ()
		{
			if (cb_getBorderWidth == null)
				cb_getBorderWidth = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBorderWidth);
			return cb_getBorderWidth;
		}

		static int n_GetBorderWidth (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.RoundedImageView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BorderWidth;
		}
#pragma warning restore 0169

		static Delegate cb_setBorderWidth_I;
#pragma warning disable 0169
		static Delegate GetSetBorderWidth_IHandler ()
		{
			if (cb_setBorderWidth_I == null)
				cb_setBorderWidth_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBorderWidth_I);
			return cb_setBorderWidth_I;
		}

		static void n_SetBorderWidth_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.RoundedImageView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.BorderWidth = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBorderWidth;
		static IntPtr id_setBorderWidth_I;
		public virtual unsafe int BorderWidth {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/method[@name='getBorderWidth' and count(parameter)=0]"
			[Register ("getBorderWidth", "()I", "GetGetBorderWidthHandler")]
			get {
				if (id_getBorderWidth == IntPtr.Zero)
					id_getBorderWidth = JNIEnv.GetMethodID (class_ref, "getBorderWidth", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBorderWidth);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBorderWidth", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='RoundedImageView']/method[@name='setBorderWidth' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBorderWidth", "(I)V", "GetSetBorderWidth_IHandler")]
			set {
				if (id_setBorderWidth_I == IntPtr.Zero)
					id_setBorderWidth_I = JNIEnv.GetMethodID (class_ref, "setBorderWidth", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBorderWidth_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBorderWidth", "(I)V"), __args);
				} finally {
				}
			}
		}

	}
}
