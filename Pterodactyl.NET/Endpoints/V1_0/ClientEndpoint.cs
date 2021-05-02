using Pterodactyl.NET.Endpoints.V1_0.Client;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V1_0
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
