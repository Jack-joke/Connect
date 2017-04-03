using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='SugarCursorFactory']"
	[global::Android.Runtime.Register ("com/orm/util/SugarCursorFactory", DoNotGenerateAcw=true)]
	public partial class SugarCursorFactory : global::Java.Lang.Object, global::Android.Database.Sqlite.SQLiteDatabase.ICursorFactory {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/SugarCursorFactory", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarCursorFactory); }
		}

		protected SugarCursorFactory (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='SugarCursorFactory']/constructor[@name='SugarCursorFactory' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SugarCursorFactory ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SugarCursorFactory)) {
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

		static IntPtr id_ctor_Z;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='SugarCursorFactory']/constructor[@name='SugarCursorFactory' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register (".ctor", "(Z)V", "")]
		public unsafe SugarCursorFactory (bool p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (SugarCursorFactory)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Z)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Z)V", __args);
					return;
				}

				if (id_ctor_Z == IntPtr.Zero)
					id_ctor_Z = JNIEnv.GetMethodID (class_ref, "<init>", "(Z)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Z, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Z, __args);
			} finally {
			}
		}

		static Delegate cb_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_;
#pragma warning disable 0169
		static Delegate GetNewCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_Handler ()
		{
			if (cb_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_ == null)
				cb_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_NewCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_);
			return cb_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_;
		}

		static IntPtr n_NewCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			global::Com.Orm.Util.SugarCursorFactory __this = global::Java.Lang.Object.GetObject<global::Com.Orm.Util.SugarCursorFactory> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.ISQLiteCursorDriver p1 = (global::Android.Database.Sqlite.ISQLiteCursorDriver)global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.ISQLiteCursorDriver> (native_p1, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString (native_p2, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteQuery p3 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteQuery> (native_p3, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.NewCursor (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='SugarCursorFactory']/method[@name='newCursor' and count(parameter)=4 and parameter[1][@type='android.database.sqlite.SQLiteDatabase'] and parameter[2][@type='android.database.sqlite.SQLiteCursorDriver'] and parameter[3][@type='java.lang.String'] and parameter[4][@type='android.database.sqlite.SQLiteQuery']]"
		[Register ("newCursor", "(Landroid/database/sqlite/SQLiteDatabase;Landroid/database/sqlite/SQLiteCursorDriver;Ljava/lang/String;Landroid/database/sqlite/SQLiteQuery;)Landroid/database/Cursor;", "GetNewCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_Handler")]
		public virtual unsafe global::Android.Database.ICursor NewCursor (global::Android.Database.Sqlite.SQLiteDatabase p0, global::Android.Database.Sqlite.ISQLiteCursorDriver p1, string p2, global::Android.Database.Sqlite.SQLiteQuery p3)
		{
			if (id_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_ == IntPtr.Zero)
				id_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_ = JNIEnv.GetMethodID (class_ref, "newCursor", "(Landroid/database/sqlite/SQLiteDatabase;Landroid/database/sqlite/SQLiteCursorDriver;Ljava/lang/String;Landroid/database/sqlite/SQLiteQuery;)Landroid/database/Cursor;");
			IntPtr native_p2 = JNIEnv.NewString (p2);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (p3);

				global::Android.Database.ICursor __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.Database.ICursor> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_newCursor_Landroid_database_sqlite_SQLiteDatabase_Landroid_database_sqlite_SQLiteCursorDriver_Ljava_lang_String_Landroid_database_sqlite_SQLiteQuery_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.Database.ICursor> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "newCursor", "(Landroid/database/sqlite/SQLiteDatabase;Landroid/database/sqlite/SQLiteCursorDriver;Ljava/lang/String;Landroid/database/sqlite/SQLiteQuery;)Landroid/database/Cursor;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

	}
}
