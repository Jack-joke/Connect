package mono.com.inscripts.interfaces;


public class OnAlertDialogButtonClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.inscripts.interfaces.OnAlertDialogButtonClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onButtonClick:(Landroid/app/AlertDialog;Landroid/view/View;II)V:GetOnButtonClick_Landroid_app_AlertDialog_Landroid_view_View_IIHandler:Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListenerInvoker, MessageSDKBinding.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListenerImplementor, MessageSDKBinding.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OnAlertDialogButtonClickListenerImplementor.class, __md_methods);
	}


	public OnAlertDialogButtonClickListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OnAlertDialogButtonClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Inscripts.Interfaces.IOnAlertDialogButtonClickListenerImplementor, MessageSDKBinding.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onButtonClick (android.app.AlertDialog p0, android.view.View p1, int p2, int p3)
	{
		n_onButtonClick (p0, p1, p2, p3);
	}

	private native void n_onButtonClick (android.app.AlertDialog p0, android.view.View p1, int p2, int p3);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
