using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/UnblockUserListAdapter", DoNotGenerateAcw=true)]
	public partial class UnblockUserListAdapter : global::Android.Widget.ArrayAdapter {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter.ViewHolder']"
		[global::Android.Runtime.Register ("com/inscripts/adapters/UnblockUserListAdapter$ViewHolder", DoNotGenerateAcw=true)]
		public partial class ViewHolder : global::Java.Lang.Object {


			static IntPtr checkBox_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter.ViewHolder']/field[@name='checkBox']"
			[Register ("checkBox")]
			public global::Android.Widget.CheckBox CheckBox {
				get {
					if (checkBox_jfieldId == IntPtr.Zero)
						checkBox_jfieldId = JNIEnv.GetFieldID (class_ref, "checkBox", "Landroid/widget/CheckBox;");
					IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, checkBox_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Android.Widget.CheckBox> (__ret, JniHandleOwnership.TransferLocalRef);
				}
				set {
					if (checkBox_jfieldId == IntPtr.Zero)
						checkBox_jfieldId = JNIEnv.GetFieldID (class_ref, "checkBox", "Landroid/widget/CheckBox;");
					IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
					try {
						JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, checkBox_jfieldId, native_value);
					} finally {
						JNIEnv.DeleteLocalRef (native_value);
					}
				}
			}

			static IntPtr userName_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter.ViewHolder']/field[@name='userName']"
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
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/inscripts/adapters/UnblockUserListAdapter$ViewHolder", ref java_class_handle);
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
				return JNIEnv.FindClass ("com/inscripts/adapters/UnblockUserListAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (UnblockUserListAdapter); }
		}

		protected UnblockUserListAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_util_ArrayList_Ljava_util_ArrayList_Ljava_util_ArrayList_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter']/constructor[@name='UnblockUserListAdapter' and count(parameter)=4 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.ArrayList&lt;java.lang.String&gt;'] and parameter[3][@type='java.util.ArrayList&lt;java.lang.String&gt;'] and parameter[4][@type='java.util.ArrayList&lt;java.lang.String&gt;']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/util/ArrayList;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", "")]
		public unsafe UnblockUserListAdapter (global::Android.Content.Context p0, global::System.Collections.Generic.IList<string> p1, global::System.Collections.Generic.IList<string> p2, global::System.Collections.Generic.IList<string> p3)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p1);
			IntPtr native_p2 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p2);
			IntPtr native_p3 = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				if (GetType () != typeof (UnblockUserListAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/util/ArrayList;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/util/ArrayList;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_util_ArrayList_Ljava_util_ArrayList_Ljava_util_ArrayList_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_util_ArrayList_Ljava_util_ArrayList_Ljava_util_ArrayList_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/util/ArrayList;Ljava/util/ArrayList;Ljava/util/ArrayList;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_util_ArrayList_Ljava_util_ArrayList_Ljava_util_ArrayList_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_util_ArrayList_Ljava_util_ArrayList_Ljava_util_ArrayList_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
				JNIEnv.DeleteLocalRef (native_p2);
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static Delegate cb_getCheckedUsersList;
#pragma warning disable 0169
		static Delegate GetGetCheckedUsersListHandler ()
		{
			if (cb_getCheckedUsersList == null)
				cb_getCheckedUsersList = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCheckedUsersList);
			return cb_getCheckedUsersList;
		}

		static IntPtr n_GetCheckedUsersList (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Adapters.UnblockUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.UnblockUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<string>.ToLocalJniHandle (__this.CheckedUsersList);
		}
#pragma warning restore 0169

		static IntPtr id_getCheckedUsersList;
		public virtual unsafe global::System.Collections.Generic.IList<string> CheckedUsersList {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter']/method[@name='getCheckedUsersList' and count(parameter)=0]"
			[Register ("getCheckedUsersList", "()Ljava/util/ArrayList;", "GetGetCheckedUsersListHandler")]
			get {
				if (id_getCheckedUsersList == IntPtr.Zero)
					id_getCheckedUsersList = JNIEnv.GetMethodID (class_ref, "getCheckedUsersList", "()Ljava/util/ArrayList;");
				try {

					if (GetType () == ThresholdType)
						return global::Android.Runtime.JavaList<string>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCheckedUsersList), JniHandleOwnership.TransferLocalRef);
					else
						return global::Android.Runtime.JavaList<string>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCheckedUsersList", "()Ljava/util/ArrayList;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static Delegate cb_toggleUnblock_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetToggleUnblock_Ljava_lang_String_Handler ()
		{
			if (cb_toggleUnblock_Ljava_lang_String_ == null)
				cb_toggleUnblock_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ToggleUnblock_Ljava_lang_String_);
			return cb_toggleUnblock_Ljava_lang_String_;
		}

		static void n_ToggleUnblock_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Adapters.UnblockUserListAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Adapters.UnblockUserListAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ToggleUnblock (p0);
		}
#pragma warning restore 0169

		static IntPtr id_toggleUnblock_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='UnblockUserListAdapter']/method[@name='toggleUnblock' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("toggleUnblock", "(Ljava/lang/String;)V", "GetToggleUnblock_Ljava_lang_String_Handler")]
		public virtual unsafe void ToggleUnblock (string p0)
		{
			if (id_toggleUnblock_Ljava_lang_String_ == IntPtr.Zero)
				id_toggleUnblock_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "toggleUnblock", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_toggleUnblock_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "toggleUnblock", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
