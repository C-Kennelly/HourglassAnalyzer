using System;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using HourglassAnalyzer.H5MatchEvents;


namespace HourglassAnalyzer
{
    public class EventGrabber
    {
        private string apiKey;
        private string baseEventURI;

        public EventGrabber(string key, string baseURI)
        {
            apiKey = key;
            baseEventURI = baseURI;            
        }
        public async Task<H5MatchEventSet> GetEventSetFromMatch(string matchID)
        {
            string endpoint = BuildEndpoint(baseEventURI, matchID);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = client.GetStreamAsync(endpoint);
            var events = await JsonSerializer.DeserializeAsync<H5MatchEventSet>(await streamTask);

            return events;
        }

        private string BuildEndpoint(string baseURI, string id)
        {
            return baseURI + @"matches/" + id + @"/events";
        }

    }

}