namespace WeatherAppXamarinNative.Utilities
{
	public class PixelUtils
	{
		public static float ConvertDpToPixels(float dp)
		{
			var context = Xamarin.Forms.Forms.Context;
			float pixWidth = (float)context.Resources.DisplayMetrics.WidthPixels;
			float fdpWidth = (float)Android.Content.Res.Resources.System.DisplayMetrics.WidthPixels;
			float pixPerDp = pixWidth / fdpWidth;
			return (int)(dp * pixPerDp + 0.5f);
		}


		public static float ConvertPixelsToDp(float pixels)
		{
			var context = Xamarin.Forms.Forms.Context;
			var dp = (int)((pixels) / context.Resources.DisplayMetrics.Density);
			return dp;
		}
	}
}
