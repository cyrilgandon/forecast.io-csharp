using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// Represent the severe weather warnings issued for the requested location by a governmental authority
    /// Please see our data sources page for a list of sources
    /// </summary>
    [DataContract]
    public class Alert
    {
        /// <summary>
        /// A brief description of the alert.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }
        /// <summary>
        /// The UNIX time at which the alert will expire.
        /// </summary>
        [DataMember(Name = "expires")]
        public long Expires { get; set; }
        /// <summary>
        /// An HTTP(S) URI that one may refer to for detailed information about the alert.
        /// </summary>
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        /// <summary>
        /// A detailed description of the alert.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
