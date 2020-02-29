using System;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;


namespace HourglassAnalyzer
{
    public class EventGrabber
    {
        private string apiKey;
        private string endpoint;

        public EventGrabber(string id, string key, string baseURI)
        {
            apiKey = key;
            endpoint = baseURI + "matches/" + id + @"/events";

        }

        public void PrintEventsFromMatch()
        {
            Console.WriteLine(endpoint);
            GetEventsFromMatch().Wait();

        }

        private async Task GetEventsFromMatch()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(endpoint);

            var msg = await stringTask;
            Console.WriteLine(msg);
            return;
//            return response;
        }




    }


}