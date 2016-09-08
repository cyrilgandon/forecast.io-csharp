using ForecastIO;
using System;

namespace Forecast.io.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.TestSync();
            test.TestAsync();
            Console.ReadKey(true);
        }
    }

    class Test
    {
        private static string key = "API Key";
        public void TestSync()
        {
            var request = new ForecastRequest(key, 43.4499376f, -79.7880999f, Unit.si);
            var response = RequestHelpers.Get(request);
            Console.WriteLine(string.Format("Sync Response: {0}", response.currently.apparentTemperature));
        }

        public async void TestAsync()
        {
            var request = new ForecastRequest(key, 43.4499376f, -79.7880999f, Unit.si);
            var response = await RequestHelpers.GetAsync(request);
            Console.WriteLine(string.Format("Async Response: {0}", response.currently.apparentTemperature));
        }
    }
}
