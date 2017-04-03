using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomViewPager']"
	[global::Android.Runtime.Register ("com/inscripts/custom/CustomViewPager", DoNotGenerateAcw=true)]
	public partial class CustomViewPager : global::Android.Support.V4.View.ViewPager {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/CustomViewPager", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CustomViewPager); }
		}

		protected CustomViewPager (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomViewPager']/constructor[@name='CustomViewPager' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe CustomViewPager (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (CustomViewPager)) {
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

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomViewPager']/constructor[@name='CustomViewPager' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe CustomViewPager (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (CustomViewPager)) {
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

		static Delegate cb_setPagingEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetPagingEnabled_ZHandler ()
		{
			if (cb_setPagingEnabled_Z == null)
				cb_setPagingEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetPagingEnabled_Z);
			return cb_setPagingEnabled_Z;
		}

		static void n_SetPagingEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.CustomViewPager __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.CustomViewPager> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetPagingEnabled (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setPagingEnabled_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='CustomViewPager']/method[@name='setPagingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setPagingEnabled", "(Z)V", "GetSetPagingEnabled_ZHandler")]
		public virtual unsafe void SetPagingEnabled (bool p0)
		{
			if (id_setPagingEnabled_Z == IntPtr.Zero)
				id_setPagingEnabled_Z = JNIEnv.GetMethodID (class_ref, "setPagingEnabled", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPagingEnabled_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setPagingEnabled", "(Z)V"), __args);
			} finally {
			}
		}

	}
}
