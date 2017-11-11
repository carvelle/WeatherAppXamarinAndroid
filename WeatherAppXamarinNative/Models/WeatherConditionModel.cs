using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class WeatherConditionModel
	{
       [JsonProperty("dt")]
		public long unixTimestamp  { get; set; }


		[JsonProperty("main")]
		public ExtendedWeatherModel weatherCondition  { get; set; }


		[JsonProperty("weather")]
		public List<WeatherModel> weather { get; set; }


		[JsonProperty("clouds")]
		public CloudsModel clouds { get; set; }


		[JsonProperty("wind")]
		public WindModel wind { get; set; }


		[JsonProperty("dt_txt")]
		public string dateTime { get; set; }

	}
}
