using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SugarContext']"
	[global::Android.Runtime.Register ("com/orm/SugarContext", DoNotGenerateAcw=true)]
	public partial class SugarContext : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/SugarContext", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarContext); }
		}

		protected SugarContext (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_getSugarDb;
#pragma warning disable 0169
		static Delegate GetGetSugarDbHandler ()
		{
			if (cb_getSugarDb == null)
				cb_getSugarDb = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetSugarDb);
			return cb_getSugarDb;
		}

		static IntPtr n_GetSugarDb (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.SugarContext __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarContext> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.SugarDb);
		}
#pragma warning restore 0169

		static IntPtr id_getSugarDb;
		protected virtual unsafe global::Com.Orm.SugarDb SugarDb {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarContext']/method[@name='getSugarDb' and count(parameter)=0]"
			[Register ("getSugarDb", "()Lcom/orm/SugarDb;", "GetGetSugarDbHandler")]
			get {
				if (id_getSugarDb == IntPtr.Zero)
					id_getSugarDb = JNIEnv.GetMethodID (class_ref, "getSugarDb", "()Lcom/orm/SugarDb;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Com.Orm.SugarDb> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSugarDb), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Com.Orm.SugarDb> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSugarDb", "()Lcom/orm/SugarDb;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getSugarContext;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarContext']/method[@name='getSugarContext' and count(parameter)=0]"
		[Register ("getSugarContext", "()Lcom/orm/SugarContext;", "")]
		public static unsafe global::Com.Orm.SugarContext GetSugarContext ()
		{
			if (id_getSugarContext == IntPtr.Zero)
				id_getSugarContext = JNIEnv.GetStaticMethodID (class_ref, "getSugarContext", "()Lcom/orm/SugarContext;");
			try {
				return global::Java.Lang.Object.GetObject<global::Com.Orm.SugarContext> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getSugarContext), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_init_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarContext']/method[@name='init' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("init", "(Landroid/content/Context;)V", "")]
		public static unsafe void Init (global::Android.Content.Context p0)
		{
			if (id_init_Landroid_content_Context_ == IntPtr.Zero)
				id_init_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "init", "(Landroid/content/Context;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_init_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static IntPtr id_terminate;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarContext']/method[@name='terminate' and count(parameter)=0]"
		[Register ("terminate", "()V", "")]
		public static unsafe void Terminate ()
		{
			if (id_terminate == IntPtr.Zero)
				id_terminate = JNIEnv.GetStaticMethodID (class_ref, "terminate", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_terminate);
			} finally {
			}
		}

	}
}
