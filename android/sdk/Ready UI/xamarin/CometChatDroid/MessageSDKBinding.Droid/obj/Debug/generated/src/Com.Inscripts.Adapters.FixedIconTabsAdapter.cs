using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='FixedIconTabsAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/FixedIconTabsAdapter", DoNotGenerateAcw=true)]
	public partial class FixedIconTabsAdapter : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/adapters/FixedIconTabsAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FixedIconTabsAdapter); }
		}

		protected FixedIconTabsAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_app_Activity_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='FixedIconTabsAdapter']/constructor[@name='FixedIconTabsAdapter' and count(parameter)=1 and parameter[1][@type='android.app.Activity']]"
		[Register (".ctor", "(Landroid/app/Activity;)V", "")]
		public unsafe FixedIconTabsAdapter (global::Android.App.Activity p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (FixedIconTabsAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/app/Activity;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/app/Activity;)V", __args);
					return;
				}

				if (id_ctor_Landroid_app_Activity_ == IntPtr.Zero)
					id_ctor_Landroid_app_Activity_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/app/Activity;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_app_Activity_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_app_Activity_, __args);
			} finally {
			}
		}

		static Delegate cb_getView_I;
#pragma warning disable 0169
		static Delegate GetGetView_IHandler ()
		{
			if (cb_getView_I == null)
				cb_getView_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetView_I);
			return cb_getView_I;
		}

		static IntPtr n_GetView_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Adapters.FixedIconTabsAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.FixedIconTabsAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.GetView (p0));
		}
#pragma warning restore 0169

		static IntPtr id_getView_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='FixedIconTabsAdapter']/method[@name='getView' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getView", "(I)Landroid/view/View;", "GetGetView_IHandler")]
		public virtual unsafe global::Android.Views.View GetView (int p0)
		{
			if (id_getView_I == IntPtr.Zero)
				id_getView_I = JNIEnv.GetMethodID (class_ref, "getView", "(I)Landroid/view/View;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getView_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getView", "(I)Landroid/view/View;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
