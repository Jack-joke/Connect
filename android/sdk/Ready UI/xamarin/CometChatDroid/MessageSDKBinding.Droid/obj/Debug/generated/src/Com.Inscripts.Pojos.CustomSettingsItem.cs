using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Pojos {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']"
	[global::Android.Runtime.Register ("com/inscripts/pojos/CustomSettingsItem", DoNotGenerateAcw=true)]
	public partial class CustomSettingsItem : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/pojos/CustomSettingsItem", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (CustomSettingsItem); }
		}

		protected CustomSettingsItem (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_ILjava_lang_String_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']/constructor[@name='CustomSettingsItem' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='java.lang.String']]"
		[Register (".ctor", "(ILjava/lang/String;)V", "")]
		public unsafe CustomSettingsItem (int p0, string p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				if (GetType () != typeof (CustomSettingsItem)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(ILjava/lang/String;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(ILjava/lang/String;)V", __args);
					return;
				}

				if (id_ctor_ILjava_lang_String_ == IntPtr.Zero)
					id_ctor_ILjava_lang_String_ = JNIEnv.GetMethodID (class_ref, "<init>", "(ILjava/lang/String;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_ILjava_lang_String_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_ILjava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static Delegate cb_getItemName;
#pragma warning disable 0169
		static Delegate GetGetItemNameHandler ()
		{
			if (cb_getItemName == null)
				cb_getItemName = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetItemName);
			return cb_getItemName;
		}

		static IntPtr n_GetItemName (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.CustomSettingsItem __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.CustomSettingsItem> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.ItemName);
		}
#pragma warning restore 0169

		static Delegate cb_setItemName_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSetItemName_Ljava_lang_String_Handler ()
		{
			if (cb_setItemName_Ljava_lang_String_ == null)
				cb_setItemName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetItemName_Ljava_lang_String_);
			return cb_setItemName_Ljava_lang_String_;
		}

		static void n_SetItemName_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Inscripts.Pojos.CustomSettingsItem __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.CustomSettingsItem> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ItemName = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getItemName;
		static IntPtr id_setItemName_Ljava_lang_String_;
		public virtual unsafe string ItemName {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']/method[@name='getItemName' and count(parameter)=0]"
			[Register ("getItemName", "()Ljava/lang/String;", "GetGetItemNameHandler")]
			get {
				if (id_getItemName == IntPtr.Zero)
					id_getItemName = JNIEnv.GetMethodID (class_ref, "getItemName", "()Ljava/lang/String;");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getItemName), JniHandleOwnership.TransferLocalRef);
					else
						return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItemName", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']/method[@name='setItemName' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("setItemName", "(Ljava/lang/String;)V", "GetSetItemName_Ljava_lang_String_Handler")]
			set {
				if (id_setItemName_Ljava_lang_String_ == IntPtr.Zero)
					id_setItemName_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "setItemName", "(Ljava/lang/String;)V");
				IntPtr native_value = JNIEnv.NewString (value);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setItemName_Ljava_lang_String_, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setItemName", "(Ljava/lang/String;)V"), __args);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static Delegate cb_getType;
#pragma warning disable 0169
		static Delegate GetGetTypeHandler ()
		{
			if (cb_getType == null)
				cb_getType = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetType);
			return cb_getType;
		}

		static int n_GetType (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Inscripts.Pojos.CustomSettingsItem __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.CustomSettingsItem> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Type;
		}
#pragma warning restore 0169

		static Delegate cb_setType_I;
#pragma warning disable 0169
		static Delegate GetSetType_IHandler ()
		{
			if (cb_setType_I == null)
				cb_setType_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetType_I);
			return cb_setType_I;
		}

		static void n_SetType_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Com.Inscripts.Pojos.CustomSettingsItem __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Pojos.CustomSettingsItem> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Type = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getType;
		static IntPtr id_setType_I;
		public virtual unsafe int Type {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']/method[@name='getType' and count(parameter)=0]"
			[Register ("getType", "()I", "GetGetTypeHandler")]
			get {
				if (id_getType == IntPtr.Zero)
					id_getType = JNIEnv.GetMethodID (class_ref, "getType", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getType);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getType", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.pojos']/class[@name='CustomSettingsItem']/method[@name='setType' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setType", "(I)V", "GetSetType_IHandler")]
			set {
				if (id_setType_I == IntPtr.Zero)
					id_setType_I = JNIEnv.GetMethodID (class_ref, "setType", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setType_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setType", "(I)V"), __args);
				} finally {
				}
			}
		}

	}
}
