using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']"
	[global::Android.Runtime.Register ("com/orm/SugarRecord", DoNotGenerateAcw=true)]
	public partial class SugarRecord : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord.CursorIterator']"
		[global::Android.Runtime.Register ("com/orm/SugarRecord$CursorIterator", DoNotGenerateAcw=true)]
		[global::Java.Interop.JavaTypeParameters (new string [] {"E"})]
		public partial class CursorIterator : global::Java.Lang.Object, global::Java.Util.IIterator {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/orm/SugarRecord$CursorIterator", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (CursorIterator); }
			}

			protected CursorIterator (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Ljava_lang_Class_Landroid_database_Cursor_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord.CursorIterator']/constructor[@name='SugarRecord.CursorIterator' and count(parameter)=2 and parameter[1][@type='java.lang.Class&lt;E&gt;'] and parameter[2][@type='android.database.Cursor']]"
			[Register (".ctor", "(Ljava/lang/Class;Landroid/database/Cursor;)V", "")]
			public unsafe CursorIterator (global::Java.Lang.Class p0, global::Android.Database.ICursor p1)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					if (GetType () != typeof (CursorIterator)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/Class;Landroid/database/Cursor;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Class;Landroid/database/Cursor;)V", __args);
						return;
					}

					if (id_ctor_Ljava_lang_Class_Landroid_database_Cursor_ == IntPtr.Zero)
						id_ctor_Ljava_lang_Class_Landroid_database_Cursor_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Class;Landroid/database/Cursor;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Class_Landroid_database_Cursor_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Class_Landroid_database_Cursor_, __args);
				} finally {
				}
			}

			static Delegate cb_hasNext;
#pragma warning disable 0169
			static Delegate GetHasNextHandler ()
			{
				if (cb_hasNext == null)
					cb_hasNext = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_HasNext);
				return cb_hasNext;
			}

			static bool n_HasNext (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Orm.SugarRecord.CursorIterator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord.CursorIterator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return __this.HasNext;
			}
#pragma warning restore 0169

			static IntPtr id_hasNext;
			public virtual unsafe bool HasNext {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord.CursorIterator']/method[@name='hasNext' and count(parameter)=0]"
				[Register ("hasNext", "()Z", "GetHasNextHandler")]
				get {
					if (id_hasNext == IntPtr.Zero)
						id_hasNext = JNIEnv.GetMethodID (class_ref, "hasNext", "()Z");
					try {

						if (GetType () == ThresholdType)
							return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasNext);
						else
							return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "hasNext", "()Z"));
					} finally {
					}
				}
			}

			static Delegate cb_next;
#pragma warning disable 0169
			static Delegate GetNextHandler ()
			{
				if (cb_next == null)
					cb_next = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Next);
				return cb_next;
			}

			static IntPtr n_Next (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Orm.SugarRecord.CursorIterator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord.CursorIterator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.Next ());
			}
#pragma warning restore 0169

			static IntPtr id_next;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord.CursorIterator']/method[@name='next' and count(parameter)=0]"
			[Register ("next", "()Ljava/lang/Object;", "GetNextHandler")]
			public virtual unsafe global::Java.Lang.Object Next ()
			{
				if (id_next == IntPtr.Zero)
					id_next = JNIEnv.GetMethodID (class_ref, "next", "()Ljava/lang/Object;");
				try {

					if (GetType () == ThresholdType)
						return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_next), JniHandleOwnership.TransferLocalRef);
					else
						return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "next", "()Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_remove;
#pragma warning disable 0169
			static Delegate GetRemoveHandler ()
			{
				if (cb_remove == null)
					cb_remove = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Remove);
				return cb_remove;
			}

			static void n_Remove (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Orm.SugarRecord.CursorIterator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord.CursorIterator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.Remove ();
			}
#pragma warning restore 0169

			static IntPtr id_remove;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord.CursorIterator']/method[@name='remove' and count(parameter)=0]"
			[Register ("remove", "()V", "GetRemoveHandler")]
			public virtual unsafe void Remove ()
			{
				if (id_remove == IntPtr.Zero)
					id_remove = JNIEnv.GetMethodID (class_ref, "remove", "()V");
				try {

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_remove);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "remove", "()V"));
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/SugarRecord", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarRecord); }
		}

		protected SugarRecord (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/constructor[@name='SugarRecord' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SugarRecord ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SugarRecord)) {
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

		static Delegate cb_getId;
#pragma warning disable 0169
		static Delegate GetGetIdHandler ()
		{
			if (cb_getId == null)
				cb_getId = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetId);
			return cb_getId;
		}

		static IntPtr n_GetId (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.SugarRecord __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Id);
		}
#pragma warning restore 0169

		static Delegate cb_setId_Ljava_lang_Long_;
#pragma warning disable 0169
		static Delegate GetSetId_Ljava_lang_Long_Handler ()
		{
			if (cb_setId_Ljava_lang_Long_ == null)
				cb_setId_Ljava_lang_Long_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetId_Ljava_lang_Long_);
			return cb_setId_Ljava_lang_Long_;
		}

		static void n_SetId_Ljava_lang_Long_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.SugarRecord __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Long p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Id = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getId;
		static IntPtr id_setId_Ljava_lang_Long_;
		public virtual unsafe global::Java.Lang.Long Id {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='getId' and count(parameter)=0]"
			[Register ("getId", "()Ljava/lang/Long;", "GetGetIdHandler")]
			get {
				if (id_getId == IntPtr.Zero)
					id_getId = JNIEnv.GetMethodID (class_ref, "getId", "()Ljava/lang/Long;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getId), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Long> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getId", "()Ljava/lang/Long;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='setId' and count(parameter)=1 and parameter[1][@type='java.lang.Long']]"
			[Register ("setId", "(Ljava/lang/Long;)V", "GetSetId_Ljava_lang_Long_Handler")]
			set {
				if (id_setId_Ljava_lang_Long_ == IntPtr.Zero)
					id_setId_Ljava_lang_Long_ = JNIEnv.GetMethodID (class_ref, "setId", "(Ljava/lang/Long;)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setId_Ljava_lang_Long_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setId", "(Ljava/lang/Long;)V"), __args);
				} finally {
				}
			}
		}

		static IntPtr id_count_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='count' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("count", "(Ljava/lang/Class;)J", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe long Count (global::Java.Lang.Class p0)
		{
			if (id_count_Ljava_lang_Class_ == IntPtr.Zero)
				id_count_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "count", "(Ljava/lang/Class;)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_count_Ljava_lang_Class_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='count' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;?&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String[]']]"
		[Register ("count", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)J", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe long Count (global::Java.Lang.Class p0, string p1, string[] p2)
		{
			if (id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "count", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)J");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='count' and count(parameter)=6 and parameter[1][@type='java.lang.Class&lt;?&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String[]'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='java.lang.String']]"
		[Register ("count", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)J", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe long Count (global::Java.Lang.Class p0, string p1, string[] p2, string p3, string p4, string p5)
		{
			if (id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "count", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)J");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (native_p5);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_count_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, __args);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

		static Delegate cb_delete;
#pragma warning disable 0169
		static Delegate GetDeleteHandler ()
		{
			if (cb_delete == null)
				cb_delete = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Delete);
			return cb_delete;
		}

		static void n_Delete (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.SugarRecord __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Delete ();
		}
#pragma warning restore 0169

		static IntPtr id_delete;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='delete' and count(parameter)=0]"
		[Register ("delete", "()V", "GetDeleteHandler")]
		public virtual unsafe void Delete ()
		{
			if (id_delete == IntPtr.Zero)
				id_delete = JNIEnv.GetMethodID (class_ref, "delete", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_delete);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "delete", "()V"));
			} finally {
			}
		}

		static IntPtr id_deleteAll_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='deleteAll' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register ("deleteAll", "(Ljava/lang/Class;)V", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe void DeleteAll (global::Java.Lang.Class p0)
		{
			if (id_deleteAll_Ljava_lang_Class_ == IntPtr.Zero)
				id_deleteAll_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "deleteAll", "(Ljava/lang/Class;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteAll_Ljava_lang_Class_, __args);
			} finally {
			}
		}

		static IntPtr id_deleteAll_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='deleteAll' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String...']]"
		[Register ("deleteAll", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)V", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe void DeleteAll (global::Java.Lang.Class p0, string p1, params  string[] p2)
		{
			if (id_deleteAll_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_deleteAll_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "deleteAll", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteAll_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_deleteInTx_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='deleteInTx' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register ("deleteInTx", "(Ljava/lang/Class;)V", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe void DeleteInTx (global::Java.Lang.Class p0)
		{
			if (id_deleteInTx_Ljava_lang_Class_ == IntPtr.Zero)
				id_deleteInTx_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "deleteInTx", "(Ljava/lang/Class;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_deleteInTx_Ljava_lang_Class_, __args);
			} finally {
			}
		}

		static IntPtr id_executeQuery_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='executeQuery' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String...']]"
		[Register ("executeQuery", "(Ljava/lang/String;[Ljava/lang/String;)V", "")]
		public static unsafe void ExecuteQuery (string p0, params  string[] p1)
		{
			if (id_executeQuery_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_executeQuery_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "executeQuery", "(Ljava/lang/String;[Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_executeQuery_Ljava_lang_String_arrayLjava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='find' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String...']]"
		[Register ("find", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/List;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.IList Find (global::Java.Lang.Class p0, string p1, params  string[] p2)
		{
			if (id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "find", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				global::System.Collections.IList __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='find' and count(parameter)=6 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String[]'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='java.lang.String']]"
		[Register ("find", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.IList Find (global::Java.Lang.Class p0, string p1, string[] p2, string p3, string p4, string p5)
		{
			if (id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "find", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (native_p5);
				global::System.Collections.IList __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_find_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

		static IntPtr id_findAll_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findAll' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register ("findAll", "(Ljava/lang/Class;)Ljava/util/Iterator;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Util.IIterator FindAll (global::Java.Lang.Class p0)
		{
			if (id_findAll_Ljava_lang_Class_ == IntPtr.Zero)
				id_findAll_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "findAll", "(Ljava/lang/Class;)Ljava/util/Iterator;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Java.Util.IIterator __ret = global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findAll_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findAsIterator' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String...']]"
		[Register ("findAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/Iterator;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Util.IIterator FindAsIterator (global::Java.Lang.Class p0, string p1, params  string[] p2)
		{
			if (id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/Iterator;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				global::Java.Util.IIterator __ret = global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findAsIterator' and count(parameter)=6 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String[]'] and parameter[4][@type='java.lang.String'] and parameter[5][@type='java.lang.String'] and parameter[6][@type='java.lang.String']]"
		[Register ("findAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/Iterator;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Util.IIterator FindAsIterator (global::Java.Lang.Class p0, string p1, string[] p2, string p3, string p4, string p5)
		{
			if (id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
				id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)Ljava/util/Iterator;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			IntPtr native_p5 = JNIEnv.NewString (p5);
			try {
				JValue* __args = stackalloc JValue [6];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				__args [5] = new JValue (native_p5);
				global::Java.Util.IIterator __ret = global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
				JNIEnv.DeleteLocalRef (native_p4);
				JNIEnv.DeleteLocalRef (native_p5);
			}
		}

		static IntPtr id_findById_Ljava_lang_Class_Ljava_lang_Integer_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findById' and count(parameter)=2 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.Integer']]"
		[Register ("findById", "(Ljava/lang/Class;Ljava/lang/Integer;)Ljava/lang/Object;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Lang.Object FindById (global::Java.Lang.Class p0, global::Java.Lang.Integer p1)
		{
			if (id_findById_Ljava_lang_Class_Ljava_lang_Integer_ == IntPtr.Zero)
				id_findById_Ljava_lang_Class_Ljava_lang_Integer_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/Class;Ljava/lang/Integer;)Ljava/lang/Object;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Java.Lang.Object __ret = (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_Class_Ljava_lang_Integer_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_findById_Ljava_lang_Class_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findById' and count(parameter)=2 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.Long']]"
		[Register ("findById", "(Ljava/lang/Class;Ljava/lang/Long;)Ljava/lang/Object;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Lang.Object FindById (global::Java.Lang.Class p0, global::Java.Lang.Long p1)
		{
			if (id_findById_Ljava_lang_Class_Ljava_lang_Long_ == IntPtr.Zero)
				id_findById_Ljava_lang_Class_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "findById", "(Ljava/lang/Class;Ljava/lang/Long;)Ljava/lang/Object;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::Java.Lang.Object __ret = (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findById_Ljava_lang_Class_Ljava_lang_Long_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_findWithQuery_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findWithQuery' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String...']]"
		[Register ("findWithQuery", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/List;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.IList FindWithQuery (global::Java.Lang.Class p0, string p1, params  string[] p2)
		{
			if (id_findWithQuery_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_findWithQuery_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findWithQuery", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/List;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				global::System.Collections.IList __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_findWithQuery_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_findWithQueryAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='findWithQueryAsIterator' and count(parameter)=3 and parameter[1][@type='java.lang.Class&lt;T&gt;'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='java.lang.String...']]"
		[Register ("findWithQueryAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/Iterator;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Java.Util.IIterator FindWithQueryAsIterator (global::Java.Lang.Class p0, string p1, params  string[] p2)
		{
			if (id_findWithQueryAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_findWithQueryAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "findWithQueryAsIterator", "(Ljava/lang/Class;Ljava/lang/String;[Ljava/lang/String;)Ljava/util/Iterator;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				global::Java.Util.IIterator __ret = global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallStaticObjectMethod  (class_ref, id_findWithQueryAsIterator_Ljava_lang_Class_Ljava_lang_String_arrayLjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_listAll_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='listAll' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register ("listAll", "(Ljava/lang/Class;)Ljava/util/List;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.IList ListAll (global::Java.Lang.Class p0)
		{
			if (id_listAll_Ljava_lang_Class_ == IntPtr.Zero)
				id_listAll_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "listAll", "(Ljava/lang/Class;)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::System.Collections.IList __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_listAll_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_save;
#pragma warning disable 0169
		static Delegate GetSaveHandler ()
		{
			if (cb_save == null)
				cb_save = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_Save);
			return cb_save;
		}

		static long n_Save (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.SugarRecord __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarRecord> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Save ();
		}
#pragma warning restore 0169

		static IntPtr id_save;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='save' and count(parameter)=0]"
		[Register ("save", "()J", "GetSaveHandler")]
		public virtual unsafe long Save ()
		{
			if (id_save == IntPtr.Zero)
				id_save = JNIEnv.GetMethodID (class_ref, "save", "()J");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_save);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "save", "()J"));
			} finally {
			}
		}

		static IntPtr id_save_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='save' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("save", "(Ljava/lang/Object;)J", "")]
		public static unsafe long Save (global::Java.Lang.Object p0)
		{
			if (id_save_Ljava_lang_Object_ == IntPtr.Zero)
				id_save_Ljava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "save", "(Ljava/lang/Object;)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				long __ret = JNIEnv.CallStaticLongMethod  (class_ref, id_save_Ljava_lang_Object_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_saveInTx_Ljava_util_Collection_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarRecord']/method[@name='saveInTx' and count(parameter)=1 and parameter[1][@type='java.util.Collection&lt;T&gt;']]"
		[Register ("saveInTx", "(Ljava/util/Collection;)V", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe void SaveInTx (global::System.Collections.ICollection p0)
		{
			if (id_saveInTx_Ljava_util_Collection_ == IntPtr.Zero)
				id_saveInTx_Ljava_util_Collection_ = JNIEnv.GetStaticMethodID (class_ref, "saveInTx", "(Ljava/util/Collection;)V");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_saveInTx_Ljava_util_Collection_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
