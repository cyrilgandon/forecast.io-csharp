using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CS2DarkSky
{
    /// <summary>
    /// https://darksky.net/dev/docs/response
    /// API response
    /// </summary>
    [DataContract]
    public class DarkSkyResponse
    {
        /// <summary>
        /// The requested latitude.
        /// </summary>
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }
        /// <summary>
        /// The requested longitude.
        /// </summary>
        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }
        /// <summary>
        /// The IANA timezone name for the requested location. 
        /// This is used for text summaries and for determining when hourly and daily data block objects begin.
        /// </summary>
        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }
        /// <summary>
        /// Contains the current weather conditions at the requested location.
        /// </summary>
        [DataMember(Name = "currently")]
        public DataPoint Currently { get; set; }
        /// <summary>
        /// Contains the weather conditions minute-by-minute for the next hour.
        /// </summary>
        [DataMember(Name = "minutely")]
        public DataBlock Minutely { get; set; }
        /// <summary>
        /// Contains the weather conditions hour-by-hour for the next two days.
        /// </summary>
        [DataMember(Name = "hourly")]
        public DataBlock Hourly { get; set; }
        /// <summary>
        /// Contains the weather conditions day-by-day for the next week.
        /// </summary>
        [DataMember(Name = "daily")]
        public DataBlock Daily { get; set; }
        /// <summary>
        /// If present, contains any severe weather alerts pertinent to the requested location.
        /// </summary>
        [DataMember(Name = "alerts")]
        public List<Alert> Alerts { get; set; }
        /// <summary>
        /// Contains miscellaneous metadata about the request.
        /// </summary>
        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }

        /// <summary>
        /// Set to a conservative value for data caching purposes based on the data present in the response body.
        /// </summary>
        [DataMember(Name = "cacheControl")]
        public string CacheControl { get; set; }

        /// <summary>
        /// The number of API requests made by the given API key for today.
        /// </summary>
        [DataMember(Name = "forecastApiCalls")]
        public int? ForecastApiCalls { get; set; }

        /// <summary>
        /// The number of API requests made by the given API key for today.
        /// </summary>
        [DataMember(Name = "responseTime")]
        public string ResponseTime { get; set; }
    }
}
