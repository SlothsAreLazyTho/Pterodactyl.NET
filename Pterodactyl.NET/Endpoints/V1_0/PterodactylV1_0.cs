using Pterodactyl.NET.Endpoints.V1_0.Client;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.V0_7
{
    public class PterodactylV1_0
    {

        public ClientEndpoint Client;

        internal PterodactylV1_0(RestClient client)
        {
            Client = new ClientEndpoint(client);
        }

    }
}
