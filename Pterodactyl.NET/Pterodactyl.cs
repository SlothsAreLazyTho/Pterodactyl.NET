using Pterodactyl.NET.Endpoints.V0_7;
using Pterodactyl.NET.Endpoints.V1_0;
using Pterodactyl.NET.Exceptions;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pterodactyl.NET
{
    public class Pterodactyl
    {

        internal RestClient HttpClient { get; set; }

        public static Pterodactyl Instance;

        public PterodactylV0_7 V0_7;
        public PterodactylV1_0 V1_0;

        public Pterodactyl(string hostname, string key)
        {
            if (key == null)
            {
                throw new Exception("No keys are provided. Provide at least a Client Key or Application Key");
            }

            if(hostname.Length <= 5)
            {
                throw new PterodactylException("Invalid host name set, Please set one.");
            }

            var regex = new Regex("http(s?)://");
            var host = regex.Match(hostname).Success ? hostname : $"https://{hostname}/";

            HttpClient = new RestClient(host);
            HttpClient.UseSerializer<NewtonsoftSerializer>();
            HttpClient.AddDefaultHeaders(new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {key}" },
                { "Accept", "Application/vnd.pterodactyl.v1+json" }
            });

            V0_7 = new PterodactylV0_7(HttpClient);
            V1_0 = new PterodactylV1_0(HttpClient);
            Instance = this;
        }

    }
}