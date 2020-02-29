using System;
using System.Collections.Generic;
using HourglassAnalyzer.H5MatchEvents;

namespace HourglassAnalyzer
{
    class Program
    {
        private static string apiKey = GetDeveloperAPIKey();
        private static string h5BaseURI = GetH5BaseURI();
        static void Main(string[] args)
        {
            Console.WriteLine("Gathering match ID's...");
            List<string> matchIDs = GetMatchIDs(); 
            
            Console.WriteLine("Querying for events...");
            List<H5MatchEventSet> matchEvents = GetMatchEvents(matchIDs);

            Console.WriteLine("Analyzing results...");
            AnalyzeEvents(matchEvents);
        }

        private static List<string> GetMatchIDs()
        {
            List<string> ids = new List<string>();

            ids.Add("033abd4a-8d6f-4337-8991-7d52dc5cdb6e");

            return ids;
        }

        private static List<H5MatchEventSet> GetMatchEvents(List<string> matchIDs)
        {
            List<H5MatchEventSet> matchEvents = new List<H5MatchEventSet>();
            EventGrabber eg = new EventGrabber(apiKey, h5BaseURI);

            foreach(string id in matchIDs)
            {
                matchEvents.Add(eg.GetEventSetFromMatch(id).Result);
            }

            return matchEvents;
        }

        private static void AnalyzeEvents(List<H5MatchEventSet> matchEvents)
        {
            foreach (H5MatchEventSet matchEventSet in matchEvents)
            {
                Console.WriteLine(matchEventSet.IsCompleteSetOfEvents.ToString());
            }
        }

        private static string GetDeveloperAPIKey()
        {
            return Environment.GetEnvironmentVariable("HALOAPI_DEV_KEY");
        }

        private static string GetProductionAPIKey()
        {
            return Environment.GetEnvironmentVariable("HALOAPI_PROD_KEY");
        }

        private static string GetH5BaseURI()
        {
            return @"https://www.haloapi.com/stats/h5/";
        }
    }
}
