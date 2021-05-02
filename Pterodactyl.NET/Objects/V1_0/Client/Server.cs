using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V1_0.Client
{
    public class Server
    {
        
        [JsonProperty("server_owner")]
        public bool IsOwner { get; set; }


    }

}
