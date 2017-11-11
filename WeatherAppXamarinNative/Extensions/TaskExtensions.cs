using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherAppXamarinNative
{
	public static class TaskExtensions
	{
		public async static Task<T> TimeoutAfter<T>(this Task<T> task, int delay)
		{
			using (CancellationTokenSource tokenSource = new CancellationTokenSource())
			{
				var token = tokenSource.Token;

				if (task == await Task.WhenAny(task, Task.Delay(delay, token)))
				{
					tokenSource.Cancel();
					return await task;
				}
				else
				{
					throw new System.TimeoutException(null);
				}
			}
		}
	}
}
