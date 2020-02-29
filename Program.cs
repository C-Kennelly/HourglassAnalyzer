using System;
using System.Collections.Generic;


namespace HourglassAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string apiKey = GetDeveloperAPIKey();
            string h5BaseURI = GetH5BaseURI();
            List<string> matchIDs = GetMatchIDs(); 

            PrintEvents(matchIDs, apiKey, h5BaseURI);
        }

        private static void PrintEvents(List<string> idList, string key, string baseURI)
        {
            foreach(string id in idList)
            {
                EventGrabber eg = new EventGrabber(id, key, baseURI);
                eg.PrintEventsFromMatch();
            }
        }

        private static string GetDeveloperAPIKey()
        {
            return Environment.GetEnvironmentVariable("HALOAPI_DEV_KEY");
        }

        private static string GetH5BaseURI()
        {
            return @"https://www.haloapi.com/stats/h5/";
        }

        private static List<string> GetMatchIDs()
        {
            List<string> ids = new List<string>();

            ids.Add("033abd4a-8d6f-4337-8991-7d52dc5cdb6e");

            return ids;
        }
    }
}
