using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/InviteUserListAdapter", DoNotGenerateAcw=true)]
	public partial class InviteUserListAdapter : global::Android.Widget.ArrayAdapter {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']"
		[global::Android.Runtime.Register ("com/inscripts/adapters/InviteUserListAdapter$ViewHolder", DoNotGenerateAcw=true)]
		public partial class ViewHolder : global::Java.Lang.Object {


			static IntPtr inviteUserCheckBox_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']/field[@name='inviteUserCheckBox']"
			[Register ("inviteUserCheckBox")]
			public global::Android.Widget.CheckBox InviteUserCheckBox {
				get {
					if (inviteUserCheckBox_jfieldId == IntPtr.Zero)
						inviteUserCheckBox_jfieldId = JNIEnv.GetFieldID (class_ref, "inviteUserCheckBox", "Landroid/widget/CheckBox;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, inviteUserCheckBox_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.CheckBox> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (inviteUserCheckBox_jfieldId == IntPtr.Zero)
						inviteUserCheckBox_jfieldId = JNIEnv.GetFieldID (class_ref, "inviteUserCheckBox", "Landroid/widget/CheckBox;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, inviteUserCheckBox_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr userAvatar_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']/field[@name='userAvatar']"
			[Register ("userAvatar")]
			public global::Com.Inscripts.Custom.RoundedImageView UserAvatar {
				get {
					if (userAvatar_jfieldId == IntPtr.Zero)
						userAvatar_jfieldId = JNIEnv.GetFieldID (class_ref, "userAvatar", "Lcom/inscripts/custom/RoundedImageView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, userAvatar_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Custom.RoundedImageView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (userAvatar_jfieldId == IntPtr.Zero)
						userAvatar_jfieldId = JNIEnv.GetFieldID (class_ref, "userAvatar", "Lcom/inscripts/custom/RoundedImageView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, userAvatar_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr userName_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']/field[@name='userName']"
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

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']/field[@name='userStatus']"
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

			static IntPtr userStatusImage_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter.ViewHolder']/field[@name='userStatusImage']"
			[Register ("userStatusImage")]
			public global::Android.Widget.ImageView UserStatusImage {
				get {
					if (userStatusImage_jfieldId == IntPtr.Zero)
						userStatusImage_jfieldId = JNIEnv.GetFieldID (class_ref, "userStatusImage", "Landroid/widget/ImageView;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, userStatusImage_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.ImageView> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (userStatusImage_jfieldId == IntPtr.Zero)
						userStatusImage_jfieldId = JNIEnv.GetFieldID (class_ref, "userStatusImage", "Landroid/widget/ImageView;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, userStatusImage_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/adapters/InviteUserListAdapter$ViewHolder", ref java_class_handle);
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
				return JNIEnv.FindClass ("com/inscripts/adapters/InviteUserListAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (InviteUserListAdapter); }
		}

		protected InviteUserListAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_util_List_Ljava_util_ArrayList_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']/constructor[@name='InviteUserListAdapter' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.List&lt;com.inscripts.models.Buddy&gt;'] and parameter[3][@type='java.util.ArrayList&lt;java.lang.String&gt;']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/util/List;Ljava/util/ArrayList;)V", "")]
		public unsafe InviteUserListAdapter (global::Android.Content.Context p0, global::System.Collections.Generic.IList<global::Com.Inscripts.Models.Buddy> p1, global::System.Collections.Generic.IList<string> p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Com.Inscripts.Models.Buddy>.ToLocalJniHandle (p1);
			IntPtr native_p2 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				if (GetType () != typeof (InviteUserListAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/util/List;Ljava/util/ArrayList;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/util/List;Ljava/util/ArrayList;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_util_List_Ljava_util_ArrayList_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_util_List_Ljava_util_ArrayList_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/util/List;Ljava/util/ArrayList;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_util_List_Ljava_util_ArrayList_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_util_List_Ljava_util_ArrayList_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
			}
		}

		static Delegate cb_getInviteUsersList;
#pragma warning disable 0169
		static Delegate GetGetInviteUsersListHandler ()
		{
			if (cb_getInviteUsersList == null)
				cb_getInviteUsersList = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInviteUsersList);
			return cb_getInviteUsersList;
		}

		static IntPtr n_GetInviteUsersList (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.InviteUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.InviteUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<string>.ToLocalJniHandle (__this.InviteUsersList);
		}
#pragma warning restore 0169

		static IntPtr id_getInviteUsersList;
		public virtual unsafe global::System.Collections.Generic.IList<string> InviteUsersList {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']/method[@name='getInviteUsersList' and count(parameter)=0]"
			[Register ("getInviteUsersList", "()Ljava/util/ArrayList;", "GetGetInviteUsersListHandler")]
			get {
				if (id_getInviteUsersList == IntPtr.Zero)
					id_getInviteUsersList = JNIEnv.GetMethodID (class_ref, "getInviteUsersList", "()Ljava/util/ArrayList;");
				try {

					if (GetType () == ThresholdType)
						return global::Android.Runtime.JavaList<string>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInviteUsersList), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaList<string>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInviteUsersList", "()Ljava/util/ArrayList;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_getInvitedUsersCount;
#pragma warning disable 0169
		static Delegate GetGetInvitedUsersCountHandler ()
		{
			if (cb_getInvitedUsersCount == null)
				cb_getInvitedUsersCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetInvitedUsersCount);
			return cb_getInvitedUsersCount;
		}

		static int n_GetInvitedUsersCount (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.InviteUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.InviteUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.InvitedUsersCount;
		}
#pragma warning restore 0169

		static IntPtr id_getInvitedUsersCount;
		public virtual unsafe int InvitedUsersCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']/method[@name='getInvitedUsersCount' and count(parameter)=0]"
			[Register ("getInvitedUsersCount", "()I", "GetGetInvitedUsersCountHandler")]
			get {
				if (id_getInvitedUsersCount == IntPtr.Zero)
					id_getInvitedUsersCount = JNIEnv.GetMethodID (class_ref, "getInvitedUsersCount", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getInvitedUsersCount);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getInvitedUsersCount", "()I"));
				} finally {
				}
			}
		}

		static Delegate cb_clearInviteList;
#pragma warning disable 0169
		static Delegate GetClearInviteListHandler ()
		{
			if (cb_clearInviteList == null)
				cb_clearInviteList = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ClearInviteList);
			return cb_clearInviteList;
		}

		static void n_ClearInviteList (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.InviteUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.InviteUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ClearInviteList ();
		}
#pragma warning restore 0169

		static IntPtr id_clearInviteList;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']/method[@name='clearInviteList' and count(parameter)=0]"
		[Register ("clearInviteList", "()V", "GetClearInviteListHandler")]
		public virtual unsafe void ClearInviteList ()
		{
			if (id_clearInviteList == IntPtr.Zero)
				id_clearInviteList = JNIEnv.GetMethodID (class_ref, "clearInviteList", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearInviteList);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "clearInviteList", "()V"));
			} finally {
			}
		}

		static Delegate cb_toggleInvite_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetToggleInvite_Ljava_lang_String_Handler ()
		{
			if (cb_toggleInvite_Ljava_lang_String_ == null)
				cb_toggleInvite_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ToggleInvite_Ljava_lang_String_);
			return cb_toggleInvite_Ljava_lang_String_;
		}

		static void n_ToggleInvite_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Adapters.InviteUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.InviteUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleInvite (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleInvite_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='InviteUserListAdapter']/method[@name='toggleInvite' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("toggleInvite", "(Ljava/lang/String;)V", "GetToggleInvite_Ljava_lang_String_Handler")]
		public virtual unsafe void ToggleInvite (string p0)
		{
			if (id_toggleInvite_Ljava_lang_String_ == IntPtr.Zero)
				id_toggleInvite_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "toggleInvite", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggleInvite_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggleInvite", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}