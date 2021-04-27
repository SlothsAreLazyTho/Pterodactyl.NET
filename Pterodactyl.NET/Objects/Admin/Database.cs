using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Database
    {

        public int Id { get; set; }

        public int Server { get; set; }

        public int Host { get; set; }

        [JsonProperty("Database")]
        public string Name { get; set; }

        public string Username { get; set; }

        public string Remote { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
