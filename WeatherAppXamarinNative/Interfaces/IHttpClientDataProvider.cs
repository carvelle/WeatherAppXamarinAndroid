using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAppXamarinNative.Interfaces
{
	public interface IHttpClientDataProvider
	{
		Task<WebResponse> RequestAsync(string requestUri, HttpMethod method);
	}
}
