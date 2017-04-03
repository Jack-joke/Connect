using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/AnnouncementListAdapter", DoNotGenerateAcw=true)]
	public partial class AnnouncementListAdapter : global::Android.Widget.ArrayAdapter {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter.ViewHolder']"
		[global::Android.Runtime.Register ("com/inscripts/adapters/AnnouncementListAdapter$ViewHolder", DoNotGenerateAcw=true)]
		public partial class ViewHolder : global::Java.Lang.Object {


			static IntPtr announcement_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter.ViewHolder']/field[@name='announcement']"
			[Register ("announcement")]
			public global::Android.Widget.TextView Announcement {
				get {
					if (announcement_jfieldId == IntPtr.Zero)
						announcement_jfieldId = JNIEnv.GetFieldID (class_ref, "announcement", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, announcement_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (announcement_jfieldId == IntPtr.Zero)
						announcement_jfieldId = JNIEnv.GetFieldID (class_ref, "announcement", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, announcement_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr readMore_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter.ViewHolder']/field[@name='readMore']"
			[Register ("readMore")]
			public global::Android.Widget.TextView ReadMore {
				get {
					if (readMore_jfieldId == IntPtr.Zero)
						readMore_jfieldId = JNIEnv.GetFieldID (class_ref, "readMore", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, readMore_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (readMore_jfieldId == IntPtr.Zero)
						readMore_jfieldId = JNIEnv.GetFieldID (class_ref, "readMore", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, readMore_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr timeStamp_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter.ViewHolder']/field[@name='timeStamp']"
			[Register ("timeStamp")]
			public global::Android.Widget.TextView TimeStamp {
				get {
					if (timeStamp_jfieldId == IntPtr.Zero)
						timeStamp_jfieldId = JNIEnv.GetFieldID (class_ref, "timeStamp", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, timeStamp_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (timeStamp_jfieldId == IntPtr.Zero)
						timeStamp_jfieldId = JNIEnv.GetFieldID (class_ref, "timeStamp", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, timeStamp_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/adapters/AnnouncementListAdapter$ViewHolder", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (ViewHolder); }
			}

			protected ViewHolder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/adapters/AnnouncementListAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AnnouncementListAdapter); }
		}

		protected AnnouncementListAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_util_List_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='AnnouncementListAdapter']/constructor[@name='AnnouncementListAdapter' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.List&lt;com.inscripts.models.Announcement&gt;']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/util/List;)V", "")]
		public unsafe AnnouncementListAdapter (global::Android.Content.Context p0, global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Announcement> p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Announcement>.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (AnnouncementListAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/util/List;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/util/List;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_util_List_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/util/List;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_util_List_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_util_List_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
