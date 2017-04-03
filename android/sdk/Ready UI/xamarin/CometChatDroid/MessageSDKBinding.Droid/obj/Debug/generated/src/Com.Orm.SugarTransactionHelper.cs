using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SugarTransactionHelper']"
	[global::Android.Runtime.Register ("com/orm/SugarTransactionHelper", DoNotGenerateAcw=true)]
	public partial class SugarTransactionHelper : global::Java.Lang.Object {

		// Metadata.xml XPath interface reference: path="/api/package[@name='com.orm']/interface[@name='SugarTransactionHelper.Callback']"
		[Register ("com/orm/SugarTransactionHelper$Callback", "", "Com.Orm.SugarTransactionHelper/ICallbackInvoker")]
		public partial interface ICallback : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/interface[@name='SugarTransactionHelper.Callback']/method[@name='manipulateInTransaction' and count(parameter)=0]"
			[Register ("manipulateInTransaction", "()V", "GetManipulateInTransactionHandler:Com.Orm.SugarTransactionHelper/ICallbackInvoker, MessageSDKBinding.Droid")]
			void ManipulateInTransaction ();

		}

		[global::Android.Runtime.Register ("com/orm/SugarTransactionHelper$Callback", DoNotGenerateAcw=true)]
		internal class ICallbackInvoker : global::Java.Lang.Object, ICallback {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/orm/SugarTransactionHelper$Callback");

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ICallbackInvoker); }
			}

			IntPtr class_ref;

			public static ICallback GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<ICallback> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "com.orm.SugarTransactionHelper.Callback"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public ICallbackInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate cb_manipulateInTransaction;
#pragma warning disable 0169
			static Delegate GetManipulateInTransactionHandler ()
			{
				if (cb_manipulateInTransaction == null)
					cb_manipulateInTransaction = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ManipulateInTransaction);
				return cb_manipulateInTransaction;
			}

			static void n_ManipulateInTransaction (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Orm.SugarTransactionHelper.ICallback __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarTransactionHelper.ICallback> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.ManipulateInTransaction ();
			}
#pragma warning restore 0169

			IntPtr id_manipulateInTransaction;
			public unsafe void ManipulateInTransaction ()
			{
				if (id_manipulateInTransaction == IntPtr.Zero)
					id_manipulateInTransaction = JNIEnv.GetMethodID (class_ref, "manipulateInTransaction", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_manipulateInTransaction);
			}

		}


		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/SugarTransactionHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarTransactionHelper); }
		}

		protected SugarTransactionHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm']/class[@name='SugarTransactionHelper']/constructor[@name='SugarTransactionHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SugarTransactionHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SugarTransactionHelper)) {
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

		static IntPtr id_doInTransaction_Lcom_orm_SugarTransactionHelper_Callback_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarTransactionHelper']/method[@name='doInTransaction' and count(parameter)=1 and parameter[1][@type='com.orm.SugarTransactionHelper.Callback']]"
		[Register ("doInTransaction", "(Lcom/orm/SugarTransactionHelper$Callback;)V", "")]
		public static unsafe void DoInTransaction (global::Com.Orm.SugarTransactionHelper.ICallback p0)
		{
			if (id_doInTransaction_Lcom_orm_SugarTransactionHelper_Callback_ == IntPtr.Zero)
				id_doInTransaction_Lcom_orm_SugarTransactionHelper_Callback_ = JNIEnv.GetStaticMethodID (class_ref, "doInTransaction", "(Lcom/orm/SugarTransactionHelper$Callback;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_doInTransaction_Lcom_orm_SugarTransactionHelper_Callback_, __args);
			} finally {
			}
		}

	}
}
