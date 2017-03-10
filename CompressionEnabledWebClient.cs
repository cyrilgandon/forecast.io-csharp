using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CS2DarkSky
{
    /// <summary>
    /// The Forecast Data API supports HTTP compression. 
    /// We heartily recommend using it, as it will make responses much smaller over the wire. 
    /// To enable it, simply add an Accept-Encoding: gzip header to your request. 
    /// Most HTTP client libraries wrap this functionality for you, please consult your library’s documentation for details.
    /// </summary>
    internal class CompressionEnabledWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            // http://stackoverflow.com/questions/2973208/automatically-decompress-gzip-response-via-webclient-downloaddata
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null)
            {
                return null;
            }
            else
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                return request;
            }
        }
    }
}
