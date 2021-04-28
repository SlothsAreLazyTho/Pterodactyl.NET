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
            var key = Environment.GetEnvironmentVariable("Pterodactyl_ClientKey", EnvironmentVariableTarget.User);
            var adminKey = Environment.GetEnvironmentVariable("Pterodactyl_AdminKey", EnvironmentVariableTarget.User);
            var pterodactyl = new Pterodactyl("panel.ghservers.eu", adminKey);

            var server = await pterodactyl.Admin.Servers.GetServersAsync();
            var userId = server.First();
            var user = await pterodactyl.Admin.Users.FindUserByIdAsync(userId.Id);
            
            
            Console.WriteLine($"{user.Email} is the owner of the server \"{server.First().Name}\"");

            Debugger.Break();
        }
    }
}
