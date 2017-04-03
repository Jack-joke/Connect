using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']"
	[global::Android.Runtime.Register ("com/orm/util/ReflectionUtil", DoNotGenerateAcw=true)]
	public partial class ReflectionUtil : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/ReflectionUtil", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ReflectionUtil); }
		}

		protected ReflectionUtil (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/constructor[@name='ReflectionUtil' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ReflectionUtil ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ReflectionUtil)) {
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

		static IntPtr id_addFieldValueToColumn_Landroid_content_ContentValues_Ljava_lang_reflect_Field_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='addFieldValueToColumn' and count(parameter)=3 and parameter[1][@type='android.content.ContentValues'] and parameter[2][@type='java.lang.reflect.Field'] and parameter[3][@type='java.lang.Object']]"
		[Register ("addFieldValueToColumn", "(Landroid/content/ContentValues;Ljava/lang/reflect/Field;Ljava/lang/Object;)V", "")]
		public static unsafe void AddFieldValueToColumn (global::Android.Content.ContentValues p0, global::Java.Lang.Reflect.Field p1, global::Java.Lang.Object p2)
		{
			if (id_addFieldValueToColumn_Landroid_content_ContentValues_Ljava_lang_reflect_Field_Ljava_lang_Object_ == IntPtr.Zero)
				id_addFieldValueToColumn_Landroid_content_ContentValues_Ljava_lang_reflect_Field_Ljava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "addFieldValueToColumn", "(Landroid/content/ContentValues;Ljava/lang/reflect/Field;Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_addFieldValueToColumn_Landroid_content_ContentValues_Ljava_lang_reflect_Field_Ljava_lang_Object_, __args);
			} finally {
			}
		}

		static IntPtr id_customSetFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Class_Ljava_lang_Object_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='customSetFieldValueFromCursor' and count(parameter)=5 and parameter[1][@type='android.database.Cursor'] and parameter[2][@type='java.lang.reflect.Field'] and parameter[3][@type='java.lang.Class&lt;?&gt;'] and parameter[4][@type='java.lang.Object'] and parameter[5][@type='java.lang.String']]"
		[Register ("customSetFieldValueFromCursor", "(Landroid/database/Cursor;Ljava/lang/reflect/Field;Ljava/lang/Class;Ljava/lang/Object;Ljava/lang/String;)V", "")]
		public static unsafe void CustomSetFieldValueFromCursor (global::Android.Database.ICursor p0, global::Java.Lang.Reflect.Field p1, global::Java.Lang.Class p2, global::Java.Lang.Object p3, string p4)
		{
			if (id_customSetFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Class_Ljava_lang_Object_Ljava_lang_String_ == IntPtr.Zero)
				id_customSetFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Class_Ljava_lang_Object_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "customSetFieldValueFromCursor", "(Landroid/database/Cursor;Ljava/lang/reflect/Field;Ljava/lang/Class;Ljava/lang/Object;Ljava/lang/String;)V");
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_customSetFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Class_Ljava_lang_Object_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

		static IntPtr id_getAllFields_Ljava_util_List_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='getAllFields' and count(parameter)=2 and parameter[1][@type='java.util.List&lt;java.lang.reflect.Field&gt;'] and parameter[2][@type='java.lang.Class&lt;?&gt;']]"
		[Register ("getAllFields", "(Ljava/util/List;Ljava/lang/Class;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> GetAllFields (global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> p0, global::Java.Lang.Class p1)
		{
			if (id_getAllFields_Ljava_util_List_Ljava_lang_Class_ == IntPtr.Zero)
				id_getAllFields_Ljava_util_List_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "getAllFields", "(Ljava/util/List;Ljava/lang/Class;)Ljava/util/List;");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::Java.Lang.Reflect.Field>.ToLocalJniHandle (p0);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> __ret = global::Android.Runtime.JavaList<global::Java.Lang.Reflect.Field>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAllFields_Ljava_util_List_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_getDomainClasses_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='getDomainClasses' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getDomainClasses", "(Landroid/content/Context;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Java.Lang.Class> GetDomainClasses (global::Android.Content.Context p0)
		{
			if (id_getDomainClasses_Landroid_content_Context_ == IntPtr.Zero)
				id_getDomainClasses_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getDomainClasses", "(Landroid/content/Context;)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::System.Collections.Generic.IList<global::Java.Lang.Class> __ret = global::Android.Runtime.JavaList<global::Java.Lang.Class>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDomainClasses_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getTableFields_Ljava_lang_Class_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='getTableFields' and count(parameter)=1 and parameter[1][@type='java.lang.Class']]"
		[Register ("getTableFields", "(Ljava/lang/Class;)Ljava/util/List;", "")]
		public static unsafe global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> GetTableFields (global::Java.Lang.Class p0)
		{
			if (id_getTableFields_Ljava_lang_Class_ == IntPtr.Zero)
				id_getTableFields_Ljava_lang_Class_ = JNIEnv.GetStaticMethodID (class_ref, "getTableFields", "(Ljava/lang/Class;)Ljava/util/List;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				global::System.Collections.Generic.IList<global::Java.Lang.Reflect.Field> __ret = global::Android.Runtime.JavaList<global::Java.Lang.Reflect.Field>.FromJniHandle (JNIEnv.CallStaticObjectMethod  (class_ref, id_getTableFields_Ljava_lang_Class_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_setFieldValueForId_Ljava_lang_Object_Ljava_lang_Long_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='setFieldValueForId' and count(parameter)=2 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.lang.Long']]"
		[Register ("setFieldValueForId", "(Ljava/lang/Object;Ljava/lang/Long;)V", "")]
		public static unsafe void SetFieldValueForId (global::Java.Lang.Object p0, global::Java.Lang.Long p1)
		{
			if (id_setFieldValueForId_Ljava_lang_Object_Ljava_lang_Long_ == IntPtr.Zero)
				id_setFieldValueForId_Ljava_lang_Object_Ljava_lang_Long_ = JNIEnv.GetStaticMethodID (class_ref, "setFieldValueForId", "(Ljava/lang/Object;Ljava/lang/Long;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setFieldValueForId_Ljava_lang_Object_Ljava_lang_Long_, __args);
			} finally {
			}
		}

		static IntPtr id_setFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ReflectionUtil']/method[@name='setFieldValueFromCursor' and count(parameter)=3 and parameter[1][@type='android.database.Cursor'] and parameter[2][@type='java.lang.reflect.Field'] and parameter[3][@type='java.lang.Object']]"
		[Register ("setFieldValueFromCursor", "(Landroid/database/Cursor;Ljava/lang/reflect/Field;Ljava/lang/Object;)V", "")]
		public static unsafe void SetFieldValueFromCursor (global::Android.Database.ICursor p0, global::Java.Lang.Reflect.Field p1, global::Java.Lang.Object p2)
		{
			if (id_setFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Object_ == IntPtr.Zero)
				id_setFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "setFieldValueFromCursor", "(Landroid/database/Cursor;Ljava/lang/reflect/Field;Ljava/lang/Object;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setFieldValueFromCursor_Landroid_database_Cursor_Ljava_lang_reflect_Field_Ljava_lang_Object_, __args);
			} finally {
			}
		}

	}
}
