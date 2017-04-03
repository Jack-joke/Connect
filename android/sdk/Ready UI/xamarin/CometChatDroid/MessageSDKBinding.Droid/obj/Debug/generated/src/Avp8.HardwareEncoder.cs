using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Avp8 {

	// Metadata.xml XPath class reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']"
	[global::Android.Runtime.Register ("avp8/HardwareEncoder", DoNotGenerateAcw=true)]
	public partial class HardwareEncoder : global::Java.Lang.Object, global::Avp8.IEncoder {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("avp8/HardwareEncoder", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HardwareEncoder); }
		}

		protected HardwareEncoder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/constructor[@name='HardwareEncoder' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HardwareEncoder ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HardwareEncoder)) {
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

		static Delegate cb_getBitrate;
#pragma warning disable 0169
		static Delegate GetGetBitrateHandler ()
		{
			if (cb_getBitrate == null)
				cb_getBitrate = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBitrate);
			return cb_getBitrate;
		}

		static int n_GetBitrate (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Bitrate;
		}
#pragma warning restore 0169

		static Delegate cb_setBitrate_I;
#pragma warning disable 0169
		static Delegate GetSetBitrate_IHandler ()
		{
			if (cb_setBitrate_I == null)
				cb_setBitrate_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBitrate_I);
			return cb_setBitrate_I;
		}

		static void n_SetBitrate_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Bitrate = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBitrate;
		static IntPtr id_setBitrate_I;
		public virtual unsafe int Bitrate {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='getBitrate' and count(parameter)=0]"
			[Register ("getBitrate", "()I", "GetGetBitrateHandler")]
			get {
				if (id_getBitrate == IntPtr.Zero)
					id_getBitrate = JNIEnv.GetMethodID (class_ref, "getBitrate", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBitrate);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBitrate", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='setBitrate' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBitrate", "(I)V", "GetSetBitrate_IHandler")]
			set {
				if (id_setBitrate_I == IntPtr.Zero)
					id_setBitrate_I = JNIEnv.GetMethodID (class_ref, "setBitrate", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBitrate_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBitrate", "(I)V"), __args);
				} finally {
				}
			}
		}

		static IntPtr id_getCodecInfo;
		public static unsafe global::Android.Media.MediaCodecInfo CodecInfo {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='getCodecInfo' and count(parameter)=0]"
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
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CodecName);
		}
#pragma warning restore 0169

		static IntPtr id_getCodecName;
		public virtual unsafe string CodecName {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='getCodecName' and count(parameter)=0]"
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

		static Delegate cb_getQuality;
#pragma warning disable 0169
		static Delegate GetGetQualityHandler ()
		{
			if (cb_getQuality == null)
				cb_getQuality = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, double>) n_GetQuality);
			return cb_getQuality;
		}

		static double n_GetQuality (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Quality;
		}
#pragma warning restore 0169

		static Delegate cb_setQuality_D;
#pragma warning disable 0169
		static Delegate GetSetQuality_DHandler ()
		{
			if (cb_setQuality_D == null)
				cb_setQuality_D = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double>) n_SetQuality_D);
			return cb_setQuality_D;
		}

		static void n_SetQuality_D (IntPtr jnienv, IntPtr native__this, double p0)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Quality = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getQuality;
		static IntPtr id_setQuality_D;
		public virtual unsafe double Quality {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='getQuality' and count(parameter)=0]"
			[Register ("getQuality", "()D", "GetGetQualityHandler")]
			get {
				if (id_getQuality == IntPtr.Zero)
					id_getQuality = JNIEnv.GetMethodID (class_ref, "getQuality", "()D");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_getQuality);
					else
						return JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getQuality", "()D"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='setQuality' and count(parameter)=1 and parameter[1][@type='double']]"
			[Register ("setQuality", "(D)V", "GetSetQuality_DHandler")]
			set {
				if (id_setQuality_D == IntPtr.Zero)
					id_setQuality_D = JNIEnv.GetMethodID (class_ref, "setQuality", "(D)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setQuality_D, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setQuality", "(D)V"), __args);
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
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Destroy ();
		}
#pragma warning restore 0169

		static IntPtr id_destroy;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='destroy' and count(parameter)=0]"
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

		static Delegate cb_encode_IIarrayBJI;
#pragma warning disable 0169
		static Delegate GetEncode_IIarrayBJIHandler ()
		{
			if (cb_encode_IIarrayBJI == null)
				cb_encode_IIarrayBJI = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, long, int, IntPtr>) n_Encode_IIarrayBJI);
			return cb_encode_IIarrayBJI;
		}

		static IntPtr n_Encode_IIarrayBJI (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2, long p3, int p4)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p2 = (byte[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.Encode (p0, p1, p2, p3, p4));
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_encode_IIarrayBJI;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='encode' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='byte[]'] and parameter[4][@type='long'] and parameter[5][@type='int']]"
		[Register ("encode", "(II[BJI)[B", "GetEncode_IIarrayBJIHandler")]
		public virtual unsafe byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4)
		{
			if (id_encode_IIarrayBJI == IntPtr.Zero)
				id_encode_IIarrayBJI = JNIEnv.GetMethodID (class_ref, "encode", "(II[BJI)[B");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);

				byte[] __ret;
				if (GetType () == ThresholdType)
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_encode_IIarrayBJI, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				else
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "encode", "(II[BJI)[B"), __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_encode_IIarrayBJII;
#pragma warning disable 0169
		static Delegate GetEncode_IIarrayBJIIHandler ()
		{
			if (cb_encode_IIarrayBJII == null)
				cb_encode_IIarrayBJII = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr, long, int, int, IntPtr>) n_Encode_IIarrayBJII);
			return cb_encode_IIarrayBJII;
		}

		static IntPtr n_Encode_IIarrayBJII (IntPtr jnienv, IntPtr native__this, int p0, int p1, IntPtr native_p2, long p3, int p4, int p5)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p2 = (byte[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.Encode (p0, p1, p2, p3, p4, p5));
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_encode_IIarrayBJII;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='encode' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='byte[]'] and parameter[4][@type='long'] and parameter[5][@type='int'] and parameter[6][@type='int']]"
		[Register ("encode", "(II[BJII)[B", "GetEncode_IIarrayBJIIHandler")]
		public virtual unsafe byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4, int p5)
		{
			if (id_encode_IIarrayBJII == IntPtr.Zero)
				id_encode_IIarrayBJII = JNIEnv.GetMethodID (class_ref, "encode", "(II[BJII)[B");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (p5);

				byte[] __ret;
				if (GetType () == ThresholdType)
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_encode_IIarrayBJII, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				else
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "encode", "(II[BJII)[B"), __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static Delegate cb_forceKeyframe;
#pragma warning disable 0169
		static Delegate GetForceKeyframeHandler ()
		{
			if (cb_forceKeyframe == null)
				cb_forceKeyframe = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ForceKeyframe);
			return cb_forceKeyframe;
		}

		static void n_ForceKeyframe (IntPtr jnienv, IntPtr native__this)
		{
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ForceKeyframe ();
		}
#pragma warning restore 0169

		static IntPtr id_forceKeyframe;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='forceKeyframe' and count(parameter)=0]"
		[Register ("forceKeyframe", "()V", "GetForceKeyframeHandler")]
		public virtual unsafe void ForceKeyframe ()
		{
			if (id_forceKeyframe == IntPtr.Zero)
				id_forceKeyframe = JNIEnv.GetMethodID (class_ref, "forceKeyframe", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forceKeyframe);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "forceKeyframe", "()V"));
			} finally {
			}
		}

		static IntPtr id_getCodecInfo_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='getCodecInfo' and count(parameter)=1 and parameter[1][@type='java.util.ArrayList&lt;java.lang.String&gt;']]"
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
			global::Avp8.HardwareEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.HardwareEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HadCriticalFailure ();
		}
#pragma warning restore 0169

		static IntPtr id_hadCriticalFailure;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareEncoder']/method[@name='hadCriticalFailure' and count(parameter)=0]"
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

	}
}
