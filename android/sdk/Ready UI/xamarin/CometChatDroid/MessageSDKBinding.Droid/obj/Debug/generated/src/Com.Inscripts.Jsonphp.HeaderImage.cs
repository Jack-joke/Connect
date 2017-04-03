using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Jsonphp {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']"
	[global::Android.Runtime.Register ("com/inscripts/jsonphp/HeaderImage", DoNotGenerateAcw=true)]
	public partial class HeaderImage : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/jsonphp/HeaderImage", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (HeaderImage); }
		}

		protected HeaderImage (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']/constructor[@name='HeaderImage' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe HeaderImage ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (HeaderImage)) {
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

		static Delegate cb_getImageHeight;
#pragma warning disable 0169
		static Delegate GetGetImageHeightHandler ()
		{
			if (cb_getImageHeight == null)
				cb_getImageHeight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetImageHeight);
			return cb_getImageHeight;
		}

		static IntPtr n_GetImageHeight (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.HeaderImage __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ImageHeight);
		}
#pragma warning restore 0169

		static IntPtr id_getImageHeight;
		public virtual unsafe global::Java.Lang.Integer ImageHeight {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']/method[@name='getImageHeight' and count(parameter)=0]"
			[Register ("getImageHeight", "()Ljava/lang/Integer;", "GetGetImageHeightHandler")]
			get {
				if (id_getImageHeight == IntPtr.Zero)
					id_getImageHeight = JNIEnv.GetMethodID (class_ref, "getImageHeight", "()Ljava/lang/Integer;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getImageHeight), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getImageHeight", "()Ljava/lang/Integer;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getImageModifiedTime;
#pragma warning disable 0169
		static Delegate GetGetImageModifiedTimeHandler ()
		{
			if (cb_getImageModifiedTime == null)
				cb_getImageModifiedTime = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetImageModifiedTime);
			return cb_getImageModifiedTime;
		}

		static IntPtr n_GetImageModifiedTime (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.HeaderImage __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ImageModifiedTime);
		}
#pragma warning restore 0169

		static IntPtr id_getImageModifiedTime;
		public virtual unsafe global::Java.Lang.Integer ImageModifiedTime {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']/method[@name='getImageModifiedTime' and count(parameter)=0]"
			[Register ("getImageModifiedTime", "()Ljava/lang/Integer;", "GetGetImageModifiedTimeHandler")]
			get {
				if (id_getImageModifiedTime == IntPtr.Zero)
					id_getImageModifiedTime = JNIEnv.GetMethodID (class_ref, "getImageModifiedTime", "()Ljava/lang/Integer;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getImageModifiedTime), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getImageModifiedTime", "()Ljava/lang/Integer;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getImagePath;
#pragma warning disable 0169
		static Delegate GetGetImagePathHandler ()
		{
			if (cb_getImagePath == null)
				cb_getImagePath = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetImagePath);
			return cb_getImagePath;
		}

		static IntPtr n_GetImagePath (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.HeaderImage __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ImagePath);
		}
#pragma warning restore 0169

		static IntPtr id_getImagePath;
		public virtual unsafe string ImagePath {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']/method[@name='getImagePath' and count(parameter)=0]"
			[Register ("getImagePath", "()Ljava/lang/String;", "GetGetImagePathHandler")]
			get {
				if (id_getImagePath == IntPtr.Zero)
					id_getImagePath = JNIEnv.GetMethodID (class_ref, "getImagePath", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getImagePath), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getImagePath", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getImageWidth;
#pragma warning disable 0169
		static Delegate GetGetImageWidthHandler ()
		{
			if (cb_getImageWidth == null)
				cb_getImageWidth = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetImageWidth);
			return cb_getImageWidth;
		}

		static IntPtr n_GetImageWidth (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Jsonphp.HeaderImage __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Jsonphp.HeaderImage> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.ImageWidth);
		}
#pragma warning restore 0169

		static IntPtr id_getImageWidth;
		public virtual unsafe global::Java.Lang.Integer ImageWidth {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.jsonphp']/class[@name='HeaderImage']/method[@name='getImageWidth' and count(parameter)=0]"
			[Register ("getImageWidth", "()Ljava/lang/Integer;", "GetGetImageWidthHandler")]
			get {
				if (id_getImageWidth == IntPtr.Zero)
					id_getImageWidth = JNIEnv.GetMethodID (class_ref, "getImageWidth", "()Ljava/lang/Integer;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getImageWidth), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getImageWidth", "()Ljava/lang/Integer;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
