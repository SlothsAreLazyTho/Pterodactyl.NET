using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pterodactyl.NET.Endpoints;
using Pterodactyl.NET.Endpoints.V0_7;
using Pterodactyl.NET.Endpoints.V0_7.Admin;
using Pterodactyl.NET.Endpoints.V0_7.Client;
using Pterodactyl.NET.Objects;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

using System;
using System.Text.RegularExpressions;

namespace Pterodactyl.NET
{
    public class Pterodactyl
    {

        internal RestClient HttpClient { get; set; }

        
        
        public PterodactylV0_7 V0_7;

        public PterodactylV1_0 V1_0;

        public Pterodactyl(string hostname, string key)
        {
            if (key == null)
            {
                throw new Exception("No keys are provided. Provide at least a Client Key or Application Key");
            }

            var regex = new Regex("http(s?)://");
            var host = regex.Match(hostname).Success ? hostname : $"https://{hostname}/";

            HttpClient = new RestClient(host);
            HttpClient.UseSerializer<NewtonsoftSerializer>();
            HttpClient.AddDefaultHeader("Authorization", $"Bearer {key}");
            HttpClient.AddDefaultHeader("Accept", "Application/vnd.pterodactyl.v1+json");

            V0_7 = new PterodactylV0_7(HttpClient);
            V1_0 = new PterodactylV1_0(HttpClient);
        }
    }
}