using Newtonsoft.Json;

using Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes;

using System.Diagnostics;

namespace Pterodactyl.NET.Objects.V0_7.Client
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Server
    {

        public string Uuid { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("server_owner")]
        public bool IsOwner { get; set; }

        public ServerLimits Limits { get; set; }

        public ServerFeatureLimits FeatureLimits { get; set; }

    }
}
