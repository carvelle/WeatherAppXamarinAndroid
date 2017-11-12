using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAppXamarinNative.Interfaces;

namespace WeatherAppXamarinNative.Network
{
	public class BaseConnectivityManager
	{
		protected IHttpClientDataProvider HttpClientDataProvider;

		public BaseConnectivityManager()
		{
			HttpClientDataProvider = new HttpClientWrapper();
		}

		protected async Task<TResult> WrapHttpCall<TResult>(string url, HttpMethod method)
		{
			using (WebResponse response = await HttpClientDataProvider.RequestAsync(url, method))
			{
				using (Stream stream = response.GetResponseStream())
				{
					try
					{
						var data = await SerializerHelper.DeserializeFromStream(stream);
						return HandleResponseSuccessful<TResult>(data);
					}
					catch (Exception e)
					{
						Debug.WriteLine(e.StackTrace);
						return default(TResult);
					}
				}
			}
		}

		private TResult HandleResponseSuccessful<TResult>(object responseMessage)
		{
			var response = JsonConvert.SerializeObject(responseMessage);
			try
			{
				var json = JsonConvert.DeserializeObject<TResult>(response);
				return json;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
			return default(TResult);
		}

	}
}
