using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin
{

    [DebuggerDisplay("{" + nameof(Description) + "}")]
    public partial class Egg
    {

        public int Id { get; set; }
        
        public string Uuid { get; set; }
        
        public int Nest { get; set; }

        public string Author { get; set; }
        
        public string Description { get; set; }

        [JsonProperty("docker_image")]
        public string DockerImage { get; set; }

        public EggConfig Config { get; set; }

        public string Startup { get; set; }

        public EggScript Script { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }

    public partial class EggConfig
    {
        public EggStartup Startup { get; set; }

        public string Stop { get; set; }

        public EggLogs Logs { get; set; }
    }

    public partial class EggLogs
    {
        [JsonProperty("custom")]
        public bool IsCustom { get; set; }

        public string Location { get; set; }
    }

    public class EggScript
    {
        [JsonProperty("privileged")]
        public bool IsPrivileged { get; set; }

        public string Install { get; set; }

        public string Entry { get; set; }

        public string Container { get; set; }
    }
    
    public class EggStartup
    {
        public string Done { get; set; }

        public string[] UserInteraction { get; set; }
    }
}
