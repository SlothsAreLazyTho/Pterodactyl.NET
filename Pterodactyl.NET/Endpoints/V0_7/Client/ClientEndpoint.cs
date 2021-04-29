using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7.Client
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
