using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']"
	[global::Android.Runtime.Register ("com/inscripts/custom/SlidingTabLayout", DoNotGenerateAcw=true)]
	public partial class SlidingTabLayout : global::Android.Widget.HorizontalScrollView {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.InternalViewPagerListener']"
		[global::Android.Runtime.Register ("com/inscripts/custom/SlidingTabLayout$InternalViewPagerListener", DoNotGenerateAcw=true)]
		public partial class InternalViewPagerListener : global::Java.Lang.Object, global::Android.Support.V4.View.ViewPager.IOnPageChangeListener {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/custom/SlidingTabLayout$InternalViewPagerListener", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (InternalViewPagerListener); }
			}

			protected InternalViewPagerListener (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static Delegate cb_onPageScrollStateChanged_I;
#pragma warning disable 0169
			static Delegate GetOnPageScrollStateChanged_IHandler ()
			{
				if (cb_onPageScrollStateChanged_I == null)
					cb_onPageScrollStateChanged_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_OnPageScrollStateChanged_I);
				return cb_onPageScrollStateChanged_I;
			}

			static void n_OnPageScrollStateChanged_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.OnPageScrollStateChanged (p0);
			}
#pragma warning restore 0169

			static IntPtr id_onPageScrollStateChanged_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.InternalViewPagerListener']/method[@name='onPageScrollStateChanged' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("onPageScrollStateChanged", "(I)V", "GetOnPageScrollStateChanged_IHandler")]
			public virtual unsafe void OnPageScrollStateChanged (int p0)
			{
				if (id_onPageScrollStateChanged_I == IntPtr.Zero)
					id_onPageScrollStateChanged_I = JNIEnv.GetMethodID (class_ref, "onPageScrollStateChanged", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPageScrollStateChanged_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onPageScrollStateChanged", "(I)V"), __args);
				} finally {
				}
			}

			static Delegate cb_onPageScrolled_IFI;
#pragma warning disable 0169
			static Delegate GetOnPageScrolled_IFIHandler ()
			{
				if (cb_onPageScrolled_IFI == null)
					cb_onPageScrolled_IFI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, float, int>) n_OnPageScrolled_IFI);
				return cb_onPageScrolled_IFI;
			}

			static void n_OnPageScrolled_IFI (IntPtr jnienv, IntPtr native__this, int p0, float p1, int p2)
			{
				global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.OnPageScrolled (p0, p1, p2);
			}
#pragma warning restore 0169

			static IntPtr id_onPageScrolled_IFI;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.InternalViewPagerListener']/method[@name='onPageScrolled' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='float'] and parameter[3][@type='int']]"
			[Register ("onPageScrolled", "(IFI)V", "GetOnPageScrolled_IFIHandler")]
			public virtual unsafe void OnPageScrolled (int p0, float p1, int p2)
			{
				if (id_onPageScrolled_IFI == IntPtr.Zero)
					id_onPageScrolled_IFI = JNIEnv.GetMethodID (class_ref, "onPageScrolled", "(IFI)V");
				try {
					JValue* __args = stackalloc JValue [3];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					__args [2] = new JValue (p2);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPageScrolled_IFI, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onPageScrolled", "(IFI)V"), __args);
				} finally {
				}
			}

			static Delegate cb_onPageSelected_I;
#pragma warning disable 0169
			static Delegate GetOnPageSelected_IHandler ()
			{
				if (cb_onPageSelected_I == null)
					cb_onPageSelected_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_OnPageSelected_I);
				return cb_onPageSelected_I;
			}

			static void n_OnPageSelected_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.InternalViewPagerListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.OnPageSelected (p0);
			}
#pragma warning restore 0169

			static IntPtr id_onPageSelected_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.InternalViewPagerListener']/method[@name='onPageSelected' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("onPageSelected", "(I)V", "GetOnPageSelected_IHandler")]
			public virtual unsafe void OnPageSelected (int p0)
			{
				if (id_onPageSelected_I == IntPtr.Zero)
					id_onPageSelected_I = JNIEnv.GetMethodID (class_ref, "onPageSelected", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onPageSelected_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onPageSelected", "(I)V"), __args);
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.TabClickListener']"
		[global::Android.Runtime.Register ("com/inscripts/custom/SlidingTabLayout$TabClickListener", DoNotGenerateAcw=true)]
		public partial class TabClickListener : global::Java.Lang.Object, global::Android.Views.View.IOnClickListener {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/custom/SlidingTabLayout$TabClickListener", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (TabClickListener); }
			}

			protected TabClickListener (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

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
				global::Com.Inscripts.Custom.SlidingTabLayout.TabClickListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.TabClickListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
				__this.OnClick (p0);
			}
#pragma warning restore 0169

			static IntPtr id_onClick_Landroid_view_View_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout.TabClickListener']/method[@name='onClick' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
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

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.custom']/interface[@name='SlidingTabLayout.TabColorizer']"
		[Register ("com/inscripts/custom/SlidingTabLayout$TabColorizer", "", "Com.Inscripts.Custom.SlidingTabLayout/ITabColorizerInvoker")]
		public partial interface ITabColorizer : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/interface[@name='SlidingTabLayout.TabColorizer']/method[@name='getIndicatorColor' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("getIndicatorColor", "(I)I", "GetGetIndicatorColor_IHandler:Com.Inscripts.Custom.SlidingTabLayout/ITabColorizerInvoker, MessageSDKBinding.Droid")]
			int GetIndicatorColor (int p0);

		}

		[global::Android.Runtime.Register ("com/inscripts/custom/SlidingTabLayout$TabColorizer", DoNotGenerateAcw=true)]
		internal class ITabColorizerInvoker : global::Java.Lang.Object, ITabColorizer {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/custom/SlidingTabLayout$TabColorizer");

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ITabColorizerInvoker); }
			}

			IntPtr class_ref;

			public static ITabColorizer GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<ITabColorizer> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.custom.SlidingTabLayout.TabColorizer"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public ITabColorizerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate cb_getIndicatorColor_I;
#pragma warning disable 0169
			static Delegate GetGetIndicatorColor_IHandler ()
			{
				if (cb_getIndicatorColor_I == null)
					cb_getIndicatorColor_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_GetIndicatorColor_I);
				return cb_getIndicatorColor_I;
			}

			static int n_GetIndicatorColor_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return __this.GetIndicatorColor (p0);
			}
#pragma warning restore 0169

			IntPtr id_getIndicatorColor_I;
			public unsafe int GetIndicatorColor (int p0)
			{
				if (id_getIndicatorColor_I == IntPtr.Zero)
					id_getIndicatorColor_I = JNIEnv.GetMethodID (class_ref, "getIndicatorColor", "(I)I");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getIndicatorColor_I, __args);
			}

		}


		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/SlidingTabLayout", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SlidingTabLayout); }
		}

		protected SlidingTabLayout (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/constructor[@name='SlidingTabLayout' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe SlidingTabLayout (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (SlidingTabLayout)) {
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
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/constructor[@name='SlidingTabLayout' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe SlidingTabLayout (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (SlidingTabLayout)) {
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
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/constructor[@name='SlidingTabLayout' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SlidingTabLayout (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (SlidingTabLayout)) {
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

		static Delegate cb_createDefaultTabView_Landroid_content_Context_;
#pragma warning disable 0169
		static Delegate GetCreateDefaultTabView_Landroid_content_Context_Handler ()
		{
			if (cb_createDefaultTabView_Landroid_content_Context_ == null)
				cb_createDefaultTabView_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_CreateDefaultTabView_Landroid_content_Context_);
			return cb_createDefaultTabView_Landroid_content_Context_;
		}

		static IntPtr n_CreateDefaultTabView_Landroid_content_Context_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.CreateDefaultTabView (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_createDefaultTabView_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='createDefaultTabView' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("createDefaultTabView", "(Landroid/content/Context;)Landroid/widget/TextView;", "GetCreateDefaultTabView_Landroid_content_Context_Handler")]
		protected virtual unsafe global::Android.Widget.TextView CreateDefaultTabView (global::Android.Content.Context p0)
		{
			if (id_createDefaultTabView_Landroid_content_Context_ == IntPtr.Zero)
				id_createDefaultTabView_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "createDefaultTabView", "(Landroid/content/Context;)Landroid/widget/TextView;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Android.Widget.TextView __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_createDefaultTabView_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "createDefaultTabView", "(Landroid/content/Context;)Landroid/widget/TextView;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_setContentDescription_ILjava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetContentDescription_ILjava_lang_String_Handler ()
		{
			if (cb_setContentDescription_ILjava_lang_String_ == null)
				cb_setContentDescription_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, IntPtr>) n_SetContentDescription_ILjava_lang_String_);
			return cb_setContentDescription_ILjava_lang_String_;
		}

		static void n_SetContentDescription_ILjava_lang_String_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.SetContentDescription (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setContentDescription_ILjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setContentDescription' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='java.lang.String']]"
		[Register ("setContentDescription", "(ILjava/lang/String;)V", "GetSetContentDescription_ILjava_lang_String_Handler")]
		public virtual unsafe void SetContentDescription (int p0, string p1)
		{
			if (id_setContentDescription_ILjava_lang_String_ == IntPtr.Zero)
				id_setContentDescription_ILjava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setContentDescription", "(ILjava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setContentDescription_ILjava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setContentDescription", "(ILjava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_;
#pragma warning disable 0169
		static Delegate GetSetCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_Handler ()
		{
			if (cb_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_ == null)
				cb_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_);
			return cb_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_;
		}

		static void n_SetCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer p0 = (global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer)global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetCustomTabColorizer (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setCustomTabColorizer' and count(parameter)=1 and parameter[1][@type='com.inscripts.custom.SlidingTabLayout.TabColorizer']]"
		[Register ("setCustomTabColorizer", "(Lcom/inscripts/custom/SlidingTabLayout$TabColorizer;)V", "GetSetCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_Handler")]
		public virtual unsafe void SetCustomTabColorizer (global::Com.Inscripts.Custom.SlidingTabLayout.ITabColorizer p0)
		{
			if (id_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_ == IntPtr.Zero)
				id_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_ = JNIEnv.GetMethodID (class_ref, "setCustomTabColorizer", "(Lcom/inscripts/custom/SlidingTabLayout$TabColorizer;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCustomTabColorizer_Lcom_inscripts_custom_SlidingTabLayout_TabColorizer_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCustomTabColorizer", "(Lcom/inscripts/custom/SlidingTabLayout$TabColorizer;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setCustomTabView_III;
#pragma warning disable 0169
		static Delegate GetSetCustomTabView_IIIHandler ()
		{
			if (cb_setCustomTabView_III == null)
				cb_setCustomTabView_III = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, int, int>) n_SetCustomTabView_III);
			return cb_setCustomTabView_III;
		}

		static void n_SetCustomTabView_III (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetCustomTabView (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_setCustomTabView_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setCustomTabView' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("setCustomTabView", "(III)V", "GetSetCustomTabView_IIIHandler")]
		public virtual unsafe void SetCustomTabView (int p0, int p1, int p2)
		{
			if (id_setCustomTabView_III == IntPtr.Zero)
				id_setCustomTabView_III = JNIEnv.GetMethodID (class_ref, "setCustomTabView", "(III)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCustomTabView_III, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCustomTabView", "(III)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setDistributeEvenly_Z;
#pragma warning disable 0169
		static Delegate GetSetDistributeEvenly_ZHandler ()
		{
			if (cb_setDistributeEvenly_Z == null)
				cb_setDistributeEvenly_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetDistributeEvenly_Z);
			return cb_setDistributeEvenly_Z;
		}

		static void n_SetDistributeEvenly_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetDistributeEvenly (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setDistributeEvenly_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setDistributeEvenly' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setDistributeEvenly", "(Z)V", "GetSetDistributeEvenly_ZHandler")]
		public virtual unsafe void SetDistributeEvenly (bool p0)
		{
			if (id_setDistributeEvenly_Z == IntPtr.Zero)
				id_setDistributeEvenly_Z = JNIEnv.GetMethodID (class_ref, "setDistributeEvenly", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDistributeEvenly_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setDistributeEvenly", "(Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_;
#pragma warning disable 0169
		static Delegate GetSetOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_Handler ()
		{
			if (cb_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_ == null)
				cb_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_);
			return cb_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_;
		}

		static void n_SetOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Support.V4.View.ViewPager.IOnPageChangeListener p0 = (global::Android.Support.V4.View.ViewPager.IOnPageChangeListener)global::Java.Lang.Object.GetObject<global::Android.Support.V4.View.ViewPager.IOnPageChangeListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetOnPageChangeListener (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setOnPageChangeListener' and count(parameter)=1 and parameter[1][@type='android.support.v4.view.ViewPager.OnPageChangeListener']]"
		[Register ("setOnPageChangeListener", "(Landroid/support/v4/view/ViewPager$OnPageChangeListener;)V", "GetSetOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_Handler")]
		public virtual unsafe void SetOnPageChangeListener (global::Android.Support.V4.View.ViewPager.IOnPageChangeListener p0)
		{
			if (id_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_ == IntPtr.Zero)
				id_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_ = JNIEnv.GetMethodID (class_ref, "setOnPageChangeListener", "(Landroid/support/v4/view/ViewPager$OnPageChangeListener;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setOnPageChangeListener_Landroid_support_v4_view_ViewPager_OnPageChangeListener_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setOnPageChangeListener", "(Landroid/support/v4/view/ViewPager$OnPageChangeListener;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setSelectedIndicatorColors_arrayI;
#pragma warning disable 0169
		static Delegate GetSetSelectedIndicatorColors_arrayIHandler ()
		{
			if (cb_setSelectedIndicatorColors_arrayI == null)
				cb_setSelectedIndicatorColors_arrayI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetSelectedIndicatorColors_arrayI);
			return cb_setSelectedIndicatorColors_arrayI;
		}

		static void n_SetSelectedIndicatorColors_arrayI (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] p0 = (int[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (int));
			__this.SetSelectedIndicatorColors (p0);
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
		}
#pragma warning restore 0169

		static IntPtr id_setSelectedIndicatorColors_arrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setSelectedIndicatorColors' and count(parameter)=1 and parameter[1][@type='int...']]"
		[Register ("setSelectedIndicatorColors", "([I)V", "GetSetSelectedIndicatorColors_arrayIHandler")]
		public virtual unsafe void SetSelectedIndicatorColors (params  int[] p0)
		{
			if (id_setSelectedIndicatorColors_arrayI == IntPtr.Zero)
				id_setSelectedIndicatorColors_arrayI = JNIEnv.GetMethodID (class_ref, "setSelectedIndicatorColors", "([I)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSelectedIndicatorColors_arrayI, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSelectedIndicatorColors", "([I)V"), __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_setViewPager_Landroid_support_v4_view_ViewPager_;
#pragma warning disable 0169
		static Delegate GetSetViewPager_Landroid_support_v4_view_ViewPager_Handler ()
		{
			if (cb_setViewPager_Landroid_support_v4_view_ViewPager_ == null)
				cb_setViewPager_Landroid_support_v4_view_ViewPager_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetViewPager_Landroid_support_v4_view_ViewPager_);
			return cb_setViewPager_Landroid_support_v4_view_ViewPager_;
		}

		static void n_SetViewPager_Landroid_support_v4_view_ViewPager_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Support.V4.View.ViewPager p0 = global::Java.Lang.Object.GetObject<global::Android.Support.V4.View.ViewPager> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetViewPager (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setViewPager_Landroid_support_v4_view_ViewPager_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='setViewPager' and count(parameter)=1 and parameter[1][@type='android.support.v4.view.ViewPager']]"
		[Register ("setViewPager", "(Landroid/support/v4/view/ViewPager;)V", "GetSetViewPager_Landroid_support_v4_view_ViewPager_Handler")]
		public virtual unsafe void SetViewPager (global::Android.Support.V4.View.ViewPager p0)
		{
			if (id_setViewPager_Landroid_support_v4_view_ViewPager_ == IntPtr.Zero)
				id_setViewPager_Landroid_support_v4_view_ViewPager_ = JNIEnv.GetMethodID (class_ref, "setViewPager", "(Landroid/support/v4/view/ViewPager;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setViewPager_Landroid_support_v4_view_ViewPager_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setViewPager", "(Landroid/support/v4/view/ViewPager;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetUpdateBadgeCount_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_UpdateBadgeCount_Ljava_lang_String_Ljava_lang_String_);
			return cb_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_;
		}

		static void n_UpdateBadgeCount_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Custom.SlidingTabLayout __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.SlidingTabLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.UpdateBadgeCount (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='SlidingTabLayout']/method[@name='updateBadgeCount' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
		[Register ("updateBadgeCount", "(Ljava/lang/String;Ljava/lang/String;)V", "GetUpdateBadgeCount_Ljava_lang_String_Ljava_lang_String_Handler")]
		public virtual unsafe void UpdateBadgeCount (string p0, string p1)
		{
			if (id_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "updateBadgeCount", "(Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_updateBadgeCount_Ljava_lang_String_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "updateBadgeCount", "(Ljava/lang/String;Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
