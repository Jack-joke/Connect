using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/ViewPagerAdapter", DoNotGenerateAcw=true)]
	public partial class ViewPagerAdapter : global::Android.Support.V4.App.FragmentPagerAdapter {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/adapters/ViewPagerAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ViewPagerAdapter); }
		}

		protected ViewPagerAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_support_v4_app_FragmentManager_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']/constructor[@name='ViewPagerAdapter' and count(parameter)=1 and parameter[1][@type='android.support.v4.app.FragmentManager']]"
		[Register (".ctor", "(Landroid/support/v4/app/FragmentManager;)V", "")]
		public unsafe ViewPagerAdapter (global::Android.Support.V4.App.FragmentManager p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (ViewPagerAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/support/v4/app/FragmentManager;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/support/v4/app/FragmentManager;)V", __args);
					return;
				}

				if (id_ctor_Landroid_support_v4_app_FragmentManager_ == IntPtr.Zero)
					id_ctor_Landroid_support_v4_app_FragmentManager_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/support/v4/app/FragmentManager;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_support_v4_app_FragmentManager_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_support_v4_app_FragmentManager_, __args);
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
			global::Com.Inscripts.Adapters.ViewPagerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.ViewPagerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Count;
		}
#pragma warning restore 0169

		static IntPtr id_getCount;
		public override unsafe int Count {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']/method[@name='getCount' and count(parameter)=0]"
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

		static Delegate cb_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I;
#pragma warning disable 0169
		static Delegate GetAddFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_IHandler ()
		{
			if (cb_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I == null)
				cb_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, int>) n_AddFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I);
			return cb_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I;
		}

		static void n_AddFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2)
		{
			global::Com.Inscripts.Adapters.ViewPagerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.ViewPagerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Support.V4.App.Fragment p0 = global::Java.Lang.Object.GetObject<global::Android.Support.V4.App.Fragment> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddFragment (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']/method[@name='addFragment' and count(parameter)=3 and parameter[1][@type='android.support.v4.app.Fragment'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='int']]"
		[Register ("addFragment", "(Landroid/support/v4/app/Fragment;Ljava/lang/String;I)V", "GetAddFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_IHandler")]
		public virtual unsafe void AddFragment (global::Android.Support.V4.App.Fragment p0, string p1, int p2)
		{
			if (id_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I == IntPtr.Zero)
				id_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I = JNIEnv.GetMethodID (class_ref, "addFragment", "(Landroid/support/v4/app/Fragment;Ljava/lang/String;I)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addFragment_Landroid_support_v4_app_Fragment_Ljava_lang_String_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "addFragment", "(Landroid/support/v4/app/Fragment;Ljava/lang/String;I)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_getItem_I;
#pragma warning disable 0169
		static Delegate GetGetItem_IHandler ()
		{
			if (cb_getItem_I == null)
				cb_getItem_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetItem_I);
			return cb_getItem_I;
		}

		static IntPtr n_GetItem_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Adapters.ViewPagerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.ViewPagerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.GetItem (p0));
		}
#pragma warning restore 0169

		static IntPtr id_getItem_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']/method[@name='getItem' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getItem", "(I)Landroid/support/v4/app/Fragment;", "GetGetItem_IHandler")]
		public override unsafe global::Android.Support.V4.App.Fragment GetItem (int p0)
		{
			if (id_getItem_I == IntPtr.Zero)
				id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Landroid/support/v4/app/Fragment;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Android.Support.V4.App.Fragment> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getItem_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Android.Support.V4.App.Fragment> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Landroid/support/v4/app/Fragment;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_getPageName_I;
#pragma warning disable 0169
		static Delegate GetGetPageName_IHandler ()
		{
			if (cb_getPageName_I == null)
				cb_getPageName_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetPageName_I);
			return cb_getPageName_I;
		}

		static IntPtr n_GetPageName_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Adapters.ViewPagerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.ViewPagerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetPageName (p0));
		}
#pragma warning restore 0169

		static IntPtr id_getPageName_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ViewPagerAdapter']/method[@name='getPageName' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getPageName", "(I)Ljava/lang/String;", "GetGetPageName_IHandler")]
		public virtual unsafe string GetPageName (int p0)
		{
			if (id_getPageName_I == IntPtr.Zero)
				id_getPageName_I = JNIEnv.GetMethodID (class_ref, "getPageName", "(I)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageName_I, __args), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getPageName", "(I)Ljava/lang/String;"), __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}
}
