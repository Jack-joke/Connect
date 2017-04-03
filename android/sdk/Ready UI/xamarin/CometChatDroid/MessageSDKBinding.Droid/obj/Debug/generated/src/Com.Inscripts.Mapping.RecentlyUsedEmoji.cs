using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Mapping {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedEmoji']"
	[global::Android.Runtime.Register ("com/inscripts/mapping/RecentlyUsedEmoji", DoNotGenerateAcw=true)]
	public partial class RecentlyUsedEmoji : global::Java.Lang.Object {


		static IntPtr emojiDrawableArrayListRecentCategory_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedEmoji']/field[@name='emojiDrawableArrayListRecentCategory']"
		[Register ("emojiDrawableArrayListRecentCategory")]
		public static global::System.Collections.IList EmojiDrawableArrayListRecentCategory {
			get {
				if (emojiDrawableArrayListRecentCategory_jfieldId == IntPtr.Zero)
					emojiDrawableArrayListRecentCategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "emojiDrawableArrayListRecentCategory", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, emojiDrawableArrayListRecentCategory_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (emojiDrawableArrayListRecentCategory_jfieldId == IntPtr.Zero)
					emojiDrawableArrayListRecentCategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "emojiDrawableArrayListRecentCategory", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, emojiDrawableArrayListRecentCategory_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}

		static IntPtr emojiUnicodeArrayListRecentcategory_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedEmoji']/field[@name='emojiUnicodeArrayListRecentcategory']"
		[Register ("emojiUnicodeArrayListRecentcategory")]
		public static global::System.Collections.IList EmojiUnicodeArrayListRecentcategory {
			get {
				if (emojiUnicodeArrayListRecentcategory_jfieldId == IntPtr.Zero)
					emojiUnicodeArrayListRecentcategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "emojiUnicodeArrayListRecentcategory", "Ljava/util/ArrayList;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, emojiUnicodeArrayListRecentcategory_jfieldId);
				return global::Android.Runtime.JavaList.FromJniHandle (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (emojiUnicodeArrayListRecentcategory_jfieldId == IntPtr.Zero)
					emojiUnicodeArrayListRecentcategory_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "emojiUnicodeArrayListRecentcategory", "Ljava/util/ArrayList;");
				IntPtr native_value = global::Android.Runtime.JavaList.ToLocalJniHandle (value);
				try {
					JNIEnv.SetStaticField (class_ref, emojiUnicodeArrayListRecentcategory_jfieldId, native_value);
				} finally {
					JNIEnv.DeleteLocalRef (native_value);
				}
			}
		}
		// Metadata.xml XPath interface reference: path="/api/package[@name='com.inscripts.mapping']/interface[@name='RecentlyUsedEmoji.RefreshGridViewAdapterListener']"
		[Register ("com/inscripts/mapping/RecentlyUsedEmoji$RefreshGridViewAdapterListener", "", "Com.Inscripts.Mapping.RecentlyUsedEmoji/IRefreshGridViewAdapterListenerInvoker")]
		public partial interface IRefreshGridViewAdapterListener : IJavaObject {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.mapping']/interface[@name='RecentlyUsedEmoji.RefreshGridViewAdapterListener']/method[@name='onNewEmojiUsed' and count(parameter)=0]"
			[Register ("onNewEmojiUsed", "()V", "GetOnNewEmojiUsedHandler:Com.Inscripts.Mapping.RecentlyUsedEmoji/IRefreshGridViewAdapterListenerInvoker, MessageSDKBinding.Droid")]
			void OnNewEmojiUsed ();

		}

		[global::Android.Runtime.Register ("com/inscripts/mapping/RecentlyUsedEmoji$RefreshGridViewAdapterListener", DoNotGenerateAcw=true)]
		internal class IRefreshGridViewAdapterListenerInvoker : global::Java.Lang.Object, IRefreshGridViewAdapterListener {

			static IntPtr java_class_ref = JNIEnv.FindClass ("com/inscripts/mapping/RecentlyUsedEmoji$RefreshGridViewAdapterListener");

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
								JNIEnv.GetClassNameFromInstance (handle), "com.inscripts.mapping.RecentlyUsedEmoji.RefreshGridViewAdapterListener"));
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

			static Delegate cb_onNewEmojiUsed;
#pragma warning disable 0169
			static Delegate GetOnNewEmojiUsedHandler ()
			{
				if (cb_onNewEmojiUsed == null)
					cb_onNewEmojiUsed = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnNewEmojiUsed);
				return cb_onNewEmojiUsed;
			}

			static void n_OnNewEmojiUsed (IntPtr jnienv, IntPtr native__this)
			{
				global::Com.Inscripts.Mapping.RecentlyUsedEmoji.IRefreshGridViewAdapterListener __this = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Mapping.RecentlyUsedEmoji.IRefreshGridViewAdapterListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				__this.OnNewEmojiUsed ();
			}
#pragma warning restore 0169

			IntPtr id_onNewEmojiUsed;
			public unsafe void OnNewEmojiUsed ()
			{
				if (id_onNewEmojiUsed == IntPtr.Zero)
					id_onNewEmojiUsed = JNIEnv.GetMethodID (class_ref, "onNewEmojiUsed", "()V");
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onNewEmojiUsed);
			}

		}

		[global::Android.Runtime.Register ("mono/com/inscripts/mapping/RecentlyUsedEmoji_RefreshGridViewAdapterListenerImplementor")]
		internal sealed partial class IRefreshGridViewAdapterListenerImplementor : global::Java.Lang.Object, IRefreshGridViewAdapterListener {

			object sender;

			public IRefreshGridViewAdapterListenerImplementor (object sender)
				: base (
					global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/inscripts/mapping/RecentlyUsedEmoji_RefreshGridViewAdapterListenerImplementor", "()V"),
					JniHandleOwnership.TransferLocalRef)
			{
				global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
				this.sender = sender;
			}

#pragma warning disable 0649
			public EventHandler Handler;
#pragma warning restore 0649

			public void OnNewEmojiUsed ()
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
				return JNIEnv.FindClass ("com/inscripts/mapping/RecentlyUsedEmoji", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (RecentlyUsedEmoji); }
		}

		protected RecentlyUsedEmoji (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedEmoji']/constructor[@name='RecentlyUsedEmoji' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe RecentlyUsedEmoji ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (RecentlyUsedEmoji)) {
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

		static IntPtr id_addEmoji_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedEmoji_RefreshGridViewAdapterListener_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.mapping']/class[@name='RecentlyUsedEmoji']/method[@name='addEmoji' and count(parameter)=3 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.Integer'] and parameter[3][@type='com.inscripts.mapping.RecentlyUsedEmoji.RefreshGridViewAdapterListener']]"
		[Register ("addEmoji", "(Ljava/lang/String;Ljava/lang/Integer;Lcom/inscripts/mapping/RecentlyUsedEmoji$RefreshGridViewAdapterListener;)V", "")]
		public static unsafe void AddEmoji (string p0, global::Java.Lang.Integer p1, global::Com.Inscripts.Mapping.RecentlyUsedEmoji.IRefreshGridViewAdapterListener p2)
		{
			if (id_addEmoji_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedEmoji_RefreshGridViewAdapterListener_ == IntPtr.Zero)
				id_addEmoji_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedEmoji_RefreshGridViewAdapterListener_ = JNIEnv.GetStaticMethodID (class_ref, "addEmoji", "(Ljava/lang/String;Ljava/lang/Integer;Lcom/inscripts/mapping/RecentlyUsedEmoji$RefreshGridViewAdapterListener;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_addEmoji_Ljava_lang_String_Ljava_lang_Integer_Lcom_inscripts_mapping_RecentlyUsedEmoji_RefreshGridViewAdapterListener_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
