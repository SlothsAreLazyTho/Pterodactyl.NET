using Pterodactyl.NET.Endpoints.V0_7.Client;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7
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
