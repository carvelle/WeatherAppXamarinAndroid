using System;
using Android.OS;
using Java.Lang;
using Java.Util;

namespace WeatherAppXamarinNative
{
	public class CronJobRunner
	{
		Handler handler;
		public CronJobRunner(Handler handler)
		{
			this.handler = handler;
		}

		public void QueueJob(int seconds, Runnable mRunnable)
		{
			Timer timer = new Timer();
			timer.ScheduleAtFixedRate(new QueuedJobRunner(mRunnable, handler), 0, seconds * 1000);
		}
	}

	public class QueuedJobRunner : TimerTask
	{
		Runnable mRunnable;
		Handler handler;
		public QueuedJobRunner(Runnable mRunnable, Handler handler)
		{
			this.handler = handler;
            this.mRunnable = mRunnable;
		}
		public override void Run()
		{
			handler.Post(mRunnable);
		}
	}
}
