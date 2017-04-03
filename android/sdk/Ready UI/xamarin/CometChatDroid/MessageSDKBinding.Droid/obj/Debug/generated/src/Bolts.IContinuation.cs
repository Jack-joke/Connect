using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath interface reference: path="/api/package[@name='bolts']/interface[@name='Continuation']"
	[Register ("bolts/Continuation", "", "Bolts.IContinuationInvoker")]
	[global::Java.Interop.JavaTypeParameters (new string [] {"TTaskResult", "TContinuationResult"})]
	public partial interface IContinuation : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/interface[@name='Continuation']/method[@name='then' and count(parameter)=1 and parameter[1][@type='bolts.Task&lt;TTaskResult&gt;']]"
		[Register ("then", "(Lbolts/Task;)Ljava/lang/Object;", "GetThen_Lbolts_Task_Handler:Bolts.IContinuationInvoker, MessageSDKBinding.Droid")]
		global::Java.Lang.Object Then (global::Bolts.Task p0);

	}

	[global::Android.Runtime.Register ("bolts/Continuation", DoNotGenerateAcw=true)]
	internal class IContinuationInvoker : global::Java.Lang.Object, IContinuation {

		static IntPtr java_class_ref = JNIEnv.FindClass ("bolts/Continuation");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IContinuationInvoker); }
		}

		IntPtr class_ref;

		public static IContinuation GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IContinuation> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "bolts.Continuation"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IContinuationInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_then_Lbolts_Task_;
#pragma warning disable 0169
		static Delegate GetThen_Lbolts_Task_Handler ()
		{
			if (cb_then_Lbolts_Task_ == null)
				cb_then_Lbolts_Task_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Then_Lbolts_Task_);
			return cb_then_Lbolts_Task_;
		}

		static IntPtr n_Then_Lbolts_Task_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.IContinuation __this = global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.Task p0 = global::Java.Lang.Object.GetObject<global::Bolts.Task> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Then (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_then_Lbolts_Task_;
		public unsafe global::Java.Lang.Object Then (global::Bolts.Task p0)
		{
			if (id_then_Lbolts_Task_ == IntPtr.Zero)
				id_then_Lbolts_Task_ = JNIEnv.GetMethodID (class_ref, "then", "(Lbolts/Task;)Ljava/lang/Object;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			global::Java.Lang.Object __ret = (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_then_Lbolts_Task_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

	}

}
