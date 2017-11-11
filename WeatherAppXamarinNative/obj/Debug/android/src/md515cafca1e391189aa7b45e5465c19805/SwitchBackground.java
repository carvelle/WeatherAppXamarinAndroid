package md515cafca1e391189aa7b45e5465c19805;


public class SwitchBackground
	extends java.util.TimerTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_run:()V:GetRunHandler\n" +
			"";
		mono.android.Runtime.register ("WeatherAppXamarinNative.SwitchBackground, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SwitchBackground.class, __md_methods);
	}


	public SwitchBackground () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SwitchBackground.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.SwitchBackground, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public SwitchBackground (android.os.Handler p0, android.support.v4.view.ViewPager p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == SwitchBackground.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.SwitchBackground, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Handler, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Support.V4.View.ViewPager, Xamarin.Android.Support.Core.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public void run ()
	{
		n_run ();
	}

	private native void n_run ();

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
