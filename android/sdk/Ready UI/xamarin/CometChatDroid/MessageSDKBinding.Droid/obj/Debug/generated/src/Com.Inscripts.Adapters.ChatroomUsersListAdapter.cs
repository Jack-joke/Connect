using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Adapters {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ChatroomUsersListAdapter']"
	[global::Android.Runtime.Register ("com/inscripts/adapters/ChatroomUsersListAdapter", DoNotGenerateAcw=true)]
	public partial class ChatroomUsersListAdapter : global::Android.Widget.ArrayAdapter {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ChatroomUsersListAdapter.ViewHolder']"
		[global::Android.Runtime.Register ("com/inscripts/adapters/ChatroomUsersListAdapter$ViewHolder", DoNotGenerateAcw=true)]
		public partial class ViewHolder : global::Java.Lang.Object {

			protected ViewHolder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/adapters/ChatroomUsersListAdapter", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ChatroomUsersListAdapter); }
		}

		protected ChatroomUsersListAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Ljava_util_ArrayList_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.adapters']/class[@name='ChatroomUsersListAdapter']/constructor[@name='ChatroomUsersListAdapter' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.ArrayList&lt;com.inscripts.pojos.ChatroomMembers&gt;']]"
		[Register (".ctor", "(Landroid/content/Context;Ljava/util/ArrayList;)V", "")]
		public unsafe ChatroomUsersListAdapter (global::Android.Content.Context p0, global::System.Collections.Generic.IList<global::Com.Inscripts.Pojos.ChatroomMembers> p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Com.Inscripts.Pojos.ChatroomMembers>.ToLocalJniHandle (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (ChatroomUsersListAdapter)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Ljava/util/ArrayList;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Ljava/util/ArrayList;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Ljava_util_ArrayList_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Ljava_util_ArrayList_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/util/ArrayList;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Ljava_util_ArrayList_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Ljava_util_ArrayList_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

	}
}
