using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Inscripts.Enums {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']"
	[global::Android.Runtime.Register ("com/inscripts/enums/ChatroomType", DoNotGenerateAcw=true)]
	public sealed partial class ChatroomType : global::Java.Lang.Enum {


		static IntPtr INVITE_ONLY_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']/field[@name='INVITE_ONLY']"
		[Register ("INVITE_ONLY")]
		public static global::Com.Inscripts.Enums.ChatroomType InviteOnly {
			get {
				if (INVITE_ONLY_jfieldId == IntPtr.Zero)
					INVITE_ONLY_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "INVITE_ONLY", "Lcom/inscripts/enums/ChatroomType;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, INVITE_ONLY_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.ChatroomType> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr PASSWORD_PROTECTED_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']/field[@name='PASSWORD_PROTECTED']"
		[Register ("PASSWORD_PROTECTED")]
		public static global::Com.Inscripts.Enums.ChatroomType PasswordProtected {
			get {
				if (PASSWORD_PROTECTED_jfieldId == IntPtr.Zero)
					PASSWORD_PROTECTED_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "PASSWORD_PROTECTED", "Lcom/inscripts/enums/ChatroomType;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, PASSWORD_PROTECTED_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.ChatroomType> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}

		static IntPtr PUBLIC_CHATROOM_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']/field[@name='PUBLIC_CHATROOM']"
		[Register ("PUBLIC_CHATROOM")]
		public static global::Com.Inscripts.Enums.ChatroomType PublicChatroom {
			get {
				if (PUBLIC_CHATROOM_jfieldId == IntPtr.Zero)
					PUBLIC_CHATROOM_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "PUBLIC_CHATROOM", "Lcom/inscripts/enums/ChatroomType;");
				IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, PUBLIC_CHATROOM_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.ChatroomType> (__ret, JniHandleOwnership.TransferLocalRef);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/inscripts/enums/ChatroomType", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (ChatroomType); }
		}

		internal ChatroomType (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_valueOf_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("valueOf", "(Ljava/lang/String;)Lcom/inscripts/enums/ChatroomType;", "")]
		public static unsafe global::Com.Inscripts.Enums.ChatroomType ValueOf (string p0)
		{
			if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
				id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/inscripts/enums/ChatroomType;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				global::Com.Inscripts.Enums.ChatroomType __ret = global::Java.Lang.Object.GetObject<global::Com.Inscripts.Enums.ChatroomType> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_values;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.inscripts.enums']/class[@name='ChatroomType']/method[@name='values' and count(parameter)=0]"
		[Register ("values", "()[Lcom/inscripts/enums/ChatroomType;", "")]
		public static unsafe global::Com.Inscripts.Enums.ChatroomType[] Values ()
		{
			if (id_values == IntPtr.Zero)
				id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/inscripts/enums/ChatroomType;");
			try {
				return (global::Com.Inscripts.Enums.ChatroomType[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Inscripts.Enums.ChatroomType));
			} finally {
			}
		}

	}
}
