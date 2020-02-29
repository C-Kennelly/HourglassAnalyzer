using System;
using System.Text.Json.Serialization;

namespace HourglassAnalyzer.H5MatchEvents
{
    public class H5MatchEventSet
    {
        [JsonPropertyName("IsCompleteSetOfEvents")]
        public bool IsCompleteSetOfEvents {get; set;}

    }

}