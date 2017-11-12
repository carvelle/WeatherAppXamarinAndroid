using Android.Net;

namespace WeatherAppXamarinNative.Helpers
{
	public class CheckNetworkConnectivity
	{
		ConnectivityManager connectivityManager;
		NetworkInfo networkInfo;
		public CheckNetworkConnectivity(ConnectivityManager connectivityManager)
		{
			this.connectivityManager = connectivityManager;
			networkInfo = connectivityManager.ActiveNetworkInfo;
		}

		public bool IsNetworkConnected()
		{
			if (networkInfo == null)
				return false;
			
			bool isOnline = networkInfo.IsConnected;

			return isOnline;
		}

		public bool IsWifiConnected()
		{
			if (networkInfo == null)
			return false;
			
			bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
			return isWifi;
		}

		public bool IsPhoneOnline()
		{
			return IsNetworkConnected() || IsWifiConnected();
		}


	}
}
