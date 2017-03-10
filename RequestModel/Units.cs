using System.ComponentModel;

namespace CS2DarkSky
{
    /// <summary>
    /// Return weather conditions in the requested units.
    /// </summary>
    public enum Units
    {
        /// <summary>
        /// Imperial units (the default)
        /// </summary>
        [Description("us")]
        Imperial,
        /// <summary>
        /// SI units
        /// </summary>
        [Description("si")]
        SI,
        /// <summary>
        /// SI units, except that windSpeed is in kilometers per hour
        /// </summary>
        // not sure why they choose 'ca', so let's suppose it's the standard for Canada
        [Description("ca")]
        SICanada,
        /// <summary>
        /// SI units, except that nearestStormDistance and visibility are in miles and windSpeed is in miles per hour
        /// </summary>
        [Description("uk2")]
        SIUnitedKingdom,
        /// <summary>
        /// Automatically select units based on geographic location
        /// </summary>
        [Description("auto")]
        Automatic
    }
}
