using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Admin.UserAttributes
{
    public class UserOptions
    {

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Password { get; set; }

        [JsonProperty("root_admin")]
        public bool IsRootAdmin { get; set; }

        public string Language { get; set; }


    }
}
