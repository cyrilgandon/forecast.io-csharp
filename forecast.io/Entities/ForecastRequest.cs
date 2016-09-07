using ForecastIO.Extensions;
using System;
using System.Globalization;

namespace ForecastIO
{
    public class ForecastRequest
    {
        public string apiKey { get; }
        public string latitude { get; }
        public string longitude { get; }
        public string unit { get; }
        public string exclude { get; }
        public string extend { get; }
        public string time { get; }
        public string lang { get; }
        public string ApiCallsMade
        {
            get
            {
                if (ApiCallsMade != null)
                {
                    return ApiCallsMade;
                }
                throw new Exception("Cannot retrieve API Calls Made. No calls have been made to the API yet.");
            }
            set { }
        }

        public string ApiResponseTime
        {
            get
            {
                if (ApiResponseTime != null)
                {
                    return ApiResponseTime;
                }
                throw new Exception("Cannot retrieve API Reponse Time. No calls have been made to the API yet.");
            }
            set { }
        }

        public ForecastRequest(string key, float latF, float longF, Unit un, Language? lng = null, Extend[] ext = null, Exclude[] exc = null)
        {
            apiKey = key;
            latitude = latF.ToString(CultureInfo.InvariantCulture);
            longitude = longF.ToString(CultureInfo.InvariantCulture);
            unit = Enum.GetName(typeof(Unit), un);
            extend = (ext != null) ? RequestHelpers.FormatExtendString(ext) : string.Empty;
            exclude = (exc != null) ? RequestHelpers.FormatExcludeString(exc) : string.Empty;
            lang = (lng != null) ? RequestHelpers.FormatLanguageEnum(lng) : Language.en.ToString();
        }

        public ForecastRequest(string key, float latF, float longF, DateTime t, Unit un, Language? lng = null, Extend[] ext = null, Exclude[] exc = null)
        {
            apiKey = key;
            latitude = latF.ToString(CultureInfo.InvariantCulture);
            longitude = longF.ToString(CultureInfo.InvariantCulture);
            time = t.ToUTCString();
            unit = Enum.GetName(typeof(Unit), un);
            extend = (ext != null) ? RequestHelpers.FormatExtendString(ext) : string.Empty;
            exclude = (exc != null) ? RequestHelpers.FormatExcludeString(exc) : string.Empty;
            lang = (lng != null) ? RequestHelpers.FormatLanguageEnum(lng) : Language.en.ToString();
        }
    }
}
