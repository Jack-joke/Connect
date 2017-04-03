using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerHashmapPatternToDrawable']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/StickerHashmapPatternToDrawable", DoNotGenerateAcw=true)]
	public partial class StickerHashmapPatternToDrawable : global::Java.Lang.Object {


		static IntPtr stickerMap_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerHashmapPatternToDrawable']/field[@name='stickerMap']"
		[Register ("stickerMap")]
		public static global::System.Collections.IDictionary StickerMap {
			get {
				if (stickerMap_jfieldId == IntPtr.Zero)
					stickerMap_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerMap", "Ljava/util/HashMap;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerMap_jfieldId);
				return global::Android.Runtime.JavaDictionary.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerMap_jfieldId == IntPtr.Zero)
					stickerMap_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerMap", "Ljava/util/HashMap;");
				IntPtr native_value = global::Android.Runtime.JavaDictionary.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerMap_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/mapping/StickerHashmapPatternToDrawable", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (StickerHashmapPatternToDrawable); }
		}

		protected StickerHashmapPatternToDrawable (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='StickerHashmapPatternToDrawable']/constructor[@name='StickerHashmapPatternToDrawable' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe StickerHashmapPatternToDrawable ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (StickerHashmapPatternToDrawable)) {
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
