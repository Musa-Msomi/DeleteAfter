using Newtonsoft.Json;

namespace DeleteAfter.Models.UpcomingEvents
{
    public class LocationDTO
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

      //  [JsonProperty("locationType")]
      //  public string LocationType { get; set; }

        [JsonProperty("uniqueId")]
        public string UniqueId { get; set; }

       // [JsonProperty("uniqueIdType")]
      //  public string UniqueIdType { get; set; }
    }
}
