﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Pterodactyl.NET.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Environment.GetEnvironmentVariable("Pterodactyl_ClientKey", EnvironmentVariableTarget.User);
            var adminKey = Environment.GetEnvironmentVariable("Pterodactyl_AdminKey", EnvironmentVariableTarget.User);
            var pterodactyl = new Pterodactyl("panel.ghservers.eu", adminKey);
            Debugger.Break();
        }
    }
}
