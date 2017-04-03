using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomAlertDialogHelper']"
	[global::Android.Runtime.Register ("com/inscripts/custom/CustomAlertDialogHelper", DoNotGenerateAcw=true)]
	public partial class CustomAlertDialogHelper : global::Java.Lang.Object, global::Android.Views.View.IOnClickListener {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/CustomAlertDialogHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CustomAlertDialogHelper); }
		}

		protected CustomAlertDialogHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_view_View_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_OnAlertDialogButtonClickListener_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomAlertDialogHelper']/constructor[@name='CustomAlertDialogHelper' and count(parameter)=8 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='android.view.View'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='java.lang.String'] and parameter[7][@type='com.inscripts.interfaces.OnAlertDialogButtonClickListener'] and parameter[8][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/lang/String;Landroid/view/View;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/OnAlertDialogButtonClickListener;I)V", "")]
		public unsafe CustomAlertDialogHelper (global::Android.Content.Context p0, string p1, global::Android.Views.View p2, string p3, string p4, string p5, global::Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListener p6, int p7)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [8];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (native_p5);
				__args [6] = new JValue (p6);
				__args [7] = new JValue (p7);
				if (GetType () != typeof (CustomAlertDialogHelper)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/lang/String;Landroid/view/View;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/OnAlertDialogButtonClickListener;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/lang/String;Landroid/view/View;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/OnAlertDialogButtonClickListener;I)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_view_View_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_OnAlertDialogButtonClickListener_I == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_view_View_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_OnAlertDialogButtonClickListener_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;Landroid/view/View;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/inscripts/interfaces/OnAlertDialogButtonClickListener;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_view_View_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_OnAlertDialogButtonClickListener_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_lang_String_Landroid_view_View_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lcom_inscripts_interfaces_OnAlertDialogButtonClickListener_I, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

		static Delegate cb_onClick_Landroid_view_View_;
#pragma warning disable 0169
		static Delegate GetOnClick_Landroid_view_View_Handler ()
		{
			if (cb_onClick_Landroid_view_View_ == null)
				cb_onClick_Landroid_view_View_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnClick_Landroid_view_View_);
			return cb_onClick_Landroid_view_View_;
		}

		static void n_OnClick_Landroid_view_View_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.CustomAlertDialogHelper __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.CustomAlertDialogHelper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnClick (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onClick_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomAlertDialogHelper']/method[@name='onClick' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
		[Register ("onClick", "(Landroid/view/View;)V", "GetOnClick_Landroid_view_View_Handler")]
		public virtual unsafe void OnClick (global::Android.Views.View p0)
		{
			if (id_onClick_Landroid_view_View_ == IntPtr.Zero)
				id_onClick_Landroid_view_View_ = JNIEnv.GetMethodID (class_ref, "onClick", "(Landroid/view/View;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onClick_Landroid_view_View_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onClick", "(Landroid/view/View;)V"), __args);
			} finally {
			}
		}

	}
}
