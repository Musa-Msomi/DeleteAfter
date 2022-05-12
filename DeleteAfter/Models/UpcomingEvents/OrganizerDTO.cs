using Newtonsoft.Json;

namespace DeleteAfter.Models.UpcomingEvents
{
    public class OrganizerDTO
    {
        [JsonProperty("emailAddress")]
        public EmailAddressDTO EmailAddress { get; set; }
    }
}
