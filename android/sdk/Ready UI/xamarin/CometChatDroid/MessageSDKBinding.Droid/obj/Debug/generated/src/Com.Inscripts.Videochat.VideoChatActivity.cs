using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Videochat {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='VideoChatActivity']"
	[global::Android.Runtime.Register ("com/inscripts/videochat/VideoChatActivity", DoNotGenerateAcw=true)]
	public partial class VideoChatActivity : global::Android.App.Activity, global::Android.Views.View.IOnClickListener {


		static IntPtr videoChatActivity_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='VideoChatActivity']/field[@name='videoChatActivity']"
		[Register ("videoChatActivity")]
		public static global::Com.Inscripts.Videochat.VideoChatActivity Activity {
			get {
				if (videoChatActivity_jfieldId == IntPtr.Zero)
					videoChatActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "videoChatActivity", "Lcom/inscripts/videochat/VideoChatActivity;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, videoChatActivity_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.VideoChatActivity> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (videoChatActivity_jfieldId == IntPtr.Zero)
					videoChatActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "videoChatActivity", "Lcom/inscripts/videochat/VideoChatActivity;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, videoChatActivity_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/videochat/VideoChatActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (VideoChatActivity); }
		}

		protected VideoChatActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='VideoChatActivity']/constructor[@name='VideoChatActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe VideoChatActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (VideoChatActivity)) {
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

		static Delegate cb_endcall;
#pragma warning disable 0169
		static Delegate GetEndcallHandler ()
		{
			if (cb_endcall == null)
				cb_endcall = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Endcall);
			return cb_endcall;
		}

		static void n_Endcall (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Videochat.VideoChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.VideoChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Endcall ();
		}
#pragma warning restore 0169

		static IntPtr id_endcall;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='VideoChatActivity']/method[@name='endcall' and count(parameter)=0]"
		[Register ("endcall", "()V", "GetEndcallHandler")]
		public virtual unsafe void Endcall ()
		{
			if (id_endcall == IntPtr.Zero)
				id_endcall = JNIEnv.GetMethodID (class_ref, "endcall", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_endcall);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "endcall", "()V"));
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
			global::Com.Inscripts.Videochat.VideoChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Videochat.VideoChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnClick (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onClick_Landroid_view_View_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.videochat']/class[@name='VideoChatActivity']/method[@name='onClick' and count(parameter)=1 and parameter[1][@type='android.view.View']]"
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
}
