using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Fragments {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='SettingsFragment']"
	[global::Android.Runtime.Register ("com/inscripts/fragments/SettingsFragment", DoNotGenerateAcw=true)]
	public partial class SettingsFragment : global::Android.Support.V4.App.Fragment, global::Android.Views.View.IOnClickListener, global::Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListener {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/fragments/SettingsFragment", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SettingsFragment); }
		}

		protected SettingsFragment (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='SettingsFragment']/constructor[@name='SettingsFragment' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SettingsFragment ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SettingsFragment)) {
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

		static Delegate cb_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II;
#pragma warning disable 0169
		static Delegate GetOnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_IIHandler ()
		{
			if (cb_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II == null)
				cb_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, int, int>) n_OnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II);
			return cb_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II;
		}

		static void n_OnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, int p3)
		{
			global::Com.Inscripts.Fragments.SettingsFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.SettingsFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.App.AlertDialog p0 = global::Java.Lang.Object.GetObject<global::Android.App.AlertDialog> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p1 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.OnButtonClick (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='SettingsFragment']/method[@name='onButtonClick' and count(parameter)=4 and parameter[1][@type='android.app.AlertDialog'] and parameter[2][@type='android.view.View'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("onButtonClick", "(Landroid/app/AlertDialog;Landroid/view/View;II)V", "GetOnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_IIHandler")]
		public virtual unsafe void OnButtonClick (global::Android.App.AlertDialog p0, global::Android.Views.View p1, int p2, int p3)
		{
			if (id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II == IntPtr.Zero)
				id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II = JNIEnv.GetMethodID (class_ref, "onButtonClick", "(Landroid/app/AlertDialog;Landroid/view/View;II)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onButtonClick", "(Landroid/app/AlertDialog;Landroid/view/View;II)V"), __args);
			} finally {
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
			global::Com.Inscripts.Fragments.SettingsFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.SettingsFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnClick (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onClick_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='SettingsFragment']/method[@name='onClick' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
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

		static Delegate cb_showStatusDialog;
#pragma warning disable 0169
		static Delegate GetShowStatusDialogHandler ()
		{
			if (cb_showStatusDialog == null)
				cb_showStatusDialog = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ShowStatusDialog);
			return cb_showStatusDialog;
		}

		static void n_ShowStatusDialog (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Fragments.SettingsFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.SettingsFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ShowStatusDialog ();
		}
#pragma warning restore 0169

		static IntPtr id_showStatusDialog;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='SettingsFragment']/method[@name='showStatusDialog' and count(parameter)=0]"
		[Register ("showStatusDialog", "()V", "GetShowStatusDialogHandler")]
		public virtual unsafe void ShowStatusDialog ()
		{
			if (id_showStatusDialog == IntPtr.Zero)
				id_showStatusDialog = JNIEnv.GetMethodID (class_ref, "showStatusDialog", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_showStatusDialog);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "showStatusDialog", "()V"));
			} finally {
			}
		}

	}
}
