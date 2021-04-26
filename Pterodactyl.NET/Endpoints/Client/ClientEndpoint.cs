using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Client
{
    public class ClientEndpoint
    {

        public ServerEndpoints Servers { get; }



        public ClientEndpoint(IRestClient client)
        {
            Servers = new ServerEndpoints(client);
        }


    }
}
