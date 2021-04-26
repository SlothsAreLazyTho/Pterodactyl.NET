using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Newtonsoft;
using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Client.ServerAttributes;

using RestSharp;

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
