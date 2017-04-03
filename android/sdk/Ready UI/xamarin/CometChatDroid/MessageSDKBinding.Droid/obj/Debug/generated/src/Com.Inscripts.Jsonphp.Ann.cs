using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Ann']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Ann", DoNotGenerateAcw=true)]
	public partial class Ann : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Ann", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Ann); }
		}

		protected Ann (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Ann']/constructor[@name='Ann' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Ann ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Ann)) {
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

		static Delegate cb_getReadLess;
#pragma warning disable 0169
		static Delegate GetGetReadLessHandler ()
		{
			if (cb_getReadLess == null)
				cb_getReadLess = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReadLess);
			return cb_getReadLess;
		}

		static IntPtr n_GetReadLess (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Ann __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ReadLess);
		}
#pragma warning restore 0169

		static IntPtr id_getReadLess;
		public virtual unsafe string ReadLess {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Ann']/method[@name='getReadLess' and count(parameter)=0]"
			[Register ("getReadLess", "()Ljava/lang/String;", "GetGetReadLessHandler")]
			get {
				if (id_getReadLess == IntPtr.Zero)
					id_getReadLess = JNIEnv.GetMethodID (class_ref, "getReadLess", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReadLess), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReadLess", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getReadMore;
#pragma warning disable 0169
		static Delegate GetGetReadMoreHandler ()
		{
			if (cb_getReadMore == null)
				cb_getReadMore = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetReadMore);
			return cb_getReadMore;
		}

		static IntPtr n_GetReadMore (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Ann __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ReadMore);
		}
#pragma warning restore 0169

		static IntPtr id_getReadMore;
		public virtual unsafe string ReadMore {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Ann']/method[@name='getReadMore' and count(parameter)=0]"
			[Register ("getReadMore", "()Ljava/lang/String;", "GetGetReadMoreHandler")]
			get {
				if (id_getReadMore == IntPtr.Zero)
					id_getReadMore = JNIEnv.GetMethodID (class_ref, "getReadMore", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReadMore), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getReadMore", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getTabText;
#pragma warning disable 0169
		static Delegate GetGetTabTextHandler ()
		{
			if (cb_getTabText == null)
				cb_getTabText = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTabText);
			return cb_getTabText;
		}

		static IntPtr n_GetTabText (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Ann __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Ann> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.TabText);
		}
#pragma warning restore 0169

		static IntPtr id_getTabText;
		public virtual unsafe string TabText {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Ann']/method[@name='getTabText' and count(parameter)=0]"
			[Register ("getTabText", "()Ljava/lang/String;", "GetGetTabTextHandler")]
			get {
				if (id_getTabText == IntPtr.Zero)
					id_getTabText = JNIEnv.GetMethodID (class_ref, "getTabText", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTabText), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTabText", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
