
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.V1_0.Client;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V1_0.Client
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

    }
}
