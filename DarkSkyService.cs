using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace CS2DarkSky
{
    /// <summary>
    /// https://darksky.net/dev/docs/forecast
    /// The Dark Sky API allows you to look up the weather anywhere on the globe, returning (where available):
    ///  - Current conditions
    ///  - Minute-by-minute forecasts out to one hour
    ///  - Hour-by-hour and day-by-day forecasts out to seven days
    ///  - Hour-by-hour and day-by-day observations going back decades
    /// We provide two types of API requests:
    ///  - A Forecast Request returns the current forecast for the next week in JSON format.
    ///  - A Time Machine Request returns the observed or forecast weather conditions for a date in the past or future in in the same JSON format.
    /// </summary>
    public class DarkSkyService
    {
        /// <summary>
        /// Your Dark Sky secret key. 
        /// Your secret key must be kept secret; in particular, do not embed it in JavaScript source code that you transmit to clients.
        /// </summary>
        public string ApiKey { get; }
        /// <summary>
        /// Host of the api, defaults to https://api.darksky.net/forecast
        /// </summary>
        public string Host { get; }
        /// <summary>
        /// Get a new instance of Dark Sky service with the specified Api key and the default host https://api.darksky.net/forecast
        /// </summary>
        /// <param name="apiKey">The api key</param>
        public DarkSkyService(string apiKey) : this(apiKey, "https://api.darksky.net/forecast/") { }
        /// <summary>
        /// Get a new instance of Dark Sky service with the specified Api key and the specified host
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// /// <param name="host">The Host</param>
        public DarkSkyService(string apiKey, string host)
        {
            this.ApiKey = apiKey;
            this.Host = host;
        }
        /// <summary>
        /// Basic usage
        /// </summary>
        public DarkSkyResponse Download(double latitude, double longitude)
            => Download(latitude, longitude, null, null, null, false, null);

        /// <summary>
        /// Specify units and language
        /// </summary>
        public DarkSkyResponse Download(double latitude, double longitude, Units? units, Language? lang)
          => Download(latitude, longitude, null, units, lang, false, null);

        /// <summary>
        /// Including the date
        /// </summary>
        public DarkSkyResponse Download(double latitude, double longitude, DateTime? dateTime, Units? units, Language? lang)
           => Download(latitude, longitude, dateTime, units, lang, false, null);

        /// <summary>
        /// Include extra data - (Currently only hourly is supported by the API) Returns hourly data for the next seven days, rather than the next two.
        /// </summary>
        public DarkSkyResponse Download(double latitude, double longitude, DateTime? dateTime, Units? units, Language? lang, bool extend)
           => Download(latitude, longitude, dateTime, units, lang, extend, null);

        /// <summary>
        /// Exclude certain objects (returned as null)
        /// </summary>
        public DarkSkyResponse Download(double latitude, double longitude, DateTime? time, Units? units, Language? lang, bool extend, IEnumerable<Exclude> exclude)
            => Download(new DarkSkyRequest(this.ApiKey, latitude, longitude, time, units, lang, extend, exclude));

        /// <summary>
        /// Build the Uri based on the request.
        /// Returns the parsed response.
        /// </summary>
        public DarkSkyResponse Download(DarkSkyRequest request)
        {
            var baseUri = new Uri(Host);
            var uri = new Uri(baseUri, request.RequestUrl);
            var queriedUri = new Uri(uri, $"?{request.QueryString}");
            return Download(queriedUri);
        }

        /// <summary>
        /// Download from the uri provided,
        /// returns the parsed response
        /// </summary>
        public DarkSkyResponse Download(Uri uri)
        {
            string response, cacheControl, forecastApiCalls, responseTime;
            using (var client = new CompressionEnabledWebClient { Encoding = Encoding.UTF8, UseDefaultCredentials = true })
            {
                response = client.DownloadString(uri);

                cacheControl = client.ResponseHeaders["Cache-Control"];
                forecastApiCalls = client.ResponseHeaders["X-Forecast-API-Calls"];
                responseTime = client.ResponseHeaders["X-Response-Time"];
            }

            var serializer = new JavaScriptSerializer();
            var parsedResponse = serializer.Deserialize<DarkSkyResponse>(response);

            // add headers information to response, this part can't be handled by the deserializer
            parsedResponse.CacheControl = cacheControl;
            parsedResponse.ResponseTime = responseTime;
            int iForecastApiCalls;
            parsedResponse.ForecastApiCalls = int.TryParse(forecastApiCalls, out iForecastApiCalls) ? (int?)iForecastApiCalls : null;
            return parsedResponse;
        }
    }
}
