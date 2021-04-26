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
