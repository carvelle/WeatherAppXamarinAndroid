using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Graphics;
using System.Threading.Tasks;
using WeatherAppXamarinNative.Models;
using System.Collections.Generic;
using Plugin.Geolocator.Abstractions;
using Java.Lang;
using WeatherAppXamarinNative.Extensions;
using Android.Net;
using WeatherAppXamarinNative.Helpers;
using System.Net;
using System;

namespace WeatherAppXamarinNative
{
	[Activity(Label = "Weather App", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		string maxLabel;
		string minLabel;
		ViewPager mViewPager;
		SlideshowAdapter slideshowAdapter;
		TextView dateLabel, mainTempLabel, areaLabel, maxTempLabel, minTempLabel, lastUpdated,
		extMaxTempRow1, extMinTempRow1, dayRow1, errorMessage,
		extMaxTempRow2, extMinTempRow2, dayRow2;
		ImageView weatherIcon, iconImageRow1, iconImageRow2;
		double? lat = -30.0000;
		double? lng = 30.000;
		DataProvider ServiceCall;
		private LinearLayout spinner, content, errorDialog;
		public Runnable currentWeatherRunnable;
		public Runnable extendedWeatherRunnable;
		ConnectivityManager connectivityManager;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.dashboard_layout);
			dateLabel = FindViewById<TextView>(Resource.Id.date_label);
			mainTempLabel = FindViewById<TextView>(Resource.Id.main_temp);
			areaLabel = FindViewById<TextView>(Resource.Id.area_label);
			maxTempLabel = FindViewById<TextView>(Resource.Id.max_temp);
			minTempLabel = FindViewById<TextView>(Resource.Id.min_temp);
			lastUpdated = FindViewById<TextView>(Resource.Id.last_updated);
			weatherIcon = FindViewById<ImageView>(Resource.Id.icon_image);
			mViewPager = FindViewById<ViewPager>(Resource.Id.pager);
			//Extended Weather
			extMaxTempRow1 =FindViewById<TextView>(Resource.Id.ext_max_temp_row1);
			extMinTempRow1 = FindViewById<TextView>(Resource.Id.ext_min_temp_row1);
			dayRow1 = FindViewById<TextView>(Resource.Id.day_label_row1);
			iconImageRow1 =  FindViewById<ImageView>(Resource.Id.ext_icon_image_row1);
			extMaxTempRow2 =FindViewById<TextView>(Resource.Id.ext_max_temp_row2); 
			extMinTempRow2 = FindViewById<TextView>(Resource.Id.ext_min_temp_row2);
			dayRow2 = FindViewById<TextView>(Resource.Id.day_label_row2);
			iconImageRow2 =  FindViewById<ImageView>(Resource.Id.ext_icon_image_row2);
			errorMessage = FindViewById<TextView>(Resource.Id.error_message);
			spinner = FindViewById<LinearLayout>(Resource.Id.progressBar);
			content = FindViewById<LinearLayout>(Resource.Id.main_content);
			errorDialog = FindViewById<LinearLayout>(Resource.Id.error_dialog);
			content.Visibility = Android.Views.ViewStates.Visible;
			errorDialog.Visibility = Android.Views.ViewStates.Gone;
			slideshowAdapter = new SlideshowAdapter(this);
			mViewPager.Adapter = slideshowAdapter;
			maxLabel = this.Resources.GetString(Resource.String.max_string);
			minLabel = this.Resources.GetString(Resource.String.min_string);
			ServiceCall = new DataProvider();
			Handler handler = new Handler();
			connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
			manageBackgroundImages(handler);
			await GetLocation();
			await LoadWeatherData();
			await LoadExtendedWeatherData();
			currentWeatherRunnable = new Runnable(async () => { await LoadWeatherData();});
			extendedWeatherRunnable = new Runnable(async () => { await LoadExtendedWeatherData();});
			QueueCronJobs(handler);

		}

		public async Task LoadWeatherData()
		{
			errorDialog.Visibility = Android.Views.ViewStates.Gone;
			CheckNetworkConnectivity connectivity = new CheckNetworkConnectivity(connectivityManager);
			await GetLocation();
			if (connectivity.IsPhoneOnline())
			{
				PointF latlng = new PointF((float)lat, (float)lng);
				try
				{
					var weatherdata = await ServiceCall.GetCurrentWeather(latlng);
					if (weatherdata != null)
					{
						setLabelValues(weatherdata);
					}
				}
				catch (WebException w)
				{
					HandleNetworkFailure();
				}
				catch (TimeoutException e)
				{
					HandleTimeout();
				}
			}else
			{
				var c = "this string";
			}
		}

		public async Task LoadExtendedWeatherData()
		{
			CheckNetworkConnectivity connectivity = new CheckNetworkConnectivity(connectivityManager);
			spinner.Visibility = Android.Views.ViewStates.Visible;
			if (connectivity.IsPhoneOnline())
			{
				PointF latlng = new PointF((float)lat, (float)lng);
				try
				{
					var extendedForecastData = await ServiceCall.GetFiveDayWeather(latlng);
					if (extendedForecastData != null)
					{
						List<WeatherConditionModel> threeDayForecast = WeatherObjectHelper.GetNextTwoDaysWeather(extendedForecastData);
						setExtendForecastValues(threeDayForecast);
					}
				}
				catch (WebException w)
				{
					HandleNetworkFailure();
				}
				catch (TimeoutException e)
				{
					HandleTimeout();
				}

			}
			else
			{
				var c = "this string";
			}
		}
		private void setLabelValues(CurrentWeatherModel model)
		{
			string countryCity = model.CityName + ", " + GetCountryFromCode.getCountry(model.System.CountryCode);
			string lastUpdatedLabel = this.Resources.GetString(Resource.String.lastupdated_string);
			dateLabel.Text = DateUtils.unixTimestampToDate(model.Timestamp);
			mainTempLabel.Text = ConvertTemperatures.AppendDegreeCharacter(model.TempPressure.Temperature);
			maxTempLabel.Text = maxLabel + " " + ConvertTemperatures.AppendDegreeCharacter(model.TempPressure.TempMax);
			minTempLabel.Text = minLabel + " " + ConvertTemperatures.AppendDegreeCharacter(model.TempPressure.TempMin);
			areaLabel.Text = countryCity;
			string updated = DateUtils.Get24HourTimeFromTimeStamp(model.Timestamp);
			lastUpdated.Text=lastUpdatedLabel + " " + updated;
			weatherIcon.SetImageResource(manageWeatherIcon(model.Weather));
		}

		private void setExtendForecastValues(List<WeatherConditionModel> extendedForecast)
		{
			extMaxTempRow1.Text = maxLabel + " " + ConvertTemperatures.AppendDegreeCharacter(extendedForecast[0].weatherCondition.maxTemp);
			extMinTempRow1.Text = minLabel + " " + ConvertTemperatures.AppendDegreeCharacter(extendedForecast[0].weatherCondition.minTemp);
			dayRow1.Text = DateUtils.GetDayOfTheWeek(extendedForecast[0].unixTimestamp);
			iconImageRow1.SetImageResource(manageWeatherIcon(extendedForecast[0].weather));
			extMaxTempRow2.Text = maxLabel + " " + ConvertTemperatures.AppendDegreeCharacter(extendedForecast[1].weatherCondition.maxTemp);
			extMinTempRow2.Text = minLabel + " " + ConvertTemperatures.AppendDegreeCharacter(extendedForecast[1].weatherCondition.minTemp);
			dayRow2.Text = DateUtils.GetDayOfTheWeek(extendedForecast[1].unixTimestamp);
			iconImageRow2.SetImageResource(manageWeatherIcon(extendedForecast[1].weather)) ;
			content.Visibility = Android.Views.ViewStates.Visible;
			spinner.Visibility = Android.Views.ViewStates.Gone;
		}

		public int manageWeatherIcon(List<WeatherModel> modelList)
		{
			int resId = 0;
			foreach (WeatherModel weather in modelList)
			{
				resId = GetIconImage.GetImage(weather.Icon, weather.Id);
        	}
        	return  resId;
    	}

		public void manageBackgroundImages(Handler handler)
		{		
			BackgroundImageChanger bgChanger = new BackgroundImageChanger(handler, this, mViewPager);
			bgChanger.pageSwitcher(60);
		}

		private async Task GetLocation()
		{
			Position position = await LocationHelper.GetLocation();
			lat = position?.Latitude;
			lng = position?.Longitude;
		}

		public void QueueCronJobs(Handler handler)
		{
			CronJobRunner CurrentWeatherCronJobRunner = new CronJobRunner(handler);
			CurrentWeatherCronJobRunner.QueueJob(3600, currentWeatherRunnable);
	
			CronJobRunner ExtendedWeatherCronJobRunner = new CronJobRunner(handler);
			ExtendedWeatherCronJobRunner.QueueJob(3600, extendedWeatherRunnable);
		}

		private void HandleTimeout()
		{
			spinner.Visibility = Android.Views.ViewStates.Gone;
			errorDialog.Visibility = Android.Views.ViewStates.Visible;
			errorMessage.Text = "Connection Timeout";
		}

		private void HandleNetworkFailure()
		{
			spinner.Visibility = Android.Views.ViewStates.Gone;
			errorDialog.Visibility = Android.Views.ViewStates.Visible;
			errorMessage.Text = "Could not resolve the domain name";
		}
	}

}

