using System;
using System.Diagnostics;

using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Client.ServerAttributes;

namespace Pterodactyl.NET.Objects.Admin
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Server
    {

        public int Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        public string Uuid { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("suspended")]
        public bool IsSuspended { get; set; }

        public ServerLimits Limits { get; set; }

        public ServerFeatureLimits FeatureLimits { get; set; }

        public int User { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
