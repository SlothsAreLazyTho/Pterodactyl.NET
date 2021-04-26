using Pterodactyl.NET.Objects.Client.ServerAttributes.ServerComponents;

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
