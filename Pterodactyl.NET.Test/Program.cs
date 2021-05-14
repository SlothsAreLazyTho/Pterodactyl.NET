using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using Pterodactyl.NET.Exceptions;

namespace Pterodactyl.NET.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Pterodactyl1_0("pterodactyl.app", "KeyHere");
            Debugger.Break();
        }

        static async Task Pterodactyl0_7(string host, string key)
        {
            var pterodactyl = new Pterodactyl(host, key);

            var servers = await pterodactyl.V0_7.Client.Servers.GetServersAsync();

            var server = servers[0];

            if (server == null)
            {
                throw new PterodactylException("Server not found.");
            }

            var resource = await server.GetResourceAsync();

            Console.WriteLine($"\nServer stats of {server.Name}");
            Console.WriteLine($"CPU: {resource.CPU.Current} / {resource.CPU.Limit}");
            Console.WriteLine($"Memory: {resource.Memory.Current} / {resource.Memory.Limit}");
            Console.WriteLine($"State: {resource.State}");
            Console.WriteLine($"Total Disk: {resource.Disk.Current} / {resource.Disk.Limit}");
        }

        static async Task Pterodactyl1_0(string host, string key)
        {
            var pterodactyl = new Pterodactyl(host, key);

            var account = await pterodactyl.V1_0.Client.Account.GetAccountAsync();

            Console.WriteLine($"\n Account of the user {account.Username}");
            Console.WriteLine($"\n Email: {account.Email}");
        }
    }
}
