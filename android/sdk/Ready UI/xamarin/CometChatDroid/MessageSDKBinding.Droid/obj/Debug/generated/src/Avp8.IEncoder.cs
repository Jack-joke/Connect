using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Avp8 {

	// Metadata.xml XPath interface reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']"
	[Register ("avp8/IEncoder", "", "Avp8.IEncoderInvoker")]
	public partial interface IEncoder : IJavaObject {

		int Bitrate {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='getBitrate' and count(parameter)=0]"
			[Register ("getBitrate", "()I", "GetGetBitrateHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")] get;
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='setBitrate' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBitrate", "(I)V", "GetSetBitrate_IHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")] set;
		}

		string CodecName {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='getCodecName' and count(parameter)=0]"
			[Register ("getCodecName", "()Ljava/lang/String;", "GetGetCodecNameHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")] get;
		}

		double Quality {
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='getQuality' and count(parameter)=0]"
			[Register ("getQuality", "()D", "GetGetQualityHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")] get;
			// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='setQuality' and count(parameter)=1 and parameter[1][@type='double']]"
			[Register ("setQuality", "(D)V", "GetSetQuality_DHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")] set;
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='destroy' and count(parameter)=0]"
		[Register ("destroy", "()V", "GetDestroyHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")]
		void Destroy ();

		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='encode' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='byte[]'] and parameter[4][@type='long'] and parameter[5][@type='int']]"
		[Register ("encode", "(II[BJI)[B", "GetEncode_IIarrayBJIHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")]
		byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4);

		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='encode' and count(parameter)=6 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='byte[]'] and parameter[4][@type='long'] and parameter[5][@type='int'] and parameter[6][@type='int']]"
		[Register ("encode", "(II[BJII)[B", "GetEncode_IIarrayBJIIHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")]
		byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4, int p5);

		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='forceKeyframe' and count(parameter)=0]"
		[Register ("forceKeyframe", "()V", "GetForceKeyframeHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")]
		void ForceKeyframe ();

		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/interface[@name='IEncoder']/method[@name='hadCriticalFailure' and count(parameter)=0]"
		[Register ("hadCriticalFailure", "()Z", "GetHadCriticalFailureHandler:Avp8.IEncoderInvoker, MessageSDKBinding.Droid")]
		bool HadCriticalFailure ();

	}

	[global::Android.Runtime.Register ("avp8/IEncoder", DoNotGenerateAcw=true)]
	internal class IEncoderInvoker : global::Java.Lang.Object, IEncoder {

		static IntPtr java_class_ref = JNIEnv.FindClass ("avp8/IEncoder");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IEncoderInvoker); }
		}

		IntPtr class_ref;

		public static IEncoder GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IEncoder> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "avp8.IEncoder"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IEncoderInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Bitrate = p0;
		}
#pragma warning restore 0169

		IntPtr id_getBitrate;
		IntPtr id_setBitrate_I;
		public unsafe int Bitrate {
			get {
				if (id_getBitrate == IntPtr.Zero)
					id_getBitrate = JNIEnv.GetMethodID (class_ref, "getBitrate", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBitrate);
			}
			set {
				if (id_setBitrate_I == IntPtr.Zero)
					id_setBitrate_I = JNIEnv.GetMethodID (class_ref, "setBitrate", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBitrate_I, __args);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CodecName);
		}
#pragma warning restore 0169

		IntPtr id_getCodecName;
		public unsafe string CodecName {
			get {
				if (id_getCodecName == IntPtr.Zero)
					id_getCodecName = JNIEnv.GetMethodID (class_ref, "getCodecName", "()Ljava/lang/String;");
				return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCodecName), JniHandleOwnership.TransferLocalRef);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Quality = p0;
		}
#pragma warning restore 0169

		IntPtr id_getQuality;
		IntPtr id_setQuality_D;
		public unsafe double Quality {
			get {
				if (id_getQuality == IntPtr.Zero)
					id_getQuality = JNIEnv.GetMethodID (class_ref, "getQuality", "()D");
				return JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_getQuality);
			}
			set {
				if (id_setQuality_D == IntPtr.Zero)
					id_setQuality_D = JNIEnv.GetMethodID (class_ref, "setQuality", "(D)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setQuality_D, __args);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Destroy ();
		}
#pragma warning restore 0169

		IntPtr id_destroy;
		public unsafe void Destroy ()
		{
			if (id_destroy == IntPtr.Zero)
				id_destroy = JNIEnv.GetMethodID (class_ref, "destroy", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_destroy);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p2 = (byte[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.Encode (p0, p1, p2, p3, p4));
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_encode_IIarrayBJI;
		public unsafe byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4)
		{
			if (id_encode_IIarrayBJI == IntPtr.Zero)
				id_encode_IIarrayBJI = JNIEnv.GetMethodID (class_ref, "encode", "(II[BJI)[B");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			JValue* __args = stackalloc JValue [5];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (native_p2);
			__args [3] = new JValue (p3);
			__args [4] = new JValue (p4);
			byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_encode_IIarrayBJI, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
			if (p2 != null) {
				JNIEnv.CopyArray (native_p2, p2);
				JNIEnv.DeleteLocalRef (native_p2);
			}
			return __ret;
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p2 = (byte[]) JNIEnv.GetArray (native_p2, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.Encode (p0, p1, p2, p3, p4, p5));
			if (p2 != null)
				JNIEnv.CopyArray (p2, native_p2);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_encode_IIarrayBJII;
		public unsafe byte[] Encode (int p0, int p1, byte[] p2, long p3, int p4, int p5)
		{
			if (id_encode_IIarrayBJII == IntPtr.Zero)
				id_encode_IIarrayBJII = JNIEnv.GetMethodID (class_ref, "encode", "(II[BJII)[B");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			JValue* __args = stackalloc JValue [6];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (native_p2);
			__args [3] = new JValue (p3);
			__args [4] = new JValue (p4);
			__args [5] = new JValue (p5);
			byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_encode_IIarrayBJII, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
			if (p2 != null) {
				JNIEnv.CopyArray (native_p2, p2);
				JNIEnv.DeleteLocalRef (native_p2);
			}
			return __ret;
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ForceKeyframe ();
		}
#pragma warning restore 0169

		IntPtr id_forceKeyframe;
		public unsafe void ForceKeyframe ()
		{
			if (id_forceKeyframe == IntPtr.Zero)
				id_forceKeyframe = JNIEnv.GetMethodID (class_ref, "forceKeyframe", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_forceKeyframe);
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
			global::Avp8.IEncoder __this = global::Java.Lang.Object.GetObject<global::Avp8.IEncoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HadCriticalFailure ();
		}
#pragma warning restore 0169

		IntPtr id_hadCriticalFailure;
		public unsafe bool HadCriticalFailure ()
		{
			if (id_hadCriticalFailure == IntPtr.Zero)
				id_hadCriticalFailure = JNIEnv.GetMethodID (class_ref, "hadCriticalFailure", "()Z");
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hadCriticalFailure);
		}

	}

}
