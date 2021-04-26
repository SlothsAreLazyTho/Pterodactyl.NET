using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.Client.ServerAttributes;

namespace Pterodactyl.NET.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var key = Environment.GetEnvironmentVariable("Pterodactyl_ClientKey", EnvironmentVariableTarget.User);
            var adminKey = Environment.GetEnvironmentVariable("Pterodactyl_AdminKey", EnvironmentVariableTarget.User);
            var pterodactyl = new Pterodactyl("panel.ghservers.eu", key);
            var servers = await pterodactyl.Client.Servers.GetAllAsync();



            Debugger.Break();
        }
    }
}
