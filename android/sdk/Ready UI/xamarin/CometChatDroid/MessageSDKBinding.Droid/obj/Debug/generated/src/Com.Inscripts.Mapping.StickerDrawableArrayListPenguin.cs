using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListPenguin']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/StickerDrawableArrayListPenguin", DoNotGenerateAcw=true)]
	public partial class StickerDrawableArrayListPenguin : global::Java.Lang.Object {


		static IntPtr stickerPenguin_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListPenguin']/field[@name='stickerPenguin']"
		[Register ("stickerPenguin")]
		public static global::System.Collections.IList StickerPenguin {
			get {
				if (stickerPenguin_jfieldId == IntPtr.Zero)
					stickerPenguin_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerPenguin", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerPenguin_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerPenguin_jfieldId == IntPtr.Zero)
					stickerPenguin_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerPenguin", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerPenguin_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/mapping/StickerDrawableArrayListPenguin", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StickerDrawableArrayListPenguin); }
		}

		protected StickerDrawableArrayListPenguin (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListPenguin']/constructor[@name='StickerDrawableArrayListPenguin' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe StickerDrawableArrayListPenguin ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (StickerDrawableArrayListPenguin)) {
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
