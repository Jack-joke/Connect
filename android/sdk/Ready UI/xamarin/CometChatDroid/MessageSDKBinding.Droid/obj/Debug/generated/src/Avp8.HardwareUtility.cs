using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Avp8 {

	// Metadata.xml XPath class reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']"
	[global::Android.Runtime.Register ("avp8/HardwareUtility", DoNotGenerateAcw=true)]
	public partial class HardwareUtility : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("avp8/HardwareUtility", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HardwareUtility); }
		}

		protected HardwareUtility (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']/constructor[@name='HardwareUtility' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HardwareUtility ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HardwareUtility)) {
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

		static IntPtr id_filterCodecInfos_arrayLandroid_media_MediaCodecInfo_Ljava_lang_String_arrayI;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']/method[@name='filterCodecInfos' and count(parameter)=3 and parameter[1][@type='android.media.MediaCodecInfo[]'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='int[]']]"
		[Register ("filterCodecInfos", "([Landroid/media/MediaCodecInfo;Ljava/lang/String;[I)[Landroid/media/MediaCodecInfo;", "")]
		public static unsafe global::Android.Media.MediaCodecInfo[] FilterCodecInfos (global::Android.Media.MediaCodecInfo[] p0, string p1, int[] p2)
		{
			if (id_filterCodecInfos_arrayLandroid_media_MediaCodecInfo_Ljava_lang_String_arrayI == IntPtr.Zero)
				id_filterCodecInfos_arrayLandroid_media_MediaCodecInfo_Ljava_lang_String_arrayI = JNIEnv.GetStaticMethodID (class_ref, "filterCodecInfos", "([Landroid/media/MediaCodecInfo;Ljava/lang/String;[I)[Landroid/media/MediaCodecInfo;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				global::Android.Media.MediaCodecInfo[] __ret = (global::Android.Media.MediaCodecInfo[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_filterCodecInfos_arrayLandroid_media_MediaCodecInfo_Ljava_lang_String_arrayI, __args), JniHandleOwnership.TransferLocalRef, typeof (global::Android.Media.MediaCodecInfo));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_getDecoderInfos_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']/method[@name='getDecoderInfos' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getDecoderInfos", "(Ljava/lang/String;)[Landroid/media/MediaCodecInfo;", "")]
		public static unsafe global::Android.Media.MediaCodecInfo[] GetDecoderInfos (string p0)
		{
			if (id_getDecoderInfos_Ljava_lang_String_ == IntPtr.Zero)
				id_getDecoderInfos_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getDecoderInfos", "(Ljava/lang/String;)[Landroid/media/MediaCodecInfo;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Android.Media.MediaCodecInfo[] __ret = (global::Android.Media.MediaCodecInfo[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDecoderInfos_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef, typeof (global::Android.Media.MediaCodecInfo));
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getEncoderInfos_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']/method[@name='getEncoderInfos' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getEncoderInfos", "(Ljava/lang/String;)[Landroid/media/MediaCodecInfo;", "")]
		public static unsafe global::Android.Media.MediaCodecInfo[] GetEncoderInfos (string p0)
		{
			if (id_getEncoderInfos_Ljava_lang_String_ == IntPtr.Zero)
				id_getEncoderInfos_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "getEncoderInfos", "(Ljava/lang/String;)[Landroid/media/MediaCodecInfo;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Android.Media.MediaCodecInfo[] __ret = (global::Android.Media.MediaCodecInfo[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_getEncoderInfos_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef, typeof (global::Android.Media.MediaCodecInfo));
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_logAvailableCodecs;
		// Metadata.xml XPath method reference: path="/api/package[@name='avp8']/class[@name='HardwareUtility']/method[@name='logAvailableCodecs' and count(parameter)=0]"
		[Register ("logAvailableCodecs", "()V", "")]
		public static unsafe void LogAvailableCodecs ()
		{
			if (id_logAvailableCodecs == IntPtr.Zero)
				id_logAvailableCodecs = JNIEnv.GetStaticMethodID (class_ref, "logAvailableCodecs", "()V");
			try {
				JNIEnv.CallStaticVoidMethod  (class_ref, id_logAvailableCodecs);
			} finally {
			}
		}

	}
}
