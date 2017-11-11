using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;

namespace WeatherAppXamarinNative
{
	public class BitmapHelper
	{
		Context context;

		public BitmapHelper(Context context)
		{
			this.context = context;
		}

		public static Bitmap decodeBitmapFromResource(Resources res, int resId, int reqWidth, int reqHeight)
		{
			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InJustDecodeBounds = true;
			BitmapFactory.DecodeResource(res, resId, options);
			options.InSampleSize = calculateInSampleSize(options, reqWidth, reqHeight);
			options.InJustDecodeBounds = false;
			return BitmapFactory.DecodeResource(res, resId, options);
		}

		public static int calculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
		{

			int height = options.OutHeight;
			int width = options.OutWidth;
			int inSampleSize = 1;

			if (height > reqHeight || width > reqWidth)
			{

				int halfHeight = height / 2;
				int halfWidth = width / 2;

				while ((halfHeight / inSampleSize) >= reqHeight
						&& (halfWidth / inSampleSize) >= reqWidth)
				{
					inSampleSize *= 2;
				}
			}
			return inSampleSize;
		}
	}
}
