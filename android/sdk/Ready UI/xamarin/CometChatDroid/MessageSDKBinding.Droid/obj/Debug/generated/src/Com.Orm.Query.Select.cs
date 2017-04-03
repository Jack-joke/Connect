using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Query {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.query']/class[@name='Select']"
	[global::Android.Runtime.Register ("com/orm/query/Select", DoNotGenerateAcw=true)]
	[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
	public partial class Select : global::Java.Lang.Object, global::Java.Lang.IIterable {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/query/Select", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Select); }
		}

		protected Select (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Ljava_lang_Class_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/constructor[@name='Select' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register (".ctor", "(Ljava/lang/Class;)V", "")]
		public unsafe Select (global::Java.Lang.Class p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (Select)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/Class;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/Class;)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_Class_ == IntPtr.Zero)
					id_ctor_Ljava_lang_Class_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/Class;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_Class_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_Class_, __args);
			} finally {
			}
		}

		static Delegate cb_and_arrayLcom_orm_query_Condition_;
#pragma warning disable 0169
		static Delegate GetAnd_arrayLcom_orm_query_Condition_Handler ()
		{
			if (cb_and_arrayLcom_orm_query_Condition_ == null)
				cb_and_arrayLcom_orm_query_Condition_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_And_arrayLcom_orm_query_Condition_);
			return cb_and_arrayLcom_orm_query_Condition_;
		}

		static IntPtr n_And_arrayLcom_orm_query_Condition_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Orm.Query.Condition[] p0 = (global::Com.Orm.Query.Condition[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Orm.Query.Condition));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.And (p0));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_and_arrayLcom_orm_query_Condition_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='and' and count(parameter)=1 and parameter[1][@type='com.orm.query.Condition...']]"
		[Register ("and", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;", "GetAnd_arrayLcom_orm_query_Condition_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select And (params global:: Com.Orm.Query.Condition[] p0)
		{
			if (id_and_arrayLcom_orm_query_Condition_ == IntPtr.Zero)
				id_and_arrayLcom_orm_query_Condition_ = JNIEnv.GetMethodID (class_ref, "and", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_and_arrayLcom_orm_query_Condition_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "and", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_count;
#pragma warning disable 0169
		static Delegate GetCountHandler ()
		{
			if (cb_count == null)
				cb_count = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_Count);
			return cb_count;
		}

		static long n_Count (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Count ();
		}
#pragma warning restore 0169

		static IntPtr id_count;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='count' and count(parameter)=0]"
		[Register ("count", "()J", "GetCountHandler")]
		public virtual unsafe long Count ()
		{
			if (id_count == IntPtr.Zero)
				id_count = JNIEnv.GetMethodID (class_ref, "count", "()J");
			try {

				if (GetType () == ThresholdType)
					return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_count);
				else
					return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "count", "()J"));
			} finally {
			}
		}

		static Delegate cb_first;
#pragma warning disable 0169
		static Delegate GetFirstHandler ()
		{
			if (cb_first == null)
				cb_first = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_First);
			return cb_first;
		}

		static IntPtr n_First (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.First ());
		}
#pragma warning restore 0169

		static IntPtr id_first;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='first' and count(parameter)=0]"
		[Register ("first", "()Ljava/lang/Object;", "GetFirstHandler")]
		public virtual unsafe global::Java.Lang.Object First ()
		{
			if (id_first == IntPtr.Zero)
				id_first = JNIEnv.GetMethodID (class_ref, "first", "()Ljava/lang/Object;");
			try {

				if (GetType () == ThresholdType)
					return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_first), JniHandleOwnership.TransferLocalRef);
				else
					return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "first", "()Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_from_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='from' and count(parameter)=1 and parameter[1][@type='java.lang.Class&lt;T&gt;']]"
		[Register ("from", "(Ljava/lang/Class;)Lcom/orm/query/Select;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
		public static unsafe global::Com.Orm.Query.Select From (global::Java.Lang.Class p0)
		{
			if (id_from_Ljava_lang_Class_ == IntPtr.Zero)
				id_from_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "from", "(Ljava/lang/Class;)Lcom/orm/query/Select;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::Com.Orm.Query.Select __ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallStaticObjectMethod  (class_ref, id_from_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_groupBy_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGroupBy_Ljava_lang_String_Handler ()
		{
			if (cb_groupBy_Ljava_lang_String_ == null)
				cb_groupBy_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GroupBy_Ljava_lang_String_);
			return cb_groupBy_Ljava_lang_String_;
		}

		static IntPtr n_GroupBy_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GroupBy (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_groupBy_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='groupBy' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("groupBy", "(Ljava/lang/String;)Lcom/orm/query/Select;", "GetGroupBy_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select GroupBy (string p0)
		{
			if (id_groupBy_Ljava_lang_String_ == IntPtr.Zero)
				id_groupBy_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "groupBy", "(Ljava/lang/String;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_groupBy_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "groupBy", "(Ljava/lang/String;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_iterator;
#pragma warning disable 0169
		static Delegate GetIteratorHandler ()
		{
			if (cb_iterator == null)
				cb_iterator = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_Iterator);
			return cb_iterator;
		}

		static IntPtr n_Iterator (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Iterator ());
		}
#pragma warning restore 0169

		static IntPtr id_iterator;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='iterator' and count(parameter)=0]"
		[Register ("iterator", "()Ljava/util/Iterator;", "GetIteratorHandler")]
		public virtual unsafe global::Java.Util.IIterator Iterator ()
		{
			if (id_iterator == IntPtr.Zero)
				id_iterator = JNIEnv.GetMethodID (class_ref, "iterator", "()Ljava/util/Iterator;");
			try {

				if (GetType () == ThresholdType)
					return global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_iterator), JniHandleOwnership.TransferLocalRef);
				else
					return global::Java.Lang.Object.GetObject<global::Java.Util.IIterator> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "iterator", "()Ljava/util/Iterator;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_limit_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetLimit_Ljava_lang_String_Handler ()
		{
			if (cb_limit_Ljava_lang_String_ == null)
				cb_limit_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Limit_Ljava_lang_String_);
			return cb_limit_Ljava_lang_String_;
		}

		static IntPtr n_Limit_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Limit (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_limit_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='limit' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("limit", "(Ljava/lang/String;)Lcom/orm/query/Select;", "GetLimit_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select Limit (string p0)
		{
			if (id_limit_Ljava_lang_String_ == IntPtr.Zero)
				id_limit_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "limit", "(Ljava/lang/String;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_limit_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "limit", "(Ljava/lang/String;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_list;
#pragma warning disable 0169
		static Delegate GetListHandler ()
		{
			if (cb_list == null)
				cb_list = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_List);
			return cb_list;
		}

		static IntPtr n_List (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList.ToLocalJniHandle (__this.List ());
		}
#pragma warning restore 0169

		static IntPtr id_list;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='list' and count(parameter)=0]"
		[Register ("list", "()Ljava/util/List;", "GetListHandler")]
		public virtual unsafe global::System.Collections.IList List ()
		{
			if (id_list == IntPtr.Zero)
				id_list = JNIEnv.GetMethodID (class_ref, "list", "()Ljava/util/List;");
			try {

				if (GetType () == ThresholdType)
					return global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_list), JniHandleOwnership.TransferLocalRef);
				else
					return global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "list", "()Ljava/util/List;")), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static Delegate cb_or_arrayLcom_orm_query_Condition_;
#pragma warning disable 0169
		static Delegate GetOr_arrayLcom_orm_query_Condition_Handler ()
		{
			if (cb_or_arrayLcom_orm_query_Condition_ == null)
				cb_or_arrayLcom_orm_query_Condition_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Or_arrayLcom_orm_query_Condition_);
			return cb_or_arrayLcom_orm_query_Condition_;
		}

		static IntPtr n_Or_arrayLcom_orm_query_Condition_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Orm.Query.Condition[] p0 = (global::Com.Orm.Query.Condition[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Orm.Query.Condition));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Or (p0));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_or_arrayLcom_orm_query_Condition_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='or' and count(parameter)=1 and parameter[1][@type='com.orm.query.Condition...']]"
		[Register ("or", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;", "GetOr_arrayLcom_orm_query_Condition_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select Or (params global:: Com.Orm.Query.Condition[] p0)
		{
			if (id_or_arrayLcom_orm_query_Condition_ == IntPtr.Zero)
				id_or_arrayLcom_orm_query_Condition_ = JNIEnv.GetMethodID (class_ref, "or", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_or_arrayLcom_orm_query_Condition_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "or", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_orderBy_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetOrderBy_Ljava_lang_String_Handler ()
		{
			if (cb_orderBy_Ljava_lang_String_ == null)
				cb_orderBy_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_OrderBy_Ljava_lang_String_);
			return cb_orderBy_Ljava_lang_String_;
		}

		static IntPtr n_OrderBy_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OrderBy (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_orderBy_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='orderBy' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("orderBy", "(Ljava/lang/String;)Lcom/orm/query/Select;", "GetOrderBy_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select OrderBy (string p0)
		{
			if (id_orderBy_Ljava_lang_String_ == IntPtr.Zero)
				id_orderBy_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "orderBy", "(Ljava/lang/String;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_orderBy_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "orderBy", "(Ljava/lang/String;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_where_arrayLcom_orm_query_Condition_;
#pragma warning disable 0169
		static Delegate GetWhere_arrayLcom_orm_query_Condition_Handler ()
		{
			if (cb_where_arrayLcom_orm_query_Condition_ == null)
				cb_where_arrayLcom_orm_query_Condition_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Where_arrayLcom_orm_query_Condition_);
			return cb_where_arrayLcom_orm_query_Condition_;
		}

		static IntPtr n_Where_arrayLcom_orm_query_Condition_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Orm.Query.Condition[] p0 = (global::Com.Orm.Query.Condition[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Orm.Query.Condition));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Where (p0));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_where_arrayLcom_orm_query_Condition_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='where' and count(parameter)=1 and parameter[1][@type='com.orm.query.Condition...']]"
		[Register ("where", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;", "GetWhere_arrayLcom_orm_query_Condition_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select Where (params global:: Com.Orm.Query.Condition[] p0)
		{
			if (id_where_arrayLcom_orm_query_Condition_ == IntPtr.Zero)
				id_where_arrayLcom_orm_query_Condition_ = JNIEnv.GetMethodID (class_ref, "where", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_where_arrayLcom_orm_query_Condition_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "where", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static Delegate cb_where_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetWhere_Ljava_lang_String_Handler ()
		{
			if (cb_where_Ljava_lang_String_ == null)
				cb_where_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Where_Ljava_lang_String_);
			return cb_where_Ljava_lang_String_;
		}

		static IntPtr n_Where_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Where (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_where_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='where' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("where", "(Ljava/lang/String;)Lcom/orm/query/Select;", "GetWhere_Ljava_lang_String_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select Where (string p0)
		{
			if (id_where_Ljava_lang_String_ == IntPtr.Zero)
				id_where_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "where", "(Ljava/lang/String;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_where_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "where", "(Ljava/lang/String;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_where_Ljava_lang_String_arrayLjava_lang_String_;
#pragma warning disable 0169
		static Delegate GetWhere_Ljava_lang_String_arrayLjava_lang_String_Handler ()
		{
			if (cb_where_Ljava_lang_String_arrayLjava_lang_String_ == null)
				cb_where_Ljava_lang_String_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_Where_Ljava_lang_String_arrayLjava_lang_String_);
			return cb_where_Ljava_lang_String_arrayLjava_lang_String_;
		}

		static IntPtr n_Where_Ljava_lang_String_arrayLjava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			string[] p1 = (string[]) JNIEnv.GetArray (native_p1, JniHandleOwnership.DoNotTransfer, typeof (string));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Where (p0, p1));
			if (p1 != null)
				JNIEnv.CopyArray (p1, native_p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_where_Ljava_lang_String_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='where' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String[]']]"
		[Register ("where", "(Ljava/lang/String;[Ljava/lang/String;)Lcom/orm/query/Select;", "GetWhere_Ljava_lang_String_arrayLjava_lang_String_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select Where (string p0, string[] p1)
		{
			if (id_where_Ljava_lang_String_arrayLjava_lang_String_ == IntPtr.Zero)
				id_where_Ljava_lang_String_arrayLjava_lang_String_ = JNIEnv.GetMethodID (class_ref, "where", "(Ljava/lang/String;[Ljava/lang/String;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_where_Ljava_lang_String_arrayLjava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "where", "(Ljava/lang/String;[Ljava/lang/String;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static Delegate cb_whereOr_arrayLcom_orm_query_Condition_;
#pragma warning disable 0169
		static Delegate GetWhereOr_arrayLcom_orm_query_Condition_Handler ()
		{
			if (cb_whereOr_arrayLcom_orm_query_Condition_ == null)
				cb_whereOr_arrayLcom_orm_query_Condition_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_WhereOr_arrayLcom_orm_query_Condition_);
			return cb_whereOr_arrayLcom_orm_query_Condition_;
		}

		static IntPtr n_WhereOr_arrayLcom_orm_query_Condition_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Select __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Orm.Query.Condition[] p0 = (global::Com.Orm.Query.Condition[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (global::Com.Orm.Query.Condition));
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.WhereOr (p0));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_whereOr_arrayLcom_orm_query_Condition_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Select']/method[@name='whereOr' and count(parameter)=1 and parameter[1][@type='com.orm.query.Condition...']]"
		[Register ("whereOr", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;", "GetWhereOr_arrayLcom_orm_query_Condition_Handler")]
		public virtual unsafe global::Com.Orm.Query.Select WhereOr (params global:: Com.Orm.Query.Condition[] p0)
		{
			if (id_whereOr_arrayLcom_orm_query_Condition_ == IntPtr.Zero)
				id_whereOr_arrayLcom_orm_query_Condition_ = JNIEnv.GetMethodID (class_ref, "whereOr", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				global::Com.Orm.Query.Select __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_whereOr_arrayLcom_orm_query_Condition_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Select> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "whereOr", "([Lcom/orm/query/Condition;)Lcom/orm/query/Select;"), __args), JniHandleOwnership.TransferLocalRef);
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
