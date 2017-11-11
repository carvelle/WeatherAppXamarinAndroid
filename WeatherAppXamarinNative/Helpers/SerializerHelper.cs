using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppXamarinNative
{
	public static class SerializerHelper
	{

		public static async Task<object> DeserializeFromStream(Stream stream)
		{
			var serializer = new JsonSerializer();

			using (var sr = new StreamReader(stream))
			using (var jsonTextReader = new JsonTextReader(sr))
			{
				return await new TaskFactory().StartNew(() => serializer.Deserialize(jsonTextReader));
			}
		}	
	}
}
