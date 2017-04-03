using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keyboards {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']"
	[global::Android.Runtime.Register ("com/inscripts/Keyboards/StickerKeyboard", DoNotGenerateAcw=true)]
	public partial class StickerKeyboard : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/Keyboards/StickerKeyboard", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StickerKeyboard); }
		}

		protected StickerKeyboard (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/constructor[@name='StickerKeyboard' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe StickerKeyboard ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (StickerKeyboard)) {
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

		static Delegate cb_isKeyboardVisibile;
#pragma warning disable 0169
		static Delegate GetIsKeyboardVisibileHandler ()
		{
			if (cb_isKeyboardVisibile == null)
				cb_isKeyboardVisibile = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsKeyboardVisibile);
			return cb_isKeyboardVisibile;
		}

		static bool n_IsKeyboardVisibile (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsKeyboardVisibile;
		}
#pragma warning restore 0169

		static IntPtr id_isKeyboardVisibile;
		public virtual unsafe bool IsKeyboardVisibile {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='isKeyboardVisibile' and count(parameter)=0]"
			[Register ("isKeyboardVisibile", "()Z", "GetIsKeyboardVisibileHandler")]
			get {
				if (id_isKeyboardVisibile == IntPtr.Zero)
					id_isKeyboardVisibile = JNIEnv.GetMethodID (class_ref, "isKeyboardVisibile", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isKeyboardVisibile);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isKeyboardVisibile", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_getScreenOrientation;
#pragma warning disable 0169
		static Delegate GetGetScreenOrientationHandler ()
		{
			if (cb_getScreenOrientation == null)
				cb_getScreenOrientation = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetScreenOrientation);
			return cb_getScreenOrientation;
		}

		static int n_GetScreenOrientation (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ScreenOrientation;
		}
#pragma warning restore 0169

		static IntPtr id_getScreenOrientation;
		public virtual unsafe int ScreenOrientation {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='getScreenOrientation' and count(parameter)=0]"
			[Register ("getScreenOrientation", "()I", "GetGetScreenOrientationHandler")]
			get {
				if (id_getScreenOrientation == IntPtr.Zero)
					id_getScreenOrientation = JNIEnv.GetMethodID (class_ref, "getScreenOrientation", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getScreenOrientation);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getScreenOrientation", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_changeKeyboardHeight_I;
#pragma warning disable 0169
		static Delegate GetChangeKeyboardHeight_IHandler ()
		{
			if (cb_changeKeyboardHeight_I == null)
				cb_changeKeyboardHeight_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_ChangeKeyboardHeight_I);
			return cb_changeKeyboardHeight_I;
		}

		static void n_ChangeKeyboardHeight_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ChangeKeyboardHeight (p0);
		}
#pragma warning restore 0169

		static IntPtr id_changeKeyboardHeight_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='changeKeyboardHeight' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("changeKeyboardHeight", "(I)V", "GetChangeKeyboardHeight_IHandler")]
		public virtual unsafe void ChangeKeyboardHeight (int p0)
		{
			if (id_changeKeyboardHeight_I == IntPtr.Zero)
				id_changeKeyboardHeight_I = JNIEnv.GetMethodID (class_ref, "changeKeyboardHeight", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_changeKeyboardHeight_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "changeKeyboardHeight", "(I)V"), __args);
			} finally {
			}
		}

		static Delegate cb_checkKeyboardHeight_Landroid_view_View_;
#pragma warning disable 0169
		static Delegate GetCheckKeyboardHeight_Landroid_view_View_Handler ()
		{
			if (cb_checkKeyboardHeight_Landroid_view_View_ == null)
				cb_checkKeyboardHeight_Landroid_view_View_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_CheckKeyboardHeight_Landroid_view_View_);
			return cb_checkKeyboardHeight_Landroid_view_View_;
		}

		static void n_CheckKeyboardHeight_Landroid_view_View_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CheckKeyboardHeight (p0);
		}
#pragma warning restore 0169

		static IntPtr id_checkKeyboardHeight_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='checkKeyboardHeight' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
		[Register ("checkKeyboardHeight", "(Landroid/view/View;)V", "GetCheckKeyboardHeight_Landroid_view_View_Handler")]
		public virtual unsafe void CheckKeyboardHeight (global::Android.Views.View p0)
		{
			if (id_checkKeyboardHeight_Landroid_view_View_ == IntPtr.Zero)
				id_checkKeyboardHeight_Landroid_view_View_ = JNIEnv.GetMethodID (class_ref, "checkKeyboardHeight", "(Landroid/view/View;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_checkKeyboardHeight_Landroid_view_View_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "checkKeyboardHeight", "(Landroid/view/View;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_dismissKeyboard;
#pragma warning disable 0169
		static Delegate GetDismissKeyboardHandler ()
		{
			if (cb_dismissKeyboard == null)
				cb_dismissKeyboard = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_DismissKeyboard);
			return cb_dismissKeyboard;
		}

		static void n_DismissKeyboard (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.DismissKeyboard ();
		}
#pragma warning restore 0169

		static IntPtr id_dismissKeyboard;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='dismissKeyboard' and count(parameter)=0]"
		[Register ("dismissKeyboard", "()V", "GetDismissKeyboardHandler")]
		public virtual unsafe void DismissKeyboard ()
		{
			if (id_dismissKeyboard == IntPtr.Zero)
				id_dismissKeyboard = JNIEnv.GetMethodID (class_ref, "dismissKeyboard", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_dismissKeyboard);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "dismissKeyboard", "()V"));
			} finally {
			}
		}

		static Delegate cb_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_;
#pragma warning disable 0169
		static Delegate GetEnable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_Handler ()
		{
			if (cb_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_ == null)
				cb_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_Enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_);
			return cb_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_;
		}

		static void n_Enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.App.Activity p0 = global::Java.Lang.Object.GetObject<global::Android.App.Activity> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Interfaces.IStickerClickInterface p1 = (global::Com.Inscripts.Interfaces.IStickerClickInterface)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IStickerClickInterface> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Integer p2 = global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.EditText p3 = global::Java.Lang.Object.GetObject<global::Android.Widget.EditText> (native_p3, JniHandleOwnership.DoNotTransfer);
			__this.Enable (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='enable' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='com.inscripts.interfaces.StickerClickInterface'] and parameter[3][@type='java.lang.Integer'] and parameter[4][@type='android.widget.EditText']]"
		[Register ("enable", "(Landroid/app/Activity;Lcom/inscripts/interfaces/StickerClickInterface;Ljava/lang/Integer;Landroid/widget/EditText;)V", "GetEnable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_Handler")]
		public virtual unsafe void Enable (global::Android.App.Activity p0, global::Com.Inscripts.Interfaces.IStickerClickInterface p1, global::Java.Lang.Integer p2, global::Android.Widget.EditText p3)
		{
			if (id_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_ == IntPtr.Zero)
				id_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_ = JNIEnv.GetMethodID (class_ref, "enable", "(Landroid/app/Activity;Lcom/inscripts/interfaces/StickerClickInterface;Ljava/lang/Integer;Landroid/widget/EditText;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_enable_Landroid_app_Activity_Lcom_inscripts_interfaces_StickerClickInterface_Ljava_lang_Integer_Landroid_widget_EditText_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "enable", "(Landroid/app/Activity;Lcom/inscripts/interfaces/StickerClickInterface;Ljava/lang/Integer;Landroid/widget/EditText;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_enableFooterView_Landroid_widget_EditText_;
#pragma warning disable 0169
		static Delegate GetEnableFooterView_Landroid_widget_EditText_Handler ()
		{
			if (cb_enableFooterView_Landroid_widget_EditText_ == null)
				cb_enableFooterView_Landroid_widget_EditText_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_EnableFooterView_Landroid_widget_EditText_);
			return cb_enableFooterView_Landroid_widget_EditText_;
		}

		static void n_EnableFooterView_Landroid_widget_EditText_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.EditText p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.EditText> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.EnableFooterView (p0);
		}
#pragma warning restore 0169

		static IntPtr id_enableFooterView_Landroid_widget_EditText_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='enableFooterView' and count(parameter)=1 and parameter[1][@type='android.widget.EditText']]"
		[Register ("enableFooterView", "(Landroid/widget/EditText;)V", "GetEnableFooterView_Landroid_widget_EditText_Handler")]
		public virtual unsafe void EnableFooterView (global::Android.Widget.EditText p0)
		{
			if (id_enableFooterView_Landroid_widget_EditText_ == IntPtr.Zero)
				id_enableFooterView_Landroid_widget_EditText_ = JNIEnv.GetMethodID (class_ref, "enableFooterView", "(Landroid/widget/EditText;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_enableFooterView_Landroid_widget_EditText_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "enableFooterView", "(Landroid/widget/EditText;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_getClickedSticker_I;
#pragma warning disable 0169
		static Delegate GetGetClickedSticker_IHandler ()
		{
			if (cb_getClickedSticker_I == null)
				cb_getClickedSticker_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetClickedSticker_I);
			return cb_getClickedSticker_I;
		}

		static IntPtr n_GetClickedSticker_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetClickedSticker (p0));
		}
#pragma warning restore 0169

		static IntPtr id_getClickedSticker_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='getClickedSticker' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getClickedSticker", "(I)Ljava/lang/String;", "GetGetClickedSticker_IHandler")]
		public virtual unsafe string GetClickedSticker (int p0)
		{
			if (id_getClickedSticker_I == IntPtr.Zero)
				id_getClickedSticker_I = JNIEnv.GetMethodID (class_ref, "getClickedSticker", "(I)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getClickedSticker_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getClickedSticker", "(I)Ljava/lang/String;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_setKeyBoardHeight_I;
#pragma warning disable 0169
		static Delegate GetSetKeyBoardHeight_IHandler ()
		{
			if (cb_setKeyBoardHeight_I == null)
				cb_setKeyBoardHeight_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetKeyBoardHeight_I);
			return cb_setKeyBoardHeight_I;
		}

		static void n_SetKeyBoardHeight_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetKeyBoardHeight (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setKeyBoardHeight_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='setKeyBoardHeight' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setKeyBoardHeight", "(I)V", "GetSetKeyBoardHeight_IHandler")]
		public virtual unsafe void SetKeyBoardHeight (int p0)
		{
			if (id_setKeyBoardHeight_I == IntPtr.Zero)
				id_setKeyBoardHeight_I = JNIEnv.GetMethodID (class_ref, "setKeyBoardHeight", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setKeyBoardHeight_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setKeyBoardHeight", "(I)V"), __args);
			} finally {
			}
		}

		static IntPtr id_setStickerSize_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='setStickerSize' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setStickerSize", "(I)V", "")]
		public static unsafe void SetStickerSize (int p0)
		{
			if (id_setStickerSize_I == IntPtr.Zero)
				id_setStickerSize_I = JNIEnv.GetStaticMethodID (class_ref, "setStickerSize", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setStickerSize_I, __args);
			} finally {
			}
		}

		static Delegate cb_showKeyboard_Landroid_view_View_;
#pragma warning disable 0169
		static Delegate GetShowKeyboard_Landroid_view_View_Handler ()
		{
			if (cb_showKeyboard_Landroid_view_View_ == null)
				cb_showKeyboard_Landroid_view_View_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ShowKeyboard_Landroid_view_View_);
			return cb_showKeyboard_Landroid_view_View_;
		}

		static void n_ShowKeyboard_Landroid_view_View_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Keyboards.StickerKeyboard __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Keyboards.StickerKeyboard> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ShowKeyboard (p0);
		}
#pragma warning restore 0169

		static IntPtr id_showKeyboard_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='showKeyboard' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
		[Register ("showKeyboard", "(Landroid/view/View;)V", "GetShowKeyboard_Landroid_view_View_Handler")]
		public virtual unsafe void ShowKeyboard (global::Android.Views.View p0)
		{
			if (id_showKeyboard_Landroid_view_View_ == IntPtr.Zero)
				id_showKeyboard_Landroid_view_View_ = JNIEnv.GetMethodID (class_ref, "showKeyboard", "(Landroid/view/View;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_showKeyboard_Landroid_view_View_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "showKeyboard", "(Landroid/view/View;)V"), __args);
			} finally {
			}
		}

		static IntPtr id_showSticker_Landroid_content_Context_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.Keyboards']/class[@name='StickerKeyboard']/method[@name='showSticker' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String']]"
		[Register ("showSticker", "(Landroid/content/Context;Ljava/lang/String;)Landroid/text/SpannableString;", "")]
		public static unsafe global::Android.Text.SpannableString ShowSticker (global::Android.Content.Context p0, string p1)
		{
			if (id_showSticker_Landroid_content_Context_Ljava_lang_String_ == IntPtr.Zero)
				id_showSticker_Landroid_content_Context_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showSticker", "(Landroid/content/Context;Ljava/lang/String;)Landroid/text/SpannableString;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				global::Android.Text.SpannableString __ret = global::Java.Lang.Object.GetObject<global::Android.Text.SpannableString> (JNIEnv.CallStaticObjectMethod  (class_ref, id_showSticker_Landroid_content_Context_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
