using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ForecastIO
{
    public static class RequestHelpers
    {
        public static string FormatResponse(string _input)
        {
            _input = _input.Replace("isd-stations", "isd_stations");
            _input = _input.Replace("lamp-stations", "lamp_stations");
            _input = _input.Replace("metar-stations", "metar_stations");
            _input = _input.Replace("darksky-stations", "darksky_stations");
            return _input;
        }

        public static string FormatExcludeString(Exclude[] input)
        {
            return string.Join(",", input.Select(i => Enum.GetName(typeof(Exclude), i)));
        }

        public static string FormatExtendString(Extend[] input)
        {
            return string.Join(",", input.Select(i => Enum.GetName(typeof(Extend), i)));
        }

        public static string FormatLanguageEnum(Language? lang)
        {
            if (lang == Language.xpiglatin)
            {
                return "x-pig-latin";
            }
            if (lang == Language.zhtw)
            {
                return "zh-tw";
            }
            return lang.ToString();
        }

        private static string CurrentForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&lang={4}&extend={5}&exclude={6}";
        private static string PeriodForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&lang={5}&extend={6}&exclude={7}";

        public static ForecastResponse Get(ForecastRequest request)
        {
            try
            {
                var uri = (request.time == null)
                            ? string.Format(CurrentForecastUrl, request.apiKey, request.latitude, request.longitude, request.unit, request.lang, request.extend, request.exclude)
                            : string.Format(PeriodForecastUrl, request.apiKey, request.latitude, request.longitude, request.time, request.unit, request.lang, request.extend, request.exclude);


                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "GET";
                webRequest.Headers.Add("Content-Encoding", "gzip");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip;
                webRequest.ContentType = "application/json";

                var response = (HttpWebResponse)webRequest.GetResponse();
                ForecastResponse result = null;

                using (Stream responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    var jsonOut = reader.ReadToEnd();
                    reader.Close();
                    result = JsonConvert.DeserializeObject<ForecastResponse>(jsonOut);
                }

                // Set response values.
                request.ApiCallsMade = response.Headers["X-Response-Time"];
                request.ApiCallsMade = response.Headers["X-Forecast-API-Calls"];

                return result;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(500);
                sb.AppendLine("Error while requesting weather from source!");

                WebException wex = ex as WebException;
                if (wex != null)
                {
                    HttpWebResponse httpResponse = wex.Response as HttpWebResponse;
                    if (httpResponse != null)
                    {
                        int statusCode = (int)httpResponse.StatusCode;
                        string statusDesc = httpResponse.StatusDescription;

                        sb.AppendLine(string.Format("Http Status Code: {0}", statusCode));
                        sb.AppendLine(string.Format("Http Status Desc: {0}", statusDesc));

                        if (httpResponse.Headers != null)
                        {
                            sb.AppendLine("All response header values:");
                            foreach (var key in httpResponse.Headers.AllKeys)
                            {
                                string value = httpResponse.Headers[key];
                                sb.AppendLine(string.Format("{0}: {1}", key, value));
                            }
                        }
                        else
                        {
                            sb.AppendLine("Unable to get response headers!");
                        }
                    }
                }
                throw new ForecastIOException(sb.ToString(), ex);
            }
        }

        public static async Task<ForecastResponse> GetAsync(ForecastRequest request)
        {
            try
            {
                var uri = (request.time == null)
                            ? string.Format(CurrentForecastUrl, request.apiKey, request.latitude, request.longitude, request.unit, request.lang, request.extend, request.exclude)
                            : string.Format(PeriodForecastUrl, request.apiKey, request.latitude, request.longitude, request.time, request.unit, request.lang, request.extend, request.exclude);


                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "GET";
                webRequest.Headers.Add("Content-Encoding", "gzip");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip;
                webRequest.ContentType = "application/json";

                var response = (HttpWebResponse)webRequest.GetResponse();
                ForecastResponse result = null;

                using (Stream responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream);
                    var jsonOut = await reader.ReadToEndAsync();
                    reader.Close();
                    result = JsonConvert.DeserializeObject<ForecastResponse>(jsonOut);
                }

                // Set response values.
                request.ApiCallsMade = response.Headers["X-Response-Time"];
                request.ApiCallsMade = response.Headers["X-Forecast-API-Calls"];

                return result;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(500);
                sb.AppendLine("Error while requesting weather from source!");

                WebException wex = ex as WebException;
                if (wex != null)
                {
                    HttpWebResponse httpResponse = wex.Response as HttpWebResponse;
                    if (httpResponse != null)
                    {
                        int statusCode = (int)httpResponse.StatusCode;
                        string statusDesc = httpResponse.StatusDescription;

                        sb.AppendLine(string.Format("Http Status Code: {0}", statusCode));
                        sb.AppendLine(string.Format("Http Status Desc: {0}", statusDesc));

                        if (httpResponse.Headers != null)
                        {
                            sb.AppendLine("All response header values:");
                            foreach (var key in httpResponse.Headers.AllKeys)
                            {
                                string value = httpResponse.Headers[key];
                                sb.AppendLine(string.Format("{0}: {1}", key, value));
                            }
                        }
                        else
                        {
                            sb.AppendLine("Unable to get response headers!");
                        }
                    }
                }
                throw new ForecastIOException(sb.ToString(), ex);
            }
        }
    }
}
