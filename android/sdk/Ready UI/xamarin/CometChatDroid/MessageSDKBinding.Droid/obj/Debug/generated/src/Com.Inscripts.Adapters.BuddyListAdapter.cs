using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/BuddyListAdapter", DoNotGenerateAcw=true)]
	public partial class BuddyListAdapter : global::Android.Widget.ArrayAdapter {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']"
		[global::Android.Runtime.Register ("com/inscripts/adapters/BuddyListAdapter$ViewHolder", DoNotGenerateAcw=true)]
		public partial class ViewHolder : global::Java.Lang.Object {


			static IntPtr avatar_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='avatar']"
			[Register ("avatar")]
			public global::Com.Inscripts.Custom.RoundedImageView Avatar {
				get {
					if (avatar_jfieldId == IntPtr.Zero)
						avatar_jfieldId = JNIEnv.GetFieldID (class_ref, "avatar", "Lcom/inscripts/custom/RoundedImageView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, avatar_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (avatar_jfieldId == IntPtr.Zero)
						avatar_jfieldId = JNIEnv.GetFieldID (class_ref, "avatar", "Lcom/inscripts/custom/RoundedImageView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, avatar_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr avtar_image_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='avtar_image']"
			[Register ("avtar_image")]
			public global::Android.Widget.ImageView AvtarImage {
				get {
					if (avtar_image_jfieldId == IntPtr.Zero)
						avtar_image_jfieldId = JNIEnv.GetFieldID (class_ref, "avtar_image", "Landroid/widget/ImageView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, avtar_image_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (avtar_image_jfieldId == IntPtr.Zero)
						avtar_image_jfieldId = JNIEnv.GetFieldID (class_ref, "avtar_image", "Landroid/widget/ImageView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, avtar_image_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr menuBtnLeft_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='menuBtnLeft']"
			[Register ("menuBtnLeft")]
			public global::Android.Widget.Button MenuBtnLeft {
				get {
					if (menuBtnLeft_jfieldId == IntPtr.Zero)
						menuBtnLeft_jfieldId = JNIEnv.GetFieldID (class_ref, "menuBtnLeft", "Landroid/widget/Button;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, menuBtnLeft_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.Button> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (menuBtnLeft_jfieldId == IntPtr.Zero)
						menuBtnLeft_jfieldId = JNIEnv.GetFieldID (class_ref, "menuBtnLeft", "Landroid/widget/Button;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, menuBtnLeft_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr menuBtnRight_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='menuBtnRight']"
			[Register ("menuBtnRight")]
			public global::Android.Widget.Button MenuBtnRight {
				get {
					if (menuBtnRight_jfieldId == IntPtr.Zero)
						menuBtnRight_jfieldId = JNIEnv.GetFieldID (class_ref, "menuBtnRight", "Landroid/widget/Button;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, menuBtnRight_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.Button> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (menuBtnRight_jfieldId == IntPtr.Zero)
						menuBtnRight_jfieldId = JNIEnv.GetFieldID (class_ref, "menuBtnRight", "Landroid/widget/Button;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, menuBtnRight_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr statusImage_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='statusImage']"
			[Register ("statusImage")]
			public global::Android.Widget.ImageView StatusImage {
				get {
					if (statusImage_jfieldId == IntPtr.Zero)
						statusImage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusImage", "Landroid/widget/ImageView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, statusImage_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (statusImage_jfieldId == IntPtr.Zero)
						statusImage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusImage", "Landroid/widget/ImageView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, statusImage_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr unreadCount_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='unreadCount']"
			[Register ("unreadCount")]
			public global::Android.Widget.TextView UnreadCount {
				get {
					if (unreadCount_jfieldId == IntPtr.Zero)
						unreadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "unreadCount", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, unreadCount_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (unreadCount_jfieldId == IntPtr.Zero)
						unreadCount_jfieldId = JNIEnv.GetFieldID (class_ref, "unreadCount", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, unreadCount_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr userName_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='userName']"
			[Register ("userName")]
			public global::Android.Widget.TextView UserName {
				get {
					if (userName_jfieldId == IntPtr.Zero)
						userName_jfieldId = JNIEnv.GetFieldID (class_ref, "userName", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, userName_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (userName_jfieldId == IntPtr.Zero)
						userName_jfieldId = JNIEnv.GetFieldID (class_ref, "userName", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, userName_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr userStatus_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter.ViewHolder']/field[@name='userStatus']"
			[Register ("userStatus")]
			public global::Android.Widget.TextView UserStatus {
				get {
					if (userStatus_jfieldId == IntPtr.Zero)
						userStatus_jfieldId = JNIEnv.GetFieldID (class_ref, "userStatus", "Landroid/widget/TextView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, userStatus_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (userStatus_jfieldId == IntPtr.Zero)
						userStatus_jfieldId = JNIEnv.GetFieldID (class_ref, "userStatus", "Landroid/widget/TextView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, userStatus_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/adapters/BuddyListAdapter$ViewHolder", ref java_class_handle);
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
				return JNIEnv.FindClass ("com/inscripts/adapters/BuddyListAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BuddyListAdapter); }
		}

		protected BuddyListAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_util_List_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='BuddyListAdapter']/constructor[@name='BuddyListAdapter' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.List&lt;com.inscripts.models.Buddy&gt;']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/util/List;)V", "")]
		public unsafe BuddyListAdapter (global::Android.Content.Context p0, global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Buddy>.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (BuddyListAdapter)) {
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
