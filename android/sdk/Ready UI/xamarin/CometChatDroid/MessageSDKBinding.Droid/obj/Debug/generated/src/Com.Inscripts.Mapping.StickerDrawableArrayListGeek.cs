using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListGeek']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/StickerDrawableArrayListGeek", DoNotGenerateAcw=true)]
	public partial class StickerDrawableArrayListGeek : global::Java.Lang.Object {


		static IntPtr stickerGeek_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListGeek']/field[@name='stickerGeek']"
		[Register ("stickerGeek")]
		public static global::System.Collections.IList StickerGeek {
			get {
				if (stickerGeek_jfieldId == IntPtr.Zero)
					stickerGeek_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerGeek", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerGeek_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerGeek_jfieldId == IntPtr.Zero)
					stickerGeek_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerGeek", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerGeek_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/mapping/StickerDrawableArrayListGeek", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StickerDrawableArrayListGeek); }
		}

		protected StickerDrawableArrayListGeek (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerDrawableArrayListGeek']/constructor[@name='StickerDrawableArrayListGeek' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe StickerDrawableArrayListGeek ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (StickerDrawableArrayListGeek)) {
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
