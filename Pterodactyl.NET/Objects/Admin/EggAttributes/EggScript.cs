using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin.EggAttributes
{
    public class EggScript
    {

        [JsonProperty("privileged")]
        public bool IsPrivileged { get; set; }

        public string Install { get; set; }

        public string Entry { get; set; }

        public string Container { get; set; }

    }
}
