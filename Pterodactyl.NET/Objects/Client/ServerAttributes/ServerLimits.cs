using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pterodactyl.NET.Objects.Client.ServerAttributes
{
    public class ServerLimits
    {

        public long Memory { get; set; }

        public long Swap { get; set; }

        public long Disk { get; set; }

        public long IO { get; set; }

        public long CPU { get; set; }

    }
}
