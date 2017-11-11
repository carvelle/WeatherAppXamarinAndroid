using System;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ExtendedWeatherModel
	{
        [JsonProperty("temp")]

		public double mainTemp { get; set; }

		[JsonProperty("temp_min")]
		public double minTemp { get; set; }

		[JsonProperty("temp_max")]
		public double maxTemp { get; set; }

		[JsonProperty("pressure")]
		public double pressure { get; set; }

		[JsonProperty("sea_level")]
		public double seaLevel { get; set; }

		[JsonProperty("grnd_level")]
		public double groundLevel { get; set; }

		[JsonProperty("humidity")]
		public double humidity { get; set; }

		[JsonProperty("temp_kf")]
		public double tempKf { get; set; }

	}
}
