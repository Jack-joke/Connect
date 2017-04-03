using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerPatternArrayListBear']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/StickerPatternArrayListBear", DoNotGenerateAcw=true)]
	public partial class StickerPatternArrayListBear : global::Java.Lang.Object {


		static IntPtr stickerBear_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerPatternArrayListBear']/field[@name='stickerBear']"
		[Register ("stickerBear")]
		public static global::System.Collections.IList StickerBear {
			get {
				if (stickerBear_jfieldId == IntPtr.Zero)
					stickerBear_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerBear", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerBear_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerBear_jfieldId == IntPtr.Zero)
					stickerBear_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerBear", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerBear_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/mapping/StickerPatternArrayListBear", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StickerPatternArrayListBear); }
		}

		protected StickerPatternArrayListBear (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerPatternArrayListBear']/constructor[@name='StickerPatternArrayListBear' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe StickerPatternArrayListBear ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (StickerPatternArrayListBear)) {
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

	}
}
