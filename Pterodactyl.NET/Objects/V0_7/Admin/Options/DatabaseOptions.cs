﻿using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Admin.DatabaseAttributes
{
    public class DatabaseOptions
    {

        [JsonProperty("database")]
        public string DatabaseName { get; set; }

        public string Remote { get; set; }

        public string Host { get; set; }

    }
}
