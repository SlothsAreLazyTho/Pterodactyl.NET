using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Pterodactyl.NET.Objects.Admin.EggAttributes;

namespace Pterodactyl.NET.Objects.Admin
{
    public class Egg
    {

        public int Id { get; set; }
        
        public string Uuid { get; set; }
        
        public int Nest { get; set; }

        public string Author { get; set; }
        
        public string Description { get; set; }

        [JsonProperty("docker_image")]
        public string DockerImage { get; set; }

        public EggConfig Config { get; set; }

        public string Startup { get; set; }

        public EggScript Script { get; set; }

        [JsonProperty("Created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
