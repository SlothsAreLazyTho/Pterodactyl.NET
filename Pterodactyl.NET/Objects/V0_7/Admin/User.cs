using System;
using System.Diagnostics;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V0_7.Admin
{
    [DebuggerDisplay("{" + nameof(Username) + "}")]
    public class User
    {

        public int Id { get; set; }

        
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }


        public string Uuid { get; set; }


        public string Username { get; set; }


        public string Email { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
       
        
        public string Language { get; set; }

        
        [JsonProperty("root_admin")]
        public bool IsRootAdmin { get; set; }


        [JsonProperty("2fa")]
        public bool Is2FA { get; set; }


        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }


        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
