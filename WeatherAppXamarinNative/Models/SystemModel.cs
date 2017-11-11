using System;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative
{

	[JsonObject(MemberSerialization.OptIn)]
	public class SystemModel
	{
		[JsonProperty("type")]
		public double Type { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("message")]
		public double Message { get; set; }

		[JsonProperty("country")]
		public string CountryCode { get; set; }

		[JsonProperty("sunrise")]
		public double Sunrise { get; set; }

		[JsonProperty("sunset")]
		public double Sunset { get; set; }	
	}
}
