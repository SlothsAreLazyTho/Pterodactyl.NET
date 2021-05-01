using System;
using System.Collections.Generic;
using System.Text;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V1_0.Client
{
    public class ClientEndpoint
    {

        public ServerEndpoints Servers { get; }

        public AccountEndpoints Account { get; }

        public ClientEndpoint(IRestClient client)
        {
            Servers = new ServerEndpoints(client);
            Account = new AccountEndpoints(client);
        }

    }
}
