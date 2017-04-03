using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Avp8 {

	// Metadata.xml XPath class reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']"
	[global::Android.Runtime.Register ("avp8/HardwareDecoder", DoNotGenerateAcw=true)]
	public partial class HardwareDecoder : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("avp8/HardwareDecoder", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HardwareDecoder); }
		}

		protected HardwareDecoder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/constructor[@name='HardwareDecoder' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HardwareDecoder ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HardwareDecoder)) {
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

		static IntPtr id_getCodecInfo;
		public static unsafe global::Android.Media.MediaCodecInfo CodecInfo {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='getCodecInfo' and count(parameter)=0]"
			[Register ("getCodecInfo", "()Landroid/media/MediaCodecInfo;", "GetGetCodecInfoHandler")]
			get {
				if (id_getCodecInfo == IntPtr.Zero)
					id_getCodecInfo = JNIEnv.GetStaticMethodID (class_ref, "getCodecInfo", "()Landroid/media/MediaCodecInfo;");
				try {
					return global::Java.Lang.Object.GetObject<global::Android.Media.MediaCodecInfo> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCodecInfo), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getCodecName;
#pragma warning disable 0169
		static Delegate GetGetCodecNameHandler ()
		{
			if (cb_getCodecName == null)
				cb_getCodecName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCodecName);
			return cb_getCodecName;
		}

		static IntPtr n_GetCodecName (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareDecoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareDecoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CodecName);
		}
#pragma warning restore 0169

		static IntPtr id_getCodecName;
		public virtual unsafe string CodecName {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='getCodecName' and count(parameter)=0]"
			[Register ("getCodecName", "()Ljava/lang/String;", "GetGetCodecNameHandler")]
			get {
				if (id_getCodecName == IntPtr.Zero)
					id_getCodecName = JNIEnv.GetMethodID (class_ref, "getCodecName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCodecName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCodecName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getNeedsKeyFrame;
#pragma warning disable 0169
		static Delegate GetGetNeedsKeyFrameHandler ()
		{
			if (cb_getNeedsKeyFrame == null)
				cb_getNeedsKeyFrame = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_GetNeedsKeyFrame);
			return cb_getNeedsKeyFrame;
		}

		static bool n_GetNeedsKeyFrame (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareDecoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareDecoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.NeedsKeyFrame;
		}
#pragma warning restore 0169

		static IntPtr id_getNeedsKeyFrame;
		public virtual unsafe bool NeedsKeyFrame {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='getNeedsKeyFrame' and count(parameter)=0]"
			[Register ("getNeedsKeyFrame", "()Z", "GetGetNeedsKeyFrameHandler")]
			get {
				if (id_getNeedsKeyFrame == IntPtr.Zero)
					id_getNeedsKeyFrame = JNIEnv.GetMethodID (class_ref, "getNeedsKeyFrame", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getNeedsKeyFrame);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getNeedsKeyFrame", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_destroy;
#pragma warning disable 0169
		static Delegate GetDestroyHandler ()
		{
			if (cb_destroy == null)
				cb_destroy = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Destroy);
			return cb_destroy;
		}

		static void n_Destroy (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareDecoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareDecoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Destroy ();
		}
#pragma warning restore 0169

		static IntPtr id_destroy;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='destroy' and count(parameter)=0]"
		[Register ("destroy", "()V", "GetDestroyHandler")]
		public virtual unsafe void Destroy ()
		{
			if (id_destroy == IntPtr.Zero)
				id_destroy = JNIEnv.GetMethodID (class_ref, "destroy", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_destroy);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "destroy", "()V"));
			} finally {
			}
		}

		static IntPtr id_getCodecInfo_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='getCodecInfo' and count(parameter)=1 and parameter[1][@type='java.util.ArrayList&lt;java.lang.String&gt;']]"
		[Register ("getCodecInfo", "(Ljava/util/ArrayList;)Landroid/media/MediaCodecInfo;", "")]
		public static unsafe global::Android.Media.MediaCodecInfo GetCodecInfo (global::System.Collections.Generic.IList<string> p0)
		{
			if (id_getCodecInfo_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_getCodecInfo_Ljava_util_ArrayList_ = JNIEnv.GetStaticMethodID (class_ref, "getCodecInfo", "(Ljava/util/ArrayList;)Landroid/media/MediaCodecInfo;");
			IntPtr native_p0 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Android.Media.MediaCodecInfo __ret = global::Java.Lang.Object.GetObject<global::Android.Media.MediaCodecInfo> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getCodecInfo_Ljava_util_ArrayList_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_hadCriticalFailure;
#pragma warning disable 0169
		static Delegate GetHadCriticalFailureHandler ()
		{
			if (cb_hadCriticalFailure == null)
				cb_hadCriticalFailure = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_HadCriticalFailure);
			return cb_hadCriticalFailure;
		}

		static bool n_HadCriticalFailure (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareDecoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareDecoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HadCriticalFailure ();
		}
#pragma warning restore 0169

		static IntPtr id_hadCriticalFailure;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='hadCriticalFailure' and count(parameter)=0]"
		[Register ("hadCriticalFailure", "()Z", "GetHadCriticalFailureHandler")]
		public virtual unsafe bool HadCriticalFailure ()
		{
			if (id_hadCriticalFailure == IntPtr.Zero)
				id_hadCriticalFailure = JNIEnv.GetMethodID (class_ref, "hadCriticalFailure", "()Z");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hadCriticalFailure);
				else
					return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "hadCriticalFailure", "()Z"));
			} finally {
			}
		}

		static Delegate cb_setNeedsKeyFrame;
#pragma warning disable 0169
		static Delegate GetSetNeedsKeyFrameHandler ()
		{
			if (cb_setNeedsKeyFrame == null)
				cb_setNeedsKeyFrame = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetNeedsKeyFrame);
			return cb_setNeedsKeyFrame;
		}

		static void n_SetNeedsKeyFrame (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareDecoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareDecoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetNeedsKeyFrame ();
		}
#pragma warning restore 0169

		static IntPtr id_setNeedsKeyFrame;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareDecoder']/method[@name='setNeedsKeyFrame' and count(parameter)=0]"
		[Register ("setNeedsKeyFrame", "()V", "GetSetNeedsKeyFrameHandler")]
		public virtual unsafe void SetNeedsKeyFrame ()
		{
			if (id_setNeedsKeyFrame == IntPtr.Zero)
				id_setNeedsKeyFrame = JNIEnv.GetMethodID (class_ref, "setNeedsKeyFrame", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setNeedsKeyFrame);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setNeedsKeyFrame", "()V"));
			} finally {
			}
		}

	}
}
