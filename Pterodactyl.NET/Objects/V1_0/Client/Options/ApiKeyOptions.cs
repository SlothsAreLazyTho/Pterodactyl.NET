using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V1_0.Client.Options
{
    public class ApiKeyOptions
    {

        public string Description { get; set; }

        [JsonProperty("allowed_ips")]
        public string[] AllowedIPs { get; set; }

    }
}
