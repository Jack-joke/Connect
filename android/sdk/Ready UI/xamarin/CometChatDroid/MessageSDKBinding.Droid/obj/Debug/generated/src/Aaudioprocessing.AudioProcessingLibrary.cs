using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Aaudioprocessing {

	// Metadata.xml XPath class reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']"
	[global::Android.Runtime.Register ("aaudioprocessing/AudioProcessingLibrary", DoNotGenerateAcw=true)]
	public partial class AudioProcessingLibrary : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("aaudioprocessing/AudioProcessingLibrary", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AudioProcessingLibrary); }
		}

		protected AudioProcessingLibrary (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']/constructor[@name='AudioProcessingLibrary' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe AudioProcessingLibrary ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (AudioProcessingLibrary)) {
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

		static IntPtr id_acousticEchoCancellerCapture_JarrayBII;
		// Metadata.xml XPath method reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']/method[@name='acousticEchoCancellerCapture' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='byte[]'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("acousticEchoCancellerCapture", "(J[BII)[B", "")]
		public static unsafe byte[] AcousticEchoCancellerCapture (long p0, byte[] p1, int p2, int p3)
		{
			if (id_acousticEchoCancellerCapture_JarrayBII == IntPtr.Zero)
				id_acousticEchoCancellerCapture_JarrayBII = JNIEnv.GetStaticMethodID (class_ref, "acousticEchoCancellerCapture", "(J[BII)[B");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				byte[] __ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_acousticEchoCancellerCapture_JarrayBII, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_acousticEchoCancellerCreate_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']/method[@name='acousticEchoCancellerCreate' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("acousticEchoCancellerCreate", "(III)J", "")]
		public static unsafe long AcousticEchoCancellerCreate (int p0, int p1, int p2)
		{
			if (id_acousticEchoCancellerCreate_III == IntPtr.Zero)
				id_acousticEchoCancellerCreate_III = JNIEnv.GetStaticMethodID (class_ref, "acousticEchoCancellerCreate", "(III)J");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_acousticEchoCancellerCreate_III, __args);
			} finally {
			}
		}

		static IntPtr id_acousticEchoCancellerDestroy_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']/method[@name='acousticEchoCancellerDestroy' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("acousticEchoCancellerDestroy", "(J)V", "")]
		public static unsafe void AcousticEchoCancellerDestroy (long p0)
		{
			if (id_acousticEchoCancellerDestroy_J == IntPtr.Zero)
				id_acousticEchoCancellerDestroy_J = JNIEnv.GetStaticMethodID (class_ref, "acousticEchoCancellerDestroy", "(J)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_acousticEchoCancellerDestroy_J, __args);
			} finally {
			}
		}

		static IntPtr id_acousticEchoCancellerRender_JarrayBII;
		// Metadata.xml XPath method reference: path="/api/package[@name='aaudioprocessing']/class[@name='AudioProcessingLibrary']/method[@name='acousticEchoCancellerRender' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='byte[]'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("acousticEchoCancellerRender", "(J[BII)V", "")]
		public static unsafe void AcousticEchoCancellerRender (long p0, byte[] p1, int p2, int p3)
		{
			if (id_acousticEchoCancellerRender_JarrayBII == IntPtr.Zero)
				id_acousticEchoCancellerRender_JarrayBII = JNIEnv.GetStaticMethodID (class_ref, "acousticEchoCancellerRender", "(J[BII)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_acousticEchoCancellerRender_JarrayBII, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

	}
}
