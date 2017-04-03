using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Bolts {

	// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='Task']"
	[global::Android.Runtime.Register ("bolts/Task", DoNotGenerateAcw=true)]
	[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
	public partial class Task : global::Java.Lang.Object {


		static IntPtr BACKGROUND_EXECUTOR_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='bolts']/class[@name='Task']/field[@name='BACKGROUND_EXECUTOR']"
		[Register ("BACKGROUND_EXECUTOR")]
		public static global::Java.Util.Concurrent.IExecutorService BackgroundExecutor {
			get {
				if (BACKGROUND_EXECUTOR_jfieldId == IntPtr.Zero)
					BACKGROUND_EXECUTOR_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "BACKGROUND_EXECUTOR", "Ljava/util/concurrent/ExecutorService;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, BACKGROUND_EXECUTOR_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutorService> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr UI_THREAD_EXECUTOR_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='bolts']/class[@name='Task']/field[@name='UI_THREAD_EXECUTOR']"
		[Register ("UI_THREAD_EXECUTOR")]
		public static global::Java.Util.Concurrent.IExecutor UiThreadExecutor {
			get {
				if (UI_THREAD_EXECUTOR_jfieldId == IntPtr.Zero)
					UI_THREAD_EXECUTOR_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "UI_THREAD_EXECUTOR", "Ljava/util/concurrent/Executor;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, UI_THREAD_EXECUTOR_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		// Metadata.xml XPath class reference: path="/api/package[@name='bolts']/class[@name='Task.TaskCompletionSource']"
		[global::Android.Runtime.Register ("bolts/Task$TaskCompletionSource", DoNotGenerateAcw=true)]
		public partial class TaskCompletionSource : global::Bolts.TaskCompletionSource {

			protected TaskCompletionSource (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		// Metadata.xml XPath interface reference: path="/api/package[@name='bolts']/interface[@name='Task.UnobservedExceptionHandler']"
		[Register ("bolts/Task$UnobservedExceptionHandler", "", "Bolts.Task/IUnobservedExceptionHandlerInvoker")]
		public partial interface IUnobservedExceptionHandler : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/interface[@name='Task.UnobservedExceptionHandler']/method[@name='unobservedException' and count(parameter)=2 and parameter[1][@type='bolts.Task&lt;?&gt;'] and parameter[2][@type='bolts.UnobservedTaskException']]"
			[Register ("unobservedException", "(Lbolts/Task;Lbolts/UnobservedTaskException;)V", "GetUnobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_Handler:Bolts.Task/IUnobservedExceptionHandlerInvoker, MessageSDKBinding.Droid")]
			void UnobservedException (global::Bolts.Task p0, global::Bolts.UnobservedTaskException p1);

		}

		[global::Android.Runtime.Register ("bolts/Task$UnobservedExceptionHandler", DoNotGenerateAcw=true)]
		internal class IUnobservedExceptionHandlerInvoker : global::Java.Lang.Object, IUnobservedExceptionHandler {

			static IntPtr java_class_ref = JNIEnv.FindClass ("bolts/Task$UnobservedExceptionHandler");

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (IUnobservedExceptionHandlerInvoker); }
			}

			IntPtr class_ref;

			public static IUnobservedExceptionHandler GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IUnobservedExceptionHandler> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "bolts.Task.UnobservedExceptionHandler"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IUnobservedExceptionHandlerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate cb_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_;
#pragma warning disable 0169
			static Delegate GetUnobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_Handler ()
			{
				if (cb_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_ == null)
					cb_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_UnobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_);
				return cb_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_;
			}

			static void n_UnobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				global::Bolts.Task.IUnobservedExceptionHandler __this = global::Java.Lang.Object.GetObject<global::Bolts.Task.IUnobservedExceptionHandler> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Bolts.Task p0 = global::Java.Lang.Object.GetObject<global::Bolts.Task> (native_p0, JniHandleOwnership.DoNotTransfer);
				global::Bolts.UnobservedTaskException p1 = global::Java.Lang.Object.GetObject<global::Bolts.UnobservedTaskException> (native_p1, JniHandleOwnership.DoNotTransfer);
				__this.UnobservedException (p0, p1);
			}
#pragma warning restore 0169

			IntPtr id_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_;
			public unsafe void UnobservedException (global::Bolts.Task p0, global::Bolts.UnobservedTaskException p1)
			{
				if (id_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_ == IntPtr.Zero)
					id_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_ = JNIEnv.GetMethodID (class_ref, "unobservedException", "(Lbolts/Task;Lbolts/UnobservedTaskException;)V");
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_unobservedException_Lbolts_Task_Lbolts_UnobservedTaskException_, __args);
			}

		}


		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("bolts/Task", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Task); }
		}

		protected Task (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static Delegate cb_getError;
#pragma warning disable 0169
		static Delegate GetGetErrorHandler ()
		{
			if (cb_getError == null)
				cb_getError = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetError);
			return cb_getError;
		}

		static IntPtr n_GetError (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Error);
		}
#pragma warning restore 0169

		static IntPtr id_getError;
		public virtual unsafe global::Java.Lang.Exception Error {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='getError' and count(parameter)=0]"
			[Register ("getError", "()Ljava/lang/Exception;", "GetGetErrorHandler")]
			get {
				if (id_getError == IntPtr.Zero)
					id_getError = JNIEnv.GetMethodID (class_ref, "getError", "()Ljava/lang/Exception;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Exception> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getError), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Exception> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getError", "()Ljava/lang/Exception;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_isCancelled;
#pragma warning disable 0169
		static Delegate GetIsCancelledHandler ()
		{
			if (cb_isCancelled == null)
				cb_isCancelled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsCancelled);
			return cb_isCancelled;
		}

		static bool n_IsCancelled (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCancelled;
		}
#pragma warning restore 0169

		static IntPtr id_isCancelled;
		public virtual unsafe bool IsCancelled {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='isCancelled' and count(parameter)=0]"
			[Register ("isCancelled", "()Z", "GetIsCancelledHandler")]
			get {
				if (id_isCancelled == IntPtr.Zero)
					id_isCancelled = JNIEnv.GetMethodID (class_ref, "isCancelled", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCancelled);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCancelled", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_isCompleted;
#pragma warning disable 0169
		static Delegate GetIsCompletedHandler ()
		{
			if (cb_isCompleted == null)
				cb_isCompleted = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsCompleted);
			return cb_isCompleted;
		}

		static bool n_IsCompleted (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsCompleted;
		}
#pragma warning restore 0169

		static IntPtr id_isCompleted;
		public virtual unsafe bool IsCompleted {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='isCompleted' and count(parameter)=0]"
			[Register ("isCompleted", "()Z", "GetIsCompletedHandler")]
			get {
				if (id_isCompleted == IntPtr.Zero)
					id_isCompleted = JNIEnv.GetMethodID (class_ref, "isCompleted", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCompleted);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isCompleted", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_isFaulted;
#pragma warning disable 0169
		static Delegate GetIsFaultedHandler ()
		{
			if (cb_isFaulted == null)
				cb_isFaulted = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsFaulted);
			return cb_isFaulted;
		}

		static bool n_IsFaulted (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsFaulted;
		}
#pragma warning restore 0169

		static IntPtr id_isFaulted;
		public virtual unsafe bool IsFaulted {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='isFaulted' and count(parameter)=0]"
			[Register ("isFaulted", "()Z", "GetIsFaultedHandler")]
			get {
				if (id_isFaulted == IntPtr.Zero)
					id_isFaulted = JNIEnv.GetMethodID (class_ref, "isFaulted", "()Z");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isFaulted);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isFaulted", "()Z"));
				} finally {
				}
			}
		}

		static Delegate cb_getResult;
#pragma warning disable 0169
		static Delegate GetGetResultHandler ()
		{
			if (cb_getResult == null)
				cb_getResult = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetResult);
			return cb_getResult;
		}

		static IntPtr n_GetResult (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Result);
		}
#pragma warning restore 0169

		static IntPtr id_getResult;
		public virtual unsafe global::Java.Lang.Object Result {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='getResult' and count(parameter)=0]"
			[Register ("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
			get {
				if (id_getResult == IntPtr.Zero)
					id_getResult = JNIEnv.GetMethodID (class_ref, "getResult", "()Ljava/lang/Object;");
				try {

					if (GetType () == ThresholdType)
						return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getResult), JniHandleOwnership.TransferLocalRef);
					else
						return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getResult", "()Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getUnobservedExceptionHandler;
		static IntPtr id_setUnobservedExceptionHandler_Lbolts_Task_UnobservedExceptionHandler_;
		public static unsafe global::Bolts.Task.IUnobservedExceptionHandler UnobservedExceptionHandler {
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='getUnobservedExceptionHandler' and count(parameter)=0]"
			[Register ("getUnobservedExceptionHandler", "()Lbolts/Task$UnobservedExceptionHandler;", "GetGetUnobservedExceptionHandlerHandler")]
			get {
				if (id_getUnobservedExceptionHandler == IntPtr.Zero)
					id_getUnobservedExceptionHandler = JNIEnv.GetStaticMethodID (class_ref, "getUnobservedExceptionHandler", "()Lbolts/Task$UnobservedExceptionHandler;");
				try {
					return global::Java.Lang.Object.GetObject<global::Bolts.Task.IUnobservedExceptionHandler> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getUnobservedExceptionHandler), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='setUnobservedExceptionHandler' and count(parameter)=1 and parameter[1][@type='bolts.Task.UnobservedExceptionHandler']]"
			[Register ("setUnobservedExceptionHandler", "(Lbolts/Task$UnobservedExceptionHandler;)V", "GetSetUnobservedExceptionHandler_Lbolts_Task_UnobservedExceptionHandler_Handler")]
			set {
				if (id_setUnobservedExceptionHandler_Lbolts_Task_UnobservedExceptionHandler_ == IntPtr.Zero)
					id_setUnobservedExceptionHandler_Lbolts_Task_UnobservedExceptionHandler_ = JNIEnv.GetStaticMethodID (class_ref, "setUnobservedExceptionHandler", "(Lbolts/Task$UnobservedExceptionHandler;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);
					JNIEnv.CallStaticVoidMethod  (class_ref, id_setUnobservedExceptionHandler_Lbolts_Task_UnobservedExceptionHandler_, __args);
				} finally {
				}
			}
		}

		static IntPtr id_call_Ljava_util_concurrent_Callable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='call' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;']]"
		[Register ("call", "(Ljava/util/concurrent/Callable;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task Call (global::Java.Util.Concurrent.ICallable p0)
		{
			if (id_call_Ljava_util_concurrent_Callable_ == IntPtr.Zero)
				id_call_Ljava_util_concurrent_Callable_ = JNIEnv.GetStaticMethodID (class_ref, "call", "(Ljava/util/concurrent/Callable;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_call_Ljava_util_concurrent_Callable_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_call_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='call' and count(parameter)=2 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("call", "(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task Call (global::Java.Util.Concurrent.ICallable p0, global::Bolts.CancellationToken p1)
		{
			if (id_call_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_call_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_ = JNIEnv.GetStaticMethodID (class_ref, "call", "(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_call_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='call' and count(parameter)=2 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor']]"
		[Register ("call", "(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task Call (global::Java.Util.Concurrent.ICallable p0, global::Java.Util.Concurrent.IExecutor p1)
		{
			if (id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_ = JNIEnv.GetStaticMethodID (class_ref, "call", "(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='call' and count(parameter)=3 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("call", "(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task Call (global::Java.Util.Concurrent.ICallable p0, global::Java.Util.Concurrent.IExecutor p1, global::Bolts.CancellationToken p2)
		{
			if (id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetStaticMethodID (class_ref, "call", "(Ljava/util/concurrent/Callable;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_call_Ljava_util_concurrent_Callable_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_callInBackground_Ljava_util_concurrent_Callable_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='callInBackground' and count(parameter)=1 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;']]"
		[Register ("callInBackground", "(Ljava/util/concurrent/Callable;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task CallInBackground (global::Java.Util.Concurrent.ICallable p0)
		{
			if (id_callInBackground_Ljava_util_concurrent_Callable_ == IntPtr.Zero)
				id_callInBackground_Ljava_util_concurrent_Callable_ = JNIEnv.GetStaticMethodID (class_ref, "callInBackground", "(Ljava/util/concurrent/Callable;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_callInBackground_Ljava_util_concurrent_Callable_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_callInBackground_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='callInBackground' and count(parameter)=2 and parameter[1][@type='java.util.concurrent.Callable&lt;TResult&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("callInBackground", "(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task CallInBackground (global::Java.Util.Concurrent.ICallable p0, global::Bolts.CancellationToken p1)
		{
			if (id_callInBackground_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_callInBackground_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_ = JNIEnv.GetStaticMethodID (class_ref, "callInBackground", "(Ljava/util/concurrent/Callable;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_callInBackground_Ljava_util_concurrent_Callable_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_cancelled;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='cancelled' and count(parameter)=0]"
		[Register ("cancelled", "()Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task Cancelled ()
		{
			if (id_cancelled == IntPtr.Zero)
				id_cancelled = JNIEnv.GetStaticMethodID (class_ref, "cancelled", "()Lbolts/Task;");
			try {
				return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_cancelled), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_cast;
#pragma warning disable 0169
		static Delegate GetCastHandler ()
		{
			if (cb_cast == null)
				cb_cast = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Cast);
			return cb_cast;
		}

		static IntPtr n_Cast (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Cast ());
		}
#pragma warning restore 0169

		static IntPtr id_cast;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='cast' and count(parameter)=0]"
		[Register ("cast", "()Lbolts/Task;", "GetCastHandler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TOut"})]
		public virtual unsafe global::Bolts.Task Cast ()
		{
			if (id_cast == IntPtr.Zero)
				id_cast = JNIEnv.GetMethodID (class_ref, "cast", "()Lbolts/Task;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_cast), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "cast", "()Lbolts/Task;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_;
#pragma warning disable 0169
		static Delegate GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Handler ()
		{
			if (cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_ == null)
				cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_);
			return cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_;
		}

		static IntPtr n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.ICallable p0 = (global::Java.Util.Concurrent.ICallable)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.ICallable> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p1 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWhile (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWhile' and count(parameter)=2 and parameter[1][@type='java.util.concurrent.Callable&lt;java.lang.Boolean&gt;'] and parameter[2][@type='bolts.Continuation&lt;java.lang.Void, bolts.Task&lt;java.lang.Void&gt;&gt;']]"
		[Register ("continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;)Lbolts/Task;", "GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Handler")]
		public virtual unsafe global::Bolts.Task ContinueWhile (global::Java.Util.Concurrent.ICallable p0, global::Bolts.IContinuation p1)
		{
			if (id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_ == IntPtr.Zero)
				id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_ = JNIEnv.GetMethodID (class_ref, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_ == null)
				cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_);
			return cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.ICallable p0 = (global::Java.Util.Concurrent.ICallable)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.ICallable> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p1 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p2 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWhile (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWhile' and count(parameter)=3 and parameter[1][@type='java.util.concurrent.Callable&lt;java.lang.Boolean&gt;'] and parameter[2][@type='bolts.Continuation&lt;java.lang.Void, bolts.Task&lt;java.lang.Void&gt;&gt;'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_Handler")]
		public virtual unsafe global::Bolts.Task ContinueWhile (global::Java.Util.Concurrent.ICallable p0, global::Bolts.IContinuation p1, global::Bolts.CancellationToken p2)
		{
			if (id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
#pragma warning disable 0169
		static Delegate GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler ()
		{
			if (cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == null)
				cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_);
			return cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		}

		static IntPtr n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.ICallable p0 = (global::Java.Util.Concurrent.ICallable)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.ICallable> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p1 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p2 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWhile (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWhile' and count(parameter)=3 and parameter[1][@type='java.util.concurrent.Callable&lt;java.lang.Boolean&gt;'] and parameter[2][@type='bolts.Continuation&lt;java.lang.Void, bolts.Task&lt;java.lang.Void&gt;&gt;'] and parameter[3][@type='java.util.concurrent.Executor']]"
		[Register ("continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;", "GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler")]
		public virtual unsafe global::Bolts.Task ContinueWhile (global::Java.Util.Concurrent.ICallable p0, global::Bolts.IContinuation p1, global::Java.Util.Concurrent.IExecutor p2)
		{
			if (id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID (class_ref, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == null)
				cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_);
			return cb_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.ICallable p0 = (global::Java.Util.Concurrent.ICallable)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.ICallable> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p1 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p2 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p3 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWhile (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWhile' and count(parameter)=4 and parameter[1][@type='java.util.concurrent.Callable&lt;java.lang.Boolean&gt;'] and parameter[2][@type='bolts.Continuation&lt;java.lang.Void, bolts.Task&lt;java.lang.Void&gt;&gt;'] and parameter[3][@type='java.util.concurrent.Executor'] and parameter[4][@type='bolts.CancellationToken']]"
		[Register ("continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler")]
		public virtual unsafe global::Bolts.Task ContinueWhile (global::Java.Util.Concurrent.ICallable p0, global::Bolts.IContinuation p1, global::Java.Util.Concurrent.IExecutor p2, global::Bolts.CancellationToken p3)
		{
			if (id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWhile_Ljava_util_concurrent_Callable_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWhile", "(Ljava/util/concurrent/Callable;Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWith_Lbolts_Continuation_;
#pragma warning disable 0169
		static Delegate GetContinueWith_Lbolts_Continuation_Handler ()
		{
			if (cb_continueWith_Lbolts_Continuation_ == null)
				cb_continueWith_Lbolts_Continuation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWith_Lbolts_Continuation_);
			return cb_continueWith_Lbolts_Continuation_;
		}

		static IntPtr n_ContinueWith_Lbolts_Continuation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWith (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWith_Lbolts_Continuation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWith' and count(parameter)=1 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;']]"
		[Register ("continueWith", "(Lbolts/Continuation;)Lbolts/Task;", "GetContinueWith_Lbolts_Continuation_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWith (global::Bolts.IContinuation p0)
		{
			if (id_continueWith_Lbolts_Continuation_ == IntPtr.Zero)
				id_continueWith_Lbolts_Continuation_ = JNIEnv.GetMethodID (class_ref, "continueWith", "(Lbolts/Continuation;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWith_Lbolts_Continuation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWith", "(Lbolts/Continuation;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWith_Lbolts_Continuation_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_ == null)
				cb_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWith_Lbolts_Continuation_Lbolts_CancellationToken_);
			return cb_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWith_Lbolts_Continuation_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p1 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWith (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWith' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("continueWith", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWith_Lbolts_Continuation_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWith (global::Bolts.IContinuation p0, global::Bolts.CancellationToken p1)
		{
			if (id_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWith", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWith_Lbolts_Continuation_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWith", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
#pragma warning disable 0169
		static Delegate GetContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler ()
		{
			if (cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == null)
				cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_);
			return cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		}

		static IntPtr n_ContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWith (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWith' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor']]"
		[Register ("continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;", "GetContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWith (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1)
		{
			if (id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID (class_ref, "continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == null)
				cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_);
			return cb_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p2 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWith (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWith' and count(parameter)=3 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWith (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1, global::Bolts.CancellationToken p2)
		{
			if (id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWith_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWith", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWithTask_Lbolts_Continuation_;
#pragma warning disable 0169
		static Delegate GetContinueWithTask_Lbolts_Continuation_Handler ()
		{
			if (cb_continueWithTask_Lbolts_Continuation_ == null)
				cb_continueWithTask_Lbolts_Continuation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWithTask_Lbolts_Continuation_);
			return cb_continueWithTask_Lbolts_Continuation_;
		}

		static IntPtr n_ContinueWithTask_Lbolts_Continuation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWithTask (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWithTask_Lbolts_Continuation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWithTask' and count(parameter)=1 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;']]"
		[Register ("continueWithTask", "(Lbolts/Continuation;)Lbolts/Task;", "GetContinueWithTask_Lbolts_Continuation_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWithTask (global::Bolts.IContinuation p0)
		{
			if (id_continueWithTask_Lbolts_Continuation_ == IntPtr.Zero)
				id_continueWithTask_Lbolts_Continuation_ = JNIEnv.GetMethodID (class_ref, "continueWithTask", "(Lbolts/Continuation;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWithTask_Lbolts_Continuation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWithTask", "(Lbolts/Continuation;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_ == null)
				cb_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_);
			return cb_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p1 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWithTask (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWithTask' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("continueWithTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWithTask (global::Bolts.IContinuation p0, global::Bolts.CancellationToken p1)
		{
			if (id_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWithTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWithTask_Lbolts_Continuation_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWithTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
#pragma warning disable 0169
		static Delegate GetContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler ()
		{
			if (cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == null)
				cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_);
			return cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		}

		static IntPtr n_ContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWithTask (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWithTask' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='java.util.concurrent.Executor']]"
		[Register ("continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;", "GetContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWithTask (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1)
		{
			if (id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID (class_ref, "continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler ()
		{
			if (cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == null)
				cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_ContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_);
			return cb_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		}

		static IntPtr n_ContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p2 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.ContinueWithTask (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='continueWithTask' and count(parameter)=3 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='java.util.concurrent.Executor'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "GetContinueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task ContinueWithTask (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1, global::Bolts.CancellationToken p2)
		{
			if (id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_continueWithTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "continueWithTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_create;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='create' and count(parameter)=0]"
		[Register ("create", "()Lbolts/Task$TaskCompletionSource;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task.TaskCompletionSource Create ()
		{
			if (id_create == IntPtr.Zero)
				id_create = JNIEnv.GetStaticMethodID (class_ref, "create", "()Lbolts/Task$TaskCompletionSource;");
			try {
				return global::Java.Lang.Object.GetObject<global::Bolts.Task.TaskCompletionSource> (JNIEnv.CallStaticObjectMethod  (class_ref, id_create), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_delay_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='delay' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("delay", "(J)Lbolts/Task;", "")]
		public static unsafe global::Bolts.Task Delay (long p0)
		{
			if (id_delay_J == IntPtr.Zero)
				id_delay_J = JNIEnv.GetStaticMethodID (class_ref, "delay", "(J)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_delay_J, __args), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_delay_JLbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='delay' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("delay", "(JLbolts/CancellationToken;)Lbolts/Task;", "")]
		public static unsafe global::Bolts.Task Delay (long p0, global::Bolts.CancellationToken p1)
		{
			if (id_delay_JLbolts_CancellationToken_ == IntPtr.Zero)
				id_delay_JLbolts_CancellationToken_ = JNIEnv.GetStaticMethodID (class_ref, "delay", "(JLbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_delay_JLbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_forError_Ljava_lang_Exception_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='forError' and count(parameter)=1 and parameter[1][@type='java.lang.Exception']]"
		[Register ("forError", "(Ljava/lang/Exception;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task ForError (global::Java.Lang.Exception p0)
		{
			if (id_forError_Ljava_lang_Exception_ == IntPtr.Zero)
				id_forError_Ljava_lang_Exception_ = JNIEnv.GetStaticMethodID (class_ref, "forError", "(Ljava/lang/Exception;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_forError_Ljava_lang_Exception_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_forResult_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='forResult' and count(parameter)=1 and parameter[1][@type='TResult']]"
		[Register ("forResult", "(Ljava/lang/Object;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task ForResult (global::Java.Lang.Object p0)
		{
			if (id_forResult_Ljava_lang_Object_ == IntPtr.Zero)
				id_forResult_Ljava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "forResult", "(Ljava/lang/Object;)Lbolts/Task;");
			IntPtr native_p0 = JNIEnv.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_forResult_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_makeVoid;
#pragma warning disable 0169
		static Delegate GetMakeVoidHandler ()
		{
			if (cb_makeVoid == null)
				cb_makeVoid = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_MakeVoid);
			return cb_makeVoid;
		}

		static IntPtr n_MakeVoid (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.MakeVoid ());
		}
#pragma warning restore 0169

		static IntPtr id_makeVoid;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='makeVoid' and count(parameter)=0]"
		[Register ("makeVoid", "()Lbolts/Task;", "GetMakeVoidHandler")]
		public virtual unsafe global::Bolts.Task MakeVoid ()
		{
			if (id_makeVoid == IntPtr.Zero)
				id_makeVoid = JNIEnv.GetMethodID (class_ref, "makeVoid", "()Lbolts/Task;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_makeVoid), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "makeVoid", "()Lbolts/Task;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_onSuccess_Lbolts_Continuation_;
#pragma warning disable 0169
		static Delegate GetOnSuccess_Lbolts_Continuation_Handler ()
		{
			if (cb_onSuccess_Lbolts_Continuation_ == null)
				cb_onSuccess_Lbolts_Continuation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccess_Lbolts_Continuation_);
			return cb_onSuccess_Lbolts_Continuation_;
		}

		static IntPtr n_OnSuccess_Lbolts_Continuation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccess (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccess_Lbolts_Continuation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccess' and count(parameter)=1 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;']]"
		[Register ("onSuccess", "(Lbolts/Continuation;)Lbolts/Task;", "GetOnSuccess_Lbolts_Continuation_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccess (global::Bolts.IContinuation p0)
		{
			if (id_onSuccess_Lbolts_Continuation_ == IntPtr.Zero)
				id_onSuccess_Lbolts_Continuation_ = JNIEnv.GetMethodID (class_ref, "onSuccess", "(Lbolts/Continuation;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccess_Lbolts_Continuation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccess", "(Lbolts/Continuation;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetOnSuccess_Lbolts_Continuation_Lbolts_CancellationToken_Handler ()
		{
			if (cb_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_ == null)
				cb_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccess_Lbolts_Continuation_Lbolts_CancellationToken_);
			return cb_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_;
		}

		static IntPtr n_OnSuccess_Lbolts_Continuation_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p1 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccess (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccess' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("onSuccess", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;", "GetOnSuccess_Lbolts_Continuation_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccess (global::Bolts.IContinuation p0, global::Bolts.CancellationToken p1)
		{
			if (id_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "onSuccess", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccess_Lbolts_Continuation_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccess", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
#pragma warning disable 0169
		static Delegate GetOnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler ()
		{
			if (cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == null)
				cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_);
			return cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		}

		static IntPtr n_OnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccess (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccess' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor']]"
		[Register ("onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;", "GetOnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccess (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1)
		{
			if (id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID (class_ref, "onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetOnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler ()
		{
			if (cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == null)
				cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_);
			return cb_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		}

		static IntPtr n_OnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p2 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccess (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccess' and count(parameter)=3 and parameter[1][@type='bolts.Continuation&lt;TResult, TContinuationResult&gt;'] and parameter[2][@type='java.util.concurrent.Executor'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "GetOnSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccess (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1, global::Bolts.CancellationToken p2)
		{
			if (id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccess_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccess", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccessTask_Lbolts_Continuation_;
#pragma warning disable 0169
		static Delegate GetOnSuccessTask_Lbolts_Continuation_Handler ()
		{
			if (cb_onSuccessTask_Lbolts_Continuation_ == null)
				cb_onSuccessTask_Lbolts_Continuation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccessTask_Lbolts_Continuation_);
			return cb_onSuccessTask_Lbolts_Continuation_;
		}

		static IntPtr n_OnSuccessTask_Lbolts_Continuation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccessTask (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccessTask_Lbolts_Continuation_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccessTask' and count(parameter)=1 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;']]"
		[Register ("onSuccessTask", "(Lbolts/Continuation;)Lbolts/Task;", "GetOnSuccessTask_Lbolts_Continuation_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccessTask (global::Bolts.IContinuation p0)
		{
			if (id_onSuccessTask_Lbolts_Continuation_ == IntPtr.Zero)
				id_onSuccessTask_Lbolts_Continuation_ = JNIEnv.GetMethodID (class_ref, "onSuccessTask", "(Lbolts/Continuation;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccessTask_Lbolts_Continuation_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccessTask", "(Lbolts/Continuation;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetOnSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_Handler ()
		{
			if (cb_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_ == null)
				cb_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_);
			return cb_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_;
		}

		static IntPtr n_OnSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p1 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccessTask (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccessTask' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='bolts.CancellationToken']]"
		[Register ("onSuccessTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;", "GetOnSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccessTask (global::Bolts.IContinuation p0, global::Bolts.CancellationToken p1)
		{
			if (id_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "onSuccessTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccessTask_Lbolts_Continuation_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccessTask", "(Lbolts/Continuation;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
#pragma warning disable 0169
		static Delegate GetOnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler ()
		{
			if (cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == null)
				cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_);
			return cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		}

		static IntPtr n_OnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccessTask (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccessTask' and count(parameter)=2 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='java.util.concurrent.Executor']]"
		[Register ("onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;", "GetOnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccessTask (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1)
		{
			if (id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ == IntPtr.Zero)
				id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_ = JNIEnv.GetMethodID (class_ref, "onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
#pragma warning disable 0169
		static Delegate GetOnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler ()
		{
			if (cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == null)
				cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_OnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_);
			return cb_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		}

		static IntPtr n_OnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Bolts.IContinuation p0 = (global::Bolts.IContinuation)global::Java.Lang.Object.GetObject<global::Bolts.IContinuation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.IExecutor p1 = (global::Java.Util.Concurrent.IExecutor)global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.IExecutor> (native_p1, JniHandleOwnership.DoNotTransfer);
			global::Bolts.CancellationToken p2 = global::Java.Lang.Object.GetObject<global::Bolts.CancellationToken> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnSuccessTask (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='onSuccessTask' and count(parameter)=3 and parameter[1][@type='bolts.Continuation&lt;TResult, bolts.Task&lt;TContinuationResult&gt;&gt;'] and parameter[2][@type='java.util.concurrent.Executor'] and parameter[3][@type='bolts.CancellationToken']]"
		[Register ("onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;", "GetOnSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_Handler")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TContinuationResult"})]
		public virtual unsafe global::Bolts.Task OnSuccessTask (global::Bolts.IContinuation p0, global::Java.Util.Concurrent.IExecutor p1, global::Bolts.CancellationToken p2)
		{
			if (id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ == IntPtr.Zero)
				id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_ = JNIEnv.GetMethodID (class_ref, "onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				global::Bolts.Task __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_onSuccessTask_Lbolts_Continuation_Ljava_util_concurrent_Executor_Lbolts_CancellationToken_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onSuccessTask", "(Lbolts/Continuation;Ljava/util/concurrent/Executor;Lbolts/CancellationToken;)Lbolts/Task;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_waitForCompletion;
#pragma warning disable 0169
		static Delegate GetWaitForCompletionHandler ()
		{
			if (cb_waitForCompletion == null)
				cb_waitForCompletion = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_WaitForCompletion);
			return cb_waitForCompletion;
		}

		static void n_WaitForCompletion (IntPtr jnienv, IntPtr native__this)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.WaitForCompletion ();
		}
#pragma warning restore 0169

		static IntPtr id_waitForCompletion;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='waitForCompletion' and count(parameter)=0]"
		[Register ("waitForCompletion", "()V", "GetWaitForCompletionHandler")]
		public virtual unsafe void WaitForCompletion ()
		{
			if (id_waitForCompletion == IntPtr.Zero)
				id_waitForCompletion = JNIEnv.GetMethodID (class_ref, "waitForCompletion", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_waitForCompletion);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "waitForCompletion", "()V"));
			} finally {
			}
		}

		static Delegate cb_waitForCompletion_JLjava_util_concurrent_TimeUnit_;
#pragma warning disable 0169
		static Delegate GetWaitForCompletion_JLjava_util_concurrent_TimeUnit_Handler ()
		{
			if (cb_waitForCompletion_JLjava_util_concurrent_TimeUnit_ == null)
				cb_waitForCompletion_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long, IntPtr, bool>) n_WaitForCompletion_JLjava_util_concurrent_TimeUnit_);
			return cb_waitForCompletion_JLjava_util_concurrent_TimeUnit_;
		}

		static bool n_WaitForCompletion_JLjava_util_concurrent_TimeUnit_ (IntPtr jnienv, IntPtr native__this, long p0, IntPtr native_p1)
		{
			global::Bolts.Task __this = global::Java.Lang.Object.GetObject<global::Bolts.Task> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Util.Concurrent.TimeUnit p1 = global::Java.Lang.Object.GetObject<global::Java.Util.Concurrent.TimeUnit> (native_p1, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.WaitForCompletion (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_waitForCompletion_JLjava_util_concurrent_TimeUnit_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='waitForCompletion' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='java.util.concurrent.TimeUnit']]"
		[Register ("waitForCompletion", "(JLjava/util/concurrent/TimeUnit;)Z", "GetWaitForCompletion_JLjava_util_concurrent_TimeUnit_Handler")]
		public virtual unsafe bool WaitForCompletion (long p0, global::Java.Util.Concurrent.TimeUnit p1)
		{
			if (id_waitForCompletion_JLjava_util_concurrent_TimeUnit_ == IntPtr.Zero)
				id_waitForCompletion_JLjava_util_concurrent_TimeUnit_ = JNIEnv.GetMethodID (class_ref, "waitForCompletion", "(JLjava/util/concurrent/TimeUnit;)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				bool __ret;
				if (GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_waitForCompletion_JLjava_util_concurrent_TimeUnit_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "waitForCompletion", "(JLjava/util/concurrent/TimeUnit;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_whenAll_Ljava_util_Collection_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='whenAll' and count(parameter)=1 and parameter[1][@type='java.util.Collection&lt;? extends bolts.Task&lt;?&gt;&gt;']]"
		[Register ("whenAll", "(Ljava/util/Collection;)Lbolts/Task;", "")]
		public static unsafe global::Bolts.Task WhenAll (global::System.Collections.ICollection p0)
		{
			if (id_whenAll_Ljava_util_Collection_ == IntPtr.Zero)
				id_whenAll_Ljava_util_Collection_ = JNIEnv.GetStaticMethodID (class_ref, "whenAll", "(Ljava/util/Collection;)Lbolts/Task;");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_whenAll_Ljava_util_Collection_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_whenAllResult_Ljava_util_Collection_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='whenAllResult' and count(parameter)=1 and parameter[1][@type='java.util.Collection&lt;? extends bolts.Task&lt;TResult&gt;&gt;']]"
		[Register ("whenAllResult", "(Ljava/util/Collection;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task WhenAllResult (global::System.Collections.ICollection p0)
		{
			if (id_whenAllResult_Ljava_util_Collection_ == IntPtr.Zero)
				id_whenAllResult_Ljava_util_Collection_ = JNIEnv.GetStaticMethodID (class_ref, "whenAllResult", "(Ljava/util/Collection;)Lbolts/Task;");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_whenAllResult_Ljava_util_Collection_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_whenAny_Ljava_util_Collection_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='whenAny' and count(parameter)=1 and parameter[1][@type='java.util.Collection&lt;? extends bolts.Task&lt;?&gt;&gt;']]"
		[Register ("whenAny", "(Ljava/util/Collection;)Lbolts/Task;", "")]
		public static unsafe global::Bolts.Task WhenAny (global::System.Collections.ICollection p0)
		{
			if (id_whenAny_Ljava_util_Collection_ == IntPtr.Zero)
				id_whenAny_Ljava_util_Collection_ = JNIEnv.GetStaticMethodID (class_ref, "whenAny", "(Ljava/util/Collection;)Lbolts/Task;");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_whenAny_Ljava_util_Collection_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_whenAnyResult_Ljava_util_Collection_;
		// Metadata.xml XPath method reference: path="/api/package[@name='bolts']/class[@name='Task']/method[@name='whenAnyResult' and count(parameter)=1 and parameter[1][@type='java.util.Collection&lt;? extends bolts.Task&lt;TResult&gt;&gt;']]"
		[Register ("whenAnyResult", "(Ljava/util/Collection;)Lbolts/Task;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"TResult"})]
		public static unsafe global::Bolts.Task WhenAnyResult (global::System.Collections.ICollection p0)
		{
			if (id_whenAnyResult_Ljava_util_Collection_ == IntPtr.Zero)
				id_whenAnyResult_Ljava_util_Collection_ = JNIEnv.GetStaticMethodID (class_ref, "whenAnyResult", "(Ljava/util/Collection;)Lbolts/Task;");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Bolts.Task __ret = global::Java.Lang.Object.GetObject<global::Bolts.Task> (JNIEnv.CallStaticObjectMethod  (class_ref, id_whenAnyResult_Ljava_util_Collection_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
