using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Pterodactyl.NET.Exceptions;
using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.Client;
using Pterodactyl.NET.Objects.Client.ServerAttributes;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Client
{

    public class ServerEndpoints : BaseEndpoint
    {

        internal ServerEndpoints(IRestClient client) : base(client) 
        { }

        public async Task<IEnumerable<Server>> GetAllAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/client", Method.GET);
            var response = await _client.ExecuteAsync<BaseListResponse<BaseResponse<Server>>>(request, token).ConfigureAwait(false);

            /* Need to find a way for this but will be solved */
            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body.errors);
            }

            return response.Data.Data.Select(c => c.Attributes);
        }

        public async Task<IEnumerable<Server>> GetAllAsync(Func<Server, bool> func, CancellationToken token = default)
        {
            var servers = await GetAllAsync(token);
            return servers.Where(func);
        }
        
        public async Task<Server> GetServerByIdAsync(string id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/servers/{id}", Method.GET);
            var response = await _client.ExecuteAsync<BaseResponse<Server>>(request, token).ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body.errors);
            }

            return response.Data.Attributes;
        }
                
        public async Task<ServerResource> GetServerResource(string id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/servers/{id}/utilization", Method.GET);
            var response = await _client.ExecuteAsync<BaseResponse<ServerResource>>(request, token).ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body.errors);
            }

            return response.Data.Attributes;
        }

        public async Task<ServerResource> GetServerResource(Server server, CancellationToken token = default) => await GetServerResource(server.Id, token);

        public async Task<bool> SendCommandAsync(string id, string command, CancellationToken token = default)
        {
            var json = new Dictionary<string, string>() {
                { "command", command }
            };

            var request = new RestRequest($"/api/client/servers/{id}/command", Method.POST).AddJsonBody(json);
            var response = await _client.ExecuteAsync(request, token).ConfigureAwait(false);


            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body.errors);
            }

            return response.IsSuccessful;
        }

        public async Task<bool> SendCommandAsync(Server server, string command, CancellationToken token = default) => await SendCommandAsync(server.Id, command, token);

        public async Task<bool> SendPowerSignalAsync(string id, ServerRunState state, CancellationToken token = default)
        {
            var json = new Dictionary<string, string>() {
                { "signal", state.ToString().ToLower() }
            };

            var request = new RestRequest($"/api/client/servers/{id}/power", Method.POST).AddJsonBody(json);
            var response = await _client.ExecuteAsync(request, token).ConfigureAwait(false);

            if (!response.IsSuccessful)
            {
                var body = JsonConvert.DeserializeObject<BaseError>(response.Content);
                throw new PterodactylException(body.errors);
            }

            return response.IsSuccessful;
        }

        public async Task<bool> SendPowerSignalAsync(Server server, ServerRunState state, CancellationToken token = default) => await SendPowerSignalAsync(server.Id, state, token);

    }
}
