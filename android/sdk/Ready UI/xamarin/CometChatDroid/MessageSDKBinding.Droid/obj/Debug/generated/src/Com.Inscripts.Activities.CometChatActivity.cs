using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/CometChatActivity", DoNotGenerateAcw=true)]
	public partial class CometChatActivity : global::Com.Inscripts.Utils.CustomActivity {


		static IntPtr tabActivity_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/field[@name='tabActivity']"
		[Register ("tabActivity")]
		public static global::Com.Inscripts.Activities.CometChatActivity TabActivity {
			get {
				if (tabActivity_jfieldId == IntPtr.Zero)
					tabActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "tabActivity", "Lcom/inscripts/activities/CometChatActivity;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, tabActivity_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.CometChatActivity> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (tabActivity_jfieldId == IntPtr.Zero)
					tabActivity_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "tabActivity", "Lcom/inscripts/activities/CometChatActivity;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, tabActivity_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/CometChatActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CometChatActivity); }
		}

		protected CometChatActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/constructor[@name='CometChatActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe CometChatActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (CometChatActivity)) {
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

		static Delegate cb_handleIntent_Landroid_content_Context_Landroid_content_Intent_;
#pragma warning disable 0169
		static Delegate GetHandleIntent_Landroid_content_Context_Landroid_content_Intent_Handler ()
		{
			if (cb_handleIntent_Landroid_content_Context_Landroid_content_Intent_ == null)
				cb_handleIntent_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_HandleIntent_Landroid_content_Context_Landroid_content_Intent_);
			return cb_handleIntent_Landroid_content_Context_Landroid_content_Intent_;
		}

		static void n_HandleIntent_Landroid_content_Context_Landroid_content_Intent_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Inscripts.Activities.CometChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.CometChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Intent p1 = global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.HandleIntent (p0, p1);
		}
#pragma warning restore 0169

		static IntPtr id_handleIntent_Landroid_content_Context_Landroid_content_Intent_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/method[@name='handleIntent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.content.Intent']]"
		[Register ("handleIntent", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetHandleIntent_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public virtual unsafe void HandleIntent (global::Android.Content.Context p0, global::Android.Content.Intent p1)
		{
			if (id_handleIntent_Landroid_content_Context_Landroid_content_Intent_ == IntPtr.Zero)
				id_handleIntent_Landroid_content_Context_Landroid_content_Intent_ = JNIEnv.GetMethodID (class_ref, "handleIntent", "(Landroid/content/Context;Landroid/content/Intent;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_handleIntent_Landroid_content_Context_Landroid_content_Intent_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "handleIntent", "(Landroid/content/Context;Landroid/content/Intent;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onNewIntent_Landroid_content_Intent_;
#pragma warning disable 0169
		static Delegate GetOnNewIntent_Landroid_content_Intent_Handler ()
		{
			if (cb_onNewIntent_Landroid_content_Intent_ == null)
				cb_onNewIntent_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnNewIntent_Landroid_content_Intent_);
			return cb_onNewIntent_Landroid_content_Intent_;
		}

		static void n_OnNewIntent_Landroid_content_Intent_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Activities.CometChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.CometChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Intent p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnNewIntent (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onNewIntent_Landroid_content_Intent_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/method[@name='onNewIntent' and count(parameter)=1 and parameter[1][@type='android.content.Intent']]"
		[Register ("onNewIntent", "(Landroid/content/Intent;)V", "GetOnNewIntent_Landroid_content_Intent_Handler")]
		public virtual unsafe void OnNewIntent (global::Android.Content.Intent p0)
		{
			if (id_onNewIntent_Landroid_content_Intent_ == IntPtr.Zero)
				id_onNewIntent_Landroid_content_Intent_ = JNIEnv.GetMethodID (class_ref, "onNewIntent", "(Landroid/content/Intent;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onNewIntent_Landroid_content_Intent_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onNewIntent", "(Landroid/content/Intent;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onStart;
#pragma warning disable 0169
		static Delegate GetOnStartHandler ()
		{
			if (cb_onStart == null)
				cb_onStart = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnStart);
			return cb_onStart;
		}

		static void n_OnStart (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Activities.CometChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.CometChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnStart ();
		}
#pragma warning restore 0169

		static IntPtr id_onStart;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/method[@name='onStart' and count(parameter)=0]"
		[Register ("onStart", "()V", "GetOnStartHandler")]
		public virtual unsafe void OnStart ()
		{
			if (id_onStart == IntPtr.Zero)
				id_onStart = JNIEnv.GetMethodID (class_ref, "onStart", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onStart);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onStart", "()V"));
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
			global::Com.Inscripts.Activities.CometChatActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.CometChatActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnStop ();
		}
#pragma warning restore 0169

		static IntPtr id_onStop;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='CometChatActivity']/method[@name='onStop' and count(parameter)=0]"
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
