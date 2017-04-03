using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SettingActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/SettingActivity", DoNotGenerateAcw=true)]
	public partial class SettingActivity : global::Com.Inscripts.Utils.SuperActivity, global::Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListener {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/SettingActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SettingActivity); }
		}

		protected SettingActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SettingActivity']/constructor[@name='SettingActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SettingActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SettingActivity)) {
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
			global::Com.Inscripts.Activities.SettingActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.SettingActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.App.AlertDialog p0 = global::Java.Lang.Object.GetObject<global::Android.App.AlertDialog> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p1 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.OnButtonClick (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SettingActivity']/method[@name='onButtonClick' and count(parameter)=4 and parameter[1][@type='android.app.AlertDialog'] and parameter[2][@type='android.view.View'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
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

	}
}
