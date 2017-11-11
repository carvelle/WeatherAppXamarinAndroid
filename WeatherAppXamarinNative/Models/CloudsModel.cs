using System;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class CloudsModel
	{
		[JsonProperty("all")]
		public double All { get; set; }	
	}
}
