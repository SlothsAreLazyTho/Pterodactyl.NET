using System;
using System.Text.RegularExpressions;

using Pterodactyl.NET.Endpoints.Client;
using Pterodactyl.NET.Exceptions;
using Pterodactyl.NET.Objects;

using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Pterodactyl.NET
{
    public class Pterodactyl
    {

        public Endpoints.Client.Endpoints Client { get; }

        public Endpoints.Client.Endpoints Admin { get; }

        internal readonly RestClient _client;

        public Pterodactyl(string hostname, string key)
        {
            var regex = new Regex("http(s?)://");
            var host = regex.Match(hostname).Success ? hostname : $"https://{hostname}/";
            
            _client = new RestClient(host);
            _client.UseSerializer<JsonNetSerializer>();


            if(key == null)
            {
                throw new PterodactylException("No keys are provided. Provide at least a Client Key or Application Key");
            }


            _client.AddDefaultHeader("Authorization", $"Bearer {key}");
            _client.AddDefaultHeader("Accept", "Application/vnd.pterodactyl.v1+json");
            
            this.Client = new Endpoints.Client.Endpoints(_client);
            this.Admin = new Endpoints.Client.Endpoints(_client);
        }

    }
}
