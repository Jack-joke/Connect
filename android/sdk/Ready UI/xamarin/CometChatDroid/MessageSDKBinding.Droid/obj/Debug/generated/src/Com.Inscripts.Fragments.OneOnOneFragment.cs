using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Fragments {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='OneOnOneFragment']"
	[global::Android.Runtime.Register ("com/inscripts/fragments/OneOnOneFragment", DoNotGenerateAcw=true)]
	public partial class OneOnOneFragment : global::Android.Support.V4.App.Fragment, global::Android.Support.V7.Widget.SearchView.IOnQueryTextListener, global::Android.Widget.AdapterView.IOnItemClickListener {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/fragments/OneOnOneFragment", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OneOnOneFragment); }
		}

		protected OneOnOneFragment (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='OneOnOneFragment']/constructor[@name='OneOnOneFragment' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe OneOnOneFragment ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (OneOnOneFragment)) {
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

		static Delegate cb_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ;
#pragma warning disable 0169
		static Delegate GetOnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler ()
		{
			if (cb_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ == null)
				cb_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, int, long>) n_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ);
			return cb_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ;
		}

		static void n_OnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, long p3)
		{
			global::Com.Inscripts.Fragments.OneOnOneFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.OneOnOneFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Widget.AdapterView p0 = global::Java.Lang.Object.GetObject<global::Android.Widget.AdapterView> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p1 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.OnItemClick (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='OneOnOneFragment']/method[@name='onItemClick' and count(parameter)=4 and parameter[1][@type='android.widget.AdapterView&lt;?&gt;'] and parameter[2][@type='android.view.View'] and parameter[3][@type='int'] and parameter[4][@type='long']]"
		[Register ("onItemClick", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V", "GetOnItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJHandler")]
		public virtual unsafe void OnItemClick (global::Android.Widget.AdapterView p0, global::Android.Views.View p1, int p2, long p3)
		{
			if (id_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ == IntPtr.Zero)
				id_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ = JNIEnv.GetMethodID (class_ref, "onItemClick", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onItemClick_Landroid_widget_AdapterView_Landroid_view_View_IJ, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onItemClick", "(Landroid/widget/AdapterView;Landroid/view/View;IJ)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onQueryTextChange_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetOnQueryTextChange_Ljava_lang_String_Handler ()
		{
			if (cb_onQueryTextChange_Ljava_lang_String_ == null)
				cb_onQueryTextChange_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_OnQueryTextChange_Ljava_lang_String_);
			return cb_onQueryTextChange_Ljava_lang_String_;
		}

		static bool n_OnQueryTextChange_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Fragments.OneOnOneFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.OneOnOneFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.OnQueryTextChange (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onQueryTextChange_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='OneOnOneFragment']/method[@name='onQueryTextChange' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onQueryTextChange", "(Ljava/lang/String;)Z", "GetOnQueryTextChange_Ljava_lang_String_Handler")]
		public virtual unsafe bool OnQueryTextChange (string p0)
		{
			if (id_onQueryTextChange_Ljava_lang_String_ == IntPtr.Zero)
				id_onQueryTextChange_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onQueryTextChange", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_onQueryTextChange_Ljava_lang_String_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onQueryTextChange", "(Ljava/lang/String;)Z"), __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_onQueryTextSubmit_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetOnQueryTextSubmit_Ljava_lang_String_Handler ()
		{
			if (cb_onQueryTextSubmit_Ljava_lang_String_ == null)
				cb_onQueryTextSubmit_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_OnQueryTextSubmit_Ljava_lang_String_);
			return cb_onQueryTextSubmit_Ljava_lang_String_;
		}

		static bool n_OnQueryTextSubmit_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Fragments.OneOnOneFragment __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Fragments.OneOnOneFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.OnQueryTextSubmit (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onQueryTextSubmit_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.fragments']/class[@name='OneOnOneFragment']/method[@name='onQueryTextSubmit' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onQueryTextSubmit", "(Ljava/lang/String;)Z", "GetOnQueryTextSubmit_Ljava_lang_String_Handler")]
		public virtual unsafe bool OnQueryTextSubmit (string p0)
		{
			if (id_onQueryTextSubmit_Ljava_lang_String_ == IntPtr.Zero)
				id_onQueryTextSubmit_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onQueryTextSubmit", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_onQueryTextSubmit_Ljava_lang_String_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onQueryTextSubmit", "(Ljava/lang/String;)Z"), __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
