using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Crstyles']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/Crstyles", DoNotGenerateAcw=true)]
	public partial class Crstyles : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/Crstyles", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Crstyles); }
		}

		protected Crstyles (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Crstyles']/constructor[@name='Crstyles' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Crstyles ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Crstyles)) {
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

		static Delegate cb_getTextcolor;
#pragma warning disable 0169
		static Delegate GetGetTextcolorHandler ()
		{
			if (cb_getTextcolor == null)
				cb_getTextcolor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTextcolor);
			return cb_getTextcolor;
		}

		static IntPtr n_GetTextcolor (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.Crstyles __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.Crstyles> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList.ToLocalJniHandle (__this.Textcolor);
		}
#pragma warning restore 0169

		static IntPtr id_getTextcolor;
		public virtual unsafe global::System.Collections.IList Textcolor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='Crstyles']/method[@name='getTextcolor' and count(parameter)=0]"
			[Register ("getTextcolor", "()Ljava/util/ArrayList;", "GetGetTextcolorHandler")]
			get {
				if (id_getTextcolor == IntPtr.Zero)
					id_getTextcolor = JNIEnv.GetMethodID (class_ref, "getTextcolor", "()Ljava/util/ArrayList;");
				try {

					if (GetType () == ThresholdType)
						return global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTextcolor), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTextcolor", "()Ljava/util/ArrayList;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
