﻿using Newtonsoft.Json;

namespace DeleteAfter.Models.UpcomingEvents
{
    public class EndDTO
    {
        [JsonProperty("dateTime")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }
    }
}
