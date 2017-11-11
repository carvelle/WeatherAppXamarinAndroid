using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace WeatherAppXamarinNative
{
	public static class LocationHelper
	{
		public static async Task<Position> GetLocation()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;
				var position = await locator.GetPositionAsync(timeout: new TimeSpan(10000));
				return position;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
				Position defaultLocation = new Position();
				defaultLocation.Latitude = -26.0000;
				defaultLocation.Longitude = 27.0000;
				return defaultLocation;
			}
		}	
	}
}
