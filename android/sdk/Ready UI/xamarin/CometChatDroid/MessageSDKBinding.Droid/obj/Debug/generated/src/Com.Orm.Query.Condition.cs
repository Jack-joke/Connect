using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Query {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']"
	[global::Android.Runtime.Register ("com/orm/query/Condition", DoNotGenerateAcw=true)]
	public partial class Condition : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']"
		[global::Android.Runtime.Register ("com/orm/query/Condition$Check", DoNotGenerateAcw=true)]
		public sealed partial class Check : global::Java.Lang.Enum {


			static IntPtr EQUALS_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='EQUALS']"
			[Register ("EQUALS")]
			public static global::Com.Orm.Query.Condition.Check Equals {
				get {
					if (EQUALS_jfieldId == IntPtr.Zero)
						EQUALS_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "EQUALS", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, EQUALS_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr GREATER_THAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='GREATER_THAN']"
			[Register ("GREATER_THAN")]
			public static global::Com.Orm.Query.Condition.Check GreaterThan {
				get {
					if (GREATER_THAN_jfieldId == IntPtr.Zero)
						GREATER_THAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "GREATER_THAN", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, GREATER_THAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr LESSER_THAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='LESSER_THAN']"
			[Register ("LESSER_THAN")]
			public static global::Com.Orm.Query.Condition.Check LesserThan {
				get {
					if (LESSER_THAN_jfieldId == IntPtr.Zero)
						LESSER_THAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "LESSER_THAN", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, LESSER_THAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr LIKE_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='LIKE']"
			[Register ("LIKE")]
			public static global::Com.Orm.Query.Condition.Check Like {
				get {
					if (LIKE_jfieldId == IntPtr.Zero)
						LIKE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "LIKE", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, LIKE_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr NOT_EQUALS_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='NOT_EQUALS']"
			[Register ("NOT_EQUALS")]
			public static global::Com.Orm.Query.Condition.Check NotEquals {
				get {
					if (NOT_EQUALS_jfieldId == IntPtr.Zero)
						NOT_EQUALS_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NOT_EQUALS", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NOT_EQUALS_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr NOT_LIKE_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/field[@name='NOT_LIKE']"
			[Register ("NOT_LIKE")]
			public static global::Com.Orm.Query.Condition.Check NotLike {
				get {
					if (NOT_LIKE_jfieldId == IntPtr.Zero)
						NOT_LIKE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NOT_LIKE", "Lcom/orm/query/Condition$Check;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NOT_LIKE_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Check> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/orm/query/Condition$Check", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Check); }
			}

			internal Check (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_getSymbol;
			public unsafe string Symbol {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Check']/method[@name='getSymbol' and count(parameter)=0]"
				[Register ("getSymbol", "()Ljava/lang/String;", "GetGetSymbolHandler")]
				get {
					if (id_getSymbol == IntPtr.Zero)
						id_getSymbol = JNIEnv.GetMethodID (class_ref, "getSymbol", "()Ljava/lang/String;");
					try {
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSymbol), JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Type']"
		[global::Android.Runtime.Register ("com/orm/query/Condition$Type", DoNotGenerateAcw=true)]
		public sealed partial class Type : global::Java.Lang.Enum {


			static IntPtr AND_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Type']/field[@name='AND']"
			[Register ("AND")]
			public static global::Com.Orm.Query.Condition.Type And {
				get {
					if (AND_jfieldId == IntPtr.Zero)
						AND_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "AND", "Lcom/orm/query/Condition$Type;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, AND_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Type> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr NOT_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Type']/field[@name='NOT']"
			[Register ("NOT")]
			public static global::Com.Orm.Query.Condition.Type Not {
				get {
					if (NOT_jfieldId == IntPtr.Zero)
						NOT_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "NOT", "Lcom/orm/query/Condition$Type;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, NOT_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Type> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr OR_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.query']/class[@name='Condition.Type']/field[@name='OR']"
			[Register ("OR")]
			public static global::Com.Orm.Query.Condition.Type Or {
				get {
					if (OR_jfieldId == IntPtr.Zero)
						OR_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "OR", "Lcom/orm/query/Condition$Type;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, OR_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition.Type> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/orm/query/Condition$Type", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (Type); }
			}

			internal Type (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/query/Condition", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Condition); }
		}

		protected Condition (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Ljava_lang_String_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/constructor[@name='Condition' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register (".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe Condition (string p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				if (GetType () != typeof (Condition)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Ljava/lang/String;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Ljava/lang/String;)V", __args);
					return;
				}

				if (id_ctor_Ljava_lang_String_ == IntPtr.Zero)
					id_ctor_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Ljava/lang/String;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Ljava_lang_String_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_getCheckSymbol;
#pragma warning disable 0169
		static Delegate GetGetCheckSymbolHandler ()
		{
			if (cb_getCheckSymbol == null)
				cb_getCheckSymbol = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCheckSymbol);
			return cb_getCheckSymbol;
		}

		static IntPtr n_GetCheckSymbol (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.CheckSymbol);
		}
#pragma warning restore 0169

		static IntPtr id_getCheckSymbol;
		public virtual unsafe string CheckSymbol {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='getCheckSymbol' and count(parameter)=0]"
			[Register ("getCheckSymbol", "()Ljava/lang/String;", "GetGetCheckSymbolHandler")]
			get {
				if (id_getCheckSymbol == IntPtr.Zero)
					id_getCheckSymbol = JNIEnv.GetMethodID (class_ref, "getCheckSymbol", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCheckSymbol), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCheckSymbol", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getProperty;
#pragma warning disable 0169
		static Delegate GetGetPropertyHandler ()
		{
			if (cb_getProperty == null)
				cb_getProperty = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetProperty);
			return cb_getProperty;
		}

		static IntPtr n_GetProperty (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Property);
		}
#pragma warning restore 0169

		static IntPtr id_getProperty;
		public virtual unsafe string Property {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='getProperty' and count(parameter)=0]"
			[Register ("getProperty", "()Ljava/lang/String;", "GetGetPropertyHandler")]
			get {
				if (id_getProperty == IntPtr.Zero)
					id_getProperty = JNIEnv.GetMethodID (class_ref, "getProperty", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getProperty), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getProperty", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getValue;
#pragma warning disable 0169
		static Delegate GetGetValueHandler ()
		{
			if (cb_getValue == null)
				cb_getValue = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetValue);
			return cb_getValue;
		}

		static IntPtr n_GetValue (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Value);
		}
#pragma warning restore 0169

		static IntPtr id_getValue;
		public virtual unsafe global::Java.Lang.Object Value {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='getValue' and count(parameter)=0]"
			[Register ("getValue", "()Ljava/lang/Object;", "GetGetValueHandler")]
			get {
				if (id_getValue == IntPtr.Zero)
					id_getValue = JNIEnv.GetMethodID (class_ref, "getValue", "()Ljava/lang/Object;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getValue), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getValue", "()Ljava/lang/Object;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_eq_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetEq_Ljava_lang_Object_Handler ()
		{
			if (cb_eq_Ljava_lang_Object_ == null)
				cb_eq_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Eq_Ljava_lang_Object_);
			return cb_eq_Ljava_lang_Object_;
		}

		static IntPtr n_Eq_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Eq (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_eq_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='eq' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("eq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetEq_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition Eq (global::Java.Lang.Object p0)
		{
			if (id_eq_Ljava_lang_Object_ == IntPtr.Zero)
				id_eq_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "eq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_eq_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "eq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_gt_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetGt_Ljava_lang_Object_Handler ()
		{
			if (cb_gt_Ljava_lang_Object_ == null)
				cb_gt_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Gt_Ljava_lang_Object_);
			return cb_gt_Ljava_lang_Object_;
		}

		static IntPtr n_Gt_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Gt (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_gt_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='gt' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("gt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetGt_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition Gt (global::Java.Lang.Object p0)
		{
			if (id_gt_Ljava_lang_Object_ == IntPtr.Zero)
				id_gt_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "gt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_gt_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "gt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_like_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetLike_Ljava_lang_Object_Handler ()
		{
			if (cb_like_Ljava_lang_Object_ == null)
				cb_like_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Like_Ljava_lang_Object_);
			return cb_like_Ljava_lang_Object_;
		}

		static IntPtr n_Like_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Like (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_like_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='like' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("like", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetLike_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition Like (global::Java.Lang.Object p0)
		{
			if (id_like_Ljava_lang_Object_ == IntPtr.Zero)
				id_like_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "like", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_like_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "like", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_lt_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetLt_Ljava_lang_Object_Handler ()
		{
			if (cb_lt_Ljava_lang_Object_ == null)
				cb_lt_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_Lt_Ljava_lang_Object_);
			return cb_lt_Ljava_lang_Object_;
		}

		static IntPtr n_Lt_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Lt (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_lt_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='lt' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("lt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetLt_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition Lt (global::Java.Lang.Object p0)
		{
			if (id_lt_Ljava_lang_Object_ == IntPtr.Zero)
				id_lt_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "lt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_lt_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "lt", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_notEq_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetNotEq_Ljava_lang_Object_Handler ()
		{
			if (cb_notEq_Ljava_lang_Object_ == null)
				cb_notEq_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_NotEq_Ljava_lang_Object_);
			return cb_notEq_Ljava_lang_Object_;
		}

		static IntPtr n_NotEq_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.NotEq (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_notEq_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='notEq' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("notEq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetNotEq_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition NotEq (global::Java.Lang.Object p0)
		{
			if (id_notEq_Ljava_lang_Object_ == IntPtr.Zero)
				id_notEq_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "notEq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_notEq_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "notEq", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_notLike_Ljava_lang_Object_;
#pragma warning disable 0169
		static Delegate GetNotLike_Ljava_lang_Object_Handler ()
		{
			if (cb_notLike_Ljava_lang_Object_ == null)
				cb_notLike_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_NotLike_Ljava_lang_Object_);
			return cb_notLike_Ljava_lang_Object_;
		}

		static IntPtr n_NotLike_Ljava_lang_Object_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.Query.Condition __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object p0 = global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.NotLike (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_notLike_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='notLike' and count(parameter)=1 and parameter[1][@type='java.lang.Object']]"
		[Register ("notLike", "(Ljava/lang/Object;)Lcom/orm/query/Condition;", "GetNotLike_Ljava_lang_Object_Handler")]
		public virtual unsafe global::Com.Orm.Query.Condition NotLike (global::Java.Lang.Object p0)
		{
			if (id_notLike_Ljava_lang_Object_ == IntPtr.Zero)
				id_notLike_Ljava_lang_Object_ = JNIEnv.GetMethodID (class_ref, "notLike", "(Ljava/lang/Object;)Lcom/orm/query/Condition;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Com.Orm.Query.Condition __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_notLike_Ljava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "notLike", "(Ljava/lang/Object;)Lcom/orm/query/Condition;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_prop_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.query']/class[@name='Condition']/method[@name='prop' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("prop", "(Ljava/lang/String;)Lcom/orm/query/Condition;", "")]
		public static unsafe global::Com.Orm.Query.Condition Prop (string p0)
		{
			if (id_prop_Ljava_lang_String_ == IntPtr.Zero)
				id_prop_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "prop", "(Ljava/lang/String;)Lcom/orm/query/Condition;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Orm.Query.Condition __ret = global::Java.Lang.Object.GetObject<global::Com.Orm.Query.Condition> (JNIEnv.CallStaticObjectMethod  (class_ref, id_prop_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
