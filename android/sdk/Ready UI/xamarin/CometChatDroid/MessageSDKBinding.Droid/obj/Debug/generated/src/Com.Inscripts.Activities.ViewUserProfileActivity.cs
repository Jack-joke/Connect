using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/ViewUserProfileActivity", DoNotGenerateAcw=true)]
	public partial class ViewUserProfileActivity : global::Com.Inscripts.Utils.SuperActivity {


		static IntPtr audioCallContainer_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='audioCallContainer']"
		[Register ("audioCallContainer")]
		protected global::Android.Widget.RelativeLayout AudioCallContainer {
			get {
				if (audioCallContainer_jfieldId == IntPtr.Zero)
					audioCallContainer_jfieldId = JNIEnv.GetFieldID (class_ref, "audioCallContainer", "Landroid/widget/RelativeLayout;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, audioCallContainer_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (audioCallContainer_jfieldId == IntPtr.Zero)
					audioCallContainer_jfieldId = JNIEnv.GetFieldID (class_ref, "audioCallContainer", "Landroid/widget/RelativeLayout;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, audioCallContainer_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr name_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='name']"
		[Register ("name")]
		protected global::Android.Widget.TextView Name {
			get {
				if (name_jfieldId == IntPtr.Zero)
					name_jfieldId = JNIEnv.GetFieldID (class_ref, "name", "Landroid/widget/TextView;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, name_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (name_jfieldId == IntPtr.Zero)
					name_jfieldId = JNIEnv.GetFieldID (class_ref, "name", "Landroid/widget/TextView;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, name_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr statusImage_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='statusImage']"
		[Register ("statusImage")]
		protected global::Android.Widget.ImageView StatusImage {
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

		static IntPtr statusMessage_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='statusMessage']"
		[Register ("statusMessage")]
		protected global::Android.Widget.TextView StatusMessage {
			get {
				if (statusMessage_jfieldId == IntPtr.Zero)
					statusMessage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusMessage", "Landroid/widget/TextView;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, statusMessage_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (statusMessage_jfieldId == IntPtr.Zero)
					statusMessage_jfieldId = JNIEnv.GetFieldID (class_ref, "statusMessage", "Landroid/widget/TextView;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, statusMessage_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr tvAudioCall_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='tvAudioCall']"
		[Register ("tvAudioCall")]
		protected global::Android.Widget.TextView TvAudioCall {
			get {
				if (tvAudioCall_jfieldId == IntPtr.Zero)
					tvAudioCall_jfieldId = JNIEnv.GetFieldID (class_ref, "tvAudioCall", "Landroid/widget/TextView;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, tvAudioCall_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (tvAudioCall_jfieldId == IntPtr.Zero)
					tvAudioCall_jfieldId = JNIEnv.GetFieldID (class_ref, "tvAudioCall", "Landroid/widget/TextView;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, tvAudioCall_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr tvVideoCall_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='tvVideoCall']"
		[Register ("tvVideoCall")]
		protected global::Android.Widget.TextView TvVideoCall {
			get {
				if (tvVideoCall_jfieldId == IntPtr.Zero)
					tvVideoCall_jfieldId = JNIEnv.GetFieldID (class_ref, "tvVideoCall", "Landroid/widget/TextView;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, tvVideoCall_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (tvVideoCall_jfieldId == IntPtr.Zero)
					tvVideoCall_jfieldId = JNIEnv.GetFieldID (class_ref, "tvVideoCall", "Landroid/widget/TextView;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, tvVideoCall_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr videoCallContainer_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/field[@name='videoCallContainer']"
		[Register ("videoCallContainer")]
		protected global::Android.Widget.RelativeLayout VideoCallContainer {
			get {
				if (videoCallContainer_jfieldId == IntPtr.Zero)
					videoCallContainer_jfieldId = JNIEnv.GetFieldID (class_ref, "videoCallContainer", "Landroid/widget/RelativeLayout;");
				IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, videoCallContainer_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.Widget.RelativeLayout> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (videoCallContainer_jfieldId == IntPtr.Zero)
					videoCallContainer_jfieldId = JNIEnv.GetFieldID (class_ref, "videoCallContainer", "Landroid/widget/RelativeLayout;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				try {
					JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, videoCallContainer_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/ViewUserProfileActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ViewUserProfileActivity); }
		}

		protected ViewUserProfileActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='ViewUserProfileActivity']/constructor[@name='ViewUserProfileActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe ViewUserProfileActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (ViewUserProfileActivity)) {
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
