using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace FetchData.Utils
{
	public static class Utils
	{
		public static string ConvertNumberToHex(this int value)
		{
            return String.Format("0x{0:X}", value);
        }

        public static int FromHexToNumber(this string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return Int32.Parse(value, NumberStyles.HexNumber);
        }

        public static decimal FromHexToDecimal(this string value)
        {
            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }
            return Int64.Parse(value, NumberStyles.HexNumber);
        }
    }
}

