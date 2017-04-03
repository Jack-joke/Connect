using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']"
	[global::Android.Runtime.Register ("com/inscripts/custom/EmoticonHandler", DoNotGenerateAcw=true)]
	public partial class EmoticonHandler : global::Java.Lang.Object, global::Android.Text.ITextWatcher {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/EmoticonHandler", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (EmoticonHandler); }
		}

		protected EmoticonHandler (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_widget_EditText_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']/constructor[@name='EmoticonHandler' and count(parameter)=2 and parameter[1][@type='android.widget.EditText'] and parameter[2][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/widget/EditText;Landroid/content/Context;)V", "")]
		public unsafe EmoticonHandler (global::Android.Widget.EditText p0, global::Android.Content.Context p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (EmoticonHandler)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/widget/EditText;Landroid/content/Context;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/widget/EditText;Landroid/content/Context;)V", __args);
					return;
				}

				if (id_ctor_Landroid_widget_EditText_Landroid_content_Context_ == IntPtr.Zero)
					id_ctor_Landroid_widget_EditText_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/widget/EditText;Landroid/content/Context;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_widget_EditText_Landroid_content_Context_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_widget_EditText_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static Delegate cb_afterTextChanged_Landroid_text_Editable_;
#pragma warning disable 0169
		static Delegate GetAfterTextChanged_Landroid_text_Editable_Handler ()
		{
			if (cb_afterTextChanged_Landroid_text_Editable_ == null)
				cb_afterTextChanged_Landroid_text_Editable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AfterTextChanged_Landroid_text_Editable_);
			return cb_afterTextChanged_Landroid_text_Editable_;
		}

		static void n_AfterTextChanged_Landroid_text_Editable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.EmoticonHandler __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.EmoticonHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Text.IEditable p0 = (global::Android.Text.IEditable)global::Java.Lang.Object.GetObject<global::Android.Text.IEditable> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AfterTextChanged (p0);
		}
#pragma warning restore 0169

		static IntPtr id_afterTextChanged_Landroid_text_Editable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']/method[@name='afterTextChanged' and count(parameter)=1 and parameter[1][@type='android.text.Editable']]"
		[Register ("afterTextChanged", "(Landroid/text/Editable;)V", "GetAfterTextChanged_Landroid_text_Editable_Handler")]
		public virtual unsafe void AfterTextChanged (global::Android.Text.IEditable p0)
		{
			if (id_afterTextChanged_Landroid_text_Editable_ == IntPtr.Zero)
				id_afterTextChanged_Landroid_text_Editable_ = JNIEnv.GetMethodID (class_ref, "afterTextChanged", "(Landroid/text/Editable;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_afterTextChanged_Landroid_text_Editable_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "afterTextChanged", "(Landroid/text/Editable;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_beforeTextChanged_Ljava_lang_CharSequence_III;
#pragma warning disable 0169
		static Delegate GetBeforeTextChanged_Ljava_lang_CharSequence_IIIHandler ()
		{
			if (cb_beforeTextChanged_Ljava_lang_CharSequence_III == null)
				cb_beforeTextChanged_Ljava_lang_CharSequence_III = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, int, int>) n_BeforeTextChanged_Ljava_lang_CharSequence_III);
			return cb_beforeTextChanged_Ljava_lang_CharSequence_III;
		}

		static void n_BeforeTextChanged_Ljava_lang_CharSequence_III (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, int p3)
		{
			global::Com.Inscripts.Custom.EmoticonHandler __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.EmoticonHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.ICharSequence p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.BeforeTextChanged (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_beforeTextChanged_Ljava_lang_CharSequence_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']/method[@name='beforeTextChanged' and count(parameter)=4 and parameter[1][@type='java.lang.CharSequence'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("beforeTextChanged", "(Ljava/lang/CharSequence;III)V", "GetBeforeTextChanged_Ljava_lang_CharSequence_IIIHandler")]
		public virtual unsafe void BeforeTextChanged (global::Java.Lang.ICharSequence p0, int p1, int p2, int p3)
		{
			if (id_beforeTextChanged_Ljava_lang_CharSequence_III == IntPtr.Zero)
				id_beforeTextChanged_Ljava_lang_CharSequence_III = JNIEnv.GetMethodID (class_ref, "beforeTextChanged", "(Ljava/lang/CharSequence;III)V");
			IntPtr native_p0 = CharSequence.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_beforeTextChanged_Ljava_lang_CharSequence_III, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "beforeTextChanged", "(Ljava/lang/CharSequence;III)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		public void BeforeTextChanged (string p0, int p1, int p2, int p3)
		{
			global::Java.Lang.String jls_p0 = p0 == null ? null : new global::Java.Lang.String (p0);
			BeforeTextChanged (jls_p0, p1, p2, p3);
			if (jls_p0 != null) jls_p0.Dispose ();
		}

		static Delegate cb_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_;
#pragma warning disable 0169
		static Delegate GetInsert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_Handler ()
		{
			if (cb_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_ == null)
				cb_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_);
			return cb_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_;
		}

		static void n_Insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Custom.EmoticonHandler __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.EmoticonHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.Drawables.Drawable p1 = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Insert (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']/method[@name='insert' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='android.graphics.drawable.Drawable']]"
		[Register ("insert", "(Ljava/lang/String;Landroid/graphics/drawable/Drawable;)V", "GetInsert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_Handler")]
		public virtual unsafe void Insert (string p0, global::Android.Graphics.Drawables.Drawable p1)
		{
			if (id_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
				id_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "insert", "(Ljava/lang/String;Landroid/graphics/drawable/Drawable;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_insert_Ljava_lang_String_Landroid_graphics_drawable_Drawable_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "insert", "(Ljava/lang/String;Landroid/graphics/drawable/Drawable;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_onTextChanged_Ljava_lang_CharSequence_III;
#pragma warning disable 0169
		static Delegate GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler ()
		{
			if (cb_onTextChanged_Ljava_lang_CharSequence_III == null)
				cb_onTextChanged_Ljava_lang_CharSequence_III = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, int, int>) n_OnTextChanged_Ljava_lang_CharSequence_III);
			return cb_onTextChanged_Ljava_lang_CharSequence_III;
		}

		static void n_OnTextChanged_Ljava_lang_CharSequence_III (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, int p3)
		{
			global::Com.Inscripts.Custom.EmoticonHandler __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.EmoticonHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.ICharSequence p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnTextChanged (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_onTextChanged_Ljava_lang_CharSequence_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='EmoticonHandler']/method[@name='onTextChanged' and count(parameter)=4 and parameter[1][@type='java.lang.CharSequence'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("onTextChanged", "(Ljava/lang/CharSequence;III)V", "GetOnTextChanged_Ljava_lang_CharSequence_IIIHandler")]
		public virtual unsafe void OnTextChanged (global::Java.Lang.ICharSequence p0, int p1, int p2, int p3)
		{
			if (id_onTextChanged_Ljava_lang_CharSequence_III == IntPtr.Zero)
				id_onTextChanged_Ljava_lang_CharSequence_III = JNIEnv.GetMethodID (class_ref, "onTextChanged", "(Ljava/lang/CharSequence;III)V");
			IntPtr native_p0 = CharSequence.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onTextChanged_Ljava_lang_CharSequence_III, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onTextChanged", "(Ljava/lang/CharSequence;III)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		public void OnTextChanged (string p0, int p1, int p2, int p3)
		{
			global::Java.Lang.String jls_p0 = p0 == null ? null : new global::Java.Lang.String (p0);
			OnTextChanged (jls_p0, p1, p2, p3);
			if (jls_p0 != null) jls_p0.Dispose ();
		}

	}
}
