using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='StickerClickInterface']"
	[Register ("com/inscripts/interfaces/StickerClickInterface", "", "Com.Inscripts.Interfaces.IStickerClickInterfaceInvoker")]
	public partial interface IStickerClickInterface : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='StickerClickInterface']/method[@name='getClickedSticker' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getClickedSticker", "(I)V", "GetGetClickedSticker_IHandler:Com.Inscripts.Interfaces.IStickerClickInterfaceInvoker, MessageSDKBinding.Droid")]
		void GetClickedSticker (int p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/StickerClickInterface", DoNotGenerateAcw=true)]
	internal class IStickerClickInterfaceInvoker : global::Java.Lang.Object, IStickerClickInterface {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/StickerClickInterface");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IStickerClickInterfaceInvoker); }
		}

		IntPtr class_ref;

		public static IStickerClickInterface GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IStickerClickInterface> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.StickerClickInterface"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IStickerClickInterfaceInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_getClickedSticker_I;
#pragma warning disable 0169
		static Delegate GetGetClickedSticker_IHandler ()
		{
			if (cb_getClickedSticker_I == null)
				cb_getClickedSticker_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_GetClickedSticker_I);
			return cb_getClickedSticker_I;
		}

		static void n_GetClickedSticker_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Interfaces.IStickerClickInterface __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IStickerClickInterface> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.GetClickedSticker (p0);
		}
#pragma warning restore 0169

		IntPtr id_getClickedSticker_I;
		public unsafe void GetClickedSticker (int p0)
		{
			if (id_getClickedSticker_I == IntPtr.Zero)
				id_getClickedSticker_I = JNIEnv.GetMethodID (class_ref, "getClickedSticker", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getClickedSticker_I, __args);
		}

	}

}
