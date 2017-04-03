using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Interfaces {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='EmojiClickInterface']"
	[Register ("com/inscripts/interfaces/EmojiClickInterface", "", "Com.Inscripts.Interfaces.IEmojiClickInterfaceInvoker")]
	public partial interface IEmojiClickInterface : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.interfaces']/interface[@name='EmojiClickInterface']/method[@name='getClickedEmoji' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getClickedEmoji", "(I)V", "GetGetClickedEmoji_IHandler:Com.Inscripts.Interfaces.IEmojiClickInterfaceInvoker, MessageSDKBinding.Droid")]
		void GetClickedEmoji (int p0);

	}

	[global::Android.Runtime.Register ("com/inscripts/interfaces/EmojiClickInterface", DoNotGenerateAcw=true)]
	internal class IEmojiClickInterfaceInvoker : global::Java.Lang.Object, IEmojiClickInterface {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/interfaces/EmojiClickInterface");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IEmojiClickInterfaceInvoker); }
		}

		IntPtr class_ref;

		public static IEmojiClickInterface GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IEmojiClickInterface> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.interfaces.EmojiClickInterface"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IEmojiClickInterfaceInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_getClickedEmoji_I;
#pragma warning disable 0169
		static Delegate GetGetClickedEmoji_IHandler ()
		{
			if (cb_getClickedEmoji_I == null)
				cb_getClickedEmoji_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_GetClickedEmoji_I);
			return cb_getClickedEmoji_I;
		}

		static void n_GetClickedEmoji_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Interfaces.IEmojiClickInterface __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Interfaces.IEmojiClickInterface> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.GetClickedEmoji (p0);
		}
#pragma warning restore 0169

		IntPtr id_getClickedEmoji_I;
		public unsafe void GetClickedEmoji (int p0)
		{
			if (id_getClickedEmoji_I == IntPtr.Zero)
				id_getClickedEmoji_I = JNIEnv.GetMethodID (class_ref, "getClickedEmoji", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_getClickedEmoji_I, __args);
		}

	}

}
