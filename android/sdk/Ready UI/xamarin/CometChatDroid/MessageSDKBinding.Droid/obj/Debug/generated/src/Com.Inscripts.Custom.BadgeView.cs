using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Custom {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']"
	[global::Android.Runtime.Register ("com/inscripts/custom/BadgeView", DoNotGenerateAcw=true)]
	public partial class BadgeView : global::Android.Widget.TextView {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/field[@name='POSITION_BOTTOM_LEFT']"
		[Register ("POSITION_BOTTOM_LEFT")]
		public const int PositionBottomLeft = (int) 3;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/field[@name='POSITION_BOTTOM_RIGHT']"
		[Register ("POSITION_BOTTOM_RIGHT")]
		public const int PositionBottomRight = (int) 4;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/field[@name='POSITION_CENTER']"
		[Register ("POSITION_CENTER")]
		public const int PositionCenter = (int) 5;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/field[@name='POSITION_TOP_LEFT']"
		[Register ("POSITION_TOP_LEFT")]
		public const int PositionTopLeft = (int) 1;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/field[@name='POSITION_TOP_RIGHT']"
		[Register ("POSITION_TOP_RIGHT")]
		public const int PositionTopRight = (int) 2;
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/custom/BadgeView", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BadgeView); }
		}

		protected BadgeView (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ILandroid_view_View_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=5 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int'] and parameter[4][@type='android.view.View'] and parameter[5][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;ILandroid/view/View;I)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2, global::Android.Views.View p3, int p4)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				if (GetType () != typeof (BadgeView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;ILandroid/view/View;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;ILandroid/view/View;I)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ILandroid_view_View_I == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ILandroid_view_View_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;ILandroid/view/View;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ILandroid_view_View_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ILandroid_view_View_I, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (BadgeView)) {
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

		static IntPtr id_ctor_Landroid_content_Context_Landroid_widget_TabWidget_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.widget.TabWidget'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/widget/TabWidget;I)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0, global::Android.Widget.TabWidget p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (BadgeView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/widget/TabWidget;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/widget/TabWidget;I)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_widget_TabWidget_I == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_widget_TabWidget_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/widget/TabWidget;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_widget_TabWidget_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_widget_TabWidget_I, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (BadgeView)) {
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
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (BadgeView)) {
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

		static IntPtr id_ctor_Landroid_content_Context_Landroid_view_View_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/constructor[@name='BadgeView' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.view.View']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/view/View;)V", "")]
		public unsafe BadgeView (global::Android.Content.Context p0, global::Android.Views.View p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (GetType () != typeof (BadgeView)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/view/View;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/view/View;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_view_View_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_view_View_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/view/View;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_view_View_, __args);
			} finally {
			}
		}

		static Delegate cb_getBadgeBackgroundColor;
#pragma warning disable 0169
		static Delegate GetGetBadgeBackgroundColorHandler ()
		{
			if (cb_getBadgeBackgroundColor == null)
				cb_getBadgeBackgroundColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBadgeBackgroundColor);
			return cb_getBadgeBackgroundColor;
		}

		static int n_GetBadgeBackgroundColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BadgeBackgroundColor;
		}
#pragma warning restore 0169

		static Delegate cb_setBadgeBackgroundColor_I;
#pragma warning disable 0169
		static Delegate GetSetBadgeBackgroundColor_IHandler ()
		{
			if (cb_setBadgeBackgroundColor_I == null)
				cb_setBadgeBackgroundColor_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBadgeBackgroundColor_I);
			return cb_setBadgeBackgroundColor_I;
		}

		static void n_SetBadgeBackgroundColor_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.BadgeBackgroundColor = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBadgeBackgroundColor;
		static IntPtr id_setBadgeBackgroundColor_I;
		public virtual unsafe int BadgeBackgroundColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='getBadgeBackgroundColor' and count(parameter)=0]"
			[Register ("getBadgeBackgroundColor", "()I", "GetGetBadgeBackgroundColorHandler")]
			get {
				if (id_getBadgeBackgroundColor == IntPtr.Zero)
					id_getBadgeBackgroundColor = JNIEnv.GetMethodID (class_ref, "getBadgeBackgroundColor", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBadgeBackgroundColor);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBadgeBackgroundColor", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='setBadgeBackgroundColor' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBadgeBackgroundColor", "(I)V", "GetSetBadgeBackgroundColor_IHandler")]
			set {
				if (id_setBadgeBackgroundColor_I == IntPtr.Zero)
					id_setBadgeBackgroundColor_I = JNIEnv.GetMethodID (class_ref, "setBadgeBackgroundColor", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBadgeBackgroundColor_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBadgeBackgroundColor", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getBadgePosition;
#pragma warning disable 0169
		static Delegate GetGetBadgePositionHandler ()
		{
			if (cb_getBadgePosition == null)
				cb_getBadgePosition = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBadgePosition);
			return cb_getBadgePosition;
		}

		static int n_GetBadgePosition (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.BadgePosition;
		}
#pragma warning restore 0169

		static Delegate cb_setBadgePosition_I;
#pragma warning disable 0169
		static Delegate GetSetBadgePosition_IHandler ()
		{
			if (cb_setBadgePosition_I == null)
				cb_setBadgePosition_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBadgePosition_I);
			return cb_setBadgePosition_I;
		}

		static void n_SetBadgePosition_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.BadgePosition = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBadgePosition;
		static IntPtr id_setBadgePosition_I;
		public virtual unsafe int BadgePosition {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='getBadgePosition' and count(parameter)=0]"
			[Register ("getBadgePosition", "()I", "GetGetBadgePositionHandler")]
			get {
				if (id_getBadgePosition == IntPtr.Zero)
					id_getBadgePosition = JNIEnv.GetMethodID (class_ref, "getBadgePosition", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBadgePosition);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBadgePosition", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='setBadgePosition' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBadgePosition", "(I)V", "GetSetBadgePosition_IHandler")]
			set {
				if (id_setBadgePosition_I == IntPtr.Zero)
					id_setBadgePosition_I = JNIEnv.GetMethodID (class_ref, "setBadgePosition", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBadgePosition_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBadgePosition", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getHorizontalBadgeMargin;
#pragma warning disable 0169
		static Delegate GetGetHorizontalBadgeMarginHandler ()
		{
			if (cb_getHorizontalBadgeMargin == null)
				cb_getHorizontalBadgeMargin = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetHorizontalBadgeMargin);
			return cb_getHorizontalBadgeMargin;
		}

		static int n_GetHorizontalBadgeMargin (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HorizontalBadgeMargin;
		}
#pragma warning restore 0169

		static IntPtr id_getHorizontalBadgeMargin;
		public virtual unsafe int HorizontalBadgeMargin {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='getHorizontalBadgeMargin' and count(parameter)=0]"
			[Register ("getHorizontalBadgeMargin", "()I", "GetGetHorizontalBadgeMarginHandler")]
			get {
				if (id_getHorizontalBadgeMargin == IntPtr.Zero)
					id_getHorizontalBadgeMargin = JNIEnv.GetMethodID (class_ref, "getHorizontalBadgeMargin", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getHorizontalBadgeMargin);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getHorizontalBadgeMargin", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_getTarget;
#pragma warning disable 0169
		static Delegate GetGetTargetHandler ()
		{
			if (cb_getTarget == null)
				cb_getTarget = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTarget);
			return cb_getTarget;
		}

		static IntPtr n_GetTarget (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Target);
		}
#pragma warning restore 0169

		static IntPtr id_getTarget;
		public virtual unsafe global::Android.Views.View Target {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='getTarget' and count(parameter)=0]"
			[Register ("getTarget", "()Landroid/view/View;", "GetGetTargetHandler")]
			get {
				if (id_getTarget == IntPtr.Zero)
					id_getTarget = JNIEnv.GetMethodID (class_ref, "getTarget", "()Landroid/view/View;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTarget), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTarget", "()Landroid/view/View;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getVerticalBadgeMargin;
#pragma warning disable 0169
		static Delegate GetGetVerticalBadgeMarginHandler ()
		{
			if (cb_getVerticalBadgeMargin == null)
				cb_getVerticalBadgeMargin = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetVerticalBadgeMargin);
			return cb_getVerticalBadgeMargin;
		}

		static int n_GetVerticalBadgeMargin (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.VerticalBadgeMargin;
		}
#pragma warning restore 0169

		static IntPtr id_getVerticalBadgeMargin;
		public virtual unsafe int VerticalBadgeMargin {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='getVerticalBadgeMargin' and count(parameter)=0]"
			[Register ("getVerticalBadgeMargin", "()I", "GetGetVerticalBadgeMarginHandler")]
			get {
				if (id_getVerticalBadgeMargin == IntPtr.Zero)
					id_getVerticalBadgeMargin = JNIEnv.GetMethodID (class_ref, "getVerticalBadgeMargin", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getVerticalBadgeMargin);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getVerticalBadgeMargin", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_decrement_I;
#pragma warning disable 0169
		static Delegate GetDecrement_IHandler ()
		{
			if (cb_decrement_I == null)
				cb_decrement_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_Decrement_I);
			return cb_decrement_I;
		}

		static int n_Decrement_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Decrement (p0);
		}
#pragma warning restore 0169

		static IntPtr id_decrement_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='decrement' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("decrement", "(I)I", "GetDecrement_IHandler")]
		public virtual unsafe int Decrement (int p0)
		{
			if (id_decrement_I == IntPtr.Zero)
				id_decrement_I = JNIEnv.GetMethodID (class_ref, "decrement", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_decrement_I, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "decrement", "(I)I"), __args);
			} finally {
			}
		}

		static Delegate cb_hide;
#pragma warning disable 0169
		static Delegate GetHideHandler ()
		{
			if (cb_hide == null)
				cb_hide = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Hide);
			return cb_hide;
		}

		static void n_Hide (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Hide ();
		}
#pragma warning restore 0169

		static IntPtr id_hide;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='hide' and count(parameter)=0]"
		[Register ("hide", "()V", "GetHideHandler")]
		public virtual unsafe void Hide ()
		{
			if (id_hide == IntPtr.Zero)
				id_hide = JNIEnv.GetMethodID (class_ref, "hide", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_hide);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "hide", "()V"));
			} finally {
			}
		}

		static Delegate cb_hide_Landroid_view_animation_Animation_;
#pragma warning disable 0169
		static Delegate GetHide_Landroid_view_animation_Animation_Handler ()
		{
			if (cb_hide_Landroid_view_animation_Animation_ == null)
				cb_hide_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Hide_Landroid_view_animation_Animation_);
			return cb_hide_Landroid_view_animation_Animation_;
		}

		static void n_Hide_Landroid_view_animation_Animation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.Animations.Animation p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Animations.Animation> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Hide (p0);
		}
#pragma warning restore 0169

		static IntPtr id_hide_Landroid_view_animation_Animation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='hide' and count(parameter)=1 and parameter[1][@type='android.view.animation.Animation']]"
		[Register ("hide", "(Landroid/view/animation/Animation;)V", "GetHide_Landroid_view_animation_Animation_Handler")]
		public virtual unsafe void Hide (global::Android.Views.Animations.Animation p0)
		{
			if (id_hide_Landroid_view_animation_Animation_ == IntPtr.Zero)
				id_hide_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID (class_ref, "hide", "(Landroid/view/animation/Animation;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_hide_Landroid_view_animation_Animation_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "hide", "(Landroid/view/animation/Animation;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_hide_Z;
#pragma warning disable 0169
		static Delegate GetHide_ZHandler ()
		{
			if (cb_hide_Z == null)
				cb_hide_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_Hide_Z);
			return cb_hide_Z;
		}

		static void n_Hide_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Hide (p0);
		}
#pragma warning restore 0169

		static IntPtr id_hide_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='hide' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("hide", "(Z)V", "GetHide_ZHandler")]
		public virtual unsafe void Hide (bool p0)
		{
			if (id_hide_Z == IntPtr.Zero)
				id_hide_Z = JNIEnv.GetMethodID (class_ref, "hide", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_hide_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "hide", "(Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_increment_I;
#pragma warning disable 0169
		static Delegate GetIncrement_IHandler ()
		{
			if (cb_increment_I == null)
				cb_increment_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_Increment_I);
			return cb_increment_I;
		}

		static int n_Increment_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Increment (p0);
		}
#pragma warning restore 0169

		static IntPtr id_increment_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='increment' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("increment", "(I)I", "GetIncrement_IHandler")]
		public virtual unsafe int Increment (int p0)
		{
			if (id_increment_I == IntPtr.Zero)
				id_increment_I = JNIEnv.GetMethodID (class_ref, "increment", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_increment_I, __args);
				else
					return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "increment", "(I)I"), __args);
			} finally {
			}
		}

		static Delegate cb_setBadgeMargin_I;
#pragma warning disable 0169
		static Delegate GetSetBadgeMargin_IHandler ()
		{
			if (cb_setBadgeMargin_I == null)
				cb_setBadgeMargin_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBadgeMargin_I);
			return cb_setBadgeMargin_I;
		}

		static void n_SetBadgeMargin_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetBadgeMargin (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setBadgeMargin_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='setBadgeMargin' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setBadgeMargin", "(I)V", "GetSetBadgeMargin_IHandler")]
		public virtual unsafe void SetBadgeMargin (int p0)
		{
			if (id_setBadgeMargin_I == IntPtr.Zero)
				id_setBadgeMargin_I = JNIEnv.GetMethodID (class_ref, "setBadgeMargin", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBadgeMargin_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBadgeMargin", "(I)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setBadgeMargin_II;
#pragma warning disable 0169
		static Delegate GetSetBadgeMargin_IIHandler ()
		{
			if (cb_setBadgeMargin_II == null)
				cb_setBadgeMargin_II = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, int>) n_SetBadgeMargin_II);
			return cb_setBadgeMargin_II;
		}

		static void n_SetBadgeMargin_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetBadgeMargin (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_setBadgeMargin_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='setBadgeMargin' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("setBadgeMargin", "(II)V", "GetSetBadgeMargin_IIHandler")]
		public virtual unsafe void SetBadgeMargin (int p0, int p1)
		{
			if (id_setBadgeMargin_II == IntPtr.Zero)
				id_setBadgeMargin_II = JNIEnv.GetMethodID (class_ref, "setBadgeMargin", "(II)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBadgeMargin_II, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBadgeMargin", "(II)V"), __args);
			} finally {
			}
		}

		static Delegate cb_show;
#pragma warning disable 0169
		static Delegate GetShowHandler ()
		{
			if (cb_show == null)
				cb_show = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Show);
			return cb_show;
		}

		static void n_Show (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Show ();
		}
#pragma warning restore 0169

		static IntPtr id_show;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='show' and count(parameter)=0]"
		[Register ("show", "()V", "GetShowHandler")]
		public virtual unsafe void Show ()
		{
			if (id_show == IntPtr.Zero)
				id_show = JNIEnv.GetMethodID (class_ref, "show", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_show);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "show", "()V"));
			} finally {
			}
		}

		static Delegate cb_show_Landroid_view_animation_Animation_;
#pragma warning disable 0169
		static Delegate GetShow_Landroid_view_animation_Animation_Handler ()
		{
			if (cb_show_Landroid_view_animation_Animation_ == null)
				cb_show_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Show_Landroid_view_animation_Animation_);
			return cb_show_Landroid_view_animation_Animation_;
		}

		static void n_Show_Landroid_view_animation_Animation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.Animations.Animation p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Animations.Animation> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Show (p0);
		}
#pragma warning restore 0169

		static IntPtr id_show_Landroid_view_animation_Animation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='show' and count(parameter)=1 and parameter[1][@type='android.view.animation.Animation']]"
		[Register ("show", "(Landroid/view/animation/Animation;)V", "GetShow_Landroid_view_animation_Animation_Handler")]
		public virtual unsafe void Show (global::Android.Views.Animations.Animation p0)
		{
			if (id_show_Landroid_view_animation_Animation_ == IntPtr.Zero)
				id_show_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID (class_ref, "show", "(Landroid/view/animation/Animation;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_show_Landroid_view_animation_Animation_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "show", "(Landroid/view/animation/Animation;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_show_Z;
#pragma warning disable 0169
		static Delegate GetShow_ZHandler ()
		{
			if (cb_show_Z == null)
				cb_show_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_Show_Z);
			return cb_show_Z;
		}

		static void n_Show_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Show (p0);
		}
#pragma warning restore 0169

		static IntPtr id_show_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='show' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("show", "(Z)V", "GetShow_ZHandler")]
		public virtual unsafe void Show (bool p0)
		{
			if (id_show_Z == IntPtr.Zero)
				id_show_Z = JNIEnv.GetMethodID (class_ref, "show", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_show_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "show", "(Z)V"), __args);
			} finally {
			}
		}

		static Delegate cb_toggle;
#pragma warning disable 0169
		static Delegate GetToggleHandler ()
		{
			if (cb_toggle == null)
				cb_toggle = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Toggle);
			return cb_toggle;
		}

		static void n_Toggle (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Toggle ();
		}
#pragma warning restore 0169

		static IntPtr id_toggle;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='toggle' and count(parameter)=0]"
		[Register ("toggle", "()V", "GetToggleHandler")]
		public virtual unsafe void Toggle ()
		{
			if (id_toggle == IntPtr.Zero)
				id_toggle = JNIEnv.GetMethodID (class_ref, "toggle", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggle);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggle", "()V"));
			} finally {
			}
		}

		static Delegate cb_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_;
#pragma warning disable 0169
		static Delegate GetToggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_Handler ()
		{
			if (cb_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_ == null)
				cb_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_);
			return cb_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_;
		}

		static void n_Toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.Animations.Animation p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Animations.Animation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.Animations.Animation p1 = global::Java.Lang.Object.GetObject<global::Android.Views.Animations.Animation> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Toggle (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='toggle' and count(parameter)=2 and parameter[1][@type='android.view.animation.Animation'] and parameter[2][@type='android.view.animation.Animation']]"
		[Register ("toggle", "(Landroid/view/animation/Animation;Landroid/view/animation/Animation;)V", "GetToggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_Handler")]
		public virtual unsafe void Toggle (global::Android.Views.Animations.Animation p0, global::Android.Views.Animations.Animation p1)
		{
			if (id_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_ == IntPtr.Zero)
				id_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_ = JNIEnv.GetMethodID (class_ref, "toggle", "(Landroid/view/animation/Animation;Landroid/view/animation/Animation;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggle_Landroid_view_animation_Animation_Landroid_view_animation_Animation_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggle", "(Landroid/view/animation/Animation;Landroid/view/animation/Animation;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_toggle_Z;
#pragma warning disable 0169
		static Delegate GetToggle_ZHandler ()
		{
			if (cb_toggle_Z == null)
				cb_toggle_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_Toggle_Z);
			return cb_toggle_Z;
		}

		static void n_Toggle_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Inscripts.Custom.BadgeView __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.BadgeView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Toggle (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggle_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.custom']/class[@name='BadgeView']/method[@name='toggle' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("toggle", "(Z)V", "GetToggle_ZHandler")]
		public virtual unsafe void Toggle (bool p0)
		{
			if (id_toggle_Z == IntPtr.Zero)
				id_toggle_Z = JNIEnv.GetMethodID (class_ref, "toggle", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggle_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggle", "(Z)V"), __args);
			} finally {
			}
		}

	}
}
