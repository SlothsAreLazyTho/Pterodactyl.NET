using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Pterodactyl.NET.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var pterodactyl = new Pterodactyl("panel.sirsloth.nl", "");
            Debugger.Break();
        }
    }
}
