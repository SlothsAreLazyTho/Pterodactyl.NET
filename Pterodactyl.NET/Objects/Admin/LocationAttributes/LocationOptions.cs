using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin.LocationAttributes
{
    public class LocationOptions
    {

        [JsonProperty("short")]
        public string ShortCode { get; set; }

        [JsonProperty("long")]
        public string Description { get; set; }

    }
}
