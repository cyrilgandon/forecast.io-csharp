using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// Contains parametrization of a Dark Sky request to the API
    /// </summary>
    public class DarkSkyRequest
    {
        /// <summary>
        /// Your Dark Sky secret key. 
        /// Your secret key must be kept secret; in particular, do not embed it in JavaScript source code that you transmit to clients.
        /// </summary>
        public string ApiKey { get; }
        /// <summary>
        /// The latitude of a location (in decimal degrees). Positive is north, negative is south.
        /// </summary>
        public double Latitude { get; }
        /// <summary>
        /// The longitude of a location (in decimal degrees). Positive is east, negative is west.
        /// </summary>
        public double Longitude { get; }

        /// <summary>
        /// Return weather conditions in the requested units.
        /// </summary>
        public Units? Units { get; }

        /// <summary>
        /// Exclude some number of data blocks from the API response. 
        /// This is useful for reducing latency and saving cache space. 
        /// </summary>
        public IEnumerable<Exclude> Excludes { get; }

        /// <summary>
        /// When extend=hourly is present, return hour-by-hour data for the next 168 hours, instead of the next 48. 
        /// When using this option, we strongly recommend enabling HTTP compression.
        /// </summary>
        public bool Extend { get; }

        /// <summary>
        /// Return summary properties in the desired language. 
        /// Note that units in the summary will be set according to the units parameter, so be sure to set both parameters appropriately.
        /// </summary>
        public Language? Lang { get; }

        /// <summary>
        /// Either be a UNIX time (that is, seconds since midnight GMT on 1 Jan 1970) or a string formatted as follows: [YYYY]-[MM]-[DD]T[HH]:[MM]:[SS][timezone]. 
        /// timezone should either be omitted (to refer to local time for the location being requested), Z (referring to GMT time), or +[HH][MM] or -[HH][MM] for an offset from GMT in hours and minutes.
        /// The timezone is only used for determining the time of the request; 
        /// the response will always be relative to the local time zone.
        /// </summary>
        public DateTime? Time { get; }

        /// <summary>
        /// Parameters of the request, that will be serialize into the query string
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get
            {
                var paramss = new Dictionary<string, string>();
                if (Lang.HasValue)
                {
                    paramss.Add("lang", Lang.Value.GetDescription());
                }
                if (this.Extend)
                {
                    paramss.Add("extend", "hourly");
                }
                if (this.Excludes != null && this.Excludes.Any())
                {
                    paramss.Add("exclude", string.Join(",", this.Excludes.Select(exclude => exclude.GetDescription())));
                }
                if (this.Units.HasValue)
                {
                    paramss.Add("units", Units.Value.GetDescription());
                }
                return paramss;
            }
        }

        /// <summary>
        /// Return the formated GET request address
        /// [key]/[latitude],[longitude](,[time])
        /// </summary>
        public string RequestUrl
        {
            get
            {
                var latitudeParam = Latitude.ToString(CultureInfo.InvariantCulture);
                var longitudeParam = Longitude.ToString(CultureInfo.InvariantCulture);
                var timeParam = Time.HasValue ? $",{(long)Time.Value.ToUnixTimestamp()}" : "";
                return $"{ApiKey}/{latitudeParam},{longitudeParam}{timeParam}";
            }
        }

        /// <summary>
        /// Returns the parameters serialize into the query string.
        /// Returns empty string if no parameters has been parametrized
        /// </summary>
        public string QueryString => string.Join("&", Parameters.Select(param => $"{param.Key}={param.Value}"));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="time"></param>
        /// <param name="units"></param>
        /// <param name="lang"></param>
        /// <param name="extend"></param>
        /// <param name="exclude"></param>
        public DarkSkyRequest(string apiKey, double latitude, double longitude, DateTime? time, Units? units, Language? lang, bool extend, IEnumerable<Exclude> exclude)
        {
            ApiKey = apiKey;
            Latitude = latitude;
            Longitude = longitude;
            Time = time;
            Units = units;
            Lang = lang;
            Extend = extend;
            Excludes = exclude;
        }
    }
}
