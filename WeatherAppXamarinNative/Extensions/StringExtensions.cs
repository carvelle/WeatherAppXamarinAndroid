using System;
namespace WeatherAppXamarinNative.Extensions
{
	public static class StringExtensions
	{
		public static string AppendCoordinates(this string url, string lat, string lon, string appid)
		{
			return string.Format("{0}&lat={1}&lon={2}&appid={3}", url, lat, lon, appid);
		}	
	}
}
