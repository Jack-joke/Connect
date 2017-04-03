using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='OnAlertDialogButtonClickListener']"
	[Register ("com/inscripts/interfaces/OnAlertDialogButtonClickListener", "", "Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListenerInvoker")]
	public partial interface IOnAlertDialogButtonClickListener : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='OnAlertDialogButtonClickListener']/method[@name='onButtonClick' and count(parameter)=4 and parameter[1][@type='android.app.AlertDialog'] and parameter[2][@type='android.view.View'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("onButtonClick", "(Landroid/app/AlertDialog;Landroid/view/View;II)V", "GetOnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_IIHandler:Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListenerInvoker, MessageSDKBinding.Droid")]
		void OnButtonClick (global::Android.App.AlertDialog p0, global::Android.Views.View p1, int p2, int p3);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/OnAlertDialogButtonClickListener", DoNotGenerateAcw=true)]
	internal class IOnAlertDialogButtonClickListenerInvoker : global::Java.Lang.Object, IOnAlertDialogButtonClickListener {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/OnAlertDialogButtonClickListener");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IOnAlertDialogButtonClickListenerInvoker); }
		}

		IntPtr class_ref;

		public static IOnAlertDialogButtonClickListener GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IOnAlertDialogButtonClickListener> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.OnAlertDialogButtonClickListener"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IOnAlertDialogButtonClickListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
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
			global::Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.App.AlertDialog p0 = global::Java.Lang.Object.GetObject<global::Android.App.AlertDialog> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p1 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.OnButtonClick (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		IntPtr id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II;
		public unsafe void OnButtonClick (global::Android.App.AlertDialog p0, global::Android.Views.View p1, int p2, int p3)
		{
			if (id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II == IntPtr.Zero)
				id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II = JNIEnv.GetMethodID (class_ref, "onButtonClick", "(Landroid/app/AlertDialog;Landroid/view/View;II)V");
			JValue* __args = stackalloc JValue [4];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			__args [3] = new JValue (p3);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onButtonClick_Landroid_app_AlertDialog_Landroid_view_View_II, __args);
		}

	}

	public partial class AlertDialogButtonClickEventArgs : global::System.EventArgs {

		public AlertDialogButtonClickEventArgs (global::Android.App.AlertDialog p0, global::Android.Views.View p1, int p2, int p3)
		{
			this.p0 = p0;
			this.p1 = p1;
			this.p2 = p2;
			this.p3 = p3;
		}

		global::Android.App.AlertDialog p0;
		public global::Android.App.AlertDialog P0 {
			get { return p0; }
		}

		global::Android.Views.View p1;
		public global::Android.Views.View P1 {
			get { return p1; }
		}

		int p2;
		public int P2 {
			get { return p2; }
		}

		int p3;
		public int P3 {
			get { return p3; }
		}
	}

	[global::Android.Runtime.Register ("mono/com/inscripts/interfaces/OnAlertDialogButtonClickListenerImplementor")]
	internal sealed partial class IOnAlertDialogButtonClickListenerImplementor : global::Java.Lang.Object, IOnAlertDialogButtonClickListener {

		object sender;

		public IOnAlertDialogButtonClickListenerImplementor (object sender)
			: base (
				global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/inscripts/interfaces/OnAlertDialogButtonClickListenerImplementor", "()V"),
				JniHandleOwnership.TransferLocalRef)
		{
			global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
			this.sender = sender;
		}

#pragma warning disable 0649
		public EventHandler<AlertDialogButtonClickEventArgs> Handler;
#pragma warning restore 0649

		public void OnButtonClick (global::Android.App.AlertDialog p0, global::Android.Views.View p1, int p2, int p3)
		{
			var __h = Handler;
			if (__h != null)
				__h (sender, new AlertDialogButtonClickEventArgs (p0, p1, p2, p3));
		}

		internal static bool __IsEmpty (IOnAlertDialogButtonClickListenerImplementor value)
		{
			return value.Handler == null;
		}
	}

}
