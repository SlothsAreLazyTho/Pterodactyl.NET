using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Pterodactyl.NET.Exceptions;

namespace Pterodactyl.NET.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Pterodactyl0_7("panel.sirsloth.nl", "Key");
            Debugger.Break();
        }

        static async Task Pterodactyl0_7(string host, string key)
        {
            var serverId = "64572892";

            var pterodactyl = new Pterodactyl(host, key);

            var server = await pterodactyl.V0_7.Client.Servers.FindServerByIdAsync(serverId);

            if (server == null)
            {
                throw new PterodactylException("Server not found.");
            }

            var success = await server.SendCommandAsync("help");

            if (success)
            {
                Console.WriteLine("Server successfully send command");
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
