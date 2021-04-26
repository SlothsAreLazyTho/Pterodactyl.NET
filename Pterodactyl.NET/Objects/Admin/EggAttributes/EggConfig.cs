using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Admin.EggAttributes
{
    public class EggConfig
    {
        
        public EggStartup Startup { get; set; }

        public string Stop { get; set; }

        public EggLogs Logs { get; set; }

    }
}
