using Newtonsoft.Json;

using Pterodactyl.NET.Endpoints;
using Pterodactyl.NET.Enum;
using Pterodactyl.NET.Objects.Components;
using Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes;

using RestSharp;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Pterodactyl.NET.Objects.V0_7.Client
{

    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class Server
    {

        private readonly IRestClient _client;

        Server()
        {
            _client = Pterodactyl.Instance.HttpClient;
        }

        public string Uuid { get; set; }

        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonProperty("server_owner")]
        public bool IsOwner { get; set; }

        public Limits Limits { get; set; }

        public ServerFeatureLimits FeatureLimits { get; set; }



        public async Task<ServerResource> GetResourceAsync(CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/servers/{Identifier}/utilization", Method.GET);

            var response = await _client.ExecuteAsync<BaseAttributes<ServerResource>>(request, token);

            return response.Data.Attributes;
        }

        public async Task<bool> SendPowerSignalAsync(ServerRunState state, CancellationToken token = default)
        {
            var payload = new
            {
                Signal = state.ToString().ToLower()
            };

            var request = new RestRequest($"/api/client/servers/{Identifier}/power", Method.POST)
                .AddJsonBody(payload);

            var response = await _client.ExecuteAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> SendCommandAsync(string command, CancellationToken token = default)
        {
            var payload = new
            {
                Command = command
            };

            var request = new RestRequest($"/api/client/servers/{Identifier}/command", Method.POST)
                .AddJsonBody(payload);

            var response = await _client.ExecuteAsync(request, token);

            return response.IsSuccessful;
        }

        

    }
}
