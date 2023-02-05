using System;
namespace FetchData
{
	public class Settings
	{
		public ConnectionString ConnectionString { get; set; }
		public int RetryTimes { get; set; }
		public int TimeOutInMinutes { get; set; }
		public string APIEndpoint { get; set; }
		public string APIKey { get; set; }
    }

	public class ConnectionString
	{
		public string ETH { get; set; }

    }
}

