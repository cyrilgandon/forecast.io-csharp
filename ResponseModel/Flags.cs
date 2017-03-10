using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// Contains various metadata information related to the request. 
    /// Despite some properties exist in the response, they are not include by this wrapper because they are not documented
    /// Not shown in this class: 
    ///  - darksky-unavailable 
    ///  - metno-license 
    ///  - lamp-stations
    ///  - isd-stations
    ///  - madis-stations
    /// </summary>
    [DataContract]
    public class Flags
    {
        /// <summary>
        /// This property contains an array of IDs for each data source utilized in servicing this request.
        /// </summary>
        [DataMember(Name = "sources")]
        public List<string> Sources { get; set; }
        /// <summary>
        /// Indicates the units which were used for the data in this request.
        /// </summary>
        [DataMember(Name = "units")]
        public string Units { get; set; }
    }
}
