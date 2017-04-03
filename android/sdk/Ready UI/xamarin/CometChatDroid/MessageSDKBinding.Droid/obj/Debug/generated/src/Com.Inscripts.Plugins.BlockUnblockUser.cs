using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Plugins {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='BlockUnblockUser']"
	[global::Android.Runtime.Register ("com/inscripts/plugins/BlockUnblockUser", DoNotGenerateAcw=true)]
	public partial class BlockUnblockUser : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/plugins/BlockUnblockUser", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (BlockUnblockUser); }
		}

		protected BlockUnblockUser (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='BlockUnblockUser']/constructor[@name='BlockUnblockUser' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe BlockUnblockUser ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (BlockUnblockUser)) {
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

		static IntPtr id_blockUser_JLandroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='BlockUnblockUser']/method[@name='blockUser' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='android.content.Context'] and parameter[3][@type='com.inscripts.interfaces.CometchatCallbacks']]"
		[Register ("blockUser", "(JLandroid/content/Context;Lcom/inscripts/interfaces/CometchatCallbacks;)V", "")]
		public static unsafe void BlockUser (long p0, global::Android.Content.Context p1, global::Com.Inscripts.Interfaces.ICometchatCallbacks p2)
		{
			if (id_blockUser_JLandroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_ == IntPtr.Zero)
				id_blockUser_JLandroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_ = JNIEnv.GetStaticMethodID (class_ref, "blockUser", "(JLandroid/content/Context;Lcom/inscripts/interfaces/CometchatCallbacks;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_blockUser_JLandroid_content_Context_Lcom_inscripts_interfaces_CometchatCallbacks_, __args);
			} finally {
			}
		}

		static IntPtr id_isblockUnblockDisabled;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.plugins']/class[@name='BlockUnblockUser']/method[@name='isblockUnblockDisabled' and count(parameter)=0]"
		[Register ("isblockUnblockDisabled", "()Z", "")]
		public static unsafe bool IsblockUnblockDisabled ()
		{
			if (id_isblockUnblockDisabled == IntPtr.Zero)
				id_isblockUnblockDisabled = JNIEnv.GetStaticMethodID (class_ref, "isblockUnblockDisabled", "()Z");
			try {
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isblockUnblockDisabled);
			} finally {
			}
		}

	}
}
