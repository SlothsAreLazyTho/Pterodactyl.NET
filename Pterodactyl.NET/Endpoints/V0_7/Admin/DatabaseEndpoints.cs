using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.V0_7.Admin;
using Pterodactyl.NET.Objects.V0_7.Admin.DatabaseAttributes;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7.Admin
{
    public class DatabaseEndpoints : BaseEndpoint
    {
        internal DatabaseEndpoints(IRestClient client) : base(client)
        { }


        public async Task<PterodactylList<Database>> GetDatabasesByIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{id}/databases");

            var response = await HandleArrayRequest<BaseAttributes<Database>>(request, token);

            var list = response.Select(rsp => rsp.Attributes);

            return new PterodactylList<Database>(list);
        }

        public async Task<IEnumerable<Database>> GetDatabasesByIdAsync(Server server, CancellationToken token = default)
        {
            return await GetDatabasesByIdAsync(server.Id, token);
        }

        public async Task<Database> FindDatabaseByIdAsync(int serverId, int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/databases/{id}");

            var response = await HandleRequest<Database>(request, token);

            return response;

        }

        public async Task<Database> FindDatabaseByIdAsync(Server server, int id, CancellationToken token = default)
        {
            return await FindDatabaseByIdAsync(server.Id, id, token);
        }

        public async Task<Database> CreateDatabaseAsync(int serverId, Action<DatabaseOptions> options, CancellationToken token = default)
        {
            var databaseOptions = new DatabaseOptions();
            options.Invoke(databaseOptions);

            var request = new RestRequest($"/api/application/servers/{serverId}/databases", Method.POST)
                .AddJsonBody(databaseOptions);

            var response = await HandleRequest<Database>(request, token);

            return response;
        }

        public async Task<Database> CreateDatabaseAsync(Server server, Action<DatabaseOptions> options, CancellationToken token = default)
        {
            return await CreateDatabaseAsync(server.Id, options, token);
        }

        public async Task<Database> CreateDatabaseAsync(int serverId, DatabaseOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/databases", Method.POST)
                 .AddJsonBody(options);

            var response = await HandleRequest<Database>(request, token);

            return response;
        }

        public async Task<Database> CreateDatabaseAsync(Server server, DatabaseOptions options, CancellationToken token = default)
        {
            return await CreateDatabaseAsync(server.Id, options, token);
        }

        public async Task<Database> RegeneratePasswordAsync(int serverId, int databaseId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/databases/{databaseId}/reset-password", Method.POST);

            var response = await HandleRequest<Database>(request, token);

            return response;
        }

        public async Task<Database> RegeneratePasswordAsync(Server server, int databaseId, CancellationToken token = default)
        {
            return await RegeneratePasswordAsync(server.Id, databaseId, token);
        }

        public async Task<Database> RegeneratePasswordAsync(Server server, Database database, CancellationToken token = default)
        {
            return await RegeneratePasswordAsync(server.Id, database.Id, token);
        }

        public async Task<Database> RegeneratePasswordAsync(int serverId, Database database, CancellationToken token = default)
        {
            return await RegeneratePasswordAsync(serverId, database.Id, token);
        }

        public async Task<bool> DeleteDatabaseAsync(int serverId, int databaseId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/servers/{serverId}/databases/{databaseId}", Method.DELETE);

            var response = await HandleRequestRawAsync(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteDatabaseAsync(Server server, int databaseId, CancellationToken token = default)
        {
            return await DeleteDatabaseAsync(server.Id, databaseId, token);
        }

        public async Task<bool> DeleteDatabaseAsync(Server server, Database database, CancellationToken token = default)
        {
            return await DeleteDatabaseAsync(server.Id, database.Id, token);
        }

        public async Task<bool> DeleteDatabaseAsync(int serverId, Database database, CancellationToken token = default)
        {
            return await DeleteDatabaseAsync(serverId, database.Id, token);
        }

    }
}
