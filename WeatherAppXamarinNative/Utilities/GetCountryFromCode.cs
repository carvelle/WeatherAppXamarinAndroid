using System;
using Java.Util;

namespace WeatherAppXamarinNative
{
	public class GetCountryFromCode
	{
		public static string getCountry(string countryCode)
		{
			if (!string.IsNullOrWhiteSpace(countryCode))
			{
				Locale loc = new Locale("", countryCode);
				return loc.GetDisplayCountry(loc);
			}
			return "Kazakstan";
		}
	}
}
