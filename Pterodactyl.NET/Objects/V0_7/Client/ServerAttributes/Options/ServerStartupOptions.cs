using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes.Options
{
    public class ServerStartupParameters
    {

        public string Startup { get; set; }

        [JsonProperty("egg")]
        public int EggId { get; set; }

        [JsonProperty("pack")]
        public int PackId { get; set; }

        public string DockerImage { get; set; }

        [JsonProperty("skip_scripts")]
        public bool ShouldSkipScripts { get; set; }


    }
}
