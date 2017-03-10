using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// Represents the various weather phenomena occurring over a period of time.
    /// </summary>
    [DataContract]
    public class DataBlock
    {
        /// <summary>
        /// An array of data points, ordered by time, which together describe the weather conditions at the requested location over time.
        /// </summary>
        [DataMember(Name = "data")]
        public List<DataPoint> Data { get; set; }
        /// <summary>
        /// A human-readable summary of this data block.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// A machine-readable text summary of this data block. (May take on the same values as the iconproperty of data points.)
        /// </summary>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }
}
