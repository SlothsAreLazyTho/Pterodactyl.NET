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
            var pterodactyl = new Pterodactyl("panel.ghservers.eu", adminKey);
            
            var users = await pterodactyl.Admin.Users.GetAllAsync(c => c.FirstName == "Chino");
            var user = users.FirstOrDefault();
            Console.WriteLine($"{user.FirstName} got created on {user.CreatedAt.ToString("G")}");

            var newUser = await pterodactyl.Admin.Users.CreateUserAsync(user =>
            {
                user.Email = "info@sirsloth.nl";
                user.ExternalId = "";
                user.FirstName = "Sir";
                user.LastName = "Sloth";
                user.Language = "nl";
                user.Password = "Sloth!?@#01";
                user.IsRootAdmin = false;
            });


            Debugger.Break();
        }
    }
}
