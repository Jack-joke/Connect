using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/LoginActivity", DoNotGenerateAcw=true)]
	public partial class LoginActivity : global::Com.Inscripts.Utils.SuperActivity {


		static IntPtr showAnimation_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']/field[@name='showAnimation']"
		[Register ("showAnimation")]
		public static bool ShowAnimation {
			get {
				if (showAnimation_jfieldId == IntPtr.Zero)
					showAnimation_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "showAnimation", "Z");
				return JNIEnv.GetStaticBooleanField (class_ref, showAnimation_jfieldId);
			}
			set {
				if (showAnimation_jfieldId == IntPtr.Zero)
					showAnimation_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "showAnimation", "Z");
				try {
					JNIEnv.SetStaticField (class_ref, showAnimation_jfieldId, value);
				} finally {
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/LoginActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LoginActivity); }
		}

		protected LoginActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']/constructor[@name='LoginActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe LoginActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (LoginActivity)) {
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

		static Delegate cb_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetPerformAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler ()
		{
			if (cb_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == null)
				cb_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_PerformAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_);
			return cb_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		}

		static void n_PerformAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Com.Inscripts.Activities.LoginActivity __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.LoginActivity> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			__this.PerformAppLogin (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']/method[@name='performAppLogin' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String']]"
		[Register ("performAppLogin", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetPerformAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler")]
		public virtual unsafe void PerformAppLogin (string p0, string p1, string p2)
		{
			if (id_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "performAppLogin", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_performAppLogin_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "performAppLogin", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static IntPtr id_removeExistingData;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']/method[@name='removeExistingData' and count(parameter)=0]"
		[Register ("removeExistingData", "()V", "")]
		public static unsafe void RemoveExistingData ()
		{
			if (id_removeExistingData == IntPtr.Zero)
				id_removeExistingData = JNIEnv.GetStaticMethodID (class_ref, "removeExistingData", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_removeExistingData);
			} finally {
			}
		}

		static IntPtr id_showVersionErrorPopUp_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='LoginActivity']/method[@name='showVersionErrorPopUp' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("showVersionErrorPopUp", "(Landroid/content/Context;)V", "")]
		public static unsafe void ShowVersionErrorPopUp (global::Android.Content.Context p0)
		{
			if (id_showVersionErrorPopUp_Landroid_content_Context_ == IntPtr.Zero)
				id_showVersionErrorPopUp_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "showVersionErrorPopUp", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showVersionErrorPopUp_Landroid_content_Context_, __args);
			} finally {
			}
		}

	}
}
