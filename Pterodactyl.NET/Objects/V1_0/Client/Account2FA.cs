using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Pterodactyl.NET.Objects.V1_0.Client
{

    /* Class had to be renamed to Account2FA As 2 is not a valid character of course. */
    public class Account2FA
    {

        [JsonProperty("image_url_data")]
        public string ImageUrlData { get; set; }
    }
}
