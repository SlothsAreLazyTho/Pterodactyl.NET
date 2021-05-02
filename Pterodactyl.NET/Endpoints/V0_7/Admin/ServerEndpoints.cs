using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.V0_7.Admin;

using RestSharp;
using System;
using Pterodactyl.NET.Objects.V0_7.Admin.ServerAttributes;

namespace Pterodactyl.NET.Endpoints.V0_7.Admin
{
    public class ServerEndpoints : BaseEndpoint
    {
        internal ServerEndpoints(IRestClient client) : base(client)
        { }

        public async Task<PterodactylList<Server>> GetServersAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/servers");

            var response = await HandleArrayRequest<BaseAttributes<Server>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<Server>(list);
        }

        public async Task<PterodactylList<Server>> FindServersByExternalIdAsync(string externalId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/external/{externalId}");

            var response = await HandleArrayRequest<BaseAttributes<Server>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<Server>(list);
        }

        public async Task<PterodactylList<Server>> GetServersAsync(Func<Server, bool> func, CancellationToken token = default)
        {
            var servers = await GetServersAsync(token);

            var filtered = servers.Where(func);

            return new PterodactylList<Server>(filtered);
        }

        public async Task<PterodactylList<Server>> FindServersByEggIdAsync(int eggId, CancellationToken token = default)
        {
            return await GetServersAsync(server => server.EggId == eggId, token);
        }

        public async Task<PterodactylList<Server>> FindServersByUserIdAsync(int userId, CancellationToken token = default)
        {
            return await GetServersAsync(server => server.OwnerId == userId, token);
        }
        
        public async Task<PterodactylList<Server>> FindServerByEggIdAsync(int nodeId, CancellationToken token = default)
        {
            return await GetServersAsync(server => server.NodeId == nodeId, token);
        }

        public async Task<PterodactylList<Server>> FindServerByUserAsync(User user, CancellationToken token = default)
        {
            return await GetServersAsync(server => server.OwnerId == user.Id, token);
        }

        public async Task<Server> GetServerByIdAsync(int serverId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}");

            var response = await HandleRequest<Server>(request, token);

            return response;
        }

        public async Task<Server> CreateServerAsync(Action<ServerOptions> options, CancellationToken token = default)
        {
            var server = new ServerOptions();
            options.Invoke(server);

            var request = new RestRequest("/api/application/servers", Method.POST)
                .AddJsonBody(server);

            var response = await HandleRequest<Server>(request, token);

            return response;
        }

        public async Task<Server> CreateServerAsync(ServerOptions options, CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/servers", Method.POST)
                .AddJsonBody(options);

            var response = await HandleRequest<Server>(request, token);

            return response;
        }

        public async Task<bool> SuspendServerAsync(int serverId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/suspend", Method.POST);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> SuspendServerAsync(Server server, CancellationToken token = default)
        {
            return await SuspendServerAsync(server.Id, token);
        }

        public async Task<bool> UnsuspendServerAsync(int serverId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/unsuspend", Method.POST);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> UnsuspendServerAsync(Server server, CancellationToken token = default)
        {
            return await UnsuspendServerAsync(server.Id, token);
        }

        public async Task<bool> ReinstallServerAsync(int serverId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/reinstall", Method.POST);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> ReinstallServerAsync(Server server, CancellationToken token = default)
        {
            return await ReinstallServerAsync(server.Id, token);
        }

        public async Task<bool> RebuildServerAsync(int serverId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/rebuild", Method.POST);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> RebuildServerAsync(Server server, CancellationToken token = default)
        {
            return await RebuildServerAsync(server.Id, token);
        }

        public async Task<bool> DeleteServerAsync(int serverId, bool force, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}{(force ? "/force" : "")}", Method.POST);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteServerAsync(Server server, bool force, CancellationToken token = default)
        {
            return await DeleteServerAsync(server.Id, force, token);
        }

    }
}
