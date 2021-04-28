using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Pterodactyl.NET.Objects;
using Pterodactyl.NET.Objects.Admin;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
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

    }
}
