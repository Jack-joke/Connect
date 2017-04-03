using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Helpers {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']"
	[global::Android.Runtime.Register ("com/inscripts/helpers/BitmapProcessingHelper", DoNotGenerateAcw=true)]
	public partial class BitmapProcessingHelper : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/helpers/BitmapProcessingHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BitmapProcessingHelper); }
		}

		protected BitmapProcessingHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']/constructor[@name='BitmapProcessingHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe BitmapProcessingHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (BitmapProcessingHelper)) {
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

		static IntPtr id_addBorderToRoundedBitmap_Landroid_graphics_Bitmap_III;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']/method[@name='addBorderToRoundedBitmap' and count(parameter)=4 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("addBorderToRoundedBitmap", "(Landroid/graphics/Bitmap;III)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap AddBorderToRoundedBitmap (global::Android.Graphics.Bitmap p0, int p1, int p2, int p3)
		{
			if (id_addBorderToRoundedBitmap_Landroid_graphics_Bitmap_III == IntPtr.Zero)
				id_addBorderToRoundedBitmap_Landroid_graphics_Bitmap_III = JNIEnv.GetStaticMethodID (class_ref, "addBorderToRoundedBitmap", "(Landroid/graphics/Bitmap;III)Landroid/graphics/Bitmap;");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_addBorderToRoundedBitmap_Landroid_graphics_Bitmap_III, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_createBitmap_Ljava_lang_String_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']/method[@name='createBitmap' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='boolean']]"
		[Register ("createBitmap", "(Ljava/lang/String;Z)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap CreateBitmap (string p0, bool p1)
		{
			if (id_createBitmap_Ljava_lang_String_Z == IntPtr.Zero)
				id_createBitmap_Ljava_lang_String_Z = JNIEnv.GetStaticMethodID (class_ref, "createBitmap", "(Ljava/lang/String;Z)Landroid/graphics/Bitmap;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_createBitmap_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getRoundedCroppedBitmap_Landroid_graphics_Bitmap_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']/method[@name='getRoundedCroppedBitmap' and count(parameter)=2 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='int']]"
		[Register ("getRoundedCroppedBitmap", "(Landroid/graphics/Bitmap;I)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap GetRoundedCroppedBitmap (global::Android.Graphics.Bitmap p0, int p1)
		{
			if (id_getRoundedCroppedBitmap_Landroid_graphics_Bitmap_I == IntPtr.Zero)
				id_getRoundedCroppedBitmap_Landroid_graphics_Bitmap_I = JNIEnv.GetStaticMethodID (class_ref, "getRoundedCroppedBitmap", "(Landroid/graphics/Bitmap;I)Landroid/graphics/Bitmap;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getRoundedCroppedBitmap_Landroid_graphics_Bitmap_I, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_scaleBitmap_Landroid_graphics_Bitmap_IILjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.helpers']/class[@name='BitmapProcessingHelper']/method[@name='scaleBitmap' and count(parameter)=4 and parameter[1][@type='android.graphics.Bitmap'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='java.lang.String']]"
		[Register ("scaleBitmap", "(Landroid/graphics/Bitmap;IILjava/lang/String;)Landroid/graphics/Bitmap;", "")]
		public static unsafe global::Android.Graphics.Bitmap ScaleBitmap (global::Android.Graphics.Bitmap p0, int p1, int p2, string p3)
		{
			if (id_scaleBitmap_Landroid_graphics_Bitmap_IILjava_lang_String_ == IntPtr.Zero)
				id_scaleBitmap_Landroid_graphics_Bitmap_IILjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "scaleBitmap", "(Landroid/graphics/Bitmap;IILjava/lang/String;)Landroid/graphics/Bitmap;");
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallStaticObjectMethod  (class_ref, id_scaleBitmap_Landroid_graphics_Bitmap_IILjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

	}
}
