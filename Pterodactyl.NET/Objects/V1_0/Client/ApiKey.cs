using System;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V1_0.Client
{
    public class ApiKey
    {

        public string Identifier { get; set; }
        
        public string Description { get; set; }

        public string[] AllowedIps { get; set; }

        [JsonProperty("last_used_at")]
        public DateTime LastUsedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
