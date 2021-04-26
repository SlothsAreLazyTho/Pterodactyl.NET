using System.Text.RegularExpressions;

using Pterodactyl.NET.Endpoints.Admin;
using Pterodactyl.NET.Endpoints.Client;
using Pterodactyl.NET.Exceptions;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Pterodactyl.NET
{
    public class Pterodactyl
    {

        internal readonly RestClient _client;


        public ClientEndpoint Client { get; }

        public AdminEndpoint Admin { get; }

        public Pterodactyl(string hostname, string key)
        {
            if (key == null)
            {
                throw new PterodactylException("No keys are provided. Provide at least a Client Key or Application Key");
            }

            var regex = new Regex("http(s?)://");
            var host = regex.Match(hostname).Success ? hostname : $"https://{hostname}/";

            _client = new RestClient(host);
            _client.UseSerializer<JsonNetSerializer>();
            _client.AddDefaultHeader("Authorization", $"Bearer {key}");
            _client.AddDefaultHeader("Accept", "Application/vnd.pterodactyl.v1+json");
            
            Client = new ClientEndpoint(_client);
            Admin = new AdminEndpoint(_client);
        }

    }
}
