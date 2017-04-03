using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/SlidingStripAdapter", DoNotGenerateAcw=true)]
	public partial class SlidingStripAdapter : global::Android.Support.V4.View.PagerAdapter, global::Com.Inscripts.Mapping.RecentlyUsedStickers.IRefreshGridViewAdapterListener {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/adapters/SlidingStripAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SlidingStripAdapter); }
		}

		protected SlidingStripAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_app_Activity_IILcom_inscripts_interfaces_StickerClickInterface_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']/constructor[@name='SlidingStripAdapter' and count(parameter)=4 and parameter[1][@type='android.app.Activity'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='com.inscripts.interfaces.StickerClickInterface']]"
		[Register (".ctor", "(Landroid/app/Activity;IILcom/inscripts/interfaces/StickerClickInterface;)V", "")]
		public unsafe SlidingStripAdapter (global::Android.App.Activity p0, int p1, int p2, global::Com.Inscripts.Interfaces.IStickerClickInterface p3)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				if (GetType () != typeof (SlidingStripAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/app/Activity;IILcom/inscripts/interfaces/StickerClickInterface;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/app/Activity;IILcom/inscripts/interfaces/StickerClickInterface;)V", __args);
					return;
				}

				if (id_ctor_Landroid_app_Activity_IILcom_inscripts_interfaces_StickerClickInterface_ == IntPtr.Zero)
					id_ctor_Landroid_app_Activity_IILcom_inscripts_interfaces_StickerClickInterface_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/app/Activity;IILcom/inscripts/interfaces/StickerClickInterface;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_app_Activity_IILcom_inscripts_interfaces_StickerClickInterface_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_app_Activity_IILcom_inscripts_interfaces_StickerClickInterface_, __args);
			} finally {
			}
		}

		static Delegate cb_getCount;
#pragma warning disable 0169
		static Delegate GetGetCountHandler ()
		{
			if (cb_getCount == null)
				cb_getCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetCount);
			return cb_getCount;
		}

		static int n_GetCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.SlidingStripAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.SlidingStripAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Count;
		}
#pragma warning restore 0169

		static IntPtr id_getCount;
		public override unsafe int Count {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']/method[@name='getCount' and count(parameter)=0]"
			[Register ("getCount", "()I", "GetGetCountHandler")]
			get {
				if (id_getCount == IntPtr.Zero)
					id_getCount = JNIEnv.GetMethodID (class_ref, "getCount", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCount);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCount", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_getPageIconResId_I;
#pragma warning disable 0169
		static Delegate GetGetPageIconResId_IHandler ()
		{
			if (cb_getPageIconResId_I == null)
				cb_getPageIconResId_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_GetPageIconResId_I);
			return cb_getPageIconResId_I;
		}

		static int n_GetPageIconResId_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Adapters.SlidingStripAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.SlidingStripAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetPageIconResId (p0);
		}
#pragma warning restore 0169

		static IntPtr id_getPageIconResId_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']/method[@name='getPageIconResId' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getPageIconResId", "(I)I", "GetGetPageIconResId_IHandler")]
		public virtual unsafe int GetPageIconResId (int p0)
		{
			if (id_getPageIconResId_I == IntPtr.Zero)
				id_getPageIconResId_I = JNIEnv.GetMethodID (class_ref, "getPageIconResId", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPageIconResId_I, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPageIconResId", "(I)I"), __args);
			} finally {
			}
		}

		static Delegate cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler ()
		{
			if (cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ == null)
				cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>) n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_);
			return cb_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;
		}

		static bool n_IsViewFromObject_Landroid_view_View_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Adapters.SlidingStripAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.SlidingStripAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p1 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p1, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.IsViewFromObject (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_isViewFromObject_Landroid_view_View_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']/method[@name='isViewFromObject' and count(parameter)=2 and parameter[1][@type='android.view.View'] and parameter[2][@type='java.lang.Object']]"
		[Register ("isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z", "GetIsViewFromObject_Landroid_view_View_Ljava_lang_Object_Handler")]
		public override unsafe bool IsViewFromObject (global::Android.Views.View p0, global::Java.Lang.Object p1)
		{
			if (id_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ == IntPtr.Zero)
				id_isViewFromObject_Landroid_view_View_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isViewFromObject_Landroid_view_View_Ljava_lang_Object_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isViewFromObject", "(Landroid/view/View;Ljava/lang/Object;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onNewStickerUsed;
#pragma warning disable 0169
		static Delegate GetOnNewStickerUsedHandler ()
		{
			if (cb_onNewStickerUsed == null)
				cb_onNewStickerUsed = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnNewStickerUsed);
			return cb_onNewStickerUsed;
		}

		static void n_OnNewStickerUsed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.SlidingStripAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.SlidingStripAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnNewStickerUsed ();
		}
#pragma warning restore 0169

		static IntPtr id_onNewStickerUsed;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='SlidingStripAdapter']/method[@name='onNewStickerUsed' and count(parameter)=0]"
		[Register ("onNewStickerUsed", "()V", "GetOnNewStickerUsedHandler")]
		public virtual unsafe void OnNewStickerUsed ()
		{
			if (id_onNewStickerUsed == IntPtr.Zero)
				id_onNewStickerUsed = JNIEnv.GetMethodID (class_ref, "onNewStickerUsed", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onNewStickerUsed);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onNewStickerUsed", "()V"));
			} finally {
			}
		}

	}
}
