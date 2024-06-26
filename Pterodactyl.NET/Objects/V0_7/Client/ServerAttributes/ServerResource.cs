﻿using Pterodactyl.NET.Enum;
using Pterodactyl.NET.Objects.Components;

namespace Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes
{

    public class ServerResource
    {

        public ServerRunningState State { get; set; }

        public Memory Memory { get; set; }

        public Cpu CPU { get; set; }

        public Disk Disk { get; set; }

    }
}
