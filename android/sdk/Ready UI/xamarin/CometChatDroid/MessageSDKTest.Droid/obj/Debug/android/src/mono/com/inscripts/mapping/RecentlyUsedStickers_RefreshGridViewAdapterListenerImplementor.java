package mono.com.inscripts.mapping;


public class RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.inscripts.mapping.RecentlyUsedStickers.RefreshGridViewAdapterListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onNewStickerUsed:()V:GetOnNewStickerUsedHandler:Com.Inscripts.Mapping.RecentlyUsedStickers/IRefreshGridViewAdapterListenerInvoker, MessageSDKBinding.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Inscripts.Mapping.RecentlyUsedStickers+IRefreshGridViewAdapterListenerImplementor, MessageSDKBinding.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor.class, __md_methods);
	}


	public RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RecentlyUsedStickers_RefreshGridViewAdapterListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Inscripts.Mapping.RecentlyUsedStickers+IRefreshGridViewAdapterListenerImplementor, MessageSDKBinding.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onNewStickerUsed ()
	{
		n_onNewStickerUsed ();
	}

	private native void n_onNewStickerUsed ();

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
