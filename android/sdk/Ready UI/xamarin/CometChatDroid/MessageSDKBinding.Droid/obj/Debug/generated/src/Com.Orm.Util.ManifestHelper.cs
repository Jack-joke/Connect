using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Orm.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']"
	[global::Android.Runtime.Register ("com/orm/util/ManifestHelper", DoNotGenerateAcw=true)]
	public partial class ManifestHelper : global::Java.Lang.Object {


		// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/field[@name='DATABASE_DEFAULT_NAME']"
		[Register ("DATABASE_DEFAULT_NAME")]
		public const string DatabaseDefaultName = (string) "Sugar.db";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/field[@name='METADATA_DATABASE']"
		[Register ("METADATA_DATABASE")]
		public const string MetadataDatabase = (string) "DATABASE";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/field[@name='METADATA_DOMAIN_PACKAGE_NAME']"
		[Register ("METADATA_DOMAIN_PACKAGE_NAME")]
		public const string MetadataDomainPackageName = (string) "DOMAIN_PACKAGE_NAME";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/field[@name='METADATA_QUERY_LOG']"
		[Register ("METADATA_QUERY_LOG")]
		public const string MetadataQueryLog = (string) "QUERY_LOG";

		// Metadata.xml XPath field reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/field[@name='METADATA_VERSION']"
		[Register ("METADATA_VERSION")]
		public const string MetadataVersion = (string) "VERSION";
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/orm/util/ManifestHelper", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ManifestHelper); }
		}

		protected ManifestHelper (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/constructor[@name='ManifestHelper' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ManifestHelper ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ManifestHelper)) {
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

		static IntPtr id_getDatabaseName_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/method[@name='getDatabaseName' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getDatabaseName", "(Landroid/content/Context;)Ljava/lang/String;", "")]
		public static unsafe string GetDatabaseName (global::Android.Content.Context p0)
		{
			if (id_getDatabaseName_Landroid_content_Context_ == IntPtr.Zero)
				id_getDatabaseName_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getDatabaseName", "(Landroid/content/Context;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDatabaseName_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getDatabaseVersion_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/method[@name='getDatabaseVersion' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getDatabaseVersion", "(Landroid/content/Context;)I", "")]
		public static unsafe int GetDatabaseVersion (global::Android.Content.Context p0)
		{
			if (id_getDatabaseVersion_Landroid_content_Context_ == IntPtr.Zero)
				id_getDatabaseVersion_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getDatabaseVersion", "(Landroid/content/Context;)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				int __ret = JNIEnv.CallStaticIntMethod  (class_ref, id_getDatabaseVersion_Landroid_content_Context_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getDebugEnabled_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/method[@name='getDebugEnabled' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getDebugEnabled", "(Landroid/content/Context;)Z", "")]
		public static unsafe bool GetDebugEnabled (global::Android.Content.Context p0)
		{
			if (id_getDebugEnabled_Landroid_content_Context_ == IntPtr.Zero)
				id_getDebugEnabled_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getDebugEnabled", "(Landroid/content/Context;)Z");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				bool __ret = JNIEnv.CallStaticBooleanMethod  (class_ref, id_getDebugEnabled_Landroid_content_Context_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_getDomainPackageName_Landroid_content_Context_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.orm.util']/class[@name='ManifestHelper']/method[@name='getDomainPackageName' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register ("getDomainPackageName", "(Landroid/content/Context;)Ljava/lang/String;", "")]
		public static unsafe string GetDomainPackageName (global::Android.Content.Context p0)
		{
			if (id_getDomainPackageName_Landroid_content_Context_ == IntPtr.Zero)
				id_getDomainPackageName_Landroid_content_Context_ = JNIEnv.GetStaticMethodID (class_ref, "getDomainPackageName", "(Landroid/content/Context;)Ljava/lang/String;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				string __ret = JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getDomainPackageName_Landroid_content_Context_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
