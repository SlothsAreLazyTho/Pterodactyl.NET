using System.Diagnostics;
using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Client.ServerAttributes;

namespace Pterodactyl.NET.Objects.Client
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Server
    {

        public string Uuid { get; set; }

        [JsonProperty("identifier")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("server_owner")]
        public bool IsOwner { get; set; }

        public ServerLimits Limits { get; set; }

        [JsonProperty("feature_limits")]
        public ServerFeatureLimits FeatureLimits { get; set; }

    }
}
