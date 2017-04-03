using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']"
	[global::Android.Runtime.Register ("bolts/TaskCompletionSource", DoNotGenerateAcw=true)]
	[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
	public partial class TaskCompletionSource : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("bolts/TaskCompletionSource", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (TaskCompletionSource); }
		}

		protected TaskCompletionSource (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/constructor[@name='TaskCompletionSource' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe TaskCompletionSource ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (TaskCompletionSource)) {
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

		static Delegate cb_getTask;
#pragma warning disable 0169
		static Delegate GetGetTaskHandler ()
		{
			if (cb_getTask == null)
				cb_getTask = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTask);
			return cb_getTask;
		}

		static IntPtr n_GetTask (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Task);
		}
#pragma warning restore 0169

		static IntPtr id_getTask;
		public virtual unsafe global::Bolts.Task Task {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='getTask' and count(parameter)=0]"
			[Register ("getTask", "()Lbolts/Task;", "GetGetTaskHandler")]
			get {
				if (id_getTask == IntPtr.Zero)
					id_getTask = JNIEnv.GetMethodID (class_ref, "getTask", "()Lbolts/Task;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTask), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTask", "()Lbolts/Task;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_setCancelled;
#pragma warning disable 0169
		static Delegate GetSetCancelledHandler ()
		{
			if (cb_setCancelled == null)
				cb_setCancelled = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SetCancelled);
			return cb_setCancelled;
		}

		static void n_SetCancelled (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetCancelled ();
		}
#pragma warning restore 0169

		static IntPtr id_setCancelled;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='setCancelled' and count(parameter)=0]"
		[Register ("setCancelled", "()V", "GetSetCancelledHandler")]
		public virtual unsafe void SetCancelled ()
		{
			if (id_setCancelled == IntPtr.Zero)
				id_setCancelled = JNIEnv.GetMethodID (class_ref, "setCancelled", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCancelled);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCancelled", "()V"));
			} finally {
			}
		}

		static Delegate cb_setError_Ljava_lang_Exception_;
#pragma warning disable 0169
		static Delegate GetSetError_Ljava_lang_Exception_Handler ()
		{
			if (cb_setError_Ljava_lang_Exception_ == null)
				cb_setError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetError_Ljava_lang_Exception_);
			return cb_setError_Ljava_lang_Exception_;
		}

		static void n_SetError_Ljava_lang_Exception_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Exception p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Exception> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetError (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setError_Ljava_lang_Exception_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='setError' and count(parameter)=1 and parameter[1][@type='java.lang.Exception']]"
		[Register ("setError", "(Ljava/lang/Exception;)V", "GetSetError_Ljava_lang_Exception_Handler")]
		public virtual unsafe void SetError (global::Java.Lang.Exception p0)
		{
			if (id_setError_Ljava_lang_Exception_ == IntPtr.Zero)
				id_setError_Ljava_lang_Exception_ = JNIEnv.GetMethodID (class_ref, "setError", "(Ljava/lang/Exception;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setError_Ljava_lang_Exception_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setError", "(Ljava/lang/Exception;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setResult_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetSetResult_Ljava_lang_Object_Handler ()
		{
			if (cb_setResult_Ljava_lang_Object_ == null)
				cb_setResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetResult_Ljava_lang_Object_);
			return cb_setResult_Ljava_lang_Object_;
		}

		static void n_SetResult_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetResult (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setResult_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='setResult' and count(parameter)=1 and parameter[1][@type='TResult']]"
		[Register ("setResult", "(Ljava/lang/Object;)V", "GetSetResult_Ljava_lang_Object_Handler")]
		public virtual unsafe void SetResult (global::Java.Lang.Object p0)
		{
			if (id_setResult_Ljava_lang_Object_ == IntPtr.Zero)
				id_setResult_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "setResult", "(Ljava/lang/Object;)V");
			IntPtr native_p0 = JNIEnv.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setResult_Ljava_lang_Object_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setResult", "(Ljava/lang/Object;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_trySetCancelled;
#pragma warning disable 0169
		static Delegate GetTrySetCancelledHandler ()
		{
			if (cb_trySetCancelled == null)
				cb_trySetCancelled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_TrySetCancelled);
			return cb_trySetCancelled;
		}

		static bool n_TrySetCancelled (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.TrySetCancelled ();
		}
#pragma warning restore 0169

		static IntPtr id_trySetCancelled;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='trySetCancelled' and count(parameter)=0]"
		[Register ("trySetCancelled", "()Z", "GetTrySetCancelledHandler")]
		public virtual unsafe bool TrySetCancelled ()
		{
			if (id_trySetCancelled == IntPtr.Zero)
				id_trySetCancelled = JNIEnv.GetMethodID (class_ref, "trySetCancelled", "()Z");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_trySetCancelled);
				else
					return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "trySetCancelled", "()Z"));
			} finally {
			}
		}

		static Delegate cb_trySetError_Ljava_lang_Exception_;
#pragma warning disable 0169
		static Delegate GetTrySetError_Ljava_lang_Exception_Handler ()
		{
			if (cb_trySetError_Ljava_lang_Exception_ == null)
				cb_trySetError_Ljava_lang_Exception_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_TrySetError_Ljava_lang_Exception_);
			return cb_trySetError_Ljava_lang_Exception_;
		}

		static bool n_TrySetError_Ljava_lang_Exception_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Exception p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Exception> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.TrySetError (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_trySetError_Ljava_lang_Exception_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='trySetError' and count(parameter)=1 and parameter[1][@type='java.lang.Exception']]"
		[Register ("trySetError", "(Ljava/lang/Exception;)Z", "GetTrySetError_Ljava_lang_Exception_Handler")]
		public virtual unsafe bool TrySetError (global::Java.Lang.Exception p0)
		{
			if (id_trySetError_Ljava_lang_Exception_ == IntPtr.Zero)
				id_trySetError_Ljava_lang_Exception_ = JNIEnv.GetMethodID (class_ref, "trySetError", "(Ljava/lang/Exception;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_trySetError_Ljava_lang_Exception_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "trySetError", "(Ljava/lang/Exception;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_trySetResult_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetTrySetResult_Ljava_lang_Object_Handler ()
		{
			if (cb_trySetResult_Ljava_lang_Object_ == null)
				cb_trySetResult_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_TrySetResult_Ljava_lang_Object_);
			return cb_trySetResult_Ljava_lang_Object_;
		}

		static bool n_TrySetResult_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.TaskCompletionSource __this = global::Java.Lang.Object.GetObject<global::Bolts.TaskCompletionSource> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.TrySetResult (p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_trySetResult_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='TaskCompletionSource']/method[@name='trySetResult' and count(parameter)=1 and parameter[1][@type='TResult']]"
		[Register ("trySetResult", "(Ljava/lang/Object;)Z", "GetTrySetResult_Ljava_lang_Object_Handler")]
		public virtual unsafe bool TrySetResult (global::Java.Lang.Object p0)
		{
			if (id_trySetResult_Ljava_lang_Object_ == IntPtr.Zero)
				id_trySetResult_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "trySetResult", "(Ljava/lang/Object;)Z");
			IntPtr native_p0 = JNIEnv.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_trySetResult_Ljava_lang_Object_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "trySetResult", "(Ljava/lang/Object;)Z"), __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
