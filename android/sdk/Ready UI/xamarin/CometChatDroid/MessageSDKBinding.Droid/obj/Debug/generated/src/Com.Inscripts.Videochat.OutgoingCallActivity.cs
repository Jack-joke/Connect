using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Videochat {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='OutgoingCallActivity']"
	[global::Android.Runtime.Register ("com/inscripts/videochat/OutgoingCallActivity", DoNotGenerateAcw=true)]
	public partial class OutgoingCallActivity : global::Android.App.Activity, global::Android.Views.View.IOnClickListener {


		static IntPtr outgoingCallActivity_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='OutgoingCallActivity']/field[@name='outgoingCallActivity']"
		[Register ("outgoingCallActivity")]
		public static global::Com.Inscripts.Videochat.OutgoingCallActivity OutCallActivity {
			get {
				if (outgoingCallActivity_jfieldId == IntPtr.Zero)
					outgoingCallActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "outgoingCallActivity", "Lcom/inscripts/videochat/OutgoingCallActivity;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, outgoingCallActivity_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.OutgoingCallActivity> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (outgoingCallActivity_jfieldId == IntPtr.Zero)
					outgoingCallActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "outgoingCallActivity", "Lcom/inscripts/videochat/OutgoingCallActivity;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, outgoingCallActivity_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/videochat/OutgoingCallActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OutgoingCallActivity); }
		}

		protected OutgoingCallActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='OutgoingCallActivity']/constructor[@name='OutgoingCallActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe OutgoingCallActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (OutgoingCallActivity)) {
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
			global::Com.Inscripts.Videochat.OutgoingCallActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.OutgoingCallActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnClick (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onClick_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='OutgoingCallActivity']/method[@name='onClick' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
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

		static Delegate cb_onStop;
#pragma warning disable 0169
		static Delegate GetOnStopHandler ()
		{
			if (cb_onStop == null)
				cb_onStop = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnStop);
			return cb_onStop;
		}

		static void n_OnStop (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Videochat.OutgoingCallActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.OutgoingCallActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnStop ();
		}
#pragma warning restore 0169

		static IntPtr id_onStop;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='OutgoingCallActivity']/method[@name='onStop' and count(parameter)=0]"
		[Register ("onStop", "()V", "GetOnStopHandler")]
		public virtual unsafe void OnStop ()
		{
			if (id_onStop == IntPtr.Zero)
				id_onStop = JNIEnv.GetMethodID (class_ref, "onStop", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStop);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onStop", "()V"));
			} finally {
			}
		}

	}
}
