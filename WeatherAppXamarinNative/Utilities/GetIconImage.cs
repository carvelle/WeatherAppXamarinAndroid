using System;
namespace WeatherAppXamarinNative
{
	public class GetIconImage
	{

		public static int GetImage(string iconCode, int conditionId)
		{
			switch (iconCode)
			{
				case "01d":
					return Resource.Drawable.d01;
				case "01n":
					return Resource.Drawable.n01;
				case "02n":
					return Resource.Drawable.n02;
				case "02d":
					return Resource.Drawable.d02;
				case "03d":
					return Resource.Drawable.dn03;
				case "03n":
					return Resource.Drawable.dn03;
				case "04d":
					return Resource.Drawable.dn03;
				case "04n":
					return Resource.Drawable.dn03;
				case "09d":
					return Resource.Drawable.dn09;
				case "09n":
					return Resource.Drawable.dn09;
				case "10d":
					return Resource.Drawable.dn09;
				case "10n":
					return Resource.Drawable.dn09;
				case "11d":
					return Resource.Drawable.dn11;
				case "11n":
					return Resource.Drawable.dn11;
				case "50d":
					return Resource.Drawable.dn50;
				case "50n":
					return Resource.Drawable.dn50;
				default:
					int weatherIcon = GetImageByWeatherConditionId(conditionId);
					return weatherIcon;
			}
		}

		public static int GetImageByWeatherConditionId(int conditionId)
		{
			switch (conditionId)
			{
				case 900:
					return Resource.Drawable.hurricane;
				case 901:
					return Resource.Drawable.hurricane;
				case 902:
					return Resource.Drawable.hurricane;
				case 903:
					return Resource.Drawable.verycold;
				case 904:
					return Resource.Drawable.veryhot;
				case 905:
					return Resource.Drawable.windy;
				case 906:
					return Resource.Drawable.sleet;
				default:
					return (int)01d;
			}
		}
	}
}
