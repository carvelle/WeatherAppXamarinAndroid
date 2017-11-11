using System;
using Android.Content;
using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using Java.Util;

namespace WeatherAppXamarinNative
{
	public class BackgroundImageChanger
	{
		Timer timer;
		Handler handler;
		Context context;
		ViewPager slideShow;

		public BackgroundImageChanger(Handler handler, Context context, ViewPager slideShow)
		{
			this.handler = handler;
			this.context = context;
			this.slideShow = slideShow;
		}

		public void pageSwitcher(int seconds)
		{
			timer = new Timer();
			timer.ScheduleAtFixedRate(new SwitchBackground(handler, slideShow), 0, seconds* 1000);
			TranslationPageTransformer pageTransformer = new TranslationPageTransformer(slideShow);
			slideShow.SetPageTransformer(true, pageTransformer);
	    }
	}

	public class TranslationPageTransformer : Java.Lang.Object, ViewPager.IPageTransformer
	{
		ViewPager mPager;
		public TranslationPageTransformer(ViewPager pager)
		{
			this.mPager = pager;
		}
		public void TransformPage(View view, float position)
		{
			view.TranslationX = view.Width * -position;
			if (position <= -1.0F || position >= 1.0F)
			{
				view.Alpha = 0.0F;
			}
			else if (position == 0.0F)
			{
				view.Alpha = 1.0F;
			}
			else
			{
				view.Alpha = 1.0F - Math.Abs(position);
			}
		}
	 }

	public class SwitchBackground : TimerTask
	{
		Handler handler;
		ViewPager slideShow;
		public SwitchBackground(Handler handler, ViewPager slideShow)
		{
			this.handler = handler;
			this.slideShow = slideShow;
		}
		public override void Run()
		{
			handler.Post(() =>
			{
				var rand = new Java.Util.Random();
				int randomImage = rand.NextInt(BackgroundImageSource.mResources.Length);
				slideShow.CurrentItem = randomImage;
			});
		}
	}
}
