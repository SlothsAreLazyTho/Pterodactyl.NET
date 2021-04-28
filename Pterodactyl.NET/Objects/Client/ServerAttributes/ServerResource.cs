using Pterodactyl.NET.Objects.Components;

namespace Pterodactyl.NET.Objects.Client.ServerAttributes
{
    public class ServerResource
    {

        public ServerRunningState State { get; set; }

        public Memory Memory { get; set; }

        public Cpu Cpu { get; set; }

        public Disk Disk { get; set; }

    }
}
