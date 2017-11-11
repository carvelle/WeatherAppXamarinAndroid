using System;
namespace WeatherAppXamarinNative
{
public class ConvertTemperatures
{

	public static string AppendDegreeCharacter(double temp)
	{
		return RoundTemperature(temp) + "º";
	}

	public static string RoundTemperature(double temp)
	{
			return (Math.Round(temp).ToString());
	}
}
}
