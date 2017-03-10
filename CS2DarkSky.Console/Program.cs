using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2DarkSky;

namespace CS2DarkSky.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new DarkSkyService("YOUR API KEY");
            var response = service.Download(37.8267, -122.423);
        }
    }
}
