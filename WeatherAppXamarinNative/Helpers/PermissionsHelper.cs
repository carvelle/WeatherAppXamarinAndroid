using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace WeatherAppXamarinNative
{
	public class PermissionsHelper
	{
		public bool IsPermissionGranted { get; set; }
		public bool IsGeoLocatorEnabled { get; set; }

		public async Task<bool> RequestLocationPermission()
		{
			try
			{
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
				if (status != PermissionStatus.Granted)
				{
					IsPermissionGranted = false;
					var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
					status = results[Permission.Location];
				}

				if (status == PermissionStatus.Granted)
				{
					IsPermissionGranted = true;
					IsGeoLocatorEnabled = CrossGeolocator.Current.IsGeolocationEnabled;
					var results = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(10000));
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);

			}
			return IsPermissionGranted;
		}

		public async Task<bool> RequestPermission(Permission perm)
		{
			try
			{
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync(perm);
				if (status != PermissionStatus.Granted)
				{
					IsPermissionGranted = false;
					var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { perm });
					status = results[Permission.Location];
				}

				if (status == PermissionStatus.Granted)
				{
					IsPermissionGranted = true;
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return IsPermissionGranted;
		}

	}
}
