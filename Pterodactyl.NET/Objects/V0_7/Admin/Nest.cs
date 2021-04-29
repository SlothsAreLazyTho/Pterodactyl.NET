using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Admin
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Nest
    {

        public int Id { get; set; }

        public string Uuid { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
