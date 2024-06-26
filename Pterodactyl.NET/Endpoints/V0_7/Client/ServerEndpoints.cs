﻿using Pterodactyl.NET.Enum;
using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.V0_7.Client;
using Pterodactyl.NET.Objects.V0_7.Client.ServerAttributes;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pterodactyl.NET.Endpoints.V0_7.Client
{

    public class ServerEndpoints : BaseEndpoint
    {

        internal ServerEndpoints(IRestClient client) : base(client) 
        { }


        public async Task<PterodactylList<Server>> GetServersAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/client");
            
            var response = await HandleArrayRequest<BaseAttributes<Server>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<Server>(list);
        }

        public async Task<PterodactylList<Server>> GetServersAsync(Func<Server, bool> func, CancellationToken token = default)
        {
            var servers = await GetServersAsync(token);

            var list = servers.Where(func);

            return new PterodactylList<Server>(list);
        }

        public async Task<Server> FindServerAsync(Func<Server, bool> func, CancellationToken token = default)
        {
            var servers = await GetServersAsync(token);
            return servers.Where(func).FirstOrDefault();
        }

        public async Task<Server> FindServerByIdAsync(string id, CancellationToken token = default)
        {
            return await FindServerAsync(x => x.Identifier.Equals(id, StringComparison.CurrentCultureIgnoreCase), token);
        }

        public async Task<Server> FindServerByIdAsync(Server server, CancellationToken token = default)
        {
            return await FindServerByIdAsync(server.Identifier, token);
        }

        public async Task<ServerResource> GetServerResourceAsync(string id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/client/servers/{id}/utilization", Method.Get);
            
            var response = await HandleRequest<ServerResource>(request, token);

            return response;
        }

        public async Task<ServerResource> GetServerResourceAsync(Server server, CancellationToken token = default)
        {
            return await GetServerResourceAsync(server.Identifier, token);
        }

        public async Task<bool> SendCommandAsync(string id, string command, CancellationToken token = default)
        {
            var payload = new
            {
                Command = command
            };

            var request = new RestRequest($"/api/client/servers/{id}/command", Method.Post)
                .AddJsonBody(payload);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> SendCommandAsync(Server server, string command, CancellationToken token = default)
        {
            return await SendCommandAsync(server.Identifier, command, token);
        }

        public async Task<bool> SendPowerSignalAsync(string id, ServerRunState state, CancellationToken token = default)
        {
            var payload = new
            {
                Signal = state.ToString().ToLower()
            };

            var request = new RestRequest($"/api/client/servers/{id}/power", Method.Post)
                .AddJsonBody(payload);
            
            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> SendPowerSignalAsync(Server server, ServerRunState state, CancellationToken token = default)
        {
            return await SendPowerSignalAsync(server.Identifier, state, token);
        }

    }
}
