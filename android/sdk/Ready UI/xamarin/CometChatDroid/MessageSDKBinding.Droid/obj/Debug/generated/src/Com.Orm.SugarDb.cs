using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm']/class[@name='SugarDb']"
	[global::Android.Runtime.Register ("com/orm/SugarDb", DoNotGenerateAcw=true)]
	public partial class SugarDb : global::Android.Database.Sqlite.SQLiteOpenHelper {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/SugarDb", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SugarDb); }
		}

		protected SugarDb (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm']/class[@name='SugarDb']/constructor[@name='SugarDb' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe SugarDb (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (GetType () != typeof (SugarDb)) {
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

		static Delegate cb_getDB;
#pragma warning disable 0169
		static Delegate GetGetDBHandler ()
		{
			if (cb_getDB == null)
				cb_getDB = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDB);
			return cb_getDB;
		}

		static IntPtr n_GetDB (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Orm.SugarDb __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarDb> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.DB);
		}
#pragma warning restore 0169

		static IntPtr id_getDB;
		public virtual unsafe global::Android.Database.Sqlite.SQLiteDatabase DB {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarDb']/method[@name='getDB' and count(parameter)=0]"
			[Register ("getDB", "()Landroid/database/sqlite/SQLiteDatabase;", "GetGetDBHandler")]
			get {
				if (id_getDB == IntPtr.Zero)
					id_getDB = JNIEnv.GetMethodID (class_ref, "getDB", "()Landroid/database/sqlite/SQLiteDatabase;");
				try {

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDB), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getDB", "()Landroid/database/sqlite/SQLiteDatabase;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_onCreate_Landroid_database_sqlite_SQLiteDatabase_;
#pragma warning disable 0169
		static Delegate GetOnCreate_Landroid_database_sqlite_SQLiteDatabase_Handler ()
		{
			if (cb_onCreate_Landroid_database_sqlite_SQLiteDatabase_ == null)
				cb_onCreate_Landroid_database_sqlite_SQLiteDatabase_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnCreate_Landroid_database_sqlite_SQLiteDatabase_);
			return cb_onCreate_Landroid_database_sqlite_SQLiteDatabase_;
		}

		static void n_OnCreate_Landroid_database_sqlite_SQLiteDatabase_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Orm.SugarDb __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarDb> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnCreate (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onCreate_Landroid_database_sqlite_SQLiteDatabase_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarDb']/method[@name='onCreate' and count(parameter)=1 and parameter[1][@type='android.database.sqlite.SQLiteDatabase']]"
		[Register ("onCreate", "(Landroid/database/sqlite/SQLiteDatabase;)V", "GetOnCreate_Landroid_database_sqlite_SQLiteDatabase_Handler")]
		public override unsafe void OnCreate (global::Android.Database.Sqlite.SQLiteDatabase p0)
		{
			if (id_onCreate_Landroid_database_sqlite_SQLiteDatabase_ == IntPtr.Zero)
				id_onCreate_Landroid_database_sqlite_SQLiteDatabase_ = JNIEnv.GetMethodID (class_ref, "onCreate", "(Landroid/database/sqlite/SQLiteDatabase;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onCreate_Landroid_database_sqlite_SQLiteDatabase_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onCreate", "(Landroid/database/sqlite/SQLiteDatabase;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
#pragma warning disable 0169
		static Delegate GetOnUpgrade_Landroid_database_sqlite_SQLiteDatabase_IIHandler ()
		{
			if (cb_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II == null)
				cb_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int, int>) n_OnUpgrade_Landroid_database_sqlite_SQLiteDatabase_II);
			return cb_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
		}

		static void n_OnUpgrade_Landroid_database_sqlite_SQLiteDatabase_II (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2)
		{
			global::Com.Orm.SugarDb __this = global::Java.Lang.Object.GetObject<global::Com.Orm.SugarDb> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Database.Sqlite.SQLiteDatabase p0 = global::Java.Lang.Object.GetObject<global::Android.Database.Sqlite.SQLiteDatabase> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnUpgrade (p0, p1, p2);
		}
#pragma warning restore 0169

		static IntPtr id_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm']/class[@name='SugarDb']/method[@name='onUpgrade' and count(parameter)=3 and parameter[1][@type='android.database.sqlite.SQLiteDatabase'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("onUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V", "GetOnUpgrade_Landroid_database_sqlite_SQLiteDatabase_IIHandler")]
		public override unsafe void OnUpgrade (global::Android.Database.Sqlite.SQLiteDatabase p0, int p1, int p2)
		{
			if (id_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II == IntPtr.Zero)
				id_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II = JNIEnv.GetMethodID (class_ref, "onUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onUpgrade_Landroid_database_sqlite_SQLiteDatabase_II, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onUpgrade", "(Landroid/database/sqlite/SQLiteDatabase;II)V"), __args);
			} finally {
			}
		}

	}
}
