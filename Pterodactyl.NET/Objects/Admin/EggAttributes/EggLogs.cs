using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
