using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherAppXamarinNative.Model;

namespace WeatherAppXamarinNative.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class CurrentWeatherModel
	{
		[JsonProperty("coord")]
		public CoordinatesModel Coordinates { get; set; }

		[JsonProperty("weather")]
		public List<WeatherModel> Weather { get; set; }

		[JsonProperty("base")]
		public string Base { get; set; }

		[JsonProperty("main")]
		public TemperaturePressureModel TempPressure { get; set; }

		[JsonProperty("wind")]
		public WindModel Wind { get; set; }

		[JsonProperty("dt")]
		public long Timestamp { get; set; }

		[JsonProperty("sys")]
		public SystemModel System { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string CityName { get; set; }

		[JsonProperty("cod")]
		public int StatusCode { get; set; }	
	}
}
