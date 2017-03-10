using System.ComponentModel;

namespace CS2DarkSky
{
    /// <summary>
    /// Exclude some number of data blocks from the API response.
    /// This is useful for reducing latency and saving cache space. 
    /// The value blocks should be a comma-delimeted list (without spaces) of any of the following:
    /// </summary>
    public enum Exclude
    {
        /// <summary>
        /// Exclude currently data point
        /// </summary>
        [Description("currently")]
        Currently,
        /// <summary>
        /// Exclude minutely data block
        /// </summary>
        [Description("minutely")]
        Minutely,
        /// <summary>
        /// Exclude hourly data block
        /// </summary>
        [Description("hourly")]
        Hourly,
        /// <summary>
        /// Exclude daily data block
        /// </summary>
        [Description("daily")]
        Daily,
        /// <summary>
        /// Exclude alerts array
        /// </summary>
        [Description("alerts")]
        Alerts,
        /// <summary>
        /// Exclude flags object
        /// </summary>
        [Description("flags")]
        Flags
    }
}
