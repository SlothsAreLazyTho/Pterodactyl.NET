using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin.EggAttributes
{
    public class EggLogs
    {

        [JsonProperty("custom")]
        public bool IsCustom { get; set; }

        public string Location { get; set; }

    }
}
