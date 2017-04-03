using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='Collection']"
	[global::Android.Runtime.Register ("com/orm/util/Collection", DoNotGenerateAcw=true)]
	public partial class Collection : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='Collection.Entry']"
		[global::Android.Runtime.Register ("com/orm/util/Collection$Entry", DoNotGenerateAcw=true)]
		[global::Java.Interop.JavaTypeParameters (new string [] {"K", "V"})]
		public partial class Entry : global::Java.Lang.Object {

			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/orm/util/Collection$Entry", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Entry); }
			}

			protected Entry (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Ljava_lang_Object_Ljava_lang_Object_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='Collection.Entry']/constructor[@name='Collection.Entry' and count(parameter)=2 and parameter[1][@type='K'] and parameter[2][@type='V']]"
			[Register (".ctor", "(Ljava/lang/Object;Ljava/lang/Object;)V", "")]
			public unsafe Entry (global::Java.Lang.Object p0, global::Java.Lang.Object p1)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				IntPtr native_p0 = JNIEnv.ToLocalJniHandle (p0);
				IntPtr native_p1 = JNIEnv.ToLocalJniHandle (p1);
				try {
					JValue* __args = stackalloc JValue [2];
					__args [0] = new JValue (native_p0);
					__args [1] = new JValue (native_p1);
					if (GetType () != typeof (Entry)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/Object;Ljava/lang/Object;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Object;Ljava/lang/Object;)V", __args);
						return;
					}

					if (id_ctor_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
						id_ctor_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Object;Ljava/lang/Object;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Object_Ljava_lang_Object_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Object_Ljava_lang_Object_, __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/Collection", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Collection); }
		}

		protected Collection (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='Collection']/constructor[@name='Collection' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe Collection ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (Collection)) {
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

		static IntPtr id_entry_Ljava_lang_Object_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='Collection']/method[@name='entry' and count(parameter)=2 and parameter[1][@type='K'] and parameter[2][@type='V']]"
		[Register ("entry", "(Ljava/lang/Object;Ljava/lang/Object;)Lcom/orm/util/Collection$Entry;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"K", "V"})]
		public static unsafe global::Com.Orm.Util.Collection.Entry InvokeEntry (global::Java.Lang.Object p0, global::Java.Lang.Object p1)
		{
			if (id_entry_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
				id_entry_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "entry", "(Ljava/lang/Object;Ljava/lang/Object;)Lcom/orm/util/Collection$Entry;");
			IntPtr native_p0 = JNIEnv.ToLocalJniHandle (p0);
			IntPtr native_p1 = JNIEnv.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				global::Com.Orm.Util.Collection.Entry __ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Util.Collection.Entry> (JNIEnv.CallStaticObjectMethod  (class_ref, id_entry_Ljava_lang_Object_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_list_arrayLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='Collection']/method[@name='list' and count(parameter)=1 and parameter[1][@type='T...']]"
		[Register ("list", "([Ljava/lang/Object;)Ljava/util/List;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.IList List (params global:: Java.Lang.Object[] p0)
		{
			if (id_list_arrayLjava_lang_Object_ == IntPtr.Zero)
				id_list_arrayLjava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "list", "([Ljava/lang/Object;)Ljava/util/List;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::System.Collections.IList __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_list_arrayLjava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_set_arrayLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='Collection']/method[@name='set' and count(parameter)=1 and parameter[1][@type='T...']]"
		[Register ("set", "([Ljava/lang/Object;)Ljava/util/Set;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::System.Collections.ICollection Set (params global:: Java.Lang.Object[] p0)
		{
			if (id_set_arrayLjava_lang_Object_ == IntPtr.Zero)
				id_set_arrayLjava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "set", "([Ljava/lang/Object;)Ljava/util/Set;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::System.Collections.ICollection __ret = global::Android.Runtime.JavaSet.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_set_arrayLjava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

	}
}
