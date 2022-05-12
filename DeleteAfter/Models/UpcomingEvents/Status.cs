using Newtonsoft.Json;

namespace DeleteAfter.Models.UpcomingEvents
{
    public class Status
    {
        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }
    }
}
