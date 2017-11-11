package md515cafca1e391189aa7b45e5465c19805;


public class TranslationPageTransformer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.PageTransformer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_transformPage:(Landroid/view/View;F)V:GetTransformPage_Landroid_view_View_FHandler:Android.Support.V4.View.ViewPager/IPageTransformerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"";
		mono.android.Runtime.register ("WeatherAppXamarinNative.TranslationPageTransformer, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TranslationPageTransformer.class, __md_methods);
	}


	public TranslationPageTransformer () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TranslationPageTransformer.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.TranslationPageTransformer, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public TranslationPageTransformer (android.support.v4.view.ViewPager p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == TranslationPageTransformer.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.TranslationPageTransformer, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.View.ViewPager, Xamarin.Android.Support.Core.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void transformPage (android.view.View p0, float p1)
	{
		n_transformPage (p0, p1);
	}

	private native void n_transformPage (android.view.View p0, float p1);

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
