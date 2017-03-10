using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// Contains various properties, each representing the average (unless otherwise specified) 
    /// of a particular weather phenomenon occurring during a period of time: 
    ///  - an instant in the case of currently, 
    ///  - a minute for minutely, 
    ///  - an hour for hourly, 
    ///  - and a day for daily.
    /// </summary>
    [DataContract]
    public class DataPoint
    {
        /// <summary>
        /// The apparent (or “feels like”) temperature in degrees Fahrenheit.
        /// </summary>
        [DataMember(Name = "apparentTemperature")]
        public float? ApparentTemperature { get; set; }
        /// <summary>
        /// The maximum value of apparentTemperature during a given day.
        /// </summary>
        [DataMember(Name = "apparentTemperatureMax")]
        public float? ApparentTemperatureMax { get; set; }
        /// <summary>
        /// The UNIX time of when apparentTemperatureMax occurs during a given day.
        /// </summary>
        [DataMember(Name = "apparentTemperatureMaxTime")]
        public long? ApparentTemperatureMaxTime { get; set; }
        /// <summary>
        /// apparentTemperatureMin optional, only on daily
        /// </summary>
        [DataMember(Name = "apparentTemperatureMin")]
        public float? ApparentTemperatureMin { get; set; }
        /// <summary>
        /// The UNIX time of when apparentTemperatureMin occurs during a given day.
        /// </summary>
        [DataMember(Name = "apparentTemperatureMinTime")]
        public long? ApparentTemperatureMinTime { get; set; }
        /// <summary>
        /// The percentage of sky occluded by clouds, between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "cloudCover")]
        public float? CloudCover { get; set; }
        /// <summary>
        /// The dew point in degrees Fahrenheit.
        /// </summary>
        [DataMember(Name = "dewPoint")]
        public float? DewPoint { get; set; }
        /// <summary>
        /// The relative humidity, between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "humidity")]
        public float? Humidity { get; set; }
        /// <summary>
        /// A machine-readable text summary of this data point, suitable for selecting an icon for display. 
        /// If defined, this property will have one of the following values: 
        ///      clear-day, clear-night, rain, snow, sleet, wind, fog, cloudy, partly-cloudy-day, or partly-cloudy-night. 
        /// Developers should ensure that a sensible default is defined, as additional values, such as hail, thunderstorm, or tornado, may be defined in the future.
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        /// <summary>
        /// The fractional part of the lunation number during the given day: 
        ///     a value of 0 corresponds to a new moon, 
        ///     0.25 to a first quarter moon, 
        ///     0.5 to a full moon, 
        ///     and 0.75 to a last quarter moon. 
        /// The ranges in between these represent waxing crescent, waxing gibbous, waning gibbous, and waning crescent moons, respectively.
        /// </summary>
        [DataMember(Name = "moonPhase")]
        public float? MoonPhase { get; set; }
        /// <summary>
        /// The approximate direction of the nearest storm in degrees, with true north at 0° and progressing clockwise. 
        /// If nearestStormDistance is zero, then this value will not be defined.
        /// </summary>
        [DataMember(Name = "nearestStormBearing")]
        public float? NearestStormBearing { get; set; }
        /// <summary>
        /// The approximate distance to the nearest storm in miles. 
        /// A storm distance of 0 doesn’t necessarily refer to a storm at the requested location, but rather a storm in the vicinity of that location.
        /// </summary>
        [DataMember(Name = "nearestStormDistance")]
        public float? NearestStormDistance { get; set; }
        /// <summary>
        /// The columnar density of total atmospheric ozone at the given time in Dobson units.
        /// </summary>
        [DataMember(Name = "ozone")]
        public float? Ozone { get; set; }
        /// <summary>
        /// The amount of snowfall accumulation expected to occur, in inches. 
        /// If no snowfall is expected, this property will not be defined.
        /// </summary>
        [DataMember(Name = "precipAccumulation")]
        public float? PrecipAccumulation { get; set; }
        /// <summary>
        /// The intensity (in inches of liquid water per hour) of precipitation occurring at the given time.
        /// This value is conditional on probability (that is, assuming any precipitation occurs at all) for minutely data points, and unconditional otherwise.
        /// </summary>
        [DataMember(Name = "precipIntensity")]
        public float? PrecipIntensity { get; set; }
        /// <summary>
        /// The maximum value of precipIntensity during a given day.
        /// </summary>
        [DataMember(Name = "precipIntensityMax")]
        public float? PrecipIntensityMax { get; set; }
        /// <summary>
        /// The UNIX time of when precipIntensityMax occurs during a given day.
        /// </summary>
        [DataMember(Name = "precipIntensityMaxTime")]
        public long? PrecipIntensityMaxTime { get; set; }
        /// <summary>
        /// The probability of precipitation occurring, between 0 and 1, inclusive.
        /// </summary>
        [DataMember(Name = "precipProbability")]
        public float? PrecipProbability { get; set; }
        /// <summary>
        /// The type of precipitation occurring at the given time. 
        /// If defined, this property will have one of the following values: 
        ///     "rain", "snow", or "sleet" (which refers to each of freezing rain, ice pellets, and “wintery mix”). 
        /// If precipIntensity is zero, then this property will not be defined.
        /// </summary>
        [DataMember(Name = "precipType")]
        public string PrecipType { get; set; }
        /// <summary>
        /// The sea-level air pressure in millibars.
        /// </summary>
        [DataMember(Name = "pressure")]
        public float? Pressure { get; set; }
        /// <summary>
        /// A human-readable text summary of this data point. 
        /// This property has millions of possible values, so don’t use it for automated purposes: use the icon property, instead!
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }
        /// <summary>
        /// The UNIX time of when the sun will rise during a given day.
        /// </summary>
        [DataMember(Name = "sunriseTime")]
        public long? SunriseTime { get; set; }
        /// <summary>
        /// The UNIX time of when the sun will set during a given day.
        /// </summary>
        [DataMember(Name = "sunsetTime")]
        public long? SunsetTime { get; set; }
        /// <summary>
        /// The air temperature in degrees Fahrenheit.
        /// </summary>
        [DataMember(Name = "temperature")]
        public float? Temperature { get; set; }
        /// <summary>
        /// The maximum value of temperature during a given day.
        /// </summary>
        [DataMember(Name = "temperatureMax")]
        public float? TemperatureMax { get; set; }
        /// <summary>
        /// The UNIX time of when temperatureMax occurs during a given day.
        /// </summary>
        [DataMember(Name = "temperatureMaxTime")]
        public long? TemperatureMaxTime { get; set; }
        /// <summary>
        /// The minimum value of temperature during a given day.
        /// </summary>
        [DataMember(Name = "temperatureMin")]
        public float? TemperatureMin { get; set; }
        /// <summary>
        /// The UNIX time of when temperatureMin occurs during a given day.
        /// </summary>
        [DataMember(Name = "temperatureMinTime")]
        public long? TemperatureMinTime { get; set; }
        /// <summary>
        /// The UNIX time at which this data point begins. 
        ///     minutely data point are always aligned to the top of the minute, 
        ///     hourly data point objects to the top of the hour, 
        ///     and daily data point objects to midnight of the day, 
        /// all according to the local time zone.
        /// </summary>
        [DataMember(Name = "time")]
        public long Time { get; set; }
        /// <summary>
        /// The average visibility in miles, capped at 10 miles.
        /// </summary>
        [DataMember(Name = "visibility")]
        public float? Visibility { get; set; }
        /// <summary>
        /// The wind speed in miles per hour.
        /// </summary>
        [DataMember(Name = "windSpeed")]
        public float? WindSpeed { get; set; }
        /// <summary>
        /// The direction that the wind is coming from in degrees, with true north at 0° and progressing clockwise.
        /// If windSpeed is zero, then this value will not be defined.
        /// </summary>
        [DataMember(Name = "windBearing")]
        public float? WindBearing { get; set; }
    }
}
