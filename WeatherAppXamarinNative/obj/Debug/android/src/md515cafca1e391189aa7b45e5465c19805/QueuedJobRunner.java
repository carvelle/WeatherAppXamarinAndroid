package md515cafca1e391189aa7b45e5465c19805;


public class QueuedJobRunner
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
		mono.android.Runtime.register ("WeatherAppXamarinNative.QueuedJobRunner, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", QueuedJobRunner.class, __md_methods);
	}


	public QueuedJobRunner () throws java.lang.Throwable
	{
		super ();
		if (getClass () == QueuedJobRunner.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.QueuedJobRunner, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public QueuedJobRunner (mono.java.lang.Runnable p0, android.os.Handler p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == QueuedJobRunner.class)
			mono.android.TypeManager.Activate ("WeatherAppXamarinNative.QueuedJobRunner, WeatherAppXamarinNative, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.Runnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.OS.Handler, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
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
