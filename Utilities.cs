using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CS2DarkSky
{
    internal static class Utilities
    {
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a DateTime to a UNIX time that is seconds since midnight GMT on 1 Jan 1970
        /// </summary>
        public static double ToUnixTimestamp(this DateTime input) => input.ToUniversalTime().Subtract(UnixEpoch).TotalSeconds;

        /// <summary>
        /// Returns the content of the Description attribute for an enum item
        /// </summary>
        public static string GetDescription<T>(this T value)
            where T : struct
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var descriptions = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            var descriptionAttribute = descriptions?.FirstOrDefault();
            return descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
        }
    }
}
