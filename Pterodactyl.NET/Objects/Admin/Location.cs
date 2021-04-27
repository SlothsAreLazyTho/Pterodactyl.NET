using System;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin
{
    public class Location
    {

        public int Id { get; set; }

        [JsonProperty("short")]
        public string ShortCode { get; set; }

        [JsonProperty("long")]
        public string Description { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
