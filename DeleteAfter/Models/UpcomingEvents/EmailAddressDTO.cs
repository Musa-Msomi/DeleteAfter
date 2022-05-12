using Newtonsoft.Json;

namespace DeleteAfter.Models.UpcomingEvents
{
    public class EmailAddressDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
