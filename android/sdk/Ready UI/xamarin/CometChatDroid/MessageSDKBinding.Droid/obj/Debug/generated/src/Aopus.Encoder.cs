using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Aopus {

	// Metadata.xml XPath class reference: path="/api/package[@name='aopus']/class[@name='Encoder']"
	[global::Android.Runtime.Register ("aopus/Encoder", DoNotGenerateAcw=true)]
	public partial class Encoder : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("aopus/Encoder", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Encoder); }
		}

		protected Encoder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_III;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='aopus']/class[@name='Encoder']/constructor[@name='Encoder' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register (".ctor", "(III)V", "")]
		public unsafe Encoder (int p0, int p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (GetType () != typeof (Encoder)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(III)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(III)V", __args);
					return;
				}

				if (id_ctor_III == IntPtr.Zero)
					id_ctor_III = JNIEnv.GetMethodID (class_ref, "<init>", "(III)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_III, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_III, __args);
			} finally {
			}
		}

		static Delegate cb_getBitrate;
#pragma warning disable 0169
		static Delegate GetGetBitrateHandler ()
		{
			if (cb_getBitrate == null)
				cb_getBitrate = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetBitrate);
			return cb_getBitrate;
		}

		static int n_GetBitrate (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Bitrate;
		}
#pragma warning restore 0169

		static Delegate cb_setBitrate_I;
#pragma warning disable 0169
		static Delegate GetSetBitrate_IHandler ()
		{
			if (cb_setBitrate_I == null)
				cb_setBitrate_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetBitrate_I);
			return cb_setBitrate_I;
		}

		static void n_SetBitrate_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Bitrate = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getBitrate;
		static IntPtr id_setBitrate_I;
		public virtual unsafe int Bitrate {
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='getBitrate' and count(parameter)=0]"
			[Register ("getBitrate", "()I", "GetGetBitrateHandler")]
			get {
				if (id_getBitrate == IntPtr.Zero)
					id_getBitrate = JNIEnv.GetMethodID (class_ref, "getBitrate", "()I");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBitrate);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getBitrate", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='setBitrate' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setBitrate", "(I)V", "GetSetBitrate_IHandler")]
			set {
				if (id_setBitrate_I == IntPtr.Zero)
					id_setBitrate_I = JNIEnv.GetMethodID (class_ref, "setBitrate", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setBitrate_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBitrate", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getQuality;
#pragma warning disable 0169
		static Delegate GetGetQualityHandler ()
		{
			if (cb_getQuality == null)
				cb_getQuality = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, double>) n_GetQuality);
			return cb_getQuality;
		}

		static double n_GetQuality (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.Quality;
		}
#pragma warning restore 0169

		static Delegate cb_setQuality_D;
#pragma warning disable 0169
		static Delegate GetSetQuality_DHandler ()
		{
			if (cb_setQuality_D == null)
				cb_setQuality_D = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, double>) n_SetQuality_D);
			return cb_setQuality_D;
		}

		static void n_SetQuality_D (IntPtr jnienv, IntPtr native__this, double p0)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Quality = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getQuality;
		static IntPtr id_setQuality_D;
		public virtual unsafe double Quality {
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='getQuality' and count(parameter)=0]"
			[Register ("getQuality", "()D", "GetGetQualityHandler")]
			get {
				if (id_getQuality == IntPtr.Zero)
					id_getQuality = JNIEnv.GetMethodID (class_ref, "getQuality", "()D");
				try {

					if (GetType () == ThresholdType)
						return JNIEnv.CallDoubleMethod (((global::Java.Lang.Object) this).Handle, id_getQuality);
					else
						return JNIEnv.CallNonvirtualDoubleMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getQuality", "()D"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='setQuality' and count(parameter)=1 and parameter[1][@type='double']]"
			[Register ("setQuality", "(D)V", "GetSetQuality_DHandler")]
			set {
				if (id_setQuality_D == IntPtr.Zero)
					id_setQuality_D = JNIEnv.GetMethodID (class_ref, "setQuality", "(D)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setQuality_D, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setQuality", "(D)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_activateFEC_I;
#pragma warning disable 0169
		static Delegate GetActivateFEC_IHandler ()
		{
			if (cb_activateFEC_I == null)
				cb_activateFEC_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_ActivateFEC_I);
			return cb_activateFEC_I;
		}

		static void n_ActivateFEC_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ActivateFEC (p0);
		}
#pragma warning restore 0169

		static IntPtr id_activateFEC_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='activateFEC' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("activateFEC", "(I)V", "GetActivateFEC_IHandler")]
		public virtual unsafe void ActivateFEC (int p0)
		{
			if (id_activateFEC_I == IntPtr.Zero)
				id_activateFEC_I = JNIEnv.GetMethodID (class_ref, "activateFEC", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_activateFEC_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "activateFEC", "(I)V"), __args);
			} finally {
			}
		}

		static Delegate cb_deactivateFEC;
#pragma warning disable 0169
		static Delegate GetDeactivateFECHandler ()
		{
			if (cb_deactivateFEC == null)
				cb_deactivateFEC = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_DeactivateFEC);
			return cb_deactivateFEC;
		}

		static void n_DeactivateFEC (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.DeactivateFEC ();
		}
#pragma warning restore 0169

		static IntPtr id_deactivateFEC;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='deactivateFEC' and count(parameter)=0]"
		[Register ("deactivateFEC", "()V", "GetDeactivateFECHandler")]
		public virtual unsafe void DeactivateFEC ()
		{
			if (id_deactivateFEC == IntPtr.Zero)
				id_deactivateFEC = JNIEnv.GetMethodID (class_ref, "deactivateFEC", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_deactivateFEC);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "deactivateFEC", "()V"));
			} finally {
			}
		}

		static Delegate cb_destroy;
#pragma warning disable 0169
		static Delegate GetDestroyHandler ()
		{
			if (cb_destroy == null)
				cb_destroy = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Destroy);
			return cb_destroy;
		}

		static void n_Destroy (IntPtr jnienv, IntPtr native__this)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Destroy ();
		}
#pragma warning restore 0169

		static IntPtr id_destroy;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='destroy' and count(parameter)=0]"
		[Register ("destroy", "()V", "GetDestroyHandler")]
		public virtual unsafe void Destroy ()
		{
			if (id_destroy == IntPtr.Zero)
				id_destroy = JNIEnv.GetMethodID (class_ref, "destroy", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_destroy);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "destroy", "()V"));
			} finally {
			}
		}

		static Delegate cb_encode_arrayBII;
#pragma warning disable 0169
		static Delegate GetEncode_arrayBIIHandler ()
		{
			if (cb_encode_arrayBII == null)
				cb_encode_arrayBII = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, int, IntPtr>) n_Encode_arrayBII);
			return cb_encode_arrayBII;
		}

		static IntPtr n_Encode_arrayBII (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2)
		{
			global::Aopus.Encoder __this = global::Java.Lang.Object.GetObject<global::Aopus.Encoder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] p0 = (byte[]) JNIEnv.GetArray (native_p0, JniHandleOwnership.DoNotTransfer, typeof (byte));
			IntPtr __ret = JNIEnv.NewArray (__this.Encode (p0, p1, p2));
			if (p0 != null)
				JNIEnv.CopyArray (p0, native_p0);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_encode_arrayBII;
		// Metadata.xml XPath method reference: path="/api/package[@name='aopus']/class[@name='Encoder']/method[@name='encode' and count(parameter)=3 and parameter[1][@type='byte[]'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("encode", "([BII)[B", "GetEncode_arrayBIIHandler")]
		public virtual unsafe byte[] Encode (byte[] p0, int p1, int p2)
		{
			if (id_encode_arrayBII == IntPtr.Zero)
				id_encode_arrayBII = JNIEnv.GetMethodID (class_ref, "encode", "([BII)[B");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);

				byte[] __ret;
				if (GetType () == ThresholdType)
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_encode_arrayBII, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				else
					__ret = (byte[]) JNIEnv.GetArray (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "encode", "([BII)[B"), __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

	}
}
