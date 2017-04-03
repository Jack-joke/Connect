using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Activities {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity']"
	[global::Android.Runtime.Register ("com/inscripts/activities/SelectLanguageActivity", DoNotGenerateAcw=true)]
	public partial class SelectLanguageActivity : global::Com.Inscripts.Utils.SuperActivity {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']"
		[global::Android.Runtime.Register ("com/inscripts/activities/SelectLanguageActivity$LanguageAdapter", DoNotGenerateAcw=true)]
		public partial class LanguageAdapter : global::Android.Widget.BaseAdapter {

			// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter.ViewHolder']"
			[global::Android.Runtime.Register ("com/inscripts/activities/SelectLanguageActivity$LanguageAdapter$ViewHolder", DoNotGenerateAcw=true)]
			public partial class ViewHolder : global::Java.Lang.Object {


				static IntPtr container_jfieldId;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter.ViewHolder']/field[@name='container']"
				[Register ("container")]
				public global::Android.Widget.LinearLayout Container {
					get {
						if (container_jfieldId == IntPtr.Zero)
							container_jfieldId = JNIEnv.GetFieldID (class_ref, "container", "Landroid/widget/LinearLayout;");
						IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, container_jfieldId);
						return global::Java.Lang.Object.GetObject<global::Android.Widget.LinearLayout> (__ret, JniHandleOwnership.TransferLocalRef);
					}
					set {
						if (container_jfieldId == IntPtr.Zero)
							container_jfieldId = JNIEnv.GetFieldID (class_ref, "container", "Landroid/widget/LinearLayout;");
						IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
						try {
							JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, container_jfieldId, native_value);
						} finally {
							JNIEnv.DeleteLocalRef (native_value);
						}
					}
				}

				static IntPtr langName_jfieldId;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter.ViewHolder']/field[@name='langName']"
				[Register ("langName")]
				public global::Android.Widget.TextView LangName {
					get {
						if (langName_jfieldId == IntPtr.Zero)
							langName_jfieldId = JNIEnv.GetFieldID (class_ref, "langName", "Landroid/widget/TextView;");
						IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, langName_jfieldId);
						return global::Java.Lang.Object.GetObject<global::Android.Widget.TextView> (__ret, JniHandleOwnership.TransferLocalRef);
					}
					set {
						if (langName_jfieldId == IntPtr.Zero)
							langName_jfieldId = JNIEnv.GetFieldID (class_ref, "langName", "Landroid/widget/TextView;");
						IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
						try {
							JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, langName_jfieldId, native_value);
						} finally {
							JNIEnv.DeleteLocalRef (native_value);
						}
					}
				}

				static IntPtr radioButton_jfieldId;

				// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter.ViewHolder']/field[@name='radioButton']"
				[Register ("radioButton")]
				public global::Android.Widget.RadioButton RadioButton {
					get {
						if (radioButton_jfieldId == IntPtr.Zero)
							radioButton_jfieldId = JNIEnv.GetFieldID (class_ref, "radioButton", "Landroid/widget/RadioButton;");
						IntPtr __ret = JNIEnv.GetObjectField (((global::Java.Lang.Object) this).Handle, radioButton_jfieldId);
						return global::Java.Lang.Object.GetObject<global::Android.Widget.RadioButton> (__ret, JniHandleOwnership.TransferLocalRef);
					}
					set {
						if (radioButton_jfieldId == IntPtr.Zero)
							radioButton_jfieldId = JNIEnv.GetFieldID (class_ref, "radioButton", "Landroid/widget/RadioButton;");
						IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
						try {
							JNIEnv.SetField (((global::Java.Lang.Object) this).Handle, radioButton_jfieldId, native_value);
						} finally {
							JNIEnv.DeleteLocalRef (native_value);
						}
					}
				}
				internal static IntPtr java_class_handle;
				internal static IntPtr class_ref {
					get {
						return JNIEnv.FindClass ("com/inscripts/activities/SelectLanguageActivity$LanguageAdapter$ViewHolder", ref java_class_handle);
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
					return JNIEnv.FindClass ("com/inscripts/activities/SelectLanguageActivity$LanguageAdapter", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (LanguageAdapter); }
			}

			protected LanguageAdapter (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_ctor_Lcom_inscripts_activities_SelectLanguageActivity_Landroid_content_Context_arrayLjava_lang_String_;
			// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']/constructor[@name='SelectLanguageActivity.LanguageAdapter' and count(parameter)=3 and parameter[1][@type='com.inscripts.activities.SelectLanguageActivity'] and parameter[2][@type='android.content.Context'] and parameter[3][@type='java.lang.String[]']]"
			[Register (".ctor", "(Lcom/inscripts/activities/SelectLanguageActivity;Landroid/content/Context;[Ljava/lang/String;)V", "")]
			public unsafe LanguageAdapter (global::Com.Inscripts.Activities.SelectLanguageActivity __self, global::Android.Content.Context p1, string[] p2)
				: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
					return;

				IntPtr native_p2 = JNIEnv.NewArray (p2);
				try {
					JValue* __args = stackalloc JValue [3];
					__args [0] = new JValue (__self);
					__args [1] = new JValue (p1);
					__args [2] = new JValue (native_p2);
					if (GetType () != typeof (LanguageAdapter)) {
						SetHandle (
								global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(L" + global::Android.Runtime.JNIEnv.GetJniName (GetType ().DeclaringType) + ";Landroid/content/Context;[Ljava/lang/String;)V", __args),
								JniHandleOwnership.TransferLocalRef);
						global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(L" + global::Android.Runtime.JNIEnv.GetJniName (GetType ().DeclaringType) + ";Landroid/content/Context;[Ljava/lang/String;)V", __args);
						return;
					}

					if (id_ctor_Lcom_inscripts_activities_SelectLanguageActivity_Landroid_content_Context_arrayLjava_lang_String_ == IntPtr.Zero)
						id_ctor_Lcom_inscripts_activities_SelectLanguageActivity_Landroid_content_Context_arrayLjava_lang_String_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Lcom/inscripts/activities/SelectLanguageActivity;Landroid/content/Context;[Ljava/lang/String;)V");
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Lcom_inscripts_activities_SelectLanguageActivity_Landroid_content_Context_arrayLjava_lang_String_, __args),
							JniHandleOwnership.TransferLocalRef);
					JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Lcom_inscripts_activities_SelectLanguageActivity_Landroid_content_Context_arrayLjava_lang_String_, __args);
				} finally {
					if (p2 != null) {
						JNIEnv.CopyArray (native_p2, p2);
						JNIEnv.DeleteLocalRef (native_p2);
					}
				}
			}

			static Delegate cb_getCount;
#pragma warning disable 0169
			static Delegate GetGetCountHandler ()
			{
				if (cb_getCount == null)
					cb_getCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetCount);
				return cb_getCount;
			}

			static int n_GetCount (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return __this.Count;
			}
#pragma warning restore 0169

			static IntPtr id_getCount;
			public override unsafe int Count {
				// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']/method[@name='getCount' and count(parameter)=0]"
				[Register ("getCount", "()I", "GetGetCountHandler")]
				get {
					if (id_getCount == IntPtr.Zero)
						id_getCount = JNIEnv.GetMethodID (class_ref, "getCount", "()I");
					try {

						if (GetType () == ThresholdType)
							return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCount);
						else
							return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCount", "()I"));
					} finally {
					}
				}
			}

			static Delegate cb_getItem_I;
#pragma warning disable 0169
			static Delegate GetGetItem_IHandler ()
			{
				if (cb_getItem_I == null)
					cb_getItem_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetItem_I);
				return cb_getItem_I;
			}

			static IntPtr n_GetItem_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.GetItem (p0));
			}
#pragma warning restore 0169

			static IntPtr id_getItem_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']/method[@name='getItem' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("getItem", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
			public override unsafe global::Java.Lang.Object GetItem (int p0)
			{
				if (id_getItem_I == IntPtr.Zero)
					id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Ljava/lang/Object;");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getItem_I, __args), JniHandleOwnership.TransferLocalRef);
					else
						return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Ljava/lang/Object;"), __args), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}

			static Delegate cb_getItemId_I;
#pragma warning disable 0169
			static Delegate GetGetItemId_IHandler ()
			{
				if (cb_getItemId_I == null)
					cb_getItemId_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, long>) n_GetItemId_I);
				return cb_getItemId_I;
			}

			static long n_GetItemId_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return __this.GetItemId (p0);
			}
#pragma warning restore 0169

			static IntPtr id_getItemId_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']/method[@name='getItemId' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("getItemId", "(I)J", "GetGetItemId_IHandler")]
			public override unsafe long GetItemId (int p0)
			{
				if (id_getItemId_I == IntPtr.Zero)
					id_getItemId_I = JNIEnv.GetMethodID (class_ref, "getItemId", "(I)J");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (p0);

					if (GetType () == ThresholdType)
						return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getItemId_I, __args);
					else
						return JNIEnv.CallNonvirtualLongMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItemId", "(I)J"), __args);
				} finally {
				}
			}

			static Delegate cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_;
#pragma warning disable 0169
			static Delegate GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler ()
			{
				if (cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_ == null)
					cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>) n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_);
				return cb_getView_ILandroid_view_View_Landroid_view_ViewGroup_;
			}

			static IntPtr n_GetView_ILandroid_view_View_Landroid_view_ViewGroup_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
			{
				global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Activities.SelectLanguageActivity.LanguageAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				global::Android.Views.View p1 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p1, JniHandleOwnership.DoNotTransfer);
				global::Android.Views.ViewGroup p2 = global::Java.Lang.Object.GetObject<global::Android.Views.ViewGroup> (native_p2, JniHandleOwnership.DoNotTransfer);
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetView (p0, p1, p2));
				return __ret;
			}
#pragma warning restore 0169

			static IntPtr id_getView_ILandroid_view_View_Landroid_view_ViewGroup_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity.LanguageAdapter']/method[@name='getView' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='android.view.View'] and parameter[3][@type='android.view.ViewGroup']]"
			[Register ("getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;", "GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler")]
			public override unsafe global::Android.Views.View GetView (int p0, global::Android.Views.View p1, global::Android.Views.ViewGroup p2)
			{
				if (id_getView_ILandroid_view_View_Landroid_view_ViewGroup_ == IntPtr.Zero)
					id_getView_ILandroid_view_View_Landroid_view_ViewGroup_ = JNIEnv.GetMethodID (class_ref, "getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;");
				try {
					JValue* __args = stackalloc JValue [3];
					__args [0] = new JValue (p0);
					__args [1] = new JValue (p1);
					__args [2] = new JValue (p2);

					global::Android.Views.View __ret;
					if (GetType () == ThresholdType)
						__ret = global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getView_ILandroid_view_View_Landroid_view_ViewGroup_, __args), JniHandleOwnership.TransferLocalRef);
					else
						__ret = global::Java.Lang.Object.GetObject<global::Android.Views.View> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getView", "(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;"), __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
				}
			}

		}

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/activities/SelectLanguageActivity", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (SelectLanguageActivity); }
		}

		protected SelectLanguageActivity (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.activities']/class[@name='SelectLanguageActivity']/constructor[@name='SelectLanguageActivity' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe SelectLanguageActivity ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (SelectLanguageActivity)) {
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
