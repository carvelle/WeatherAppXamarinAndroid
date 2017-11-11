using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ExtendedForecastModel
	{
        [JsonProperty("cnt")]
		public int count { get; set; }

		[JsonProperty("list")]
		public List<WeatherConditionModel> weatherCollection { get; set; }
	}
}
