
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.V0_7.Admin;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V1_0.Client
{
    public class ServerEndpoints : BaseEndpoint
    {

        internal ServerEndpoints(IRestClient client) : base(client)
        { }

    }
}
