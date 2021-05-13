using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes.Options
{
    public class ServerDetailOptions
    {

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        public string Name { get; set; }

        public string User { get; set; }

        public string Description { get; set; }

    }
}
