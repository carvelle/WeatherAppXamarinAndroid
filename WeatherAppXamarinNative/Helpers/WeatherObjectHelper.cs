using System;
using System.Collections.Generic;
using Java.Util;
using WeatherAppXamarinNative.Models;

namespace WeatherAppXamarinNative
{
	public class WeatherObjectHelper
	{
		public static List<WeatherConditionModel> GetNextTwoDaysWeather(ExtendedForecastModel extendedForecastModel)
		{
			List<WeatherConditionModel> weatherConditionsList = new List<WeatherConditionModel>();
			Date today = DateUtils.convertDateTimeToDate(extendedForecastModel.weatherCollection[0].dateTime);
			Date tomorrow = DateUtils.addDays(today, 1);
			Date thirdDay = DateUtils.addDays(today, 2);
			String tomorrowDateString = DateUtils.ConvertDateToString(tomorrow);
			String thirdDayString = DateUtils.ConvertDateToString(thirdDay);

			foreach (WeatherConditionModel condModel in extendedForecastModel.weatherCollection)
			{
				if (condModel.dateTime.Equals(tomorrowDateString + " 12:00:00"))
				{
					weatherConditionsList.Add(condModel);
				}
				else if (condModel.dateTime.Equals(thirdDayString + " 12:00:00"))
				{
					weatherConditionsList.Add(condModel);
				}
			}
			return weatherConditionsList;   
		}
	}
}
