using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Aopus {

	// Metadata.xml XPath class reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']"
	[global::Android.Runtime.Register ("aopus/OpusLibrary", DoNotGenerateAcw=true)]
	public partial class OpusLibrary : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("aopus/OpusLibrary", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (OpusLibrary); }
		}

		protected OpusLibrary (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/constructor[@name='OpusLibrary' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe OpusLibrary ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (OpusLibrary)) {
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

		static IntPtr id_decoderCreate_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='decoderCreate' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("decoderCreate", "(III)J", "")]
		public static unsafe long DecoderCreate (int p0, int p1, int p2)
		{
			if (id_decoderCreate_III == IntPtr.Zero)
				id_decoderCreate_III = JNIEnv.GetStaticMethodID (class_ref, "decoderCreate", "(III)J");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_decoderCreate_III, __args);
			} finally {
			}
		}

		static IntPtr id_decoderDecode2_JarrayBZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='decoderDecode2' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='byte[]'] and parameter[3][@type='boolean']]"
		[Register ("decoderDecode2", "(J[BZ)[B", "")]
		public static unsafe byte[] DecoderDecode2 (long p0, byte[] p1, bool p2)
		{
			if (id_decoderDecode2_JarrayBZ == IntPtr.Zero)
				id_decoderDecode2_JarrayBZ = JNIEnv.GetStaticMethodID (class_ref, "decoderDecode2", "(J[BZ)[B");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_decoderDecode2_JarrayBZ, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_decoderDecode_JarrayB;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='decoderDecode' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='byte[]']]"
		[Register ("decoderDecode", "(J[B)[B", "")]
		public static unsafe byte[] DecoderDecode (long p0, byte[] p1)
		{
			if (id_decoderDecode_JarrayB == IntPtr.Zero)
				id_decoderDecode_JarrayB = JNIEnv.GetStaticMethodID (class_ref, "decoderDecode", "(J[B)[B");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_decoderDecode_JarrayB, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_decoderDestroy_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='decoderDestroy' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("decoderDestroy", "(J)V", "")]
		public static unsafe void DecoderDestroy (long p0)
		{
			if (id_decoderDestroy_J == IntPtr.Zero)
				id_decoderDestroy_J = JNIEnv.GetStaticMethodID (class_ref, "decoderDestroy", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_decoderDestroy_J, __args);
			} finally {
			}
		}

		static IntPtr id_encoderActivateFEC_JI;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderActivateFEC' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register ("encoderActivateFEC", "(JI)V", "")]
		public static unsafe void EncoderActivateFEC (long p0, int p1)
		{
			if (id_encoderActivateFEC_JI == IntPtr.Zero)
				id_encoderActivateFEC_JI = JNIEnv.GetStaticMethodID (class_ref, "encoderActivateFEC", "(JI)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_encoderActivateFEC_JI, __args);
			} finally {
			}
		}

		static IntPtr id_encoderCreate_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderCreate' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("encoderCreate", "(III)J", "")]
		public static unsafe long EncoderCreate (int p0, int p1, int p2)
		{
			if (id_encoderCreate_III == IntPtr.Zero)
				id_encoderCreate_III = JNIEnv.GetStaticMethodID (class_ref, "encoderCreate", "(III)J");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_encoderCreate_III, __args);
			} finally {
			}
		}

		static IntPtr id_encoderDeactivateFEC_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderDeactivateFEC' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("encoderDeactivateFEC", "(J)V", "")]
		public static unsafe void EncoderDeactivateFEC (long p0)
		{
			if (id_encoderDeactivateFEC_J == IntPtr.Zero)
				id_encoderDeactivateFEC_J = JNIEnv.GetStaticMethodID (class_ref, "encoderDeactivateFEC", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_encoderDeactivateFEC_J, __args);
			} finally {
			}
		}

		static IntPtr id_encoderDestroy_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderDestroy' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("encoderDestroy", "(J)V", "")]
		public static unsafe void EncoderDestroy (long p0)
		{
			if (id_encoderDestroy_J == IntPtr.Zero)
				id_encoderDestroy_J = JNIEnv.GetStaticMethodID (class_ref, "encoderDestroy", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_encoderDestroy_J, __args);
			} finally {
			}
		}

		static IntPtr id_encoderEncode_JarrayBII;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderEncode' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='byte[]'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("encoderEncode", "(J[BII)[B", "")]
		public static unsafe byte[] EncoderEncode (long p0, byte[] p1, int p2, int p3)
		{
			if (id_encoderEncode_JarrayBII == IntPtr.Zero)
				id_encoderEncode_JarrayBII = JNIEnv.GetStaticMethodID (class_ref, "encoderEncode", "(J[BII)[B");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_encoderEncode_JarrayBII, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_encoderGetBitrate_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderGetBitrate' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("encoderGetBitrate", "(J)I", "")]
		public static unsafe int EncoderGetBitrate (long p0)
		{
			if (id_encoderGetBitrate_J == IntPtr.Zero)
				id_encoderGetBitrate_J = JNIEnv.GetStaticMethodID (class_ref, "encoderGetBitrate", "(J)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_encoderGetBitrate_J, __args);
			} finally {
			}
		}

		static IntPtr id_encoderGetQuality_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderGetQuality' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("encoderGetQuality", "(J)D", "")]
		public static unsafe double EncoderGetQuality (long p0)
		{
			if (id_encoderGetQuality_J == IntPtr.Zero)
				id_encoderGetQuality_J = JNIEnv.GetStaticMethodID (class_ref, "encoderGetQuality", "(J)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_encoderGetQuality_J, __args);
			} finally {
			}
		}

		static IntPtr id_encoderSetBitrate_JI;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderSetBitrate' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='int']]"
		[Register ("encoderSetBitrate", "(JI)V", "")]
		public static unsafe void EncoderSetBitrate (long p0, int p1)
		{
			if (id_encoderSetBitrate_JI == IntPtr.Zero)
				id_encoderSetBitrate_JI = JNIEnv.GetStaticMethodID (class_ref, "encoderSetBitrate", "(JI)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_encoderSetBitrate_JI, __args);
			} finally {
			}
		}

		static IntPtr id_encoderSetQuality_JD;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='OpusLibrary']/method[@name='encoderSetQuality' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='double']]"
		[Register ("encoderSetQuality", "(JD)V", "")]
		public static unsafe void EncoderSetQuality (long p0, double p1)
		{
			if (id_encoderSetQuality_JD == IntPtr.Zero)
				id_encoderSetQuality_JD = JNIEnv.GetStaticMethodID (class_ref, "encoderSetQuality", "(JD)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_encoderSetQuality_JD, __args);
			} finally {
			}
		}

	}
}
