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
            var pterodactyl = new Pterodactyl("panel.sirsloth.nl", "M1qRvWLv72FL2pwijzAJ0ycwM71S4ZFSLOXDSiRm1B814Ego");

            var account = await pterodactyl.V1_0.Client.Account.GetAccountAsync();

            Debugger.Break();


        }
    }
}
