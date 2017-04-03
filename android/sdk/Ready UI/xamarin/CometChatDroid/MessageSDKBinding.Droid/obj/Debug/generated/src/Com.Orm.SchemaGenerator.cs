using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SchemaGenerator']"
	[global::Android.Runtime.Register ("com/orm/SchemaGenerator", DoNotGenerateAcw=true)]
	public partial class SchemaGenerator : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/SchemaGenerator", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SchemaGenerator); }
		}

		protected SchemaGenerator (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm']/class[@name='SchemaGenerator']/constructor[@name='SchemaGenerator' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SchemaGenerator (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (SchemaGenerator)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static Delegate cb_createDatabase_Landroid_database_sqlite_SQLiteDatabase_;
#pragma warning disable 0169
		static Delegate GetCreateDatabase_Landroid_database_sqlite_SQLiteDatabase_Handler ()
		{
			if (cb_createDatabase_Landroid_database_sqlite_SQLiteDatabase_ == null)
				cb_createDatabase_Landroid_database_sqlite_SQLiteDatabase_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_CreateDatabase_Landroid_database_sqlite_SQLiteDatabase_);
			return cb_createDatabase_Landroid_database_sqlite_SQLiteDatabase_;
		}

		static void n_CreateDatabase_Landroid_database_sqlite_SQLiteDatabase_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.SchemaGenerator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SchemaGenerator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.CreateDatabase (p0);
		}
#pragma warning restore 0169

		static IntPtr id_createDatabase_Landroid_database_sqlite_SQLiteDatabase_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SchemaGenerator']/method[@name='createDatabase' and count(parameter)=1 and parameter[1][@type='android.database.sqlite.SQLiteDatabase']]"
		[Register ("createDatabase", "(Landroid/database/sqlite/SQLiteDatabase;)V", "GetCreateDatabase_Landroid_database_sqlite_SQLiteDatabase_Handler")]
		public virtual unsafe void CreateDatabase (global::Android.Database.Sqlite.SQLiteDatabase p0)
		{
			if (id_createDatabase_Landroid_database_sqlite_SQLiteDatabase_ == IntPtr.Zero)
				id_createDatabase_Landroid_database_sqlite_SQLiteDatabase_ = JNIEnv.GetMethodID (class_ref, "createDatabase", "(Landroid/database/sqlite/SQLiteDatabase;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_createDatabase_Landroid_database_sqlite_SQLiteDatabase_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "createDatabase", "(Landroid/database/sqlite/SQLiteDatabase;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_deleteTables_Landroid_database_sqlite_SQLiteDatabase_;
#pragma warning disable 0169
		static Delegate GetDeleteTables_Landroid_database_sqlite_SQLiteDatabase_Handler ()
		{
			if (cb_deleteTables_Landroid_database_sqlite_SQLiteDatabase_ == null)
				cb_deleteTables_Landroid_database_sqlite_SQLiteDatabase_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_DeleteTables_Landroid_database_sqlite_SQLiteDatabase_);
			return cb_deleteTables_Landroid_database_sqlite_SQLiteDatabase_;
		}

		static void n_DeleteTables_Landroid_database_sqlite_SQLiteDatabase_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.SchemaGenerator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SchemaGenerator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.DeleteTables (p0);
		}
#pragma warning restore 0169

		static IntPtr id_deleteTables_Landroid_database_sqlite_SQLiteDatabase_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SchemaGenerator']/method[@name='deleteTables' and count(parameter)=1 and parameter[1][@type='android.database.sqlite.SQLiteDatabase']]"
		[Register ("deleteTables", "(Landroid/database/sqlite/SQLiteDatabase;)V", "GetDeleteTables_Landroid_database_sqlite_SQLiteDatabase_Handler")]
		public virtual unsafe void DeleteTables (global::Android.Database.Sqlite.SQLiteDatabase p0)
		{
			if (id_deleteTables_Landroid_database_sqlite_SQLiteDatabase_ == IntPtr.Zero)
				id_deleteTables_Landroid_database_sqlite_SQLiteDatabase_ = JNIEnv.GetMethodID (class_ref, "deleteTables", "(Landroid/database/sqlite/SQLiteDatabase;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_deleteTables_Landroid_database_sqlite_SQLiteDatabase_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "deleteTables", "(Landroid/database/sqlite/SQLiteDatabase;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
#pragma warning disable 0169
		static Delegate GetDoUpgrade_Landroid_database_sqlite_SQLiteDatabase_IIHandler ()
		{
			if (cb_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II == null)
				cb_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, int>) n_DoUpgrade_Landroid_database_sqlite_SQLiteDatabase_II);
			return cb_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
		}

		static void n_DoUpgrade_Landroid_database_sqlite_SQLiteDatabase_II (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2)
		{
			global::Com.Orm.SchemaGenerator __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SchemaGenerator> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.DoUpgrade (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SchemaGenerator']/method[@name='doUpgrade' and count(parameter)=3 and parameter[1][@type='android.database.sqlite.SQLiteDatabase'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("doUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V", "GetDoUpgrade_Landroid_database_sqlite_SQLiteDatabase_IIHandler")]
		public virtual unsafe void DoUpgrade (global::Android.Database.Sqlite.SQLiteDatabase p0, int p1, int p2)
		{
			if (id_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II == IntPtr.Zero)
				id_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II = JNIEnv.GetMethodID (class_ref, "doUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_doUpgrade_Landroid_database_sqlite_SQLiteDatabase_II, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "doUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V"), __args);
			} finally {
			}
		}

	}
}
