using System.Threading.Tasks;
using Android.Graphics;
using WeatherAppXamarinNative.Models;

namespace WeatherAppXamarinNative.Interfaces
{
	public interface IDataProvider
	{
		Task<CurrentWeatherModel> GetCurrentWeather(PointF latlng);
		Task<ExtendedForecastModel> GetFiveDayWeather(PointF latlng);
	}
}
