using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V1_0.Client
{

    [DebuggerDisplay("{" + nameof(Username) + "}")]
    public class Account
    {

        public int Id { get; set; }

        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        public string Username { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Language { get; set; }


    }
}
