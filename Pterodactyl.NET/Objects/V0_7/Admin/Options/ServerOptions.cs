using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Components;
using Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes;

namespace Pterodactyl.NET.Objects.V0_7.Admin.ServerAttributes
{
    public class ServerOptions
    {

        public string Name { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        [JsonProperty("egg")]
        public int EggId { get; set; }

        [JsonProperty("docker_image")]
        public string DockerImage { get; set; }

        public Limits Limits { get; set; }

        [JsonProperty("feature_limits")]
        public ServerFeatureLimits FeatureLimits { get; set; }

    }
}