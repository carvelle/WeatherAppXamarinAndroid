using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAppXamarinNative.Interfaces;
using WeatherAppXamarinNative.Urls;
using WeatherAppXamarinNative.Models;
using WeatherAppXamarinNative.Extensions;
using Android.Graphics;

namespace WeatherAppXamarinNative
{
	public class DataProvider : BaseConnectivityManager, IDataProvider
	{
		public async Task<CurrentWeatherModel> GetCurrentWeather(PointF latlng)
		{
			if (latlng == null)
				return null;
			
			string latitude = latlng.X.ToString();
			string longitude = latlng.Y.ToString();
			string weatherUrl = UrlConfig.CurrentWeatherUrl.AppendCoordinates(latitude, longitude, Constants.APPID);
			return await WrapHttpCall<CurrentWeatherModel>(weatherUrl, HttpMethod.Get);
		}

		public async Task<ExtendedForecastModel> GetFiveDayWeather(PointF latlng)
		{
			if (latlng == null)
				return null;
			
			string latitude = latlng.X.ToString();
			string longitude = latlng.Y.ToString();
			string ExtendedWeatherUrl = UrlConfig.ExtendedForecastUrl.AppendCoordinates(latitude, longitude, Constants.APPID);
			return await WrapHttpCall<ExtendedForecastModel>(ExtendedWeatherUrl, HttpMethod.Get);
		}

	}
}
