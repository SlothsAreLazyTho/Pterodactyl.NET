using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.Client.ServerAttributes
{
    public class ServerContainer
    {

        [JsonProperty("startup_command")]
        public string StartupCommand { get; set; }

        public string Image { get; set; }

        public bool Installed { get; set; }

        //I didn't make values for the environment as its inpredictable to know what values will be there. This will be made in a next update or so

    }
}
