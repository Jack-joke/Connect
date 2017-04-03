using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='InviteViaSmsActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/InviteViaSmsActivity", DoNotGenerateAcw=true)]
	public partial class InviteViaSmsActivity : global::Com.Inscripts.Utils.SuperActivity {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/InviteViaSmsActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (InviteViaSmsActivity); }
		}

		protected InviteViaSmsActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='InviteViaSmsActivity']/constructor[@name='InviteViaSmsActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe InviteViaSmsActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (InviteViaSmsActivity)) {
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

		static Delegate cb_onTokenAdded_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetOnTokenAdded_Ljava_lang_Object_Handler ()
		{
			if (cb_onTokenAdded_Ljava_lang_Object_ == null)
				cb_onTokenAdded_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnTokenAdded_Ljava_lang_Object_);
			return cb_onTokenAdded_Ljava_lang_Object_;
		}

		static void n_OnTokenAdded_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Activities.InviteViaSmsActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.InviteViaSmsActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnTokenAdded (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onTokenAdded_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='InviteViaSmsActivity']/method[@name='onTokenAdded' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("onTokenAdded", "(Ljava/lang/Object;)V", "GetOnTokenAdded_Ljava_lang_Object_Handler")]
		public virtual unsafe void OnTokenAdded (global::Java.Lang.Object p0)
		{
			if (id_onTokenAdded_Ljava_lang_Object_ == IntPtr.Zero)
				id_onTokenAdded_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "onTokenAdded", "(Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onTokenAdded_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onTokenAdded", "(Ljava/lang/Object;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onTokenRemoved_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetOnTokenRemoved_Ljava_lang_Object_Handler ()
		{
			if (cb_onTokenRemoved_Ljava_lang_Object_ == null)
				cb_onTokenRemoved_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnTokenRemoved_Ljava_lang_Object_);
			return cb_onTokenRemoved_Ljava_lang_Object_;
		}

		static void n_OnTokenRemoved_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Activities.InviteViaSmsActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.InviteViaSmsActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnTokenRemoved (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onTokenRemoved_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='InviteViaSmsActivity']/method[@name='onTokenRemoved' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("onTokenRemoved", "(Ljava/lang/Object;)V", "GetOnTokenRemoved_Ljava_lang_Object_Handler")]
		public virtual unsafe void OnTokenRemoved (global::Java.Lang.Object p0)
		{
			if (id_onTokenRemoved_Ljava_lang_Object_ == IntPtr.Zero)
				id_onTokenRemoved_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "onTokenRemoved", "(Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onTokenRemoved_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onTokenRemoved", "(Ljava/lang/Object;)V"), __args);
			} finally {
			}
		}

	}
}
