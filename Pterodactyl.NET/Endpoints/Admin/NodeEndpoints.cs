using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class NodeEndpoints : BaseEndpoint
    {
        internal NodeEndpoints(IRestClient client) : base(client)
        { }
    }
}
