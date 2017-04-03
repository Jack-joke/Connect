using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PopupHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/PopupHelper", DoNotGenerateAcw=true)]
	public partial class PopupHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/PopupHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (PopupHelper); }
		}

		protected PopupHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PopupHelper']/constructor[@name='PopupHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe PopupHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (PopupHelper)) {
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

		static IntPtr id_newBasicPopupWindow_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PopupHelper']/method[@name='newBasicPopupWindow' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("newBasicPopupWindow", "(Landroid/content/Context;)Landroid/widget/PopupWindow;", "")]
		public static unsafe global::Android.Widget.PopupWindow NewBasicPopupWindow (global::Android.Content.Context p0)
		{
			if (id_newBasicPopupWindow_Landroid_content_Context_ == IntPtr.Zero)
				id_newBasicPopupWindow_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "newBasicPopupWindow", "(Landroid/content/Context;)Landroid/widget/PopupWindow;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Android.Widget.PopupWindow __ret = global::Java.Lang.Object.GetObject<global::Android.Widget.PopupWindow> (JNIEnv.CallStaticObjectMethod  (class_ref, id_newBasicPopupWindow_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_showLikeQuickAction_Landroid_widget_PopupWindow_Landroid_view_View_Landroid_view_View_Landroid_view_WindowManager_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='PopupHelper']/method[@name='showLikeQuickAction' and count(parameter)=6 and parameter[1][@type='android.widget.PopupWindow'] and parameter[2][@type='android.view.View'] and parameter[3][@type='android.view.View'] and parameter[4][@type='android.view.WindowManager'] and parameter[5][@type='int'] and parameter[6][@type='int']]"
		[Register ("showLikeQuickAction", "(Landroid/widget/PopupWindow;Landroid/view/View;Landroid/view/View;Landroid/view/WindowManager;II)V", "")]
		public static unsafe void ShowLikeQuickAction (global::Android.Widget.PopupWindow p0, global::Android.Views.View p1, global::Android.Views.View p2, global::Android.Views.IWindowManager p3, int p4, int p5)
		{
			if (id_showLikeQuickAction_Landroid_widget_PopupWindow_Landroid_view_View_Landroid_view_View_Landroid_view_WindowManager_II == IntPtr.Zero)
				id_showLikeQuickAction_Landroid_widget_PopupWindow_Landroid_view_View_Landroid_view_View_Landroid_view_WindowManager_II = JNIEnv.GetStaticMethodID (class_ref, "showLikeQuickAction", "(Landroid/widget/PopupWindow;Landroid/view/View;Landroid/view/View;Landroid/view/WindowManager;II)V");
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showLikeQuickAction_Landroid_widget_PopupWindow_Landroid_view_View_Landroid_view_View_Landroid_view_WindowManager_II, __args);
			} finally {
			}
		}

	}
}
