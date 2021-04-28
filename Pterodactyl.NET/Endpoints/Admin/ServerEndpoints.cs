using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.Admin;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class ServerEndpoints : BaseEndpoint
    {
        internal ServerEndpoints(IRestClient client) : base(client)
        { }

        public async Task<IEnumerable<Server>> GetServersAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/servers");

            var response = await HandleRequest<BaseAttributes<List<Server>>>(request, token);

            return response.Data.Attributes;
        }

    }
}
