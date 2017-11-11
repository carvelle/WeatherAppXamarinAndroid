using System;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative
{
	[JsonObject(MemberSerialization.OptIn)]
	public class WindModel
	{
		[JsonProperty("speed")]
		public double Speed { get; set; }

		[JsonProperty("deg")]
		public double Bearing { get; set; }
	}
}
