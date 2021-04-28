using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pterodactyl.NET.Endpoints.Admin;
using Pterodactyl.NET.Endpoints.Client;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

using System;
using System.Text.RegularExpressions;

namespace Pterodactyl.NET
{
    public class Pterodactyl
    {

        internal RestClient HttpClient { get; set; }
        
        internal JsonSerializer Serializer { get; set; }


        public ClientEndpoint Client { get; }
        public AdminEndpoint Admin { get; }

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

            Serializer = new JsonSerializer
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(false, false)
                }
            };

            Client = new ClientEndpoint(HttpClient);
            Admin = new AdminEndpoint(HttpClient);
        }

    }
}