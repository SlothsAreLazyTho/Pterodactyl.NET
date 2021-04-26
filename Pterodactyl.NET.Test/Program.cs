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
                user.ExternalId = null;
                user.Username = "SirSloth";
                user.FirstName = "Sir";
                user.LastName = "Sloth";
                user.Language = "de";
                user.Password = "SlotsAreLazyTho";
                user.IsRootAdmin = false;
            });

            Console.WriteLine($"Created the user {newUser.FirstName}...");
            var success = await pterodactyl.Admin.Users.DeleteUserAsync(newUser.Id);

            if(success)
            {
                Console.WriteLine($"Deleted the user {newUser.FirstName}...");
            }

            Debugger.Break();
        }
    }
}
