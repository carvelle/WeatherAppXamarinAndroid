using System;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative.Model
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TemperaturePressureModel
	{
		[JsonProperty("temp")]
		public double Temperature { get; set; }

		[JsonProperty("pressure")]
		public double Pressure { get; set; }

		[JsonProperty("humidity")]
		public double Humidity { get; set; }

		[JsonProperty("temp_min")]
		public double TempMin { get; set; }

		[JsonProperty("temp_max")]
		public double TempMax { get; set; }	
	}
}
