using System;
using Android.Icu.Text;
using Java.Util;

namespace WeatherAppXamarinNative
{
	public class DateUtils
	{
		public static string unixTimestampToDate(long timestamp)
		{
			SimpleDateFormat weatherDateTime = new SimpleDateFormat("EEEE, MMMM d");
			Date time = new Date(timestamp * 1000);
			string dateTime = weatherDateTime.Format(time);
			return dateTime;
		}

		public static string Get24HourTimeFromTimeStamp(long timestamp)
		{
			SimpleDateFormat weatherDateTime = new SimpleDateFormat("HH:mm");
			Date time = new Date(timestamp * 1000);
			string dateTime = weatherDateTime.Format(time);
			return dateTime;
		}

		public static string GetDayOfTheWeek(long timestamp)
		{
			SimpleDateFormat weatherDateTime = new SimpleDateFormat("EEEE");
			Date time = new Date(timestamp * 1000);
			string dateTime = weatherDateTime.Format(time);
			return dateTime;
		}

		public static Date convertDateTimeToDate(string datetime)
		{
			string sourceDate = datetime;
			SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
			Date myDate = null;
			try
			{
				myDate = format.Parse(sourceDate);

			}
			catch (Exception e)
			{

				System.Diagnostics.Debug.Print(e.Message);
			}
			return myDate;
		}

		public static Date addDays(Date date, int days)
		{
			Calendar cal = Calendar.GetInstance( new Locale("En", "ZA"));
			cal.Time = date;
			cal.Add(Calendar.Date, days);
			return cal.Time;
		}

		public static string ConvertDateToString(Date dateString)
		{
			SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
			string formattedDate = dateFormat.Format(dateString);
			return formattedDate;
		}
	}
}
