using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
