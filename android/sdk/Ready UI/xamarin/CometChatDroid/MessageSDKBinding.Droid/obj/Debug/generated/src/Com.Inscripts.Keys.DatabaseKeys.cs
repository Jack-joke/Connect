using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Keys {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys']"
	[global::Android.Runtime.Register ("com/inscripts/keys/DatabaseKeys", DoNotGenerateAcw=true)]
	public partial class DatabaseKeys : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']"
		[global::Android.Runtime.Register ("com/inscripts/keys/DatabaseKeys$ColoumnKeys", DoNotGenerateAcw=true)]
		public partial class ColoumnKeys : global::Java.Lang.Object {


			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='FROM']"
			[Register ("FROM")]
			public const string From = (string) "from";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='FROMID']"
			[Register ("FROMID")]
			public const string Fromid = (string) "fromid";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='ID']"
			[Register ("ID")]
			public const string Id = (string) "id";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='IMAGE_URL']"
			[Register ("IMAGE_URL")]
			public const string ImageUrl = (string) "image_url";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='MESSAGE']"
			[Register ("MESSAGE")]
			public const string Message = (string) "message";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='MESSAGE_INSERTED_BY']"
			[Register ("MESSAGE_INSERTED_BY")]
			public const string MessageInsertedBy = (string) "inserted_by";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='MESSAGE_TICK']"
			[Register ("MESSAGE_TICK")]
			public const string MessageTick = (string) "messagetick";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='SELF']"
			[Register ("SELF")]
			public const string Self = (string) "self";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='SENT']"
			[Register ("SENT")]
			public const string Sent = (string) "sent";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='TEXT_COLOR']"
			[Register ("TEXT_COLOR")]
			public const string TextColor = (string) "text_color";

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/field[@name='TO']"
			[Register ("TO")]
			public const string To = (string) "to";
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/keys/DatabaseKeys$ColoumnKeys", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ColoumnKeys); }
			}

			protected ColoumnKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys.ColoumnKeys']/constructor[@name='DatabaseKeys.ColoumnKeys' and count(parameter)=0]"
			[Register (".ctor", "()V", "")]
			public unsafe ColoumnKeys ()
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				try {
					if (GetType () != typeof (ColoumnKeys)) {
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

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/keys/DatabaseKeys", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (DatabaseKeys); }
		}

		protected DatabaseKeys (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.keys']/class[@name='DatabaseKeys']/constructor[@name='DatabaseKeys' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe DatabaseKeys ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (DatabaseKeys)) {
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

	}
}
