using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedStickers']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/RecentlyUsedStickers", DoNotGenerateAcw=true)]
	public partial class RecentlyUsedStickers : global::Java.Lang.Object {


		static IntPtr stickerDrawableArrayListRecentCategory_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedStickers']/field[@name='stickerDrawableArrayListRecentCategory']"
		[Register ("stickerDrawableArrayListRecentCategory")]
		public static global::System.Collections.IList StickerDrawableArrayListRecentCategory {
			get {
				if (stickerDrawableArrayListRecentCategory_jfieldId == IntPtr.Zero)
					stickerDrawableArrayListRecentCategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerDrawableArrayListRecentCategory", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerDrawableArrayListRecentCategory_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerDrawableArrayListRecentCategory_jfieldId == IntPtr.Zero)
					stickerDrawableArrayListRecentCategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerDrawableArrayListRecentCategory", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerDrawableArrayListRecentCategory_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr stickerUnicodeArrayListRecentcategory_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedStickers']/field[@name='stickerUnicodeArrayListRecentcategory']"
		[Register ("stickerUnicodeArrayListRecentcategory")]
		public static global::System.Collections.IList StickerUnicodeArrayListRecentcategory {
			get {
				if (stickerUnicodeArrayListRecentcategory_jfieldId == IntPtr.Zero)
					stickerUnicodeArrayListRecentcategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerUnicodeArrayListRecentcategory", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, stickerUnicodeArrayListRecentcategory_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (stickerUnicodeArrayListRecentcategory_jfieldId == IntPtr.Zero)
					stickerUnicodeArrayListRecentcategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "stickerUnicodeArrayListRecentcategory", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, stickerUnicodeArrayListRecentcategory_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.mapping']/interface[@name='RecentlyUsedStickers.RefreshGridViewAdapterListener']"
		[Register ("com/inscripts/mapping/RecentlyUsedStickers$RefreshGridViewAdapterListener", "", "Com.Inscripts.Mapping.RecentlyUsedStickers/IRefreshGridViewAdapterListenerInvoker")]
		public partial interface IRefreshGridViewAdapterListener : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.mapping']/interface[@name='RecentlyUsedStickers.RefreshGridViewAdapterListener']/method[@name='onNewStickerUsed' and count(parameter)=0]"
			[Register ("onNewStickerUsed", "()V", "GetOnNewStickerUsedHandler:Com.Inscripts.Mapping.RecentlyUsedStickers/IRefreshGridViewAdapterListenerInvoker, MessageSDKBinding.Droid")]
			void OnNewStickerUsed ();

		}

		[global::Android.Runtime.Register ("com/inscripts/mapping/RecentlyUsedStickers$RefreshGridViewAdapterListener", DoNotGenerateAcw=true)]
		internal class IRefreshGridViewAdapterListenerInvoker : global::Java.Lang.Object, IRefreshGridViewAdapterListener {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/mapping/RecentlyUsedStickers$RefreshGridViewAdapterListener");

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (IRefreshGridViewAdapterListenerInvoker); }
			}

			IntPtr class_ref;

			public static IRefreshGridViewAdapterListener GetObject (IntPtr handle, JniHandleOwnership transfer)
			{
				return global::Java.Lang.Object.GetObject<IRefreshGridViewAdapterListener> (handle, transfer);
			}

			static IntPtr Validate (IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
					throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
								JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.mapping.RecentlyUsedStickers.RefreshGridViewAdapterListener"));
				return handle;
			}

			protected override void Dispose (bool disposing)
			{
				if (this.class_ref != IntPtr.Zero)
					JNIEnv.DeleteGlobalRef (this.class_ref);
				this.class_ref = IntPtr.Zero;
				base.Dispose (disposing);
			}

			public IRefreshGridViewAdapterListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
			{
				IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
				this.class_ref = JNIEnv.NewGlobalRef (local_ref);
				JNIEnv.DeleteLocalRef (local_ref);
			}

			static Delegate cb_onNewStickerUsed;
#pragma warning disable 0169
			static Delegate GetOnNewStickerUsedHandler ()
			{
				if (cb_onNewStickerUsed == null)
					cb_onNewStickerUsed = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnNewStickerUsed);
				return cb_onNewStickerUsed;
			}

			static void n_OnNewStickerUsed (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Inscripts.Mapping.RecentlyUsedStickers.IRefreshGridViewAdapterListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Mapping.RecentlyUsedStickers.IRefreshGridViewAdapterListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.OnNewStickerUsed ();
			}
#pragma warning restore 0169

			IntPtr id_onNewStickerUsed;
			public unsafe void OnNewStickerUsed ()
			{
				if (id_onNewStickerUsed == IntPtr.Zero)
					id_onNewStickerUsed = JNIEnv.GetMethodID (class_ref, "onNewStickerUsed", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onNewStickerUsed);
			}

		}

		[global::Android.Runtime.Register ("mono/com/inscripts/mapping/RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor")]
		internal sealed partial class IRefreshGridViewAdapterListenerImplementor : global::Java.Lang.Object, IRefreshGridViewAdapterListener {

			object sender;

			public IRefreshGridViewAdapterListenerImplementor (object sender)
				: base (
					global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/inscripts/mapping/RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor", "()V"),
					JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
				this.sender = sender;
			}

#pragma warning disable 0649
			public EventHandler Handler;
#pragma warning restore 0649

			public void OnNewStickerUsed ()
			{
				var __h = Handler;
				if (__h != null)
					__h (sender, new EventArgs ());
			}

			internal static bool __IsEmpty (IRefreshGridViewAdapterListenerImplementor value)
			{
				return value.Handler == null;
			}
		}


		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/mapping/RecentlyUsedStickers", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RecentlyUsedStickers); }
		}

		protected RecentlyUsedStickers (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedStickers']/constructor[@name='RecentlyUsedStickers' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe RecentlyUsedStickers ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (RecentlyUsedStickers)) {
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

		static IntPtr id_addSticker_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedStickers_RefreshGridViewAdapterListener_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedStickers']/method[@name='addSticker' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Integer'] and parameter[3][@type='com.inscripts.mapping.RecentlyUsedStickers.RefreshGridViewAdapterListener']]"
		[Register ("addSticker", "(Ljava/lang/String;Ljava/lang/Integer;Lcom/inscripts/mapping/RecentlyUsedStickers$RefreshGridViewAdapterListener;)V", "")]
		public static unsafe void AddSticker (string p0, global::Java.Lang.Integer p1, global::Com.Inscripts.Mapping.RecentlyUsedStickers.IRefreshGridViewAdapterListener p2)
		{
			if (id_addSticker_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedStickers_RefreshGridViewAdapterListener_ == IntPtr.Zero)
				id_addSticker_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedStickers_RefreshGridViewAdapterListener_ = JNIEnv.GetStaticMethodID (class_ref, "addSticker", "(Ljava/lang/String;Ljava/lang/Integer;Lcom/inscripts/mapping/RecentlyUsedStickers$RefreshGridViewAdapterListener;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_addSticker_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedStickers_RefreshGridViewAdapterListener_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
